using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class ExpressProjectTests : AuthTestBase
    {
        [Test]
        public void ExpressProjectExclamationPopupTest()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            applicationManager.Projects.ExpressProjectExclamationPopup(projectData);

            Assert.IsTrue(applicationManager.Projects.ExpressProjectExclamationPopupIsPresent());
            Assert.IsTrue(applicationManager.Projects.ExpressProjectExclamationPopupIsFilled());
        }

        [Test]
        public void ExpressProjectFileAttachTest()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            applicationManager.Projects.ExpressProjectFileAttach(projectData);
            
            // добавить проверки правильного расчета
        }
        
        [Test]
        public void ExpressProjectTextAttach8000Test()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };
            
            applicationManager.Projects.ExpressProjectTextAttach8000(projectData);

            // добавить проверки правильного расчета
        }
        
    }
}
