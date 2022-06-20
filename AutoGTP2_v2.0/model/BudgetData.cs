using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoGTP2Tests
{
    public class BudgetData
    {
        private string budgetPO;
        private string budgetCost;
        private string budgetTotal;
        
        public string BudgetPO { get { return budgetPO; } set { budgetPO = value; } }
        public string BudgetCost { get { return budgetCost; } set { budgetCost = value; } }
        public string BudgetTotal { get { return budgetTotal; } set { budgetTotal = value; } }

    }
}

