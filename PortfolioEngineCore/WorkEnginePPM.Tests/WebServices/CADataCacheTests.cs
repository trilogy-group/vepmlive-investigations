using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CADataCache;
using CostDataValues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CADataCacheTests
    {
        public CostAnalyzerDataCache _testEntity;
        public PrivateObject _privateObject;
        private const string CopyOverTotFieldsMethod = "CopyOverTotFields";

        private const string DummyCatName = "DummyCatName";
        private const string DummyFullCatName = "DummyFullCatName";
        private const string DummyCcName = "DummyCcName";
        private const string DummyFullCcName = "DummyFullCcName";
        private const string DummyScenName = "DummyScenName";
        private const string DummyCtName = "DummyCtName";
        private const string DummyRoleName = "DummyRoleName";
        private const string DummyPiName = "DummyPiName";
        private const string DummyTextOcVal = "DummyTextOcVal";
        private const string DummyTxVal = "DummyTxVal";
        private const string DummyString = "DummyString";
        private const int DummyInternalId = 10;
        private const int DummyId = 3;
        private const int DummyUid = 4;
        private const int DummyProjectId = 5;
        private const int DummyScenarioId = 6;
        private const int DummyBcUid = 7;
        private const int DummyBcRoleUid = 8;
        private const int DummyCtId = 9;

        [TestInitialize]
        public void TestInitialize()
        {
            _testEntity = new CostAnalyzerDataCache();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void CopyOverTotFields_FirstPassTrue_CopyFields()
        {
            // Arrange
            var detailRowDataOrigin = new clsDetailRowData(1)
            {
                Cat_Name = DummyCatName,
                FullCatName = DummyFullCatName,
                CC_Name = DummyCcName,
                FullCCName = DummyFullCcName,
                Text_OCVal = new string[5]
                {
                    $"{DummyTextOcVal}1",
                    $"{DummyTextOcVal}2",
                    $"{DummyTextOcVal}3",
                    $"{DummyTextOcVal}4",
                    $"{DummyTextOcVal}5"
                },
                TXVal = new string[5]
                {
                    $"{DummyTxVal}1",
                    $"{DummyTxVal}2",
                    $"{DummyTxVal}3",
                    $"{DummyTxVal}4",
                    $"{DummyTxVal}5"
                },
                Scen_Name = DummyScenName,
                CT_Name = DummyCtName,
                Role_Name = DummyRoleName,
                PI_Name = DummyPiName,
                Internal_ID = DummyInternalId,
                m_PI_Format_Extra_data = new string[2]
                {
                    $"{DummyString}1",
                    $"{DummyString}2"
                }
            };

            var detailRowDataDestiny = new clsDetailRowData(1)
            {
                m_PI_Format_Extra_data = new string[2]
            };
            List<clsDataItem> totalRoot = CreateListClsDataItem();

            _privateObject.SetField("m_TotalRoot", totalRoot);

            // Act
            _privateObject.Invoke(CopyOverTotFieldsMethod, detailRowDataDestiny, detailRowDataOrigin, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => detailRowDataDestiny.Cat_Name.ShouldBe(DummyCatName),
                () => detailRowDataDestiny.FullCatName.ShouldBe(DummyFullCatName),
                () => detailRowDataDestiny.CC_Name.ShouldBe(DummyCcName),
                () => detailRowDataDestiny.FullCCName.ShouldBe(DummyFullCcName),
                () => detailRowDataDestiny.Text_OCVal[1].ShouldBe($"{DummyTextOcVal}2"),
                () => detailRowDataDestiny.TXVal[1].ShouldBe($"{DummyTxVal}2"),
                () => detailRowDataDestiny.Scen_Name.ShouldBe(DummyScenName),
                () => detailRowDataDestiny.CT_Name.ShouldBe(DummyCtName),
                () => detailRowDataDestiny.Role_Name.ShouldBe(DummyRoleName),
                () => detailRowDataDestiny.PI_Name.ShouldBe(DummyPiName),
                () => detailRowDataDestiny.Internal_ID.ShouldBe(DummyInternalId),
                () => detailRowDataDestiny.m_PI_Format_Extra_data[0].ShouldBe($"{DummyString}1"));
        }

        [TestMethod]
        public void CopyOverTotFields_FirstPassFalse_CopyFields()
        {
            // Arrange
            var detailRowDataOrigin = new clsDetailRowData(1)
            {
                PROJECT_ID = DummyProjectId,
                CT_ID = DummyCtId,
                Scenario_ID = DummyScenarioId,
                BC_UID = DummyBcUid,
                BC_ROLE_UID = DummyBcRoleUid,
                Cat_Name = DummyCatName,
                FullCatName = DummyFullCatName,
                CC_Name = DummyCcName,
                FullCCName = DummyFullCcName,
                Text_OCVal = new string[5]
                {
                    $"{DummyTextOcVal}1",
                    $"{DummyTextOcVal}2",
                    $"{DummyTextOcVal}3",
                    $"{DummyTextOcVal}4",
                    $"{DummyTextOcVal}5"
                },
                TXVal = new string[5]
                {
                    $"{DummyTxVal}1",
                    $"{DummyTxVal}2",
                    $"{DummyTxVal}3",
                    $"{DummyTxVal}4",
                    $"{DummyTxVal}5"
                },
                Scen_Name = DummyScenName,
                CT_Name = DummyCtName,
                Role_Name = DummyRoleName,
                PI_Name = DummyPiName,
                Internal_ID = DummyInternalId,
                m_PI_Format_Extra_data = new string[2]
                {
                    $"{DummyString}1",
                    $"{DummyString}2"
                }
            };

            var detailRowDataDestiny = new clsDetailRowData(1)
            {
                Cat_Name = DummyCatName,
                FullCatName = DummyFullCatName,
                CC_Name = $"{DummyCcName}2",
                FullCCName = $"{DummyFullCcName}2",
                Text_OCVal = new string[5]
                {
                    $"{DummyTextOcVal}6",
                    $"{DummyTextOcVal}7",
                    $"{DummyTextOcVal}8",
                    $"{DummyTextOcVal}9",
                    $"{DummyTextOcVal}10"
                },
                TXVal = new string[5]
                {
                    $"{DummyTxVal}6",
                    $"{DummyTxVal}7",
                    $"{DummyTxVal}8",
                    $"{DummyTxVal}9",
                    $"{DummyTxVal}10"
                },
                Scen_Name = $"{DummyScenName}2",
                CT_Name = $"{DummyCtName}2",
                Role_Name = DummyRoleName,
                PI_Name = DummyPiName,
                Internal_ID = DummyInternalId,
                m_PI_Format_Extra_data = new string[2]
                {
                    $"{DummyString}3",
                    $"{DummyString}4"
                }
            };
            List<clsDataItem> totalRoot = CreateListClsDataItem();

            _privateObject.SetField("m_TotalRoot", totalRoot);

            // Act
            _privateObject.Invoke(CopyOverTotFieldsMethod, detailRowDataDestiny, detailRowDataOrigin, false);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => detailRowDataDestiny.Cat_Name.ShouldBe(string.Empty),
                () => detailRowDataDestiny.FullCatName.ShouldBe(string.Empty),
                () => detailRowDataDestiny.CC_Name.ShouldBe(string.Empty),
                () => detailRowDataDestiny.FullCCName.ShouldBe(string.Empty),
                () => detailRowDataDestiny.Text_OCVal[1].ShouldBe(string.Empty),
                () => detailRowDataDestiny.TXVal[1].ShouldBe(string.Empty),
                () => detailRowDataDestiny.Scen_Name.ShouldBe($"{DummyScenName}2"),
                () => detailRowDataDestiny.CT_Name.ShouldBe(string.Empty),
                () => detailRowDataDestiny.Role_Name.ShouldBe(string.Empty),
                () => detailRowDataDestiny.PI_Name.ShouldBe(string.Empty),
                () => detailRowDataDestiny.Internal_ID.ShouldBe(0),
                () => detailRowDataDestiny.m_PI_Format_Extra_data[0].ShouldBe($"{DummyString}3"));
        }

        private static List<clsDataItem> CreateListClsDataItem()
        {
            return new List<clsDataItem>()
            {
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = (int)FieldIDs.BC_FID
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = (int)FieldIDs.CAT_FID
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = 11801
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = 11811
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = (int)FieldIDs.SCEN_FID
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = (int)FieldIDs.CT_FID
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = (int)FieldIDs.BC_ROLE
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = DummyId,
                    UID = (int)FieldIDs.PI_FID
                },
                new clsDataItem()
                {
                    bSelected = true,
                    ID = 100,
                    UID = 999
                }
            };
        }
    }
}
