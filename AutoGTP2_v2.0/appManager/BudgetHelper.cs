﻿using System;
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

        public BudgetHelper EnterExistingBudgetName()
        {
            manager.Navigator.GoToBudgetPage();            
            TakeBudgetNameAndEnterItToSearchBar();
            MagnifyingGlassClick();
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
































        // Низкоуровневые методы

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
