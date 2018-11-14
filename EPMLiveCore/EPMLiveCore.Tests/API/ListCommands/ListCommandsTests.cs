using System;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ListCommandsTests
    {
        private IDisposable _shimsContext;
        private ListCommands _testEntity;
        private PrivateObject _privateObject;
        private PrivateType _privateType;

        private static readonly Guid SiteId = Guid.NewGuid();
        private static readonly Guid ListId = Guid.NewGuid();
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyImageUrl = "http://tempuri.org/image.png";
        private const string DummyInternalName = "DummyInternalName";
        private const string DummyTitle = "DummyTitle";
        private const string DummyId = "7";
        private const string DummyUser = "DummyUser";
        private const string DummyUrl = "http://tempuri.org";
        private const string DummyIcon = "icon-square";

        private ShimSPSite _spSiteConstructor;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _testEntity = new ListCommands();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(ListCommands));

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };

            _spSiteConstructor = new ShimSPSite();

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite();
            ShimSPSite.ConstructorString = (sender, guid) => new ShimSPSite();

            ShimSPSite.AllInstances.OpenWebGuid = (sender, guid) => new ShimSPWeb();
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => string.Empty
                }
            };

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (web, setting, isRelative) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) =>
            {
                switch (setting)
                {
                    case "EPMLiveDisablePublishing":
                    case "EPMLiveDisablePlanners":
                        return "true";
                    case "EPKLists":
                        return DummyTitle;
                    case "EPKDummyTitle_nonactivexs":
                    case "EPKDummyTitle_menus":
                        return string.Empty;
                    case "EPKMenus":
                        return "EPKMenus";
                    case "epknonactivexs":
                        return "epknonactivexs";
                    default:
                        break;
                }

                return null;
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void iGetListPlannerInfo_CommandPrefixEqualsTitle_ReturnsListPlannerProps()
        {
            // Arrange
            var list = new ShimSPList()
            {
                ParentWebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => SiteId,
                        OpenWeb = () => new ShimSPWeb()
                    }
                },
                TitleGet = () => DummyTitle
            };

            ShimSPSite.AllInstances.FeaturesGet = sender => new ShimSPFeatureCollection()
            {
                ItemGetGuid = guid => new ShimSPFeature()
            };

            ShimCoreFunctions.GetPlannerListSPWebSPListItem = (inWeb, listItem) => new Dictionary<string, PlannerDefinition>()
            {
                {
                    DummyId, new PlannerDefinition { commandPrefix = DummyTitle }
                }
            };

            // Act
            var actualResult = (ListPlannerProps)_privateType.InvokeStatic("iGetListPlannerInfo", list.Instance);

            // Assert
            actualResult.PlannerV2Menu.ShouldBe("<Button Id=\"Ribbon.ListItem.EPMLive.Planner\" Sequence=\"33\" Command=\"EPMLivePlanner\" LabelText=\"Edit Plan\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/planner32.png\"/>");
        }

        [TestMethod]
        public void iGetListPlannerInfo_CommandEqualsTitle_ReturnsListPlannerProps()
        {
            // Arrange
            var list = new ShimSPList()
            {
                ParentWebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => SiteId,
                        OpenWeb = () => new ShimSPWeb()
                    }
                },
                TitleGet = () => DummyTitle
            };
            ShimSPSite.AllInstances.FeaturesGet = sender => new ShimSPFeatureCollection()
            {
                ItemGetGuid = guid => new ShimSPFeature()
            };

            ShimCoreFunctions.GetPlannerListSPWebSPListItem = (inWeb, listItem) => new Dictionary<string, PlannerDefinition>()
            {
                {
                    DummyId, new PlannerDefinition { command = DummyTitle }
                }
            };

            // Act
            var actualResult = (ListPlannerProps)_privateType.InvokeStatic("iGetListPlannerInfo", list.Instance);

            // Assert
            actualResult.PlannerV2CurPlanner.ShouldBe(DummyId);
            actualResult.PlannerV2Menu.ShouldBe("<Button Id=\"Ribbon.ListItem.EPMLive.Planner\" Sequence=\"33\" Command=\"TaskPlanner\" LabelText=\"Edit Plan\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/planner32.png\"/>");
        }

        [TestMethod]
        public void GetRibbonProps_ContentTypesEnabledFalse_ReturnsGridGanttSettings()
        {
            // Arrange
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permission) => true;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        if (internalName == "AssignedTo")
                        {
                            return new ShimSPField();
                        }

                        return null;
                    }
                },
                TitleGet = () => DummyTitle
            };

            ShimSPSite.AllInstances.OpenWeb = sender => new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = name => new ShimSPList(
                        new ShimSPDocumentLibrary()
                        {
                            DocumentTemplateUrlGet = () => "mpp"
                        })
                    {
                        ContentTypesEnabledGet = () => true,
                        ContentTypesGet = () => new ShimSPContentTypeCollection().Bind(
                            new SPContentType[]
                            {
                                new ShimSPContentType()
                                {
                                    DocumentTemplateUrlGet = () => "mpp"
                                }
                            })
                    }
                }
            };
            ShimSPSite.AllInstances.FeaturesGet = sender => new ShimSPFeatureCollection()
            {
                ItemGetGuid = guid => new ShimSPFeature()
            };
            ShimSPSite.AllInstances.RootWebGet = sender => new ShimSPWeb();

            var gridGranttSettings = new ShimGridGanttSettings();
            gridGranttSettings.Instance.BuildTeam = true;
            ShimListCommands.GetGridGanttSettingsSPList = listParam => gridGranttSettings;

            // Act
            var actualResult = ListCommands.GetRibbonProps(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.bBuildTeam.ShouldBeTrue(),
                () => actualResult.bDisableProject.ShouldBeTrue(),
                () => actualResult.bDisablePlan.ShouldBeTrue(),
                () => actualResult.aEPKButtons.Count.ShouldBe(1),
                () => actualResult.aEPKButtons[0].ShouldBe("EPKMenus"),
                () => actualResult.aEPKActivex.Count.ShouldBe(1),
                () => actualResult.aEPKActivex[0].ShouldBe("epknonactivexs"));
        }

        [TestMethod]
        public void GetRibbonProps_ContentTypesEnabledTrue_ReturnsGridGanttSettings()
        {
            // Arrange
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permission) => true;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        if (internalName == "AssignedTo")
                        {
                            return new ShimSPField();
                        }

                        return null;
                    }
                },
                TitleGet = () => DummyTitle
            };

            ShimSPSite.AllInstances.OpenWeb = sender => new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = name => new ShimSPList(new ShimSPDocumentLibrary())
                    {
                        ContentTypesEnabledGet = () => false,
                        ContentTypesGet = () => new ShimSPContentTypeCollection().Bind(
                            new SPContentType[]
                            {
                                new ShimSPContentType()
                                {
                                    DocumentTemplateUrlGet = () => "mpp"
                                }
                            })
                    }
                }
            };
            ShimSPSite.AllInstances.FeaturesGet = sender => new ShimSPFeatureCollection()
            {
                ItemGetGuid = guid => new ShimSPFeature()
            };
            ShimSPSite.AllInstances.RootWebGet = sender => new ShimSPWeb();

            var gridGranttSettings = new ShimGridGanttSettings();
            gridGranttSettings.Instance.BuildTeam = true;
            ShimListCommands.GetGridGanttSettingsSPList = listParam => gridGranttSettings;

            // Act
            var actualResult = ListCommands.GetRibbonProps(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.bBuildTeam.ShouldBeTrue(),
                () => actualResult.bDisableProject.ShouldBeTrue(),
                () => actualResult.bDisablePlan.ShouldBeTrue(),
                () => actualResult.aEPKButtons.Count.ShouldBe(1),
                () => actualResult.aEPKButtons[0].ShouldBe("EPKMenus"),
                () => actualResult.aEPKActivex.Count.ShouldBe(1),
                () => actualResult.aEPKActivex[0].ShouldBe("epknonactivexs"));
        }

        [TestMethod]
        public void GetAssociatedLists_NotFound_ReturnsArrayList()
        {
            // Arrange
            var list = new ShimSPList()
            {
                IDGet = () => ListId,
                ParentWebGet = () => new ShimSPWeb()
                {
                    ListsGet = () => new ShimSPListCollection().Bind(
                        new SPList[]
                        {
                            new ShimSPList()
                            {
                                FieldsGet = () => new ShimSPFieldCollection().Bind(
                                    new SPField[]
                                    {
                                        new ShimSPField(
                                            new ShimSPFieldLookup()
                                            {
                                                LookupListGet = () => $"{{{ListId}}}"
                                            })
                                        {
                                            TypeGet = () => SPFieldType.Lookup,
                                            InternalNameGet = () => DummyInternalName
                                        }
                                    }),
                                ImageUrlGet = () => DummyImageUrl,
                                IDGet = () => DummyGuid,
                                TitleGet = () => DummyTitle
                            }
                        })
                }
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) => sender.AssociatedItems = true;

            // Act
            var actualResult = ListCommands.GetAssociatedLists(list);

            // Assert
            var associatedListInfo = (AssociatedListInfo)actualResult[0];
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].ShouldBeOfType<AssociatedListInfo>(),
                () => associatedListInfo.Title.ShouldBe(DummyTitle),
                () => associatedListInfo.LinkedField.ShouldBe(DummyInternalName),
                () => associatedListInfo.ListId.ShouldBe(DummyGuid),
                () => associatedListInfo.icon.ShouldBe(DummyImageUrl));
        }

        [TestMethod]
        public void EnableTeamFeatures_Updated_ReturnsTrue()
        {
            // Arrange
            var actualUpdatedField = false;
            var countGetField = 0;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        if (countGetField == 0)
                        {
                            countGetField++;
                            return null;
                        }

                        return new ShimSPField()
                        {
                            Update = () => actualUpdatedField = true
                        };
                    },
                    AddStringSPFieldTypeBoolean = (displayName, type, required) => string.Empty
                }
            };

            // Act
            var actualResult = ListCommands.EnableTeamFeatures(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => actualUpdatedField.ShouldBeTrue());
        }

        [TestMethod]
        public void EnableTeamFeatures_Found_ReturnsTrue()
        {
            // Arrange
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                }
            };

            // Act
            var actualResult = ListCommands.EnableTeamFeatures(list);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void EnableTeamFeatures_ExceptionUpdate_ReturnsFalse()
        {
            // Arrange
            var countGetField = 0;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        if (countGetField == 0)
                        {
                            countGetField++;
                            return null;
                        }

                        return new ShimSPField()
                        {
                            Update = () =>
                            {
                                throw new Exception();
                            }
                        };
                    },
                    AddStringSPFieldTypeBoolean = (displayName, type, required) => string.Empty
                }
            };

            // Act
            var actualResult = ListCommands.EnableTeamFeatures(list);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void EnableTimesheets_Should_UpdateFields()
        {
            // Arrange
            var countUpdatedField = 0;
            var countUpdatedContentType = 0;
            var countUpdatedList = 0;
            var actualEpmLiveTsLists = string.Empty;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        Update = () => countUpdatedField++
                    }
                },
                ContentTypesGet = () => new ShimSPContentTypeCollection()
                {
                    ItemGetString = itemName => new ShimSPContentType()
                    {
                        FieldLinksGet = () => new ShimSPFieldLinkCollection()
                        {
                            ItemGetGuid = guid => null
                        },
                        Update = () => countUpdatedContentType++
                    }
                },
                Update = () => countUpdatedList++,
                TitleGet = () => DummyTitle
            };

            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                }
            };
            ShimSPFieldLink.ConstructorSPField = (sender, spField) => new ShimSPFieldLink();

            ShimCoreFunctions.getConfigSettingSPWebString = (rootWeb, setting) => string.Empty;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (rootWeb, setting, value) => actualEpmLiveTsLists = value;

            // Act
            ListCommands.EnableTimesheets(list, web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => countUpdatedField.ShouldBe(2),
                () => countUpdatedContentType.ShouldBe(2),
                () => countUpdatedList.ShouldBe(1),
                () => actualEpmLiveTsLists.ShouldBe($"\r\n{DummyTitle}"));
        }

        [TestMethod]
        public void DisableTimesheets_Should_RemoveStringFromList()
        {
            // Arrange
            var actualEpmLiveTsLists = string.Empty;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                },
                TitleGet = () => DummyTitle
            };

            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                }
            };
            ShimSPFieldLink.ConstructorSPField = (sender, spField) => new ShimSPFieldLink();

            ShimCoreFunctions.getConfigSettingSPWebString = (rootWeb, setting) => $"{DummyTitle}\r\n{DummyInternalName}";
            ShimCoreFunctions.setConfigSettingSPWebStringString = (rootWeb, setting, value) => actualEpmLiveTsLists = value;

            // Act
            ListCommands.DisableTimesheets(list, web);

            // Assert
            actualEpmLiveTsLists.ShouldBe(DummyInternalName);
        }

        [TestMethod]
        public void TryDeleteField_NotFound_ReturnsTrue()
        {
            // Arrange
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => null
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryDeleteField", list.Instance, DummyInternalName);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void TryDeleteField_Found_ReturnsTrue()
        {
            // Arrange
            var countUpdatedField = 0;
            var countDeletedField = 0;
            var countUpdatedList = 0;
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SealedGet = () => true,
                        Update = () => countUpdatedField++,
                        Delete = () => countDeletedField++
                    }
                },
                Update = () => countUpdatedList++
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryDeleteField", list.Instance, DummyInternalName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => countUpdatedList.ShouldBe(1),
                () => countUpdatedField.ShouldBe(1),
                () => countDeletedField.ShouldBe(1));
        }

        [TestMethod]
        public void TryDeleteField_UpdateException_ReturnsFalse()
        {
            // Arrange
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SealedGet = () => true,
                        Update = () =>
                        {
                            throw new Exception();
                        }
                    }
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryDeleteField", list.Instance, DummyInternalName);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void TryHideField_NotFound_ReturnsTrue()
        {
            // Arrange
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => null
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryHideField", list.Instance, DummyInternalName);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void TryHideField_Found_ReturnsTrue()
        {
            // Arrange
            var countUpdatedField = 0;
            var countUpdatedList = 0;
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SealedGet = () => true,
                        Update = () => countUpdatedField++
                    }
                },
                Update = () => countUpdatedList++
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryHideField", list.Instance, DummyInternalName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => countUpdatedList.ShouldBe(1),
                () => countUpdatedField.ShouldBe(2));
        }

        [TestMethod]
        public void TryHideField_UpdateException_ReturnsFalse()
        {
            // Arrange
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SealedGet = () => true,
                        Update = () =>
                        {
                            throw new Exception();
                        }
                    }
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryHideField", list.Instance, DummyInternalName);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void TryAddField_Found_ReturnsTrue()
        {
            // Arrange
            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryAddField", list.Instance, DummyInternalName, SPFieldType.Text, DummyTitle, false);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void TryAddField_NotFound_ReturnsTrue()
        {
            // Arrange
            var countUpdatedField = 0;
            var countGetField = 0;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        if (countGetField == 0)
                        {
                            countGetField++;
                            return null;
                        }

                        return new ShimSPField()
                        {
                            SealedGet = () => true,
                            Update = () => countUpdatedField++
                        };
                    }
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryAddField", list.Instance, DummyInternalName, SPFieldType.Text, DummyTitle, false);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => countUpdatedField.ShouldBe(1));
        }

        [TestMethod]
        public void TryAddField_UpdateException_ReturnsFalse()
        {
            // Arrange
            var countGetField = 0;

            var list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        if (countGetField == 0)
                        {
                            countGetField++;
                            return null;
                        }

                        return new ShimSPField()
                        {
                            SealedGet = () => true,
                            Update = () =>
                            {
                                throw new Exception();
                            }
                        };
                    }
                }
            };

            // Act
            var actualResult = (bool)_privateType.InvokeStatic("TryAddField", list.Instance, DummyInternalName, SPFieldType.Text, DummyTitle, false);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void InstallListsViewsWebParts_NotFoundGridListView_AddGridView()
        {
            // Arrange
            var actualAddedGridView = false;
            var actualDisposeWeb = false;

            var spList = new ShimSPList()
            {
                BaseTemplateGet = () => SPListTemplateType.AccessApp,
                ParentWebGet = () => new ShimSPWeb()
                {
                    GetFileString = strUrl => new ShimSPFile()
                    {
                        ExistsGet = () => true,
                        GetLimitedWebPartManagerPersonalizationScope = scope => new ShimSPLimitedWebPartManager()
                        {
                            WebPartsGet = () => new ShimSPLimitedWebPartCollection().Bind(
                                new WebPart[]
                                {
                                    new ShimWebPart(new ShimImageWebPart().Instance)
                                }),
                            AddWebPartWebPartStringInt32 = (webPart, zoneId, zoneIndex) =>
                            {
                                if (webPart.GetType() == typeof(GridListView))
                                {
                                    actualAddedGridView = true;
                                }
                            },
                            WebGet = () => new ShimSPWeb()
                            {
                                Dispose = () => actualDisposeWeb = true
                            }
                        }
                    }
                },
                ViewsGet = () => new ShimSPViewCollection().Bind(
                    new SPView[]
                    {
                        new ShimSPView()
                        {
                            UrlGet = () => DummyUrl
                        }
                    })
            };

            // Act
            ListCommands.InstallListsViewsWebparts(spList);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualAddedGridView.ShouldBeTrue(),
                () => actualDisposeWeb.ShouldBeTrue());
        }

        [TestMethod]
        public void InstallListsViewsWebParts_FoundGridListView_AddGridView()
        {
            // Arrange
            var actualAddedGridView = false;
            var actualDisposeWeb = false;

            var spList = new ShimSPList()
            {
                BaseTemplateGet = () => SPListTemplateType.AccessApp,
                ParentWebGet = () => new ShimSPWeb()
                {
                    GetFileString = strUrl => new ShimSPFile()
                    {
                        ExistsGet = () => true,
                        GetLimitedWebPartManagerPersonalizationScope = scope => new ShimSPLimitedWebPartManager()
                        {
                            WebPartsGet = () => new ShimSPLimitedWebPartCollection().Bind(
                                new WebPart[]
                                {
                                    new ShimWebPart(new ShimGridListView().Instance)
                                }),
                            AddWebPartWebPartStringInt32 = (webPart, zoneId, zoneIndex) =>
                            {
                                if (webPart.GetType() == typeof(GridListView))
                                {
                                    actualAddedGridView = true;
                                }
                            },
                            WebGet = () => new ShimSPWeb()
                            {
                                Dispose = () => actualDisposeWeb = true
                            }
                        }
                    }
                },
                ViewsGet = () => new ShimSPViewCollection().Bind(
                    new SPView[]
                    {
                        new ShimSPView()
                        {
                            UrlGet = () => DummyUrl
                        }
                    })
            };

            // Act
            ListCommands.InstallListsViewsWebparts(spList);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualAddedGridView.ShouldBeFalse(),
                () => actualDisposeWeb.ShouldBeTrue());
        }

        [TestMethod]
        public void MapListToReporting_Should_CreateListBiz()
        {
            // Arrange
            var actualCreatedListBiz = false;

            var list = new ShimSPList()
            {
                IDGet = () => DummyGuid,
                ParentWebGet = () => new ShimSPWeb
                {
                    IDGet = () => DummyGuid,
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummyGuid
                    }
                }
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                }
            };

            ShimReportBiz.AllInstances.GetListBizGuid = (sender, guid) => new ShimListBiz()
            {
                ListNameGet = () => string.Empty
            };
            ShimReportBiz.AllInstances.CreateListBizGuid = (sender, guid) =>
            {
                actualCreatedListBiz = true;
                return new ShimListBiz();
            };
            ShimReportBiz.ConstructorGuidGuidBoolean = (sender, siteId, webId, reporintv2) => new ShimReportBiz();

            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => "true";

            // Act
            ListCommands.MapListToReporting(list);

            // Assert
            actualCreatedListBiz.ShouldBeTrue();
        }

        [TestMethod]
        public void SaveIconToReporting_Should_ExecuteQuery()
        {
            // Arrange
            var actualQueryExecute = string.Empty;
            IDictionary<string, object> actualParameters = new Dictionary<string, object>();

            var list = new ShimSPList()
            {
                IDGet = () => DummyGuid,
                ParentWebGet = () => new ShimSPWeb()
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) => sender.ListIcon = DummyIcon;

            ShimQueryExecutor.ConstructorSPWeb = (sender, web) => new ShimQueryExecutor();
            ShimQueryExecutor.AllInstances.ExecuteReportingDBNonQueryStringIDictionaryOfStringObject = (sender, query, parameters) =>
            {
                actualQueryExecute = query;
                actualParameters = parameters;
            };

            // Act
            ListCommands.SaveIconToReporting(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualQueryExecute.ShouldBe(@"INSERT INTO ReportListIds (Id, ListIcon) VALUES (@Id, @Icon)"),
                () => actualParameters.Count.ShouldBe(2),
                () => actualParameters.ShouldContainKeyAndValue("@Id", DummyGuid),
                () => actualParameters.ShouldContainKeyAndValue("@Icon", DummyIcon));
        }

        [TestMethod]
        public void EnableFancyForms_FancyFormNotFound_SaveChangesAndDispose()
        {
            // Arrange
            var actualCountSaveChanges = 0;
            var actualDisposeWeb = false;
            var list = new ShimSPList()
            {
                ParentWebGet = () => new ShimSPWeb()
                {
                    ServerRelativeUrlGet = () => DummyUrl,
                    GetFileString = strUrl => new ShimSPFile()
                    {
                        GetLimitedWebPartManagerPersonalizationScope = scope => new ShimSPLimitedWebPartManager()
                        {
                            WebPartsGet = () => new ShimSPLimitedWebPartCollection()
                            {
                                ItemGetInt32 = itemId =>
                                {
                                    if (itemId == 0)
                                    {
                                        return new ShimWebPart(new ShimGridListView().Instance)
                                        {
                                            TitleGet = () => "Fancy Display Form"
                                        };
                                    }

                                    return new ShimWebPart(new ShimListFormWebPart().Instance);
                                }
                            }
                               .Bind(
                                    new WebPart[]
                                    {
                                        new ShimWebPart(new ShimGridListView().Instance),
                                        new ShimWebPart(new ShimListFormWebPart().Instance)
                                    }),
                            SaveChangesWebPart = webPartChanged => actualCountSaveChanges++,
                            WebGet = () => new ShimSPWeb()
                            {
                                Dispose = () => actualDisposeWeb = true
                            }
                        }
                    }
                },
                RootFolderGet = () => new ShimSPFolder()
            };

            // Act
            ListCommands.EnableFancyForms(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualCountSaveChanges.ShouldBe(2),
                () => actualDisposeWeb.ShouldBeTrue());
        }

        [TestMethod]
        public void EnableFancyForms_FancyFormNotFound_AddChangesAndDispose()
        {
            // Arrange
            var actualCountAddChanges = 0;
            var actualDisposeWeb = false;
            var list = new ShimSPList()
            {
                ParentWebGet = () => new ShimSPWeb()
                {
                    ServerRelativeUrlGet = () => DummyUrl,
                    GetFileString = strUrl => null
                },
                RootFolderGet = () => new ShimSPFolder()
                {
                    FilesGet = () => new ShimSPFileCollection()
                    {
                        AddStringSPTemplateFileType = (urlOfFile, templateFileType) => new ShimSPFile()
                        {
                            GetLimitedWebPartManagerPersonalizationScope = scope => new ShimSPLimitedWebPartManager()
                            {
                                AddWebPartWebPartStringInt32 = (webPart, zoneId, zoneIndex) => actualCountAddChanges++,
                                WebGet = () => new ShimSPWeb()
                                {
                                    Dispose = () => actualDisposeWeb = true
                                }
                            }
                        }
                    }
                }
            };

            // Act
            ListCommands.EnableFancyForms(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualCountAddChanges.ShouldBe(1),
                () => actualDisposeWeb.ShouldBeTrue());
        }
    }
}