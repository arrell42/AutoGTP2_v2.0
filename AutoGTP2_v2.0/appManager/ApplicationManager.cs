using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoGTP2Tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;        
        protected string baseURL;
        
        //HELPERS ADD 
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected BudgetHelper budgetHelper;
        protected ProjectHelper projectHelper;
        protected ServiceHelper serviceHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        // Начало теста - открыть браузер, перейти на нужную страницу
        private ApplicationManager()
        {
            driver = new ChromeDriver();                       
            baseURL = "https://gtp-test.janusww.com:9999/";            
            //HELPERS INIT
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            budgetHelper = new BudgetHelper(this);
            projectHelper = new ProjectHelper(this);
            serviceHelper = new ServiceHelper(this);
        }

        //Завершение теста - закрыть браузер
        ~ApplicationManager()
        {
            try
            {                
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        
        public static ApplicationManager GetInstance()
        {
            if(!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToLoginPage();
                app.Value = newInstance;                
            }
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }

        public string GetRandomString(int length)
        {
            var r = new Random();
            return new String(Enumerable.Range(0, length).Select(n => (Char)(r.Next(32, 127))).ToArray());
        }



        //Property for helpers - чтобы не делать их public
        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navigator
        {
            get { return navigationHelper; }
        }

        public BudgetHelper Budgets
        {
            get { return budgetHelper; }
        }

        public ProjectHelper Project
        {
            get { return projectHelper; }
        }

        public ServiceHelper Service
        {
            get { return serviceHelper; }
        }
        

    }
}
