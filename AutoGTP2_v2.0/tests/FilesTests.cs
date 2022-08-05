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
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            app.Services.DownloadSourceFileFromEditPage(projectData);

            Assert.IsTrue(app.Services.CheckFileDownloaded(filename));
        }

        [Test]
        public void DownloadSourceFileFromServiceListTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            app.Services.DownloadSourceFileFromServiceList(projectData);

            Assert.IsTrue(app.Services.CheckFileDownloaded(filename));
        }

        [Test]
        public void DownloadCATLogFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
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
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.SourceFileRemove(projectData);

            Assert.IsTrue(app.Services.SourceFileIsRemoved());
        }

        [Test]
        public void UploadInvalidSourceFileTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };

            app.Services.UploadInvalidSourceFile(projectData);

            Assert.IsTrue(app.Services.CircleNextToTheFilePopupIsPresent());
        }


    }
}
