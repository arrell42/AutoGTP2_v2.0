using NUnit.Framework;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class DeadlineTests : AuthTestBase
    {
        // GTP2-R-01-11.1
        [Test]
        [Category("Deadline")]
        public void DeadlineTooltipTest()
        {
            app.Dashport.OpenDeadlineAndQuestionMarkClick();

            Assert.IsTrue(app.Dashport.DeadlineTooltipIsPresent());
            Assert.IsTrue(app.Dashport.DeadlineTooltipContainsText());
        }

        // GTP2-R-01-11.1
        [Test]
        [Category("Deadline")]
        public void OpenProjectInDeadlineTest()
        {
            app.Dashport.OpenProjectInDeadline();

            Assert.IsTrue(app.Dashport.ProjectCardIsOpen());
            Assert.IsTrue(app.Dashport.ProjectStatusInProjectCardIsCorrect("In progress"));
        }

    }
}
