using NUnit.Framework;
using System;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class ExpressProjectTests : AuthTestBase
    {
        // GTP2-R-03-03
        [Test]
        public void ExpressProjectExclamationPopupTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectExclamationPopup(projectData);

            Assert.IsTrue(app.Projects.ExpressProjectExclamationPopupIsPresent());
            Assert.IsTrue(app.Projects.ExpressProjectExclamationPopupIsFilled());
        }

        [Test]
        public void ExpressProjectFileAttachTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectFileAttach(projectData);
            
            // добавить проверки правильного расчета
        }
        
        [Test]
        public void ExpressProjectTextAttach8000Test()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"                
            };            
            
            app.Projects.ExpressProjectTextAttach(projectData, app.expressFile8000);

            Assert.AreEqual(app.Projects.ExpressWordCount(), "0 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectTextAttach8001Test()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectTextAttach(projectData, app.expressFile8001);

            Assert.AreEqual(app.Projects.ExpressWordCount(), "-1 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectTextAttach7999Test()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectTextAttach(projectData, app.expressFile7999);

            Assert.AreEqual(app.Projects.ExpressWordCount(), "1 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectLimitPopupCancelButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectLimitPopupCancelButton(projectData, app.expressFile8001);

            Assert.IsTrue(app.Projects.ExpressProjectTextAreaIsPresent());
            Assert.AreEqual(app.Projects.ExpressWordCount(), "-1 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectLimitPopupSwitchButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectLimitPopupSwitchButton(projectData, app.expressFile8001);

            Assert.IsFalse(app.Projects.ExpressProjectTextAreaIsPresent());
            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
        }

    }
}
