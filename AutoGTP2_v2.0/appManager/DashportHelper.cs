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
    public class DashportHelper :BaseHelper
    {
        public DashportHelper(ApplicationManager manager) : base(manager)
        {
        }


        public DashportHelper OpenProjectFromTableName()
        {
            manager.Navigator.GoToDashportPage();
            MouseClickImitation(By.XPath("//div[@class = 'header']"));
            driver.FindElement(By.Id("DASHPORT_GANTT_0_PROJECT_IN_LIST")).Click();
            WaitUntilFindElement(10, 
                By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
            return this;
        }

        public DashportHelper OpenProjectFromTableLine()
        {
            manager.Navigator.GoToDashportPage();
            MouseClickImitation(By.XPath("//div[@class = 'header']"));
            driver.FindElement(By.Id("DASHPORT_GANTT_0_PROJECT_LINE_IN_LIST")).Click();
            WaitUntilFindElement(10,
                By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
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

        public DashportHelper ExpressButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_EXPRESS_BUTTON")).Click();
            return this;
        }

        public DashportHelper ProjectFromTableLinePopup()
        {
            manager.Navigator.GoToDashportPage();
            MouseClickImitation(By.XPath("//div[@class = 'header']"));
            MouseClickAndHoldImitation(By.Id("DASHPORT_GANTT_0_PROJECT_LINE_IN_LIST"));
            WaitUntilFindElement(10,
                By.XPath("//div[@class = '__react_component_tooltip show place-top type-dark tooltip']"));
            return this;
        }


        // низкоуровневые методы
        public DashportHelper GanttMoreButtonClick()
        {
            driver.FindElement(By.Id("DASHPORT_GANTT_MORE_BUTTON")).Click();
            WaitUntilElementIsHide(10, By.XPath("//div[@class = 'My-spending-chart-preview']"));
            return this;
        }

        public bool ExpressProjectsNotPresent()
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
        public bool ProjectPopupIsPresent()
        {
            return IsElementPresent(
                By.XPath("//div[@class = 'styles_modal__gNwvD styles_modalCenter__L9F2w project-card-modal']"));
        }

        public bool ProjectLinePopupIsPresent()
        {
            return IsElementPresent(
                By.XPath("//div[@class = '__react_component_tooltip show place-top type-dark tooltip']"));
        }
    }
}
