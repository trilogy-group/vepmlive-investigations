using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using CostDataValues;


namespace PortfolioEngineCore
{
    public class CostAnalyzerData : PFEBase
    {

        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields

        public CostAnalyzerData(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ModelSupport Class");
            _sqlConnection = _PFECN;
            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

        public CostAnalyzerData(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading CostAnalyzerData Class");
            _sqlConnection = _PFECN;
        }

        public clsCostData InitalLoadData(string ticket, string sViewID, out string m_loadmsg, out int m_loaddatareturn)
        {
            m_loaddatareturn = 0;

            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();
                
                m_loadmsg = "";
                m_loaddatareturn = 10;

                bool bPMOAdmin = false;
                if (_userWResID <= 1 )
                {
                    bPMOAdmin = true;
                }
                else
                {
                    bPMOAdmin = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpProjectVerCenter);
                }
               // if (bPMOAdmin) RVClass.gpPMOAdmin = 1; else RVClass.gpPMOAdmin = 0;

                clsCostData clscd = new clsCostData();

                clscd.m_gPOPerm = (bPMOAdmin == true ? 1 : 0);

                GrabPidsFromTickect(_sqlConnection, ticket, out clscd.m_sPids, out clscd.m_GotAllPIs, out clscd.m_PI_Count);

                m_loaddatareturn = 20;
                int lFirstP = 0;
                int lLastP = 0;

                GrabCostViewInfo(_sqlConnection, sViewID, out clscd.m_CB_ID, out clscd.m_sCostTypes, out clscd.m_sOtherCostTypes, out clscd.m_sCalcCostTypes, out lFirstP, out lLastP);


                m_loaddatareturn = 30;




                if (clscd.m_CB_ID < 0 || clscd.m_sPids == "")
                {
                    if (clscd.m_CB_ID < 0)
                    {
                        m_loadmsg = "No Cost Breakdown (CB_IB) specified";
                        m_loaddatareturn = 1;
                    }

                    return null;
                }


                if (clscd.m_sCostTypes == "" && clscd.m_sOtherCostTypes == "")
                {
                    m_loadmsg = "No Cost Types specified";
                    m_loaddatareturn = 2;
                    return null;
                }


                m_loaddatareturn = 40;
                GrabStatus(_sqlConnection, clscd);
                m_loaddatareturn = 41;
                ReadPeriods(_sqlConnection, clscd);
                m_loaddatareturn = 42;
                ReadCatItems(_sqlConnection, clscd);
                m_loaddatareturn = 43;
                ReadCustomFields(_sqlConnection, clscd);
                m_loaddatareturn = 44;

                ReadCostTypeNames(_sqlConnection, clscd);
                m_loaddatareturn = 45;

                ReadStages(_sqlConnection, clscd);
                m_loaddatareturn = 46;
                ReadExtraPifields(_sqlConnection, clscd);
                m_loaddatareturn = 47;

                DateTime edate, ldate;
                ReadPILevelData(_sqlConnection, clscd, out edate, out ldate);
                m_loaddatareturn = 48;
                ReadCostCustomFieldsAndData(_sqlConnection, clscd);
                m_loaddatareturn = 49;
                ReadBudgetBands(_sqlConnection, clscd);
                m_loaddatareturn = 50;
                ReadRateTable(_sqlConnection, clscd);
                m_loaddatareturn = 51;

                LoadTargets(clscd);

                //int psfppid = 0;
                //int pslppid = 0;


                //foreach (clsPeriodData oPeriod in m_Periods.Values)
                //{

                //    if (edate != DateTime.MinValue)
                //    {
                //        if (oPeriod.StartDate <= edate && edate <= oPeriod.FinishDate)
                //            psfppid = oPeriod.PeriodID;
                //    }

                //    if (ldate != DateTime.MinValue)
                //    {
                //        if (oPeriod.StartDate <= ldate && ldate <= oPeriod.FinishDate)
                //            pslppid = oPeriod.PeriodID;
                //    }

                //}




                m_loaddatareturn = 40;

                StashRateCache(clscd);


                Dictionary<string, clsDetailRowData> nonzero = new Dictionary<string, clsDetailRowData>();

                foreach (clsDetailRowData oDet in clscd.m_detaildata.Values)
                {

                    if (oDet.HasValues)
                        nonzero.Add(oDet.m_dict_key, oDet);

                    clsDataItem odi;

                    if (clscd.m_CostTypes.TryGetValue(oDet.CT_ID, out odi) == true)
                        oDet.CT_ind = odi.ID;
                    else
                    {
                        oDet.CT_ind = -1;
                        
                    }

                    PerformCalcs(oDet, clscd);

                }


                clscd.m_detaildata = nonzero;


                return clscd;


            }

            catch (Exception ex)
            {
                m_loadmsg = ex.Message;
            //    m_loaddatareturn = 3;
                return null;

            }

            //return 2;
        }

        private int GrabPidsFromTickect(SqlConnection oDataAccess, string ticket, out string sPids, out bool bNoneMissing, out int PICount)
        {

            string sCommand = "";
            int eStatus = 0;
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sGuids = "";
            string sGin = "";
            sPids = "";
            bNoneMissing = true;
            PICount = 0;
            int i = 0;
            int lPid;

             sCommand = "SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = '" + ticket + "'";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                sGuids = DBAccess.ReadStringValue(reader["DC_DATA"]);
            }
            reader.Close();
            reader = null;


            sGuids = sGuids.Replace(",", " ");
            sGuids = sGuids.ToUpper();
            sGuids = sGuids.Trim();


            while (sGuids.Length != 0)
            {
                sGin = "";

                i = sGuids.IndexOf(" ");

                if (i == -1)
                {
                    sGin = sGuids;
                    sGuids = "";
                }
                else
                {
                    sGin = sGuids.Substring(0, i);
                    sGuids = sGuids.Substring(i + 1);
                }

                if (sGin != "")
                {

                    sCommand = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE { fn UCASE(PROJECT_EXT_UID) }  = '" + sGin + "'";

                    oCommand = new SqlCommand(sCommand, oDataAccess);
                    reader = oCommand.ExecuteReader();
                    lPid = 0;
                    while (reader.Read())
                    {
                        lPid = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    }
                    reader.Close();
                    reader = null;

                    if (lPid == 0)
                        bNoneMissing = false;
                    else
                    {
                        ++PICount;
                        if (sPids == "")
                            sPids = lPid.ToString();
                        else
                            sPids = sPids + "," + lPid.ToString();
                    }

                }

            }
            return eStatus;

        }
        private int GrabCostViewInfo(SqlConnection oDataAccess, string sCostView, out int lCB_ID, out string sCostTypes, out string sOtherCostTypes, out string m_sCalcCostTypes, out int lMinP, out int lMaxP)
        {

            int eStatus = 0;
            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            int lCostView = 0;
            lMinP = 0;
            lMaxP = 0;



            lCB_ID = 0;
            sCostTypes = "";
            sOtherCostTypes = "";
            m_sCalcCostTypes = "";


            try
            {
                lCostView = Int32.Parse(sCostView);
            }
            catch
            {
                lCostView = 0;
            }

            if (lCostView == 0)
                return 1;

            if (lCostView == -1)
            {

                bool bfnd = false;
                sCommand = "SELECT * FROM EPGT_COSTVIEW_DISPLAY";
                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    if (bfnd == false)
                    {
                        bfnd = true;
                        lCostView = DBAccess.ReadIntValue(reader["VIEW_UID"]);
                        sCostView = lCostView.ToString();
                    }

                }
                reader.Close();
                reader = null;

                if (bfnd == false)
                    return 1;

            }

            sCommand = "SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID = " + sCostView;
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {
                lCB_ID = DBAccess.ReadIntValue(reader["VIEW_COST_BREAKDOWN"]);
                lMinP = DBAccess.ReadIntValue(reader["VIEW_FIRST_PERIOD"]);
                lMaxP = DBAccess.ReadIntValue(reader["VIEW_LAST_PERIOD"]);


            }
            reader.Close();
            reader = null;

            if (lCB_ID == 0)
                return 1;




            sCommand = "SELECT  EPGT_COSTVIEW_COST_TYPES.CT_ID, EPGP_COST_TYPES.CT_EDIT_MODE FROM EPGT_COSTVIEW_COST_TYPES INNER JOIN EPGP_COST_TYPES ON EPGT_COSTVIEW_COST_TYPES.CT_ID = EPGP_COST_TYPES.CT_ID WHERE VIEW_UID = " + sCostView;

            int lCTID = 0;
            int lEMode = 0;

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                lCTID = DBAccess.ReadIntValue(reader["CT_ID"]);
                lEMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);

                if (lEMode == 1)
                {
                    if (sCostTypes == "")
                        sCostTypes = lCTID.ToString();
                    else
                        sCostTypes = sCostTypes + "," + lCTID.ToString();

                }
                else
                {
                    if (sOtherCostTypes == "")
                        sOtherCostTypes = lCTID.ToString();
                    else
                        sOtherCostTypes = sOtherCostTypes + "," + lCTID.ToString();

                    if (lEMode == 3)
                    {
                        if (m_sCalcCostTypes == "")
                            m_sCalcCostTypes = lCTID.ToString();
                        else
                            m_sCalcCostTypes = m_sCalcCostTypes + "," + lCTID.ToString();
                    }


                }

            }
            reader.Close();
            reader = null;

            return eStatus;
        }
        private void GrabStatus(SqlConnection oDataAccess, clsCostData clscd)
        {

            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;


            sCommand = " SELECT ADM_STATUS_DATE, ADM_PI_GROUP_CF1 AS GID, ADM_PI_GROUP_CF2 AS GSQ From EPG_ADMIN";
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                clscd.m_statdate = DBAccess.ReadDateValue(reader["ADM_STATUS_DATE"]);
     
            }
            reader.Close();
            reader = null;

        }
        private void ReadPeriods(SqlConnection oDataAccess, clsCostData clscd)
        {
            clsPeriodData oPeriod;
            int maxp = 0;

  

            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            maxp = 0;

            clscd.m_Periods = new Dictionary<int, clsPeriodData>();

            oCommand = new SqlCommand("EPG_SP_ReadPeriods", oDataAccess);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            oCommand.Parameters.AddWithValue("CalID", clscd.m_CB_ID);
            reader = oCommand.ExecuteReader();




            while (reader.Read())
            {
                oPeriod = new clsPeriodData();


                oPeriod.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                oPeriod.PeriodName = DBAccess.ReadStringValue(reader["PRD_NAME"]);
                oPeriod.StartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
                oPeriod.FinishDate = DBAccess.ReadDateValue(reader["PRD_FINISH_DATE"]);

                if (maxp == 0)
                {
                    clscd.m_dtMin = oPeriod.StartDate;
                    clscd.m_dtMax = oPeriod.FinishDate;
                }
                else if (clscd.m_dtMax < oPeriod.FinishDate)
                    clscd.m_dtMax = oPeriod.FinishDate;





                if (oPeriod.PeriodID > maxp)
                    maxp = oPeriod.PeriodID;

                if (clscd.m_statdate >= oPeriod.StartDate && clscd.m_statdate <= oPeriod.FinishDate)
                    clscd.m_status_period = oPeriod.PeriodID;

                clscd.m_Periods.Add(oPeriod.PeriodID, oPeriod);
            }

            reader.Close();
            reader = null;

            clscd.m_max_period = maxp;


        }
        private void ReadCatItems(SqlConnection oDataAccess, clsCostData clscd)
        {
            clsCatItemData oCat, xCat;
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            int CatItemId = 0;
            int PerID = 0;
            string sCommand = "";
            int[] PidSet = new int[1000];
            int iTemp = 0;
            Dictionary<int, clsCatItemData> rolenames = new Dictionary<int, clsCatItemData>();


            sCommand = "SELECT BC_UID, BC_ID, BC_LEVEL, BC_NAME, BC_UOM, BC_ROLE, CA_UID, EPGP_LOOKUP_VALUES.LV_VALUE, MC_UID " +
                       " FROM EPGP_COST_CATEGORIES LEFT OUTER JOIN EPGP_LOOKUP_VALUES ON EPGP_COST_CATEGORIES.MC_UID = EPGP_LOOKUP_VALUES.LV_UID " +
                       " ORDER BY EPGP_COST_CATEGORIES.BC_ID";

            clscd.m_CostCat = new Dictionary<int, clsCatItemData>();
            clscd.m_Role_CC = new Dictionary<string, int>();
            clscd.m_CostCat_rolly = new Dictionary<int, clsCatItemData>();

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                oCat = new clsCatItemData(clscd.m_max_period);

                oCat.UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                oCat.ID = ++i;
                oCat.Level = DBAccess.ReadIntValue(reader["BC_LEVEL"]);
                oCat.Role_UID = DBAccess.ReadIntValue(reader["BC_ROLE"]);
                oCat.MC_UID = DBAccess.ReadIntValue(reader["MC_UID"]);

                if (oCat.Level < 1000)
                {
                    PidSet[oCat.Level] = oCat.UID;

                    if (oCat.Level > 1)
                        oCat.PID = PidSet[oCat.Level - 1];
                    else
                        oCat.PID = 0;
                }
                else
                    oCat.PID = 0;

                oCat.Name = DBAccess.ReadStringValue(reader["BC_NAME"]);
                oCat.UoM = DBAccess.ReadStringValue(reader["BC_UOM"]);
                oCat.Mode = (oCat.UoM == "" ? 0 : 1);
                oCat.Category = DBAccess.ReadIntValue(reader["CA_UID"]);
                oCat.MC_Val = DBAccess.ReadStringValue(reader["LV_VALUE"]);

                clscd.m_CostCat.Add(oCat.UID, oCat);

                oCat.Role_Name = "";

                if (oCat.Role_UID > 0)
                {

                    if (clscd.m_Role_CC.TryGetValue(oCat.Name, out iTemp) == false)
                    {
                        clscd.m_Role_CC.Add(oCat.Name, oCat.UID);
                        clscd.m_CostCat_rolly.Add(oCat.UID, oCat);
                        rolenames.Add(oCat.Role_UID, oCat);
                    }



                    if (rolenames.TryGetValue(oCat.Role_UID, out xCat) == true)
                    {
                        oCat.Role_Name = xCat.Name;
                    }
                }
            }

            reader.Close();
            reader = null;


            sCommand = "SELECT BA_BC_UID, BA_PRD_ID, BA_FTE_CONV,BA_RATE FROM EPGP_COST_BREAKDOWN_ATTRIBS WHERE  BA_RATETYPE_UID = 0 And BA_CODE_UID = 0 And CB_ID = " + clscd.m_CB_ID.ToString();

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                CatItemId = DBAccess.ReadIntValue(reader["BA_BC_UID"]);
                PerID = DBAccess.ReadIntValue(reader["BA_PRD_ID"]);

                if (clscd.m_CostCat.TryGetValue(CatItemId, out oCat) == true)
                {
                    oCat.FTEConv[PerID] = DBAccess.ReadDoubleValue(reader["BA_FTE_CONV"]);
                    oCat.Rates[PerID] = DBAccess.ReadDoubleValue(reader["BA_RATE"]);

                }
            }
            reader.Close();
            reader = null;

            string[] sFull = new string[500];

            foreach (clsCatItemData oxCat in clscd.m_CostCat.Values)
            {
                sFull[oxCat.Level] = oxCat.Name;

                oxCat.FullName = "";

                for (int xi = 1; xi < oxCat.Level; xi++)
                    oxCat.FullName = oxCat.FullName + sFull[xi] + ".";

                oxCat.FullName = oxCat.FullName + oxCat.Name;
            }


        }
        private void ReadCustomFields(SqlConnection oDataAccess, clsCostData clscd)
        {
            clscd.m_CustFields = new Dictionary<int, clsCustomFieldData>();
            clsCustomFieldData ocf;


            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            oCommand = new SqlCommand("EPG_SP_ReadCTFieldsInfo", oDataAccess);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                ocf = new clsCustomFieldData();

                ocf.FieldID = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);
                ocf.DisplayName = DBAccess.ReadStringValue(reader["FA_NAME"]);
                ocf.Name = ocf.DisplayName.Replace(" ", "");

                ocf.LookupOnly = DBAccess.ReadIntValue(reader["FA_LOOKUPONLY"]);
                ocf.LookupID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);
                ocf.LeafOnly = DBAccess.ReadIntValue(reader["FA_LEAFONLY"]);
                ocf.UseFullName = DBAccess.ReadIntValue(reader["FA_USEFULLNAME"]);

                ocf.ListItems = new Dictionary<int, clsListItemData>();
                clscd.m_CustFields.Add(ocf.FieldID, ocf);
            }

            reader.Close();
            reader = null;


            clsListItemData oListItem;
            string sCommand = "";

            foreach (clsCustomFieldData oc in clscd.m_CustFields.Values)
            {

                if (oc.LookupID != 0)
                {
                    sCommand = "SELECT LV_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = " + oc.LookupID.ToString() + " ORDER BY LV_ID ";

                    oCommand = new SqlCommand(sCommand, oDataAccess);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oListItem = new clsListItemData();

                        oListItem.UID = DBAccess.ReadIntValue(reader["LV_UID"]);
                        oListItem.ID = DBAccess.ReadIntValue(reader["LV_ID"]);
                        oListItem.Level = DBAccess.ReadIntValue(reader["LV_LEVEL"]);
                        oListItem.InActive = DBAccess.ReadBoolValue(reader["LV_INACTIVE"]);

                        oListItem.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                        oListItem.FullName = DBAccess.ReadStringValue(reader["LV_FULLVALUE"]);

                        oc.ListItems.Add(oListItem.UID, oListItem);
                    }

                    reader.Close();
                    reader = null;
                }
            }

            clscd.m_CustAttribs = new List<clsPortFieldData>();
            string sdata = clscd.m_sCostTypes.Trim();
            string stmp = "";
            sdata = sdata.Replace(",", " ").Trim();

            while (sdata != "")
            {
                int i = 0;

                i = sdata.IndexOf(" ");

                if (i == -1)
                {
                    stmp = sdata;
                    sdata = "";
                }
                else
                {
                    stmp = sdata.Substring(0, i);
                    sdata = sdata.Substring(i + 1);
                }

                i = int.Parse(stmp);

                oCommand = new SqlCommand("EPG_SP_ReadCTCustomFields", oDataAccess);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("CTID", i);

                reader = oCommand.ExecuteReader();

                clsPortFieldData oFieldItem = null;

                while (reader.Read())
                {
                    oFieldItem = new clsPortFieldData();

                    oFieldItem.ID = DBAccess.ReadIntValue(reader["FIELD_ID"]);
                    oFieldItem.Name = DBAccess.ReadStringValue(reader["FIELD_NAME"]);
                    oFieldItem.GivenName = DBAccess.ReadStringValue(reader["FA_NAME"]);

                    oFieldItem.Editable = DBAccess.ReadIntValue(reader["CF_EDITABLE"]);
                    oFieldItem.Required = DBAccess.ReadIntValue(reader["CF_REQUIRED"]);
                    oFieldItem.Identity = DBAccess.ReadIntValue(reader["CF_IDENTITY"]);
                    oFieldItem.Visible = DBAccess.ReadIntValue(reader["CF_VISIBLE"]);
                    oFieldItem.Frozen = DBAccess.ReadIntValue(reader["CF_FROZEN"]);

                    oFieldItem.Sequence = i;
                    clscd.m_CustAttribs.Add(oFieldItem);
                }
                reader.Close();
                reader = null;
            }

        }
        private void ReadCostTypeNames(SqlConnection oDataAccess, clsCostData clscd)
        {
            string stmp = "";
            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            clsDataItem oItem = null;


            stmp = clscd.m_sCostTypes;

            if (clscd.m_sOtherCostTypes != "")
            {
                if (stmp == "")
                    stmp = clscd.m_sOtherCostTypes;
                else
                    stmp = stmp + "," + clscd.m_sOtherCostTypes;
            }


            sCommand = " SELECT CT_ID, CT_NAME From EPGP_COST_TYPES Where CT_ID in (" + stmp + ") ORDER BY CT_NAME";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            clscd.m_CostTypes = new Dictionary<int, clsDataItem>();

            while (reader.Read())
            {
                oItem = new clsDataItem();

                oItem.UID = DBAccess.ReadIntValue(reader["CT_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["CT_NAME"]);
                oItem.Desc = oItem.Name;
                oItem.bSelected = true;
                clscd.m_CostTypes.Add(oItem.UID, oItem);
                oItem.ID = clscd.m_CostTypes.Count;
            }

            reader.Close();
            reader = null;

        }
        private void ReadStages(SqlConnection oDataAccess, clsCostData clscd)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            clsDataItem oItem = null;

            string sCommand = "";
            int i = 0;
            clscd.m_stages = new Dictionary<int, clsDataItem>();

            sCommand = "SELECT  STAGE_ID, STAGE_SEQ, STAGE_NAME From EPGP_STAGES";
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                oItem = new clsDataItem();

                i = DBAccess.ReadIntValue(reader["STAGE_ID"]);
                oItem.UID = DBAccess.ReadIntValue(reader["STAGE_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["STAGE_NAME"]);
                clscd.m_stages.Add(i, oItem);
            }
            reader.Close();
            reader = null;
        }
        private void ReadExtraPifields(SqlConnection oDataAccess, clsCostData clscd)
        {

            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            string sCommand = "";
            int i = 0;
            int ftabextra = 0;
            int fintabextra = 0;


            //            sCommand = "Select rd.*,FIELD_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,at.FA_FORMAT, fl.FIELD_NAME_SQL, at.FA_NAME, fl.FIELD_NAME AS Expr1" +
            //                       " From EPGP_RD_FIELDS rd  Left Join EPGT_FIELDS fl On fl.FIELD_ID=rd.FIELD_ID  Left Join EPGC_FIELD_ATTRIBS at On at.FA_FIELD_ID=rd.FIELD_ID Where CONTEXT_ID = 101";

            sCommand =
                "Select t.* From EPGT_FIELDS t Left Join  EPGP_RD_FIELDS r On t.FIELD_ID=r.FIELD_ID And CONTEXT_ID=101 " +
                " Where t.FIELD_ID IN (9901,9902,9904,9911,9928,9950,9922,9925,9930)";

            // need to read these and munge them into the arrays that were used before
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read() && i <= (int)cdFieldIDs.MAX_PI_EXTRA)
            {
                ++i;

                clscd.m_fidextra[i] = DBAccess.ReadIntValue(reader["FIELD_ID"]);

                clscd.m_ExtraFieldNames[i] = "";

                if (clscd.m_ExtraFieldNames[i] == "")
                    clscd.m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["FIELD_NAME"]);

                clscd.m_ExtraFieldNames[i] = clscd.m_ExtraFieldNames[i].Replace("%", "Percent");

                if (clscd.m_fidextra[i] == 9911)
                    clscd.m_ExtraFieldTypes[i] = 9911;     //   ' change Stage from an integer (2) to a special text field (9911)
                else if (clscd.m_ExtraFieldTypes[i] == 0)
                    clscd.m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);


                clscd.m_sextra[i] = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);



            }
            reader.Close();
            reader = null;

            sCommand = "SELECT     rd.CONTEXT_ID, rd.FIELD_ID, rd.FIELD_NAME, rd.FIELD_SELECT, fl.FIELD_FORMAT, at.FA_TABLE_ID, at.FA_FIELD_IN_TABLE, at.FA_FORMAT, fl.FIELD_NAME_SQL,  " +
                "  at.FA_NAME, fl.FIELD_NAME AS Expr1 FROM  EPGC_FIELD_ATTRIBS AS at LEFT OUTER JOIN EPGP_RD_FIELDS AS rd ON rd.FIELD_ID = at.FA_FIELD_ID AND rd.CONTEXT_ID = 101 LEFT OUTER JOIN " +
                " EPGT_FIELDS AS fl ON fl.FIELD_ID = rd.FIELD_ID WHERE     (at.FA_TABLE_ID = 201) AND (at.FA_FORMAT = 4 OR at.FA_FORMAT = 13 OR at.FA_FORMAT = 7) OR " +
                " (at.FA_TABLE_ID = 202) OR (at.FA_TABLE_ID = 203) OR (at.FA_TABLE_ID = 205)";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read() && i <= (int)cdFieldIDs.MAX_PI_EXTRA)
            {
                ++i;

                clscd.m_fidextra[i] = DBAccess.ReadIntValue(reader["FIELD_ID"]);

                clscd.m_ExtraFieldNames[i] = "";

                if (clscd.m_ExtraFieldNames[i] == "")
                    clscd.m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["FA_NAME"]);

                if (clscd.m_ExtraFieldNames[i] == "")
                    clscd.m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["Expr1"]);


                clscd.m_ExtraFieldNames[i] = clscd.m_ExtraFieldNames[i].Replace("%", "Percent");

                clscd.m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);

                if (clscd.m_fidextra[i] == 9911)
                    clscd.m_ExtraFieldTypes[i] = 9911;     //   ' change Stage from an integer (2) to a special text field (9911)
                else if (clscd.m_ExtraFieldTypes[i] == 0)
                    clscd.m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FA_FORMAT"]);


                clscd.m_sextra[i] = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);

                if (clscd.m_sextra[i] == "")
                {
                    ftabextra = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    fintabextra = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);

                    string stab = "";
                    string sfnam = "";

                    GetCFFieldName(ftabextra, fintabextra, out stab, out sfnam);
                    clscd.m_sextra[i] = sfnam;
                }

            }
            reader.Close();
            reader = null;

            clscd.m_Use_extra = i;
        }
        private void ReadPILevelData(SqlConnection oDataAccess, clsCostData clscd, out DateTime earlystart, out DateTime latefinish)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            clsDataItem oItem = null;
            earlystart = DateTime.MinValue;
            latefinish = DateTime.MinValue;

            string sCommand = "";

            clscd.m_PIs = new Dictionary<string, clsPIData>();


            sCommand = "SELECT  EPGP_PROJECTS.PROJECT_ID,  EPGP_PROJECTS.PROJECT_START_DATE,  EPGP_PROJECTS.PROJECT_FINISH_DATE,  EPGP_PROJECTS.PROJECT_NAME ";

            if (clscd.m_SelFID == 0)
                sCommand = sCommand + ",1 AS XYZZY ";
            else
                sCommand = sCommand + "," + clscd.m_Select_FieldName + " AS XYZZY ";


            for (int i = 1; i <= clscd.m_Use_extra; i++)
                sCommand = sCommand + "," + clscd.m_sextra[i];

            string sCodes = "";
            string sRes = "";


            sCommand = sCommand + " From EPGP_PROJECTS "
                        + " left join EPGP_PROJECT_INT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_INT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_TEXT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_TEXT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_NTEXT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_NTEXT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_DEC_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_DEC_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_DATE_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_DATE_VALUES.PROJECT_ID"
                        + " Where  EPGP_PROJECTS.PROJECT_ID in (" + clscd.m_sPids + ")";


            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            clsPIData oPI;



            while (reader.Read())
            {
                oPI = new clsPIData((int)cdFieldIDs.MAX_PI_EXTRA);
                oPI.PI_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                oPI.PI_Name = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);
                oPI.StartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                oPI.FinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);
                oPI.oStartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                oPI.oFinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);

                if (earlystart == DateTime.MinValue)
                    earlystart = oPI.oStartDate;
                else if (oPI.oStartDate != DateTime.MinValue)
                {
                    if (earlystart > oPI.oStartDate)
                        earlystart = oPI.oStartDate;
                }


                if (latefinish < oPI.FinishDate)
                    latefinish = oPI.FinishDate;

                oPI.Scenario_name = clsCostData.CONST_CURRENT;


                if (clscd.m_dtMin > oPI.StartDate && oPI.StartDate != DateTime.MinValue)
                    clscd.m_dtMin = oPI.StartDate;

                if (clscd.m_dtMax < oPI.FinishDate)
                    clscd.m_dtMax = oPI.FinishDate;


                oPI.ScenarioID = -1;
                oPI.PISelected = DBAccess.ReadIntValue(reader["XYZZY"]);

                if (oPI.PISelected != 0)
                    oPI.PISelected = 1;

                object obj = null;

                for (int i = 1; i <= clscd.m_Use_extra; i++)
                {
                    obj = reader[4 + i];

                    if (clscd.m_fidextra[i] == 9911)
                    {
                        int xi = 0;
                        if (!obj.Equals(System.DBNull.Value))
                            xi = Convert.ToInt32(obj);
                        else
                            xi = 0;

                        if (clscd.m_stages.TryGetValue(xi, out oItem))
                            oPI.m_PI_Extra_data[i] = oItem.UID.ToString();
                        else
                            oPI.m_PI_Extra_data[i] = "";
                    }
                    else
                        oPI.m_PI_Extra_data[i] = MyFormat(obj, clscd.m_ExtraFieldTypes[i], ref sCodes, ref sRes);
                }

                string sKey = oPI.PI_ID.ToString() + " " + oPI.ScenarioID.ToString();

                clscd.m_PIs.Add(sKey, oPI);
                oPI.Internal_ID = clscd.m_PIs.Count;
            }
            reader.Close();
            reader = null;

            sCodes = sCodes.Replace(" ", "");
            sRes = sRes.Replace(" ", "");

            clscd.m_codes = new Dictionary<int, clsDataItem>();
            clscd.m_reses = new Dictionary<int, clsDataItem>();

            // ' Now read Code and resource values....

            if (sCodes != "")
            {

                sCommand = "SELECT LV_UID, LV_VALUE, LV_FULLVALUE From EPGP_LOOKUP_VALUES WHERE LV_UID IN (" + sCodes + ")";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new clsDataItem();

                    oItem.UID = DBAccess.ReadIntValue(reader["LV_UID"]);
                    oItem.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                    oItem.Desc = DBAccess.ReadStringValue(reader["LV_FULLVALUE"]);
                    clscd.m_codes.Add(oItem.UID, oItem);

                }
                reader.Close();
                reader = null;
            }

            if (sRes != "")
            {

                sCommand = "SELECT WRES_ID, RES_NAME FROM  EPG_RESOURCES WHERE WRES_ID IN (" + sRes + ")";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new clsDataItem();

                    oItem.UID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    oItem.Name = DBAccess.ReadStringValue(reader["RES_NAME"]);
                    clscd.m_reses.Add(oItem.UID, oItem);

                }
                reader.Close();
                reader = null;
            }
        }
        private void ReadCostCustomFieldsAndData(SqlConnection oDataAccess, clsCostData clscd)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            clsDetailRowData Det = null;
            clsDetailRowData TryDet = null;
            string sCommand = "";
            Dictionary<int, clsDataItem> clnCalcs = new Dictionary<int, clsDataItem>();
            clsDataItem oItem = null;


            int xCT_ID = 0;
            int xProject_ID = 0;
            int xBC_UID = 0;
            int xBC_SEQ = 0;
            int Peracc = 0;
            int xCurScen = -1;

            int ctid = 0;
            int CL_CT_ID = 0;
            int CL_OP = 0;

            clscd.m_firstperiod_data = clscd.m_max_period;

            clscd.m_detaildata = new Dictionary<string, clsDetailRowData>();

            if (clscd.m_sCostTypes != "")
            {
                sCommand = "SELECT * FROM EPGP_COST_DETAILS " +
                          " WHERE CB_ID = " + clscd.m_CB_ID.ToString() +
                          " AND CT_ID IN (" + clscd.m_sCostTypes + ") " +
                          " AND PROJECT_ID IN (" + clscd.m_sPids + ") " +
                          " ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    Det = new clsDetailRowData(clscd.m_max_period);

                    Det.CB_ID = DBAccess.ReadIntValue(reader["CB_ID"]);
                    Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    Det.BC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);
                    Det.Scenario_ID = xCurScen;

                    for (int i = 1; i <= 5; i++)
                    {
                        Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                        Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                    }

                    Det.m_rt = DBAccess.ReadIntValue(reader["RT_UID"]);
                    Det.bSelected = true;
                    sCommand = "K" + Det.CT_ID.ToString() + " " + Det.PROJECT_ID.ToString() + " " + Det.BC_UID.ToString() + " " + Det.BC_SEQ.ToString() + " " + Det.Scenario_ID.ToString();
                    Det.m_dict_key = sCommand;


                    if (clscd.m_detaildata.TryGetValue(sCommand, out TryDet) == false)
                        clscd.m_detaildata.Add(sCommand, Det);
                }
                reader.Close();
                reader = null;


                if (clscd.m_sCalcCostTypes != "")
                {
                    sCommand = "SELECT * FROM EPGP_COST_CALC WHERE CT_ID IN (" + clscd.m_sCalcCostTypes + ") ORDER BY CT_ID,CL_ID";


                    oCommand = new SqlCommand(sCommand, oDataAccess);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        ctid = DBAccess.ReadIntValue(reader["CT_ID"]);
                        CL_CT_ID = DBAccess.ReadIntValue(reader["CL_CT_ID"]);
                        CL_OP = DBAccess.ReadIntValue(reader["CL_OP"]);

                        if (clnCalcs.TryGetValue(ctid, out oItem) == false)
                        {
                            oItem = new clsDataItem();
                            oItem.UID = ctid;
                            clnCalcs.Add(ctid, oItem);
                            oItem.Desc = "";
                        }

                        oItem.Desc = oItem.Desc + " " + CL_CT_ID.ToString() + " " + CL_OP.ToString();
                        oItem.Name = oItem.Name + " " + CL_CT_ID.ToString();

                    }
                    reader.Close();
                    reader = null;
                    clsDataItem oi = null;

                    foreach (KeyValuePair<int, clsDataItem> pair in clnCalcs)
                    {
                        oi = pair.Value;
                        oi.Name = oi.Name.Trim();
                        oi.Name = oi.Name.Replace(" ", ",");

                        sCommand = "SELECT * FROM EPGP_COST_DETAILS WHERE CB_ID = " + clscd.m_CB_ID.ToString() + " AND CT_ID IN (" + oi.Name + ") AND PROJECT_ID IN (" + clscd.m_sPids + ")  ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

                        oCommand = new SqlCommand(sCommand, oDataAccess);
                        reader = oCommand.ExecuteReader();


                        while (reader.Read())
                        {
                            Det = new clsDetailRowData(clscd.m_max_period);

                            Det.CB_ID = DBAccess.ReadIntValue(reader["CB_ID"]);
                            Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                            Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                            Det.BC_SEQ = 0;
                            Det.bSelected = true;

                            Det.Scenario_ID = xCurScen;
                            for (int i = 1; i <= 5; i++)
                            {
                                Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                                Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                            }

                            Det.m_rt = DBAccess.ReadIntValue(reader["RT_UID"]);

                            sCommand = "K" + oi.UID.ToString() + " " + Det.PROJECT_ID.ToString() + " " + Det.BC_UID.ToString() + " " + Det.Scenario_ID.ToString();
                            Det.m_dict_key = sCommand;

                            if (clscd.m_detaildata.TryGetValue(sCommand, out TryDet) == false)
                                clscd.m_detaildata.Add(sCommand, Det);
                            else
                            {
                                for (int i = 1; i <= 5; i++)
                                {
                                    if (TryDet.OCVal[i] != Det.OCVal[i])
                                        TryDet.OCVal[i] = 0;
                                    if (TryDet.TXVal[i] != Det.TXVal[i])
                                        TryDet.TXVal[i] = "";
                                }

                                if (TryDet.m_rt != Det.m_rt)
                                    TryDet.m_rt = 0;

                            }
                        }
                        reader.Close();
                        reader = null;
                    }
                }


                sCommand = "SELECT * FROM EPGP_DETAIL_VALUES WHERE CB_ID = " + clscd.m_CB_ID.ToString() + " AND CT_ID IN (" + clscd.m_sCostTypes + ") AND PROJECT_ID IN (" + clscd.m_sPids + ")  ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    xCT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    xBC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);

                    sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xCurScen.ToString();

                    if (clscd.m_detaildata.TryGetValue(sCommand, out Det) == false)
                    {
                        Det = new clsDetailRowData(clscd.m_max_period);
                        Det.m_dict_key = sCommand;

                        Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                        Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        Det.BC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);
                        Det.Scenario_ID = xCurScen;
                        Det.bSelected = true;

                        for (int i = 1; i <= 5; i++)
                        {
                            Det.OCVal[i] = 0;
                            Det.TXVal[i] = "";
                        }

                        Det.m_rt = 0;
                        clscd.m_detaildata.Add(sCommand, Det);
                    }

                    Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);


                    Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                    Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);


                    if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                    {
                        Det.HasValues = true;
                        if (clscd.m_firstperiod_data > Peracc)
                            clscd.m_firstperiod_data = Peracc;

                        if (Peracc > clscd.m_lastperiod_data)
                            clscd.m_lastperiod_data = Peracc;                        
                    }
 
                }
                reader.Close();
                reader = null;
            }


            if (clscd.m_sOtherCostTypes != "")
            {

                sCommand = "SELECT  * From EPGP_COST_VALUES WHERE CB_ID = " + clscd.m_CB_ID.ToString() +
                           " AND CT_ID IN (" + clscd.m_sOtherCostTypes + ") AND PROJECT_ID IN (" + clscd.m_sPids + ") AND BD_IS_SUMMARY = 0  AND BC_UID <> 0 ORDER BY PROJECT_ID, CT_ID, BC_UID";



                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    xCT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    xBC_SEQ = 0;


                    sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xCurScen.ToString();

                    if (clscd.m_detaildata.TryGetValue(sCommand, out Det) == false)
                    {
                        Det = new clsDetailRowData(clscd.m_max_period);
                        Det.m_dict_key = sCommand;

                        Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                        Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        Det.BC_SEQ = 0;
                        Det.Scenario_ID = xCurScen;
                        Det.bSelected = true;


                        for (int i = 1; i <= 5; i++)
                        {
                            Det.OCVal[i] = 0;
                            Det.TXVal[i] = "";
                        }

                        Det.m_rt = 0;
                        clscd.m_detaildata.Add(sCommand, Det);
                    }

                    Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);


                    Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                    Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                    if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                    {
                        Det.HasValues = true;
                        if (clscd.m_firstperiod_data > Peracc)
                            clscd.m_firstperiod_data = Peracc;

                        if (Peracc > clscd.m_lastperiod_data)
                            clscd.m_lastperiod_data = Peracc;
                    }

                }
                reader.Close();
                reader = null;
            }


            string scalc = "";


            if (clscd.m_sCalcCostTypes != "")
            {
                foreach (KeyValuePair<int, clsDataItem> pair in clnCalcs)
                {
                    clsDataItem oi = null;

                    oi = pair.Value;

                    scalc = oi.Desc.Trim();

                    while (scalc != "")
                    {

                        CL_CT_ID = StripNum(ref scalc);
                        CL_OP = StripNum(ref scalc);

                        sCommand = "SELECT * FROM EPGP_DETAIL_VALUES " +
                                 " WHERE CB_ID = " + clscd.m_CB_ID.ToString() +
                                 " AND CT_ID = " + CL_CT_ID.ToString() +
                                 " AND PROJECT_ID IN (" + clscd.m_sPids + ") " +
                                 " ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";



                        oCommand = new SqlCommand(sCommand, oDataAccess);
                        reader = oCommand.ExecuteReader();


                        while (reader.Read())
                        {
                            xCT_ID = oi.UID;  //oDBAccess.ReadIntValue(reader["CT_ID"]);
                            xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                            xBC_SEQ = 0;


                            sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xCurScen.ToString();

                            if (clscd.m_detaildata.TryGetValue(sCommand, out Det) == false)
                            {
                                Det = new clsDetailRowData(clscd.m_max_period);
                                Det.m_dict_key = sCommand;

                                Det.CT_ID = xCT_ID;
                                Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                                Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                                Det.BC_SEQ = 0;
                                Det.Scenario_ID = xCurScen;

                                Det.bSelected = true;

                                for (int i = 1; i <= 5; i++)
                                {
                                    Det.OCVal[i] = 0;
                                    Det.TXVal[i] = "";
                                }

                                Det.m_rt = 0;
                                clscd.m_detaildata.Add(sCommand, Det);
                            }


                            double dCost = 0;
                            double dValue = 0;

                            Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);


                            dCost = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                            dValue = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);

                            if (CL_OP == 0)
                            {
                                Det.zCost[Peracc] = Det.zCost[Peracc] + dCost;
                                Det.zValue[Peracc] = Det.zValue[Peracc] + dValue;
                                if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                                {
                                    Det.HasValues = true;
                                    if (clscd.m_firstperiod_data > Peracc)
                                        clscd.m_firstperiod_data = Peracc;

                                    if (Peracc > clscd.m_lastperiod_data)
                                        clscd.m_lastperiod_data = Peracc;
                                }
                            }
                            else
                            {

                                Det.zCost[Peracc] = Det.zCost[Peracc] - dCost;
                                Det.zValue[Peracc] = Det.zValue[Peracc] - dValue;
                                if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                                {
                                    Det.HasValues = true;
                                    if (clscd.m_firstperiod_data > Peracc)
                                        clscd.m_firstperiod_data = Peracc;

                                    if (Peracc > clscd.m_lastperiod_data)
                                        clscd.m_lastperiod_data = Peracc;
                                }
                            }

                        }
                        reader.Close();
                        reader = null;
                    }
                }
            }

            foreach (clsDetailRowData xDet in clscd.m_detaildata.Values)
            {

                clsPIData oPI = null;
                clsCatItemData oCat;

                if (clscd.m_PIs.TryGetValue(xDet.PROJECT_ID.ToString() + " -1", out oPI))
                    xDet.PI_Name = oPI.PI_Name;
                else
                    xDet.PI_Name = "";

                if (clscd.m_CostTypes.TryGetValue(xDet.CT_ID, out oItem))
                    xDet.CT_Name = oItem.Name;
                else
                    xDet.CT_Name = "";

                //if (m_Scenario.TryGetValue(xDet.Scenario_ID, out oItem))
                //    xDet.Scen_Name = oItem.Name;
                //else
                    xDet.Scen_Name = "";

                if (clscd.m_CostCat.TryGetValue(xDet.BC_UID, out oCat))
                {
                    xDet.Cat_Name = oCat.Name;
                    xDet.FullCatName = oCat.FullName;
                    xDet.MC_Name = oCat.MC_Val;
                    xDet.Role_Name = oCat.Role_Name;

                    if (clscd.m_CostCat.TryGetValue(oCat.Category, out oCat))
                    {
                        xDet.CC_Name = oCat.Name;
                        xDet.FullCCName = oCat.FullName;
                    }
                }

                for (int xi = 1; xi <= 5; ++xi)
                {
                    xDet.Text_OCVal[xi] = "";

                }




            }


        }
        private void ReadBudgetBands(SqlConnection oDataAccess, clsCostData clscd)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";

            clsTargetColours TarCol = null;

            clscd.m_clsTargetColours = new List<clsTargetColours>();

            sCommand = "SELECT BUDSP_UID, BAND_ID, BAND_BOT,BAND_TOP,BAND_BACKCOLOR,BAND_NAME FROM EPGT_VIEW_BUDSPEC_BAND WHERE BUDSP_UID = 1 ORDER BY BAND_ID";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                TarCol = new clsTargetColours();

                TarCol.ID = DBAccess.ReadIntValue(reader["BAND_ID"]);
                TarCol.rgb_val = DBAccess.ReadIntValue(reader["BAND_BACKCOLOR"]);
                TarCol.low_val = DBAccess.ReadDoubleValue(reader["BAND_BOT"]);
                TarCol.high_val = DBAccess.ReadDoubleValue(reader["BAND_TOP"]);
                TarCol.Desc = DBAccess.ReadStringValue(reader["BAND_NAME"]);

                clscd.m_clsTargetColours.Add(TarCol);

            }
            reader.Close();
            reader = null;

            if (clscd.m_clsTargetColours.Count != 0)
                return;
  

            sCommand = "SELECT BUDSP_UID, BAND_ID, BAND_BOT,BAND_TOP,BAND_BACKCOLOR,BAND_NAME FROM EPGT_VIEW_BUDSPEC_BAND WHERE BUDSP_UID = 0 ORDER BY BAND_ID";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                TarCol = new clsTargetColours();

                TarCol.ID = DBAccess.ReadIntValue(reader["BAND_ID"]);
                TarCol.rgb_val = DBAccess.ReadIntValue(reader["BAND_BACKCOLOR"]);
                TarCol.low_val = DBAccess.ReadDoubleValue(reader["BAND_BOT"]);
                TarCol.high_val = DBAccess.ReadDoubleValue(reader["BAND_TOP"]);
                TarCol.Desc = DBAccess.ReadStringValue(reader["BAND_NAME"]);

                clscd.m_clsTargetColours.Add(TarCol);

            }
            reader.Close();
            reader = null;
        }

        private void ReadRateTable(SqlConnection oDataAccess, clsCostData clscd)
        {

            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";
            int rCount = 0;

            clscd.m_Rates = new Dictionary<int, clsRateTable>();
            clscd.m_ratecache = new Dictionary<string, clsRateFTECache>();




            sCommand = "SELECT COUNT(CT_ALLOW_NAMED_RATES) AS CT_ALLOW_NAMED_RATES From EPGP_COST_TYPES Where (CT_ALLOW_NAMED_RATES <> 0)";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                rCount = DBAccess.ReadIntValue(reader["CT_ALLOW_NAMED_RATES"]);
            }
            reader.Close();
            reader = null;



            // will only need rates if there is a CT that uas rates enabled

            if (rCount != 0)
            {


                sCommand = "SELECT  * FROM   EPG_RATES ORDER BY RT_ID";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();
                clsRateTable oRatItem = null;

                while (reader.Read())
                {
                    oRatItem = new clsRateTable(clscd.m_max_period);
                    oRatItem.UID = DBAccess.ReadIntValue(reader["RT_UID"]);
                    oRatItem.ID = DBAccess.ReadIntValue(reader["RT_ID"]);
                    oRatItem.Level = DBAccess.ReadIntValue(reader["RT_LEVEL"]);
                    oRatItem.Name = DBAccess.ReadStringValue(reader["RT_NAME"]);
                    clscd.m_Rates.Add(oRatItem.UID, oRatItem);


                }
                reader.Close();
                reader = null;


                sCommand = "SELECT  * FROM    EPG_RATE_VALUES ORDER BY RT_UID,RT_EFFECTIVE_DATE";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();
                int RT_UID = 0;
                DateTime EffectiveDate;
                double Rate = 0;
                int sp;

                while (reader.Read())
                {
                    RT_UID = DBAccess.ReadIntValue(reader["RT_UID"]);
                    Rate = DBAccess.ReadDoubleValue(reader["RT_RATE"]);
                    EffectiveDate = DBAccess.ReadDateValue(reader["RT_EFFECTIVE_DATE"]);

                    if (clscd.m_Rates.TryGetValue(RT_UID, out oRatItem) == false)
                    {
                        oRatItem = new clsRateTable(clscd.m_max_period);
                        oRatItem.UID = RT_UID;
                        clscd.m_Rates.Add(oRatItem.UID, oRatItem);
                    }

                    if (EffectiveDate <= DateTime.MinValue)
                        sp = 1;
                    else
                    {
                        sp = 0;
                        foreach (clsPeriodData oPer in clscd.m_Periods.Values)
                        {
                            ++sp;
                            if (oPer.StartDate >= EffectiveDate)
                                break;

                        }

                    }

                    for (int i = sp; i <= clscd.m_max_period; i++)
                    {
                        oRatItem.zRate[i] = Rate;
                    }


                }
                reader.Close();
                reader = null;
            }

        }

        private void StashRateCache(clsCostData clscd)
        {

            // This code caches a unique collectrion of rate/fte conversion factors based upon the details BC_UID and RT ID - which allows the rapid conversion calcs to be carried out
            string sKey = "";
            clsRateFTECache oRF = null;
            clsCatItemData oCat = null;
            clsRateTable oRT = null;

            foreach (clsDetailRowData Det in clscd.m_detaildata.Values)
            {
                sKey = "K" + Det.BC_UID.ToString() + " " + Det.m_rt.ToString();

                if (clscd.m_ratecache.TryGetValue(sKey, out oRF) == false)
                {
                    oRF = new clsRateFTECache(clscd.m_max_period);

                    if (clscd.m_CostCat.TryGetValue(Det.BC_UID, out oCat))
                    {
                        for (int i = 1; i <= clscd.m_max_period; i++)
                        {
                            oRF.zRate[i] = oCat.Rates[i];
                            oRF.zFTE[i] = oCat.FTEConv[i];
                        }
                    }

                    if (clscd.m_Rates.TryGetValue(Det.m_rt, out oRT))
                    {
                        for (int i = 1; i <= clscd.m_max_period; i++)
                        {
                            oRF.zRate[i] = oRT.zRate[i];
                        }
                    }

                    clscd.m_ratecache.Add(sKey, oRF);
                }
            }
        }

        private void PerformCalcs(clsDetailRowData odet, clsCostData clscd)
        {

            if (odet.sUoM == "")
            {
                for (int i = 1; i <= clscd.m_max_period; i++)
                {
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
                return;
            }
            else 
            {
                for (int i = 1; i <= clscd.m_max_period; i++)
                {
                    odet.zFTE[i] = 0;
                }
            }

            string sKey = "";
            clsRateFTECache oRF = null;
            clsCatItemData oCat = null;

            double[] rates = null, fte = null;

            sKey = "K" + odet.BC_UID.ToString() + " " + odet.m_rt.ToString();

            if (clscd.m_ratecache.TryGetValue(sKey, out oRF))
            {
                rates = oRF.zRate;
                fte = oRF.zFTE;
            }
            else if (clscd.m_CostCat.TryGetValue(odet.BC_UID, out oCat))
            {
                rates = oCat.Rates;
                fte = oCat.FTEConv;
            }

 //           if (rates == null)
 //           {

 //               for (int i = 1; i <= clscd.m_max_period; i++)
 //               {
 ////                   odet.zCost[i] = 0;
 //               }
 //               return;
 //           }


 //           for (int i = 1; i <= clscd.m_max_period; i++)
 //           {
 ////               odet.zCost[i] = odet.zValue[i] * rates[i];
 //           }

            if (fte == null)
                return;

            for (int i = 1; i <= clscd.m_max_period; i++)
            {
                if (fte[i] != 0)
                    odet.zFTE[i] = (odet.zValue[i] / fte[i]) * 100;
                else
                    odet.zFTE[i] = 0;
            }
         }

        private void GetCFFieldName(int lTableID, int lFieldID, out string sTable, out string sField)
        {
            switch ((CustomFieldDBTable)lTableID)
            {
                case CustomFieldDBTable.ResourceINT:
                    sTable = "EPGC_RESOURCE_INT_VALUES";
                    sField = "RI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceTEXT:
                    sTable = "EPGC_RESOURCE_TEXT_VALUES";
                    sField = "RT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceDEC:
                    sTable = "EPGC_RESOURCE_DEC_VALUES";
                    sField = "RC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceNTEXT:
                    sTable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sField = "RN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceDATE:
                    sTable = "EPGC_RESOURCE_DATE_VALUES";
                    sField = "RD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceMV:
                    sTable = "EPGC_RESOURCE_MV_VALUES";
                    sField = "MVR_UID";
                    break;
                case CustomFieldDBTable.PortfolioINT:
                    sTable = "EPGP_PROJECT_INT_VALUES";
                    sField = "PI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioTEXT:
                    sTable = "EPGP_PROJECT_TEXT_VALUES";
                    sField = "PT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioDEC:
                    sTable = "EPGP_PROJECT_DEC_VALUES";
                    sField = "PC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioNTEXT:
                    sTable = "EPGP_PROJECT_NTEXT_VALUES";
                    sField = "PN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioDATE:
                    sTable = "EPGP_PROJECT_DATE_VALUES";
                    sField = "PD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.Program:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_UID";
                    break;
                case CustomFieldDBTable.ProjectINT:
                    sTable = "EPGX_PROJ_INT_VALUES";
                    sField = "XI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectTEXT:
                    sTable = "EPGX_PROJ_TEXT_VALUES";
                    sField = "XT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectDEC:
                    sTable = "EPGX_PROJ_DEC_VALUES";
                    sField = "XC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectNTEXT:
                    sTable = "EPGX_PROJ_NTEXT_VALUES";
                    sField = "XN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectDATE:
                    sTable = "EPGX_PROJ_DATE_VALUES";
                    sField = "XD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProgramText:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_PI_TEXT" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWIINT:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_FLAG" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWITEXT:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_CTEXT" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWIDEC:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_NUMBER" + lFieldID.ToString("0");
                    break;
                default:
                    sTable = "Unknown Table";
                    sField = "";
                    break;
            }

        }
        private string MyFormat(object obj, int lt, ref string sCodes, ref string sRes)
        {



            switch (lt)
            {
                case clsCostData.EPK_FTYPE_DATE:
                    DateTime dt;

                    dt = DBAccess.ReadDateValue(obj);
                    string rs = dt.ToString("yyyyMMddHHmm");
                    return rs;


                case clsCostData.EPK_FTYPE_INTEGER:
                case clsCostData.EPK_FTYPE_NUMBER:
                case clsCostData.EPK_FTYPE_CURRENCY:
                case clsCostData.EPK_FTYPE_PERCENT:
                case clsCostData.EPK_FTYPE_YESNO:
                case clsCostData.EPK_FTYPE_WORK:
                case clsCostData.EPK_FTYPE_DURATION:

                    long i;

                    i = (long)DBAccess.ReadDecimalValue(obj);
                    return i.ToString();

                case clsCostData.EPK_FTYPE_URL:
                case clsCostData.EPK_FTYPE_TEXT:
                case clsCostData.EPK_FTYPE_RTF:
                    return DBAccess.ReadStringValue(obj);

                case clsCostData.EPK_FTYPE_CODE:
                    int c;

                    c = DBAccess.ReadIntValue(obj);

                    if (sCodes.IndexOf(" " + c.ToString() + " ") == -1)
                    {
                        if (sCodes == "")
                            sCodes = " " + c.ToString() + " ";
                        else
                            sCodes = sCodes + ", " + c.ToString() + " ";
                    }

                    return c.ToString();

                case clsCostData.EPK_FTYPE_RES:
                    int r;

                    r = DBAccess.ReadIntValue(obj);

                    if (sRes.IndexOf(" " + r.ToString() + " ") == -1)
                    {
                        if (sRes == "")
                            sRes = " " + r.ToString() + " ";
                        else
                            sRes = sRes + ", " + r.ToString() + " ";
                    }

                    return r.ToString();
            }
            return "";
        }
        private int StripNum(ref string sin)
        {
            int i = 0;
            string sval = "";

            sin = sin.Trim();
            i = sin.IndexOf(" ");

            if (i == -1)
            {
                sval = sin;
                sin = "";
            }
            else
            {
                sval = sin.Substring(0, i);
                sin = sin.Substring(i + 1); //, sin.Length - i);
            }

            return int.Parse(sval);
        }

 
        public bool GetCostAnalyzerViewsXML(out string sReply)
        {
            sReply = "";
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xRPE = new CStruct();
            xRPE.Initialize("Views");

            //string sCommand = "SELECT VIEW_GUID,VIEW_NAME,VIEW_PERSONAL,VIEW_DEFAULT FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";
            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=33000 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_NAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                CStruct xView = new CStruct();
                //CStruct xView = xRPE.CreateSubStruct("View");
                //xView.CreateGuidAttr("ViewGUID", DBAccess.ReadGuidValue(reader["VIEW_GUID"]));
                //xView.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["VIEW_NAME"]));
                //xView.CreateBooleanAttr("Personal", DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]));
                //xView.CreateBooleanAttr("Default", DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]));
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView.LoadXML(sXML);
                    xRPE.AppendSubStruct(xView);
                }
            }
            reader.Close();
            sReply = xRPE.XML();
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool GetCostAnalyzerViewXML(Guid guidView, out string sReply)
        {
            sReply = "";

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xView = new CStruct();
            //xView.Initialize("View");

            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=33000 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                //Guid guidView2 = DBAccess.ReadGuidValue(reader["VIEW_GUID"]);
                //string sName = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                //bool bPersonal = DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]);
                //bool bDefault = DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]);
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                    xView.LoadXML(sXML);
                //xView.SetIntAttr("ViewUID", nUID);
                //xView.SetStringAttr("Name", sName);
                //xView.SetBooleanAttr("Personal", bPersonal);
                //xView.SetBooleanAttr("Default", bDefault);
            }
            reader.Close();
            sReply = xView.XML(); ;
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool SaveCostAnalyzerViewXML(Guid guidView, string sName, bool bPersonal, bool bDefault, string sData)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            //SqlCommand cmd = new SqlCommand("DELETE FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND VIEW_UID=?",  _sqlConnection);
            //cmd.Parameters.AddWithValue("VIEW_UID", nViewUID);
            //int lRowsAffected = cmd.ExecuteNonQuery();
            string sCommand;
            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@vname,WRES_ID=@wres,VIEW_DEFAULT=@vdef,VIEW_DATA=@vdata,VIEW_CONTEXT=33000 WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@vname", sName);
            cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
            cmd.Parameters.AddWithValue("@vdef", bDefault);
            cmd.Parameters.AddWithValue("@vdata", sData);
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                sCommand = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@guid,@name,@wres,@def,@vdata,33000)";
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.Parameters.AddWithValue("@guid", guidView);
                cmd.Parameters.AddWithValue("@name", sName);
                cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
                cmd.Parameters.AddWithValue("@def", bDefault);
                cmd.Parameters.AddWithValue("@vdata", sData);
                nRowsAffected = cmd.ExecuteNonQuery();
            }

            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool DeleteCostAnalyzerViewXML(Guid guidView)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            string sCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool RenameCostAnalyzerViewXML(Guid guidView, string sName)
        {
            string sCommand;
            CStruct xView = null;
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=33000 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView = new CStruct();
                    xView.LoadXML(sXML);
                }
            }
            reader.Close();

            if (xView == null)
                return false;

            xView.SetStringAttr("Name", sName);

            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@name,VIEW_DATA = @vdata WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@name", sName);
            cmd.Parameters.AddWithValue("@vdata", xView.XML());
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                return false;
            }


            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }


        private string FormatSQLDateTime(DateTime dt)
        {
            return "CONVERT(DATETIME, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', 102)";
        }

        private int LoadTargets(clsCostData clscd)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open(); 
            
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";
            clsDetailRowData Det = null;
            clsDetailRowData TryDet = null;
            int xBC_SEQ = 0;
            int xScenID = 0;
            int Peracc;
            clsDataItem oItem;

            int retv = 0;

            sCommand = "SELECT TARGET_ID, TARGET_NAME, TARGET_DESC FROM EPGP_MODEL_TARGETS WHERE CB_ID = " + clscd.m_CB_ID.ToString() + " ORDER BY TARGET_NAME";

            string targets = "";

            oCommand = new SqlCommand(sCommand, _sqlConnection);
            reader = oCommand.ExecuteReader();

            clscd.m_targets = new Dictionary<int, clsDataItem>();
            clscd.m_targetdata = new Dictionary<string, clsDetailRowData>();

            while (reader.Read())
            {

                oItem = new clsDataItem();

                oItem.UID = DBAccess.ReadIntValue(reader["TARGET_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["TARGET_NAME"]);
                oItem.Desc = DBAccess.ReadStringValue(reader["TARGET_DESC"]);
                if (targets == "")
                    targets = oItem.UID.ToString();
                else
                    targets += "," + oItem.UID.ToString();

                clscd.m_targets.Add(oItem.UID, oItem);
                oItem.ID = clscd.m_targets.Count;
            }
            reader.Close();
            reader = null;

            if (targets == "")
                return 0;

            sCommand = "SELECT * FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID IN (" + targets + ") ORDER BY TARGET_ID";

            oCommand = new SqlCommand(sCommand, _sqlConnection);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                Det = new clsDetailRowData(clscd.m_max_period);

                Det.CB_ID = clscd.m_CB_ID;
                Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                Det.BC_SEQ = DBAccess.ReadIntValue(reader["TARGET_UID"]);

                Det.Scenario_ID = DBAccess.ReadIntValue(reader["TARGET_ID"]);

                if (clscd.m_targets.TryGetValue(Det.Scenario_ID, out oItem) == true)
                    Det.CT_ind = oItem.ID;
                else
                    Det.CT_ind = -1;

                for (int i = 1; i <= 5; i++)
                {
                    Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                    Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                }

                sCommand = "K" + Det.BC_SEQ.ToString() + " " + Det.Scenario_ID.ToString();

                if (clscd.m_targetdata.TryGetValue(sCommand, out TryDet) == false)
                    clscd.m_targetdata.Add(sCommand, Det);

            }
            reader.Close();
            reader = null;



            sCommand = "SELECT * FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID IN (" + targets + ") ORDER BY TARGET_ID,TARGET_UID";

            oCommand = new SqlCommand(sCommand, _sqlConnection);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {

                xBC_SEQ = DBAccess.ReadIntValue(reader["TARGET_UID"]);
                xScenID = DBAccess.ReadIntValue(reader["TARGET_ID"]);

                sCommand = "K" + xBC_SEQ.ToString() + " " + xScenID.ToString();

                if (clscd.m_targetdata.TryGetValue(sCommand, out Det))
                {

                    Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                    Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                    Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                }
            }
            reader.Close();
            reader = null;

            return retv;
        }

        public void DeleteTarget(int iTarget)
        {
            string sCommand = "";

            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open(); 
                
                sCommand = "Delete FROM EPGP_MODEL_TARGETS  Where TARGET_ID = " + iTarget.ToString();
                SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.ExecuteNonQuery();

                sCommand = "Delete FROM EPGP_MODEL_TARGET_DETAILS  Where TARGET_ID = " + iTarget.ToString();
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.ExecuteNonQuery();

                sCommand = "Delete FROM EPGP_MODEL_TARGET_VALUES  Where TARGET_ID = " + iTarget.ToString();
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
            }


        }

        public void SaveTargetData(string sXML, int CB_ID, out int targetID, out string sTargetName, out bool bNewTarget)
        {

            string sCommand = "";
            SqlDataReader reader = null;
            SqlCommand oCommand = null;
            SqlCommand cmd;

            targetID = 0;
            sTargetName = "";
            bNewTarget = false;

            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();



                CStruct xRoot = new CStruct();

                if (xRoot.LoadXML(sXML) == false)
                {
                    return;
                }

                string sNewName = xRoot.GetStringAttr("Name");
                string sDesc = xRoot.GetStringAttr("Desc");
                int tID = xRoot.GetIntAttr("ID");

                if (sNewName != "" && tID == 0)
                {

                    int nameCount = 0;
                    int LocalTarget = 0;

                    sCommand = "SELECT COUNT(TARGET_NAME) AS TARGET_COUNT FROM EPGP_MODEL_TARGETS WHERE TARGET_NAME = " + DBAccess.PrepareText(sNewName);

                    oCommand = new SqlCommand(sCommand, _sqlConnection);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        nameCount = DBAccess.ReadIntValue(reader["TARGET_COUNT"]);
                    }
                    reader.Close();
                    reader = null;

                    if (nameCount != 0)
                    {
                        targetID = -1;
                        return;
                    }

                    sCommand = "SELECT MAX(TARGET_ID) AS TARGET_ID FROM EPGP_MODEL_TARGETS";

                    oCommand = new SqlCommand(sCommand, _sqlConnection);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        targetID = DBAccess.ReadIntValue(reader["TARGET_ID"]);
                    }
                    reader.Close();
                    reader = null;

                    ++targetID;
                    tID = targetID;

                    sCommand = "INSERT into EPGP_MODEL_TARGETS (CB_ID, TARGET_ID,WRES_ID,TARGET_NAME,TARGET_DESC) VALUES(" +
                       CB_ID.ToString() + ", " + targetID.ToString() + "," + LocalTarget.ToString() + "," + DBAccess.PrepareText(sNewName) + "," + DBAccess.PrepareText(sDesc) + ")";


                    cmd = new SqlCommand(sCommand, _sqlConnection);
                    cmd.ExecuteNonQuery();
                    //m_oDataAccess = null;

                    sTargetName = sNewName;
                    bNewTarget = true;
                }
                else
                    targetID = tID;



                sCommand = "DELETE FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID = " + tID.ToString();
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.ExecuteNonQuery();

                sCommand = "DELETE FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID = " + tID.ToString();
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.ExecuteNonQuery();

                sCommand = "insert into EPGP_MODEL_TARGET_DETAILS (TARGET_ID,CT_ID, BC_UID, TARGET_UID, OC_01,OC_02, OC_03, OC_04, OC_05,TEXT_01,TEXT_02, TEXT_03, TEXT_04, TEXT_05) " +
                            "VALUES(" + targetID.ToString() + ",@CT_ID, @BC_UID, @TARGET_UID, @OC_01,@OC_02, @OC_03, @OC_04, @OC_05,@TEXT_01,@TEXT_02, @TEXT_03, @TEXT_04, @TEXT_05)";

                SqlCommand oCmdCF = new SqlCommand(sCommand, _sqlConnection);

                SqlParameter ct_id = oCmdCF.Parameters.Add("@CT_ID", SqlDbType.Int);
                SqlParameter bc_uid = oCmdCF.Parameters.Add("@BC_UID", SqlDbType.Int);
                SqlParameter tar_uid = oCmdCF.Parameters.Add("@TARGET_UID", SqlDbType.Int);

                SqlParameter oc1_id = oCmdCF.Parameters.Add("@OC_01", SqlDbType.Int);
                SqlParameter oc2_id = oCmdCF.Parameters.Add("@OC_02", SqlDbType.Int);
                SqlParameter oc3_id = oCmdCF.Parameters.Add("@OC_03", SqlDbType.Int);
                SqlParameter oc4_id = oCmdCF.Parameters.Add("@OC_04", SqlDbType.Int);
                SqlParameter oc5_id = oCmdCF.Parameters.Add("@OC_05", SqlDbType.Int);

                SqlParameter tx1_id = oCmdCF.Parameters.Add("@TEXT_01", SqlDbType.VarChar, 255);
                SqlParameter tx2_id = oCmdCF.Parameters.Add("@TEXT_02", SqlDbType.VarChar, 255);
                SqlParameter tx3_id = oCmdCF.Parameters.Add("@TEXT_03", SqlDbType.VarChar, 255);
                SqlParameter tx4_id = oCmdCF.Parameters.Add("@TEXT_04", SqlDbType.VarChar, 255);
                SqlParameter tx5_id = oCmdCF.Parameters.Add("@TEXT_05", SqlDbType.VarChar, 255);

                
                List<CStruct> trows = xRoot.GetList("TROW");

                int i = 0;

               foreach (CStruct orow in trows)
               {
                   i = i + 1; 
                   ct_id.Value = orow.GetIntAttr("CT_ID");
                    tar_uid.Value = i;
                    bc_uid.Value = orow.GetIntAttr("BC_UID");

                    oc1_id.Value = orow.GetIntAttr("OC1");
                    oc2_id.Value = orow.GetIntAttr("OC2");
                    oc3_id.Value = orow.GetIntAttr("OC3");
                    oc4_id.Value = orow.GetIntAttr("OC4");
                    oc5_id.Value = orow.GetIntAttr("OC5");

                    tx1_id.Value = orow.GetStringAttr("TX1");
                    tx2_id.Value = orow.GetStringAttr("TX2");
                    tx3_id.Value = orow.GetStringAttr("TX3");
                    tx4_id.Value = orow.GetStringAttr("TX4");
                    tx5_id.Value = orow.GetStringAttr("TX5");

                    oCmdCF.ExecuteNonQuery();
                }

                sCommand = "insert into EPGP_MODEL_TARGET_VALUES (TARGET_ID,TARGET_UID, BD_PERIOD, BD_COST, BD_VALUE) " +
                               "VALUES(" + targetID.ToString() + ",@TARGET_UID, @BD_PERIOD, @BD_COST, @BD_VALUE)";

                SqlCommand oCmdVal = new SqlCommand(sCommand, _sqlConnection);
                SqlParameter val_tar_uid = oCmdVal.Parameters.Add("@TARGET_UID", SqlDbType.Int);

                SqlParameter val_per_id = oCmdVal.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                SqlParameter val_cost_id = oCmdVal.Parameters.Add("@BD_COST", SqlDbType.Decimal);
                SqlParameter val_val_id = oCmdVal.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
                val_cost_id.Precision = 25;
                val_cost_id.Scale = 6;
                val_val_id.Precision = 25;
                val_val_id.Scale = 6;

                i = 0;

                foreach (CStruct orow in trows)
                {

                    List<CStruct> pvals = orow.GetList("Per");
                    i = i + 1;

  
                    foreach (CStruct oper in pvals)
                    {
                        val_tar_uid.Value = i;
                        val_per_id.Value = oper.GetIntAttr("ID");
                        val_cost_id.Value = oper.GetDoubleAttr("Cost",0);
                        val_val_id.Value = oper.GetDoubleAttr("Val", 0);
                        oCmdVal.ExecuteNonQuery();
                    }
                }


            }

            catch (Exception ex)
            {
            }


        }

        public clsCostData ReloadTargets(int CB_ID, int max_period)
        {

            
            clsCostData cds = new clsCostData();


            try
            {
                cds.m_CB_ID = CB_ID;
                cds.m_max_period = max_period;
                LoadTargets(cds);
            }

            catch (Exception ex) { }
            return cds;

        }


    }



}

