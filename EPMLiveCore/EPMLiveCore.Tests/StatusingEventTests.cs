using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class StatusingEventTests
    {
        private const int Id = 1;
        private const string Zero = "0";
        private const string Half = ".5";
        private const string One = "1";
        private const string Two = "2";
        private const string Three = "3";
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string StatusInProgress = "In Progress";
        private const string StatusCompleted = "Completed";
        private const string MethodProcessItem = "processItem";
        private const string KeyPercentComplete = "PercentComplete";
        private const string KeyStatus = "Status";
        private const string KeyComplete = "Complete";
        private StatusingEvent _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private Guid _siteId;
        private Guid _webId;
        private string _percentComplete;
        private string _complete;
        private string _status;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new StatusingEvent();
            _privateObject = new PrivateObject(_testObject);

            _percentComplete = null;
            _complete = null;
            _status = null;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void ProcessItem_AllHidden_DoesNotSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimSPField.AllInstances.HiddenGet = _ => true;

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldBeNull(),
                () => _complete.ShouldBeNull(),
                () => _status.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessItem_MethodOne_SetsProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => One;

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe("0.3333333"),
                () => _complete.ShouldBe(Half),
                () => _status.ShouldBe(Half));
        }

        [TestMethod]
        public void ProcessItem_MethodTwo_SetsProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Two;

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(Zero),
                () => _complete.ShouldBe(Half),
                () => _status.ShouldBe(Half));
        }

        [TestMethod]
        public void ProcessItem_MethodInvalid_SetsProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Three;

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(Half),
                () => _complete.ShouldBe(Half),
                () => _status.ShouldBe(Half));
        }

        [TestMethod]
        public void ProcessItem_NoAfterProperties_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) => null;

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(DummyString),
                () => _complete.ShouldBe(Zero),
                () => _status.ShouldBe(StatusInProgress));
        }

        [TestMethod]
        public void ProcessItem_NoAfterPropertiesWithFieldDefaultStatus_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) => null;
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.DefaultValueGet = _ => Two;

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(DummyString),
                () => _complete.ShouldBe(Zero),
                () => _status.ShouldBe(Two));
        }

        [TestMethod]
        public void ProcessItem_HasCompleteHalfButNotPercentComplete_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Three;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case KeyPercentComplete:
                        return null;
                    default:
                        return GetAfterProperty(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(DummyString),
                () => _complete.ShouldBe(Half),
                () => _status.ShouldBe(Half));
        }

        [TestMethod]
        public void ProcessItem_HasCompleteTrueButNotPercentComplete_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Three;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case KeyPercentComplete:
                        return null;
                    case KeyComplete:
                        return One;
                    default:
                        return GetAfterProperty(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(One),
                () => _complete.ShouldBe(One),
                () => _status.ShouldBe(Half));
        }

        [TestMethod]
        public void ProcessItem_HasCompleteEmptyButNotPercentComplete_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Two;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case KeyPercentComplete:
                        return null;
                    case KeyComplete:
                        return DummyString;
                    default:
                        return GetAfterProperty(key);
                }
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Work":
                        return DummyString;
                    default:
                        return GetItemFromList(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(DummyString),
                () => _complete.ShouldBe(DummyString),
                () => _status.ShouldBe(Half));
        }

        [TestMethod]
        public void ProcessItem_HasCompleteTrueButNoStatus_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Three;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case KeyStatus:
                        return string.Empty;
                    case KeyComplete:
                        return One;
                    default:
                        return GetAfterProperty(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(Half),
                () => _complete.ShouldBe(One),
                () => _status.ShouldBe(StatusCompleted));
        }

        [TestMethod]
        public void ProcessItem_HasCompleteFalseButNoStatus_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Three;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case KeyStatus:
                        return string.Empty;
                    case KeyComplete:
                        return Zero;
                    default:
                        return GetAfterProperty(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(Half),
                () => _complete.ShouldBe(Zero),
                () => _status.ShouldBe(StatusInProgress));
        }

        [TestMethod]
        public void ProcessItem_HasNoCompleteOrStatusOrPercent_DoesntSetProperties()
        {
            // Arrange
            var eventProperties = new ShimSPItemEventProperties();
            PrepareToProcess();
            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Three;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case KeyStatus:
                        return string.Empty;
                    case KeyComplete:
                        return null;
                    case KeyPercentComplete:
                        return null;
                    default:
                        return GetAfterProperty(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessItem, new object[] { eventProperties.Instance, true });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _percentComplete.ShouldNotBeNull(),
                () => _complete.ShouldNotBeNull(),
                () => _status.ShouldNotBeNull(),
                () => _percentComplete.ShouldBe(DummyString),
                () => _complete.ShouldBe(Zero),
                () => _status.ShouldBe(StatusInProgress));
        }

        private void PrepareToProcess()
        {
            _siteId = Guid.NewGuid();
            _webId = Guid.NewGuid();
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection();
            ShimSPItemEventProperties.AllInstances.ListGet = _ => new ShimSPList();
            ShimSPItemEventProperties.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPItemEventProperties.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPItemEventProperties.AllInstances.ListTitleGet = _ => "ListTitle";
            ShimSPEventPropertiesBase.AllInstances.SiteIdGet = _ => _siteId;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.ItemGetString = (_, key) => GetItemFromList(key);

            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.HiddenGet = _ => false;

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, key) => GetAfterProperty(key);
            ShimSPItemEventDataCollection.AllInstances.ItemSetStringObject = (_, key, value) => SetAfterProperty(key, value);
            ShimSPItemEventDataCollection.AllInstances.GetEnumerator = _ => new DictionaryEntry[]
            {
                new DictionaryEntry("FieldName", "value")
            }.GetEnumerator();

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();

            ShimSPWeb.AllInstances.IDGet = _ => _webId;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();

            ShimPlannerCore.getStatusMethodSPWebString = (_, __) => Two;
        }

        private string GetItemFromList(string key)
        {
            switch (key)
            {
                case "Work":
                    return Two;
                default:
                    return DummyString;
            }
        }

        private string GetAfterProperty(string key)
        {
            switch (key)
            {
                case "ActualWork":
                    return One;
                case "RemainingWork":
                    return Two;
                default:
                    return Half;
            }
        }

        private void SetAfterProperty(string key, object value)
        {
            switch (key)
            {
                case KeyPercentComplete:
                    _percentComplete = value as string;
                    break;
                case KeyComplete:
                    _complete = value as string;
                    break;
                case KeyStatus:
                    _status = value as string;
                    break;
            }
        }
    }
}
