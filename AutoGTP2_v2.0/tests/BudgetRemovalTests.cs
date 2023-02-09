using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutoGTP2Tests
{
    [TestFixture]    
    public class BudgetRemovalTests : AuthTestBase
    {
        [Test]
        [Category("Budgets")]

        public void BudgetRemovalCancelTest()
        {
            BudgetData budget = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3),
                BudgetTotal = "1000"
            };            

            List<BudgetData> oldBudgets = app.Budgets.GetBudgetList();

            app.Budgets.BudgetRemovalCancel(budget);

            List<BudgetData> newBudgets = app.Budgets.GetBudgetList();

            Assert.AreEqual(oldBudgets.Count, newBudgets.Count);
            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(newBudgets, oldBudgets);
        }

        [Test]
        [Category("Budgets")]
        public void BudgetRemovalTest()
        {
            BudgetData budget = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3),
                BudgetTotal = "1000"
            };
            
            List<BudgetData> oldBudgets = app.Budgets.GetBudgetList();

            app.Budgets.BudgetRemoval(budget);

            List<BudgetData> newBudgets = app.Budgets.GetBudgetList();

            oldBudgets.RemoveAt(0); // удаляем первый в старом списке
            if (newBudgets.Count == 20)
            {                
                newBudgets.RemoveAt(19); // удаляем последний в новом списке
            }            

            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(oldBudgets, newBudgets);
        }
        
    }
         
}

