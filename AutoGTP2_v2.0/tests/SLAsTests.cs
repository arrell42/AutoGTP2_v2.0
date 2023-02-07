using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class SLAsTests : AuthTestBase
    {
        // GTP2-R-01-08.1
        [Test]
        public void SLAsTooltipTest()
        {
            app.Dashport.OpenSLAsAndQuestionMarkClick();

            Assert.IsTrue(app.Dashport.SLAsTooltipIsPresent());
            Assert.IsTrue(app.Dashport.SLAsTooltipContainsText());
        }

        // GTP2-R-01-08.2
        [Test]
        public void OpenProjectInSLAsTest()
        {
            app.Dashport.OpenProjectInSLAs();

            Assert.IsTrue(app.Dashport.ProjectCardIsOpen());
            Assert.IsTrue(app.Dashport.ProjectStatusInProjectCardIsCorrect("Completed"));
        }        
    }
}
