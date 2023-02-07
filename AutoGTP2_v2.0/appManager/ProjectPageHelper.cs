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

        //LOCATORS
        public readonly By applyButtonInFilters = By.Id("PROJECTS_FILTERS_APPLY");
        public readonly By expressIcon = By.XPath("//*[local-name()='circle' and @fill='#b536e2']");
        public readonly By headProjectIcon = By.XPath("//*[local-name()='circle' and @fill='url(#paint0_linear)']");
        public readonly By projectCardOnPage = By.XPath("//div[@class= 'Y60VrDynu5B8vFAVkO5A']");
        public readonly By dateTypeButton = By.XPath("//div[@class= 'react-dropdown-select filter-type-list css-12zlm52-ReactDropdownSelect e1gzf2xs0']");
        public readonly By startDateFieldInFilters = By.Id("PROJECTS_FILTERSFROM");
        public readonly By endDateFieldInFilters = By.Id("PROJECTS_FILTERSTO");
        public readonly By endDatePopupInFilters = By.XPath("//p[@class= 'NlYXWAOoJuW3ZB980xxr']");
        public readonly By vendorFieldInFilters = By.XPath("//div[@class= 'filter-vendor filter-section']//div[@class= 'react-dropdown-select undefined css-12zlm52-ReactDropdownSelect e1gzf2xs0']//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']");
        public readonly By projectCard = By.XPath("//div[@class= 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']");
        public readonly By vendorInProjectCardField = By.XPath("//div[@id= 'project-vendor-dropdown']//span");
        public readonly By searchingField = By.Id("PROJECTS_SEARCH_FIELD");
        public readonly By noDataMessage = By.XPath("//div[@class= 'u8jP831aiskq6Oe6mMlo']");
        public readonly By crossButtonInSearchingField = By.XPath("//p[@class= 'search-delete']");
        public readonly By projectNameColumnValue = By.Id("PROJECTS_PROJECT_NAME");
        public readonly By startDatePopupInFilters = By.XPath("//p[@class= 'YGwtnExaSDV_RZqBYnPD']");
        public readonly By projectList = By.XPath("//div[@class= 'fPooHDtNQyVHMCf4O9mn']");
        public readonly By representativeFieldInFilters = By.XPath("//div[@class= 'filter-representative']//span");
        public readonly By representativeNameInProjectList = By.XPath("//div[@class= 'HmZHR9aWxu9QsxsKBvP_ GfQWB6JjS_ecBSmInOZe']//following-sibling::div");
        public readonly By pmFieldInFilters = By.XPath("//div[@class= 'filter-representative-PM']//span");
        public readonly By pmNameInProjectList = By.XPath("//div[@class= 'HmZHR9aWxu9QsxsKBvP_' and contains(text(), 'Responsible PM')]//following-sibling::div");
        public readonly By statusInFilters = By.XPath("//div[@class= 'statuses-dropdown-lock']");
        public readonly By statusNameInProjectList = By.XPath("//div[@id= 'PROJECT_STATUS']//span");
        public readonly By deleteStatusCrossInFilters = By.XPath("//*[local-name()='path' and @stroke='#3798F3']");
        public readonly By disabledCheckboxInColumsSettingsPopup = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB _fGfxt_KTPxUyHmi7HXe']");
        public readonly By columnsPopup = By.Id("settings-columns");
        public readonly By newProjectButton = By.Id("PROJECTS_NEW_PROJECT_BUTTON");
        public readonly By disabledColumnInColumnsPopup = By.XPath("//div[@class= 'UVPAJnHrDOYjcYvCJvHC jfNvdXFx_TRHu6VpHYEB']");
        




        public ProjectPageHelper ProjectsColumnButtonClick()
        {
            manager.Navigator.GoToProjectPage();
            ColumnsButtonClick();
            return this;
        }

        public ProjectPageHelper FillFilterAndClearButtonClick(int projectType, string dateTypeName, string startDate, string endDate)
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectProjectTypeInFilters(projectType); // 1 - All, 2 - Regular, 3 - Express, 4 - Multiproject
            SelectDateTypeInFilters(dateTypeName); // Types: start date, end date, date of creation / Date format - 10 Nov 2022
            SetStartDateInFilter(startDate);
            SetEndDateInFilter(endDate);
            SelectVendorInFilters(1); // Multiple vendors - index 0
            //SelectSubjectAreaInFilters("Arts"); // Имя тематики
            //SelectRepresentativeInFilters("Main_test"); //Имя представителя
            //SelectPMInFilters("Mogilevsky Igor"); // Имя ПМа
            //SelectDepartmentInFilters("dtestDepartament 1"); // Имя отдела
            //SelectTeamInFilters(""); // Имя команды
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

        public ProjectPageHelper OpenBurgerForQuotationCompletedStatusProject(string status)
        {
            manager.Navigator.GoToProjectPage();
            manager.Projects.SortProjectsByStatus(status);
            manager.Projects.ClickProjectBurger();
            manager.Projects.ProjectDeleteButtonInBurgerClick();
            return this;
        }

        public ProjectPageHelper OpenMessagesFromProjectBurger()
        {
            manager.Navigator.GoToProjectPage();            
            manager.Projects.ClickProjectBurger();
            manager.Projects.OpenMessagesButtonClick();
            return this;
        }

        public ProjectPageHelper EditButtonInBurgerClick()
        {
            manager.Navigator.GoToProjectPage();
            driver.Navigate().Refresh();
            manager.Projects.ClickProjectBurger();
            manager.Projects.EditButtonInBurgerClick();
            return this;
        }
        public ProjectPageHelper SelectProjectCountOnPage(string i)
        {
            manager.Navigator.GoToProjectPage();
            ShowOnPageClick();
            SelectCountOnPage(i);
            return this;
        }

        public ProjectPageHelper SelectProjectTypeInFilter(int projectType)
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectProjectTypeInFilters(projectType);
            ApplyButtonInFiltersClick();
            return this;
        }

        public ProjectPageHelper SelectDateTypeAndRangeInFilter(string dateTypeName, string startDate, string endDate)
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectDateTypeInFilters(dateTypeName);
            SetStartDateInFilter(startDate);
            SetEndDateInFilter(endDate);
            PushEnter(endDateFieldInFilters);
            return this;
        }       

        public ProjectPageHelper SortByVendorInFilters()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectVendorInFilters(1);
            ApplyButtonInFiltersClick();
            return this;
        }

        public ProjectPageHelper EnterNotExistingProjectName()
        {
            manager.Navigator.GoToProjectPage();
            EnterRandomTextInSearchingField();
            PushEnter(searchingField);
            WaitUntilFindElement(10, noDataMessage);
            return this;
        }
        public ProjectPageHelper EnterNotExistingProjectNameAndClearSearchingField()
        {
            EnterNotExistingProjectName();
            CrossButtonInSearchingFieldClick();
            return this;
        }

        public ProjectPageHelper EnterExistingProjectNameAndPushEnter()
        {
            manager.Navigator.GoToProjectPage();
            TakeProjectNameAndEnterItToSearchBar();
            PushEnter(searchingField);
            Thread.Sleep(2000);
            return this;
        }

        public ProjectPageHelper EnterExistingProjectNameAndAndClickMagnifyingGlass()
        {
            manager.Navigator.GoToProjectPage();
            TakeProjectNameAndEnterItToSearchBar();
            MagnifyingGlassClick();
            Thread.Sleep(2000);
            return this;
        }

        public ProjectPageHelper SearchingFieldClick()
        {
            manager.Navigator.GoToProjectPage();
            MagnifyingGlassClick();
            PushEnter(searchingField);
            return this;
        }
        public ProjectPageHelper SortByRepresentativeInFilters()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectRepresentativeInFilters();
            ApplyButtonInFiltersClick();
            return this;
        }
        
        public ProjectPageHelper SortByPMInFilters()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectPMInFilters();
            ApplyButtonInFiltersClick();
            return this;
        }
        public ProjectPageHelper SortByCompletedStatusInFilters()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectStatusInFilters("Completed");
            ApplyButtonInFiltersClick();
            return this;
        }
        public ProjectPageHelper SortByDeferredAndCompletedStatusInFilters()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectStatusInFilters("Completed");            
            SelectStatusInFilters("Deferred");
            ApplyButtonInFiltersClick();
            return this;
        }
        public ProjectPageHelper SortByThreeStatusesInFilters()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectStatusInFilters("Completed");
            SelectStatusInFilters("Deferred");
            SelectStatusInFilters("Cancelled");            
            return this;
        }

        public ProjectPageHelper DeleteStatusFromStatusesList()
        {
            manager.Navigator.GoToProjectPage();
            FiltersButtonClick();
            SelectStatusInFilters("Completed");
            SelectStatusInFilters("Deferred");
            SelectStatusInFilters("Cancelled");
            DeleteStatusInFilter();
            return this;
        }

        public ProjectPageHelper TurnOffProjectsColumn(ProjectColumnsData projectColumnsData)
        {
            manager.Navigator.GoToProjectPage();
            ColumnsButtonClick();
            ColumnsSwitchOff(projectColumnsData);
            driver.Navigate().Refresh();
            WaitUntilFindProjectList();
            return this;
        }


















        // Низкоуровневые методы

        public ProjectPageHelper ColumnsTurnOnIfItTurnOff()
        {
            if (IsElementPresent(newProjectButton) == false)
            {
                manager.Navigator.GoToProjectPage();
            }

            if (IsElementPresent(columnsPopup) == false)
            {
                ColumnsButtonClick();
            }

            if (ColumnsInColumnsListAreOff())
            {
                ColumnsTurnOn();
            }

            if (ColumnsAreOn())
            {
                ColumnsButtonClick();
            }
            return this;
        }

        public bool ColumnsInColumnsListAreOff()
        {
            return driver.FindElements(disabledColumnInColumnsPopup).Count >= 1;
        }
        public ProjectPageHelper ColumnsTurnOn()
        {
            var elements = driver.FindElements(disabledColumnInColumnsPopup);
            foreach (var element in elements)
            {
                element.Click();
            }
            return this;
        }

        public double CheckBoxIsDisabled()
        {
            if (ColumnsPopupIsOpen() == false)
            {
                ColumnsButtonClick();
            }
            return driver.FindElements(disabledCheckboxInColumsSettingsPopup).Count;            
        }

        public bool ColumnsPopupIsOpen()
        {
            return IsElementPresent(columnsPopup);
        }

        public ProjectPageHelper WaitUntilFindProjectList()
        {
            WaitUntilFindElement(10, projectList);
            return this;
        }
        public bool ColumnsAreOn()
        {
            return driver.FindElements(disabledColumnInColumnsPopup).Count == 0;
        }

        public ProjectPageHelper ColumnsSwitchOff(ProjectColumnsData projectColumnsData)
        {
            if (projectColumnsData.ProjectName == null) { projectColumnsData.ProjectName = "  "; }
            if (projectColumnsData.Status == null) { projectColumnsData.Status = "  "; }
            if (projectColumnsData.LanguagePair == null) { projectColumnsData.LanguagePair = "  "; }
            if (projectColumnsData.Quantity == null) { projectColumnsData.Quantity = "  "; }
            if (projectColumnsData.StartDate == null) { projectColumnsData.StartDate = "  "; }
            if (projectColumnsData.EndDate == null) { projectColumnsData.EndDate = "  "; }
            if (projectColumnsData.TotalAmount == null) { projectColumnsData.TotalAmount = "  "; }
            if (projectColumnsData.DateOfCreation == null) { projectColumnsData.DateOfCreation = "  "; }
            if (projectColumnsData.Representative == null) { projectColumnsData.Representative = "  "; }
            if (projectColumnsData.ResponsiblePM == null) { projectColumnsData.ResponsiblePM = "  "; }
            if (projectColumnsData.Budget == null) { projectColumnsData.Budget = "  "; }
            if (projectColumnsData.Vendor == null) { projectColumnsData.Vendor = "  "; }
            if (projectColumnsData.SubjectArea == null) { projectColumnsData.SubjectArea = "  "; }

            ICollection<IWebElement> elementsCount = driver.FindElements(By.XPath(
                    "//div[@id= 'settings-columns']//div[@class= 'UVPAJnHrDOYjcYvCJvHC zQlqaPTsRxDizaEB2uBM jfNvdXFx_TRHu6VpHYEB' and " +
                    "contains(text(), '" + projectColumnsData.ProjectName + "') or " +
                    "contains(text(), '" + projectColumnsData.Status + "') or " +
                    "contains(text(), '" + projectColumnsData.LanguagePair + "') or " +
                    "contains(text(), '" + projectColumnsData.Quantity + "') or " +
                    "contains(text(), '" + projectColumnsData.StartDate + "') or " +
                    "contains(text(), '" + projectColumnsData.EndDate + "') or " +
                    "contains(text(), '" + projectColumnsData.TotalAmount + "') or " +
                    "contains(text(), '" + projectColumnsData.DateOfCreation + "') or " +
                    "contains(text(), '" + projectColumnsData.Representative + "') or " +
                    "contains(text(), '" + projectColumnsData.ResponsiblePM + "') or " +
                    "contains(text(), '" + projectColumnsData.Budget + "') or " +
                    "contains(text(), '" + projectColumnsData.Vendor + "') or " +
                    "contains(text(), '" + projectColumnsData.SubjectArea + "')]"
                    ));

            foreach (var element in elementsCount)
            {
                element.Click();
                Thread.Sleep(200);
            }
            return this;
        }

        public ProjectPageHelper DeleteStatusInFilter()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class= 'filter-chosen-status']"));
            foreach (IWebElement element in elements)
            {
                driver.FindElement(deleteStatusCrossInFilters).Click();
            }
            return this;
        }
        public bool? StatusListContainsElements(int i)
        {
            return driver.FindElements(By.XPath("//div[@class= 'filter-chosen-status']")).Count == i;
        }
        public bool? StatusInProjectIsCorrect()
        {
            FiltersButtonClick();
            bool result = true;
            string statusName = driver.FindElement(statusNameInProjectList).Text;

            ICollection<IWebElement> elements = driver.FindElements(By.Id("PROJECTS_PROJECT_NAME"));
            foreach (IWebElement element in elements)
            {
                if (statusName == "Completed" || statusName == "Deferred")
                {
                    continue;
                }
                else { return result = false; }
            }
            return result;
        }

        public ProjectPageHelper SelectStatusInFilters(string status)
        {
            driver.FindElement(statusInFilters).Click();
            driver.FindElement(By.XPath("//span[@aria-label= '" + status + "']")).Click();
            return this;
        }

        public bool? PMInProjectIsCorrect()
        {
            FiltersButtonClick();
            bool result = true;
            string pmName = driver.FindElement(pmFieldInFilters).Text;

            ICollection<IWebElement> elements = driver.FindElements(By.Id("PROJECTS_PROJECT_NAME"));
            foreach (IWebElement element in elements)
            {
                string pmNameInProjectCard = driver.FindElement(pmNameInProjectList).Text;
                if (pmNameInProjectCard.Contains(pmName))
                {
                    continue;
                }
                else { return result = false; }
            }
            return result;
        }

        public bool? RepresentativeInProjectIsCorrect()
        {
            FiltersButtonClick();
            bool result = true;
            string repName = driver.FindElement(representativeFieldInFilters).Text;

            ICollection<IWebElement> elements = driver.FindElements(By.Id("PROJECTS_PROJECT_NAME"));
            foreach (IWebElement element in elements)
            {                
                string representativeNameInProjectCard = driver.FindElement(representativeNameInProjectList).Text;
                if (representativeNameInProjectCard.Contains(repName))
                {                    
                    continue;
                }
                else { return result = false; }
            }
            return result;
        }

        public bool? StartDatePopupInFiltersIsPresent()
        {
            return IsElementPresent(startDatePopupInFilters);
        }

        public ProjectPageHelper PushEnter(By element)
        {
            if ( ! IsElementPresent(By.XPath("//div[@class= 'popup-overlay ']")))
            {
                driver.FindElement(element).Click();
                driver.FindElement(element).SendKeys(Keys.Enter);
            }            
            return this;
        }

        public bool? SearchingFieldIsEmpty()
        {
            string text = driver.FindElement(searchingField).GetAttribute("value");
            if (text.Contains("")) { return true; }
            return false;
        }

        public ProjectPageHelper MagnifyingGlassClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('PROJECTS_SEARCH_FIELD_BUTTON').click()");
            Thread.Sleep(1000);
            return this;
        }

        public bool? SearchingIsCorrect()
        {
            bool result = true;
            ICollection<IWebElement> elements = driver.FindElements(projectNameColumnValue);
            foreach (IWebElement element in elements)
            {
                string text = element.Text.ToLower();
                string projectNameInSearchBar = driver.FindElement(searchingField).GetAttribute("value").ToLower();
                if (text.Contains(projectNameInSearchBar)) { continue; }
                else { return result = false; }
            }
            return result;
        }

        public ProjectPageHelper TakeProjectNameAndEnterItToSearchBar()
        {
            WaitUntilFindElement(10, projectNameColumnValue);
            string projectName = driver.FindElement(projectNameColumnValue).Text;
            driver.FindElement(searchingField).SendKeys(projectName);
            return this;
        }

        public ProjectPageHelper CrossButtonInSearchingFieldClick()
        {
            driver.FindElement(crossButtonInSearchingField).Click();
            WaitUntilFindElement(10, projectCardOnPage);
            return this;
        }

        public bool? ProjectsNotFound()
        {
            return driver.FindElements(projectCard).Count() == 0;
        }

        public ProjectPageHelper EnterRandomTextInSearchingField()
        {
            string text = manager.TextGenerator(1, 8);
            driver.FindElement(searchingField).SendKeys(text);
            return this;
        }

        public bool? VendorInProjectIsCorrect()
        {
            FiltersButtonClick();
            bool result = true;
            string vendorName = driver.FindElement(vendorFieldInFilters).Text;
            
            ICollection<IWebElement> elements = driver.FindElements(By.Id("PROJECTS_PROJECT_NAME"));
            foreach (IWebElement element in elements)
            {
                element.Click();
                WaitUntilFindElement(4, projectCard);
                string vendorNameInProjectCard = driver.FindElement(vendorInProjectCardField).Text;
                if (vendorNameInProjectCard.Contains(vendorName))
                { 
                    manager.Projects.CancelButtonInProjectCardClick();                    
                    continue; 
                } else { return result = false; }
            }            
            return result;
        }

        public bool? StartDatePopupInFiltersContainsCorrectText()
        {
            string popupText = driver.FindElement(startDatePopupInFilters).Text;
            if ( ! popupText.Contains("Invalid date. Please enter correct value.")) { return false; }
            return true;
        }

        public bool? EndDatePopupInFiltersContainsCorrectText()
        {
            string popupText = driver.FindElement(endDatePopupInFilters).Text;
            if( ! popupText.Contains("Invalid date. Please enter correct value.")) { return false; }
            return true;
        }

        public bool? EndDatePopupInFiltersIsPresent()
        {           
            return IsElementPresent(endDatePopupInFilters);
        }

        public bool? AllProjectsInPageAreRegular()
        {
            if (IsElementPresent(expressIcon)
                && IsElementPresent(headProjectIcon)) { return false; }
            return true;
        }

        public bool? AllProjectsInPageAreExpress()
        {
            ICollection<IWebElement> expressIcons = driver.FindElements(expressIcon);
            ICollection<IWebElement> projectsOnPage = driver.FindElements(projectCardOnPage);
            if(expressIcons.Count != projectsOnPage.Count) { return false; }
            return true;            
        }

        public ProjectPageHelper ApplyButtonInFiltersClick()
        {
            driver.FindElement(applyButtonInFilters).Click();
            Thread.Sleep(2000);
            return this;
        }

        public bool ProjectCountOnPage(int i)
        {
            return driver.FindElements(By.XPath("//div[@class='Y60VrDynu5B8vFAVkO5A']")).Count == i;
        }

        public ProjectPageHelper ShowOnPageClick()
        {
            IWebElement showOnPage =
                driver.FindElement(By.XPath(
                    "//div[@class= 'react-dropdown-select t9s7tcO8gRvMaCSP8RY6 css-12zlm52-ReactDropdownSelect e1gzf2xs0']"));
            showOnPage.Click();
            WaitUntilFindElement(10, By.XPath("//div[@class= 'react-dropdown-select-dropdown react-dropdown-select-dropdown-position-top css-1emopdu-DropDown e1qjn9k90']"));
            return this;
        }

        public ProjectPageHelper SelectCountOnPage(string i)
        {
            driver.FindElement(By.XPath("//p[@title='" + i + "']")).Click();
            driver.Navigate().Refresh();
            manager.Projects.WaitUntilFindProjectList();
            Thread.Sleep(2000);
            return this;
        }
        public ProjectPageHelper SelectProjectTypeInFilters(int i) // 1 - All, 2 - Regular, 3 - Express, 4 - Multiproject
        {
            IWebElement type = driver.FindElement(By.XPath("//label[@class= 'filter-check'][" + i + "]"));
            type.Click();
            return this;
        }

        public ProjectPageHelper SelectDateTypeInFilters(string dateTypeName)
        {
            driver.FindElement(dateTypeButton).Click();            

            IWebElement dateType = driver.FindElement(
                By.XPath("//p[@class= 'CKkqQTXqlkqO2CTJTb3k' and contains(text(), '" + dateTypeName + "')]"));
            dateType.Click();

            //SetStartDateInFilter(startDate);
            //SetEndDateInFilter(endDate);
            return this;
        }

        public ProjectPageHelper SetStartDateInFilter(string startDate)
        {
            driver.FindElement(startDateFieldInFilters).Click();
            driver.FindElement(startDateFieldInFilters).SendKeys(startDate);            
            return this;
        }

        public ProjectPageHelper SetEndDateInFilter(string endDate)
        {
            if( ! IsElementPresent(By.XPath("//div[@class= 'popup-overlay ']")))
            {
                driver.FindElement(endDateFieldInFilters).Click();
                driver.FindElement(endDateFieldInFilters).SendKeys(endDate);
            }                        
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

        public ProjectPageHelper SelectRepresentativeInFilters()
        {
            IWebElement representativeField = driver.FindElement(By.XPath("//p[contains(text(), 'representative')]//following-sibling::div//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']"));
            representativeField.Click();

            IWebElement representative = driver.FindElement(By.XPath("//div[@class= 'YxhDSz1flbKA8yowp3RE  '][1]"));
            representative.Click();
            return this;
        }

        public ProjectPageHelper SelectPMInFilters()
        {
            IWebElement pmField = driver.FindElement(
                By.XPath("//p[contains(text(), 'PM')]//following-sibling::div//div[@class= 'react-dropdown-select-content react-dropdown-select-type-single css-v1jrxw-ContentComponent e1gn6jc30']"));
            pmField.Click();

            IWebElement pm = driver.FindElement(By.XPath("//div[@class= 'YxhDSz1flbKA8yowp3RE  ']"));
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
