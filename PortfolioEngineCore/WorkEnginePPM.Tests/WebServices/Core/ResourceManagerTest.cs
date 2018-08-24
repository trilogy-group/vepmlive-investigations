using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using PortfolioEngineCore.Infrastructure.Entities;
using PortfolioEngineCore.Infrastructure.Entities.Fakes;
using PortfolioEngineCore.Infrastructure.Fields;
using PortfolioEngineCore.Infrastructure.Fields.Fakes;
using Shouldly;
using WorkEnginePPM.Core.Fakes;
using WorkEnginePPM.Fakes;
using WorkEnginePPM.WebServices.Core;

namespace WorkEnginePPM.Tests.WebServices.Core
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResourceManagerTest
    {
        private IDisposable _shimObject;
        private ResourceManager _testObject;
        private PrivateObject _privateObject;
        private bool _resourceDeleted;
        private bool _resourceUpdated;
        private bool _availabilitiesCalculated;

        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const decimal DummyDecimal = 1.0M;

        private const string DeleteResourceCheckTag = "<DeleteResourceCheck>";
        private const string DeleteResourcesTag = "<DeleteResources>";
        private const string ReadPermissionGroupsTag = "<ReadPermissionGroups";
        private const string PermissionGroupTag = "<PermissionGroup";
        private const string ReadResourceCostCategoryRoleTag = "<ReadResourceCostCategoryRole>";
        private const string CostCategoryRoleTag = "<CostCategoryRole";
        private const string ReadResourcePermissionGroupsTag = "<ReadResourcePermissionGroups>";
        private const string ReadResourcesTag = "<ReadResources>";
        private const string UpdateResourcesTag = "<UpdateResources>";
        private const string ErrorIdTag = "Error ID";
        private const string PfEFailureTrue = "PfEFailure=\"True\"";
        private const string PfEFailureFalse = "PfEFailure=\"False\"";

        private const string GetRequestedResourcesMethod = "GetRequestedResources";

        private const string RootElementNotFound = "Cannot find the root element.";
        private const string DataElementNotFound = "Cannot find the data element.";
        private const string ResourceNotFound = "No Resource element was found.";
        private const string IdIsNull = "You must specify at least one of these attributes: Id, ExtId, Username";
        private const string DataIdNotFound = "Cannot find the DataId attribute.";
        private const string DataIdIsNull = "Please specify the DataId Attribute.";
        private const string DuplicateDataId = "Duplicate DataId found.";

        [TestInitialize]
        public void TestInitialize()
        {
            _resourceDeleted = false;
            _resourceUpdated = false;
            _availabilitiesCalculated = false;
            _shimObject = ShimsContext.Create();

            SetupShims();

            _testObject = new ResourceManager(new ShimSPWeb
            {
                InitWebPublic = () => { },
                CurrentUserGet = () => new ShimSPUser()
            });

            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void DeleteResourceCheck_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateTemplateXML();

            // Act
            var result = _testObject.DeleteResourceCheck(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(DeleteResourceCheckTag),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void DeleteResources_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateTemplateXML();

            // Act
            var result = _testObject.DeleteResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(DeleteResourcesTag),
                () => result.ShouldContain(DummyString),
                () => _resourceDeleted.ShouldBeTrue());
        }

        [TestMethod]
        public void ReadPermissionGroups_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = _testObject.ReadPermissionGroups();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ReadPermissionGroupsTag),
                () => result.ShouldContain(PermissionGroupTag),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ReadResourceCostCategoryRole_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateTemplateXML();

            // Act
            var result = _testObject.ReadResourceCostCategoryRole(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ReadResourceCostCategoryRoleTag),
                () => result.ShouldContain(CostCategoryRoleTag),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ReadResourcePermissionGroups_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateTemplateXML();

            // Act
            var result = _testObject.ReadResourcePermissionGroups(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ReadResourcePermissionGroupsTag),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ReadResources_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateTemplateXML();

            // Act
            var result = _testObject.ReadResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ReadResourcesTag),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void UpdateResources_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateTemplateXML();

            // Act
            var result = _testObject.UpdateResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(UpdateResourcesTag),
                () => _resourceUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void CalculateResourceAvailabilities_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            _testObject.CalculateResourceAvailabilities(DummyInt);

            // Assert
            _availabilitiesCalculated.ShouldBeTrue();
        }

        [TestMethod]
        public void GetRequestedResources_WhenRootNotFound_ThrowException()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXDocument.ParseString = _ => new ShimXDocument();
            ShimXDocument.AllInstances.RootGet = _ => null;

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(RootElementNotFound);
        }

        [TestMethod]
        public void GetRequestedResources_WhenDataElementNotFound_ThrowException()
        {
            // Arrange
            var xmlString = @"
                     <root>
                        <Resource />
                     </root>";

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(DataElementNotFound);
        }

        [TestMethod]
        public void GetRequestedResources_WhenResourceElementNotFound_ThrowException()
        {
            // Arrange
            var xmlString = @"
                     <root>
                        <Data />
                     </root>";

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ResourceNotFound);
        }

        [TestMethod]
        public void GetRequestedResources_WhenIdIsNull_ThrowException()
        {
            // Arrange
            var xmlString = $@"
                  <root>
                    <Data>
                        <Resource>
                            <Field Id='{DummyInt}'></Field>
                        </Resource>
                    </Data>
                   </root>";

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(IdIsNull);
        }

        [TestMethod]
        public void GetRequestedResources_WhenNoDataId_ThrowException()
        {
            // Arrange
            var xmlString = $@"
                  <root>
                    <Data>
                        <Resource Id='{DummyInt}' ExtId='{DummyInt}' Username='{DummyString}'>
                            <Field Id='{DummyInt}'></Field>
                        </Resource>
                    </Data>
                   </root>";

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(DataIdNotFound);
        }

        [TestMethod]
        public void GetRequestedResources_WhenDataIdIsNull_ThrowException()
        {
            // Arrange
            var xmlString = $@"
                  <root>
                    <Data>
                        <Resource Id='{DummyInt}' ExtId='{DummyInt}' Username='{DummyString}' DataId=''>
                            <Field Id='{DummyInt}'></Field>
                        </Resource>
                    </Data>
                   </root>";

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(DataIdIsNull);
        }

        [TestMethod]
        public void GetRequestedResources_WhenDuplicatedDataId_ThrowException()
        {
            // Arrange
            var xmlString = $@"
                  <root>
                    <Data>
                        <Resource Id='{DummyInt}' ExtId='{DummyInt}' Username='{DummyString}' DataId='{DummyInt}'>
                            <Field Id='{DummyInt}'></Field>
                        </Resource>
                        <Resource Id='{DummyInt}' ExtId='{DummyInt}' Username='{DummyString}' DataId='{DummyInt}'>
                            <Field Id='{DummyInt}'></Field>
                        </Resource>
                    </Data>
                   </root>";

            // Act
            Action action = () => _privateObject.Invoke(GetRequestedResourcesMethod, xmlString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(DuplicateDataId);
        }

        [TestMethod]
        public void UpdateResources_WhenPFEException_ReturnError()
        {
            // Arrange
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.UpdateResources(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void UpdateResources_WhenException_ReturnError()
        {
            // Arrange
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.UpdateResources(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        [TestMethod]
        public void ReadResources_WhenPFEException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.ReadResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void ReadResources_WhenException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.ReadResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        [TestMethod]
        public void ReadResourcePermissionGroups_WhenPFEException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.ReadResourcePermissionGroups(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void ReadResourcePermissionGroups_WhenException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.ReadResourcePermissionGroups(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        [TestMethod]
        public void ReadResourceCostCategoryRole_WhenPFEException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.ReadResourceCostCategoryRole(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void ReadResourceCostCategoryRole_WhenException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.ReadResourceCostCategoryRole(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        [TestMethod]
        public void ReadPermissionGroups_WhenPFEException_ReturnError()
        {
            // Arrange
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.ReadPermissionGroups();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void ReadPermissionGroups_WhenException_ReturnError()
        {
            // Arrange
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.ReadPermissionGroups();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        [TestMethod]
        public void DeleteResources_WhenPFEException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.DeleteResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void DeleteResources_WhenException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.DeleteResources(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        [TestMethod]
        public void DeleteResourceCheck_WhenPFEException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new PFEException(DummyInt, DummyString); };

            // Act
            var result = _testObject.DeleteResourceCheck(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureTrue));
        }

        [TestMethod]
        public void DeleteResourceCheck_WhenException_ReturnError()
        {
            // Arrange
            var xmlString = CreateTemplateXML();
            ShimXElement.ConstructorXName = (_, __) => { throw new Exception(DummyString); };

            // Act
            var result = _testObject.DeleteResourceCheck(xmlString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(ErrorIdTag),
                () => result.ShouldContain(PfEFailureFalse));
        }

        private string CreateTemplateXML()
        {
            var xmlString = $@"
                <root>
                    <Data>
                        <Resource Id='{DummyInt}' ExtId='{DummyInt}' Username='{DummyString}' DataId='{DummyInt}'>
                            <Field Id='{DummyInt}'></Field>
                        </Resource>
                    </Data>
                </root>";

            return xmlString;
        }

        private void SetupShims()
        {
            ShimSPWeb.AllInstances.Dispose = (_) => { };
            ShimSPWeb.AllInstances.CurrentUserGet = (_) => new ShimSPUser();
            ShimSPWeb.AllInstances.UsersGet = (_) =>
            {
                ShimSPUserCollection users = new ShimSPUserCollection();
                users.CountGet = () => 0;
                return users;
            };

            ShimBaseManager.ConstructorSPWeb = (_, __) => { };
            ShimBaseManager.AllInstances.WebGet = _ => new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                }
            };

            ShimConfigFunctions.GetCleanUsernameSPWeb = (_) => DummyString;

            ShimExtensionMethods.GetExtIdSPUserSPWeb = (_, __) => DummyInt;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) => { action(); };

            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimResources.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => new ShimResources();
            ShimResources.AllInstances.BuildResourceDataRow = (_, __) => new ShimResource();
            ShimResources.AllInstances.CanDeleteResourceStringOut = (Resources _, Resource __, out string message) =>
            {
                message = DummyString;
                return "YES";
            };
            ShimResources.AllInstances.DeleteResourceInt32 = (_, __, ___) => _resourceDeleted = true;
            ShimResources.AllInstances.GetResourceCostCategoryRoleNullableOfInt32StringString = (_, _1, _2, _3) => 
                new ShimRole
                {
                    IdGet = () => DummyInt,
                    CostCategoryRoleIdGet = () => DummyInt,
                    NameGet = () => DummyString
                };
            var groupList = new List<Group>
            {
                new Group
                {
                    Id = DummyInt,
                    Description = DummyString,
                    Name = DummyString
                }
            };
            ShimResources.AllInstances.GetPermissionGroups = _ => groupList;
            ShimResources.AllInstances.GetResourcePermissionGroupsNullableOfInt32StringString = (_, _1, _2, _3) => groupList;
            ShimResources.AllInstances.FindResourceNullableOfInt32StringString = (_, _1, _2, _3) =>
                new ShimResource
                {
                    IdGet = () => DummyInt,
                    CustomFieldsGet = () => new List<IField>
                    {
                        new CodeField(DummyInt, DummyString),
                        new MultiValueCodeField(DummyInt, DummyString),
                        new TextField(DummyInt, DummyString)
                    }
                };
            ShimResources.AllInstances.UpdateResourceResource = (_, __) =>
            {
                _resourceUpdated = true;
                return DummyInt;
            };

            ShimCodeField.AllInstances.GetCode = _ => DummyInt;
            ShimCodeField.AllInstances.GetValue = _ => DummyString;

            ShimMultiValueCodeField.AllInstances.GetValue = _ => new Dictionary<int, string> { [DummyInt] = DummyString };

            ShimTextField.AllInstances.GetValue = _ => DummyString;


            ShimResource.AllInstances.IdGet = _ => DummyInt;
            ShimResource.AllInstances.ExternalUIdGet = _ => DummyString;
            ShimResource.AllInstances.NTAccountGet = _ => DummyString;
            ShimResource.AllInstances.PermissionsDictionaryGet = _ => new Dictionary<int, string> { [DummyInt] = DummyString };

            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;

            ShimAdminFunctions.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdminFunctions();
            ShimAdminFunctions.AllInstances.CalcResourceRateInt32 = (_, __) => DummyDecimal;
            ShimAdminFunctions.AllInstances.CalcAvailabilitiesInt32String = (_, _1, _2) => _availabilitiesCalculated = true;
        }
    }
}
