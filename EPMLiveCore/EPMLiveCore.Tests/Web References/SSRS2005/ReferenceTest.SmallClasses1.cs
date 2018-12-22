using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using EPMLiveCore.SSRS2005;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SSRS2005
{
    /// <summary>
    /// Unit Tests for remaining small classes in namespace <see cref="EPMLiveCore.SSRS2005"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReferenceTest1
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
                ["CreationDate"] = new DateTime(2010, 10, 10, 10, 10, 10),
                ["CreationDateSpecified"] = true,
                ["ModifiedDate"] = new DateTime(2010, 10, 10, 10, 10, 10),
                ["ModifiedDateSpecified"] = true,
                ["CreatedBy"] = DummyString,
                ["ModifiedBy"] = DummyString,
                ["MimeType"] = DummyString,
                ["ExecutionDate"] = new DateTime(),
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
                ["AnyAttr"] = new XmlAttribute[] { },
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

        private void SetProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            foreach (var kvp in propertiesDictionary)
            {
                privateObject.SetProperty(kvp.Key, kvp.Value);
            }
        }

        private void AssertProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            var assertions = new List<Action>();
            foreach (var kvp in propertiesDictionary)
            {
                assertions.Add(() => privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}
