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
                //app.Auth.Login(new LoginData("dtestClient191022Contact_1", "123456"));                
            }
            
            if (app.baseURL.Contains("https://gtp2.janusww.com"))
            {
                app.Auth.Login(new LoginData("Denis Inozemtsev CR", "xe3q7z-"));
                //app.Auth.Login(new LoginData("Sergey Zezyulinsky CR", "irhj-d/"));
            }

            if (app.baseURL.Contains("https://gtp-test.janusww.com:9998"))
            {
                app.Auth.Login(new LoginData("dtestBoxClient2User", "123456"));
            }        
        }

    }
}
