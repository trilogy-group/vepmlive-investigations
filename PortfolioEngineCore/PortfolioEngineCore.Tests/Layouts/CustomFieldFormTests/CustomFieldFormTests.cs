using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Fakes;
using WorkEnginePPM.Layouts.ppm;

namespace PortfolioEngineCore.Tests.Layouts
{
    [TestClass]
    public partial class CustomFieldFormTests
    {
        private const string UpdatecustomfieldMethod = "UpdateCustomField";
        private IDisposable _shimContext;
        private bool _readFirstCall;
        private PrivateObject _privateObject;
        private AdoShims _shimAdoNetCalls;
        private NameValueCollection _valueCollection;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _shimAdoNetCalls = AdoShims.ShimAdoNetCalls();

            _privateObject = new PrivateObject(typeof(CustomFieldForm));
            _readFirstCall = true;

            ArrangeShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        private void ArrangeShims()
        {
            ShimSqlDataReader.AllInstances.Read = reader =>
            {
                if (_readFirstCall)
                {
                    _readFirstCall = false;
                    return true;
                }
                return false;
            };
            ShimSqlDataReader.AllInstances.Close = reader => { _readFirstCall = true; };
            ShimDbDataReader.AllInstances.Dispose = reader => { _readFirstCall = true; };

            ShimSqlDb.ReadIntValueObject = o => 1;
            ShimSqlDb.ReadStringValueObject = o => "string";
            ShimSqlDb.ReadDoubleValueObject = o => 1.0;

            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = (SqlDb a, string b, StatusEnum c, out DataTable table) =>
            {
                table = new ShimDataTable().Instance;
                return StatusEnum.rsSuccess;
            };

            ShimDataTable.AllInstances.ColumnsGet = _ => new ShimDataColumnCollection();

            ShimInternalDataCollectionBase.AllInstances.GetEnumerator = _ =>
            {
                var list = new List<DataColumn>
                {
                    new ShimDataColumn().Instance
                };
                return list.GetEnumerator();
            };

            ShimDataColumn.AllInstances.ColumnNameGet = _ => "RC_001";

            _valueCollection = new NameValueCollection
            {
                ["id"] = string.Empty,
                ["mode"] = string.Empty
            };
            ShimHttpRequest.AllInstances.QueryStringGet = _ => _valueCollection;

            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", string.Empty);
            ShimPage.AllInstances.ClientScriptGet = _ => new ShimClientScriptManager();

            ShimClientScriptManager.AllInstances.RegisterStartupScriptTypeStringStringBoolean = (a, b, c, d, e) => { };

            ShimWebAdmin.GetBasePath = () => string.Empty;
            ShimWebAdmin.GetConnectionString = () => string.Empty;

            ShimDBAccess.ConstructorString = (a, b) => { };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimDataRow();
        }
    }
}
