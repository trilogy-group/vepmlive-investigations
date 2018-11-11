using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class CustomFieldForm : LayoutsPageBase
    {
        private const string UpdateCustomFieldId = "Update_CustomField";
        private const string ModeAdd = "Add";
        private const string ModeDelete = "Delete";
        private const string ModeModify = "Modify";
        private const string QueryId = "id";
        private const string QueryMode = "mode";
        private const string FaFieldId = "FA_FIELD_ID";
        private const string FaName = "FA_NAME";
        private const string FaTableId = "FA_TABLE_ID";
        private const string FaFormat = "FA_FORMAT";
        private const string FaDesc = "FA_DESC";
        private const string UsedMessage = "UsedMessage";
        private const string UsedData = "UsedData";
        private const int TableNumberMin = 100;
        private const int TableNumberMax = 200;

        private int _dataType;
        private int _entity;
        private int _id;

        protected string DialogTitle = string.Empty;

        public int Id
        {
            get { return _id; }
        }

        public int Entity
        {
            get { return _entity; }
        }

        public string Name { get; private set; } = string.Empty;

        public string Desc { get; private set; } = string.Empty;

        public int DataType
        {
            get { return _dataType; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack || !Request.QueryString.HasKeys())
            {
                return;
            }

            var queryId = Request.QueryString[QueryId];
            var queryMode = Request.QueryString[QueryMode];

            InitControls(queryMode);
            InitEntityDropDown();
            InitFieldTypeDropDown();

            int fieldId;
            if (int.TryParse(queryId, out fieldId))
            {
                var connectionString = GetConnectionString();
                using (var dbAccess = new DBAccess(connectionString))
                {
                    if (dbAccess.Open() != StatusEnum.rsSuccess)
                    {
                        lblGeneralError.Text = dbAccess.FormatErrorText();
                        lblGeneralError.Visible = true;

                        return;
                    }

                    if (queryMode != ModeAdd)
                    {
                        if (fieldId <= 0)
                        {
                            lblGeneralError.Text = "Invalid field selected";
                            lblGeneralError.Visible = true;
                        }
                        else
                        {
                            ReadData(dbAccess, fieldId);
                        }

                        if (queryMode == ModeDelete)
                        {
                            ProcessDelete(dbAccess, fieldId);
                        }
                    }
                    else
                    {
                        txtId.Text = "0";
                        txtName.Text = "New Custom Field";
                    }
                }
            }
            else
            {
                lblGeneralError.Text = "Invalid field selected";
                lblGeneralError.Visible = true;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int.TryParse(txtId.Text, out _id);

            var basePath = hiddenData.Value;
            var connectionString = WebAdmin.GetConnectionString(basePath);
            using (var dbAccess = new DBAccess(connectionString))
            {
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    int rowsAffected;
                    if (DeleteCustomField(dbAccess, this, out rowsAffected) != StatusEnum.rsSuccess)
                    {
                        lblGeneralError.Text = "DELETE FAILED!";
                        lblGeneralError.Visible = true;

                        return;
                    }

                    ClientScript.RegisterStartupScript(GetType(), "CT_Script", "OnCostTypeSavedOK();", true);
                }
                else
                {
                    lblGeneralError.Text = dbAccess.FormatErrorText();
                    lblGeneralError.Visible = true;
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == string.Empty)
            {
                lblGeneralError.Text = "Error Saving Field : Name cannot be blank";
                lblGeneralError.Visible = true;
                return;
            }

            int.TryParse(txtId.Text, out _id);
            Name = txtName.Text;
            Desc = txtDesc.Text;
            int.TryParse(ddlEntity.SelectedValue, out _entity);
            int.TryParse(ddlFieldType.SelectedValue, out _dataType);

            var basePath = hiddenData.Value;
            var sDBConnect = WebAdmin.GetConnectionString(basePath);
            using (var dbAccees = new DBAccess(sDBConnect))
            {
                if (dbAccees.Open() == StatusEnum.rsSuccess)
                {
                    int rowsAffected;
                    if (UpdateCustomField(dbAccees, this, out rowsAffected) != StatusEnum.rsSuccess)
                    {
                        lblGeneralError.Text = dbAccees.FormatErrorText();
                        lblGeneralError.Visible = true;
                        return;
                    }

                    ClientScript.RegisterStartupScript(GetType(), "CT_Script", "OnCostTypeSavedOK();", true);
                }
                else
                {
                    lblGeneralError.Text = dbAccees.FormatErrorText();
                    lblGeneralError.Visible = true;
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            // nothing here
        }

        private string GetConnectionString()
        {
            var basePath = WebAdmin.GetBasePath();
            hiddenData.Value = basePath;
            var connectionString = WebAdmin.GetConnectionString(basePath);
            return connectionString;
        }

        private void InitControls(string queryMode)
        {
            switch (queryMode)
            {
                case ModeAdd:
                    DialogTitle = "Add a new Custom Field";
                    btnOK.Visible = true;
                    btnDelete.Visible = false;
                    break;
                case ModeModify:
                    InitControls("Modify Custom Field", true, false);
                    break;
                case ModeDelete:
                    InitControls("Delete Custom Field", false, true);
                    break;
                default:
                    // nothing here
                    break;
            }
        }

        private void ReadData(DBAccess dbAccess, int fieldId)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            DataTable dataTable;
            var cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1";
            if (dbAccess.SelectDataById(cmdText, fieldId, (StatusEnum)99917, out dataTable) == StatusEnum.rsSuccess)
            {
                using (dataTable)
                {
                    if (dataTable?.Rows?.Count == 1)
                    {
                        bool bIsNull;
                        var row = dataTable.Rows[0];
                        txtId.Text = row[FaFieldId].ToString();
                        txtName.Text = row[FaName].ToString();
                        txtDesc.Text = row[FaDesc].ToString();
                        var tableId = SqlDb.ReadIntValue(row[FaTableId], out bIsNull);
                        var iEntity = EPKClass01.GetEntityID(tableId);
                        ddlEntity.SelectedValue = iEntity.ToString();
                        var dataType = SqlDb.ReadIntValue(row[FaFormat], out bIsNull);
                        ddlFieldType.SelectedValue = dataType.ToString();
                    }
                }
            }
        }

        private void ProcessDelete(DBAccess dbAccess, int fieldId)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var deletemessage = string.Empty;
            if (CanDeleteCustomField(dbAccess, fieldId, out deletemessage) == false)
            {
                lblGeneralError.Text = deletemessage;
                lblGeneralError.Visible = true;

                btnDelete.Visible = false;
            }
            else
            {
                CheckDeleteCustomField(dbAccess, fieldId, out deletemessage);
                lblGeneralError.Text = deletemessage;
                lblGeneralError.Visible = true;
            }
        }

        private void InitFieldTypeDropDown()
        {
            ddlFieldType.Items.Clear();
            AddItem(ddlFieldType.Items, FieldType.TypeText);
            AddItem(ddlFieldType.Items, FieldType.TypeNumber);
            AddItem(ddlFieldType.Items, FieldType.TypeCost);
            AddItem(ddlFieldType.Items, FieldType.TypeFlag);
            AddItem(ddlFieldType.Items, FieldType.TypeDate);
            AddItem(ddlFieldType.Items, FieldType.TypeMVCode);
        }

        private void AddItem(ListItemCollection items, FieldType fieldType)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            var id = (int)fieldType;
            items.Add(new ListItem(EPKClass01.GetDataType(id), id.ToString()));
        }

        private void InitEntityDropDown()
        {
            ddlEntity.Items.Clear();
            AddItem(ddlEntity.Items, EntityID.Portfolio);
            AddItem(ddlEntity.Items, EntityID.Resource);
        }

        private void AddItem(ListItemCollection items, EntityID entityId)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            var id = (int)entityId;
            items.Add(new ListItem(EPKClass01.GetEntity(id), id.ToString()));
        }

        private void InitControls(string title, bool isOkVisible, bool isDeleteVisible)
        {
            DialogTitle = title;
            btnOK.Visible = isOkVisible;
            btnDelete.Visible = isDeleteVisible;

            txtName.Enabled = false;
            ddlEntity.Enabled = false;
            ddlFieldType.Enabled = false;
        }

        private static StatusEnum UpdateCustomField(DBAccess dbAccess, CustomFieldForm customField, out int rowsAffected)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            StatusEnum status;
            rowsAffected = 0;

            try
            {
                // make sure there isn't already another field with this name
                if (!CheckExistingId(dbAccess, customField, out status))
                {
                    return status;
                }

                if (customField.Id > 0)
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
                        var maxField = GetMaxField(dbAccess, out status, tableName, fieldNam);

                        var useField = GetUseField(dbAccess, tableId, maxField);

                        if (useField > maxField)
                        {
                            status = dbAccess.HandleStatusError(
                                SeverityEnum.Error,
                                UpdateCustomFieldId,
                                (StatusEnum)99884,
                                "Can't save Field, all Fields of this type are already used");
                            return status;
                        }

                        rowsAffected += AddField(dbAccess, customField, tableId, useField);
                    }
                }
            }
            catch (Exception ex)
            {
                status = dbAccess.HandleStatusError(SeverityEnum.Exception, "UpdateCustomField_Main", (StatusEnum)99883, ex.Message);
                Debug.WriteLine(ex.ToString());
            }

            return status;
        }

        private static bool CheckExistingId(DBAccess dbAccess, CustomFieldForm customField, out StatusEnum status)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (customField == null)
            {
                throw new ArgumentNullException(nameof(customField));
            }

            status = StatusEnum.rsSuccess;

            const string cmdText = "SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME";
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                command.Parameters.Add("@FIELD_NAME", SqlDbType.VarChar, 255).Value = customField.Name;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var existingId = SqlDb.ReadIntValue(reader[FaFieldId]);
                        if (existingId != customField.Id)
                        {
                            status = dbAccess.HandleStatusError(
                                SeverityEnum.Error,
                                UpdateCustomFieldId,
                                (StatusEnum)99886,
                                "Can't save Field, a Field with this name already exists");
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
                .AppendFormat(" WHERE FA_FIELD_ID = {0}", customField.Id);

            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                command.Parameters.AddWithValue("@pNAME", customField.Name);
                command.Parameters.AddWithValue("@pDESC", customField.Desc);
                return command.ExecuteNonQuery();
            }
        }

        private static int GetMaxField(DBAccess dbAccess, out StatusEnum status, string tableName, string fieldName)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText = $"SELECT TOP 1 * FROM {tableName}";
            DataTable dataTable;
            status = dbAccess.SelectData(cmdText, (StatusEnum)99885, out dataTable);

            // find the field with the highest number suffix - eg PC_050 - user can add to these tables
            var maxField = 0;
            var prefix = fieldName.Substring(0, 3);
            var columns = dataTable.Columns;
            foreach (DataColumn column in columns)
            {
                var columnName = column.ColumnName;
                var thisPrefix = columnName.Substring(0, 3);
                if (thisPrefix == prefix)
                {
                    var fieldNumber = int.Parse(columnName.Substring(3));
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
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var useField = 1;
            var listUsedFields = new List<int>();
            var cmdText = $"SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID={tableId}";
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fieldNumber = SqlDb.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
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

        private static bool CanDeleteCustomField(DBAccess dbAccess, int fieldId, out string message)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var stringBuilder = new StringBuilder();
            try
            {
                using (var command = new SqlCommand("EPG_SP_ReadUsedCF", dbAccess.Connection))
                {
                    command.Parameters.AddWithValue("@FieldId", fieldId);
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stringBuilder.AppendFormat("<br>{0}: ", reader[UsedMessage])
                                .Append(reader[UsedData]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                stringBuilder.Append("<br>")
                    .Append("Check for field used FAILED!");
                Debug.WriteLine(ex.ToString());
            }

            message = stringBuilder.ToString();
            if (message.Length > 0)
            {
                message = "This custom field cannot be deleted until you remove it from these areas:" + message;
                return false;
            }
            return true;
        }

        private static bool CheckDeleteCustomField(DBAccess dbAccess, int fieldId, out string message)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var stringBuilder = new StringBuilder();
            try
            {
                using (var command = new SqlCommand("EPG_SP_ReadFieldInfo", dbAccess.Connection))
                {
                    command.Parameters.AddWithValue("@FieldId", fieldId);
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        var tableNumber = 0;
                        var fieldName = string.Empty;
                        while (reader.Read())
                        {
                            tableNumber = SqlDb.ReadIntValue(reader[FaTableId]);
                            fieldName = SqlDb.ReadStringValue(reader[FaName]);
                        }

                        if (tableNumber > TableNumberMin && tableNumber < TableNumberMax)
                        {
                            stringBuilder.AppendFormat("Values for {0} will be cleared from all Resources", fieldName);
                        }
                        else
                        {
                            stringBuilder.AppendFormat("Values for {0} will be cleared from all PIs", fieldName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                stringBuilder.Append("<br>")
                    .Append("Check for field FAILED!");
                Debug.WriteLine(ex.ToString());
            }

            stringBuilder.Append("<br><br>Are you sure you want to delete this custom field?");
            message = stringBuilder.ToString();

            return true;
        }

        private static StatusEnum DeleteCustomField(DBAccess dbAccess, CustomFieldForm field, out int rowsAffected)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            // NOTE - CF cannot be deleted right now (Sep06) when used in a view or on a TAB so don't have to worry to delete the ref

            var fieldId = field.Id;
            var status = StatusEnum.rsSuccess;
            rowsAffected = 0;

            try
            {
                var tableNumber = 0;
                var fieldNumber = 0;

                using (var command = new SqlCommand("EPG_SP_ReadFieldInfo", dbAccess.Connection))
                {
                    command.Parameters.AddWithValue("@FieldId", fieldId);
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNumber = SqlDb.ReadIntValue(reader[FaTableId]);
                            fieldNumber = SqlDb.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                        }
                    }
                }

                // erase the values for this CF by setting all to NULL or deleting records as necessary
                string tableName;
                string fieldName;
                if (EPKClass01.GetTableAndField(tableNumber, fieldNumber, out tableName, out fieldName))
                {
                    if (tableNumber == (int)CustomFieldTable.ResourceMV)
                    {
                        var cmdText = "Delete From EPGC_RESOURCE_MV_VALUES Where MVR_FIELD_ID= @FieldId";
                        using (var command = new SqlCommand(cmdText, dbAccess.Connection))
                        {
                            command.Parameters.AddWithValue("@FieldId", fieldId);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        var cmdText = $"Update {tableName} Set {fieldName}=NULL";
                        using (var command = new SqlCommand(cmdText, dbAccess.Connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    // delete the custom field itself
                    using (var command = new SqlCommand("EPG_SP_DeleteCustomFieldX", dbAccess.Connection))
                    {
                        command.Parameters.AddWithValue("@FieldId", fieldId);
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    status = StatusEnum.rsRequestCannotBeCompleted;
                }
            }
            catch (Exception ex)
            {
                status = dbAccess.HandleStatusError(SeverityEnum.Exception, "DeleteCustomField_Main", (StatusEnum)99882, ex.Message);
                Debug.WriteLine((ex.ToString()));
            }
            return status;
        }
    }
}