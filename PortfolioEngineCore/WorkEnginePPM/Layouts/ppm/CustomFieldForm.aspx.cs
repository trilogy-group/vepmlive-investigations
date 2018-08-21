using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class CustomFieldForm : LayoutsPageBase
    {
        protected string DialogTitle = "";
        private int c_id = 0;
        public int id
        {
            get { return c_id; }
        }
        private int c_entity = 0;
        public int Entity
        {
            get { return c_entity; }
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
        private int c_datatype = 0;
        public int DataType
        {
            get { return c_datatype; }
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
                            DialogTitle = "Add a new Custom Field";
                            btnOK.Visible = true;
                            btnDelete.Visible = false;
                            break;
                        case "Modify":
                            DialogTitle = "Modify Custom Field";
                            btnOK.Visible = true;
                            btnDelete.Visible = false;
                            ddlEntity.Enabled = false;
                            ddlFieldType.Enabled = false;
                            break;
                        case "Delete":
                            DialogTitle = "Delete Custom Field";
                            btnOK.Visible = false;
                            btnDelete.Visible = true;
                            txtName.Enabled = false;
                            ddlEntity.Enabled = false;
                            ddlFieldType.Enabled = false;
                            break;
                    }

                    ddlEntity.Items.Clear();
                    int nEntity;
                    nEntity = (int)EntityID.Portfolio;
                    ddlEntity.Items.Add(new ListItem(EPKClass01.GetEntity(nEntity), nEntity.ToString()));
                    nEntity = (int)EntityID.Resource;
                    ddlEntity.Items.Add(new ListItem(EPKClass01.GetEntity(nEntity), nEntity.ToString()));

                    ddlFieldType.Items.Clear();
                    int nDataType;
                    nDataType = (int)FieldType.TypeText;
                    ddlFieldType.Items.Add(new ListItem(EPKClass01.GetDataType(nDataType), nDataType.ToString()));
                    nDataType = (int)FieldType.TypeNumber;
                    ddlFieldType.Items.Add(new ListItem(EPKClass01.GetDataType(nDataType), nDataType.ToString()));
                    nDataType = (int)FieldType.TypeCost;
                    ddlFieldType.Items.Add(new ListItem(EPKClass01.GetDataType(nDataType), nDataType.ToString()));
                    nDataType = (int)FieldType.TypeFlag;
                    ddlFieldType.Items.Add(new ListItem(EPKClass01.GetDataType(nDataType), nDataType.ToString()));
                    nDataType = (int)FieldType.TypeDate;
                    ddlFieldType.Items.Add(new ListItem(EPKClass01.GetDataType(nDataType), nDataType.ToString()));
                    nDataType = (int)FieldType.TypeMVCode;
                    ddlFieldType.Items.Add(new ListItem(EPKClass01.GetDataType(nDataType), nDataType.ToString()));

                    int nFieldId;
                    if (Int32.TryParse(m_sId, out nFieldId))
                    {
                        string basePath = WebAdmin.GetBasePath();
                        hiddenData.Value = basePath;
                        string sDBConnect = WebAdmin.GetConnectionString(basePath);
                        dba = new DBAccess(sDBConnect);
                        if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                        DataTable dt;

                        if (m_sMode != "Add")
                        {
                            if (nFieldId <= 0)
                            {
                                lblGeneralError.Text = "Invalid field selected";
                                lblGeneralError.Visible = true;
                            }
                            else
                            {
                                string cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1";
                                dba.SelectDataById(cmdText, nFieldId, (StatusEnum)99917, out dt);
                                //if (dbaUsers.SelectCustomField(dba, nFieldId, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                                if (dt.Rows.Count == 1)
                                {
                                    DataRow row = dt.Rows[0];
                                    txtId.Text = row["FA_FIELD_ID"].ToString();
                                    txtName.Text = row["FA_NAME"].ToString();
                                    txtDesc.Text = row["FA_DESC"].ToString();
                                    int iTable = DBAccess.ReadIntValue(row["FA_TABLE_ID"], out bIsNull);
                                    int iEntity = EPKClass01.GetEntityID(iTable);
                                    ddlEntity.SelectedValue = iEntity.ToString();
                                    int iDataType = DBAccess.ReadIntValue(row["FA_FORMAT"], out bIsNull);
                                    ddlFieldType.SelectedValue = iDataType.ToString();
                                }
                            }

                            if (m_sMode == "Delete")
                            {
                                string deletemessage = "";
                                if (CanDeleteCustomField(dba, nFieldId, out deletemessage) == false)
                                {
                                    lblGeneralError.Text = deletemessage;
                                    lblGeneralError.Visible = true;
                                    btnDelete.Visible = false;
                                }
                                else
                                {
                                    CheckDeleteCustomField(dba, nFieldId, out deletemessage);
                                    lblGeneralError.Text = deletemessage;
                                    lblGeneralError.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            txtId.Text = "0";
                            txtName.Text = "New Custom Field";
                        }

                        dba.Close();
                    }
                    else
                    {
                        lblGeneralError.Text = "Invalid field selected";
                        lblGeneralError.Visible = true;
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
            if (DeleteCustomField(dba, this, out lRowsAffected) != StatusEnum.rsSuccess)
            {
                lblGeneralError.Text = "DELETE FAILED!";
                lblGeneralError.Visible = true;
                dba.Close();
                return;
            }

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
                lblGeneralError.Text = "Error Saving Field : Name cannot be blank";
                lblGeneralError.Visible = true;
                return;
            }

            Int32.TryParse(txtId.Text, out c_id);
            c_name = txtName.Text;
            c_desc = txtDesc.Text;
            Int32.TryParse(ddlEntity.SelectedValue, out c_entity);
            Int32.TryParse(ddlFieldType.SelectedValue, out c_datatype);

            string basePath = hiddenData.Value;
            string sDBConnect = WebAdmin.GetConnectionString(basePath);
            dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

            int lRowsAffected;
            if (UpdateCustomField(dba, this, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

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
        private static StatusEnum UpdateCustomField(DBAccess dbAccess, CustomFieldForm customField, out int rowsAffected)
        {
            StatusEnum eStatus;
            rowsAffected = 0;

            try
            {
                // make sure there isn't already another field with this name
                if (!CheckExistingId(dbAccess, customField, out eStatus))
                {
                    return eStatus;
                }
                
                if (customField.id > 0)
                {
                    rowsAffected += UpdateField(dbAccess, customField);
                }
                else
                {
                    // figure which table
                    var tableId = EPKClass01.GetTableID(customField.Entity, customField.DataType);
                    string tableName;
                    string fieldNam;
                    if (EPKClass01.GetTableAndField(tableId, 1, out tableName, out fieldNam))
                    {
                        var maxField = GetMaxField(dbAccess, out eStatus, tableName, fieldNam);

                        var useField = GetUseField(dbAccess, tableId, maxField);

                        if (useField > maxField)
                        {
                            eStatus = dbAccess.HandleStatusError(SeverityEnum.Error, "Update_CustomField", (StatusEnum)99884, "Can't save Field, all Fields of this type are already used");
                            return eStatus;
                        }

                        rowsAffected += AddField(dbAccess, customField, tableId, useField);
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dbAccess.HandleStatusError(SeverityEnum.Exception, "UpdateCustomField_Main", (StatusEnum)99883, ex.Message.ToString());
            }

            return eStatus;
        }

        private static bool CheckExistingId(DBAccess dbAccess, CustomFieldForm customField, out StatusEnum eStatus)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (customField == null)
            {
                throw new ArgumentNullException(nameof(customField));
            }

            eStatus = StatusEnum.rsSuccess;

            const string cmdText = "SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME";
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                command.Parameters.Add("@FIELD_NAME", SqlDbType.VarChar, 255).Value = customField.Name;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var existingId = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);
                        if (existingId != customField.id)
                        {
                            eStatus = dbAccess.HandleStatusError(SeverityEnum.Error, "Update_CustomField", (StatusEnum)99886, "Can't save Field, a Field with this name already exists");
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static int UpdateField(DBAccess dbAccess, CustomFieldForm customField)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (customField == null)
            {
                throw new ArgumentNullException(nameof(customField));
            }
            var cmdText = new StringBuilder();
            cmdText.Append("UPDATE EPGC_FIELD_ATTRIBS ")
                .Append(" SET FA_NAME=@pNAME,FA_DESC=@pDESC")
                .AppendFormat(" WHERE FA_FIELD_ID = {0}", customField.id);

            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                command.Parameters.AddWithValue("@pNAME", customField.Name);
                command.Parameters.AddWithValue("@pDESC", customField.Desc);
                return command.ExecuteNonQuery();
            }
        }

        private static int GetMaxField(DBAccess dbAccess, out StatusEnum eStatus, string tableName, string fieldNam)
        {
            var cmdText = $"SELECT TOP 1 * FROM {tableName}";
            DataTable dataTable;
            eStatus = dbAccess.SelectData(cmdText, (StatusEnum)99885, out dataTable);

            // find the field with the highest number suffix - eg PC_050 - user can add to these tables
            string ColumnName;
            var maxField = 0;
            var prefix = fieldNam.Substring(0, 3);
            DataColumnCollection columns = dataTable.Columns;
            foreach (DataColumn column in columns)
            {
                ColumnName = column.ColumnName;
                string sThisPrefix = ColumnName.Substring(0, 3);
                if (sThisPrefix == prefix)
                {
                    string sfieldnumber = ColumnName.Substring(3);
                    var fieldNumber = int.Parse(ColumnName.Substring(3));
                    if (fieldNumber > maxField)
                    {
                        maxField = fieldNumber;
                    }
                }
            }

            return maxField;
        }

        private static int GetUseField(DBAccess dbAccess, int tableId, int maxField)
        {
            var useField = 1;
            var listUsedFields = new List<int>();
            var cmdText = $"SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID={tableId}";
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fieldNumber = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                        listUsedFields.Add(fieldNumber);
                    }
                }

                for (useField = 1; useField < maxField + 2; useField++)
                {
                    if (!listUsedFields.Contains(useField))
                    {
                        break;
                    }
                }
            }

            return useField;
        }

        private static int AddField(DBAccess dbAccess, CustomFieldForm customField, int tableId, int useField)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (customField == null)
            {
                throw new ArgumentNullException(nameof(customField));
            }
            var cmdText = new StringBuilder();
            cmdText.Append("INSERT Into EPGC_FIELD_ATTRIBS ")
                .Append(" (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE)")
                .Append(" Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)");

            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                command.Parameters.AddWithValue("@pNAME", customField.Name);
                command.Parameters.AddWithValue("@pDESC", customField.Desc);
                command.Parameters.AddWithValue("@pFORMAT", customField.DataType);
                command.Parameters.AddWithValue("@pTABLE", tableId);
                command.Parameters.AddWithValue("@pFIELD", useField);

                return command.ExecuteNonQuery();
            }
        }

        private static Boolean CanDeleteCustomField(DBAccess dba, int nField, out string message)
        {
            message = "";
            try
            {
                {
                    SqlCommand oCommand = new SqlCommand("EPG_SP_ReadUsedCF", dba.Connection);
                    oCommand.Parameters.AddWithValue("@FieldId", nField);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        message += "<br>" + (string)reader["UsedMessage"] + ": ";
                        message += (string)reader["UsedData"];
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                //eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCustomField_Main", (StatusEnum)99883, ex.Message.ToString());
                message += "<br>" + "Check for field used FAILED!";
            }

            if (message.Length > 0)
            {
                message = "This custom field cannot be deleted until you remove it from these areas:" + message;
                return false;
            }
            return true;
        }

        private static Boolean CheckDeleteCustomField(DBAccess dba, int nField, out string message)
        {
            message = "";
            try
            {
                {
                    SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", dba.Connection);
                    oCommand.Parameters.AddWithValue("@FieldId", nField);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = oCommand.ExecuteReader();

                    int lTableNumber = 0;
                    //int lFieldNumber = 0;
                    string sFieldName = "";
                    while (reader.Read())
                    {
                        lTableNumber = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                        //lFieldNumber = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                        sFieldName = DBAccess.ReadStringValue(reader["FA_NAME"]);
                    }
                    reader.Close();

                    if (lTableNumber > 100 && lTableNumber < 200)
                    {
                        message = "Values for " + sFieldName + " will be cleared from all Resources";
                    }
                    else
                    {
                        message = "Values for " + sFieldName + " will be cleared from all PIs";
                    }
                }
            }
            catch (Exception ex)
            {
                //eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCustomField_Main", (StatusEnum)99883, ex.Message.ToString());
                message += "<br>" + "Check for field FAILED!";
            }

            message += "<br><br>Are you sure you want to delete this custom field?";

            return true;
        }

        private static StatusEnum DeleteCustomField(DBAccess dba, CustomFieldForm Field, out int lRowsAffected)
        {
            // NOTE - CF cannot be deleted right now (Sep06) when used in a view or on a TAB so don't have to worry to delete the ref
            
            int nFieldId = Field.id;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            try
            {
                SqlCommand oCommand;
                SqlDataReader reader;
                {
                    oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", dba.Connection);
                    oCommand.Parameters.AddWithValue("@FieldId", nFieldId);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    int lTableNumber = 0;
                    int lFieldNumber = 0;
                    //string sFieldName = "";
                    while (reader.Read())
                    {
                        lTableNumber = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                        lFieldNumber = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                        //sFieldName = DBAccess.ReadStringValue(reader["FA_NAME"]);
                    }
                    reader.Close();

                    // erase the values for this CF by setting all to NULL or deleting records as necessary
                    string sTable;
                    string sField;
                    if (EPKClass01.GetTableAndField(lTableNumber, lFieldNumber, out sTable, out sField))
                    {
                        if (lTableNumber == 151)
                        {
                            string cmdText = "Delete From EPGC_RESOURCE_MV_VALUES Where MVR_FIELD_ID= @FieldId";                            
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Parameters.AddWithValue("@FieldId", nFieldId);
                            oCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            string cmdText = "Update " + sTable + " Set " + sField + "=NULL";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            //oCommand.Parameters.AddWithValue("FieldId", nFieldId);
                            oCommand.ExecuteNonQuery();
                        }

                        // delete the custom field itself
                        oCommand = new SqlCommand("EPG_SP_DeleteCustomFieldX", dba.Connection);
                        oCommand.Parameters.AddWithValue("@FieldId", nFieldId);
                        oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        oCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        eStatus = StatusEnum.rsRequestCannotBeCompleted;
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCustomField_Main", (StatusEnum)99882, ex.Message.ToString());
            }
            return eStatus;
        }
    }
    internal enum CustomFieldTable
    {
        Unknown = 0,
        ResourceINT = 101,
        ResourceTEXT = 102,
        ResourceDEC = 103,
        ResourceNTEXT = 104,
        ResourceDATE = 105,
        ResourceMV = 151,
        PortfolioINT = 201,
        PortfolioTEXT = 202,
        PortfolioDEC = 203,
        PortfolioNTEXT = 204,
        PortfolioDATE = 205,
        Program = 251,
        ProjectINT = 301,
        ProjectTEXT = 302,
        ProjectDEC = 303,
        ProjectNTEXT = 304,
        ProjectDATE = 305,
        ProgramText = 402, //  ??
        TaskWIINT = 801,
        TaskWITEXT = 802,
        TaskWIDEC = 803
    }

    internal enum FieldType
    {
        TypeCost = 8,
        TypeCode = 4,
        TypeMVCode = 40,
        TypeFlag = 13,
        TypeText = 9,
        TypeNumber = 3,
        TypeDate = 1,
        TypeNText = 19,
    }

    internal enum EntityID
    {
        Resource = 1,
        Portfolio = 2,
        Program = 3,
        Project = 4,
        Task = 5,
        Unknown = 0
    }

    internal class EPKClass01
    {

        public static int GetEntityID(int iTable)
        {
            EntityID nEntity;
            CustomFieldTable nTable = (CustomFieldTable)iTable;
            if (nTable >= CustomFieldTable.ResourceINT && nTable <= CustomFieldTable.ResourceMV)
                nEntity = EntityID.Resource;
            else if (nTable >= CustomFieldTable.PortfolioINT && nTable <= CustomFieldTable.PortfolioDATE)
                nEntity = EntityID.Portfolio;
            else if (nTable == CustomFieldTable.Program)
                nEntity = EntityID.Program;
            else if (nTable >= CustomFieldTable.ProjectINT && nTable <= CustomFieldTable.ProjectDATE)
                nEntity = EntityID.Project;
            else if (nTable >= CustomFieldTable.TaskWIINT && nTable <= CustomFieldTable.TaskWIDEC)
                nEntity = EntityID.Task;
            else
                nEntity = EntityID.Unknown;
            int iEntity = (Int32)nEntity;
            return iEntity;
        }

        public static string GetEntity(int iEntity)
        {
            string sEntity = "";
            EntityID nEntity = (EntityID)iEntity;

            if (nEntity == EntityID.Resource)
                sEntity = "Resource";
            else if (nEntity == EntityID.Portfolio)
                sEntity = "Portfolio";
            else if (nEntity == EntityID.Program)
                sEntity = "Program";
            else if (nEntity == EntityID.Project)
                sEntity = "Project";
            else if (nEntity == EntityID.Task)
                sEntity = "Task";
            else
                sEntity = "Unknown";
            return sEntity;
        }
        public static string GetDataType(int iFieldType)
        {
            string sDataType = "";
            FieldType nFieldType = (FieldType)iFieldType;

            switch (nFieldType)
            {
                case FieldType.TypeCost:
                    sDataType = "Cost";
                    break;
                case FieldType.TypeCode:
                    sDataType = "Code";
                    break;
                case FieldType.TypeDate:
                    sDataType = "Date";
                    break;
                case FieldType.TypeFlag:
                    sDataType = "Flag";
                    break;
                case FieldType.TypeNumber:
                    sDataType = "Number";
                    break;
                case FieldType.TypeText:
                    sDataType = "Text";
                    break;
                case FieldType.TypeNText:
                    sDataType = "RTF";
                    break;
                default:
                    sDataType = "Unknown";
                    break;

            }
            return sDataType;
        }

        public static string GetFieldFormat(int iDataType)
        {
            string sdatatype = "";
            FieldType nDataType = (FieldType)iDataType;
            switch (nDataType)
            {
                case FieldType.TypeCost:
                    sdatatype = "Cost";
                    break;
                case FieldType.TypeCode:
                    sdatatype = "Code";
                    break;
                case FieldType.TypeMVCode:
                    sdatatype = "MV Code";
                    break;
                case FieldType.TypeFlag:
                    sdatatype = "Flag";
                    break;
                case FieldType.TypeText:
                    sdatatype = "Text";
                    break;
                case FieldType.TypeNumber:
                    sdatatype = "Number";
                    break;
                case FieldType.TypeDate:
                    sdatatype = "Date";
                    break;
                case FieldType.TypeNText:
                    sdatatype = "NText";
                    break;
                default:
                    sdatatype = "Unknown Type";
                    break;
            }
            return sdatatype;
        }

        public static bool GetTableAndField(int iTable, int iField, out string sTable, out string sField)
        {
            bool bFound = true;
            string stable = "";
            string sfield = "";
            CustomFieldTable nTable = (CustomFieldTable)iTable;
            switch (nTable)
            {
                case CustomFieldTable.ResourceINT:
                    stable = "EPGC_RESOURCE_INT_VALUES";
                    sfield = "RI_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceTEXT:
                    stable = "EPGC_RESOURCE_TEXT_VALUES";
                    sfield = "RT_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceDEC:
                    stable = "EPGC_RESOURCE_DEC_VALUES";
                    sfield = "RC_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceNTEXT:
                    stable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sfield = "RN_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceDATE:
                    stable = "EPGC_RESOURCE_DATE_VALUES";
                    sfield = "RD_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceMV:
                    stable = "EPGC_RESOURCE_MV_VALUES";
                    sfield = "MVR_UID";
                    break;
                case CustomFieldTable.PortfolioINT:
                    stable = "EPGP_PROJECT_INT_VALUES";
                    sfield = "PI_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioTEXT:
                    stable = "EPGP_PROJECT_TEXT_VALUES";
                    sfield = "PT_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioDEC:
                    stable = "EPGP_PROJECT_DEC_VALUES";
                    sfield = "PC_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioNTEXT:
                    stable = "EPGP_PROJECT_NTEXT_VALUES";
                    sfield = "PN_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioDATE:
                    stable = "EPGP_PROJECT_DATE_VALUES";
                    sfield = "PD_" + String.Format("{0:d3}", iField);
                    break;
                default:
                    stable = "Unknown Table";
                    sfield = "";
                    bFound = false;
                    break;
            }

            sTable = stable;
            sField = sfield;
            return bFound;
        }

        public static int GetTableID(int iEntity, int iDataType)
        {
            CustomFieldTable nTable = 0;
            FieldType nDataType = (FieldType)iDataType;
            EntityID nEntity = (EntityID)iEntity;

            switch (nEntity)
            {
                case EntityID.Resource:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldTable.ResourceDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldTable.ResourceDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.ResourceINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.ResourceTEXT;
                            break;
                        case FieldType.TypeMVCode:
                            nTable = CustomFieldTable.ResourceMV;
                            break;
                    }
                    break;
                case EntityID.Portfolio:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldTable.PortfolioDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldTable.PortfolioDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.PortfolioINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.PortfolioTEXT;
                            break;
                        case FieldType.TypeNText:
                            nTable = CustomFieldTable.PortfolioNTEXT;
                            break;
                    }
                    break;
                case EntityID.Program:
                    nTable = CustomFieldTable.Program;
                    break;
                case EntityID.Project:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldTable.ProjectDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldTable.ProjectDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.ProjectINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.ProjectTEXT;
                            break;
                        case FieldType.TypeNText:
                            nTable = CustomFieldTable.ProjectNTEXT;
                            break;
                    }
                    break;
                case EntityID.Task:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                            nTable = CustomFieldTable.TaskWIDEC;
                            break;
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.TaskWIINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.TaskWITEXT;
                            break;
                    }
                    break;
                default:
                    nTable = CustomFieldTable.Unknown;
                    break;
            }
            return (int)nTable;
        }

    }
}
