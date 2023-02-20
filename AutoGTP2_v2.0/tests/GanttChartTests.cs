﻿using NUnit.Framework;
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
            Assert.IsTrue(app.Dashport.ProjectCardIsOpen());
        }

        [Test]
        public void ProjectFromTableLineTest()
        {
            app.Dashport.OpenProjectFromTableLine();
            Assert.IsTrue(app.Dashport.ProjectCardIsOpen());
        }

        [Test]
        public void ProjectFromTableLinePopupTest()
        {
            app.Dashport.ProjectFromTableLinePopup();
            Assert.IsTrue(app.Dashport.ProjectLinePopupIsPresent());
        }

        [Test]
        public void RegularProjectTypeTest()
        {
            app.Dashport.RegularProjectTypeFilter();
            
            Assert.IsFalse(app.Dashport.ExpressProjectsPresent());            
        }

        [Test]
        public void ExpressProjectTypeTest()
        {
            app.Dashport.ExpressProjectTypeFilter();
            
            Assert.IsTrue(app.Dashport.ExpressProjectsPresent());
        }

        [Test]
        public void ProjectStatusesOrderedFilterTest()
        {
            app.Dashport.OrderedProjectStatusesFilter();             

            Assert.IsTrue(app.Dashport.ProjectsStatusesInListIsCorrect(10, "Ordered"));
        }

        [Test]
        public void ProjectStatusesInProgressFilterTest()
        {
            app.Dashport.InProgressProjectStatusesFilter();

            Assert.IsTrue(app.Dashport.ProjectsStatusesInListIsCorrect(10, "In progress"));
        }

        [Test]
        public void ClearButtonTest()
        {
            app.Dashport.FillFilterAndClearButtonClick();

            Assert.IsTrue(app.Dashport.GanttAllButtonIsActive());
            Assert.IsTrue(app.Dashport.GanttProjectStatusesValueIsAll());
        }

        [Test]
        public void GanttCloseButtonTest()
        {
            app.Dashport.GanttClose();

            Assert.IsTrue(app.Dashport.AllDashportCardsIsPresent());            
        }

        [Test]
        public void GanttQuestionMarkPopupTest()
        {
            app.Dashport.GanttQuestionMarkPopup();

            Assert.IsTrue(app.Dashport.GanttQuestionMarkPopupIsPresent());
            Assert.IsTrue(app.Dashport.GanttQuestionMarkPopupIsFilled());
        }

        // GTP2-R-01-23
        [Test]
        public void FeedbackFormButtonTest()
        {
            app.Dashport.FeedbackButtonClickInDashport();

            Assert.IsTrue(app.Dashport.NewTabOpenedWithCorrectURL());
        }

    }
}
