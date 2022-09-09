using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;

namespace AutoGTP2Tests
{
    [TestFixture]    
    
    public class BudgetCreateTests : AuthTestBase
    {        
        [Test]
        //[Description("Создание бюджета")]
        

        public void CreateBudgetTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3),
                BudgetTotal = "1000"
            };

            List<BudgetData> oldBudgets = app.Budgets.GetBudgetList();            

            app.Budgets.CreateBudget(budgetData);
            
            List<BudgetData> newBudgets = app.Budgets.GetBudgetList();            

            //добавляет данные в старый список
            oldBudgets.Add(budgetData);
            if (oldBudgets.Count > 20)
            {
                oldBudgets.RemoveAt(oldBudgets.Count - 2); // удаляем предпоследний элемент из списка, в котором 21 элемент
            }            
            oldBudgets.Sort(); // сортировка старого списка
            newBudgets.Sort(); // сортировка нового списка
            Assert.AreEqual(newBudgets, oldBudgets);
        }

    }

    
}
