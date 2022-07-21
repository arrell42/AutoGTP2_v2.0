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
            
            applicationManager.Projects.ExpressProjectTextAttach(projectData, applicationManager.expressFile8000);

            Assert.AreEqual(applicationManager.Projects.ExpressWordCount(), "0 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectTextAttach8001Test()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            applicationManager.Projects.ExpressProjectTextAttach(projectData, applicationManager.expressFile8001);

            Assert.AreEqual(applicationManager.Projects.ExpressWordCount(), "-1 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectTextAttach7999Test()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            applicationManager.Projects.ExpressProjectTextAttach(projectData, applicationManager.expressFile7999);

            Assert.AreEqual(applicationManager.Projects.ExpressWordCount(), "1 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectLimitPopupCancelButtonTest()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            applicationManager.Projects.ExpressProjectLimitPopupCancelButton(projectData, applicationManager.expressFile8001);

            Assert.IsTrue(applicationManager.Projects.ExpressProjectTextAreaIsPresent());
            Assert.AreEqual(applicationManager.Projects.ExpressWordCount(), "-1 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectLimitPopupSwitchButtonTest()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            applicationManager.Projects.ExpressProjectLimitPopupSwitchButton(projectData, applicationManager.expressFile8001);

            Assert.IsFalse(applicationManager.Projects.ExpressProjectTextAreaIsPresent());
            Assert.IsTrue(applicationManager.Services.ServiceIsNotCalculated());
        }

    }
}
