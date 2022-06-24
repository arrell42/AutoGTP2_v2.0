using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class CreateBudgetTests : AuthTestBase
    {   
        [Test]
        public void AddBudgetTest()
        {  
            BudgetData budget = new BudgetData()
            {                
                BudgetTotal = "1000"
            };
            applicationManager.Budgets.CreateBudget(budget);
        }
    }
}
