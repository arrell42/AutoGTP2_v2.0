using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    public class ProjectPageTests : AuthTestBase
    {
        // GTP2-R-04-08
        [Test]        
        public void ProjectsColumnButtonClickTest()
        {
            app.ProjectPage.ProjectsColumnButtonClick();

            Assert.IsTrue(app.ProjectPage.ColumnsListIsOpen());
        }

        // GTP2-R-04-13
        [Test]
        public void ClearFilterTest()
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.ProjectPage.FillFilterAndClearButtonClick();

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            Assert.AreEqual(oldProjects, newProjects);
        }

        //GTP2-R-04-14
        //[Test]
        public void FilterExpressProjectTest()
        {
            app.ProjectPage.SelectStatusInFilter();            

            
        }



        //GTP2-R-04-40
        [Test]
        public void ShownOnPage50Test()
        {
            app.ProjectPage.SelectProjectCountOnPage("50");

            Assert.IsTrue(app.ProjectPage.ProjectCountOnPage(50));
        }

        //GTP2-R-04-41
        [Test]
        public void ShownOnPage100Test()
        {
            app.ProjectPage.SelectProjectCountOnPage("100");

            Assert.IsTrue(app.ProjectPage.ProjectCountOnPage(100));
        }

        //GTP2-R-04-42
        [Test]
        public void ShownOnPage20Test()
        {
            app.ProjectPage.SelectProjectCountOnPage("20");

            Assert.IsTrue(app.ProjectPage.ProjectCountOnPage(20));
        }

        //GTP2-R-04-44
        [Test]
        public void EditButtonInProjectBurgerTest()
        {
            app.ProjectPage.EditButtonInBurgerClick();

            Assert.IsTrue(app.Projects.SourceDataTabIsOpened());
        }

        //GTP2-R-04-45
        [Test]
        public void MessageButtonInProjectBurgerTest()
        {
            app.ProjectPage.OpenMessagesFromProjectBurger();

            Assert.IsTrue(app.Projects.MessageTabIsOpened());
        }

        //GTP2-R-04-47
        [Test]
        public void QuotationCompletedStatusDeleteTest()
        {
            app.ProjectPage.OpenBurgerForQuotationCompletedStatusProject("Quotation completed");

            Assert.IsTrue(app.Projects.WarningPopupWhenDeleteProjectIsPresent());
        }

        //GTP2-R-04-58
        [Test]
        public void PendingProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Pending");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Pending"));
            Assert.IsTrue(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectCanBeChanged());
        }

        //GTP2-R-04-59
        [Test]
        public void ManualEvaluationProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Manual evaluation");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Manual evaluation"));
            Assert.IsFalse(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }

        //GTP2-R-04-60
        [Test]
        public void QuotationCompletedProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Quotation completed");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Quotation completed"));
            Assert.IsTrue(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectCanBeChanged());
        }

        //GTP2-R-04-61
        [Test]
        public void OrderedProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Ordered");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Ordered"));
            Assert.IsFalse(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectCanBeChanged());
        }

        //GTP2-R-04-62
        [Test]
        public void InProgressProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("In progress");

            Assert.IsTrue(app.Projects.ProjectStatusIs("In progress"));
            Assert.IsFalse(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }

        //GTP2-R-04-63
        [Test]
        public void CompleteProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Complete");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Complete"));
            Assert.IsFalse(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }

        //GTP2-R-04-64
        [Test]
        public void DefferedProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Deferred");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Deferred"));
            Assert.IsFalse(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }

        //GTP2-R-04-65
        [Test]
        public void CancelledProjectChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Cancelled");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Cancelled"));
            Assert.IsFalse(app.Projects.PlaceOrderButtonIsPresent());
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }
    }
}
