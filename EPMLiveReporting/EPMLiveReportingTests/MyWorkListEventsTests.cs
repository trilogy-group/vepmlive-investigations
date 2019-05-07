using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveReportsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Microsoft.QualityTools.Testing.Fakes;
using EPMLiveReportsAdmin.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using System.Reflection;

namespace EPMLiveReportsAdmin.Tests
{
    [TestClass()]
    public class MyWorkListEventsTests
    {
        private IDisposable _context;
        private string DummyString = "Dummy String";

        private string InitializeMethodName = "Initialize";
        private int DummyInt = 0;
        private bool _disposeWasCalled;
        private bool _CancelledCalled = false;

        private MyWorkListEvents _myWorkListEvents;
        private PrivateObject _privateObject;
        PrivateType _privateType;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _myWorkListEvents = new MyWorkListEvents();
            _privateObject = new PrivateObject(_myWorkListEvents);
            _privateType = new PrivateType(typeof(MyWorkListEvents));
        }

        [TestMethod()]
        public void ItemDeletingTest_When_ItemDeleting_Initialize_True()
        {
            // Arrange
            bool Initialize = true;
            ShimMyWorkListEvents.AllInstances.InitializeBooleanSPItemEventProperties = (_, __, ___) => { return Initialize; };
            SetupShim();

            // Act
            var properties = CreateSPItemEventProperties();
            _myWorkListEvents.ItemDeleting(properties);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _disposeWasCalled.ShouldBe(true),
                () => _CancelledCalled.ShouldBe(false));
        }

        [TestMethod()]
        public void ItemDeletingTest_When_ItemDeleting_Initialize_False()
        {
            // Arrange
            bool Initialize = false;
            ShimMyWorkListEvents.AllInstances.InitializeBooleanSPItemEventProperties = (_, __, ___) => { return Initialize; };
            SetupShim();

            // Act
            var properties = CreateSPItemEventProperties();
            _myWorkListEvents.ItemDeleting(properties);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _disposeWasCalled.ShouldBe(true),
                () => _CancelledCalled.ShouldBe(true));
        }

        [TestMethod()]
        public void ItemDeletingTest_When_ItemDeleting_Initialize_Throw_Exception()
        {
            // Arrange
            ShimMyWorkListEvents.AllInstances.InitializeBooleanSPItemEventProperties = (_, __, ___) => { throw new Exception(); };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            SetupShim();

            // Act
            var properties = CreateSPItemEventProperties();
            _myWorkListEvents.ItemDeleting(properties);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _disposeWasCalled.ShouldBe(true),
                () => _CancelledCalled.ShouldBe(true));
        }
        
        private void SetupShim()
        {
            ShimMyWorkListEvents.AllInstances.DeleteItem = (_) => { return true; };
            ShimMyWorkListEvents.AllInstances.LogEventExceptionInt32String = (_, __, ___, ____) => { };
            ShimReportData.AllInstances.GetTableNameGuid = (_, __) =>
            {
                return DummyString;
            };
            ShimReportData.AllInstances.ListReportsWorkString = (_, __) => { return true; };
            ShimReportData.AllInstances.DeleteWorkGuidInt32 = (_, __, ___) => { return true; };
            ShimReportData.AllInstances.Dispose = (_) =>
            {
                _disposeWasCalled = true;
            };
            ShimSPEventPropertiesBase.AllInstances.StatusSetSPEventReceiverStatus = (_, __) =>
            {
                _CancelledCalled = true;
            };
            
            var properties = CreateSPItemEventProperties();
            var _listItem = new ShimSPListItem
            {
                ParentListGet = () =>
                {
                    return new ShimSPList()
                    {
                        IDGet = () => Guid.Empty
                    };
                }

            };
            _privateObject.SetFieldOrProperty("_listItem", _listItem.Instance);
            _privateObject.SetFieldOrProperty("_myWorkReportData", new ShimMyWorkReportData().Instance);
            _privateObject.SetFieldOrProperty("_properties", properties.Instance);
        }

        private ShimSPItemEventProperties CreateSPItemEventProperties()
        {
            return new ShimSPItemEventProperties()
            {
                ListItemIdGet = () =>
                {
                    return DummyInt;
                },
                ListTitleGet = () =>
                {
                    return DummyString;
                },
                ListIdGet = () =>
                {
                    return Guid.Empty;
                },
                ListItemGet = () => new ShimSPListItem
                {
                    ParentListGet = () =>
                    {
                        return new ShimSPList()
                        {
                            IDGet = () => Guid.Empty
                        };
                    }
                }
            };
        }
    }
}