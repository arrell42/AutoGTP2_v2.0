using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGTP2Tests
{
    [TestFixture]
    public class GanttChartTests : AuthTestBase
    {
        [Test]
        public void ProjectFromTableNameTest()
        {
            app.Dashport.OpenProjectFromTableName();
            Assert.IsTrue(app.Dashport.ProjectPopupIsPresent());
        }

        [Test]
        public void ProjectFromTableLineTest()
        {
            app.Dashport.OpenProjectFromTableLine();
            Assert.IsTrue(app.Dashport.ProjectPopupIsPresent());
        }

        [Test]
        public void ProjectFromTableLinePopupTest()
        {
            app.Dashport.ProjectFromTableLinePopup();
            Assert.IsTrue(app.Dashport.ProjectLinePopupIsPresent());
        }

        [Test]
        public void RegularProjectTypeTests()
        {
            app.Dashport.RegularProjectTypeFilter();
            
            Assert.IsFalse(app.Dashport.ExpressProjectsNotPresent());            
        }

        [Test]
        public void ExpressProjectTypeTests()
        {
            app.Dashport.ExpressProjectTypeFilter();
            
            Assert.IsTrue(app.Dashport.ExpressProjectsNotPresent());
        }

        //[Test]
        public void OrderedStatusFilterTests()
        {
            //applicationManager.Dashport.OrderedStatusFilter();

            Assert.IsTrue(app.Dashport.ExpressProjectsNotPresent());
        }


    }
}
