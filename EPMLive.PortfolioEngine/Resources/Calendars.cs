using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;


namespace PortfolioEngineCore
{
    public class Calendars : PFEBase
    {

        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields


        public Calendars(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading Calendars Class");
            _sqlConnection = _PFECN;
        }

        public Calendars(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading Calendars Class");
            _sqlConnection = _PFECN;
        }


        public bool DeleteCalendar(int iCalendarID)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            // delete any portfolio views 
            string cmdText = "Delete From EPGT_COSTVIEW_DISPLAY Where VIEW_COST_BREAKDOWN =  " + iCalendarID.ToString();
            SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;

            cmdText = "Delete From EPGT_COSTVIEW_COST_TYPES Where VIEW_UID Not In (Select VIEW_UID From EPGT_COSTVIEW_DISPLAY)";
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;

            cmdText = "Update EPGT_VIEW_DISPLAY Set COSTVIEW_UID=0 Where COSTVIEW_UID Not In (Select VIEW_UID From EPGT_COSTVIEW_DISPLAY)";
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();


            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;
            // Delete Model Target entries

            cmdText = "DELETE FROM EPGP_MODEL_TARGET_VALUES  WHERE TARGET_ID IN (SELECT TARGET_ID FROM EPGP_MODEL_TARGETS WHERE CB_ID = " + iCalendarID.ToString() + ")";
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();


            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;
            
            cmdText = "DELETE FROM EPGP_MODEL_TARGET_DETAILS  WHERE TARGET_ID IN (SELECT TARGET_ID FROM EPGP_MODEL_TARGETS WHERE CB_ID = " + iCalendarID.ToString() + ")";
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();


            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;

            cmdText = "Delete From EPGP_MODEL_TARGETS WHERE CB_ID = " + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();


            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;
            // Delete Rates and FTE conversion values for this CB
 
            cmdText = "DELETE FROM EPGP_COST_BREAKDOWN_ATTRIBS WHERE CB_ID =" + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();


            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;
            //  Delete Cost Total specs for all Cost Types using this CB

             
            cmdText = "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CB_ID =" + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;
            // Delete Cost Values for all Cost Types using this CB

             
            cmdText = "DELETE FROM EPGP_COST_VALUES WHERE CB_ID =" + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;

            // Delete 'Budget' status entries

           
            cmdText = "DELETE FROM EPGP_PROJECT_CT_STATUS WHERE CB_ID =" + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;

            // Delete Periods
        
            cmdText = "DELETE FROM EPG_PERIODS WHERE CB_ID =" + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            //if (_dba.Status != StatusEnum.rsSuccess)
            //    return false;

            // now delete the cb dfefn
            

           
            cmdText = "DELETE FROM EPGP_COST_BREAKDOWNS WHERE CB_ID =" + iCalendarID.ToString();
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();
 
            //return (_dba.Status == StatusEnum.rsSuccess);

            return true;

        }

        public int AddCalendar(string sCalendarName, string sCalendarDesc)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            int maxid = 0;

            _dba.BeginTransaction();

            string cmdText = "SELECT MAX(CB_ID) AS MAXID FROM EPGP_COST_BREAKDOWNS";
            SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                maxid = DBAccess.ReadIntValue(reader["MAXID"]);
            }
            reader.Close();

            ++maxid;

            cmdText = "INSERT INTO EPGP_COST_BREAKDOWNS (CB_ID,  CB_NAME, CB_DESC) VALUES(" + maxid.ToString() + ", " + DBAccess.PrepareText(sCalendarName) + ", "
                      + DBAccess.PrepareText(sCalendarDesc) + ")";
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            reader = oCommand.ExecuteReader();

            _dba.CommitTransaction();

            return maxid;

        }

        public bool SaveCalendarPeriods(int iCalendarID, string sCalendarDataXML)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

           CStruct xDataIn = new CStruct();
            if (xDataIn.LoadXML(sCalendarDataXML) == false)
            {

                _dba.Status = StatusEnum.rsRequestInvalidParameter;
                return false;
            }

            CStruct xMainPeriods = xDataIn.GetSubStruct("Periods");
            List<CStruct> xPeriods = xMainPeriods.GetList("Period");
            CPeriod oPer;
            List<CPeriod> oPerList = new List<CPeriod>();

            int iLastPerID = 0;
            DateTime dtLastFinishDate = DateTime.MinValue;


            foreach (CStruct xPer in xPeriods)
            {
                oPer = new CPeriod();

                oPer.PeriodID = xPer.GetIntAttr("ID");

                if (oPer.PeriodID != iLastPerID + 1)
                {
                    _dba.Status = StatusEnum.rsInvalidPeriodID;
                    return false;
                }

                ++iLastPerID;

                oPer.StartDate = xPer.GetDateAttr("StartDate");
                oPer.FinishDate = xPer.GetDateAttr("FinishDate");

                if (oPer.StartDate > oPer.FinishDate)
                {
                    _dba.Status = StatusEnum.rsInvalidPeriodID;
                    return false;
                }

                if (dtLastFinishDate > oPer.FinishDate)
                {
                    _dba.Status = StatusEnum.rsInvalidPeriodID;
                    return false;
                }

                dtLastFinishDate = oPer.FinishDate;

                oPer.PeriodName = xPer.GetStringAttr("Name");

                oPer.Closed = xPer.GetIntAttr("ClosedFlag", 0);
                oPer.ClosedDate = xPer.GetDateAttr("ClosedDate");
                oPer.ClosedName = xPer.GetStringAttr("ClosedName");

                oPerList.Add(oPer);

            }


            string cmdText = "DELETE FROM EPG_PERIODS WHERE CB_ID =" + iCalendarID.ToString();
            SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();

            if (_dba.Status != StatusEnum.rsSuccess)
                return false;

 
            cmdText = "INSERT INTO EPG_PERIODS (CB_ID, PRD_ID, PRD_NAME, PRD_START_DATE, PRD_FINISH_DATE, PRD_CLOSED_DATE, PRD_CLOSED_NAME, PRD_IS_CLOSED) " +
                      "VALUES(" + iCalendarID.ToString() + ",@prd,@prdname,@sdate,@fdate,@cdate,@cname,@iscsd)";

            oCommand = new SqlCommand(cmdText, _sqlConnection);

            SqlParameter pPRD_ID = oCommand.Parameters.Add("@prd", SqlDbType.Int);
            SqlParameter pPRD_NAME = oCommand.Parameters.Add("@prdname", SqlDbType.VarChar, 255);
            SqlParameter pPRD_START_DATE = oCommand.Parameters.Add("@sdate", SqlDbType.DateTime);
            SqlParameter pPRD_FINISH_DATE = oCommand.Parameters.Add("@fdate", SqlDbType.DateTime);
            SqlParameter pPRD_CLOSED_DATE = oCommand.Parameters.Add("@cdate", SqlDbType.DateTime);
            SqlParameter pPRD_CLOSED_NAME = oCommand.Parameters.Add("@cname", SqlDbType.VarChar, 255);
            SqlParameter pPRD_IS_CLOSED = oCommand.Parameters.Add("@iscsd", SqlDbType.TinyInt);

            foreach (CPeriod per in oPerList)
            {
                pPRD_ID.Value = per.PeriodID;
                pPRD_NAME.Value = per.PeriodName;
                pPRD_START_DATE.Value = per.StartDate;
                pPRD_FINISH_DATE.Value = per.FinishDate;

                if (per.ClosedDate == DateTime.MinValue)
                    pPRD_CLOSED_DATE.Value = null;
                else
                    pPRD_CLOSED_DATE.Value = per.ClosedDate;

                if (per.ClosedName == "")
                    pPRD_CLOSED_NAME.Value = null;
                else
                    pPRD_CLOSED_NAME.Value = per.ClosedName;

                pPRD_IS_CLOSED.Value = per.Closed;
                int lRowsAffected = oCommand.ExecuteNonQuery();

                if (_dba.Status != StatusEnum.rsSuccess)
                    return false;
            }

            return true;
        }

        public bool SaveCalendarRatesFTES(int iCalendarID, string sCalendarDataXML)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();


            CStruct xDataIn = new CStruct();
            if (xDataIn.LoadXML(sCalendarDataXML) == false)
            {

                _dba.Status = StatusEnum.rsRequestInvalidParameter;
                return false;
            }

            CStruct xMainFTE = xDataIn.GetSubStruct("FTES");
            List<CStruct> xRnF = xMainFTE.GetList("FTE");


            string cmdText = "DELETE FROM EPGP_COST_BREAKDOWN_ATTRIBS WHERE CB_ID =" + iCalendarID.ToString();
            SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand.ExecuteNonQuery();


            if (_dba.Status != StatusEnum.rsSuccess)
                return false;


            cmdText = "INSERT INTO EPGP_COST_BREAKDOWN_ATTRIBS (CB_ID, BA_RATETYPE_UID, BA_CODE_UID, BA_BC_UID, BA_PRD_ID, BA_FTE_CONV, BA_RATE) " +
                      "VALUES(" + iCalendarID.ToString() + ",@rtu,@cuid,@bcuid,@prd,@fte,@rate)";

            oCommand = new SqlCommand(cmdText, _sqlConnection);

            SqlParameter pBA_RATETYPE_UID = oCommand.Parameters.Add("@rtu", SqlDbType.Int);
            SqlParameter pBA_CODE_UID = oCommand.Parameters.Add("@cuid", SqlDbType.Int);
            SqlParameter pBA_BC_UID = oCommand.Parameters.Add("@bcuid", SqlDbType.Int);
            SqlParameter pBA_PRD_ID = oCommand.Parameters.Add("@prd", SqlDbType.Int);

            SqlParameter pBA_FTE_CONV = oCommand.Parameters.Add("@fte", SqlDbType.Int);
            SqlParameter pBA_RATE = oCommand.Parameters.Add(",@rate", SqlDbType.Decimal);



            foreach (CStruct xData in xRnF)
            {
                pBA_RATETYPE_UID.Value = xData.GetIntAttr("RateTypeUID");
                pBA_CODE_UID.Value = xData.GetIntAttr("CodeUID");
                pBA_BC_UID.Value = xData.GetIntAttr("CategoryUID");
                pBA_PRD_ID.Value = xData.GetIntAttr("PeriodID");

                pBA_FTE_CONV.Value = xData.GetIntAttr("FTEConv");
                pBA_RATE.Value = xData.GetIntAttr("Rate");


                int lRowsAffected = oCommand.ExecuteNonQuery();

                if (_dba.Status != StatusEnum.rsSuccess)
                    return false;
            }
           
            return true;


        }

        public bool ReadCalendarListXML(out string sReply)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xCL = new CStruct();
            CStruct xNode;
            CStruct xPeriods;
            CStruct xPeriod;
            List<CPeriod> clnPeriods;
            xCL.Initialize("Calendars");



            string cmdText = "SELECT * FROM  EPGP_COST_BREAKDOWNS ORDER BY CB_ID";

            SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                xNode = xCL.CreateSubStruct("Calendar");

                int cb_id = DBAccess.ReadIntValue(reader["CB_ID"]);
                string cb_name = DBAccess.ReadStringValue(reader["CB_NAME"]);
                string cb_desc = DBAccess.ReadStringValue(reader["CB_DESC"]);

                xNode.CreateIntAttr("ID", cb_id);
                xNode.CreateStringAttr("Name", cb_name);
                xNode.CreateStringAttr("Desc", cb_desc);
                xPeriods = xNode.CreateSubStruct("Periods");


                if (DBCommon.GetPeriods(_dba, cb_id, out clnPeriods) == StatusEnum.rsSuccess)
                {
                    foreach (CPeriod oPer in clnPeriods)
                    {
                        xPeriod = xPeriods.CreateSubStruct("Period");


                        xPeriod.CreateIntAttr("ID", oPer.PeriodID);
                        xPeriod.CreateStringAttr("Name", oPer.PeriodName);
                        xPeriod.CreateDateAttr("StartDate", oPer.StartDate);
                        xPeriod.CreateDateAttr("FinishDate", oPer.FinishDate);
                        xPeriod.CreateIntAttr("ClosedFlag", oPer.Closed);
                        xPeriod.CreateStringAttr("ClosedName", oPer.ClosedName);
                        xPeriod.CreateDateAttr("ClosedDate", oPer.ClosedDate);

                    }
                }
  
            }
            reader.Close();



            sReply = xCL.XML();
            //return (_dba.Status == StatusEnum.rsSuccess);
            return true;
        }


        public bool ReadCalendarDataXML(int iCalendarID, out string sReply)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xCL = new CStruct();
            CStruct xPar;
            CStruct xNode;
            List<CPeriod> clnPeriods;
            xCL.Initialize("Calendar");

            sReply = "";

            // read periods

            if (DBCommon.GetPeriods(_dba,iCalendarID, out clnPeriods) == StatusEnum.rsSuccess) {
                xPar = xCL.CreateSubStruct("Periods");
                foreach (CPeriod oPer in clnPeriods)
                {
                    xNode = xPar.CreateSubStruct("Period");

   
                    xNode.CreateIntAttr("ID", oPer.PeriodID);
                    xNode.CreateStringAttr("Name", oPer.PeriodName);
                    xNode.CreateDateAttr("StartDate", oPer.StartDate);
                    xNode.CreateDateAttr("FinishDate", oPer.FinishDate);
                    xNode.CreateIntAttr("ClosedFlag", oPer.Closed);
                    xNode.CreateStringAttr("ClosedName", oPer.ClosedName);
                    xNode.CreateDateAttr("ClosedDate", oPer.ClosedDate);
                 
                }
            }
            else
                return false;


            // read the period attributs

            string cmdText = "SELECT * FROM  EPGP_COST_BREAKDOWN_ATTRIBS WHERE CB_ID = " + iCalendarID.ToString() + " ORDER BY BA_BC_UID, BA_PRD_ID";

            SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();
            xPar = xCL.CreateSubStruct("Attributes");
 
            while (reader.Read())
            {
                xNode = xPar.CreateSubStruct("Attribute");

                xNode.CreateIntAttr("PeriodID", DBAccess.ReadIntValue(reader["BA_PRD_ID"]));
                xNode.CreateIntAttr("CategoryUID", DBAccess.ReadIntValue(reader["BA_BC_UID"]));
                xNode.CreateIntAttr("RateTypeUID", DBAccess.ReadIntValue(reader["BA_RATETYPE_UID"]));
                xNode.CreateIntAttr("CodeUID", DBAccess.ReadIntValue(reader["BA_CODE_UID"]));

                xNode.CreateIntAttr("FTEConv", DBAccess.ReadIntValue(reader["BA_FTE_CONV"]));
                xNode.CreateDoubleAttr("Rate", DBAccess.ReadDoubleValue(reader["BA_RATE"]));
           }

            reader.Close();

            cmdText = "SELECT BC_UID, BC_NAME, BC_LEVEL  FROM  EPGP_COST_CATEGORIES ORDER BY BC_ID";

            oCommand = new SqlCommand(cmdText, _sqlConnection);
            reader = oCommand.ExecuteReader();
            xPar = xCL.CreateSubStruct("CostCategories");

            while (reader.Read())
            {
                xNode = xPar.CreateSubStruct("CostCategory");

                xNode.CreateIntAttr("CategoryUID", DBAccess.ReadIntValue(reader["BC_UID"]));
                xNode.CreateStringAttr("CategoryName", DBAccess.ReadStringValue(reader["BC_NAME"]));
                xNode.CreateIntAttr("Level", DBAccess.ReadIntValue(reader["BC_LEVEL"]));
            }

            // and now read the cost gategory structure

            reader.Close();


            sReply = xCL.XML();
            //return (_dba.Status == StatusEnum.rsSuccess);

            return true;
        }

    }
}
