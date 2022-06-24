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
            CreateButtonClick();
            Thread.Sleep(500);
            return this;
        }

        public BudgetHelper RemoveBudget()
        {
            manager.Navigator.GoToBudgetPage();
            WaitUntiFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));            
            BudgetBurgerClick();
            BudgetDeleteButtonClick();
            BudgetDeleteConfirm();
            return this;
        }

        public BudgetHelper CancelRemoveBudget()
        {
            manager.Navigator.GoToBudgetPage();
            WaitUntiFindElement(10, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));            
            BudgetBurgerClick();
            BudgetDeleteButtonClick();
            BudgetDeleteDecline();            
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


    }
}
