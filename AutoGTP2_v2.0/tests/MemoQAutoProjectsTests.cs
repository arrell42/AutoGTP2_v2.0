using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace AutoGTP2Tests
{
    //[TestFixture]
    public class MemoQAutoProjectsTests : AuthTestBase
    {
        // 16 - Проект с 1 услугой, 1 исходным языком и 1 исходным файлом
        //[Test]
        public void CreatePendingProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "CreatePendingProject " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                Status = "Pending",
                BudgetCost = "Unknown"
            };

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.Projects.CreatePendingProject(projectData);
            List<ProjectData> newProjects = app.Projects.GetProjectList();

            oldProjects.Add(projectData); //добавляет данные в старый список
            if (oldProjects.Count > 20)
            {
                oldProjects.RemoveAt(oldProjects.Count - 2);
            }
            oldProjects.Sort(); // сортировка старого списка
            newProjects.Sort(); // сортировка нового списка

            Assert.AreEqual(oldProjects, newProjects); // сравнение списков 
        }



    }
}
