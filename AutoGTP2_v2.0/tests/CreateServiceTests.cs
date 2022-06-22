using System;
using System.Collections.Generic;
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
    public class CreateServiceTests : AuthTestBase
    {
        [Test]
        public void CreateServiceTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            applicationManager.Service.CreateService(projectData);
        }



    }
}
