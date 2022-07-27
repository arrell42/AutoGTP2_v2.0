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

            app.Services.ServiceCancelButton(projectData, serviceData);

            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }

        [Test]
        public void ServiceManualCorrectQuantityTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceManualCorrectQuantity(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "100.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());
            Assert.AreEqual(app.Services.QuantityPriceMultiplication(), 
                app.Services.ServiceCostValueText());
        }

        [Test]
        public void ServiceManualQuantityWordTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("word");

            app.Services.ServiceCreateManualQuantityWord(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "0.00");
            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
        }

        [Test]
        public void ServiceManualQuantityZeroFirstTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("00078");

            app.Services.ServiceCreateManualQuantityZeroFirst(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "78.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());
        }

        [Test]
        public void ServiceManualQuantityMinusTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData serviceData = new ServiceData("-190");

            app.Services.ServiceCreateManualQuantityMinus(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "190.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());
        }

        [Test]
        public void ServiceCreateAutoCountTest()
        {
            ProjectData projectData = new ProjectData("");

            app.Services.ServiceCreateAutoCount(projectData);

            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
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

            app.Services.ServiceCreateCATLog(projectData);

            Assert.IsTrue(app.Services.ServiceIsCalculated());
            Assert.AreEqual(app.Services.QuantityTextValue(), "CAT log file");
            Assert.IsTrue(app.Services.ServiceEditButtonIsPresent());
            Assert.IsTrue(app.Services.ServiceStatisticsButtonIsPresent());
        }

        [Test]
        public void ServiceCATLogWithOutCATFileTest()
        {
            ProjectData projectData = new ProjectData("");

            app.Services.ServiceCATLogWithOutCATFile(projectData);

            Assert.IsTrue(app.Services.WarningPopupIsPresent());
        }

        [Test]
        public void ServiceCATLogWithOutCATFileContinueButtonTest()
        {
            ProjectData projectData = new ProjectData("");

            app.Services.ServiceCATLogWithOutCATFileContinueButton(projectData);

            Assert.IsFalse(app.Services.WarningPopupIsPresent());
            Assert.IsFalse(app.Services.PlugItemIsPresent());
        }

        [Test]
        public void ServiceCATLogWithOutCATFileCancelButtonTest()
        {
            ProjectData projectData = new ProjectData("");

            app.Services.ServiceCATLogWithOutCATFileCancelButton(projectData);

            Assert.IsFalse(app.Services.WarningPopupIsPresent());
            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }


    }
}
