using System;
using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
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
        private string[] _rollupLists;

        [TestMethod]
        public void PageLoad_DocIcon_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("DocIcon");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"60\" id=\"&lt;![CDATA[DocIcon]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_WorkspaceUrl_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("WorkspaceUrl");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"60\" id=\"&lt;![CDATA[WorkspaceUrl]]&gt;\" sort=\"str\" align=\"center\"><![CDATA[<div style=\"width:100%; text-align:center;padding-right:4px\"></div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Edit_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("Edit");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"60\" id=\"&lt;![CDATA[Edit]]&gt;\" sort=\"str\" align=\"center\"><![CDATA[<div style=\"width:100%; text-align:center;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Wbs_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("WBS");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[WBS]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_List_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("List");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[List]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Title_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("Title");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"tree\" width=\"376\" id=\"&lt;![CDATA[Title]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_FileLeafRef_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("FileLeafRef");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"tree\" width=\"376\" id=\"&lt;![CDATA[FileLeafRef]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Url_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("URL");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"tree\" width=\"376\" id=\"&lt;![CDATA[URL]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_TotalRollup_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("TotalRollup");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[TotalRollup]]&gt;\" sort=\"str\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_ContentTypeDisabled_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad("ContentType");
            ShimSPList.AllInstances.ContentTypesEnabledGet = _ => false;

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[ContentType]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_ContentTypeEnabled_LoadsXml()
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
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[ContentType]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Note_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Note);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root RichText=\"FALSE\"></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"txt\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_CalculatedIndicator_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"center\"><![CDATA[<div style=\"width:100%; text-align:center;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_CalculatedDateTime_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='DateTime'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"date\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_CalculatedText_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><type ResultType='Text'></type></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_CalculatedCurrency_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='Currency'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"int\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_CalculatedNumber_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='Number'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"int\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_CalculatedOther_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<type ResultType='Other'></type>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_DateTime_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.DateTime);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Format='Format'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"dhxCalendarA\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"date\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_NumberPercentage_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Number);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Percentage=\"TRUE\" Decimals='1'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"edn\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"int\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_NumberNonPercentage_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Number);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Decimals='1'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"edn\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"int\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Currency_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Currency);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<result Decimals='2'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"edn\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"int\" align=\"right\"><![CDATA[<div style=\"width:100%; text-align:right;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Attachments_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Attachments);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_User_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.User);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            AddUsersAndGroups();

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"usereditor\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Boolean_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Boolean);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ch\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"center\"><![CDATA[<div style=\"width:100%; text-align:center;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Choice_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Choice);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>Choice</CHOICE></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"choice\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_MultiChoice_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.MultiChoice);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>MultiChoice</CHOICE></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"mchoice\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Lookup_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Lookup);
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<result List='{Guid.NewGuid().ToString()}' ShowField='field'></result>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_LookupMulti_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Lookup);
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<result List='{Guid.NewGuid().ToString()}' ShowField='field'></result>";
            ShimSPField.AllInstances.TypeAsStringGet = _ => "LookupMulti";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_Text_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ed\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_FilteredLookup_LoadsXml()
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
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ro\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_ItemNodesAvg_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();
            SetAggregationDef("AVG");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ed\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_ItemNodesStdev_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();
            SetAggregationDef("STDEV");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ed\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_ItemNodesCount_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Text);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><result></result></root>";
            SetItemNodes();
            SetAggregationDef("COUNT");

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"ed\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        [TestMethod]
        public void PageLoad_ItemNodesNoAggregation_LoadsXml()
        {
            // Arrange
            PrepareForPageLoad(Other, SPFieldType.Lookup);
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<result List='{Guid.NewGuid().ToString()}' ShowField='field'></result>";
            SetItemNodes();

            var listId = Guid.NewGuid();
            FillParams(listId);
            FillSpList(listId);

            // Act
            _privateObj.Invoke(MethodPageLoad, new object[] { _testObj, EventArgs.Empty });

            // Assert
            var result = GetResultData();
            result.ShouldNotBeNull();
            result.ShouldContain("<column type=\"choice\" width=\"157.5\" id=\"&lt;![CDATA[Other]]&gt;\" sort=\"str\" align=\"left\"><![CDATA[<div style=\"width:100%; text-align:left;padding-right:4px\">Dummy</div>]]></column>");
        }

        private static void FillSpList(Guid listId)
        {
            ShimSPList.AllInstances.FieldsGet = list =>
            {
                var fields = new List<SPFieldLookup>
                {
                    new ShimSPFieldLookup
                    {
                        LookupListGet = () => listId.ToString()
                    }.Instance
                };
                var fieldCollection = new ShimSPFieldCollection();
                fieldCollection.Bind(fields);
                return fieldCollection.Instance;
            };

            var items = new List<SPListItem>
            {
                new ShimSPListItem().Instance
            };
            var itemCollection = new ShimSPListItemCollection();
            itemCollection.Bind(items);
            ShimSPList.AllInstances.ItemsGet = _ => itemCollection.Instance;
        }

        private void FillParams(Guid listId)
        {
            _privateObj.SetField("DifferentGroups", "User,Admin");
            _privateObj.SetField("ReportID", "1");
            _privateObj.SetField("filterfield", string.Empty);
            _privateObj.SetField("LookupFilterField", DummyFieldName);
            _privateObj.SetField("lookupFilterField", DummyFieldName);
            _privateObj.SetField("lookupFilterFieldList", "1,2");
            _privateObj.SetField("sSearchType", "2");
            _privateObj.SetField("sSearchField", DummyFieldName);
            _privateObj.SetField("sSearchValue", DummyVal);
            CreateSqlConnection(listId);
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

        private void CreateSqlConnection(Guid listId)
        {
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                GetStringInt32 = x => "1",
                GetGuidInt32 = x => listId,
                Close = () => { }
            };
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

            SetupResponse();
            SetupData();

            ShimGridGanttSettings.ConstructorSPList = (_, __) => { };
            var sets = new GridGanttSettings(new ShimSPList());
            var privateSets = new PrivateObject(sets);
            privateSets.SetField("TotalSettings", string.Empty);
            ShimListCommands.GetGridGanttSettingsSPList = _ => sets;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyText;

            _rollupLists = new string[] { DummyVal };

            PrepareSPContext();

            GetParameters();
            Shimgetgriditems.AllInstances.addItemSPListItemString = (a, b, c) => { };
            Shimgetgriditems.AllInstances.addItemDataRow = (_, __) => { };

            PrepareSpFieldRelatedShims(internalName, fieldType);
            ShimSPView.AllInstances.QueryGet = _ => "<GroupBy><By Name='Title' Ascending='true'></By></GroupBy>";
        }

        private static void SetupData()
        {
            var columns = new string[]
            {
                DummyFieldName, "User", "UserText", "Admin", "AdminText", "WebID", "ListID", "ID"
            };
            var row = new object[]
            {
                DummyVal, DummyVal, DummyVal, DummyVal, DummyVal, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(columns.Select(x => new DataColumn(x)).ToArray());
            dataTable.LoadDataRow(row, true);

            ShimEPMData.SAccountInfoGuidGuid = (_, __) => dataTable.NewRow();
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => dataTable;
        }

        private void SetupResponse()
        {
            _responseWriter = new StringWriter();
            _response = new HttpResponse(_responseWriter);
            ShimPage.AllInstances.RequestGet = _ => new HttpRequest(string.Empty, ExampleUrl, string.Empty);
            ShimPage.AllInstances.ResponseGet = _ => _response;
            ShimPage.AllInstances.SessionGet = _ => new ShimHttpSessionState()
            {
                ItemSetStringObject = (x, y) => { }
            };
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
        }

        private void PrepareSPContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();

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
                _privateObj.SetField("rolluplists", _rollupLists);
                _privateObj.SetField("inEditMode", true);
                _privateObj.SetField("showCheckboxes", true);
                _privateObj.SetField("isTimesheet", false);
                _privateObj.SetField("bUseReporting", true);
                _privateObj.SetField("additionalgroups", "|");
                _privateObj.SetField("executive", "on");
            };
        }

        private string GetResultData()
        {
            var data = _privateObj.GetField("data") as string;

            var i = data.LastIndexOf("<column ");
            data = data.Substring(i);

            return data;
        }
    }
}
