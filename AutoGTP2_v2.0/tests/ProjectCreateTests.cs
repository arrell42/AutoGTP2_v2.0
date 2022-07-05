using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    public class ProjectCreateTests : AuthTestBase
    {
        [Test]
        public void CreateProjectTest()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            applicationManager.Project.CreatePendingProject(projectData);

        }

    }
}
