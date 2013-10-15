using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{

    public class dbaModels
    {
        public static StatusEnum SelectModels(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_MODEL_SCENARIOS ORDER BY MODEL_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99920, out dt);
        }
        public static StatusEnum SelectModel(DBAccess dba, int nModelId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_MODEL_SCENARIOS WHERE MODEL_UID = @p1";
            return dba.SelectDataById(cmdText, nModelId, (StatusEnum)99921, out dt);
        }
        public static StatusEnum SelectCostTypesForModel(DBAccess dba, int nModelId, out DataTable dt)
        {
            //string cmdText = "SELECT * FROM EPGP_COST_TYPES Where CT_EDIT_MODE Not In (3,30) ORDER BY CT_NAME ";
            //return dba.SelectData(cmdText, (StatusEnum)99922, out dt);
            const string cmdText = "SELECT ct.CT_ID, CT_NAME,"
            + " case When (cvct.MODEL_CT_ID is null) Then 0 Else 1 End as used"
            + " FROM EPGP_COST_TYPES ct"
            + " LEFT JOIN  EPGP_MODEL_CTS cvct ON (cvct.MODEL_CT_ID = ct.CT_ID AND MODEL_UID = @p1)"
            + " WHERE CT_EDIT_MODE Not In (3,30) ORDER BY CT_NAME";
            return dba.SelectDataById(cmdText, nModelId, (StatusEnum)99922, out dt);
        }
        public static StatusEnum SelectCustomFields_Flags(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FORMAT=13 AND FA_TABLE_ID=201 ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99918, out dt);
        }

        public static StatusEnum SelectModelVersions(DBAccess dba, int nModelId, out DataTable dt)
        {
            const string cmdText = "select mv.MODEL_UID, mv.MODEL_VERSION_UID, mv.MODEL_VERSION_NAME, mv.MODEL_VERSION_DESC, mgs.GROUP_ID, g.GROUP_NAME, mgs.VIEW_PERMISSION, mgs.EDIT_PERMISSION"
            + " from EPGP_MODEL_VERSIONS mv"
            + " left join EPGP_MODEL_GROUP_SECURITY mgs on mgs.MODEL_UID = mv.MODEL_UID and mgs.MODEL_VERSION_UID = mv.MODEL_VERSION_UID"
            + " left join EPG_GROUPS g on g.GROUP_ID = mgs.GROUP_ID"
            + " where mv.MODEL_UID = @p1"
            + " order by MODEL_VERSION_NAME";
            return dba.SelectDataById(cmdText, nModelId, (StatusEnum)99922, out dt);
        }

        //public static StatusEnum SelectSecurityForModel(DBAccess dba, int nModelId, out DataTable dt)
        //{
        //    const string cmdText = "Select GROUP_NAME,s.GROUP_ID,MODEL_VERSION_UID,VIEW_PERMISSION,EDIT_PERMISSION"
        //   + " From EPGP_MODEL_GROUP_SECURITY s"
        //   + " Inner Join EPG_GROUPS g on s.GROUP_ID = g.GROUP_ID"
        //   + " Where MODEL_UID = @p1"
        //   + " Order By MODEL_VERSION_UID,GROUP_NAME";
        //    return dba.SelectDataById(cmdText, nModelId, (StatusEnum)99922, out dt);
        //}
        //public static StatusEnum SelectViews(DBAccess dba, out DataTable dt)
        //{
        //    string cmdText = "SELECT VIEW_UID, VIEW_NAME, VIEW_DESC FROM EPGT_COSTVIEW_DISPLAY ORDER BY VIEW_NAME";
        //    return dba.SelectData(cmdText, (StatusEnum)99971, out dt);
        //}
        //public static StatusEnum SelectCostView(DBAccess dba, int nViewId, out DataTable dt)
        //{
        //    //if (nViewId > 0)
        //    {
        //        const string cmdText = "SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID = @p1";
        //        return dba.SelectDataById(cmdText, nViewId, (StatusEnum)99971, out dt);
        //    }
        //    //else
        //    //{
        //    //    const string cmdText = "SELECT CB_ID=0,CB_NAME='New Calendar',CB_DESC=NULL,CB_LOCK_TO=NULL,CB_LOCK_FROM=NULL";
        //    //    return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        //    //}
        //}

        //public static StatusEnum SelectCostTypesForView(DBAccess dba, int nViewId, out DataTable dt)
        //{
        //    const string cmdText = "SELECT ct.CT_ID, CT_NAME,"
        //    + " case When (cvct.CT_ID is null) Then 0 Else 1 End as used"
        //    + " FROM EPGP_COST_TYPES ct"
        //    + " LEFT JOIN  EPGT_COSTVIEW_COST_TYPES cvct ON (cvct.CT_ID = ct.CT_ID AND VIEW_UID = @p1)"
        //    + " ORDER BY cvct.VT_ID, CT_NAME";
        //    return dba.SelectDataById(cmdText, nViewId, (StatusEnum)99971, out dt);
        //}

        public static StatusEnum UpdateModelInfo(DBAccess dba, ref int nMODEL_UID, string sName, string sDesc, int nCalendar, int nCF, string sCTs, DataTable dtVersions, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // make sure there isn't already another Model with this name
                {
                    sName = sName.Trim();
                    if (sName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "Models.UpdateModelInfo", "Please enter a Model Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    cmdText = "SELECT MODEL_UID From EPGP_MODEL_SCENARIOS WHERE MODEL_NAME = @p1";
                    DataTable dt;
                    if (dba.SelectDataByName(cmdText, sName, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                        sReply = DBAccess.FormatAdminError("exception", "Models.UpdateModelInfo1", dba.StatusText);
                    else if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nExistingId = DBAccess.ReadIntValue(row["MODEL_UID"]);
                        if (nExistingId != nMODEL_UID)
                        {
                            sReply = DBAccess.FormatAdminError("error", "Models.UpdateModelInfo", "Can't save Model.\nA Model with name '" + sName + "' already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }

                if (nMODEL_UID == 0)
                {
                    // ADD - no need to figure new UID as IDENTITY
                    cmdText =
                           "INSERT Into EPGP_MODEL_SCENARIOS (MODEL_NAME,MODEL_DESC,MODEL_CB_ID,MODEL_SELECTED_FIELD_ID)"
                       + " Values(@pMODEL_NAME, @pMODEL_DESC,@pCB_ID,@pCF)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pMODEL_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pMODEL_DESC", sDesc);
                    oCommand.Parameters.AddWithValue("@pCB_ID", nCalendar);
                    oCommand.Parameters.AddWithValue("@pCF", nCF);
                    oCommand.ExecuteNonQuery();
                    dba.GetLastIdentityValue(out nMODEL_UID);
                }
                else
                {
                    //  update
                    cmdText = "UPDATE EPGP_MODEL_SCENARIOS "
                                + " SET MODEL_NAME=@pMODEL_NAME,MODEL_DESC=@pMODEL_DESC,MODEL_CB_ID=@pCB_ID,MODEL_SELECTED_FIELD_ID=@pCF"
                                + " WHERE MODEL_UID = @pMODEL_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pMODEL_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pMODEL_DESC", sDesc);
                    oCommand.Parameters.AddWithValue("@pCB_ID", nCalendar);
                    oCommand.Parameters.AddWithValue("@pCF", nCF);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    oCommand.ExecuteNonQuery();
                }

                if (nMODEL_UID > 0)
                {
                    //  update the list of CTs for this Model
                    SqlTransaction transaction;
                    transaction = dba.Connection.BeginTransaction();
                    cmdText =
                        "DELETE FROM EPGP_MODEL_CTS WHERE MODEL_UID = @pMODEL_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    oCommand.ExecuteNonQuery();

                    string[] costtypes = sCTs.Split(',');
                    cmdText =
                    "INSERT INTO EPGP_MODEL_CTS (MODEL_UID,MODEL_CT_ID)  VALUES(@pMODEL_UID,@pCT_ID)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    SqlParameter pCT_ID = oCommand.Parameters.Add("@pCT_ID", SqlDbType.Int);

                    int ientry;
                    foreach (string sentry in costtypes)
                    {
                        int.TryParse(sentry, out ientry);
                        if (ientry > 0)
                        {
                            pCT_ID.Value = ientry;
                            oCommand.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();

                    // Replace list of Versions and Version Security
                    //   incase need to ADD - need to figure new MODEL_VERSION UID
                    int nNewVersion_UID;
                    cmdText = "SELECT MAX(MODEL_VERSION_UID) as maxUID FROM EPGP_MODEL_VERSIONS Where MODEL_UID=@pMODEL_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                        nNewVersion_UID = DBAccess.ReadIntValue(reader["maxUID"]) + 1;
                    else
                        nNewVersion_UID = 1;
                    reader.Close();

                    transaction = dba.Connection.BeginTransaction();
                    cmdText = "DELETE FROM EPGP_MODEL_GROUP_SECURITY WHERE MODEL_UID = @pMODEL_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    oCommand.ExecuteNonQuery();

                    cmdText = "DELETE FROM EPGP_MODEL_VERSIONS WHERE MODEL_UID = @pMODEL_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    oCommand.ExecuteNonQuery();

                    cmdText = "INSERT INTO EPGP_MODEL_VERSIONS (MODEL_UID,MODEL_VERSION_UID,MODEL_VERSION_NAME,MODEL_VERSION_DESC)  VALUES(@pMODEL_UID,@pVERSION_UID,@pName,@pDesc)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    SqlParameter pVERSION_UID = oCommand.Parameters.Add("@pVERSION_UID", SqlDbType.Int);
                    SqlParameter pName = oCommand.Parameters.Add("@pName", SqlDbType.VarChar);
                    SqlParameter pDesc = oCommand.Parameters.Add("@pDesc", SqlDbType.VarChar);

                    List<PfEModelVersionPermissionGroup> grouppermissions = new List<PfEModelVersionPermissionGroup>();
                    foreach (DataRow row in dtVersions.Rows)
                    {
                        int VERSION_UID = DBAccess.ReadIntValue(row["MODEL_VERSION_UID"]);
                        int Deleted = DBAccess.ReadIntValue(row["Deleted"]);
                        string VERSION_NAME = DBAccess.ReadStringValue(row["MODEL_VERSION_NAME"]);
                        string VERSION_DESC = DBAccess.ReadStringValue(row["MODEL_VERSION_DESC"]);
                        //string Permissions = DBAccess.ReadStringValue(row["MODEL_VERSION_PERMISSIONS"]);
                        string FullPermissions = DBAccess.ReadStringValue(row["MODEL_VERSION_PERMISSIONS_HIDDEN"]);

                        if (Deleted==0)
                        {
                            int version_uid = VERSION_UID;
                            if (version_uid <= 0)
                            {
                                version_uid = nNewVersion_UID;
                                nNewVersion_UID++;
                            }
                            pVERSION_UID.Value = version_uid;
                            pName.Value = VERSION_NAME;
                            pDesc.Value = VERSION_DESC;
                            oCommand.ExecuteNonQuery();

                            // we've written out VERSION record but need to stash the Group Permission info for writting next...
                            string[] permissiongroups = FullPermissions.Split(',');
                            foreach (string sentry in permissiongroups)
                            {
                                // group entry looks like this '1::Admins::1::1'   
                                string[] groupentries = sentry.Split(':');
                                int group_uid;
                                int readpermission;
                                int editpermission;
                                int.TryParse(groupentries[0], out group_uid);
                                if (group_uid > 0)
                                {
                                    int.TryParse(groupentries[4], out readpermission);
                                    int.TryParse(groupentries[6], out editpermission);
                                    PfEModelVersionPermissionGroup pgroup = new PfEModelVersionPermissionGroup();
                                    pgroup.MODEL_UID = nMODEL_UID;
                                    pgroup.VERSION_UID = version_uid;
                                    pgroup.GROUP_UID = group_uid;
                                    pgroup.ReadPermission = readpermission;
                                    pgroup.EditPermission = editpermission;
                                    grouppermissions.Add(pgroup);
                                }
                            }
                        }
                    }

                    //ok now add the permission group info for the Versions we've just added
                    cmdText = "INSERT INTO EPGP_MODEL_GROUP_SECURITY (MODEL_UID,MODEL_VERSION_UID,GROUP_ID,VIEW_PERMISSION, EDIT_PERMISSION)" +
                                "VALUES(@pMODEL_UID,@pGroupVERSION_UID,@pGroupID,@pReadPermission,@pEditPermission)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pMODEL_UID", nMODEL_UID);
                    SqlParameter pGroupVERSION_UID = oCommand.Parameters.Add("@pGroupVERSION_UID", SqlDbType.Int);
                    SqlParameter pGroupID = oCommand.Parameters.Add("@pGroupID", SqlDbType.Int);
                    SqlParameter pReadPermission = oCommand.Parameters.Add("@pReadPermission", SqlDbType.Int);
                    SqlParameter pEditPermission = oCommand.Parameters.Add("@pEditPermission", SqlDbType.Int);

                    foreach (PfEModelVersionPermissionGroup groupentry in grouppermissions)
                    {
                        pGroupVERSION_UID.Value = groupentry.VERSION_UID;
                        pGroupID.Value = groupentry.GROUP_UID;
                        pReadPermission.Value = groupentry.ReadPermission;
                        pEditPermission.Value = groupentry.EditPermission;
                        oCommand.ExecuteNonQuery();
                    }

                    // Clean up orphans that may have been created by deleting versions
                    oCommand = new SqlCommand("EPG_SP_CleanModelAdmin ", dba.Connection, transaction);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@ModelUID", nMODEL_UID);
                    oCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostViews.UpdateCostViewInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum DeleteModel(DBAccess dba, int nMODEL_UID, out string sReply)
        {
            SqlCommand oCommand;
            sReply = "";
            try
            {
                oCommand = new SqlCommand("EPG_SP_DeleteModel", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@ModelUID", nMODEL_UID);
                oCommand.ExecuteNonQuery();
                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Models.DeleteModel", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private class PfEModelVersionPermissionGroup
        {
            public int MODEL_UID;
            public int VERSION_UID;
            public int GROUP_UID;
            public int ReadPermission;
            public int EditPermission;
        }
    }
}

