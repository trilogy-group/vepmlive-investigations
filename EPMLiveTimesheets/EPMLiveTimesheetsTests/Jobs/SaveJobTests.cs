using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;

namespace EPMLiveTimesheets.Tests.Jobs
{
    using TimeSheets.Fakes;

    [TestClass]
    public class SaveJobTests
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string GetAttributeMethodName = "iGetAttribute";
        private const string GetValueMethodName = "iGetValue";
        private const string ProcessTimesheetHoursMethodName = "ProcessTimesheetHours";
        private const string ProcessListFieldsMethodName = "ProcessListFields";
        private const string ProcessTimesheetFieldsMethodName = "ProcessTimesheetFields";
        private const string ProcessItemRowMethodName = "ProcessItemRow";
        private const string ProcessItemHoursMethodName = "ProcessItemHours";
        private const string ProcessItemNotesMethodName = "ProcessItemNotes";
        private const string WebId = "WebID";
        private const string ListId = "ListID";
        private const string ItemId = "ItemID";
        private const string UID = "UID";
        private const string Value = "Value";
        private const string Hours = "Hours";
        private const string TypeAttribute = "Type";
        private const string LoadJobItemsMethodName = "LoadJobItems";
        private const string JobItemHoursFieldName = "_jobItemHours";
        private const string JobItemNotesFieldName = "_jobItemNotes";
        private const string JobItemDatesFieldName = "_jobItemDates";
        private const string DbItemHoursFieldName = "_dbItemHours";
        private const string DbItemNotesFieldName = "_dbItemNotes";
        private IDisposable shimsContext;
        private SaveJob saveJob;
        private PrivateObject privateObject;
        private PrivateType privateType;
        
        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            saveJob = new SaveJob();
            privateObject = new PrivateObject(saveJob);
            privateType = new PrivateType(typeof(SaveJob));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimXmlDocument.AllInstances.LoadXmlString = (_, data) => { };
            ShimSPPersistedObject.AllInstances.IdGet = _ => DummyGuid;
            ShimBaseJob.AllInstances.CreateConnection = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, dataSet) => 1;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new ShimXmlDocument());
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => bool.TrueString;
            ShimTimesheetSettings.ConstructorSPWeb = (_, web) => { };
            ShimTimesheetAPI.SubmitTimesheetStringSPWeb = (content, web) => DummyString;
            ShimSPFieldLookupValue.ConstructorString = (_, field) => { };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => DummyString;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[] { };
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
        }

        [TestMethod]
        public void GetAttribute_OnSuccess_ReturnsExpectedValue()
        {
            // Arrange
            var node = new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => new ShimXmlAttribute
                    {
                        ValueGet = () => DummyString
                    }
                }
            }.Instance;

            // Act
            var result = privateType.InvokeStatic(GetAttributeMethodName, node, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetAttribute_OnException_ReturnsEmptyValue()
        {
            // Arrange
            var node = new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => null
            }.Instance;

            // Act
            var result = privateType.InvokeStatic(GetAttributeMethodName, node, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void GetValue_SPFieldType_ReturnsExpectedValue()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ParentListGet = () => new ShimSPList
                {
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        GetFieldByInternalNameString = _ => new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Number,
                            IdGet = () => DummyGuid
                        }
                    }
                },
                ItemGetGuid = _ => DummyString
            }.Instance;

            // Act
            var result = privateType.InvokeStatic(GetValueMethodName, listItem, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetValue_SPFieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ParentListGet = () => new ShimSPList
                {
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        GetFieldByInternalNameString = _ => new ShimSPField
                        {
                            TypeGet = () => SPFieldType.WorkflowStatus,
                            IdGet = () => DummyGuid,
                            GetFieldValueAsTextObject = valueObject => DummyString
                        }
                    }
                },
                ItemGetGuid = _ => DummyString
            }.Instance;

            // Act
            var result = privateType.InvokeStatic(GetValueMethodName, listItem, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetValue_OnException_ReturnsEmptyValue()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ParentListGet = () =>
                {
                    throw new Exception();
                }
            }.Instance;

            // Act
            var result = privateType.InvokeStatic(GetValueMethodName, listItem, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void ProcessTimesheetHours_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var sqlCommands = new List<string>();
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var sqlConnection = new ShimSqlConnection().Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            var spWeb = new ShimSPWeb().Instance;
            var apiWasCalled = false;
            ShimTimesheetAPI.GetPeriodDaysArraySqlConnectionTimesheetSettingsSPWebString =
                (connection, settings, web, period) =>
                {
                    apiWasCalled = true;
                    return new ArrayList
                    {
                        dummyDate
                    };
                };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            privateObject.Invoke(ProcessTimesheetHoursMethodName, DummyString, row, sqlConnection, timesheetSettings, spWeb, DummyString);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => sqlCommands.ShouldBeEmpty(),
                () => apiWasCalled.ShouldBeTrue());
        }


        [TestMethod]
        public void LoadJobItems_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dummyHours = "10";
            var dummyType = "10";

            ShimXmlNode.AllInstances.SelectNodesString = (_, name) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateElement(DummyString);
                doc.AppendChild(element);
                return doc.ChildNodes;
            };

            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection
            {
                ItemOfGetString = name =>
                {
                    switch (name)
                    {
                        case UID:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => DummyString
                            };
                        case Value:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyDate.ToShortDateString()
                            };
                        case Hours:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyHours
                            };
                        case TypeAttribute:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyType
                            };
                        default:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => string.Empty
                            };
                    }
                    
                }
            };

            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, name) => new ShimXmlNode(new XmlDocument())
            {
                InnerTextGet = () => DummyString
            };

            var nodes = new List<XmlNode>()
            {
                row
            };

            var nodeList = new ShimXmlNodeList(new StubXmlNodeList {GetEnumerator01 = () => nodes.GetEnumerator()}).Instance;

            // Act
            privateObject.Invoke(LoadJobItemsMethodName, nodeList);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(JobItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(JobItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;
            var jobItemDates = privateObject.GetFieldOrProperty(JobItemDatesFieldName) as Dictionary<string, List<DateTime>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();
            jobItemDates.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () =>
                {
                    jobItemDates.Count.ShouldBe(1);
                    jobItemDates[DummyString].Count.ShouldBe(1);
                    var itemDate = jobItemDates[DummyString].First();
                    itemDate.Date.ShouldBe(dummyDate);
                },
                () =>
                {
                    jobItemNotes.Count.ShouldBe(1);
                    jobItemNotes[DummyString].Count.ShouldBe(1);
                    var itemNote = jobItemNotes[DummyString].First();
                    itemNote.ShouldSatisfyAllConditions(
                        () => itemNote.Date.ShouldBe(dummyDate),
                        () => itemNote.Notes.ShouldBe(DummyString));
                },
                () =>
                {
                    jobItemHours.Count.ShouldBe(1);
                    jobItemHours[DummyString].Count.ShouldBe(1);
                    var itemHour = jobItemHours[DummyString].First();
                    itemHour.ShouldSatisfyAllConditions(
                        () => itemHour.Date.ShouldBe(dummyDate),
                        () => itemHour.Hours.ShouldBe(dummyHours),
                        () => itemHour.Type.ShouldBe(dummyType));
                });
        }

        [TestMethod]
        public void LoadJobItems_WithInvalidDate_ShouldExecuteCorrectly()
        {
            // Arrange
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dummyHours = "10";
            var dummyType = "10";

            ShimXmlNode.AllInstances.SelectNodesString = (_, name) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateElement(DummyString);
                doc.AppendChild(element);
                return doc.ChildNodes;
            };

            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection
            {
                ItemOfGetString = name =>
                {
                    switch (name)
                    {
                        case UID:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => DummyString
                            };
                        case Value:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => DummyString
                            };
                        case Hours:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyHours
                            };
                        case TypeAttribute:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyType
                            };
                        default:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => string.Empty
                            };
                    }

                }
            };

            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, name) => new ShimXmlNode(new XmlDocument())
            {
                InnerTextGet = () => DummyString
            };

            var nodes = new List<XmlNode>()
            {
                row
            };

            var nodeList = new ShimXmlNodeList(new StubXmlNodeList { GetEnumerator01 = () => nodes.GetEnumerator() }).Instance;

            // Act
            privateObject.Invoke(LoadJobItemsMethodName, nodeList);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(JobItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(JobItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;
            var jobItemDates = privateObject.GetFieldOrProperty(JobItemDatesFieldName) as Dictionary<string, List<DateTime>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();
            jobItemDates.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () => jobItemDates[DummyString].Count.ShouldBe(0),
                () => jobItemNotes[DummyString].Count.ShouldBe(0),
                () => jobItemHours[DummyString].Count.ShouldBe(0));
        }

        [TestMethod]
        public void LoadJobItems_WithInvalidType_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dummyHours = "10";
            var dummyType = string.Empty;
            var expectedType = "0";

            ShimXmlNode.AllInstances.SelectNodesString = (_, name) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateElement(DummyString);
                doc.AppendChild(element);
                return doc.ChildNodes;
            };

            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection
            {
                ItemOfGetString = name =>
                {
                    switch (name)
                    {
                        case UID:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => DummyString
                            };
                        case Value:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyDate.ToShortDateString()
                            };
                        case Hours:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyHours
                            };
                        case TypeAttribute:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => dummyType
                            };
                        default:
                            return new ShimXmlAttribute
                            {
                                ValueGet = () => string.Empty
                            };
                    }

                }
            };

            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, name) => new ShimXmlNode(new XmlDocument())
            {
                InnerTextGet = () => DummyString
            };

            var nodes = new List<XmlNode>()
            {
                row
            };

            var nodeList = new ShimXmlNodeList(new StubXmlNodeList { GetEnumerator01 = () => nodes.GetEnumerator() }).Instance;

            // Act
            privateObject.Invoke(LoadJobItemsMethodName, nodeList);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(JobItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(JobItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;
            var jobItemDates = privateObject.GetFieldOrProperty(JobItemDatesFieldName) as Dictionary<string, List<DateTime>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();
            jobItemDates.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () =>
                {
                    jobItemDates.Count.ShouldBe(1);
                    jobItemDates[DummyString].Count.ShouldBe(1);
                    var itemDate = jobItemDates[DummyString].First();
                    itemDate.Date.ShouldBe(dummyDate);
                },
                () =>
                {
                    jobItemNotes.Count.ShouldBe(1);
                    jobItemNotes[DummyString].Count.ShouldBe(1);
                    var itemNote = jobItemNotes[DummyString].First();
                    itemNote.ShouldSatisfyAllConditions(
                        () => itemNote.Date.ShouldBe(dummyDate),
                        () => itemNote.Notes.ShouldBe(DummyString));
                },
                () =>
                {
                    jobItemHours.Count.ShouldBe(1);
                    jobItemHours[DummyString].Count.ShouldBe(1);
                    var itemHour = jobItemHours[DummyString].First();
                    itemHour.ShouldSatisfyAllConditions(
                        () => itemHour.Date.ShouldBe(dummyDate),
                        () => itemHour.Hours.ShouldBe(dummyHours),
                        () => itemHour.Type.ShouldBe(expectedType));
                });
        }

        [TestMethod]
        public void ProcessItemHours_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var expectedSqlCommands = new List<string>
            {
                "DELETE FROM TSITEMHOURS WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE IN (@dt0,@dt1,@dt2)",
                "UPDATE TSITEMHOURS SET TS_ITEM_HOURS=@hours, TS_ITEM_TYPE_ID=@type WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE=@dt",
                "UPDATE TSITEMHOURS SET TS_ITEM_HOURS=@hours, TS_ITEM_TYPE_ID=@type WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE=@dt",
                "INSERT INTO TSITEMHOURS (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_HOURS, TS_ITEM_TYPE_ID) VALUES (@id0, @dt0, @hours0, @type0),(@id1, @dt1, @hours1, @type1),(@id2, @dt2, @hours2, @type2)"
            };
            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var periods = new ArrayList
            {
                dummyDate,
                dummyDate.AddDays(1),
                dummyDate.AddDays(2),
                dummyDate.AddDays(3),
                dummyDate.AddDays(4),
                dummyDate.AddDays(5),
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };

            var jobItems = new List<SaveJob.TsItemHour>()
            {
                new SaveJob.TsItemHour(DummyString, dummyDate, "10", "1"),
                new SaveJob.TsItemHour(DummyString, dummyDate, "20", "2"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(1), "2", "2"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(4), "20", "2"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(5), "2", "2"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(6), "20", "2"),
            };
            privateObject.SetFieldOrProperty(JobItemHoursFieldName, new Dictionary<string, List<SaveJob.TsItemHour>>()
            {
                {DummyString, jobItems}
            });

            var dbItems = new List<SaveJob.TsItemHour>()
            {
                new SaveJob.TsItemHour(DummyString, dummyDate, "0", "0"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(1), "2", "0"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(2), "0", "0"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(3), "0", "0"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(5), "20", "2"),
                new SaveJob.TsItemHour(DummyString, dummyDate.AddDays(6), "0", "0")
            };
            privateObject.SetFieldOrProperty(DbItemHoursFieldName, new Dictionary<string, List<SaveJob.TsItemHour>>()
            {
                {DummyString, dbItems}
            });
            var dates = periods.OfType<DateTime>().ToList();
            dates.Add(dummyDate.AddDays(10));
            privateObject.SetFieldOrProperty(JobItemDatesFieldName, new Dictionary<string, List<DateTime>>()
            {
                {DummyString, dates}
            });

            // Act
            privateObject.Invoke(ProcessItemHoursMethodName, DummyString, sqlConnection, periods);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.ShouldBe(sqlCommands));
        }

        [TestMethod]
        public void ProcessItemHours_WithoutData_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var periods = new ArrayList
            {
                dummyDate
            };

            // Act
            privateObject.Invoke(ProcessItemHoursMethodName, DummyString, sqlConnection, periods);

            // Assert
            sqlCommands.ShouldBeEmpty();
        }

        [TestMethod]
        public void ProcessItemNotes_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var expectedSqlCommands = new List<string>
            {
                "DELETE FROM TSNOTES WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE IN (@dt0)",
                "UPDATE TSNOTES SET TS_ITEM_NOTES=@notes WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE=@dt",
                "INSERT INTO TSNOTES (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_NOTES) VALUES (@id0, @dt0, @notes0),(@id1, @dt1, @notes1)"
            };
            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var periods = new ArrayList
            {
                dummyDate,
                dummyDate.AddDays(1),
                dummyDate.AddDays(2),
                dummyDate.AddDays(3),
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };

            var jobItems = new List<SaveJob.TsItemNote>()
            {
                new SaveJob.TsItemNote(DummyString, dummyDate, "1"),
                new SaveJob.TsItemNote(DummyString, dummyDate.AddDays(1), "1"),
                new SaveJob.TsItemNote(DummyString, dummyDate.AddDays(2), "2"),
            };
            privateObject.SetFieldOrProperty(JobItemNotesFieldName, new Dictionary<string, List<SaveJob.TsItemNote>>()
            {
                {DummyString, jobItems}
            });

            var dbItems = new List<SaveJob.TsItemNote>()
            {
                new SaveJob.TsItemNote(DummyString, dummyDate, "0"),
                new SaveJob.TsItemNote(DummyString, dummyDate.AddDays(2), "0"),
                new SaveJob.TsItemNote(DummyString, dummyDate.AddDays(2), "0")
            };
            privateObject.SetFieldOrProperty(DbItemNotesFieldName, new Dictionary<string, List<SaveJob.TsItemNote>>()
            {
                {DummyString, dbItems}
            });
            var dates = periods.OfType<DateTime>().ToList();
            dates.Add(dummyDate.AddDays(10));
            privateObject.SetFieldOrProperty(JobItemDatesFieldName, new Dictionary<string, List<DateTime>>()
            {
                {DummyString, dates}
            });

            // Act
            privateObject.Invoke(ProcessItemNotesMethodName, DummyString, sqlConnection, periods);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.ShouldBe(sqlCommands));
        }


        [TestMethod]
        public void LoadDbItems_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;

            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var rowCounts = new Dictionary<ShimSqlDataReader, int>();

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                var reader = new ShimSqlDataReader
                {
                    ItemGetString = field => field == "TS_ITEM_DATE" ? dummyDate.ToShortDateString() : DummyString
                };
                reader.Read = () => ++rowCounts[reader] <= 1;
                rowCounts.Add(reader, 0);
                return reader;
            };

            var dates = new Dictionary<string, List<DateTime>>
            {
                {DummyString, new List<DateTime> {dummyDate}}
            };

            privateObject.SetFieldOrProperty(JobItemDatesFieldName, dates);

            // Act
            privateObject.Invoke("LoadDbItems", sqlConnection);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(DbItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(DbItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () =>
                {
                    jobItemHours.Count.ShouldBe(1);
                    jobItemHours[DummyString].Count.ShouldBe(1);
                    var itemHour = jobItemHours[DummyString].First();
                    itemHour.ShouldSatisfyAllConditions(
                        () => itemHour.Date.ShouldBe(dummyDate),
                        () => itemHour.Hours.ShouldBe(DummyString),
                        () => itemHour.Type.ShouldBe(DummyString));
                },
                () =>
                {
                    jobItemNotes.Count.ShouldBe(1);
                    jobItemNotes[DummyString].Count.ShouldBe(1);
                    var itemNotes = jobItemNotes[DummyString].First();
                    itemNotes.ShouldSatisfyAllConditions(
                        () => itemNotes.Date.ShouldBe(dummyDate),
                        () => itemNotes.Notes.ShouldBe(DummyString));
                });
        }

        [TestMethod]
        public void LoadDbItems_WithNoDates_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var sqlConnection = new ShimSqlConnection().Instance;

            // Act
            privateObject.Invoke("LoadDbItems", sqlConnection);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(DbItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(DbItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () => jobItemHours.Count.ShouldBe(0),
                () => jobItemNotes.Count.ShouldBe(0));
        }

        [TestMethod]
        public void LoadDbItems_WithInvalidDates_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;

            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var rowCounts = new Dictionary<ShimSqlDataReader, int>();

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                var reader = new ShimSqlDataReader
                {
                    ItemGetString = field => DummyString
                };
                reader.Read = () => ++rowCounts[reader] <= 1;
                rowCounts.Add(reader, 0);
                return reader;
            };

            var dates = new Dictionary<string, List<DateTime>>
            {
                {DummyString, new List<DateTime> {dummyDate}}
            };

            privateObject.SetFieldOrProperty(JobItemDatesFieldName, dates);

            // Act
            privateObject.Invoke("LoadDbItems", sqlConnection);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(DbItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(DbItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () => jobItemHours.Count.ShouldBe(0),
                () => jobItemNotes.Count.ShouldBe(0));
        }


        [TestMethod]
        public void LoadDbItems_WithDBNulls_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;

            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var rowCounts = new Dictionary<ShimSqlDataReader, int>();

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                var reader = new ShimSqlDataReader
                {
                    ItemGetString = field => DBNull.Value
                };
                reader.Read = () => ++rowCounts[reader] <= 1;
                rowCounts.Add(reader, 0);
                return reader;
            };

            var dates = new Dictionary<string, List<DateTime>>
            {
                {DummyString, new List<DateTime> {dummyDate}}
            };

            privateObject.SetFieldOrProperty(JobItemDatesFieldName, dates);

            // Act
            privateObject.Invoke("LoadDbItems", sqlConnection);

            // Assert
            var jobItemHours = privateObject.GetFieldOrProperty(DbItemHoursFieldName) as Dictionary<string, List<SaveJob.TsItemHour>>;
            var jobItemNotes = privateObject.GetFieldOrProperty(DbItemNotesFieldName) as Dictionary<string, List<SaveJob.TsItemNote>>;

            jobItemHours.ShouldNotBeNull();
            jobItemNotes.ShouldNotBeNull();

            saveJob.ShouldSatisfyAllConditions(
                () => jobItemHours.Count.ShouldBe(0),
                () => jobItemNotes.Count.ShouldBe(0));
        }

        [TestMethod]
        public void ProcessItemNotes_WithoutData_ShouldExecuteCorrectly()
        {
            // Arrange
            var dummyDate = DateTime.Now.Date;
            var sqlCommands = new List<string>();
            var sqlConnection = new ShimSqlConnection().Instance;
            var periods = new ArrayList
            {
                dummyDate
            };

            // Act
            privateObject.Invoke(ProcessItemNotesMethodName, DummyString, sqlConnection, periods);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => sqlCommands.ShouldBeEmpty());
        }


        [TestMethod]
        public void ProcessListFields_OnSuccess_ShouldExecutesCorrectly()
        {
            // Arrange
            const string EmptyField = "EmptyField";
            var expectedSqlCommands = new List<string>
            {
                "UPDATE TSMETA SET ColumnValue=@val where TSMETA_UID=@muid",
                "INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@uid,@col,@disp,@val,@list)",
                "DELETE FROM TSMETA WHERE TS_ITEM_UID=@uid and ColumnName=@col and ListName=@list"
            };
            var sqlCommands = new List<string>();
            var node = new ShimXmlNode(new XmlDocument()).Instance;
            var sqlConnection = new SqlConnection();
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyString
            }.Instance;
            var list = new ShimSPList()
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite
                    {
                        RootWebGet = () => new ShimSPWeb()
                    },
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guid => new ShimSPList()
                    }
                },
                DefaultViewGet = () => new ShimSPView(),
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => DummyGuid.ToString()
                    }
                }
            }.Instance;
            ShimPath.GetDirectoryNameString = _ => DummyString;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => $",{DummyString},{DummyGuid},{EmptyField}";
            ShimSaveJob.iGetValueSPListItemString = (item, field) => field == EmptyField ? string.Empty : field;
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = index => new ShimDataTable
                {
                    SelectString = query =>
                    {
                        if (query.Contains(DummyString))
                        {
                            return new DataRow[]
                            {
                                new ShimDataRow
                                {
                                    ItemGetString = i => DummyString
                                }
                            };
                        }
                        else
                        {
                            return new DataRow[] { };
                        }
                    }
                }
            };

            // Act
            privateObject.Invoke(ProcessListFieldsMethodName,
                DummyString,
                node,
                sqlConnection,
                timesheetSettings,
                listItem,
                true,
                list);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessTimesheetFields_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var expectedSqlCommands = new List<string>
            {
                "UPDATE TSMETA SET ColumnValue=@val where TSMETA_UID=@muid",
                "INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@uid,@col,@disp,@val,'MYTS')",
                "DELETE FROM TSMETA WHERE TS_ITEM_UID=@uid and ColumnName=@col and ListName='MYTS'"
            };
            var sqlCommands = new List<string>();
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var connection = new SqlConnection();
            var timeSettings = new ShimTimesheetSettings().Instance;
            timeSettings.TimesheetFields = new ArrayList
            {
                string.Empty,
                DummyString,
                DummyInt.ToString(),
            };
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) => field;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField()
            };
            privateObject.SetFieldOrProperty("WorkList", new ShimSPList().Instance);
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = i => new ShimDataTable
                {
                    SelectString = query =>
                    {
                        if (query.Contains(DummyString))
                        {
                            return new DataRow[]
                            {
                                new ShimDataRow
                                {
                                    ItemGetString = name => DummyString
                                }
                            };
                        }
                        else
                        {
                            return new DataRow[] { };
                        }
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            privateObject.Invoke(ProcessTimesheetFieldsMethodName,
                DummyString,
                row,
                connection,
                timeSettings);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessItemRow_DataTableItemsNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedSqlCommand = "UPDATE TSITEM set Title = @title, project=@project, project_id=@projectid,rate=@rate where ts_item_uid=@uid";
            var sqlCommand = string.Empty;
            var processTimesheetHoursWasCalled = false;
            var processListFieldsWasCalled = false;
            var processTimesheetFieldsWasCalled = false;
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite()
            {
                OpenWebGuid = guid => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = _ => new ShimSPList
                        {
                            GetItemsSPQuery = (query) => new ShimSPListItemCollection
                            {
                                GetItemByIdInt32 = (id) => new ShimSPListItem()
                            }
                        },
                        ItemGetString = name => new ShimSPList()
                    }
                }
            }.Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case WebId:
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => DummyString;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                ContainsFieldString = name => true,
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => DummyGuid
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommand = command.CommandText;
                return 1;
            };
            ShimSharedFunctions.GetStandardRatesSqlConnectionStringSPWebStringString =
                (sqlConnection, id, web, username, projectId) => DummyString;
            ShimSaveJob.AllInstances.ProcessTimesheetHoursStringXmlNodeSqlConnectionTimesheetSettingsSPWebString = 
                (_, id, node, sqlConnection, settings, web, period) => 
                {
                    processTimesheetHoursWasCalled = true;
                };
            ShimSaveJob.AllInstances.ProcessTimesheetFieldsStringXmlNodeSqlConnectionTimesheetSettings = 
                (_, id, node, sqlConnection, settings) => 
                {
                    processTimesheetFieldsWasCalled = true;
                };
            ShimSaveJob.AllInstances.ProcessListFieldsStringXmlNodeSqlConnectionTimesheetSettingsSPListItemBooleanSPList = 
                (_, id, node, sqlConnection, settings, listItem, recursive, spList) => 
                {
                    processListFieldsWasCalled = true;
                };
            privateObject.SetFieldOrProperty("WorkList", new ShimSPList().Instance);
            var getProjectListFieldsSPListWasCalled = false;
            ShimSaveJob.GetProjectListFieldsSPList = _ =>
            {
                getProjectListFieldsSPListWasCalled = true;
                return new string[0];
            };

            var executeCache = new SaveJob.ExecuteCache(spSite);
            string preloadErrors;
            executeCache.PreloadListItems(new[]
            {
                new SaveDataJobExecuteCache.ListItemInfo
                {
                    WebId = DummyGuid.ToString(),
                    ListId = DummyGuid.ToString(),
                    ListItemId = DummyInt.ToString()
                }
            }, out preloadErrors);

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                executeCache,
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => processTimesheetFieldsWasCalled.ShouldBeTrue(),
                () => processTimesheetHoursWasCalled.ShouldBeTrue(),
                () => processListFieldsWasCalled.ShouldBeTrue(),
                () => getProjectListFieldsSPListWasCalled.ShouldBeTrue(),
                () => sqlCommand.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void ProcessItemRow_DataTableItemsNotEmptyAndProjectId_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedSqlCommand = "UPDATE TSITEM set Title = @title, project=@project, project_id=@projectid,rate=@rate where ts_item_uid=@uid";
            var sqlCommand = string.Empty;
            var processTimesheetHoursWasCalled = false;
            var processListFieldsWasCalled = false;
            var processTimesheetFieldsWasCalled = false;
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite()
            {
                OpenWebGuid = guid => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = _ => new ShimSPList
                        {
                            GetItemsSPQuery = (query) => new ShimSPListItemCollection
                            {
                                GetItemByIdInt32 = (id) => new ShimSPListItem()
                            }
                        },
                        ItemGetString = name => new ShimSPList()
                    }
                }
            }.Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case WebId:
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => DummyString;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                ContainsFieldString = name => false,
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => DummyGuid
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommand = command.CommandText;
                return 1;
            };
            ShimSharedFunctions.GetStandardRatesSqlConnectionStringSPWebStringString =
                (sqlConnection, id, web, username, projectId) => DummyString;
            ShimSaveJob.AllInstances.ProcessTimesheetHoursStringXmlNodeSqlConnectionTimesheetSettingsSPWebString =
                (_, id, node, sqlConnection, settings, web, period) =>
                {
                    processTimesheetHoursWasCalled = true;
                };
            ShimSaveJob.AllInstances.ProcessTimesheetFieldsStringXmlNodeSqlConnectionTimesheetSettings =
                (_, id, node, sqlConnection, settings) =>
                {
                    processTimesheetFieldsWasCalled = true;
                };
            ShimSaveJob.AllInstances.ProcessListFieldsStringXmlNodeSqlConnectionTimesheetSettingsSPListItemBooleanSPList =
                (_, id, node, sqlConnection, settings, listItem, recursive, spList) =>
                {
                    processListFieldsWasCalled = true;
                };
            privateObject.SetFieldOrProperty("WorkList", new ShimSPList().Instance);
            var getProjectListFieldsSPListWasCalled = false;
            ShimSaveJob.GetProjectListFieldsSPList = _ =>
            {
                getProjectListFieldsSPListWasCalled = true;
                return new string[0];
            };

            var executeCache = new SaveJob.ExecuteCache(spSite);
            string preloadErrors;
            executeCache.PreloadListItems(
                new[]
                {
                    new SaveDataJobExecuteCache.ListItemInfo
                    {
                        WebId = DummyGuid.ToString(),
                        ListId = DummyGuid.ToString(),
                        ListItemId = DummyInt.ToString()
                    }
                },
                out preloadErrors);

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                executeCache,
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => processTimesheetFieldsWasCalled.ShouldBeTrue(),
                () => processTimesheetHoursWasCalled.ShouldBeTrue(),
                () => processListFieldsWasCalled.ShouldBeTrue(),
                () => getProjectListFieldsSPListWasCalled.ShouldBeTrue(),
                () => sqlCommand.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void ProcessItemRow_DataTableItemsEmpty_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedSqlCommand = "INSERT INTO TSITEM SELECT DISTINCT TS_UID, case when TS_UID=@currenttsuid then @uidcurrent else NEWID() end";
            var sqlCommand = string.Empty;
            var processTimesheetHoursWasCalled = false;
            var processListFieldsWasCalled = false;
            var processTimesheetFieldsWasCalled = false;
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite()
            {
                OpenWebGuid = guid => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = _ => new ShimSPList
                        {
                            GetItemsSPQuery = (query) => new ShimSPListItemCollection
                            {
                                GetItemByIdInt32 = (id) => new ShimSPListItem()
                            }
                        },
                        ItemGetString = name => new ShimSPList()
                    }
                }
            }.Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case WebId:
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommand = command.CommandText;
                return 1;
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                ContainsFieldString = name => false,
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => DummyGuid
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList()
            };
            ShimSharedFunctions.GetStandardRatesSqlConnectionStringSPWebStringString =
                (sqlConnection, id, web, username, projectId) => DummyString;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPFieldLookup
                {
                    LookupListGet = () => string.Empty
                }
            };
            ShimSaveJob.AllInstances.ProcessTimesheetHoursStringXmlNodeSqlConnectionTimesheetSettingsSPWebString =
                (_, id, node, sqlConnection, settings, web, period) =>
                {
                    processTimesheetHoursWasCalled = true;
                };
            ShimSaveJob.AllInstances.ProcessTimesheetFieldsStringXmlNodeSqlConnectionTimesheetSettings =
                (_, id, node, sqlConnection, settings) =>
                {
                    processTimesheetFieldsWasCalled = true;
                };
            ShimSaveJob.AllInstances.ProcessListFieldsStringXmlNodeSqlConnectionTimesheetSettingsSPListItemBooleanSPList =
                (_, id, node, sqlConnection, settings, listItem, recursive, spList) =>
                {
                    processListFieldsWasCalled = true;
                };
            privateObject.SetFieldOrProperty("WorkList", new ShimSPList().Instance);
            var getProjectListFieldsSPListWasCalled = false;
            ShimSaveJob.GetProjectListFieldsSPList = _ =>
            {
                getProjectListFieldsSPListWasCalled = true;
                return new string[0];
            };

            var executeCache = new SaveJob.ExecuteCache(spSite);
            string preloadErrors;
            executeCache.PreloadListItems(
                new[]
                {
                    new SaveDataJobExecuteCache.ListItemInfo
                    {
                        WebId = DummyGuid.ToString(),
                        ListId = DummyGuid.ToString(),
                        ListItemId = DummyInt.ToString()
                    }
                },
                out preloadErrors);

            // Act    
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                executeCache,
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => processTimesheetFieldsWasCalled.ShouldBeTrue(),
                () => processTimesheetHoursWasCalled.ShouldBeTrue(),
                () => processListFieldsWasCalled.ShouldBeTrue(),
                () => getProjectListFieldsSPListWasCalled.ShouldBeTrue(),
                () => sqlCommand.ShouldContain(ExpectedSqlCommand));
        }

        [TestMethod]
        public void ProcessItemRow_OnException_LogsError()
        {
            // Arrange
            var expectedMessage = $"Item ({DummyString}) Error: System.Exception: {DummyString}";
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite()
            {
                OpenWebGuid = guid => new ShimSPWeb
                {
                    ListsGet = () =>
                    {
                        throw new Exception(DummyString);
                    }
                }
            }.Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case WebId:
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                new SaveJob.ExecuteCache(spSite),
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);
            var stringBuilder = privateObject.GetFieldOrProperty("sbErrors") as StringBuilder;
            var errorContent = stringBuilder?.ToString();

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.bErrors.ShouldBeTrue(),
                () => errorContent.ShouldNotBeNullOrEmpty(),
                () => errorContent.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void ProcessItemRow_OnGetAttributeException_LogsError()
        {
            // Arrange
            var expectedMessage = $"Item ({DummyString}) Error x2: System.Exception: {DummyString}";
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite()
            {
                OpenWebGuid = guid => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection()
                }
            }.Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case WebId:
                        throw new Exception(DummyString);
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                new SaveJob.ExecuteCache(spSite),
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);
            var stringBuilder = privateObject.GetFieldOrProperty("sbErrors") as StringBuilder;
            var errorContent = stringBuilder?.ToString();

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.bErrors.ShouldBeTrue(),
                () => errorContent.ShouldNotBeNullOrEmpty(),
                () => errorContent.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void ProcessItemRow_IdEmpty_LogsError()
        {
            // Arrange
            const string ExpectedMessage = "Could not get id for item";
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite().Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) => string.Empty;
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                new SaveJob.ExecuteCache(spSite),
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);
            var stringBuilder = privateObject.GetFieldOrProperty("sbErrors") as StringBuilder;
            var errorContent = stringBuilder?.ToString();

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.bErrors.ShouldBeTrue(),
                () => errorContent.ShouldNotBeNullOrEmpty(),
                () => errorContent.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void ProcessItemRow_WebIdEmpty_LogsError()
        {
            // Arrange
            var expectedMessage = $"Item ({DummyInt}) missing web id";
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite().Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case UID:
                        return DummyInt.ToString();
                    case WebId:
                        return string.Empty;
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                new SaveJob.ExecuteCache(spSite),
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);
            var stringBuilder = privateObject.GetFieldOrProperty("sbErrors") as StringBuilder;
            var errorContent = stringBuilder?.ToString();

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.bErrors.ShouldBeTrue(),
                () => errorContent.ShouldNotBeNullOrEmpty(),
                () => errorContent.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void ProcessItemRow_ListIdEmpty_LogsError()
        {
            // Arrange
            var expectedMessage = $"Item ({DummyInt}) missing list id";
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite().Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case UID:
                        return DummyInt.ToString();
                    case WebId:
                        return DummyGuid.ToString();
                    case ListId:
                        return string.Empty;
                    case ItemId:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                new SaveJob.ExecuteCache(spSite),
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);
            var stringBuilder = privateObject.GetFieldOrProperty("sbErrors") as StringBuilder;
            var errorContent = stringBuilder?.ToString();

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.bErrors.ShouldBeTrue(),
                () => errorContent.ShouldNotBeNullOrEmpty(),
                () => errorContent.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void ProcessItemRow_ItemIdEmpty_LogsError()
        {
            // Arrange
            var expectedMessage = $"Item ({DummyInt}) missing item id";
            var row = new ShimXmlNode(new XmlDocument()).Instance;
            var dtItems = new DataTable();
            var connection = new SqlConnection();
            var spSite = new ShimSPSite().Instance;
            var timesheetSettings = new ShimTimesheetSettings().Instance;
            ShimSaveJob.iGetAttributeXmlNodeString = (node, field) =>
            {
                switch (field)
                {
                    case UID:
                        return DummyInt.ToString();
                    case WebId:
                        return DummyGuid.ToString();
                    case ListId:
                        return DummyGuid.ToString();
                    case ItemId:
                        return string.Empty;
                    default:
                        return DummyString;
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            privateObject.SetFieldOrProperty("sbErrors", new StringBuilder());

            // Act
            privateObject.Invoke(ProcessItemRowMethodName,
                row,
                dtItems,
                connection,
                spSite,
                new SaveJob.ExecuteCache(spSite),
                timesheetSettings,
                DummyString,
                DummyString,
                true,
                false);
            var stringBuilder = privateObject.GetFieldOrProperty("sbErrors") as StringBuilder;
            var errorContent = stringBuilder?.ToString();

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.bErrors.ShouldBeTrue(),
                () => errorContent.ShouldNotBeNullOrEmpty(),
                () => errorContent.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void Execute_OnGeneralException_LogsError()
        {
            // Arrange
            var expectedErrorMessage = $"Error: System.Exception: {DummyString}";
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, data) =>
            {
                throw new Exception(DummyString);
            };

            // Act
            saveJob.execute(spSite, DummyString);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.sErrors.ShouldNotBeEmpty(),
                () => saveJob.sErrors.ShouldContain(expectedErrorMessage),
                () => saveJob.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_ConnectionException_LogsError()
        {
            // Arrange
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception(DummyString);
            };

            // Act
            saveJob.execute(spSite, DummyString);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.sErrors.ShouldNotBeEmpty(),
                () => saveJob.sErrors.ShouldContain(DummyString),
                () => saveJob.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_TimesheetDoestNotExist_LogsError()
        {
            // Arrange
            const string ExpectedErrorMessage = "Timesheet does not exist";
            var sqlCommandList = new List<string>();
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimTimesheetAPI.GetUserSPWebString = (web, name) => new ShimSPUser
            {
                IDGet = () => 10
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
                GetInt32Int32 = index => DummyInt,
                GetStringInt32 = index => DummyString
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommandList.Add(command.CommandText);
                return 1;
            };

            // Act
            saveJob.execute(spSite, DummyString);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.sErrors.ShouldNotBeEmpty(),
                () => saveJob.sErrors.ShouldContain(ExpectedErrorMessage),
                () => saveJob.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_UserDoesNotHavePermission_LogsError()
        {
            // Arrange
            const string ExpectedErrorMessage = "You do not have access to edit that timesheet.";
            var sqlCommandList = new List<string>();
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimTimesheetAPI.GetUserSPWebString = (web, name) => new ShimSPUser
            {
                IDGet = () => 10
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                GetInt32Int32 = index => DummyInt,
                GetStringInt32 = index => DummyString
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommandList.Add(command.CommandText);
                return 1;
            };

            // Act
            saveJob.execute(spSite, DummyString);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.sErrors.ShouldNotBeEmpty(),
                () => saveJob.sErrors.ShouldContain(ExpectedErrorMessage),
                () => saveJob.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            var processResourcesWasCalled = false;
            var submitTimesheetWasCalled = false;
            var sqlCommandList = new List<string>();
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            var expectedSqlCommands = new List<string>
            {
                "UPDATE TSTIMESHEET SET LASTMODIFIEDBYU=@uname, LASTMODIFIEDBYN=@name where TS_UID=@tsuid",
                "SELECT * FROM TSITEM WHERE TS_UID=@tsuid",
                "SELECT period_id FROM TSTIMESHEET WHERE TS_UID=@tsuid",
                "update TSQUEUE set percentcomplete=@pct where TSQUEUE_ID=@QueueUid",
                "update TSQUEUE set percentcomplete=98 where TSQUEUE_ID=@QueueUid",
                "DELETE FROM TSITEM where TS_ITEM_UID=@uid",
                "update TSQUEUE set percentcomplete=99 where TSQUEUE_ID=@QueueUid",
                "INSERT INTO TSQUEUE (TS_UID, STATUS, JOBTYPE_ID, USERID, JOBDATA, DTCREATED) VALUES (@tsuid, 0, 32, @userid, @jobdata, GETDATE())"
            };
            ShimTimesheetAPI.GetUserSPWebString = (web, name) => new ShimSPUser
            {
                IDGet = () => DummyInt
            };
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = index => new DataTable()
            };

            var rowCounts = new Dictionary<ShimSqlDataReader, int>();
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                var reader = new ShimSqlDataReader
                {
                    GetInt32Int32 = index => DummyInt,
                    GetStringInt32 = index => DummyString,
                    ItemGetString = s => DummyString
                };
                reader.Read = () => ++rowCounts[reader] <= 2;
                rowCounts.Add(reader, 0);
                return reader;
            };
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection
            {
                ItemOfGetString = name => new ShimXmlAttribute()
                {
                    ValueGet = () => bool.TrueString
                }
            };
            ShimXmlNode.AllInstances.SelectNodesString = (_, node) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateElement(DummyString);
                doc.AppendChild(element);
                return doc.ChildNodes;
            };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyString
                    }
                }.GetEnumerator()
            };
            ShimSharedFunctions.processResourcesSqlConnectionStringSPWebString = (connection, id, web, username) =>
            {
                processResourcesWasCalled = true;
            };
            ShimTimesheetAPI.SubmitTimesheetStringSPWeb = (content, web) =>
            {
                submitTimesheetWasCalled = true;
                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommandList.Add(command.CommandText);
                return 1;
            };
            ShimSaveJob.AllInstances.ProcessItemRowXmlNodeDataTableRefSqlConnectionSPSiteSaveJobExecuteCacheTimesheetSettingsStringStringBooleanBoolean = ProcessItemRow;
            var preloadListItemsWasCalled = false;
            ShimSaveJob.ShimExecuteCache.AllInstances.PreloadListItemsIEnumerableOfSaveDataJobExecuteCacheListItemInfoStringOut = (SaveJob.ExecuteCache cache, IEnumerable<SaveDataJobExecuteCache.ListItemInfo> tuples, out string errors) =>
            {
                preloadListItemsWasCalled = true;
                errors = string.Empty;
                return false;
            };

            // Act
            saveJob.execute(spSite, DummyString);

            // Assert
            saveJob.ShouldSatisfyAllConditions(
                () => saveJob.sErrors.ShouldBeEmpty(),
                () => saveJob.bErrors.ShouldBeFalse(),
                () => preloadListItemsWasCalled.ShouldBeTrue(),
                () => processResourcesWasCalled.ShouldBeTrue(),
                () => submitTimesheetWasCalled.ShouldBeTrue(),
                () => expectedSqlCommands.All(p => sqlCommandList.Contains(p)));
        }

        /// <summary>
        /// This method is fake, all the parameters are required, even though not all of them are used
        /// </summary>
        private void ProcessItemRow(
            SaveJob instance,
            XmlNode ndRow,
            ref DataTable dtItems,
            SqlConnection cn,
            SPSite site,
            SaveJob.ExecuteCache cache,
            TimesheetSettings settings,
            string period,
            string username,
            bool liveHours,
            bool bSkipSP)
        {
            dtItems = new DataTable();
        }
    }
}
