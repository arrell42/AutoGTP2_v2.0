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
    public class ProjectHelper : HelperBase
    {   
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        //Высокоуровневые методы
        public ProjectHelper CreateProject()
        {
            manager.Navigator.GoToProjectPage();
            NewProjectButtonClick();
            EnterProjectName();
            SaveButtonClick();
            //ждем пока исчезнет всплывающее окно с проектом
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.Id("PROJECT_CARD_SAVE_AND_EXIT")).Count == 0);
            return this;
        }

        //Низкоуровневые методы
        public ProjectHelper SaveButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_SAVE_AND_EXIT")).Click();
            return this;
        }

        public ProjectHelper EnterProjectName()
        {
            driver.FindElement(By.Id("PROJECT_CARD_NAME")).Click();
            driver.FindElement(By.Id("PROJECT_CARD_NAME")).Clear();
            driver.FindElement(By.Id("PROJECT_CARD_NAME")).SendKeys("Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest");
            return this;
        }

        public ProjectHelper NewProjectButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_NEW_PROJECT_BUTTON")).Click();
            return this;
        }
    }
}
