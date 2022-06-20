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
        public object TimeUnit { get; private set; }

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        
        //Высокоуровневые методы
        public void Login(LoginData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//a[@id='MENU_LOGOUT']/div/p"));
        }

        public bool IsLoggedIn(LoginData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.XPath("//a[@id='MENU_LOGOUT']/div/p"))
                .FindElement(By.Id("MENU_ADMINISTRATION")).Displayed;
        }

        public void Logout()
        {
            driver.FindElement(By.XPath("//a[@id='MENU_LOGOUT']/div/p")).Click();
        }

        public void CorrectAuth(LoginData newData)
        {
            EnterUsername(newData);
            EnterPassword(newData);
            SignInButtonClick();            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => driver.FindElement(By.Id("MENU_LOGOUT")));
            driver.FindElement(By.Id("MENU_LOGOUT")).Click();
            wait.Until(driver => driver.FindElement(By.Id("LOGIN_FORM_BUTTON")));
            driver.Navigate().Refresh();

        }

        public void IncorrectAuth(LoginData newData)
        {
            EnterUsername(newData);
            EnterPassword(newData);
            SignInButtonClick();            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@class='__floater __floater__open']")));
            driver.Navigate().Refresh();

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
