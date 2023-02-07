using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGTP2Tests
{
    public class DashportHelper : BaseHelper
    {
        public DashportHelper(ApplicationManager manager) : base(manager)
        {
        }



        //LOCATORS
        public readonly By slasMoreButton = By.Id("DASHPORT_SLAS_MORE_BUTTON");
        public readonly By slasQuestionMark = By.XPath("//*[local-name()='circle' and @id='Ellipse_32-2']");
        public readonly By slasQuestionMarkTooltip = By.XPath("//div[@class= 'ant-tooltip-inner']");
        public readonly By slasClearButton = By.Id("DASHPORT_SLAS_CLEAR");
        public readonly By slasProjectList = By.XPath("//div[@class= 'HSStc5BEXsAPQ6gUcSfu']");
        public readonly By projectInSLAsList = By.XPath("//div[@class= 'uAfEqUrZYfNrNwCCnLdA oKZtZJR8g507Qy4nvITv']");
        public readonly By statusInProjectCard = By.XPath("//div[@id= 'PROJECT_STATUS']//span");
        public readonly By openedProjectCard = By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']");
        public readonly By deadlineMorebutton = By.Id("DASHPORT_DEADLINE_MORE_BUTTON");
        public readonly By deadlineQuestionMark = By.XPath("//div[@class= 'XVR3QeVpFL2UBvjzs8du']");
        public readonly By deadlineQuestionMarkTooltip = By.XPath("//div[@class= 'ant-tooltip-inner']");
        public readonly By deadlineOverdueButton = By.XPath("//button[contains(text(), 'Overdue')]");
        public readonly By projectInDeadlineList = By.XPath("//div[@class= 'zSSmn3r4L3KkiQczHqhP V7dJquKUaR_pVbkss6gS']");
        public readonly By mySpendingMoreButton = By.Id("MYSPENDING_MORE_BUTTON");
        public readonly By mySpendingQuestionMark = By.XPath("//div[@class= 'aNIhwSI1kcHehZT9A317']");
        public readonly By mySpendingQuestionMarkTooltip = By.XPath("//div[@class= 'ant-tooltip-inner']");





        public DashportHelper OpenProjectFromTableName()
        {
            manager.Navigator.GoToDashportPage();
            GanttChartProjectNameClick();
            return this;
        }

        public DashportHelper OpenProjectFromTableLine()
        {
            manager.Navigator.GoToDashportPage();
            GanttChartProjectInLineClick();
            return this;
        }
                
        public DashportHelper RegularProjectTypeFilter()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            RegularButtonClick();
            GanttApplyButtonClick();
            return this;
        }

        public DashportHelper ExpressProjectTypeFilter()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            ExpressButtonClick();
            GanttApplyButtonClick();
            return this;
        }

        public DashportHelper ProjectFromTableLinePopup()
        {
            manager.Navigator.GoToDashportPage();
            GanttChartProjectInLineClickAndHold();
            return this;
        }

        public DashportHelper OrderedProjectStatusesFilter()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            GanttChartProjectStatusesFieldClick();
            OrderedStatusSelect();
            GanttApplyButtonClick();
            return this;
        }

        public DashportHelper InProgressProjectStatusesFilter()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            GanttChartProjectStatusesFieldClick();
            InProgressStatusSelect();
            GanttApplyButtonClick();
            return this;
        }

        public DashportHelper GanttClose()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            GanttCloseButtonClick();
            return this;
        }

        public DashportHelper GanttQuestionMarkPopup()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            GanttQuestionMarkClick();
            return this;
        }

        public DashportHelper FillFilterAndClearButtonClick()
        {
            manager.Navigator.GoToDashportPage();
            GanttMoreButtonClick();
            FillFilter();
            ClearButtonClick();
            return this;
        }

        public DashportHelper OpenSLAsAndQuestionMarkClick()
        {
            manager.Navigator.GoToDashportPage();
            SLAsMoreButtonClick();
            SLAsQuestionMarkClick();
            return this;
        }

        public DashportHelper OpenProjectInSLAs()
        {
            manager.Navigator.GoToDashportPage();
            SLAsMoreButtonClick();
            SLAsClearButtonClick();
            SLAsProjectClick();
            return this;
        }

        public DashportHelper OpenDeadlineAndQuestionMarkClick()
        {
            manager.Navigator.GoToDashportPage();
            DeadlineMoreButtonClick();
            DeadlineQuestionMarkClick();            
            return this;
        }

        public DashportHelper OpenProjectInDeadline()
        {
            manager.Navigator.GoToDashportPage();
            DeadlineMoreButtonClick();
            OverdueButtonClick();
            DeadlineProjectClick();
            return this;
        }

        public DashportHelper OpenMySpendingAndQuestionMarkClick()
        {
            manager.Navigator.GoToDashportPage();
            MySpendingMoreButtonClick();
            MySpendingQuestionMarkClick();
            return this;
        }




















        // низкоуровневые методы


        public DashportHelper MySpendingMoreButtonClick()
        {
            driver.FindElement(mySpendingMoreButton).Click();
            WaitUntilFindElement(10, mySpendingQuestionMark);
            return this;
        }

        public DashportHelper MySpendingQuestionMarkClick()
        {
            driver.FindElement(mySpendingQuestionMark).Click();
            WaitUntilFindElement(5, mySpendingQuestionMarkTooltip);
            return this;
        }

        public bool? MySpendingTooltipIsPresent()
        {
            return IsElementPresent(mySpendingQuestionMarkTooltip);
        }

        public bool? MySpendingTooltipContainsText()
        {
            string textInTooltip = driver.FindElement(mySpendingQuestionMarkTooltip).Text;
            if (textInTooltip.Contains("This section provides information on project expenditure " +
                "based on Completed and In progress projects in the form of pie charts.")) { return true; }
            return false;
        }
        public DashportHelper OverdueButtonClick()
        {
            driver.FindElement(deadlineOverdueButton).Click();
            Thread.Sleep(500);
            return this;
        }
        public DashportHelper DeadlineProjectClick()
        {
            driver.FindElement(projectInDeadlineList).Click();
            WaitUntilFindElement(5, openedProjectCard);
            return this;
        }
        public DashportHelper DeadlineMoreButtonClick()
        {
            driver.FindElement(deadlineMorebutton).Click();
            WaitUntilFindElement(10, deadlineQuestionMark);
            return this;
        }

        public void DeadlineQuestionMarkClick()
        {            
            driver.FindElement(deadlineQuestionMark).Click();
            WaitUntilFindElement(5, deadlineQuestionMarkTooltip);
        }

        public bool? DeadlineTooltipIsPresent()
        {
            return IsElementPresent(deadlineQuestionMarkTooltip);
        }

        public bool? DeadlineTooltipContainsText()
        {
            string textInTooltip = driver.FindElement(deadlineQuestionMarkTooltip).Text;
            if (textInTooltip.Contains("This section provides information on how many projects are due today or tomorrow.")) { return true; }
            return false;
        }
        public bool? ProjectStatusInProjectCardIsCorrect(string statusName)
        {
            string statusText = driver.FindElement(statusInProjectCard).Text;
            if (statusText == statusName) { return true; }
            return false;
        }

        public DashportHelper SLAsClearButtonClick()
        {
            WaitUntilFindElement(10, slasClearButton);
            driver.FindElement(slasClearButton).Click();
            WaitUntilFindElement(10, slasProjectList);
            return this;
        }

        public DashportHelper SLAsProjectClick()
        {
            driver.FindElement(projectInSLAsList).Click();
            WaitUntilFindElement(10, openedProjectCard);
            return this;
        }

        public DashportHelper SLAsMoreButtonClick()
        {
            driver.FindElement(slasMoreButton).Click();
            WaitUntilFindElement(10, slasQuestionMark);            
            return this;
        }

        public DashportHelper SLAsQuestionMarkClick()
        {
            driver.FindElement(slasQuestionMark).Click();
            WaitUntilFindElement(10, slasQuestionMarkTooltip);
            return this;
        }

        public bool? SLAsTooltipIsPresent()
        {
            return IsElementPresent(slasQuestionMarkTooltip);
        }

        public bool? SLAsTooltipContainsText()
        {
            string textInTooltip = driver.FindElement(slasQuestionMarkTooltip).Text;
            if (textInTooltip.Contains("This section provides information on completed projects " +
                "(status completed with such projects in GTP) in the following subsections:")) { return true; }
            return false;
        }

        public void GanttQuestionMarkClick()
        {
            MouseClickAndHoldImitation(By.Id("DASHPORT_GANTT_TOOLTIP_ICON"));
            WaitUntilFindElement(10, By.XPath("//div[@class = 'ant-tooltip ant-tooltip-placement-bottomLeft']"));
        }

        public bool GanttQuestionMarkPopupIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'ant-tooltip ant-tooltip-placement-bottomLeft']"));
        }

        public bool GanttQuestionMarkPopupIsFilled()
        {
            return IsElementPresent(By.
                XPath("//div[@class = 'aIW9hhs7Sg_H74clfype']//p[contains(text()," +
                " 'This chart shows all current projects in statuses Ordered and In progress.')]"));
        }

        public bool AllDashportCardsIsPresent()
        {
            return IsElementPresent(By.XPath("//div[@class = 'Qs_MbKyCZqGEMKOJLKoK']"));
        }

        public DashportHelper GanttCloseButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_CLOSE_BUTTON")).Click();
            return this;
        }

        public bool GanttProjectStatusesValueIsAll()
        {
            return IsElementPresent(By.
                XPath("//div[@class = 'react-dropdown-select-content react-dropdown-select-type-single " +
                "css-v1jrxw-ContentComponent e1gn6jc30']//span[contains(text(), 'All')]"));
        }

        public bool GanttAllButtonIsActive()
        {
            return IsElementPresent(By.XPath("//button[@value = 'all' and contains (@class, 'active')]"));
        }

        public DashportHelper ClearButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_CLEAR_BUTTON")).Click();
            return this;
        }

        public DashportHelper FillFilter()
        {
            RegularButtonClick();
            GanttChartProjectStatusesFieldClick();
            OrderedStatusSelect();
            return this;
        }

        public bool ProjectsStatusesInListIsCorrect(int projCountForCheck, string statusName)
        {
            bool status = false;
            var projects = driver.FindElements(By.XPath("//div[@class= 'item ']"));
            if (projects.Count() > 0)
            {
                foreach (var item in projects)
                {                    
                    for (int i = 0; i < projCountForCheck; i++)
                    {
                        driver.FindElement(By.XPath("//div[@class= 'line-container '][" + (i + 1) + "]")).Click();
                        WaitUntilFindElement(10, By.Id("PROJECT_STATUS"));
                        string text = driver.FindElement(By.Id("PROJECT_STATUS")).Text;
                        if (text.Contains(statusName))
                        {
                            driver.FindElement(By.Id("PROJECT_CARD_CANCEL")).Click();
                            status = true;
                        }
                    }
                    break;
                }                
            }
            return status;
        }

        public DashportHelper InProgressStatusSelect()
        {
            driver.FindElement(By.XPath("//p[@title= 'In progress']")).Click();
            return this;
        }

        public DashportHelper OrderedStatusSelect()
        {

            driver.FindElement(By.XPath("//p[@title= 'Ordered']")).Click();
            return this;
        }

        public DashportHelper GanttChartProjectStatusesFieldClick()
        {
            driver.FindElement(By.XPath("//input[@class= 'react-dropdown-select-input css-26pbll-InputComponent e11wid6y0']")).Click();
            return this;
        }

        public DashportHelper GanttChartProjectInLineClickAndHold()
        {
            MouseClickImitation(By.XPath("//div[@class = 'header']"));
            MouseClickAndHoldImitation(By.Id("DASHPORT_GANTT_0_PROJECT_LINE_IN_LIST"));
            WaitUntilFindElement(10,
                By.XPath("//div[@class = '__react_component_tooltip show place-top type-dark tooltip']"));
            return this;
        }

        public DashportHelper ExpressButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_EXPRESS_BUTTON")).Click();
            return this;
        }

        public DashportHelper GanttChartProjectInLineClick()
        {
            MouseClickImitation(By.XPath("//div[@class = 'header']"));
            driver.FindElement(By.Id("DASHPORT_GANTT_0_PROJECT_LINE_IN_LIST")).Click();
            WaitUntilFindElement(10, openedProjectCard);
            return this;
        }

        public DashportHelper GanttChartProjectNameClick()
        {
            MouseClickImitation(By.XPath("//div[@class = 'header']"));
            driver.FindElement(By.Id("DASHPORT_GANTT_0_PROJECT_IN_LIST")).Click();
            WaitUntilFindElement(10, openedProjectCard);
            return this;
        }

        public DashportHelper GanttMoreButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_MORE_BUTTON")).Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'My-spending-chart-preview']"));
            return this;
        }

        public bool ExpressProjectsPresent()
        {
            return IsElementPresent(By.Id("Component_76_488"));
        }

        public DashportHelper RegularButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_REGULAR_BUTTON")).Click();
            return this;
        }
        public DashportHelper GanttApplyButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_APPLY_BUTTON")).Click();
            return this;
        }
        public bool ProjectCardIsOpen()
        {
            return IsElementPresent(openedProjectCard);
        }

        public bool ProjectLinePopupIsPresent()
        {
            return IsElementPresent(
                By.XPath("//div[@class = '__react_component_tooltip show place-top type-dark tooltip']"));
        }
    }
}
