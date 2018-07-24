using System;
using EPMLiveCore.Fakes;
using EPMLiveCore.Tests.Shared;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class ControlDataBuilderTest
    {
        private IDisposable _shimsContext;
        private ControlDataBuilder _controlDataBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _controlDataBuilder = new ControlDataBuilder();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void AddParameter_NewKey_ParameterAdded()
        {
            // Arrange
            const string newKey = "test-key";
            object newValue = 1;

            // Act
            _controlDataBuilder.AddParameter(newKey, newValue);

            // Assert
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey(newKey));
            Assert.AreEqual(newValue.ToString(), _controlDataBuilder.Parameters[newKey]);
        }

        [TestMethod]
        public void AddParameter_ExistingKey_Throws()
        {
            // Arrange
            const string newKey = "test-key";
            object newValue = 1;
            
            // Act
            _controlDataBuilder.AddParameter(newKey, newValue);
            Action action = () => _controlDataBuilder.AddParameter(newKey, newValue);

            // Assert
            AssertException.Throws<ArgumentException>(action);
        }

        [TestMethod]
        public void AddParametersForLookupField_FieldNull_Throws()
        {
            // Arrange
            // Act
            Action action = () => _controlDataBuilder.AddParametersForLookupField(null);

            // Assert
            AssertException.Throws<ArgumentNullException>(action);
        }

        [TestMethod]
        public void AddParametersForLookupField_FieldOk_AddsExpectedParameters()
        {
            // Arrange
            var parentWebIdExpected = Guid.NewGuid();
            var lookupWebIdExpected = Guid.NewGuid();
            var lookupListExpected = "list-expected";
            var lookupFieldExpected = "field-expected";
            var idExpected = Guid.NewGuid();
            var requiredExpected = true;
            var allowMultipleValuesExpected = true;

            ShimSPField.AllInstances.ParentListGet = (element) => new ShimSPList();
            ShimSPField.AllInstances.IdGet = (element) => idExpected;
            ShimSPField.AllInstances.RequiredGet = (element) => requiredExpected;
            ShimSPList.AllInstances.ParentWebGet = (element) => new ShimSPWeb { IDGet = () => parentWebIdExpected };

            var lookupFieldShim = new ShimSPFieldLookup();
            lookupFieldShim.LookupWebIdGet = () => lookupWebIdExpected;
            lookupFieldShim.LookupListGet = () => lookupListExpected;
            lookupFieldShim.LookupFieldGet = () => lookupFieldExpected;
            lookupFieldShim.AllowMultipleValuesGet = () => allowMultipleValuesExpected;

            // Act
            _controlDataBuilder.AddParametersForLookupField(lookupFieldShim);

            // Assert
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("ParentWebID"));
            Assert.AreEqual(parentWebIdExpected.ToString(), _controlDataBuilder.Parameters["ParentWebID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("LookupWebID"));
            Assert.AreEqual(lookupWebIdExpected.ToString(), _controlDataBuilder.Parameters["LookupWebID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("LookupListID"));
            Assert.AreEqual(lookupListExpected.ToString(), _controlDataBuilder.Parameters["LookupListID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("LookupFieldInternalName"));
            Assert.AreEqual(lookupFieldExpected.ToString(), _controlDataBuilder.Parameters["LookupFieldInternalName"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("LookupFieldID"));
            Assert.AreEqual(idExpected.ToString(), _controlDataBuilder.Parameters["LookupFieldID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("IsMultiSelect"));
            Assert.AreEqual(allowMultipleValuesExpected.ToString(), _controlDataBuilder.Parameters["IsMultiSelect"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("Required"));
            Assert.AreEqual(requiredExpected.ToString(), _controlDataBuilder.Parameters["Required"]);
        }

        [TestMethod]
        public void AddParametersForField_FieldNull_Throws()
        {
            // Arrange
            // Act
            Action action = () => _controlDataBuilder.AddParametersForField(null, true);

            // Assert
            AssertException.Throws<ArgumentNullException>(action);
        }

        [TestMethod]
        public void AddParametersForField_FieldOkAllowMultipleValues_AddsExpectedParameters()
        {
            // Arrange
            const string internalNameExpected = "test-internal-name";
            var idExpected = Guid.NewGuid();
            var prefixExpected = internalNameExpected + "_" + idExpected;

            var fieldShim = new ShimSPField();
            fieldShim.InternalNameGet = () => internalNameExpected;
            fieldShim.IdGet = () => idExpected;

            // Act
            _controlDataBuilder.AddParametersForField(fieldShim, true);

            // Assert
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("SelectCandidateID"));
            Assert.AreEqual(prefixExpected + "_SelectCandidate", _controlDataBuilder.Parameters["SelectCandidateID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("AddButtonID"));
            Assert.AreEqual(prefixExpected + "_AddButton", _controlDataBuilder.Parameters["AddButtonID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("RemoveButtonID"));
            Assert.AreEqual(prefixExpected + "_RemoveButton", _controlDataBuilder.Parameters["RemoveButtonID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("SelectResultID"));
            Assert.AreEqual(prefixExpected + "_SelectResult", _controlDataBuilder.Parameters["SelectResultID"]);
        }

        [TestMethod]
        public void AddParametersForField_FieldOkNotAllowMultiple_AddsExpectedParameters()
        {
            // Arrange
            const string internalNameExpected = "test-internal-name";
            var idExpected = Guid.NewGuid();
            var prefixExpected = internalNameExpected + "_" + idExpected + "_$";

            var fieldShim = new ShimSPField();
            fieldShim.InternalNameGet = () => internalNameExpected;
            fieldShim.IdGet = () => idExpected;
            fieldShim.FieldRenderingControlGet = () => new ShimBusinessDataFieldControl();

            // Act
            _controlDataBuilder.AddParametersForField(fieldShim, false);

            // Assert
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("SourceDropDownID"));
            Assert.AreEqual(prefixExpected + typeof(BusinessDataFieldControl).Name, _controlDataBuilder.Parameters["SourceDropDownID"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("SourceControlID"));
            Assert.AreEqual(prefixExpected + typeof(BusinessDataFieldControl).Name, _controlDataBuilder.Parameters["SourceControlID"]);
        }

        [TestMethod]
        public void AddParametersForLookupData_FieldNull_Throws()
        {
            // Arrange
            // Act
            Action action = () => _controlDataBuilder.AddParametersForLookupData(null);

            // Assert
            AssertException.Throws<ArgumentNullException>(action);
        }

        [TestMethod]
        public void AddParametersForLookupData_FieldOk_AddsExpectedParameters()
        {
            // Arrange
            var fieldExpected = "test-field";
            var typeExpected = "test-type";
            var parentExpected = "test-parent";
            var parentListFieldExpected = "test-parent-list-field";

            var lookupDataShim = new ShimLookupConfigData();

            lookupDataShim.FieldGet = () => fieldExpected;
            lookupDataShim.TypeGet = () => typeExpected;
            lookupDataShim.ParentGet = () => parentExpected;
            lookupDataShim.ParentListFieldGet = () => parentListFieldExpected;

            // Act
            _controlDataBuilder.AddParametersForLookupData(lookupDataShim);

            // Assert
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("Field"));
            Assert.AreEqual(fieldExpected, _controlDataBuilder.Parameters["Field"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("ControlType"));
            Assert.AreEqual(typeExpected, _controlDataBuilder.Parameters["ControlType"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("Parent"));
            Assert.AreEqual(parentExpected, _controlDataBuilder.Parameters["Parent"]);
            Assert.IsTrue(_controlDataBuilder.Parameters.ContainsKey("ParentListField"));
            Assert.AreEqual(parentListFieldExpected, _controlDataBuilder.Parameters["ParentListField"]);
        }

        [TestMethod]
        public void BuildControlData_ParametersExist_BuildsExpectedXml()
        {
            // Arrange

            // Act
            _controlDataBuilder.AddParameter("First", 1);
            _controlDataBuilder.AddParameter("Second", 1.1);
            var result = _controlDataBuilder.BuildControlData();

            // Assert
            Assert.AreEqual("<Data><Param key=\"First\">1</Param><Param key=\"Second\">1.1</Param></Data>", result);
        }
    }
}
