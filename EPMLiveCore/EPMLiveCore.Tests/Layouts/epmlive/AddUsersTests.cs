using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM;
using ShimAddUsers = EPMLiveCore.Fakes.Shimaddusers;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass]
    public class AddUsersTests
    {
        private IDisposable _shimsObject;

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
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void InitializeUiControls(PrivateObject privateObj)
        {
            var allFields = typeof(addusers)
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .Where(field => field.FieldType.IsSubclassOf(typeof(Control)) && field.FieldType != typeof(CommentCCPeopleEditor));

            foreach (var control in allFields)
            {
                privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
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
            ShimCoreFunctions.getConfigSettingSPWebString = (_1, _2) => DummyString;
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication())
            {
                IdGet = () => Guid.Empty
            };

            ShimSPSite.AllInstances.OpenWeb = site => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = s => new ShimSPList()
                }
            };

            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void PageLoad_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            var literalControlConstructorCount = 0;
            var literalControlDisposeCount = 0;
            var linkButtonConstructorCount = 0;
            var linkButtonDisposeCount = 0;

            ShimControl.AllInstances.Dispose = component =>
            {
                if (component is LiteralControl)
                {
                    literalControlDisposeCount++;
                }

                if (component is LinkButton)
                {
                    linkButtonDisposeCount++;
                }
            };

            ShimLiteralControl.ConstructorString = (control, s) => literalControlConstructorCount++;
            ShimLinkButton.Constructor = button => linkButtonConstructorCount++;

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

            ShimAddUsers.AllInstances.GetViewListSPList = (_, __) => new addusers.ViewList("ViewListString", "DefaultView");
            ShimAddUsers.AllInstances.GetGridUrlString = (_, input) => input;

            SetupShims();

            using (var testObject = new addusers())
            {
                var privateObject = new PrivateObject(testObject);
                InitializeUiControls(privateObject);

                // Act
                privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);
            }

            // Assert
            this.ShouldSatisfyAllConditions(
                () => literalControlConstructorCount.ShouldBe(2),
                () => literalControlDisposeCount.ShouldBe(2),
                () => linkButtonConstructorCount.ShouldBe(1),
                () => linkButtonDisposeCount.ShouldBe(1));
        }
    }
}
