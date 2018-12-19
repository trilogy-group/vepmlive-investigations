using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;
using static WorkEnginePPM.EditCosts;

namespace WorkEnginePPM.Tests.WebServices
{
    public partial class EditCostsTests
    {
        [TestMethod]
        public void CheckStatus_PermissionFalse_ReturnsString()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            ShimdbaGeneral.CheckUserGlobalPermissionDBAccessGlobalPermissionsEnum = (dbAccess, permUid) => false;

            // Act
            var actualResult = _testEntity.CheckStatus(DummyString);

            // Assert
            actualResult.ShouldBe("You do not have permission to view cost plan");
        }

        [TestMethod]
        public void CheckStatus_PermissionForProjectFalse_ReturnsString()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            ShimdbaGeneral.CheckUserGlobalPermissionDBAccessGlobalPermissionsEnum = (dbAccess, permUid) => true;
            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dbAccess, string extUid, out int projectId) =>
            {
                projectId = 1;
                return StatusEnum.rsSuccess;
            };
            ShimdbaGeneral.CheckUserPermissionForProjectDBAccessInt32StringOut = (DBAccess dbAccess, int projectId, out string status) =>
            {
                status = DummyString;
                return status;
            };

            // Act
            var actualResult = _testEntity.CheckStatus(DummyBaseInfo);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CheckStatus_AuthenticateUserAndProductFalse_ReturnsString()
        {
            // Arrange
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return false;
            };

            // Act
            var actualResult = _testEntity.CheckStatus(DummyBaseInfo);

            // Assert
            actualResult.ShouldBe($"AuthenticateUserAndProduct failed STAGE={DummyString}");
        }

        [TestMethod]
        public void GetPiList_Should_ReturnsListPiFilled()
        {
            // Arrange
            ShimdbaGeneral.GetPIListDBAccessStringOut = (DBAccess dba, out string sReply) =>
            {
                var xPIs = new CStruct();
                xPIs.Initialize("PIs");
                var xPi = xPIs.CreateSubStruct("PI");
                xPi.CreateIntAttr("id", DummyInt);
                xPi.CreateStringAttr("name", DummyProjectResourceName);

                sReply = xPIs.XML();
                return true;
            };

            // Act
            var actualResult = _testEntity.GetPIList();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].Id.ShouldBe(DummyInt),
                () => actualResult[0].Name.ShouldBe(DummyProjectResourceName));
        }

        [TestMethod]
        public void GetPiList_DbaAccessOpenFail_ReturnsListPiEmpty()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            // Act
            var actualResult = _testEntity.GetPIList();

            // Assert
            actualResult.Count.ShouldBe(0);
        }

        [TestMethod]
        public void GetViewList_Should_ReturnsListViewFilled()
        {
            // Arrange
            ShimdbaEditCosts.SelectViewsDBAccessDataTableOut = (DBAccess dbAccess, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(ViewUidFieldName);
                dataTable.Columns.Add(ViewNameFieldName);

                var dataRow = dataTable.NewRow();
                dataRow[ViewUidFieldName] = DummyInt;
                dataRow[ViewNameFieldName] = DummyViewName;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.GetViewList();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].Uid.ShouldBe(DummyInt),
                () => actualResult[0].Name.ShouldBe(DummyViewName));
        }

        [TestMethod]
        public void GetViewList_DbaAccessOpenFail_ReturnsListViewEmpty()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            // Act
            var actualResult = _testEntity.GetViewList();

            // Assert
            actualResult.Count.ShouldBe(0);
        }

        [TestMethod]
        public void GetCostTypes_Should_ReturnsListViewFilled()
        {
            // Arrange
            ShimdbaEditCosts.SelectCostTypesByViewDBAccessInt32DataTableOut = (DBAccess dbAccess, int viewUid, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeIdFieldName);
                dataTable.Columns.Add(CostTypeNameFieldName);
                dataTable.Columns.Add(CostTypeEditModeFieldName);
                dataTable.Columns.Add(CostTypeInitialLevelFieldName);
                dataTable.Columns.Add(CostTypeAllowNamedRatesFieldName);

                var dataRow = dataTable.NewRow();
                dataRow[CostTypeIdFieldName] = DummyCostTypeId1;
                dataRow[CostTypeNameFieldName] = DummyCostTypeName;
                dataRow[CostTypeEditModeFieldName] = _costTypeEditMode;
                dataRow[CostTypeInitialLevelFieldName] = DummyCostTypeInitialLevel;
                dataRow[CostTypeAllowNamedRatesFieldName] = DummyCostTypeIncludeNamedRates;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };

            ShimdbaEditCosts.CheckCostTypeSecurityDBAccessInt32Int32Ref = (DBAccess dbAccess, int costTypeId, ref int costTypeEditMode) => true;

            // Act
            var actualResult = _testEntity.GetCostTypes(WepId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].Id.ShouldBe(DummyCostTypeId1),
                () => actualResult[0].Name.ShouldBe(DummyCostTypeName),
                () => actualResult[0].EditMode.ShouldBe(_costTypeEditMode),
                () => actualResult[0].InitialLevel.ShouldBe(DummyCostTypeInitialLevel),
                () => actualResult[0].IncludeNamedRates.ShouldBe(DummyCostTypeIncludeNamedRates));
        }

        [TestMethod]
        public void GetCostTypes_DbaAccessOpenFail_ReturnsListViewEmpty()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            // Act
            var actualResult = _testEntity.GetCostTypes(DummyString);

            // Assert
            actualResult.Count.ShouldBe(0);
        }

        [TestMethod]
        public void GetNamedRates_Should_ReturnsListViewFilled()
        {
            // Arrange
            ShimdbaEditCosts.SelectNamedRateValuesDBAccessDataTableOut = (DBAccess dbAccess, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(NamedRateUidFieldName);
                dataTable.Columns.Add(NamedRateEffectiveDateFieldName);
                dataTable.Columns.Add(NamedRateRateFieldName);

                var dataRow = dataTable.NewRow();
                dataRow[NamedRateUidFieldName] = DummyNamedRateId;
                dataRow[NamedRateEffectiveDateFieldName] = DummyDateTime;
                dataRow[NamedRateRateFieldName] = DummyInt;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };

            ShimdbaEditCosts.CheckCostTypeSecurityDBAccessInt32Int32Ref = (DBAccess dbAccess, int costTypeId, ref int costTypeEditMode) => true;

            // Act
            var actualResult = _testEntity.GetNamedRates();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].Id.ShouldBe(DummyNamedRateId),
                () => actualResult[0].EffectiveDate.ShouldBe(DummyDateTime),
                () => actualResult[0].Rate.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void GetNamedRates_DbaAccessOpenFail_ReturnsListViewEmpty()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            // Act
            var actualResult = _testEntity.GetNamedRates();

            // Assert
            actualResult.Count.ShouldBe(0);
        }

        [TestMethod]
        public void GetPeriods_Should_ReturnsListViewFilled()
        {
            // Arrange
            ShimdbaEditCosts.SelectViewCalendarInfoDBAccessInt32Int32OutInt32OutInt32Out = (DBAccess dbAccess, int viewUid, out int calendarId, out int firstPeriod, out int lastPeriod) =>
            {
                calendarId = DummyCostTypeCalendarId;
                firstPeriod = Int32.MinValue;
                lastPeriod = Int32.MaxValue;
                return StatusEnum.rsSuccess;
            };

            ShimdbaEditCosts.SelectCalendarPeriodsDBAccessInt32DataTableOut = (DBAccess dbAccess, int calendarId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(PeriodIdFieldName);
                dataTable.Columns.Add(PeriodNameFieldName);
                dataTable.Columns.Add(PeriodStartDateFieldName);
                dataTable.Columns.Add(PeriodFinishDateFieldName);

                var dataRow = dataTable.NewRow();
                dataRow[PeriodIdFieldName] = DummyPeriodId1;
                dataRow[PeriodNameFieldName] = DummyPeriodName1;
                dataRow[PeriodStartDateFieldName] = DummyStartDate1;
                dataRow[PeriodFinishDateFieldName] = DummyFinishDate1;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };

            ShimdbaEditCosts.CheckCostTypeSecurityDBAccessInt32Int32Ref = (DBAccess dbAccess, int costTypeId, ref int costTypeEditMode) => true;

            // Act
            var actualResult = _testEntity.GetPeriods(DummyViewUid);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].Id.ShouldBe(DummyPeriodId1),
                () => actualResult[0].Name.ShouldBe(DummyPeriodName1),
                () => actualResult[0].StartDate.ShouldBe(DummyStartDate1),
                () => actualResult[0].FinishDate.ShouldBe(DummyFinishDate1));
        }

        [TestMethod]
        public void GetPeriods_DbaAccessOpenFail_ReturnsListViewEmpty()
        {
            // Arrange
            _sqlDb.Open = () => StatusEnum.rsRequestInvalid;

            // Act
            var actualResult = _testEntity.GetPeriods(DummyViewUid);

            // Assert
            actualResult.Count.ShouldBe(0);
        }

        [TestMethod]
        public void CheckInPi_SelectProjectIdFail_ReturnStringEmpty()
        {
            // Arrange
            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dba, string extUid, out int projectId) =>
            {
                projectId = 0;
                return StatusEnum.rsWSSUnknownError;
            };

            // Act
            var actualResult = _testEntity.CheckInPI(0, WepId);

            // Assert
            actualResult.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void CheckInPi_CheckInPiFail_ReturnStringEmpty()
        {
            // Arrange
            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dba, string extUid, out int projectId) =>
            {
                projectId = DummyInt;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.CheckinPIDBAccessInt32Int32Out = (DBAccess dba, int projectId, out int rowsAffected) =>
            {
                rowsAffected = 0;
                return StatusEnum.rsWSSUnknownError;
            };

            // Act
            var actualResult = _testEntity.CheckInPI(0, WepId);

            // Assert
            actualResult.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void CheckInPi_Should_ReturnStringEmpty()
        {
            // Arrange
            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dba, string extUid, out int projectId) =>
            {
                projectId = DummyInt;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.CheckinPIDBAccessInt32Int32Out = (DBAccess dba, int projectId, out int rowsAffected) =>
            {
                rowsAffected = 0;
                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.CheckInPI(0, WepId);

            // Assert
            actualResult.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void MergeCostCategories_List2FinishFirst_ReturnsListCostCategory()
        {
            // Arrange
            SetupMergeCostCategories();
            var costTypeOperation = _costTypeOperationCtor.Invoke(new object[] { });

            // Act
            var actualResult = (List<CostCategory>)_privateObject.Invoke(MergeCostCategoriesMethodName, _dbAccess.Instance, _costCategoryList1, _costCategoryList2, costTypeOperation);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(5),
                () => actualResult[0].Id.ShouldBe(2),
                () => actualResult[1].Id.ShouldBe(3),
                () => actualResult[2].Id.ShouldBe(4),
                () => actualResult[3].Id.ShouldBe(6),
                () => actualResult[4].Id.ShouldBe(7));
        }

        [TestMethod]
        public void MergeCostCategories_List1FinishFirst_ReturnsListCostCategory()
        {
            // Arrange
            SetupMergeCostCategories();
            var costTypeOperation = _costTypeOperationCtor.Invoke(new object[] { });

            // Act
            var actualResult = (List<CostCategory>)_privateObject.Invoke(MergeCostCategoriesMethodName, _dbAccess.Instance, _costCategoryList2, _costCategoryList1, costTypeOperation);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(5),
                () => actualResult[0].Id.ShouldBe(2),
                () => actualResult[1].Id.ShouldBe(3),
                () => actualResult[2].Id.ShouldBe(4),
                () => actualResult[3].Id.ShouldBe(6),
                () => actualResult[4].Id.ShouldBe(7));
        }

        [TestMethod]
        public void MergeCostCategoryValues_CostCategory1PeriodFinishFirst_ReturnsCostCategory()
        {
            // Arrange
            SetupMergeCostCategoryValues();

            // Act
            var actualResult = (CostCategory)_privateObject.Invoke(MergeCostCategoryValuesMethodName, _costCategory1, _costCategory2, 1);

            //  Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.periodCostValues.Count.ShouldBe(5),
                () => actualResult.periodCostValues[0].PeriodId.ShouldBe(1),
                () => actualResult.periodCostValues[1].PeriodId.ShouldBe(2),
                () => actualResult.periodCostValues[2].PeriodId.ShouldBe(3),
                () => actualResult.periodCostValues[3].PeriodId.ShouldBe(4),
                () => actualResult.periodCostValues[4].PeriodId.ShouldBe(5));
        }

        [TestMethod]
        public void MergeCostCategoryValues_CostCategory2PeriodFinishFirst_ReturnsCostCategory()
        {
            // Arrange
            SetupMergeCostCategoryValues();

            // Act
            var actualResult = (CostCategory)_privateObject.Invoke(MergeCostCategoryValuesMethodName, _costCategory2, _costCategory1, 1);

            //  Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.periodCostValues.Count.ShouldBe(5),
                () => actualResult.periodCostValues[0].PeriodId.ShouldBe(1),
                () => actualResult.periodCostValues[1].PeriodId.ShouldBe(2),
                () => actualResult.periodCostValues[2].PeriodId.ShouldBe(3),
                () => actualResult.periodCostValues[3].PeriodId.ShouldBe(4),
                () => actualResult.periodCostValues[4].PeriodId.ShouldBe(5));
        }

        [TestMethod]
        public void MergeCostCategoryValues_CostCategory1Null_ReturnsCostCategory()
        {
            // Arrange
            SetupMergeCostCategoryValues();

            // Act
            var actualResult = (CostCategory)_privateObject.Invoke(MergeCostCategoryValuesMethodName, (CostCategory)null, _costCategory2, 1);

            //  Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.periodCostValues.Count.ShouldBe(3),
                () => actualResult.periodCostValues[0].PeriodId.ShouldBe(1),
                () => actualResult.periodCostValues[1].PeriodId.ShouldBe(3),
                () => actualResult.periodCostValues[2].PeriodId.ShouldBe(4));
        }

        [TestMethod]
        public void MergeCostCategoryValues_CostCategory2Null_ReturnsCostCategory()
        {
            // Arrange
            SetupMergeCostCategoryValues();

            // Act
            var actualResult = (CostCategory)_privateObject.Invoke(MergeCostCategoryValuesMethodName, _costCategory1, (CostCategory)null, 1);

            //  Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.periodCostValues.Count.ShouldBe(3),
                () => actualResult.periodCostValues[0].PeriodId.ShouldBe(1),
                () => actualResult.periodCostValues[1].PeriodId.ShouldBe(2),
                () => actualResult.periodCostValues[2].PeriodId.ShouldBe(5));
        }

        [TestMethod]
        public void BuildJsonLookup_BiggerLevel_ReturnsJson()
        {
            // Arrange
            var lookupItems = new LookupItem[]
            {
                new LookupItem()
                {
                    Level = 1,
                    Inactive = true,
                    Uid = DummyLookupItemUid1,
                    Name = DummyLookupItemName1
                },
                new LookupItem()
                {
                    Level = 1,
                    Inactive = false,
                    Uid = DummyLookupItemUid2,
                    Name = DummyLookupItemName2
                },
                new LookupItem()
                {
                    Level = 2,
                    Uid = DummyLookupItemUid3,
                    Name = DummyLookupItemName3
                },
                new LookupItem()
                {
                    Level = 0,
                    Uid = DummyLookupItemUid4,
                    Name = DummyLookupItemName4
                }
            };

            var expectedResult = new List<string>()
            {
                $"{{Name:'{DummyLookupItemUid1}',Text:'{DummyLookupItemName1}',Disabled:1,Value:'{DummyLookupItemUid1}_{DummyLookupItemName1}'}},",
                $"{{Name:'{DummyLookupItemUid2}',Text:'{DummyLookupItemName2}',Disabled:1,Value:'{DummyLookupItemUid2}_{DummyLookupItemName2}'}},",
                $"{{Name:'Level{DummyLookupItemUid2}',Expanded:-1,Level:1,Items:[{{Name:'{DummyLookupItemUid3}',Text:'{DummyLookupItemName3}',Value:'{DummyLookupItemUid3}_{DummyLookupItemName3}'}}]}}"
            };

            // Act
            var actualResult = (string)_privateObject.Invoke(BuildJsonLookupMethodName, lookupItems, 0, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void BuildJsonLookup_SameLevel_ReturnsJson()
        {
            // Arrange
            var lookupItems = new LookupItem[]
            {
                new LookupItem()
                {
                    Level = 1,
                    Inactive = true,
                    Uid = DummyLookupItemUid1,
                    Name = DummyLookupItemName1
                },
                new LookupItem()
                {
                    Level = 1,
                    Inactive = false,
                    Uid = DummyLookupItemUid2,
                    Name = DummyLookupItemName2
                }
            };

            var expectedResult = new List<string>()
            {
                $"{{Name:'{DummyLookupItemUid1}',Text:'{DummyLookupItemName1}',Disabled:1,Value:'{DummyLookupItemUid1}_{DummyLookupItemName1}'}},",
                $"{{Name:'{DummyLookupItemUid2}',Text:'{DummyLookupItemName2}',Value:'{DummyLookupItemUid2}_{DummyLookupItemName2}'}}"
            };

            // Act
            var actualResult = (string)_privateObject.Invoke(BuildJsonLookupMethodName, lookupItems, 0, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void SendXmlToWorkEngine_ThrowException_ReturnsStatus()
        {
            // Arrange
            var xmlNode = new XmlDocument().CreateNode(XmlNodeType.Element, "nodeName", string.Empty);
            ShimIntegration.Constructor = sender =>
            {
                throw new Exception();
            };

            var parameters = new object[]
            {
                _dbAccess.Instance,
                string.Empty,
                string.Empty,
                string.Empty,
                xmlNode
            };

            // Act
            var actualResult = (StatusEnum)_privateType.InvokeStatic(SendXmlToWorkEngineMethodName, parameters);

            // Assert
            actualResult.ShouldBe((StatusEnum)99830);
        }

        [TestMethod]
        public void BuildCalculatedData_CostTypeOperationsEmpty_ReturnStatus()
        {
            // Arrange
            var costCategories = new List<CostCategory>();

            var parameters = new object[]
            {
                _dbAccess.Instance,
                0,
                0,
                0,
                0,
                costCategories
            };

            ShimdbaEditCosts.SelectCostTypeOperationsDBAccessInt32DataTableOut = (DBAccess dba, int costTypeId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeOperationIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeOperationOperationFieldName, typeof(int));

                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = (StatusEnum)_privateObject.Invoke(BuildCalculatedDataMethodName, parameters);

            // Assert
            actualResult.ShouldBe((StatusEnum)99837);
        }

        [TestMethod]
        public void BuildCalculatedData_EditMode101_ReturnStatus()
        {
            // Arrange
            SetupShimDbaEditCosts();

            var parameters = new object[]
            {
                _dbAccess.Instance,
                0,
                0,
                0,
                0,
                new List<CostCategory>()
            };

            ShimdbaEditCosts.SelectCostTypeOperationsDBAccessInt32DataTableOut = (DBAccess dba, int costTypeId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeOperationIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeOperationOperationFieldName, typeof(int));

                var dataRow = dataTable.NewRow();
                dataRow[CostTypeOperationIdFieldName] = DummyCostTypeOperationId;
                dataRow[CostTypeOperationOperationFieldName] = DummyCostTypeOperationOperation;
                dataTable.Rows.Add(dataRow);

                var dataRow2 = dataTable.NewRow();
                dataRow2[CostTypeOperationIdFieldName] = DummyCostTypeOperationId;
                dataRow2[CostTypeOperationOperationFieldName] = DummyCostTypeOperationOperation;
                dataTable.Rows.Add(dataRow2);

                return StatusEnum.rsSuccess;
            };

            _costTypeEditMode = 101;

            // Act
            var actualResult = (StatusEnum)_privateObject.Invoke(BuildCalculatedDataMethodName, parameters);

            // Assert
            var actualCostCategories = (List<CostCategory>)parameters[5];

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe(StatusEnum.rsSuccess),
                () => actualCostCategories.Count.ShouldBe(2),
                () => actualCostCategories[0].Id.ShouldBe(DummyCostCategoryId1),
                () => actualCostCategories[0].Discount.ShouldBe(DummyDiscountRate),
                () => actualCostCategories[0].Level.ShouldBe(DummyCostCategoryLevel2),
                () => actualCostCategories[0].Name.ShouldBe(DummyCostCategoryName1),
                () => actualCostCategories[0].NamedRateName.ShouldBe(DummyNamedRateName),
                () => actualCostCategories[0].NamedRateUID.ShouldBe(DummyNamedRateId),
                () => actualCostCategories[0].Uid.ShouldBe(DummyCostCategoryUid1),
                () => actualCostCategories[0].UoM.ShouldBe(DummyCostCategoryUom1),
                () => actualCostCategories[1].Id.ShouldBe(DummyCostCategoryId2),
                () => actualCostCategories[1].Discount.ShouldBe(DummyDiscountRate),
                () => actualCostCategories[1].Level.ShouldBe(DummyCostCategoryLevel3),
                () => actualCostCategories[1].Name.ShouldBe(DummyCostCategoryName2),
                () => actualCostCategories[1].NamedRateName.ShouldBe(null),
                () => actualCostCategories[1].NamedRateUID.ShouldBe(0),
                () => actualCostCategories[1].Uid.ShouldBe(DummyCostCategoryUid2),
                () => actualCostCategories[1].UoM.ShouldBe(DummyCostCategoryUom2));
        }

        [TestMethod]
        public void GetCostType_SelectCostTypeFail_ReturnStatus()
        {
            // Arrange
            var parameters = new object[]
            {
                _dbAccess.Instance,
                0,
                new CostType()
            };

            ShimdbaEditCosts.SelectCostTypeDBAccessInt32DataTableOut = (DBAccess dbAccessParam, int costTypeIdParam, out DataTable dataTable) =>
            {
                dataTable = new DataTable();

                return StatusEnum.rsRequestInvalid;
            };

            // Act
            var actualResult = (StatusEnum)_privateObject.Invoke(GetCostTypeMethodName, parameters);

            // Assert
            actualResult.ShouldBe(StatusEnum.rsSuccess);
        }

        [TestMethod]
        public void GetCostType_RowsCount0_ReturnStatus()
        {
            // Arrange
            var parameters = new object[]
            {
                _dbAccess.Instance,
                0,
                new CostType()
            };
            ShimdbaEditCosts.SelectCostTypeDBAccessInt32DataTableOut = (DBAccess dbAccessParam, int costTypeIdParam, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = (StatusEnum)_privateObject.Invoke(GetCostTypeMethodName, parameters);

            // Assert
            actualResult.ShouldBe((StatusEnum)99839);
        }

        private void SetupMergeCostCategories()
        {
            _costCategoryList1 = new List<CostCategory>()
            {
                new CostCategory()
                {
                    Seq = 0,
                    Id = 2
                },
                new CostCategory()
                {
                    Seq = 0,
                    Id = 3
                },
                new CostCategory()
                {
                    Seq = 0,
                    Id = 6
                },
                new CostCategory()
                {
                    Seq = 1
                }
            };
            _costCategoryList2 = new List<CostCategory>()
            {
                new CostCategory()
                {
                    Seq = 0,
                    Id = 2
                },
                new CostCategory()
                {
                    Seq = 0,
                    Id = 4
                },
                new CostCategory()
                {
                    Seq = 0,
                    Id = 7
                },
                new CostCategory()
                {
                    Seq = 1
                }
            };
        }

        private void SetupMergeCostCategoryValues()
        {
            _costCategory1 = new CostCategory()
            {
                periodCostValues = new List<PeriodCostValue>()
                {
                    new PeriodCostValue()
                    {
                        PeriodId = 1
                    },
                    new PeriodCostValue()
                    {
                        PeriodId = 2
                    },
                    new PeriodCostValue()
                    {
                        PeriodId = 5
                    }
                }
            };

            _costCategory2 = new CostCategory()
            {
                periodCostValues = new List<PeriodCostValue>()
                {
                    new PeriodCostValue()
                    {
                        PeriodId = 1
                    },
                    new PeriodCostValue()
                    {
                        PeriodId = 3
                    },
                    new PeriodCostValue()
                    {
                        PeriodId = 4
                    }
                }
            };
        }
    }
}