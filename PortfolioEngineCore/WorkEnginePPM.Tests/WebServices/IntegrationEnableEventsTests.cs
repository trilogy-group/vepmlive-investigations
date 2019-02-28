using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationEnableEventsTests : IntegrationTestsBase
    {
        private const string Xml = @"<FirstChild Key=""001"" EventClass=""Class01""/>";
        private bool _updateListCalled;
        private bool _addCalled;
        private bool _deleteCalled;

        [TestMethod]
        public void EnableEvents_NoConfig_Errors()
        {
            // Arrange
            ArrangeEnableTests(false, true, true, true, true, SPEventReceiverType.FieldAdding);
            var result = string.Empty;

            // Act
            Action action = () => result = (string)PrivateObject.Invoke("EnableEvents", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _updateListCalled.ShouldBeFalse(),
                () => _addCalled.ShouldBeFalse(),
                () => _deleteCalled.ShouldBeFalse(),
                () => result.ShouldContain("error", Case.Insensitive),
                () => result.ShouldContain("102"));
        }

        [TestMethod]
        public void EnableEvents_AddingEvent_NoErrors()
        {
            // Arrange
            ArrangeEnableTests(true, true, true, true, true, SPEventReceiverType.FieldAdding);
            var result = string.Empty;

            // Act
            Action action = () => result = (string)PrivateObject.Invoke("EnableEvents", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _updateListCalled.ShouldBeTrue(),
                () => _addCalled.ShouldBeFalse(),
                () => _deleteCalled.ShouldBeTrue(),
                () => result.ShouldNotContain("error", Case.Insensitive));
        }

        [TestMethod]
        public void EnableEvents_AddedEvent_NoErrors()
        {
            EnableEventsAdding(SPEventReceiverType.ItemAdded);
        }

        [TestMethod]
        public void EnableEvents_AddedEvent_NoAdding_NoErrors()
        {
            EnableEventsNotAdding(SPEventReceiverType.ItemAdded);
        }

        [TestMethod]
        public void EnableEvents_UpdatingEvent_NoErrors()
        {
            EnableEventsAdding(SPEventReceiverType.ItemUpdating);
        }
        
        [TestMethod]
        public void EnableEvents_UpdatingEvent_NoAdding_NoErrors()
        {
            EnableEventsNotAdding(SPEventReceiverType.ItemUpdating);
        }

        [TestMethod]
        public void EnableEvents_DeletingEvent_NoErrors()
        {
            EnableEventsAdding(SPEventReceiverType.ItemDeleting);
        }
        
        [TestMethod]
        public void EnableEvents_DeletingEvent_NoAdding_NoErrors()
        {
            EnableEventsNotAdding(SPEventReceiverType.ItemDeleting);
        }

        [TestMethod]
        public void EnableEvents_AddedEvent_Adding_ErrorMessage()
        {
            EnableEventsAddingErrorMessage(SPEventReceiverType.ItemAdded);
        }

        [TestMethod]
        public void EnableEvents_UpdatingEvent_Adding_ErrorMessage()
        {
            EnableEventsAddingErrorMessage(SPEventReceiverType.ItemUpdating);
        }

        [TestMethod]
        public void EnableEvents_DeletingEvent_Adding_ErrorMessage()
        {
            EnableEventsAddingErrorMessage(SPEventReceiverType.ItemDeleting);
        }

        [TestMethod]
        public void EnableEvents_AddedEvent_NoAdding_ErrorMessage()
        {
            EnableEventsNotAddingErrorMessage(SPEventReceiverType.ItemAdded);
        }

        [TestMethod]
        public void EnableEvents_UpdatingEvent_NoAdding_ErrorMessage()
        {
            EnableEventsNotAddingErrorMessage(SPEventReceiverType.ItemUpdating);
        }

        [TestMethod]
        public void EnableEvents_DeletingEvent_NoAdding_ErrorMessage()
        {
            EnableEventsNotAddingErrorMessage(SPEventReceiverType.ItemDeleting);
        }

        private void EnableEventsAdding(SPEventReceiverType spEventReceiverType)
        {
            // Arrange
            ArrangeEnableTests(true, true, true, true, true, spEventReceiverType);
            var result = string.Empty;

            // Act
            Action action = () => result = (string)PrivateObject.Invoke("EnableEvents", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _updateListCalled.ShouldBeTrue(),
                () => _addCalled.ShouldBeFalse(),
                () => _deleteCalled.ShouldBeTrue(),
                () => result.ShouldNotContain("error", Case.Insensitive));
        }

        private void EnableEventsNotAdding(SPEventReceiverType spEventReceiverType)
        {
            // Arrange
            ArrangeEnableTests(true, false, true, true, true, spEventReceiverType);
            var result = string.Empty;

            // Act
            Action action = () => result = (string)PrivateObject.Invoke("EnableEvents", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _updateListCalled.ShouldBeFalse(),
                () => _addCalled.ShouldBeFalse(),
                () => _deleteCalled.ShouldBeFalse(),
                () => result.ShouldNotContain("error", Case.Insensitive));
        }

        private void EnableEventsAddingErrorMessage(SPEventReceiverType spEventReceiverType)
        {
            // Arrange
            ArrangeEnableTests(true, true, false, false, false, spEventReceiverType);
            var result = string.Empty;

            // Act
            Action action = () => result = (string)PrivateObject.Invoke("EnableEvents", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _updateListCalled.ShouldBeTrue(),
                () => _addCalled.ShouldBeTrue(),
                () => _deleteCalled.ShouldBeTrue(),
                () => result.ShouldContain("error", Case.Insensitive));
        }

        private void EnableEventsNotAddingErrorMessage(SPEventReceiverType spEventReceiverType)
        {
            // Arrange
            ArrangeEnableTests(true, false, false, false, false, spEventReceiverType);
            var result = string.Empty;

            // Act
            Action action = () => result = (string)PrivateObject.Invoke("EnableEvents", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _updateListCalled.ShouldBeTrue(),
                () => _addCalled.ShouldBeTrue(),
                () => _deleteCalled.ShouldBeFalse(),
                () => result.ShouldContain("error", Case.Insensitive));
        }

        private void ArrangeEnableTests(
            bool shouldHaveConfig,
            bool shouldAdding,
            bool shouldAdded,
            bool shouldUpdating,
            bool shouldDeleting,
            SPEventReceiverType eventTypeToCheck)
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimConfigFunctions.getConfigSettingSPWebString = (_1, _2) => shouldHaveConfig
                ? "DummySetting1,DummySetting2,DummySetting3,DummySetting4"
                : string.Empty;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_1, _2) => new ShimSPList();
            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection();
            _addCalled = false;
            ShimSPEventReceiverDefinitionCollection.AllInstances.AddSPEventReceiverTypeStringString = (_1, eventType, _2, _3) =>
            {
                if(eventType.Equals(eventTypeToCheck))
                {
                    _addCalled = true;
                }
            };
            ShimSPEventReceiverDefinitionCollection.AllInstances.ItemGetGuid = (_1, _2) => new ShimSPEventReceiverDefinition();
            _deleteCalled = false;
            ShimSPEventReceiverDefinition.AllInstances.Delete = _ => _deleteCalled = true;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPEventReceiverDefinition>
            {
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemAdding,
                    IdGet = () => new Guid("62435184510284517253748591524364"),
                    ClassGet = () => shouldAdding
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemAdded,
                    ClassGet = () => shouldAdded
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemUpdating,
                    ClassGet = () => shouldUpdating
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemDeleting,
                    ClassGet = () => shouldDeleting
                        ? "Class01"
                        : string.Empty
                }
            }.GetEnumerator();
            _updateListCalled = false;
            ShimSPList.AllInstances.Update = _ => _updateListCalled = true;
        }
    }
}