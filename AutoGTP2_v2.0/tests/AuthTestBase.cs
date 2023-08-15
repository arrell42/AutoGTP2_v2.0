using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            
            if(app.baseURL.Contains("https://gtp-test.janusww.com:9999"))
            {
                app.Auth.Login(new LoginData("Main_test", "123456"));
                //app.Auth.Login(new LoginData("Dmitriy Semenov CR", "123456"));
                //app.Auth.Login(new LoginData("MemoQTestClient_2_User", "123456"));
                //app.Auth.Login(new LoginData("IvanTest_Copy_7User", "123456"));                
            }

            if (app.baseURL.Contains("https://gtp2.janusww.com"))
            {
                app.Auth.Login(new LoginData("Denis Inozemtsev CR", "xe3q7z-"));
                //app.Auth.Login(new LoginData("Sergey Zezyulinsky CR", "irhj-d/"));
                //app.Auth.Login(new LoginData("Albert Kasimov CR", @"4xvxcy"""));
            }

            if (app.baseURL.Contains("https://81.90.180.117:9999"))
            {
                app.Auth.Login(new LoginData("dtestHostingClient_22.11AdminUser", "123456"));
            }        
        }

    }
}
