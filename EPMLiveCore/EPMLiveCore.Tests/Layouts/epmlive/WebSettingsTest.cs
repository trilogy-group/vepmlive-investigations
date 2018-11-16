using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.Administration.Fakes;

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
        private const string DummyIntAsString = "1";
        private const string Web = "_web";
        private const string PageLoadMethod = "Page_Load";
        private const string BtnResetOnClick = "btnReset_OnClick";
        private const string BtnSaveOnClick = "btnSave_OnClick";
        private const string BtnRefreshFieldOnClick = "btnRefreshField_OnClick";
        private const string EPMLiveMyWorkGeneralSettingsWorkDayFilters = "EPMLive_MyWork_GeneralSettings_WorkDayFilters";
        private const string EPMLiveMyWorkGeneralSettingsNewItemIndicator = "EPMLive_MyWork_GeneralSettings_NewItemIndicator";
        private const string KeyVal = "key:val";
        private const string KeyVal4 = "key:val|key1:val1|key2:val2|key3:val3";
        private const string TrimString = " ";
        private bool getListsAndFields;
        private bool adminPanelVisible;
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
                () => adminPanelVisible.ShouldBeTrue(),
                () => settingSaved.ShouldBeTrue(),
                () => executeReaderCalled.ShouldBeTrue(),
                () => readMethodSwitcher.ShouldBeFalse());
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
                    WebApplicationGet = () => new ShimSPWebApplication {
                    }
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IsSiteAdminGet = () => false
                },
                PropertiesGet = () => new ShimSPPropertyBag {
                    
                }
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => spWeb
            };
            ShimCoreFunctions.getLockedWebSPWeb = a =>
            {
                adminPanelVisible = true;
                return DummyGuid;
            };
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => settingSaved = true;
            ShimExtensionMethods.DecompressString = _ => KeyVal;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) =>
            {
                getListsAndFields = true;
                return KeyVal4;
            };
            ShimMyWork.GetArchivedWebsGuid = _ => new List<Guid> { DummyGuid };
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
