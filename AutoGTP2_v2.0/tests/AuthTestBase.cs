using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            applicationManager.Auth.Login(new LoginData("Main_test", "123456"));            
        }
    }
}
