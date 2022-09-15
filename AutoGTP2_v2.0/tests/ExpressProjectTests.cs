using NUnit.Framework;
using System;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class ExpressProjectTests : AuthTestBase
    {
        // GTP2-R-03-01
        [Test]
        public void ExpressProjectToggleOnTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectToggleOn(projectData);

            Assert.IsTrue(app.Projects.ExpressProjectTextAreaIsPresent());
        }

        // GTP2-R-03-02
        [Test]
        public void ExpressProjectToggleOnAndOffTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectToggleOnAndOff(projectData);

            Assert.IsFalse(app.Projects.ExpressProjectTextAreaIsPresent());
        }

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

        // GTP2-R-03-05
        [Test]
        public void ExpressProjectPlaceOrderTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectTextAttachAndPlaceOrder(projectData, app.expressFile7999);

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "1 out of 8,000 left");
            Assert.AreEqual(app.Projects.ExpressWordsCount(), "7999.000");
        }

        // GTP2-R-03-06
        [Test]
        public void ExpressProjectRequestQuoteTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectRequestQuote(projectData);
                        
            Assert.IsTrue(app.Projects.ExpressDeadlineIsCorrect());
            Assert.AreEqual(app.Projects.ExpressWordsCount(), "100.000");
        }


        [Test]
        public void ExpressProjectTextAttach8000Test()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"                
            };            
            
            app.Projects.ExpressProjectTextAttachAndPlaceOrder(projectData, app.expressFile8000);

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "0 out of 8,000 left");
        }

        [Test]
        public void ExpressProjectTextAttach8001Test()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectTextAttachAndPlaceOrder(projectData, app.expressFile8001);

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "-1 out of 8,000 left");
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
            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "-1 out of 8,000 left");
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
