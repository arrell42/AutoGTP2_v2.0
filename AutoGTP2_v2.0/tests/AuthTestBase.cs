using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new LoginData("Main_test", "123456"));
            //applicationManager.Auth.Login(new LoginData("Denis Inozemtsev CR", "xe3q7z-"));
        }
    }
}
