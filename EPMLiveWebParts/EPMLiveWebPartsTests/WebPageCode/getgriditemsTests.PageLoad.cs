using System;
using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class getgriditemsTests
    {
        private const string Other = "Other";
        private const string MethodPageLoad = "Page_Load";

        [TestMethod]
        public void PageLoad_DocIcon_()
        {
            // Arrange
            PrepareForPageLoad("DocIcon");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_WorkspaceUrl_()
        {
            // Arrange
            PrepareForPageLoad("WorkspaceUrl");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Edit_()
        {
            // Arrange
            PrepareForPageLoad("Edit");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Wbs_()
        {
            // Arrange
            PrepareForPageLoad("WBS");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_List_()
        {
            // Arrange
            PrepareForPageLoad("List");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Title_()
        {
            // Arrange
            PrepareForPageLoad("Title");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_FileLeafRef_()
        {
            // Arrange
            PrepareForPageLoad("FileLeafRef");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Url_()
        {
            // Arrange
            PrepareForPageLoad("URL");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_TotalRollup_()
        {
            // Arrange
            PrepareForPageLoad("TotalRollup");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_ContentTypeDisabled_()
        {
            // Arrange
            PrepareForPageLoad("ContentType");
            ShimSPList.AllInstances.ContentTypesEnabledGet = _ => false;

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_ContentTypeEnabled_()
        {
            // Arrange
            PrepareForPageLoad("ContentType");
            ShimSPList.AllInstances.ContentTypesEnabledGet = _ => true;
            ShimSPList.AllInstances.ContentTypesGet = _ => new ShimSPContentTypeCollection();
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPContentType>
            {
                new ShimSPContentType
                {
                    HiddenGet = () => false,
                    ParentGet = () => new ShimSPContentType(),
                    NameGet = () => DummyText
                }
            }.GetEnumerator();
            

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Note_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Note);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root RichText=\"FALSE\"></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_CalculatedIndicator_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_CalculatedDateTime_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='DateTime'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_CalculatedText_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><type ResultType='Text'></type></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_CalculatedCurrency_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='Currency'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_CalculatedNumber_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='Number'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_CalculatedOther_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='Other'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_DateTime_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.DateTime);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Format='Format'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_NumberPercentage_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Number);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Percentage=\"TRUE\" Decimals='1'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_NumberNonPercentage_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Number);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Decimals='1'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Currency_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Currency);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Decimals='2'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Attachments_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Attachments);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_User_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.User);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            AddUsersAndGroups();

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Boolean_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Boolean);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Choice_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Choice);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>Choice</CHOICE></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_MultiChoice_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.MultiChoice);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>MultiChoice</CHOICE></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Lookup_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Lookup);
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<result List='{Guid.NewGuid().ToString()}' ShowField='field'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_LookupMulti_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Lookup);
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<result List='{Guid.NewGuid().ToString()}' ShowField='field'></result>";
            ShimSPField.AllInstances.TypeAsStringGet = _ => "LookupMulti";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_Text_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_FilteredLookup_()
        {
            // Arrange
            PrepareForPageLoad(Other, new SPFieldType());
            ShimSPField.AllInstances.SchemaXmlGet = _ => $@"
                <result List='{Guid.NewGuid().ToString()}'
                    ShowField='{Guid.NewGuid().ToString()}'
                    WebId='{Guid.NewGuid().ToString()}'>
                    <Customization>
                        <ArrayOfProperty>
                            <Property Name='QueryFilterAsString'><Value>X</Value></p>
                            <Property Name='ListViewFilter'><Value>{Guid.NewGuid().ToString()}</Value></p>
                            <Property Name='SupportsMultipleValues'><Value>true</Value></p>
                            <Property Name='IsFilterRecursive'><Value>true</Value></p>
                        </ArrayOfProperty>
                    </Customization>
                </result>";
            ShimSPField.AllInstances.TypeAsStringGet = _ => "FilteredLookup";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_ItemNodesAvg_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();
            SetAggregationDef("AVG");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_ItemNodesStdev_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();
            SetAggregationDef("STDEV");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_ItemNodesCount_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();
            SetAggregationDef("COUNT");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        [TestMethod]
        public void PageLoad_ItemNodesNoAggregation_()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
        }

        private void SetItemNodes()
        {
            var document = new XmlDocument();
            var node = document.CreateNode(XmlNodeType.Element, "root", document.NamespaceURI);
            node.InnerXml = "<cell id='Title'></cell>";
            _privateObj.SetField("hshItemNodes", new Hashtable
            {
                {
                    DummyText,
                    node
                }
            });

            ShimCoreFunctions.setConfigSettingSPWebStringString = (a, b, c) => { };
        }

        private void SetAggregationDef(string value)
        {
            var arrAggregationDef = new SortedList();
            arrAggregationDef.Add("Title", value);
            _privateObj.SetField("arrAggregationDef", arrAggregationDef);

            var arrAggregationVals = new SortedList();
            arrAggregationVals.Add($"{DummyText}\nTitle", ",1,2");
            _privateObj.SetField("arrAggregationVals", arrAggregationVals);
        }

        private void AddUsersAndGroups()
        {
            var userCollection = new ShimSPUserCollection();
            userCollection.Bind(new List<SPUser>
            {
                new ShimSPUser
                {
                    NameGet = () => DummyText
                }
            });

            var groupCollection = new ShimSPGroupCollection();
            groupCollection.Bind(new List<SPGroup>
            {
                new ShimSPGroup
                {
                    CanCurrentUserViewMembershipGet = () => true,
                    IDGet = () => 1,
                    UsersGet = () => userCollection.Instance
                }
            });
            ShimSPWeb.AllInstances.GroupsGet = _ => groupCollection.Instance;
            ShimSPWeb.AllInstances.UsersGet = _ => userCollection.Instance;
        }

        private void PrepareForPageLoad(string internalName, SPFieldType fieldType = SPFieldType.Text)
        {
            _privateObj.SetField("view", new ShimSPView().Instance);
            _privateObj.SetField("list", new ShimSPList().Instance);
            _privateObj.SetFieldOrProperty("StartDateField", "StartDateField");
            _privateObj.SetFieldOrProperty("DueDateField", "DueDateField");
            _privateObj.SetFieldOrProperty("ProgressField", "ProgressField");

            _responseWriter = new StringWriter();
            _response = new HttpResponse(_responseWriter);
            ShimPage.AllInstances.RequestGet = _ => new HttpRequest(string.Empty, ExampleUrl, string.Empty);
            ShimPage.AllInstances.ResponseGet = _ => _response;
            ShimHttpRequest.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "epmdebug":
                        return bool.TrueString;
                    default:
                        return DummyVal;
                }
            };
            ShimHttpResponse.AllInstances.ExpiresSetInt32 = (_, __) => { };
            var row = new DataTable().NewRow();
            ShimEPMData.SAccountInfoGuidGuid = (_, __) => row;

            ShimGridGanttSettings.ConstructorSPList = (_, __) => { };
            var sets = new GridGanttSettings(new ShimSPList());
            var privateSets = new PrivateObject(sets);
            privateSets.SetField("TotalSettings", string.Empty);
            ShimListCommands.GetGridGanttSettingsSPList = _ => sets;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyText;

            PrepareSPContext();
            GetParameters();
            PrepareSpFieldRelatedShims(internalName, fieldType);
        }

        private void PrepareSPContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            PrepareSpWebRelatedShims();
            PrepareSpListRelatedShims();

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPSite.AllInstances.CatchAccessDeniedExceptionSetBoolean = (_, __) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb().Instance;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb().Instance;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => new ShimSPWeb().Instance;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb().Instance;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPView.AllInstances.QueryGet = _ => "<Child></Child>";
            ShimSPView.AllInstances.AggregationsStatusGet = _ => "Off";

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code?.Invoke();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
        }

        private void GetParameters()
        {
            Shimgetgriditems.AllInstances.getParamsSPWeb = (_, __) =>
            {
                var aViewFields = new ArrayList
                {
                    "Gantt", string.Empty
                };
                var arrColumns = new ArrayList
                {
                    "Title", string.Empty
                };
                var hshLists = new Hashtable { { DummyListId, DummyText } };
                var hshColumnSelectFilter = new Hashtable { { DummyListId, DummyText } };

                _privateObj.SetField("aViewFields", aViewFields);
                _privateObj.SetField("arrColumns", arrColumns);
                _privateObj.SetField("aHiddenViewFields", new ArrayList());
                _privateObj.SetField("hshLists", hshLists);
                _privateObj.SetField("rolluplists", new string[] { DummyVal });
                _privateObj.SetField("inEditMode", true);
                _privateObj.SetField("showCheckboxes", true);
                _privateObj.SetField("isTimesheet", false);
                _privateObj.SetField("bUseReporting", true);
                _privateObj.SetField("additionalgroups", "|");
                _privateObj.SetField("executive", "on");
            };
        }
    }
}
