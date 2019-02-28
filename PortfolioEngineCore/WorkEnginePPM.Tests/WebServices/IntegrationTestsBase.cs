using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Xml.Linq;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkEnginePPM.Tests.WebServices
{
    public abstract class IntegrationTestsBase
    {
        private const string SpSiteGuid = "47513485164794582456987451248763";
        private const string SpWebGuid = "21457943652817649520145730698410";

        private IDisposable _context;
        private Integration _integration;
        protected string Result { get; set; }
        protected XDocument XmlDocument { get; set; }
        protected PrivateObject PrivateObject { get; set; }
        protected bool DataSetReadCalled { get; set; }

        [TestInitialize]
        public virtual void Setup()
        {
            _context = ShimsContext.Create();
            _integration = new Integration();
            PrivateObject = new PrivateObject(_integration);
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
        }

        [TestCleanup]
        public virtual void TearDown()
        {
            _context?.Dispose();
        }

        protected void ArrangeDataTable()
        {
            DataSetReadCalled = false;
            ShimDataSet.AllInstances.ReadXmlTextReaderXmlReadMode = (_1, _2, readMode) =>
            {
                DataSetReadCalled = true;
                return readMode;
            };
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection();
            ShimDataTableCollection.AllInstances.ItemGetInt32 = (_1, _2) => new ShimDataTable();
            ShimDataTable.AllInstances.DefaultViewGet = _ => new ShimDataView();
            ShimDataView.AllInstances.TableGet = _ => new ShimDataTable();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimDataRowCollection.AllInstances.GetEnumerator = _ => new List<DataRow>()
            {
                new ShimDataRow()
            }.GetEnumerator();
        }

        protected void ArrangeSPWeb()
        {
            ShimSPWeb.AllInstances.IDGet = _ => new Guid(SpWebGuid);
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
        }

        protected void ArrangeSPSite()
        {
            ShimSPSite.AllInstances.IDGet = _ => new Guid(SpSiteGuid);
            ShimSPSite.ConstructorGuid = (_1, _2) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_1, _2) => new ShimSPWeb();
        }

        protected void ArrangeSPContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
        }
    }
}