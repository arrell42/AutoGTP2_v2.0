using NUnit.Framework;

namespace AutoGTP2Tests

{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        public void SetupApplicationManager()
        {   
            applicationManager = ApplicationManager.GetInstance();
        }
    }

}
