using System;
using System.Data;
using System.Data.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationUpdateItemsTests : IntegrationTestsBase
    {
        private const string ItemsGuids = "12034702156974102369870315478950.12487013547852036974154872036954.410239510475236541028751394152";
        private const string UpdateItemsMethodName = "UpdateItems";
        private const string DummyXml = "DummyXml";

        private bool _processPortfolioCalled;

        [TestMethod]
        public void UpdateItems_ExecutesWithNoErrors()
        {
            // Arrange
            ArrangeUpdateItems(false);
            var resultString = string.Empty;

            // Act
            Action action = () => resultString = (string)PrivateObject.Invoke(UpdateItemsMethodName, DummyXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => DataSetReadCalled.ShouldBeTrue(),
                () => _processPortfolioCalled.ShouldBeTrue(),
                () => resultString.ShouldNotContain("error", Case.Insensitive));

        }

        [TestMethod]
        public void UpdateItems_InnerThrow_IsHandledAndMessageContainErrors()
        {
            // Arrange
            ArrangeUpdateItems(true);
            var resultString = string.Empty;

            // Act
            Action action = () => resultString = (string)PrivateObject.Invoke(UpdateItemsMethodName, DummyXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => DataSetReadCalled.ShouldBeTrue(),
                () => _processPortfolioCalled.ShouldBeFalse(),
                () => resultString.ShouldContain("error", Case.Insensitive),
                () => resultString.ShouldContain("100"));

        }

        private void ArrangeUpdateItems(bool delegateShouldThrow)
        {
            var callCount = 0;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code =>
            {
                callCount++;

                if (!delegateShouldThrow || callCount != 2)
                {
                    code();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            };

            ArrangeDataTable();
            ShimDataRow.AllInstances.ItemGetString = (_1, _2) => ItemsGuids;
            ArrangeSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid("41052063041052063041052063041010");
            ArrangeSPSite();
            ArrangeSPWeb();

            ShimSPListCollection.AllInstances.ItemGetGuid = (_1, guid) => new ShimSPList
            {
                IDGet = () => guid
            };

            _processPortfolioCalled = false;
            ShimHelperFunctions.processPortfolioItemSPWebSPListStringDataRowArrayStringBooleanOut = (
                SPWeb _1,
                SPList _2,
                string _3,
                DataRow[] _4,
                string _5,
                out bool outValue) =>
            {
                _processPortfolioCalled = true;
                outValue = true;
                return "success";
            };
        }
    }
}
