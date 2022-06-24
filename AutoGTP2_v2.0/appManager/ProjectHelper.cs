using OpenQA.Selenium;


namespace AutoGTP2Tests
{
    public class ProjectHelper : HelperBase
    {   
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }
               

        //Высокоуровневые методы
        public ProjectHelper CreateProject(ProjectData projectData)
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
            if (ProjectDeleteButtonIsDisabled())
            {
                FindPendingProject();
            }
            ClickProjectBurger();
            ProjectDeleteButtonClick();
            ProjectDeleteDeclineButtonClick();
            return this;
        }

        public ProjectHelper RemoveProjectConfirm()
        {
            manager.Navigator.GoToProjectPage();
            if (ProjectDeleteButtonIsDisabled())
            {
                FindPendingProject();                
            }
            ClickProjectBurger();
            ProjectDeleteButtonClick();
            ProjectDeleteConfirmButtonClick();
            return this;
        }
        

        // Низкоуровневые методы

        public ProjectHelper FindPendingProject()
        {
            driver.FindElement(By.Id("PROJECTS_FILTERS_BUTTON")).Click();
            driver.FindElement(By.XPath("//div[@class = 'statuses-dropdown-lock']//input")).Click();
            driver.FindElement(By.XPath("//span[@aria-label= 'Pending']")).Click();
            driver.FindElement(By.Id("PROJECTS_FILTERS_APPLY")).Click();
            WaitUntiFindElement(20, By.XPath("//div[@id = 'PROJECT_0']//div[@id = 'PROJECT_STATUS']//span[contains(text(), 'Pending')]"));                        
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
        public bool ProjectDeleteButtonIsDisabled() => driver.FindElements(By.XPath("//p[@class = 'delete-project-btn disabled']")).Count == 1;
    }
}
