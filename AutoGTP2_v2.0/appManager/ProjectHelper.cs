using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AutoGTP2Tests
{
    public class ProjectHelper : HelperBase
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

        //Получение списка проектов
        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class = 'NISN5104MJmPjvzE4xDN']//div"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;
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


        // выбор даты в проекте
        public void SetDatePicker(IWebDriver driver, string cssSelector, string date)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (driver as IJavaScriptExecutor).ExecuteScript(
                string.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));




            driver.SwitchTo().Frame(
            driver.FindElement(By.CssSelector("iframe.demo-frame")));
            SetDatePicker(driver, "#datepicker", "02/20/2002");
        }




        // Низкоуровневые методы

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
            WaitUntiFindElements(15, By.Id("PROJECT_CARD_SAVE_AND_EXIT"), 0);            
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
