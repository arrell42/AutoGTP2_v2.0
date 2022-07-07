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

            applicationManager.Projects.RemoveProjectConfirm();
            // проверка, что проект удалился
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

            applicationManager.Projects.RemoveProjectDecline();
            // проверка, что проект не удалился
        }


    }
}
