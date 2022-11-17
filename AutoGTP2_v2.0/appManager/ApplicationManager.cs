using System;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace AutoGTP2Tests
{
    public class ApplicationManager
    {        
        protected IWebDriver driver;
        public string baseURL;
        public string sourceFile;
        public string CATLogFilePath;
        public string invalidSourceFilePath;
        public string expressFile8000;
        public string expressFile8001;
        public string expressFile7999;
        public string refFile;

        //HELPERS ADD 
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected BudgetHelper budgetHelper;
        protected ProjectHelper projectHelper;
        protected ServiceHelper serviceHelper;
        protected DashportHelper dashportHelper;
        protected ProjectPageHelper projectPageHelper;

        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public IWebDriver Driver { get { return driver; } }

        
        // Начало теста - открыть браузер, перейти на нужную страницу, инициализация хелперов
        private ApplicationManager()
        {
            ChromeOptions options = new ChromeOptions();            
            
            options.AddArguments("start-maximized");            
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            options.AddArguments("ignore-certificate-errors");

            driver = new ChromeDriver(options);
                        
            baseURL = "https://gtp-test.janusww.com:9999";
            //baseURL = "https://gtp2.janusww.com";
            //baseURL = "https://81.90.180.117:9999";
            sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\SourceTest.txt");
            CATLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\memoQ.csv");
            invalidSourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\InvaildSourceFileTest.dwg");
            expressFile8000 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\Express8000.txt");
            expressFile8001 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\Express8001.txt");            
            expressFile7999 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\Express7999.txt");
            refFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\RefTest.txt");

            //HELPERS INIT
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            budgetHelper = new BudgetHelper(this);
            projectHelper = new ProjectHelper(this);
            serviceHelper = new ServiceHelper(this);
            dashportHelper = new DashportHelper(this);
            projectPageHelper = new ProjectPageHelper(this);
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
            if(!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToLoginPage();
                app.Value = newInstance;                
            }
            return app.Value;
        }

        // Генератор рандомных слов        
        public static Random rnd = new Random();
        public string TextGenerator(int wrd, int let)
        {
            string result = "";
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            
            for (int i = 1; i <= wrd; i++)
            {
                string word = "";
                for(int j = 0; j < let; j++)
                {
                    int letter_num = rnd.Next(0, letters.Length - 1);
                    word += letters[letter_num];

                }
                result = result + " " + word;
            }
            return result.Trim();
        }

        

        // генерация набора случайных символов
        public string GetRandomString(int length)
        {
            var r = new Random();
            return new string(Enumerable.Range(0, length).Select(n => (Char)(r.Next(32, 127))).ToArray());
        }

        

        // Property for helpers - чтобы не делать их public
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
    }
}
