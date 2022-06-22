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
    public class ServiceHelper : HelperBase
    {
        public ServiceHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ServiceHelper CreateService(ProjectData projectData)
        {
            manager.Navigator.GoToProjectPage();
            manager.Project.NewProjectButtonClick();
            manager.Project.EnterProjectName(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity();
            //SourceFileLoad();
            SaveServiceButtonClick();
            return this;
        }

        
        // Низкоуровневые методы
        public ServiceHelper CreateServiceButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_CREATE_SERVICE")).Click();
            return this;
        }

        public ServiceHelper SelectSourceLanguage()
        {
            driver.FindElement(By.Name("SERVICE_SOURCE_LANG")).Click();
            driver.FindElement(By.Id("SERVICE_SOURCE_LANG_2")).Click();            
            return this;
        }

        public ServiceHelper SelectTargetLanguage()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();            
            driver.FindElement(By.Id("SERVICE_TARGET_LANG_1")).Click();            
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
        public ServiceHelper SourceFileLoad()
        {
            driver.FindElement(By.Id("FILE_LOADER")).Click();            
            return this;
        }

        public ServiceHelper SaveServiceButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_SAVE")).Click();
            return this;
        }
    }
}
