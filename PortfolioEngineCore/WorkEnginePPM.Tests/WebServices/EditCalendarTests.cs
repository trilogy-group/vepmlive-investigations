using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class EditCalendarTests
    {
        private IDisposable _shimsContext;
        private PrivateType _privateType;

        [TestInitialize]
        public void Setup()
        {
            _shimsContext = ShimsContext.Create();
            _privateType = new PrivateType(typeof(EditCalendar));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void CreateCalendarGrid_EverythingOk_EnsureFlow()
        {
            // Arrange
            var initializeWasCalled = false;
            var subStructsCreated = new HashSet<string>();
            var createdIntAttributes = new Dictionary<string, int>();
            var createdStrAttributes = new Dictionary<string, string>();
            var createdBoolAttributes = new Dictionary<string, bool>();

            ShimCStruct.Constructor = cStruct => new ShimCStruct(cStruct);
            ShimCStruct.AllInstances.InitializeString = (_1, _2) => initializeWasCalled = true;
            ShimCStruct.AllInstances.CreateSubStructString = (_1, str) =>
            {
                subStructsCreated.Add(str);
                return new ShimCStruct();
            };
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, key, value) => createdIntAttributes[key] = value;
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, key, value) => createdStrAttributes[key] = value;
            ShimCStruct.AllInstances.CreateBooleanAttrStringBoolean =
                (_, key, value) => createdBoolAttributes[key] = value;

            // Act
            var result = _privateType.InvokeStatic("CreateCalendarGrid");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeOfType<CStruct>(),
                () => initializeWasCalled.ShouldBeTrue(),
                () => subStructsCreated.ShouldContain(str => str == "Toolbar"),
                () => subStructsCreated.ShouldContain(str => str == "Panel"),
                () => subStructsCreated.ShouldContain(str => str == "Cfg"),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="Visible" && pair.Value == 1),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="Delete" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="MaxHeight" && pair.Value == 300),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="ShowDeleted" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="Deleting" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="Selecting" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="ColResizing" && pair.Value == 1),
                () => createdBoolAttributes.ShouldContain(pair => pair.Key=="DateStrings" && pair.Value),
                () => createdBoolAttributes.ShouldContain(pair => pair.Key=="NoTreeLines" && pair.Value),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="MaxWidth" && pair.Value == 1),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="AppendId" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="FullId" && pair.Value == 0),
                () => createdStrAttributes.ShouldContain(pair => pair.Key=="IdChars" && pair.Value == "0123456789"),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="NumberId" && pair.Value == 1),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="FilterEmpty" && pair.Value == 1),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="Dragging" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="DragEdit" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="ExportFormat" && pair.Value == 1),
                () => createdStrAttributes.ShouldContain(pair => pair.Key=="IdPrefix" && pair.Value == "R"),
                () => createdStrAttributes.ShouldContain(pair => pair.Key=="IdPostfix" && pair.Value == "x"),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="CaseSensitiveId" && pair.Value == 0),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="CaseSensitiveId" && pair.Value == 0),
                () => createdStrAttributes.ShouldContain(pair => pair.Key=="Code" && pair.Value == "GTACCNPSQEBSLC"),
                () => createdStrAttributes.ShouldContain(pair => pair.Key=="Style" && pair.Value == "GM"),
                () => createdStrAttributes.ShouldContain(pair => pair.Key=="CSS" && pair.Value == "ResPlanAnalyzer"),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="LeftWidth" && pair.Value == 500),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="SuppressCfg" && pair.Value == 1),
                () => createdIntAttributes.ShouldContain(pair => pair.Key=="Sorting" && pair.Value == 0));
        }
    }
}
