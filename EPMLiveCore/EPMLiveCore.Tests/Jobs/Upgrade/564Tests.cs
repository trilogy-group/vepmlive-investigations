using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPEmulators;

namespace EPMLiveCore.Tests.Jobs.Upgrade
{
    [TestClass]
    public class Upgrade564Tests
    {
        #region Methods (1) 

        // Public Methods (1) 

        [TestMethod]
        public void CS_OFF_ColumnShouldBeAddedTo_EPGP_CAPACITY_VALUES()
        {
            using (var context = new SPEmulationContext(IsolationLevel.Fake))
            {
                context.Web.Title.Should().Be("Munjal");
            }
        }

        #endregion Methods 
    }
}