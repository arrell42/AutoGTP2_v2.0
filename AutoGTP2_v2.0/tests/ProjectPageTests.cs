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






        //GTP2-R-04-63
        [Test]
        public void CompleteFileChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Complete");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Complete"));
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }

        //GTP2-R-04-64
        [Test]
        public void DefferedFileChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Deferred");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Deferred"));
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }

        //GTP2-R-04-65
        [Test]
        public void CancelledFileChangeTest()
        {
            app.ProjectPage.OpenProjectWithStatus("Cancelled");

            Assert.IsTrue(app.Projects.ProjectStatusIs("Cancelled"));
            Assert.IsTrue(app.Projects.ProjectOnlyForReading());
        }
    }
}
