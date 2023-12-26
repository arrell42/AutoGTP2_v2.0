using NUnit.Framework;
using System;
using System.Threading;

/*
Эти методы созданы для быстрого формирования нужных условий. Сами уведомления нужно проверять вручную на почте.

Триггеры: 
New project created in GTP - нет необходимости создавать проверку отдельно, проверяется при прохождении других тестов
Project cancelled in GTP
Project's end/start date changed
Project's budget changed
Project's subject area changed
Service adding to an existing project
Service deleted in project
Sorce file were loaded into a project
Reference files were loaded
Chat message was written
*/
namespace AutoGTP2Tests
{
    public class NotificationGTPTests : AuthTestBase
    {
        readonly int i = 180000;

        // Project cancelled in GTP
        [Test]

        public void ProjectCancelledInGTPTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ProjectCancelled" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.CancelOrderedProject(projectData);

            Assert.IsTrue(app.Projects.ProjectStatusIs("Cancelled"));
            Thread.Sleep(i);
        }

        // Project's end/start date changed
        [Test]
        
        public void ProjectDateChangedInGTPTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ProjectDateChanged" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            }; 
        
            int daysFromStartDate = app.Base.AddRandomNumberFrom1To5();
            app.Projects.ChangeDateInOrderedProject(projectData, daysFromStartDate);

            Assert.IsTrue(app.Projects.EndDateIsCorrect(daysFromStartDate));
            //Thread.Sleep(i);
        }
        

        // Project's budget changed
        [Test]

        public void ProjectBudgetChangedInGTPTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ProjectDateChanged" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };
                        
            app.Projects.FindAndOpenOrderedProject(projectData);
            
            string oldBudget = app.Projects.GetBudgetName();                        
            app.Projects.SelectBudget();
            string newBudget = app.Projects.GetBudgetName();

            // Проверка, что бюджет сменился
            Assert.AreNotEqual(oldBudget, newBudget);

            app.Projects.SaveProjectButtonClick();
            Thread.Sleep(i);
        }

        // Project's subject area changed
        [Test]

        public void ProjectSAChangedInGTPTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ProjectSAChanged" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.FindAndOpenOrderedProject(projectData);

            string oldSA = app.Projects.GetSAName();
            app.Projects.SelectSA();
            string newSA = app.Projects.GetSAName();

            // Проверка, что тематика сменилась
            Assert.AreNotEqual(oldSA, newSA);

            app.Projects.SaveProjectButtonClick();
            Thread.Sleep(i);
        }

        // Service adding to an existing project
        [Test]

        public void NewServiseAddingToExistingProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "NewServiseAdding" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            ServiceData serviceData = new ServiceData("100");

            app.Projects.AddNewServiceInOrderedProject(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "100.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());

            app.Projects.SaveProjectButtonClick();
            Thread.Sleep(i);
        }

        // Service deleted in project
        [Test]

        public void ServiceDeletedInExistingProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ServiseADeleted" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.DeleteServiceInOrderedProject(projectData);

            Thread.Sleep(i);
        }

        // Sorce file were loaded into a project
        [Test]

        public void NewSourceFileLoadedIntoProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "NewSourceFile" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.AddNewSourceFileIntoProject(projectData);
            Thread.Sleep(i);
        }

        // Reference files were loaded
        [Test]

        public void ReferenceFileLoadedIntoOrderedProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "AddRefFile" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.AddReferenceFileIntoOrderedProject(projectData);

            Assert.IsTrue(app.Projects.FileLoaderIsPresent());
            Assert.IsTrue(app.Projects.FilesAttached(1));

            Thread.Sleep(i);
        }


        // Chat message was written
        [Test]

        public void ChatMessageWasWrittenInOrderedProjectTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ChatMessage" + DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]") + " autotest"
            };

            app.Projects.WriteChatMessageInOrderedProject(projectData);
                        
            Thread.Sleep(i);
        }
    }

}
