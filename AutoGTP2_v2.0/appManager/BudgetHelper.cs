using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;


namespace AutoGTP2Tests
{
    public class BudgetHelper : HelperBase
    {
        public BudgetHelper(ApplicationManager manager) : base(manager)
        {
        }
        //Высокоуровневые методы
        public BudgetHelper CreateBudget(BudgetData budget)
        {
            manager.Navigator.GoToBudgetPage();
            NewBudgetButtonClick();
            EnterPOnumber();
            EnterBudgetName();
            SelectUSDCurrency();
            EnterTotal(budget);
            BudgetCreateButtonClick();
            Thread.Sleep(500);
            return this;
        }

        public BudgetHelper BudgetRemoval()
        {
            manager.Navigator.GoToBudgetPage();                        
            BudgetBurgerClick();                      
            BudgetDeleteButtonClick();
            BudgetDeleteConfirm();
            return this;
        }

        public BudgetHelper BudgetRemovalCancel()
        {
            manager.Navigator.GoToBudgetPage();                        
            BudgetBurgerClick();            
            BudgetDeleteButtonClick();
            BudgetDeleteDecline();            
            return this;
        }




        // Низкоуровневые методы

        // Создаем список бюджетов
        public List<BudgetData> GetBudgetList()
        {
            List<BudgetData> budgets = new List<BudgetData>();

            manager.Navigator.GoToBudgetPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class = 'oTwbbIIc9i_OOdONf0OL']"));
            foreach(IWebElement element in elements)
            {                
                budgets.Add(new BudgetData(element.Text, element.Text));
            }

            return budgets;
        }

        public BudgetHelper BudgetCreateButtonClick()
        {
            driver.FindElement(By.Id("NEW_BUDGET_CREATE")).Click();
            return this;
        }

        public BudgetHelper EnterTotal(BudgetData budget)
        {
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).SendKeys(budget.BudgetTotal);
            return this;
        }

        public BudgetHelper SelectUSDCurrency()
        {
            driver.FindElement(By.XPath("//div[@class='react-dropdown-select undefined css-12zlm52-ReactDropdownSelect e1gzf2xs0']/div")).Click();
            driver.FindElement(By.XPath("//p[@title='USD']")).Click();
            return this;
        }

        public BudgetHelper EnterBudgetName()
        {
            driver.FindElement(By.Id("NEW_BUDGET_COST")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_COST")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_COST")).SendKeys(GetRandomString(5));
            return this;
        }

        public BudgetHelper EnterPOnumber()
        {
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).SendKeys(GetRandomString(5));
            return this;
        }

        public BudgetHelper NewBudgetButtonClick()
        {
            driver.FindElement(By.Id("BUDGETS_CREATE_NEW_BUDGET")).Click();
            return this;
        }                
        
        public BudgetHelper BudgetBurgerClick()
        {
            driver.FindElement(By.CssSelector("#BUDGETS_BURGER_0 > svg > path")).Click();
            return this;
        }

        public BudgetHelper BudgetDeleteButtonClick()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE")).Click();
            return this;
        }

        public BudgetHelper BudgetDeleteConfirm()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE_DELETE")).Click();
            return this;
        }
        public BudgetHelper BudgetDeleteDecline()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE_DECLINE")).Click();
            return this;
        }

        // ищем неактивную кнопку Delete при удалении бюджета
        public bool BudgetDeleteButtonIsDisabled()
        {
            manager.Navigator.GoToBudgetPage();
            WaitUntilFindElement(10, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
            BudgetBurgerClick();
            if (driver.FindElements(By.XPath("//p[@class = 'delete-project-btn disabled']")).Count == 1)
            {
                return true;
            }
            return false;            
        }
        


    }
}
