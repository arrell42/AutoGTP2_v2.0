using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        public ServiceHelper ServiceCreateManualQuantityMinus(ProjectData projectName, ServiceData serviceData)
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

        public ServiceHelper ServiceDeleteConfirm(ProjectData projectName, ServiceData serviceData)
        {
            manager.Services.ServiceManualCorrectQuantity(projectName, serviceData);
            EditButtonClick();
            ServiceDeleteButtonClick();
            ServiceDeleteConfirmButtonClick();
            return this;
        }

        public ServiceHelper ServiceDeleteDecline(ProjectData projectName, ServiceData serviceData)
        {
            manager.Services.ServiceManualCorrectQuantity(projectName, serviceData);
            EditButtonClick();
            ServiceDeleteButtonClick();
            ServiceDeleteDeclineButtonClick();
            return this;
        }





        // Низкоуровневые методы

        public bool ServiceIsCalculated()
        {
            return driver.FindElements(By.XPath("//div[@class = 'service-card undefined']")).Count > 0;
        }

        public bool ServiceIsNotCalculated()
        {
            return driver.FindElements(By.XPath("//div[@class = 'service-card withRed']")).Count > 0;
        }

        public ServiceHelper ServiceDeleteConfirmButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'TcMMo6iDjW2Wg_KudxB2 WwSFVDblp_mIPZp2ZJYT']")).Click();
            return this;
        }

        public ServiceHelper EditButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_OPEN_AND_EDIT")).Click();
            return this;
        }

        public ServiceHelper ServiceDeleteButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_DELETE")).Click();
            return this;
        }
        public ServiceHelper ServiceDeleteDeclineButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'TcMMo6iDjW2Wg_KudxB2 nbJ_lQ3s5whrR3I5IMAA']")).Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w jCJKDwoHxJL_65eHEGC4']"));
            return this;
        }
        public bool WarningOverlayIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w jCJKDwoHxJL_65eHEGC4']"));
        }

        public string QuantityTextValue()
        {
            return driver.FindElement(By.XPath("//p[contains(text(), 'Quantity')]/following-sibling::p")).Text;
        }

        public ServiceHelper OpenNewProject(ProjectData projectName)
        {
            manager.Navigator.GoToProjectPage();
            manager.Projects.NewProjectButtonClick();
            manager.Projects.EnterProjectName(projectName);
            return this;
        }

        public bool PlugItemIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'plug-item']"));
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
            //WaitUntilFindElement(10, By.Id("SERVICE_SOURCE_LANG_0"));
            Thread.Sleep(200);
            driver.FindElement(By.Id("SERVICE_SOURCE_LANG_2")).Click();
            return this;
        }        

        public ServiceHelper SelectTargetLanguage()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();
            //WaitUntilFindElement(10, By.Id("SERVICE_TARGET_LANG_0"));
            Thread.Sleep(200);
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
            WaitUntilFindElement(10, By.XPath("//div[@class = 'services-list']"));
            return this;
        }

        
    }
}
