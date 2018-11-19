using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass]
    public class TimerFixTests
    {
        private TimerFix timerFix;
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private const string processResPlanMethodName = "processResPlan";
        private const string DummyString = "DummyString";
        private const string storeResPlanInfoMethodName = "storeResPlanInfo";
        private const string ProcessWebMethodName = "processWeb";
        private const string getListItemCountMethodName = "getListItemCount";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            timerFix = new TimerFix();
            privateObject = new PrivateObject(timerFix);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimResourcePlan.BuildResourceInfoDataTable = () => new DataTable();
            ShimResourcePlan.BuildResourceLinkDataTable = () => new DataTable();
            ShimTimerFix.AllInstances.storeResPlanInfo = _ => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, setting) => string.Empty;
            ShimBaseJob.AllInstances.CreateConnection = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
        }

        [TestMethod]
        public void Execute_OnSuccess_ExecuteCorrectly()
        {
            // Arrange
            var expectedCommands = new List<string>
            {
                "update queue set status = 2, dtfinished=GETDATE() where timerjobuid=@timerjobuid",
                "DELETE FROM EPMLIVE_LOG where timerjobuid=@timerjobuid",
                "INSERT INTO EPMLIVE_LOG (timerjobuid,result,resulttext) VALUES (@timerjobuid,@result,@resulttext)",
                "DELETE FROM RESINFO where siteid=@siteid",
                "DELETE FROM RESLINK where siteid=@siteid or siteid in (select siteid from reslink where weburl=@weburl)",
                "select timerjobuid from vwQueueTimer where siteguid=@siteguid and jobtype=1"
            };
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 1,
                        WorkDayEndHourGet = () => 2,
                        WorkDaysGet = () => 2
                    }
                },
                AllWebsGet = () =>
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            };
            var web = new ShimSPWeb();
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = ProcessWeb;
            ShimTimerFix.AllInstances.processResPlanSPWebStringGuidInt32String =
                (_, spWeb, lists, id, hours, days) => { };
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimBaseJob.AllInstances.initJobSPSite = (_, spSite) => true;
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executedCommands.Add(command.CommandText);
                return new ShimSqlDataReader
                {
                    Read = () => true,
                    GetGuidInt32 = index => Guid.NewGuid()
                };
            };

            // Act
            timerFix.execute(site, web, string.Empty);

            // Assert
            expectedCommands.All(cmd => executedCommands.Contains(cmd)).ShouldBeTrue();
        }

        [TestMethod]
        public void Execute_OnException_ExecutesCorrectly()
        {
            // Arrange
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 1,
                        WorkDayEndHourGet = () => 2,
                        WorkDaysGet = () => 2
                    }
                },
                AllWebsGet = () =>
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            };
            var web = new ShimSPWeb();
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = ProcessWeb;
            ShimTimerFix.AllInstances.processResPlanSPWebStringGuidInt32String =
                (_, spWeb, lists, id, hours, days) => { };
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception();
            };
            ShimResourcePlan.BuildResourceLinkDataTable = () =>
            {
                throw new Exception();
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executedCommands.Add(command.CommandText);
                return new ShimSqlDataReader
                {
                    Read = () => true,
                    GetGuidInt32 = index => Guid.NewGuid()
                };
            };
            ShimBaseJob.AllInstances.initJobSPSite = (_, spSite) => true;

            // Act
            timerFix.execute(site, web, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => timerFix.bErrors.ShouldBeTrue(),
                () => timerFix.sErrors.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void Execute_OnGeneralException_ShoudlThrowException()
        {
            // Arrange
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () =>
                {
                    throw new Exception();
                }
            };
            var web = new ShimSPWeb();

            // Act
            Action action = () => timerFix.execute(site, web, string.Empty);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void Execute_InitiJobFalse_NoActionTaken()
        {
            // Arrange
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 1,
                        WorkDayEndHourGet = () => 2,
                        WorkDaysGet = () => 2
                    }
                },
                AllWebsGet = () =>
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            };
            var web = new ShimSPWeb();
            ShimBaseJob.AllInstances.initJobSPSite = (_, spSite) => false;
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = ProcessWeb;
            ShimTimerFix.AllInstances.processResPlanSPWebStringGuidInt32String =
                (_, spWeb, lists, id, hours, days) => { };
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executedCommands.Add(command.CommandText);
                return new ShimSqlDataReader
                {
                    Read = () => true,
                    GetGuidInt32 = index => Guid.NewGuid()
                };
            };

            // Act
            timerFix.execute(site, web, string.Empty);

            // Assert
            executedCommands.ShouldBeEmpty();
        }

        [TestMethod]
        public void ProcessResPlan_Should_ExecuteCorrectly()
        {
            // Arrange
            var rowsCount = 0;
            var builder = new StringBuilder();
            var web = new ShimSPWeb().Instance;
            var siteId = Guid.NewGuid();
            var args = new object[]
            {
                web, string.Empty, siteId, 1, string.Empty
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, setting) => "https://dummy.org/url";
            ShimResourcePlan.ProcessResourcePlanStringSPWebStringGuidInt32String =
                (resUrl, spWeb, planListString, id, hours, workDays) =>
                {
                    var result = new ResourcePlanProcessingResult();
                    result.ResourceLinks.Add(new ResourcePlanProcessingResult.ResourceLink());
                    result.ResourceInfos.Add(new ResourcePlanProcessingResult.ResourceInfo());
                    result.InfoMessages.Add(DummyString);
                    result.ErrorMessages.Add(DummyString);
                    return result;
                };
            privateObject.SetFieldOrProperty("dtResLink", new DataTable());
            privateObject.SetFieldOrProperty("dtResInfo", new DataTable());
            privateObject.SetFieldOrProperty("sbErrors", builder);
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, values) =>
            {
                rowsCount++;
                return new ShimDataRow();
            };

            // Act
            privateObject.Invoke(processResPlanMethodName, args);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => timerFix.bErrors.ShouldBeTrue(),
                () => rowsCount.ShouldBeGreaterThan(0),
                () => builder.ToString().ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void StoreResPlanInfo_OnSuccess_ExecuteCorrectly()
        {
            // Arrange
            const int RowCount = 501;
            var writeToServerWasCalled = false;
            ShimTimerFix.AllInstances.storeResPlanInfo = null;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => RowCount
                }
            }.Instance;
            privateObject.SetFieldOrProperty("dtResInfo", dataTable);
            privateObject.SetFieldOrProperty("dtResLink", dataTable);
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable =
                (_, dt) => writeToServerWasCalled = true;

            // Act
            privateObject.Invoke(storeResPlanInfoMethodName);

            // Assert
            writeToServerWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void StoreResPlanInfo_OnException_ShouldLogMessage()
        {
            // Arrange
            const int RowCount = 501;
            const string ErrorMessage = "Error Message";
            ShimTimerFix.AllInstances.storeResPlanInfo = null;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => RowCount
                }
            }.Instance;
            privateObject.SetFieldOrProperty("dtResInfo", dataTable);
            privateObject.SetFieldOrProperty("dtResLink", dataTable);
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable =
                (_, dt) =>
                {
                    throw new Exception(ErrorMessage);
                };

            // Act
            privateObject.Invoke(storeResPlanInfoMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => timerFix.bErrors.ShouldBeTrue(),
                () => timerFix.sErrors.ShouldNotBeNullOrEmpty(),
                () => timerFix.sErrors.ShouldContain(ErrorMessage));
        }

        [TestMethod]
        public void ProcessWeb_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            var spWeb = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = listName => new ShimSPList
                    {
                        FieldsGet = () =>
                        {
                            var list = new List<SPField>
                            {
                                new ShimSPField
                                {
                                    TypeAsStringGet = () => "TotalRollup"
                                }
                            };
                            return new ShimSPFieldCollection().Bind(list);
                        }
                    }
                },
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = guid => new ShimSPFeature()
                }
            }.Instance;
            const string FixList = "task center";
            var counter = 0F;
            var args = new object[] { spWeb, FixList, counter };
            var systemUpdateWasCalled = false;
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = null;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, query) => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        ItemGetString = name => DummyString,
                    }
                }.GetEnumerator()
            };
            ShimTimerFix.AllInstances.getListItemCountSPWebSPFieldString = (_, web, field, project) => 1D;
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, name) => true;
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());
            ShimSPListItem.AllInstances.SystemUpdate = _ =>
            {
                systemUpdateWasCalled = true;
            };

            // Act
            privateObject.Invoke(ProcessWebMethodName, args);
            counter = ((float?)args[2]).GetValueOrDefault(0);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => counter.ShouldBeGreaterThan(0),
                () => systemUpdateWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessWeb_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string Error = "err";
            var spWeb = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = listName =>
                    {
                        if (listName == Error)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            return new ShimSPList
                            {
                                FieldsGet = () =>
                                {
                                    var list = new List<SPField>
                                    {
                                        new ShimSPField
                                        {
                                            TypeAsStringGet = () => "TotalRollup"
                                        }
                                    };
                                    return new ShimSPFieldCollection().Bind(list);
                                }
                            };
                        }
                    }
                },
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = guid => new ShimSPFeature()
                }
            }.Instance;
            var FixList = $"{Error}\ntask center";
            var counter = 0F;
            var args = new object[] { spWeb, FixList, counter };
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = null;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, query) => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        ItemGetString = name => DummyString,
                    }
                }.GetEnumerator()
            };
            ShimSPListItem.AllInstances.SystemUpdate = _ =>
            {
                throw new Exception();
            };
            ShimTimerFix.AllInstances.getListItemCountSPWebSPFieldString = (_, web, field, project) => 1D;
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, name) =>
            {
                throw new Exception();
            };
            var builder = new StringBuilder();
            privateObject.SetFieldOrProperty("sbErrors", builder);

            // Act
            privateObject.Invoke(ProcessWebMethodName, args);
            counter = ((float?)args[2]).GetValueOrDefault(0);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => counter.ShouldBeGreaterThan(0),
                () => builder.ToString().ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void GetListItemCount_AggTypeSum_ReturnsExpectedValue()
        {
            // Arrange
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
                                    ItemGetString = itemName => DummyString,
                                    FieldsGet = () => new ShimSPFieldCollection
                                    {
                                        GetFieldByInternalNameString = internalName => new ShimSPField
                                        {
                                            GetFieldValueString = fieldName => "Value;#1"
                                        }
                                    }
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            var field = new ShimSPField
            {
                GetCustomPropertyString = GetItem(new Hashtable
                {
                    ["AggType"] = "Sum"
                })
            }.Instance;

            // Act
            var result = privateObject.Invoke(getListItemCountMethodName, spWeb, field, DummyString) as double?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(1));
        }

        [TestMethod]
        public void GetListItemCount_AggTypeSumOnException_ReturnsExpectedValue()
        {
            // Arrange
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
                                    ItemGetString = itemName => DummyString,
                                    FieldsGet = () => new ShimSPFieldCollection
                                    {
                                        GetFieldByInternalNameString = internalName => new ShimSPField
                                        {
                                            GetFieldValueString = fieldName => null
                                        }
                                    }
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            var field = new ShimSPField
            {
                GetCustomPropertyString = GetItem(new Hashtable
                {
                    ["AggType"] = "Sum"
                })
            }.Instance;

            // Act
            var result = privateObject.Invoke(getListItemCountMethodName, spWeb, field, DummyString) as double?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(0));
        }

        [TestMethod]
        public void GetListItemCount_AggTypeAvg_ReturnsExpectedValue()
        {
            // Arrange
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
                                    ItemGetString = itemName => DummyString,
                                    FieldsGet = () => new ShimSPFieldCollection
                                    {
                                        GetFieldByInternalNameString = internalName => new ShimSPField
                                        {
                                            GetFieldValueString = fieldName => "Value;#1"
                                        }
                                    }
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            var field = new ShimSPField
            {
                GetCustomPropertyString = GetItem(new Hashtable
                {
                    ["AggType"] = "Avg",
                    ["AggColumn"] = null,
                    ["LookupColumn"] = null
                })
            }.Instance;

            // Act
            var result = privateObject.Invoke(getListItemCountMethodName, spWeb, field, DummyString) as double?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(1));
        }

        [TestMethod]
        public void GetListItemCount_AggTypeAvgOnException_ReturnsExpectedValue()
        {
            // Arrange
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
                                    ItemGetString = itemName => DummyString,
                                    FieldsGet = () => new ShimSPFieldCollection
                                    {
                                        GetFieldByInternalNameString = internalName => new ShimSPField
                                        {
                                            GetFieldValueString = fieldName => null
                                        }
                                    }
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            var field = new ShimSPField
            {
                GetCustomPropertyString = GetItem(new Hashtable
                {
                    ["AggType"] = "Avg",
                    ["AggColumn"] = null,
                    ["LookupColumn"] = null
                })
            }.Instance;

            // Act
            var result = privateObject.Invoke(getListItemCountMethodName, spWeb, field, DummyString) as double?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(0));
        }

        [TestMethod]
        public void GetListItemCount_AggTypeDefault_ReturnsExpectedValue()
        {
            // Arrange
            var spWeb = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection
                        {
                            CountGet = () => 1,
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    ItemGetString = itemName => DummyString,
                                    FieldsGet = () => new ShimSPFieldCollection
                                    {
                                        GetFieldByInternalNameString = internalName => new ShimSPField
                                        {
                                            GetFieldValueString = fieldName => "Value;#1"
                                        }
                                    }
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            var field = new ShimSPField
            {
                GetCustomPropertyString = GetItem(new Hashtable
                {
                    ["AggType"] = null,
                    ["AggColumn"] = null,
                    ["ListQuery"] = DummyString
                })
            }.Instance;

            // Act
            var result = privateObject.Invoke(getListItemCountMethodName, spWeb, field, DummyString) as double?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(1));
        }

        [TestMethod]
        public void GetListItemCount_OnException_ReturnsExpectedValue()
        {
            // Arrange
            var spWeb = new ShimSPWeb
            {
                ListsGet = () => null
            }.Instance;
            var field = new ShimSPField
            {
                GetCustomPropertyString = GetItem(new Hashtable
                {
                    ["AggType"] = null,
                    ["AggColumn"] = null,
                    ["ListQuery"] = DummyString
                })
            }.Instance;

            // Act
            var result = privateObject.Invoke(getListItemCountMethodName, spWeb, field, DummyString) as double?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(0));
        }

        private FakesDelegates.Func<string, object> GetItem(Hashtable table)
        {
            return name =>
            {
                return table.ContainsKey(name)
                    ? table[name]
                    : string.Empty;
            };
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private void ProcessWeb(
            TimerFix timer,
            SPWeb web,
            string fixLists,
            ref float counter)
        {
            counter++;
        }
    }
    
}
