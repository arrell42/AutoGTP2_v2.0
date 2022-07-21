using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectConfirmTest()
        {
            if (applicationManager.Projects.ProjectDeleteButtonIsDisabled())
            {
                ProjectData projectData = new ProjectData("")
                {
                    ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
                };
                applicationManager.Projects.CreatePendingProject(projectData);
            }

            List<ProjectData> oldProjects = applicationManager.Projects.GetProjectList();

            applicationManager.Projects.RemoveProjectConfirm();

            List<ProjectData> newProjects = applicationManager.Projects.GetProjectList();            
            
            if (oldProjects.Count > 20)
            {
                oldProjects.RemoveAt(oldProjects.Count - 2);
            }
            oldProjects.RemoveAt(0); // удаляем первый в старом списке
            newProjects.RemoveAt(19); // удаляем последний в новом списке
            oldProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка старого списка
            newProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка нового списка
            Assert.AreEqual(oldProjects, newProjects); // сравнение списков            
        }

        [Test]
        public void RemoveProjectDeclineTest()
        {
            if (applicationManager.Projects.ProjectDeleteButtonIsDisabled())
            {
                ProjectData projectData = new ProjectData("")
                {
                    ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
                };
                applicationManager.Projects.CreatePendingProject(projectData);
            }

            List<ProjectData> oldProjects = applicationManager.Projects.GetProjectList();

            applicationManager.Projects.RemoveProjectDecline();

            List<ProjectData> newProjects = applicationManager.Projects.GetProjectList();

            if (oldProjects.Count > 20)
            {
                oldProjects.RemoveAt(oldProjects.Count - 2);
            }            
            oldProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка старого списка
            newProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка нового списка
            Assert.AreEqual(oldProjects, newProjects); // сравнение списков
        }


    }
}
