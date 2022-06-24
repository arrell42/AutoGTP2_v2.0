using OpenQA.Selenium;


namespace AutoGTP2Tests
{
    public class NavigationHelper : HelperBase
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
            if(driver.Url != "https://gtp-test.janusww.com:9999/dashport")
            {
                driver.Navigate().GoToUrl(baseURL);                
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_BUDGETS")).Click();
        }

        public void GoToProjectPage()
        {
            if (driver.Url != "https://gtp-test.janusww.com:9999/dashport")
            {
                driver.Navigate().GoToUrl(baseURL);
                LoginData account = new LoginData("Main_test", "123456");
                manager.Auth.Login(account);
            }
            driver.FindElement(By.Id("MENU_PROJECTS")).Click();
            WaitUntiFindElement(10, By.Id("PROJECT_0"));            
        }
    }
}
