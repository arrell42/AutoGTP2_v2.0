using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class BudgetRemovalTests : AuthTestBase
    {
        [Test]
        public void BudgetRemovalCancelTest()
        {
            applicationManager.Budgets.CancelRemoveBudget();
        }

        [Test]
        public void BudgetRemovalTest(BudgetData budget)
        {
            applicationManager.Budgets.RemoveBudget(budget);           
        }
        
    }
         
}

