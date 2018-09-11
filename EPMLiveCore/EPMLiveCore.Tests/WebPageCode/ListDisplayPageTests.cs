using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ListDisplayPageTests
    {
        private IDisposable _shimsObject;
        private ListDisplayPage _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private bool _fieldUpdated;
        private bool _redirected;
        private bool _scriptRegistered;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string PageRenderField = "pageRender";
        private const string DisplayableFields = "displayableFields";
        private const string FieldProperties = "fieldProperties";
        private const string GroupsProperty = "groups";
        private const string MemOptionFieldWhere = "[Me]";
        private const string MemModeValue = "where";
        private const string NewMode = "New";
        private const string EditMode = "Edit";
        private const string DisplayMode = "Display";
        private const string EditableMode = "Editable";
        private const string GeneralSettings = "GeneralSettings";
        private const string AlwaysValue = "always";

        private const string OnLoadMethod = "OnLoad";
        private const string SaveCustomDisplayMethod = "SaveCustomDisplay";
        private const string RenderOptionsMethod = "RenderOptions";

        [TestInitialize]
        public void TestInitialize()
        {
            _fieldUpdated = false;
            _redirected = false;
            _scriptRegistered = false;
            _shimsObject = ShimsContext.Create();
            _testObj = new ListDisplayPage();
            _privateObj = new PrivateObject(_testObj);

            InitializeUiControls();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void InitializeUiControls()
        {
            var allFields = _testObj.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));
            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        private void SetupShims()
        {
            ShimCoreFunctions.getListSettingStringSPList = (setting, list) =>
            {
                if (setting == GeneralSettings)
                {
                    return $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{DummyString}";
                }
                return $"{DummyString}|{DummyString}|{DummyString}";
            };

            _web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = _ => new ShimSPList
                    {
                        IDGet = () => Guid.NewGuid(),
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name => new ShimSPField
                            {
                                Update = () => _fieldUpdated = true
                            }
                        }.Bind(new SPField[]
                        {
                            new ShimSPField
                            {
                                ReorderableGet = () => true,
                                SealedGet = () => false,
                                TitleGet = () => DummyString
                            }
                        }),
                        ParentWebGet = () => _web
                    }
                },
                GroupsGet = () => new ShimSPGroupCollection().Bind(new SPGroup[]
                {
                    new ShimSPGroup()
                })
            };
            
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _web
            };

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                QueryStringGet = () => new NameValueCollection
                {
                    ["List"] = Guid.NewGuid().ToString(),
                    ["Page"] = DummyInt.ToString()
                }
            };
            ShimPage.AllInstances.IsPostBackGet = _ => false;

            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    ParamsGet = () => new NameValueCollection
                    {
                        [$"Hidden{DummyString}New"] = AlwaysValue,
                        [$"Hidden{DummyString}Display"] = AlwaysValue,
                        [$"Hidden{DummyString}Edit"] = AlwaysValue,
                        [$"Hidden{DummyString}Editable"] = DummyString,
                    }
                }
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => _redirected = true;
        }

        [TestMethod]
        public void OnLoad_OnValidCall_ConfirmResult()
        {
            // Arrange
            var scriptRegistered = false;
            ShimClientScriptManager.AllInstances.RegisterClientScriptBlockTypeStringStringBoolean = (_, _1, _2, _3, _4) => scriptRegistered = true;

            // Act
            _privateObj.Invoke(OnLoadMethod, EventArgs.Empty);

            // Assert
            var pageRender = (string)_privateObj.GetFieldOrProperty(PageRenderField);
            this.ShouldSatisfyAllConditions(
                () => pageRender.ShouldNotBeNullOrEmpty(),
                () => scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveCustomDisplay_OnValidCall_ConfirmResult()
        {
            // Arrange
            var displayableFields = (SortedList<string, SPField>)_privateObj.GetFieldOrProperty(DisplayableFields);
            displayableFields.Add(DummyString, new ShimSPField
            {
                InternalNameGet = () => DummyString
            });
            
            // Act
            _privateObj.Invoke(SaveCustomDisplayMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _fieldUpdated.ShouldBeTrue(),
                () => _redirected.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_FirstSituation_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => DummyString
            }.Instance;

            SetupForRenderOptions(MemModeValue, DummyString, NewMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_SecondSituation_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => DummyString
            }.Instance;

            SetupForRenderOptions(MemModeValue, MemOptionFieldWhere, NewMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_ThirdSituation_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => DummyString
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, NewMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_ForthSituation_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => DummyString
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, EditMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_FifthSituation_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => DummyString
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, DisplayMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_SixthSituation_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => DummyString
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, EditableMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_Situation7_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => $"{DummyString}_"
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, NewMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_Situation8_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => $"{DummyString}_"
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, EditMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_Situation9_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => $"{DummyString}_",
                ShowInEditFormGet = () => true
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, NewMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderOptions_Situation10_ConfirmResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text,
                RequiredGet = () => false,
                InternalNameGet = () => $"{DummyString}_",
                ShowInEditFormGet = () => true
            }.Instance;

            SetupForRenderOptions(DummyString, MemOptionFieldWhere, EditMode);

            // Act
            var result = (string)_privateObj.Invoke(RenderOptionsMethod, field);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        private void SetupForRenderOptions(string memModeValue, string memOptionFieldWhere, string mode)
        {
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>();
            fieldProperties.Add(DummyString, new Dictionary<string, string>
            {
                [mode] = $"{memModeValue};{memOptionFieldWhere};{DummyString};{DummyString};{DummyString}"
            });
            _privateObj.SetFieldOrProperty(FieldProperties, fieldProperties);

            var displayableFields = (SortedList<string, SPField>)_privateObj.GetFieldOrProperty(DisplayableFields);
            displayableFields.Add(DummyString, new ShimSPField
            {
                InternalNameGet = () => DummyString,
                TitleGet = () => DummyString
            });

            var groups = (List<SPGroup>)_privateObj.GetFieldOrProperty(GroupsProperty);
            groups.Add(new ShimSPGroup
            {
                NameGet = () => DummyString
            });

            ShimClientScriptManager.AllInstances.RegisterHiddenFieldStringString = (_, __, ___) => _scriptRegistered = true;
        }
    }
}
