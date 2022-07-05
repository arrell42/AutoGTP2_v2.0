using System;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class ServiceCreateTests : AuthTestBase
    {
        [Test]
        public void CreateServiceTest()
        {
            ProjectData projectData = new ProjectData("");
                       
            applicationManager.Service.CreateService(projectData);
        }



    }
}
