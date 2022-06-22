using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoGTP2Tests
{
    public class BudgetHelper : HelperBase
    {
        //Высокоуровневые методы
        public BudgetHelper CreateBudget(BudgetData budget)
        {
            manager.Navigator.GoToBudgetPage();
            NewBudgetButtonClick();
            EnterPOnumber();
            EnterBudgetName();
            SelectUSDCurrency();
            EnterTotal(budget);
            CreateButtonClick();
            Thread.Sleep(500);
            return this;
        }

        public BudgetHelper RemoveBudget()
        {
            manager.Navigator.GoToBudgetPage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => driver.FindElement(By.CssSelector("#BUDGETS_BURGER_0 > svg > path")));
            BudgetBurgerClick();
            BudgetDeleteButtonClick();
            BudgetDeleteConfirm();
            return this;
        }

        public BudgetHelper CancelRemove()
        {
            manager.Navigator.GoToBudgetPage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("#BUDGETS_BURGER_0 > svg > path")));
            BudgetBurgerClick();
            BudgetDeleteButtonClick();
            BudgetDeleteCancel();            
            return this;
        }




        // Низкоуровневые методы
        public BudgetHelper CreateButtonClick()
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
            driver.FindElement(By.Id("NEW_BUDGET_COST")).SendKeys(manager.GetRandomString(5));
            return this;
        }

        public BudgetHelper EnterPOnumber()
        {
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).SendKeys(manager.GetRandomString(5));
            return this;
        }

        public BudgetHelper NewBudgetButtonClick()
        {
            driver.FindElement(By.Id("BUDGETS_CREATE_NEW_BUDGET")).Click();
            return this;
        }

        
        public BudgetHelper(ApplicationManager manager) : base(manager)
        {                        
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
        public BudgetHelper BudgetDeleteCancel()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE_DECLINE")).Click();
            return this;
        }


    }
}
