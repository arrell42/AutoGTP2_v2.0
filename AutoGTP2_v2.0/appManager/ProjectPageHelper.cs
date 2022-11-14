using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoGTP2Tests
{
    public class ProjectPageHelper : BaseHelper
    {
        public ProjectPageHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectPageHelper ProjectsColumnButtonClick()
        {
            manager.Navigator.GoToProjectPage();
            ColumnsButtonClick();
            return this;
        }

        public ProjectPageHelper FillFilterAndClearButtonClick()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectProjectTypeInFilters(2); // 1 - All, 2 - Regular, 3 - Express, 4 - Multiproject
            SelectDateInFilters("start date", "01 Nov 2022", "10 Nov 2022"); // Types: start date, end date, date of creation / Date format - 10 Nov 2022
            SelectVendorInFilters(1); // Multiple vendors - index 0
            SelectSubjectAreaInFilters("Arts"); // Имя тематики
            SelectRepresentativeInFilters("Main_test"); //Имя представителя
            SelectPMInFilters("Mogilevsky Igor"); // Имя ПМа
            SelectDepartmentInFilters("dtestDepartament 1"); // Имя отдела
            SelectTeamInFilters(""); // Имя команды
            SelectAmountRangeInFilters("USD", "100", "10000"); // Название валюты, начальная сумма, конечная сумма
            manager.Projects.SelectProjectStatusInFilter("Ordered"); //Название статуса            
            manager.Projects.FilterApplyButtonClick();
            FiltersButtonClick();
            ClearButtonClick();
            return this;
        }

        public ProjectPageHelper OpenProjectWithStatus(string status)
        {
            manager.Navigator.GoToProjectPage();
            manager.Projects.SortProjectsByStatus(status);
            manager.Projects.ClickProjectBurger();
            manager.Projects.EditButtonInBurgerClick();
            return this;
        }














        // Низкоуровневые методы
        public ProjectPageHelper SelectProjectTypeInFilters(int i)
        {
            IWebElement type = driver.FindElement(By.XPath("//label[@class= 'filter-check'][" + i + "]"));
            type.Click();
            return this;
        }

        public ProjectPageHelper SelectDateInFilters(string dateTypeName, string startDate, string endDate)
        {
            IWebElement dateTypeButton = driver.FindElement(
                By.XPath("//div[@class= 'react-dropdown-select filter-type-list css-12zlm52-ReactDropdownSelect e1gzf2xs0']//div"));
            dateTypeButton.Click();

            IWebElement dateType = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + dateTypeName + "')]"));
            dateType.Click();

            SetStartDateInFilter(startDate);
            SetEndDateInFilter(endDate);
            return this;
        }

        public ProjectPageHelper SetStartDateInFilter(string startDate)
        {
            IWebElement startDateField = driver.FindElement(By.Id("PROJECTS_FILTERSFROM"));
            startDateField.Click();
            startDateField.SendKeys(startDate);
            return this;
        }

        public ProjectPageHelper SetEndDateInFilter(string endDate)
        {
            IWebElement endDateField = driver.FindElement(By.Id("PROJECTS_FILTERSTO"));
            endDateField.Click();
            endDateField.SendKeys(endDate);
            return this;
        }

        public ProjectPageHelper SelectVendorInFilters(int i)
        {
            IWebElement vendorField = driver.FindElement(By.XPath("//input[@name= 'VENDOR_DROPDOWN']"));
            vendorField.Click();

            IWebElement vendor = driver.FindElement(By.Id("VENDOR_DROPDOWN_OPTION_" + (i + 1) + ""));
            vendor.Click();
            return this;
        }

        public ProjectPageHelper SelectSubjectAreaInFilters(string saName)
        {
            IWebElement saField = driver.FindElement(By.XPath("//input[@name= 'SUBJECT_AREA']"));
            saField.Click();

            IWebElement sa = driver.FindElement(
                By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC' and contains(text(), '" + saName + "')]"));
            sa.Click();
            CloseSAListInProjectFilter();
            return this;
        }

        public ProjectPageHelper CloseSAListInProjectFilter()
        {
            IWebElement saFieldMark = driver.FindElement(By.CssSelector("#subject_area_dropdown > div > div > svg"));
            saFieldMark.Click();
            return this;
        }

        public ProjectPageHelper SelectRepresentativeInFilters(string repName)
        {
            IWebElement representativeField = driver.FindElement(
                By.XPath("//p[contains(text(), 'representative')]//following-sibling::div//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']"));
            representativeField.Click();

            IWebElement representative = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + repName + "')]"));
            representative.Click();
            return this;
        }

        public ProjectPageHelper SelectPMInFilters(string pmName)
        {
            IWebElement pmField = driver.FindElement(
                By.XPath("//p[contains(text(), 'PM')]//following-sibling::div//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']"));
            pmField.Click();

            IWebElement pm = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + pmName + "')]"));
            pm.Click();
            return this;
        }

        public ProjectPageHelper SelectDepartmentInFilters(string depName)
        {
            IWebElement departmentField = driver.FindElement(
                By.XPath("//p[contains(text(), 'Department')]//following-sibling::div//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']"));
            departmentField.Click();

            IWebElement department = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + depName + "')]"));
            department.Click();
            return this;
        }

        public ProjectPageHelper SelectTeamInFilters(string teamName)
        {
            IWebElement teamField = driver.FindElement(
                By.XPath("//p[contains(text(), 'Team')]//following-sibling::div//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']"));
            teamField.Click();

            IWebElement team = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + teamName + "')]"));
            team.Click();
            return this;
        }

        public ProjectPageHelper SelectAmountRangeInFilters(string currencyName, string start, string end)
        {
            IWebElement currencyField = driver.FindElement(By.XPath("//div[contains(text(), 'Currency')]//following-sibling::div"));
            currencyField.Click();

            IWebElement currency = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + currencyName + "')]"));
            currency.Click();

            IWebElement startRange = driver.FindElement(By.XPath("//output[@id= 'output']//input[1]"));
            IWebElement endRange = driver.FindElement(By.XPath("//output[@id= 'output']//input[2]"));

            startRange.SendKeys(Keys.Control + "a");
            startRange.SendKeys(start);

            endRange.SendKeys(Keys.Control + "a");
            endRange.SendKeys(end);

            return this;
        }

        public ProjectPageHelper FiltersButtonClick()
        {
            var filtersButton = By.Id("PROJECTS_FILTERS_BUTTON");
            driver.FindElement(filtersButton).Click();
            return this;
        }

        public ProjectPageHelper ClearButtonClick()
        {
            IWebElement clearButton = driver.FindElement(By.Id("PROJECTS_FILTERS_CLEAR"));
            clearButton.Click();
            Thread.Sleep(1000);
            return this;
        }
        public ProjectPageHelper ColumnsButtonClick()
        {
            driver.FindElement(By.Id("PROJECTS_COLUMNS_BUTTON")).Click();
            return this;
        }

        public bool ColumnsListIsOpen()
        {
            var columnsList = By.Id("settings-columns");
            return IsElementPresent(columnsList);
        }

    }
}
