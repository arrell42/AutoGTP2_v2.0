using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace AutoGTP2Tests
{
    public class ApplicationManager
    {        
        protected IWebDriver driver;                
        protected string baseURL;
        public string sourceFilePath;
        public string CATLogFilePath;
        public string invalidSourceFilePath;
        public string expressFile8000;
        public string expressFile8001;
        public string expressFile7999;
        public string test;

        //HELPERS ADD 
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected BudgetHelper budgetHelper;
        protected ProjectHelper projectHelper;
        protected ServiceHelper serviceHelper;        

        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public IWebDriver Driver { get { return driver; } }

        
        // Начало теста - открыть браузер, перейти на нужную страницу, инициализация хелперов
        private ApplicationManager()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            driver = new ChromeDriver(options);            
                        
            baseURL = "https://gtp-test.janusww.com:9999";            
            sourceFilePath = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\SourceTest.txt";
            CATLogFilePath = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\memoQ.csv";
            invalidSourceFilePath = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\InvaildSourceFileTest.dwg";
            expressFile8000 = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\Express8000.txt";
            expressFile8001 = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\Express8001.txt";
            expressFile7999 = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\Express7999.txt";
            test = @"C:\Users\d_inozemtsev\source\repos\AutoGTP2_v2.0\AutoGTP2_v2.0\Files\test.txt";

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

    }
}
