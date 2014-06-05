using System;
using System.Collections.Generic;
//using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;


namespace PortfolioEngineCore.PortfolioItems
{
    internal class CCustomFieldAttr
    {
        public int FA_FIELD_ID;
        public int FA_FIELD_IN_TABLE;
        public int FA_FORMAT;
        public int FA_LEAFONLY;
        public int FA_LOOKUP_UID;
        public int FA_LOOKUPONLY;
        public string FA_NAME;
        public int FA_TABLE_ID;
        public int FA_USEFULLNAME;

    }

    internal class EPKItem
    {
        public int ID;
        public string Name;
        public int Value;
    }

    internal class EPKCustomField
    {
        public int ID;
        public string Name;
        public string FieldName;
        public int Fieldtype;
        public int CFTable;
        public int CFField;
        public int LookupID;
    }


    public class PortfolioItems : PFEBase
    {

        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields

        #region Constructors (1)

        public PortfolioItems(string basepath, string username, string pid, string company, string dbcnstring, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, SecurityLevels.EditPortfolioItems, bDebug)
        {
            debug.AddMessage("Loading PortfolioItems Class");
            _sqlConnection = _PFECN;
        }

        #endregion Constructors

        private const int CONST_PI_MANAGER_SURROGATE_CONTEXT = 4;

        public void ObtainManagedPortfolioItems(out string sExtIDList, out string sPIDList, out string sXML)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();


            bool bSuperPIM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperPIM);
            bool bSuperRM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperRM);

            sExtIDList = "";
            sPIDList = "";
            sXML = "";

            string sProjectIDs = "";
            string sProjectEXTIDs = "";
            string sPIName;

            CStruct xRoot = new CStruct();
            xRoot.Initialize("PIS");
            CStruct xPI;


            string sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID IS NOT NULL OR PROJECT_EXT_UID <> '' ORDER BY PROJECT_NAME";
            int iPid;
            string sExtID;

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            SqlDataReader reader = null;
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                iPid = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                sExtID = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                sPIName = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);

                xPI = xRoot.CreateSubStruct("PI");
                xPI.CreateIntAttr("ID", iPid);
                xPI.CreateStringAttr("EXTID", sExtID);
                xPI.CreateStringAttr("NAME", sPIName);



                if (sProjectIDs == "")
                    sProjectIDs = iPid.ToString();
                else
                    sProjectIDs += "," + iPid.ToString();


                if (sProjectEXTIDs == "")
                    sProjectEXTIDs = sExtID;
                else
                    sProjectEXTIDs += "," + sExtID;

            }

            reader.Close();
            reader = null;

            if (sProjectIDs == "")
                return;

            if (bSuperPIM)
            {
                sPIDList = sProjectIDs;
                sExtIDList = sProjectEXTIDs;
                sXML = xRoot.XML();
                return;
            }

            xRoot = new CStruct();
            xRoot.Initialize("PIS");

            sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS" +
           " LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID" +
           " WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = " + _userWResID.ToString("0") + " OR SU.SURR_WRES_ID = " + _userWResID.ToString("0") + ")" +
           " AND PROJECT_ID in (" + sProjectIDs + ")  ORDER BY PROJECT_NAME";

            oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                iPid = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                sExtID = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                sPIName = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);

                xPI = xRoot.CreateSubStruct("PI");
                xPI.CreateIntAttr("ID", iPid);
                xPI.CreateStringAttr("EXTID", sExtID);
                xPI.CreateStringAttr("NAME", sPIName);

                if (sProjectIDs == "")
                    sPIDList = iPid.ToString();
                else
                    sPIDList += "," + iPid.ToString();


                if (sExtIDList == "")
                    sExtIDList = sExtID;
                else
                    sExtIDList += "," + sExtID;

            }
            reader.Close();

            sXML = xRoot.XML();
        }

        public string GeneratePortfolioItemTicket(string sDataIn)
        {

            try
            {

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                Guid newticket = Guid.NewGuid();


                string cmdText = "INSERT INTO EPG_DATA_CACHE ( DC_TICKET, DC_TIMESTAMP, DC_DATA) " +
                                      " VALUES(@pticket,@ptimest,@pdta)";
                SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);

                SqlParameter pTicketID = oCommand.Parameters.Add("@pticket", SqlDbType.UniqueIdentifier);
                SqlParameter pTimestampID = oCommand.Parameters.Add("@ptimest", SqlDbType.DateTime);
                SqlParameter pDataID = oCommand.Parameters.Add("@pdta", SqlDbType.NText);


                pTicketID.Value = newticket;
                pTimestampID.Value = DateTime.Now;
                pDataID.Value = sDataIn;

                int lRowsAffected = oCommand.ExecuteNonQuery();



                return newticket.ToString();

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string UpdatePortfolioItems(string xml)
        {
            //TODO: Check Security on the PI
            //TODO: Find PI By ID or EXTID
            //TODO: Update PI

            // Ref : WE 4.1 9.2.1.6

            String statusText = "";
            String MissingResNames = "";
            String latchStatusText = "";
            String sGuidList = "";
            String sPIDList = "";

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "Input", xml);

            StatusEnum eStatus = StatusEnum.rsSuccess;

            CStruct xReply = new CStruct();

            CStruct xEPKUpdatePI = new CStruct();
            xEPKUpdatePI.LoadXML(xml);
            Queue<CStruct> clnUpdatePIs = xEPKUpdatePI.GetCollection("Item");

            CStruct xEPKUpdate = new CStruct();
            xEPKUpdate.Initialize("UpdatePortfolioItems");

            try
            {
                string sCommand = "SELECT FA_FIELD_ID, FA_NAME, FA_LOOKUPONLY, FA_LOOKUP_UID, FA_LEAFONLY, FA_USEFULLNAME, FA_TABLE_ID, FA_FIELD_IN_TABLE, FA_FORMAT FROM EPGC_FIELD_ATTRIBS";



                SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlDataReader reader = null;
                reader = oCommand.ExecuteReader();

                CCustomFieldAttr oFieldAttr = null;
                Queue<CCustomFieldAttr> clnFieldAttr = new Queue<CCustomFieldAttr>();


                while (reader.Read())
                {
                    oFieldAttr = new CCustomFieldAttr();

                    oFieldAttr.FA_FIELD_ID = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);
                    oFieldAttr.FA_NAME = DBAccess.ReadStringValue(reader["FA_NAME"]);
                    oFieldAttr.FA_LOOKUPONLY = DBAccess.ReadIntValue(reader["FA_LOOKUPONLY"]);
                    oFieldAttr.FA_LOOKUP_UID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);
                    oFieldAttr.FA_LEAFONLY = DBAccess.ReadIntValue(reader["FA_LEAFONLY"]);
                    oFieldAttr.FA_USEFULLNAME = DBAccess.ReadIntValue(reader["FA_USEFULLNAME"]);
                    oFieldAttr.FA_TABLE_ID = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    oFieldAttr.FA_FIELD_IN_TABLE = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                    oFieldAttr.FA_FORMAT = DBAccess.ReadIntValue(reader["FA_FORMAT"]);

                    clnFieldAttr.Enqueue(oFieldAttr);

                }


                reader.Close();
                reader = null;

                // now for each Item in the collection
                bool bUpdatedViaName = false;

                foreach (CStruct xPI in clnUpdatePIs)
                {
                    string sGuid = xPI.GetStringAttr("EXTID", "");
                    string sListID = xPI.GetStringAttr("ListID", "");

                    sCommand = "UPDATE EPGP_PROJECTS SET PROJECT_MARKED_DELETION = 0 WHERE PROJECT_EXT_UID = @extid";

                    // When a PI is to be updated, then if it does not exists - create in.  If it has been closed, then unclose it.
                    // So basically if always set Marked for Deletion to 0 (i.e. not closed) then if no rows were affected -  need to create the PI

                    oCommand = new SqlCommand(sCommand, _sqlConnection);
                    oCommand.Parameters.AddWithValue("@extid", sGuid);
                    int lRowsAffected = oCommand.ExecuteNonQuery();
                    int iPI = 0;

                    bUpdatedViaName = false;

                    // FIXING BUG: EPML-2952

                    //if (lRowsAffected == 0)
                    //{

                    //    string sTitleValue = "";

                    //    sTitleValue = GetPITitleValue(xPI);

                    //    if (sTitleValue != "")
                    //    {
                    //        sCommand = "UPDATE EPGP_PROJECTS SET PROJECT_MARKED_DELETION = 0, PROJECT_EXT_UID =  '" + sGuid + "' WHERE PROJECT_NAME = " + DBAccess.PrepareText(sTitleValue);

                    //        oCommand = new SqlCommand(sCommand, _sqlConnection);
                    //        lRowsAffected = oCommand.ExecuteNonQuery();
                    //        // bUpdatedViaName = true;
                    //    }
                    //}

                    // DONE FIXING BUG: EPML-2952


                    if (lRowsAffected == 0)
                    {
                        iPI = CreatePI(sGuid, out statusText);
                        _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "CreatedPI", iPI.ToString());
                    }
                    else
                    {
                        sCommand = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @extid";
                        oCommand = new SqlCommand(sCommand, _sqlConnection);
                        oCommand.Parameters.AddWithValue("@extid", sGuid);


                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            iPI = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        }
                        reader.Close();
                        reader = null;
                        _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "UpdatePI", iPI.ToString());
                    }

                    try
                    {


                        if (iPI != 0 && sListID != "")
                        {
                            sCommand = "UPDATE EPGP_PROJECTS SET PROJECT_LIST_ID = @plistid WHERE PROJECT_EXT_UID = @extid";
                            oCommand = new SqlCommand(sCommand, _sqlConnection);
                            oCommand.Parameters.AddWithValue("@plistid", sListID);
                            oCommand.Parameters.AddWithValue("@extid", sGuid);
                            oCommand.ExecuteNonQuery();


                            _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "SetListID", sListID);

                        }

                    }
                    catch (Exception ex)
                    {
                        _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "ErrorSetListID", "ListID: " + sListID + " Error: " + ex.Message);

                    }

                    // so by here we have an unclosed PI that "matches " the item - unless iPI is zero - inwhich case something nasty must have happened - as there was no match!

                    if (iPI == 0)
                    {
                        CStruct xItem = xEPKUpdate.CreateSubStruct("Item");
                        xItem.CreateStringAttr("ItemId", sGuid);
                        xItem.CreateIntAttr("Error", 100);
                        xItem.CreateStringAttr("ErrorText", statusText);


                        if (latchStatusText == "")
                            latchStatusText = statusText;



                    }
                    else if (bUpdatedViaName == false)
                    {

                        int iRes = 0;

                        if (sGuidList == "")
                            sGuidList = sGuid;
                        else
                            sGuidList += "," + sGuid;

                        if (sPIDList == "")
                            sPIDList = iPI.ToString();
                        else
                            sPIDList += "," + iPI.ToString();

                        iRes = UpdatePI(xPI, iPI, clnFieldAttr, out statusText, ref MissingResNames);
                        CStruct xItem = xEPKUpdate.CreateSubStruct("Item");
                        xItem.CreateStringAttr("ItemId", sGuid);
                        xItem.CreateIntAttr("ID", iPI);
                        xItem.CreateIntAttr("Error", iRes);
                        if (iRes != 0)
                        {
                            xItem.CreateStringAttr("ErrorText", statusText);
                            if (iRes != 2)
                            {
                                if (latchStatusText == "")
                                    latchStatusText = statusText;
                            }
                        }

                    }
                    else
                    {
                        CStruct xItem = xEPKUpdate.CreateSubStruct("Item");
                        xItem.CreateStringAttr("ItemId", sGuid);
                        xItem.CreateIntAttr("ID", iPI);
                        xItem.CreateIntAttr("Error", 0);
                    }


                }

                // so by here   sGuidList is a commas sep list of projects with guids changed and sPIDList is a list of commas sep list of Project IDs 
                // and its time to call Kens stuff to post and changes back - though I am not sure it will work - as this is being called from a push from WE 
                // and we are trying to blow back the updates!


                eStatus = ExportPIInfo(_dba, sPIDList, xEPKUpdate);


                if (eStatus != StatusEnum.rsSuccess)
                {

                    // an item was noyt updated and have to insert this code here to be able to propergate the error plus the structure that gives each items status back to WE
                    //                CStruct xUpdateReplyRoot = new CStruct();
                    //                xUpdateReplyRoot.Initialize("Reply", xReply);
                    //                xUpdateReplyRoot.CreateInt("HRESULT", 0);
                    //                xUpdateReplyRoot.CreateInt("STATUS", 1);   // jason wants a failure to return a status of 1
                    //                xUpdateReplyRoot.CreateString("Error", latchStatusText);
                    //                xUpdateReplyRoot.CreateString("UserName", _username);
                    //                if (MissingResNames.Length != 0)
                    //                    xUpdateReplyRoot.CreateString("MissingResources", MissingResNames);

                    //                xUpdateReplyRoot.AppendSubStruct(xEPKUpdate);

                    //                return xUpdateReplyRoot.XML();



                    xEPKUpdate.CreateInt("HRESULT", 0);
                    xEPKUpdate.CreateInt("STATUS", 1);   // jason wants a failure to return a status of 1
                    xEPKUpdate.CreateString("Error", latchStatusText);
                    xEPKUpdate.CreateString("UserName", _username);
                    if (MissingResNames.Length != 0)
                        xEPKUpdate.CreateString("MissingResources", MissingResNames);


                    _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "ErrReturn", xEPKUpdate.XML());

                    _sqlConnection.Close();
                    return xEPKUpdate.XML();

                }

                if (MissingResNames.Length != 0)
                {

                    // an item was noyt updated and have to insert this code here to be able to propergate the error plus the structure that gives each items status back to WE
                    //CStruct xUpdateReplyRoot = new CStruct();
                    //xUpdateReplyRoot.Initialize("Reply", xReply);
                    //xUpdateReplyRoot.CreateInt("HRESULT", 0);
                    //xUpdateReplyRoot.CreateInt("STATUS", 0);   // jason wants a failure to return a status of 1
                    //xUpdateReplyRoot.CreateString("UserName", _username);
                    //xUpdateReplyRoot.CreateString("MissingResources", MissingResNames);
                    //xUpdateReplyRoot.AppendSubStruct(xEPKUpdate);

                    //return xUpdateReplyRoot.XML();

                    xEPKUpdate.CreateInt("HRESULT", 0);
                    xEPKUpdate.CreateInt("STATUS", 0);   // jason wants a failure to return a status of 1
                    xEPKUpdate.CreateString("UserName", _username);
                    xEPKUpdate.CreateString("MissingResources", MissingResNames);

                    _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "MissingNamesReturn", xEPKUpdate.XML());
                    _sqlConnection.Close();
                    return xEPKUpdate.XML();

                }

            }
            catch (Exception ex)
            {
                _dba.HandleException("UpdatePortfolioItems", (StatusEnum)9999, ex);
                return "<UpdatePortfolioItems Status='1'></UpdatePortfolioItems>";
            }


            xEPKUpdate.CreateInt("HRESULT", 0);
            xEPKUpdate.CreateInt("STATUS", 0);
            xEPKUpdate.CreateString("UserName", _username);

            _dba.WriteImmTrace("PortfolioItems", "UpdatePortfolioItems", "Return", xEPKUpdate.XML());


            _sqlConnection.Close();
            return xEPKUpdate.XML();

            //          return "<UpdatePortfolioItems Status='0'></UpdatePortfolioItems>";
        }

        public string ClosePortfolioItems(string xml)
        {
            //TODO: Check Security on the PI
            //TODO: Find PI By ID or EXTID
            //TODO: Close PI

            // Ref : WE 4.1 9.2.1.7

            CStruct xEPKClosePI = new CStruct();

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            xEPKClosePI.LoadXML(xml);
            Queue<CStruct> clnClosePIs = xEPKClosePI.GetCollection("Item");
            CStruct xEPKUpdate = new CStruct();
            xEPKUpdate.Initialize("ClosePortfolioItems");

            try
            {

                foreach (CStruct xPI in clnClosePIs)
                {
                    string sGuid = xPI.GetStringAttr("ID", "");

                    if (sGuid != "")
                    {
                        string sCommand = "UPDATE EPGP_PROJECTS SET PROJECT_MARKED_DELETION = 1 WHERE PROJECT_EXT_UID = @extid";

                        SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);

                        oCommand.Parameters.AddWithValue("@extid", sGuid);
                        int lRowsAffected = oCommand.ExecuteNonQuery();
                        oCommand = null;

                        CStruct xItem = xEPKUpdate.CreateSubStruct("Item");
                        xItem.CreateStringAttr("ItemId", sGuid);
                        xItem.CreateIntAttr("Error", 0);
                    }
                }

                // this used to return <Reply Result=0><ClosePortfolioItems><Item ItemID=guid etc.....
                // now returns "<ClosePortfolioItems Status='0'></ClosePortfolioItems>"

                //          CStruct xUpdateReplyRoot = new CStruct();
                //          xUpdateReplyRoot.Initialize("Reply", xReply);
                //          xUpdateReplyRoot.CreateInt("HRESULT", 0);
                xEPKUpdate.CreateInt("STATUS", 0);
                //          xUpdateReplyRoot.AppendSubStruct(xEPKUpdate);

                //          return xUpdateReplyRoot.XML();
                return xEPKUpdate.XML();

            }
            catch (Exception ex)
            {
                return "<ClosePortfolioItems><STATUS>1</STATUS><Error>" + ex.Message + "</Error></ClosePortfolioItems>";
            }


            //    return "<ClosePortfolioItems Status='0'></ClosePortfolioItems>";
        }

        public string CreateUpdateUpdatePortfolioItemsXML(string pids)
        {

            try
            {

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                StatusEnum eStatus = StatusEnum.rsSuccess;

                //CStruct xEPKUpdate = new CStruct();
                //xEPKUpdate.Initialize("UpdatePortfolioItems");
                string sXML;
                dbaUsers.ExportPIInfo(_dba, pids, out sXML);
                //xEPKUpdate.CreateInt("HRESULT", 0);
                //xEPKUpdate.CreateInt("STATUS", 0);
                //xEPKUpdate.CreateString("UserName", _username);

                //return xEPKUpdate.XML();
                return sXML;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private int CreatePI(string sGuid, out string statusText)
        {

            statusText = "";
            try
            {

                string[] sTabList;
                sTabList = new string[5];


                sTabList[0] = "EPGP_PROJECT_INT_VALUES";
                sTabList[1] = "EPGP_PROJECT_TEXT_VALUES";
                sTabList[2] = "EPGP_PROJECT_NTEXT_VALUES";
                sTabList[3] = "EPGP_PROJECT_DATE_VALUES";
                sTabList[4] = "EPGP_PROJECT_DEC_VALUES";

                int lUseStage = 1;

                string sCommand = "SELECT STAGE_ID FROM EPGP_STAGES Where (STAGE_SEQ = 1)";
                SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);

                SqlDataReader reader = null;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    lUseStage = DBAccess.ReadIntValue(reader["STAGE_ID"]);
                }
                reader.Close();
                reader = null;

                int iPI = 0;


                sCommand = "SELECT MAX(PROJECT_ID) AS EXPR1 FROM EPGP_PROJECTS";
                oCommand = new SqlCommand(sCommand, _sqlConnection);

                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    iPI = DBAccess.ReadIntValue(reader["EXPR1"]);
                }
                reader.Close();
                reader = null;
                 
                iPI = iPI + 1;

                //if (iPI == 1)
                //{
                //    sCommand = "DELETE FROM EPGP_PROJECT_STAGES";
                //    oCommand = new SqlCommand(sCommand, _sqlConnection);
                //    lRowsAffected = oCommand.ExecuteNonQuery();

                //    for (int lstloop = 0; lstloop <= 4; ++lstloop)
                //    {
                //        sCommand = "DELETE FROM " + sTabList[lstloop];
                //        oCommand = new SqlCommand(sCommand, _sqlConnection);
                //        lRowsAffected = oCommand.ExecuteNonQuery();
                //    }
                //}


                sCommand = "INSERT INTO EPGP_PROJECTS (PROJECT_ID, PROJECT_NAME, PROJECT_MARKED_DELETION, PROJECT_STAGE_ID, PROJECT_CREATEDBY,PROJECT_OWNER,PROJECT_MANAGER, PROJECT_CREATED, PROJECT_EXT_UID)" +
                            " VALUES(" + iPI.ToString() + ", 'Creating Item for WE4.3', 0, " + lUseStage.ToString() + ", " + _dba.UserWResID.ToString() + ", " + _dba.UserWResID.ToString() +
                            ", " + _dba.UserWResID.ToString() + ", @pcre, '" + sGuid + "')";
                oCommand = new SqlCommand(sCommand, _sqlConnection);
                oCommand.Parameters.AddWithValue("@pcre", DateTime.Now);
                int lRowsAffected = oCommand.ExecuteNonQuery();

                sCommand = "DELETE FROM EPGP_PROJECT_STAGES WHERE PROJECT_ID = " + iPI.ToString();
                oCommand = new SqlCommand(sCommand, _sqlConnection);
                lRowsAffected = oCommand.ExecuteNonQuery();

                sCommand = "INSERT into EPGP_PROJECT_STAGES (PROJECT_ID,STAGE_ID,WRES_ID,STAGE_OWNER,STAGE_DATE)" +
                           "VALUES(" + iPI.ToString() + ", " + lUseStage.ToString() + ", " + _dba.UserWResID.ToString() + ", " + _dba.UserWResID.ToString() + ",@sdate)";

                oCommand = new SqlCommand(sCommand, _sqlConnection);
                oCommand.Parameters.AddWithValue("@sdate", DateTime.Now);
                lRowsAffected = oCommand.ExecuteNonQuery();




                for (int lstloop = 0; lstloop <= 4; ++lstloop)
                {
                    sCommand = "DELETE FROM " + sTabList[lstloop] + " WHERE PROJECT_ID = " + iPI.ToString();
                    oCommand = new SqlCommand(sCommand, _sqlConnection);
                    lRowsAffected = oCommand.ExecuteNonQuery();


                    sCommand = "insert into " + sTabList[lstloop] + " (PROJECT_ID) VALUES(" + iPI.ToString() + ")";

                    oCommand = new SqlCommand(sCommand, _sqlConnection);
                    lRowsAffected = oCommand.ExecuteNonQuery();
                }

                return iPI;
            }

            catch (Exception ex)
            {
                statusText = ex.Message.ToString();
                _dba.HandleException("CMain.CreatePI", (StatusEnum)9999, ex);
                statusText = "Create PI failed with Error = " + statusText;
            }
            return 0;
        }

        private string GetPITitleValue(CStruct xPI)
        {


            Queue<CStruct> clnUpdateFields = xPI.GetCollection("");

            foreach (CStruct UpdateField in clnUpdateFields)
            {
                string sNodeName = UpdateField.Name;
                string sText = UpdateField.InnerText;

                if (sNodeName == "Title")
                {
                    return sText;
                }
            }



            return "";
        }

        private int StripNum(ref string sin)
        {
            try
            {
                if (sin == "")
                    return 0;


                int i = 0;
                string sval = "";

                sin = sin.Trim();
                i = sin.IndexOf(" ");

                if (i == -1)
                {
                    sval = sin;
                    sin = "";

                    if (sval == "")
                        return 0;
                }
                else
                {
                    sval = sin.Substring(0, i);
                    sin = sin.Substring(i + 1); //, sin.Length - i);
                }

                return int.Parse(sval);
            }
            catch (Exception ex)
            {
                sin = "";
                return 0;
            }
        }

        private int UpdatePI(CStruct xPI, int iPID, Queue<CCustomFieldAttr> clnFieldAttr, out string statusText, ref string MissingResNames)
        {
            //           const int CONST_PORT_NAME = 9900;
            const int CONST_PORT_START = 9901;
            const int CONST_PORT_FINISH = 9902;
            //            const  int CONST_PORT_PORTID = 9903;
            const int CONST_PORT_PORTPCOMP = 9904;
            const int CONST_PORT_STATUS = 9910;
            const int CONST_PORT_STAGE = 9911;
            const int CONST_PORT_WORKFLOW = 9912;
            const int CONST_PORT_EV_GROUP = 9913;
            const int CONST_PORT_MAJORCATEGORY = 9919;
            const int CONST_PORT_CREATEDBY = 9920;
            const int CONST_PORT_CREATED = 9921;
            const int CONST_PORT_OWNER = 9922;
            //            const  int CONST_PORT_LINKED_PROJ = 9923;
            //            const  int CONST_PORT_LINKED_PROJ_IND = 9924;
            const int CONST_PORT_PROJ_MANAGER = 9925;
            const int CONST_PORT_PROJ_PRIORITY = 9928;
            //           const int CONST_PORT_WI_WORK = 9934;
            const int CONST_PORT_CHARGENUMBER = 9926;
            const int CONST_PORT_CHARGESTATUS = 9927;
            const int CONST_PROJ_PLAN_CHARGESTATUS = 9929;
            const int CONST_PROJECT_PLAN_OWNER = 9930;


            statusText = "";
            int iRes = 0;
            int iFid = 0;
            string sText = "";
            string sCommand = "";

            try
            {
                // delete any pervios delegates for this PI


                SqlCommand oCommand = null;
                int lRowsAffected = 0;

                sCommand = "DELETE FROM EPG_DELEGATES Where (SURR_CONTEXT_VALUE = " + iPID.ToString() + ") AND (SURR_CONTEXT = " + CONST_PI_MANAGER_SURROGATE_CONTEXT.ToString() + ")";

                oCommand = new SqlCommand(sCommand, _sqlConnection);
                lRowsAffected = oCommand.ExecuteNonQuery();

                oCommand = null;

                string[] sTabList;
                sTabList = new string[6];
                bool[] bTabTouched;
                bTabTouched = new bool[6];
                string sPostFix = " WHERE PROJECT_ID = " + iPID.ToString();


                sTabList[0] = "UPDATE EPGP_PROJECTS SET ";
                sTabList[1] = "UPDATE EPGP_PROJECT_INT_VALUES SET ";
                sTabList[2] = "UPDATE EPGP_PROJECT_TEXT_VALUES SET ";
                sTabList[3] = "UPDATE EPGP_PROJECT_DEC_VALUES SET ";
                sTabList[4] = "UPDATE EPGP_PROJECT_NTEXT_VALUES SET ";
                sTabList[5] = "UPDATE EPGP_PROJECT_DATE_VALUES SET ";


                for (int i = 0; i <= 5; i++)
                {
                    bTabTouched[i] = false;
                }

                Queue<CStruct> clnUpdateFields = xPI.GetCollection("");

                foreach (CStruct UpdateField in clnUpdateFields)
                {
                    string sNodeName = UpdateField.Name;
                    sText = UpdateField.InnerText;

                    if (sNodeName == "Title")
                    {
                        if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                        sTabList[0] = sTabList[0] + "PROJECT_NAME = " + DBAccess.PrepareText(sText);
                    }
                    else if (sNodeName == "Team")
                    {

                        sText = sText.Replace(",", " ").Trim();

                        sCommand = "DELETE FROM EPGP_TEAMS Where (PROJECT_ID = " + iPID.ToString() +
                                          ") AND (RES_IN_PLAN = 0 OR RES_IN_PLAN IS NULL)";

                        oCommand = new SqlCommand(sCommand, _sqlConnection);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        sCommand = "INSERT into EPGP_TEAMS (PROJECT_ID,WRES_ID, RES_IN_PLAN) " +
                        "VALUES(" + iPID.ToString() + ",@wresid,0)";


                        oCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlParameter pWRES_ID = oCommand.Parameters.Add("@wresid", SqlDbType.Int);

                        while (sText != "")
                        {
                            int wid = StripNum(ref sText);

                            if (wid != 0)
                            {

                                pWRES_ID.Value = wid;
                                lRowsAffected = oCommand.ExecuteNonQuery();
                            }
                        }

                        sCommand = "DELETE FROM EPGP_TEAMS Where (PROJECT_ID = " + iPID.ToString() +
                                   ") AND (RES_IN_PLAN = 0 OR RES_IN_PLAN IS NULL) And WRES_ID In " +
                                   "(Select WRES_ID From EPGP_TEAMS Where PROJECT_ID = " + iPID.ToString() +
                                   " AND RES_IN_PLAN = 1)";

                        oCommand = new SqlCommand(sCommand, _sqlConnection);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                    }

                    else if (sNodeName == "Field")
                    {
                        iFid = UpdateField.GetIntAttr("Name");
                        bool bFound = false;

                        if (iFid < 20000)
                        {
                            bFound = true;

                            if (iFid == CONST_PORT_EV_GROUP)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_EV_GROUP = " + DoIntStuff(sText).ToString();
                            }
                            else if (iFid == CONST_PORT_PORTPCOMP)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_PERCENT_COMPLETE = " + DoIntStuff(sText).ToString();
                            }
                            else if (iFid == CONST_PORT_CHARGESTATUS)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_CHARGESTATUS = " + DBAccess.PrepareText(sText);
                            }
                            else if (iFid == CONST_PORT_CHARGENUMBER)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_CHARGENUMBER = " + DBAccess.PrepareText(sText);
                            }
                            else if (iFid == CONST_PROJ_PLAN_CHARGESTATUS)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_PLAN_CHARGESTATUS = " + DBAccess.PrepareText(sText);
                            }
                            else if (iFid == CONST_PORT_OWNER)
                            {

                                String sRName = "";

                                sRName = ResolveNameAndDelegates(sText, ref MissingResNames, iPID, CONST_PI_MANAGER_SURROGATE_CONTEXT, false).ToString();

                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_OWNER = " + sRName;
                            }
                            else if (iFid == CONST_PORT_PROJ_MANAGER)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_MANAGER = " + ResolveNameAndDelegates(sText, ref MissingResNames, iPID, CONST_PI_MANAGER_SURROGATE_CONTEXT, true).ToString();
                            }
                            //if (iFid == CONST_PORT_NAME) 
                            //{
                            //    if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                            //    sTabList[0] = sTabList[0] + "PROJECT_NAME = " + sText;
                            //}
                            else if (iFid == CONST_PORT_MAJORCATEGORY)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_MAJORCATEGORY = " + DBAccess.PrepareText(sText);
                            }
                            else if (iFid == CONST_PORT_START)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_START_DATE = " + InsertDateString(sText);
                            }
                            else if (iFid == CONST_PORT_FINISH)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_FINISH_DATE = " + InsertDateString(sText);
                            }
                            else if (iFid == CONST_PORT_STATUS)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_STATUS = " + DoIntStuff(sText).ToString();
                            }
                            else if (iFid == CONST_PORT_STAGE)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_STAGE_ID = " + DoIntStuff(sText).ToString();
                            }
                            else if (iFid == CONST_PORT_WORKFLOW)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_WORKFLOW = " + DoIntStuff(sText).ToString();
                            }
                            else if (iFid == CONST_PORT_CREATEDBY)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_CREATEDBY = " + ResolveResName(sText, ref MissingResNames).ToString();
                            }
                            else if (iFid == CONST_PORT_CREATED)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_CREATED = " + InsertDateString(sText);
                            }
                            else if (iFid == CONST_PROJECT_PLAN_OWNER)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_PLAN_OWNER = " + ResolveNameAndDelegates(sText, ref MissingResNames, iPID, CONST_PI_MANAGER_SURROGATE_CONTEXT, false).ToString();
                            }
                            else if (iFid == CONST_PORT_PROJ_PRIORITY)
                            {
                                if (bTabTouched[0] == false) bTabTouched[0] = true; else sTabList[0] = sTabList[0] + ", ";
                                sTabList[0] = sTabList[0] + "PROJECT_PRIORITY = " + DoIntStuff(sText).ToString();

                            }


                            else
                            {
                                iRes = 2;
                                statusText = "Field Name " + iFid.ToString() + " not found";
                                bFound = false;

                            }
                        }

                        else
                        {

                            foreach (CCustomFieldAttr xAttr in clnFieldAttr)
                            {
                                if (iFid == xAttr.FA_FIELD_ID)
                                {
                                    switch (xAttr.FA_TABLE_ID)
                                    {
                                        case 0:
                                            iRes = 1;
                                            break;

                                        case 201:
                                            if (bTabTouched[1] == false)
                                                bTabTouched[1] = true;
                                            else
                                                sTabList[1] = sTabList[1] + ", ";

                                            if (xAttr.FA_FORMAT == 13)
                                                sTabList[1] = sTabList[1] + "PI_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + DoFlagStuff(sText).ToString();
                                            else if (xAttr.FA_FORMAT == 7)
                                                sTabList[1] = sTabList[1] + "PI_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + ResolveResName(sText, ref MissingResNames).ToString();
                                            else
                                                sTabList[1] = sTabList[1] + "PI_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + DoIntStuff(sText).ToString();

                                            break;

                                        case 202:
                                            if (bTabTouched[2] == false)
                                                bTabTouched[2] = true;
                                            else
                                                sTabList[2] = sTabList[2] + ", ";

                                            sTabList[2] = sTabList[2] + "PT_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + DBAccess.PrepareText(sText);

                                            break;

                                        case 203:
                                            if (bTabTouched[3] == false)
                                                bTabTouched[3] = true;
                                            else
                                                sTabList[3] = sTabList[3] + ", ";

                                            sTabList[3] = sTabList[3] + "PC_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + DoDoubleStuff(sText).ToString();


                                            break;

                                        case 204:
                                            if (bTabTouched[4] == false)
                                                bTabTouched[4] = true;
                                            else
                                                sTabList[4] = sTabList[4] + ", ";

                                            sTabList[4] = sTabList[4] + "PN_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + DBAccess.PrepareText(sText);

                                            break;

                                        case 205:
                                            if (bTabTouched[5] == false)
                                                bTabTouched[5] = true;
                                            else
                                                sTabList[5] = sTabList[5] + ", ";

                                            sTabList[5] = sTabList[5] + "PD_" + FormatAs000(xAttr.FA_FIELD_IN_TABLE) + " = " + InsertDateString(sText);
                                            break;

                                        default:

                                            iRes = 2;
                                            statusText = "Field Name " + iFid.ToString() + " not found";
                                            break;

                                    }

                                    bFound = true;
                                    break;
                                }
                            }
                        }

                        if (bFound == false)
                        {
                            iRes = 2;
                            statusText = "Field Name " + iFid.ToString() + " not found";
                            break;
                        }
                    }
                }



                for (int i = 0; i <= 5; i++)
                {
                    if (bTabTouched[i] == true)
                    {
                        sCommand = sTabList[i] + sPostFix;
                        oCommand = new SqlCommand(sCommand, _sqlConnection);
                        lRowsAffected = oCommand.ExecuteNonQuery();
                    }

                }

                PerformCustomFieldsCalculate(iPID);

                return iRes;
            }

            catch (Exception ex)
            {
                statusText = ex.Message.ToString();
                _dba.HandleException("CMain.UpdatePI", (StatusEnum)9999, ex);
                statusText = "Field Name = " + iFid.ToString() + " Value = " + sText + " Error = " + statusText;
            }
            return 1;
        }

        private StatusEnum PerformCustomFieldsCalculate(int iPID)
        {

            List<string> sqlstatements = new List<string>();
            string seqStmt = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            int lastuid = -1;
            int uid = 0;
            int fit = 0;
            int fat = 0;
            double dRatio = 0;
            int seq = 0;
            int op = 0;
            string sOp = "";

            string sCommand = "SELECT     EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ, EPGP_CALCS.CL_RESULT, EPGC_FIELD_ATTRIBS.FA_FIELD_IN_TABLE, " +
                      "EPGP_CALCS.CL_COMPONENT, EPGC_FIELD_ATTRIBS_1.FA_FIELD_IN_TABLE AS Expr1, EPGP_CALCS.CL_RATIO, EPGP_CALCS.CL_OP, " +
                      "EPGC_FIELD_ATTRIBS_1.FA_TABLE_ID AS EXFAT " +
                      "FROM         EPGP_CALCS INNER JOIN " +
                      "EPGC_FIELD_ATTRIBS ON EPGP_CALCS.CL_RESULT = EPGC_FIELD_ATTRIBS.FA_FIELD_ID LEFT JOIN " +
                      "EPGC_FIELD_ATTRIBS AS EPGC_FIELD_ATTRIBS_1 ON EPGP_CALCS.CL_COMPONENT = EPGC_FIELD_ATTRIBS_1.FA_FIELD_ID " +
                      "Where (EPGP_CALCS.CL_OBJECT = 1) ";


            sCommand += " ORDER BY EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ";


            oCommand = new SqlCommand(sCommand, _sqlConnection);
            reader = oCommand.ExecuteReader();

            string sWherecluase = "";
            string sErrSQL = "";

            while (reader.Read())
            {
                uid = DBAccess.ReadIntValue(reader["CL_UID"]);

                if (lastuid != uid)
                {

                    if (seqStmt != "")
                    {
                        seqStmt += "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";

                        if (sWherecluase != "")
                            sqlstatements.Add(seqStmt + " WHERE EPGP_PROJECT_DEC_VALUES.PROJECT_ID = " + iPID.ToString());
                        else
                            sqlstatements.Add(seqStmt + sWherecluase + " AND EPGP_PROJECT_DEC_VALUES.PROJECT_ID = " + iPID.ToString());

                        if (sWherecluase != "")
                            sqlstatements.Add(sErrSQL + sWherecluase + " AND EPGP_PROJECT_DEC_VALUES.PROJECT_ID = " + iPID.ToString());
                    }


                    seqStmt = "";
                    sWherecluase = "";

                    lastuid = uid;

                    fit = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);

                    seqStmt = "UPDATE EPGP_PROJECT_DEC_VALUES SET PC_" + fit.ToString("000") + " = ";
                    sErrSQL = "UPDATE EPGP_PROJECT_DEC_VALUES SET PC_" + fit.ToString("000") + " = 999999 ";

                }



                seq = DBAccess.ReadIntValue(reader["CL_SEQ"]);
                op = DBAccess.ReadIntValue(reader["CL_OP"]);

                if (seq != 1)
                {
                    if (op == 1)
                        sOp = " - ";
                    else if (op == 2)
                        sOp = " * ";
                    else if (op == 3)
                        sOp = " / ";
                    else
                        sOp = " + ";


                    seqStmt += sOp;
                }

                fit = DBAccess.ReadIntValue(reader["Expr1"]);
                fat = DBAccess.ReadIntValue(reader["EXFAT"]);

                dRatio = DBAccess.ReadDoubleValue(reader["CL_RATIO"]);

                if (fit == 0)
                    seqStmt += dRatio.ToString();
                else
                {

                    string sval = GetCustFieldVal(fit, fat); //  "PC_" + fit.ToString("000");

                    seqStmt += "(" + sval + " * " + dRatio.ToString() + ")";

                    if (seq != 1)
                    {
                        if (op == 3)
                        {
                            if (sWherecluase == "")
                                sWherecluase = " WHERE (" + sval + "<> 0) ";
                            else
                                sWherecluase += " AND (" + sval + "<> 0) ";
                        }
                    }

                }


            }

            if (seqStmt != "")
            {
                seqStmt += "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";

                if (sWherecluase != "")
                    sqlstatements.Add(seqStmt + " WHERE EPGP_PROJECT_DEC_VALUES.PROJECT_ID = " + iPID.ToString());
                else
                    sqlstatements.Add(seqStmt + sWherecluase + " AND EPGP_PROJECT_DEC_VALUES.PROJECT_ID = " + iPID.ToString());

                if (sWherecluase != "")
                    sqlstatements.Add(sErrSQL + sWherecluase + " AND EPGP_PROJECT_DEC_VALUES.PROJECT_ID = " + iPID.ToString());

            }



            reader.Close();
            reader = null;


            foreach (string sql in sqlstatements)
            {


                oCommand = new SqlCommand(sql, _sqlConnection);
                int lRowsAffected = oCommand.ExecuteNonQuery();
            }


            return _dba.Status;
        }

        private static string GetCustFieldVal(int lfit, int lfat)
        {
            string sfn = "0";
            if (lfat == 203)
                sfn = "PC_" + lfit.ToString("000");
            else if (lfat == 202)
            {
                //sfn = "CAST(PT_" + lfit.ToString("000") + " AS int)";

                //  want: IsNull(cast(Left(PT_003, PatIndex('%[^0-9]%', PT_003+'x' ) - 1 ) as int),0)
                sfn = "IsNull(cast(Left(PT_" + lfit.ToString("000") + ", PatIndex('%[^0-9]%', PT_" + lfit.ToString("000") + "+'x' ) - 1 ) as int),0)";
            }

            return sfn;
        }

        private string FormatAs000(int inval)
        {

            string s = inval.ToString();

            while (s.Length < 3)
                s = "0" + s;

            return s;
        }


        private string InsertDateString(string sIn)
        {


            IFormatProvider culture = new CultureInfo(1044, false);
            DateTime dt;

            sIn = sIn.Trim();

            if (sIn.Length == 0)
                return "NULL";


            dt = DateTime.ParseExact(sIn, "yyyy-MM-ddTHH:mm:ss", culture);


            string ret = "CONVERT(DATETIME, '";
            ret = ret + dt.ToString("yyyy-MM-dd HH:mm:ss");

            ret = ret + "', 102)";

            return ret;
        }

        private int ResolveResName(string resName, ref string missingnames)
        {
            try
            {

                resName = resName.Trim();

                if (resName == "")
                    return 0;

                string sCommand = "SELECT WRES_ID FROM EPG_RESOURCES Where ( { fn UCASE(WRES_NT_ACCOUNT) } = '" + resName.ToUpper() + "')";
                int resId = 0;
                SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);

                SqlDataReader reader = null;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    resId = DBAccess.ReadIntValue(reader["WRES_ID"]);
                }
                reader.Close();
                reader = null;

                if (resId == 0)
                {
                    if (missingnames.IndexOf(resName) == -1)
                    {
                        if (missingnames == "")
                            missingnames = resName;
                        else
                            missingnames = missingnames + "," + resName;
                    }
                }


                return resId;

            }

            catch (Exception ex)
            {
                _dba.HandleException("CMain.ResolveResName", (StatusEnum)9999, ex);
                return 0;
            }
        }

        private int ResolveNameAndDelegates(string resName, ref string missingnames, int iPI, int surrContext, bool bDoDelegateWrite)
        {
            try
            {
                int latchedRId = 0;
                int delegatecnt = 0;
                string sCommand = "";
                int lRowsAffected = 0;

                SqlCommand oCommand = null;

                resName = resName.Trim();

                if (resName == "")
                    return 0;

                string[] reslist = resName.Split(',');

                for (int i = 0; i < reslist.Length; i++)
                {
                    resName = reslist[i];
                    if (resName != "")
                    {
                        sCommand = "SELECT WRES_ID FROM EPG_RESOURCES Where ( { fn UCASE(WRES_NT_ACCOUNT) } = '" + resName.ToUpper() + "')";
                        int resId = 0;
                        oCommand = new SqlCommand(sCommand, _sqlConnection);

                        SqlDataReader reader = null;
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            resId = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        }
                        reader.Close();
                        reader = null;
                        oCommand = null;

                        if (resId == 0)
                        {
                            if (missingnames.IndexOf(resName) == -1)
                            {
                                if (missingnames == "")
                                    missingnames = resName;
                                else
                                    missingnames = missingnames + "," + resName;
                            }
                        }
                        else
                        {
                            if (latchedRId == 0)
                                latchedRId = resId;
                            else if (bDoDelegateWrite == true)
                            {
                                // time to insert into the delegate table

                                ++delegatecnt;

                                sCommand =
                                    "INSERT INTO EPG_DELEGATES (WRES_ID, SURR_ID, SURR_ASSN_DATE, SURR_WRES_ID, SURR_CONTEXT, SURR_CONTEXT_VALUE) " +
                                    "VALUES(" + latchedRId.ToString() + ", " + delegatecnt.ToString() + ", GetDate(), " +
                                    resId.ToString() + ", " + surrContext.ToString() + ", " + iPI.ToString() + ")";

                                oCommand = new SqlCommand(sCommand, _sqlConnection);
                                lRowsAffected = oCommand.ExecuteNonQuery();

                                oCommand = null;

                            }
                        }

                    }
                }

                return latchedRId;

            }

            catch (Exception ex)
            {
                _dba.HandleException("CMain.ResolveNameAndDelegates", (StatusEnum)9999, ex);
                return 0;
            }
        }

        private int DoFlagStuff(string sFlag)
        {
            try
            {

                sFlag = sFlag.Trim();

                if (sFlag == "")
                    return 0;

                string sFC = "";
                sFC = sFlag.Substring(0, 1);


                if (sFC == "1" || sFC == "Y" || sFC == "y")
                    return 1;
                else
                    return 0;
            }

            catch
            {
                return 0;
            }

        }

        private int DoIntStuff(string sNum)
        {
            try
            {
                string swrk = "";
                string sDigits = "0123456789";
                sNum = sNum.Trim();

                Boolean bFound = false;



                for (int i = 0; i < sNum.Length; i++)
                {
                    if (sDigits.IndexOf(sNum[i]) == -1)
                    {
                        if (bFound)
                            break;
                    }
                    else
                    {
                        swrk = swrk + sNum.Substring(i, 1);
                        bFound = true;
                    }
                }


                if (swrk == "")
                    return 0;

                return Int32.Parse(swrk);
            }

            catch
            {
                return 0;
            }

        }

        private double DoDoubleStuff(string sNum)
        {
            try
            {
                string swrk = "";
                string sDigits = "0123456789";

                sNum = sNum.Trim();

                Boolean bFound = false;


                for (int i = 0; i < sNum.Length; i++)
                {
                    if (sDigits.IndexOf(sNum[i]) == -1)
                    {
                        if (sNum.Substring(i, 1) == ".")
                        {
                            swrk = swrk + sNum.Substring(i, 1);
                            bFound = true;
                        }

                        else if (sNum.Substring(i, 1) != ",")
                            if (bFound)
                                break;
                    }
                    else
                    {
                        swrk = swrk + sNum.Substring(i, 1);
                        bFound = true;
                    }

                }

                if (swrk == "")
                    return 0;


                return Double.Parse(swrk);
            }

            catch
            {
                return 0;
            }
        }


        private static StatusEnum ExecuteSQLSelect(SqlCommand oCommand, out SqlDataReader reader)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            reader = null;
            try
            {
                reader = oCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                //eStatus = HandleStatusError(SeverityEnum.Exception, "ExecuteSQL", (StatusEnum)eStatusOnException, ex.Message.ToString());
                eStatus = (StatusEnum)99871;
            }
            return eStatus;
        }


        private StatusEnum ExportPIInfo(DBAccess dba, string sProjectIDs, CStruct xEPKUpdate)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;

            // see if we have a list of mapped fields, if we do the we will use them to limit the fields we pass
            bool bMappedFields = false;


            // jwg 6/11/12  Hopefully this will send everything back...

            //cmdText = "SELECT COUNT(*) as lCount FROM EPG_WE_MAPPING WHERE WEM_ENTITY=20";
            //oCommand = new SqlCommand(cmdText, dba.Connection);
            //if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            //{
            //    if (reader.Read())
            //    {
            //        int lCount = (int)reader["lCount"];
            //        if (lCount > 0) bMappedFields = true;
            //    }
            //    reader.Close();
            //}

            // Read list of Standard Portfolio Fields we want - Standard means all except for Custom Fields - only ones that are mapped
            List<int> clnLookups = new List<int>();
            SortedList<int, EPKItem> clnStandardFields = new SortedList<int, EPKItem>();
            SortedList<int, EPKCustomField> clnCustomFields = new SortedList<int, EPKCustomField>();
            EPKItem oField;
            EPKCustomField oCustomField;
            bool bNeedResources = false;

            // We want these fields regardless so we'll just add them - they won't be mapped
            cmdText = "SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS" +
                    " Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID";
            //  oCommand.CommandText = cmdText;
            //   oCommand = new SqlCommand(cmdText, _sqlConnection);
            oCommand = new SqlCommand(cmdText, _sqlConnection);


            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    int nID = (int)reader["FIELD_ID"];
                    int nFieldType = (int)reader["FIELD_FORMAT"];
                    string sName = reader["FIELD_NAME"].ToString();
                    oField = new EPKItem();
                    oField.ID = nID;
                    oField.Name = sName;
                    oField.Value = nFieldType;
                    clnStandardFields.Add(nID, oField);
                }
                reader.Close();
            }

            //  now read marked list from EPGT_FIELDS
            cmdText = "SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f";
            if (bMappedFields) cmdText = cmdText + " Join EPG_WE_MAPPING m On f.FIELD_ID=m.WEM_EPK_FIELD_ID And WEM_ENTITY=20";
            cmdText = cmdText + " Where FIELD_EXPORT=1 ORDER BY FIELD_ID";
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    int nID = (int)reader["FIELD_ID"];
                    int nFieldType = (int)reader["FIELD_FORMAT"];
                    string sName = reader["FIELD_NAME"].ToString();
                    oField = new EPKItem();
                    oField.ID = nID;
                    oField.Name = sName;
                    oField.Value = nFieldType;
                    clnStandardFields.Add(nID, oField);
                    // add lookup UID to collection if TS Dept or RP Dept  - will we have Charge Code and similar here for PIs?
                    //                    if (nID == 3010) if (!clnLookups.Contains(lTSDeptEROC)) clnLookups.Add(lTSDeptEROC);
                    //                    if (nID == 3020) if (!clnLookups.Contains(lRPDeptEROC)) clnLookups.Add(lRPDeptEROC);
                    // we could remove joins to get Resource Name from main SQL because we might have to read the list of resaources anyway
                    //  for now we won't do that and expect that usually there will not be a CF of type Resource and we can avoid reading them
                    //  if the main SQL stmnt is too slow then removing the joins to EPG_RESOURCES might be one thing to try
                }
                reader.Close();
            }


            {
                //eStatus = HandleStatusError(SeverityEnum.Exception, "SelectDataById", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }

            // read list of Custom Portfolio Fields - if there is a list of mapped fields then get only the ones that are mapped
            cmdText = "Select * From EPGC_FIELD_ATTRIBS f";
            if (bMappedFields) cmdText = cmdText + " Join EPG_WE_MAPPING m On f.FA_FIELD_ID=m.WEM_EPK_FIELD_ID And WEM_ENTITY=20";
            cmdText = cmdText + " Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID";
            oCommand.CommandText = cmdText;
            oCommand = new SqlCommand(cmdText, _sqlConnection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    oCustomField = new EPKCustomField();
                    int nID = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);
                    oCustomField.ID = nID;
                    oCustomField.Name = reader["FA_NAME"].ToString();
                    oCustomField.Fieldtype = DBAccess.ReadIntValue(reader["FA_FORMAT"]);
                    oCustomField.CFTable = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    oCustomField.CFField = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                    oCustomField.LookupID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);

                    clnCustomFields.Add(nID, oCustomField);
                    // if it is a Code then add the Lookup to those we need to go get 
                    if (oCustomField.Fieldtype == 4 && oCustomField.LookupID > 0) if (!clnLookups.Contains(nID)) clnLookups.Add(nID);
                    if (oCustomField.Fieldtype == 7) bNeedResources = true;
                }
                reader.Close();
            }

            // Make a list of the lookups we need           
            SortedList<int, string> clnLookupValues = new SortedList<int, string>();
            string sLookupList = "";
            //int lLookup = 0;

            foreach (int iLookupId in clnLookups)
            {
                if (sLookupList.Length > 0)
                    sLookupList = sLookupList + "," + iLookupId.ToString();
                else
                    sLookupList = iLookupId.ToString();
            }

            // get the full(?) values for the lookup tables
            if (sLookupList.Length > 0)
            {
                oCommand = new SqlCommand("PPM_SP_ReadLookupValuesByLookup", _sqlConnection);
                oCommand.Parameters.AddWithValue("sList", sLookupList);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    int lVal = DBAccess.ReadIntValue(reader["LV_UID"]);
                    string sVal = reader["LV_FULLVALUE"].ToString();
                    clnLookupValues.Add(lVal, sVal);
                }
                reader.Close();
            }

            // before getting most fields for each PI in one SQL stmnt get the MV field values (Programs only for PIs) into a collection of collections
            //    stick with same method as for Resources even though there can only be a single MV field
            SortedList<int, SortedList<int, string>> clnMVs = new SortedList<int, SortedList<int, string>>();
            SortedList<int, string> clnMVValues;
            int lPrevProjectID;
            string sGroups;

            // Program Groups - more complicated as there can be multiple groups - for now I'll just lump them all together and assume the result is self explanatory
            if (clnStandardFields.ContainsKey(9960))
            {
                lPrevProjectID = 0;
                sGroups = "";
                cmdText = "Select pg.PROG_UID,PROJECT_ID,LV_FULLVALUE as GROUP_NAME From EPGP_PI_PROGS pg" +
                            " Join EPGP_LOOKUP_VALUES lv on lv.LV_UID=pg.PROG_UID";
                if (sProjectIDs.Length > 0) cmdText = cmdText + " JOIN dbo.EPG_FN_ConvertListToTable(N'" + sProjectIDs + "') LT on PROJECT_ID=LT.TokenVal";
                cmdText = cmdText + " Order By PROJECT_ID,pg.FIELD_ID";

                oCommand = new SqlCommand(cmdText, _sqlConnection);
                if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
                {
                    clnMVValues = new SortedList<int, string>();
                    int lProjectID = 0;
                    while (reader.Read())
                    {
                        lProjectID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        string sVal = reader["GROUP_NAME"].ToString();
                        if (lProjectID != lPrevProjectID && lPrevProjectID > 0)
                        {
                            if (!clnMVValues.ContainsKey(lPrevProjectID)) clnMVValues.Add(lPrevProjectID, sGroups);
                            sGroups = "";
                        }
                        if (sGroups.Length > 0) sGroups = sGroups + ", " + sVal; else sGroups = sVal;
                        lPrevProjectID = lProjectID;
                    }
                    reader.Close();
                    if (sGroups.Length > 0) if (!clnMVValues.ContainsKey(lPrevProjectID)) clnMVValues.Add(lPrevProjectID, sGroups);
                    clnMVs.Add(9960, clnMVValues);
                }
            }

            // get a resources collection if we need to resolve any Custom Fields
            SortedList<int, string> clnResources = new SortedList<int, string>();
            if (bNeedResources)
            {
                cmdText = "Select WRES_ID,RES_NAME From EPG_RESOURCES";
                oCommand = new SqlCommand(cmdText, _sqlConnection);
                if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
                {
                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        string sName = reader["RES_NAME"].ToString();
                        clnResources.Add(lWResID, sName);
                    }
                    reader.Close();
                }
            }

            // Build SQL to get Portfolio fields - only add the joins that are needed by special selected fields and Custom Fields
            string sFields, sJoins;

            // standard fields
            sFields = "pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID," +
                "PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE";
            sJoins = " ";

            if (clnStandardFields.ContainsKey(9224))    //  Linked Schedule
            {
                sFields = sFields + ",ps.WPROJ_ID";
                sJoins = sJoins + " Left Join EPGX_PROJECT_VERSIONS ps On ps.PROJECT_ID=pi.PROJECT_ID";
            }
            if (clnStandardFields.ContainsKey(9911))    //  Stage
            {
                sFields = sFields + ",sg.STAGE_NAME";
                sJoins = sJoins + " Left Join EPGP_STAGES sg On sg.STAGE_ID=pi.PROJECT_STAGE_ID";
            }
            if (clnStandardFields.ContainsKey(9922))    //  Stage Owner
            {
                sFields = sFields + ",r1.RES_NAME as StageOwner";
                sJoins = sJoins + " Left Join EPG_RESOURCES r1 On r1.WRES_ID=pi.PROJECT_OWNER";
            }
            if (clnStandardFields.ContainsKey(9925))    //  Item Manager
            {
                sFields = sFields + ",r2.RES_NAME as ItemManager";
                sJoins = sJoins + " Left Join EPG_RESOURCES r2 On r2.WRES_ID=pi.PROJECT_MANAGER";
            }
            if (clnStandardFields.ContainsKey(9930))    //  Schedule Manager
            {
                sFields = sFields + ",r3.RES_NAME as ScheduleManager";
                sJoins = sJoins + " Left Join EPG_RESOURCES r3 On r3.WRES_ID=pi.PROJECT_PLAN_OWNER";
            }
            if (clnStandardFields.ContainsKey(9920))    //  Created By
            {
                sFields = sFields + ",r4.RES_NAME as CreatedBy";
                sJoins = sJoins + " Left Join EPG_RESOURCES r4 On r4.WRES_ID=pi.PROJECT_CREATEDBY";
            }

            //  add custom fields
            bool b01 = false, b02 = false, b03 = false, b05 = false;
            string sTable, sField;

            foreach (KeyValuePair<int, EPKCustomField> oCustomField1 in clnCustomFields)
            {
                switch (oCustomField1.Value.CFTable)
                {
                    case 201:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b01) sJoins = sJoins + " LEFT JOIN " + sTable + " x1 ON x1.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b01 = true;
                        }
                        break;
                    case 202:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b02) sJoins = sJoins + " LEFT JOIN " + sTable + " x2 ON x2.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b02 = true;
                        }
                        break;
                    case 203:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b03) sJoins = sJoins + " LEFT JOIN " + sTable + " x3 ON x3.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b03 = true;
                        }
                        break;
                    case 205:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b05) sJoins = sJoins + " LEFT JOIN " + sTable + " x5 ON x5.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b05 = true;
                        }
                        break;
                }
            }

            // ready to put the beast together and read some data
            cmdText = "SELECT " + sFields + " FROM EPGP_PROJECTS pi " + sJoins;
            if (sProjectIDs.Length > 0) cmdText = cmdText + " JOIN dbo.EPG_FN_ConvertListToTable(N'" + sProjectIDs + "') LT on pi.PROJECT_ID=LT.TokenVal";
            cmdText = cmdText + " Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID";

            CStruct xPortfolioItems = xEPKUpdate.CreateSubStruct("PortfolioItems");
            xPortfolioItems.CreateStringAttr("Key", "EPK");

            oCommand = new SqlCommand(cmdText, _sqlConnection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {

                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();



                foreach (DataRow orow in dt.Rows)
                {
                    int lProjectID = 0;
                    string sWeePID = "";
                    string sXMLType = "";
                    string sVal = "";
                    DateTime dVal = DateTime.MinValue;
                    double dblVal = 0;
                    int lVal = 0;

                    lProjectID = DBAccess.ReadIntValue(orow["PROJECT_ID"]);
                    sWeePID = orow["PROJECT_EXT_UID"].ToString();
                    if (lProjectID > 0 && sWeePID.Length > 0)
                    {
                        CStruct xPortfolioItem = xPortfolioItems.CreateSubStruct("PortfolioItem");
                        xPortfolioItem.CreateStringAttr("ItemID", sWeePID);

                        //  get the team -  another SELECT withing the main one is ok?
                        SqlDataReader reader1;
                        string steamlist = "";
                        cmdText = "Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@pid ";  // reject entries w/o resource in case
                        SqlCommand oCommand1 = new SqlCommand(cmdText, _sqlConnection);
                        oCommand1.Parameters.AddWithValue("@pid", lProjectID);

                        if (ExecuteSQLSelect(oCommand1, out reader1) == StatusEnum.rsSuccess)
                        {
                            while (reader1.Read())
                            {
                                string steammember = DBAccess.ReadIntValue(reader1["WRES_ID"]).ToString(); ;
                                if (steamlist.Length == 0) steamlist = steammember; else steamlist += "," + steammember;
                            }
                            reader1.Close();
                        }
                        if (steamlist.Length > 0)
                        {
                            CStruct xTeam = xPortfolioItem.CreateSubStruct("Field");
                            xTeam.CreateStringAttr("ID", "Team");
                            xTeam.CreateStringAttr("Value", steamlist);
                        }

                        foreach (KeyValuePair<int, EPKItem> oField1 in clnStandardFields)
                        {
                            switch (oField1.Value.ID)
                            {
                                case 9900:
                                    sXMLType = "s";
                                    sVal = orow["PROJECT_NAME"].ToString();
                                    break;
                                case 9903:
                                    sXMLType = "i";
                                    lVal = lProjectID;
                                    break;
                                case 9901:
                                    dVal = DBAccess.ReadDateValue(orow["PROJECT_START_DATE"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9902:
                                    dVal = DBAccess.ReadDateValue(orow["PROJECT_FINISH_DATE"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9911:
                                    sVal = orow["STAGE_NAME"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9918:
                                    sXMLType = "";
                                    //sVal = reader["PROJECT_EXT_UID"].ToString();
                                    break;
                                case 9920:
                                    sVal = orow["CreatedBy"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9921:
                                    dVal = DBAccess.ReadDateValue(orow["PROJECT_CREATED"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9922:
                                    sVal = orow["StageOwner"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9924:
                                    sXMLType = "i";
                                    lVal = DBAccess.ReadIntValue(orow["WPROJ_ID"]);
                                    break;
                                case 9925:
                                    sVal = orow["ItemManager"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9928:
                                    sXMLType = "i";
                                    lVal = DBAccess.ReadIntValue(orow["PROJECT_PRIORITY"]);
                                    break;
                                case 9930:
                                    sVal = orow["ScheduleManager"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9936:
                                    dVal = DBAccess.ReadDateValue(orow["WORKITEM_START_DATE"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9960:
                                    sVal = GetMVValue(clnMVs, oField1.Value.ID, lProjectID);
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                default:
                                    sXMLType = "";
                                    break;
                            }

                            if (sXMLType.Length > 0)
                            {
                                CStruct xField = xPortfolioItem.CreateSubStruct("Field");
                                xField.CreateIntAttr("ID", oField1.Value.ID);
                                switch (sXMLType)
                                {
                                    case "d":
                                        xField.CreateDateAttr("Value", dVal);
                                        break;
                                    case "i":
                                        xField.CreateIntAttr("Value", lVal);
                                        break;
                                    case "dbl":
                                        xField.CreateDoubleAttr("Value", dblVal);
                                        break;
                                    default:
                                        xField.CreateStringAttr("Value", sVal);
                                        break;
                                }
                            }
                        }

                        foreach (KeyValuePair<int, EPKCustomField> oField1 in clnCustomFields)
                        {
                            switch (oField1.Value.CFTable)
                            {
                                case 201:
                                    if (oField1.Value.Fieldtype == 4)  // code
                                    {
                                        lVal = DBAccess.ReadIntValue(orow[oField1.Value.FieldName]);
                                        sVal = GetLookupValue(clnLookupValues, lVal);
                                        if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    }
                                    else if (oField1.Value.Fieldtype == 7)  // resource
                                    {
                                        lVal = DBAccess.ReadIntValue(orow[oField1.Value.FieldName]);
                                        sVal = GetLookupValue(clnResources, lVal);
                                        if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    }
                                    else
                                    {
                                        sXMLType = "i";
                                        lVal = DBAccess.ReadIntValue(orow[oField1.Value.FieldName]);
                                    }
                                    break;
                                case 202:
                                    sVal = orow[oField1.Value.FieldName].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 203:
                                    sXMLType = "dbl";
                                    dblVal = DBAccess.ReadDoubleValue(orow[oField1.Value.FieldName]);
                                    break;
                                case 205:
                                    dVal = DBAccess.ReadDateValue(orow[oField1.Value.FieldName]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                default:
                                    sXMLType = "";
                                    break;
                            }
                            if (sXMLType.Length > 0)
                            {
                                CStruct xField = xPortfolioItem.CreateSubStruct("Field");
                                xField.CreateIntAttr("ID", oField1.Value.ID);
                                switch (sXMLType)
                                {
                                    case "d":
                                        xField.CreateDateAttr("Value", dVal);
                                        break;
                                    case "i":
                                        xField.CreateIntAttr("Value", lVal);
                                        break;
                                    case "dbl":
                                        xField.CreateDoubleAttr("Value", dblVal);
                                        break;
                                    default:
                                        xField.CreateStringAttr("Value", sVal);
                                        break;
                                }
                            }
                        }
                    }
                }
            }


            return eStatus;

        }

        private static string GetMVValue(SortedList<int, SortedList<int, string>> clnMVs, int lFieldID, int lWresID)
        {
            string sValue = "";
            SortedList<int, string> clnMVValues;

            if (clnMVs.ContainsKey(lFieldID))
            {
                clnMVValues = clnMVs[lFieldID];
                if (clnMVValues.ContainsKey(lWresID)) sValue = clnMVValues[lWresID];
            }
            return sValue;
        }
        private static string GetLookupValue(SortedList<int, string> clnLookupValues, int lID)
        {
            string sValue = "";
            if (clnLookupValues.ContainsKey(lID)) sValue = clnLookupValues[lID];
            return sValue;
        }
    }
}
