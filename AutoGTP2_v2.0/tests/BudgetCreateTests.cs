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
            BudgetData budget = new BudgetData("", "")
            {
                BudgetTotal = "1000"
            };

            List<BudgetData> oldBudgets = applicationManager.Budgets.GetBudgetList();

            applicationManager.Budgets.CreateBudget(budget);

            List<BudgetData> newBudgets = applicationManager.Budgets.GetBudgetList();
            Assert.AreEqual(oldBudgets.Count + 1, newBudgets.Count);
        }
    }
}
