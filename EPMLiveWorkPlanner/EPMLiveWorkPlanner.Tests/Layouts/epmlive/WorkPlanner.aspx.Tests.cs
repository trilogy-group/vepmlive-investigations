using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Layouts.epmlive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class WorkPlannerTests
    {
        private WorkPlanner testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private ShimSPWeb spWeb;
        private ShimSPList spList;
        private ShimSPField spField;
        private const string DummyString = "DummyString";
        private const string OnInitMethodName = "OnInit";
        private const string GetFieldsMethodName = "getFields";
        private const string GetAttachedListsMethodName = "getAttachedLists";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new WorkPlanner();
            privateObject = new PrivateObject(testObject);

            privateObject.Invoke(
                OnInitMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { EventArgs.Empty });
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest()
            {
                ItemGetString = input =>
                {
                    if (input == "debug")
                    {
                        return "False";
                    }
                    return string.Empty;
                }
            };
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
        }

        private void SetupVariables()
        {
            spField = new ShimSPField();

            spList = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => spField
                }
            };

            spWeb = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = _ => spList
                }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetFields_WhenCalled_GetsData()
        {
            // Arrange
            const string schemaXml = @"<Default>Default</Default>";

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.User,
                    InternalNameGet = () => "User"
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Attachments,
                    InternalNameGet = () => "Attachment",
                    ReadOnlyFieldGet = () => false,
                    SchemaXmlGet = () => schemaXml
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Number,
                    InternalNameGet = () => "StartDate",
                    ReadOnlyFieldGet = () => false,
                    HiddenGet = () => false,
                    ReorderableGet = () => true,
                    SchemaXmlGet = () => schemaXml
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Boolean,
                    InternalNameGet = () => "DueDate",
                    ReadOnlyFieldGet = () => false,
                    HiddenGet = () => false,
                    ReorderableGet = () => true,
                    SchemaXmlGet = () => schemaXml
                }
            }.GetEnumerator();

            spField.InternalNameGet = () => DummyString;

            privateObject.SetFieldOrProperty("sTaskUserFields", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sDefaults", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sProjectUserFields", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);

            // Act
            privateObject.Invoke(
                GetFieldsMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { spWeb.Instance });

            // Assert
            var taskUserFields = privateObject.GetFieldOrProperty("sTaskUserFields", BindingFlags.Instance | BindingFlags.NonPublic);
            var defaults = privateObject.GetFieldOrProperty("sDefaults", BindingFlags.Instance | BindingFlags.NonPublic);
            var projectUserFields = privateObject.GetFieldOrProperty("sProjectUserFields", BindingFlags.Instance | BindingFlags.NonPublic);
            var baselineFields = privateObject.GetFieldOrProperty("sBaselineFields", BindingFlags.Instance | BindingFlags.NonPublic);

            taskUserFields.ShouldSatisfyAllConditions(
                () => taskUserFields.ShouldBe($"{DummyString},'User'"),
                () => defaults.ShouldBe($"{DummyString}Attachment:\"Default\",StartDate:\"Default\",DueDate:\"Default\""),
                () => projectUserFields.ShouldBe($"{DummyString},'User'"),
                () => baselineFields.ShouldBe($"StartDate:\"{DummyString}\",DueDate:\"{DummyString}\""));
        }

        [TestMethod]
        public void GetAttachedLists_WhenCalled_GetsAttachedLists()
        {
            // Arrange
            const string listid = "listid";

            var title = $"Not{DummyString}";
            var schemaXml = string.Format(@"<Child List=""{0}""/>", listid);
            var getEnumeratorCount = 0;

            spList.HiddenGet = () => false;
            spList.TitleGet = () => title;
            spList.BaseTypeGet = () => (SPBaseType)1;
            spField.TypeGet = () => SPFieldType.Lookup;
            spField.SchemaXmlGet = () => schemaXml;
            spField.InternalNameGet = () => DummyString;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ =>
            {
                getEnumeratorCount = getEnumeratorCount + 1;
                if (getEnumeratorCount == 1)
                {
                    return new List<SPList>()
                    {
                        spList
                    }.GetEnumerator();
                }
                return new List<SPField>()
                    {
                        spField
                    }.GetEnumerator();
            };

            privateObject.SetFieldOrProperty("sListProjectCenter", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sListTaskCenter", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sAttachedDocLibs", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sAttachedLists", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);

            // Act
            privateObject.Invoke(
                GetAttachedListsMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { spWeb.Instance, listid });

            // Assert
            var docLibs = privateObject.GetFieldOrProperty("sAttachedDocLibs", BindingFlags.Instance | BindingFlags.NonPublic);
            var lists = privateObject.GetFieldOrProperty("sAttachedLists", BindingFlags.Instance | BindingFlags.NonPublic);

            docLibs.ShouldSatisfyAllConditions(
                () => docLibs.ShouldBe(DummyString),
                () => lists.ShouldBe(DummyString));
        }
    }
}
