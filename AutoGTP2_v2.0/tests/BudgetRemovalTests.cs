﻿using NUnit.Framework;
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
            if (applicationManager.Budgets.BudgetDeleteButtonIsDisabled())
            {
                BudgetData budget = new BudgetData("", "")
                {
                    BudgetPO = applicationManager.TextGenerator(1, 5),
                    BudgetCost = applicationManager.TextGenerator(1, 3),
                    BudgetTotal = "1000"
                };
                applicationManager.Budgets.CreateBudget(budget);
                applicationManager.Budgets.WaitUntilFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
                applicationManager.Budgets.BudgetBurgerClick();                
            }

            List<BudgetData> oldBudgets = applicationManager.Budgets.GetBudgetList();

            applicationManager.Budgets.BudgetRemovalCancel();

            List<BudgetData> newBudgets = applicationManager.Budgets.GetBudgetList();

            Assert.AreEqual(oldBudgets.Count, newBudgets.Count);
            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(newBudgets, oldBudgets);
        }

        [Test]
        public void BudgetRemovalTest()
        { 
            if (applicationManager.Budgets.BudgetDeleteButtonIsDisabled())
            {
                BudgetData budget = new BudgetData("", "")
                {
                    BudgetPO = applicationManager.TextGenerator(1, 5),
                    BudgetCost = applicationManager.TextGenerator(1, 3),
                    BudgetTotal = "1000"
                };  
                applicationManager.Budgets.CreateBudget(budget);
                applicationManager.Budgets.WaitUntilFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
                applicationManager.Budgets.BudgetBurgerClick();                
            }

            List<BudgetData> oldBudgets = applicationManager.Budgets.GetBudgetList();

            applicationManager.Budgets.BudgetRemoval();

            List<BudgetData> newBudgets = applicationManager.Budgets.GetBudgetList();
            Assert.AreEqual(oldBudgets.Count - 1, newBudgets.Count);

            oldBudgets.RemoveAt(0);
            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(newBudgets, oldBudgets);
        }
        
    }
         
}

