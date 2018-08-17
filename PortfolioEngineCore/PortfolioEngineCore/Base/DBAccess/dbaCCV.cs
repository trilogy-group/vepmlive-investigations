using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PortfolioEngineCore
{
    public class dbaCCV
    {
        private const string No = "@@NO@@";
        private const string UOM = "@@@@";

        private const string BcUid = "BC_UID";
        private const string BcId = "BC_ID";
        private const string BcLevel = "BC_LEVEL";
        private const string BcUom = "BC_UOM";
        private const string AvailBcUid = "Avail_BC_UID";
        private const string ProjectId = "PROJECT_ID";
        private const string Periodcount = "PeriodCount";
        private const string BdPeriod = "BD_PERIOD";
        private const string BdCost = "BD_COST";
        private const string BdValue = "BD_VALUE";
        private const string CtId = "CT_ID";
        private const string CbId = "CB_ID";
        private const string BudgetTotalField = "BUDGET_TOTAL_FIELD";
        private const string FaTableId = "FA_TABLE_ID";
        private const string FaFieldInTable = "FA_FIELD_IN_TABLE";
        private const string CtEditMode = "CT_EDIT_MODE";
        private const string CcvComplete = "CCV Complete";

        public static StatusEnum CalculateCostValues(DBAccess dbAccess, int ctId, int cbId, int projectId, out string sResult)
        {
            var eStatus = StatusEnum.rsSuccess;
            sResult = CcvComplete;

            if (!(ctId > 0) || !(cbId >= 0))
            {
                return eStatus;
            };

            // likely will have to expand on this parameter options later
            bool bDeleteAllProjects;
            bool bAllProjects;
            IList<int> projectIds;
            int periodCount;
            bool bsingleUOM;
            string sTotalUoM;
            CostValues costValues;
            IDictionary<int, CostCategoryInternal> costCategories;
            IList<int> costCategoriesIndex;

            PrepareData(
                dbAccess, 
                ctId, 
                cbId, 
                projectId, 
                out bDeleteAllProjects, 
                out bAllProjects, 
                out periodCount, 
                out costCategories, 
                out costCategoriesIndex, 
                out bsingleUOM, 
                out sTotalUoM, 
                out costValues,
                out projectIds);

            foreach (var id in projectIds)
            {
                ReadValues(dbAccess, ctId, cbId, costValues, costCategories, id);
                SetValues(costCategories, costCategoriesIndex, periodCount, costValues);
                RollupValues(costCategoriesIndex, costCategories, periodCount, costValues, sTotalUoM, bsingleUOM);

                try
                {
                    eStatus = WriteOutTheResults(
                        dbAccess,
                        ctId,
                        cbId,
                        bDeleteAllProjects,
                        id,
                        periodCount,
                        costValues,
                        costCategoriesIndex,
                        costCategories);
                }
                catch (Exception ex)
                {
                    eStatus = dbAccess.HandleStatusError(SeverityEnum.Exception, "UpdatePermGroup_Delete_Perms", (StatusEnum)99847, ex.Message);
                }
            }

            if (eStatus == StatusEnum.rsSuccess)
            {
                eStatus = SetCostTotals(dbAccess, ctId, cbId, projectIds, bAllProjects);
            }
            
            return eStatus;
        }

        private static void PrepareData(
            DBAccess dbAccess,
            int ctId,
            int cbId,
            int projectId,
            out bool bDeleteAllProjects,
            out bool bAllProjects,
            out int lPeriodCount,
            out IDictionary<int, CostCategoryInternal> costCategories,
            out IList<int> costCategoriesIndex,
            out bool bsingleUOM,
            out string sTotalUoM,
            out CostValues costValues,
            out IList<int> listPIs)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            sTotalUoM = UOM;

            listPIs = GetProjectIds(dbAccess, projectId, out bDeleteAllProjects, out bAllProjects);

            lPeriodCount = GetPeriodCount(dbAccess, cbId);

            costCategories = new Dictionary<int, CostCategoryInternal>();
            costCategoriesIndex = new List<int>();

            var nMaxLevel = GetCategories(dbAccess, ctId, costCategories, costCategoriesIndex, out bsingleUOM);

            var parentUiDs = new int[nMaxLevel + 1];
            foreach (var costcategoryentry in costCategories)
            {
                var costcategory = costcategoryentry.Value;
                parentUiDs[costcategory.Level] = costcategory.UID;
                if (costcategory.Level > 1)
                {
                    costcategory.ParentUID = parentUiDs[costcategory.Level - 1];
                }
            }

            if (!bsingleUOM) // if only one UOM can always roll up
            {
                sTotalUoM = RollupUOM(costCategories, costCategoriesIndex, sTotalUoM);
            }

            // set arrays to hold Cost Values - incl extra category line for TOTALS
            costValues = new CostValues(lPeriodCount, costCategories.Count);
        }

        private static int GetCategories(
            DBAccess dbAccess, 
            int ctId, 
            IDictionary<int, CostCategoryInternal> costCategories, 
            IList<int> costCategoriesIndex,
            out bool bsingleUOM)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (costCategories == null)
            {
                throw new ArgumentNullException(nameof(costCategories));
            }
            if (costCategoriesIndex == null)
            {
                throw new ArgumentNullException(nameof(costCategoriesIndex));
            }
            var nMaxLevel = 0;
            bsingleUOM = true;
            var susedUOM = string.Empty;

            var cmdText = new StringBuilder();
            cmdText.Append("SELECT cc.BC_UID,BC_ID,BC_LEVEL,BC_UOM,ac.BC_UID as Avail_BC_UID FROM EPGP_COST_CATEGORIES cc")
                .AppendFormat(" Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID = cc.BC_UID And ac.CT_ID={0}", ctId)
                .AppendFormat(" ORDER BY cc.BC_ID");
            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                SqlDataReader reader;
                if (dbaUsers.ExecuteSQLSelect(cmd, out reader) != StatusEnum.rsSuccess)
                {
                    return nMaxLevel;
                }
                using (reader)
                {
                    while (reader.Read())
                    {
                        var costCategory = new CostCategoryInternal
                        {
                            UID = DBAccess.ReadIntValue(reader[BcUid]),
                            ID = DBAccess.ReadIntValue(reader[BcId]),
                            Level = DBAccess.ReadIntValue(reader[BcLevel])
                        };
                        if (costCategory.Level > nMaxLevel)
                        {
                            nMaxLevel = costCategory.Level;
                        }
                        costCategory.UOM = DBAccess.ReadStringValue(reader[BcUom]);
                        costCategory.RollupUOM = costCategory.UOM;

                        if (DBAccess.ReadIntValue(reader[AvailBcUid]) > 0) //  this category available for this CT
                        {
                            costCategory.IsAvailable = true;
                            if (bsingleUOM && costCategory.UOM != string.Empty) // check to see if we use more than one non-blank UOM
                            {
                                if (susedUOM == string.Empty)
                                {
                                    susedUOM = costCategory.UOM;
                                }
                                else
                                {
                                    if (susedUOM != costCategory.UOM)
                                    {
                                        bsingleUOM = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            costCategory.IsAvailable = false;
                        }

                        costCategories.Add(costCategory.UID, costCategory);
                        costCategoriesIndex.Add(costCategory.UID); // just used to access the Dictionary in reverse order - will be saved in entry (BC_ID-1)
                    }
                }
            }
            return nMaxLevel;
        }

        private static IList<int> GetProjectIds(DBAccess dbAccess, int projectId, out bool bDeleteAllProjects, out bool bAllProjects)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            bDeleteAllProjects = false;
            bAllProjects = false;

            var listPIs = new List<int>();
            if (projectId > 0)
            {
                listPIs.Add(projectId);
            }
            else
            {
                bDeleteAllProjects = true;
                bAllProjects = true;
                const string cmdText = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION = 0";
                using (var cmd = new SqlCommand(cmdText, dbAccess.Connection))
                {
                    SqlDataReader reader;
                    if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
                    {
                        using (reader)
                        {
                            while (reader.Read())
                            {
                                var id = DBAccess.ReadIntValue(reader[ProjectId]);
                                listPIs.Add(id);
                            }
                        }
                    }
                }
            }
            return listPIs;
        }

        private static int GetPeriodCount(DBAccess dbAccess, int cbId)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var lPeriodCount = 0;
            var cmdText = $"Select MAX(PRD_ID) as PeriodCount From EPG_PERIODS Where CB_ID={cbId}";
            using (var cmd = new SqlCommand(cmdText, dbAccess.Connection))
            {
                SqlDataReader reader;
                if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        if (reader.Read())
                        {
                            lPeriodCount = DBAccess.ReadIntValue(reader[Periodcount]);
                        }
                    }
                }
            }
            return lPeriodCount;
        }

        private static string RollupUOM(IDictionary<int, CostCategoryInternal> costCategories, IList<int> costCategoriesIndex, string sTotalUoM)
        {
            if (costCategories == null)
            {
                throw new ArgumentNullException(nameof(costCategories));
            }
            if (costCategoriesIndex == null)
            {
                throw new ArgumentNullException(nameof(costCategoriesIndex));
            }
            for (var i = costCategories.Count - 1; i >= 0; i--)
            {
                var categoryUID = costCategoriesIndex[i];
                var costcategory = costCategories[categoryUID];

                if (costcategory.IsAvailable)
                {
                    var sUOM = costcategory.RollupUOM; // final determined UOM for this line as children already handled
                    if (costcategory.ParentUID == 0)
                    {
                        // this is a level 1 Category so check UOM against Total line UoM
                        if (sTotalUoM == UOM)
                        {
                            sTotalUoM = sUOM;
                        }
                        else if (sTotalUoM != sUOM)
                        {
                            sTotalUoM = No;
                        }
                    }
                    else
                    {
                        // rollup UOM all the way up to level 1
                        while (costcategory.ParentUID > 0)
                        {
                            costcategory = costCategories[costcategory.ParentUID];
                            if (costcategory.RollupUOM == string.Empty)
                            {
                                costcategory.RollupUOM = sUOM;
                            }
                            else if (costcategory.RollupUOM != sUOM)
                            {
                                costcategory.RollupUOM = No;
                            }
                        }
                    }
                }
            }

            return sTotalUoM;
        }

        private static void ReadValues(
            DBAccess dbAccess, 
            int ctId, 
            int cbId, 
            CostValues costValues, 
            IDictionary<int, CostCategoryInternal> costCategories, 
            int projectId)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (costValues == null)
            {
                throw new ArgumentNullException(nameof(costValues));
            }
            if (costCategories == null)
            {
                throw new ArgumentNullException(nameof(costCategories));
            }
            costValues.SetArrays();
            foreach (var costcategoryentry in costCategories)
            {
                var costcategory = costcategoryentry.Value;
                costcategory.IsSummary = false;
                costcategory.HasData = false;
            }

            // read cost values
            var cmdText = new StringBuilder();
            cmdText.AppendFormat("SELECT BD_VALUE,BD_COST,BD_PERIOD,BC_UID FROM EPGP_DETAIL_VALUES  WHERE PROJECT_ID={0}", projectId)
                .AppendFormat(" AND CB_ID={0}", cbId)
                .AppendFormat(" AND CT_ID={0}", ctId);

            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                SqlDataReader reader;
                if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var period = DBAccess.ReadIntValue(reader[BdPeriod]);
                            // doesn't seem worth trying to figure a Period offset in the arrays for periods not used but could do that at the beginning fofr all PIs I suppose 
                            var category = DBAccess.ReadIntValue(reader[BcUid]);

                            if (costCategories.ContainsKey(category))
                            {
                                var costcategory = costCategories[category];

                                if (costcategory.IsAvailable)
                                {
                                    costcategory.HasData = true;
                                    category = costcategory.ID;
                                    costValues.incrCost(period, category, DBAccess.ReadDoubleValue(reader[BdCost]));
                                    costValues.incrQuantity(period, category, DBAccess.ReadDoubleValue(reader[BdValue]));
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void SetValues(
            IDictionary<int, CostCategoryInternal> costCategories, 
            IList<int> costCategoriesIndex, 
            int periodCount, 
            CostValues costValues)
        {
            if (costCategories == null)
            {
                throw new ArgumentNullException(nameof(costCategories));
            }
            if (costCategoriesIndex == null)
            {
                throw new ArgumentNullException(nameof(costCategoriesIndex));
            }
            if (costValues == null)
            {
                throw new ArgumentNullException(nameof(costValues));
            }
            for (var i = costCategories.Count - 1; i >= 0; i--)
            {
                var categoryUID = costCategoriesIndex[i];
                var costcategory = costCategories[categoryUID];

                // if already a summary then no need to look at it
                if (costcategory.IsSummary)
                {
                    continue;
                }

                if (costcategory.HasData)
                {
                    // mark as summary and clear values (just in case) all the way up to level 1
                    while (costcategory.ParentUID > 0)
                    {
                        costcategory = costCategories[costcategory.ParentUID];
                        costcategory.IsSummary = true;

                        for (var j = 1; j <= periodCount; j++)
                        {
                            costValues.setCost(j, costcategory.ID, 0);
                            costValues.setQuantity(j, costcategory.ID, 0);
                        }
                    }
                }
            }
        }

        private static void RollupValues(
            IList<int> costCategoriesIndex, 
            IDictionary<int, CostCategoryInternal> costCategories, 
            int periodCount, 
            CostValues costValues,
            string sTotalUoM, 
            bool bsingleUOM)
        {
            if (costCategoriesIndex == null)
            {
                throw new ArgumentNullException(nameof(costCategoriesIndex));
            }
            if (costCategories == null)
            {
                throw new ArgumentNullException(nameof(costCategories));
            }
            if (costValues == null)
            {
                throw new ArgumentNullException(nameof(costValues));
            }
            for (var i = costCategories.Count - 1; i >= 0; i--)
            {
                var categoryUID = costCategoriesIndex[i];
                var costCategory = costCategories[categoryUID];
                if (costCategory.ParentUID == 0)
                {
                    // this is a level 1 Category so total to TOTAL line - stored in row where BC_UID = 0
                    for (var j = 1; j <= periodCount; j++)
                    {
                        costValues.incrCost(j, 0, costValues.getCost(j, costCategory.ID));
                    }

                    if (sTotalUoM != No)
                    {
                        for (var j = 1; j <= periodCount; j++)
                        {
                            costValues.incrQuantity(j, 0, costValues.getQuantity(j, costCategory.ID));
                        }
                    }
                }
                else
                {
                    var parentCostcategory = costCategories[costCategory.ParentUID];
                    var thisRow = costCategory.ID;
                    var parentrow = parentCostcategory.ID;

                    for (var j = 1; j <= periodCount; j++)
                    {
                        costValues.incrCost(j, parentrow, costValues.getCost(j, thisRow));
                    }

                    if (bsingleUOM || (costCategory.RollupUOM == parentCostcategory.RollupUOM))
                    {
                        for (var j = 1; j <= periodCount; j++)
                        {
                            costValues.incrQuantity(j, parentrow, costValues.getQuantity(j, thisRow));
                        }
                    }
                }
            }
        }

        private static StatusEnum WriteOutTheResults(
            DBAccess dbAccess, 
            int ctId, 
            int cbId, 
            bool bDeleteAllProjects, 
            int projectId, 
            int periodCount,
            CostValues costValues, 
            IList<int> costCategoriesIndex, 
            IDictionary<int, CostCategoryInternal> costCategories)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (costValues == null)
            {
                throw new ArgumentNullException(nameof(costValues));
            }
            if (costCategoriesIndex == null)
            {
                throw new ArgumentNullException(nameof(costCategoriesIndex));
            }
            if (costCategories == null)
            {
                throw new ArgumentNullException(nameof(costCategories));
            }

            var eStatus = StatusEnum.rsSuccess;

            var cmdText = new StringBuilder();
            cmdText.AppendFormat("DELETE FROM  EPGP_COST_VALUES WHERE CB_ID={0} AND CT_ID={1}", cbId, ctId);

            if (!bDeleteAllProjects)
            {
                cmdText.AppendFormat(" AND PROJECT_ID={0}", projectId);
            }
            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                cmd.ExecuteNonQuery();
            }
            cmdText.Clear();

            try
            {
                cmdText
                    .Append("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY)")
                    .AppendFormat(" VALUES({0},{1},{2}", cbId, ctId, projectId)
                    .Append(",@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)");
                using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
                {
                    var pBcUid = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    var pBdPeriod = cmd.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                    var pBdValue = cmd.Parameters.Add("@BD_VALUE", SqlDbType.Float);
                    var pBdCost = cmd.Parameters.Add("@BD_COST", SqlDbType.Float);
                    var pBdIsSummary = cmd.Parameters.Add("@BD_IS_SUMMARY", SqlDbType.Int);

                    pBdValue.Precision = 25;
                    pBdValue.Scale = 6;
                    pBdCost.Precision = 25;
                    pBdCost.Scale = 6;

                    // Write out the Grand Total line
                    for (var i = 1; i <= periodCount; i++)
                    {
                        if (costValues.getCost(i, 0) != 0 || costValues.getQuantity(i, 0) != 0)
                        {
                            pBcUid.Value = 0;
                            pBdPeriod.Value = i;
                            pBdIsSummary.Value = 1;
                            pBdValue.Value = costValues.getQuantity(i, 0);
                            pBdCost.Value = costValues.getCost(i, 0);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Write out the Cost Category lines
                    for (var j = 0; j < costCategories.Count; j++)
                    {
                        var categoryUID = costCategoriesIndex[j];
                        var costcategory = costCategories[categoryUID];
                        var thisRow = costcategory.ID;

                        for (var i = 1; i <= periodCount; i++)
                        {
                            if (costValues.getCost(i, thisRow) != 0 || costValues.getQuantity(i, thisRow) != 0)
                            {
                                pBcUid.Value = costcategory.UID;
                                pBdPeriod.Value = i;
                                var nIsSummary = costcategory.IsSummary ? 1 : 0;
                                pBdIsSummary.Value = nIsSummary;
                                pBdValue.Value = costValues.getQuantity(i, thisRow);
                                pBdCost.Value = costValues.getCost(i, thisRow);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dbAccess.HandleStatusError(SeverityEnum.Exception, "InsertCOST_VALUES", (StatusEnum)99848, ex.Message);
            }
            return eStatus;
        }

        internal static StatusEnum SetCostTotals(DBAccess dbAccess, int ctId, int cbId, IList<int> projectIds, bool bAllProjects)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (projectIds == null)
            {
                throw new ArgumentNullException(nameof(projectIds));
            }
            var eStatus = StatusEnum.rsSuccess;

            if (!(ctId > 0) || !(cbId >= 0))
            {
                return eStatus;
            }

            IEnumerable<CostTotal> costTotals;
            try
            {
                costTotals = ReadTotals(dbAccess);
            }
            catch (Exception ex)
            {
                eStatus = dbAccess.HandleStatusError(SeverityEnum.Exception, "Set COST_VALUES", (StatusEnum)99846, ex.Message);
                return eStatus;
            }
            if (!costTotals.Any())
            {
                return eStatus;
            }

            try
            {
                foreach (var costTotal in costTotals)
                {
                    if (costTotal.CT_ID == ctId && costTotal.CB_ID == cbId)
                    {
                        // read info on Total Field
                        string sTable;
                        string sField;
                        if (!ReadInfoOnTotalField(dbAccess, costTotal.FIELD_ID, out sTable, out sField))
                        {
                            return eStatus;
                        }

                        // read info on CT
                        var lEditMode = GetEditMode(dbAccess, ctId);
                        if (lEditMode == -1)
                        {
                            return eStatus;
                        }
                        
                        if (bAllProjects)
                        {
                            UpdateProjects(dbAccess, ctId, cbId, sTable, sField, lEditMode);
                        }
                        else
                        {
                            foreach (var projectId in projectIds)
                            {
                                UpdateProject(dbAccess, ctId, cbId, sTable, sField, projectId, lEditMode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dbAccess.HandleStatusError(SeverityEnum.Exception, "Set COST_VALUES", (StatusEnum)99845, ex.Message);
            }

            return eStatus;
        }

        private static IEnumerable<CostTotal> ReadTotals(DBAccess dbAccess)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var costTotals = new List<CostTotal>();
            using (var cmd = new SqlCommand("EPG_SP_ReadCostTotals", dbAccess.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var costtotal = new CostTotal
                        {
                            CT_ID = DBAccess.ReadIntValue(reader[CtId]),
                            CB_ID = DBAccess.ReadIntValue(reader[CbId]),
                            FIELD_ID = DBAccess.ReadIntValue(reader[BudgetTotalField])
                        };
                        costTotals.Add(costtotal);
                    }
                }
            }

            return costTotals;
        }

        private static bool ReadInfoOnTotalField(DBAccess dbAccess, int fieldId, out string sTable, out string sField)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            sTable = string.Empty;
            sField = string.Empty;

            var cmdText = $"SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID={fieldId}";
            using (var cmd = new SqlCommand(cmdText, dbAccess.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var lTable = DBAccess.ReadIntValue(reader[FaTableId]);
                    var lFieldinTable = DBAccess.ReadIntValue(reader[FaFieldInTable]);
                    return EPKClass01.GetTableAndField(lTable, lFieldinTable, out sTable, out sField);
                }
            }

            return false;
        }

        private static int GetEditMode(DBAccess dbAccess, int ctId)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var lEditMode = -1;
            var cmdText = $"SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID={ctId}";
            using (var cmd = new SqlCommand(cmdText, dbAccess.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lEditMode = DBAccess.ReadIntValue(reader[CtEditMode]);
                    }
                }
            }

            return lEditMode;
        }

        private static void UpdateProjects(DBAccess dbAccess, int ctId, int cbId, string sTable, string sField, int lEditMode)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText =new StringBuilder();
            cmdText.AppendFormat("Update {0} SET {1}=0", sTable, sField);
            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                cmd.ExecuteNonQuery();
            }

            cmdText.Clear();
            cmdText.AppendFormat("Update {0} SET {1}", sTable, sField)
                .Append("=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES")
                .AppendFormat(" WHERE  (CB_ID={0} AND CT_ID ={1}", cbId, ctId);

            cmdText.Append(lEditMode == 0 ? " AND BD_IS_SUMMARY=0" : " AND BC_UID=0");

            cmdText.AppendFormat(") AND ({0}.PROJECT_ID=PROJECT_ID))", sTable);

            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void UpdateProject(DBAccess dbAccess, int ctId, int cbId, string sTable, string sField, int projectId, int lEditMode)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText = new StringBuilder();
            cmdText.AppendFormat("Update {0} SET {1}=0 Where PROJECT_ID={2}", sTable, sField, projectId);
            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                cmd.ExecuteNonQuery();
            }
            cmdText.Clear();
            cmdText.AppendFormat("Update {0} SET {1}", sTable, sField)
                .Append("=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES")
                .AppendFormat(" WHERE  (CB_ID={0} AND CT_ID ={1}", cbId, ctId);

            cmdText.Append(lEditMode == 0 ? " AND BD_IS_SUMMARY=0" : " AND BC_UID=0");

            cmdText.AppendFormat(") AND ({0}.PROJECT_ID=PROJECT_ID))", sTable)
                .AppendFormat(" Where PROJECT_ID={0}", projectId);

            using (var cmd = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}