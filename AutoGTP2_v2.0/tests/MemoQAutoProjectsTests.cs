using NUnit.Framework;
using System;
using System.Threading;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class MemoQAutoProjectsTests : AuthTestBase
    {
        /* PLACE ORDER PROJECTS*/

        // ERP-MQ-1_PlaceOrder
        [Test]
        public void ERP_MQ_1_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-1_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_1(projectData, button);

            Thread.Sleep(30000);
        }

        // ERP-MQ-2_PlaceOrder
        [Test]
        public void ERP_MQ_2_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-2_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_2(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-3_PlaceOrder
        [Test]
        public void ERP_MQ_3_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-3_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_3(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-4_PlaceOrder
        [Test]
        public void ERP_MQ_4_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-4_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_4(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-5_PlaceOrder
        [Test]
        public void ERP_MQ_5_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-5_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_5(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-6_PlaceOrder
        [Test]
        public void ERP_MQ_6_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-6_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_6(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-7_PlaceOrder
        [Test]
        public void ERP_MQ_7_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-7_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_7(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-8_PlaceOrder
        [Test]
        public void ERP_MQ_8_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-8_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_8(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-9_PlaceOrder
        [Test]
        public void ERP_MQ_9_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-9_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_9(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-10_PlaceOrder
        [Test]
        public void ERP_MQ_10_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-10_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_10(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-11_PlaceOrder
        [Test]
        public void ERP_MQ_11_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-11_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_11(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-12_PlaceOrder
        [Test]
        public void ERP_MQ_12_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-12_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_12(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-13_PlaceOrder
        [Test]
        public void ERP_MQ_13_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-13_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_13(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-14_PlaceOrder
        [Test]
        public void ERP_MQ_14_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-14_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };            

            app.MemoQ.CreateERP_MQ_14(projectData);
            Thread.Sleep(30000);
        }

        // ERP-MQ-15_PlaceOrder
        [Test]
        public void ERP_MQ_15_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-15_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_15(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-16_PlaceOrder
        [Test]
        public void ERP_MQ_16_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-16_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_16(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-17_PlaceOrder
        [Test]
        public void ERP_MQ_17_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-17_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "PO"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_17(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-18_PlaceOrder
        [Test]
        public void ERP_MQ_18_PlaceOrder()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-18_PlaceOrder " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };            

            app.MemoQ.CreateERP_MQ_18(projectData);
            Thread.Sleep(30000);
        }



        /*======================================== REQUEST QUOTE ======================================================================*/        
        
        // ERP-MQ-1_RequestQuote
        [Test]
        public void ERP_MQ_1_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-1_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_1(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-2_RequestQuote
        [Test]
        public void ERP_MQ_2_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-2_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_2(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-3_RequestQuote
        [Test]
        public void ERP_MQ_3_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-3_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_3(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-4_RequestQuote
        [Test]
        public void ERP_MQ_4_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-4_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_4(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-5_RequestQuote
        [Test]
        public void ERP_MQ_5_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-5_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_5(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-6_RequestQuote
        [Test]
        public void ERP_MQ_6_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-6_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_6(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-7_RequestQuote
        [Test]
        public void ERP_MQ_7_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-7_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_7(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-8_RequestQuote
        [Test]
        public void ERP_MQ_8_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-8_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_8(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-9_RequestQuote
        [Test]
        public void ERP_MQ_9_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-9_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_9(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-10_RequestQuote
        [Test]
        public void ERP_MQ_10_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-10_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_10(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-11_RequestQuote
        [Test]
        public void ERP_MQ_11_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-11_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_11(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-12_RequestQuote
        [Test]
        public void ERP_MQ_12_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-12_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_12(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-13_RequestQuote
        [Test]
        public void ERP_MQ_13_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-13_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_13(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-15_RequestQuote
        [Test]
        public void ERP_MQ_15_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-15_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_15(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-16_RequestQuote
        [Test]
        public void ERP_MQ_16_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-16_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_16(projectData, button);
            Thread.Sleep(30000);
        }

        // ERP-MQ-17_RequestQuote
        [Test]
        public void ERP_MQ_17_RequestQuote()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "ERP-MQ-17_RequestQuote " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            string button = "RQ"; // RQ - request quote / PO - place order / SAVE - save and exit

            app.MemoQ.CreateERP_MQ_17(projectData, button);
            Thread.Sleep(30000);
        }



        /*======================== ADD FILES AND LP TO PROJECT ===========================================*/

        // FILES-MQ-1
        [Test]
        public void FILES_MQ_1()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_1 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_1(projectData);
        }

        // FILES-MQ-2
        [Test]
        public void FILES_MQ_2()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_2 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_2(projectData);
        }

        // FILES-MQ-3
        [Test]
        public void FILES_MQ_3()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_3 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_3(projectData);
        }

        // FILES-MQ-4
        [Test]
        public void FILES_MQ_4()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_4 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_4(projectData);
        }

        // FILES-MQ-5
        [Test]
        public void FILES_MQ_5()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_5 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_5(projectData);
        }

        // FILES-MQ-6
        [Test]
        public void FILES_MQ_6()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_6 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_6(projectData);
        }

        // FILES-MQ-7
        [Test]
        public void FILES_MQ_7()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_7 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_7(projectData);
        }

        // FILES-MQ-8
        [Test]
        public void FILES_MQ_8()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_8 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_8(projectData);
        }

        // FILES-MQ-9
        [Test]
        public void FILES_MQ_9()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_9 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_9(projectData);
        }

        // FILES-MQ-10
        [Test]
        public void FILES_MQ_10()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_10 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_10(projectData);
        }

        // FILES-MQ-11
        [Test]
        public void FILES_MQ_11()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_11 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_11(projectData);
        }

        // FILES-MQ-12
        [Test]
        public void FILES_MQ_12()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_12 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_12(projectData);
        }

        // FILES-MQ-13
        [Test]
        public void FILES_MQ_13()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_13 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_13(projectData);
        }

        // FILES-MQ-10
        [Test]
        public void FILES_MQ_14()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_14 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_14(projectData);
        }

        // FILES-MQ-15
        [Test]
        public void FILES_MQ_15()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_15 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_15(projectData);
        }

        // FILES-MQ-16
        [Test]
        public void FILES_MQ_16()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_16 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_16(projectData);
        }

        // FILES-MQ-17
        [Test]
        public void FILES_MQ_17()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_17 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_17(projectData);
        }

        // FILES-MQ-18
        [Test]
        public void FILES_MQ_18()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "FILES_MQ_18 " + DateTime.Now.ToString("[dd_MM HH_mm]")
            };

            app.MemoQ.CreateFILES_MQ_18(projectData);
        }
    }
}
