using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    /// <summary>
    /// Unit test for <see cref="websettings"/> class.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class WebSettingsTest
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyUrl = "http://xyz.com";
        private const string DummyString = "DummyString";
        private const string PageLoadMethod = "Page_Load";
        private const string Button1Click = "Button1_Click";
        private bool getListsAndFields;
        private bool responseRedirected;
        private bool settingSaved;
        private bool executeReaderCalled;
        private bool readMethodSwitcher;
        private ShimSPListCollection _spListCollectionShim;
        private IList<ShimSPList> _spLists;
        private IDisposable _shimsObject;
        private websettings _testObj;
        private PrivateObject _privateObj;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new websettings();
            _privateObj = new PrivateObject(_testObj);
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
            InitializeUIControls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        [TestMethod]
        public void PageLoad_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupShim();
            
            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => getListsAndFields.ShouldBeTrue(),
                () => executeReaderCalled.ShouldBeTrue(),
                () => readMethodSwitcher.ShouldBeTrue());
        }

        [TestMethod]
        public void Button1Click_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupShim();
            var executeNonQuery = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQuery = true;
                return 1;
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = item => DummyString
            };
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                RedirectString = __ => responseRedirected = true
            };

            // Act
            _privateObj.Invoke(Button1Click, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => settingSaved.ShouldBeTrue(),
                () => responseRedirected.ShouldBeTrue(),
                () => executeNonQuery.ShouldBeTrue(),
                () => executeReaderCalled.ShouldBeFalse(),
                () => readMethodSwitcher.ShouldBeTrue());
        }

        private void InitializeUIControls()
        {
            var allFields = _testObj.GetType()
                                       .GetFields(BindingFlags.Instance |
                                                  BindingFlags.NonPublic)
                                       .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));
            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        private void SetupShim()
        {
            const int fieldsCount = 1;
            var shimSqlDataReader = new ShimSqlDataReader();
            var parameterList = new List<SqlParameter>();
            var sqlCommandCtorCommandText = string.Empty;
            readMethodSwitcher = true;
            getListsAndFields = false;
            settingSaved = false;
            _spLists = new[] {
                new ShimSPList {
                    IDGet = () => Guid.NewGuid()
                }
            };
            _spListCollectionShim = new ShimSPListCollection()
            {
                TryGetListString = _ => new ShimSPList { },
                ItemGetString = name => new ShimSPList
                {
                    ItemsGet = () =>
                    {
                        var spListItemCollection = new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                ItemGetGuid = guid => DummyString + ".MASTER",
                                FieldsGet = () =>  new ShimSPFieldCollection
                                {
                                    GetFieldByInternalNameString = internalName => new ShimSPField
                                    {
                                        IdGet = () => DummyGuid
                                    }
                                }
                            }
                        };
                        return new ShimSPListItemCollection().Bind(spListItemCollection);
                    },
                    FieldsGet = () =>
                    {
                        var list = new List<SPField>
                            {
                                new ShimSPField()
                                {
                                    HiddenGet = () => false,
                                    InternalNameGet = () => DummyString
                                }
                            };
                        return new ShimSPFieldCollection().Bind(list);
                    }
                }
            };
            _spListCollectionShim.Bind(_spLists.Select(shim => shim.Instance));
            SPWeb spWeb = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                ServerRelativeUrlGet = () => DummyUrl,
                ListsGet = () => _spListCollectionShim,
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => DummyGuid,
                    WebApplicationGet = () => new ShimSPWebApplication
                    {
                    }.Instance
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IsSiteAdminGet = () => false
                },
                PropertiesGet = () => new ShimSPPropertyBag { }.Instance
            };
            ShimSPWeb.AllInstances.PropertiesGet = (a) => new ShimSPPropertyBag { Update = () => new object { } };
            ShimStringDictionary.AllInstances.ContainsKeyString = (a, b) => true;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => spWeb
            };
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => settingSaved = true;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) =>
            {
                getListsAndFields = true;
                return "true";
            };
            ShimMyWork.GetArchivedWebsGuid = _ => new List<Guid> { DummyGuid };

            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };

            ShimMyWork.GetSpContentDbSqlConnectionSPWeb = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            shimSqlDataReader.FieldCountGet = () => fieldsCount;
            shimSqlDataReader.GetGuidInt32 = columnIndex => DummyGuid;
            shimSqlDataReader.GetStringInt32 = columnIndex => DummyString;
            shimSqlDataReader.Read = () => readMethodSwitcher = !readMethodSwitcher;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                executeReaderCalled = true;
                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }
                return shimSqlDataReader.Instance;
            };
            ShimExtensionMethods.ToPrettierNameStringStringSPWeb = (_, __, ___) => DummyString;
            ShimPage.AllInstances.IsPostBackGet = _ => false;
        }
    }
}
