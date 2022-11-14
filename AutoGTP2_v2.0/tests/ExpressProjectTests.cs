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
        public void ExpressProject7999Test()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectTextAttachAndPlaceOrder(projectData, app.expressFile7999);

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "1 out of 8,000 left");
            Assert.That(app.Projects.ExpressWordsCount().Contains("7999"));
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
            Assert.That(app.Projects.ExpressWordsCount().Contains("100"));
        }

        // GTP2-R-03-07
        [Test]
        public void ExpressProjectFileAndTextAttachTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectFileAndTextAttach(projectData, app.sourceFile);

            Assert.IsTrue(app.Projects.ExpressDeadlineIsCorrect());
            Assert.That(app.Projects.ExpressWordsCount().Contains("200"));
        }

        // GTP2-R-03-08
        [Test]
        public void ExpressProject8001RequestQuoteTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProject8001WordsAttachAndRequestQuote(projectData, app.expressFile8001);

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "-1 out of 8,000 left");
            Assert.IsTrue(app.Projects.WordLimitModalIsOpen());
        }

        // GTP2-R-03-09
        [Test]
        public void ExpressProjectRequestQuoteThenPlaceOrderTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProject8001WordsAttachAndRequestQuoteThenPlaceOrder(projectData, app.expressFile8001);

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "-1 out of 8,000 left");
            Assert.IsTrue(app.Projects.WordLimitModalIsOpen());
        }

        // GTP2-R-03-10
        [Test]
        public void ExpressProjectTextAndFileAttachTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectTextAndFileAttachAndRequestQuote(projectData, app.expressFile8000);
            
            Assert.IsTrue(app.Projects.WordLimitModalIsOpen());
        }

        // GTP2-R-03-11
        [Test]
        public void ExpressProjectFileAttachAndPlaceOrderTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectFileAttachAndPlaceOrder(projectData);

            Assert.That(app.Projects.ExpressWordsCount().Contains("100"));
            Assert.IsTrue(app.Projects.ExpressDeadlineIsCorrect());
        }

        // GTP2-R-03-12
        [Test]
        public void ExpressProjectFileAttachThanFillTextareaTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProjectFileAttachThanFillTextarea(projectData, app.sourceFile);

            Assert.That(app.Projects.ExpressWordsCount().Contains("200"));
            Assert.IsTrue(app.Projects.ExpressDeadlineIsCorrect());
        }

        // GTP2-R-03-13
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

        // GTP2-R-03-14
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

        // GTP2-R-03-15
        [Test]
        public void ExpressProject8001PlaceOrderTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ExpressProject8001WordsAttachAndPlaceOrder(projectData, app.expressFile8001);            

            Assert.AreEqual(app.Projects.ExpressTextAreaWordCount(), "-1 out of 8,000 left");
            Assert.IsTrue(app.Projects.WordLimitModalIsOpen());
        }          
    }
}
