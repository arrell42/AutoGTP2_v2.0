using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace AutoGTP2Tests
{
    public class ApplicationManager
    {        
        protected IWebDriver driver;
        public string baseURL;
        public string sourceFile;
        public string sourceFile2;
        public string sourceFile3;
        public string sourceFile4;        
        public string CATLogFilePath;
        public string invalidSourceFilePath;
        public string expressFile8000;
        public string expressFile8001;
        public string expressFile7999;
        public string refFile;

        //HELPERS ADD 
        protected BaseHelper baseHelper;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected BudgetHelper budgetHelper;
        protected ProjectHelper projectHelper;
        protected ServiceHelper serviceHelper;
        protected DashportHelper dashportHelper;
        protected ProjectPageHelper projectPageHelper;
        protected MemoQHelper memoQHelper;
        

        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        public IWebDriver Driver { get { return driver; } }
        
        // Начало теста - открыть браузер, перейти на нужную страницу, инициализация хелперов
        private ApplicationManager()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser); // Autoupdate chromedriver

            ChromeOptions options = new ChromeOptions();

            //========================HEADLESS=====================================
            string headlessOption = "on";
            //string headlessOption = "off";

            if (headlessOption == "on")
            {
                //options.AddArguments("--remote-debugging-port=9222"); // настройка дебагера для хедлесс режима, керио не дает подключится. Можно попробовать исправить через тикет
                options.AddArguments("--headless=new");
                options.AddArguments("--disable-gpu");                
                options.AddArguments("--enable-javascript");
                options.AddArguments("--user-agent='Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Mobile Safari/537.36'");
                options.AddArguments("--no-sandbox");
                options.AddArguments("--ignore-certificate-errors");
                options.AddArguments("--allow-insecure-localhost");
                options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                options.AddArguments("ignore-certificate-errors");
                options.AddArguments("--window-size=1920,1080");
            }

            if (headlessOption == "off")
            {
                options.AddArguments("start-maximized");
                options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                options.AddArguments("ignore-certificate-errors");
                //options.AddArguments("--wm-window-animations-disabled"); // отключение анимации css, надо тестировать. На первый взгляд ни чего не отключает.        
            }
                       

            driver = new ChromeDriver(options);

            //chromedriver autoupdate
            ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;
            Console.WriteLine((capabilities.GetCapability("chrome") as Dictionary<string, object>)["chromedriverVersion"]);
            


            //baseURL = "https://gtp-test.janusww.com:9999";
            baseURL = "https://gtp2.janusww.com";
            //baseURL = "https://81.90.180.117:9999";

            sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\SourceTest.txt");
            sourceFile2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\SourceTest2.txt");
            sourceFile3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\SourceTest3.txt");
            sourceFile4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\SourceTest4.txt");
            CATLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\memoQ.csv");
            invalidSourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\InvaildSourceFileTest.dwg");
            expressFile8000 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\Express8000.txt");
            expressFile8001 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\Express8001.txt");            
            expressFile7999 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\Express7999.txt");
            refFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\RefTest.txt");

            //HELPERS INIT
            baseHelper = new BaseHelper(this);
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            budgetHelper = new BudgetHelper(this);
            projectHelper = new ProjectHelper(this);
            serviceHelper = new ServiceHelper(this);
            dashportHelper = new DashportHelper(this);
            projectPageHelper = new ProjectPageHelper(this);
            memoQHelper = new MemoQHelper(this);
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
        
        // Проверка на открытый браузер - если открыт, то НЕ открывать новый экземпляр
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToLoginPage();
                app.Value = newInstance;                
            }
            return app.Value;
        }

        // Property for helpers - чтобы не делать их public
        public BaseHelper Base
        {
            get { return baseHelper; }
        }
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
        public ProjectHelper Projects
        {
            get { return projectHelper; }
        }
        public ServiceHelper Services
        {
            get { return serviceHelper; }
        }
        public DashportHelper Dashport
        {
            get { return dashportHelper; }
        }
        public ProjectPageHelper ProjectPage
        {
            get { return projectPageHelper; }
        }
        public MemoQHelper MemoQ
        {
            get { return memoQHelper; }
        }
        
    }
}
