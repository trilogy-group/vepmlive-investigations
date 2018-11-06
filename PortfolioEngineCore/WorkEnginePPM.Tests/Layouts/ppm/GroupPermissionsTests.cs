using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var context = new ShimHttpContext().Instance;
            var data= new CStruct();
            data.Initialize("root");
            data.CreateIntAttr("groupid", 10);
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimdbaGroups.DeleteGroupPermissionDBAccessInt32StringOut = DeleteGroupPermission;

            // Act
            var result = privateType.InvokeStatic(DeleteGroupPermissionMethodName, context, data) as string;

            // Assert
            result.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteGroupPermission_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedMessage = "<message>Exception of type 'System.Exception' was thrown.</message>";
            var context = new ShimHttpContext().Instance;
            var data = new CStruct();
            data.Initialize("root");
            data.CreateIntAttr("groupid", 10);
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimdbaGroups.DeleteGroupPermissionDBAccessInt32StringOut = DeleteGroupPermissionException;

            // Act
            var result = privateType.InvokeStatic(DeleteGroupPermissionMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        private StatusEnum DeleteGroupPermission(DBAccess dbAccess, int id, out string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsSuccess;
        }

        private StatusEnum DeleteGroupPermissionException(DBAccess dbAccess, int id, out string reply)
        {
            throw new Exception();
        }
    }
}
