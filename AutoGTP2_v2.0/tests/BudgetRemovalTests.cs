﻿using System.Threading;
using NUnit.Framework;


namespace AutoGTP2Tests
{
    [TestFixture]
    public class BudgetRemovalTests : AuthTestBase
    {
        [Test]
        public void BudgetRemovalCancelTest()
        {
            applicationManager.Budgets.CancelRemove();
        }

        [Test]
        public void BudgetRemovalTest()
        {
            applicationManager.Budgets.RemoveBudget();            
        }
        
    }
         
}

