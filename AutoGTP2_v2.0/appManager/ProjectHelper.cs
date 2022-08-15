using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
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
            return this;
        }

        public ProjectHelper ProjectCancel(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            CancelProjectButtonClick();
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
            ProjectDeleteButtonClick();
            ProjectDeleteDeclineButtonClick();
            return this;
        }

        public ProjectHelper RemoveProjectConfirm()
        {
            manager.Navigator.GoToProjectPage();            
            ClickProjectBurger();
            ProjectDeleteButtonClick();
            ProjectDeleteConfirmButtonClick();
            return this;
        }

        public ProjectHelper CreateExpressProject(ProjectData projectData)
        {
            OpenNewExpressProject(projectData);
            SaveProjectButtonClick();
            return this;
        }        

        public ProjectHelper ExpressProjectExclamationPopup(ProjectData projectData)
        {
            OpenNewExpressProject(projectData);
            ExpressProjectExclamationClick();
            return this;
        }

        public ProjectHelper ExpressProjectFileAttach(ProjectData projectData)
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
            return this;
        }

        public ProjectHelper ExpressProjectTextAttach(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);            
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
            WaitUntilFindElement(4, By.XPath("//p[@class = 'i9matKNoUHudiZkMT8BL']"));
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
            Thread.Sleep(200);
            SaveProjectButtonClick();
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
            OpenThisProject();
            OpenRefTab();
            return this;
        }

        public ProjectHelper RefTabInProjectMultipleFileAttach(ProjectData projectData)
        {
            OpenNewPendingProject(projectData, 3, "00:30");
            OpenRefTab();
            RefFileAttach(5);
            SaveProjectButtonClick();
            OpenThisProject();
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

        













        //Получение списка проектов                

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class = 'Y60VrDynu5B8vFAVkO5A']"));
            foreach(var element in elements)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    string name = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[@id= 'PROJECTS_PROJECT_NAME']")).Text.Trim();
                    string budget = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Budget')]//following-sibling::div//div")).Text.Trim();
                    string subjectArea = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Subject area')]//following-sibling::div")).Text.Trim();
                    string vendor = driver.FindElement(By.XPath(
                        "//div[@id= 'PROJECT_" + i + "']//div[contains(text(), 'Vendor')]//following-sibling::div")).Text.Trim();
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
                        Vendor = vendor,
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

        
        public ProjectData GetDatesFromProjectList()
        {
            manager.Navigator.GoToProjectPage();
            driver.FindElement(By.XPath("//div[@id= 'PROJECT_0']//div[@id= 'PROJECTS_PROJECT_NAME']")).Click();
            WaitUntilFindElement(10, By.XPath(
                "//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));

            string start = driver.FindElement(By.XPath(
                "//div[@id= 'PROJECT_0']//div[@class= 'cKVdbe5ncl_hH94NrcVk']/div[2]")).Text;
            string end = driver.FindElement(By.XPath(
                "//div[@id= 'PROJECT_0']//div[@class= 'dXd7OzCXmiZiomDAUNh1']/div[2]")).Text;


            return new ProjectData()
            {
                StartDate = start,
                EndDate = end
            };
        }

        
        public ProjectData GetDatesFromProject()
        {
            manager.Navigator.GoToProjectPage();

            string start = driver.FindElement(By.XPath("//input[@name= 'start_date']")).GetAttribute("value").Trim();
            string end = driver.FindElement(By.XPath("//input[@name= 'end_date']")).GetAttribute("value").Trim();
            string time = driver.FindElement(By.XPath(
                "//input[@name= 'PROJECT_CARD_END_TIME_DROP']")).GetAttribute("value").Trim();

            return new ProjectData()
            {
                StartDate = start,
                EndDate = end,
                //Time = time
            };
        }






        // Низкоуровневые методы

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

        public ProjectHelper OpenThisProject()
        {
            manager.Navigator.GoToProjectPage();
            MouseClickImitation(By.XPath("//div[@class= 'WL6eEVs3cgv5l5JGCHtM']"));
            Thread.Sleep(200);
            driver.FindElement(By.XPath("//div[@id= 'PROJECT_0']//div[@id= 'PROJECTS_PROJECT_NAME']")).Click();
            WaitUntilFindElement(10, By.Id("ProjectCardReferenceMaterials"));
            return this;
        }

        public ProjectHelper RefFileAttach(int f)
        {
            for (int i = 0; i < f; i++)
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
            WaitUntilElementIsHide(10, By.XPath(
                "//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
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

        public ProjectHelper CancelProjectButtonClick()
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

        public bool WarningPopupIsPresent()
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

        public string ExpressWordCount()
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
            return this;
        }

        public ProjectHelper ProjectDeleteButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_SUB_DELETE")).Click();            
            return this;
        }

        public ProjectHelper ClickProjectBurger()
        {            
            driver.FindElement(By.XPath("//div[@class = 'project-selection-menu']")).Click();
            return this;
        }

        public ProjectHelper ProjectDeleteDeclineButtonClick()
        {
            driver.FindElement(By.XPath("//button[@class = 'btn primary-btn']")).Click();            
            return this;
        }

        public ProjectHelper SaveProjectButtonClick()
        {
            driver.FindElement(By.Id("PROJECT_CARD_SAVE_AND_EXIT")).Click();
            //ждем пока исчезнет всплывающее окно с проектом
            if (!WarningPopupIsPresent())
            {
                WaitUntilFindElements(15, By.Id("PROJECT_CARD_SAVE_AND_EXIT"), 0);
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

        public ProjectHelper RemoveProject()
        {
            manager.Navigator.GoToProjectPage();
            SortByPending();            
            DeleteAllProjects(40);
            return this;
        }



        public void DeleteAllProjects(int f)
        {
            for (int i = 0; i < f; i++)
            {                
                //driver.SwitchTo().Alert().Accept();
                ClickProjectBurger();
                ProjectDeleteButtonClick();
                ProjectDeleteConfirmButtonClick();
                Thread.Sleep(3000);
            }

        }

        public ProjectHelper SortByPending()
        {
            FiltersButtonClick();
            ChoosePendingStatus();
            FilterApplyButtonClick();
            WaitUntilFindElement(5, By.XPath("//span[contains(text(), 'Pending')]"));
            return this;
        }

        public ProjectHelper FiltersButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_FILTERS_BUTTON")).Click();
            return this;
        }

        public ProjectHelper ChoosePendingStatus()
        {
            driver.FindElement(By.XPath("//span[contains(text(), 'Choose status')]")).Click();
            driver.FindElement(By.XPath(
                "//span[@class='react-dropdown-select-item    css-148o527-ItemComponent evc32pp0' and contains(text(), 'Pending')]")).Click();
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
