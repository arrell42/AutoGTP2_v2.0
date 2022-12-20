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
            if (app.Projects.DeleteButtonIsDisable())
            {
                ProjectData projectData = new ProjectData()
                {
                    ProjectName = "RemoveProjectConfirm " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                    Status = "Pending",
                    BudgetCost = "Unknown"
                };
                app.Projects.CreatePendingProject(projectData);
            }

            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.RemoveProjectConfirm();

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            oldProjects.RemoveAt(0); // удаляем первый в старом списке
            if (newProjects.Count == 20)
            {
                newProjects.RemoveAt(19); // удаляем последний в новом списке
            }

            oldProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка старого списка
            newProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка нового списка
            Assert.AreEqual(oldProjects, newProjects); // сравнение списков            
        }

        [Test]
        public void RemoveProjectDeclineTest()
        {
            if (app.Projects.DeleteButtonIsDisable())
            {
                ProjectData projectData = new ProjectData()
                {
                    ProjectName = "RemoveProjectDecline " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                    Status = "Pending",
                    BudgetCost = "Unknown"
                };
                app.Projects.CreatePendingProject(projectData);
            }

            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.RemoveProjectDecline();

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            if (oldProjects.Count > 20)
            {
                oldProjects.RemoveAt(oldProjects.Count - 2);
            }            
            oldProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка старого списка
            newProjects.Sort((x, y) => x.ProjectName.CompareTo(y.ProjectName)); // сортировка нового списка
            Assert.AreEqual(oldProjects, newProjects); // сравнение списков
        }


        // Метод для удаления ненужных проектов
        //[Test]
        public void RemoveAllPendingProjects()
        {              
            app.Projects.RemoveProject(40);
        }

    }
}
