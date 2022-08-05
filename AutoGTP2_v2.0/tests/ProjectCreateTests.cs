﻿using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    public class ProjectCreateTests : AuthTestBase
    {
        [Test]
        public void CreatePendingProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
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


        [Test]
        public void CreateExpressProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Express " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.CreateExpressProject(projectData);

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

        // GTP2-R-02-3
        [Test]
        public void CreateEmptyProjecTest()
        {
            app.Projects.CreateEmptyProject();

            Assert.IsTrue(app.Projects.WarningPopupIsPresent());
        }

        // GTP2-R-02-4, GTP2-R-02-5
        [Test]
        public void CreateEmptyProjecPopupTest()
        {
            app.Projects.EmptyProjecPopupButtons();

            Assert.IsTrue(app.Projects.ProjectListIsPresent());
        }
    }
}
