using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using DocumentFormat.OpenXml.Fakes;
using DocumentFormat.OpenXml.Packaging.Fakes;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Spreadsheet.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.Jobs;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.ResourceGrid
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourceImporterTests
    {
        private IDisposable _shimObject;
        private ResourceImporter _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private bool _fileDeleted;
        private bool _itemUpdated;
        private int? _itemValue;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyDateField = "DummyDate";
        private const string NeedToBeSiteAdminErrorMessage = "You need to be a Site Collection Administrator in order to import resources.";
        private const string DSMResultProperty = "_dSMResult";
        private const string DtResourcesProperty = "_dtResources";
        private const string TotalRecordsProperty = "_totalRecords";

        private const string IdField = "ID";
        private const string GenericField = "Generic";
        private const string SharePointAccountField = "SharePointAccount";
        private const string TitleField = "Title";
        private const string ResourceLevelField = "ResourceLevel";
        private const string PermissionsField = "Permissions";
        private const string EmailField = "Email";

        private const string ImportCancelledMessage = "Import cancelled!";
        private const string ImportCompletedErrorMessage = "Import completed with errors!";
        private const string LoadingSpreadsheetMessage = "Loading Spreadsheet";
        private const string ImportingResourcesMessage = "Importing Resources";
        private const string ImportCompletedSuccessfullyMessage = "Import completed successfully!";
        private const string ImportCompletedCheckLogMessage = "Import Completed. Check the log for more details.";

        private const string AddNewResourceMethod = "AddNewResource";
        private const string GetUserValueMethod = "GetUserValue";

        [TestInitialize]
        public void TestInitializer()
        {
            _fileDeleted = false;
            _itemUpdated = false;
            _shimObject = ShimsContext.Create();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims(bool isSiteAdmin)
        {
            _web = new ShimSPWeb
            {
                EnsureUserString = _ => new ShimSPUser
                {
                    LoginNameGet = () => DummyString,
                    IDGet = () => DummyInt,
                    NameGet = () => DummyString
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IsSiteAdminGet = () => isSiteAdmin
                },
                SiteUserInfoListGet = () => new ShimSPList
                {
                    GetItemsStringArray = _ => new ShimSPListItemCollection().Bind(new SPListItem[]
                    {
                        new ShimSPListItem
                        {
                            ItemGetString = item =>
                            {
                                if (item == IdField)
                                {
                                    return DummyInt;
                                }

                                return DummyString;
                            }
                        }
                    })
                },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => new ShimSPList
                    {
                        AddItem = () => new ShimSPListItem
                        {
                            ItemGetString = __ => DummyString,
                            Update = () => _itemUpdated = true
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name =>
                            {
                                if (name == DummyString)
                                {
                                    return new ShimSPFieldLookup
                                    {
                                        LookupListGet = () => Guid.NewGuid().ToString(),
                                        LookupFieldGet = () => DummyString
                                    };
                                }
                                if (name == GenericField)
                                {
                                    return new ShimSPField
                                    {
                                        TypeGet = () => SPFieldType.Boolean
                                    };
                                }
                                if (name == SharePointAccountField)
                                {
                                    return new ShimSPFieldUser();
                                }
                                if (name == DummyDateField)
                                {
                                    return new ShimSPField
                                    {
                                        TypeGet = () => SPFieldType.DateTime
                                    };
                                }
                                
                                return new ShimSPField();
                            }
                        },
                        GetItemsSPQuery = __ => new ShimSPListItemCollection
                        {
                            CountGet = () => DummyInt,
                            ItemGetInt32 = ___ => new ShimSPListItem
                            {
                                IDGet = () => _itemValue.HasValue ? _itemValue.Value : DummyInt
                            }
                        },
                        GetItemByIdInt32 = __ => new ShimSPListItem
                        {
                            ItemGetString = ___ => DummyString,
                            Update = () => _itemUpdated = true
                        }
                    },
                    ItemGetGuid = _ => new ShimSPList
                    {
                        GetItemsStringArray = __ => new ShimSPListItemCollection().Bind(new SPListItem[]
                        {
                            new ShimSPListItem
                            {
                                ItemGetString = item =>
                                {
                                    if (item == IdField)
                                    {
                                        return DummyInt;
                                    }

                                    return DummyString;
                                }
                            }
                        })
                    }
                },
                GroupsGet = () => new ShimSPGroupCollection().Bind(new SPGroup[]
                {
                    new ShimSPGroup
                    {
                        NameGet = () => DummyString,
                        IDGet = () => DummyInt
                    }
                })
            };

            ShimSPField.AllInstances.TypeGet = instance =>
            {
                if (instance is SPFieldUser)
                {
                    return SPFieldType.User;
                }
                if (instance is SPFieldLookup)
                {
                    return SPFieldType.Lookup;
                }

                return SPFieldType.Text;
            };

            ShimSPFieldLookupValue.ConstructorInt32String = (_, __, ___) => { };

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.IsOnlineGet = _ => true;
            ShimAct.AllInstances.GetLevelsFromSiteInt32OutString = (Act instance, out int actType, string userName) =>
            {
                actType = DummyInt;

                return new ArrayList
                {
                    new ActLevel
                    {
                        name = DummyString,
                        id = DummyInt
                    }
                };
            };

            ShimEPMLiveFileStore.ConstructorSPWeb = (_, __) => { };
            ShimEPMLiveFileStore.AllInstances.Dispose = _ => { };
            ShimEPMLiveFileStore.AllInstances.GetStreamString = (_, __) => new ShimFileStream();
            ShimEPMLiveFileStore.AllInstances.DeleteString = (_, __) => _fileDeleted = true;

            ShimFileStream.AllInstances.DisposeBoolean = (_, __) => { };

            ShimSpreadsheetDocument.OpenStreamBoolean = (_, __) => new ShimSpreadsheetDocument
            {
                WorkbookPartGet = () => new ShimWorkbookPart
                {
                    WorkbookGet = () => new ShimWorkbook()
                }
            };

            ShimOpenXmlPackage.AllInstances.Dispose = _ => { };

            ShimOpenXmlElement.AllInstances.GetFirstChildOf1<Sheets>(_ => new ShimSheets());
            ShimOpenXmlElement.AllInstances.GetFirstChildOf1<SheetData>(_ => new ShimSheetData());
            ShimOpenXmlElement.AllInstances.ElementsOf1(_ => new List<Sheet>
            {
                new ShimSheet
                {
                    IdGet = () => DummyString
                }
            });
            ShimOpenXmlElement.AllInstances.DescendantsOf1(_ => new List<Row>
            {
                new ShimRow().Bind(new List<Cell>
                {
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell()
                }),
                new ShimRow(),
                new ShimRow()
            });
            ShimOpenXmlElement.AllInstances.DescendantsOf1(_ => new List<Cell>
            {
                new ShimCell(),
                new ShimCell(),
                new ShimCell(),
                new ShimCell(),
                new ShimCell(),
                new ShimCell(),
                new ShimCell(),
                new ShimCell(),
                new ShimCell()
            });

            ShimCellType.AllInstances.CellValueGet = _ => new ShimCellValue();
            var count1 = 0;
            ShimCellType.AllInstances.CellReferenceGet = _ =>
            {
                count1++;
                switch (count1)
                {
                    case 1:
                        return IdField;
                    case 2:
                        return TitleField;
                    case 3:
                        return ResourceLevelField;
                    case 4:
                        return PermissionsField;
                    case 5:
                        return $"{GenericField}{DummyInt}";
                    case 6:
                        return EmailField;
                    case 7:
                        return SharePointAccountField;
                    case 8:
                        return DummyDateField;
                    default:
                        count1 = 0;
                        return DummyString;
                }
            };

            var count2 = 0;
            ShimOpenXmlLeafTextElement.AllInstances.InnerXmlGet = _ => 
            {
                count2++;
                switch (count2)
                {
                    case 1:
                        return IdField;
                    case 2:
                        return TitleField;
                    case 3:
                        return ResourceLevelField;
                    case 4:
                        return PermissionsField;
                    case 5:
                        return GenericField;
                    case 6:
                        return EmailField;
                    case 7:
                        return SharePointAccountField;
                    case 8:
                        return DummyDateField;
                    case 10:
                    case 14:
                    case 17:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };

            ShimOpenXmlPartContainer.AllInstances.GetPartByIdString = (_, __) => new ShimWorksheetPart
            {
                WorksheetGet = () => new ShimWorksheet()
            };

            ShimSPQuery.Constructor = _ => { };
        }

        private void CreateTestObject(string data, bool isImportCancelled)
        {
            _testObj = new ResourceImporter(_web.Instance, data, true);
            _testObj.IsImportCancelled = isImportCancelled;
            _testObj.ImportCompleted += ResourceImportCompleted;
            _testObj.ImportProgressChanged += ResourceImportProgressChanged;

            _privateObj = new PrivateObject(_testObj);
        }

        private void ResourceImportCompleted(object sender, ImportCompletedEventHandlerArgs args)
        {
            // Dummy event for test purpose
        }

        private void ResourceImportProgressChanged(object sender, ImportProgressChangedEventHandlerArgs args)
        {
            // Dummy event for test purpose
        }

        [TestMethod]
        public void OnCreate_WhenUserIsNotSiteAdmin_ConfirmResult()
        {
            // Arrange
            SetupShims(false);
            
            // Act
            Action action = () => CreateTestObject(DummyString, false);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(NeedToBeSiteAdminErrorMessage);
        }

        [TestMethod]
        public void ImportAsync_WhenImportIsCancelled_LogCreated()
        {
            // Arrange
            SetupShims(true);
            CreateTestObject(DummyString, true);

            // Act
            _testObj.ImportAsync();

            // Assert
            var dSMResult = (ResourceImportResult)_privateObj.GetFieldOrProperty(DSMResultProperty);
            this.ShouldSatisfyAllConditions(
                () => dSMResult.Log.InfoCount.ShouldBe(1),
                () => dSMResult.Log.WarningCount.ShouldBe(0),
                () => dSMResult.Log.ErrorCount.ShouldBe(0),
                () => dSMResult.Log.Messages.Count.ShouldBe(1),
                () => dSMResult.Log.Messages[0].Message.ShouldBe(ImportCancelledMessage));
        }

        [TestMethod]
        public void ImportAsync_OnError_LogCreated()
        {
            // Arrange
            const string DummyErrorMessage = "Dummy Error Message";

            SetupShims(true);
            CreateTestObject(DummyString, false);

            ShimResourceImporter.AllInstances.LoadSpreadsheet = _ =>
            {
                throw new Exception(DummyErrorMessage);
            };

            // Act
            _testObj.ImportAsync();

            // Assert
            var dSMResult = (ResourceImportResult)_privateObj.GetFieldOrProperty(DSMResultProperty);
            this.ShouldSatisfyAllConditions(
                () => dSMResult.Log.InfoCount.ShouldBe(0),
                () => dSMResult.Log.WarningCount.ShouldBe(1),
                () => dSMResult.Log.ErrorCount.ShouldBe(1),
                () => dSMResult.Log.Messages.Count.ShouldBe(2),
                () => dSMResult.Log.Messages[0].Message.ShouldBe(DummyErrorMessage),
                () => dSMResult.Log.Messages[1].Message.ShouldBe(ImportCompletedErrorMessage));
        }

        [TestMethod]
        public void ImportAsync_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupShims(true);
            CreateTestObject(DummyString, false);

            // Act
            _testObj.ImportAsync();

            // Assert
            var dSMResult = (ResourceImportResult)_privateObj.GetFieldOrProperty(DSMResultProperty);
            var dtResources = (DataTable)_privateObj.GetFieldOrProperty(DtResourcesProperty);
            this.ShouldSatisfyAllConditions(
                () => dSMResult.Log.InfoCount.ShouldBe(3),
                () => dSMResult.Log.ErrorCount.ShouldBe(0),
                () => dSMResult.Log.WarningCount.ShouldBe(0),
                () => dSMResult.Log.Messages[0].Message.ShouldBe(LoadingSpreadsheetMessage),
                () => dSMResult.Log.Messages[1].Message.ShouldBe(ImportingResourcesMessage),
                () => dSMResult.Log.Messages[2].Message.ShouldBe(ImportCompletedSuccessfullyMessage),
                () => dSMResult.CurrentProcess.ShouldBe(ImportCompletedCheckLogMessage),
                () => dSMResult.FailedRecords.ShouldBe(0),
                () => dSMResult.ProcessedRecords.ShouldBe(1),
                () => dSMResult.SuccessRecords.ShouldBe(1),
                () => dSMResult.TotalRecords.ShouldBe(1),
                () => dSMResult.PercentComplete.ShouldBe(100),
                () => _fileDeleted.ShouldBeTrue(),
                () => _itemUpdated.ShouldBeTrue(),
                () => dtResources.Columns.Contains(IdField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(TitleField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(ResourceLevelField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(PermissionsField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(GenericField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(EmailField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(SharePointAccountField).ShouldBeTrue(),
                () => dtResources.Columns.Contains(DummyString).ShouldBeTrue(),
                () => dtResources.Columns.Contains(DummyDateField).ShouldBeTrue(),
                () => dtResources.Rows.Count.ShouldBe(1));
        }

        [TestMethod]
        public void AddNewResource_WhenIsGeneric_ConfirmResult()
        {
            // Arrange
            var dataRow = SetupForAddNewResource();

            // Act
            _privateObj.Invoke(AddNewResourceMethod, dataRow, true);

            // Assert
            _itemUpdated.ShouldBeTrue();
        }

        [TestMethod]
        public void AddNewResource_WhenIsNotGeneric_ConfirmResult()
        {
            // Arrange
            var dataRow = SetupForAddNewResource();

            // Act
            _privateObj.Invoke(AddNewResourceMethod, dataRow, false);

            // Assert
            _itemUpdated.ShouldBeTrue();
        }

        private DataRow SetupForAddNewResource()
        {
            _itemValue = -1;
            SetupShims(true);
            CreateTestObject(DummyString, false);

            var dataTable = new DataTable();
            dataTable.Columns.Add(IdField);
            dataTable.Columns.Add(TitleField);
            dataTable.Columns.Add(EmailField);
            dataTable.Columns.Add(SharePointAccountField);

            var dataRow = dataTable.NewRow();
            dataRow[IdField] = DummyInt;
            dataRow[TitleField] = DummyString;
            dataRow[EmailField] = DummyString;
            dataRow[SharePointAccountField] = DummyString;

            dataTable.Rows.Add(dataRow);
            return dataRow;
        }

        [TestMethod]
        public void GetUserValue_WhenNotFound_ConfirmResult()
        {
            // Arrange
            var usersDict = new Dictionary<string, object[]>();

            SetupShims(true);
            CreateTestObject(DummyString, false);

            // Act
            var result = _privateObj.Invoke(GetUserValueMethod, usersDict, DummyString);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetUserValue_WhenFoundAtSecondPosition_ConfirmResult()
        {
            // Arrange
            var usersDict = new Dictionary<string, object[]>();
            usersDict.Add(DummyString, new[] { DummyString, string.Empty });
            usersDict.Add($"{DummyString}2", new[] { (object)DummyInt, DummyString });

            SetupShims(true);
            CreateTestObject(DummyString, false);

            // Act
            var result = _privateObj.Invoke(GetUserValueMethod, usersDict, DummyString);

            // Assert
            result.ShouldNotBeNull();
        }
    }
}
