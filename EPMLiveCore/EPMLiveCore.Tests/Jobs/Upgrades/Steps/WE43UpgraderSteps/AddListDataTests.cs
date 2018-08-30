﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [TestClass]
    public class AddListDataTests
    {
        private AddListData _testObj;
        private PrivateObject _privateObj;
        private IDisposable _shimsContext;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            var data = "data";
            var stepNumber = 1;
            var bispfe = true;
            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => Guid.Empty,
                    WebApplicationGet = () => new ShimSPWebApplication()
                    {
                        FeaturesGet = () => new ShimSPFeatureCollection()
                        {
                            ItemGetGuid = _ => null
                        }.Instance
                    }
                }.Instance
            }.Instance;

            _testObj = new AddListData(web, data, stepNumber, bispfe);
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void ProcessResources_WhenCalled_UpdatesListItem()
        {
            // Arrange
            const string mapId = "mapId";
            const string folderUrl = "folderUrl";

            var actual = false;
            var oResourcePool = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => new ShimSPField()
                },
                ItemsGet = () => new ShimSPListItemCollection()
                {
                    GetEnumerator = () => new List<SPListItem>()
                    {
                        new ShimSPListItem()
                        {
                            IDGet = () => 1
                        }
                    }.GetEnumerator()
                },
                GetItemByIdInt32 = _ => new ShimSPListItem()
                {
                    IDGet = () => 1,
                    ItemGetString = __ => mapId,
                    Update = () =>
                    {
                        actual = true;
                    }
                }
            }.Instance;
            
            // Act
            _privateObj.Invoke("ProcessResources", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            actual.ShouldBeTrue();
        }
    }
}
