using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Logging.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.WebPageCode
{
    [TestClass]
    public class TpreportTests
    {
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private tpreport tpreport;
        private const string BuildColumnsMethodName = "buildColumns";
        private const string DummyString = "DummyString";
        private const string LogErrorMethodName = "logError";
        private const string BuildResourceCapMethodName = "buildResourceCap";
        private const string ProcessResourceInfoMethodName = "processResourceInfo";
        private const string ProcessProjectInfoMethodName = "processProjectInfo";
        private const string ProcessTaskInfoMethodName = "processTaskInfo";
        private const string ProcessPeriodsMethodName = "processPeriods";
        private const string EPMLiveCoreDll = "EPM Live Core.dll";
        private const string PeriodItemFullName = "EPMLiveCore.tpreport+PeriodItem";
        private const string PageLoadMethodName = "Page_Load";
        private const string ProcessDataMethodName = "processData";
        private const int DataRowLength = 16;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            tpreport = new tpreport();
            privateObject = new PrivateObject(tpreport);
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorString = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebString = (_, url) => new ShimSPWeb();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
        }

        [TestMethod]
        public void BuildColumns_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            var spWeb = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    ItemGetString = itemName => $"{DummyString}{++count}",
                                    TitleGet = () => DummyString
                                }
                            }.GetEnumerator()
                        },
                        FieldsGet = () =>
                        {
                            var list = new List<SPField>
                            {
                                new ShimSPField
                                {
                                    HiddenGet = () => false,
                                    ReadOnlyFieldGet = () => false,
                                    TypeGet =  () => SPFieldType.Boolean,
                                    InternalNameGet = () => DummyString,
                                    TitleGet = () => $"Field{DummyString}"
                                }
                            };
                            return new ShimSPFieldCollection().Bind(list);
                        },
                        ItemsGet = () => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    TitleGet = () => "Dummy Title",
                                    ItemGetString = itemName => DummyString
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyString;
            Shimtpreport.AllInstances.buildResourceCapSPListString = (_, list, name) => { };
            var arrPeriods = privateObject.GetFieldOrProperty("arrPeriods") as ArrayList;
            var arrResOC = privateObject.GetFieldOrProperty("arrResOC") as ArrayList;
            var arrTaskOC = privateObject.GetFieldOrProperty("arrTaskOC") as ArrayList;
            var arrProjectOC = privateObject.GetFieldOrProperty("arrProjectOC") as ArrayList;

            // Act
            privateObject.Invoke(BuildColumnsMethodName, spWeb);

            // Assert
            tpreport.ShouldSatisfyAllConditions(
                () => arrPeriods.ShouldNotBeNull(),
                () => arrPeriods.Count.ShouldBeGreaterThan(0),
                () => arrResOC.ShouldNotBeNull(),
                () => arrResOC.Count.ShouldBeGreaterThan(0),
                () => arrTaskOC.ShouldNotBeNull(),
                () => arrTaskOC.Count.ShouldBeGreaterThan(0),
                () => arrProjectOC.ShouldNotBeNull(),
                () => arrProjectOC.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void LogError_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ErrorMessage = "Error Message";
            var logMessage = string.Empty;
            ShimTextWriter.AllInstances.WriteLineString = (_, content) => logMessage = content;
            ShimStreamWriter.AllInstances.Close = _ => { };

            // Act
            privateObject.Invoke(LogErrorMethodName, ErrorMessage);

            // Assert
            logMessage.ShouldBe(ErrorMessage);
        }

        [TestMethod]
        public void BuildResourceCap_Should_ExecuteCorrectly()
        {
            // Arrange
            var list = new ShimSPList
            {
                ItemsGet = () => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem>
                    {
                        new ShimSPListItem
                        {
                            ItemGetString = name => "1"
                        },
                        new ShimSPListItem
                        {
                            ItemGetString = name => "1"
                        }
                    }.GetEnumerator()
                }
            }.Instance;

            // Act
            privateObject.Invoke(BuildResourceCapMethodName, list, DummyString);
            var resourceList = privateObject.GetFieldOrProperty("lstResourceCap") as SortedList;

            // Assert
            resourceList.ShouldSatisfyAllConditions(
                () => resourceList.ShouldNotBeNull(),
                () => resourceList.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void ProcessResourceInfo_Should_ExecuteCorrectly()
        {
            // Arrange
            const string LookupResource = "Lookup";
            const string IntegerResource = "Integer";
            const string ExceptionResource = "Exception";
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query =>
                        {
                            return new ShimSPListItemCollection
                            {
                                CountGet = () => 1,
                                ItemGetInt32 = index => new ShimSPListItem
                                {
                                    ItemGetGuid = guid => $"{DummyString}\n"
                                },
                            };
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = fieldName => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid(),
                                TypeGet = () =>
                                {
                                    switch (fieldName)
                                    {
                                        case LookupResource:
                                            return SPFieldType.Lookup;
                                        case IntegerResource:
                                            return SPFieldType.Integer;
                                        case ExceptionResource:
                                            throw new Exception();
                                        default:
                                            return SPFieldType.Guid;
                                    }
                                }
                            }
                        }
                    }
                }
            }.Instance;
            var dataRows = new object[DataRowLength];
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => DummyString;
            privateObject.SetFieldOrProperty("arrResOC", new ArrayList
            {
                LookupResource, IntegerResource, ExceptionResource
            });

            // Act
            privateObject.Invoke(ProcessResourceInfoMethodName, web, dataRows, DummyString);
            var hshResourceOC = privateObject.GetFieldOrProperty("hshResourceOC") as Hashtable;

            // Assert
            hshResourceOC.ShouldSatisfyAllConditions(
                () => hshResourceOC.ShouldNotBeNull(),
                () => hshResourceOC.Count.ShouldBeGreaterThan(0),
                () => dataRows.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ProcessProjectInfo_Should_ExecuteCorrectly()
        {
            // Arrange
            const string LookupResource = "Lookup";
            const string IntegerResource = "Integer";
            const string ExceptionResource = "Exception";
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query =>
                        {
                            return new ShimSPListItemCollection
                            {
                                CountGet = () => 1,
                                ItemGetInt32 = index => new ShimSPListItem
                                {
                                    ItemGetGuid = guid => $"{DummyString}\n"
                                },
                            };
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = fieldName => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid(),
                                TypeGet = () =>
                                {
                                    switch (fieldName)
                                    {
                                        case LookupResource:
                                            return SPFieldType.Lookup;
                                        case IntegerResource:
                                            return SPFieldType.Integer;
                                        case ExceptionResource:
                                            throw new Exception();
                                        default:
                                            return SPFieldType.Guid;
                                    }
                                }
                            }
                        }
                    }
                }
            }.Instance;
            var dataRows = new object[DataRowLength];
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => DummyString;
            privateObject.SetFieldOrProperty("arrProjectOC", new ArrayList
            {
                LookupResource, IntegerResource, ExceptionResource
            });

            // Act
            privateObject.Invoke(ProcessProjectInfoMethodName, web, dataRows, DummyString);
            var hshProjectOC = privateObject.GetFieldOrProperty("hshProjectOC") as Hashtable;

            // Assert
            hshProjectOC.ShouldSatisfyAllConditions(
                () => hshProjectOC.ShouldNotBeNull(),
                () => hshProjectOC.Count.ShouldBeGreaterThan(0),
                () => dataRows.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ProcessTaskInfo_Should_ExecuteCorrectly()
        {
            // Arrange
            const string LookupResource = "Lookup";
            const string IntegerResource = "Integer";
            const string ExceptionResource = "Exception";
            var expectedValue = $"{DummyString} - {DummyString}";
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query =>
                        {
                            return new ShimSPListItemCollection
                            {
                                CountGet = () => 1,
                                ItemGetInt32 = index => new ShimSPListItem
                                {
                                    ItemGetGuid = guid => $"{DummyString}\n"
                                },
                            };
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = fieldName => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid(),
                                TypeGet = () =>
                                {
                                    switch (fieldName)
                                    {
                                        case LookupResource:
                                            return SPFieldType.Lookup;
                                        case IntegerResource:
                                            return SPFieldType.Integer;
                                        case ExceptionResource:
                                            throw new Exception();
                                        default:
                                            return SPFieldType.Guid;
                                    }
                                }
                            }
                        }
                    }
                }
            }.Instance;
            var dataRows = new object[DataRowLength];
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => DummyString;
            privateObject.SetFieldOrProperty("arrTaskOC", new ArrayList
            {
                LookupResource, IntegerResource, ExceptionResource
            });

            // Act
            privateObject.Invoke(
                ProcessTaskInfoMethodName,
                web,
                dataRows,
                DummyString,
                DummyString,
                DummyString);

            // Assert
            dataRows.ShouldSatisfyAllConditions(
                () => dataRows.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void ProcessPeriods_Should_ExecuteCorrectly()
        {
            // Arrange
            privateObject.SetFieldOrProperty("arrPeriods", new ArrayList
            {
                CreatePeriodItemObject(new Dictionary<string, object>
                {
                    ["name"] = DummyString,
                    ["start"] = DummyString,
                    ["finish"] = DummyString,
                    ["capacity"] = "1",
                })
            });
            var dataRow = new object[DataRowLength];
            var rowAdded = new object[] { };
            var listItem = new ShimSPListItem
            {
                ItemGetGuid = guid => DummyString,
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField
                    {
                        IdGet = () => Guid.NewGuid()
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("arrResOC", new ArrayList
            {
                DummyString
            });
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, row) =>
            {
                rowAdded = row;
                return new ShimDataRow();
            };

            // Act
            privateObject.Invoke(ProcessPeriodsMethodName, listItem, dataRow);

            // Assert
            rowAdded.ShouldSatisfyAllConditions(
                () => rowAdded.ShouldNotBeNull(),
                () => rowAdded.ShouldBe(dataRow));
        }

        [TestMethod]
        public void PageLoad_OnSuccess_ExecuteCorrectly()
        {
            // Arrange
            var buildColumnsWasCalled = false;
            var processDataWasCalled = false;
            var dataBindWasCalled = false;
            const string DummyUrl = "dummy.org/url";
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => DummyUrl;
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => "/url";
            ShimSPSite.AllInstances.UrlGet = _ => DummyUrl;
            Shimtpreport.AllInstances.buildColumnsSPWeb = (_, web) => buildColumnsWasCalled = true;
            Shimtpreport.AllInstances.processDataSPWebSPWeb = (_, web, response) => processDataWasCalled = true;
            ShimGridView.AllInstances.DataBind = _ => dataBindWasCalled = true;
            privateObject.SetFieldOrProperty("Gridview1", new GridView());

            // Act
            privateObject.Invoke(PageLoadMethodName, null, EventArgs.Empty);

            // Assert
            tpreport.ShouldSatisfyAllConditions(
                () => buildColumnsWasCalled.ShouldBeTrue(),
                () => processDataWasCalled.ShouldBeTrue(),
                () => dataBindWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_OnException_LogException()
        {
            // Arrange
            var logTraced = false;
            var dataBindWasCalled = false;
            const string DummyUrl = "dummy.org/url";
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => "/url";
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => "/url";
            ShimSPSite.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPSite.AllInstances.OpenWebString = (_, url) => new ShimSPWeb();
            Shimtpreport.AllInstances.buildColumnsSPWeb = (_, web) =>
            {
                throw new Exception();
            };
            ShimGridView.AllInstances.DataBind = _ => dataBindWasCalled = true;
            privateObject.SetFieldOrProperty("Gridview1", new GridView());
            ShimLoggingService.WriteTraceStringStringTraceSeverityString = (area, category, severity, message) =>
            {
                logTraced = true;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, null, EventArgs.Empty);

            // Assert
            tpreport.ShouldSatisfyAllConditions(
                () => logTraced.ShouldBeTrue(),
                () => dataBindWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessData_OnSuccess_ExecutesCorerrectly()
        {
            // Arrange
            var dataRow = new object[] { };
            const string Url = "/url";
            var web = new ShimSPWeb
            {
                TitleGet = () => DummyString,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    ItemGetString = _ => DummyString
                                }
                            }.GetEnumerator()
                        }
                    }
                },
                WebsGet = () => 
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            }.Instance;
            var resWeb = new ShimSPWeb
            {
                ServerRelativeUrlGet = () => Url
            }.Instance;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => Url;
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            Shimtpreport.AllInstances.processProjectInfoSPWebObjectArrayRefString = ProcessProjectInfo;
            Shimtpreport.AllInstances.processTaskInfoSPWebObjectArrayRefStringStringString = ProcessTaskInfo;
            Shimtpreport.AllInstances.processResourceInfoSPWebObjectArrayRefString = ProcessProjectInfo;
            Shimtpreport.AllInstances.processPeriodsSPListItemObjectArrayRef = ProcessPeriods;
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, row) =>
            {
                dataRow = row;
                return new ShimDataRow();
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name => bool.TrueString.ToLower()
            };
            ShimLoggingService.WriteTraceStringStringTraceSeverityString = 
                (area, category, severity, message) => { };

            // Act
            privateObject.Invoke(ProcessDataMethodName, web, resWeb);

            // Assert
            dataRow.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ProcessData_ResourceUrlNotEqualToServerUrl_NoActionTaken()
        {
            // Arrange
            var dataRow = new object[] { };
            const string Url = "/url";
            var web = new ShimSPWeb
            {
                TitleGet = () => DummyString,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    ItemGetString = _ => DummyString
                                }
                            }.GetEnumerator()
                        }
                    }
                },
                WebsGet = () =>
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            }.Instance;
            var resWeb = new ShimSPWeb
            {
                ServerRelativeUrlGet = () => Url
            }.Instance;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) => DummyString;
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, row) =>
            {
                dataRow = row;
                return new ShimDataRow();
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name => bool.TrueString.ToLower()
            };
            ShimLoggingService.WriteTraceStringStringTraceSeverityString =
                (area, category, severity, message) => { };

            // Act
            privateObject.Invoke(ProcessDataMethodName, web, resWeb);

            // Assert
            dataRow.ShouldBeEmpty();
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, event though not all of them are used
        /// </summary>
        private void ProcessPeriods(
            tpreport report, 
            SPListItem listItem, 
            ref object[] dataRow)
        {
            dataRow[0] = DummyString;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, event though not all of them are used
        /// </summary>
        private void ProcessTaskInfo(
            tpreport report, 
            SPWeb web, 
            ref object[] arrDtRow, 
            string project, 
            string task, 
            string wbs)
        {
            arrDtRow[0] = DummyString;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, event though not all of them are used
        /// </summary>
        private void ProcessProjectInfo(
            tpreport report, 
            SPWeb web, 
            ref object[] arrDtRow, 
            string project)
        {
            arrDtRow[0] = DummyString;
        }

        private object CreatePeriodItemObject(IDictionary<string, object> fields)
        {
            var type = GetPeriodItemType();
            var instance = Activator.CreateInstance(type);

            foreach (var field in fields)
            {
                type.GetField(field.Key)?.SetValue(instance, field.Value);
            }

            return instance;
        }

        private static Type GetPeriodItemType()
        {
            var asm = Assembly.LoadFrom(EPMLiveCoreDll);
            var type = asm.GetTypes().FirstOrDefault(p => p.FullName == PeriodItemFullName);
            return type;
        }
    }
}
