using OpenQA.Selenium;
using System.Threading;

namespace AutoGTP2Tests
{
    public class NavigationHelper : BaseHelper
    {        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {            
            this.baseURL = baseURL;
        }

        //LOCATORS
        public readonly By projectList = By.XPath("//div[@class= 'fPooHDtNQyVHMCf4O9mn']");
        public readonly By projectsButtonInNavBar = By.Id("MENU_PROJECTS");
        public readonly By loadingCircle = By.XPath("//div[@class = 'uAVm9bKcbGvOpCLx2Whj']");
        public readonly By projectCardOnPage = By.XPath("//div[@class= 'Y60VrDynu5B8vFAVkO5A']");
        


        public void GoToLoginPage()
        {
               driver.Navigate().GoToUrl(baseURL);            
        }

        public void GoToBudgetPage()
        {            
            if (driver.Url == "" + baseURL + "/budgets")
            {                
                WaitUntilFindElement(10, By.XPath("//div[@class= 'vKOuKRPiTZr_i_RoPDcw']"));
                manager.Budgets.ColumnsTurnOnIfItTurnOff();
                return;                
            }            
            driver.FindElement(By.Id("MENU_BUDGETS")).Click();
            WaitUntilElementIsHide(5, By.XPath("//div[@class = 'uAVm9bKcbGvOpCLx2Whj']"));
            if (NoBudgetsForDisplay())
            {
                BudgetData budgetData = new BudgetData("", "")
                {
                    BudgetPO = TextGenerator(1, 5),
                    BudgetCost = TextGenerator(1, 3),
                    BudgetTotal = "1000"
                };
                CreateNewBudget(budgetData);
                driver.Navigate().Refresh();
            }
            WaitUntilFindElement(10, By.XPath("//div[@class= 'vKOuKRPiTZr_i_RoPDcw']"));
            manager.Budgets.ColumnsTurnOnIfItTurnOff();
        }
        

        public void GoToProjectPage()
        {
            if (driver.Url == "" + baseURL + "/projects")
            {
                WaitUntilFindElement(15, projectList);
                manager.ProjectPage.ColumnsTurnOnIfItTurnOff();
                return;
            }
            driver.FindElement(projectsButtonInNavBar).Click();            
            WaitUntilElementIsHide(10, loadingCircle);
            WaitUntilFindElement(15, projectList);
            Thread.Sleep(1000);
            if(CountOfProjectsOnPage() > 20) { manager.ProjectPage.SelectProjectCountOnPage("20"); }
            manager.ProjectPage.ColumnsTurnOnIfItTurnOff();

        }

        public void GoToDashportPage()
        {            
            if (driver.Url == "" + baseURL + "/dashport")
            {
                WaitUntilFindElement(10, By.Id("DASHPORT_GANTT_0_PROJECT_IN_LIST"));
                return;
            }
            driver.FindElement(By.Id("MENU_DASHPORT")).Click();
            WaitUntilFindElement(10, By.Id("DASHPORT_GANTT_0_PROJECT_IN_LIST"));
        }








        public int CountOfProjectsOnPage()
        {
            return driver.FindElements(projectCardOnPage).Count;
        }


        private bool NoBudgetsForDisplay()
        {
            var noData = By.XPath("//div[@class= 'u8jP831aiskq6Oe6mMlo']");
            return IsElementPresent(noData);
        }
        private void CreateNewBudget(BudgetData budgetData)
        {
            manager.Budgets.NewBudgetButtonClick();
            manager.Budgets.EnterPOnumber(budgetData);
            manager.Budgets.EnterBudgetCost(budgetData);
            manager.Budgets.SelectUSDCurrency();
            manager.Budgets.EnterTotal(budgetData);
            manager.Budgets.BudgetCreateButtonClick();
            Thread.Sleep(1000);
        }
    }
}
