using System;
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
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [TestFixtureSetUp]
        public void SetupTest()
        {
            applicationManager = new ApplicationManager();
            
            applicationManager.Auth.Login(new LoginData("Main_test", "123456"));
            applicationManager.WaitUntilLogoutButtonDisplay();
        }
    }

}
