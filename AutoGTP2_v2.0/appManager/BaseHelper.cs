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

        // проверка на скачанный файл
        public bool CheckFileDownloaded(ServiceData filename)
        {
            bool exist = false;
            string Path = Environment.GetEnvironmentVariable(@"C:") + @"\Users\d_inozemtsev\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename.FileName))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p); //удаление файла после проверки
                    break;
                }
            }
            return exist;
        }

        // ожидание появления элемента по локатору
        public void WaitUntilFindElement(int time, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(driver => driver.FindElement(locator));
        }

        // ожидание всех элементов по локатору (с помощью index можно выбрать количество элементов)
        public void WaitUntilFindElements(int time, By locator, int index)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(driver => driver.FindElements(locator).Count == index);
        }

        // ожидание пока элемент пропадет со страницы
        public void WaitUntilElementIsHide(int time, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        // имитация клика мышкой
        public void MouseClickImitation()
        {
            IWebElement clickable = driver.FindElement(By.XPath("//p[@class = 'RjSxBXvO6oCmh2PBtYg9']"));
            new Actions(driver).Click(clickable).Perform();
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
