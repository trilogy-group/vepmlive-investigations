using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Layouts.epmlive.Integration;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive.Integration
{
    [TestClass]
    public class ManageTests
    {
        private IDisposable _shimsObject;
        private Manage _testObj;
        private PrivateObject _privateObj;
        private PrivateObject _privateUnsecuredPageObject;

        private const int DummyIntOne = 1;
        private const string DummyUrl = "http://xyz.com";
        private const string DummyString = "DummyString";
        private const string PageLoadMethod = "Page_Load";
        private const string ListId = "List_Id";
        private const string Title = "Title";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new Manage();
            _privateObj = new PrivateObject(_testObj);

            InitializeUiControls();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void InitializeUiControls()
        {
            var allFields = _testObj.GetType()
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .Where(field => field.FieldType.IsSubclassOf(typeof(Control)) && field.FieldType != typeof(CommentCCPeopleEditor));

            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => new ShimSPSite
                {
                    MakeFullUrlString = _ => DummyUrl
                },
                WebGet = () => new ShimSPWeb
                {
                    ServerRelativeUrlGet = () => DummyUrl,
                    UrlGet = () => DummyUrl,
                    CurrentUserGet = () => new ShimSPUser
                    {
                        IDGet = () => DummyIntOne
                    }
                }
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ParamsGet = () => new NameValueCollection
                {
                    ["listId"] = Guid.NewGuid().ToString(),
                    ["itemid"] = DummyIntOne.ToString()
                }
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyIntOne,
                    NameGet = () => DummyString,
                    EmailGet = () => DummyString
                },
                ListsGet = () =>
                {
                    var list = new List<SPList>
                    {
                        new ShimSPList
                        {
                            EventReceiversGet = () =>
                            {
                                var eventList = new List<SPEventReceiverDefinition>
                                {
                                    new ShimSPEventReceiverDefinition()
                                };
                                return new ShimSPEventReceiverDefinitionCollection().Bind(eventList);
                            }
                        }
                    };
                    return new ShimSPListCollection().Bind(list);
                },
                SiteUserInfoListGet = () => new ShimSPList
                {
                    GetItemByIdInt32 = __ => new ShimSPListItem
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = ___ => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid()
                            }
                        },
                        ItemGetGuid = guid => DummyString
                    }
                }
            };

            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlReferrerGet = () => new Uri(DummyUrl)
                }
            };

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, __, ___) => { };

            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue
            {
                LookupIdGet = () => DummyIntOne
            };

            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyIntOne;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => { };
            ShimSPQuery.Constructor = _ => { };
            ShimSqlConnection.ConstructorString = (_, __) => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;

            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication())
            {
                IdGet = () => Guid.Empty
            };

            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void PageLoad_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            var sqlConnectionConstructorCount = 0;
            var sqlConnectionDisposeCount = 0;
            var sqlCommandConstructorCount = 0;
            var sqlCommandDisposeCount = 0;
            var sqlDataAdapterConstructorCount = 0;
            var sqlDataAdapterDisposeCount = 0;
            ShimSqlConnection.ConstructorString = (instance, _string) => sqlConnectionConstructorCount++;
            ShimSqlConnection.AllInstances.Open = connection => { };
            ShimSqlCommand.ConstructorStringSqlConnection = (_1, _2, _3) => sqlCommandConstructorCount++;
            ShimSqlDataAdapter.ConstructorSqlCommand = (adapter, command) => sqlDataAdapterConstructorCount++;
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlCommand)
                {
                    sqlCommandDisposeCount++;
                }

                if (component is SqlConnection)
                {
                    sqlConnectionDisposeCount++;
                }

                if (component is SqlDataAdapter)
                {
                    sqlDataAdapterDisposeCount++;
                }
            };

            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection();
            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (_1, str, value) => null;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;
            ShimSqlDataReader.AllInstances.Read = reader => false;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_1, _2, _3) => true;
            var dataTable = new DataTable();
            dataTable.Columns.Add(ListId);
            dataTable.Columns.Add(Title);
            ShimGridView.AllInstances.DataBind = view => { };
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(dataTable);
                return 0;
            };

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlConnectionConstructorCount.ShouldBe(1),
                () => sqlConnectionDisposeCount.ShouldBe(1),
                () => sqlCommandConstructorCount.ShouldBe(1),
                () => sqlCommandDisposeCount.ShouldBe(1),
                () => sqlDataAdapterConstructorCount.ShouldBe(1),
                () => sqlDataAdapterDisposeCount.ShouldBe(1));
        }
    }
}
