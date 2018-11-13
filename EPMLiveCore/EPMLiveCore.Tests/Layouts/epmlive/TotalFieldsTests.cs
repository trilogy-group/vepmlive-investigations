using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Layouts.epmlive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass]
    public class TotalFieldsTests
    {
        private totalfields totalFields;
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private readonly Panel pnlFields = new Panel();
        private const string PageLoadMethodName = "Page_Load";
        private const string DummyString = "DummyValue";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            totalFields = new totalfields();
            privateObject = new PrivateObject(totalFields);
            privateObject.SetFieldOrProperty("pnlFields", pnlFields);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void PageLoad_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guid => new ShimSPList
                        {
                            FieldsGet = () => GetDummySPFieldCollection()
                        }
                    }
                }
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                QueryStringGet = () => new NameValueCollection
                {
                    ["List"] = Guid.NewGuid().ToString()
                }
            };
            ShimPage.AllInstances.IsPostBackGet = _ => true;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var list = pnlFields.Controls.OfType<DropDownList>().FirstOrDefault();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => pnlFields.Controls.Count.ShouldBeGreaterThan(0),
                () => list.ShouldNotBeNull(),
                () => list.Items.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void PageLoad_IsPostBackFalse_ExecutesCorrectly()
        {
            // Arrange
            var dropDownValue = string.Empty;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guid => new ShimSPList
                        {
                            FieldsGet = () => GetDummySPFieldCollection()
                        }
                    }
                }
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                QueryStringGet = () => new NameValueCollection
                {
                    ["List"] = Guid.NewGuid().ToString()
                }
            };
            ShimPage.AllInstances.IsPostBackGet = _ => false;
            ShimCoreFunctions.getListSettingStringSPList = (setting, list) => $"List|{DummyString}";
            ShimControl.AllInstances.FindControlString = (_, name) => new DropDownList();
            ShimListControl.AllInstances.SelectedValueSetString = (_, value) => dropDownValue = value;
            
            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dropDownValue.ShouldNotBeNullOrEmpty(),
                () => dropDownValue.ShouldBe(DummyString));
        }

        private SPFieldCollection GetDummySPFieldCollection()
        {
            var list = new List<SPField>
            {
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.Text,
                    TitleGet = () => "Field1",
                    TypeAsStringGet = () => "TotalRollup"
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.Text,
                    TitleGet = () => "Field2",
                    TypeAsStringGet = () => DummyString
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.Currency,
                    TitleGet = () => "Field3",
                    TypeAsStringGet = () => DummyString
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.DateTime,
                    TitleGet = () => "Field4",
                    TypeAsStringGet = () => DummyString
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.WorkflowStatus,
                    TitleGet = () => "Field5",
                    TypeAsStringGet = () => DummyString
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.Calculated,
                    TitleGet = () => "Field6",
                    TypeAsStringGet = () => DummyString,
                    SchemaXmlGet = () => "<main ResultType=\"Currency\"></main>"
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.Calculated,
                    TitleGet = () => "Field7",
                    TypeAsStringGet = () => DummyString,
                    SchemaXmlGet = () => "<main ResultType=\"DateTime\"></main>"
                },
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.Calculated,
                    TitleGet = () => "Field8",
                    TypeAsStringGet = () => DummyString,
                    SchemaXmlGet = () => "<main ResultType=\"Dummy\"></main>"
                }
            };
            return new ShimSPFieldCollection().Bind(list);
        }
    }
}
