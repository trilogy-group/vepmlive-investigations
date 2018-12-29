using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Text;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.API.APITeam"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class APITeamTests2
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private APITeam _testEntity;
        private IDisposable _shimsContext;
        private readonly StringBuilder query = new StringBuilder();
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            query.Clear();
            maxDatareaderCount = 1;
            currentDataReaderCount = 0;

            _testEntity = new APITeam();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(APITeam));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void iGetResourcesFromlist_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("SPID");
            dataTable.Columns.Add("Groups");
            dataTable.Columns.Add("Photo");
            dataTable.Columns.Add("PrincipalType");
            dataTable.Columns.Add("Username");
            dataTable.Columns.Add("SPAccountInfo");
            dataTable.Columns.Add(DummyString);

            var arrayList = new ArrayList();
            var parameters = new object[]
            {
                new ShimSPList().Instance,
                dataTable,
                new ShimSPWeb().Instance,
                DummyString,
                DummyString,
                true,
                arrayList,
                new ShimSPListItem().Instance
            };

            // Act
            const string methodName = "iGetResourcesFromlist";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeOfType(typeof(DataTable)),
                () => ((DataTable)result).Rows.Count.ShouldBe(1));
        }

        [TestMethod]
        public void iGetResourcesFromlist_liItemNull_CheckBehaviour()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("SPID");
            dataTable.Columns.Add("Groups");
            dataTable.Columns.Add("Photo");
            dataTable.Columns.Add("PrincipalType");
            dataTable.Columns.Add("Username");
            dataTable.Columns.Add("SPAccountInfo");
            dataTable.Columns.Add(DummyString);

            var arrayList = new ArrayList();
            var parameters = new object[]
            {
                new ShimSPList().Instance,
                dataTable,
                new ShimSPWeb().Instance,
                DummyString,
                DummyString,
                true,
                arrayList,
                null
            };

            // Act
            const string methodName = "iGetResourcesFromlist";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeOfType(typeof(DataTable)),
                () => ((DataTable)result).Rows.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetTeamGridLayout_ParametersGiven_ThrowsException()
        {
            // Arrange
            var xmlString = $@"<dummy></dummy>";
            var parameters = new object[] { xmlString, new ShimSPWeb().Instance };
            var expectedResult = "<Grid><Cfg id=\"TeamGrid\" SuppressCfg=\"0\" /><!-- Configuration is not saved to cookies --><Cfg MainCol=\"Title\" NameCol=\"Title\" Style=\"GM\" CSS=\"TreeGrid/WorkEngine/Grid.css\" Undo=\"0\" ChildParts=\"0\" /><Cfg ExportType=\"Expanded,Outline\" /><Cfg PrintCols=\"1\" /><Cfg ExportCols=\"1\" /><Cfg NumberId=\"1\" FullId=\"0\" IdChars=\"1234567890\" AddFocusCol=\"Title\" /><Cfg StaticCursor=\"1\" Dragging=\"0\" SelectingCells=\"1\" ShowDeleted=\"0\" SelectClass=\"0\" Hover=\"0\" /><Cfg Paging=\"2\" AllPages=\"1\" PageLength=\"25\" MaxPages=\"20\" NoPager=\"1\" ChildParts=\"2\" /><Toolbar Visible=\"0\"></Toolbar><Panel Visible=\"1\" Delete=\"0\" Move=\"0\" NoFormatEscape=\"1\" CanHide=\"0\" SelectWidth=\"30\" /><Cfg NoTreeLines=\"1\" DetailOn=\"0\" MinRowHeight=\"20\" MidWidth=\"300\" MenuColumnsSort=\"1\" StandardFilter=\"2\" /><Header SortIcons=\"2\" ProjectRate=\"Project Rate\" ProjectRateEdit=\"\" /><Cfg Code=\"GTACCNPSQEBSLC\" /><LeftCols><C Name=\"Photo\" Visible=\"1\" Width=\"65\" Type=\"Html\" CanHide=\"1\" /><C Name=\"Title\" Visible=\"1\" RelWidth=\"1\" CanHide=\"0\" Type=\"Html\" CaseSensitive=\"0\" /></LeftCols><Cols><C Name=\"SPAccountInfo\" Type=\"Html\" Visible=\"0\" /><C Name=\"Groups\" Type=\"Html\" Visible=\"0\" /><C Name=\"ProjectRate\" Type=\"Html\" Width=\"100\" Align=\"Right\" Visible=\"0\" /><C Name=\"ProjectRateEdit\" Type=\"Html\" Width=\"30\" Align=\"Left\" Visible=\"0\" /></Cols><RightCols></RightCols><Def><D Name=\"R\" Calculated=\"0\" /><D Name=\"Group\" CanSelect=\"0\" /></Def><Solid></Solid><Header Visible=\"1\" /><Head><I Kind=\"Filter\" Visible=\"0\" id=\"Filter\" /><I Kind=\"Group\" Visible=\"0\" id=\"GroupRow\" /></Head></Grid>";

            // Act
            const string methodName = "GetTeamGridLayout";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void GetTeamFromWeb_ListIsNull_ThrowsException()
        {
            // Arrange
            var arrayList = new ArrayList();
            var parameters = new object[] { new ShimSPWeb().Instance, DummyString, DummyString, arrayList };
            ShimSPListCollection.AllInstances.TryGetListString = (_, _1) => null;

            // Act
            const string methodName = "GetTeamFromWeb";
            var ex = Should.Throw<Exception>(() => _privateType.InvokeStatic(methodName, parameters));

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(APIException)),
                () => ex.Message.ShouldContain("Cannot Find Team List or Create a new Team List"));
        }

        [TestMethod]
        public void GetTeamFromWeb_ListNotNull_ThrowsException()
        {
            // Arrange
            var arrayList = new ArrayList();
            var parameters = new object[] { new ShimSPWeb().Instance, DummyString, DummyString, arrayList };
            var expectedInnerXml = "<Team><Member ID=\"DummyString\" SPID=\"DummyString\" SPAccountInfo=\"DummyString\" Username=\"DummyString\" PrincipalType=\"DummyString\" Photo=\"DummyString\" Groups=\"DummyString\" Permissions=\"\" /></Team>";

            // Act
            const string methodName = "GetTeamFromWeb";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeOfType(typeof(XmlDocument)),
                () => ((XmlDocument)result).InnerXml.ShouldBe(expectedInnerXml));
        }

        [TestMethod]
        public void GetGenericResourceGrid_ExceptionThrown_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSPList.AllInstances.FieldsGet = _ => { throw new Exception("access is denied"); };
            var expectedInnerXML = "<Grid><Cfg id=\"DummyString\" SuppressCfg=\"0\" /><!-- Configuration is not saved to cookies --><Cfg MainCol=\"Title\" NameCol=\"Title\" Style=\"GM\" CSS=\"TreeGrid/WorkEngine/Grid.css\" Undo=\"0\" ChildParts=\"0\" /><Cfg ExportType=\"Expanded,Outline\" /><Cfg PrintCols=\"1\" /><Cfg ExportCols=\"1\" /><Cfg NumberId=\"1\" FullId=\"0\" IdChars=\"1234567890\" AddFocusCol=\"Title\" /><Cfg StaticCursor=\"1\" Dragging=\"0\" SelectingCells=\"1\" ShowDeleted=\"0\" SelectClass=\"0\" Hover=\"0\" /><Cfg Paging=\"2\" AllPages=\"1\" PageLength=\"25\" MaxPages=\"20\" NoPager=\"1\" ChildParts=\"2\" /><Toolbar Visible=\"0\"></Toolbar><Panel Visible=\"1\" Delete=\"0\" Move=\"0\" NoFormatEscape=\"1\" CanHide=\"0\" SelectWidth=\"30\" /><Cfg NoTreeLines=\"1\" DetailOn=\"0\" MinRowHeight=\"20\" MidWidth=\"300\" MenuColumnsSort=\"1\" StandardFilter=\"2\" /><Header SortIcons=\"2\" Title=\"Display Name\" /><Cfg Code=\"GTACCNPSQEBSLC\" /><LeftCols><C Name=\"Photo\" Visible=\"1\" Width=\"65\" Type=\"Html\" CanHide=\"1\" /><C Name=\"Title\" Visible=\"1\" RelWidth=\"1\" CanHide=\"0\" Type=\"Html\" CaseSensitive=\"0\" /></LeftCols><Cols><C Name=\"Title\" Type=\"Html\" RelWidth=\"100\" /><C Name=\"SPAccountInfo\" Type=\"Html\" Visible=\"0\" /><C Name=\"Groups\" Type=\"Html\" Visible=\"0\" /></Cols><RightCols></RightCols><Def><D Name=\"R\" Calculated=\"0\" /><D Name=\"Group\" CanSelect=\"0\" /></Def><Solid></Solid><Header Visible=\"1\" /><Head><I Kind=\"Filter\" Visible=\"0\" id=\"Filter\" /><I Kind=\"Group\" Visible=\"0\" id=\"GroupRow\" /></Head></Grid>";

            // Act
            const string methodName = "GetGenericResourceGrid";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeOfType(typeof(XmlDocument)),
                () => ((XmlDocument)result).InnerXml.ShouldBe(expectedInnerXML));
        }

        [TestMethod]
        public void GetTeamGridData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xmlString = $@"<dummy ItemId='{DummyInt}'>
                            </dummy>";
            var parameters = new object[] { xmlString, new ShimSPWeb().Instance };
            var expectedResult = "<Grid><Body><B><I NoColorState=\"1\" id=\"DummyString\" SPID=\"DummyString\" SPAccountInfo=\"DummyString\" Username=\"DummyString\" PrincipalType=\"DummyString\" Photo=\"DummyString\" Groups=\"DummyString\" Permissions=\"\" AllowEditProjectRate=\"0\" /></B></Body></Grid>";

            // Act
            const string methodName = "GetTeamGridData";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void GetTeamFromCurrent_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimSPWeb().Instance,
                DummyString,
                DummyString,
                new ArrayList(),
                DummyString
            };
            var expectedxmlResult = "<Team><Member ID=\"DummyString\" SPID=\"DummyString\" SPAccountInfo=\"DummyString\" Username=\"DummyString\" PrincipalType=\"DummyString\" Photo=\"DummyString\" Groups=\"DummyString\" /></Team>";

            // Act
            const string methodName = "GetTeamFromCurrent";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeOfType(typeof(XmlDocument)),
                () => ((XmlDocument)result).InnerXml.ShouldBe(expectedxmlResult));
        }

        [TestMethod]
        public void setPermissions_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimSPWeb().Instance,
                DummyString,
                DummyString
            };

            // Act
            const string methodName = "setPermissions";
            var ex = Should.Throw<Exception>(() => { _privateType.InvokeStatic(methodName, parameters); });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(ArgumentNullException)),
                () => ex.Message.ShouldContain("Value cannot be null"));
        }

        [TestMethod]
        public void GetResourceGridData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimDataRow.AllInstances.ItemGetString = (_, key) =>
            {
                return DummyInt;
            };
            var expectedResult = "<Grid><Body><B><I NoColorState=\"1\" id=\"DummyString\" SPID=\"DummyString\" SPAccountInfo=\"DummyString\" Username=\"DummyString\" PrincipalType=\"DummyString\" Photo=\"DummyString\" Groups=\"DummyString\" AllowEditProjectRate=\"1\" /></B></Body></Grid>";

            // Act
            const string methodName = "GetResourceGridData";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void GetWebGroups_ParametersGiven_ThrowsException()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance };

            // Act
            const string methodName = "GetWebGroups";
            var ex = Should.Throw<Exception>(() => { _privateType.InvokeStatic(methodName, parameters); });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(ArgumentNullException)),
                () => ex.Message.ShouldContain("Value cannot be null"));
        }

        [TestMethod]
        public void GetResourceGridLayout_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            var expectedResult = "<Grid><Cfg id=\"ResourceGrid\" SuppressCfg=\"0\" /><!-- Configuration is not saved to cookies --><Cfg MainCol=\"Title\" NameCol=\"Title\" Style=\"GM\" CSS=\"TreeGrid/WorkEngine/Grid.css\" Undo=\"0\" ChildParts=\"0\" /><Cfg ExportType=\"Expanded,Outline\" /><Cfg PrintCols=\"1\" /><Cfg ExportCols=\"1\" /><Cfg NumberId=\"1\" FullId=\"0\" IdChars=\"1234567890\" AddFocusCol=\"Title\" /><Cfg StaticCursor=\"1\" Dragging=\"0\" SelectingCells=\"1\" ShowDeleted=\"0\" SelectClass=\"0\" Hover=\"0\" /><Cfg Paging=\"2\" AllPages=\"1\" PageLength=\"25\" MaxPages=\"20\" NoPager=\"1\" ChildParts=\"2\" /><Toolbar Visible=\"0\"></Toolbar><Panel Visible=\"1\" Delete=\"0\" Move=\"0\" NoFormatEscape=\"1\" CanHide=\"0\" SelectWidth=\"30\" /><Cfg NoTreeLines=\"1\" DetailOn=\"0\" MinRowHeight=\"20\" MidWidth=\"300\" MenuColumnsSort=\"1\" StandardFilter=\"2\" /><Header SortIcons=\"2\" /><Cfg Code=\"GTACCNPSQEBSLC\" /><LeftCols><C Name=\"Photo\" Visible=\"0\" Width=\"65\" Type=\"Html\" CanHide=\"1\" /><C Name=\"Title\" Visible=\"1\" RelWidth=\"1\" CanHide=\"0\" Type=\"Html\" CaseSensitive=\"0\" /></LeftCols><Cols><C Name=\"SPAccountInfo\" Type=\"Html\" Visible=\"0\" /><C Name=\"Groups\" Type=\"Html\" Visible=\"0\" /></Cols><RightCols></RightCols><Def><D Name=\"R\" Calculated=\"0\" /><D Name=\"Group\" CanSelect=\"0\" /></Def><Solid></Solid><Header Visible=\"1\" /><Head><I Kind=\"Filter\" Visible=\"0\" id=\"Filter\" /><I Kind=\"Group\" Visible=\"0\" id=\"GroupRow\" /></Head></Grid>";

            // Act
            const string methodName = "GetResourceGridLayout";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void UpdateProjectResourceRate_ParametersGiven_ThrowsException()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, DummyInt, DummyInt, null };

            // Act
            const string methodName = "UpdateProjectResourceRate";
            var ex = Should.Throw<Exception>(() => { _privateType.InvokeStatic(methodName, parameters); });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(NullReferenceException)));
        }

        [TestMethod]
        public void GetResourceId_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("Generic");
            dataTable.Columns.Add("Username");
            dataTable.Columns.Add("Title");
            dataTable.Rows.Add(DummyString, DummyString, DummyString);
            var parameters = new object[] { new ShimSPWeb().Instance, dataTable.Rows[0] };
            ShimAPITeam.GetResourceIdSPWebStringString = (_, _1, _2) => DummyInt;

            // Act
            const string methodName = "GetResourceId";
            var result = _privateType.InvokeStatic(methodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyInt));
        }

        private void InitShims()
        {
            ShimAPITeam.IsPfeSiteSPWeb = _ => true;
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection().Instance;
            ShimSPListItemCollection.AllInstances.GetDataTable = _ =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("ResID");
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Title");
                dataTable.Rows.Add(DummyString, DummyString, DummyString);
                return dataTable;
            };
            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection().Instance;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimAPITeam.getResourcesSPWebStringStringBooleanArrayListSPListItemXmlNodeList = (_, _1, _2, _3, _4, _5, _6) =>
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("SPID");
                dataTable.Columns.Add("SPAccountInfo");
                dataTable.Columns.Add("Username");
                dataTable.Columns.Add("PrincipalType");
                dataTable.Columns.Add("Photo");
                dataTable.Columns.Add("Groups");

                dataTable.Rows.Add(DummyString, DummyString, DummyString, DummyString, DummyString, DummyString, DummyString);
                return dataTable;
            };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb().Instance;
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) => new ShimSPWeb().Instance;
            ShimSPSite.ConstructorString = (_, _1) => { };
            ShimSPSite.ConstructorGuid = (_, _1) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_, _1, _2, _3) => DummyString;
            ShimSPListCollection.AllInstances.TryGetListString = (_, _1) => new ShimSPList().Instance;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection().Instance;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite().Instance;
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection().Instance;
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser().Instance;
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => { };
            ShimSPListItem.AllInstances.ItemGetString = (_, key) => DummyString;
            var sPListItems = new List<SPListItem>()
            {
                new ShimSPListItem().Instance,
            };
            ShimSPList.AllInstances.GetItemsSPQuery = (_, _1) =>
            {
                return new ShimSPListItemCollection()
                {
                    GetEnumerator = () => sPListItems.GetEnumerator(),
                    CountGet = () => sPListItems.Count,
                    ItemGetInt32 = index => sPListItems[index],
                }.Instance;
            };
            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
            SetupSqlShims();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
        }

        private void SetupSqlShims()
        {
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                if (command.CommandText == "SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)")
                {
                    return true;
                }
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                query.Append("\n" + command.CommandText);
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key == "FA_FORMAT")
                        {
                            return 4;
                        }
                        else if (key == "CMT_TIMESTAMP" || key == "RPEN_TIMESTAMP" || key == "PRD_FINISH_DATE" || key == "PRD_CLOSED_DATE")
                        {
                            return DateTime.Now;
                        }
                        else if (key == "CMT_GUID")
                        {
                            return new Guid();
                        }
                        else if (key == "ADM_PORT_COMMITMENTS_OPMODE")
                        {
                            return 0;
                        }
                        else if (key == "CB_ID")
                        {
                            return 14;
                        }
                        else if (key == "VIEW_DATA")
                        {
                            return "<Dummy></Dummy>";
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
        }
    }
}
