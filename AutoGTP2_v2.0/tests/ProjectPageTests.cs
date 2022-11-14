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
    }
}
