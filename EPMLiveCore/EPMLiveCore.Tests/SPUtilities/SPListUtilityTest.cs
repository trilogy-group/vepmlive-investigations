using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.SPUtilities;
using EPMLiveCore.SPUtilities.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.SPUtilities
{
    [TestClass]
    public class SPListUtilityTest
    {
        private IDisposable _shimContext;

        private ShimSPWeb _spWebShim;
        private ShimSPListCollection _spListCollectionShim;
        private IList<ShimSPList> _spLists;

        private Guid _testList1ID = Guid.NewGuid();
        private Guid _testList2ID = Guid.NewGuid();
        private Guid _testList3ID = Guid.NewGuid();

        [TestInitialize]
        public void SetUp()
        {
            _shimContext = ShimsContext.Create();

            _spWebShim = new ShimSPWeb();
            _spLists = new[] {
                new ShimSPList { IDGet = () => _testList1ID },
                new ShimSPList { IDGet = () => _testList2ID },
                new ShimSPList { IDGet = () => _testList3ID },
            };

            _spListCollectionShim = new ShimSPListCollection();
            _spListCollectionShim.Bind(_spLists.Select(shim => shim.Instance));

            _spWebShim.ListsGet = () => _spListCollectionShim;
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimContext.Dispose();
        }

        [TestMethod]
        public void MapLists_ListsExist_ProcessesAllListsExceptMappingNotRequired()
        {
            // Arrange
            var validListIds = _spLists.Where(pred => pred.Instance.ID != _testList3ID)
                                    .Select(pred => pred.Instance.ID)
                                    .ToArray();

            var listIdsUsed = new List<Guid>();
            ShimCoreFunctions.GetListEventsSPListStringStringIListOfSPEventReceiverType =
                (list, assemblyName, className, types) =>
                {
                    listIdsUsed.Add(list.ID);
                    return new List<SPEventReceiverDefinition>();
                };

            // Act
            SPListUtility.MapListsReporting(_spWebShim, list => validListIds.Contains(list.ID));

            // Assert
            Assert.IsTrue(listIdsUsed.SequenceEqual(validListIds));
        }

        [TestMethod]
        public void MapLists_ListsHaveEvents_ListWithEventsMapped()
        {
            // Arrange
            var listsWithEvents = new[] { _testList1ID, _testList3ID };
            ShimCoreFunctions.GetListEventsSPListStringStringIListOfSPEventReceiverType =
                (list, assemblyName, className, types) =>
                {
                    var result = new List<SPEventReceiverDefinition>();
                    if (listsWithEvents.Contains(list.ID))
                    {
                        result.Add(new ShimSPEventReceiverDefinition());
                    }
                    return result;
                };

            IList<Guid> listsUsed = null;
            ShimSPListUtility.MapListsSPWebHashSetOfGuid = (spWeb, listsToBeMapped) =>
            {
                listsUsed = listsToBeMapped.ToArray();
            };

            // Act
            SPListUtility.MapListsReporting(_spWebShim);

            // Assert
            Assert.IsTrue(listsUsed.SequenceEqual(listsWithEvents));
        }

        [TestMethod]
        public void MapLists_ListsHaveIcons_ListWithIconsGetIconsSet()
        {
            // Arrange
            ShimCoreFunctions.GetListEventsSPListStringStringIListOfSPEventReceiverType =
                (list, assemblyName, className, types) => new List<SPEventReceiverDefinition> { new ShimSPEventReceiverDefinition() };

            var listsWithIcons = new[] { _testList1ID, _testList3ID };
            ShimSPListUtility.GetListIconSPList =
                (list) =>
                {
                    if (listsWithIcons.Contains(list.ID))
                    {
                        return "icon";
                    }

                    return null;
                };

            IDictionary<string, string> listIconsUsed = null;
            ShimSPListUtility.SetListsIconsSPWebDictionaryOfStringString = (spWeb, listIconsToBeSet) =>
            {
                listIconsUsed = listIconsToBeSet;
            };

            // Act
            SPListUtility.MapListsReporting(_spWebShim);

            // Assert
            Assert.AreEqual(listsWithIcons.Length, listIconsUsed.Count);
            Assert.IsTrue(listsWithIcons.All(pred => listIconsUsed.ContainsKey(pred.ToString())));
        }
    }
}
