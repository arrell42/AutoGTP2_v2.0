using OpenQA.Selenium;


namespace AutoGTP2Tests
{
    public class LoginHelper : BaseHelper
    {
        public object TimeUnit { get; private set; }

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        //Высокоуровневые методы
        public void Login(LoginData account)
        {
            if (IsLoggedIn())
            {
                return;
            }            
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
            WaitUntilFindElement(10, By.Id("MENU_LOGOUT"));            
        }
                
        public void CorrectLogin(LoginData account)
        {            
            LogoutIfLoginIn();
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
            WaitUntilFindElement(10, By.Id("MENU_LOGOUT"));
        }
        
        public void InvalidLogin(LoginData account)
        {
            LogoutIfLoginIn();
            EnterUsername(account);
            EnterPassword(account);
            SignInButtonClick();
            WaitUntilFindElement(10, By.XPath("//div[@class = '__floater __floater__open']"));
        }
                

        //Методы позволяют выйти, если залогинен
        public void LogoutIfLoginIn()
        {
            if (IsLoggedIn())
            {
                Logout();
            }
        }
        public bool IsLoggedIn()
        {
            driver.Navigate().Refresh();
            return IsElementPresent(By.Id("MENU_LOGOUT"));
        }
        public void Logout()
        {
            if (IsLoggedIn())
            { 
            driver.FindElement(By.Id("MENU_LOGOUT")).Click();
            WaitUntilFindElement(10, By.Id("LOGIN_FORM_BUTTON"));            
            }
        }


        //Низкоуровневые методы
        public void SignInButtonClick()
        {
            driver.FindElement(By.Id("LOGIN_FORM_BUTTON")).Click();
        }

        public void EnterUsername(LoginData account)
        {
            Type(By.Id("LOGIN_FORM_USERNAME"), account.Username);
        }
        public void EnterPassword(LoginData account)
        {
            Type(By.Id("LOGIN_FORM_PASSWORD"), account.Password);
        }
        public void Type(By locator, string text)
        {
            driver.FindElement(locator).Click();
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }
    }
}
