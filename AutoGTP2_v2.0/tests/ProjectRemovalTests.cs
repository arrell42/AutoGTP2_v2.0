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
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {            
            applicationManager.Project.RemoveProjectConfirm();
        }

        [Test]
        public void RemoveProjectDeclineTest()
        {
            applicationManager.Project.RemoveProjectDecline();            
        }


    }
}
