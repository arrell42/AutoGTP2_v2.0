using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {            
            applicationManager.Project.RemoveProjectConfirm();
        }

        [Test]
        public void RemoveProjectDeclineTest()
        {
            applicationManager.Project.RemoveProjectDecline();            
        }


    }
}
