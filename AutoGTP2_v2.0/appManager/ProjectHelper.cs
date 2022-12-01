using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutoGTP2Tests
{
    public class ProjectHelper : BaseHelper
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        //Высокоуровневые методы
        public ProjectHelper CreatePendingProject(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            SaveProjectButtonClick();
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();
            return this;
        }


        public ProjectHelper ProjectCancel(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            CancelButtonInProjectCardClick();
            return this;
        }

        public ProjectHelper CreateEmptyProject()
        {
            manager.Navigator.GoToProjectPage();
            NewProjectButtonClick();
            SaveProjectButtonClick();
            return this;
        }

        public ProjectHelper EmptyProjecPopupButtons()
        {
            manager.Navigator.GoToProjectPage();
            NewProjectButtonClick();
            SaveProjectButtonClick();
            AddDetailsButtonClick();
            SaveProjectButtonClick();
            ExitAndDeleteButtonClick();
            return this;
        }

        public ProjectHelper RemoveProjectDecline()
        {
            manager.Navigator.GoToProjectPage();
            ClickProjectBurger();
            ProjectDeleteButtonInBurgerClick();
            ProjectDeleteDeclineButtonClick();
            return this;
        }

        public ProjectHelper RemoveProjectConfirm()
        {
            manager.Navigator.GoToProjectPage();
            ClickProjectBurger();
            ProjectDeleteButtonInBurgerClick();
            ProjectDeleteConfirmButtonClick();
            return this;
        }

        public ProjectHelper CreateExpressProject(ProjectData projectData)
        {
            OpenNewExpressProject(projectData);
            SaveProjectButtonClick();
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();
            return this;
        }
        
        public ProjectHelper ExpressProjectExclamationPopup(ProjectData projectData)
        {
            OpenNewExpressProject(projectData);
            ExpressProjectExclamationClick();
            return this;
        }

        public ProjectHelper ExpressProjectRequestQuote(ProjectData projectData)
        {
            OpenNewExpressProject(projectData);
            manager.Services.SourceFileAttach();
            manager.Services.RequestQuoteButtonClick();
            return this;
        }

        public ProjectHelper PlaceOrderProjectCreation(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            PlaceOrderButtonClick();
            PlaceOrderMessageOKClick();
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();
            return this;
        }

        public ProjectHelper ExpressProjectTextAttachAndPlaceOrder(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            manager.Services.RequestQuoteButtonClick();            
            PlaceOrderButtonClick();            
            OpenThisProject(projectData);            
            manager.Services.OpenAndEditButtonClick();
            return this;
        }
                
        public ProjectHelper ExpressProjectLimitPopupCancelButton(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            MouseClickImitation(By.XPath("//p[@class = 'RjSxBXvO6oCmh2PBtYg9']"));
            LimitPopupCancelButtonClick();
            return this;
        }


        public ProjectHelper ExpressProjectLimitPopupSwitchButton(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            MouseClickImitation(By.XPath("//p[@class = 'RjSxBXvO6oCmh2PBtYg9']"));
            LimitPopupSwitchButtonClick();
            return this;
        }
        
        public ProjectHelper AddAndDeleteBudgetInProject(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            AddBudget();
            DeleteBudget();
            SaveProjectButtonClick();
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();
            return this;
        }

        public ProjectHelper OpenBudgetFormInProject(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            CreateNewBudgetButtonClick();
            return this;
        }

        public ProjectHelper NewBudgetInProjectExistPOInput(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            CreateNewBudgetButtonClick();
            EnterPOnumber(projectData);
            EnterBudgetName(projectData);
            manager.Budgets.SelectUSDCurrency();
            EnterTotal(projectData);
            manager.Budgets.BudgetCreateButtonClick();
            WaitPopupInBudgetField();            
            return this;
        }

        public ProjectHelper NewBudgetCreateInProject(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            CreateNewBudgetButtonClick();
            EnterPOnumber(projectData);
            EnterBudgetName(projectData);
            manager.Budgets.SelectUSDCurrency();
            EnterTotal(projectData);
            manager.Budgets.BudgetCreateButtonClick();
            Thread.Sleep(4000);
            SaveProjectButtonClick();
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();
            return this;
        }

        public ProjectHelper OpenRefTabInProject(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            return this;
        }

        public ProjectHelper RefTabInProjectFileAttach(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(1);
            SaveProjectButtonClick();
            OpenThisProject(projectData);
            OpenRefTab();
            return this;
        }

        public ProjectHelper RefTabInProjectMultipleFileAttach(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(5);
            SaveProjectButtonClick();
            OpenThisProject(projectData);
            OpenRefTab();
            return this;
        }

        public ProjectHelper OpenMessageTabAndSend(ProjectData projectData, string messageText)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenMessageTab();
            SendMessage(messageText);
            return this;
        }

        public ProjectHelper DownloadAllRefFiles(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(5);
            SaveProjectButtonClick();
            OpenThisProject(projectData);
            OpenRefTab();
            DownloadAllFilesButtonClick("Ref");
            return this;
        }

        public ProjectHelper AddDescriptionToRefFile(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(1);
            DescriptionButtonClick();
            AddDescriptionText("Test description");
            SaveDescriptionButtonClick();
            SaveProjectButtonClick();
            OpenThisProject(projectData);
            OpenRefTab();
            return this;
        }

        public ProjectHelper DownloadRefFile(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(1);
            SaveProjectButtonClick();
            OpenThisProject(projectData);
            OpenRefTab();
            DownloadFileButtonClick();            
            return this;
        }

        public ProjectHelper DeleteRefFile(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(1);
            SaveProjectButtonClick();
            OpenThisProject(projectData);
            OpenRefTab();
            DeleteFileButtonClick();            
            return this;
        }

        public ProjectHelper DeclineCancellationProject(ProjectData projectData)
        {            
            FindOrderedProject(projectData); //если проектов в статусе Ordered не найдено - этот метод такой проект создает
            CancelProjectButtonClick();
            CancelProjectDeclineButtonClick();
            return this;
        }

        public ProjectHelper ConfirmCancellationProject(ProjectData projectData)
        {
            FindOrderedProject(projectData);
            CancelProjectButtonClick();            
            CancelProjectConfirmButtonClick();
            return this;
        }

        public ProjectHelper ExpressProjectToggleOn(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            ExpressProjectToggleClick();
            return this;
        }

        public ProjectHelper ExpressProjectToggleOnAndOff(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            ExpressProjectToggleClick();
            Thread.Sleep(200);
            ExpressProjectToggleClick();
            return this;
        }
        public ProjectHelper ExpressProjectFileAndTextAttach(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            manager.Services.SourceFileAttach();
            FillTextAreaFromFile(filePath);
            manager.Services.RequestQuoteButtonClick();
            return this;
        }

        public ProjectHelper ExpressProject8001WordsAttachAndRequestQuote(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            manager.Services.RequestQuoteButtonClick();
            return this;
        }

        public ProjectHelper ExpressProject8001WordsAttachAndPlaceOrder(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath); 
            PlaceOrderButtonClick();
            manager.Services.WordLimitModalCancelButtonClick();
            PlaceOrderButtonClick();
            return this;
        }

        public ProjectHelper ExpressProject8001WordsAttachAndRequestQuoteThenPlaceOrder(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            manager.Services.RequestQuoteButtonClick();
            manager.Services.WordLimitModalCancelButtonClick();
            PlaceOrderButtonClick();
            return this;
        }

        public ProjectHelper ExpressProjectTextAndFileAttachAndRequestQuote(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            manager.Services.SourceFileAttach();
            manager.Services.RequestQuoteButtonClick();
            PlaceOrderButtonClick();
            return this;
        }

        public ProjectHelper ExpressProjectFileAttachAndPlaceOrder(ProjectData projectData)
        {
            OpenNewExpressProject(projectData);
            manager.Services.SourceFileAttach();
            PlaceOrderButtonClick();
            OpenThisProject(projectData);
            WaitUntilProjectIsCalculated();
            return this;
        }

        public ProjectHelper ExpressProjectFileAttachThanFillTextarea(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            manager.Services.SourceFileAttach();
            manager.Services.RequestQuoteButtonClick();
            FillTextAreaFromFile(filePath);
            manager.Services.RequestQuoteButtonClick();
            return this;
        }

        public ProjectHelper ExpressProjectSwitchProjectCancel(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            manager.Services.RequestQuoteButtonClick();
            manager.Services.WordLimitModalCancelButtonClick();            
            return this;
        }











        //Получение списка проектов                

        public List<ProjectData> GetProjectList()
        {            
            List<ProjectData> projects = new List<ProjectData>();

            manager.Navigator.GoToProjectPage();
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();


            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class = 'Y60VrDynu5B8vFAVkO5A']"));
            foreach (var element in elements)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    string name = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[@id= 'PROJECTS_PROJECT_NAME']")).Text.Trim();
                    string budget = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Budget')]//following-sibling::div//div")).Text.Trim();
                    string subjectArea = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Subject area')]//following-sibling::div")).Text.Trim();                    
                    string pm = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Responsible PM')]//following-sibling::div")).Text.Trim();
                    string representative = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'representative')]//following-sibling::div")).Text.Trim();
                    string startDate = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Start date')]//following-sibling::div")).Text.Trim();
                    string endDate = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'End date')]//following-sibling::div")).Text.Trim();
                    string creationDate = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Date of creation')]//following-sibling::div")).Text.Trim();
                    string total = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Total amount')]//following-sibling::div")).Text.Trim();
                    string status = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[@id = 'PROJECT_STATUS']")).Text.Trim();

                    projects.Add(new ProjectData()
                    {
                        ProjectName = name,
                        BudgetCost = budget,
                        SubjectArea = subjectArea,                        
                        ResponsiblePM = pm,
                        ClientRepresentative = representative,
                        StartDate = startDate,
                        EndDate = endDate,
                        CreationDate = creationDate,
                        TotalAmount = total,
                        Status = status
                    });
                }
                break;
            }
            return new List<ProjectData>(projects);
        }


        // проверка на скачанный файл
        public bool CheckFileDownloaded(ProjectData filename)
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

        public bool? SourceDataTabIsOpened()
        {
            var selectedSourceDataTab = By.XPath("//li[@class = 'react-tabs__tab react-tabs__tab--selected']");
            return IsElementPresent(selectedSourceDataTab);
        }

        public bool? MessageTabIsOpened()
        {
            var selectedMessageTab = By.XPath("//li[@class = 'react-tabs__tab react-tabs__tab--selected']//span[@id= 'ProjectCardMessages']");
            return IsElementPresent(selectedMessageTab);
        }

        public ProjectHelper OpenMessagesButtonClick()
        {
            IWebElement messagesButton = driver.FindElement(By.Id("PROJECT_SUB_OPEN_MESSAGES"));
            messagesButton.Click();
            WaitUntilFindElement(10, By.Id("PROJECT_CARD_MESSAGES_INPUT"));
            return this;
        }

        public bool? WarningPopupWhenDeleteProjectIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w nste4vhOguERm01e2UNw']"));
        }

        public bool? ProjectCanBeChanged()
        {
            if(ProjectNameIsEnabled()
               && VendorFieldIsEnabled()
               && SAFieldIsEnabled()
               && DateFieldsIsEnabled())
            {
                return true;
            }
            return false;
        }

        public bool ProjectNameIsEnabled()
        {
            var projectName = By.Id("PROJECT_CARD_NAME");
            return driver.FindElement(projectName).Enabled;
        }

        public bool VendorFieldIsEnabled()
        {
            var vendorField = driver.FindElement(
                By.XPath("//div[@id= 'project-vendor-dropdown']" +
                "//div[@class= 'react-dropdown-select undefined css-12zlm52-ReactDropdownSelect e1gzf2xs0']"));
            return vendorField.Enabled;
        }

        public bool SAFieldIsEnabled()
        {
            var saField = By.XPath("//input[@name= 'SUBJECT_AREA']");
            return driver.FindElement(saField).Enabled;
        }

        public bool DateFieldsIsEnabled()
        {
            var dateField = By.XPath("//input[@name= 'start_date']");
            return driver.FindElement(dateField).Enabled;
        }

        public bool? PlaceOrderButtonIsPresent()
        {
            var placeOrderButton = By.Id("PROJECT_CARD_PLACE_ORDER");
            return IsElementPresent(placeOrderButton);
        }

        public bool? ProjectStatusIs(string statusName)
        {
            var completeStatus = By.XPath
                ("//div[@class= 'CXwQMpaC5HQszu_q1TIp']//div[@id= 'PROJECT_STATUS']//span[contains(text(), '" + statusName + "')]");
            return IsElementPresent(completeStatus);
        }

        public bool? ProjectOnlyForReading()
        {
            if(ProjectNameIsDisabled() && VendorFieldIsDisabled() && SAFieldIsDisabled() && DateFieldsIsDisabled())
            {
                return true;
            }
            return false;
        }

        public bool ProjectNameIsDisabled()
        {
            var projectName = By.Id("PROJECT_CARD_NAME_TEXT");
            if(!IsElementPresent(projectName))
            {
                var projectNameDisabled = driver.FindElement(By.Id("PROJECT_CARD_NAME"));
                if (projectNameDisabled.Enabled) { return false; } return true; 
            }
            return IsElementPresent(projectName);
        }

        public bool VendorFieldIsDisabled()
        {
            var vendorField = By.XPath("//div[@class= 'dxZIY3HKw2lMKexSt1x1'][1]//p[@class= 'PPxwmtZdEfz_pGWOwkSk']");
            if (!IsElementPresent(vendorField))
            {
                var vendorFieldDisabled = driver.FindElement(By.Name("VENDOR_DROPDOWN"));
                if (vendorFieldDisabled.Enabled) { return false; }
                return true;
            }
            return IsElementPresent(vendorField);
        }

        public bool SAFieldIsDisabled()
        {
            var saField = By.XPath("//div[@class= 'dxZIY3HKw2lMKexSt1x1'][2]//p[@class= 'PPxwmtZdEfz_pGWOwkSk']");
            if (!IsElementPresent(saField))
            {
                var saFieldDisabled = driver.FindElement(By.Name("SUBJECT_AREA"));
                if (saFieldDisabled.Enabled) { return false; }
                return true;
            }
            return IsElementPresent(saField);
        }

        public bool DateFieldsIsDisabled()
        {
            var dateFields = By.XPath("//p[@class= 'f0wVc_ZyhjxA78gme7rk']");
            if (!IsElementPresent(dateFields))
            {
                var dateFieldDisabled = driver.FindElement(By.Name("start_date"));
                if (dateFieldDisabled.Enabled) { return false; }
                return true;
            }
            return IsElementPresent(dateFields);
        }

        public ProjectHelper EditButtonInBurgerClick()
        {            
            IWebElement openButton = driver.FindElement(By.Id("PROJECT_SUB_EDIT"));
            openButton.Click();
            WaitUntilProjectModalIsOpened();
            Thread.Sleep(1000);
            return this;
        }

        public void WaitUntilProjectModalIsOpened()
        {
            WaitUntilFindElement(5, By.XPath("//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
        }

        public void WaitUntilFindProjectList()
        {
            WaitUntilFindElement(5, By.XPath("//div[@class= 'fPooHDtNQyVHMCf4O9mn']"));
        }

        public ProjectHelper WaitUntilProjectIsCalculated()
        {
            Thread.Sleep(1000);
            WaitUntilElementIsHide(100, By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']"));
            return this;
        }

        public bool? WordLimitModalIsOpen()
        {
            //modal window
            return IsElementPresent(By.XPath(
                "//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w CPIy0UxHVarTASaZXBRS']"));
        }

        public bool ExpressDeadlineIsCorrect()
        {
            string dateText = driver.FindElement(By.XPath("//p[contains(text(), 'Deadline')]//following-sibling::p")).Text;
            int hour = Int32.Parse(DateTime.Now.ToString("HH")) + 4; //int hour = Int32.Parse(DateTime.Now.AddHours(4))
            string correctTime = hour.ToString();
            if (dateText.Contains(DateTime.Now.ToString("dd")) && dateText.Contains(correctTime))
            {
                return true;
            }
            return false;
        }

        public string ExpressWordsCount()
        {
            return driver.FindElement(By.XPath("//p[contains(text(), 'Word')]" +
                 "//following-sibling::p[@class = 'JYY3cyt6ivHCSM8aXGfg']")).Text;
        }

        public ProjectHelper WaitPopupInBudgetField()
        {
            WaitUntilFindElement(4, By.XPath("//p[@class = 'i9matKNoUHudiZkMT8BL']"));
            return this;
        }

        public ProjectHelper ExpressProjectToggleClick()
        {
            driver.FindElement(By.XPath("//div[@class = 'USxIMGQdXNMaIPLJs7fT']")).Click();
            return this;
        }

        public ProjectHelper CancelProjectConfirmButtonClick()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Yes')]")).Click();
            WaitUntilElementIsHide(4, By.XPath("//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
            return this;
        }

        public bool FirstProjectStatusIsCancelled()
        {
            return IsElementPresent(By.XPath("//div[@id= 'PROJECT_STATUS']//span[contains(text(), 'Cancelled')]"));
        }

        public ProjectHelper FindOrderedProject(ProjectData projectData)
        {
            manager.Navigator.GoToProjectPage();
            SortProjectsByStatus("Ordered");
            if (OrderedStatusNotFounded())
            {
                CreateOrderedProject(projectData);
            }            
            FirstProjectClick();
            return this;
        }

        public ProjectHelper FirstProjectClick()
        {
            driver.FindElement(By.Id("PROJECTS_PROJECT_NAME")).Click();

            var projectCard = By.XPath("//div[@class = 'CXwQMpaC5HQszu_q1TIp']");
            WaitUntilFindElement(10, projectCard);
            return this;
        }

        public ProjectHelper CreateOrderedProject(ProjectData projectData)
        {
            manager.Navigator.GoToProjectPage();
            OpenNewPendingProject(projectData, 3, "00:30");
            PlaceOrderButtonClick();
            OpenThisProject(projectData);
            return this;
        }

        public bool OrderedStatusNotFounded()
        {
            int c = driver.FindElements(By.XPath("//span[contains(text(), 'Ordered')]")).Count();
            if (c > 0) { return false; }
            return true;
        }

        public ProjectHelper CancelProjectButtonClick()
        {
            driver.FindElement(By.XPath("//div[@class = 'Ls81UsGuOEperZX7nWiw i6vQQjoEWNY1KRkGn5rQ']")).Click();
            WaitUntilFindElement(4, By.XPath("//button[@class = 'btn bordered-btn p12' and contains(text(), 'Yes')]"));            
            return this;
        }

        public ProjectHelper CancelProjectDeclineButtonClick()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'No')]")).Click();
            var modal = By.XPath("//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w']");
            WaitUntilElementIsHide(4, modal);
            return this;
        }

        public bool ProjectStatusIsOrdered()
        {
            string text = driver.FindElement(By.Id("PROJECT_STATUS")).Text;
            if (text == "Ordered")
            {
                return true;
            }
            return false;
        }

        public ProjectHelper DeleteFileButtonClick()
        {
            IWebElement deleteFileButton = driver.FindElement(By.Id("FILE_DELETE"));
            deleteFileButton.Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class= 'abj3PIbZlVZEaANnTgWi ']"));
            return this;
        }

        public bool RefFileIsDeleted()
        {
            return IsElementPresent(By.XPath("//div[@class = 'D3WSi9SyfqedE19FLuZH ']"));
        }

        public ProjectHelper DownloadFileButtonClick()
        {
            driver.FindElement(By.Id("FILE_DOWNLOAD")).Click();
            Thread.Sleep(4000); //нужно продумать ожидание
            return this;
        }

        public string TextInDescription()
        {
            string text = driver.FindElement(By.XPath("//div[@class = 'PK78jLTzjFjnFAeVs5iA']")).Text.Trim();
            return text;
        }

        public ProjectHelper DescriptionButtonClick()
        {
            driver.FindElement(By.Id("FILE_COMMENT")).Click();
            WaitUntilFindElement(4, By.Id("FILE_COMMENT_SAVE"));
            return this;
        }

        public ProjectHelper AddDescriptionText(string text)
        {
            driver.FindElement(By.Id("FILE_COMMENT_TEXTAREA")).SendKeys(text);
            Thread.Sleep(200);
            return this;
        }

        public ProjectHelper SaveDescriptionButtonClick()
        {
            driver.FindElement(By.Id("FILE_COMMENT_SAVE")).Click();
            return this;
        }

        public bool AllFilesIsCorrect(string fileName)
        {
            bool exist = false;
            string downloadPath = Path.Combine(Syroot.Windows.IO.KnownFolders.Downloads.Path);
            string[] filePaths = Directory.GetFiles(downloadPath);
            foreach (string f in filePaths)
            {
                if (f.Contains(fileName))
                {
                    FileInfo thisFile = new FileInfo(f);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(f); //удаление файла после проверки                   
                }                
            }
            return exist;
        }

        public int DownloadAllFiles(string fileName)
        {            
            string downloadPath = Path.Combine(Syroot.Windows.IO.KnownFolders.Downloads.Path);
            int fCount = Directory.GetFiles(downloadPath, fileName + "*", SearchOption.TopDirectoryOnly).Length;
            return fCount;
        }

        public ProjectHelper DownloadAllFilesButtonClick(string fileName)
        {
            string downloadPath = Path.Combine(Syroot.Windows.IO.KnownFolders.Downloads.Path);
            string[] filePaths = Directory.GetFiles(downloadPath);
            var directoryFiles = Directory.EnumerateFiles(downloadPath).ToList();
            foreach (string f in filePaths)
            {
                if (f.Contains(fileName))
                {
                    File.Delete(f); //удаление файла                   
                }
            }

            driver.FindElement(By.XPath("//button[@class = 'btn primary-btn ']")).Click();

            Thread.Sleep(10000); // доработать метод ожидания загрузки файлов
            
            return this;
        }

        public ProjectHelper OpenMessageTab()
        {
            driver.FindElement(By.XPath("//span[contains(text(), 'Messages')]")).Click();
            return this;
        }

        public ProjectHelper SendMessage(string text)
        {
            driver.FindElement(By.Id("PROJECT_CARD_MESSAGES_INPUT")).SendKeys(text);
            driver.FindElement(By.Id("PROJECT_CARD_MESSAGES_SEND_BUTTON")).Click();
            WaitUntilFindElement(3, By.XPath("//div[@class = 'RhjoYcpGysnqEhJIMQeo']"));
            return this;
        }

        public bool MessageDateIsCorrect()
        {
            string startDate = driver.FindElement(By.XPath("//input[@name= 'start_date']")).GetAttribute("value");
            string messageDate = driver.FindElement(By.XPath("//p[@class = 'dFxDzSyHuO4NPeo0YjAo']")).Text;
            if (!startDate.Equals(messageDate))
            {
                return false;
            }
            return true;
        }

        public bool MessageIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'RhjoYcpGysnqEhJIMQeo']"));
        }

        public ProjectHelper OpenThisProject(ProjectData projectData)
        {
            manager.Navigator.GoToProjectPage();
            MouseClickImitation(By.XPath("//div[@class= 'WL6eEVs3cgv5l5JGCHtM']"));
            Thread.Sleep(200);

            string t = projectData.ToString();            
            Regex regexTemp = new Regex(@"\[.*\]");
            string pd = regexTemp.Match(t).Value;

            WaitUntilFindElement(10, By.XPath("//div[contains(text(), '" + pd + "')]"));
            driver.FindElement(By.XPath("//div[contains(text(), '"+ pd + "')]")).Click();            
            WaitUntilFindElement(10, By.Id("ProjectCardReferenceMaterials"));
            if (IsElementPresent(By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']")))
            {
                WaitUntilElementIsHide(10, By.XPath("//span[@class = 'oSlLzqSfaLdSFEWpZxdw']"));                
            }
            Thread.Sleep(3000);
            if (IsElementPresent(By.Id("PROJECTS_EXPRESS_TEXT")))
            {
                CloseProjectCardAndOpenAgain(projectData);
            }
            return this;
        }

        public ProjectHelper CloseProjectCardAndOpenAgain(ProjectData projectData)
        {
            CancelButtonInProjectCardClick();
            OpenThisProject(projectData);
            return this;
        }

        public ProjectHelper RefFileAttach(int numberOfFiles)
        {
            for (int i = 0; i < numberOfFiles; i++)
            {
                driver.FindElement(By.Id("FILE_LOADER")).SendKeys(manager.refFile);
                WaitUntilFindElement(5, By.XPath("//div[@class= ' abj3PIbZlVZEaANnTgWi']"));
                Thread.Sleep(2000);
            }
            return this;
        }

        public bool FileLoaderIsPresent()
        {
            return IsElementPresent(By.Id("FILE_LOADER"));
        }

        public bool FilesAttached(int i)
        {
            return driver.FindElements(By.XPath("//div[@class = 'abj3PIbZlVZEaANnTgWi ']")).Count == i;
        }

        public ProjectHelper OpenRefTab()
        {
            driver.FindElement(By.Id("ProjectCardReferenceMaterials")).Click();            
            return this;
        }

        public ProjectHelper EnterPOnumber(ProjectData projectData)
        {
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).SendKeys(projectData.BudgetPO);
            return this;
        }

        public ProjectHelper EnterBudgetName(ProjectData projectData)
        {
            driver.FindElement(By.Id("NEW_BUDGET_COST")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_COST")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_COST")).SendKeys(projectData.BudgetCost);
            return this;
        }

        public ProjectHelper EnterTotal(ProjectData projectData)
        {
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).SendKeys(projectData.BudgetTotal);
            return this;
        }

        public bool NewBudgetFormIsPresent()
        {
            return IsElementPresent(By.XPath(
                "//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w new-budget-modal']"));
        }

        public bool CreateBudgetButtonIsEnabled()
        {
            return driver.FindElement(By.Id("NEW_BUDGET_CREATE")).Enabled;
            
        }

        public ProjectHelper CreateNewBudgetButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_CREATE_NEW_BUDGET")).Click();
            return this;
        }

        public ProjectHelper AddBudget()
        {
            driver.FindElement(By.XPath(
                "//div[@class = 'react-dropdown-select  css-12zlm52-ReactDropdownSelect e1gzf2xs0']")).Click();
            driver.FindElement(By.XPath("//div[@class = 'eI5geOyhgjozycHCJ1DC']//div[1]")).Click();
            return this;
        }

        public ProjectHelper DeleteBudget()
        {
            driver.FindElement(By.XPath(
                "//div[@class = 'react-dropdown-select  css-12zlm52-ReactDropdownSelect e1gzf2xs0']")).Click();
            driver.FindElement(By.XPath("//p[@class = 'oBLgHpQOCsxNcp9OWrIZ']")).Click();
            return this;
        }
        public ProjectHelper PlaceOrderMessageOKClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'TcMMo6iDjW2Wg_KudxB2 WwSFVDblp_mIPZp2ZJYT']")).Click();
            return this;
        }
        public ProjectHelper PlaceOrderButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_PLACE_ORDER")).Click();
            if(!IsElementPresent(By.XPath("//div[@class = 'lnENMnXk_1d8K8Gsv0Wm']//button[@class= 'btn bordered-btn']")))
            {
                WaitUntilElementIsHide(10, By.XPath(
                "//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
            }            
            return this;
        }
        public bool PlaceOrderMessageIsOpen()
        {
            return IsElementPresent(By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w vc6thQ1uSFnJQCMf28iV']"));
        }

        public bool ProjectCardIsOpen()
        {
            return IsElementPresent(By.XPath(
                "//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
        }

        public ProjectHelper CancelButtonInProjectCardClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_CANCEL")).Click();
            WaitUntilElementIsHide(10, By.XPath(
                "//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
            return this;
        }
        public ProjectHelper AddDetailsButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'TcMMo6iDjW2Wg_KudxB2 nbJ_lQ3s5whrR3I5IMAA']")).Click();
            WaitUntilElementIsHide(5, By.XPath
                ("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w ewdjRZof9VeUtsLdyqQf']"));
            return this;
        }

        public ProjectHelper ExitAndDeleteButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'TcMMo6iDjW2Wg_KudxB2 WwSFVDblp_mIPZp2ZJYT']")).Click();
            return this;
        }

        public bool ProjectListIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'fPooHDtNQyVHMCf4O9mn']"));
        }

        public bool WarningPopupIsPresentInProject()
        {
            return IsElementPresent(By.XPath
                ("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w ewdjRZof9VeUtsLdyqQf']"));
        }

        public ProjectHelper OpenNewPendingProject(ProjectData projectData, int endDate, string time)
        {
            manager.Navigator.GoToProjectPage();
            NewProjectButtonClick();
            EnterProjectName(projectData);
            SetEndDate(endDate);// устанавливает конечную дату, индекс указывает количество дней от начальной даты
            SetTime(time);// время задается в формате 00:00 с шагом 30 минут
            return this;
        }
        public ProjectHelper SetTime(string t)
        {
            driver.FindElement(By.XPath("//div[@class = 'kZAaPPhFtdt6fjMT3dkk']")).Click();
            driver.FindElement(By.XPath(
                "//p[@class = 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + t + "')]")).Click();
            return this;
        }

        public ProjectHelper SetEndDate(int i)
        {
            driver.FindElement(By.Id("PROJECT_CARD_END_DATE")).Click();
            Thread.Sleep(300);
            driver.FindElement(By.Id("PROJECT_CARD_END_DATE")).Click();
            driver.FindElement(By.XPath(
                "//div[@class = 'nKgW2jzaADOuJ9x1mz0H FG0sahfhP8LsIt1TK7TM']//following-sibling::div["+i+"]")).Click();
            WaitUntilFindElement(10, By.XPath("//div[@class = 'react-dropdown-select W8tRcu9L7alboUMK92q_" +
                "  css-12zlm52-ReactDropdownSelect e1gzf2xs0']"));
            return this;
        }

        public ProjectHelper LimitPopupSwitchButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_EXPRESS_BACK_TO_CLASSIC")).Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'c8SKZENNUPbG9odvBGrJ ']"));
            return this;
        }

        public bool ExpressProjectTextAreaIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'c8SKZENNUPbG9odvBGrJ ']"));
        }

        public ProjectHelper LimitPopupCancelButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'btn bordered-btn']"));
            return this;
        }                

        public string ExpressTextAreaWordCount()
        {   
            return driver.FindElement(By.XPath("//textarea[@id = 'PROJECTS_EXPRESS_TEXT']//following-sibling::p")).Text;            
        }

        public ProjectHelper FillTextAreaFromFile(string filePath)
        {
            string text = InternalReadAllText(filePath, Encoding.UTF8).Trim().Replace(Environment.NewLine, "");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('PROJECTS_EXPRESS_TEXT').value = '" + text + "';");
            driver.FindElement(By.Id("PROJECTS_EXPRESS_TEXT")).SendKeys(" "); //чтобы слова подсчитались, иначе подсчета не происходит            
            return this;
        }

        public ProjectHelper OpenNewExpressProject(ProjectData projectData)
        {
            manager.Navigator.GoToProjectPage();
            NewProjectButtonClick();
            ExpressCheckBoxClick();
            EnterProjectName(projectData);
            SelectExpressSourceLanguage();
            SelectExpressTargetLanguage();
            return this;
        }

        public bool ExpressProjectExclamationPopupIsFilled()
        {
            return driver.FindElements(By.XPath("//p[@class = 'Se8iQWVOc1XTMFZTdZCI']")).Count <= 4;
        }
        public bool ExpressProjectExclamationPopupIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'ant-tooltip-inner']"));
        }
        public ProjectHelper ExpressProjectExclamationClick()
        {
            driver.FindElement(By.Id("Path_301")).Click();
            WaitUntilFindElement(10, By.XPath("//div[@class = 'ant-tooltip-inner']"));
            return this;
        }
        public ProjectHelper SelectExpressSourceLanguage()
        {
            driver.FindElement(By.XPath("//input[@name = 'source-language']")).Click();
            WaitUntilFindElement(10, By.Id("PROJECT_EXPRESS_LANGUAGE_SOURCE_OPTION_1"));
            driver.FindElement(By.Id("PROJECT_EXPRESS_LANGUAGE_SOURCE_OPTION_1")).Click();
            return this;
        }
        public ProjectHelper SelectExpressTargetLanguage()
        {
            driver.FindElement(By.XPath("//input[@name = 'PROJECT_EXPRESS_LANGUAGE_TARGET']")).Click();
            WaitUntilFindElement(10, By.Id("PROJECT_EXPRESS_LANGUAGE_TARGET_OPTION_1"));
            driver.FindElement(By.Id("PROJECT_EXPRESS_LANGUAGE_TARGET_OPTION_1")).Click();
            return this;
        }
        public ProjectHelper ExpressCheckBoxClick()
        {
            driver.FindElement(By.XPath("//div[@class = 'USxIMGQdXNMaIPLJs7fT']")).Click();
            return this;
        }

        public ProjectHelper ProjectDeleteConfirmButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_DELETE_CONFIRMATION")).Click();
            Thread.Sleep(1500);
            return this;
        }

        public ProjectHelper ProjectDeleteButtonInBurgerClick()
        {
            IWebElement deleteButton = driver.FindElement(By.Id("PROJECT_SUB_DELETE"));
            deleteButton.Click();
            return this;
        }

        public bool DeleteButtonIsDisable()
        {
            manager.Navigator.GoToProjectPage();
            Thread.Sleep(500);
            ClickProjectBurger(); 
            var enabledDeleteButton = By.XPath("//p[@class= 'delete-project-btn disabled']");
            return IsElementPresent(enabledDeleteButton);
        }

        public ProjectHelper ClickProjectBurger()
        {
            WaitUntilFindElement(10, By.XPath("//div[@class = 'project-selection-menu']"));
            IWebElement projectBurger = driver.FindElement(By.XPath("//div[@class = 'project-selection-menu']"));
            projectBurger.Click();
            return this;
        }

        public ProjectHelper ProjectDeleteDeclineButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'btn primary-btn']")).Click();
            Thread.Sleep(1000);
            return this;
        }

        public ProjectHelper SaveProjectButtonClick()
        {

            driver.FindElement(By.Id("PROJECT_CARD_SAVE_AND_EXIT")).Click();
            //ждем пока исчезнет всплывающее окно с проектом
            if (!WarningPopupIsPresentInProject())
            {                
                var projectModal = By.XPath("//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']");
                WaitUntilElementIsHide(5, projectModal);
            }
            
            return this;
        }

        public ProjectHelper EnterProjectName(ProjectData projectData)
        {
            driver.FindElement(By.Id("PROJECT_CARD_NAME")).Click();
            driver.FindElement(By.Id("PROJECT_CARD_NAME")).Clear();
            driver.FindElement(By.Id("PROJECT_CARD_NAME")).SendKeys(projectData.ProjectName);
            return this;
        }

        public ProjectHelper NewProjectButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_NEW_PROJECT_BUTTON")).Click();
            return this;
        }

        // ищем неактивную кнопку Delete при удалении проекта
        public bool ProjectDeleteButtonIsDisabled()
        {
            manager.Navigator.GoToProjectPage();
            Thread.Sleep(200);
            ClickProjectBurger();
            if (driver.FindElements(By.XPath("//p[@class = 'delete-project-btn disabled']")).Count == 1)
            {
                return true;
            }
            return false;
        }





        // методы для удаления всех проектов

        public ProjectHelper RemoveProject(int i)
        {
            manager.Navigator.GoToProjectPage();
            SortProjectsByStatus("Pending");            
            DeleteAllProjects(i);
            return this;
        }

        public void DeleteAllProjects(int f)
        {
            for (int i = 0; i < f; i++)
            {                
                //driver.SwitchTo().Alert().Accept();
                ClickProjectBurger();
                ProjectDeleteButtonInBurgerClick();
                ProjectDeleteConfirmButtonClick();
                Thread.Sleep(3000);
            }

        }

        public ProjectHelper SortProjectsByStatus(string t)
        {
            FiltersButtonClick();
            manager.ProjectPage.SelectProjectTypeInFilters(2);
            SelectProjectStatusInFilter(t);
            FilterApplyButtonClick();
            Thread.Sleep(2000);            
            return this;
        }

        public ProjectHelper FiltersButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_FILTERS_BUTTON")).Click();
            return this;
        }

        public ProjectHelper SelectProjectStatusInFilter(string t)
        {
            driver.FindElement(By.XPath("//span[contains(text(), 'Choose status')]")).Click();
            driver.FindElement(By.XPath(
                "//span[@class='react-dropdown-select-item    css-148o527-ItemComponent evc32pp0' and contains(text(), '"+t+"')]")).Click();
            return this;
        }

        public ProjectHelper FilterApplyButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_FILTERS_APPLY")).Click();
            Thread.Sleep(500);
            return this;
        }
    }
}
