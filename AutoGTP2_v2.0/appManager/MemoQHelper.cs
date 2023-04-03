using OpenQA.Selenium;
using System.Threading;

namespace AutoGTP2Tests
{
    public class MemoQHelper : BaseHelper
    {
        public MemoQHelper(ApplicationManager manager) : base(manager)
        {
        }
        
        public readonly By sourceFilePopup = By.XPath("//div[@class= 'ZIJuzPuVJpR9HfMlmjAo  ']");
        public readonly By assignAllPairsButton = By.XPath("//span[@class= 'btn secondary-btn']");
        



        /*======================================================================================================*/
        public MemoQHelper CreateERP_MQ_1(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();            

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }            

            return this;
        }        

        public MemoQHelper CreateERP_MQ_2(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_3(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);            
            Thread.Sleep(3000);

            AssignAllPairsButtonClick();
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(3000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_4(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            AssignAllPairsButtonClick();
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(3000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_5(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");

            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(3000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_6(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            AssignAllPairsButtonClick();

            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(3000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_7(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");
            SelectLanguagePairsForSourceFile("SourceTest3.txt", "ALL_PAIRS");

            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(3000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_8(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");            
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(200);
            manager.Services.SaveServiceButtonClick();

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(200);
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_9(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(2000);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(2000);
            manager.Services.SourceFileAttach(manager.sourceFile4);
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_10(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);            
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("German");
            SelectTargetLanguage("English");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(2000);            
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_11(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_12(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile3);
            manager.Services.SourceFileAttach(manager.sourceFile4);
            Thread.Sleep(2000);
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_13(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("German");
            SelectTargetLanguage("English");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile3);
            manager.Services.SourceFileAttach(manager.sourceFile4);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_14(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);            
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);            
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateERP_MQ_15(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_16(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }
                
        public MemoQHelper CreateERP_MQ_17(ProjectData projectData, string button)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("German");
            SelectTargetLanguage("English");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            if (button == "PO") { manager.Projects.PlaceOrderButtonClick(); }
            if (button == "RQ") { manager.Services.RequestQuoteButtonClick(); }

            return this;
        }

        public MemoQHelper CreateERP_MQ_18(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("German");
            SelectTargetLanguage("English");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }




        /*========================================= ADD FILES AND LP TO PROJECT =====================================================================*/

        public MemoQHelper CreateFILES_MQ_1(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            Thread.Sleep(1000);
            manager.Projects.SaveProjectButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_2(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            Thread.Sleep(1000);
            manager.Projects.SaveProjectButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_3(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            Thread.Sleep(1000);
            manager.Projects.SaveProjectButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.PlaceOrderButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_4(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            Thread.Sleep(1000);
            manager.Projects.PlaceOrderButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_5(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            Thread.Sleep(1000);
            manager.Projects.PlaceOrderButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_6(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            
            Thread.Sleep(1000);
            manager.Projects.PlaceOrderButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_7(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();

            Thread.Sleep(1000);
            manager.Projects.PlaceOrderButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_8(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);            

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("German");
            SelectTargetLanguage("English");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Services.RequestQuoteButtonClick();
            manager.Projects.CancelButtonInProjectCardClick();
            Thread.Sleep(2000);

            manager.Projects.OpenThisProject(projectData);
            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_9(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("German");
            SelectTargetLanguage("English");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Services.RequestQuoteButtonClick();
            manager.Projects.CancelButtonInProjectCardClick();
            Thread.Sleep(2000);

            manager.Projects.OpenThisProject(projectData);
            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Services.OpenAndEditButtonClick(2);
            manager.Services.SourceFileAttach(manager.sourceFile4);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(2000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_10(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");            

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest3.txt", "English_German");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_11(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest3.txt", "English_German");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_12(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            manager.Projects.PlaceOrderButtonClick();
            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            manager.Services.AssignAllLanguagePairsButtonClick();
            Thread.Sleep(1000);

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_13(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");            
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Projects.CancelButtonInProjectCardClick();

            manager.Projects.OpenThisProject(projectData);
            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_14(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            manager.Projects.PlaceOrderButtonClick();

            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            
            manager.Services.OpenAndEditButtonClick(2);
            manager.Services.SourceFileAttach(manager.sourceFile4);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_15(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            manager.Projects.PlaceOrderButtonClick();

            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            SelectTargetLanguage("French");
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_French");
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Projects.SaveProjectButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_16(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_Russian");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);
            manager.Services.RequestQuoteButtonClick();
            manager.Projects.PlaceOrderButtonClick();

            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            SelectTargetLanguage("French");
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);
            SelectLanguagePairsForSourceFile("SourceTest2.txt", "English_French");
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_17(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");            
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.RequestQuoteButtonClick();
            manager.Projects.PlaceOrderButtonClick();

            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            SelectTargetLanguage("French");
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest3.txt", "English_French");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }

        public MemoQHelper CreateFILES_MQ_18(ProjectData projectData)
        {
            manager.Projects.OpenNewPendingProject(projectData, 3, "00:30");
            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("German");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.CreateServiceButtonClick();
            SelectSourceLanguage("English");
            SelectTargetLanguage("Russian");
            manager.Services.SelectQuantityTypeAuto();
            manager.Services.SourceFileAttach(manager.sourceFile2);
            Thread.Sleep(3000);
            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.RequestQuoteButtonClick();
            manager.Projects.PlaceOrderButtonClick();

            manager.Projects.OpenThisProject(projectData);

            manager.Services.OpenAndEditButtonClick(1);
            SelectTargetLanguage("French");
            manager.Services.SourceFileAttach(manager.sourceFile3);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest3.txt", "English_French");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            //////////////////////////////////
            
            manager.Services.OpenAndEditButtonClick(2);
            SelectTargetLanguage("French");
            manager.Services.SourceFileAttach(manager.sourceFile4);
            Thread.Sleep(3000);

            SelectLanguagePairsForSourceFile("SourceTest.txt", "English_German");
            SelectLanguagePairsForSourceFile("SourceTest4.txt", "English_French");

            manager.Services.SaveServiceButtonClick();
            Thread.Sleep(1000);

            manager.Services.RequestQuoteButtonClick();

            return this;
        }



        //

        public MemoQHelper SelectLanguagePairsForSourceFile(string fileName, string languagePair)
        {
            WaitUntilFindElement(5, By.XPath("//div[@title= '" + fileName + "' ]//following-sibling::div[@class= 'CjLCnWG2I76az0SPKDXC']"));
            driver.FindElement(By.XPath("//div[@title= '" + fileName + "' ]//following-sibling::div[@class= 'CjLCnWG2I76az0SPKDXC']")).Click();

            WaitUntilFindElement(5, By.XPath("//div[@title= '" + fileName + "' ]//following-sibling::div[@class= 'CjLCnWG2I76az0SPKDXC']//div[contains(@id, '" + languagePair + "')]"));
            driver.FindElement(By.XPath("//div[@title= '" + fileName + "' ]//following-sibling::div[@class= 'CjLCnWG2I76az0SPKDXC']//div[contains(@id, '" + languagePair + "')]")).Click();

            manager.Base.MouseClickImitation(By.XPath("//div[@class= 'KgmT0bP0ypkY24LjD8ey']"));
            WaitUntilElementIsHide(5, By.XPath("//div[@class= 'Mk26PYjSRRDfQko0r5cP']"));
            return this;
        }

        public MemoQHelper AssignAllPairsButtonClick()
        {
            WaitUntilFindElement(5, sourceFilePopup);
            WaitUntilFindElement(5, assignAllPairsButton);
            driver.FindElement(assignAllPairsButton).Click();
            return this;
        }

        public MemoQHelper SelectSourceLanguage(string language)
        {            
            driver.FindElement(By.Name("SERVICE_SOURCE_LANG")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//p[@class = 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '"+ language +"')]")).Click();
            return this;
        }

        public MemoQHelper SelectTargetLanguage(string language)
        {
            driver.FindElement(By.XPath("//input[@name = 'SERVICE_TARGET_LANG']")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[@class = 'YxhDSz1flbKA8yowp3RE  ' ]//div[contains(text(), '"+ language + "')]")).Click();
            return this;
        }
    }
}
