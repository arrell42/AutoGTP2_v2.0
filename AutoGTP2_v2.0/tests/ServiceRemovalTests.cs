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
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceDeleteDecline(projectData, serviceData);

            Assert.IsFalse(app.Services.WarningOverlayIsPresent());
        }


        [Test]

        public void ServiceDeleteConfirmTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceDeleteConfirm(projectData, serviceData);

            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }
    }
}
