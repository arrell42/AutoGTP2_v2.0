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
            applicationManager.Dashport.OpenProjectFromTableName();
            Assert.IsTrue(applicationManager.Dashport.ProjectPopupIsPresent());
        }

        [Test]
        public void ProjectFromTableLineTest()
        {
            applicationManager.Dashport.OpenProjectFromTableLine();
            Assert.IsTrue(applicationManager.Dashport.ProjectPopupIsPresent());
        }

        [Test]
        public void ProjectFromTableLinePopupTest()
        {
            applicationManager.Dashport.ProjectFromTableLinePopup();
            Assert.IsTrue(applicationManager.Dashport.ProjectLinePopupIsPresent());
        }

        [Test]
        public void RegularProjectTypeTests()
        {
            applicationManager.Dashport.RegularProjectTypeFilter();
            
            Assert.IsFalse(applicationManager.Dashport.ExpressProjectsNotPresent());            
        }

        [Test]
        public void ExpressProjectTypeTests()
        {
            applicationManager.Dashport.ExpressProjectTypeFilter();
            
            Assert.IsTrue(applicationManager.Dashport.ExpressProjectsNotPresent());
        }

        [Test]
        public void OrderedStatusFilterTests()
        {
            applicationManager.Dashport.OrderedStatusFilter();

            Assert.IsTrue(applicationManager.Dashport.ExpressProjectsNotPresent());
        }


    }
}
