using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PortfolioEngineCore
{
    public class dbaGroups
    {
        public static StatusEnum SelectGroups(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT GROUP_ID, GROUP_NAME, GROUP_NOTES FROM EPG_GROUPS Where GROUP_ENTITY=1 ORDER BY GROUP_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }
        public static StatusEnum SelectCostTypeSecurityGroups(DBAccess dba, int nCosttypeID, out DataTable dt)
        {
            const string cmdText = "Select sg.GROUP_ID, GROUP_NAME, DS_READ, DS_EDIT "
                             + " From EPG_GROUPS sg"
                             + " Left Join EPGP_DATA_SECURITY ds on ds.GROUP_ID = sg.GROUP_ID AND ds.DS_CONTEXT = 2 AND ds.DS_UID=@p1"
                             + " Where GROUP_ENTITY=1 "
                             + " Order by GROUP_NAME";
            return dba.SelectDataById(cmdText, nCosttypeID, (StatusEnum)99999, out dt);
        }
        public static StatusEnum SelectGroup(DBAccess dba, int nGroupID, out DataTable dt)
        {
            const string cmdText = "SELECT GROUP_ID, GROUP_NAME, GROUP_NOTES FROM EPG_GROUPS Where GROUP_ENTITY=1 AND GROUP_ID=@p1";

            return dba.SelectDataById(cmdText, nGroupID, (StatusEnum)99999, out dt);
        }
        public static StatusEnum SelectGroupMembers(DBAccess dba, int nGroupID, out DataTable dt)
        {
            const string cmdText = "SELECT GM.MEMBER_UID, R.RES_NAME"
                             + "  FROM EPG_GROUP_MEMBERS GM"
                             + "  LEFT JOIN EPG_GROUPS G ON (G.GROUP_ID = GM.GROUP_ID)"
                             + "  LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = GM.MEMBER_UID)"
                             + " WHERE GROUP_ENTITY = 1 AND GM.GROUP_ID = @p1";

            return dba.SelectDataById(cmdText, nGroupID, (StatusEnum)99999, out dt);
        }
        public static StatusEnum UpdateGroupPermissionsInfo(DBAccess dba, ref int nGroupId, string sName, string sNotes, CStruct xPerms, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader;
            StatusEnum eStatus = StatusEnum.rsSuccess;

            List<CStruct> listPerms = xPerms.GetList("Perm");  //new list of permissions
            sReply = "";
            try
            {
                // make sure there isn't already another group with this name
                {
                    sName = sName.Trim();
                    if (sName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "Customfields.UpdateGroupPermissionsInfo", "Please enter a Group Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    cmdText = "SELECT GROUP_ID From EPG_GROUPS WHERE GROUP_NAME = @p1";  // NOTE that we don't allow groups of same name even when ENTITY is different - could really
                    DataTable dt;
                    if (dba.SelectDataByName(cmdText, sName, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                        sReply = DBAccess.FormatAdminError("exception", "GroupPermissions.UpdateGroupPermissionsInfo1", dba.StatusText);
                    else if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nExistingId = DBAccess.ReadIntValue(row["GROUP_ID"]);
                        if (nExistingId != nGroupId)
                        {
                            sReply = DBAccess.FormatAdminError("error", "Customfields.UpdateGroupPermissionsInfo", "Can't save group.\nA group with name '" + sName + "' already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }

                if (nGroupId == 0)
                {
                    // ADD - need to figure new GROUP_ID
                    cmdText = "SELECT MAX(GROUP_ID) As maxGroupId FROM EPG_GROUPS";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    reader = oCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        nGroupId = DBAccess.ReadIntValue(reader["maxGroupId"]);
                    }
                    reader.Close();
                    nGroupId = nGroupId + 1;

                    cmdText =
                           "INSERT Into EPG_GROUPS (GROUP_ENTITY,GROUP_ID,GROUP_NAME,GROUP_NOTES)"
                       + " Values(1,@pGROUP_ID, @pGROUP_NAME, @pGROUP_NOTES)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pGROUP_ID", nGroupId);
                    oCommand.Parameters.AddWithValue("@pGROUP_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pGROUP_NOTES", sNotes);
                    oCommand.ExecuteNonQuery();
                }
                else
                {
                    //  update the group
                    cmdText = "UPDATE EPG_GROUPS "
                                + " SET GROUP_NAME=@pGROUP_NAME,GROUP_NOTES=@pGROUP_NOTES"
                                + " WHERE GROUP_ID = @pGROUP_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@pGROUP_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pGROUP_NOTES", sNotes);
                    oCommand.Parameters.AddWithValue("@pGROUP_ID", nGroupId);
                    oCommand.ExecuteNonQuery();
                }

                //  update the permissions
                SqlTransaction transaction = dba.Connection.BeginTransaction();
                cmdText =
                    "DELETE FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID = @pGROUP_ID";
                oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                oCommand.Parameters.AddWithValue("@pGROUP_ID", nGroupId);
                oCommand.ExecuteNonQuery();

                if (listPerms.Count > 0)
                {
                    cmdText =
                    "INSERT INTO EPG_GROUP_PERMISSIONS (GROUP_ID,PERM_UID)  VALUES(@pGROUP_ID,@pPERM_UID)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pGROUP_ID", nGroupId);
                    SqlParameter pPERM_UID = oCommand.Parameters.Add("@pPERM_UID", SqlDbType.Int);

                    foreach (CStruct xP in listPerms)
                    {
                        pPERM_UID.Value = xP.GetIntAttr("ID");
                        oCommand.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Customfields.UpdateGroupPermissionsInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum DeleteGroupPermission(DBAccess dba, int nGroupId, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                // get info for group to be deleted
                {
                    cmdText = "SELECT GROUP_ID, GROUP_NAME, GROUP_NOTES FROM EPG_GROUPS Where GROUP_ENTITY=1 AND GROUP_ID=@p1";
                    DataTable dt;
                    dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99999, out dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nGroup = DBAccess.ReadIntValue(row["GROUP_ID"]);
                    }
                    else
                    {
                        sReply = DBAccess.FormatAdminError("error", "GroupPermission.DeleteGroupPermission", "Can't delete group, group not found");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                //   clear group data from Resources
                cmdText = "DELETE FROM EPG_GROUP_MEMBERS WHERE GROUP_ID = @pGroupld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pGroupld", nGroupId);
                oCommand.ExecuteNonQuery();

                // Delete the Permissions
                cmdText = "DELETE FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID = @pGroupld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pGroupld", nGroupId);
                oCommand.ExecuteNonQuery();

                // Delete the Group itself
                cmdText = "DELETE FROM EPG_GROUPS WHERE GROUP_ID = @pGroupld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pGroupld", nGroupId);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "GroupPermission.DeleteGroupPermission", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
    }
}
