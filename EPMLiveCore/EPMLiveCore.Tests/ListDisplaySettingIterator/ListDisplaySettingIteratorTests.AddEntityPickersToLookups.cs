using System;
using System.Collections.Generic;
using EPMLiveCore.Fakes;
using EPMLiveCore.Tests.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    public partial class ListDisplaySettingIteratorTests
    {
        private const string AddEntityPickersToLookupsMethod = "AddEntityPickersToLookups";
        private const string ModeField = "mode";

        [TestMethod]        
        public void AddEntityPickersToLookups_Should_Return()
        {
            // Arrange
            // CustomPropertySetString should not be called
            // If so, there will be excepiton 

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Asset
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_Mode_New_Should_Return()
        {
            // Arrange
            // CustomPropertySetString should not be called
            // If so, there will be excepiton 

            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_isParent()
        {
            // Arrange
            var expected = string.Empty;
            ArrangeAddEntityPickersToLookups(true, false);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Edit);
            ShimCascadingLookupRenderControl.AllInstances.CustomPropertySetString = (control, value) =>
            {
                expected = value;
            };

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Assert
            expected.ShouldBe(Resources.AddEntityPickersToLookups_With_isParent_Expected);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_isParent_isEnhance_Type2()
        {
            // Arrange
            ArrangeAddEntityPickersToLookups(true, true);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetFieldDataString = (a, b) => new ShimLookupConfigData();
            ShimLookupConfigData.AllInstances.TypeGet = _ => "2";
            var expected = string.Empty;
            ShimEntityEditor.AllInstances.CustomPropertySetString = (control, value) =>
            {
                expected = value;
            };

            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);
            

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Assert
            expected.ShouldBe(Resources.AddEntityPickersToLookups_With_isParent_isEnhance_Type2_Expected);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_isParent_isEnhance_Type1()
        {
            // Arrange
            ArrangeAddEntityPickersToLookups(true, true);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetFieldDataString = (a, b) => new ShimLookupConfigData();
            ShimLookupConfigData.AllInstances.TypeGet = _ => "1";

            var expected = string.Empty;
            ShimCascadingLookupRenderControl.AllInstances.CustomPropertySetString = (control, value) =>
            {
                expected = value;
            };

            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Assert
            expected.ShouldBe(Resources.AddEntityPickersToLookups_With_isParent_isEnhance_Type1_Expected);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_isEnhance_Type2()
        {
            // Arrange
            ArrangeAddEntityPickersToLookups(false, true);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetFieldDataString = (a, b) => new ShimLookupConfigData();
            ShimLookupConfigData.AllInstances.TypeGet = _ => "2";
            var expected = string.Empty;
            ShimEntityEditor.AllInstances.CustomPropertySetString = (control, value) =>
            {
                expected = value;
            };

            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);


            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Assert
            expected.ShouldBe(Resources.AddEntityPickersToLookups_With_isEnhance_Type2_Expected);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_isEnhance_Type1()
        {
            // Arrange
            ArrangeAddEntityPickersToLookups(false, true);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetFieldDataString = (a, b) => new ShimLookupConfigData();
            ShimLookupConfigData.AllInstances.TypeGet = _ => "1";

            var expected = string.Empty;
            ShimCascadingLookupRenderControl.Constructor = _ => { };
            ShimCascadingLookupRenderControl.AllInstances.CustomPropertySetString = (control, value) =>
            {
                expected = value;
            };

            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod,  new object[] { });

            // Assert
            expected.ShouldBe(Resources.AddEntityPickersToLookups_With_isEnhance_Type1_Expected);
        }

        [TestMethod]
        public void AddEntityPickersToLookups_With_isEnhance_Type1_Not_AllowMultipleValues()
        {
            // Arrange
            ArrangeAddEntityPickersToLookups(false, true);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetFieldDataString = (a, b) => new ShimLookupConfigData();
            ShimLookupConfigData.AllInstances.TypeGet = _ => "1";
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;

            var expected = string.Empty;
            ShimCascadingMultiLookupRenderControl.AllInstances.CustomPropertySetString = (control, value) =>
            {
                expected = value;
            };

            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act
            _privateObject.Invoke(AddEntityPickersToLookupsMethod, new object[] { });

            // Assert
            expected.ShouldBe(Resources.AddEntityPickersToLookups_With_isEnhance_Type1_Not_AllowMultipleValues_Expected);
        }

        private void ArrangeAddEntityPickersToLookups(bool isParent,bool isEnhanced)
        {
            ShimEnhancedLookupConfigValuesHelper.ConstructorString = (a, b) => { };
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (a, b) => isEnhanced;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (a, b) => isParent;

            ShimListDisplaySettingIterator.GetFieldLookupFormField = _ => new ShimSPFieldLookup();
            ShimListDisplaySettingIterator.AllInstances.GenerateControlDataForLookupFieldFormFieldBoolean = (a, b, c) => "param";
            ShimListDisplaySettingIterator.AllInstances.GetQueryStringLookupValFormField = (a, b) => new SPFieldLookupValueCollection { new ShimSPFieldLookupValue().Instance };
            ShimListFieldIteratorExtensions.GetFormFieldByTypeListFieldIteratorType = (a, b) => new List<FormField> { new ShimFormField().Instance };

            ShimSPFieldLookup.AllInstances.LookupWebIdGet = _ => Guid.Empty;
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => "lookUpList";
            ShimSPFieldLookup.AllInstances.LookupFieldGet = _ => "lookUpField";

            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();

            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();

            ShimSPWeb.AllInstances.IDGet = _ => Guid.Empty;

            ShimGenericEntityEditor.Constructor = _ => { };
            ShimEntityEditor.AllInstances.UpdateEntitiesArrayList = (a, b) => { };

            ShimCascadingLookupRenderControl.AllInstances.CustomPropertySetString = (control, value) =>
            {
                throw new InvalidOperationException();
            };

            ShimCascadingMultiLookupRenderControl.AllInstances.CustomPropertySetString = (control, value) =>
            {
                throw new InvalidOperationException();
            };

            ShimEntityEditor.AllInstances.CustomPropertySetString = (control, value) =>
            {
                throw new InvalidOperationException();
            };
        }
    }
}
