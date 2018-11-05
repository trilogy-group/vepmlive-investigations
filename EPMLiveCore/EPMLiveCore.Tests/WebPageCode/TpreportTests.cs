using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
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
        private string buildColumnsMethodName = "buildColumns";
        private const string DummyString = "DummyString";
        private string logErrorMethodName = "logError";
        private string buildResourceCapMethodName = "buildResourceCap";

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
            privateObject.Invoke(buildColumnsMethodName, spWeb);

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
            privateObject.Invoke(logErrorMethodName, ErrorMessage);

            // Assert
            logMessage.ShouldBe(ErrorMessage);
        }

        [TestMethod]
        public void buildResourceCap()
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
            privateObject.Invoke(buildResourceCapMethodName, list, DummyString);
            var resourceList = privateObject.GetFieldOrProperty("lstResourceCap") as SortedList;

            // Assert
            resourceList.ShouldSatisfyAllConditions(
                () => resourceList.ShouldNotBeNull(),
                () => resourceList.Count.ShouldBeGreaterThan(0));
        }

    }
}
