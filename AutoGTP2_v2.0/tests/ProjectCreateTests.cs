using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    public class ProjectCreateTests : AuthTestBase
    {
        [Test]
        public void CreatePendingProjectTest()
        {
            ProjectData projectData = new ProjectData("")
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            List<ProjectData> oldProjects = applicationManager.Projects.GetProjectList();

            applicationManager.Projects.CreatePendingProject(projectData);

            List<ProjectData> newProjects =  applicationManager.Projects.GetProjectList();            
            oldProjects.Add(projectData);
            oldProjects.RemoveAt(19);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
