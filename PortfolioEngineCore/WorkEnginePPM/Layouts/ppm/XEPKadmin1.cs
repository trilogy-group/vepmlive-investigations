using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    internal class xepkadmin1
    {
        public static StatusEnum SelectFields(DBAccess dba, out DataTable dt)
        {
            string cmdText =
                "SELECT * FROM EPGC_FIELD_ATTRIBS Where ((FA_TABLE_ID=203 and FA_FORMAT=3) or (FA_TABLE_ID=202 and FA_FORMAT=9)) ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99858, out dt);
        }

        public static string UpdatePermissions(string sContextInfo, string sData)
        {
            string sReply = "";
            try
            {
                CStruct xPage = new CStruct();
                if (xPage.FromString(sData, true) == false)
                {
                    sReply = "UpdatePermissions : Unable to load Page XML";
                    return sReply;
                }
                else
                {
                    SqlCommand oCommand;
                    SqlDataReader reader;
                    string cmdText;

                    string sDBConnect = WebAdmin.GetConnectionString(sContextInfo);
                    DBAccess dba = new DBAccess(sDBConnect);
                    if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                    
                    try
                    {
                        string sid = xPage.GetStringAttr("id");
                        string name = xPage.GetStringAttr("name");
                        string desc = xPage.GetStringAttr("desc");
                        int nGroupId;
                        int.TryParse(sid, out nGroupId);
                        //if (nGroupId <= 0)    // WHAT ABOUT A NEW GROUP?
                        //{
                        //    sReply = "Error saving Group : Invalid Group Id";
                        //    return sReply;
                        //}
                        if (name.Trim() == string.Empty)
                        {
                            sReply = "Error saving Group : Name cannot be blank";
                            return sReply;
                        }

                        // make sure there isn't already another group with this name
                        {
                            cmdText = "SELECT GROUP_ID From EPG_GROUPS WHERE GROUP_NAME = @GROUP_NAME";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Parameters.Add("@GROUP_NAME", SqlDbType.VarChar, 255).Value = name;
                            reader = oCommand.ExecuteReader();

                            int nExistingGroupId;
                            if (reader.Read())
                            {
                                nExistingGroupId = DBAccess.ReadIntValue(reader["GROUP_ID"]);
                                if (nExistingGroupId != nGroupId)
                                {
                                    sReply = "Error saving Group : A Group with this name already exists";
                                    return sReply;
                                }
                            }
                        }

                        CStruct xGrid = xPage.GetSubStruct("Grid");
                        // get list of Permissions that are ON from XML
                        CStruct xBody = xGrid.GetSubStruct("Body");
                        CStruct xB = xBody.GetSubStruct("B");
                        List<CStruct> listIGroups = xB.GetList("I");  // list of permission sections

                        List<int> c_permissions = new List<int>();
                        foreach (CStruct xIGroup in listIGroups)
                        {
                            List<CStruct> listI = xIGroup.GetList("I");  // list of permissions
                            foreach (CStruct xI in listI)
                            {
                                int uid = xI.GetIntAttr("FieldID");
                                int perm_value = xI.GetIntAttr("CB");
                                if (perm_value != 0) c_permissions.Add(uid);
                            }
                        }

                        dba.BeginTransaction();
                        if (nGroupId > 0)
                        {
                            cmdText =
                                   "UPDATE EPG_GROUPS SET GROUP_NAME=@GROUP_NAME,GROUP_NOTES=@GROUP_NOTES "
                               + " WHERE GROUP_ID = " + nGroupId.ToString();
                        }
                        else
                        {
                            //   need to figure new GROUP_ID
                            cmdText = "SELECT MAX(GROUP_ID) As maxGroupId FROM EPG_GROUPS";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            reader = oCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                nGroupId = DBAccess.ReadIntValue(reader["maxGroupId"]);
                            }
                            nGroupId = nGroupId + 1;

                            cmdText =
                                   "INSERT Into EPG_GROUPS "
                               + " (GROUP_ID,GROUP_NAME,GROUP_NOTES)"
                               + " Values(" + nGroupId.ToString() + ",@GROUP_NAME,@GROUP_NOTES)";
                        }
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        oCommand.Parameters.AddWithValue("@GROUP_NAME", name);
                        oCommand.Parameters.AddWithValue("@GROUP_NOTES", desc);
                        oCommand.Transaction = dba.Transaction;
                        oCommand.ExecuteNonQuery();

                        // update the permissions
                        cmdText = "DELETE FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID = @GROUP_ID";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        oCommand.Parameters.AddWithValue("@GROUP_ID", nGroupId);
                        oCommand.Transaction = dba.Transaction;
                        oCommand.ExecuteNonQuery();

                        if (c_permissions.Count > 0)
                        {
                            cmdText = "INSERT INTO EPG_GROUP_PERMISSIONS (GROUP_ID,PERM_UID) " + " VALUES(@GROUP_ID,@PERM_UID)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            oCommand.Parameters.AddWithValue("@GROUP_ID", nGroupId);
                            SqlParameter pPERM_UID = oCommand.Parameters.Add("@PERM_UID", SqlDbType.Int);
                            oCommand.Transaction = dba.Transaction;

                            foreach (int perm_uid in c_permissions)
                            {
                                pPERM_UID.Value = perm_uid;
                                oCommand.ExecuteNonQuery();
                            }
                        }

                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        dba.RollbackTransaction();
                        sReply = HandleException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException(ex);
            }

        Exit_Function:
        Status_Error:
            return sReply;
        }

        public static string HandleException(Exception ex)
        {
            return "Permissions Exception : " + ex.Message.ToString();
        }
    }
}
