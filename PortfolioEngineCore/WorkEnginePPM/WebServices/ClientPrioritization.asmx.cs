using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Services;
using ClientPrioritizationDataCache;
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

    public class ClientPrioritization : System.Web.Services.WebService
    {


        /// <summary>
        /// Ping the session data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void DoPingSession()
        {
           ClientPrioritizationData PriDataData = null;

            PriDataData = (ClientPrioritizationData)Session["ClientPrioritization"];

            if (PriDataData != null)
                Session["ClientPrioritization"] = PriDataData;

            return;   
        }

        /// <summary>
        /// Builds xml to drive the layout of the CostType grid
        /// </summary>
        /// <returns>XML formatted string</returns>
        /// 
        [WebMethod(EnableSession = true)]
        public PriGridData GetClientPrioritizationData()
        {


            ClientPrioritizationData PriDataData = null;

 //           PriDataData = (ClientPrioritizationData)Session["ClientPrioritization"];

            if (PriDataData == null)
            {

                PriDataData = new ClientPrioritizationData();
                Session["ClientPrioritization"] = PriDataData;

                string sStage;
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
                {

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                    SqlConnection conn = new SqlConnection(sDBConnect);
                    conn.Open();

                    PriDataData.GrabPrioritizationData(conn);

                    conn.Close();
                    conn.Dispose();
                }

            }

            PriGridData gdata = new PriGridData();

            gdata.NumCols = PriDataData.m_oCols.Count;
            gdata.griddata = new List<PriRowData>();
            PriWeight oweight;
            PriRowData row_data;


            foreach (PriItemDefn ritem in PriDataData.m_oRows)
            {
                List<double> rdata = new List<double>();
                double d = 0;
                string skey;


                foreach (PriItemDefn citem in PriDataData.m_oCols)
                {
                    skey = ritem.fid.ToString() + " " + citem.fid.ToString();

                    if (PriDataData.m_oWeights.TryGetValue(skey, out oweight))
                        d = oweight.ratio;
                    else
                        d = 0;

                    rdata.Add(d);
                }

                row_data = new PriRowData();
                row_data.rowdata = rdata;



                gdata.griddata.Add(row_data);
            }



            return gdata;
        }

        [WebMethod(EnableSession = true)]
        public string SetClientPrioritizationData(PriGridData data)
        {

 
                ClientPrioritizationData PriDataData = null;
                int lRowsAffected;
                DBAccess dba = null;

                string sStage;
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == false)
                {
                    dba.HandleStatusError(SeverityEnum.Error, "SetClientPrioritizationData", (StatusEnum)99999, "User Authentication Failed. Stage=" + sStage);
                    goto Exit_Function;
                }

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                dba = new DBAccess(sDBConnect);
                if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

                PriDataData = (ClientPrioritizationData)Session["ClientPrioritization"];

                if (PriDataData == null)
                {

                    PriDataData = new ClientPrioritizationData();
                    Session["ClientPrioritization"] = PriDataData;

                    PriDataData.GrabPrioritizationData(dba.Connection);
                }


                string sCommand = "DELETE FROM EPGP_PI_PRI_WEIGHTS";
                SqlCommand cmd = new SqlCommand(sCommand, dba.Connection);
                lRowsAffected = cmd.ExecuteNonQuery();

                sCommand = "DELETE FROM EPGP_CALCS WHERE CL_PRI = 1";
                cmd = new SqlCommand(sCommand, dba.Connection);
                lRowsAffected = cmd.ExecuteNonQuery();


                sCommand = "INSERT INTO EPGP_PI_PRI_WEIGHTS (CW_RESULT, CW_COMPONENT, CW_RATIO) VALUES(@CW_RESULT, @CW_COMPONENT, @CW_RATIO)";

                SqlCommand oCmdCW = new SqlCommand(sCommand, dba.Connection);

                SqlParameter cw_res = oCmdCW.Parameters.Add("@CW_RESULT", SqlDbType.Int);
                SqlParameter cw_com = oCmdCW.Parameters.Add("@CW_COMPONENT", SqlDbType.Int);
                SqlParameter cw_rat = oCmdCW.Parameters.Add("@CW_RATIO", SqlDbType.Decimal);

                cw_rat.Precision = 25;
                cw_rat.Scale = 6;


                sCommand = "INSERT INTO  EPGP_CALCS (CL_OBJECT, CL_PRI, CL_OP, CL_UID, CL_SEQ, CL_RESULT, CL_COMPONENT, CL_RATIO) " +
                            "VALUES(1, 1, 0, " + "@CL_UID, @CL_SEQ, @CL_RESULT, @CL_COMPONENT, @CL_RATIO)";

                SqlCommand oCmdCL = new SqlCommand(sCommand, dba.Connection);
                SqlParameter cl_uid = oCmdCL.Parameters.Add("@CL_UID", SqlDbType.Int);
                SqlParameter cl_seq = oCmdCL.Parameters.Add("@CL_SEQ", SqlDbType.Int);
                SqlParameter cl_res = oCmdCL.Parameters.Add("@CL_RESULT", SqlDbType.Int);
                SqlParameter cl_com = oCmdCL.Parameters.Add("@CL_COMPONENT", SqlDbType.Int);
                SqlParameter cl_rat = oCmdCL.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);

                cl_rat.Precision = 25;
                cl_rat.Scale = 6;

                PriItemDefn ritem;
                PriItemDefn citem;

                for (var r = 0; r < data.griddata.Count; r++)
                {

                    ritem = PriDataData.m_oRows[r];

                    for (var c = 0; c < data.NumCols; c++)
                    {
                        citem = PriDataData.m_oCols[c];
                        //cl_uid.Value = r + 1;
                        cl_uid.Value = ritem.uid;
                        cl_seq.Value = c + 1;

                        cl_res.Value = ritem.fid;
                        cl_com.Value = citem.fid;
                        cl_rat.Value = data.griddata[r].rowdata[c];

                        cw_res.Value = ritem.fid;
                        cw_com.Value = citem.fid;
                        cw_rat.Value = data.griddata[r].rowdata[c];

                        oCmdCL.ExecuteNonQuery();
                        oCmdCW.ExecuteNonQuery();


                    }
                }


                if (dba.Status != StatusEnum.rsSuccess) goto Exit_Function;

                // refresh the data just saved!!!!
                PriDataData.GrabPrioritizationData(dba.Connection);

                if (dba.Status != StatusEnum.rsSuccess) goto Exit_Function;
                PerformCustomFieldsCalculate(dba);

Exit_Function:

                dba.Close();


                if (dba.Status != StatusEnum.rsSuccess)
                    return dba.FormatErrorText();
                else
                    return "";

        }

        [WebMethod(EnableSession = true)]
        public string GetGridLayout()
        {
            WeightGridDataLayout oGrid = new WeightGridDataLayout();


            ClientPrioritizationData PriDataData = null;

            PriDataData = (ClientPrioritizationData)Session["ClientPrioritization"];

            if (PriDataData == null)
            {

                PriDataData = new ClientPrioritizationData();
                Session["ClientPrioritization"] = PriDataData;

                string sStage;
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
                {

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                    SqlConnection conn = new SqlConnection(sDBConnect);
                    conn.Open();

                    PriDataData.GrabPrioritizationData(conn);

                    conn.Close();
                    conn.Dispose();
                }

            }
            oGrid.InitializeGridLayout(PriDataData.m_oCols);

            return oGrid.GetString();
        }

        [WebMethod(EnableSession = true)]
        public string GetGridData()
        {
            WeightGridData oGrid = new WeightGridData();
            PriWeight oweight;

            ClientPrioritizationData PriDataData = null;

            PriDataData = (ClientPrioritizationData)Session["ClientPrioritization"];

            if (PriDataData == null)
            {

                PriDataData = new ClientPrioritizationData();
                Session["ClientPrioritization"] = PriDataData;

                string sStage;
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
                {

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                    SqlConnection conn = new SqlConnection(sDBConnect);
                    conn.Open();

                    PriDataData.GrabPrioritizationData(conn);

                    conn.Close();
                    conn.Dispose();
                }

            }

            oGrid.InitializeGridLayout();

            int lrow = 0;

            foreach (PriItemDefn ritem in PriDataData.m_oRows)
            {
                List<double> data = new List<double>();
                double d = 0;
                string skey;

                ++lrow;


                foreach (PriItemDefn citem in PriDataData.m_oCols)
                {
                    skey = ritem.fid.ToString() + " " + citem.fid.ToString();

                    if (PriDataData.m_oWeights.TryGetValue(skey, out oweight))
                        d = oweight.ratio;
                    else
                        d = 0;

                    data.Add(d);
                }


                oGrid.AddRow(lrow, ritem.Name, data);


            }

            return oGrid.GetString();
        }

        private void PerformCustomFieldsCalculate(DBAccess dba)
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

  //          if (bonlyPRIs)
                sCommand += " AND (EPGP_CALCS.CL_PRI = 1) ";

            sCommand += " ORDER BY EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ";

            string sWhereClause = "";

            oCommand = new SqlCommand(sCommand, dba.Connection);
            reader = oCommand.ExecuteReader();
            string sErrSQL = "";


            while (reader.Read())
            {
                uid = DBAccess.ReadIntValue(reader["CL_UID"]);

                if (lastuid != uid)
                {
                    if (seqStmt != "")
                    {
                        seqStmt += "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID "; 
                         sqlstatements.Add(seqStmt + sWhereClause);

                        if (sWhereClause != "")
                            sqlstatements.Add(sErrSQL + sWhereClause);
                    }

                    seqStmt = "";
                    sWhereClause = "";

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
                            if (sWhereClause == "")
                                sWhereClause = " WHERE (" + sval + "<> 0) ";
                            else
                                sWhereClause += " AND (" + sval + "<> 0) ";
                        }
                    }


                }


            }

            if (seqStmt != "")
            {
                seqStmt += "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";
                sqlstatements.Add(seqStmt + sWhereClause);
                if (sWhereClause != "")
                    sqlstatements.Add(sErrSQL + sWhereClause);
            }

            reader.Close();
            reader = null;


            foreach (string sql in sqlstatements)
            {


                oCommand = new SqlCommand(sql, dba.Connection);
                int lRowsAffected = oCommand.ExecuteNonQuery();
            }

            string sWEServerURL = "";
            string Projectids = "";

            sCommand = "SELECT ADM_WE_SERVERURL FROM EPG_ADMIN";

            oCommand = new SqlCommand(sCommand, dba.Connection);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {
                sWEServerURL = DBAccess.ReadStringValue(reader["ADM_WE_SERVERURL"]);
            }

            reader.Close();
            reader = null;

            //sCommand = "SELECT PROJECT_EXT_UID FROM EPGP_PROJECTS";

            //oCommand = new SqlCommand(sCommand, dba.Connection);
            //reader = oCommand.ExecuteReader();
            //while (reader.Read())
            //{
            //    sCommand = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
            //    if (sCommand.Length > 0)
            //    {

            //        if (Projectids.Length > 0)
            //            Projectids += ",";

            //        Projectids += sCommand;
            //    }
            //}
            //reader.Close();
            //reader = null;

            //if (sWEServerURL.Length > 0 && Projectids.Length > 0)
            if (sWEServerURL.Length > 0)
            {
                string sXMLRequest;
                if (dbaUsers.ExportPIInfo(dba, Projectids, out sXMLRequest) == StatusEnum.rsSuccess)
                {
                    XmlNode xNode;
                    if (SendXMLToWorkEngine(dba, sWEServerURL, "UpdateItems", sXMLRequest, out xNode) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    if (xNode != null)
                    {
                        CStruct xResult = new CStruct();
                        if (xResult.LoadXML(xNode.OuterXml) == false)
                        {
                            dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99843, "Invalid XML response from WorkEngine WebService");
                            goto Exit_Function;
                        }
                        if (xResult.GetIntAttr("Status") != 0)
                        {
                            CStruct xError = xResult.GetSubStruct("Error");
                            if (xError != null)
                            {
                                string sError = xError.GetStringAttr("ID") + " : " + xError.GetString("");
                                dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99842, "Invalid XML response from WorkEngine WebService\n\nStatus=" + xResult.GetStringAttr("Status") + "\n\nError=" + sError);
                            }
                            else
                            {
                                CStruct xItem = xResult.GetSubStruct("Item");
                                if (xItem != null)
                                {
                                    string sItem = xItem.GetStringAttr("ID") + " : " + xItem.GetString("");
                                    dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99999, "Invalid XML response from WorkEngine WebService\n\nStatus=" + xResult.GetStringAttr("Status") + "\n\nItem Error=" + sItem);
                                }
                            }
                            goto Exit_Function;
                        }
                    }
                }
            }

Exit_Function:
            
            //if (dba != null)
            //{
            //    if (dba.Status != StatusEnum.rsSuccess)
            //    {
            //        HandleDBAccessError("PerformCustomFieldsCalculate", dba);
            //    }
            //}

            return;
        }

        private static string GetCustFieldVal(int lfit, int lfat)
        {
            string sfn = "0";
            if (lfat == 203) 
                 sfn =  "PC_" + lfit.ToString("000"); 
            else if (lfat == 202)
            {
                //sfn = "CAST(PT_" + lfit.ToString("000") + " AS int)";

                //  want: IsNull(cast(Left(PT_003, PatIndex('%[^0-9]%', PT_003+'x' ) - 1 ) as int),0)
                sfn = "IsNull(cast(Left(PT_" + lfit.ToString("000") + ", PatIndex('%[^0-9]%', PT_" + lfit.ToString("000") + "+'x' ) - 1 ) as int),0)";
            }

            return sfn;
        }

        private static StatusEnum SendXMLToWorkEngine(DBAccess dba, string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            //HttpContext context = HttpContext.Current;
            //if (WorkEnginePPM.WebAdmin.CheckProductFlag(context, (uint)Security.ProductFlag.pfSPWorkEngine) == true)
            {

                try
                {
                    WorkEnginePPM.Integration weInt = new WorkEnginePPM.Integration();
                    xNode = weInt.execute(sContext, sXMLRequest);
                    dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "WE Request", "Context=" + sContext + "; URL=" + sURL, sXMLRequest);
                    if (xNode != null)
                        dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "WE Reply", "Context=" + sContext + "; URL=" + sURL, xNode.OuterXml.ToString());
                }
                catch (Exception ex)
                {
                    dba.Status = (StatusEnum)99830;
                    dba.StatusText = ex.Message;
                    dba.StackTrace = ex.StackTrace;
                    dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "Exception", ex.Message, ex.StackTrace);
                }
            }
            return dba.Status;
        }

        private static string HandleDBAccessError(string sContext, DBAccess dba)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Grid");
            CStruct xIO = xReply.CreateSubStruct("IO");
            xIO.CreateStringAttr("Message", "DBAccess Status Exception in EditCosts.asmx.cs Context=" + sContext + "; Text=" + dba.FormatErrorText() + ";");

            return xReply.XML();
        }

        internal class WeightGridDataLayout
        {
            private CStruct xGrid;

            public void InitializeGridLayout(List<PriItemDefn> oCols)
            {


                xGrid = new CStruct();
                xGrid.Initialize("Grid");

                CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
                xToolbar.CreateIntAttr("Visible", 0);

                CStruct xPanel = xGrid.CreateSubStruct("Panel");
                xPanel.CreateIntAttr("Visible", 1);
                xPanel.CreateIntAttr("Delete", 0);

                CStruct xCfg = xGrid.CreateSubStruct("Cfg");

                xCfg.CreateStringAttr("MainCol", "Filtering");

                xCfg.CreateBooleanAttr("NoTreeLines", true);
                xCfg.CreateIntAttr("MaxHeight", 0);
                xCfg.CreateIntAttr("MaxHeight", 0);
                xCfg.CreateIntAttr("ShowDeleted", 0);
                xCfg.CreateIntAttr("Deleting", 0);
                xCfg.CreateIntAttr("Selecting", 0);
                xCfg.CreateIntAttr("Dragging", 0);
                xCfg.CreateIntAttr("DragEdit", 0);
                //          xCfg.CreateIntAttr("MaxWidth", 1);
                //          xCfg.CreateIntAttr("ConstHeight", 1);

                xCfg.CreateIntAttr("ExactSize", 0);
                xCfg.CreateIntAttr("SelectingCells", 1);





                xCfg.CreateBooleanAttr("DateStrings", true);
                xCfg.CreateIntAttr("MaxWidth", 1);
                xCfg.CreateIntAttr("AppendId", 0);
                xCfg.CreateIntAttr("FullId", 0);
                xCfg.CreateStringAttr("IdChars", "0123456789");
                xCfg.CreateIntAttr("NumberId", 1);
                xCfg.CreateIntAttr("FilterEmpty", 1);

                xCfg.CreateStringAttr("IdPrefix", "R");
                xCfg.CreateStringAttr("IdPostfix", "x");
                xCfg.CreateIntAttr("CaseSensitiveId", 0);

                xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
                //            xCfg.CreateStringAttr("Style", "Modern");
                xCfg.CreateStringAttr("Style", "GM");
                xCfg.CreateStringAttr("CSS", "WorkEngine");





                CStruct xCols = xGrid.CreateSubStruct("LeftCols");
                CStruct xHead = xGrid.CreateSubStruct("Header");

                xHead.CreateIntAttr("Visible", 1);
                xHead.CreateIntAttr("SortIcons", 0);
                // Add category column
                CStruct xC = null;


                xC = xCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "RowNames");
                xC.CreateStringAttr("Type", "Text");
                xC.CreateIntAttr("Width", 200);
                xC.CreateBooleanAttr("CanEdit", false);
                xHead.CreateStringAttr("RowNames", " ");


                int ccnt = 0;
                string Colname = "";

                foreach (PriItemDefn pdata in oCols)
                {
                    ++ccnt;

                    Colname = "C" + ccnt.ToString();
                    xC = xCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", Colname);
                    xC.CreateStringAttr("Type", "Float");
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateBooleanAttr("CanEdit", true);
                    xC.CreateStringAttr("Format", "0.###");
                    xHead.CreateStringAttr(Colname, pdata.Name);

                }
            }


            public string GetString()
            {
                return xGrid.XML();
            }
        }
        internal class WeightGridData
        {
            private CStruct xGrid, xRoot;

            public void InitializeGridLayout()
            {
                xGrid = new CStruct();
                xGrid.Initialize("Grid");
                CStruct xCfg = xGrid.CreateSubStruct("Cfg");
                xCfg.CreateIntAttr("FilterEmpty", 1);

                CStruct xBody = xGrid.CreateSubStruct("Body");
                CStruct xB = xBody.CreateSubStruct("B");
                CStruct xI = xBody.CreateSubStruct("I");
                xI.CreateStringAttr("Grouping", "Totals");
                xI.CreateBooleanAttr("CanEdit", true);

                xRoot = xI;
            }
            public void AddRow(int rID, string Name, List<double> weights)
            {

                CStruct xI = xRoot.CreateSubStruct("I");


                xI.CreateStringAttr("id", rID.ToString());
                xI.CreateStringAttr("RowNames", Name);
                xI.CreateStringAttr("Color", "254,254,254");
                xI.CreateIntAttr("NoColorState", 1);

                int ccnt = 0;
                string Colname = "";

                foreach (double d in weights)
                {
                    ++ccnt;
                    Colname = "C" + ccnt.ToString();
                    xI.CreateDoubleAttr(Colname, d);
                    xI.CreateBooleanAttr(Colname + "CanEdit", true);
                }


            }
            public string GetString()
            {
                return xGrid.XML();
            }
        }

    }
}

