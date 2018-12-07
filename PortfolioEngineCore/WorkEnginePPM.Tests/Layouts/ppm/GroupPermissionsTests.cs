using System;
using System.Data;
using System.Data.Fakes;
using System.IO;
using System.IO.Fakes;
using System.Web.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    public class GroupPermissionsTests
    {
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private PrivateType privateType;
        private GroupPermissions groupPermissions;
        private const string BuildGridLayoutMethodName = "BuildGridLayout";
        private const string DeleteGroupPermissionMethodName = "DeleteGroupPermission";
        private const string DummyString = "DummyString";
        private static StatusEnum StatusEnumReturn;
        private static string ReturnContent;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            groupPermissions = new GroupPermissions();
            privateObject = new PrivateObject(groupPermissions);
            privateType = new PrivateType(typeof(GroupPermissions));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimDataAccess.ConstructorStringSecurityLevels = (_, info, level) => { };
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimSqlDb.AllInstances.Close = _ => { };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
        }

        [TestMethod]
        public void BuildGridLayout_Should_CreateCStruct()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = privateType.InvokeStatic(BuildGridLayoutMethodName, dataTable) as CStruct;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.GetSubStruct("Toolbar").ShouldNotBeNull(),
                () => result.GetSubStruct("Panel").ShouldNotBeNull(),
                () => result.GetSubStruct("Cfg").ShouldNotBeNull(),
                () => result.GetSubStruct("Def").ShouldNotBeNull(),
                () => result.GetSubStruct("LeftCols").ShouldNotBeNull(),
                () => result.GetSubStruct("Header").ShouldNotBeNull());
        }

        [TestMethod]
        public void IsReusable_Get_ReturnsFalse()
        {
            // Arrange, Act
            var result = groupPermissions.IsReusable;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void DeleteGroupPermission_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string RequestContext = "DeleteGroupPermission";
            var context = new ShimHttpContext();
            var structData = new CStruct();
            structData.Initialize("root");
            structData.CreateIntAttr("groupid", 10);
            ShimdbaGroups.DeleteGroupPermissionDBAccessInt32StringOut = DeleteGroupPermission;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(context, RequestContext, structData);

            // Assert
            result.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteGroupPermission_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string RequestContext = "DeleteGroupPermission";
            const string ExpectedMessage = "<message>Exception of type 'System.Exception' was thrown.</message>";
            var context = new ShimHttpContext();
            var data = new CStruct();
            data.Initialize("root");
            data.CreateIntAttr("groupid", 10);
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimdbaGroups.DeleteGroupPermissionDBAccessInt32StringOut = DeleteGroupPermissionException;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateGroupPermissionsInfo_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string XmlData = @"<Grid>
                <Body>
                    <B>
                        <I>
                            <I FieldID=""3009"" CB=""1""/>
                            <I FieldID=""3025"" CB=""0""/>
                        </I>
                    </B>
                </Body>
            </Grid>";
            const string RequestContext = "UpdateGroupPermissionsInfo";
            var httpContext = new ShimHttpContext();
            var structData = new CStruct();
            structData.Initialize("Main");
            structData.SetIntAttr("groupid", 1);
            structData.SetStringAttr("name", DummyString);
            structData.SetStringAttr("notes", DummyString);
            structData.CreateString("treegridData", XmlData);
            ShimdbaGroups.UpdateGroupPermissionsInfoDBAccessInt32RefStringStringCStructStringOut = UpdateGroupPermissions;
            StatusEnumReturn = StatusEnum.rsSuccess;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void UpdateGroupPermissionsInfo_UpdatePermissionsError_ReturnsExpectedMessage()
        {
            // Arrange
            const string XmlData = @"<Grid>
                <Body>
                    <B>
                        <I>
                            <I FieldID=""3009"" CB=""1""/>
                        </I>
                    </B>
                </Body>
            </Grid>";
            const string ExpectedMessage = "<message>Error Message</message>";
            const string RequestContext = "UpdateGroupPermissionsInfo";
            var httpContext = new ShimHttpContext();
            var structData = new CStruct();
            structData.Initialize("Main");
            structData.SetIntAttr("groupid", 1);
            structData.SetStringAttr("name", DummyString);
            structData.SetStringAttr("notes", DummyString);
            structData.CreateString("treegridData", XmlData);
            ShimdbaGroups.UpdateGroupPermissionsInfoDBAccessInt32RefStringStringCStructStringOut = UpdateGroupPermissions;
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ReturnContent = string.Empty;
            ShimSqlDb.AllInstances.StatusTextGet = _ => "Error Message";

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateGroupPermissionsInfo_OnException_ReturnsExpectedMessage()
        {
            // Arrange
            const string XmlData = @"<Grid>
                <Body>
                    <B>
                        <I>
                            <I FieldID=""3009"" CB=""1""/>
                        </I>
                    </B>
                </Body>
            </Grid>";
            const string ExpectedMessage = "<message>Error Message</message>";
            const string RequestContext = "UpdateGroupPermissionsInfo";
            var httpContext = new ShimHttpContext();
            var structData = new CStruct();
            structData.Initialize("Main");
            structData.SetIntAttr("groupid", 1);
            structData.SetStringAttr("name", DummyString);
            structData.SetStringAttr("notes", DummyString);
            structData.CreateString("treegridData", XmlData);
            ShimCStruct.AllInstances.GetListString = (_, name) =>
            {
                throw new Exception("Error Message");
            };

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void GetGroupMembersInfo_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string RequestContext = "GetGroupMembersInfo";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };

            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaGroups.SelectGroupMembersDBAccessInt32DataTableOut = SelectGroupMembers;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void GetGroupMembersInfo_SelectGroupMembersError_ReturnsExpectedMessage()
        {
            // Arrange
            const string ExpectedMessage = "<message>Error Message</message>";
            const string RequestContext = "GetGroupMembersInfo";
            ShimSqlDb.AllInstances.StatusTextGet = _ => "Error Message";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ShimdbaGroups.SelectGroupMembersDBAccessInt32DataTableOut = SelectGroupMembers;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void GetGroupMembersInfo_OnException_ReturnsExpectedMessage()
        {
            // Arrange
            const string ExpectedMessage = "<message>Error Message</message>";
            const string RequestContext = "GetGroupMembersInfo";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaGroups.SelectGroupMembersDBAccessInt32DataTableOut = SelectGroupMembers;
            Shim_DGrid.AllInstances.SetDataTableDataTable = (_, dt) =>
            {
                throw new Exception("Error Message");
            };

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void GetGroupPermissionsInfo_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string RequestContext = "GetGroupPermissionsInfo";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaGroups.SelectGroupDBAccessInt32DataTableOut = SelectGroupMembers;
            ShimdbaUsers.SelectGroupPermissionsDBAccessInt32DataTableOut = SelectGroupMembers;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => "1"
                }
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimGroupPermissions.BuildGridLayoutDataTable = dataTable => new CStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void GetGroupPermissionsInfo_SelectGroupPermissionsError_ReturnsExpectedMessage()
        {
            // Arrange
            const string RequestContext = "GetGroupPermissionsInfo";
            const string ExpectedMessage = "<message>Error Message</message>";
            ShimSqlDb.AllInstances.StatusTextGet = _ => "Error Message";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaGroups.SelectGroupDBAccessInt32DataTableOut = SelectGroupMembers;
            ShimdbaUsers.SelectGroupPermissionsDBAccessInt32DataTableOut = SelectGroupMembers;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsRequestCannotBeCompleted;
            ShimGroupPermissions.BuildGridLayoutDataTable = dataTable => new CStruct();

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void GetGroupPermissionsInfo_SelectGroupError_ReturnsExpectedMessage()
        {
            // Arrange
            const string RequestContext = "GetGroupPermissionsInfo";
            const string ExpectedMessage = "<message>Error Message</message>";
            ShimSqlDb.AllInstances.StatusTextGet = _ => "Error Message";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ShimdbaGroups.SelectGroupDBAccessInt32DataTableOut = SelectGroupMembers;

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void GetGroupPermissionsInfo_OnException_ReturnsExpectedMessage()
        {
            // Arrange
            const string RequestContext = "GetGroupPermissionsInfo";
            const string ExpectedMessage = "<message>Error Message</message>";
            var httpContext = new ShimHttpContext();
            var structData = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            ShimSqlDb.AllInstances.Open = _ =>
            {
                throw new Exception("Error Message");
            };

            // Act
            var result = GroupPermissions.GroupPermissionsRequest(httpContext, RequestContext, structData);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void ProcessRequest_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            var contentType = string.Empty;
            var response = string.Empty;
            var httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new MemoryStream()
                },
                ServerGet = () => new ShimHttpServerUtility(),
                ResponseGet = ()=> new ShimHttpResponse
                {
                    WriteString = content => response = content
                }
            };
            ShimStreamReader.AllInstances.ReadToEnd = _ => DummyString;
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => "GroupPermissionsRequest";
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimWebAdmin.CheckRequestHttpContextStringString = 
                (context, className, request) => string.Empty;
            ShimWebAdmin.BuildReplyStringStringStringString = 
                (className, function, context, message) => message;
            ShimGroupPermissions.GroupPermissionsRequestHttpContextStringCStruct = 
                (context, request, data) => DummyString;
            ShimCStruct.ConvertXMLToJSONString = xml => xml;
            ShimHttpResponse.AllInstances.ContentTypeSetString = (_, type) => contentType = type;

            // Act
            groupPermissions.ProcessRequest(httpContext);

            // Assert
            response.ShouldSatisfyAllConditions(
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.ShouldBe(DummyString),
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType));
        }

        [TestMethod]
        public void ProcessRequest_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string ExpectedErrorMessage = "<message>Error Message</message>";
            var contentType = string.Empty;
            var response = string.Empty;
            var httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new MemoryStream()
                },
                ServerGet = () => new ShimHttpServerUtility(),
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => response = content
                }
            };
            ShimStreamReader.AllInstances.ReadToEnd = _ => DummyString;
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => "GroupPermissionsRequest";
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimWebAdmin.CheckRequestHttpContextStringString =
                (context, className, request) =>
                {
                    throw new Exception("Error Message");
                };
            ShimWebAdmin.BuildReplyStringStringStringString =
                (className, function, context, message) => message;
            ShimGroupPermissions.GroupPermissionsRequestHttpContextStringCStruct =
                (context, request, data) => DummyString;
            ShimCStruct.ConvertXMLToJSONString = xml => xml;
            ShimHttpResponse.AllInstances.ContentTypeSetString = (_, type) => contentType = type;

            // Act
            groupPermissions.ProcessRequest(httpContext);

            // Assert
            response.ShouldSatisfyAllConditions(
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.ShouldContain(ExpectedErrorMessage),
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType));
        }

        [TestMethod]
        public void ProcessRequest_OnMethodException_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string ExpectedErrorMessage = "<message>Object reference not set to an instance of an object.</message>";
            var contentType = string.Empty;
            var response = string.Empty;
            var httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new MemoryStream()
                },
                ServerGet = () => new ShimHttpServerUtility(),
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => response = content
                }
            };
            ShimStreamReader.AllInstances.ReadToEnd = _ => DummyString;
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimWebAdmin.CheckRequestHttpContextStringString =
                (context, className, request) => string.Empty;
            ShimWebAdmin.BuildReplyStringStringStringString =
                (className, function, context, message) => message;
            ShimGroupPermissions.GroupPermissionsRequestHttpContextStringCStruct =
                (context, request, data) => DummyString;
            ShimCStruct.ConvertXMLToJSONString = xml => xml;
            ShimHttpResponse.AllInstances.ContentTypeSetString = (_, type) => contentType = type;

            // Act
            groupPermissions.ProcessRequest(httpContext);

            // Assert
            response.ShouldSatisfyAllConditions(
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.ShouldContain(ExpectedErrorMessage),
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, eve though not all of them are used
        /// </summary>
        private StatusEnum SelectGroupMembers(
            DBAccess dbAccess, 
            int id, 
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, eve though not all of them are used
        /// </summary>
        private StatusEnum UpdateGroupPermissions(
            DBAccess dba, 
            ref int nGroupId, 
            string sName, 
            string sNotes, 
            CStruct xPerms, 
            out string sReply)
        {
            sReply = ReturnContent;
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, eve though not all of them are used
        /// </summary>
        private StatusEnum DeleteGroupPermission(
            DBAccess dbAccess, 
            int id, 
            out string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, eve though not all of them are used
        /// </summary>
        private StatusEnum DeleteGroupPermissionException(
            DBAccess dbAccess, 
            int id, 
            out string reply)
        {
            throw new Exception();
        }
    }
}
