using NUnit.Framework;

namespace AutoGTP2Tests

{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {   
            app = ApplicationManager.GetInstance();
        }
    }

}
