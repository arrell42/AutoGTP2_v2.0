using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Globalization;
using System.IO;

namespace AutoGTP2Tests
{
    public class ServiceHelper : BaseHelper
    {
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        public ServiceHelper(ApplicationManager manager) : base(manager)
        {
        }
                

        // Основные методы
        public ServiceHelper ServiceManualCorrectQuantity(ProjectData projectData, ServiceData serviceData)
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

        public ServiceHelper ServiceCancelButton(ProjectData projectData, ServiceData serviceData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            ServiceCancelButtonClick();            
            return this;
        }

        public ServiceHelper ServiceCreateManualQuantityWord(ProjectData projectData, ServiceData serviceData)
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

        public ServiceHelper ServiceCreateManualQuantityZeroFirst(ProjectData projectData, ServiceData serviceData)
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

        public ServiceHelper ServiceDeleteConfirm(ProjectData projectData, ServiceData serviceData)
        {
            manager.Services.ServiceManualCorrectQuantity(projectData, serviceData);
            EditButtonClick();
            ServiceDeleteButtonClick();
            ServiceDeleteConfirmButtonClick();
            return this;
        }
        
        public ServiceHelper ServiceDeleteDecline(ProjectData projectData, ServiceData serviceData)
        {
            manager.Services.ServiceManualCorrectQuantity(projectData, serviceData);
            EditButtonClick();
            ServiceDeleteButtonClick();
            ServiceDeleteDeclineButtonClick();
            return this;
        }        

        public ServiceHelper ServiceCreateAutoCount(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeAuto();
            SourceFileAttach();
            ServiceSaveButtonClick();            
            return this;
        }

        
        public int QuantityPriceMultiplication()
        {
           // if (LanguagePairsTableIsHidden())
           // {
           //     driver.FindElement(By.Id("SHOW_LANGUAGE_PAIRS")).Click();
           // }
            string a = driver.FindElement(By.XPath("//div[@class = 'row']/div/p[@class = 'GxpMAeiU_LKN4yZsTEhL']")).Text;
            string b = driver.FindElement(By.XPath("//div[@class = 'row']/div/p[@class = 'GxpMAeiU_LKN4yZsTEhL']")).Text;
            double c = double.Parse(a, formatter);
            double d = double.Parse(b, formatter);
            double i = c * d;            
            return (int)i;
        }

        
        public int ServiceCostValueTextInTable()
        {
          //  if (LanguagePairsTableIsHidden())
           // {
           //     driver.FindElement(By.Id("SHOW_LANGUAGE_PAIRS")).Click();
           // }
            string a = driver.FindElement(By.XPath("//p[@class = 'cost-row']")).Text;
            double i = double.Parse(a, formatter);
            return (int)i;
        }

        public bool LanguagePairsTableIsHidden()
        {
            return IsElementPresent(By.XPath("//div[@class = 'language-pairs-table hidden']"));
        }

        public ServiceHelper ServiceAutoCountRequestQuote(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeAuto();
            SourceFileAttach();
            ServiceSaveButtonClick();
            RequestQuoteButtonClick();
            return this;
        }

        public ServiceHelper ServiceCreateCATLog(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            ServiceSaveButtonClick();
            return this;
        }

        public ServiceHelper ServiceAutoCountDownloadSourceFile(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage();
            SelectQuantityTypeAuto();
            SourceFileAttach();
            Thread.Sleep(200);
            SourceFileDownloadButtonClick();
            Thread.Sleep(4000);
            return this;
        }

        public ServiceHelper SourceFileDownloadButtonClick()
        {
            driver.FindElement(By.Id("FILE_DOWNLOAD")).Click();
            return this;
        }



        // Низкоуровневые методы

        public ServiceHelper SelectQuantityTypeCATLog()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TYPE']")).Click();
            driver.FindElement(By.XPath("//p[@title = 'CAT log file']")).Click();
            return this;
        }

        public ServiceHelper SelectCATToolMemoQ()
        {
            driver.FindElement(By.Name("SERVICE_CAT_DROP")).Click();
            WaitUntilFindElement(10, By.Id("SERVICE_CAT_DROP_2"));
            driver.FindElement(By.Id("SERVICE_CAT_DROP_2")).Click();
            return this;
        }

        public ServiceHelper UploadCATFile()
        {
            driver.FindElement(By.Id("SERVICE_CAT_FILES_UPLOAD")).SendKeys(manager.CATLogFilePath);
            Thread.Sleep(200);
            WaitUntilElementIsHide(10, By.XPath("//span[@class = 'hRFbZ85DzhNaXfrQ_8Uv']"));
            return this;
        }

        public int ServiceCostValueText()
        {
            string a = driver.FindElement(By.XPath("//div[@class = 'cost']//p[@class = 'value']/span")).Text;
            double i = double.Parse(a, formatter);
            return (int)i;
        }
        public string TotalAmountText()
        {
            return driver.FindElement(By.XPath("//p[@class = 'Fv5Fpk811wD6hYa_DGHS']")).Text;
        }

        public bool ServiceEditButtonIsPresent()
        {
            return driver.FindElements(By.Id("SERVICE_OPEN_AND_EDIT")).Count >= 1;
        }

        public bool ServiceStatisticsButtonIsPresent()
        {
            return driver.FindElements(By.Id("SERVICE_CAT_STATISTIC")).Count >= 1;
        }

        public ServiceHelper SourceFileAttach()
        {
            driver.FindElement(By.Id("FILE_LOADER")).SendKeys(manager.sourceFilePath);
            WaitUntilFindElement(10, By.Id("FILE_DOWNLOAD"));
            return this;
        }
        public ServiceHelper RequestQuoteButtonClick()
        {
            driver.FindElement(By.Id("requestQuote")).Click();
            WaitUntilFindElement(10, By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']"));
            WaitUntilElementIsHide(30, By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']"));
            return this;
        }
        public ServiceHelper SelectQuantityTypeAuto()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TYPE']")).Click();
            driver.FindElement(By.XPath("//p[@title = 'Auto']")).Click();
            return this;
        }

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

        public ServiceHelper OpenNewProject(ProjectData projectData)
        {
            manager.Navigator.GoToProjectPage();
            manager.Projects.NewProjectButtonClick();
            manager.Projects.EnterProjectName(projectData);
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
            Thread.Sleep(200);
            driver.FindElement(By.Id("SERVICE_SOURCE_LANG_2")).Click();
            return this;
        }        

        public ServiceHelper SelectTargetLanguage()
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();            
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
