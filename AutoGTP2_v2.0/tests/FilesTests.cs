using NUnit.Framework;
using System;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class FilesTests : AuthTestBase
    {
        [Test]
        public void DownloadSourceFileFromEditPageTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "DownloadSourceFileFromEditPage " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            app.Services.DownloadSourceFileFromEditPage(projectData);

            Assert.IsTrue(app.Services.CheckFileDownloaded(filename));
        }


        // GTP2-R-05-05, GTP2-R-05-06
        [Test]
        public void DownloadSourceFileFromServiceListTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "DownloadSourceFileFromServiceList " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            app.Services.DownloadSourceFileFromServiceList(projectData);

            Assert.IsTrue(app.Services.CheckFileDownloaded(filename));
        }


        // GTP2-R-05-11, GTP2-R-05-14
        [Test]
        public void DownloadCATLogFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "DownloadCATLogFile " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData filename = new ServiceData("")
            {
                FileName = "memoQ"
            };

            app.Services.DownloadCATLogFile(projectData);

            Assert.IsTrue(app.Services.CheckFileDownloaded(filename));
        }

        [Test]
        public void SourceFileRemoveTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "SourceFileRemove " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.SourceFileRemove(projectData);

            Assert.IsTrue(app.Services.SourceFileIsRemoved());
        }


        // GTP2-R-05-18
        [Test]
        public void UploadInvalidSourceFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "R-05-18 " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.UploadInvalidSourceFile(projectData);

            Assert.IsTrue(app.Services.CircleNextToTheFilePopupIsPresent());
        }


    }
}
