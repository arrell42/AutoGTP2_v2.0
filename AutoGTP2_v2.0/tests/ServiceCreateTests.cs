using System;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class ServiceCreateTests : AuthTestBase
    {
        [Test]
        public void ServiceCancelButtonTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("100");

            applicationManager.Services.ServiceCancelButton(projectData, serviceData);

            Assert.IsTrue(applicationManager.Services.PlugItemIsPresent());
        }

        [Test]
        public void ServiceManualCorrectQuantityTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("100");

            applicationManager.Services.ServiceManualCorrectQuantity(projectData, serviceData);

            Assert.AreEqual(applicationManager.Services.QuantityTextValue(), "100.00");
            Assert.IsTrue(applicationManager.Services.ServiceIsCalculated());
        }

        [Test]
        public void ServiceManualQuantityWordTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("word");

            applicationManager.Services.ServiceCreateManualQuantityWord(projectData, serviceData);

            Assert.AreEqual(applicationManager.Services.QuantityTextValue(), "0.00");
            Assert.IsTrue(applicationManager.Services.ServiceIsNotCalculated());
        }

        [Test]
        public void ServiceManualQuantityZeroFirstTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("00078");

            applicationManager.Services.ServiceCreateManualQuantityZeroFirst(projectData, serviceData);

            Assert.AreEqual(applicationManager.Services.QuantityTextValue(), "78.00");
            Assert.IsTrue(applicationManager.Services.ServiceIsCalculated());
        }

        [Test]
        public void ServiceManualQuantityMinusTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("-190");

            applicationManager.Services.ServiceCreateManualQuantityMinus(projectData, serviceData);

            Assert.AreEqual(applicationManager.Services.QuantityTextValue(), "190.00");
            Assert.IsTrue(applicationManager.Services.ServiceIsCalculated());
        }





    }
}
