using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class GanttChartTests : AuthTestBase
    {
        [Test]
        public void ProjectFromTableNameTest()
        {
            app.Dashport.OpenProjectFromTableName();
            Assert.IsTrue(app.Dashport.ProjectPopupIsPresent());
        }

        [Test]
        public void ProjectFromTableLineTest()
        {
            app.Dashport.OpenProjectFromTableLine();
            Assert.IsTrue(app.Dashport.ProjectPopupIsPresent());
        }

        [Test]
        public void ProjectFromTableLinePopupTest()
        {
            app.Dashport.ProjectFromTableLinePopup();
            Assert.IsTrue(app.Dashport.ProjectLinePopupIsPresent());
        }

        [Test]
        public void RegularProjectTypeTests()
        {
            app.Dashport.RegularProjectTypeFilter();
            
            Assert.IsFalse(app.Dashport.ExpressProjectsNotPresent());            
        }

        [Test]
        public void ExpressProjectTypeTests()
        {
            app.Dashport.ExpressProjectTypeFilter();
            
            Assert.IsTrue(app.Dashport.ExpressProjectsNotPresent());
        }

        [Test]
        public void ProjectStatusesOrderedFilterTests()
        {
            app.Dashport.OrderedProjectStatusesFilter();             

            Assert.IsTrue(app.Dashport.ProjectsStatusesInListIsCorrect(10, "Ordered"));
        }

        [Test]
        public void ProjectStatusesInProgressFilterTests()
        {
            app.Dashport.InProgressProjectStatusesFilter();

            Assert.IsTrue(app.Dashport.ProjectsStatusesInListIsCorrect(10, "In progress"));
        }

        [Test]
        public void ClearButtonTests()
        {
            app.Dashport.FillFilterAndClearButtonClick();

            Assert.IsTrue(app.Dashport.GanttAllButtonIsActive());
            Assert.IsTrue(app.Dashport.GanttProjectStatusesValueIsAll());
        }

        [Test]
        public void GanttCloseButtonTests()
        {
            app.Dashport.GanttClose();

            Assert.IsTrue(app.Dashport.AllDashportCardsIsPresent());            
        }

        [Test]
        public void GanttQuestionMarkPopupTests()
        {
            app.Dashport.GanttQuestionMarkPopup();

            Assert.IsTrue(app.Dashport.GanttQuestionMarkPopupIsPresent());
            Assert.IsTrue(app.Dashport.GanttQuestionMarkPopupIsFilled());
        }

    }
}
