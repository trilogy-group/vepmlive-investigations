using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLive.TestFakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using TimeSheets.Fakes;

namespace EPMLiveTimesheets.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetTimesheetTest: TestClassInitializer<gettimesheet>
    {
        private const string DummyUrl = "http://dummy.url";
        private HttpContext _httpContext;
        private HttpRequest _httpRequest;
        private HttpResponse _httpResponse;
        private static readonly NameValueCollection _queryString = new NameValueCollection();

        [TestInitialize]
        public new void TestInitialize()
        {
            ShimObject = ShimsContext.Create();
            SetupShimsForSharePoint();
            TestEntity = new gettimesheet();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(gettimesheet));
            InitializeAllControls();
        }

        [TestMethod]
        public void GetParams_OnValidCall_SetPeriod()
        {
            // Arrange
            var data = new StringBuilder();
            SetupShimsForHttpRequest();
            data.Append($"List\t{DummyString}");
            data.Append($"\nView\t{DummyString}");
            data.Append($"\nFilterField\t{DummyString}");
            data.Append($"\nFilterValue\t{DummyString}");
            data.Append($"\nGridName\t{DummyString}");
            _queryString.Add("period", DummyInt.ToString());
            _queryString.Add("data", Convert.ToBase64String(Encoding.ASCII.GetBytes(data.ToString())));
            ShimSPBaseCollection.AllInstances.GetEnumerator = instance =>
            {
                if (instance.GetType() == typeof(ShimSPFieldCollection)
                    || instance.GetType() == typeof(SPFieldCollection))
                {
                    return new List<SPField>
                    {
                        new ShimSPField()
                    }.GetEnumerator();
                }
                if (instance.GetType() == typeof(ShimSPViewFieldCollection)
                    || instance.GetType() == typeof(SPViewFieldCollection))
                {
                    return new List<string>
                    {
                        DummyString
                    }.GetEnumerator();
                }
                return new List<SPForm>
                {
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_DISPLAYFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_EDITFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_NEWFORM }
                }.GetEnumerator();
            };

            // Act
            TestEntity.getParams(new ShimSPWeb());

            // Assert
            Get<int>("period").ShouldBe(DummyInt);
        }

        [TestMethod]
        public void PopulateGroups_OnValidCall_AddToSortedList()
        {
            // Arrange
            var arrGTemp = new SortedList();
            SetupShimsForHttpRequest();
            SetupShimsForSharePoint();
            SetupShimsForSqlClient();
            _queryString.Add("duser", DummyString);
            ShimSharedFunctions.canUserImpersonateStringStringSPWebStringOut = (string s, string s1, SPWeb spWeb, out string name) =>
            {
                name = DummyString;
                return true;
            };
            var firstTimeCall = true;
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, dataSet) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                }
                else
                {
                    dataTable.Rows.Add(DummyString);
                    dataTable.Rows.Add(DummyString);
                }
                dataSet.Tables.Add(dataTable);
                return DummyInt;
            };
            ShimDataRow.AllInstances.ItemGetInt32 = (_, indx) =>
            {
                if (indx.Equals(0) || indx.Equals(1))
                {
                    return Guid.NewGuid();
                }
                if (indx.Equals(2))
                {
                    return DummyInt;
                }
                return DummyString;
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => bool.TrueString;

            // Act
            TestEntity.populateGroups(DummyString, arrGTemp, new ShimSPWeb());
            var arrItems = Get<SortedList>("arrItems");

            // Assert
            arrItems.Count.ShouldBe(2);
        }

        [TestMethod]
        public void OutputXml_OnValidCall_SetData()
        {
            // Arrange, Act, Assert
            TestOutputXml(true ,true, false, true);
        }

        [TestMethod]
        public void OutputXml_OnInEditMode_SetData()
        {
            // Arrange, Act, Assert
            TestOutputXml(true, true, false, false);
        }

        [TestMethod]
        public void OutputXml_OnAllowNotesIsFalse_SetData()
        {
            // Arrange, Act, Assert
            TestOutputXml(false, false, true, false);
        }

        [TestMethod]
        public void OutputXml_OnAllowNotesIsFalseAndNodeListNotNull_SetData()
        {
            // Arrange, Act, Assert
            TestOutputXml(false, false, false, true);
        }

        [TestMethod]
        public void AddItem_OnValidCall_AddToSortedList()
        {
            // Arrange, Act, Assert
            TestAddItemWithDataRow(SPFieldType.User);
        }

        [TestMethod]
        public void AddItem_OnDifferentSPFieldType_AddToSortedList()
        {
            // Arrange, Act, Assert
            TestAddItemWithDataRow(SPFieldType.Calculated);
        }

        [TestMethod]
        public void AddItem_OnSPListItem_AddToSortedList()
        {
            // Arrange, Act, Assert
            TestAddItemWithSPListItem(SPFieldType.User);
        }

        [TestMethod]
        public void AddItem_OnSPListItemAndDifferentSPFieldType_AddToSortedList()
        {
            // Arrange, Act, Assert
            TestAddItemWithSPListItem(SPFieldType.Calculated);
        }

        private void TestAddItemWithSPListItem(SPFieldType fieldType)
        {
            // Arrange
            var arrGTemp = new SortedList();
            SetupShimsForAddItem(fieldType);

            // Act
            PrivateObject.Invoke("addItem", new ShimSPListItem().Instance, arrGTemp);

            // Assert
            arrGTemp.ShouldSatisfyAllConditions(
                () => arrGTemp.Count.ShouldBe(1),
                () =>
                {
                    var keys = arrGTemp.Keys.Cast<string>().ToList();
                    keys.ShouldNotBeNull();
                    keys.Count.ShouldBeGreaterThan(0);
                    keys[0].ShouldContain("No");
                });
        }        

        private void TestAddItemWithDataRow(SPFieldType fieldType)
        {
            // Arrange
            var arrGTemp = new SortedList();
            var dataSet = new DataSet();
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            SetupShimsForSqlClient();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("dsTSMeta", dataSet);
            PrivateObject.SetField("arrGroupFields", new[] {DummyString});
            PrivateObject.SetField("list", new ShimSPList().Instance);
            ShimDataTable.AllInstances.SelectString = (_, __) => new DataRow[] { new ShimDataRow() };
            ShimDataRow.AllInstances.ItemGetInt32 = (_, __) => DummyString;
            ShimDataRow.AllInstances.ItemGetString = (_, str) => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => fieldType;
            ShimSPViewFieldCollection.AllInstances.CountGet = _ => DummyInt;

            // Act
            PrivateObject.Invoke("addItem", new ShimDataRow().Instance, arrGTemp, new ShimSPWeb().Instance);

            // Assert
            arrGTemp.ShouldSatisfyAllConditions(
                () => arrGTemp.Count.ShouldBe(1),
                () =>
                {
                    var keys = arrGTemp.Keys.Cast<string>().ToList();
                    keys.ShouldNotBeNull();
                    keys.Count.ShouldBeGreaterThan(0);
                    keys[0].ShouldContain(DummyString);
                });
        }

        private void SetupShimsForAddItem(SPFieldType fieldType)
        {
            var dataSet = new DataSet();
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            SetupShimsForSqlClient();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("dsTSMeta", dataSet);
            PrivateObject.SetField("arrGroupFields", new[] { DummyString });
            PrivateObject.SetField("list", new ShimSPList().Instance);
            ShimDataTable.AllInstances.SelectString = (_, __) => new DataRow[] { new ShimDataRow() };
            ShimDataRow.AllInstances.ItemGetInt32 = (_, __) => DummyString;
            ShimDataRow.AllInstances.ItemGetString = (_, str) => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => fieldType;
            ShimSPViewFieldCollection.AllInstances.CountGet = _ => DummyInt;
        }

        private void TestOutputXml(bool sqlRead, bool allowNotes, bool ndListIdNull, bool inEditMode)
        {
            // Arrange
            var readCount = 0;
            var dataSet = new DataSet();
            var outputString = new StringBuilder();
            var guid = Guid.NewGuid();
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            SetupShimsForSqlClient();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("docXml", new XmlDocument());
            PrivateObject.SetField("submitted", true);
            PrivateObject.SetField("dsTSHours", dataSet);
            PrivateObject.SetField("dsTimesheetTasks", dataSet);
            PrivateObject.SetField("dsTSMeta", dataSet);
            PrivateObject.SetField("dsTSHours", dataSet);
            PrivateObject.SetField("view", new ShimSPView().Instance);
            _queryString.Add("width", "50");
            ShimXmlNode.AllInstances.SelectNodesString = (_, str) =>
            {
                if (str.Equals("cell"))
                {
                    return new StubXmlNodeList
                    {
                        CountGet = () => 1,
                        ItemInt32 = ind => new ShimXmlElement(),
                        GetEnumerator01 = () => new List<XmlNode>
                        {
                            new ShimXmlElement()
                        }.GetEnumerator()
                    };
                }

                return new StubXmlNodeList
                {
                    CountGet = () => 2,
                    ItemInt32 = ind => new ShimXmlElement(),
                    GetEnumerator01 = () => new List<XmlNode>
                    {
                        new ShimXmlElement()
                    }.GetEnumerator()
                };
            };
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, str) =>
            {
                if (str.Equals("userdata[@name='listid']"))
                {
                    return ndListIdNull ? null : new ShimXmlElement();
                }
                return new ShimXmlElement();
            };
            ShimXmlElement.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection();
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection();
            ShimXmlNode.AllInstances.AppendChildXmlNode = (_, __) => new ShimXmlElement();
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlElement();
            ShimXmlNode.AllInstances.Clone = _ => new ShimXmlAttribute();
            ShimXmlElement.AllInstances.InnerXmlSetString = (_, str) => outputString.Append(str);
            ShimXmlElement.AllInstances.InnerTextSetString = (_, str) => outputString.Append(str);
            ShimXmlElement.AllInstances.InnerTextGet = _ => DummyString;
            ShimXmlElement.AllInstances.InnerXmlGet = _ => DummyString;
            ShimXmlAttributeCollection.AllInstances.ItemOfGetString = (_, __) => new ShimXmlAttribute();
            ShimXmlAttributeCollection.AllInstances.AppendXmlAttribute = (_, __) => new ShimXmlAttribute();
            ShimXmlAttribute.AllInstances.ValueGet = _ => DummyString;
            ShimXmlAttribute.AllInstances.ValueSetString = (_, str) => outputString.Append(str);
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
            {
                if (name.Equals("EPMLiveTSAllowNotes"))
                {
                    return allowNotes.ToString();
                }

                if (name.Equals("EPMLiveTSUseCurrent"))
                {
                    return bool.FalseString;
                }

                if (name.Equals("EPMLiveDaySettings"))
                {
                    return string.Join("|", Enumerable.Repeat(bool.TrueString, 30));
                }

                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = cmd =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (cmd.CommandText.Contains("select TSTYPE_ID from TSTYPE where site_uid=@siteid"))
                        {
                            if (readCount == 0)
                            {
                                readCount++;
                                return sqlRead;
                            }
                        }

                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }
                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, indx) =>
                indx.Equals(0) ? DateTime.Now : DateTime.Now.AddDays(1);
            ShimDataTable.AllInstances.SelectString = (_, __) => new DataRow[] {new ShimDataRow()};
            ShimDataRow.AllInstances.ItemGetInt32 = (_, __) => DummyString;
            ShimDataRow.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("TS_ITEM_UID"))
                {
                    return guid;
                }
                return DummyString;
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPViewFieldCollection.AllInstances.CountGet = _ => DummyInt;

            // Act
            PrivateObject.Invoke("outputXml");
            var output = outputString.ToString();

            // Assert
            output.ShouldSatisfyAllConditions(
                () => output.ShouldContain(DummyString),
                () =>
                {
                    if (allowNotes)
                    {
                        output.ShouldContain(guid.ToString());
                    }
                },
                () =>
                {
                    if (inEditMode)
                    {
                        output.ShouldContain("background: #EFEFEF");
                    }
                });
        }

        private void SetupShimsForHttpRequest()
        {
            _queryString.Clear();
            _httpRequest = new HttpRequest(DummyString, DummyUrl, DummyString);
            _httpResponse = new HttpResponse(TextWriter.Null);
            _httpContext = new HttpContext(_httpRequest, _httpResponse);
            ShimHttpContext.CurrentGet = () => _httpContext;
            ShimPage.AllInstances.RequestGet = _ => _httpRequest;
            ShimHttpRequest.AllInstances.QueryStringGet = _ => _queryString;
        }

        private void SetupShimsForSharePoint()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.GetContextHttpContextGuidGuidSPWeb = (_, _2, _3, _4) => new ShimSPContext();
            ShimSPContext.AllInstances.ListGet = _ => new ShimSPList();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.ViewContextGet = _ => new ShimSPViewContext();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.LocaleGet = _ => new CultureInfo(1033);
            ShimSPWeb.AllInstances.LanguageGet = _ => DummyInt;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.GetListFromUrlString = (_, __) => new ShimSPList();
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimSPWeb.AllInstances.GetListString = (_, __) => new ShimSPList();
            ShimSPRegionalSettings.AllInstances.WorkDaysGet = _ => 5;
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();
            ShimSPUserCollection.AllInstances.ItemGetString = (_, __) => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = elevated => { elevated(); };
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPPersistedObject.AllInstances.NameGet = _ => DummyString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPFeature();
            ShimSPViewContext.AllInstances.ViewGet = _ => new ShimSPView();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPView.AllInstances.TitleGet = _ => DummyString;
            ShimSPView.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPView.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.DescriptionGet = _ => DummyString;
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => new ShimSPListItemCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
            ShimSPViewCollection.AllInstances.ItemGetString = (_, __) => new ShimSPView();
            ShimSPFormCollection.AllInstances.ItemGetString = (_, __) => new ShimSPForm();
            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>
            {
                new ShimSPListItem()
            }.GetEnumerator();
            ShimSPListItemCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _2, _3) => { };
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
        }

        private static void SetupShimsForSqlClient()
        {
            var readCount = 0;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }
                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.Now;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, __) => true;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.NewGuid();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
        }
    }
}
