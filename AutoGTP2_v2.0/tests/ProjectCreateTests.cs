﻿using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{    
    public class ProjectCreateTests : AuthTestBase
    {
        // GTP2-R-02-6, GTP2-R-02-8, GTP2-R-02-15
        [Test]
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


        // GTP2-R-03-01
        [Test]
        public void CreateExpressProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-03-01 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                Status = "Pending",
                BudgetCost = "Unknown"
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

            Assert.IsTrue(app.Projects.WarningPopupIsPresentInProject());
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
                ProjectName = "R-02-2 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
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
                ProjectName = "R-02-7 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                Status = "Ordered",
                BudgetCost = "Unknown"
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
        public void AddAndDeleteBudgetInProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-10 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                Status = "Pending",
                BudgetCost = "Unknown"
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
        public void OpenBudgetFormInProjectButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-11 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };
            
            app.Projects.OpenBudgetFormInProject(projectData);

            Assert.IsTrue(app.Projects.NewBudgetFormIsPresent());
            Assert.IsFalse(app.Projects.CreateBudgetButtonIsEnabled());
        }


        // GTP2-R-02-12
        [Test]
        public void CreateBudgetInProjectExistPOTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-12 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                BudgetCost = app.Base.TextGenerator(1, 5),
                BudgetPO = "Test budget",
                BudgetTotal = "100"
            };

            app.Projects.NewBudgetInProjectExistPOInput(projectData);
                        
            Assert.IsTrue(app.Projects.NewBudgetFormIsPresent());
            Assert.IsTrue(app.Budgets.BudgetTooltipIsPresent());
            Assert.IsTrue(app.Budgets.POTooltipContainCorrectText());
        }

        // GTP2-R-02-13
        [Test]
        public void CreateBudgetInProjectExistCostTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-13 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                BudgetCost = "Test budget",
                BudgetPO = app.Base.TextGenerator(1, 5),
                BudgetTotal = "100"
            };

            app.Projects.NewBudgetInProjectExistPOInput(projectData);

            Assert.IsTrue(app.Projects.NewBudgetFormIsPresent());
            Assert.IsTrue(app.Budgets.BudgetTooltipIsPresent());
            Assert.IsTrue(app.Budgets.CostTooltipContainCorrectText());
        }

        // GTP2-R-02-14
        [Test]
        public void CreateBudgetInProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-14 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                Status = "Pending",
                BudgetCost = app.Base.TextGenerator(1, 3),
                BudgetPO = app.Base.TextGenerator(1, 5),
                BudgetTotal = "100",                
            };
            
            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.NewBudgetCreateInProject(projectData);

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

        // GTP2-R-02-16
        [Test]
        public void RefTabInProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-16 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"                                
            };

            app.Projects.OpenRefTabInProject(projectData);
            
            Assert.IsTrue(app.Projects.FileLoaderIsPresent());
            Assert.IsTrue(app.Projects.FilesAttached(0));
        }

        // GTP2-R-02-17
        [Test]
        public void RefTabInProjectFileAttachTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-17 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.RefTabInProjectFileAttach(projectData);

            Assert.IsTrue(app.Projects.FileLoaderIsPresent());
            Assert.IsTrue(app.Projects.FilesAttached(1));
        }

        // GTP2-R-02-19, // GTP2-R-02-20
        [Test]
        public void RefTabInProjectMultipleFileAttachTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "RefTabInProjectMultipleFileAttach " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.RefTabInProjectMultipleFileAttach(projectData);

            Assert.IsTrue(app.Projects.FileLoaderIsPresent());
            Assert.IsTrue(app.Projects.FilesAttached(5));
        }

        // GTP2-R-02-21
        [Test]
        public void MessagesInProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-21 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.OpenMessageTabAndSend(projectData, "test text");

            Assert.IsTrue(app.Projects.MessageIsPresent());
            Assert.IsTrue(app.Projects.MessageDateIsCorrect());
        }

        // GTP2-R-02-22
        [Test]
        public void RefFilesDownloadAllButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-22 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"                
            };            

            app.Projects.DownloadAllRefFiles(projectData);

            Assert.IsTrue(app.Projects.FilesAttached(5));
            Assert.AreEqual(app.Projects.DownloadAllFiles("RefTest"), 5);
            Assert.IsTrue(app.Projects.AllFilesIsCorrect("RefTest"));
        }

        // GTP2-R-02-23
        [Test]
        public void RefFileDescriptionTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-23 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
                
            };

            app.Projects.AddDescriptionToRefFile(projectData);

            Assert.AreEqual(app.Projects.TextInDescription(), "Test description");
        }

        // GTP2-R-02-24
        [Test]
        public void RefFileDownloadTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-24 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
                FileName = "RefTest"
            };
            
            app.Projects.DownloadRefFile(projectData);

            Assert.IsTrue(app.Projects.CheckFileDownloaded(projectData));
        }

        // GTP2-R-02-25
        [Test]
        public void RefFileDeleteTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-25 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",                
            };

            app.Projects.DeleteRefFile(projectData);

            Assert.IsTrue(app.Projects.RefFileIsDeleted());
        }

        // GTP2-R-02-26
        [Test]
        public void CancelOrderedProjectDeclineTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-26 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
            };

            app.Projects.DeclineCancellationProject(projectData);

            Assert.IsTrue(app.Projects.ProjectCardIsOpen());
            Assert.IsTrue(app.Projects.ProjectStatusIsOrdered());
        }

        // GTP2-R-02-27
        [Test]
        public void CancelOrderedProjectConfirmTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-02-27 " + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest",
            };

            app.Projects.ConfirmCancellationProject(projectData);

            Assert.IsTrue(app.Projects.FirstProjectStatusIsCancelled());
        }
    }
}
