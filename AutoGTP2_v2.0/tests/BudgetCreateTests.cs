using NUnit.Framework;
using System.Collections.Generic;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class BudgetCreateTests : AuthTestBase
    {   
        [Test]
        public void CreateBudgetTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = applicationManager.GetRandomString(5),
                BudgetCost = applicationManager.GetRandomString(10),
                BudgetTotal = "1000"
            };

            List<BudgetData> oldBudgets = applicationManager.Budgets.GetBudgetList();            

            applicationManager.Budgets.CreateBudget(budgetData);

            List<BudgetData> newBudgets = applicationManager.Budgets.GetBudgetList();

            //oldBudgets.Add(budgetData); //добавляет данные в старый список
            if(oldBudgets.Count > 20)
            {
                oldBudgets.RemoveAt(oldBudgets.Count - 2); // удаляем предпоследний элемент из списка, в котором 21 элемент
            }            
            //oldBudgets.Sort(); // сортировка старого списка
            //newBudgets.Sort(); // сортировка нового списка            
            Assert.AreEqual(oldBudgets.Count + 1, newBudgets.Count);
            //Assert.AreEqual(oldBudgets, newBudgets);
        }

    }
}
