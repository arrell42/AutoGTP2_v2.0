using System;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    public class CreateProjectTests : AuthTestBase
    {
        [Test]
        public void CreateProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            applicationManager.Project.CreateProject(projectData);            
        }

    }
}
