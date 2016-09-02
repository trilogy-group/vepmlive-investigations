using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;

namespace WorkEnginePPM.Layouts.ppm3
{
    public partial class calendarform : LayoutsPageBase
    {
        protected string DialogTitle = "";
        private int c_id = 0;
        public int id
        {
            get { return c_id; }
        }
        private string c_name = "";
        public string Name
        {
            get { return c_name; }
        }
        private string c_desc = "";
        public string Desc
        {
            get { return c_desc; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            Boolean bIsNull;
            if (!IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    string m_sId = Request.QueryString["id"].ToString();
                    string m_sMode = Request.QueryString["mode"].ToString();

                    //if (!PPM.WebAdmin.HasPagePermission("CustomFieldForm", m_sMode))
                    //    HttpContext.Current.Response.Redirect("NoPermForm.aspx");

                    //lblMode.Text = "Unknown Mode";
                    switch (m_sMode)
                    {
                        case "Add":
                            DialogTitle = "Add a Calendar";
                            btnOK.Visible = true;
                            btnDelete.Visible = false;
                            break;
                        case "Modify":
                            DialogTitle = "Modify a Calendar";
                            btnOK.Visible = true;
                            btnDelete.Visible = false;
                            break;
                        case "Delete":
                            DialogTitle = "Delete a Calendar";
                            btnOK.Visible = false;
                            btnDelete.Visible = true;
                            txtName.Enabled = false;
                            break;
                    }

                    int nGroupId;
                    if (Int32.TryParse(m_sId, out nGroupId))
                    {
                        string basePath = WebAdmin.GetBasePath();
                        hiddenData.Value = basePath;
                        string sDBConnect = WebAdmin.GetConnectionString(basePath);
                        dba = new DBAccess(sDBConnect);
                        if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                        DataTable dt;

                        if (m_sMode != "Add")
                        {
                            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = @p1";
                            dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99917, out dt);
                            //if (dbaUsers.SelectGroup(dba, nGroupId, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                            if (dt.Rows.Count == 1)
                            {
                                DataRow row = dt.Rows[0];
                                txtId.Text = row["CB_ID"].ToString();
                                txtName.Text = row["CB_NAME"].ToString();
                                txtDesc.Text = row["CB_DESC"].ToString();
                            }
                        }
                        else
                        {
                            txtId.Text = "0";
                            txtName.Text = "New Calendar";
                        }

                        {
                            //if (dbaUsers.SelectAllGroupPermissions(dba, nGroupId, out dt) != StatusEnum.rsSuccess) goto Exit_Function;
                            string cmdText = "SELECT * From EPG_PERIODS Where CB_ID=@p1"
                                                + " Order by PRD_ID";
                            dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99999, out dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                //int nLevel = (int)row["PERM_LEVEL"];
                                ////treetable1.AddRow(row["PERM_UID"].ToString(), nLevel);
                                ////treetable1.AddValue("outline", row["PERM_NAME"].ToString());
                                //string name = row["PERM_NAME"].ToString();
                                //int nJoinedGroup = DBAccess.ReadIntValue(row["GROUP_ID"], out bIsNull);
                                //int nPermSet;
                                //if (nJoinedGroup > 0) nPermSet = 1; else nPermSet = 0;
                                ////if (nLevel > 1) treetable1.AddCheckboxValue("cb1", nPermSet);
                            }
                            //treetable1.Render();
                        }

                        dba.Close();
                    }
                }
            }
            return;
        Status_Error:
            if (dba != null)
            {
                dba.Close();
                lblGeneralError.Text = dba.FormatErrorText();
                lblGeneralError.Visible = true;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DBAccess dba = null;
            Int32.TryParse(txtId.Text, out c_id);

            string basePath = hiddenData.Value;
            string sDBConnect = WebAdmin.GetConnectionString(basePath);
            dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

            int lRowsAffected;
            //if (DeleteCustomField(dba, this, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnCostTypeSavedOK();", true);
        Exit_Function:
            if (dba != null)
            {
                if (dba.Status != StatusEnum.rsSuccess)
                {
                    lblGeneralError.Text = dba.FormatErrorText();
                    lblGeneralError.Visible = true;
                }
                dba.Close();
            }
            return;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            DBAccess dba = null;
            if (txtName.Text.Trim() == string.Empty)
            {
                lblGeneralError.Text = "Error Saving Calendar : Name cannot be blank";
                lblGeneralError.Visible = true;
                return;
            }

            Int32.TryParse(txtId.Text, out c_id);
            c_name = txtName.Text;
            c_desc = txtDesc.Text;

            //// Stick clicked permissions into collection
            //DataTable dtResult = treetable1.GetData();
            //c_permissions = new List<Permission>();
            //Permission perm;
            //foreach (DataRow row in dtResult.Rows)
            //{
            //    if (row["cb1"].ToString() == "1")
            //    {
            //        perm = new Permission();
            //        perm.group = c_id;
            //        perm.perm = DBAccess.ReadIntValue(row["RowUID"]);
            //        c_permissions.Add(perm);
            //    }
            //}

            string basePath = hiddenData.Value;
            string sDBConnect = WebAdmin.GetConnectionString(basePath);
            dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

            int lRowsAffected;
            if (UpdateCalendar(dba, this, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnCostTypeSavedOK();", true);
        Exit_Function:
            if (dba != null)
            {
                if (dba.Status != StatusEnum.rsSuccess)
                {
                    lblGeneralError.Text = dba.FormatErrorText();
                    lblGeneralError.Visible = true;
                }
                dba.Close();
            }
            return;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnCostTypeClose();", true);
        }
        private static StatusEnum UpdateCalendar(DBAccess dba, calendarform Group, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            int nGroupId = Group.id;
            string sGroupName = Group.Name;
            string sGroupDesc = Group.Desc;

            SqlCommand oCommand;
            string cmdText;
            SqlDataReader reader;

            try
            {
                // make sure there isn't already another calendar with this name
                {
                    cmdText = "SELECT CB_ID From EPGP_COST_BREAKDOWNS WHERE CB_NAME = @GROUP_NAME";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.Add("@GROUP_NAME", SqlDbType.VarChar, 255).Value = sGroupName;
                    reader = oCommand.ExecuteReader();

                    int nExistingGroupId;
                    if (reader.Read())
                    {
                        nExistingGroupId = DBAccess.ReadIntValue(reader["CB_ID"]);
                        if (nExistingGroupId != nGroupId)
                        {
                            eStatus = dba.HandleStatusError(SeverityEnum.Error, "Update Calendar", (StatusEnum)99912, "Can't save, a Calendar with this name already exists");
                            return eStatus;
                        }
                    }
                }

                if (nGroupId > 0)
                {
                    cmdText =
                           "UPDATE EPGP_COST_BREAKDOWNS SET CB_NAME=?,CB_DESC=? "
                       + " WHERE CB_ID = " + nGroupId.ToString();
                }
                else
                {
                    //   need to figure new GROUP_ID
                    cmdText = "SELECT MAX(CB_ID) As maxGroupId FROM EPGP_COST_BREAKDOWNS";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    reader = oCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        nGroupId = DBAccess.ReadIntValue(reader["maxGroupId"]);
                    }
                    nGroupId = nGroupId + 1;

                    cmdText =
                           "INSERT Into EPGP_COST_BREAKDOWNS "
                       + " (CB_ID,CB_NAME,CB_DESC)"
                       + " Values(" + nGroupId.ToString() + ",@CB_NAME,@CB_DESC)";
                }

                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@CB_NAME", sGroupName);
                oCommand.Parameters.AddWithValue("@CB_DESC", sGroupDesc);

                lRowsAffected += oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCalendar_Main", (StatusEnum)99911, ex.Message.ToString());
                return eStatus;
            }

            //List<Permission> Permissions;
            //Permissions = Group.Permisions;

            //if (eStatus == StatusEnum.rsSuccess)
            //{
            //    lRowsAffected = 0;
            //    {
            //        try
            //        {
            //            cmdText =
            //                "DELETE FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID = ?";
            //            oCommand = new SQLCommand(cmdText, dba.Connection);
            //            oCommand.Parameters.AddWithValue("GROUP_ID", nGroupId);
            //            lRowsAffected = oCommand.ExecuteNonQuery();

            //            if (Permissions.Count > 0)
            //            {
            //                cmdText =
            //                "INSERT INTO EPG_GROUP_PERMISSIONS (GROUP_ID,PERM_UID) " + " VALUES(?,?)";
            //                try
            //                {
            //                    oCommand = new SqlCommand(cmdText, dba.Connection);
            //                    oCommand.Parameters.Add("GROUP_ID", SqlDbType.Int).Value = nGroupId;
            //                    SqlParameter pPERM_UID = oCommand.Parameters.Add("PERM_UID", SqlDbType.Int);

            //                    int lPermRowsAffected = 0;
            //                    foreach (Permission permission in Permissions)
            //                    {
            //                        pPERM_UID.Value = permission.perm;
            //                        lPermRowsAffected += oCommand.ExecuteNonQuery();
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateGroup_Perms", (StatusEnum)99910, ex.Message.ToString());
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCalendar_Delete_Perms", (StatusEnum)99909, ex.Message.ToString());
            //        }
            //    }
            //}

                return eStatus;
        }
    }
}
