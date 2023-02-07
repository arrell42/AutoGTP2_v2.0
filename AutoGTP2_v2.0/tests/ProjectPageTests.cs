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

        //GTP2-R-04-10
        [Test]
        public void TurnOffProjectsColumnTest()
        {
            ProjectColumnsData projectColumnsData = new ProjectColumnsData()
            {
                LanguagePair = "Language pair",
                Quantity = "Quantity"
            };

            app.ProjectPage.TurnOffProjectsColumn(projectColumnsData);

            Assert.That(app.Projects.AllProjectColumns(), Has.No.Member(projectColumnsData.LanguagePair));
            Assert.That(app.Projects.AllProjectColumns(), Has.No.Member(projectColumnsData.Quantity));
            Assert.That(app.Projects.AllProjectColumns(), Has.Member("Project name"));
        }

        //GTP2-R-04-11
        [Test]
        public void TurnOffAllProjectsColumnTest()
        {
            ProjectColumnsData projectColumnsData = new ProjectColumnsData()
            {
                ProjectName = "Project name",
                Status = "Status",
                LanguagePair = "Language pair",
                Quantity = "Quantity",
                StartDate = "Start date",
                EndDate = "End date",
                TotalAmount = "Total amount",
                DateOfCreation = "Date of creation",
                Representative = "representative",
                ResponsiblePM = "Responsible PM",
                Budget = "Budget",
                Vendor = "Vendor"                
            };

            app.ProjectPage.TurnOffProjectsColumn(projectColumnsData);

            Assert.AreEqual(app.ProjectPage.CheckBoxIsDisabled(), 1);
        }

        // GTP2-R-04-13
        [Test]
        public void ClearFilterTest()
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.ProjectPage.FillFilterAndClearButtonClick(2, "start date", "01 Nov 2022", "10 Nov 2022");

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            Assert.AreEqual(oldProjects, newProjects);
        }

        //GTP2-R-04-14
        [Test]
        public void ExpressProjectTypeInFiltersTest()
        {
            app.ProjectPage.SelectProjectTypeInFilter(3);

            Assert.IsTrue(app.ProjectPage.AllProjectsInPageAreExpress());
        }

        //GTP2-R-04-15
        [Test]
        public void RegularProjectTypeInFiltersTest()
        {
            app.ProjectPage.SelectProjectTypeInFilter(2);

            Assert.IsTrue(app.ProjectPage.AllProjectsInPageAreRegular());
        }

        //GTP2-R-04-19.1
        [Test]
        public void StartDateInFiltersPopupTest()
        {
            app.ProjectPage.SelectDateTypeAndRangeInFilter("start date", "10 Nov 2022", "01 Nov 2022");

            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersIsPresent());
            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersContainsCorrectText());
        }

        //GTP2-R-04-19.2
        [Test]
        public void EndDateInFiltersPopupTest()
        {
            app.ProjectPage.SelectDateTypeAndRangeInFilter("end date", "10 Nov 2022", "01 Nov 2022");

            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersIsPresent());
            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersContainsCorrectText());
        }

        //GTP2-R-04-19.3
        [Test]
        public void CreationDateInFiltersPopupTest()
        {
            app.ProjectPage.SelectDateTypeAndRangeInFilter("date of creation", "10 Nov 2022", "01 Nov 2022");

            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersIsPresent());
            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersContainsCorrectText());
        }

        //GTP2-R-04-20
        [Test]
        public void VendorSortInFiltersTest()
        {
            app.ProjectPage.SortByVendorInFilters();

            Assert.IsTrue(app.ProjectPage.VendorInProjectIsCorrect());            
        }

        //GTP2-R-04-21
        [Test]
        public void RepresentativeSortInFiltersTest()
        {
            app.ProjectPage.SortByRepresentativeInFilters();

            Assert.IsTrue(app.ProjectPage.RepresentativeInProjectIsCorrect());
        }

        //GTP2-R-04-22
        [Test]
        public void PMSortInFiltersTest()
        {
            app.ProjectPage.SortByPMInFilters();

            Assert.IsTrue(app.ProjectPage.PMInProjectIsCorrect());
        }

        //GTP2-R-04-24
        [Test]
        public void StatusSortInFiltersTest()
        {            
            app.ProjectPage.SortByCompletedStatusInFilters();

            Assert.IsTrue(app.ProjectPage.StatusInProjectIsCorrect());
        }

        //GTP2-R-04-25
        [Test]
        public void TwoStatusesSortInFiltersTest()
        {
            app.ProjectPage.SortByDeferredAndCompletedStatusInFilters();

            Assert.IsTrue(app.ProjectPage.StatusInProjectIsCorrect());
        }

        //GTP2-R-04-26
        [Test]
        public void DeleteStatusFromStatusesListInFiltersTest()
        {
            app.ProjectPage.DeleteStatusFromStatusesList();

            Assert.IsTrue(app.ProjectPage.StatusListContainsElements(0));
        }

        // GTP2-R-04-27
        [Test]
        public void StartDateInFiltersWordTest()
        {
            app.ProjectPage.SelectDateTypeAndRangeInFilter("end date", "word", "");

            Assert.IsTrue(app.ProjectPage.StartDatePopupInFiltersIsPresent());
            Assert.IsTrue(app.ProjectPage.StartDatePopupInFiltersContainsCorrectText());
        }

        // GTP2-R-04-28
        [Test]
        public void EndDateInFiltersWordTest()
        {
            app.ProjectPage.SelectDateTypeAndRangeInFilter("end date", "10 Nov 2022", "word");

            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersIsPresent());
            Assert.IsTrue(app.ProjectPage.EndDatePopupInFiltersContainsCorrectText());
        }

        // GTP2-R-04-29
        [Test]
        public void MagnifyingGlassClickTest()
        {
            app.ProjectPage.SearchingFieldClick();

            Assert.IsTrue(app.Budgets.SearchingFieldHintIsPresent());
            Assert.IsTrue(app.Budgets.SearchingFieldCrossIsPresent());
        }

        //GTP2-R-04-31
        [Test]
        public void SearchExistingProjectWithEnterTest()
        {
            app.ProjectPage.EnterExistingProjectNameAndPushEnter();

            Assert.IsTrue(app.ProjectPage.SearchingIsCorrect());
        }

        //GTP2-R-04-32
        [Test]
        public void SearchExistingProjectWithMagnifyingGlassClickTest()
        {
            app.ProjectPage.EnterExistingProjectNameAndAndClickMagnifyingGlass();

            Assert.IsTrue(app.ProjectPage.SearchingIsCorrect());
        }

        //GTP2-R-04-33
        [Test]
        public void SearchNotExistingProjectTest()
        {
            app.ProjectPage.EnterNotExistingProjectName();

            Assert.IsTrue(app.ProjectPage.ProjectsNotFound());
        }

        //GTP2-R-04-34 / GTP2-R-04-30
        [Test]
        public void ClearSearchingFieldTest()
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.ProjectPage.EnterNotExistingProjectNameAndClearSearchingField();
            List<ProjectData> newProjects = app.Projects.GetProjectList();

            Assert.AreEqual(oldProjects, newProjects);
            Assert.True(app.ProjectPage.SearchingFieldIsEmpty());
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

        //GTP2-R-04-69
        
    }
}
