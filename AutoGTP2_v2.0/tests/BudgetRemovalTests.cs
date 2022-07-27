using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class BudgetRemovalTests : AuthTestBase
    {
        [Test]
        public void BudgetRemovalCancelTest()
        {
            if (app.Budgets.BudgetDeleteButtonIsDisabled())
            {
                BudgetData budget = new BudgetData("", "")
                {
                    BudgetPO = app.TextGenerator(1, 5),
                    BudgetCost = app.TextGenerator(1, 3),
                    BudgetTotal = "1000"
                };
                app.Budgets.CreateBudget(budget);
                app.Budgets.WaitUntilFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
                app.Budgets.BudgetBurgerClick();                
            }

            List<BudgetData> oldBudgets = app.Budgets.GetBudgetList();

            app.Budgets.BudgetRemovalCancel();

            List<BudgetData> newBudgets = app.Budgets.GetBudgetList();

            Assert.AreEqual(oldBudgets.Count, newBudgets.Count);
            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(newBudgets, oldBudgets);
        }

        [Test]
        public void BudgetRemovalTest()
        { 
            if (app.Budgets.BudgetDeleteButtonIsDisabled())
            {
                BudgetData budget = new BudgetData("", "")
                {
                    BudgetPO = app.TextGenerator(1, 5),
                    BudgetCost = app.TextGenerator(1, 3),
                    BudgetTotal = "1000"
                };  
                app.Budgets.CreateBudget(budget);
                app.Budgets.WaitUntilFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
                app.Budgets.BudgetBurgerClick();                
            }

            List<BudgetData> oldBudgets = app.Budgets.GetBudgetList();

            app.Budgets.BudgetRemoval();

            List<BudgetData> newBudgets = app.Budgets.GetBudgetList();
            Assert.AreEqual(oldBudgets.Count - 1, newBudgets.Count);

            oldBudgets.RemoveAt(0);
            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(newBudgets, oldBudgets);
        }
        
    }
         
}

