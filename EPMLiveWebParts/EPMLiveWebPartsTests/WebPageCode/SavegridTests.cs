using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SavegridTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string MethodGetParams = "getParams";
        private savegrid _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private object _objectAddedToList;
        private string _contentType;
        private StringWriter _responseWriter;
        private bool _allowUnsafeUpdates;
        private ShimSPWeb _shimSpWeb;
        private string _fieldValue;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new savegrid();
            _privateObject = new PrivateObject(_testObject);

            _objectAddedToList = null;
            _contentType = string.Empty;
            _fieldValue = string.Empty;
            _responseWriter = new StringWriter();
            _allowUnsafeUpdates = false;

            Shimgetgriditems.AllInstances.getParamsSPWeb = (_, __) => { };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            _shimSpWeb = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                AllowUnsafeUpdatesSetBoolean = allow => _allowUnsafeUpdates = allow
            };
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection
            {
                ItemGetString = __ => new ShimSPUser
                {
                    IDGet = () => 2,
                    NameGet = () => DummyString
                }
            }.Instance;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _responseWriter?.Dispose();
        }

        [TestMethod]
        public void GetParams_Calculated_SetsNullObjectToList()
        {
            // Arrange
            _fieldValue = DummyString;
            PrepareForProcessItem(SPFieldType.Calculated);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBeNull();
        }

        [TestMethod]
        public void GetParams_UserMulti_SetsUsersToList()
        {
            // Arrange
            _fieldValue = "1\nDummy\nId\nDummy";
            PrepareForProcessItem(SPFieldType.User, "UserMulti");

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            var userValueCollection = _objectAddedToList as SPFieldUserValueCollection;
            userValueCollection.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => userValueCollection[0].LookupValue.ShouldBe("Dummy"),
                () => userValueCollection[1].LookupValue.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetParams_User_SetsUsersToList()
        {
            // Arrange
            _fieldValue = "1\nDummy\nId\nDummy";
            PrepareForProcessItem(SPFieldType.User);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            var userValueCollection = _objectAddedToList as SPFieldUserValue;
            userValueCollection.ShouldNotBeNull();
            userValueCollection.LookupValue.ShouldBe("Dummy");
        }

        [TestMethod]
        public void GetParams_UserIdNotInt_SetsUsersToList()
        {
            // Arrange
            _fieldValue = "Id\nDummy\n1\nDummy";
            PrepareForProcessItem(SPFieldType.User);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            var userValueCollection = _objectAddedToList as SPFieldUserValue;
            userValueCollection.ShouldNotBeNull();
            userValueCollection.LookupValue.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetParams_Number_SetsNumberToList()
        {
            // Arrange
            _fieldValue = "20%";
            PrepareForProcessItem(SPFieldType.Number);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _objectAddedToList.ShouldNotBeNull(),
                () => _objectAddedToList.ShouldBe(0.2));
        }

        [TestMethod]
        public void GetParams_NumberInvalid_SetsNullObjectToList()
        {
            // Arrange
            _fieldValue = "Dummy%";
            PrepareForProcessItem(SPFieldType.Number);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBeNull();
        }

        [TestMethod]
        public void GetParams_Lookup_SetsSemiColonSeparatedValueToList()
        {
            // Arrange
            _fieldValue = $"{DummyString}\n{DummyString}";
            PrepareForProcessItem(SPFieldType.Lookup);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            var result = _objectAddedToList as string;
            result.ShouldNotBeNull();
            var choices = result.Split(';');
            this.ShouldSatisfyAllConditions(
                () => choices.Length.ShouldBe(2),
                () => choices[0].ShouldBe(DummyString),
                () => choices[1].ShouldBe($"#{DummyString}"));
        }

        [TestMethod]
        public void GetParams_Choice_SetsChoiceToList()
        {
            // Arrange
            _fieldValue = $"{DummyString};#Dummy";
            PrepareForProcessItem(SPFieldType.Choice);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetParams_MultiChoice_SetsChoiceToList()
        {
            // Arrange
            _fieldValue = $"{DummyString}\nDummy";
            PrepareForProcessItem(SPFieldType.MultiChoice);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBe($";#{DummyString};#Dummy;#");
        }

        [TestMethod]
        public void GetParams_Url_DoesntSetObjectToList()
        {
            // Arrange
            _fieldValue = DummyString;
            PrepareForProcessItem(SPFieldType.URL);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBeNull();
        }

        [TestMethod]
        public void GetParams_DateTime_SetsDateTimeToList()
        {
            // Arrange
            var date = DateTime.Today;
            _fieldValue = date.ToString();
            PrepareForProcessItem(SPFieldType.DateTime);

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBe(date);
        }

        [TestMethod]
        public void GetParams_ContentType_SetsContenTypeToList()
        {
            // Arrange
            _fieldValue = $"{DummyString};#{DummyString}";
            PrepareForProcessItem(SPFieldType.ContentTypeId, "ContentType");

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetParams_FilteredLookup_SetsSemiColonSeparatedValueToList()
        {
            // Arrange
            _fieldValue = $"{DummyString}\n{DummyString}";
            PrepareForProcessItem(SPFieldType.Text, "FilteredLookup");

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            var result = _objectAddedToList as string;
            result.ShouldNotBeNull();
            var choices = result.Split(';');
            this.ShouldSatisfyAllConditions(
                () => choices.Length.ShouldBe(2),
                () => choices[0].ShouldBe(DummyString),
                () => choices[1].ShouldBe($"#{DummyString}"));
        }

        [TestMethod]
        public void GetParams_Text_SetsTextToList()
        {
            // Arrange
            _fieldValue = $"{DummyString}\n{DummyString}";
            PrepareForProcessItem(SPFieldType.Text, "Text");

            // Act
            _testObject.getParams(_shimSpWeb.Instance);

            // Assert
            _objectAddedToList.ShouldBe(_fieldValue);
        }

        private void PrepareForProcessItem(SPFieldType fieldType, string typeAsString = "User")
        {
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();

            var field = new ShimSPField
            {
                RequiredGet = () => true,
                ReadOnlyFieldGet = () => false,
                ShowInEditFormGet = () => true,
                TypeGet = () => fieldType,
                TypeAsStringGet = () => typeAsString,
                InternalNameGet = () => typeAsString,
                SchemaXmlGet = () => "Percentage=\"TRUE\""
            };
            var fieldCollection = new ShimSPFieldCollection
            {
                ContainsFieldString = y => true,
                GetFieldByInternalNameString = y => field
            };
            var listItem = new ShimSPListItem
            {
                IDGet = () => Id,
                ItemSetGuidObject = (_, item) => _objectAddedToList = item,
                ItemSetStringObject = (_, item) => _objectAddedToList = item
            };
            var list = new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                GetItemByIdInt32 = y => null,
                ItemsGet = () => new ShimSPListItemCollection
                {
                    Add = () => listItem
                },
                FieldsGet = () => fieldCollection,
                ParentWebGet = () => _shimSpWeb
            };
            listItem.ParentListGet = () => list;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb
                    {
                IDGet = () => Guid.NewGuid(),
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = x => list
                }
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = key =>
                {
                    if (key.Contains("_status"))
                    {
                        //return "deleted";
                    }
                    else if (key.Equals("columns"))
                    {
                        return Convert.ToBase64String(Encoding.ASCII.GetBytes(DummyString));
                    }
                    else if (key.Equals("1_c0") || key.Equals("1_c1"))
                    {
                        return _fieldValue;
                    }
                    else if (key.Contains("_itemid"))
                    {
                        return One;
                    }
                    else if (key.Contains("_webid") || key.Contains("_listid") || key.Contains("_siteid"))
                    {
                        return Guid.NewGuid().ToString();
                    }

                    return One;
                }
            };
            ShimPage.AllInstances.ResponseGet = _ => new HttpResponse(_responseWriter);
        }
    }
}
