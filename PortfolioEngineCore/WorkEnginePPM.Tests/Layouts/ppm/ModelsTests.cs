using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    public class ModelsTests
    {
        private IDisposable shimsContext;
        private Models modelsObject;
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyException = "Dummy Exception";
        private const string DeleteModelInfoMethodName = "DeleteModelInfo";
        private const string UpdateModelInfoMethodName = "UpdateModelInfo";
        private const string InitializeSecurityColumnsMethodName = "InitializeSecurityColumns";
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            modelsObject = new Models();
            privateType = new PrivateType(typeof(Models));
        }

        private void SetupShims()
        {
            ShimCStruct.ConvertXMLToJSONString = content => content;
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetSubStructString = (_, content) => new CStruct();
            ShimDataAccess.ConstructorStringSecurityLevels = (_, baseInfo, level) => { };
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimWebAdmin.CheckRequestHttpContextStringString = (httpContext, className, request) => string.Empty;
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;


        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void IsReusable_Get_ReturnsFalse()
        {
            // Arrange, Act
            var result = modelsObject.IsReusable;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void ProcessRequest_OnSuccess_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string FunctionName = "ModelsRequest";
            var expectedResponseContent = $"<reply handler=\"WorkEnginePPM.Models\" function=\"{FunctionName}\" context=\"{FunctionName}\" >";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var context = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new ShimStream(new MemoryStream())
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content

                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimCStruct.AllInstances.GetStringAttrString = (_, content) => FunctionName;

            // Act
            modelsObject.ProcessRequest(context);

            // Assert
            modelsObject.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void ProcessRequest_OnException_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string FunctionName = "ModelsRequest";
            var expectedResponseContent = $"<location>WorkEnginePPM.Models.ProcessRequest</location><message>{DummyException}</message>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var context = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new ShimStream(new MemoryStream())
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content

                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimWebAdmin.CheckRequestHttpContextStringString = (httpContext, className, request) => string.Empty;
            ShimCStruct.AllInstances.GetStringAttrString = (_, content) => FunctionName;
            ShimCStruct.AllInstances.GetSubStructString = (_, content) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            modelsObject.ProcessRequest(context);

            // Assert
            modelsObject.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void ProcessRequest_CheckRequestException_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            var expectedResponseContent = $"<location>WorkEnginePPM.Models.ProcessRequest</location><message>{DummyException}</message>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var context = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new ShimStream(new MemoryStream())
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content

                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimWebAdmin.CheckRequestHttpContextStringString = (httpContext, className, request) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            modelsObject.ProcessRequest(context);

            // Assert
            modelsObject.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void DeleteModelInfo_OnSuccess_ReturnsExpectedMessage()
        {
            // Arrange
            var context = new ShimHttpContext().Instance;
            var data = new CStruct();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 1;
            ShimdbaModels.DeleteModelDBAccessInt32StringOut = DeleteModelSuccess;

            // Act
            var result = privateType.InvokeStatic(DeleteModelInfoMethodName, context, data) as string;


            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void DeleteModelInfo_OnException_ReturnsExpectedMessage()
        {
            // Arrange
            var expectedErrorMessage = $"<message>{DummyException}</message><trace></trace></error>";
            var context = new ShimHttpContext().Instance;
            var data = new CStruct();
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 1;
            ShimdbaModels.DeleteModelDBAccessInt32StringOut = DeleteModelException;

            // Act
            var result = privateType.InvokeStatic(DeleteModelInfoMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(expectedErrorMessage));
        }

        [TestMethod]
        public void UpdateModelInfo_OnSuccess_ReturnsExpectedMessage()
        {
            // Arrange
            var expectedMessage = $"<Model MODEL_UID=\"{DummyInt}\" MODEL_NAME=\"{DummyString}\" MODEL_DESC=\"{DummyString}\" />";
            var context = new ShimHttpContext().Instance;
            var data = new ShimCStruct
            {
                GetIntAttrString = name => DummyInt,
                GetStringAttrString = _ => DummyString
            }.Instance;
            Shim_DGrid.AllInstances.SetXmlDataString = (_, content) => new DataTable();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaModels.UpdateModelInfoDBAccessInt32RefStringStringInt32Int32StringDataTableStringOut = UpdateModelInfoSuccess;

            // Act
            var result = privateType.InvokeStatic(UpdateModelInfoMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedMessage));
        }

        [TestMethod]
        public void UpdateModelInfo_OnException_ReturnsErrorMessage()
        {
            // Arrange
            var expectedMessage = $"<location>Models.UpdateModelsInfo3</location><message>{DummyException}</message><trace></trace></error>";
            var context = new ShimHttpContext().Instance;
            var data = new ShimCStruct
            {
                GetIntAttrString = name => DummyInt,
                GetStringAttrString = _ => DummyString
            }.Instance;
            Shim_DGrid.AllInstances.SetXmlDataString = (_, content) => new DataTable();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaModels.UpdateModelInfoDBAccessInt32RefStringStringInt32Int32StringDataTableStringOut = UpdateModelInfoException;

            // Act
            var result = privateType.InvokeStatic(UpdateModelInfoMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(expectedMessage));
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateModelInfoSuccess(
            DBAccess dba, 
            ref int viewId, 
            string name, 
            string description, 
            int calendar, 
            int firstPeriod, 
            string lastPEriod, 
            DataTable dataTable, 
            out string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateModelInfoException(
            DBAccess dba,
            ref int viewId, 
            string name, 
            string description, 
            int calendar, 
            int firstPeriod,
            string lastPEriod, 
            DataTable dataTable, 
            out string reply)
        {
            throw new Exception(DummyException);
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteModelSuccess(DBAccess dbAccess, int id, out string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteModelException(DBAccess dbAccess, int id, out string reply)
        {
            throw new Exception(DummyException);
        }
    }
}
