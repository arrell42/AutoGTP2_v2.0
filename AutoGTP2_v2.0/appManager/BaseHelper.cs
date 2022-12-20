using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            driver = manager.Driver;
        }

        // чтение текста из файла
        public static string InternalReadAllText(string path, Encoding encoding)
        {            
            string result;
            using (StreamReader streamReader = new StreamReader(path, encoding))
            {
                result = streamReader.ReadToEnd();
            }            
            return result;
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

        // ожидание появления элемента по локатору
        public void WaitUntilFindElement(int time, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(driver => driver.FindElement(locator));
        }        

        // ожидание пока элемент пропадет со страницы
        public void WaitUntilElementIsHide(int time, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        // имитация клика мышкой
        public void MouseClickImitation(By by)
        {
            IWebElement clickable = driver.FindElement(by);
            new Actions(driver).Click(clickable).Perform();            
        }

        // имитация клик и задержка на элементе
        public void MouseClickAndHoldImitation(By by)
        {
            IWebElement clickable = driver.FindElement(by);
            new Actions(driver).ClickAndHold(clickable).Perform();
        }

        /*
        // имитация клика мышкой - второй вариант
        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
            RightUp = 0x0010, Absolute = 0x8000
        };

        public void MouseClickImitation()
        {
            // использование - клик правой примерно в центре экрана
            //(подробнее о координатах, передаваемых в mouse_event см. в MSDN): 
            const int x = 0;
            const int y = 32000;

            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, x, y, 0, UIntPtr.Zero);
        }
        */

        // Поиск определенного языка по indexValue в рамках сервиса
        /*
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

    }
}
