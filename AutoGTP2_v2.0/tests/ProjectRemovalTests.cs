using NUnit.Framework;
using System;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectConfirmTest()
        {
            if (applicationManager.Project.ProjectDeleteButtonIsDisabled())
            {
                ProjectData projectData = new ProjectData()
                {
                    ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
                };
                applicationManager.Project.CreatePendingProject(projectData);
            }

            applicationManager.Project.RemoveProjectConfirm();
        }

        [Test]
        public void RemoveProjectDeclineTest()
        {
            if (applicationManager.Project.ProjectDeleteButtonIsDisabled())
            {
                ProjectData projectData = new ProjectData()
                {
                    ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
                };
                applicationManager.Project.CreatePendingProject(projectData);
            }

            applicationManager.Project.RemoveProjectDecline();            
        }


    }
}
