using OpenQA.Selenium;
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
            SelectTargetLanguage(1);
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            SaveServiceButtonClick();            
            return this;
        }                

        public ServiceHelper ServiceCancelButton(ProjectData projectData, ServiceData serviceData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
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
            SelectTargetLanguage(1);
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            SaveServiceButtonClick();
            return this;
        }
        public ServiceHelper ServiceCreateManualQuantityZeroFirst(ProjectData projectData, ServiceData serviceData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper ServiceCreateManualQuantityMinus(ProjectData projectData, ServiceData serviceData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper ServiceDeleteConfirm(ProjectData projectData, ServiceData serviceData)
        {
            manager.Services.ServiceManualCorrectQuantity(projectData, serviceData);
            OpenAndEditButtonClick();
            ServiceDeleteButtonClick();
            ServiceDeleteConfirmButtonClick();
            return this;
        }
        
        public ServiceHelper ServiceDeleteDecline(ProjectData projectData, ServiceData serviceData)
        {
            manager.Services.ServiceManualCorrectQuantity(projectData, serviceData);
            OpenAndEditButtonClick();
            ServiceDeleteButtonClick();
            ServiceDeleteDeclineButtonClick();
            return this;
        }        

        public ServiceHelper ServiceCreateAutoCount(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeAuto();
            SourceFileAttach();
            SaveServiceButtonClick();
            SourceFileClick();
            return this;
        }


        public ServiceHelper ServiceAutoCountRequestQuote(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeAuto();
            SourceFileAttach();
            SaveServiceButtonClick();
            RequestQuoteButtonClick();
            return this;
        }

        public ServiceHelper ServiceCreateCATLog(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper DownloadSourceFileFromEditPage(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeAuto();
            SourceFileAttach();
            Thread.Sleep(200);
            SaveServiceButtonClick();
            OpenAndEditButtonClick();
            SourceFileInServiceEditPageDownloadButtonClick();            
            return this;
        }

        public ServiceHelper DownloadSourceFileFromServiceList(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeAuto();
            SourceFileAttach();
            Thread.Sleep(200);
            SaveServiceButtonClick();            
            SourceFileInServiceListDownloadButtonClick();            
            return this;
        }

        public ServiceHelper DownloadCATLogFile(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            OpenAndEditButtonClick();
            CATFileDownloadButtonClick();
            return this;
        }

        public ServiceHelper SourceFileRemove(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeAuto();
            SourceFileAttach();
            Thread.Sleep(200);
            SaveServiceButtonClick();
            OpenAndEditButtonClick();            
            SourceFileRemoveButtonClick();
            return this;
        }

        public ServiceHelper ServiceCATLogWithOutCATFile(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();            
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper ServiceCATLogWithOutCATFileContinueButton(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            SaveServiceButtonClick();
            WarningContinueButtonClick();
            return this;
        }        

        public ServiceHelper ServiceCATLogWithOutCATFileCancelButton(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            SaveServiceButtonClick();
            WarningCancelButtonClick();
            return this;
        }        

        public ServiceHelper UploadInvalidSourceFile(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeAuto();
            InvalidSourceFileAttach();
            BackToProjectButtonClick();
            ExclamationClick();
            BackToProjectButtonClick();
            CircleNextToTheFileClick();
            return this;
        }

        public ServiceHelper ServiceCreateManualQuantitySymbols(ProjectData projectData, ServiceData serviceData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeManual();
            EnterQuantity(serviceData);
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper OpenStatisticInCATService(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            StatisticButtonClick();
            return this;
        }

        public ServiceHelper AddAndDeleteCATFile(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            OpenAndEditButtonClick();
            CATFileDeleteButtonClick();
            return this;
        }

        public ServiceHelper CATFileDeleteAndSaveService(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            OpenAndEditButtonClick();
            CATFileDeleteButtonClick();
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper NewServiceWithCATCreate(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            MouseClickAndHoldImitation(By.XPath(
                "//div[@class = 'react-dropdown-select cat-tool-dropdown css-1jmlu6t-ReactDropdownSelect e1gzf2xs0']"));
            Thread.Sleep(200);
            return this;
        }

        public ServiceHelper ServiceWithoutLanguagePairCreate(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectQuantityTypeCATLog();
            SelectCATToolMemoQ();
            UploadCATFile();
            SaveServiceButtonClick();
            OpenAndEditButtonClick();
            CATFileDeleteButtonClick();
            SaveServiceButtonClick();
            WarningContinueButtonClick();
            TargetLanguageDelete();
            SelectQuantityTypeAuto();
            SaveServiceButtonClick();
            return this;
        }

        public ServiceHelper ChangeDefaultTypeOfSerice(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectTypeOfService();            
            return this;
        }

        public ServiceHelper ChangeDefaultTypeOfSericeAndSelectUnit(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectTypeOfService();
            SelectUnit();
            return this;
        }

        public ServiceHelper SecondSelectSubjectAreaInService(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSubjectArea(1);
            SelectSourceLanguage();
            SelectTargetLanguage(1);
            SelectSubjectArea(2);
            return this;
        }

        public ServiceHelper CreateServiceWithTwoLanguagePairs(ProjectData projectData)
        {
            OpenNewProject(projectData);
            CreateServiceButtonClick();
            SelectSubjectArea(1);
            SelectSourceLanguage();
            SelectTargetLanguage(1);            
            SelectTargetLanguage(2);
            MouseClickImitation(By.XPath("//p[@class = 'RWdtSGyL9LH9qs2LKXGO']"));
            SourceFileAttach();
            return this;
        }


        














        // проверка на скачанный файл
        public bool CheckFileDownloaded(ServiceData filename)
        {
            bool exist = false;
            string downloadPath = Path.Combine(Syroot.Windows.IO.KnownFolders.Downloads.Path);
            string[] filePaths = Directory.GetFiles(downloadPath);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename.FileName))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p); //удаление файла после проверки
                    break;
                }
            }
            return exist;
        }








        // Низкоуровневые методы


        public bool SourceFileTableIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'glPRJNnEF2QbMnC0ZqIX  ']"));
        }

        public bool FileNameIsPresentAndCorrect()
        {
            string text = driver.FindElement(By.XPath(
                "//div[@class = 'FnH8t9fP06da_3Fkcw7A obJCzZBibf9su26s0UsA ']//div[@class = 'CjLCnWG2I76az0SPKDXC'][1]")).Text;
            if (text.Contains("SourceTest"))
            {
                return true;
            }
            return false;
        }

        public bool LanguagePairsFieldIsEmpty()
        {
            string text = driver.FindElement(By.Id("LANGUAGE_PAIRS_DROPDOWN")).Text;
            if (text.Contains("Select 1 or more language pairs for this source file"))
            {
                return true;
            }
            return false;
        }

        public bool ActionColumnHaveButtons()
        {
            return driver.FindElements(By.XPath("//div[@class = 'gTsUe9gPzJ3OctS7grJU']")).Count == 3;
        }


        public ServiceHelper SelectSubjectArea(int i)
        {
            driver.FindElement(By.XPath("//div[@id = 'SERVICE_SUBJECT_AREA']//div")).Click();
            WaitUntilFindElement(4, By.Id("SERVICE_SUBJECT_AREA_OPTION_" + i + ""));
            driver.FindElement(By.Id("SERVICE_SUBJECT_AREA_OPTION_" + i + "")).Click();
            return this;
        }

        public bool LanguagesFieldsAreEmpty()
        {
            string text1 = driver.FindElement(By.XPath(
                "//input[@class = 'react-dropdown-select-input css-ipe0e3-InputComponent e11wid6y0']")).
                    GetAttribute("placeholder").Trim();
            string text2 = driver.FindElement(By.XPath("//span[contains(text(), 'Choose language')]")).Text.Trim();

            if (text1 == "Choose language" &&
                text2 == "Choose language")
            {
                return true;
            }
            return false;
        }

        public ServiceHelper SelectUnit()
        {
            driver.FindElement(By.XPath("//div[@class = 'unit-of-measure']//div")).Click();
            WaitUntilFindElement(4, By.Id("SERVICE_UNIT_OPTION_0"));
            driver.FindElement(By.Id("SERVICE_UNIT_OPTION_0")).Click();
            return this;
        }

        public ServiceHelper SelectTypeOfService()
        {
            driver.FindElement(By.XPath("//div[@class = 'type-of-service']//following-sibling::div")).Click();
            WaitUntilFindElement(4, By.Id("SERVICE_TYPE_OF_SERVICE_OPTION_0"));

            int c = driver.FindElements(By.XPath("//div[@class= 'YxhDSz1flbKA8yowp3RE  ']")).Count;
            for (int i = 0; i < c; i++)
            {
                driver.FindElement(By.XPath("//div[@class = 'type-of-service']//following-sibling::div")).Click();
                WaitUntilFindElement(4, By.Id("SERVICE_TYPE_OF_SERVICE_OPTION_0"));
                driver.FindElement(By.XPath("//div[@class= 'YxhDSz1flbKA8yowp3RE  '][" + (i + 1) + "]")).Click();
                if(UnitIsNotEmpty() == true)
                {
                    break;
                }
            }

            return this;
        }

        public bool UnitIsNotEmpty()
        {
            string text = driver.FindElement(By.XPath("//input[@name = 'SERVICE_UNIT']//preceding-sibling::div//span")).Text;
            if(text == "Character") { return true; } return false;
        }

        public bool SaveServiceButtonIsDisabled()
        {
            if (driver.FindElement(By.Id("SERVICE_SAVE")).Enabled)
            {
                return false;
            }
            return true;
        }

        public bool LanguagePairSelectIsDisabled(int i)
        {
            if(driver.FindElements(By.XPath(
                "//div[@class = 'react-dropdown-select dropdown css-1jmlu6t-ReactDropdownSelect e1gzf2xs0']")).Count == i)
            {
                return true;
            }
            return false;
        }

        public ServiceHelper TargetLanguageDelete()
        {
            driver.FindElement(By.Name("SERVICE_SOURCE_LANG")).Click();
            WaitUntilFindElement(4, By.Id("SERVICE_SOURCE_LANG_0"));
            driver.FindElement(By.Id("SERVICE_SOURCE_LANG_0")).Click();
            return this;
        }

        public bool LanguagePairIsEmpty()
        {
            return IsElementPresent(By.Id("SHOW_LANGUAGE_PAIRS"));
        }

        public bool CATToolPopupIsPresentAndHaveCorrectText()
        {
            string text = driver.FindElement(By.XPath("//div[@class = 'popup-content ']")).Text;
            if (text == "Only one CAT tool can be used per project")
            {
                return true;
            }
            return false;
        }

        public bool WarningTextIsCorrect()
        {
            string text1 = driver.FindElement(By.XPath("//p[@class = 'bYs_kMWmvVuZpJVhZfH4'][1]")).Text;
            string text2 = driver.FindElement(By.XPath("//p[@class = 'bYs_kMWmvVuZpJVhZfH4'][2]")).Text;
            if (text1 == "Please, upload cat log file" && text2 == "Are you sure you want to interrupt the service creating process?")
            {
                return true;
            }
            return false;
        }

        public ServiceHelper CATFileDeleteButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_CAT_FILE_REMOVE")).Click();
            return this;
        }

        public ServiceHelper StatisticButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_CAT_STATISTIC")).Click();
            Thread.Sleep(200);
            return this;
        }

        public bool StatisticIsOpen()
        {
            return IsElementPresent(By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w Rg7DxUmIwnJe0nOb6KZC']"));
        }

        public bool TargetLanguageCanChoose()
        {
            OpenTargetLanguage();
            return IsElementPresent(By.XPath("//p[@class = 'CKkqQTXqlkqO2CTJTb3k']"));
        }

        public ServiceHelper OpenTargetLanguage()
        {
            driver.FindElement(By.XPath("//input[@name= 'CATSTATISTICS_TARGETLANGUAGE_DROP']")).Click();
            WaitUntilFindElement(4, By.XPath("//p[@class = 'CKkqQTXqlkqO2CTJTb3k']"));
            return this;
        }

        public bool StatisticTableIsPresent()
        {
            return driver.FindElements(By.XPath("//div[@class= 'DqOrlCG2LP930OmpmjQT']")).Count == 7;
        }

        public string SourceFileName()
        {
            string text = driver.FindElement(By.XPath("//div[@class = 'row one']//p[@class = 'title']")).Text.Trim();
            return text;
        }

        public ServiceHelper SourceFileClick()
        {
            driver.FindElement(By.Id("SHOW_SOURCE_FILES")).Click();
            Thread.Sleep(200);
            return this;
        }

        public ServiceHelper ReferenceTabClick()
        {
            driver.FindElement(By.Id("ProjectCardReferenceMaterials"));
            return this; ;
        }

        public int QuantityPriceMultiplication()
        {
            if (ServiceLanguagePairsTableIsHidden())
            {
                OpenServiceLanguagePairsTable();
            }            
            string a = driver.FindElement(By.XPath("//div[@class = 'row']/div/p[@class = 'GxpMAeiU_LKN4yZsTEhL']")).Text;
            string b = driver.FindElement(By.XPath("//div[@class = 'row']/div/p[@class = 'zEEPIQ2axxHqUkIhoCtb']")).Text;

            double i = Convert.ToDouble(a.Replace(".", ",").Trim()) * Convert.ToDouble(b.Replace(".", ",").Trim());
            return (int)i;
        }

        public bool ServiceLanguagePairsTableIsHidden()
        {
            return IsElementPresent(By.XPath("//div[@class = 'language-pairs-table hidden']"));
        }

        public int ServiceCostValueTextInTable()
        {
            string a = driver.FindElement(By.XPath("//p[@class = 'cost-row']")).Text;
            double i = Convert.ToDouble(a.Replace(".", ",").Trim());
            return (int)i;
        }

        public ServiceHelper OpenServiceLanguagePairsTable()
        {
            driver.FindElement(By.Id("SHOW_LANGUAGE_PAIRS")).Click();
            Thread.Sleep(5000);
            return this;
        }
        public bool CircleNextToTheFilePopupIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = '__react_component_tooltip show place-top type-dark fAxMCCe7_OgpcIpCLAsy']"));
        }
        public ServiceHelper BackToProjectButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'btn secondary-btn']")).Click();
            Thread.Sleep(200);
            return this;
        }
        public ServiceHelper ExclamationClick()
        {
            driver.FindElement(By.Id("Path_301")).Click();
            return this;
        }
        public ServiceHelper CircleNextToTheFileClick()
        {
            driver.FindElement(By.XPath("//span[@class = 'geRBJYkHaPThqun2Myj_']")).Click();
            return this;
        }

        public ServiceHelper InvalidSourceFileAttach()
        {
            driver.FindElement(By.Id("FILE_LOADER")).SendKeys(manager.invalidSourceFilePath);
            WaitUntilFindElement(10, By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w gjXLfDGk0Gk3_3dIbrxy']"));
            return this;
        }
        public ServiceHelper WarningCancelButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'TcMMo6iDjW2Wg_KudxB2 WwSFVDblp_mIPZp2ZJYT']")).Click();
            return this;
        }
        public bool UploadFileButtonIsPresent()
        {
            return driver.FindElements(By.Id("SERVICE_CAT_FILES_UPLOAD")).Count == 1;
        }
        public ServiceHelper WarningContinueButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_CAT_CONTINUE")).Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w Nrf1TFC7pwuCLdZKvQtK']"));
            return this;
        }
        public bool WarningPopupIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w Nrf1TFC7pwuCLdZKvQtK']"));            
        }
        public bool SourceFileIsRemoved()
        {
            return driver.FindElements(By.XPath("//div[@class = 'YmshXQqoZM73RbpHd4Fq']")).Count == 0;
        }

        public ServiceHelper SourceFileRemoveButtonClick()
        {
            driver.FindElement(By.Id("FILE_DELETE")).Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'YmshXQqoZM73RbpHd4Fq']"));
            return this;
        }
        public ServiceHelper CATFileDownloadButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_CAT_DOWNLOAD")).Click();
            Thread.Sleep(4000);
            return this;
        }
        public ServiceHelper SourceFileInServiceListDownloadButtonClick()
        {
            driver.FindElement(By.Id("SHOW_SOURCE_FILES")).Click();
            driver.FindElement(By.Id("DOWNLOAD_FILE")).Click();
            Thread.Sleep(4000);
            return this;
        }

        public ServiceHelper SourceFileInServiceEditPageDownloadButtonClick()
        {
            driver.FindElement(By.Id("FILE_DOWNLOAD")).Click();
            Thread.Sleep(4000);
            return this;
        }

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
            WaitUntilElementIsHide(20, By.XPath("//span[@class = 'hRFbZ85DzhNaXfrQ_8Uv']"));
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
            driver.FindElement(By.Id("FILE_LOADER")).SendKeys(manager.sourceFile);            
            if (IsElementPresent(By.XPath("//div[@class = 'glPRJNnEF2QbMnC0ZqIX  ']")))
            {                
                WaitUntilElementIsHide(10, By.XPath("//p[@class = 'CjLCnWG2I76az0SPKDXC ZqX4aBORRQ0nnzF9Y5P5']"));
            }
            WaitUntilFindElement(10, By.Id("FILE_DOWNLOAD"));
            return this;
        }

        public ServiceHelper RequestQuoteButtonClick()
        {
            driver.FindElement(By.Id("requestQuote")).Click();
            WaitUntilFindElement(10, By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']"));
            WaitUntilElementIsHide(40, By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']"));
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

        public ServiceHelper OpenAndEditButtonClick()
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
            Thread.Sleep(500);
            driver.FindElement(By.Id("SERVICE_SOURCE_LANG_2")).Click();
            return this;
        }        

        public ServiceHelper SelectTargetLanguage(int i)
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();            
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[@class = 'YxhDSz1flbKA8yowp3RE  ']["+i+"]")).Click();
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
        
        public ServiceHelper SaveServiceButtonClick()
        {
            driver.FindElement(By.Id("SERVICE_SAVE")).Click();
            if (!WarningPopupIsPresent())
            {
                WaitUntilFindElement(10, By.XPath("//div[@class = 'services-list']"));                
            }            
            return this;
        }
        
    }
}
