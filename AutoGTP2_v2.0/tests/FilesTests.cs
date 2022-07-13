using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class FilesTests : AuthTestBase
    {
        [Test]
        public void DownloadSourceFileFromEditPageTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            applicationManager.Services.DownloadSourceFileFromEditPage(projectData);

            Assert.IsTrue(applicationManager.Services.CheckFileDownloaded(filename));
        }

        [Test]
        public void DownloadSourceFileFromServiceListTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData filename = new ServiceData("")
            {
                FileName = "SourceTest"
            };

            applicationManager.Services.DownloadSourceFileFromServiceList(projectData);

            Assert.IsTrue(applicationManager.Services.CheckFileDownloaded(filename));
        }

        [Test]
        public void DownloadCATLogFileTest()
        {
            ProjectData projectData = new ProjectData("");
            ServiceData filename = new ServiceData("")
            {
                FileName = "memoQ"
            };

            applicationManager.Services.DownloadCATLogFile(projectData);

            Assert.IsTrue(applicationManager.Services.CheckFileDownloaded(filename));
        }

        [Test]
        public void SourceFileRemoveTest()
        {
            ProjectData projectData = new ProjectData("");                        

            applicationManager.Services.SourceFileRemove(projectData);

            Assert.IsTrue(applicationManager.Services.SourceFileIsRemoved());
        }

        [Test]
        public void UploadInvalidSourceFileTest()
        {
            ProjectData projectData = new ProjectData("");

            applicationManager.Services.UploadInvalidSourceFile(projectData);

            Assert.IsTrue(applicationManager.Services.CircleNextToTheFilePopupIsPresent());
        }


    }
}
