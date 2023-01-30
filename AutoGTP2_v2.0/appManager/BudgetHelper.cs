using System;
using System.Collections.Generic;
using System.Linq;
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

        //LOCATORS
        public readonly By firstBudgetRemainingColumnTitle = By.XPath("//div[@id= 'BUDGETS_0']//div[contains(text(), 'Amount remaining')]");
        public readonly By firstBudgetPOTitle = By.XPath("//div[@id= 'BUDGETS_0']//div[contains(text(), 'PO number')]");
        public readonly By firstBudgetNameTitle = By.XPath("//div[@id= 'BUDGETS_0']//div[contains(text(), 'Cost account/Budget name')]");
        public readonly By allBudgetColumnsTitles = By.XPath("//div[@id='BUDGETS_0']//div[@class='HmZHR9aWxu9QsxsKBvP_' or p[contains(text(), 'Projects') ]]");
        public readonly By budgetList = By.XPath("//div[@class= 'vKOuKRPiTZr_i_RoPDcw']");
        public readonly By budgetCard = By.XPath("//div[contains(@id, 'BUDGETS') and not(contains(@id, 'BURGER'))]");
        public readonly By columnsSettingsPopup = By.Id("settings-columns");
        public readonly By disabledCheckboxInColumsSettingsPopup = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB _fGfxt_KTPxUyHmi7HXe']");
        public readonly By columnsPopupNameTitle = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Budget name')]");
        public readonly By columnsPopupRemainingTitle = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Amount remaining')]");
        public readonly By columnsPopupPOTitle = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'PO')]");
        public readonly By columnsPopupProjectsTitle = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Projects')]");
        public readonly By columnsPopupTotalTitle = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Total amount')]");
        public readonly By columnsPopupCreatedTitle = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and contains(., 'Created at')]");
        public readonly By enabledColumnInColumnsPopup = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB']");
        public readonly By columnsButton = By.Id("PROJECTS_COLUMNS_BUTTON");
        public readonly By newBudgetButton = By.Id("BUDGETS_CREATE_NEW_BUDGET");
        public readonly By disabledColumnInColumnsPopup = By.XPath("//div[@class= 'r6y6jrWnmWzm1eEt9OwN']");
        public readonly By searchField = By.Id("BUDGETS_SEARCH_FIELD");
        public readonly By noBudgetsToDisplayText = By.XPath("//div[@class= 'u8jP831aiskq6Oe6mMlo' and contains(., 'No data')]");
        public readonly By budgetNameColumnValue = By.XPath("//div[@class= 'kyuJpfa35LDUXSJH2FJS']");
        public readonly By budgetModalReadOnlyIcon = By.XPath("//div[@class= 'newBudget-modal-read']//span");
        public readonly By budgetModalReadOnlyIconPopup = By.XPath("//p[@class= 'tooltip-content']");
        public readonly By budgetBurgerWithProjects = By.XPath("//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and not(contains(., 'None'))]//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]");
        public readonly By openButtonInBurger = By.XPath("//div[@class= 'hamburger-open-content']");
        public readonly By budgetBurgerWithOutProjects = By.XPath("//div[@class= 'wF4f8z1gZkBosC4Dy4j7' and contains(., 'None')]//following-sibling::div[contains(@id, 'BUDGETS_BURGER')]");
        public readonly By budgetModalEditButton = By.Id("BUDGET_EDIT_UPDATE");
        public readonly By budgetModal = By.XPath("//div[@class= 'newBudget-modal']");
        public readonly By budgetModalCreateButton = By.Id("NEW_BUDGET_CREATE");
        public readonly By budgetModalPOPopup = By.XPath("//p[@class = 'i9matKNoUHudiZkMT8BL']");
        public readonly By budgetModalCurrencyField = By.XPath("//input[@name = 'NEW_BUDGET_CURRENCY']");
        public readonly By budgetModalCurrencyUSD = By.XPath("//p[@title='USD']");
        public readonly By budgetModalCostField = By.Id("NEW_BUDGET_COST");
        public readonly By budgetModalPOField = By.Id("NEW_BUDGET_PO");
        public readonly By budgetBurgerDeleteButton = By.XPath("//p[@class = 'delete-project-btn ']");
        public readonly By budgetDeleteConfirmButton = By.XPath("//button[@class = 'btn bordered-btn']");
        public readonly By budgetDeleteDeclineButton = By.XPath("//button[@class = 'btn primary-btn']");
        public readonly By budgetModalTotalField = By.Id("NEW_BUDGET_TOTAL");
        public readonly By searchingFieldHint = By.XPath("//p[@class= 'search-text']");
        public readonly By searchingFieldCross = By.XPath("//p[@class= 'search-delete']");


        




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
            Thread.Sleep(1000);
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

        public BudgetHelper BudgetRemoval(BudgetData budget)
        {
            manager.Navigator.GoToBudgetPage();
            FindBudgetWithoutProjectsAndOpenBurger(budget);
            BudgetDeleteButtonClick();
            BudgetDeleteConfirm();
            return this;
        }

        public BudgetHelper BudgetRemovalCancel(BudgetData budget)
        {
            manager.Navigator.GoToBudgetPage();
            FindBudgetWithoutProjectsAndOpenBurger(budget);
            BudgetDeleteButtonClick();
            BudgetDeleteDecline();            
            return this;
        }

        public BudgetHelper OpenBudgetWithoutProjects(BudgetData budgetData)
        {
            manager.Navigator.GoToBudgetPage();
            FindBudgetWithoutProjectsAndOpenBurger(budgetData);
            OpenButtonInBurgerClick();
            return this;
        }

        public BudgetHelper OpenBudgetWithProjects()
        {
            manager.Navigator.GoToBudgetPage();
            FindBudgetWithProjectsAndOpenBurger();            
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
            Thread.Sleep(1000);
            return this;
        }

        public BudgetHelper EnterExistingBudgetNameAndPushEnter()
        {
            manager.Navigator.GoToBudgetPage();            
            TakeBudgetNameAndEnterItToSearchBar();
            PushEnter();
            Thread.Sleep(1000);
            return this;
        }

        public BudgetHelper EnterNotExistingBudgetName()
        {
            manager.Navigator.GoToBudgetPage();
            EnterRandomTextInSearchingField();            
            PushEnter();
            WaitUntilFindElement(10, By.XPath("//div[@class= 'u8jP831aiskq6Oe6mMlo']"));
            return this;
        }                

        public BudgetHelper OpenColumnsButtonPopup()
        {
            manager.Navigator.GoToBudgetPage();            
            BudgetColumnsButtonClick();
            return this;
        }

        public BudgetHelper BudgetColumnsTurnOff(BudgetColumnsData budgetColumnsData)
        {
            manager.Navigator.GoToBudgetPage();
            BudgetColumnsButtonClick();
            ColumnsSwitchOff(budgetColumnsData);
            driver.Navigate().Refresh();
            WaitUntilFindBudgetList();
            return this;
        }
        public BudgetHelper SearchingFieldClick()
        {
            manager.Navigator.GoToBudgetPage();
            MagnifyingGlassClick();
            PushEnter();
            return this;
        }











        // Создаем список бюджетов
        public List<BudgetData> GetBudgetList()
        {            
            List<BudgetData> budgets = new List<BudgetData>();
            manager.Navigator.GoToBudgetPage();
            driver.Navigate().Refresh();
            WaitUntilFindBudgetList();

            ICollection<IWebElement> elements = driver.FindElements(budgetCard);            
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
        public List<string> AllBudgetColumns() => driver.FindElements(allBudgetColumnsTitles).Select(x => x.Text).ToList();





        // Низкоуровневые методы


        public bool? SearchingFieldHintIsPresent()
        {
            return driver.FindElement(searchingFieldHint).Displayed;
        }        

        public bool? SearchingFieldCrossIsPresent()
        {
            return driver.FindElement(searchingFieldCross).Displayed;
        }

        public BudgetHelper WaitUntilFindBudgetList()
        {
            WaitUntilFindElement(10, budgetList);
            return this;
        }

        public int CheckBoxIsDisabled()
        {
            if (ColumnsPopupIsOpen() == false)
            {
                BudgetColumnsButtonClick();
            }
            return driver.FindElements(disabledCheckboxInColumsSettingsPopup).Count;
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
                    "contains(text(), '" + budgetColumnsData.ColumnName + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnRemaining + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnPO + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnProjects + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnTotal + "') or " +
                    "contains(text(), '" + budgetColumnsData.ColumnDate + "')]"));
            
            foreach(var element in elementsCount)
            {
                element.Click();
                Thread.Sleep(200);
            }
            return this;
        }

        public bool ColumnsPopupIsOpen()
        {
            return IsElementPresent(columnsSettingsPopup);
        }

        public bool ColumnsPopupHaveColumnsName()
        {
            if (IsElementPresent(columnsPopupNameTitle)
                && IsElementPresent(columnsPopupRemainingTitle)
                && IsElementPresent(columnsPopupPOTitle)
                && IsElementPresent(columnsPopupProjectsTitle)
                && IsElementPresent(columnsPopupTotalTitle)
                && IsElementPresent(columnsPopupCreatedTitle)
                ) { return true; }
            return false;
        }

        public bool AllColumnsIsTurnOn(int i)
        {
            if (driver.FindElements(enabledColumnInColumnsPopup).Count == i)
            {
                return true;
            }
            return false;
        }

        public BudgetHelper BudgetColumnsButtonClick()
        {
            driver.FindElement(columnsButton).Click();            
            return this;
        }

        public BudgetHelper ColumnsTurnOnIfItTurnOff()
        {
            if (IsElementPresent(newBudgetButton) == false)
            {
                manager.Navigator.GoToBudgetPage();
            }

            if (IsElementPresent(columnsSettingsPopup) == false)
            {
                BudgetColumnsButtonClick();
            }

            if (ColumnsInColumnsListAreOff())
            {
                ColumnsTurnOn();                
            }

            if (ColumnsAreOn())
            {
                BudgetColumnsButtonClick();
            }
            return this;
        }

        public bool ColumnsAreOn()
        {
            return driver.FindElements(disabledColumnInColumnsPopup).Count == 0;
        }

        public bool ColumnsInColumnsListAreOff()
        {
            return driver.FindElements(disabledColumnInColumnsPopup).Count >= 1;
        }

        public BudgetHelper ColumnsTurnOn()
        {
            var elements = driver.FindElements(disabledColumnInColumnsPopup);
            foreach (var element in elements)
            {
                element.Click();
            }
            return this;
        }

        public BudgetHelper EnterRandomTextInSearchingField()
        {
            string text = manager.TextGenerator(1, 8);
            driver.FindElement(searchField).SendKeys(text);
            return this;
        }

        public bool BudgetsNotFound()
        {
            if (IsElementPresent(noBudgetsToDisplayText)) { return true; }
            return false;
        }

        public BudgetHelper PushEnter()
        {
            driver.FindElement(searchField).SendKeys(Keys.Enter);            
            return this;
        }

        public BudgetHelper TakeBudgetNameAndEnterItToSearchBar()
        {
            WaitUntilFindElement(10, budgetNameColumnValue);
            string bname = driver.FindElement(budgetNameColumnValue).Text;
            driver.FindElement(searchField).SendKeys(bname);
            return this;
        }

        public BudgetHelper MagnifyingGlassClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('BUDGETS_SEARCH_FIELD_BUTTON').click()");
            Thread.Sleep(1000);
            return this;
        }
        
        public bool SearchingIsCorrect()
        {
            bool result = true;
            ICollection<IWebElement> elements = driver.FindElements(budgetNameColumnValue);
            foreach (IWebElement element in elements)
            {
                string text = element.Text.ToLower();
                string budgetNameInSearchBar = driver.FindElement(searchField).GetAttribute("value").ToLower();
                if (text.Contains(budgetNameInSearchBar)) { continue; }
                else { return result = false; }
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
            driver.FindElement(searchField).SendKeys(text);
            return this;
        }

        public bool BudgetSearchFieldIsEmpty()
        {
            string text = driver.FindElement(searchField).GetAttribute("value");
            if (text.Contains("")) { return true; }
            return false;
        }

        public BudgetHelper ReadonlyQuestionMarkClick()
        {
            driver.FindElement(budgetModalReadOnlyIcon).Click();
            Thread.Sleep(200);
            return this;
        }

        public bool BudgetModalReadOnlyIconPopupText()
        {
            string text = driver.FindElement(budgetModalReadOnlyIconPopup).Text;
            if (text.Contains("This budget has already been used in projects.")) { return true; }
            return false;
        }

        public BudgetHelper FindBudgetWithProjectsAndOpenBurger()
        {   
            driver.FindElement(budgetBurgerWithProjects).Click();
            return this;
        }

        public BudgetHelper OpenButtonInBurgerClick()
        {
            WaitUntilFindElement(10, openButtonInBurger);
            driver.FindElement(openButtonInBurger).Click();                        
            Thread.Sleep(200);
            return this;
        }

        public BudgetHelper FindBudgetWithoutProjectsAndOpenBurger(BudgetData budgetData)
        {
            driver.Navigate().Refresh();
            WaitUntilFindBudgetList();
            
            if (IsElementPresent(budgetBurgerWithOutProjects) == false)
            {
                CreateNewBudget(budgetData);
                manager.Navigator.GoToBudgetPage();
                driver.FindElement(budgetBurgerWithOutProjects).Click();
            }
            else
            {
                driver.FindElement(budgetBurgerWithOutProjects).Click();
            }
            return this;
        }

        public bool BudgetUpdateButtonIsPresent()
        {
            return IsElementPresent(budgetModalEditButton);
        }

        public bool NewBudgetModalIsOpen()
        {
            return IsElementPresent(budgetModal);
        }

        public bool CreateBudgetButtonIsEnabled()
        {
            return driver.FindElement(budgetModalCreateButton).Enabled;
        }

        public bool BudgetTooltipIsPresent()
        {
            return IsElementPresent(budgetModalPOPopup);
        }

        public bool POTooltipContainCorrectText()
        {
            string text = driver.FindElement(budgetModalPOPopup).Text;
            return text.Contains("Budget with such po number is already exists.");
        }

        public bool CostTooltipContainCorrectText()
        {
            string text = driver.FindElement(budgetModalPOPopup).Text;
            return text.Contains("Such budget already defined for the client.");
        }

        public BudgetHelper BudgetCreateButtonClick()
        {
            driver.FindElement(budgetModalCreateButton).Click();            
            return this;
        }

        public BudgetHelper EnterTotal(BudgetData budgetData)
        {
            driver.FindElement(budgetModalTotalField).Click();
            driver.FindElement(budgetModalTotalField).Clear();
            driver.FindElement(budgetModalTotalField).SendKeys(budgetData.BudgetTotal);
            return this;
        }

        public BudgetHelper SelectUSDCurrency()
        {            
            if (IsElementPresent(budgetModalCurrencyField))
            {
                driver.FindElement(budgetModalCurrencyField).Click();
                driver.FindElement(budgetModalCurrencyUSD).Click();
            }
            return this;
        }

        public BudgetHelper EnterBudgetCost(BudgetData budgetData)
        {
            driver.FindElement(budgetModalCostField).Click();
            driver.FindElement(budgetModalCostField).Clear();
            driver.FindElement(budgetModalCostField).SendKeys(budgetData.BudgetCost);
            return this;
        }

        public BudgetHelper EnterPOnumber(BudgetData budgetData)
        {
            driver.FindElement(budgetModalPOField).Click();
            driver.FindElement(budgetModalPOField).Clear();
            driver.FindElement(budgetModalPOField).SendKeys(budgetData.BudgetPO);
            return this;
        }

        public BudgetHelper NewBudgetButtonClick()
        {
            driver.FindElement(newBudgetButton).Click();
            return this;
        }

        public BudgetHelper BudgetBurgerClick()
        {
            //WaitUntilFindElement(10, budgetBurgerWithOutProjects);
            driver.FindElement(budgetBurgerWithOutProjects).Click();
            return this;
        }

        public BudgetHelper BudgetDeleteButtonClick()
        {
            driver.FindElement(budgetBurgerDeleteButton).Click();
            return this;
        }

        public BudgetHelper BudgetDeleteConfirm()
        {
            driver.FindElement(budgetDeleteConfirmButton).Click();
            return this;
        }

        public BudgetHelper BudgetDeleteDecline()
        {
            driver.FindElement(budgetDeleteDeclineButton).Click();
            return this;
        }
    }
}
