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

        [Test]
        public void ServiceCreateAutoCountTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.ServiceCreateAutoCount(projectData);

            Assert.IsTrue(applicationManager.Services.ServiceIsNotCalculated());
        }

        /*
        [Test]
        public void ServiceAutoCountRequestQuoteTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.ServiceAutoCountRequestQuote(projectData);

            Assert.IsTrue(applicationManager.Services.ServiceIsCalculated());
            Assert.AreEqual(applicationManager.Services.QuantityTextValue(), "Auto");
            //Assert.AreNotEqual(applicationManager.Services.TotalAmountText(), "0.00");
            //Assert.AreNotEqual(applicationManager.Services.ServiceCostValueText(), 0.00);
            Assert.AreEqual(applicationManager.Services.ServiceCostValueText(), 0.00);
            //Assert.IsTrue(applicationManager.Services.ServiceEditButtonIsPresent());
            //Assert.IsTrue(applicationManager.Services.ServiceStatisticsButtonIsPresent());
            Assert.AreEqual(applicationManager.Services.QuantityPriceMultiplication(), applicationManager.Services.ServiceCostValueText());
            Assert.AreEqual(applicationManager.Services.QuantityPriceMultiplication(), applicationManager.Services.ServiceCostValueTextInTable());
        }
        */

        [Test]
        public void ServiceCreateCATLogTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.ServiceCreateCATLog(projectData);

            Assert.IsTrue(applicationManager.Services.ServiceIsCalculated());
            Assert.AreEqual(applicationManager.Services.QuantityTextValue(), "CAT log file");
            Assert.IsTrue(applicationManager.Services.ServiceEditButtonIsPresent());
            Assert.IsTrue(applicationManager.Services.ServiceStatisticsButtonIsPresent());
        }

        [Test]
        public void ServiceCATLogWithOutCATFileTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.ServiceCATLogWithOutCATFile(projectData);

            Assert.IsTrue(applicationManager.Services.WarningPopupIsPresent());
        }

        [Test]
        public void ServiceCATLogWithOutCATFileContinueButtonTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.ServiceCATLogWithOutCATFileContinueButton(projectData);

            Assert.IsFalse(applicationManager.Services.WarningPopupIsPresent());
            Assert.IsFalse(applicationManager.Services.PlugItemIsPresent());
        }

        [Test]
        public void ServiceCATLogWithOutCATFileCancelButtonTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.ServiceCATLogWithOutCATFileCancelButton(projectData);

            Assert.IsFalse(applicationManager.Services.WarningPopupIsPresent());
            Assert.IsTrue(applicationManager.Services.PlugItemIsPresent());
        }


    }
}
