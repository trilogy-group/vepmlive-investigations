using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets;

namespace EPMLiveTimesheets.Tests.WebPageCode
{
    [TestClass]
    public class GetPmApprovalsTests
    {
        private IDisposable _shimContext;
        private bool _readFirstCall;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _readFirstCall = true;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void outputXml()
        {
            // Arrange
            ArrangeShims();
            var docXml = new XmlDocument();
            docXml.LoadXml(@"<root>
<head>
    <settings></settings>
    <column width='0' type='' id='Project'></column>
    <column width='0' type='' id='Boo'></column>
</head>
<rows>
    <row id='                                                                           . .'>
        <userdata name='listid'></userdata>
        <userdata name='itemid'></userdata>
        <userdata name='Work'></userdata>
    </row>
</rows>
</root>");

            var approval = new GetPmApprovals();
            SetFieldValue(approval, "docXml", docXml);
            SetFieldValue(approval, "cn", new ShimSqlConnection().Instance);
            SetFieldValue(approval, "view", new ShimSPView().Instance);

            // Act
            InvokeMethod(approval, "outputXml");
            var actual = GetFieldValue<string>(approval, "data");

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual));
        }

        private void ArrangeShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = context => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = context => new ShimSPWeb();

            ShimSPWeb.AllInstances.CurrentUserGet = web => new ShimSPUser();

            ShimSPSite.AllInstances.RootWebGet = site => new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => false.ToString();

            ShimSqlCommand.ConstructorStringSqlConnection = (a, b, c) => { };
            ShimSqlCommand.AllInstances.ParametersGet = command => new ShimSqlParameterCollection();
            ShimSqlCommand.AllInstances.ExecuteReader = command => new ShimSqlDataReader();

            ShimSqlDataReader.AllInstances.Read = reader =>
            {
                if (_readFirstCall)
                {
                    _readFirstCall = false;
                    return false;
                }
                return true;
            };
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (reader, i) => true;

            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (a, b, c) => new SqlParameter();

            var valueCollection = new NameValueCollection
            {
                ["width"] = "1"
            };
            ShimHttpRequest.AllInstances.QueryStringGet = _ => valueCollection;

            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "width=1");

            ShimSqlDataAdapter.ConstructorSqlCommand = (adapter, command) => { };
            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, set) => 0;

            ShimSPView.AllInstances.ViewFieldsGet = view => new ShimSPViewFieldCollection();
            ShimSPViewFieldCollection.AllInstances.CountGet = collection => 0;
        }

        public static void SetFieldValue(object obj, string fieldName, object fieldValue)
        {
            var fieldInfo = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo?.SetValue(obj, fieldValue);
        }

        public static T GetFieldValue<T>(object obj, string fieldName)
        {
            var fieldInfo = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            return (T)fieldInfo?.GetValue(obj);
        }

        public static void InvokeMethod(object obj, string methodName)
        {
            var dynMethod = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod?.Invoke(obj, new object[] { });

        }
    }
}