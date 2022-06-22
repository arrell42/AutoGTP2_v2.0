using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoGTP2Tests
{
    public class LoginHelper : HelperBase
    {
        //public object TimeUnit { get; private set; }

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        
        //Высокоуровневые методы
        public void Login(LoginData account)
        {
            if (IsLoggedIn())
            {
                return;
            }
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("MENU_LOGOUT")));
        }

        public void CorrectLogin(LoginData account)
        {
            if (IsLoggedIn())
            {
                Logout();
            }
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("MENU_LOGOUT")));
        }

        // для проверки некорректных данных
        public void IncorrectLogin(LoginData account)
        {
            if (IsLoggedIn())
            {
                Logout();
            }
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@class = '__floater __floater__open']")));
            driver.Navigate().Refresh();
        }


        public bool IsLoggedIn()
        {            
            return IsElementPresent(By.Id("MENU_LOGOUT"));
        }                

        public void Logout()
        {
            if (IsLoggedIn())
            { 
            driver.FindElement(By.Id("MENU_LOGOUT")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("LOGIN_FORM_BUTTON")));
            }
        }

        //Низкоуровневые методы

        private void SignInButtonClick()
        {
            driver.FindElement(By.Id("LOGIN_FORM_BUTTON")).Click();
        }

        private void EnterPassword(LoginData account)
        {
            driver.FindElement(By.Id("LOGIN_FORM_PASSWORD")).Click();
            driver.FindElement(By.Id("LOGIN_FORM_PASSWORD")).Clear();
            driver.FindElement(By.Id("LOGIN_FORM_PASSWORD")).SendKeys(account.Password);
        }

        private void EnterUsername(LoginData account)
        {
            driver.FindElement(By.Id("LOGIN_FORM_USERNAME")).Click();
            driver.FindElement(By.Id("LOGIN_FORM_USERNAME")).Clear();
            driver.FindElement(By.Id("LOGIN_FORM_USERNAME")).SendKeys(account.Username);
        }
    }
}
