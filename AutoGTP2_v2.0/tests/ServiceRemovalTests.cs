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

            applicationManager.Services.ServiceDeleteDecline(projectData, serviceData);

            Assert.IsFalse(applicationManager.Services.WarningOverlayIsPresent());
        }


        [Test]

        public void ServiceDeleteConfirmTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("100");

            applicationManager.Services.ServiceDeleteConfirm(projectData, serviceData);

            Assert.IsTrue(applicationManager.Services.PlugItemIsPresent());
        }
    }
}
