using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace AutoGTP2Tests
{
    public class ServiceHelper : HelperBase
    {
        public ServiceHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ServiceHelper CreateService(ProjectData projectName)
        {
            manager.Navigator.GoToProjectPage();
            manager.Project.NewProjectButtonClick();
            manager.Project.EnterProjectName(projectName);
            CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectQuantityTypeManual();
            EnterQuantity();            
            SaveServiceButtonClick();
            manager.Project.SaveProjectButtonClick();
            return this;
        }

        
        // Низкоуровневые методы
        public ServiceHelper CreateServiceButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_CREATE_SERVICE")).Click();
            return this;
        }

        public ServiceHelper SelectSourceLanguage(string indexValue)
        {
            driver.FindElement(By.Name("SERVICE_SOURCE_LANG")).Click();
            WaitUntilItemFind(10, By.Id("SERVICE_SOURCE_LANG_0"));
            LanguageFind(indexValue);
            return this;
        }

        

        public ServiceHelper SelectTargetLanguage(string indexValue)
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();
            WaitUntilItemFind(10, By.Id("SERVICE_TARGET_LANG_0"));            
            LanguageFind(indexValue);
            return this;
        }

        public ServiceHelper SelectQuantityTypeManual()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TYPE']")).Click();
            driver.FindElement(By.XPath("//p[@title = 'Manual']")).Click();            
            return this;
        }
        public ServiceHelper EnterQuantity()
        {
            driver.FindElement(By.Id("SERVICE_MANUAL_QUANTITY")).Click();
            driver.FindElement(By.Id("SERVICE_MANUAL_QUANTITY")).Clear();
            driver.FindElement(By.Id("SERVICE_MANUAL_QUANTITY")).SendKeys("100");
            return this;
        }
        
        public ServiceHelper SaveServiceButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_SAVE")).Click();
            return this;
        }

        
    }
}
