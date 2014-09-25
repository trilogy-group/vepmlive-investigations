using System;
using System.Collections.Generic;
using EPMLiveCore.Jobs.EPMLiveUpgrade;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Steps;
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
            // Ensure PFE DB update step is one of the update step

            List<Type> upgradeSteps = UpgradeUtilities.GetUpgradeSteps("5.6.4");
            upgradeSteps.Should().Contain(t => t == typeof (UpgradePfeDb));
        }

        #endregion Methods 

        [TestMethod]
        public void Transfer_AssignedToID_From_LSTMyWork_To_TSITEM()
        {
            
        }
    }
}