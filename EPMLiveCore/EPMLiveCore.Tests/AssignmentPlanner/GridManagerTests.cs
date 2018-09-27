using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Resources.Fakes;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.AssignmentPlanner;
using EPMLiveCore.AssignmentPlanner.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EPMLiveCore.Tests.AssignmentPlanner
{
    [TestClass, ExcludeFromCodeCoverage]    
    public class GridManagerTests
    {
        private GridManager testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private Guid guid;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPList spList;
        private ShimSPListItem spListItem;
        private ShimSPListCollection spListCollection;
        private const int DummyNumber = 111;
        private const string DummyString = "DummyString";
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string DateColumn = "Date";
        private const string HoursColumn = "Hours";
        private const string DeleteViewsMethodName = "DeleteViews";
        private const string GetModelMethodName = "GetModel";
        private const string LoadModelsMethodName = "LoadModels";
        private const string LoadViewsMethodName = "LoadViews";
        private const string SaveModelsMethodName = "SaveModels";
        private const string SaveViewsMethodName = "SaveViews";
        private const string UpdateViewsMethodName = "UpdateViews";
        private const string ConfigureColumnsMethodName = "ConfigureColumns";
        private const string ConfigureDefaultColumnsMethodName = "ConfigureDefaultColumns";
        private const string GetGanttExcludeMethodName = "GetGanttExclude";
        private const string RegisterGridIdAndCssMethodName = "RegisterGridIdAndCss";
        private const string ValidateMyWorkDataResponseMethodName = "ValidateMyWorkDataResponse";
        private const string GetLayoutMethodName = "GetLayout";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new GridManager(spWeb);
            privateObject = new PrivateObject(testObject);
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimCoreFunctions.getConfigSettingSPWebString = (_, key) =>
            {
                var result = string.Empty;
                switch (key)
                {
                    case "EPMLive_MyWork_GeneralSettings_LunchStartHour":
                        result = "14";
                        break;
                    case "EPMLive_MyWork_GeneralSettings_LunchEndHour":
                        result = "15";
                        break;
                    default:
                        break;
                }
                return result;
            };
            ShimGridViewManagerFactory.Constructor = _ => new ShimGridViewManagerFactory();
            ShimUtils.GetConfigWebSPWebGuid = (_, __) => spWeb;
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
        }

        private void SetupVariables()
        {
            guid = new Guid(GuidString);
            spList = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection(),
                ItemsGet = () => new ShimSPListItemCollection()
            };
            spListItem = new ShimSPListItem()
            {
                IDGet = () => DummyNumber,
                UniqueIdGet = () => guid
            };
            spListCollection = new ShimSPListCollection()
            {
                ItemGetString = _ => spList
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid
            };
            spWeb = new ShimSPWeb()
            {
                ListsGet = () => spListCollection,
                UrlGet = () => DummyString,
                SiteGet = () => spSite,
                CurrentUserGet = () => new ShimSPUser()
                {
                    RegionalSettingsGet = () => null
                }
            };
        }

        [TestMethod]
        public void DeleteViews_WhenCalled_Deletes()
        {
            // Arrange
            const string expected = "<AssignmentPlannerViews/>";
            const string data = @"
                <xmlcfg>
                    <View Id=""1"">View1</View>
                    <View Id=""2"">View2</View>
                </xmlcfg>";

            var validationCount = 0;
            var mockObject = new Mock<IGridViewManager>();

            mockObject
                .Setup(x => x.Remove(It.IsAny<GridView>()))
                .Callback(() =>
                {
                    validationCount = validationCount + 1;
                });

            ShimGridViewManagerFactory.AllInstances.MakeGridViewManagerStringGridView = (_, _1, _2) => mockObject.Object;

            // Act
            var actual = (string)privateObject.Invoke(
                DeleteViewsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { data });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validationCount.ShouldBe(2));
        }

        [TestMethod]
        public void GetModel_WhenCalled_ReturnsString()
        {
            // Arrange
            const string fileName = "fileName";
            const string extension = ".xml";

            var data = string.Format(@"
                <model Name=""{0}""/>
                ", fileName);
            var byteArray = new byte[] { 1, 2, 3 };
            var file = new ShimSPFile()
            {
                NameGet = () => $"{fileName}{extension}",
                ItemGet = () => spListItem,
                OpenBinary = () => byteArray
            }.Instance;

            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary();
            spListItem.FileGet = () => file;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => spListItem;
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder()
            {
                FilesGet = () => new ShimSPFileCollection()
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPFile>()
            {
                file
            }.GetEnumerator();

            // Act
            var actual = Encoding.Default.GetBytes((string)privateObject.Invoke(
                GetModelMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count().ShouldBe(3),
                () => actual[0].ShouldBe<byte>(1),
                () => actual[1].ShouldBe<byte>(2),
                () => actual[2].ShouldBe<byte>(3));
        }

        [TestMethod]
        public void LoadModels_WhenCalled_ReturnsString()
        {
            // Arrange
            const string fileName = "fileName";
            const string extension = ".xml";

            var file = new ShimSPFile()
            {
                NameGet = () => $"C:\\{fileName}{extension}",
                ItemGet = () => spListItem,
                UrlGet = () => DummyString
            }.Instance;

            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => spListItem;
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder()
            {
                FilesGet = () => new ShimSPFileCollection()
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPFile>()
            {
                file
            }.GetEnumerator();

            // Act
            var actual = XElement.Parse((string)privateObject.Invoke(
                LoadModelsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.LocalName.ShouldBe("AssignmentPlannerModels"),
                () => actual.Element("Models").Element("Model").Attribute("Name").Value.ShouldBe(fileName),
                () => actual.Element("Models").Element("Model").Attribute("Url").Value.ShouldBe($"{DummyString}/{DummyString}"));
        }

        [TestMethod]
        public void LoadViews_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "<AssignmentPlannerView/>";

            var validationCount = 0;
            var mockObject = new Mock<IGridViewManager>();
            var grids = new List<GridView>()
            {
                new GridView()
                {
                    Definition = expected
                }
            };

            mockObject
                .Setup(x => x.Initialize())
                .Callback(() =>
                {
                    validationCount = validationCount + 1;
                });
            mockObject
                .SetupGet(x => x.List)
                .Returns(grids);

            ShimGridViewManagerFactory.AllInstances.MakeGridViewManagerStringGridViewManagerKind = (_, _1, _2) => mockObject.Object;

            // Act
            var actual = XElement.Parse((string)privateObject.Invoke(
                LoadViewsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => validationCount.ShouldBe(2),
                () => actual.Name.LocalName.ShouldBe("AssignmentPlannerViews"),
                () => actual.Element("Views").Elements("AssignmentPlannerView").Count().ShouldBe(2));
        }

        [TestMethod]
        public void SaveModels_WhenCalled_ReturnsString()
        {
            // Arrange
            const string data = @"
                <Models>
                    <Model Name=""modelName1"">MTEx</Model>
                    <Model Name=""modelName2"">MTEx</Model>
                </Models>";

            var validationCount = 0;
            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary();
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder()
            {
                FilesGet = () => new ShimSPFileCollection()
                {
                    AddStringByteArray = (name, array) =>
                    {
                        if (name.StartsWith("modelName"))
                        {
                            validationCount = validationCount + 1;
                        }
                        return null;
                    }
                }
            };

            // Act
            var actual = (string)privateObject.Invoke(
                SaveModelsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { data });

            // Asert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("<Models/>"),
                () => validationCount.ShouldBe(2));
        }

        [TestMethod]
        public void SaveViews_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "<AssignmentPlannerViews/>";
            const string data = @"
                <xmlcfg>
                    <View Id=""1"">View1</View>
                    <View Id=""2"">View2</View>
                </xmlcfg>";

            var validationCount = 0;
            var mockObject = new Mock<IGridViewManager>();

            mockObject
                .Setup(x => x.Add(It.IsAny<GridView>()))
                .Callback(() =>
                {
                    validationCount = validationCount + 1;
                });

            ShimGridViewManagerFactory.AllInstances.MakeGridViewManagerStringGridView = (_, _1, _2) => mockObject.Object;

            // Act
            var actual = (string)privateObject.Invoke(
                SaveViewsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { data });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validationCount.ShouldBe(2));
        }

        [TestMethod]
        public void UpdateViews_WhenCalled_ReturnsString()
        {
            // Arrange
            const string data = @"
                <xmlcfg>
                    <View Id=""1"">View1</View>
                    <View Id=""2"">View2</View>
                </xmlcfg>";

            var mockObject = new Mock<IGridViewManager>();
            var validationCount = 0;

            mockObject
                .Setup(x => x.Update(It.IsAny<GridView>()))
                .Callback(() =>
                {
                    validationCount = validationCount + 1;
                });

            ShimGridViewManagerFactory.AllInstances.MakeGridViewManagerStringGridView = (_, _1, _2) =>
            {
                return mockObject.Object;
            };

            // Act
            var actual = privateObject.Invoke(
                UpdateViewsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { data });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("<AssignmentPlannerViews/>"),
                () => validationCount.ShouldBe(2));
        }

        [TestMethod]
        public void ConfigureColumns_WhenCalled_ConfiguresColumns()
        {
            // Arrange
            var actual = default(XElement);
            var headerElement = new XElement("headerElement");
            var colsElement = new XElement("colsElement");
            var defaultColumns = new List<string>()
            {
                "1"
            };
            var fields = new List<string>()
            {
                "1",
                "2"
            };

            ShimUtils.GetRelatedGridTypeSPField = _ => "Icon";
            ShimUtils.GetFormatSPField = _ => DummyString;
            ShimUtils.ToGridSafeFieldNameString = (input) => input;
            ShimMyWork.GetRelatedGridFormatStringStringSPFieldSPWeb = (_, _1, _2, _3) => DummyString;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, __) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                TypeGet = () => SPFieldType.Lookup,
                TitleGet = () => DummyString
            };
            ShimXContainer.AllInstances.AddObject = (instance, input) =>
            {
                if (instance.NodeType == XmlNodeType.Element)
                {
                    if (colsElement.Name.LocalName.Equals(((XElement)instance).Name.LocalName))
                    {
                        actual = (XElement)input;
                    }
                }
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    instance.Add(input);
                });
            };

            // Act
            privateObject.Invoke(
                ConfigureColumnsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[]
                {
                    spWeb.Instance,
                    string.Empty,
                    headerElement,
                    colsElement,
                    string.Empty,
                    defaultColumns,
                    fields,
                    spList.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attribute("Name").Value.ShouldBe($"{DummyString}Text"),
                () => actual.Attribute("Type").Value.ShouldBe("Icon"),
                () => actual.Attribute("IconAlign").Value.ShouldBe("Center"),
                () => actual.Attribute("Format").Value.ShouldBe("DummyString"),
                () => actual.Attribute("Visible").Value.ShouldBe("0"));
        }

        [TestMethod]
        public void ConfigureDefaultColumns_WhenCalled_ConfiguresDefaultColumns()
        {
            // Arrange
            const short startHour = 10;
            const short endHour = 20;
            const string ganttExclude = "ganttExclude";
            const string layoutXmlString = @"
                <xmlcfg>
                    <RightCols>
                        <C Name=""ColName""/>
                    </RightCols>
                </xmlcfg>";

            var actual = default(XElement);
            var layoutXml = XDocument.Parse(layoutXmlString);
            var defaultColumns = new List<string>();

            ShimUtils.GetRelatedGridTypeSPField = _ => "Icon";
            ShimUtils.GetFormatSPField = _ => DummyString;
            ShimUtils.ToGridSafeFieldNameString = (input) => input;
            ShimMyWork.GetRelatedGridFormatStringStringSPFieldSPWeb = (_, _1, _2, _3) => DummyString;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, __) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                TypeGet = () => SPFieldType.Lookup,
                TitleGet = () => DummyString
            };
            ShimXContainer.AllInstances.AddObject = (instance, input) =>
            {
                if (instance.NodeType == XmlNodeType.Element)
                {
                    if (((XElement)instance).Name.LocalName.Equals("RightCols"))
                    {
                        actual = (XElement)input;
                    }
                }
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    instance.Add(input);
                });
            };

            // Act
            privateObject.Invoke(
                ConfigureDefaultColumnsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[]
                {
                    spList.Instance,
                    string.Empty,
                    string.Empty,
                    spWeb.Instance,
                    startHour,
                    endHour,
                    ganttExclude,
                    layoutXml,
                    defaultColumns
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attribute("Name").Value.ShouldBe("G"),
                () => actual.Attribute("GanttExclude").Value.ShouldBe(ganttExclude),
                () => actual.Attribute("GanttNewStart").Value.ShouldBe("1/1/2000 10:00"),
                () => actual.Attribute("GanttNewEnd").Value.ShouldBe("1/1/2000 20:00"));
        }

        [TestMethod]
        public void GetGanttExclude_WhenCalled_ReturnsString()
        {
            // Arrange
            const short workDayStartHour = 9;
            const short workDayEndHour = 6;

            var expected = new StringBuilder();
            expected.Append("d#0:00~9:00#4;d#14:00~15:00#4;d#6:00~24:00#4;")
                .Append("w#2008-01-06~2008-01-07#5;")
                .Append("w#2008-01-08~2008-01-09#5;")
                .Append("w#2008-01-09~2008-01-10#5;")
                .Append("w#2008-01-10~2008-01-11#5;")
                .Append("w#2008-01-11~2008-01-12#5;")
                .Append("w#2008-01-12~2008-01-13#5;")
                .Append("2016-01-10~2016-01-11#3;")
                .Append("2016-01-10 00:00~2016-01-10 9:00;2016-01-10 5:00~2016-01-11 24:00#3");

            var dataTable = new DataTable();
            dataTable.Columns.Add(DateColumn);
            dataTable.Columns.Add(HoursColumn);
            var row = dataTable.NewRow();
            row[DateColumn] = "2016-01-10";
            row[HoursColumn] = string.Empty;
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[DateColumn] = "2016-01-10";
            row[HoursColumn] = "1";
            dataTable.Rows.Add(row);

            var regionalSettings = new ShimSPRegionalSettings()
            {
                WorkDaysGet = () => 2
            };

            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimSPListItemCollection.AllInstances.GetDataTable = _ => dataTable;

            // Act
            var actual = (string)privateObject.Invoke(
                GetGanttExcludeMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { regionalSettings.Instance, spWeb.Instance, workDayStartHour, workDayEndHour });

            // Assert
            actual.ShouldBe(expected.ToString());
        }

        [TestMethod]
        public void RegisterGridIdAndCss_WhenCalled_Registers()
        {
            // Arrange
            const string dataXmlString = @"
                <xmlcfg>
                    <Id>111</Id>
                </xmlcfg>";

            var actual = default(XElement);
            var dataXml = XDocument.Parse(dataXmlString);
            var resultRootElement = new XElement("resultRootElement");

            ShimXContainer.AllInstances.AddObject = (instance, input) =>
            {
                if (instance.NodeType == XmlNodeType.Element)
                {
                    if (resultRootElement.Name.LocalName.Equals(((XElement)instance).Name.LocalName))
                    {
                        actual = (XElement)input;
                    }
                }
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    instance.Add(input);
                });
            };

            // Act
            privateObject.Invoke(
                RegisterGridIdAndCssMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { resultRootElement, dataXml });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.LocalName.ShouldBe("Cfg"),
                () => actual.Attribute("id").Value.ShouldBe("111"));
        }

        [TestMethod]
        public void ValidateMyWorkDataResponse_WhenCalled_Validates()
        {
            // Arrange
            const string myWorkDataXmlString = @"
                <xmlcfg Status=""1"">
                    <Error ID=""111"">CustomErrorMessage</Error>
                </xmlcfg>";

            var myWorkDataXml = XDocument.Parse(myWorkDataXmlString);
            var actual = default(APIException);

            // Act
            try
            {
                privateObject.Invoke(
                    ValidateMyWorkDataResponseMethodName,
                    BindingFlags.Static | BindingFlags.NonPublic,
                    new object[] { myWorkDataXml });
            }
            catch (APIException exception)
            {
                actual = exception;
            }

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ExceptionNumber.ShouldBe(111),
                () => actual.Message.ShouldBe("CustomErrorMessage"));
        }

        [TestMethod]
        public void GetLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string data = "<xmlcfg/>";
            const string layoutXml = @"
                <xmlcfg>
                    <Header/>
                    <Cols/>
                </xmlcfg>";
            const string fieldsResponse = @"
                <xmlcfg>
                    <Error>Error</Error>
                    <GetMyWorkFields>
                        <Data>
                            <Field Name=""FieldName1""/>
                            <Field Name=""FieldName2""/>
                        </Data>
                    </GetMyWorkFields>
                </xmlcfg>";

            var validationCount = 0;
            var regionalSettings = new ShimSPRegionalSettings()
            {
                LocaleIdGet = () => 1033,
                WorkDayStartHourGet = () => 540,
                WorkDayEndHourGet = () => 1080
            };

            spWeb.RegionalSettingsGet = () => regionalSettings;
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => layoutXml;
            ShimWorkEngineAPI.AllInstances.ExecuteStringString = (_, _1, _2) => fieldsResponse;
            ShimUtilities.DecodeGridDataString = input => input;
            ShimGridManager.RegisterGridIdAndCssXElementXDocument = (_, __) =>
            {
                validationCount = validationCount + 1;
            };
            ShimGridManager.AllInstances.GetGanttExcludeSPRegionalSettingsSPWebInt16Int16 = (_, _1, _2, _3, _4) =>
            {
                validationCount = validationCount + 1;
                return string.Empty;
            };
            ShimGridManager.ConfigureDefaultColumnsSPListStringStringSPWebInt16Int16StringXDocumentRefListOfStringRef =
                (SPList spList, string datePattern, string currencyFormat,
                SPWeb spWeb, short workDayStartHour, short workDayEndHour,
                string ganttExclude, ref XDocument layoutXmlParam, ref List<string> defaultColumns) =>
                {
                    validationCount = validationCount + 1;
                };
            ShimGridManager.ConfigureColumnsSPWebStringXElementRefXElementRefStringListOfStringIEnumerableOfStringSPList =
                (SPWeb spWeb, string currencyFormat, ref XElement headerElement,
                ref XElement colsElement, string datePattern, List<string> defaultColumns,
                IEnumerable<string> fields, SPList spList) =>
                {
                    validationCount = validationCount + 1;
                };

            // Act
            var actual = (string)privateObject.Invoke(
                GetLayoutMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { data });

            // Assert
            validationCount.ShouldBe(4);
        }
    }
}
