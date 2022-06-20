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
    public class NavigationHelper : HelperBase
    {        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {            
            this.baseURL = baseURL;
        }
        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToBudgetPage()
        {
            driver.FindElement(By.Id("MENU_BUDGETS")).Click();
        }

        public void GoToProjectPage()
        {
            driver.FindElement(By.Id("MENU_PROJECTS")).Click();
        }
    }
}
