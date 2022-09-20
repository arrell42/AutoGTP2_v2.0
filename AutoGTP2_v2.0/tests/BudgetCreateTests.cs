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

            app.Budgets.CreateNewBudget(budgetData);
            
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

        // GTP2-R-06-02
        [Test]
        public void NewBudgetModalOpenTest()
        {
            app.Budgets.NewBudgetModalOpen();

            Assert.IsTrue(app.Budgets.NewBudgetModalIsOpen());
            Assert.IsFalse(app.Budgets.CreateBudgetButtonIsEnabled());
        }

        // GTP2-R-06-03
        [Test]
        public void FillNewBudgetPOFieldTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5)
            };

            app.Budgets.FillNewBudgetPOField(budgetData);

            Assert.IsTrue(app.Budgets.NewBudgetModalIsOpen());
            Assert.IsFalse(app.Budgets.CreateBudgetButtonIsEnabled());
        }

        // GTP2-R-06-04
        [Test]
        public void FillNewBudgetPOAndCostFieldTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3)
            };

            app.Budgets.FillNewBudgetPOFAndCostield(budgetData);

            Assert.IsTrue(app.Budgets.NewBudgetModalIsOpen());
            Assert.IsFalse(app.Budgets.CreateBudgetButtonIsEnabled());
        }

        // GTP2-R-06-05
        [Test]
        public void FillNewBudgetPOAndCostFieldAndSelectCurrencyTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3)
            };

            app.Budgets.FillNewBudgetPOAndCostFieldAndSelectCurrency(budgetData);

            Assert.IsTrue(app.Budgets.NewBudgetModalIsOpen());
            Assert.IsFalse(app.Budgets.CreateBudgetButtonIsEnabled());
        }

        // GTP2-R-06-09
        [Test]
        public void OpenBudgetWithoutProjectsTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3),
                BudgetTotal = "1000"
            };

            app.Budgets.OpenBudgetWithoutProjects(budgetData);

            Assert.IsTrue(app.Budgets.NewBudgetModalIsOpen());
            Assert.IsTrue(app.Budgets.BudgetUpdateButtonIsPresent());
        }

        // GTP2-R-06-10
        [Test]
        public void OpenBudgetWithProjectsTest()
        {
            BudgetData budgetData = new BudgetData("", "")
            {
                BudgetPO = app.TextGenerator(1, 5),
                BudgetCost = app.TextGenerator(1, 3),
                BudgetTotal = "1000"
            };

            app.Budgets.OpenBudgetWithProjects(budgetData);

            Assert.IsTrue(app.Budgets.NewBudgetModalIsOpen());
            Assert.IsFalse(app.Budgets.BudgetUpdateButtonIsPresent());
            Assert.IsTrue(app.Budgets.QuestionMarkPopupIsPresentAndHaveCorrectText());
        }
    }
}
