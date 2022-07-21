using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


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
            manager.Navigator.GoToProjectPage();
            NewProjectButtonClick();
            EnterProjectName(projectData);
            SaveProjectButtonClick();            
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
            MouseClickImitation();                        
            LimitPopupCancelButtonClick();            
            return this;
        }

        public ProjectHelper ExpressProjectLimitPopupSwitchButton(ProjectData projectData, string filePath)
        {
            OpenNewExpressProject(projectData);
            FillTextAreaFromFile(filePath);
            MouseClickImitation();
            LimitPopupSwitchButtonClick();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'c8SKZENNUPbG9odvBGrJ ']"));
            return this;
        }

        




        //Получение списка проектов
        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectPage();
            IList<IWebElement> name = driver.FindElements(By.Id("PROJECTS_PROJECT_NAME"));
            IList<IWebElement> stat = driver.FindElements(By.Id("PROJECTS_PROJECT_NAME"));
            if (name.Count == stat.Count)
            {
                for (int i = 0; i < name.Count; i++)
                {
                    projects.Add(new ProjectData(name[i].Text));
                }
            }
            return projects;
        }

        // Низкоуровневые методы

        public ProjectHelper LimitPopupSwitchButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_EXPRESS_BACK_TO_CLASSIC")).Click();
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
            WaitUntilFindElements(15, By.Id("PROJECT_CARD_SAVE_AND_EXIT"), 0);
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
            ClickProjectBurger();
            if (driver.FindElements(By.XPath("//p[@class = 'delete-project-btn disabled']")).Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
