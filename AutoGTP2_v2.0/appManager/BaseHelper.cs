using System;
using System.IO;
using System.Linq;
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

        // Генератор члучайного числа от 1 до 5
        public static readonly Random random = new Random();
        public int AddRandomNumberFrom1To5()
        {
            return random.Next(1, 6);  // Random.Next будет включать нижний предел, но исключать верхний, так что 26 не включается
        }


        // Генератор рандомных слов        
        public static Random rnd = new Random();
        public string TextGenerator(int wrd, int let)
        {
            string result = "";
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 1; i <= wrd; i++)
            {
                string word = "";
                for (int j = 0; j < let; j++)
                {
                    int letter_num = rnd.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }
                result = result + " " + word;
            }
            return result.Trim();
        }

        // генерация набора случайных символов
        public string GetRandomString(int length)
        {
            var r = new Random();
            return new string(Enumerable.Range(0, length).Select(n => (Char)(r.Next(32, 127))).ToArray());
        }

        public void CloseBrowserTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
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
