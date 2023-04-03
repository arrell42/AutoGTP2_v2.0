using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;

namespace AutoGTP2Tests
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentManager()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            string dir = projectPath.ToString() + "reports\\" + DateTime.Now.ToString("[dd_MM_yyyy  hh_mm_ss]");

            if ( ! Directory.Exists(dir)) // создать папку в проекте, если ее нет
            {
                Directory.CreateDirectory(dir);
            }
            
            Console.WriteLine(projectPath.ToString());
            var reportPath = dir + "\\index.html";
            Console.WriteLine(reportPath);
            

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            Instance.AttachReporter(htmlReporter);

            Instance.AddSystemInfo("Host Name", "GTP_test");
            Instance.AddSystemInfo("Environment", "Test Environment");
            Instance.AddSystemInfo("UserName", "Denis Inozemtsev");

            htmlReporter.LoadConfig(projectPath + "report-config.xml"); // использовать настройки для файла репорта из файла конфига
            
        }

        private ExtentManager()
        {
        }
    }
}
