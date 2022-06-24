using System;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class CreateServiceTests : AuthTestBase
    {
        [Test]
        public void CreateServiceTest()
        {
            ProjectData projectData = new ProjectData()
            {
                ProjectName = "Project " + DateTime.Now.ToString("[dd.MM.yyyy HH: mm:ss]") + " autotest"
            };
            applicationManager.Service.CreateService(projectData);
        }



    }
}
