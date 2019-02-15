using System;
using System.Collections.Generic;
using System.Xml.Fakes;
using System.Xml.Linq;
using EPMLive.TestFakes.Utility;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public abstract class IntegrationUpdatesTestsBase : IntegrationTestsBase
    {
        protected static readonly string SettingsString =
            "DummySetting1,DummyValue1|DummySetting2,DummyValue2|DummySetting3,DummyValue3|DummySetting4,DummyValue4";
        private int _updateCalledCount;

        protected AdoShims AdoShims { get; private set; }
        protected SharepointShims SharePointShims { get; private set; }

        [TestInitialize]

        /// <inheritdoc />
        public override void Setup()
        {
            base.Setup();
            AdoShims = AdoShims.ShimAdoNetCalls();
            SharePointShims = SharepointShims.ShimSharepointCalls();
        }

        protected void ArrangeBaseUpdatesEvents(
            bool shouldHaveConfig,
            bool shouldAdded,
            bool shouldUpdating,
            bool shouldDeleting,
            bool docLoadShouldThrow)
        {
            ShimConfigFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => shouldHaveConfig
                ? SettingsString
                : string.Empty;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSPWebCollection.AllInstances.ItemGetInt32 = (_1, _2) => SharePointShims.WebShim;
            SharePointShims.WebShim.ListsGet = () => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_1, _2) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetString = (_1, _2) => new ShimSPList();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_1, _2) => new ShimSPListItem();
            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection();
            ShimSPEventReceiverDefinitionCollection.AllInstances.ItemGetGuid = (_1, _2) => new ShimSPEventReceiverDefinition();
            _updateCalledCount = 0;
            ShimSPList.AllInstances.Update = _ => _updateCalledCount++;
            ShimSPList.AllInstances.ParentWebGet = _ => SharePointShims.WebShim;

            ShimSPListItem.AllInstances.ItemGetString = (_, str) => str;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPEventReceiverDefinition>
            {
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemAdded,
                    IdGet = () => new Guid("12457845126547841203145201010101"),
                    ClassGet = () => shouldAdded
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemUpdating,
                    IdGet = () => new Guid("46514080904051230604070105040203"),
                    ClassGet = () => shouldUpdating
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemDeleting,
                    IdGet = () => new Guid("10451023147050408010406052364785"),
                    ClassGet = () => shouldDeleting
                        ? "Class01"
                        : string.Empty
                }
            }.GetEnumerator();

            if (docLoadShouldThrow)
            {
                ShimXmlDocument.AllInstances.LoadXmlString = (_1, _2) =>
                {
                    throw new InvalidOperationException("Exception Handled");
                };
            }
        }
    }
}