using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AdminSite
{
    public partial class changeowner : System.Web.UI.Page
    {
        private const string EpmLiveConnectionName = "epmlive";
        private const string AccountIdRequestArgument = "account_Id";

        private const string MoveAccountStoredProcedure = "spMoveAccount";
        private const string AccountIdParameter = "@account_uid";
        private const string NewOwnerParameter = "@newowner";
        private const string OldOwnerParameter = "@oldowner";

        private const string GetAccountUsersQuery = "SELECT name + '(' + email + ')' as fullname, uid  FROM vwAccountUsers WHERE account_id=" + AccountIdParameter + " AND deleted is null ORDER BY name";
        private const string GetOwnerIdQuery = "SELECT owner_id, secondary_owner_id FROM account WHERE account_id=" + AccountIdParameter;
        private const string UpdateSecondaryAccountQuery = "UPDATE account set secondary_owner_id = " + NewOwnerParameter + " WHERE account_id = " + AccountIdParameter;

        private const string UserIdField = "uid";
        private const string UserFullNameField = "fullname";

        protected string strLic;

        protected void btnReset_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlMessage.Visible = true;

            var status = ChangeOwnerStatus.NotExecuted;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                // get selected values
                var primaryOwnerId = !string.IsNullOrWhiteSpace(ddlOwner.SelectedValue)
                    ? new Guid(ddlOwner.SelectedValue)
                    : Guid.Empty;
                var secondaryOwnerId = !string.IsNullOrWhiteSpace(secondaryOwner.SelectedValue)
                    ? new Guid(secondaryOwner.SelectedValue)
                    : Guid.Empty;

                // get actual owners
                var owners = GetOwners(connection);

                if (owners.Length < 2)
                {
                    // if no owner data received mark as error
                    status = ChangeOwnerStatus.PrimaryOwnerCurrentOwnerNotFound;
                }
                else if (owners[0] != primaryOwnerId)
                {
                    // if primary owner changed - update the primary account owner
                    status = UpdatePrimaryOwner(connection, owners[0], primaryOwnerId);
                }

                // if primary owner updated and secondary owner is changed, call update for the secondary owner
                if ((status == ChangeOwnerStatus.Success
                     || status == ChangeOwnerStatus.NotExecuted
                     || status == ChangeOwnerStatus.PrimaryOwnerNoChange) && owners[1] != secondaryOwnerId)
                {
                    status = UpdateSecondaryOwner(connection, secondaryOwnerId);
                }
            }

            DisplayStatus(status);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                var primaryOwnerData = GetAccountUsers(connection);
                var secondaryOwnerData = primaryOwnerData.Copy();

                var emptyRow = secondaryOwnerData.Tables[0].NewRow();
                emptyRow[UserIdField] = Guid.Empty;
                emptyRow[UserFullNameField] = string.Empty;
                secondaryOwnerData.Tables[0].Rows.InsertAt(emptyRow, 0);
                secondaryOwnerData.Tables[0].AcceptChanges();

                SetDataSource(ddlOwner, primaryOwnerData, UserIdField, UserFullNameField);
                SetDataSource(secondaryOwner, secondaryOwnerData, UserIdField, UserFullNameField);

                var owners = GetOwners(connection);
                if (owners.Length == 2)
                {
                    ddlOwner.SelectedValue = owners[0].ToString();
                    secondaryOwner.SelectedValue = owners[1].ToString();
                }
            }
        }

        protected virtual string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[EpmLiveConnectionName].ToString();
        }

        private void DisplayStatus(ChangeOwnerStatus result)
        {
            switch (result)
            {
                case ChangeOwnerStatus.Success:
                    lblMessage.Text = "Successfully changed owners";
                    break;
                case ChangeOwnerStatus.PrimaryOwnerDataMismatch:
                    lblMessage.Text = "Primary owner: mismatched account id and older owner id";
                    break;
                case ChangeOwnerStatus.PrimaryOwnerNoChange:
                    lblMessage.Text = "Primary owner: new owner already has an account";
                    break;
                case ChangeOwnerStatus.PrimaryOwnerNewOwnerDoesNotExist:
                    lblMessage.Text = "Primary owner: new owner doesn't exist";
                    break;
                case ChangeOwnerStatus.PrimaryOwnerFailedToExecute:
                    lblMessage.Text = "Primary owner: failed to execute move";
                    break;
                case ChangeOwnerStatus.PrimaryOwnerCurrentOwnerNotFound:
                    lblMessage.Text = "Primary owner: current user not found";
                    break;
                case ChangeOwnerStatus.SecondaryOwnerFailedToExecute:
                    lblMessage.Text = "Secondary owner: failed to update";
                    break;
                case ChangeOwnerStatus.NotExecuted:
                    lblMessage.Text = "Nothing to update";
                    break;
                default:
                    lblMessage.Text = string.Format("Unspecified error occurred: {0}", (int)result);
                    break;
            }
        }

        private DataSet GetAccountUsers(SqlConnection connection)
        {
            var result = new DataSet();
            using (var sqlCommand = new SqlCommand(GetAccountUsersQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue(AccountIdParameter, Request[AccountIdRequestArgument]);
                var adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(result);
            }

            return result;
        }

        private Guid[] GetOwners(SqlConnection connection)
        {
            var result = new List<Guid>();
            using (var sqlCommand = new SqlCommand(GetOwnerIdQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue(AccountIdParameter, Request[AccountIdRequestArgument]);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Add(reader.GetGuid(0));
                        result.Add(reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1));
                    }
                }
            }

            return result.ToArray();
        }

        private void SetDataSource(DropDownList control, DataSet data, string valueColumn, string textColumn)
        {
            control.DataValueField = valueColumn;
            control.DataTextField = textColumn;
            control.DataSource = data;
            control.DataBind();
        }

        private ChangeOwnerStatus UpdatePrimaryOwner(SqlConnection connection, Guid originalValue, Guid selectedValue)
        {
            using (var sqlCommand = new SqlCommand(MoveAccountStoredProcedure, connection) {CommandType = CommandType.StoredProcedure})
            {
                sqlCommand.Parameters.AddWithValue(AccountIdParameter, Request[AccountIdRequestArgument]);
                sqlCommand.Parameters.AddWithValue(OldOwnerParameter, originalValue);
                sqlCommand.Parameters.AddWithValue(NewOwnerParameter, selectedValue);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (ChangeOwnerStatus) reader.GetInt32(0);
                    }

                    return ChangeOwnerStatus.PrimaryOwnerFailedToExecute;
                }
            }
        }

        private ChangeOwnerStatus UpdateSecondaryOwner(SqlConnection connection, Guid selectedValue)
        {
            var sqlCommand = new SqlCommand(UpdateSecondaryAccountQuery, connection);
            sqlCommand.Parameters.AddWithValue(AccountIdParameter, Request[AccountIdRequestArgument]);
            sqlCommand.Parameters.AddWithValue(NewOwnerParameter, selectedValue);

            var result = sqlCommand.ExecuteNonQuery();
            return result > 0 ? ChangeOwnerStatus.Success : ChangeOwnerStatus.SecondaryOwnerFailedToExecute;
        }
    }
}