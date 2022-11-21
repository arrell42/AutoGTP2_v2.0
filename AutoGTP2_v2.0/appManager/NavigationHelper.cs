using OpenQA.Selenium;


namespace AutoGTP2Tests
{
    public class NavigationHelper : BaseHelper
    {        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {            
            this.baseURL = baseURL;
        }
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
            WaitUntilFindElement(10, By.XPath("//div[@class= 'vKOuKRPiTZr_i_RoPDcw']"));
            manager.Budgets.ColumnsTurnOnIfItTurnOff();
        }

        public void GoToProjectPage()
        {
            if (driver.Url == "" + baseURL + "/projects")
            {
                WaitUntilFindElement(10, By.XPath("//div[@class= 'fPooHDtNQyVHMCf4O9mn']"));                
                return;
            }
            driver.FindElement(By.Id("MENU_PROJECTS")).Click();
            var loadingCircle = By.XPath("//div[@class = 'uAVm9bKcbGvOpCLx2Whj']");
            WaitUntilElementIsHide(5, loadingCircle);
            WaitUntilFindElement(10, By.XPath("//div[@class= 'fPooHDtNQyVHMCf4O9mn']"));
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
    }
}
