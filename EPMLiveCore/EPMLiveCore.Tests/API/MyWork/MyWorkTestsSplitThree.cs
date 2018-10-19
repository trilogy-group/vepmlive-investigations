using System;
using System.Collections.Generic;
using System.Data;
using System.Fakes;
using System.Linq;
using System.Reflection;
using System.Resources.Fakes;
using System.Web.Fakes;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.MyWork
{
    public partial class MyWorkRemTests
    {
        private const string GetMyWorkFieldTypeMethodName = "GetMyWorkFieldType";
        private const string GetMyWorkGridColTypeMethodName = "GetMyWorkGridColType";
        private const string GetMyWorkGridDataMethodName = "GetMyWorkGridData";
        private const string GetMyWorkGridEnumMethodName = "GetMyWorkGridEnum";
        private const string GetMyWorkGridLayoutMethodName = "GetMyWorkGridLayout";
        private const string GetMyWorkGridViewsMethodName = "GetMyWorkGridViews";
        private const string GetMyWorkListItemMethodName = "GetMyWorkListItem";
        private const string GetRelatedGridFormatMethodName = "GetRelatedGridFormat";
        private const string GetWorkingOnGridDataMethodName = "GetWorkingOnGridData";
        private const string GetWorkingOnGridLayoutMethodName = "GetWorkingOnGridLayout";
        private const string RenameMyWorkGridViewMethodName = "RenameMyWorkGridView";
        private const string UpdateMyWorkItemMethodName = "UpdateMyWorkItem";
        private const string DueDateColumn = "DueDate";
        private const string DueDayColumn = "DueDay";
        private const string AuthorColumn = "Author";
        private const string EditorColumn = "Editor";

        private void SetupShimsSplitThree()
        {
            ShimHttpUtility.HtmlDecodeString = input => input;
            ShimUtils.ToGridSafeFieldNameString = input => input;
            ShimUtils.GetConfigWeb = () => spWeb;
        }

        [TestMethod]
        public void GetMyWorkFieldType_WhenCalled_ReturnsString()
        {
            // Arrange
            const string sampleString = "sampleString";

            var myWorkField = new MyWorkField()
            {
                Name = sampleString
            };
            var fieldTypes = new Dictionary<string, SPField>()
            {
                [sampleString] = new ShimSPField().Instance
            };

            ShimUtils.GetRelatedGridTypeSPField = _ => sampleString;
            ShimUtils.GetFormatSPField = _ => sampleString;

            // Act
            var actual = (string)privateObj.Invoke(
                GetMyWorkFieldTypeMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { myWorkField, fieldTypes, string.Empty });

            // Assert
            actual.ShouldBe(sampleString);
        }

        [TestMethod]
        public void GetMyWorkGridColType_WhenCalled_ReturnsString()
        {
            // Arrange
            const string sampleString = "sampleString";

            var myWorkElement = new XElement(sampleString);
            myWorkElement.Add(new XElement("IsFromMyTimesheet", true));

            ShimMyWork.GetMyWorkElementString = _ => myWorkElement;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            fields.GetFieldByInternalNameString = _ => new ShimSPField();
            ShimUtils.GetItemListWebSiteStringXElementInt32OutGuidOutGuidOutGuidOutStringOut =
                (string data, XElement element, out int itemId, out Guid listId, out Guid webId, out Guid siteId, out string siteUrl) =>
                {
                    itemId = 1;
                    listId = guid;
                    webId = guid;
                    siteId = guid;
                    siteUrl = sampleString;
                };
            ShimFieldInfo.GetGuessOriginalFieldNameSettingXElement = _ => true;
            ShimFieldInfo.GetFieldsXElement = _ => new List<string>()
            {
                sampleString
            };
            ShimUtils.ToOriginalFieldNameString = field => sampleString;
            ShimUtils.GetRelatedGridTypeForMyTimesheetSPField = field => $"{sampleString}_Timesheet";
            ShimUtils.GetRelatedGridTypeSPField = field => sampleString;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkGridColTypeMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Element("Fields").Attribute("ListID").Value.ShouldBe(GuidString),
                () => actual.Element("MyWork").Element("Fields").Element("Field").Attribute("Name").Value.ShouldBe(sampleString),
                () => actual.Element("MyWork").Element("Fields").Element("Field").Attribute("Type").Value.ShouldBe($"{sampleString}_Timesheet"));
        }

        [TestMethod]
        public void GetMyWorkGridData_ApiException_ReturnsString()
        {
            // Arrange
            const int exceptionNumber = 100;
            const string exceptionMessage = DummyString;

            var expected = string.Format(@"<Grid><IO Result=""-{0}"" Message=""{1}"" /></Grid>", exceptionNumber, exceptionMessage);

            ShimMyWork.GetMyWorkString = input =>
            {
                throw new APIException(exceptionNumber, exceptionMessage);
            };
            ShimMyWork.GetGridSafeValueXElement = input => input.Value;

            // Act
            var actual = (string)privateObj.Invoke(
                GetMyWorkGridDataMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetMyWorkGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var documentXml = string.Format(@"
                <MyPersonalization>
                    <Personalizations>
                        <Field Key=""Flag"" Value=""flagValue""/>
                    </Personalizations>
                    <Keys>Flag</Keys>
                    <Item ID=""{0}""/>
                    <List ID=""{1}""/>
                    <Web ID=""{2}""/>
                    <Site ID=""{3}"" URL=""{4}""/>
                </MyPersonalization>",
                1, GuidString, GuidString, GuidString, "siteUrl");
            var data = string.Format(@"
                <MyWork>
                    <Params>
                        <ProcessFlag>True</ProcessFlag>
                    </Params>
                    <Item ID=""{0}"" ListID=""{1}"" WebID=""{2}"" SiteID=""{3}"" SiteURL=""{4}"" WorkingOn=""True"" Work0000Type=""WorkType"" Workspace=""Workspace"">
                        <Fields>
                            <Field Name=""flag"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""Edit"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""ItemID"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""ListID"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""WebID"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""SiteID"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""SiteURL"" Type=""Choice"">fieldValue</Field>
                            <Field Name=""MaxHeight"" Type=""Choice"">fieldValue</Field>
                        </Fields>
                    </Item>
                </MyWork>",
                1, GuidString, GuidString, GuidString, "siteUrl");

            ShimMyWork.GetMyWorkString = input => input;
            ShimMyWork.GetSettingsString =
                (string dataParam) => { };
            ShimMyPersonalization.GetMyPersonalizationString = input => documentXml;
            ShimMyWork.GetGridSafeValueXElement = input => input.Value;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkGridDataMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute("Workspace").Value.ShouldBe("Workspace"),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute("WorkingOn").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute("Edit").Value.ShouldBe(string.Empty),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute("WebID").Value.ShouldBe(GuidString),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute("MaxHeight").Value.ShouldBe("30"));
        }

        [TestMethod]
        public void GetMyWorkGridEnum_WhenCalled_ReturnsString()
        {
            // Arrange
            const string sampleString = "sampleString";

            var myWorkElement = new XElement(sampleString);
            myWorkElement.Add(new XElement("IsFromMyTimesheet", true));

            ShimMyWork.GetMyWorkElementString = _ => myWorkElement;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            fields.GetFieldByInternalNameString = _ => new ShimSPField();
            ShimUtils.GetItemListWebSiteStringXElementInt32OutGuidOutGuidOutGuidOutStringOut =
                (string data, XElement element, out int itemId, out Guid listId, out Guid webId, out Guid siteId, out string siteUrl) =>
                {
                    itemId = 1;
                    listId = guid;
                    webId = guid;
                    siteId = guid;
                    siteUrl = sampleString;
                };
            ShimFieldInfo.GetGuessOriginalFieldNameSettingXElement = _ => true;
            ShimFieldInfo.GetFieldsXElement = _ => new List<string>()
            {
                sampleString
            };
            ShimUtils.ToOriginalFieldNameString = field => sampleString;
            ShimUtils.GetGridEnumSPSiteSPFieldStringOutInt32OutStringOut = (SPSite spSite, SPField spField, out string values, out int range, out string keys) =>
            {
                values = sampleString;
                range = 10;
                keys = sampleString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkGridEnumMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Element("Fields").Attribute("ListID").Value.ShouldBe(GuidString),
                () => actual.Element("MyWork").Element("Fields").Element("Field").Attribute("Name").Value.ShouldBe(sampleString),
                () => actual.Element("MyWork").Element("Fields").Element("Field").Attribute("EnumKeys").Value.ShouldBe($"|{sampleString}"),
                () => actual.Element("MyWork").Element("Fields").Element("Field").Attribute("Range").Value.ShouldBe("10"));
        }

        [TestMethod]
        public void GetMyWorkGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            var data = @"
                <MyWork>
                    <WebPart ID=""1"" />
                    <CompleteItemsQuery>False</CompleteItemsQuery>
                </MyWork>";
            var resultXml = string.Format(@"
                <Grid>
                    <Header />
                    <LeftCols>
                        <C Name=""Complete""/>
                    </LeftCols>
                    <Cols>
                        <C Name=""ColName""/>
                        <C Name=""{0}""/>
                    </Cols>
                    <RightCols>
                        <C Name=""RightColName""/>
                    </RightCols>
                </Grid>",
                WorkingOnColumn);
            var field = new ShimSPField();
            var myFieldTypes = new Dictionary<string, SPField>()
            {
                [DueDateColumn] = field,
                [AuthorColumn] = field,
                [EditorColumn] = field
            };

            ShimUtils.GetFieldTypes = () => myFieldTypes;
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => resultXml;
            ShimExtensionMethods.ToPrettierNameStringListOfStringSPWeb = (instance, _, _1) => instance;
            ShimMyWork.ShouldUseReportingDbSPWeb = _ => false;
            ShimMyWork.GetMyWorkFieldTypeMyWorkFieldIDictionaryOfStringSPFieldStringOut = (MyWorkField myWorkField, IDictionary<string, SPField> fieldTypes, out string format) =>
            {
                format = "format";
                return "Date";
            };
            GetMyWorkParams.SelectedFields = new List<string>();

            ShimMyWork.GetRelatedGridFormatStringStringSPFieldSPWeb = (_, _1, _2, _3) => "editFormat%";
            ShimMyWork.GetSettingsString =
                (string dataParam) =>
                {
                    GetMyWorkParams.SelectedFields.Add(DueDateColumn);
                    GetMyWorkParams.SelectedFields.Add(AuthorColumn);
                    GetMyWorkParams.SelectedFields.Add(EditorColumn);
                };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkGridLayoutMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("id").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Cols").Elements().Count().ShouldBe(7),
                () => actual.Element("Grid").Element("Header").Attribute("Author").Value.ShouldBe("Created By"),
                () => actual.Element("Grid").Element("RightCols").Elements().Count().ShouldBe(0),
                () => actual.Element("Grid").Element("LeftCols").Element("C").Attribute("Tip").Value.ShouldBe("Mark Complete"),
                () => actual.Element("Grid").Element("Cols").Elements().FirstOrDefault(x => x.Attribute("Name").Value.Equals(WorkingOnColumn)).Attributes().Count(x => x.Value == "0").ShouldBe(3));
        }

        [TestMethod]
        public void GetMyWorkGridViews_WhenCalled_RetunsString()
        {
            // Arrange
            var myWorkGridViews = new List<MyWorkGridView>();
            var myPersonalGridViews = new List<MyWorkGridView>()
            {
                new MyWorkGridView
                {
                    Id = "GridViewId",
                    Name = "Default View",
                    Default = true,
                    Personal = false,
                    LeftCols = "LeftCols",
                    Cols = "cols",
                    RightCols = string.Empty,
                    Filters = "0|",
                    Grouping = "0|",
                    Sorting = "DueDate"
                }
            };

            ShimMyWork.GetGlobalViewsSPWeb = _ => myPersonalGridViews;
            ShimMyWork.GetPersonalViewsSPWeb = _ => myPersonalGridViews;
            ShimMyWork.SaveGlobalViewsMyWorkGridViewSPWeb = (_, _1) => { };
            ShimMyWork.GetLeftColsMyWorkGridView = myWorkGridView => myWorkGridView.LeftCols;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkGridViewsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Element("Views").Elements().Count(x => x.Name.LocalName.Equals("View") && x.Attribute("ID").Value.Equals("dv")).ShouldBe(1),
                () => actual.Element("MyWork").Element("Views").Elements().Count(x => x.Name.LocalName.Equals("View") && !x.Attribute("ID").Value.Equals("dv")).ShouldBe(2));
        }

        [TestMethod]
        public void GetMyWorkListItem_WhenCalled_ReturnsString()
        {
            // Arrange
            var expectedDate = DateTime.Parse("2018-09-15 19:20:00");
            var data = string.Format(@"
                <MyWork>
                    <Site ID=""{0}"" URL=""sampleURL""/>
                    <Web ID=""{0}""/>
                    <List ID=""{0}""/>
                    <Item ID=""1""/>
                    <Fields>
                        <Field Name=""FieldType"" Type=""Date"">2018-09-15 19:20:00</Field>
                    </Fields>
                </MyWork>",
                GuidString);

            ShimListItem.GetListItemString = input => input;
            ShimMyWork.GetGridSafeValueXElement = input => input.Value;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkListItemMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Elements().Count().ShouldBe(5),
                () => actual.Element("MyWork").Element("Site").Attribute("ID").Value.ShouldBe(GuidString),
                () => actual.Element("MyWork").Element("Fields").Element("Field").Value.ShouldBe(expectedDate.ToString("MM/dd/yyyy HH:mm:ss")));
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberAutomatic_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0.##########";

            var displayFormat = SPNumberFormatTypes.Automatic;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberNoDecimal_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0";

            var displayFormat = SPNumberFormatTypes.NoDecimal;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberOneDecimal_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0.0";

            var displayFormat = SPNumberFormatTypes.OneDecimal;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberTwoDecimals_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0.00";

            var displayFormat = SPNumberFormatTypes.TwoDecimals;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberThreeDecimals_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0.000";

            var displayFormat = SPNumberFormatTypes.ThreeDecimals;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberFourDecimals_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0.0000";

            var displayFormat = SPNumberFormatTypes.FourDecimals;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeNumberFiveDecimals_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string percentageSign = @"\%";
            const string expected = ",#0.00000";

            var displayFormat = SPNumberFormatTypes.FiveDecimals;
            var field = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true,
                DisplayFormatGet = () => displayFormat
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe($"{expected}{percentageSign}");
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeCurrency_ReturnsString()
        {
            // Arrange
            const string type = "Float";
            const string expected = "$##,#.00";

            var field = new ShimSPFieldCurrency()
            {
                CurrencyLocaleIdGet = () => 1033
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Currency;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetRelatedGridFormat_FieldTypeOther_ReturnsString()
        {
            // Arrange
            const string type = "Float";

            var field = new ShimSPField();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Attachments;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetRelatedGridFormat_Date_ReturnsString()
        {
            // Arrange
            const string type = "Date";
            const string format = "yyyy-MM-dd";
            const string expected = "yyyy-MM-dd h:mm tt";

            var field = new ShimSPField();

            ShimMyWork.GetExampleDateFormatSPWebStringStringString = (_, _1, _2, _3) => format;

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetRelatedGridFormat_Other_ReturnsString()
        {
            // Arrange
            const string type = "Other";

            var field = new ShimSPField();

            // Act
            var actual = (string)privateObj.Invoke(
                GetRelatedGridFormatMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { type, string.Empty, field.Instance, spWeb.Instance });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetWorkingOnGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            const string date = "2018-09-16 01:00:00";
            const string format = "yyyy/MM/dd HH:mm:ss";

            var friendlyDate = Convert.ToDateTime(date).ToString(format);
            var dataTable = new DataTable();
            dataTable.Columns.Add(DueDateColumn);
            dataTable.Columns.Add(AuthorColumn);
            var row = dataTable.NewRow();
            row[DueDateColumn] = date;
            row[AuthorColumn] = DummyString;
            dataTable.Rows.Add(row);

            var field = new ShimSPField();
            var myFieldTypes = new Dictionary<string, SPField>()
            {
                [DueDateColumn] = field,
                [AuthorColumn] = field
            };

            ShimExtensionMethods.ToFriendlyDateDateTime = instance => instance.ToString(format);
            ShimUtils.GetFieldTypes = () => myFieldTypes;
            ShimMyWork.GetWorkingOnString = _ => dataTable;
            ShimMyWork.GetGridSafeValueXElement = input => input.Value;
            ShimMyWork.BuildFieldElementIDictionaryOfStringSPFieldStringString = (_, value, name) => new XElement(name, value);

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetWorkingOnGridDataMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attributes().Count().ShouldBe(3),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute(DueDayColumn).Value.ShouldBe(friendlyDate),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute(DueDateColumn).Value.ShouldBe(date),
                () => actual.Element("Grid").Element("Body").Element("B").Element("I").Attribute(AuthorColumn).Value.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetWorkingOnGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string resultXml = "<Grid/>";

            var data = @"
                <MyWork>
                    <Params>
                        <GridId>111</GridId>
                    </Params>
                </MyWork>";
            var field = new ShimSPField();
            var myFieldTypes = new Dictionary<string, SPField>()
            {
                [DueDateColumn] = field,
                [AuthorColumn] = field,
                [EditorColumn] = field
            };

            ShimUtils.GetFieldTypes = () => myFieldTypes;
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => resultXml;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetWorkingOnGridLayoutMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("id").Value.ShouldBe("111"),
                () => actual.Element("Grid").Element("Cfg").Attribute("CSS").Value.ShouldBe(string.Format("{0}/_layouts/epmlive/treegrid/workingon/grid.css", Url)));
        }

        [TestMethod]
        public void RenameMyWorkGridView_PersonalTrue_ReturnsString()
        {
            // Arrange
            var methodCalled = false;
            var data = string.Format(@"
                <MyWork>
                    <View ID=""111"" Name=""viewName"" Personal=""{0}"" />
                </MyWork>",
                true);

            ShimMyWork.GetPersonalViewsSPWeb = _ => null;
            ShimMyWork.GetGlobalViewsSPWeb = _ => null;
            ShimMyWork.RenamePersonalViewStringStringIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2, _3) =>
            {
                methodCalled = true;
            };
            ShimMyWork.RenameGlobalViewStringStringIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2, _3) =>
            {
                methodCalled = false;
            };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                RenameMyWorkGridViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => methodCalled.ShouldBeTrue(),
                () => actual.Element("MyWork").ShouldNotBeNull());
        }

        [TestMethod]
        public void RenameMyWorkGridView_PersonalFalse_ReturnsString()
        {
            // Arrange
            var methodCalled = false;
            var data = string.Format(@"
                <MyWork>
                    <View ID=""111"" Name=""viewName"" Personal=""{0}"" />
                </MyWork>",
                false);

            ShimMyWork.GetPersonalViewsSPWeb = _ => null;
            ShimMyWork.GetGlobalViewsSPWeb = _ => null;
            ShimMyWork.RenamePersonalViewStringStringIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2, _3) =>
            {
                methodCalled = false;
            };
            ShimMyWork.RenameGlobalViewStringStringIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2, _3) =>
            {
                methodCalled = true;
            };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                RenameMyWorkGridViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => methodCalled.ShouldBeTrue(),
                () => actual.Element("MyWork").ShouldNotBeNull());
        }

        [TestMethod]
        public void UpdateMyWorkItem_WhenCalled_ReturnsString()
        {
            // Arrange
            const string sampleString = "sampleString";
            const string date = "2018-09-16 02:00:00";
            const string dueDayformat = "yyyy-MM-dd HH:mm:ss";
            const string dueDateformat = "MM/dd/yyyy HH:mm:ss";
            const string data = "<MyWorkItem/>";
            const string messageText = "MessageText";

            var fieldValues = new Dictionary<string, string>()
            {
                [ItemIdColumn] = DummyString
            };
            var friendlyDate = DateTime.Parse(date).ToString(dueDayformat);
            var dueDate = DateTime.Parse(date).ToString(dueDateformat);
            var methodCount = 0;

            ShimMyWork.GetMyWorkItemElementString = _ => null;
            ShimMyWork.GetGridSafeValueXElement = input => input.Value;
            ShimUtils.GetFieldValuesXElement = _ => fieldValues;
            ShimUtils.ToOriginalFieldNameString = field => field;
            ShimListItem.GetListItemString = input => input;
            ShimListItem.UpdateListItemString = input => input;
            ShimExtensionMethods.ToFriendlyDateDateTime = instance => instance.ToString(dueDayformat);
            ShimUtils.AddItemListWebSiteToXElementInt32GuidGuidGuidStringXElementRef = (int itemId, Guid listId, Guid webId, Guid siteId, string siteUrl, ref XElement listItemElement) =>
            {
                methodCount = methodCount + 1;
                if (methodCount == 1)
                {
                    listItemElement.Add(new XElement("Messages"));
                    listItemElement.Element("Messages").Add(new XElement("Message", messageText));
                }
                else
                {
                    listItemElement.Add(new XElement("Fields"));
                    listItemElement.Element("Fields").Add(new XElement("Field", date));
                    listItemElement.Element("Fields").Element("Field").Add(new XAttribute("Name", DueDateColumn));
                    listItemElement.Element("Fields").Element("Field").Add(new XAttribute("Type", DueDateColumn));
                }
            };
            ShimUtils.GetItemListWebSiteStringXElementInt32OutGuidOutGuidOutGuidOutStringOut =
                (string dataParam, XElement element, out int itemId, out Guid listId, out Guid webId, out Guid siteId, out string siteUrl) =>
                {
                    itemId = 111;
                    listId = guid;
                    webId = guid;
                    siteId = guid;
                    siteUrl = sampleString;
                };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                UpdateMyWorkItemMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWorkItem").Element("Messages").Element("Message").Value.ShouldBe(messageText),
                () => actual.Element("MyWorkItem").Element("Fields").Elements("Field").FirstOrDefault(x => x.Attribute("Name").Value.Equals(DueDayColumn)).Value.ShouldBe(friendlyDate),
                () => actual.Element("MyWorkItem").Element("Fields").Elements("Field").FirstOrDefault(x => x.Attribute("Name").Value.Equals(DueDateColumn)).Value.ShouldBe(dueDate));
        }
    }
}
