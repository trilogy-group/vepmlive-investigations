using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLive.TestFakes.Utility;
using EPMLiveEnterprise;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLive.TestFakes.Utility.AdoShims;

namespace EPMLivePS.Tests.HelperClasses
{
    [TestClass]
    public class ProjectWorkspaceSynchTest
    {
        private const string QuerySelectCustomFields01 = "select wssfieldname,editable from customfields where visible = 1 and fieldcategory in (3,4)";
        private const string QuerySelectCustomFields02 = "select * from customfields where wssfieldname=@fieldname";
        private const string QuerySelectCustomFields03 = "select * from customfields where wssfieldname=@fieldname and fieldcategory=3";

        private ProjectWorkspaceSynch _testEntity;
        private PrivateObject _testEntityPrivate;
        private IDisposable _shimsContext;
        private AdoShims _adoShims;
        private ShimSPWeb _shimMyWebToPublish;
        private Dictionary<string, SPList> _listsDictionary;

        [TestInitialize]
        public void TestInitialize()
        {
            _testEntity = new ProjectWorkspaceSynch();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            SetupDefaultShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void ProcessTaskCenter_Always_SelectsValuesFromCustomfields()
        {
            // Arrange & Act
            _testEntity.processTaskCenter();

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsCommandCreated(QuerySelectCustomFields01).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(QuerySelectCustomFields01).ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessTaskCenter_WhenNewFieldsAreFound_FetchesNewFields()
        {
            // Arrange
            const string newFieldName = "NewField";
            const bool newFieldEditable = true;
            const string newFieldTitle = "Title";
            const string newFieldTypeName = "CHOICE";

            var executeReaderHandler = new ExecuteReaderHandler((sqlCommand, dataReader) =>
            {
                if (sqlCommand.CommandText.Equals(QuerySelectCustomFields01))
                {
                    ShimQuerySelectCustomFields01Reader(dataReader, newFieldName, newFieldEditable);
                }
                else if (sqlCommand.CommandText.Equals(QuerySelectCustomFields02))
                {
                    ShimQuerySelectCustomFields02Reader(dataReader, newFieldTitle, newFieldTypeName);
                }
                else if (sqlCommand.CommandText.Equals(QuerySelectCustomFields03))
                {
                    ShimQuerySelectCustomFields03Reader(dataReader);
                }
            });

            _adoShims.ExecuteReaderCalled += executeReaderHandler;

            // Act
            _testEntity.processTaskCenter();

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsCommandCreated(QuerySelectCustomFields02).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(QuerySelectCustomFields02).ShouldBeTrue(),
                () => _adoShims.IsCommandCreated(QuerySelectCustomFields03).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(QuerySelectCustomFields03).ShouldBeTrue());
        }

        private void ShimQuerySelectCustomFields03Reader(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        private void ShimQuerySelectCustomFields01Reader(SqlDataReader dataReader, string fieldName, bool editable)
        {
            var readCount = 0;
            var shimDataReader = new ShimSqlDataReader(dataReader)
            {
                Read = () => ++readCount == 1,
                GetStringInt32 = (index) => index == 0 ? fieldName : null,
                GetBooleanInt32 = index => index == 1 && editable
            };
        }

        private void ShimQuerySelectCustomFields02Reader(SqlDataReader dataReader, string fieldTitle, string fieldTypeName)
        {
            var readCount = 0;
            var shimDataReader = new ShimSqlDataReader(dataReader)
            {
                Read = () => ++readCount == 1,
                GetStringInt32 = (index) =>
                {
                    switch (index)
                    {
                        case 2:
                            return fieldTitle;
                        case 7:
                            return fieldTypeName;
                        default:
                            return null;
                    }
                }
            };
        }
        
        private void SetupDefaultShims()
        {
            var shimFeatures = CreateShimSpFeatureCollection();
            var shimFields = CreateShimSpFieldCollection();
            var shimLists = CreateShimSpListCollection(shimFields);

            _shimMyWebToPublish = new ShimSPWeb();
            _shimMyWebToPublish.FeaturesGet = () => shimFeatures.Instance;
            _shimMyWebToPublish.ListsGet = () => shimLists.Instance;
            _testEntityPrivate.SetField("myWebToPublish", _shimMyWebToPublish.Instance);
        }

        private ShimSPListCollection CreateShimSpListCollection(ShimSPFieldCollection shimFields)
        {
            _listsDictionary = new Dictionary<string, SPList>();
            var shimLists = new ShimSPListCollection();
            shimLists.ItemGetString = listName => _listsDictionary[listName];
            shimLists.TryGetListString = listName => _listsDictionary.ContainsKey(listName)
                ? _listsDictionary[listName]
                : null;

            var shimSpList = new ShimSPList();
            shimSpList.FieldsGet = () => shimFields.Instance;
            _listsDictionary.Add("Task Center", shimSpList.Instance);

            return shimLists;
        }

        private ShimSPFieldCollection CreateShimSpFieldCollection()
        {
            var fieldsDictionary = new Dictionary<string, SPField>();
            var shimFields = new ShimSPFieldCollection();
            shimFields.ContainsFieldString = fieldName => fieldsDictionary.ContainsKey(fieldName);
            shimFields.ItemGetString = fieldName => fieldsDictionary[fieldName];
            shimFields.AddSPField = spField =>
            {
                fieldsDictionary.Add(spField.TypeDisplayName, spField);
                return spField.TypeDisplayName;
            };
            shimFields.AddStringSPFieldTypeBoolean = (displayName, fieldType, required) =>
            {
                var spField = CreateSpField(displayName, fieldType, fieldsDictionary.Count);
                fieldsDictionary.Add(displayName, spField);

                return displayName;
            };
            shimFields.CreateNewFieldStringString = (typeName, displayName) =>
            {
                SPField spField;

                if (typeName == SPFieldType.Text.ToString())
                {
                    var spFieldText = new ShimSPFieldText();
                    spField = CreateSpField(displayName, SPFieldType.Text, fieldsDictionary.Count, spFieldText.Instance);
                }
                else
                {
                    spField = CreateSpField(displayName, SPFieldType.Invalid, fieldsDictionary.Count);
                }

                return spField;
            };

            var shimBaseCollection = new ShimSPBaseCollection(shimFields.Instance);
            shimBaseCollection.GetEnumerator = () => fieldsDictionary.Values.ToList().GetEnumerator();

            return shimFields;
        }

        private static SPField CreateSpField(string displayName, SPFieldType fieldType, int fieldNumber, SPField spFieldBase = null)
        {
            var requiredField = false;
            var hiddenField = false;
            var defaultValueField = default(string);
            var showInEditFormField = default(bool?);
            var showInNewForm = default(bool?);
            var spFieldTypeField = fieldType;

            var shimSpField = spFieldBase == null
                ? new ShimSPField()
                : new ShimSPField(spFieldBase);
            shimSpField.TypeDisplayNameGet = () => displayName;
            shimSpField.InternalNameGet = () => $"Int{fieldNumber}";
            shimSpField.RequiredGet = () => requiredField;
            shimSpField.RequiredSetBoolean = arg => requiredField = arg;
            shimSpField.HiddenGet = () => hiddenField;
            shimSpField.HiddenSetBoolean = arg => hiddenField = arg;
            shimSpField.TypeGet = () => spFieldTypeField;
            shimSpField.TypeSetSPFieldType = arg => spFieldTypeField = arg;
            shimSpField.DefaultValueGet = () => defaultValueField;
            shimSpField.DefaultValueSetString = arg => defaultValueField = arg;
            shimSpField.ShowInEditFormGet = () => showInEditFormField;
            shimSpField.ShowInEditFormSetNullableOfBoolean = arg => showInEditFormField = arg;
            shimSpField.ShowInNewFormGet = () => showInNewForm;
            shimSpField.ShowInNewFormSetNullableOfBoolean = arg => showInNewForm = arg;

            var spField = shimSpField.Instance;
            return spField;
        }

        private ShimSPFeatureCollection CreateShimSpFeatureCollection()
        {
            var featuresDictionary = new Dictionary<Guid, SPFeature>();
            var shimFeatures = new ShimSPFeatureCollection();
            shimFeatures.AddGuid = featureId =>
            {
                var shimFeature = new ShimSPFeature();
                featuresDictionary.Add(featureId, shimFeature.Instance);

                return shimFeature.Instance;
            };
            shimFeatures.ItemGetGuid = featureId => featuresDictionary.ContainsKey(featureId)
                ? featuresDictionary[featureId]
                : null;

            return shimFeatures;
        }
    }
}
