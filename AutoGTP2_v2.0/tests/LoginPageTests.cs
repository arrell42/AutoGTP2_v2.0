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
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Main_test", "123456");
            applicationManager.Auth.CorrectLogin(account);            
            Assert.IsTrue(applicationManager.Auth.IsLoggedIn());
        }
        
        [Test]
        //В поле Username or email ввести корректный логин с последующими 2мя пробелами.
        //В поле Password ввести корректный пароль с последующими 2мя пробелами.
        public void CorrectLoginTestWithSpacesAfter()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("dtest_user_2  ", "123456  ");
            applicationManager.Auth.CorrectLogin(account);            
            Assert.IsTrue(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин с буквами разного регистра.
        //В поле Password ввести корректный пароль.
        public void CorrectLoginTestWithCamelStyle()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("DtEsT_uSeR_2", "123456");
            applicationManager.Auth.CorrectLogin(account);            
            Assert.IsTrue(applicationManager.Auth.IsLoggedIn());
        }        

        [Test]
        //В поле Username or email ввести некорректный логин.
        //В поле Password ввести некорретный пароль.
                
        public void IncorrectLoginTest_1()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Main_test123", "123");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }
               
        [Test]
        //В поле Username or email ввести некорректный логин.
        //В поле Password ввести корретный пароль.
        public void IncorrectLoginTest_2()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Main_test123", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин.
        //В поле Password ввести некорретный пароль.
        public void IncorrectLoginTest_3()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Main_test", "34235675674");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ничего не вводить.
        //В поле Password ввести текст.
        public void IncorrectLoginTest_4()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("", "qwerty");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести текст.
        //В поле Password ничего не вводить.
        public void IncorrectLoginTest_5()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("qwerty", "");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
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
            applicationManager.Auth.Logout();
            LoginData account = new LoginData(s100, "qwerty");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
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
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Main_test", s100);
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
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
            applicationManager.Auth.Logout();
            LoginData account = new LoginData(s100, s100);
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести пробелы.
        //В поле Password ввести пробелы.
        public void IncorrectLoginTest_9()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("     ", "     ");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин.
        //В поле Password ничего не вводить.
        public void IncorrectLoginTest_10()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Main_test123", "123");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ничего не вводить.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_11()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный пароль.
        //В поле Password ввести корректный логин.
        public void IncorrectLoginTest_12()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("123456", "Main_test");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести скрипт.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_13()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("<script>alert(123)</script>", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести html теги.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_14()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("(<form action=»http://live.hh.ru»><input type=»submit»></form>)", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести сложную последовательность символов.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_15()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("@#$%^&*()<->1!,.", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин с лидирующим пробелом.
        //В поле Password ввести корректный пароль с лидирующим пробелом.
        public void IncorrectLoginTest_16()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData(" Main_test", " 123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }
                
        [Test]
        //В поле Username or email ввести сложную последовательность символов.
        //В поле Password ввести сложную последовательность символов.
        public void IncorrectLoginTest_17()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("@#$%^&*()<->1!,.", "@#$%^&*()<->1!,.");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин на кириллице.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_18()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("Еуыеукф_еуые", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }

        [Test]
        //В поле Username or email ввести корректный логин, обрамив его рамками.
        //В поле Password ввести корректный пароль.
        public void IncorrectLoginTest_19()
        {
            applicationManager.Auth.Logout();
            LoginData account = new LoginData("<Main_test>", "123456");
            applicationManager.Auth.IncorrectLogin(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn());
        }
        
    }
}
