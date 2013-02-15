using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM.Layouts.ppm2
{
    public partial class grouppermissionform : LayoutsPageBase
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
                            DialogTitle = "Add a Permission Group";
                            btnOK.Visible = true;
                            btnDelete.Visible = false;
                            break;
                        case "Modify":
                            DialogTitle = "Modify a Permission Group";
                            btnOK.Visible = true;
                            btnDelete.Visible = false;
                            break;
                        case "Delete":
                            DialogTitle = "Delete Permission Group";
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

                        string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                        dba = new DBAccess(sDBConnect);
                        if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                       
                        DataTable dt;

                        if (m_sMode != "Add")
                        {
                            string cmdText = "SELECT * FROM EPG_GROUPS WHERE GROUP_ID = @p1";
                            dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99917, out dt);
                            //if (dbaUsers.SelectGroup(dba, nGroupId, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                            if (dt.Rows.Count == 1)
                            {
                                DataRow row = dt.Rows[0];
                                txtId.Text = row["GROUP_ID"].ToString();
                                txtName.Text = row["GROUP_NAME"].ToString();
                                txtDesc.Text = row["GROUP_NOTES"].ToString();
                            }
                        }
                        else
                        {
                            txtId.Text = "0";
                            txtName.Text = "New Permission Group";
                        }

                        {
                            //if (dbaUsers.SelectAllGroupPermissions(dba, nGroupId, out dt) != StatusEnum.rsSuccess) goto Exit_Function;
                            string cmdText = "SELECT p.*,gp.GROUP_ID From EPG_PERMISSIONS p"
                                                + " Left Join EPG_GROUP_PERMISSIONS gp On gp.PERM_UID=p.PERM_UID and gp.GROUP_ID=@p1"
                                                + " Order by PERM_ID";
                            dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99925, out dt);

                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    int nLevel = (int)row["PERM_LEVEL"];
                            //    //treetable1.AddRow(row["PERM_UID"].ToString(), nLevel);
                            //    //treetable1.AddValue("outline", row["PERM_NAME"].ToString());
                            //    string name = row["PERM_NAME"].ToString();
                            //    int nJoinedGroup = DBAccess.ReadIntValue(row["GROUP_ID"], out bIsNull);
                            //    int nPermSet;
                            //    if (nJoinedGroup > 0) nPermSet = 1; else nPermSet = 0;
                            //    //if (nLevel > 1) treetable1.AddCheckboxValue("cb1", nPermSet);
                            //}
                            ////treetable1.Render();

                            CStruct xGridLayout = BuildGridLayout();
                            idGridLayout.Value = xGridLayout.ToString(true);
                            CStruct xGridData = BuildGridData(dt);
                            idGridData.Value = xGridData.ToString(true);
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
        private CStruct BuildGridLayout()
        {
            CStruct xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Delete", 0);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("InEditMode", 0);
            xCfg.CreateIntAttr("Sorting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("Dropping", 0);
            xCfg.CreateIntAttr("ColsMoving", 0);
            xCfg.CreateIntAttr("ColsPostLap", 0);
            xCfg.CreateIntAttr("ColsLap", 0);
            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateBooleanAttr("ShowDeleted", true);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "RPEditor");

            xCfg.CreateStringAttr("MainCol", "Permission");

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            CStruct xHeader = xGrid.CreateSubStruct("Header");
            xHeader.CreateIntAttr("Visible", 1);
            xHeader.CreateIntAttr("SortIcons", 0);

            // Add FieldID column
            CStruct xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "FieldID");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);

            // Add name column
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Permission");
            xHeader.CreateStringAttr("Permission", "");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("MinWidth", 70);

            //Add cb column
            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "CB");
            xHeader.CreateStringAttr("CB", "");
            xC.CreateStringAttr("Type", "Bool");
            //xC.CreateStringAttr("BoolIcon", "6");  ugly X when checked
            xC.CreateBooleanAttr("CanEdit", true);
            //xC.CreateIntAttr("MinWidth", 25);

            return xGrid;
        }
        private CStruct BuildGridData(DataTable dt)
        {
            CStruct[] xLevels = new CStruct[2];

            CStruct xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");

            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Permission", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateStringAttr("Def", "Summary");
            xLevels[0] = xI;

            //List<ComponentWeight> Weights = new List<ComponentWeight>();
            //if (dt_Weights != null)
            //{
            //    foreach (DataRow row in dt_Weights.Rows)
            //    {
            //        ComponentWeight cw = new ComponentWeight();
            //        cw.ScenarioId = DBAccess.ReadIntValue(row["CW_RESULT"]);
            //        cw.ComponentId = DBAccess.ReadIntValue(row["CW_COMPONENT"]);
            //        cw.Weight = DBAccess.ReadDoubleValue(row["CW_RATIO"]);
            //        Weights.Add(cw);
            //    }
            //}

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int nPermLevel = DBAccess.ReadIntValue(row["PERM_LEVEL"]);
                    if (nPermLevel > 0)
                    {
                        int nPermUID = DBAccess.ReadIntValue(row["PERM_UID"]);

                        string sPermName = DBAccess.ReadStringValue(row["PERM_NAME"]);

                        CStruct xIParent;
                        if (nPermLevel == 1)
                        {
                            xIParent = xLevels[0];                      // grab the node we are adding a child to
                            xI = xIParent.CreateSubStruct("I");         // add a new child
                            xLevels[1] = xI;                            // save a new parent node at this new level
                            xI.CreateIntAttr("FieldID", nPermUID);      //  carry on and define details for our new node
                            xI.CreateStringAttr("CBType", "Text");        // don't want a cb on title lines
                            xI.CreateBooleanAttr("CanEdit", false);
                            //xI.CreateStringAttr("CB", "");
                        }
                        else
                        {
                            xIParent = xLevels[1];
                            xI = xIParent.CreateSubStruct("I");
                            xI.CreateIntAttr("FieldID", nPermUID);
                            xI.CreateBooleanAttr("CanEdit", true);
                            int nJoinedGroup = DBAccess.ReadIntValue(row["GROUP_ID"]);
                            bool bPermSet;
                            if (nJoinedGroup > 0) bPermSet = true; else bPermSet = false;
                            xI.CreateBooleanAttr("CB", bPermSet);
                        }
                        xI.CreateStringAttr("Permission", sPermName);

                        xI.CreateStringAttr("Color", "254,254,254");
                        xI.CreateIntAttr("NoColorState", 1);
                    }
                }
            }
            return xGrid;
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

            //ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnCostTypeSavedOK();", true);
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
                lblGeneralError.Text = "Error Saving Group : Name cannot be blank";
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
            //if (UpdatePermGroup(dba, this, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            //ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnCostTypeSavedOK();", true);
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
        //private static StatusEnum UpdatePermGroup(DBAccess dba, grouppermissionform Group, out int lRowsAffected)
        //{
        //    StatusEnum eStatus = StatusEnum.rsSuccess;
        //    lRowsAffected = 0;

        //    int nGroupId = Group.id;
        //    string sGroupName = Group.Name;
        //    string sGroupDesc = Group.Desc;

        //    SqlCommand oCommand;
        //    string cmdText;
        //    SqlDataReader reader;

        //    try
        //    {
        //        // make sure there isn't already another group with this name
        //        {
        //            cmdText = "SELECT GROUP_ID From EPG_GROUPS WHERE GROUP_NAME = ?";
        //            oCommand = new SqlCommand(cmdText, dba.Connection);
        //            oCommand.Parameters.Add("GROUP_NAME", SqlType.VarChar, 255).Value = sGroupName;
        //            reader = oCommand.ExecuteReader();

        //            int nExistingGroupId;
        //            if (reader.Read())
        //            {
        //                nExistingGroupId = DBAccess.ReadIntValue(reader["GROUP_ID"]);
        //                if (nExistingGroupId != nGroupId)
        //                {
        //                    eStatus = dba.HandleStatusError(SeverityEnum.Error, "Update Permission Group", (StatusEnum)99912, "Can't save Group, a Group with this name already exists");
        //                    return eStatus;
        //                }
        //            }
        //        }

        //        if (nGroupId > 0)
        //        {
        //            cmdText =
        //                   "UPDATE EPG_GROUPS SET GROUP_NAME=?,GROUP_NOTES=? "
        //               + " WHERE GROUP_ID = " + nGroupId.ToString();
        //        }
        //        else
        //        {
        //            //   need to figure new GROUP_ID
        //            cmdText = "SELECT MAX(GROUP_ID) As maxGroupId FROM EPG_GROUPS";
        //            oCommand = new SqlCommand(cmdText, dba.Connection);
        //            reader = oCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                nGroupId = DBAccess.ReadIntValue(reader["maxGroupId"]);
        //            }
        //            nGroupId = nGroupId + 1;

        //            cmdText =
        //                   "INSERT Into EPG_GROUPS "
        //               + " (GROUP_ID,GROUP_NAME,GROUP_NOTES)"
        //               + " Values(" + nGroupId.ToString() + ",?,?)";
        //        }

        //        oCommand = new SqlSqlCommand(cmdText, dba.Connection);
        //        oCommand.Parameters.AddWithValue("GROUP_NAME", sGroupName);
        //        oCommand.Parameters.AddWithValue("GROUP_NOTES", sGroupDesc);

        //        lRowsAffected += oCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdatePermGroup_Main", (StatusEnum)99911, ex.Message.ToString());
        //        return eStatus;
        //    }

        //    //List<Permission> Permissions;
        //    //Permissions = Group.Permisions;

        //    //if (eStatus == StatusEnum.rsSuccess)
        //    //{
        //    //    lRowsAffected = 0;
        //    //    {
        //    //        try
        //    //        {
        //    //            cmdText =
        //    //                "DELETE FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID = ?";
        //    //            oCommand = new SqlCommand(cmdText, dba.Connection);
        //    //            oCommand.Parameters.AddWithValue("GROUP_ID", nGroupId);
        //    //            lRowsAffected = oCommand.ExecuteNonQuery();

        //    //            if (Permissions.Count > 0)
        //    //            {
        //    //                cmdText =
        //    //                "INSERT INTO EPG_GROUP_PERMISSIONS (GROUP_ID,PERM_UID) " + " VALUES(?,?)";
        //    //                try
        //    //                {
        //    //                    oCommand = new SqlCommand(cmdText, dba.Connection);
        //    //                    oCommand.Parameters.Add("GROUP_ID", OSqlbType.Int).Value = nGroupId;
        //    //                    SqlParameter pPERM_UID = oCommand.Parameters.Add("PERM_UID", SqlDbType.Int);

        //    //                    int lPermRowsAffected = 0;
        //    //                    foreach (Permission permission in Permissions)
        //    //                    {
        //    //                        pPERM_UID.Value = permission.perm;
        //    //                        lPermRowsAffected += oCommand.ExecuteNonQuery();
        //    //                    }
        //    //                }
        //    //                catch (Exception ex)
        //    //                {
        //    //                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateGroup_Perms", (StatusEnum)99910, ex.Message.ToString());
        //    //                }
        //    //            }
        //    //        }
        //    //        catch (Exception ex)
        //    //        {
        //    //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdatePermGroup_Delete_Perms", (StatusEnum)99909, ex.Message.ToString());
        //    //        }
        //    //    }
        //    //}

        //        return eStatus;
        //}
    }
}
