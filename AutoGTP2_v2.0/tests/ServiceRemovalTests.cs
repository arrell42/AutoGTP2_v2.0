using System;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class ServiceRemovalTests : AuthTestBase
    {
        [Test]
        public void ServiceDeclineTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceDeleteDecline(projectData, serviceData);

            Assert.IsFalse(app.Services.WarningOverlayIsPresent());
        }

        [Test]
        public void ServiceDeleteConfirmTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceDeleteConfirm(projectData, serviceData);

            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }
    }
}
