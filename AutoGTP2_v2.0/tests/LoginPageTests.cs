﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class LoginPageTests : TestBase
    {
        // передача валидных данных
        public static IEnumerable<LoginData> CorrectLoginDataFromFile()
        {
            List<LoginData> loginData = new List<LoginData>();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\correctLoginData.csv");
            string[] lines = File.ReadAllLines(path);
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                loginData.Add(new LoginData(parts[0], parts[1]));
            }
            return loginData;
        }

        // передача НЕ валидных данных
        public static IEnumerable<LoginData> IncorrectLoginDataFromFile()
        {
            List<LoginData> loginData = new List<LoginData>();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\invalidLoginData.csv");
            string[] lines = File.ReadAllLines(path);
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                loginData.Add(new LoginData(parts[0], parts[1]));
            }
            return loginData;
        }

        // Тесты
        //[Test, TestCaseSource("CorrectLoginDataFromFile")]
        
        public void CorrectLoginTests(LoginData loginData)
        {
            app.Auth.Logout();            
            app.Auth.CorrectLogin(loginData);            
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }        

        //[Test, TestCaseSource("IncorrectLoginDataFromFile")]
                        
        public void InvalidLoginTests(LoginData loginData)
        {
            app.Auth.Logout();            
            app.Auth.InvalidLogin(loginData);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

        // GTP2-R-01-22
        [Test]
        public void GoToDashportPageWithoutLoginTest()
        {
            app.Auth.GoToDashportPageWithoutLogin();

            Assert.IsTrue(app.Auth.StayOnLoginPage());
        }

        
    }
}
