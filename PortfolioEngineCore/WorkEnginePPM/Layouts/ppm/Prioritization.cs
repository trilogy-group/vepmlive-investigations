using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WorkEnginePPM
{
    internal class dbaPrioritz
    {
        public static StatusEnum SelectFields(DBAccess dba, out DataTable dt)
        {
            string cmdText =
                "SELECT * FROM EPGC_FIELD_ATTRIBS Where ((FA_TABLE_ID=203 and FA_FORMAT=3) or (FA_TABLE_ID=202 and FA_FORMAT=9)) ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99858, out dt);
        }

        public static StatusEnum SelectComponents(DBAccess dba, out DataTable dt)
        {
            string cmdText = "Select * From EPGP_PI_PRI_COMPONENTS Order BY CC_SEQ";
            return dba.SelectData(cmdText, (StatusEnum) 99857, out dt);
        }

        public static StatusEnum SelectFormulas(DBAccess dba, out DataTable dt)
        {
            string cmdText = "Select Distinct c.CW_RESULT,f.FA_NAME From EPGP_PI_PRI_WEIGHTS c" +
                             " Inner Join EPGC_FIELD_ATTRIBS f On f.FA_FIELD_ID=c.CW_RESULT Order BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99856, out dt);
        }

        public static StatusEnum SelectWeights(DBAccess dba, out DataTable dt)
        {
            string cmdText = "Select * From EPGP_PI_PRI_WEIGHTS";
            return dba.SelectData(cmdText, (StatusEnum) 99855, out dt);
        }

        public static StatusEnum SelectComponentFields(DBAccess dba, out DataTable dt)
        {
            string cmdText =
                "SELECT * FROM EPGC_FIELD_ATTRIBS Where ((FA_TABLE_ID=203 and FA_FORMAT=3) or (FA_TABLE_ID=202 and FA_FORMAT=9))" +
                " And FA_FIELD_ID Not In (Select Distinct CL_RESULT From EPGP_CALCS Where CL_PRI=1)" +
                " ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99854, out dt);
        }

        public static StatusEnum SelectFormulaFields(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS Where (FA_TABLE_ID=203 and FA_FORMAT=3)" +
                             " And FA_FIELD_ID Not In (Select CC_COMPONENT From EPGP_PI_PRI_COMPONENTS)" +
                             " ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99853, out dt);
        }

        public static StatusEnum UpdateComponents(DBAccess dba, Pri_ComponentsForm ComponentsForm, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            List<int> Components;
            Components = ComponentsForm.Components;

            if (eStatus == StatusEnum.rsSuccess)
            {
                lRowsAffected = 0;
                {
                    dba.BeginTransaction();
                    try
                    {
                        cmdText =
                            "DELETE FROM EPGP_PI_PRI_COMPONENTS";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        if (Components.Count > 0)
                        {
                            cmdText =
                                "INSERT INTO EPGP_PI_PRI_COMPONENTS (CC_COMPONENT,CC_SEQ) VALUES(@CC_COMPONENT,@CC_SEQ)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlParameter pComponent = oCommand.Parameters.Add("@CC_COMPONENT", SqlDbType.Int);
                            SqlParameter pSEQ = oCommand.Parameters.Add("@CC_SEQ", SqlDbType.Int);

                            int lCTRowsAffected = 0;
                            int lSEQ = 0;
                            foreach (int nComponent in Components)
                            {
                                lSEQ = lSEQ + 1;
                                pSEQ.Value = lSEQ;
                                pComponent.Value = nComponent;
                                lCTRowsAffected += oCommand.ExecuteNonQuery();
                            }

                            // clean out orphans that may have been caused in WEIGHTS
                            cmdText =
                                "DELETE FROM EPGP_PI_PRI_WEIGHTS Where CW_COMPONENT Not In (Select CC_COMPONENT From EPGP_PI_PRI_COMPONENTS)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            lRowsAffected = oCommand.ExecuteNonQuery();

                            eStatus = UpdateCalcs(dba);
                        }
                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateComponents", (StatusEnum) 99852,
                                                        ex.Message.ToString());
                        dba.RollbackTransaction();
                    }
                }
            }
            return eStatus;
        }

        public static StatusEnum UpdateFormulas(DBAccess dba, Pri_FormulasForm FormulasForm, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            List<int> Formulas;
            Formulas = FormulasForm.Formulas;

            // need to read existing formulas and components
            DataTable dt;
            List<int> Components = new List<int>();
            if (SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                Components.Add(lFieldID);
            }

            List<int> OLDFormulas = new List<int>();
            if (SelectFormulas(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CW_RESULT"]);
                OLDFormulas.Add(lFieldID);
            }


            if (eStatus == StatusEnum.rsSuccess)
            {
                lRowsAffected = 0;
                {
                    dba.BeginTransaction();
                    try
                    {
                        if (Formulas.Count > 0)
                        {
                            cmdText =
                                "INSERT INTO EPGP_PI_PRI_WEIGHTS (CW_RESULT,CW_COMPONENT,CW_RATIO) VALUES(@CW_RESULT,@CW_COMPONENT,@CW_RATIO)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlParameter pRESULT = oCommand.Parameters.Add("@CW_RESULT", SqlDbType.Int);
                            SqlParameter pCOMPONENT = oCommand.Parameters.Add("@CW_COMPONENT", SqlDbType.Int);
                            oCommand.Parameters.AddWithValue("@CW_RATIO", 0);

                            foreach (int nFormula in Formulas)
                            {
                                if (OLDFormulas.Contains(nFormula))
                                {
                                    OLDFormulas.Remove(nFormula);
                                }
                                else
                                {
                                    // add an entry into WEIGHT table for each component
                                    foreach (int nComponent in Components)
                                    {
                                        pRESULT.Value = nFormula;
                                        pCOMPONENT.Value = nComponent;
                                        int lCCRowsAffected = oCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        // delete formulas no longer needed
                        foreach (int nFormula in OLDFormulas)
                        {
                            cmdText = "DELETE FROM EPGP_PI_PRI_WEIGHTS Where CW_RESULT=" + nFormula.ToString();
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            int lCCRowsAffected = oCommand.ExecuteNonQuery();
                        }

                        eStatus = UpdateCalcs(dba);

                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateFormulas", (StatusEnum) 99851,
                                                        ex.Message.ToString());
                        dba.RollbackTransaction();
                    }
                }
            }
            Status_Error:

            return eStatus;
        }

        public static StatusEnum UpdateWeights(DBAccess dba, List<EPKPriFormula> Formulas, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            if (eStatus == StatusEnum.rsSuccess)
            {
                lRowsAffected = 0;
                {
                    dba.BeginTransaction();
                    try
                    {
                        cmdText = "DELETE FROM EPGP_PI_PRI_WEIGHTS";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        if (Formulas.Count > 0)
                        {
                            cmdText =
                                "INSERT INTO EPGP_PI_PRI_WEIGHTS (CW_RESULT,CW_COMPONENT,CW_RATIO) VALUES(@CW_RESULT,@CW_COMPONENT,@CW_RATIO)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlParameter pResult = oCommand.Parameters.Add("@CW_RESULT", SqlDbType.Int);
                            SqlParameter pComponent = oCommand.Parameters.Add("@CW_COMPONENT", SqlDbType.Int);
                            SqlParameter pRatio = oCommand.Parameters.Add("@CW_RATIO", SqlDbType.Float);
                            pRatio.Precision = 25;
                            pRatio.Scale = 6;

                            int lCWRowsAffected = 0;
                            foreach (EPKPriFormula Formula in Formulas)
                            {
                                foreach (ComponentWeight component in Formula.components)
                                {
                                    pResult.Value = Formula.uid;
                                    pComponent.Value = component.ComponentId;
                                    pRatio.Value = component.Weight;
                                    lCWRowsAffected += oCommand.ExecuteNonQuery();
                                }
                            }
                            eStatus = UpdateCalcs(dba);
                        }
                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateComponents", (StatusEnum) 99850,
                                                        ex.Message.ToString());
                        dba.RollbackTransaction();
                    }
                }
            }
            if (dba.Status == StatusEnum.rsSuccess) eStatus = PerformCustomFieldsCalculate(dba);

            return eStatus;
        }

        private static StatusEnum UpdateCalcs(DBAccess dba)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            SqlCommand oCommand;
            string cmdText;

            // read formulas and components
            DataTable dt;
            List<int> Components = new List<int>();
            if (SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                Components.Add(lFieldID);
            }

            List<int> Formulas = new List<int>();
            if (SelectFormulas(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CW_RESULT"]);
                Formulas.Add(lFieldID);
            }

            if (eStatus == StatusEnum.rsSuccess)
            {
                int lRowsAffected = 0;
                {
                    try
                    {
                        cmdText = "DELETE FROM EPGP_CALCS Where CL_PRI=1";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        if (Formulas.Count > 0 && Components.Count > 0)
                        {
                            // get UID for next formula
                            int nNewCLUID = 0;
                            cmdText = "SELECT MAX(CL_UID) As maxUID FROM EPGP_CALCS";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlDataReader reader = oCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                nNewCLUID = DBAccess.ReadIntValue(reader["maxUID"]);
                            }
                            reader.Close();

                            cmdText =
                                "INSERT INTO EPGP_CALCS (CL_OBJECT,CL_UID,CL_SEQ,CL_RESULT,CL_COMPONENT,CL_RATIO,CL_OP,CL_PRI) VALUES(@CL_OBJECT,@CL_UID,@CL_SEQ,@CL_RESULT,@CL_COMPONENT,@CL_RATIO,@CL_OP,@CL_PRI)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            oCommand.Parameters.AddWithValue("@CL_OBJECT", 1);
                            SqlParameter pUID = oCommand.Parameters.Add("@CL_UID", SqlDbType.Int);
                            SqlParameter pSEQ = oCommand.Parameters.Add("@CL_SEQ", SqlDbType.Int);
                            SqlParameter pRESULT = oCommand.Parameters.Add("@CL_RESULT", SqlDbType.Int);
                            SqlParameter pCOMPONENT = oCommand.Parameters.Add("@CL_COMPONENT", SqlDbType.Int);
                            oCommand.Parameters.AddWithValue("@CL_RATIO", 0);
                            oCommand.Parameters.AddWithValue("@CL_OP", 0);
                            oCommand.Parameters.AddWithValue("@CL_PRI", 1);

                            foreach (int nFormula in Formulas)
                            {
                                // add an entry into CLAC table for each component for each formula
                                int lSEQ = 0;
                                nNewCLUID = nNewCLUID + 1;
                                foreach (int nComponent in Components)
                                {
                                    lSEQ = lSEQ + 1;
                                    pUID.Value = nNewCLUID;
                                    pSEQ.Value = lSEQ;
                                    pRESULT.Value = nFormula;
                                    pCOMPONENT.Value = nComponent;
                                    int lCCRowsAffected = oCommand.ExecuteNonQuery();
                                }
                            }

                            // update the Ratios in the CALC table from the Weights table
                            cmdText = "Update EPGP_CALCS Set CL_RATIO=CW_RATIO"
                                      + " From EPGP_CALCS JOIN EPGP_PI_PRI_WEIGHTS"
                                      +
                                      " On EPGP_CALCS.CL_RESULT=EPGP_PI_PRI_WEIGHTS.CW_RESULT And EPGP_CALCS.CL_COMPONENT=EPGP_PI_PRI_WEIGHTS.CW_COMPONENT"
                                      + " And EPGP_CALCS.CL_PRI=1";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            lRowsAffected = oCommand.ExecuteNonQuery();

                        }
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateComponents", (StatusEnum) 99849,
                                                        ex.Message.ToString());
                    }
                }
            }

            Status_Error:

            return eStatus;
        }

        private static StatusEnum PerformCustomFieldsCalculate(DBAccess dba)
        {
            //StatusEnum eStatus = StatusEnum.rsSuccess;

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

            string sCommand =
                "SELECT     EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ, EPGP_CALCS.CL_RESULT, EPGC_FIELD_ATTRIBS.FA_FIELD_IN_TABLE, " +
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
                        seqStmt +=
                            "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";
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
                seqStmt +=
                    "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";
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

            //if (sWEServerURL.Length > 0)
            //{
            //    string sXMLRequest;
            //    if (dbaUsers.ExportPIInfo(dba, Projectids, out sXMLRequest) == StatusEnum.rsSuccess)
            //    {

            //XmlNode xNode;
            //if (SendXMLToWorkEngine(dba, sWEServerURL, "UpdateItems", sXMLRequest, out xNode) != StatusEnum.rsSuccess)
            //    goto Exit_Function;

            //if (xNode != null)
            //{
            //    CStruct xResult = new CStruct();
            //    if (xResult.LoadXML(xNode.OuterXml) == false)
            //    {
            //        dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99843, "Invalid XML response from WorkEngine WebService");
            //        goto Exit_Function;
            //    }

            //    if (xResult.GetIntAttr("Status") != 0)
            //    {
            //        CStruct xError = xResult.GetSubStruct("Error");
            //        string sError = xError.GetStringAttr("ID") + " : " + xError.GetString("");
            //        dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99842, "Invalid XML response from WorkEngine WebService\n\nStatus=" + xResult.GetStringAttr("Status") + "\n\nError=" + sError);
            //        goto Exit_Function;
            //    }
            //}

            //    }
            //}

            //Exit_Function:

            //if (dba != null)
            //{
            //    if (dba.Status != StatusEnum.rsSuccess)
            //    {
            //        HandleDBAccessError("PerformCustomFieldsCalculate", dba);
            //    }
            //}

            return dba.Status;
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
                sfn = "IsNull(cast(Left(PT_" + lfit.ToString("000") + ", PatIndex('%[^0-9]%', PT_" +
                      lfit.ToString("000") + "+'x' ) - 1 ) as int),0)";
            }

            return sfn;
        }

        //    //    private static StatusEnum SendXMLToWorkEngine(DBAccess dba, string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        //    //    {
        //    //        xNode = null;
        //    //        HttpContext context = HttpContext.Current;
        //    //        if (PPM.WebAdmin.CheckProductFlag(context, (uint)Security.ProductFlag.pfSPWorkEngine) == true)
        //    //        {
        //    //            IntPtr token = ((WindowsIdentity)context.User.Identity).Token;
        //    //            WindowsImpersonationContext impersonateContext = WindowsIdentity.Impersonate(token);
        //    //            PPM.LMRSession weInt = new PPM.LMRSession();
        //    //            weInt.BeginSession(sURL);
        //    //            try
        //    //            {
        //    //                WebAdmin.DBTrace((StatusEnum)0, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "WE Request", "Context=" + sContext + "; URL=" + sURL, sXMLRequest);
        //    //                if (!weInt.ExecuteProcess2(sContext, sXMLRequest, out xNode))
        //    //                {
        //    //                    dba.Status = (StatusEnum)99841;
        //    //                    dba.StatusText = weInt.LastError;
        //    //                    dba.StackTrace = weInt.LastStackTrace;
        //    //                    WebAdmin.DBTrace((StatusEnum)99841, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "WE Exception", weInt.LastError, weInt.LastStackTrace);
        //    //                }
        //    //                if (xNode != null)
        //    //                    WebAdmin.DBTrace((StatusEnum)0, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "WE Reply", "Context=" + sContext + "; URL=" + sURL, xNode.OuterXml.ToString());
        //    //            }
        //    //            catch (Exception ex)
        //    //            {
        //    //                dba.Status = (StatusEnum)99840;
        //    //                dba.StatusText = ex.Message;
        //    //                dba.StackTrace = ex.StackTrace;
        //    //                WebAdmin.DBTrace((StatusEnum)99840, TraceChannelEnum.WebServices, "ClientPrioritization.SendXMLToWorkEngine", "Exception", ex.Message, ex.StackTrace);
        //    //            }
        //    //            finally
        //    //            {
        //    //                weInt.ServerEndSession();
        //    //                impersonateContext.Undo();
        //    //            }
        //    //        }
        //    //        return dba.Status;
        //    //    }
    }
}
