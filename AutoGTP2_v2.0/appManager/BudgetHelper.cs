using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutoGTP2Tests
{
    public class BudgetHelper : BaseHelper
    {
        public BudgetHelper(ApplicationManager manager) : base(manager)
        {
        }
        //Высокоуровневые методы

        public BudgetHelper NewBudgetModalOpen()
        {
            manager.Navigator.GoToBudgetPage();
            NewBudgetButtonClick();
            return this;
        }       

        public BudgetHelper CreateNewBudget(BudgetData budgetData)
        {
            NewBudgetModalOpen();
            EnterPOnumber(budgetData);
            EnterBudgetCost(budgetData);
            SelectUSDCurrency();
            EnterTotal(budgetData);
            BudgetCreateButtonClick();
            Thread.Sleep(500);
            return this;
        }

        public BudgetHelper FillNewBudgetPOField(BudgetData budgetData)
        {
            NewBudgetModalOpen();
            EnterPOnumber(budgetData);            
            BudgetCreateButtonClick();
            return this;
        }

        public BudgetHelper FillNewBudgetPOFAndCostield(BudgetData budgetData)
        {
            NewBudgetModalOpen();
            EnterPOnumber(budgetData);
            EnterBudgetCost(budgetData);
            BudgetCreateButtonClick();
            return this;
        }

        public BudgetHelper FillNewBudgetPOAndCostFieldAndSelectCurrency(BudgetData budgetData)
        {
            NewBudgetModalOpen();
            EnterPOnumber(budgetData);
            EnterBudgetCost(budgetData);
            SelectUSDCurrency();
            BudgetCreateButtonClick();
            return this;
        }

        public BudgetHelper BudgetRemoval()
        {
            manager.Navigator.GoToBudgetPage();                        
            BudgetBurgerClick();                      
            BudgetDeleteButtonClick();
            BudgetDeleteConfirm();
            return this;
        }

        public BudgetHelper BudgetRemovalCancel()
        {
            manager.Navigator.GoToBudgetPage();                        
            BudgetBurgerClick();            
            BudgetDeleteButtonClick();
            BudgetDeleteDecline();            
            return this;
        }

        public BudgetHelper OpenBudgetWithoutProjects(BudgetData budgetData)
        {            
            FindBudgetWithoutProjectsAndOpenBurger(budgetData);
            OpenButtonInBurgerClick();
            return this;
        }

        public BudgetHelper OpenBudgetWithProjects(BudgetData budgetData)
        {
            FindBudgetWithProjectsAndOpenBurger(budgetData);            
            OpenButtonInBurgerClick();
            ReadonlyQuestionMarkClick();
            return this;
        }

        public BudgetHelper AddThenDeleteTextFromSearchBar()
        {
            manager.Navigator.GoToBudgetPage();
            EnterTextInSearchBar("test");
            DeleteTextButtonInSearchBarClick();
            return this;
        }

        public BudgetHelper EnterExistingBudgetNameAndClickMagnifyingGlass()
        {
            manager.Navigator.GoToBudgetPage();            
            TakeBudgetNameAndEnterItToSearchBar();
            MagnifyingGlassClick();
            return this;
        }

        public BudgetHelper EnterExistingBudgetNameAndPushEnter()
        {
            manager.Navigator.GoToBudgetPage();
            TakeBudgetNameAndEnterItToSearchBar();
            PushEnter();
            return this;
        }

        public BudgetHelper EnterNotExistingBudgetName()
        {
            manager.Navigator.GoToBudgetPage();
            EnterRandomBudgetName();            
            PushEnter();
            return this;
        }                

        public BudgetHelper OpenColumnsList()
        {
            manager.Navigator.GoToBudgetPage();            
            ColumnsTurnOnIfItTurnOff();
            return this;
        }

        public BudgetHelper BudgetColumnsTurnOff(BudgetColumnsData budgetColumnsData)
        {
            manager.Navigator.GoToBudgetPage();            
            ColumnsTurnOnIfItTurnOff();
            ColumnsSwitchOff(budgetColumnsData);
            return this;
        }

        









        // Создаем список бюджетов
        public List<BudgetData> GetBudgetList()
        {            
            List<BudgetData> budgets = new List<BudgetData>();
            manager.Navigator.GoToBudgetPage();
            ICollection<IWebElement> elements = driver.FindElements
                (By.XPath("//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))]"));            
            foreach(var element in elements)
            {                
                for (int i = 0; i < elements.Count; i++)
                {
                    string cost = driver.FindElement(By.XPath(
                        "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][" + (i + 1) + "]" +
                        "//div[contains(text(), 'Cost')]//following-sibling::div")).Text;
                    string po = driver.FindElement(By.XPath(
                        "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][" + (i + 1) + "]" +
                        "//div[contains(text(), 'PO')]//following-sibling::div")).Text;
                    string total = driver.FindElement(By.XPath(
                        "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][" + (i + 1) + "]" +
                        "//div[contains(text(), 'total')]//following-sibling::div")).Text;
                    string remaining = driver.FindElement(By.XPath(
                        "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][" + (i + 1) + "]" +
                        "//div[contains(text(), 'remaining')]//following-sibling::div")).Text;
                    string date = driver.FindElement(By.XPath(
                        "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][" + (i + 1) + "]" +
                        "//div[contains(text(), 'Date')]//following-sibling::div")).Text;

                    budgets.Add(new BudgetData(cost, po)
                    {
                        BudgetTotal = total,
                        BudgetRemaining = remaining,
                        CreationDate = date                       
                    });
                }
                break;
            }
            return new List<BudgetData>(budgets);
        }

        



        // Создаем список колонок бюджетов
        public List<BudgetColumnsData> GetBudgetColumnsList()
        {          
            List<BudgetColumnsData> columns = new List<BudgetColumnsData>();
            manager.Navigator.GoToBudgetPage();
            
            //ICollection<IWebElement> columns = driver.FindElements(By.XPath(
            //    "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][1]//div[@class= 'eQ5lQ_D0FC26twfwcmhy' or @class= 'wF4f8z1gZkBosC4Dy4j7']"));

            if (IsElementPresent(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Cost account/Budget name')]")))
            {
                string name = driver.FindElement(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Cost account/Budget name')]")).Text;
                columns.Add(new BudgetColumnsData()
                {
                    ColumnName = name                    
                });
            }

            if (IsElementPresent(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Amount remaining')]")))
            {
                string remaining = driver.FindElement(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Amount remaining')]")).Text;
                columns.Add(new BudgetColumnsData()
                {
                    ColumnName = remaining
                });
            }

            if (IsElementPresent(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'PO number')]")))
            {
                string po = driver.FindElement(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'PO number')]")).Text;
                columns.Add(new BudgetColumnsData()
                {
                    ColumnName = po
                });
            }

            if (IsElementPresent(By.XPath(
                "//p[@class= 'JS5QDNbVwPTSQkGOFVx8' and contains(text(), 'Projects')]")))
            {
                string projects = driver.FindElement(By.XPath(
                "//p[@class= 'JS5QDNbVwPTSQkGOFVx8' and contains(text(), 'Projects')]")).Text;
                columns.Add(new BudgetColumnsData()
                {
                    ColumnName = projects
                });
            }

            if (IsElementPresent(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Amount total')]")))
            {
                string total = driver.FindElement(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Amount total')]")).Text;
                columns.Add(new BudgetColumnsData()
                {
                    ColumnName = total
                });
            }

            if (IsElementPresent(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Date of creation')]")))
            {
                string date = driver.FindElement(By.XPath(
                "//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Date of creation')]")).Text;
                columns.Add(new BudgetColumnsData()
                {
                    ColumnName = date
                });
            }

            return columns;
        }











































        // Низкоуровневые методы

        public int CheckBoxIsDisabled()
        {
            return driver.FindElements(By.XPath(
                "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB _fGfxt_KTPxUyHmi7HXe']")).Count;
        }

        public BudgetHelper ColumnsSwitchOff(BudgetColumnsData budgetColumnsData)
        {
            if (budgetColumnsData.ColumnName == null) { budgetColumnsData.ColumnName = "  "; }
            if (budgetColumnsData.ColumnRemaining == null) { budgetColumnsData.ColumnRemaining = "  "; }
            if (budgetColumnsData.ColumnPO == null) { budgetColumnsData.ColumnPO = "  "; }
            if (budgetColumnsData.ColumnProjects == null) { budgetColumnsData.ColumnProjects = "  "; }
            if (budgetColumnsData.ColumnTotal == null) { budgetColumnsData.ColumnTotal = "  "; }
            if (budgetColumnsData.ColumnDate == null) { budgetColumnsData.ColumnDate = "  "; }

            ICollection<IWebElement> elementsCount = driver.FindElements(By.XPath(
                    "//div[@id= 'settings-columns']//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and " +
                    "contains(text(), '"+ budgetColumnsData.ColumnName + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnRemaining + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnPO + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnProjects + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnTotal + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnDate + "')]"));
            
            foreach(var element in elementsCount)
            {
                element.Click();
            }
            return this;
        }

        public bool ColumnsListIsOpen()
        {
            return IsElementPresent(By.Id("settings-columns"));
        }

        public bool ColumnsListHaveColumnsName()
        {
            if (IsElementPresent(By.XPath(
                "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'PO')]"))
                && IsElementPresent(By.XPath(
                    "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Budget name')]"))
                && IsElementPresent(By.XPath(
                    "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Amount remaining')]"))
                && IsElementPresent(By.XPath(
                    "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Projects')]"))
                && IsElementPresent(By.XPath(
                    "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Total amount')]"))
                && IsElementPresent(By.XPath(
                    "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Created at')]"))
                ) { return true; }
            return false;
        }

        public bool ColumnsIsTurnOn(int i)
        {
            if (driver.FindElements(By.XPath(
                "//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB']")).Count == i)
            {
                return true;
            }
            return false;
        }

        public BudgetHelper BudgetColumnsButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_COLUMNS_BUTTON")).Click();            
            return this;
        }

        public BudgetHelper ColumnsTurnOnIfItTurnOff()
        {
            if (!IsElementPresent(By.Id("BUDGETS_CREATE_NEW_BUDGET")))
            {
                manager.Navigator.GoToBudgetPage();
            }

            if (!IsElementPresent(By.XPath("settings-columns")))
            {
                BudgetColumnsButtonClick();
            }

            if (ColumnsAreOff())
            {
                ColumnsTurnOn();
            }
            return this;
        }

        public bool ColumnsAreOff()
        {
            return driver.FindElements(By.XPath("//div[@class= 'r6y6jrWnmWzm1eEt9OwN']")).Count >= 1;
        }

        public BudgetHelper ColumnsTurnOn()
        {
            var elements = driver.FindElements(By.XPath("//div[@class= 'r6y6jrWnmWzm1eEt9OwN']"));
            foreach (var element in elements)
            {
                driver.FindElement(By.XPath("//div[@class= 'r6y6jrWnmWzm1eEt9OwN']")).Click();
            }
            return this;
        }

        public BudgetHelper EnterRandomBudgetName()
        {
            string text = manager.TextGenerator(1, 8);
            driver.FindElement(By.Id("BUDGETS_SEARCH_FIELD")).SendKeys(text);
            return this;
        }

        public bool BudgetsNotFound()
        {
            if (IsElementPresent(By.XPath("//div[@class= 'u8jP831aiskq6Oe6mMlo' and contains(., 'No data')]"))) { return true; }
            return false;
        }

        public BudgetHelper PushEnter()
        {
            driver.FindElement(By.Id("BUDGETS_SEARCH_FIELD")).SendKeys(Keys.Enter);
            //WaitUntilFindElement(3, By.XPath("//div[@class= 'u8jP831aiskq6Oe6mMlo' and contains(., 'No data')]"));
            Thread.Sleep(200);
            return this;
        }

        public BudgetHelper TakeBudgetNameAndEnterItToSearchBar()
        {
            string bname = driver.FindElement(By.XPath("//div[@class= 'kyuJpfa35LDUXSJH2FJS']")).Text;
            driver.FindElement(By.Id("BUDGETS_SEARCH_FIELD")).SendKeys(bname);
            return this;
        }

        public BudgetHelper MagnifyingGlassClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('BUDGETS_SEARCH_FIELD_BUTTON').click()");
            return this;
        }


        public bool SearchingIsCorrect()
        {
            bool result = false;
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class= 'kyuJpfa35LDUXSJH2FJS']"));
            foreach (var element in elements)
            {
                string bnameInSearchBar = driver.FindElement(By.Id("BUDGETS_SEARCH_FIELD")).GetAttribute("value");
                for (int i = 0; i < elements.Count; i++)
                {
                    string bnameInBudget = driver.FindElement(By.XPath(
                        "//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))][" + (i + 1) + "]//div[contains(text(), 'Cost')]//following-sibling::div//div")).Text;
                    if (bnameInBudget.Contains(bnameInSearchBar)) { return result = true; }
                }
            }
            return result;
        }
        public BudgetHelper DeleteTextButtonInSearchBarClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByClassName('search-delete')[0].click()");
            return this;
        }

        public BudgetHelper EnterTextInSearchBar(string text)
        {
            driver.FindElement(By.Id("BUDGETS_SEARCH_FIELD")).SendKeys(text);
            return this;
        }

        public bool BudgetSearchFieldIsEmpty()
        {
            string text = driver.FindElement(By.Id("BUDGETS_SEARCH_FIELD")).GetAttribute("value");
            if (text.Contains("")) { return true; }
            return false;
        }

        public BudgetHelper ReadonlyQuestionMarkClick()
        {
            driver.FindElement(By.XPath("//div[@class= 'newBudget-modal-read']//span")).Click();
            Thread.Sleep(200);
            return this;
        }

        public bool QuestionMarkPopupIsPresentAndHaveCorrectText()
        {
            string text = driver.FindElement(By.XPath("//p[@class= 'tooltip-content']")).Text;
            if (text.Contains("This budget has already been used in projects.")) { return true; }
            return false;
        }

        public BudgetHelper FindBudgetWithProjectsAndOpenBurger(BudgetData budgetData)
        {
            manager.Navigator.GoToBudgetPage();
            Thread.Sleep(200);
            if (driver.FindElements(By.XPath("//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and not(contains(., 'None'))]//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]")).Count == 0)
            {
                CreateNewBudget(budgetData);
                manager.Navigator.GoToBudgetPage();
                driver.FindElement(By.XPath("//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and not(contains(., 'None'))]//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and not(contains(., 'None'))]//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]")).Click();
            }

            return this;
        }

        public BudgetHelper OpenButtonInBurgerClick()
        {
            driver.FindElement(By.XPath("//div[@class= 'hamburger-open-content']")).Click();
            Thread.Sleep(200);
            return this;
        }

        public BudgetHelper FindBudgetWithoutProjectsAndOpenBurger(BudgetData budgetData)
        {
            manager.Navigator.GoToBudgetPage();
            if (driver.FindElements(By.XPath(
                "//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and contains(., 'None')]" +
                "//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]")).Count == 0)
            {
                CreateNewBudget(budgetData);
                manager.Navigator.GoToBudgetPage();
                driver.FindElement(By.XPath(
                "//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and contains(., 'None')]" +
                "//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]")).Click();
            }
            else
            {
                driver.FindElement(By.XPath(
                "//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and contains(., 'None')]" +
                "//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]")).Click();
            }

            return this;
        }

        public bool BudgetUpdateButtonIsPresent()
        {
            return IsElementPresent(By.Id("BUDGET_EDIT_UPDATE"));
        }

        public bool NewBudgetModalIsOpen()
        {
            return IsElementPresent(By.XPath("//div[@class= 'newBudget-modal']"));
        }
        public bool CreateBudgetButtonIsEnabled()
        {
            return driver.FindElement(By.Id("NEW_BUDGET_CREATE")).Enabled;
        }

        public bool BudgetTooltipIsPresent()
        {
            return IsElementPresent(By.XPath("//p[@class = 'i9matKNoUHudiZkMT8BL']"));
        }

        public bool POTooltipContainCorrectText()
        {
            string text = driver.FindElement(By.XPath("//p[@class = 'i9matKNoUHudiZkMT8BL']")).Text;
            return text.Contains("Budget with such po number is already exists.");
        }

        public bool CostTooltipContainCorrectText()
        {
            string text = driver.FindElement(By.XPath("//p[@class = 'i9matKNoUHudiZkMT8BL']")).Text;
            return text.Contains("Such budget already defined for the client.");
        }

        public BudgetHelper BudgetCreateButtonClick()
        {
            driver.FindElement(By.Id("NEW_BUDGET_CREATE")).Click();
            return this;
        }

        public BudgetHelper EnterTotal(BudgetData budgetData)
        {
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_TOTAL")).SendKeys(budgetData.BudgetTotal);
            return this;
        }

        public BudgetHelper SelectUSDCurrency()
        {
            var currencyField = By.XPath("//input[@name = 'NEW_BUDGET_CURRENCY']");
            if (IsElementPresent(currencyField))
            {
                driver.FindElement(By.XPath(
                "//input[@class= 'react-dropdown-select-input css-o79eln-InputComponent e11wid6y0']")).Click();
                driver.FindElement(By.XPath("//p[@title='USD']")).Click();
            }
            return this;
        }
        public BudgetHelper EnterBudgetCost(BudgetData budgetData)
        {
            driver.FindElement(By.Id("NEW_BUDGET_COST")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_COST")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_COST")).SendKeys(budgetData.BudgetCost);
            return this;
        }
        public BudgetHelper EnterPOnumber(BudgetData budgetData)
        {
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Click();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).Clear();
            driver.FindElement(By.Id("NEW_BUDGET_PO")).SendKeys(budgetData.BudgetPO);
            return this;
        }

        public BudgetHelper NewBudgetButtonClick()
        {
            driver.FindElement(By.Id("BUDGETS_CREATE_NEW_BUDGET")).Click();
            return this;
        }
        public BudgetHelper BudgetBurgerClick()
        {
            driver.FindElement(By.CssSelector("#BUDGETS_BURGER_0 > svg > path")).Click();
            return this;
        }
        public BudgetHelper BudgetDeleteButtonClick()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE")).Click();
            return this;
        }
        public BudgetHelper BudgetDeleteConfirm()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE_DELETE")).Click();
            return this;
        }
        public BudgetHelper BudgetDeleteDecline()
        {
            driver.FindElement(By.Id("BUDGETS_0_BURGER_MENU_DELETE_DECLINE")).Click();
            return this;
        }

        // ищем неактивную кнопку Delete при удалении бюджета
        public bool BudgetDeleteButtonIsDisabled()
        {
            manager.Navigator.GoToBudgetPage();
            WaitUntilFindElement(10, By.CssSelector("#BUDGETS_BURGER_0 > svg > path"));
            BudgetBurgerClick();
            if (driver.FindElements(By.XPath("//p[@class = 'delete-project-btn disabled']")).Count == 1)
            {
                return true;
            }
            return false;
        }

    }
}
