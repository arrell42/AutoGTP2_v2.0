using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class MySpendingTests : AuthTestBase
    {
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
