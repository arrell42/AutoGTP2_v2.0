using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoGTP2Tests
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;
        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        
        // Проверка присутствия элемента
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /*
        // Поиск определенного языка по indexValue в рамках сервиса
        public void LanguageFindByValue(string indexValue)
        {
            string index = indexValue;
            var langs = driver.FindElements(By.ClassName("YxhDSz1flbKA8yowp3RE  "));
            for (int i = 0; i < langs.Count; i++)
            {
                if (langs[i].Text == index && langs[i].Displayed)
                {
                    langs[i].Click();
                    break;
                }
            }
        }
        */

        // ожидание появления элемента по локатору
        public void WaitUntilFindElement(int time, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(driver => driver.FindElement(locator));
        }

        // ожидание всех элементов по локатору (с помощью index можно выбрать количество элементов)
        public void WaitUntiFindElements(int time, By locator, int index)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(driver => driver.FindElements(locator).Count == index);
        }

    }

    
}
