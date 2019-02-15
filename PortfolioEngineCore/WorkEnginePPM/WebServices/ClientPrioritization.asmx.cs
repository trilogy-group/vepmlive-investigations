using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Xml;
using ClientPrioritizationDataCache;
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
            var sqlStatements = new List<string>();
            var seqStatement = string.Empty;
            var seqStatementStringBuilder = new StringBuilder(seqStatement);
            var lastId = -1;

            //CC-78062 - leaving as concatenation because since it's all static strings it will be inlined by the compiler, and keeps the formatting nicer than using interpolation or string format.
            const string Command = "SELECT     EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ, EPGP_CALCS.CL_RESULT, EPGC_FIELD_ATTRIBS.FA_FIELD_IN_TABLE, "
                + "EPGP_CALCS.CL_COMPONENT, EPGC_FIELD_ATTRIBS_1.FA_FIELD_IN_TABLE AS Expr1, EPGP_CALCS.CL_RATIO, EPGP_CALCS.CL_OP, "
                + "EPGC_FIELD_ATTRIBS_1.FA_TABLE_ID AS EXFAT "
                + "FROM         EPGP_CALCS INNER JOIN "
                + "EPGC_FIELD_ATTRIBS ON EPGP_CALCS.CL_RESULT = EPGC_FIELD_ATTRIBS.FA_FIELD_ID LEFT JOIN "
                + "EPGC_FIELD_ATTRIBS AS EPGC_FIELD_ATTRIBS_1 ON EPGP_CALCS.CL_COMPONENT = EPGC_FIELD_ATTRIBS_1.FA_FIELD_ID "
                + "Where (EPGP_CALCS.CL_OBJECT = 1) "
                + " AND (EPGP_CALCS.CL_PRI = 1) "
                + " ORDER BY EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ";

            var whereClause = string.Empty;

            using (var sqlCommand = new SqlCommand(Command, dba.Connection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var errSql = string.Empty;

                    while (reader.Read())
                    {
                        var id = SqlDb.ReadIntValue(reader["CL_UID"]);
                        var fieldInTable = 0;

                        HandleLastFieldCase(
                            ref lastId,
                            id,
                            ref seqStatement,
                            sqlStatements,
                            reader,
                            ref seqStatementStringBuilder,
                            ref whereClause,
                            ref errSql);

                        var seq = SqlDb.ReadIntValue(reader["CL_SEQ"]);
                        var operationId = SqlDb.ReadIntValue(reader["CL_OP"]);

                        HandleMiddleFieldCase(seq, operationId, seqStatementStringBuilder, ref seqStatement);

                        fieldInTable = SqlDb.ReadIntValue(reader["Expr1"]);
                        var fat = SqlDb.ReadIntValue(reader["EXFAT"]);
                        var ratio = SqlDb.ReadDoubleValue(reader["CL_RATIO"]);

                        HandleFirstFieldCase(fieldInTable, seqStatementStringBuilder, ratio, fat, seq, operationId, out seqStatement, ref whereClause);
                    }

                    AddCommands(seqStatement, seqStatementStringBuilder, sqlStatements, whereClause, errSql);
                }
            }

            ExecuteSqlCommands(dba, sqlStatements);

            string projectIds;
            var weServerUrl = ReadServerUrls(dba, out projectIds);
            ProcessServerUrl(dba, weServerUrl, projectIds);
        }

        private static void HandleLastFieldCase(
            ref int lastId,
            int id,
            ref string seqStmt,
            List<string> sqlStatements,
            SqlDataReader reader,
            ref StringBuilder seqStmtStringBuilder,
            ref string whereClause,
            ref string errSql)
        {
            int fieldInTable;
            if (lastId != id)
            {
                if (!string.IsNullOrWhiteSpace(seqStmt))
                {
                    seqStmtStringBuilder.Append(
                        "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ");
                    seqStmt = seqStmtStringBuilder.ToString();

                    sqlStatements.Add(string.Format("{0}{1}", seqStmt, whereClause));

                    if (!string.IsNullOrWhiteSpace(whereClause))
                    {
                        sqlStatements.Add(string.Format("{0}{1}", errSql, whereClause));
                    }
                }

                whereClause = string.Empty;

                lastId = id;

                fieldInTable = SqlDb.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);

                seqStmt = string.Format("UPDATE EPGP_PROJECT_DEC_VALUES SET PC_{0:000} = ", fieldInTable);
                seqStmtStringBuilder = new StringBuilder(seqStmt);

                errSql = string.Format("UPDATE EPGP_PROJECT_DEC_VALUES SET PC_{0:000} = 999999 ", fieldInTable);
            }
        }

        private static void HandleMiddleFieldCase(int seq, int operationId, StringBuilder seqStmtStringBuilder, ref string seqStmt)
        {
            if (seq != 1)
            {
                string operation;
                switch (operationId)
                {
                    case 1:
                        operation = " - ";
                        break;
                    case 2:
                        operation = " * ";
                        break;
                    case 3:
                        operation = " / ";
                        break;
                    default:
                        operation = " + ";
                        break;
                }

                seqStmtStringBuilder.Append(operation);
                seqStmt = seqStmtStringBuilder.ToString();
            }
        }

        private static void HandleFirstFieldCase(
            int fieldInTable,
            StringBuilder seqStmtStringBuilder,
            double ratio,
            int fat,
            int seq,
            int operationId,
            out string seqStmt,
            ref string whereClause)
        {
            if (fieldInTable == 0)
            {
                seqStmtStringBuilder.Append(ratio.ToString());
                seqStmt = seqStmtStringBuilder.ToString();
            }
            else
            {
                var sval = GetCustFieldVal(fieldInTable, fat);

                seqStmtStringBuilder.Append(string.Format("({0} * {1})", sval, ratio));
                seqStmt = seqStmtStringBuilder.ToString();

                if (seq != 1)
                {
                    const int operationIdToCheck = 3;
                    if (operationId == operationIdToCheck)
                    {
                        if (whereClause == string.Empty)
                        {
                            whereClause = string.Format(" WHERE ({0}<> 0) ", sval);
                        }
                        else
                        {
                            var whereStringBuilder = new StringBuilder(whereClause);
                            whereStringBuilder.Append(string.Format(" AND ({0}<> 0) ", sval));
                            whereClause = whereStringBuilder.ToString();
                        }
                    }
                }
            }
        }

        private static void AddCommands(string seqStmt, StringBuilder stringBuilder, List<string> sqlStatements, string whereClause, string errSql)
        {
            if (!string.IsNullOrWhiteSpace(seqStmt))
            {
                stringBuilder.Append(
                    "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ");
                seqStmt = stringBuilder.ToString();

                sqlStatements.Add(string.Format("{0}{1}", seqStmt, whereClause));
                if (!string.IsNullOrWhiteSpace(whereClause))
                {
                    sqlStatements.Add(string.Format("{0}{1}", errSql, whereClause));
                }
            }
        }

        private static void ExecuteSqlCommands(DBAccess dbAccess, List<string> sqlStatements)
        {
            foreach (var sql in sqlStatements)
            {
                using (var sqlCommand = new SqlCommand(sql, dbAccess.Connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private static void ProcessServerUrl(DBAccess dbAccess, string weServerUrl, string Projectids)
        {
            if (weServerUrl.Length > 0)
            {
                string xmlRequest;
                if (dbaUsers.ExportPIInfo(dbAccess, Projectids, out xmlRequest) == StatusEnum.rsSuccess)
                {
                    XmlNode xmlNode;
                    if (SendXMLToWorkEngine(dbAccess, weServerUrl, "UpdateItems", xmlRequest, out xmlNode)
                        != StatusEnum.rsSuccess)
                    {
                        return;
                    }

                    if (xmlNode != null)
                    {
                        var result = new CStruct();
                        if (result.LoadXML(xmlNode.OuterXml) == false)
                        {
                            dbAccess.HandleStatusError(
                                SeverityEnum.Error,
                                "PerformCustomFieldsCalculate",
                                (StatusEnum)99843,
                                "Invalid XML response from WorkEngine WebService");
                            return;
                        }
                        if (result.GetIntAttr("Status") != 0)
                        {
                            var error = result.GetSubStruct("Error");
                            if (error != null)
                            {
                                var sError = $"{error.GetStringAttr("ID")} : {error.GetString("")}";
                                dbAccess.HandleStatusError(
                                    SeverityEnum.Error,
                                    "PerformCustomFieldsCalculate",
                                    (StatusEnum)99842,
                                    string.Format(
                                        "Invalid XML response from WorkEngine WebService\n\nStatus={0}\n\nError={1}",
                                        result.GetStringAttr("Status"),
                                        sError));
                            }
                            else
                            {
                                var item = result.GetSubStruct("Item");
                                if (item != null)
                                {
                                    var sItem = $"{item.GetStringAttr("ID")} : {item.GetString("")}";
                                    dbAccess.HandleStatusError(
                                        SeverityEnum.Error,
                                        "PerformCustomFieldsCalculate",
                                        (StatusEnum)99999,
                                        string.Format(
                                            "Invalid XML response from WorkEngine WebService\n\nStatus={0}\n\nItem Error={1}",
                                            result.GetStringAttr("Status"),
                                            sItem));
                                }
                            }
                        }
                    }
                }
            }
        }

        private static string ReadServerUrls(DBAccess dbAccess, out string projectIds)
        {
            var weServerUrl = string.Empty;
            projectIds = string.Empty;

            const string Command = "SELECT ADM_WE_SERVERURL FROM EPG_ADMIN";

            using (var sqlCommand = new SqlCommand(Command, dbAccess.Connection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        weServerUrl = SqlDb.ReadStringValue(reader["ADM_WE_SERVERURL"]);
                    }
                }
            }
            return weServerUrl;
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

