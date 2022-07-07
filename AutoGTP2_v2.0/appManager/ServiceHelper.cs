using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutoGTP2Tests
{
    public class ServiceHelper : BaseHelper
    {
        public ServiceHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ServiceHelper ServiceManualCorrectQuantity(ProjectData projectName, ServiceData serviceData)
        {
            OpenNewProject(projectName);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            ServiceSaveButtonClick();            
            return this;
        }

        public ServiceHelper ServiceCancelButton(ProjectData projectName, ServiceData serviceData)
        {
            OpenNewProject(projectName);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            ServiceCancelButtonClick();            
            return this;
        }

        public ServiceHelper ServiceCreateManualQuantityWord(ProjectData projectName, ServiceData serviceData)
        {
            OpenNewProject(projectName);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            ServiceSaveButtonClick();
            return this;
        }

        public string QuantityTextValue()
        {
            return driver.FindElement(By.XPath("//p[contains(text(), 'Quantity')]/following-sibling::p")).Text;            
        }

        public ServiceHelper ServiceCreateManualQuantityZeroFirst(ProjectData projectName, ServiceData serviceData)
        {
            OpenNewProject(projectName);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            ServiceSaveButtonClick();
            return this;
        }

        public ServiceHelper ServiceCreateManualQuantityMinus(ProjectData projectData, ServiceData serviceData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            ServiceSaveButtonClick();
            return this;
        }




        // Низкоуровневые методы

        public ServiceHelper OpenNewProject(ProjectData projectName)
        {
            manager.Navigator.GoToProjectPage();
            manager.Projects.NewProjectButtonClick();
            manager.Projects.EnterProjectName(projectName);
            return this;
        }

        public bool CreateButtonIsPresent()
        {
            return IsElementPresent(By.Id("PROJECT_CARD_CREATE_SERVICE"));
        }

        private void ServiceCancelButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_CANCEL")).Click();            
        }

        public ServiceHelper CreateServiceButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_CREATE_SERVICE")).Click();
            return this;
        }

        public ServiceHelper SelectSourceLanguage()
        {
            driver.FindElement(By.Name("SERVICE_SOURCE_LANG")).Click();
            WaitUntilFindElement(10, By.Id("SERVICE_SOURCE_LANG_0"));
            driver.FindElement(By.Id("SERVICE_SOURCE_LANG_2")).Click();
            return this;
        }

        

        public ServiceHelper SelectTargetLanguage()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();
            WaitUntilFindElement(10, By.Id("SERVICE_TARGET_LANG_0"));
            driver.FindElement(By.Id("SERVICE_TARGET_LANG_1")).Click();
            return this;
        }

        public ServiceHelper SelectQuantityTypeManual()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TYPE']")).Click();
            driver.FindElement(By.XPath("//p[@title = 'Manual']")).Click();            
            return this;
        }
        public ServiceHelper EnterQuantity(ServiceData serviceData)
        {
            driver.FindElement(By.Id("SERVICE_MANUAL_QUANTITY")).Click();
            driver.FindElement(By.Id("SERVICE_MANUAL_QUANTITY")).Clear();
            driver.FindElement(By.Id("SERVICE_MANUAL_QUANTITY")).SendKeys(serviceData.Quantity);
            return this;
        }
        
        public ServiceHelper ServiceSaveButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_SAVE")).Click();
            WaitUntilFindElement(10, By.Id("PROJECT_CARD_CREATE_SERVICE"));
            return this;
        }

        
    }
}
