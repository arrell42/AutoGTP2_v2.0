using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class BudgetRemovalTests : AuthTestBase
    {
        [Test]
        public void BudgetRemovalCancelTest()
        {
            BudgetData budget = new BudgetData()
            {
                BudgetTotal = "1000"
            };
            applicationManager.Budgets.CancelRemoveBudget(budget);
        }

        [Test]
        public void BudgetRemovalTest()
        {
            BudgetData budget = new BudgetData()
            {
                BudgetTotal = "1000"
            };
            applicationManager.Budgets.RemoveBudget(budget);           
        }
        
    }
         
}

