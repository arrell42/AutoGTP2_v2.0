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

        // GTP2-R-06-14
        [Test]
        public void DeleteTextFromSearchBarTest()
        {            
            app.Budgets.AddThenDeleteTextFromSearchBar();

            Assert.IsTrue(app.Budgets.BudgetSearchFieldIsEmpty());            
        }

        // GTP2-R-06-15
        [Test]
        public void SearchExistingBudgetWithMagnifyingGlassClickTest()
        {            
            app.Budgets.EnterExistingBudgetNameAndClickMagnifyingGlass();

            Assert.IsTrue(app.Budgets.SearchingIsCorrect());
        }

        // GTP2-R-06-16
        [Test]
        public void SearchExistingBudgetWithEnterTest()
        {
            app.Budgets.EnterExistingBudgetNameAndPushEnter();

            Assert.IsTrue(app.Budgets.SearchingIsCorrect());
        }

        // GTP2-R-06-17
        [Test]
        public void SearchNotExistingBudgetTest()
        {
            app.Budgets.EnterNotExistingBudgetName();

            Assert.IsTrue(app.Budgets.BudgetsNotFound());
        }

        // GTP2-R-06-18
        [Test]
        public void BudgetColumnsButtonTest()
        {
            app.Budgets.OpenColumnsList();

            Assert.IsTrue(app.Budgets.ColumnsListIsOpen());
            Assert.IsTrue(app.Budgets.ColumnsListHaveColumnsName());
            Assert.IsTrue(app.Budgets.ColumnsIsTurnOn(6));            
        }

        // GTP2-R-06-19
        //[Test]
        public void BudgetColumnsTurnOffTest()
        {
            BudgetColumnsData budgetColumnsData = new BudgetColumnsData()
            {                
                ColumnRemaining = "Amount remaining",
                ColumnPO = "PO number"                
            };
            
            List<BudgetColumnsData> oldColumns = app.Budgets.GetBudgetColumnsList();            

            app.Budgets.BudgetColumnsTurnOff(budgetColumnsData);

            List<BudgetColumnsData> newColumns = app.Budgets.GetBudgetColumnsList();

            oldColumns.Remove(budgetColumnsData);

            Assert.AreEqual(oldColumns, newColumns);            
        }

        // GTP2-R-06-20
        [Test]
        public void TurnOffAllBudgetColumnsTest()
        {
            BudgetColumnsData budgetColumnsData = new BudgetColumnsData()
            {
                ColumnName = "Budget name",
                ColumnRemaining = "Amount remaining",
                ColumnPO = "PO number",
                ColumnProjects = "Projects",
                ColumnTotal = "Total amount"
            }; 

            app.Budgets.BudgetColumnsTurnOff(budgetColumnsData);

            Assert.AreEqual(app.Budgets.CheckBoxIsDisabled(), 1);
        }
    }
}
