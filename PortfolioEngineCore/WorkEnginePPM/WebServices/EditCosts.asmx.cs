using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Xml;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    /// <summary>
    /// Summary description for EditCosts
    /// </summary>
    [WebService(Namespace = "WorkEnginePPM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EditCosts : System.Web.Services.WebService
    {

        public class PI
        {
            public int Id;
            public string Name;
        }
        public class View
        {
            public int Uid;
            public string Name;
        }
        public class LookupItem
        {
            public int Uid;
            public string Name;
            public int Level;
        }

        /// <summary>
        /// Gets the costtype ids and names associated with a view
        /// </summary>
        /// <param name="Context"></param>
        /// <returns>list of Costypes</returns>
        [WebMethod(EnableSession = true)]
        public string CheckStatus(string Context)
        {
            string sStatus = ""; 
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(this.Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess)
                {
                    sStatus = "Open DB Error=" + dba.FormatErrorText() + "; STAGE=" + sStage;
                }
                if (dbaGeneral.CheckUserGlobalPermission(dba, GlobalPermissionsEnum.gpEditCostType) == false)
                {
                    sStatus = "You do not have permission to view cost plan";
                }
                dba.Close();
            }
            else
                sStatus = "AuthenticateUserAndProduct failed STAGE=" + sStage;
            return sStatus;
        }

        /// <summary>
        /// Gets the list of PIs
        /// </summary>
        /// <returns>list of PIs</returns>
        [WebMethod(EnableSession = true)]
        public List<PI> GetPIList()
        {
            List<PI> pis = new List<PI>();
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(this.Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                //DataTable dt;
                //if (dbaEditCosts.SelectPIs(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                string sPIs;
                if (dbaGeneral.GetPIList(dba, out sPIs) == true)
                {
                    CStruct xPIs = new CStruct();
                    if (xPIs.LoadXML(sPIs) == true)
                    {
                        List<CStruct> lstPIs = xPIs.GetList("PI");
                        foreach (CStruct xPI in lstPIs)
                        {
                            PI pi = new PI();
                            pi.Id = xPI.GetIntAttr("id");
                            pi.Name = xPI.GetStringAttr("name");
                            pis.Add(pi);
                        }
                    }
                }
Status_Error:
                dba.Close();
            }
            return pis;
        }

        /// <summary>
        /// Gets the list of PI Views
        /// </summary>
        /// <returns>list of PI Views</returns>
        [WebMethod(EnableSession = true)]
        public List<View> GetViewList()
        {
            List<View> views = new List<View>();
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                DataTable dt;
                if (dbaEditCosts.SelectViews(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                foreach (DataRow row in dt.Rows)
                {
                    View view = new View();
                    view.Uid = DBAccess.ReadIntValue(row["VIEW_UID"]);
                    view.Name = DBAccess.ReadStringValue(row["VIEW_NAME"]);
                    views.Add(view);
                }
Status_Error:
                dba.Close();
            }
            return views;
        }

        /// <summary>
        /// Gets the costtype ids and names associated with a view
        /// </summary>
        /// <param name="Viewuid"></param>
        /// <returns>list of Costypes</returns>
        [WebMethod(EnableSession = true)]
        public List<CostType> GetCostTypes(string Viewuid)
        {
            int nViewUID;
            List<CostType> costTypes = new List<CostType>();
            Int32.TryParse(Viewuid, out nViewUID);

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

                List<CostType> costTypesTemp = new List<CostType>();

                if (nViewUID > 0)
                {
                    DataTable dt;
                    if (dbaEditCosts.SelectCostTypesByView(dba, nViewUID, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        CostType costType = new CostType();
                        costType.Id =  DBAccess.ReadIntValue(row["CT_ID"]);
                        costType.Name = DBAccess.ReadStringValue(row["CT_NAME"]);
                        costType.EditMode = DBAccess.ReadIntValue(row["CT_EDIT_MODE"]);
                        costType.InitialLevel = DBAccess.ReadIntValue(row["INITIAL_LEVEL"]);
                        costType.IncludeNamedRates = DBAccess.ReadBoolValue(row["CT_ALLOW_NAMED_RATES"]);
                        costTypesTemp.Add(costType);
                    }

                    // check if any CT security. If none at all then add otherwise check read and edit
                    foreach (CostType costType2 in costTypesTemp)
                    {
                        if (dbaEditCosts.CheckCostTypeSecurity(dba, costType2.Id, ref costType2.EditMode) == true)
                            costTypes.Add(costType2);
                    }
                }
            Status_Error:
                dba.Close();
            }
            return costTypes;
        }

        /// <summary>
        /// Get the named rates
        /// </summary>
        /// <returns>list of Costypes</returns>
        [WebMethod(EnableSession = true)]
        public List<NamedRateValue> GetNamedRates()
        {
            List<NamedRateValue> namedRates = new List<NamedRateValue>();

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

                {
                    DataTable dt;
                    if (dbaEditCosts.SelectNamedRateValues(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                    foreach (DataRow row in dt.Rows)
                    {
                        NamedRateValue namedRate = new NamedRateValue();
                        namedRate.Id = DBAccess.ReadIntValue(row["RT_UID"]);
                        namedRate.EffectiveDate = DBAccess.ReadDateValue(row["RT_EFFECTIVE_DATE"]);
                        namedRate.Rate = DBAccess.ReadDoubleValue(row["RT_RATE"]);
                        namedRates.Add(namedRate);
                    }
                }
Status_Error:
                dba.Close();
            }
            return namedRates;
        }

        /// <summary>
        /// Gets periods associated with a view
        /// </summary>
        /// <param name="Viewuid"></param>
        /// <returns>list of periods</returns>
        [WebMethod(EnableSession = true)]
        public List<Period> GetPeriods(string Viewuid)
        {
            int nViewUID;
            List<Period> periods = new List<Period>();
            Int32.TryParse(Viewuid, out nViewUID);

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

                if (nViewUID > 0)
                {
                    int nCalendarID;
                    int nFirstPeriod;
                    int nLastPeriod;
                    if (dbaEditCosts.SelectViewCalendarInfo(dba, nViewUID, out nCalendarID, out nFirstPeriod, out nLastPeriod) != StatusEnum.rsSuccess) goto Exit_Function;

                    if (nCalendarID >= 0)
                    {
                        DataTable dt;
                        if (dbaEditCosts.SelectCalendarPeriods(dba, nCalendarID, out dt) != StatusEnum.rsSuccess) goto Exit_Function;

                        Period period = null;
                        foreach (DataRow row in dt.Rows)
                        {
                            bool bIsNull;
                            period = new Period();
                            period.Id = DBAccess.ReadIntValue(row["PRD_ID"]);
                            period.Name = DBAccess.ReadStringValue(row["PRD_NAME"]);
                            period.StartDate = DBAccess.ReadDateValue(row["PRD_START_DATE"], out bIsNull);
                            period.FinishDate = DBAccess.ReadDateValue(row["PRD_FINISH_DATE"], out bIsNull);

                            if (nFirstPeriod == Int32.MinValue)
                                nFirstPeriod = period.Id;

                            if (period.Id >= nFirstPeriod && period.Id <= nLastPeriod)
                                periods.Add(period);
                        }
                        if (period != null && nLastPeriod == Int32.MaxValue)
                            nLastPeriod = period.Id;
                    }
                }
Exit_Function:
                dba.Close();
            }
            return periods;
        }

        /// <summary>
        /// Checks in the PIs in the list which are checked out to the user
        /// </summary>
        /// <param name="Projectid"></param>
        /// <param name="Wepid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string CheckInPI(int Projectid, string Wepid)
        {
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                DBAccess dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;
                if (Projectid == 0 && Wepid != "")
                {
                    if (dbaEditCosts.SelectProjectIDByExtUID(dba, Wepid, out Projectid) != StatusEnum.rsSuccess)
                        return "";
                }

                if (Projectid > 0)
                {
                    int nRowsAffected;
                    if (dbaEditCosts.CheckinPI(dba, Projectid, out nRowsAffected) != StatusEnum.rsSuccess)
                        return "";
                }
Exit_Function:
                dba.Close();
            }

            return "";
        }

        private bool ConvertDateToPeriod(List<InternalPeriod> clnPeriods, DateTime dt, out int lPeriod)
        {
            lPeriod = 0;
            foreach (InternalPeriod oPeriod in clnPeriods)
            {
                if (dt >= oPeriod.StartDate && dt <= oPeriod.FinishDate)
                {
                    lPeriod = oPeriod.Id;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Builds xml to drive the layout of the CostType grid
        /// </summary>
        /// <param name="Projectid"></param>
        /// <param name="Costtypeid"></param>
        /// <param name="Viewuid"></param>
        /// <param name="Ftemode"></param>
        /// <param name="Wepid"></param>
        /// <param name="Trycheckout"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string GetEditCostsLayout(int Projectid, int Costtypeid, string Viewuid, int Ftemode, string Wepid, int Trycheckout)
        {
            int nViewUID;
            Int32.TryParse(Viewuid, out nViewUID);
            DBAccess dba;
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

                CostType costType;
                if (GetCostType(dba, Costtypeid, out costType) != StatusEnum.rsSuccess) goto Status_Error;

                dbaEditCosts.CheckCostTypeSecurity(dba, costType.Id, ref costType.EditMode);

                //DateTime dtStatusDate;
                //{
                //    // read in the statusdate - convert it to a periodID
                //    DataTable dt;
                //    if (dbaGeneral.SelectAdmin(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                //    if (dt.Rows.Count != 1)
                //    {
                //        dba.Status = (StatusEnum)99999;
                //        dba.StatusText = "Invalid Admin row count : " + dt.Rows.Count.ToString("0");
                //        goto Status_Error;
                //    }

                //    dtStatusDate = DBAccess.ReadDateValue(dt.Rows[0]["ADM_STATUS_DATE"]);
                //}

                int nCalendarID;
                int nFirstPeriod;
                int nLastPeriod;
                if (dbaEditCosts.SelectViewCalendarInfo(dba, nViewUID, out nCalendarID, out nFirstPeriod, out nLastPeriod) != StatusEnum.rsSuccess) goto Status_Error;

                List<InternalPeriod> periods = new List<InternalPeriod>();
                if (nCalendarID >= 0)
                {
                    DataTable dt;
                    if (dbaEditCosts.SelectCalendarPeriods(dba, nCalendarID, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                    InternalPeriod period = null;
                    DateTime dtNow = DateTime.Now.Date;
                    foreach (DataRow row in dt.Rows)
                    {
                        bool bIsNull;
                        period = new InternalPeriod();
                        period.Id = DBAccess.ReadIntValue(row["PRD_ID"]);
                        period.Name = DBAccess.ReadStringValue(row["PRD_NAME"]);
                        period.StartDate = DBAccess.ReadDateValue(row["PRD_START_DATE"], out bIsNull);
                        period.FinishDate = DBAccess.ReadDateValue(row["PRD_FINISH_DATE"], out bIsNull);

                        if (nFirstPeriod == Int32.MinValue)
                            nFirstPeriod = period.Id;
                        // NB: Using old Status period flag for current period marker
                        if (period.StartDate <= dtNow && period.FinishDate >= dtNow)
                            period.IsStatusPeriod = true;

                        if (period.Id >= nFirstPeriod && period.Id <= nLastPeriod)
                        {
                            //if (dtStatusDate >= period.StartDate && dtStatusDate <= period.FinishDate)
                            //    period.IsStatusPeriod = true;
                            periods.Add(period);
                        }
                    }
                    if (period != null && nLastPeriod == Int32.MaxValue)
                        nLastPeriod = period.Id;
                }

                if (Projectid == 0 && Wepid != "")
                {
                    if (dbaEditCosts.SelectProjectIDByExtUID(dba, Wepid, out Projectid) != StatusEnum.rsSuccess) goto Status_Error;
                }
                if (Projectid == 0)
                {
                    dba.Status = StatusEnum.rsProjectNotFound;
                    dba.StatusText = "Project not found for WEPID " + Wepid;
                    goto Status_Error;
                }

                DateTime dtStart;
                DateTime dtFinish;
                if (dbaEditCosts.GetProjectInfo(dba, Projectid, out dtStart, out dtFinish) != StatusEnum.rsSuccess) goto Status_Error;

                int lStartPeriod = 0;
                int lFinishPeriod = 0;
                ConvertDateToPeriod(periods, dtStart, out lStartPeriod);
                ConvertDateToPeriod(periods, dtFinish, out lFinishPeriod);


                string sCheckedoutDetails = "";

                //Cost Types and variations	                          Edit Mode	 Editable	Calculate Cost	Comes From
                // Display Only	                                        0	        No	        No	        COST_VALUES
                // Editable – Input Calendar or No Input Calendar (-1) 	1	        Yes	        Yes	        COST_DETAILS
                // Editable – Calendar different than  Input Calendar	1	        No	        No	        COST_DETAILS
                // Display Only w/Details	                            101	        No	        No	        COST_DETAILS
                // Calculated (Cumulative?)	                            3(30)	    No	        No	        COST_VALUES
                // Timesheet Actuals (status Date?)	                    4(40)	    No	        No	        COST_VALUES
                // WE Timesheet Actuals	                                41	        No	        No	        COST_VALUES
                // Project Schedule (Status Date?)	                    5(50)	    No	        No	        COST_VALUES
                // Work Item (Status Date?)	                            6(60)	    No	        No	        COST_VALUES
                // Resource Plans (Revenue + Status Date?)	            9(90,91,92)	No	        No	        COST_VALUES

                EditCostsLayout oGrid = new EditCostsLayout();
                switch (costType.EditMode)
                {
                    case 1:     // editable
                        bool bEditable = !(costType.CalendarId != nCalendarID && costType.CalendarId != -1);
                        if (Trycheckout != 0 && bEditable == true)
                        {
                            bool bCheckedOut;
                            if (CheckOutPI(dba, Projectid, Wepid, out bCheckedOut, out sCheckedoutDetails) != StatusEnum.rsSuccess) goto Status_Error;
                        }
                        oGrid.InitializeGridLayout(costType.Id, Ftemode, bEditable, sCheckedoutDetails, lStartPeriod, lFinishPeriod);
                        break;
                    case 101:     // non-editable with details
                        oGrid.InitializeGridLayout(costType.Id, Ftemode, false, sCheckedoutDetails, lStartPeriod, lFinishPeriod);
                        break;
                    case 3:     // calculated
                    case 30:    // cumulative calculated
                        // read in the calculations
                        List<CostTypeOperation> costTypeOperations;
                        if (GetCostTypeOperations(dba, costType.Id, out costTypeOperations) != StatusEnum.rsSuccess) goto Status_Error;

                        if (costTypeOperations.Count < 1)
                        {
                            dba.Status = (StatusEnum)99838;
                            dba.StatusText = "No operations found for Calculated Cost type : " + costType.Id.ToString("0");
                            goto Status_Error;
                        }

                        if (GetCostType(dba, costTypeOperations[0].Id, out costType) != StatusEnum.rsSuccess) goto Status_Error;
                        oGrid.InitializeGridLayout(costType.Id, Ftemode, false, "", lStartPeriod, lFinishPeriod);
                        break;
                    default:
                        oGrid.InitializeGridLayout(costType.Id, Ftemode, false, "", lStartPeriod, lFinishPeriod);
                        break;
                }
                if (BuildLayout(dba, oGrid, costType, periods) != StatusEnum.rsSuccess) goto Status_Error;
                oGrid.FinalizeGridLayout();
                string sXML = oGrid.GetString();
                dba.Close();
                return sXML;
            }
            else
                return HandleError("GetEditCostsLayout", "User Authentication Failed. Stage=" + sStage);
Status_Error:
            dba.Close();
            return HandleError("GetEditCostsLayout", dba.FormatErrorText());
        }

        private StatusEnum CheckOutPI(DBAccess dba, int Projectid, string Wepid, out bool bCheckedOut, out string sCheckedoutDetails)
        {
            bCheckedOut = false;
            sCheckedoutDetails = "";

            if (Projectid > 0)
            {
                int nRowsAffected;
                if (dbaEditCosts.CheckoutPI(dba, Projectid, out nRowsAffected) != StatusEnum.rsSuccess)
                    return dba.Status;
                bCheckedOut = (nRowsAffected == 1) ? true : false;
                if (bCheckedOut == false)
                {
                    DataTable dt;
                    if (dbaEditCosts.SelectPIDetails(dba, Projectid, out dt) != StatusEnum.rsSuccess)
                        return dba.Status;

                    if (dt.Rows.Count == 1)
                    {

                        DataRow row = dt.Rows[0];

                        if (DBAccess.ReadIntValue(row["PROJECT_CHECKEDOUT"]) != 0)
                        {
                            DateTime dateTime = DBAccess.ReadDateValue(row["PROJECT_CHECKEDOUT_DATE"]);
                            sCheckedoutDetails = "Project checked out by " + DBAccess.ReadStringValue(row["RES_NAME"]) + " on " + dateTime.ToString()
                                + "\n\nCost information is opened read-only";
                        }
                    }
                }
            }
            return dba.Status;
        }

        private StatusEnum GetCostType(DBAccess dba, int Costtypeid, out CostType costType)
        {
            costType = new CostType();
            DataTable dt;
            if (dbaEditCosts.SelectCostType(dba, Costtypeid, out dt) != StatusEnum.rsSuccess)
                return dba.Status;

            if (dt.Rows.Count != 1)
            {
                dba.Status = (StatusEnum)99839;
                dba.StatusText = "Cost type not found : " + Costtypeid.ToString("0");
                return dba.Status;
            }

            DataRow row = dt.Rows[0];
            costType.Id = DBAccess.ReadIntValue(row["CT_ID"]);
            costType.Name = DBAccess.ReadStringValue(row["CT_NAME"]);
            costType.CalendarId = DBAccess.ReadIntValue(row["CT_CB_ID"]);
            costType.EditMode = DBAccess.ReadIntValue(row["CT_EDIT_MODE"]);
            costType.IncludeNamedRates = DBAccess.ReadBoolValue(row["CT_ALLOW_NAMED_RATES"]);
            costType.InitialLevel = DBAccess.ReadIntValue(row["INITIAL_LEVEL"]);
            return dba.Status;
        }

        private StatusEnum GetCostTypeOperations(DBAccess dba, int Costtypeid, out List<CostTypeOperation> costTypeOperations)
        {
            costTypeOperations = new List<CostTypeOperation>();
            DataTable dt;
            if (dbaEditCosts.SelectCostTypeOperations(dba, Costtypeid, out dt) != StatusEnum.rsSuccess)
                return dba.Status;

            foreach (DataRow row in dt.Rows)
            {
                CostTypeOperation costTypeOperation = new CostTypeOperation();
                costTypeOperation.Id = DBAccess.ReadIntValue(row["CL_CT_ID"]);
                costTypeOperation.Operation = DBAccess.ReadIntValue(row["CL_OP"]);
                costTypeOperations.Add(costTypeOperation);
            }

            return dba.Status;
        }

        private StatusEnum GetNamedRateLookup(DBAccess dba, out string jsonRateLookup)
        {
            List<LookupItem> namedRateItems = new List<LookupItem>();
            jsonRateLookup = "";
            DataTable dt;
            if (dbaEditCosts.SelectNamedRateItems(dba, out dt) != StatusEnum.rsSuccess)
                return dba.Status;

            foreach (DataRow row in dt.Rows)
            {
                LookupItem namedRateItem = new LookupItem();
                namedRateItem.Uid = DBAccess.ReadIntValue(row["RT_UID"]);
                namedRateItem.Name = DBAccess.ReadStringValue(row["RT_NAME"]);
                namedRateItem.Level = DBAccess.ReadIntValue(row["RT_LEVEL"]);
                namedRateItems.Add(namedRateItem);
            }

            // add in lookup info in json format
            LookupItem[] arrNamedRateItems = namedRateItems.ToArray();
            jsonRateLookup = "{Items:[" + BuildJSONLookup(arrNamedRateItems, 0) + "]}";
            return dba.Status;
        }

        private StatusEnum GetCostCustomFields(DBAccess dba, int costTypeId, bool bIncludeLookup, out List<CostCustomField> costCustomFields)
        {
            costCustomFields = new List<CostCustomField>();
            {
                DataTable dt;
                if (dbaEditCosts.SelectCostCustomFields(dba, costTypeId, out dt) != StatusEnum.rsSuccess)
                    return dba.Status;


                foreach (DataRow row in dt.Rows)
                {
                    CostCustomField costCustomField = new CostCustomField();
                    costCustomField.Id = DBAccess.ReadIntValue(row["CF_ID"]);
                    costCustomField.CostTypeId = DBAccess.ReadIntValue(row["CT_ID"]);
                    costCustomField.FieldId = DBAccess.ReadIntValue(row["CF_FIELD_ID"]);
                    costCustomField.Editable = DBAccess.ReadBoolValue(row["CF_EDITABLE"]);
                    costCustomField.Visible = DBAccess.ReadBoolValue(row["CF_VISIBLE"]);
                    costCustomField.Identity = DBAccess.ReadBoolValue(row["CF_IDENTITY"]);
                    costCustomField.Required = DBAccess.ReadBoolValue(row["CF_REQUIRED"]);
                    costCustomField.Frozen = DBAccess.ReadBoolValue(row["CF_FROZEN"]);
                    costCustomField.Name = DBAccess.ReadStringValue(row["FA_NAME"]);
                    costCustomField.LookupOnly = DBAccess.ReadBoolValue(row["FA_LOOKUPONLY"]);
                    costCustomField.LookupUid = DBAccess.ReadIntValue(row["FA_LOOKUP_UID"]);
                    costCustomField.LeafOnly = DBAccess.ReadBoolValue(row["FA_LEAFONLY"]);
                    costCustomField.UseFullName = DBAccess.ReadBoolValue(row["FA_USEFULLNAME"]);
                    costCustomFields.Add(costCustomField);
                }
            }

            if (bIncludeLookup)
            {
                // add in lookup info in json format
                foreach (CostCustomField costCustomField in costCustomFields)
                {
                    if (costCustomField.LookupUid > 0)
                    {
                        List<LookupItem> lookupItems = new List<LookupItem>();
                        DataTable dt;
                        if (dbaEditCosts.SelectLookup(dba, costCustomField.LookupUid, out dt) != StatusEnum.rsSuccess)
                            return dba.Status;

                        foreach (DataRow row in dt.Rows)
                        {
                            LookupItem lookupItem = new LookupItem();
                            lookupItem.Uid = DBAccess.ReadIntValue(row["LV_UID"]);
                            if (costCustomField.UseFullName == true)
                            {
                                lookupItem.Name = DBAccess.ReadStringValue(row["LV_FULLVALUE"]);
                                lookupItem.Level = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                                //lookupItem.Level = 1;
                            }
                            else
                            {
                                lookupItem.Name = DBAccess.ReadStringValue(row["LV_VALUE"]);
                                lookupItem.Level = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                            }
                            lookupItems.Add(lookupItem);
                        }

                        // add in lookup info in json format
                        LookupItem[] arrLookupItems = lookupItems.ToArray();
                        costCustomField.jsonLookup = "{Items:[" + BuildJSONLookup(arrLookupItems, 0) + "]}";
                    }
                }
            }
            return dba.Status;
        }

        private StatusEnum BuildLayout(DBAccess dba, EditCostsLayout oGrid, CostType costType, List<InternalPeriod> periods)
        {
            string jsonRateLookup;
            if (GetNamedRateLookup(dba, out jsonRateLookup) != StatusEnum.rsSuccess) goto Status_Error;

            List<CostCustomField> costCustomFields;
            if (GetCostCustomFields(dba, costType.Id, true, out costCustomFields) != StatusEnum.rsSuccess) goto Status_Error;

            if (costType.IncludeNamedRates)
            {
                oGrid.AddNamedRateColumn(jsonRateLookup);
            }

            foreach (CostCustomField costCustomField in costCustomFields)
            {
                oGrid.AddCustomFieldColumn(costCustomField);
            }

            foreach (InternalPeriod period in periods)
            {
                oGrid.AddPeriodColumn(period);
            }
            return StatusEnum.rsSuccess;
Status_Error:
            return dba.Status;
        }

        private string BuildJSONLookup(LookupItem[] lookupItems, int nIndex)
        {
            string sJSON = "";
            int nItems = lookupItems.Length;
            for (int i=nIndex; i<nItems; i++)
            {
                if (lookupItems[nIndex].Level == lookupItems[i].Level)
                {
                    if (sJSON != "")
                        sJSON += ",";
                    sJSON += "{Name:'" + lookupItems[i].Uid.ToString("0") + "',Text:'" + lookupItems[i].Name + "',Value:'" + lookupItems[i].Uid.ToString("0") + "_" + lookupItems[i].Name + "'}";
                    if (i + 1 < nItems)
                    {
                        if (lookupItems[i + 1].Level > lookupItems[i].Level)
                        {
                            sJSON += ",{Name:'Level" + lookupItems[i].Uid.ToString("0") + "',Expanded:-1,Level:1,Items:[" + BuildJSONLookup(lookupItems, i + 1) + "]}";
                            //jsonLookup = "{Items:[{Name:'Name1',Text:'Text1',Value:'Value1'},{Name:'Level2',Expanded:-1,Level:1,Items:[{Name:'Name1.1',Text:'Text1.1',Value:'Value1.1'},{Name:'Name1.2',Text:'Text1.2',Value:'Value1.2'}]}]}";
                        }
                    }
                }
                else if (lookupItems[nIndex].Level > lookupItems[i].Level)
                    return sJSON;
                //else if (nIndex != 0)
                //    return sJSON;
            }
            return sJSON; 
        }

        /// <summary>
        /// Builds XML to populate the CostType grid
        /// </summary>
        /// <param name="Projectid"></param>
        /// <param name="Costtypeid"></param>
        /// <param name="Viewuid"></param>
        /// <param name="Ftemode"></param>
        /// <param name="Wepid"></param>
        /// <param name="Trycheckout"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetEditCostsData(int Projectid, int Costtypeid, string Viewuid, int Ftemode, string Wepid, int Trycheckout)
        {
            int nProjectID = Projectid;
            int nCostTypeID = Costtypeid;
            int nViewUID;
            Int32.TryParse(Viewuid, out nViewUID);
            DBAccess dba = null;

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                string sXML = "";
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                dba = da.dba;

                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

                if (nProjectID == 0 && Wepid != "")
                {
                    if (dbaEditCosts.SelectProjectIDByExtUID(dba, Wepid, out nProjectID) != StatusEnum.rsSuccess) goto Status_Error;
                }

                if (nProjectID == 0)
                {
                    return HandleError("GetEditCostsData", "Invalid Project ID:" + nProjectID.ToString("0") + "; wepid:" + Wepid + ";");
                }
                
                CostType costType;
                if (GetCostType(dba, Costtypeid, out costType) != StatusEnum.rsSuccess) goto Status_Error;

                // get the calendar from the view
                int nCalendarID;
                int nFirstPeriod;
                int nLastPeriod;
                if (dbaEditCosts.SelectViewCalendarInfo(dba, nViewUID, out nCalendarID, out nFirstPeriod, out nLastPeriod) != StatusEnum.rsSuccess) goto Status_Error;

                //Cost Types and variations	                          Edit Mode	 Editable	Calculate Cost	Comes From
                // Display Only	                                        0	        No	        No	        COST_VALUES
                // Editable – Input Calendar or No Input Calendar    	1	        Yes	        Yes	        COST_DETAILS
                // Editable – Calendar different than  Input Calendar	1	        No	        No	        COST_DETAILS
                // Display Only w/Details	                            101	        No	        No	        COST_DETAILS
                // Calculated (Cumulative?)	                            3(30)	    No	        No	        COST_VALUES
                // Timesheet Actuals (status Date?)	                    4(40)	    No	        No	        COST_VALUES
                // WE Timesheet Actuals	                                41	        No	        No	        COST_VALUES
                // Project Schedule (Status Date?)	                    5(50)	    No	        No	        COST_VALUES
                // Work Item (Status Date?)	                            6(60)	    No	        No	        COST_VALUES
                // Resource Plans (Revenue + Status Date?)	            9(90,91,92)	No	        No	        COST_VALUES
                List<CostCategory> costCategories;
                List<CostCustomField> costCustomFields = null;
                switch (costType.EditMode)
                {
                    case 1:     // editable
                    case 101:   // non-editable w/details

                        if (GetCostCustomFields(dba, nCostTypeID, true, out costCustomFields) != StatusEnum.rsSuccess) goto Status_Error;
                        if (BuildCostDetailsData(dba, nCalendarID, nCostTypeID, nProjectID, Ftemode, out costCategories) != StatusEnum.rsSuccess) goto Status_Error;
                        break;
                    case 3:     // calculated
                    case 30:    // cumulative calculated
                        if (BuildCalculatedData(dba, nCalendarID, nCostTypeID, nProjectID, Ftemode, out costCategories) != StatusEnum.rsSuccess) goto Status_Error;
                        break;
                    default:
                        if (BuildCostValuesData(dba, nCalendarID, nCostTypeID, nProjectID, Ftemode, out costCategories) != StatusEnum.rsSuccess) goto Status_Error;
                        break;
                }
                dba.Close();

                EditCostsData oGridData = new EditCostsData();
                oGridData.InitializeGridData(nCostTypeID, Ftemode);

                CostCategory prevCostCategory = null;
                CostCategory[] CCLevels = new CostCategory[10];
                foreach (CostCategory costCategory in costCategories)
                {
                    costCategory.IsSummary = false;
                    if (costCategory.Seq > 0)
                    {
                        costCategory.Parent = prevCostCategory;
                        costCategory.Level = prevCostCategory.Level + 1;
                    }
                    else
                    {
                        CCLevels[costCategory.Level] = costCategory;
                        if (prevCostCategory != null)
                        {
                            if (costCategory.Level > prevCostCategory.Level)
                            {
                                prevCostCategory.IsSummary = true;
                                costCategory.Parent = prevCostCategory;
                            }
                            else if (costCategory.Level == prevCostCategory.Level)
                                costCategory.Parent = prevCostCategory.Parent;
                            else
                            {
                                costCategory.Parent = CCLevels[costCategory.Level - 1];
                            }
                        }
                        prevCostCategory = costCategory;
                    }
                }

                bool bChanged = true;
                while (bChanged)
                {
                    bChanged = false;
                    foreach (CostCategory costCategory in costCategories)
                    {
                        if (costCategory.HasData == true && costCategory.Parent != null && costCategory.Parent.HasData == false)
                        {
                            costCategory.Parent.HasData = true;
                            bChanged = true;
                        }
                    }
                }

                bool bNoRows = true;
                foreach (CostCategory costCategory in costCategories)
                {
                    if (costCategory.HasData == true)
                    {
                        bNoRows = false;
                        break;
                    }
                }

                int nRowId = 0;
                foreach (CostCategory costCategory in costCategories)
                {
                    if (bNoRows)
                        costCategory.HasData = true;
                    oGridData.AddCostCategory(costCategory, costCustomFields, nRowId++);
                }
                sXML = oGridData.GetString();
                return sXML;
            }
            else
                return HandleError("GetEditCostsData", "User Authentication Failed. Stage=" + sStage);
Status_Error:
            dba.Close();
            return HandleError("GetEditCostsData", dba.FormatErrorText());
        }

        private StatusEnum BuildCostDetailsData(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, int Ftemode, out List<CostCategory> costCategories)
        {
            // Get the outline
            costCategories = new List<CostCategory>();
            {
                DataTable dt;
                if (dbaEditCosts.SelectCostCategoryData(dba, nCalendarID, nCostTypeID, nProjectID, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                int prev_bcuid = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int bcuid = DBAccess.ReadIntValue(row["BC_UID"]);
                    int seq = DBAccess.ReadIntValue(row["Seq"]);
                    if (seq > 0 && prev_bcuid != bcuid)
                    {
                        CostCategory costCategory2 = new CostCategory();
                        costCategory2.Uid = bcuid;
                        costCategory2.Id = DBAccess.ReadIntValue(row["BC_ID"]);
                        costCategory2.Seq = 0;
                        costCategory2.Name = DBAccess.ReadStringValue(row["BC_NAME"]);
                        costCategory2.Level = DBAccess.ReadIntValue(row["BC_LEVEL"]) + 1;
                        costCategory2.UoM = DBAccess.ReadStringValue(row["BC_UOM"]);
                        costCategory2.HasData = true;
                        costCategories.Add(costCategory2);
                    }
                    
                    CostCategory costCategory = new CostCategory();
                    costCategory.Uid = bcuid;
                    costCategory.Id = DBAccess.ReadIntValue(row["BC_ID"]);
                    costCategory.Name = DBAccess.ReadStringValue(row["BC_NAME"]);
                    costCategory.Level = DBAccess.ReadIntValue(row["BC_LEVEL"]) + 1;
                    costCategory.UoM = DBAccess.ReadStringValue(row["BC_UOM"]);
                    //costCategory.HasData = (DBAccess.ReadIntValue(row["Used"]) > 0) ? true : false;
                    costCategory.HasData = (DBAccess.ReadIntValue(row["Used"]) > 0);
                    costCategory.Seq = seq;
                    costCategory.NamedRateUID = DBAccess.ReadIntValue(row["RT_UID"]);
                    costCategory.NamedRateName = DBAccess.ReadStringValue(row["RT_NAME"]);

                    for (int i = 0; i < 5; i++)
                    {
                        string si = (i + 1).ToString("0");
                        costCategory.CustomCodeValues[i] = DBAccess.ReadIntValue(row["OC_0" + si]);
                        costCategory.CustomCodeTextValues[i] = DBAccess.ReadStringValue(row["LV_0" + si]);
                        costCategory.CustomTextValues[i] = DBAccess.ReadStringValue(row["TEXT_0" + si]);
                    }

                    costCategories.Add(costCategory);
                    prev_bcuid = bcuid;
                }
            }

            List<PeriodRate> periodRates;
            if (GetPeriodRates(dba, nCalendarID, out periodRates) != StatusEnum.rsSuccess) goto Status_Error;

            // Get the period costs and values
            List<PeriodCostValue> periodCostValues = new List<PeriodCostValue>();
            {
                DataTable dt;
                if (dbaEditCosts.SelectPeriodsCostDetailsValues(dba, nCalendarID, nCostTypeID, nProjectID, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                foreach (DataRow row in dt.Rows)
                {
                    int nCostCategoryId = DBAccess.ReadIntValue(row["BC_UID"]);
                    int nPeriod = DBAccess.ReadIntValue(row["BD_PERIOD"]);
                    bool bIsNullCost;
                    bool bIsNullQuantity;
                    double dblQuantity = DBAccess.ReadDoubleValue(row["BD_VALUE"], out bIsNullQuantity);
                    double dblCost = DBAccess.ReadDoubleValue(row["BD_COST"], out bIsNullCost);
                    if (bIsNullQuantity == false || bIsNullCost == false)
                    {
                        PeriodCostValue periodCostValue = new PeriodCostValue();
                        periodCostValue.PeriodId = nPeriod;
                        periodCostValue.Seq = DBAccess.ReadIntValue(row["BC_SEQ"]);
                        periodCostValue.CostCategoryId = nCostCategoryId;
                        periodCostValue.Quantity = bIsNullQuantity ? double.MinValue : dblQuantity;
                        periodCostValue.Cost = bIsNullCost ? double.MinValue : dblCost;
                        periodCostValues.Add(periodCostValue);
                    }
                }
            }

            // add the rate values into the costcategory list
            foreach (PeriodRate periodRate in periodRates)
            {
                foreach (CostCategory costCategory in costCategories)
                {
                    if (periodRate.CostCategoryId == costCategory.Uid)
                    {
                        costCategory.periodRates.Add(periodRate);
                    }
                }
            }

            // add the costs and values into the costcategory list
            foreach (PeriodCostValue periodCostValue in periodCostValues)
            {
                foreach (CostCategory costCategory in costCategories)
                {
                    if (periodCostValue.CostCategoryId == costCategory.Uid && periodCostValue.Seq == costCategory.Seq)
                    {
                        costCategory.periodCostValues.Add(periodCostValue);
                        costCategory.HasData = true;
                        break;
                    }
                }
            }

            return StatusEnum.rsSuccess;
Status_Error:
            return dba.Status;
        }

        private StatusEnum BuildCalculatedData(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, int Ftemode, out List<CostCategory> costCategories)
        {
            costCategories = null;
            List<CostTypeOperation> costTypeOperations;
            if (GetCostTypeOperations(dba, nCostTypeID, out costTypeOperations) != StatusEnum.rsSuccess) goto Status_Error;

            if (costTypeOperations.Count < 1)
            {
                dba.Status = (StatusEnum)99837;
                dba.StatusText = "No operations found for Calculated Cost type : " + nCostTypeID.ToString("0");
                return dba.Status;
            }

            bool bFirst = true;
            foreach (CostTypeOperation cto in costTypeOperations)
            {
                List<CostCategory> costCategories1;
                CostType ct;
                if (GetCostType(dba, cto.Id, out ct) != StatusEnum.rsSuccess) goto Status_Error;

                switch (ct.EditMode)
                {
                    case 1:
                    case 101:
                        if (BuildCostDetailsData(dba, nCalendarID, ct.Id, nProjectID, Ftemode, out costCategories1) != StatusEnum.rsSuccess) goto Status_Error;
                        break;
                    default:
                        if (BuildCostValuesData(dba, nCalendarID, ct.Id, nProjectID, Ftemode, out costCategories1) != StatusEnum.rsSuccess) goto Status_Error;
                        break;
                }

                if (bFirst)
                {
                    bFirst = false;
                    costCategories = costCategories1;
                }
                else
                {
                    costCategories = MergeCostCategories(dba, costCategories, costCategories1, cto);
                }
            }

Status_Error:
            return dba.Status;
        }

        private List<CostCategory> MergeCostCategories(DBAccess dba, List<CostCategory> costCategories1, List<CostCategory> costCategories2, CostTypeOperation cto)
        {
            List<CostCategory> costCategories = new List<CostCategory>();
            CostCategory[] arrcc1 = costCategories1.ToArray();
            CostCategory[] arrcc2 = costCategories2.ToArray();
            int ncc1 = 0;
            int ncc2 = 0;
            int nOp = cto.Operation;
            CostCategory lastcc = null;
            while (ncc1 < arrcc1.Length && ncc2 < arrcc2.Length)
            {
                CostCategory cc1 = arrcc1[ncc1];
                CostCategory cc2 = arrcc2[ncc2];
                if (cc1.Seq > 0 || cc2.Seq > 0)
                {
                    // NB for now we are ignoring detail rows
                    if (cc1.Seq > 0)
                    {
                        if (lastcc != null)
                            MergeCostCategoryValues(lastcc, cc1, 0);
                        ncc1++;
                    }
                    if (cc2.Seq > 0)
                    {
                        if (lastcc != null)
                            MergeCostCategoryValues(lastcc, cc2, 0);
                        ncc2++;
                    }
                }
                else
                {
                    if (cc1.Id == cc2.Id && cc1.Seq == cc2.Seq)
                    {
                        lastcc = MergeCostCategoryValues(cc1, cc2, nOp);
                        costCategories.Add(lastcc);
                        ncc1++;
                        ncc2++;
                    }
                    else if ((cc1.Id == cc2.Id && cc1.Seq < cc2.Seq) || cc1.Id < cc2.Id)
                    {
                        lastcc = MergeCostCategoryValues(cc1, null, nOp);
                        costCategories.Add(lastcc);
                        ncc1++;
                    }
                    else if ((cc1.Id == cc2.Id && cc1.Seq > cc2.Seq) || cc1.Id > cc2.Id)
                    {
                        lastcc = MergeCostCategoryValues(null, cc2, nOp);
                        costCategories.Add(lastcc);
                        ncc2++;
                    }
                    else
                        break;
                }
            }
            while (ncc1 < arrcc1.Length)
            {
                if (arrcc1[ncc1].Seq == 0)
                    costCategories.Add(MergeCostCategoryValues(arrcc1[ncc1], null, nOp));
                ncc1++;
            }
            while (ncc2 < arrcc2.Length)
            {
                if (arrcc2[ncc2].Seq == 0)
                    costCategories.Add(MergeCostCategoryValues(null, arrcc2[ncc2], nOp));
                ncc2++;
            }
            return costCategories;
        }

        private CostCategory MergeCostCategoryValues(CostCategory cc1, CostCategory cc2, int nOp)
        {
            CostCategory costCategory = null;
            if (cc2 == null)
                costCategory = cc1;
            else if (cc1 == null)
            {
                costCategory = ApplyOperation(cc2, nOp);
            }
            else
            {
                costCategory = cc1;
                ApplyOperation(cc2, nOp);

                List<PeriodCostValue> periodCostValues = new List<PeriodCostValue>();
                PeriodCostValue[] arrPCV1 = cc1.periodCostValues.ToArray();
                PeriodCostValue[] arrPCV2 = cc2.periodCostValues.ToArray();

                int index1 = 0;
                int index2 = 0;
                int maxIndex1 = arrPCV1.Length;
                int maxIndex2 = arrPCV2.Length;

                while (index1 < maxIndex1 || index2 < maxIndex2)
                {
                    if (index1 >= maxIndex1)
                    {
                        periodCostValues.Add(AddPeriodCostValues(null, arrPCV2[index2++]));
                    }
                    else if (index2 >= maxIndex2)
                    {
                        periodCostValues.Add(AddPeriodCostValues(arrPCV1[index1++], null));
                    }
                    else
                    {
                        if (arrPCV1[index1].PeriodId == arrPCV2[index2].PeriodId)
                        {
                            periodCostValues.Add(AddPeriodCostValues(arrPCV1[index1++], arrPCV2[index2++]));
                        }
                        else if (arrPCV1[index1].PeriodId > arrPCV2[index2].PeriodId)
                        {
                            periodCostValues.Add(AddPeriodCostValues(null, arrPCV2[index2++]));
                        }
                        else
                        {
                            periodCostValues.Add(AddPeriodCostValues(arrPCV1[index1++], null));
                        }
                    }
                }
                costCategory.periodCostValues = periodCostValues;

            }

            return costCategory;
        }

        private CostCategory ApplyOperation(CostCategory costCategory, int nOp)
        {
            if (nOp == 1)
            {
                foreach (PeriodCostValue pcv in costCategory.periodCostValues)
                {
                    pcv.Cost = -pcv.Cost;
                    pcv.Quantity = -pcv.Quantity;
                }
            }
            return costCategory;
        }

        private PeriodCostValue AddPeriodCostValues(PeriodCostValue pcv1, PeriodCostValue pcv2)
        {
            PeriodCostValue pcv = pcv2;
            double cost1 = 0;
            double quantity1 = 0;
            if (pcv1 != null)
            {
                pcv = pcv1;
                cost1 = pcv1.Cost;
                quantity1 = pcv1.Quantity;
            }

            double cost2 = 0;
            double quantity2 = 0;
            if (pcv2 != null)
            {
                cost2 = pcv2.Cost;
                quantity2 = pcv2.Quantity;
            }

            PeriodCostValue periodCostValue = new PeriodCostValue();
            periodCostValue.PeriodId = pcv.PeriodId;
            periodCostValue.Seq = pcv.Seq;
            periodCostValue.CostCategoryId = pcv.CostCategoryId;
            periodCostValue.Cost = cost1 + cost2;
            periodCostValue.Quantity = quantity1 + quantity2;

            return periodCostValue;
        }

        private StatusEnum BuildCostValuesData(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, int Ftemode, out List<CostCategory> costCategories)
        {
            // Get the outline
            costCategories = new List<CostCategory>();
            {
                DataTable dt;
                if (dbaEditCosts.SelectCostCategories(dba, nCostTypeID, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                foreach (DataRow row in dt.Rows)
                {
                    bool bUsed = (DBAccess.ReadIntValue(row["CT_ID"]) > 0);
                    if (bUsed)
                    {
                        CostCategory costCategory = new CostCategory();
                        costCategory.Uid = DBAccess.ReadIntValue(row["BC_UID"]);
                        costCategory.Id = DBAccess.ReadIntValue(row["BC_ID"]);
                        costCategory.Name = DBAccess.ReadStringValue(row["BC_NAME"]);
                        costCategory.Level = DBAccess.ReadIntValue(row["BC_LEVEL"]) + 1;
                        costCategory.UoM = DBAccess.ReadStringValue(row["BC_UOM"]);
                        costCategory.Seq = 0;
                        costCategories.Add(costCategory);
                    }
                }
            }

            List<PeriodRate> periodRates;
            if (GetPeriodRates(dba, nCalendarID, out periodRates) != StatusEnum.rsSuccess) goto Status_Error;

            // Get the period costs and values
            List<PeriodCostValue> periodCostValues = new List<PeriodCostValue>();
            {
                DataTable dt;
                if (dbaEditCosts.SelectPeriodsCostValues(dba, nCalendarID, nCostTypeID, nProjectID, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                foreach (DataRow row in dt.Rows)
                {
                    int nCostCategoryId = DBAccess.ReadIntValue(row["BC_UID"]);
                    int nPeriod = DBAccess.ReadIntValue(row["BD_PERIOD"]);
                    bool bIsNullCost;
                    bool bIsNullQuantity;
                    double dblQuantity = DBAccess.ReadDoubleValue(row["BD_VALUE"], out bIsNullQuantity);
                    double dblCost = DBAccess.ReadDoubleValue(row["BD_COST"], out bIsNullCost);
                    if (bIsNullQuantity == false || bIsNullCost == false)
                    {
                        PeriodCostValue periodCostValue = new PeriodCostValue();
                        periodCostValue.PeriodId = nPeriod;
                        periodCostValue.Seq = 0;
                        periodCostValue.CostCategoryId = nCostCategoryId;
                        periodCostValue.Quantity = bIsNullQuantity ? double.MinValue : dblQuantity;
                        periodCostValue.Cost = bIsNullCost ? double.MinValue : dblCost;
                        periodCostValues.Add(periodCostValue);
                    }
                }
            }

            // add the rate values into the costcategory list
            foreach (PeriodRate periodRate in periodRates)
            {
                foreach (CostCategory costCategory in costCategories)
                {
                    if (periodRate.CostCategoryId == costCategory.Uid)
                    {
                        costCategory.periodRates.Add(periodRate);
                    }
                }
            }

            // add the costs and values into the costcategory list
            foreach (PeriodCostValue periodCostValue in periodCostValues)
            {
                foreach (CostCategory costCategory in costCategories)
                {
                    if (periodCostValue.CostCategoryId == costCategory.Uid)
                    {
                        costCategory.periodCostValues.Add(periodCostValue);
                        costCategory.HasData = true;
                        break;
                    }
                }
            }
            return StatusEnum.rsSuccess;
Status_Error:
            return dba.Status;
        }

        private StatusEnum GetPeriodRates(DBAccess dba, int nCalendarID, out List<PeriodRate> periodRates)
        {
            periodRates = new List<PeriodRate>();
            DataTable dt;
            if (dbaEditCosts.SelectPeriodsRates(dba, nCalendarID, out dt) != StatusEnum.rsSuccess)
                return dba.Status;

            foreach (DataRow row in dt.Rows)
            {
                int nCostCategoryId = DBAccess.ReadIntValue(row["BA_BC_UID"]);
                int nPeriod = DBAccess.ReadIntValue(row["BA_PRD_ID"]);
                bool bIsNullRate;
                bool bIsNullFTEConv;
                int nFTEConv = DBAccess.ReadIntValue(row["BA_FTE_CONV"], out bIsNullFTEConv);
                double dblRate = DBAccess.ReadDoubleValue(row["BA_RATE"], out bIsNullRate);
                if (bIsNullFTEConv == false || bIsNullRate == false)
                {
                    PeriodRate periodRate = new PeriodRate();
                    periodRate.PeriodId = nPeriod;
                    periodRate.CostCategoryId = nCostCategoryId;
                    periodRate.FTEConv = bIsNullFTEConv ? int.MinValue : nFTEConv;
                    periodRate.Rate = bIsNullRate ? double.MinValue : dblRate;
                    periodRates.Add(periodRate);
                }
            }
            return dba.Status;
        }

        private void BuildWritableList(CStruct xB, List<CStruct> listI)
        {
            List<CStruct> list = xB.GetList("I");
            if (list.Count > 0)
            {
                foreach (CStruct xI in list)
                {
                    if (xI.GetIntAttr("Visible", 0) == 1)
                    {
                        MarkWriteableItems(xI);
                    }
                }
                foreach (CStruct xI in list)
                {
                    if (xI.GetIntAttr("Visible", 0) == 1)
                    {
                        BuildItemsList(xI, listI);
                    }
                }
            }
        }

        private void BuildItemsList(CStruct xItemI, List<CStruct> listI)
        {
            if (xItemI.GetBooleanAttr("CanWrite") == true)
                listI.Add(xItemI);
            List<CStruct> list = xItemI.GetList("I");
            if (list.Count > 0)
            {
                foreach (CStruct xI in list)
                {
                    BuildItemsList(xI, listI);
                }
            }
        }

        private void MarkWriteableItems(CStruct xItemI)
        {
            bool bSequencedChildren = false;
            // for an item to be writable it must be 
            // - visible
            // - a row or a summary without any visible children or a summary with only visible children with seqence values

            // for a writable item to have writable details it must be
            // - a row or a summary without any visible children
            List<CStruct> listI = xItemI.GetList("I");
            if (listI.Count == 0)
            {
                // item has no children so it is an editable leaf row
                xItemI.CreateBooleanAttr("CanWrite", true);
                //xItemI.CreateBooleanAttr("CanWriteDetails", true);
            }
            else
            {
                // item has children but it could be writable if it doesn't have any visible children
                bool bAnyVisibleChildren = false;
                foreach (CStruct xI in listI)
                {
                    if (xI.GetIntAttr("Visible", 0) == 1)
                    {
                        if (xI.GetStringAttr("id", "").Contains("S"))
                            bSequencedChildren = true;

                        MarkWriteableItems(xI);
                        bAnyVisibleChildren = true;
                    }
                }
                if (bAnyVisibleChildren == false)
                {
                    xItemI.CreateBooleanAttr("CanWrite", true);
                    //xItemI.CreateBooleanAttr("CanWriteDetails", true);
                }
                else if (bSequencedChildren)
                {
                    xItemI.CreateBooleanAttr("CanWrite", true);
                    xItemI.CreateBooleanAttr("DontValidate", true);
                }
            }
        }

        /// <summary>
        /// Builds XML to populate the CostType grid
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="Projectid"></param>
        /// <param name="Costtypeid"></param>
        /// <param name="Viewuid"></param>
        /// <param name="Wepid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string SaveEditCostsData(string sData, int Projectid, int Costtypeid, string Viewuid, string Wepid)
        {
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;

            int nViewUID;
            Int32.TryParse(Viewuid, out nViewUID);
            string sReply = "";
            try
            {
                CStruct xGrid = new CStruct();
                if (xGrid.LoadXML(sData) == false)
                    sReply = HandleError("Error saving Cost data", "Unable to load XML");
                else
                {
                    CStruct xBody = xGrid.GetSubStruct("Body");
                    CStruct xB = xBody.GetSubStruct("B");

                    // we are only interested in writable rows
                    List<CStruct> listI = new List<CStruct>();
                    BuildWritableList(xB, listI);

                    if (listI.Count > 0)
                    {
                        if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

                        if (Projectid == 0 && Wepid != "")
                        {
                            // convert wepid to ProjectID
                            if (dbaEditCosts.SelectProjectIDByExtUID(dba, Wepid, out Projectid) != StatusEnum.rsSuccess)
                            {
                                return HandleError("Error saving Cost data", "Unable to convert wepid '" + Wepid + "' to ProjectID");
                            }
                        }

                        if (Projectid <= 0)
                        {
                            return HandleError("Error saving Cost data", "Invalid ProjectID");
                        }
                        
                        int nCalendarID;
                        int nFirstPeriod;
                        int nLastPeriod;
                        if (dbaEditCosts.SelectViewCalendarInfo(dba, nViewUID, out nCalendarID, out nFirstPeriod, out nLastPeriod) != StatusEnum.rsSuccess) goto Exit_Function;
                        if (nCalendarID < 0)
                        {
                            return HandleError("Error saving Cost data", "Invalid Calendar");
                        }


                        List<CostCustomField> costCustomFields;
                        if (GetCostCustomFields(dba, Costtypeid, false, out costCustomFields) != StatusEnum.rsSuccess) goto Exit_Function;
                        bool bHaveIdentity = false;
                        bool bHaveRequired = false;
                        foreach (CostCustomField costCustomField in costCustomFields)
                        {
                            if (costCustomField.Identity)
                                bHaveIdentity = true;
                            if (costCustomField.Required)
                                bHaveRequired = true;
                            if (bHaveIdentity && bHaveRequired)
                                break;

                        }

                        if (bHaveRequired)
                        {
                            foreach (CStruct xI in listI)
                            {
                                string sId = xI.GetStringAttr("id", "");
                                if (xI.GetBooleanAttr("DontValidate", false) == false && xI.GetIntAttr("Changed", 0) != 0)
                                {
                                    int id; int seq;
                                    if (DecodeIdAndSeq(sId, out id, out seq))
                                    {
                                        string sLongKey = "Category = \"" + xI.GetStringAttr("Category") + (seq > 0 ? "(" + sId + ")" : "") + "\";\n";
                                        foreach (CostCustomField costCustomField in costCustomFields)
                                        {
                                            if (costCustomField.Required)
                                            {
                                                string sFieldId = costCustomField.FieldId.ToString("0");
                                                switch (costCustomField.FieldId)
                                                {
                                                    case 11801:
                                                    case 11802:
                                                    case 11803:
                                                    case 11804:
                                                    case 11805:
                                                        if (xI.GetIntAttr("Y" + sFieldId, 0) <= 0)
                                                            return HandleError("Error saving Cost data", costCustomField.Name + " is a required code field\n\n" + sLongKey);
                                                        break;
                                                    case 11811:
                                                    case 11812:
                                                    case 11813:
                                                    case 11814:
                                                    case 11815:
                                                        if (xI.GetIntAttr("Y" + sFieldId, 0) <= 0 && xI.GetStringAttr("Z" + sFieldId, "") == "" && xI.GetStringAttr("X" + sFieldId, "") == "")
                                                            return HandleError("Error saving Cost data", costCustomField.Name + " is a required text field\n\n" + sLongKey);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (bHaveIdentity)
                        {
                            SortedList<string, CStruct> clnKeys = new SortedList<string, CStruct>();
                            foreach (CStruct xI in listI)
                            {
                                int id; int seq;
                                string sId = xI.GetStringAttr("id", "");

                                string sKey = "";
                                string sLongKey = "Category = \"" + xI.GetStringAttr("Category") + "\";\n";
                                if (DecodeIdAndSeq(sId, out id, out seq))
                                {
                                    sKey += "id:" + id.ToString("0") + ";level:" + xI.GetIntAttr("Level", 0);
                                    foreach (CostCustomField costCustomField in costCustomFields)
                                    {
                                        if (costCustomField.Identity)
                                        {
                                            string sFieldId = costCustomField.FieldId.ToString("0");
                                            switch (costCustomField.FieldId)
                                            {
                                                case 11801:
                                                case 11802:
                                                case 11803:
                                                case 11804:
                                                case 11805:
                                                    sKey += ";Y" + sFieldId + ":" + xI.GetIntAttr("Y" + sFieldId, 0);
                                                    sLongKey += costCustomField.Name + " = \"" + xI.GetStringAttr("Z" + sFieldId, "") + "\";\n";
                                                    break;
                                                case 11811:
                                                case 11812:
                                                case 11813:
                                                case 11814:
                                                case 11815:
                                                    sKey += ";X" + sFieldId + ":" + xI.GetStringAttr("X" + sFieldId, "");
                                                    sLongKey += costCustomField.Name + " = \"" + xI.GetStringAttr("X" + sFieldId, "") + "\";\n";
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (clnKeys.ContainsKey(sKey) == false)
                                    clnKeys.Add(sKey, xI);
                                else
                                {
                                    return HandleError("Error saving Cost data", "Two or more rows found with the same identity:\n\n" + sLongKey);
                                }
                            }
                        }

                        List<Period> periods = new List<Period>();
                        DataTable dtPeriods;
                        if (dbaEditCosts.SelectCalendarPeriods(dba, nCalendarID, out dtPeriods) != StatusEnum.rsSuccess) goto Exit_Function;

                        {
                            Period period = null;
                            foreach (DataRow row in dtPeriods.Rows)
                            {
                                bool bIsNull;
                                period = new Period();
                                period.Id = DBAccess.ReadIntValue(row["PRD_ID"]);
                                period.Name = DBAccess.ReadStringValue(row["PRD_NAME"]);
                                period.StartDate = DBAccess.ReadDateValue(row["PRD_START_DATE"], out bIsNull);
                                period.FinishDate = DBAccess.ReadDateValue(row["PRD_FINISH_DATE"], out bIsNull);

                                if (nFirstPeriod == Int32.MinValue)
                                    nFirstPeriod = period.Id;

                                if (period.Id >= nFirstPeriod && period.Id <= nLastPeriod)
                                    periods.Add(period);
                            }
                            if (period != null && nLastPeriod == Int32.MaxValue)
                                nLastPeriod = period.Id;
                        }


                        dba.BeginTransaction();
                        
                        int lRowsAffected;
                        if (dbaEditCosts.DeleteCostDetails(dba, nCalendarID, Costtypeid, Projectid, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;
                        if (dbaEditCosts.DeleteCostDetailsValues(dba, nCalendarID, Costtypeid, Projectid, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("BC_UID");
                            dt.Columns.Add("BC_SEQ");
                            dt.Columns.Add("RT_UID");
                            dt.Columns.Add("OC_01");
                            dt.Columns.Add("OC_02");
                            dt.Columns.Add("OC_03");
                            dt.Columns.Add("OC_04");
                            dt.Columns.Add("OC_05");
                            dt.Columns.Add("TEXT_01");
                            dt.Columns.Add("TEXT_02");
                            dt.Columns.Add("TEXT_03");
                            dt.Columns.Add("TEXT_04");
                            dt.Columns.Add("TEXT_05");
                            foreach (CStruct xI in listI)
                            {
                                string sId = xI.GetStringAttr("id", "");

                                int ratetype = xI.GetIntAttr("V", 0);
                                //if (xI.GetIntAttr("Visible", 0) == 1) // && xI.GetStringAttr("Def", "") != "Summary")
                                {
                                    int id; int seq;
                                    if (DecodeIdAndSeq(sId, out id, out seq))
                                    {
                                        int oc1; int oc2; int oc3; int oc4; int oc5;
                                        oc1 = oc2 = oc3 = oc4 = oc5 = 0;
                                        string text1; string text2; string text3; string text4; string text5;
                                        text1 = text2 = text3 = text4 = text5 = "";

                                        foreach (CostCustomField costCustomField in costCustomFields)
                                        {
                                            string sFieldId = costCustomField.FieldId.ToString("0");
                                            string sPrefix = (costCustomField.LookupUid > 0) ? "Z" : "X";
                                            switch (costCustomField.FieldId)
                                            {
                                                case 11801:
                                                    oc1 = xI.GetIntAttr("Y11801", 0);
                                                    break;
                                                case 11802:
                                                    oc2 = xI.GetIntAttr("Y11802", 0);
                                                    break;
                                                case 11803:
                                                    oc3 = xI.GetIntAttr("Y11803", 0);
                                                    break;
                                                case 11804:
                                                    oc4 = xI.GetIntAttr("Y11804", 0);
                                                    break;
                                                case 11805:
                                                    oc5 = xI.GetIntAttr("Y11805", 0);
                                                    break;
                                                case 11811:
                                                    text1 = xI.GetStringAttr(sPrefix + "11811", "");
                                                    break;
                                                case 11812:
                                                    text2 = xI.GetStringAttr(sPrefix + "11812", "");
                                                    break;
                                                case 11813:
                                                    text3 = xI.GetStringAttr(sPrefix + "11813", "");
                                                    break;
                                                case 11814:
                                                    text4 = xI.GetStringAttr(sPrefix + "11814", "");
                                                    break;
                                                case 11815:
                                                    text5 = xI.GetStringAttr(sPrefix + "11815", "");
                                                    break;
                                            }
                                        }
                                           
                                        if (id > 0) dt.Rows.Add(new object[] { id, seq, ratetype, oc1, oc2, oc3, oc4, oc5, text1, text2, text3, text4, text5 });
                                    }
                                }
                            }
                            if (dbaEditCosts.InsertCostDetails(dba, nCalendarID, Costtypeid, Projectid, dt) != StatusEnum.rsSuccess) goto Exit_Function;
                        }
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("BC_UID");
                            dt.Columns.Add("BC_SEQ");
                            dt.Columns.Add("BD_PERIOD");
                            dt.Columns.Add("BD_VALUE");
                            dt.Columns.Add("BD_COST");
                            foreach (CStruct xI in listI)
                            {
                                int id; int seq;
                                string sId = xI.GetStringAttr("id", "");

                                //if (xI.GetIntAttr("Visible", 0) == 1 && xI.GetStringAttr("Def", "") != "Summary")
                                //if (xI.GetIntAttr("Visible", 0) == 1 && xI.GetBooleanAttr("IsSummary", false) == false)
                                if (xI.GetBooleanAttr("DontValidate", false) == false)
                                {
                                    if (DecodeIdAndSeq(sId, out id, out seq))
                                    {
                                        foreach (Period period in periods)
                                        {
                                            bool bCostTagFound;
                                            bool bQuantityTagFound;
                                            string sQ = "Q" + period.Id.ToString("0");
                                            string sC = "C" + period.Id.ToString("0");

                                            double dblQuantity = xI.GetDoubleAttr(sQ, out bQuantityTagFound);
                                            double dblCost = xI.GetDoubleAttr(sC, out bCostTagFound);
                                            if ((bQuantityTagFound == true && dblQuantity != 0) || (bCostTagFound == true && dblCost != 0))
                                            {
                                                dt.Rows.Add(new object[] { id, seq, period.Id, dblQuantity, dblCost });
                                            }
                                        }
                                    }
                                }
                            }

                            if (dbaEditCosts.InsertCostDetailValues(dba, nCalendarID, Costtypeid, Projectid, dt) != StatusEnum.rsSuccess) goto Exit_Function;
                            dba.CommitTransaction();


                            // now call Ken's CalculateCostValues - don't think sResult is significant
                            string sResult;
                            if (dbaCCV.CalculateCostValues(dba, Costtypeid, nCalendarID, Projectid, out sResult) != StatusEnum.rsSuccess) goto Exit_Function;


                            if (dbaGeneral.SelectAdmin(dba, out dt) != StatusEnum.rsSuccess) goto Exit_Function;

                            if (dt.Rows.Count != 1)
                            {
                                dba.Status = (StatusEnum)99836;
                                dba.StatusText = "Invalid Admin row count : " + dt.Rows.Count.ToString("0");
                                goto Exit_Function;
                            }

                            string sWEServerURL = DBAccess.ReadStringValue(dt.Rows[0]["ADM_WE_SERVERURL"]);
                            if (sWEServerURL.Length > 0)
                            {
                                string sXMLRequest;
                                if (dbaUsers.ExportPIInfo(dba, Projectid.ToString("0"), out sXMLRequest) != StatusEnum.rsSuccess) goto Exit_Function;

                                XmlNode xNode;
                                if (SendXMLToWorkEngine(dba, sWEServerURL, "UpdateItems", sXMLRequest, out xNode) != StatusEnum.rsSuccess) goto Exit_Function;

                                if (xNode == null || xNode.OuterXml == "")
                                {
                                    dba.Status = (StatusEnum)99835;
                                    dba.StatusText = "No response from WorkEngine WebService";
                                    goto Exit_Function;
                                }

                                CStruct xResult = new CStruct();
                                string s = xNode.OuterXml;
                                //s = "<Result Status=\"1\"><Item ID=\"1\" Error=\"102\"><![CDATA[Error Processing Item: Index was outside the bounds of the array.]]></Item></Result>";
                                if (xResult.LoadXML(s) == false)
                                {
                                    dba.Status = (StatusEnum)99834;
                                    dba.StatusText = "Invalid XML response from WorkEngine WebService";
                                    goto Exit_Function;
                                }

                                if (xResult.GetIntAttr("Status") != 0)
                                {
                                    CStruct xError = xResult.GetSubStruct("Error");
                                    if (xError != null)
                                    { 
                                        string sError = xError.GetStringAttr("ID") + " : " + xError.GetString("");
                                        dba.Status = (StatusEnum)99833;
                                        dba.StatusText = "Invalid XML response from WorkEngine WebService. Status=" + xResult.GetStringAttr("Status") + "; Error=" + sError;
                                    }
                                    else
                                    {
                                        CStruct xItem = xResult.GetSubStruct("Item");
                                        if (xItem != null)
                                        {
                                            string sError = xItem.GetStringAttr("Error") + " : " + xItem.GetString("");
                                            dba.Status = (StatusEnum)99999;
                                            dba.StatusText = "Invalid XML response from WorkEngine WebService. Status=" + xResult.GetStringAttr("Status") + "; Error=" + sError;
                                        }
                                        else
                                        {
                                            dba.Status = (StatusEnum)99999;
                                            dba.StatusText = "XML response from WorkEngine WebService not recognized"; 
                                        }
                                    }
                                    goto Exit_Function;
                                }
                            }
                        }
                    }
                    sReply = "<Grid><IO Result=\"0\"/></Grid>";
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveEditCostsData", ex);
                dba.Status = (StatusEnum)99832;
            }
            
Exit_Function:
            if (dba != null)
            {
                if (dba.Status != StatusEnum.rsSuccess)
                {
                    dba.RollbackTransaction();
                    sReply = HandleDBAccessError("SaveEditCostsData", dba);
                }
                else
                {
                    dba.CommitTransaction();
                }
                dba.Close();
            }
            return sReply;
        }

        private static StatusEnum SendXMLToWorkEngine(DBAccess dba, string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            //HttpContext context = HttpContext.Current;
            //if (WorkEnginePPM.WebAdmin.CheckProductFlag(context, (uint)Security.ProductFlag.pfSPWorkEngine) == true)
            {

                try
                {
                    Integration weInt = new Integration();
                    xNode = weInt.execute(sContext, sXMLRequest);
                    dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "EditCosts.SendXMLToWorkEngine", "WE Request", "Context=" + sContext + "; URL=" + sURL, sXMLRequest);
                    if (xNode != null)
                        dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "EditCosts.SendXMLToWorkEngine", "WE Reply", "Context=" + sContext + "; URL=" + sURL, xNode.OuterXml);
                }
                catch (Exception ex)
                {
                    dba.Status = (StatusEnum)99830;
                    dba.StatusText = ex.Message;
                    dba.StackTrace = ex.StackTrace;
                    dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "EditCosts.SendXMLToWorkEngine", "Exception", ex.Message, ex.StackTrace);
                }
            }
            return dba.Status;
        }

        private static string EncodeIdAndSeq(int id, int seq)
        {
            // format = Ixxx[Syyy] x == id; y == seq != 0;
            return "I" + id.ToString("0") + ((seq > 0) ? "S" + seq.ToString("0") : "");
        }

        private static bool DecodeIdAndSeq(string sIdAndSeq, out int id, out int seq)
        {
            id = 0;
            seq = 0;
            if (sIdAndSeq.StartsWith("I") == false)
                return false;

            sIdAndSeq = sIdAndSeq.Substring(1);

            string[] sarr = sIdAndSeq.Split('S');
            if (sarr.Length > 1)
            {
                if (Int32.TryParse(sarr[1], out seq) == false)
                    return false;
            }
            
            if (Int32.TryParse(sarr[0], out id) == false)
                return false;

            return true;
        }


        private static string HandleDBAccessError(string sContext, DBAccess dba)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Grid");
            CStruct xIO = xReply.CreateSubStruct("IO");
            xIO.CreateIntAttr("Result", -11);
            xIO.CreateStringAttr("Message", "DBAccess Status Exception in EditCosts.asmx.cs" + "\n\n" + "Context=" + sContext + "\n\n" + "Text=" + dba.FormatErrorText() + ";");

            return xReply.XML();
        }

        private static string HandleError(string sContext, string sError)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Grid");
            CStruct xIO = xReply.CreateSubStruct("IO");
            xIO.CreateIntAttr("Result", -10);
            xIO.CreateStringAttr("Message", sContext + "\n\n" + sError);

            return xReply.XML();
        }

        private static string HandleException(string sContext, Exception ex)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Grid");
            CStruct xIO = xReply.CreateSubStruct("IO");
            xIO.CreateStringAttr("Message", "Exception in EditCosts.asmx.cs Context=" + sContext + "; Text=" + ex.Message + ";");

            return xReply.XML();
        }

        public class CostType
        {
            public int Id;
            public string Name;
            public int EditMode;    // 1=Editable; 3=Calculated; 30=CumulativeCalculated; other=dat comes from costvalues table
            public bool IncludeNamedRates;
            public int InitialLevel;
            public int CalendarId;
        }

        private class CostTypeOperation
        {
            public int Id;
            //public int EditMode;    // 1=Editable; 3=Calculated; 30=CumulativeCalculated; other=dat comes from costvalues table
            //public bool IncludeNamedRates;
            public int Operation;
        }

        public class NamedRateValue
        {
            public int Id;
            public DateTime EffectiveDate;
            public double Rate;
        }

        public class Period
        {
            public int Id;
            public string Name;
            public DateTime StartDate;
            public DateTime FinishDate;
        }

        internal class InternalPeriod
        {
            public int Id;
            public string Name;
            public DateTime StartDate;
            public DateTime FinishDate;
            public bool IsStatusPeriod = false;
        }

        internal class CostCustomField
        {
            public int Id;
            public int CostTypeId;
            public int FieldId;
            public bool Editable;
            public bool Visible;
            public bool Identity;
            public bool Required;
            public bool Frozen;
            public string Name;
            public bool LookupOnly;
            public int LookupUid;
            public bool LeafOnly;
            public bool UseFullName;
            public string jsonLookup;

        }

        internal class EditCostsLayout
        {
            private CStruct xGrid;
            private CStruct m_xPeriodCols;
            private CStruct m_xHeader1;
            private CStruct m_xHeader2;
            private CStruct m_xDSummaryRow;
            private CStruct m_xLeftCols;
            //private string m_sCFormula = "";
            //private string m_sVFormula = "";
            //private bool m_bFirstPeriod;
            private int m_nFTEMode = 0;

            public bool InitializeGridLayout(int CostTypeId, int FTEMode, bool bEditable, string sCheckedoutDetails, int lStartPeriod, int lFinishPeriod)
            {
                m_nFTEMode = FTEMode;
                xGrid = new CStruct();
                xGrid.Initialize("Grid");

                CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
                xToolbar.CreateIntAttr("Visible", 0);

                CStruct xPanel = xGrid.CreateSubStruct("Panel");
                xPanel.CreateIntAttr("Visible", 1);
                //CStruct xCPanel = xPanel.CreateSubStruct("C");
                xPanel.CreateIntAttr("Delete", 0);

                CStruct xCfg = xGrid.CreateSubStruct("Cfg");

                xCfg.CreateBooleanAttr("CostsAreEditable", bEditable);
                if (bEditable == false && sCheckedoutDetails.Length > 0)
                {
                    xCfg.CreateStringAttr("CheckedoutDetails", sCheckedoutDetails);
                }
                xCfg.CreateIntAttr("StartPeriod", lStartPeriod);
                xCfg.CreateIntAttr("FinishPeriod", lFinishPeriod);

                //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());
                xCfg.CreateStringAttr("MainCol", "Category");
                xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
                //xCfg.CreateStringAttr("AddFocusCol", "Category");
                xCfg.CreateIntAttr("Dragging", 0);
                xCfg.CreateIntAttr("ColMoving", 0);
                xCfg.CreateIntAttr("ColsPosLap", 1);
                xCfg.CreateIntAttr("ColsLap", 1);
                //xCfg.CreateIntAttr("MinLeftWidth", 50);
                xCfg.CreateIntAttr("LeftWidth", 400);
                xCfg.CreateIntAttr("SuppressCfg", 1);
                //xCfg.CreateIntAttr("LeftCanResize", 1);

                xCfg.CreateIntAttr("InEditMode", 1);

                xCfg.CreateIntAttr("MaxHeight", 0);
                xCfg.CreateIntAttr("ShowDeleted", 0);
                xCfg.CreateBooleanAttr("DateStrings", true);
                //xCfg.CreateIntAttr("MaxHeight", 1);
                xCfg.CreateIntAttr("MaxWidth", 1);
                xCfg.CreateIntAttr("MaxSort", 2);
                xCfg.CreateStringAttr("DefaultSort", "rowid");
                //xCfg.CreateStringAttr("IdNames", "Category");
                xCfg.CreateIntAttr("AppendId", 0);
                xCfg.CreateIntAttr("FullId", 0);
                xCfg.CreateStringAttr("IdChars", "0123456789IS");
                //xCfg.CreateIntAttr("NumberId", 1);
                //xCfg.CreateIntAttr("LastId", 1);
                //xCfg.CreateIntAttr("CaseSensitiveId", 0);
                //xCfg.CreateStringAttr("Style", "Modern");
                xCfg.CreateStringAttr("Style", "GM");
                xCfg.CreateStringAttr("CSS", "RPEditor");   // EditCosts css exists but might not be used
                //xCfg.CreateStringAttr("CSS", "Modern");
                xCfg.CreateIntAttr("FastColumns", 1);
                xCfg.CreateIntAttr("Sorting", 0);
                //xCfg.CreateIntAttr("Selecting", 0);
                xCfg.CreateIntAttr("NoTreeLines", 1);

                m_xLeftCols = xGrid.CreateSubStruct("LeftCols");

                m_xPeriodCols = xGrid.CreateSubStruct("Cols");
                CStruct xHead = xGrid.CreateSubStruct("Head");
                m_xHeader1 = xHead.CreateSubStruct("Header");
                m_xHeader1.CreateIntAttr("CategoryVisible", -1);
                m_xHeader1.CreateIntAttr("Spanned", -1);

                m_xHeader2 = xHead.CreateSubStruct("Header");
                m_xHeader2.CreateStringAttr("id", "Header");

                // Add category column
                CStruct xC = m_xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Category");
                xC.CreateStringAttr("Type", "Text");
                xC.CreateIntAttr("MinWidth", 50);
                xC.CreateIntAttr("Width", 175);
                //xC.CreateBooleanAttr("CanEdit", false);
                xC.CreateIntAttr("CanEdit", 0);
                xC.CreateIntAttr("CanMove", 0);

                // Add uom column
                xC = m_xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "uom");
                xC.CreateStringAttr("Type", "Text");
                xC.CreateIntAttr("CanEdit", 0);
                xC.CreateIntAttr("CanMove", 0);
                m_xHeader1.CreateStringAttr("uom", " ");
                m_xHeader2.CreateStringAttr("uom", " UoM ");

                // Add hidden id column for default sort
                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "rowid");
                xC.CreateStringAttr("Type", "Int");
                xC.CreateIntAttr("Visible", 0);


                CStruct xDef = xGrid.CreateSubStruct("Def");
                m_xDSummaryRow = xDef.CreateSubStruct("D");
                m_xDSummaryRow.CreateStringAttr("Name", "Summary");
                //m_xDSummaryRow.CreateStringAttr("Calculated", "1");
                return true;
            }

            public void AddNamedRateColumn(string jsonLookup)
            {
                // W = named rate name. V = associated named rate uid
                CStruct xC = m_xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "W");
                xC.CreateStringAttr("Type", "Text");
                m_xHeader1.CreateStringAttr("W", " ");
                m_xHeader2.CreateStringAttr("W", " Named Rate ");
                xC.CreateIntAttr("CanEdit", 0);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Defaults", jsonLookup);

                //xC = m_xLeftCols.CreateSubStruct("C");
                //xC.CreateStringAttr("Name", "V");
                //xC.CreateStringAttr("Type", "Text");
                //m_xHeader1.CreateStringAttr("V", " ");
                //m_xHeader2.CreateStringAttr("V", " Named Rate UID ");
                //xC.CreateIntAttr("CanEdit", 0);
            }

            public void AddCustomFieldColumn(CostCustomField costCustomField)
            {
                if (costCustomField.Visible == true)
                {
                    CStruct xC = m_xLeftCols.CreateSubStruct("C");
                    if (costCustomField.LookupUid > 0)
                    {
                        // Z = custom field with lookup. Y = associated lookup uid
                        xC.CreateStringAttr("Name", "Z" + costCustomField.Id.ToString("0"));
                        xC.CreateStringAttr("Type", "Text");
                        m_xHeader1.CreateStringAttr("Z" + costCustomField.Id.ToString("0"), " ");
                        m_xHeader2.CreateStringAttr("Z" + costCustomField.Id.ToString("0"), " " + costCustomField.Name + " ");
                        xC.CreateIntAttr("CanEdit", 0);
                        xC.CreateIntAttr("CanMove", 0);
                        xC.CreateStringAttr("Defaults", costCustomField.jsonLookup);
                        xC.CreateIntAttr("MinWidth", 30);
                        // setting WidthPad to 0 make dropdown button disappear
                        // Seems to be an auto col width sizing bug in treegrid - doesn't take into account button width
                        //xC.CreateIntAttr("WidthPad", 0);
                    }
                    else
                    {
                        // X = custom field
                        xC.CreateStringAttr("Name", "X" + costCustomField.Id.ToString("0"));
                        xC.CreateStringAttr("Type", "Text");
                        m_xHeader1.CreateStringAttr("X" + costCustomField.Id.ToString("0"), " ");
                        m_xHeader2.CreateStringAttr("X" + costCustomField.Id.ToString("0"), " " + costCustomField.Name + " ");
                        xC.CreateIntAttr("CanEdit", 0);
                        xC.CreateIntAttr("CanMove", 0);
                        xC.CreateIntAttr("MinWidth", 25);
                    }
                }
            }

            public void AddPeriodColumn(InternalPeriod period)
            {
                //if (m_bFirstPeriod)
                //{
                //    m_bFirstPeriod = false;
                //    m_sCFormula = "C" + sId;
                //    m_sVFormula = "Q" + sId;
                //}
                //else
                //{
                //    m_sCFormula += "+C" + sId;
                //    m_sVFormula += "+Q" + sId;
                //}

                string sId = period.Id.ToString("0");
                string sName = period.Name;
                m_xHeader1.CreateStringAttr("P" + sId + "Span", "4");
                m_xHeader1.CreateStringAttr("P" + sId, " " + sName);

                m_xHeader2.CreateStringAttr("P" + sId, "");
                m_xHeader2.CreateStringAttr("Q" + sId, " Qty ");
                m_xHeader2.CreateStringAttr("F" + sId, " FTE ");
                m_xHeader2.CreateStringAttr("C" + sId, " Cost ");
                //m_xHeader2.CreateStringAttr("E" + sId, " FTE Conv ");
                //m_xHeader2.CreateStringAttr("R" + sId, " Rate ");

                CStruct xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId);
                xC.CreateIntAttr("Simple", 13);
                xC.CreateIntAttr("Width", 0);
                xC.CreateIntAttr("CanResize", 0);
                xC.CreateIntAttr("ShowHint", 0);

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Q" + sId);
                xC.CreateStringAttr("Type", "Float");
                xC.CreateStringAttr("EditFormat", "0.##");
                xC.CreateStringAttr("Format", ",0.##;<span style='color:red;'>-,0.##</span>;");
                xC.CreateIntAttr("CanMove", 0);
                //xC.CreateIntAttr("CanResize", 0);
                xC.CreateIntAttr("MinWidth", 25);
                xC.CreateIntAttr("Width", 40);
                //if (period.IsStatusPeriod)
                //    xC.CreateBooleanAttr("IsStatusPeriod", true);
                if (period.IsStatusPeriod)
                    xC.CreateBooleanAttr("Current", true);

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "F" + sId);
                xC.CreateStringAttr("Type", "Float");
                xC.CreateStringAttr("EditFormat", "0.###");
                xC.CreateStringAttr("Format", ",0.000;<span style='color:red;'>-,0.000</span>;");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("MinWidth", 25);
                xC.CreateIntAttr("Width", 45);

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "C" + sId);
                xC.CreateStringAttr("Type", "Float");
                xC.CreateStringAttr("EditFormat", "0.##");
                //xC.CreateStringAttr("Format", ",0.##;<span style='color:red;'>-,0.##</span>;");
                xC.CreateStringAttr("Format", ",0;<span style='color:red;'>-,0</span>;");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("MinWidth", 50);
                xC.CreateIntAttr("Width", 70);
            }

            public void FinalizeGridLayout()
            {
                m_xHeader1.CreateStringAttr("PQSpan", "3");
                m_xHeader1.CreateStringAttr("PQ", " Full Totals");

                m_xHeader2.CreateStringAttr("TQ", " Qty ");
                m_xHeader2.CreateStringAttr("TC", " Cost ");

                CStruct xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "PQ");
                xC.CreateIntAttr("Simple", 13);
                xC.CreateIntAttr("Width", 0);
                xC.CreateIntAttr("CanResize", 0);
                xC.CreateIntAttr("ShowHint", 0);

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "TQ");
                xC.CreateStringAttr("Type", "Float");
                //xC.CreateStringAttr("Formula", m_sVFormula);
                xC.CreateStringAttr("Format", ",#.##;<span style='color:red;'>-,#.##</span>;");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("MinWidth", 25);
                xC.CreateIntAttr("Width", 90);

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "TC");
                xC.CreateStringAttr("Type", "Float");
                //xC.CreateStringAttr("Formula", m_sCFormula);
                //xC.CreateStringAttr("Format", ",#.##;<span style='color:red;'>-,#.##</span>;");
                xC.CreateStringAttr("Format", ",#;<span style='color:red;'>-,#</span>;");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("MinWidth", 25);
                xC.CreateIntAttr("Width", 90);

                //m_xDSummaryRow.CreateStringAttr("TCFormula", "sum()");
                //m_xDSummaryRow.CreateStringAttr("TQFormula", "sum()");

            }

            public string GetString()
            {
                return xGrid.XML();
            }
        }

        internal class CostCategory
        {
            public int Uid;
            public int Id;
            public string Name;
            public int Level;
            public string UoM;
            public bool IsSummary;
            //public int Status;
            public bool HasData = false;
            public int Seq;
            public int NamedRateUID;
            public string NamedRateName;
            public int[] CustomCodeValues = new int[5];
            public string[] CustomCodeTextValues = new string[5];
            public string[] CustomTextValues = new string[5];

            public CostCategory Parent = null;
            public List<PeriodRate> periodRates = new List<PeriodRate>();
            public List<PeriodCostValue> periodCostValues = new List<PeriodCostValue>();
        }

        internal class PeriodRate
        {
            public int CostCategoryId;
            public int PeriodId;
            public int FTEConv;
            public double Rate;
        }

        internal class PeriodCostValue
        {
            public int CostCategoryId;
            public int Seq;
            public int PeriodId;
            public double Cost;
            public double Quantity;
        }

        internal class EditCostsData
        {
            private CStruct xGrid;
            private CStruct[] m_xLevels = new CStruct[10];
            private int m_nLevel = 0;
            private int m_nFTEMode = 0;

            public bool InitializeGridData(int CostTypeId, int FTEMode)
            {
                m_nFTEMode = FTEMode;
                xGrid = new CStruct();
                xGrid.Initialize("Grid");
                CStruct xCfg = xGrid.CreateSubStruct("Cfg");
                //xCfg.CreateStringAttr("id", "EditCostsGrid");
                //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());

                CStruct xBody = xGrid.CreateSubStruct("Body");
                CStruct xB = xBody.CreateSubStruct("B");
                CStruct xI = xB.CreateSubStruct("I");
                xI.CreateStringAttr("id", "0");
                xI.CreateStringAttr("Category", "Totals");
                xI.CreateIntAttr("CanEdit", 0);
                xI.CreateStringAttr("Def", "Summary");
                m_nLevel = 1;
                m_xLevels[m_nLevel] = xI;
                return true;
            }

            public void AddCostCategory(CostCategory costCategory, List<CostCustomField> costCustomFields, int nRowId)
            {
                CStruct xIParent = m_xLevels[costCategory.Level - 1];
                CStruct xI = xIParent.CreateSubStruct("I");
                m_xLevels[costCategory.Level] = xI;
                string sId = EncodeIdAndSeq(costCategory.Uid, costCategory.Seq);
                xI.CreateStringAttr("id", sId);
                xI.CreateIntAttr("rowid", costCategory.Uid);
                xI.CreateStringAttr("Category", costCategory.Name);
                xI.CreateStringAttr("uom", costCategory.UoM);
                //xI.CreateBooleanAttr("CanEdit", !costCategory.IsSummary);
                xI.CreateIntAttr("CanEdit", 0);
                //xI.CreateBooleanAttr("CanEdit", true);
                //xI.CreateStringAttr("TestAttr", "Row=" + costCategory.Name);
                if (costCategory.IsSummary)
                    xI.CreateStringAttr("Def", "Summary");
                else
                    xI.CreateStringAttr("Def", "R");

                if (costCategory.HasData == false)
                    xI.CreateBooleanAttr("Visible", false);

                if (costCategory.NamedRateUID > 0)
                {
                    xI.CreateIntAttr("V", costCategory.NamedRateUID);
                    xI.CreateStringAttr("W", costCategory.NamedRateName);
                }

                if (costCustomFields != null)
                {
                    foreach (CostCustomField costCustomField in costCustomFields)
                    {
                        if (costCustomField.Visible == true)
                        {
                            switch (costCustomField.FieldId)
                            {
                                case 11801:
                                case 11802:
                                case 11803:
                                case 11804:
                                case 11805:
                                    int nCode = costCategory.CustomCodeValues[costCustomField.FieldId - 11801];
                                    xI.CreateIntAttr("Y" + costCustomField.Id.ToString("0"), nCode);
                                    string sCodeText = costCategory.CustomCodeTextValues[costCustomField.FieldId - 11801];
                                    if (string.IsNullOrEmpty(sCodeText) == false)
                                        xI.CreateStringAttr("Z" + costCustomField.Id.ToString("0"), sCodeText);
                                    break;
                                case 11811:
                                case 11812:
                                case 11813:
                                case 11814:
                                case 11815:
                                    string sPrefix = (costCustomField.LookupUid > 0) ? "Z" : "X";
                                    string sValue = costCategory.CustomTextValues[costCustomField.FieldId - 11811];
                                    if (string.IsNullOrEmpty(sValue) == false)
                                        xI.CreateStringAttr(sPrefix + costCustomField.Id.ToString("0"), sValue);
                                    break;
                            }
                        }
                    }
                }

                foreach (PeriodRate periodRate in costCategory.periodRates)
                {
                    if (periodRate.Rate != double.MinValue)
                        xI.CreateStringAttr("R" + periodRate.PeriodId.ToString("0"), periodRate.Rate.ToString());
                    if (periodRate.FTEConv != int.MinValue)
                        xI.CreateStringAttr("E" + periodRate.PeriodId.ToString("0"), periodRate.FTEConv.ToString());
                }

                foreach (PeriodCostValue periodCostValue in costCategory.periodCostValues)
                {
                    if (periodCostValue.Quantity != double.MinValue)
                        xI.CreateStringAttr("Q" + periodCostValue.PeriodId.ToString("0"), periodCostValue.Quantity.ToString());
                    if (periodCostValue.Cost != double.MinValue)
                    {
                        xI.CreateStringAttr("C" + periodCostValue.PeriodId.ToString("0"), periodCostValue.Cost.ToString());
                        //xI.CreateIntAttr("Calculated", 1);
                    }
                }
            }

            public string GetString()
            {
                return xGrid.XML();
            }
        }
    }
}

