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
            if (driver.Url != "" + baseURL + "/dashport")
            {
                GoToLoginPage();
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_BUDGETS")).Click();
            WaitUntilElementIsHide(5, By.XPath("//div[@class = 'uAVm9bKcbGvOpCLx2Whj']"));
            manager.Budgets.ColumnsTurnOnIfItTurnOff();
        }

        public void GoToProjectPage()
        {
            if (driver.Url != ""+ baseURL + "/dashport")
            {
                GoToLoginPage();                
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_PROJECTS")).Click();

            var loadingCircle = By.XPath("//div[@class = 'uAVm9bKcbGvOpCLx2Whj']");
            WaitUntilElementIsHide(5, loadingCircle);
        }

        public void GoToDashportPage()
        {
            if (driver.Url != "" + baseURL + "/dashport")
            {
                GoToLoginPage();
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_DASHPORT")).Click();
            WaitUntilFindElement(10, By.Id("DASHPORT_GANTT_0_PROJECT_IN_LIST"));
        }
    }
}
