using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class ServiceCreateTests : AuthTestBase
    {
        // GTP2-R-05-19
        [Test]
        public void ServiceCancelButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-19 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceCancelButton(projectData, serviceData);

            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }


        // GTP2-R-05-01, GTP2-R-05-19
        [Test]
        public void ServiceManualCorrectQuantityTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ServiceManualCorrectQuantity " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("100");

            app.Services.ServiceManualCorrectQuantity(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "100.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());
            Assert.AreEqual(app.Services.QuantityPriceMultiplication(), 
                app.Services.ServiceCostValueText());
        }


        // GTP2-R-05-02
        [Test]
        public void ServiceManualQuantityWordTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-02 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("word");

            app.Services.ServiceCreateManualQuantityWord(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "0.00");
            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
        }


        // GTP2-R-05-04
        [Test]
        public void ServiceManualQuantityZeroFirstTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-04 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("00078");

            app.Services.ServiceCreateManualQuantityZeroFirst(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "78.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());
        }

        // GTP2-R-05-33
        [Test]
        public void ServiceManualQuantityMinusTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-33 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData("-190");

            app.Services.ServiceCreateManualQuantityMinus(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "190.00");
            Assert.IsTrue(app.Services.ServiceIsCalculated());
        }

        // GTP2-R-05-05
        [Test]
        public void ServiceCreateAutoCountTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-05 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"                
            };

            app.Services.ServiceCreateAutoCount(projectData);

            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
            Assert.AreEqual(app.Services.SourceFileName(), "SourceTest.txt");
        }

        // GTP2-R-05-34
        [Test]
        public void ServiceAutoCountRequestQuoteTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-34 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ServiceAutoCountRequestQuote(projectData);

            Assert.IsTrue(app.Services.ServiceIsCalculated());
            Assert.AreEqual(app.Services.QuantityTextValue(), "Auto");
            Assert.AreNotEqual(app.Services.TotalAmountText(), "0.00");
            Assert.AreNotEqual(app.Services.ServiceCostValueText(), 0.00);            
            Assert.IsTrue(app.Services.ServiceEditButtonIsPresent());
            Assert.IsTrue(app.Services.ServiceStatisticsButtonIsPresent());
            Assert.AreEqual(app.Services.QuantityPriceMultiplication(), app.Services.ServiceCostValueText());
            Assert.AreEqual(app.Services.QuantityPriceMultiplication(), app.Services.ServiceCostValueTextInTable());
        }


        // GTP2-R-05-08
        [Test]
        public void ServiceCreateCATLogTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-08 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ServiceCreateCATLog(projectData);

            Assert.IsTrue(app.Services.ServiceIsCalculated());
            Assert.AreEqual(app.Services.QuantityTextValue(), "CAT log file");
            Assert.IsTrue(app.Services.ServiceEditButtonIsPresent());
            Assert.IsTrue(app.Services.ServiceStatisticsButtonIsPresent());
        }


        // GTP2-R-05-13
        [Test]
        public void ServiceCATLogWithoutCATFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-13 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ServiceCATLogWithOutCATFile(projectData);

            Assert.IsTrue(app.Services.WarningPopupIsPresent());
        }


        // GTP2-R-05-15
        [Test]
        public void ServiceCATLogWithOutCATFileContinueButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-15 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            app.Services.ServiceCATLogWithOutCATFileContinueButton(projectData);

            Assert.IsFalse(app.Services.WarningPopupIsPresent());
            Assert.IsFalse(app.Services.PlugItemIsPresent());
        }

        // GTP2-R-05-14
        [Test]
        public void ServiceCATLogWithOutCATFileCancelButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-14 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ServiceCATLogWithOutCATFileCancelButton(projectData);

            Assert.IsFalse(app.Services.WarningPopupIsPresent());
            Assert.IsTrue(app.Services.PlugItemIsPresent());
        }

        // GTP2-R-05-03
        [Test]
        public void ServiceManualQuantitySymbolsTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-03 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData serviceData = new ServiceData(@"!@#$%^&*(){}][-_+=|\/");

            app.Services.ServiceCreateManualQuantitySymbols(projectData, serviceData);

            Assert.AreEqual(app.Services.QuantityTextValue(), "0.00");
            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
        }

        // GTP2-R-05-09
        [Test]
        public void ServiceCATStatisticButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-09 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.OpenStatisticInCATService(projectData);

            Assert.IsTrue(app.Services.StatisticIsOpen());
            Assert.IsTrue(app.Services.TargetLanguageCanChoose());
            Assert.IsTrue(app.Services.StatisticTableIsPresent());
        }

        // GTP2-R-05-12
        [Test]
        public void ServiceCATStatisticUploadButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-12 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.AddAndDeleteCATFile(projectData);

            Assert.IsTrue(app.Services.UploadFileButtonIsPresent());
        }

        // GTP2-R-05-13
        [Test]
        public void WarningCATFileUploadTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-13 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.CATFileDeleteAndSaveService(projectData);

            Assert.IsTrue(app.Services.WarningPopupIsPresent());
            Assert.IsTrue(app.Services.WarningTextIsCorrect());
        }

        // GTP2-R-05-10
        [Test]
        public void CATToolFieldInSecondServiceTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-10 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.NewServiceWithCATCreate(projectData);

            Assert.IsTrue(app.Services.CATToolPopupIsPresentAndHaveCorrectText());            
        }

        // GTP2-R-05-16
        [Test]
        public void QuantityTypeAutoServiceSaveTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-16 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ServiceWithoutLanguagePairCreate(projectData);

            Assert.IsTrue(app.Services.ServiceIsNotCalculated());
            Assert.IsFalse(app.Services.LanguagePairIsEmpty());
            Assert.AreEqual(app.Services.QuantityTextValue(), "Auto");
        }

        // GTP2-R-05-20
        [Test]
        public void TypeOfServiceWithoutUnitTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-20 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ChangeDefaultTypeOfSerice(projectData);

            Assert.IsTrue(app.Services.SaveServiceButtonIsDisabled());
            Assert.IsTrue(app.Services.LanguagePairSelectIsDisabled(2));
        }

        // GTP2-R-05-21
        [Test]
        public void TypeOfServiceSelectWithUnitTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-21 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.ChangeDefaultTypeOfSericeAndSelectUnit(projectData);

            Assert.IsFalse(app.Services.SaveServiceButtonIsDisabled());
            Assert.IsTrue(app.Services.LanguagePairSelectIsDisabled(1));
        }

        // GTP2-R-05-23
        [Test]
        public void SubjectAreaInServiceTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-23 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.SecondSelectSubjectAreaInService(projectData);

            Assert.IsTrue(app.Services.LanguagesFieldsAreEmpty());
        }

        // GTP2-R-05-25
        [Test]
        public void ServiceWithTwoLanguagePairsTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-25 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.CreateServiceWithTwoLanguagePairs(projectData);

            Assert.IsTrue(app.Services.SourceFileTableIsPresent());
            Assert.IsTrue(app.Services.FileNameIsPresentAndCorrect());
            Assert.IsTrue(app.Services.LanguagePairsFieldIsEmpty());
            Assert.IsTrue(app.Services.ActionColumnHaveButtons());

        }

        // GTP2-R-05-26
        [Test]
        public void LanguagePairsTableInService_SourceFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-26 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.CreateServiceWithAllPairsCheckBoxClick(projectData);

            Assert.IsTrue(app.Services.FirstLanguagePairCheckBoxIsEnabled()); 
            Assert.AreEqual(app.Services.DropdownLanguagePairsCount(), 1); 
        }

        // GTP2-R-05-27
        [Test]
        public void DescriptionInLanguagePairsTableTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-27 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.AddDescriptionInLanguagePairsTable(projectData);

            Assert.AreEqual(app.Services.TextInDescription(), "Test description");
        }

        // GTP2-R-05-28
        [Test]
        public void DownloadFileFromLanguagePairsTableTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-28 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            app.Services.DownloadFileFromLanguagePairsTable(projectData);

            Assert.IsTrue(app.Services.CheckFileDownloaded(filename));
        }

        // GTP2-R-05-29
        [Test]
        public void DeleteFileFromLanguagePairsTableTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-29 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };            

            app.Services.DeleteFileFromLanguagePairsTable(projectData);

            Assert.IsFalse(app.Services.LanguagePairsTableIsHide());
        }

        // GTP2-R-05-31
        [Test]
        public void TwoLanguagePairs_CATFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-31 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.CreateServiceWithTwoLanguagePairsAndCATFile(projectData);

            Assert.IsFalse(app.Services.LanguagePairsTableIsHide());
            Assert.IsTrue(app.Services.CATTableIsPresent());
            Assert.AreEqual(app.Services.TableLinesCount(), 2);
        }

        // GTP2-R-05-35
        [Test]
        public void AssignAllLanguagePairsButtonTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-35 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.AssignAllLanguagePairsButtonInServiceClick(projectData);

            Assert.AreEqual(app.Services.DropdownLanguagePairsCount(), 2);
            Assert.IsTrue(app.Services.AllPairsCheckboxIsEnabled());
            Assert.AreEqual(app.Services.LanguageCheckboxIsEnabledCount(), 2);
        }

        //GTP2-R-05-32
        [Test]
        public void BigProjectE2ETest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "BigProjectE2E " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest",
                Status = "Manual evaluation",
                BudgetCost = app.Base.TextGenerator(1, 3),
                BudgetPO = app.Base.TextGenerator(1, 5),
                BudgetTotal = "100000"
            };
            ServiceData serviceData500 = new ServiceData("500");
            ServiceData serviceData15000 = new ServiceData("15000");
            ServiceData serviceData2000 = new ServiceData("2000");

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            
            app.Services.ProjectE2ECreate(projectData, serviceData500, serviceData15000, serviceData2000);

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            oldProjects.Add(projectData); //добавляет данные в старый список
            if (oldProjects.Count > 20)
            {
                oldProjects.RemoveAt(oldProjects.Count - 2);
            }
            oldProjects.Sort(); // сортировка старого списка
            newProjects.Sort(); // сортировка нового списка
            Assert.AreEqual(oldProjects, newProjects); // сравнение списков 


        }
    }
}
