using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    // GTP2-R-02-6, GTP2-R-02-8, GTP2-R-02-15
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


        // GTP2-R-03-01
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
        public void CreateEmptyProjectTest()
        {
            app.Projects.CreateEmptyProject();

            Assert.IsTrue(app.Projects.WarningPopupIsPresent());
        }

        // GTP2-R-02-4, GTP2-R-02-5
        [Test]
        public void CreateEmptyProjectPopupTest()
        {
            app.Projects.EmptyProjecPopupButtons();

            Assert.IsTrue(app.Projects.ProjectListIsPresent());
        }

        // GTP2-R-02-2
        [Test]
        public void CancelButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.ProjectCancel(projectData);

            Assert.IsFalse(app.Projects.ProjectCardIsOpen());
        }


        // GTP2-R-02-7
        [Test]
        public void ProjectPlaceOrderButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.Projects.PlaceOrderProjectCreation(projectData);
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


        // GTP2-R-02-10
        [Test]
        public void AddBudgetInProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.Projects.AddAndDeleteBudgetInProject(projectData);
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


        // GTP2-R-02-11 
        [Test]
        public void CreateBudgetInProjectButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };
            
            app.Projects.CreateNewBudgetInProject(projectData);

            Assert.IsTrue(app.Projects.NewBudgetFormIsPresent());
            Assert.IsFalse(app.Projects.CreateBudgetButtonIsEnabled());
        }


        // GTP2-R-02-12
        [Test]
        public void CreateBudgetInProjectExistPOTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            BudgetData budgetData = new BudgetData("Test budget", "Test budget")
            {                
                BudgetTotal = "100"
            };

            app.Projects.NewBudgetInProjectExistPOInput(projectData, budgetData);
                        
            Assert.IsTrue(app.Projects.NewBudgetFormIsPresent());
            Assert.IsTrue(app.Budgets.PONumberPopupIsPresent());
            Assert.IsTrue(app.Budgets.POTooltipContainCorrectText());
        }


    }
}
