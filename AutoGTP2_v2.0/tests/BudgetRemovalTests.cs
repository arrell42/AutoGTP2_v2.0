using NUnit.Framework;
using OpenQA.Selenium;

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
                    BudgetTotal = "1000"
                };
                applicationManager.Budgets.CreateBudget(budget);
                applicationManager.Budgets.WaitUntilFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
                applicationManager.Budgets.BudgetBurgerClick();                
            }
            
            applicationManager.Budgets.BudgetRemovalCancel();            
        }

        [Test]
        public void BudgetRemovalTest()
        { 
            if (applicationManager.Budgets.BudgetDeleteButtonIsDisabled())
            {
                BudgetData budget = new BudgetData("", "")
            {
                BudgetTotal = "1000"
            };  
                applicationManager.Budgets.CreateBudget(budget);
                applicationManager.Budgets.WaitUntilFindElement(5, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
                applicationManager.Budgets.BudgetBurgerClick();                
            }

            applicationManager.Budgets.BudgetRemoval();
        }
        
    }
         
}

