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
    [TestFixture]
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            applicationManager.Auth.Login(new LoginData("Main_test", "123456"));            
        }
    }
}
