using NUnit.Framework;
using System;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class LoginPageTests : TestBase
    {        
        [Test]
        //В поле Username or email ввести корректный логин.
        //В поле Password ввести корректный пароль.
        public void CorrectLoginTest()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("Main_test", "123456");
            app.Auth.CorrectLogin(account);            
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }
        
        [Test]
        //В поле Username or email ввести корректный логин с последующими 2мя пробелами.
        //В поле Password ввести корректный пароль с последующими 2мя пробелами.
        public void CorrectLoginTestWithSpacesAfter()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("dtest_user_2  ", "123456  ");
            app.Auth.CorrectLogin(account);            
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин с буквами разного регистра.
        //В поле Password ввести корректный пароль.
        public void CorrectLoginTestWithCamelStyle()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("DtEsT_uSeR_2", "123456");
            app.Auth.CorrectLogin(account);            
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }        

        [Test]
        //В поле Username or email ввести некорректный логин.
        //В поле Password ввести некорретный пароль.
                
        public void IncorrectLoginTest_1()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("Main_test123", "123");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
               
        [Test]
        //В поле Username or email ввести некорректный логин.
        //В поле Password ввести корретный пароль.
        public void IncorrectLoginTest_2()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("Main_test123", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин.
        //В поле Password ввести некорретный пароль.
        public void IncorrectLoginTest_3()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("Main_test", "34235675674");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ничего не вводить.
        //В поле Password ввести текст.
        public void IncorrectLoginTest_4()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("", "qwerty");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести текст.
        //В поле Password ничего не вводить.
        public void IncorrectLoginTest_5()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("qwerty", "");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести 100+ символов.
        //В поле Password ввести текст.
        public void IncorrectLoginTest_6()
        {
            string s100 = "";
            for (int i = 0; i <= 99; i++)
            {
                s100 = s100 + "g";
            }
            app.Auth.Logout();
            LoginData account = new LoginData(s100, "qwerty");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        private string NewMethod()
        {
            throw new NotImplementedException();
        }

        [Test]
        //В поле Username or email ввести корректный логин.
        //В поле Password ввести 100+ символов.
        public void IncorrectLoginTest_7()
        {
            string s100 = "";
            for (int i = 0; i <= 99; i++)
            {
                s100 = s100 + "g";
            }
            app.Auth.Logout();
            LoginData account = new LoginData("Main_test", s100);
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести 100+ символов.
        //В поле Password ввести 100+ символов.
        public void IncorrectLoginTest_8()
        {
            string s100 = "";
            for (int i = 0; i <= 99; i++)
            {
                s100 = s100 + "g";
            }
            app.Auth.Logout();
            LoginData account = new LoginData(s100, s100);
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести пробелы.
        //В поле Password ввести пробелы.
        public void IncorrectLoginTest_9()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("     ", "     ");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин.
        //В поле Password ничего не вводить.
        public void IncorrectLoginTest_10()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("Main_test123", "123");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ничего не вводить.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_11()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный пароль.
        //В поле Password ввести корректный логин.
        public void IncorrectLoginTest_12()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("123456", "Main_test");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести скрипт.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_13()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("<script>alert(123)</script>", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести html теги.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_14()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("(<form action=»http://live.hh.ru»><input type=»submit»></form>)", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести сложную последовательность символов.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_15()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("@#$%^&*()<->1!,.", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин с лидирующим пробелом.
        //В поле Password ввести корректный пароль с лидирующим пробелом.
        public void IncorrectLoginTest_16()
        {
            app.Auth.Logout();
            LoginData account = new LoginData(" Main_test", " 123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
                
        [Test]
        //В поле Username or email ввести сложную последовательность символов.
        //В поле Password ввести сложную последовательность символов.
        public void IncorrectLoginTest_17()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("@#$%^&*()<->1!,.", "@#$%^&*()<->1!,.");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин на кириллице.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_18()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("Еуыеукф_еуые", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин, обрамив его рамками.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_19()
        {
            app.Auth.Logout();
            LoginData account = new LoginData("<Main_test>", "123456");
            app.Auth.IncorrectLogin(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
        
    }
}
