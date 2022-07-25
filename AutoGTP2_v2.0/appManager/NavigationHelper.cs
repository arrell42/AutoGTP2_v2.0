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
            if (driver.Url != "https://gtp-test.janusww.com:9999/dashport" 
                /*driver.Url != "https://gtp2.janusww.com/dashport"*/)
            {
                GoToLoginPage();                                
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_BUDGETS")).Click();
            WaitUntilFindElement(10, By.XPath("//div[@class = 'vKOuKRPiTZr_i_RoPDcw']"));
        }

        public void GoToProjectPage()
        {
            if (driver.Url != "https://gtp-test.janusww.com:9999/dashport" 
                /*driver.Url != "https://gtp2.janusww.com/dashport"*/)
            {
                GoToLoginPage();                
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_PROJECTS")).Click();
            WaitUntilFindElement(10, By.Id("PROJECT_0"));            
        }

        public void GoToDashportPage()
        {
            if (driver.Url != "https://gtp-test.janusww.com:9999/dashport"
                /*driver.Url != "https://gtp2.janusww.com/dashport"*/)
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
