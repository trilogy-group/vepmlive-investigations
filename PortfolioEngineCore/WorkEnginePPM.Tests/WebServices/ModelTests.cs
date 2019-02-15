using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using PortfolioEngineCore.PortfolioItems;
using PortfolioEngineCore.PortfolioItems.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;
using ShimWebService = System.Web.Services.Fakes.ShimWebService;

namespace WorkEnginePPM.Tests.WebServices
{
    /// <summary> 
    /// Unit Tests for <see cref="WorkEnginePPM.Model"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ModelTests
    {
        private const string Target = "target";
        private const string ViewName = "viewName";
        private const int Localflag = 15;
        private const string ZoomTo = "ZoomTo";
        private const string Ticket = "Ticket";
        private const string DummyConnectionString = "DummyConnectionString";
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const bool DummyBool = true;
        private const int Uid = 105;
        private const string Name = "name";
        private const string BasePath = "basePath";
        private const string UserName = "userName";
        private const string PpmID = "ppmID";
        private const string PpmCompany = "ppmCompany";
        private const string PpmDBConn = "ppmDBConn";
        private const SecurityLevels SecurityLevel = SecurityLevels.AdminCalc;
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private Model _testEntity;
        private IDisposable _shimsContext;
        private HttpContext _httpContext;
        private StringBuilder query = new StringBuilder();
        private bool isScalarExecuted;
        private bool isNonQueryExecuted;
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int _wresID = 210;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private DataTable _dataTable;
        private string commandText = string.Empty;
        private readonly List<SyncStepInfo> stepInfos = new List<SyncStepInfo>();

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitCommonShims();
            SetupSqlShims();
            commandText = string.Empty;

            _testEntity = new Model();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(Model));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
            _dataTable?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void GetModels_GlobalPermissionFalse_CheckBehaviour()
        {
            // Arrange
            var assertions = new List<Action>();
            SetupForGetModelsTest(assertions, false);

            // Act
            var result = _testEntity.GetModels();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            assertions.Add(() => result[0].Id.ShouldBe(0));
            assertions.Add(() => result[0].Name.ShouldBe("***PermsisionsCheck***"));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetModels_GlobalPermissionTrue_CheckBehaviour()
        {
            // Arrange
            var assertions = new List<Action>();
            SetupForGetModelsTest(assertions, true);

            // Act
            var result = _testEntity.GetModels();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            assertions.Add(() => result[0].Id.ShouldBe(Uid));
            assertions.Add(() => result[0].Name.ShouldBe(Name));
            assertions.Add(() => result[0].Deflt.ShouldBe(0));
            assertions.Add(() => query.ToString().ShouldContain("SELECT MODEL_UID, MODEL_NAME FROM EPGP_MODEL_SCENARIOS ORDER BY MODEL_NAME"));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void LoadModelData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var ticket = string.Empty;
            var model = string.Empty;
            var versions = string.Empty;
            var viewID = "ViewID";
            var assertions = new List<Action>();
            var authenticateUserAndProductCallCount = 0;
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext httpContect, out string stage) =>
            {
                authenticateUserAndProductCallCount++;
                assertions.Add(() => httpContect.ShouldBe(_httpContext));
                stage = "stage";
                return true;
            };
            assertions.Add(() => authenticateUserAndProductCallCount.ShouldBe(1));
            var getConnectionStringCallCount = 0;
            ShimWebAdmin.GetConnectionStringHttpContext = getConnectionHttpContext =>
            {
                getConnectionStringCallCount++;
                assertions.Add(() => getConnectionHttpContext.ShouldBe(_httpContext));
                return "connection_string";
            };
            assertions.Add(() => getConnectionStringCallCount.ShouldBe(1));
            var checkUserGlobalPermissionCallCount = 0;
            ShimModel.CheckUserGlobalPermissionSqlConnectionInt32GlobalPermissionsEnum = (connection, wresID, permission) =>
            {
                checkUserGlobalPermissionCallCount++;
                assertions.AddRange(new List<Action>()
                {
                    () => connection.ShouldBe(_sqlConnection),
                    () => wresID.ShouldBe(_wresID),
                    () => permission.ShouldBe(GlobalPermissionsEnum.gpProjectVerCenter)
                });
                return true;
            };
            assertions.Add(() => checkUserGlobalPermissionCallCount.ShouldBe(1));
            var expectedTicket = "ebe45859-43b7-4e4c-a5df-4615b14904ed";
            var initalLoadDataCallCount = 0;
            ShimModelCache.AllInstances.InitalLoadDataSqlConnectionStringStringStringStringString =
                (_, conn, sTicket, sModel, sVersions, sWresID, sViewID) =>
                {
                    initalLoadDataCallCount++;
                    assertions.AddRange(new List<Action>()
                    {
                        () => conn.ShouldBe(_sqlConnection),
                        () => sTicket.ShouldBe(expectedTicket),
                        () => sModel.ShouldBe("1"),
                        () => sVersions.ShouldBe("0"),
                        () => sWresID.ShouldBe(_wresID.ToString()),
                        () => sViewID.ShouldBe(viewID)
                    });
                    return DummyInt;
                };
            assertions.Add(() => initalLoadDataCallCount.ShouldBe(1));
            var saveCachedDataCallCount = 0;
            ShimModel.SaveCachedDataHttpContextStringObject = (saveCachedDatacontext, saveCachedDataTicket, modelData) =>
            {
                saveCachedDataCallCount++;
                assertions.AddRange(new List<Action>()
                {
                    () => saveCachedDatacontext.ShouldBe(_httpContext),
                    () => saveCachedDataTicket.ShouldBe(expectedTicket),
                    () => modelData.ShouldBeOfType(typeof(ModelCache))
                });
            };
            assertions.Add(() => saveCachedDataCallCount.ShouldBe(1));

            // Act
            var result = _testEntity.LoadModelData(ticket, model, versions, viewID);

            // Assert
            assertions.Add(() => result.ShouldBe(string.Empty));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void LoadModelData_ExceptionThrown_ExceptionMessageReturned()
        {
            // Arrange
            var model = "model";
            var versions = "version";
            var viewID = "ViewID";
            var parameters = new object[] { Ticket, model, versions, viewID };
            var assertions = new List<Action>();
            const string expectedExceptionMessage = "Exception in LoadModelData Method";
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext httpContect, out string stage) =>
            {
                assertions.Add(() => httpContect.ShouldBe(_httpContext));
                stage = "stage";
                throw new InvalidOperationException(expectedExceptionMessage);
            };

            // Act
            const string MethodName = "LoadModelData";
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(expectedExceptionMessage));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void ObtainSqlConnection_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var wresID = 0;
            var parameters = new object[] { wresID };
            ShimModel.AllInstances.ObtainSqlConnectionInt32Out = null;
            var assertions = new List<Action>();
            var modelSupportConstructorCallCount = 0;
            ShimModelSupport.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, basepath, username, pid, company, dbcnstring, secLevel, bDebug) =>
                {
                    modelSupportConstructorCallCount++;
                    assertions.AddRange(new List<Action>()
                    {
                        () => basepath.ShouldBe(BasePath),
                        () => username.ShouldBe(UserName),
                        () => pid.ShouldBe(PpmID),
                        () => company.ShouldBe(PpmCompany),
                        () => secLevel.ShouldBe(SecurityLevel),
                    });
                };
            assertions.Add(() => modelSupportConstructorCallCount.ShouldBe(1));
            const string ExpectedQuery = "SELECT WRES_ID FROM EPG_RESOURCES Where (";

            // Act
            const string MethodName = "ObtainSqlConnection";
            _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => query.ToString().ShouldContain(ExpectedQuery));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetCostViews_EmptyInput_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { };
            var assertions = new List<Action>();
            AuthenticateAndConnectionStringShims(assertions);
            _dataTable = new DataTable();
            _dataTable.Columns.Add("VIEW_UID");
            _dataTable.Columns.Add("VIEW_NAME");
            _dataTable.Rows.Add(Uid, Name);
            const string ExpectedQuery = "SELECT* FROM EPGT_COSTVIEW_DISPLAY";

            // Act
            const string MethodName = "GetCostViews";
            var result = (List<ItemDefn>)_privateObject.Invoke(MethodName, parameters);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            assertions.Add(() => query.ToString().ShouldContain(ExpectedQuery));
            assertions.Add(() => result[0].Id.ShouldBe(Uid));
            assertions.Add(() => result[0].Name.ShouldBe(Name));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPortfolioItemList_ParametersGiven_ReturnedXmlString()
        {
            // Arrange
            const string MethodName = "GetPortfolioItemList";
            const string PidList = "sPIDList";
            const string ExtIDList = "sExtIDList";
            const string Xml = "<xml></xml>";
            var modelData = new ModelCache();
            var parameters = new object[] { _httpContext, Xml, modelData };
            var assertions = new List<Action>();
            var portfolioItemsConstructorCallCount = 0;
            ShimPortfolioItems.ConstructorStringStringStringStringStringBoolean = (_, basePath, username, ppmId, ppmCompany, ppmDbConn, isDebug) =>
            {
                portfolioItemsConstructorCallCount++;
                assertions.Add(() => basePath.ShouldBe(BasePath));
                assertions.Add(() => username.ShouldBe(UserName));
                assertions.Add(() => ppmId.ShouldBe(PpmID));
                assertions.Add(() => ppmCompany.ShouldBe(PpmCompany));
                assertions.Add(() => ppmDbConn.ShouldBe(PpmDBConn));
                assertions.Add(() => isDebug.ShouldBe(false));
            };
            assertions.Add(() => portfolioItemsConstructorCallCount.ShouldBe(1));
            var isInvokedObtainManagedPortfolioItems = false;
            ShimPortfolioItems.AllInstances.ObtainManagedPortfolioItemsStringOutStringOutStringOut =
                (PortfolioItems instance, out string sExtIDList, out string sPIDList, out string sXML) =>
                {
                    sExtIDList = ExtIDList;
                    sPIDList = PidList;
                    sXML = Xml;
                    isInvokedObtainManagedPortfolioItems = true;
                };
            var isInvokedBuildResultXML = false;
            var resultXml = new CStruct();
            var buildResultXMLCallCount = 0;
            ShimModel.BuildResultXMLStringInt32 = (context, status) =>
            {
                buildResultXMLCallCount++;
                isInvokedBuildResultXML = true;
                assertions.Add(() => context.ShouldBe("GetPortfolioItemList"));
                assertions.Add(() => status.ShouldBe(0));
                return resultXml;
            };
            assertions.Add(() => buildResultXMLCallCount.ShouldBe(1));
            var isInvokedCreateSubStruct = false;
            ShimCStruct.AllInstances.CreateSubStructString = (_, itemName) =>
            {
                isInvokedCreateSubStruct = true;
                assertions.Add(() => itemName.ShouldBe("IDLists"));
                return new CStruct();
            };
            var cStructAttributes = new Dictionary<string, string>();
            var expectedCStructAttributes = new Dictionary<string, string>()
            {
                ["EXTLIST"] = ExtIDList,
                ["IDLIST"] = PidList,
            };
            var createStringCallCount = 0;
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, itemName, value) =>
            {
                createStringCallCount++;
                cStructAttributes.Add(itemName, value);
            };
            assertions.Add(() => createStringCallCount.ShouldBe(2));
            var appendXMLCallCount = 0;
            ShimCStruct.AllInstances.AppendXMLString = (_, xmlString) =>
            {
                appendXMLCallCount++;
                assertions.Add(() => xmlString.ShouldBe(Xml));
                return true;
            };
            assertions.Add(() => appendXMLCallCount.ShouldBe(1));
            ShimCStruct.AllInstances.XML = _ => Xml;

            // Act
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            assertions.Add(() => isInvokedObtainManagedPortfolioItems.ShouldBeTrue());
            assertions.Add(() => isInvokedBuildResultXML.ShouldBeTrue());
            assertions.Add(() => isInvokedCreateSubStruct.ShouldBeTrue());
            assertions.Add(() => cStructAttributes.ShouldBe(expectedCStructAttributes));
            assertions.Add(() => result.ShouldBe(Xml));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPortfolioItemList_OnException_ExceptionCaught()
        {
            // Arrange
            const string MethodName = "GetPortfolioItemList";
            const string ExpectedExceptionMessage = "Exception In GetPortfolioItemList";
            const string ExpectedResult = "ExpectedResult";
            const int ExpectedStatus = 99999;
            var parameters = new object[] { _httpContext, DummyString, new ModelCache() };
            var assertions = new List<Action>();
            var portfolioItemsConstructorCallCount = 0;
            ShimPortfolioItems.ConstructorStringStringStringStringStringBoolean = (_, basePath, username, ppmId, ppmCompany, ppmDbConn, isDebug) =>
            {
                portfolioItemsConstructorCallCount++;
                assertions.Add(() => basePath.ShouldBe(BasePath));
                assertions.Add(() => username.ShouldBe(UserName));
                assertions.Add(() => ppmId.ShouldBe(PpmID));
                assertions.Add(() => ppmCompany.ShouldBe(PpmCompany));
                assertions.Add(() => ppmDbConn.ShouldBe(PpmDBConn));
                assertions.Add(() => isDebug.ShouldBe(false));
            };
            assertions.Add(() => portfolioItemsConstructorCallCount.ShouldBe(1));
            var obtainManagedPortfolioItemsCallCount = 0;
            ShimPortfolioItems.AllInstances.ObtainManagedPortfolioItemsStringOutStringOutStringOut =
                (PortfolioItems _, out string exts, out string pid, out string xml) =>
                {
                    obtainManagedPortfolioItemsCallCount++;
                    exts = DummyString;
                    pid = DummyString;
                    xml = DummyString;
                    throw new InvalidOperationException(ExpectedExceptionMessage);
                };
            assertions.Add(() => obtainManagedPortfolioItemsCallCount.ShouldBe(1));
            var handleErrorCallCount = 0;
            ShimModel.HandleErrorStringInt32String = (error, status, context) =>
            {
                handleErrorCallCount++;
                assertions.Add(() => error.ShouldBe(MethodName));
                assertions.Add(() => status.ShouldBe(ExpectedStatus));
                return ExpectedResult;
            };
            assertions.Add(() => handleErrorCallCount.ShouldBe(1));

            // Act
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(ExpectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void CheckUserGlobalPermission_WresIDEquals1_ReturnsTrue()
        {
            // Arrange
            const string MethodName = "CheckUserGlobalPermission";
            var parameters = new object[] { new SqlConnection(), 1, GlobalPermissionsEnum.gpBudgetAnalyzer };

            // Act
            var result = (bool)_privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(true));
        }

        [TestMethod]
        public void CheckUserGlobalPermission_WresIDNotEquals1_ReturnsTrue()
        {
            // Arrange
            const string MethodName = "CheckUserGlobalPermission";
            const int WResID = 0;
            var parameters = new object[] { new SqlConnection(), WResID, GlobalPermissionsEnum.gpBudgetAnalyzer };
            var expectedStepInfos = new List<SyncStepInfo>
            {
                new SyncStepInfo { Index = 2, Method = "SqlCommand" },
                new SyncStepInfo { Index = 5, Method = "CommandExecuteReader" },
                new SyncStepInfo { Index = 6, Method = "SqlDataReaderRead" },
                new SyncStepInfo { Index = 7, Method = "ReaderClose" },
            };
            var expectedSQLQuery = "EPG_SP_CheckUserGlobalPermission";

            // Act
            var result = (bool)_privateType.InvokeStatic(MethodName, parameters);

            // Assert
            _sqlCommand.Parameters.Count.ShouldBe(2);
            this.ShouldSatisfyAllConditions(
                () => query.ToString().ShouldContain(expectedSQLQuery),
                () => _sqlCommand.Parameters[0].ParameterName.ShouldBe("WResID"),
                () => _sqlCommand.Parameters[0].Value.ShouldBe(WResID),
                () => _sqlCommand.Parameters[1].ParameterName.ShouldBe("PermUID"),
                () => _sqlCommand.Parameters[1].Value.ShouldBe((int)GlobalPermissionsEnum.gpBudgetAnalyzer),
                () => result.ShouldBeTrue(),
                () => expectedStepInfos.SequenceEqual(stepInfos).ShouldBeTrue());
        }

        [TestMethod]
        public void GetGeneratedPortfolioItemTicket_ParametersGiven_ReturnedXmlString()
        {
            // Arrange
            const string MethodName = "GetGeneratedPortfolioItemTicket";
            const string PidList = "sPIDList";
            const string ExtIDList = "sExtIDList";
            const string Xml = "<xml></xml>";
            const string Guid = "123";
            var modelData = new ModelCache();
            var parameters = new object[] { _httpContext, Xml, modelData };
            var assertions = new List<Action>();
            var portfolioItemsConstructorCallCount = 0;
            ShimPortfolioItems.ConstructorStringStringStringStringStringBoolean = (_, basePath, username, ppmId, ppmCompany, ppmDbConn, isDebug) =>
            {
                portfolioItemsConstructorCallCount++;
                assertions.Add(() => basePath.ShouldBe(BasePath));
                assertions.Add(() => username.ShouldBe(UserName));
                assertions.Add(() => ppmId.ShouldBe(PpmID));
                assertions.Add(() => ppmCompany.ShouldBe(PpmCompany));
                assertions.Add(() => ppmDbConn.ShouldBe(PpmDBConn));
                assertions.Add(() => isDebug.ShouldBe(false));
            };
            assertions.Add(() => portfolioItemsConstructorCallCount.ShouldBe(1));
            var isInvokedGeneratePortfolioItemTicket = false;
            ShimPortfolioItems.AllInstances.GeneratePortfolioItemTicketString =
                (instance, dataIn) =>
                {
                    dataIn.ShouldBe(Xml);
                    isInvokedGeneratePortfolioItemTicket = true;
                    return Guid;
                };
            var isInvokedBuildResultXML = false;
            var resultXml = new CStruct();
            ShimModel.BuildResultXMLStringInt32 = (context, status) =>
            {
                isInvokedBuildResultXML = true;
                assertions.Add(() => context.ShouldBe("GetGeneratedPortfolioItemTicket"));
                assertions.Add(() => status.ShouldBe(0));
                return resultXml;
            };
            var isInvokedCreateSubStruct = false;
            ShimCStruct.AllInstances.CreateSubStructString = (_, itemName) =>
            {
                isInvokedCreateSubStruct = true;
                assertions.Add(() => itemName.ShouldBe("Ticket"));
                return new CStruct();
            };
            var cStructAttributes = new Dictionary<string, string>();
            var expectedCStructAttributes = new Dictionary<string, string>()
            {
                ["Value"] = Guid,
            };
            var createStringCallCount = 0;
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, itemName, value) =>
            {
                createStringCallCount++;
                cStructAttributes.Add(itemName, value);
            };
            assertions.Add(() => createStringCallCount.ShouldBe(1));
            ShimCStruct.AllInstances.XML = _ => Xml;

            // Act
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            assertions.Add(() => isInvokedGeneratePortfolioItemTicket.ShouldBeTrue());
            assertions.Add(() => isInvokedBuildResultXML.ShouldBeTrue());
            assertions.Add(() => isInvokedCreateSubStruct.ShouldBeTrue());
            assertions.Add(() => cStructAttributes.ShouldBe(expectedCStructAttributes));
            assertions.Add(() => result.ShouldBe(Xml));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetGeneratedPortfolioItemTicket_OnException_ExceptionCaught()
        {
            // Arrange
            const string MethodName = "GetGeneratedPortfolioItemTicket";
            const string ExpectedExceptionMessage = "Exception In GetGeneratedPortfolioItemTicket";
            const string ExpectedResult = "ExpectedResult";
            const int ExpectedStatus = 99999;
            var parameters = new object[] { _httpContext, DummyString, new ModelCache() };
            var assertions = new List<Action>();
            var portfolioItemsConstructorCallCount = 0;
            ShimPortfolioItems.ConstructorStringStringStringStringStringBoolean = (_, basePath, username, ppmId, ppmCompany, ppmDbConn, isDebug) =>
            {
                portfolioItemsConstructorCallCount++;
                assertions.Add(() => basePath.ShouldBe(BasePath));
                assertions.Add(() => username.ShouldBe(UserName));
                assertions.Add(() => ppmId.ShouldBe(PpmID));
                assertions.Add(() => ppmCompany.ShouldBe(PpmCompany));
                assertions.Add(() => ppmDbConn.ShouldBe(PpmDBConn));
                assertions.Add(() => isDebug.ShouldBe(false));
            };
            assertions.Add(() => portfolioItemsConstructorCallCount.ShouldBe(1));
            ShimPortfolioItems.AllInstances.GeneratePortfolioItemTicketString =
                (instance, dataIn) =>
                {
                    throw new InvalidOperationException(ExpectedExceptionMessage);
                };
            ShimModel.HandleErrorStringInt32String = (error, status, context) =>
            {
                assertions.Add(() => error.ShouldBe(MethodName));
                assertions.Add(() => status.ShouldBe(ExpectedStatus));
                return ExpectedResult;
            };

            // Act
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(ExpectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SetFilterData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "SetFilterData";
            var ticket = "ticket";
            var filterData = "filterData";
            const string Version = "version";
            var parameters = new object[] { ticket, filterData };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, ticket);
            var setFilterDataCallCount = 0;
            ShimModelCache.AllInstances.SetFilterDataString = (instance, filterDataParam) =>
            {
                setFilterDataCallCount++;
                assertions.Add(() => filterDataParam.ShouldBe(filterData));
                return Version;
            };
            assertions.Add(() => setFilterDataCallCount.ShouldBe(1));
            var isInvokedLoadScenarioData = false;
            ShimModelCache.AllInstances.LoadScenarioDataSqlConnectionString = (_, conn, versions) =>
            {
                isInvokedLoadScenarioData = true;
                assertions.Add(() => conn.ShouldBe(_sqlConnection));
                assertions.Add(() => versions.ShouldBe(Version));
                return DummyInt;
            };
            assertions.Add(() => isInvokedLoadScenarioData.ShouldBeTrue());
            var isInvokedProcessAndCreateDistplayLists = true;
            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ => isInvokedProcessAndCreateDistplayLists = true;
            assertions.Add(() => isInvokedProcessAndCreateDistplayLists.ShouldBeTrue());

            // Act
            _privateObject.Invoke(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void CreateTarget_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "CreateTarget";
            var ticket = "ticket";
            var targetName = "targetName";
            var targetDescription = "targetDescription";
            var localTarget = 10;
            var copyfromTarget = 20;
            var parameters = new object[] { ticket, targetName, targetDescription, localTarget, copyfromTarget };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, ticket);
            var createTargetCallCount = 0;
            ShimModelCache.AllInstances.CreateTargetSqlConnectionStringStringInt32Int32 =
                (_, conn, sTargetName, sTargetDesc, ilocalTarget, icopyfromTarget) =>
                {
                    createTargetCallCount++;
                    _.ShouldSatisfyAllConditions(
                        () => conn.ShouldBe(_sqlConnection),
                        () => sTargetName.ShouldBe(targetName),
                        () => sTargetDesc.ShouldBe(targetDescription),
                        () => ilocalTarget.ShouldBe(localTarget),
                        () => icopyfromTarget.ShouldBe(copyfromTarget));
                    return localTarget;
                };
            assertions.Add(() => createTargetCallCount.ShouldBe(1));

            // Act
            var result = (ItemDefn)_privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.Id.ShouldBe(localTarget));
            assertions.Add(() => result.Name.ShouldBe(targetName));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SelectUserViewData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "SelectUserViewData";
            const string ViewZoomTo = "ViewZoomTo";
            var ticket = "ticket";
            var viewIndex = 10;
            var parameters = new object[] { ticket, viewIndex };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, ticket);
            var selectUserViewDataCallCount = 0;
            ShimModelCache.AllInstances.SelectUserViewDataSqlConnectionInt32 = (_, conn, viewIndexParam) =>
            {
                selectUserViewDataCallCount++;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => viewIndexParam.ShouldBe(viewIndex));
                return ViewZoomTo;
            };
            assertions.Add(() => selectUserViewDataCallCount.ShouldBe(1));
            var isInvokedProcessAndCreateDistplayLists = false;
            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ => isInvokedProcessAndCreateDistplayLists = true;
            assertions.Add(() => isInvokedProcessAndCreateDistplayLists.ShouldBeTrue());
            var getSortAndGroupCallCount = 0;
            ShimModelCache.AllInstances.GetSortAndGroupSortGroupDefnRef = (ModelCache instance, ref SortGroupDefn sortGroupDefn) =>
            {
                getSortAndGroupCallCount++;
                sortGroupDefn.ViewZoomTo.ShouldBe(ViewZoomTo);
            };
            assertions.Add(() => getSortAndGroupCallCount.ShouldBe(1));

            // Act
            var result = (SortGroupDefn)_privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ViewZoomTo.ShouldBe(ViewZoomTo));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void DeleteUserViewData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "DeleteUserViewData";
            var viewName = "sviewName";
            var localFlag = 1;
            var parameters = new object[] { Ticket, viewName, localFlag };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var isInvokedDeleteUserViewData = false;
            ShimModelCache.AllInstances.DeleteUserViewDataSqlConnectionStringInt32 = (_, conn, viewNameParam, localFlagParam) =>
            {
                isInvokedDeleteUserViewData = true;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => viewNameParam.ShouldBe(viewName),
                    () => localFlagParam.ShouldBe(localFlag));
            };
            assertions.Add(() => isInvokedDeleteUserViewData.ShouldBeTrue());
            var userViewData = new List<ItemDefn>();
            ShimModelCache.AllInstances.LoadUserViewData = _ => userViewData;

            // Act
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(userViewData));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void PrepareTargetData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "PrepareTargetData";
            const int TargetID = 12;
            var parameters = new object[] { Ticket, TargetID };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var expectedResult = new CSTargetData();
            ShimModelCache.AllInstances.PrepareTargetDataSqlConnectionInt32CSTargetDataRef =
                (ModelCache _, SqlConnection conn, int targetID, ref CSTargetData csTargetData) =>
                {
                    _.ShouldSatisfyAllConditions(
                        () => conn.ShouldBe(_sqlConnection),
                        () => targetID.ShouldBe(TargetID));
                    expectedResult = csTargetData;
                };

            // Act
            var result = (CSTargetData)_privateObject.Invoke(MethodName, parameters);

            // Assert
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public void RenameUserViewData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "RenameUserViewData";
            const string NewName = "NewName";
            const string ViewName = "ViewName";
            const int LocalFlag = 10;
            var parameters = new object[] { Ticket, NewName, ViewName, LocalFlag };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var isInvokedRenameUserViewData = false;
            ShimModelCache.AllInstances.RenameUserViewDataSqlConnectionStringStringInt32 = (_, conn, snewName, sviewName, localflag) =>
            {
                isInvokedRenameUserViewData = true;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => snewName.ShouldBe(NewName),
                    () => sviewName.ShouldBe(ViewName),
                    () => localflag.ShouldBe(LocalFlag));
            };
            assertions.Add(() => isInvokedRenameUserViewData.ShouldBeTrue());
            var expectedResult = new List<ItemDefn>();
            ShimModelCache.AllInstances.LoadUserViewData = _ => expectedResult;

            // Act
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(expectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void ReturnVersionAsTarget_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string MethodName = "ReturnVersionAsTarget";
            const int VersID = 15;
            var parameters = new object[] { Ticket, VersID };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var expectedResult = new CSTargetData();
            ShimModelCache.AllInstances.LoadVersionTargetDataSqlConnectionInt32CSTargetDataRef =
                (ModelCache _, SqlConnection conn, int versID, ref CSTargetData cSTargetData) =>
                {
                    _.ShouldSatisfyAllConditions(
                        () => conn.ShouldBe(_sqlConnection),
                        () => versID.ShouldBe(VersID));
                    expectedResult = cSTargetData;
                };

            // Act
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(expectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SaveUserViewData_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { Ticket, ViewName, Localflag, ZoomTo };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var saveUserViewDataCallCount = 0;
            ShimModelCache.AllInstances.SaveUserViewDataSqlConnectionStringInt32String = (_, conn, sviewName, localflag, sZoomTo) =>
            {
                saveUserViewDataCallCount++;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => sviewName.ShouldBe(ViewName),
                    () => localflag.ShouldBe(Localflag),
                    () => sZoomTo.ShouldBe(ZoomTo));
            };
            assertions.Add(() => saveUserViewDataCallCount.ShouldBe(1));
            var expectedResult = new List<ItemDefn>();
            ShimModelCache.AllInstances.LoadUserViewData = _ => expectedResult;

            // Act
            const string MethodName = "SaveUserViewData";
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(expectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void DoLoadTarget_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { Ticket, Target };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var isInvokedLoadTargetData = false;
            ShimModelCache.AllInstances.LoadTargetDataSqlConnectionString = (_, conn, target) =>
            {
                isInvokedLoadTargetData = true;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => target.ShouldBe(Target));
                return DummyInt;
            };
            assertions.Add(() => isInvokedLoadTargetData.ShouldBeTrue());

            // Act
            const string MethodName = "DoLoadTarget";
            _privateObject.Invoke(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void DoLoadVersion_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string Load = "load";
            var parameters = new object[] { Ticket, Load };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var isInvokedLoadScenarioData = false;
            ShimModelCache.AllInstances.LoadScenarioDataSqlConnectionString = (_, conn, sLoad) =>
            {
                isInvokedLoadScenarioData = true;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => sLoad.ShouldBe(Load));
                return DummyInt;
            };
            assertions.Add(() => isInvokedLoadScenarioData.ShouldBeTrue());

            // Act
            const string MethodName = "DoLoadVersion";
            _privateObject.Invoke(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void DoSaveVersion_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string Version = "version";
            var parameters = new object[] { Ticket, Version };
            var assertions = new List<Action>();
            CommonShimsCacheAuthAndConnection(assertions, Ticket);
            var isInvokedSaveVersion = false;
            ShimModelCache.AllInstances.SaveVersionSqlConnectionString = (_, conn, version) =>
            {
                isInvokedSaveVersion = true;
                _.ShouldSatisfyAllConditions(
                    () => conn.ShouldBe(_sqlConnection),
                    () => version.ShouldBe(Version));
                return DummyInt;
            };
            assertions.Add(() => isInvokedSaveVersion.ShouldBeTrue());

            // Act
            const string MethodName = "DoSaveVersion";
            _privateObject.Invoke(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void ExecuteJSON_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const string Function = "function";
            const string Dataxml = "Dataxml";
            const string resultXML = "<xml>xml</xml>";
            var parameters = new object[] { Ticket, Function, Dataxml };
            var assertions = new List<Action>();
            ShimModel.AllInstances.ExecuteStringStringString = (_, ticket, function, dataxml) =>
            {
                _.ShouldSatisfyAllConditions(
                    () => ticket.ShouldBe(Ticket),
                    () => function.ShouldBe(Function),
                    () => dataxml.ShouldBe(Dataxml));
                return resultXML;
            };
            var dummyJson = "{}";
            ShimCStruct.ConvertXMLToJSONString = xml =>
            {
                assertions.Add(() => xml.ShouldBe(resultXML));
                return dummyJson;
            };

            // Act
            const string MethodName = "ExecuteJSON";
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(dummyJson));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void LoadSelectVersions_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            const int ModleID = 10;
            var parameters = new object[] { ModleID };
            var assertions = new List<Action>();
            CommonShimsAuthAndConnection(assertions);
            var expectedResult = new List<ItemDefn>();
            ShimModelCache.AllInstances.ReadModelNamesStringStringSqlConnectionListOfItemDefnRef =
                (ModelCache _, string model, string WresID, SqlConnection conn, ref List<ItemDefn> vers) =>
                {
                    _.ShouldSatisfyAllConditions(
                        () => model.ShouldBe(ModleID.ToString()),
                        () => WresID.ShouldBe(_wresID.ToString()),
                        () => conn.ShouldBe(_sqlConnection));
                    vers = expectedResult;
                };

            // Act
            const string MethodName = "LoadSelectVersions";
            var result = _privateObject.Invoke(MethodName, parameters);

            // Assert
            assertions.Add(() => result.ShouldBe(expectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        private void InitCommonShims()
        {
            ShimWebAdmin.CapturePFEBaseInfoStringOutStringOutStringOutStringOutStringOutSecurityLevelsOut = (out string basepath,
                out string username,
                out string ppmId,
                out string ppmCompany,
                out string ppmDbConn,
                out SecurityLevels secLevel) =>
            {
                basepath = BasePath;
                username = UserName;
                ppmId = PpmID;
                ppmCompany = PpmCompany;
                ppmDbConn = PpmDBConn;
                secLevel = SecurityLevel;
            };
            ShimModelSupport.AllInstances.GetConnection = _ => _sqlConnection;
            _sqlConnection = new ShimSqlConnection().Instance;
            ShimModel.AllInstances.ObtainSqlConnectionInt32Out = (Model modalInstance, out int wResID) =>
            {
                wResID = _wresID;
                return _sqlConnection;
            };
            _httpContext = new ShimHttpContext().Instance;
            ShimWebService.AllInstances.ContextGet = _ => _httpContext;
        }

        private void SetupSqlShims()
        {
            _dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut =
                (SqlDb instance, string cmdText, StatusEnum eStatusOnException, out DataTable dataTable) =>
                {
                    query.Append($"\n{cmdText}");
                    dataTable = _dataTable;
                    return StatusEnum.rsSuccess;
                };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            maxDatareaderCount = 1;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                CheckAndAddList(1, "SqlConnectionOpen");
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, sql, connection) =>
            {
                query.Append("\n" + sql);
                CheckAndAddList(2, "SqlCommand");
            };
            ShimSqlConnection.AllInstances.Close = _ =>
            {
                CheckAndAddList(8, "ConnectionClose");
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                _sqlCommand = command;
                query.Append("\n" + command.CommandText);
                isScalarExecuted = true;
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                _sqlCommand = command;
                CheckAndAddList(9, "CommandExecuteNonQuery");
                query.Append("\n" + command.CommandText);
                isNonQueryExecuted = true;
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                _sqlCommand = command;
                CheckAndAddList(5, "CommandExecuteReader");
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () =>
                    {
                        CheckAndAddList(7, "ReaderClose");
                        currentDataReaderCount = 0;
                    },
                    Read = () =>
                    {
                        CheckAndAddList(6, "SqlDataReaderRead");
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        if (key.IndexOf("uid", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            return Uid;
                        }

                        if (key.IndexOf("name", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            return Name;
                        }

                        if (key.IndexOf("WRES_ID", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            return _wresID;
                        }

                        throw new InvalidOperationException("key not implemented");
                    },
                }.Instance;
            };
        }

        private void CommonShimsAuthAndConnection(List<Action> assertions)
        {
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                assertions.Add(() => context.ShouldBe(_testEntity.Context));
                stage = DummyString;
                return true;
            };
            var getConnectionStringCallCount = 0;
            ShimWebAdmin.GetConnectionStringHttpContext = context =>
            {
                getConnectionStringCallCount++;
                assertions.Add(() => context.ShouldBe(_testEntity.Context));
                return DummyConnectionString;
            };
            assertions.Add(() => getConnectionStringCallCount.ShouldBe(1));
            var obtainSqlConnectionCallCount = 0;
            ShimModel.AllInstances.ObtainSqlConnectionInt32Out = (Model instance, out int id) =>
            {
                obtainSqlConnectionCallCount++;
                id = _wresID;
                return _sqlConnection;
            };
            assertions.Add(() => obtainSqlConnectionCallCount.ShouldBe(1));
        }

        private void CommonShimsCacheAuthAndConnection(List<Action> assertions, string ticket)
        {
            var modelData = new ModelCache();
            var getCachedDataCallCount = 0;
            ShimModel.GetCachedDataHttpContextString = (context, ticketParam) =>
            {
                getCachedDataCallCount++;
                assertions.AddRange(new Action[]
                {
                    () => context.ShouldBe(_testEntity.Context),
                    () => ticketParam.ShouldBe(ticket)
                });
                return modelData;
            };
            assertions.Add(() => getCachedDataCallCount.ShouldBe(1));
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                assertions.Add(() => context.ShouldBe(_testEntity.Context));
                stage = DummyString;
                return true;
            };
            var getConnectionStringCallCount = 0;
            ShimWebAdmin.GetConnectionStringHttpContext = context =>
            {
                getConnectionStringCallCount++;
                assertions.Add(() => context.ShouldBe(_testEntity.Context));
                return DummyConnectionString;
            };
            assertions.Add(() => getConnectionStringCallCount.ShouldBe(1));
            var obtainSqlConnectionCallCount = 0;
            ShimModel.AllInstances.ObtainSqlConnectionInt32Out = (Model instance, out int id) =>
            {
                obtainSqlConnectionCallCount++;
                id = DummyInt;
                return _sqlConnection;
            };
            assertions.Add(() => obtainSqlConnectionCallCount.ShouldBe(1));
            var isInvokedSaveCachedData = false;
            ShimModel.SaveCachedDataHttpContextStringObject = (context, ticketParam, modelDataParam) =>
            {
                isInvokedSaveCachedData = true;
                assertions.Add(() => context.ShouldBe(_testEntity.Context));
                assertions.Add(() => ticketParam.ShouldBe(ticket));
                assertions.Add(() => modelDataParam.ShouldBe(modelData));
            };
            assertions.Add(() => isInvokedSaveCachedData.ShouldBeTrue());
        }

        private void AuthenticateAndConnectionStringShims(ICollection<Action> assertions)
        {
            const string ConnectionString = "connection_string";
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                assertions.Add(() => context.ShouldBe(_httpContext));
                stage = "stage";
                return true;
            };
            var getConnectionStringCallCount = 0;
            ShimWebAdmin.GetConnectionStringHttpContext = contextGetConnectionString =>
            {
                getConnectionStringCallCount++;
                assertions.Add(() => contextGetConnectionString.ShouldBe(_httpContext));
                return ConnectionString;
            };
            assertions.Add(() => getConnectionStringCallCount.ShouldBe(1));
        }

        private void SetupForGetModelsTest(ICollection<Action> assertions, bool hasGlobalPermission)
        {
            AuthenticateAndConnectionStringShims(assertions);
            var wresID = 10;
            var sqlConnection = new ShimSqlConnection().Instance;
            ShimModel.AllInstances.ObtainSqlConnectionInt32Out = (Model modalInstance, out int wResID) =>
            {
                wResID = wresID;
                return sqlConnection;
            };
            ShimModel.CheckUserGlobalPermissionSqlConnectionInt32GlobalPermissionsEnum = (connection, wResID, permission) =>
            {
                assertions.Add(() => connection.ShouldBe(sqlConnection));
                assertions.Add(() => wResID.ShouldBe(wresID));
                assertions.Add(() => permission.ShouldBe(GlobalPermissionsEnum.gpBudgetAnalyzer));
                return hasGlobalPermission;
            };
        }

        private void CheckAndAddList(int methodIndex, string methodName)
        {
            if (!stepInfos.Contains(new SyncStepInfo { Index = methodIndex, Method = methodName }))
            {
                stepInfos.Add(new SyncStepInfo { Index = methodIndex, Method = methodName });
            }
        }

        private class SyncStepInfo : IEquatable<SyncStepInfo>
        {
            public string Message { get; set; }
            public string Method { get; set; }
            public int Index { get; set; }

            public bool Equals(SyncStepInfo other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }
                if (ReferenceEquals(this, other))
                {
                    return true;
                }
                return string.Equals(Message, other.Message) && string.Equals(Method, other.Method) && Equals(Index, other.Index);
            }
        }
    }
}
