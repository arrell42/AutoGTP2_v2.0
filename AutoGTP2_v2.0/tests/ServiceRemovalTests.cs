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

            // Проверка наличия блока с текстом "To get a quote or place an order at least one service has to be added."
            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }
    }
}
