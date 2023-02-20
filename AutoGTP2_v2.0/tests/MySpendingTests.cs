using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class MySpendingTests : AuthTestBase
    {
        public static IEnumerable<DashportData> CorrectDatesFromFile()
        {
            List<DashportData> dashportData = new List<DashportData>();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\CorrcectDatesForMySpending.csv");
            string[] lines = File.ReadAllLines(path);
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                dashportData.Add(new DashportData(parts[0], parts[1]));
            }
            return dashportData;
        }
        public static IEnumerable<DashportData> InvalidDatesFromFile()
        {
            List<DashportData> dashportData = new List<DashportData>();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataFiles\InvalidDatesForMySpending.csv");
            string[] lines = File.ReadAllLines(path);
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                dashportData.Add(new DashportData(parts[0], parts[1]));
            }
            return dashportData;
        }


        // GTP2-R-01-18

        [Test, TestCaseSource("CorrectDatesFromFile")]
        public void CorrectStartDatesInMySpendingFilterTest(DashportData dates)
        {
            app.Dashport.OpenMySpendingAndEnterStartDates(dates);

            Assert.IsFalse(app.Dashport.DatesPopupIsPresent());
        }

        [Test, TestCaseSource("CorrectDatesFromFile")]
        public void CorrectEndDatesInMySpendingFilterTest(DashportData dates)
        {
            app.Dashport.OpenMySpendingAndEnterEndDates(dates);

            Assert.IsFalse(app.Dashport.DatesPopupIsPresent());
        }

        [Test, TestCaseSource("InvalidDatesFromFile")]
        public void InvalidStartDatesInMySpendingFilterTest(DashportData dates)
        {
            app.Dashport.OpenMySpendingAndEnterStartDates(dates);

            Assert.IsTrue(app.Dashport.DatesPopupIsPresent());
        }

        [Test, TestCaseSource("InvalidDatesFromFile")]
        public void InvalidEndDatesInMySpendingFilterTest(DashportData dates)
        {
            app.Dashport.OpenMySpendingAndEnterEndDates(dates);

            Assert.IsTrue(app.Dashport.DatesPopupIsPresent());
        }

        



        // GTP2-R-01-13
        [Test]
        public void MySpendingTooltipTest()
        {
            app.Dashport.OpenMySpendingAndQuestionMarkClick();

            Assert.IsTrue(app.Dashport.MySpendingTooltipIsPresent());
            Assert.IsTrue(app.Dashport.MySpendingTooltipContainsText());
        }
        
    }
}
