using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using EPMLiveCore.SSRS2006;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SSRS2006
{
    /// <summary>
    /// Unit Tests for remaining small classes in namespace <see cref="EPMLiveCore.SSRS2006"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReferenceTest
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestMethod]
        public void ReportParameterClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ReportParameter());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Type"] = new ParameterTypeEnum(),
                ["TypeSpecified"] = true,
                ["Nullable"] = true,
                ["NullableSpecified"] = true,
                ["AllowBlank"] = true,
                ["AllowBlankSpecified"] = true,
                ["MultiValue"] = true,
                ["MultiValueSpecified"] = true,
                ["QueryParameter"] = true,
                ["QueryParameterSpecified"] = true,
                ["Prompt"] = DummyString,
                ["PromptUser"] = true,
                ["PromptUserSpecified"] = true,
                ["Dependencies"] = new string[] { },
                ["ValidValuesQueryBased"] = true,
                ["ValidValuesQueryBasedSpecified"] = true,
                ["ValidValues"] = new ValidValue[] { },
                ["DefaultValuesQueryBased"] = true,
                ["DefaultValuesQueryBasedSpecified"] = true,
                ["DefaultValues"] = new string[] { },
                ["State"] = new ParameterStateEnum(),
                ["StateSpecified"] = true,
                ["ErrorMessage"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void CatalogItemClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new CatalogItem());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ID"] = DummyString,
                ["Name"] = DummyString,
                ["Path"] = DummyString,
                ["VirtualPath"] = DummyString,
                ["Type"] = new ItemTypeEnum(),
                ["Size"] = DummyInt,
                ["SizeSpecified"] = true,
                ["Description"] = DummyString,
                ["Hidden"] = true,
                ["HiddenSpecified"] = true,
                ["CreationDate"] = new DateTime(2010, 10, 10),
                ["CreationDateSpecified"] = true,
                ["ModifiedDate"] = new DateTime(2010, 10, 10),
                ["ModifiedDateSpecified"] = true,
                ["CreatedBy"] = DummyString,
                ["ModifiedBy"] = DummyString,
                ["MimeType"] = DummyString,
                ["ExecutionDate"] = new DateTime(2010, 10, 10),
                ["ExecutionDateSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void SubscriptionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Subscription());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["SubscriptionID"] = DummyString,
                ["Owner"] = DummyString,
                ["Path"] = DummyString,
                ["VirtualPath"] = DummyString,
                ["Report"] = DummyString,
                ["DeliverySettings"] = new ExtensionSettings(),
                ["Description"] = DummyString,
                ["Status"] = DummyString,
                ["Active"] = new ActiveState(),
                ["LastExecuted"] = new DateTime(2010, 10, 10),
                ["LastExecutedSpecified"] = true,
                ["ModifiedBy"] = DummyString,
                ["ModifiedDate"] = new DateTime(2010, 10, 10),
                ["EventType"] = DummyString,
                ["IsDataDriven"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourceDefinitionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSourceDefinition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Extension"] = DummyString,
                ["ConnectString"] = DummyString,
                ["UseOriginalConnectString"] = true,
                ["OriginalConnectStringExpressionBased"] = true,
                ["CredentialRetrieval"] = new CredentialRetrievalEnum(),
                ["WindowsCredentials"] = true,
                ["ImpersonateUser"] = true,
                ["ImpersonateUserSpecified"] = true,
                ["Prompt"] = DummyString,
                ["UserName"] = DummyString,
                ["Password"] = DummyString,
                ["Enabled"] = true,
                ["EnabledSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSetDefinitionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSetDefinition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Fields"] = new Field[] { },
                ["Query"] = new QueryDefinition(),
                ["CaseSensitivity"] = new SensitivityEnum(),
                ["CaseSensitivitySpecified"] = true,
                ["Collation"] = DummyString,
                ["AccentSensitivity"] = new SensitivityEnum(),
                ["AccentSensitivitySpecified"] = true,
                ["KanatypeSensitivity"] = new SensitivityEnum(),
                ["KanatypeSensitivitySpecified"] = true,
                ["WidthSensitivity"] = new SensitivityEnum(),
                ["WidthSensitivitySpecified"] = true,
                ["Name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void MonthsOfYearSelectorClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new MonthsOfYearSelector());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["January"] = true,
                ["February"] = true,
                ["March"] = true,
                ["April"] = true,
                ["May"] = true,
                ["June"] = true,
                ["July"] = true,
                ["August"] = true,
                ["September"] = true,
                ["October"] = true,
                ["November"] = true,
                ["December"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ScheduleClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Schedule());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ScheduleID"] = DummyString,
                ["Name"] = DummyString,
                ["Definition"] = new ScheduleDefinition(),
                ["Description"] = DummyString,
                ["Creator"] = DummyString,
                ["NextRunTime"] = new DateTime(2010, 10, 10),
                ["NextRunTimeSpecified"] = true,
                ["LastRunTime"] = new DateTime(2010, 10, 10),
                ["LastRunTimeSpecified"] = true,
                ["ReferencesPresent"] = true,
                ["State"] = new ScheduleStateEnum(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ActiveStateClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ActiveState());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["DeliveryExtensionRemoved"] = true,
                ["DeliveryExtensionRemovedSpecified"] = true,
                ["SharedDataSourceRemoved"] = true,
                ["SharedDataSourceRemovedSpecified"] = true,
                ["MissingParameterValue"] = true,
                ["MissingParameterValueSpecified"] = true,
                ["InvalidParameterValue"] = true,
                ["InvalidParameterValueSpecified"] = true,
                ["UnknownReportParameter"] = true,
                ["UnknownReportParameterSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ExtensionParameterClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ExtensionParameter());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["DisplayName"] = DummyString,
                ["Required"] = true,
                ["RequiredSpecified"] = true,
                ["ReadOnly"] = true,
                ["Value"] = DummyString,
                ["Error"] = DummyString,
                ["Encrypted"] = true,
                ["IsPassword"] = true,
                ["ValidValues"] = new ValidValue[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void JobClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Job());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["JobID"] = DummyString,
                ["Name"] = DummyString,
                ["Path"] = DummyString,
                ["Description"] = DummyString,
                ["Machine"] = DummyString,
                ["User"] = DummyString,
                ["StartDateTime"] = new DateTime(2010, 10, 10),
                ["Action"] = new JobActionEnum(),
                ["Type"] = new JobTypeEnum(),
                ["Status"] = new JobStatusEnum(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void SYSTEMTIMEClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new SYSTEMTIME());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["year"] = (short)DummyInt,
                ["month"] = (short)DummyInt,
                ["dayOfWeek"] = (short)DummyInt,
                ["day"] = (short)DummyInt,
                ["hour"] = (short)DummyInt,
                ["minute"] = (short)DummyInt,
                ["second"] = (short)DummyInt,
                ["milliseconds"] = (short)DummyInt,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DaysOfWeekSelectorClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DaysOfWeekSelector());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Sunday"] = true,
                ["Monday"] = true,
                ["Tuesday"] = true,
                ["Wednesday"] = true,
                ["Thursday"] = true,
                ["Friday"] = true,
                ["Saturday"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ServerInfoHeaderClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ServerInfoHeader());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ReportServerVersionNumber"] = DummyString,
                ["ReportServerEdition"] = DummyString,
                ["ReportServerVersion"] = DummyString,
                ["ReportServerDateTime"] = DummyString,
                ["ReportServerTimeZoneInfo"] = new TimeZoneInformation(),
                ["AnyAttr"] = new XmlAttribute[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ExtensionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Extension());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ExtensionType"] = new ExtensionTypeEnum(),
                ["Name"] = DummyString,
                ["LocalizedName"] = DummyString,
                ["Visible"] = true,
                ["IsModelGenerationSupported"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelItemClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelItem());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ID"] = DummyString,
                ["Name"] = DummyString,
                ["Type"] = new ModelItemTypeEnum(),
                ["Description"] = DummyString,
                ["ModelItems"] = new ModelItem[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void TimeZoneInformationClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new TimeZoneInformation());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Bias"] = DummyInt,
                ["StandardBias"] = DummyInt,
                ["StandardDate"] = new SYSTEMTIME(),
                ["DaylightBias"] = DummyInt,
                ["DaylightDate"] = new SYSTEMTIME(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void WarningClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Warning());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Code"] = DummyString,
                ["Severity"] = DummyString,
                ["ObjectName"] = DummyString,
                ["ObjectType"] = DummyString,
                ["Message"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void MonthlyDOWRecurrenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new MonthlyDOWRecurrence());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["WhichWeek"] = new WeekNumberEnum(),
                ["WhichWeekSpecified"] = true,
                ["DaysOfWeek"] = new DaysOfWeekSelector(),
                ["MonthsOfYear"] = new MonthsOfYearSelector(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void QueryDefinitionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new QueryDefinition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["CommandType"] = DummyString,
                ["CommandText"] = DummyString,
                ["Timeout"] = DummyInt,
                ["TimeoutSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ScheduleDefinitionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ScheduleDefinition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["StartDateTime"] = new DateTime(2010, 10, 10),
                ["EndDate"] = new DateTime(2010, 10, 10),
                ["EndDateSpecified"] = true,
                ["Item"] = new RecurrencePattern(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourceCredentialsClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSourceCredentials());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["DataSourceName"] = DummyString,
                ["UserName"] = DummyString,
                ["Password"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourcePromptClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSourcePrompt());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["DataSourceID"] = DummyString,
                ["Prompt"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelCatalogItemClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelCatalogItem());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Model"] = DummyString,
                ["Description"] = DummyString,
                ["Perspectives"] = new ModelPerspective[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelPerspectiveClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelPerspective());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ID"] = DummyString,
                ["Name"] = DummyString,
                ["Description"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ParameterValueClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ParameterValue());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Value"] = DummyString,
                ["Label"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ReportHistorySnapshotClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ReportHistorySnapshot());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["HistoryID"] = DummyString,
                ["CreationDate"] = new DateTime(2010, 10, 10),
                ["Size"] = DummyInt,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void TaskClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Task());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["TaskID"] = DummyString,
                ["Name"] = DummyString,
                ["Description"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void TrustedUserHeaderClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new TrustedUserHeader());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["UserName"] = DummyString,
                ["UserToken"] = new byte[] { },
                ["AnyAttr"] = new XmlAttribute[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void WeeklyRecurrenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new WeeklyRecurrence());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["WeeksInterval"] = DummyInt,
                ["WeeksIntervalSpecified"] = true,
                ["DaysOfWeek"] = new DaysOfWeekSelector(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataRetrievalPlanClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataRetrievalPlan());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Item"] = new DataSourceDefinitionOrReference(),
                ["DataSet"] = new DataSetDefinition(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSource());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Item"] = new DataSourceDefinitionOrReference(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ExtensionSettingsClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ExtensionSettings());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Extension"] = DummyString,
                ["ParameterValues"] = new ParameterValueOrFieldReference[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void FieldClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Field());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Alias"] = DummyString,
                ["Name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelDrillthroughReportClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelDrillthroughReport());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Path"] = DummyString,
                ["Type"] = new DrillthroughType(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void MonthlyRecurrenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new MonthlyRecurrence());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Days"] = DummyString,
                ["MonthsOfYear"] = new MonthsOfYearSelector(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ParameterFieldReferenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ParameterFieldReference());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ParameterName"] = DummyString,
                ["FieldAlias"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void PolicyClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Policy());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["GroupUserName"] = DummyString,
                ["Roles"] = new Role[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void PropertyClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Property());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Value"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void RoleClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Role());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Description"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ScheduleReferenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ScheduleReference());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ScheduleID"] = DummyString,
                ["Definition"] = new ScheduleDefinition(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ValidValueClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ValidValue());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Label"] = DummyString,
                ["Value"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        static private void SetProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            foreach (var keyValuePair in propertiesDictionary)
            {
                privateObject.SetProperty(keyValuePair.Key, keyValuePair.Value);
            }
        }

        private void AssertProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            var assertions = new List<Action>();
            foreach (var keyValuePair in propertiesDictionary)
            {
                assertions.Add(() => privateObject.GetProperty(keyValuePair.Key).ShouldBe(keyValuePair.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}
