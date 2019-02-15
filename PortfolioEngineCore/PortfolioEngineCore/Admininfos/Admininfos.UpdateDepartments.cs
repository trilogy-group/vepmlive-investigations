using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace PortfolioEngineCore
{
    public partial class Admininfos
    {
        /// <summary>
        /// Updates the department lookup and infos.   
        /// </summary>
        /// <param name="data">xmll defn of dept structure.</param>
        /// <returns></returns>
        public bool UpdateDepartments(string data, out string result)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateDepartments", "Input", data);

                var cStruct = new CStruct();
                cStruct.LoadXML(data);
                var id = 0;
                var fullName = string.Empty;
                var dicDepts = new Dictionary<int, PFELookup>();

                GetLookup(cStruct, "Department", dicDepts, 0, ref id, fullName);
                var errorMessage = string.Empty;
                var errorDepts = new List<PFELookup>();

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                var transaction = _sqlConnection.BeginTransaction();
                var deptLookupId = 0;

                UpdateDeptCode(transaction, ref deptLookupId);

                if (deptLookupId <= 0)
                {
                    throw new PFEException((int)PFEError.UD_NoLookupTable, "Can't Find/Create Lookup Table");
                }

                var canUpdate = UpdateLookupValues(transaction, deptLookupId, dicDepts, errorDepts, ref errorMessage);

                if (canUpdate)
                {
                    InsertOnEpgLookupValue(dicDepts, transaction, deptLookupId);
                }

                UpdateDeptManagers(canUpdate, transaction, dicDepts);

                if (canUpdate)
                {
                    transaction.Commit();
                }

                var tempResult = new CStruct();

                if (!canUpdate)
                {
                    var errorMessageBuilder = new StringBuilder(errorMessage);

                    foreach (var deptItem in errorDepts)
                    {
                        errorMessageBuilder.Append($": {deptItem.name}");
                    }

                    throw new PFEException((int)PFEError.UpdateDepartments, errorMessageBuilder.ToString());
                }

                tempResult.Initialize("Data");

                foreach (var deptItem in dicDepts)
                {
                    var xDept = tempResult.CreateSubStruct("Department");
                    xDept.CreateIntAttr("Id", deptItem.Value.UID);
                    xDept.CreateStringAttr("DataId", deptItem.Value.DataId);
                }

                result = tempResult.XML();
                return canUpdate;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new PFEException((int)PFEError.UpdateDepartments, exception.GetBaseMessage());
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        private void UpdateDeptManagers(bool canUpdate, SqlTransaction transaction, Dictionary<int, PFELookup> dicDepts)
        {
            Utilities.ArgumentIsNotNull(dicDepts, nameof(dicDepts));
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));

            if (canUpdate)
            {
                var commandText = @"Delete From EPG_RES_MANAGERS";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction)
                {
                    CommandType = CommandType.Text
                })
                {
                    sqlCommand.ExecuteNonQuery();
                }

                commandText = @"Insert Into EPG_RES_MANAGERS (CODE_UID,WRES_ID) Values (@LV_uid,@wres_id)";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction)
                {
                    CommandType = CommandType.Text
                })
                {
                    var paramUid = sqlCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                    var resourceId = sqlCommand.Parameters.Add("@wres_id", SqlDbType.Int);

                    foreach (var deptItem in dicDepts)
                    {
                        if (deptItem.Value.Managers != null && deptItem.Value.Managers.Count > 0)
                        {
                            paramUid.Value = deptItem.Value.UID;
                            resourceId.Value = deptItem.Value.Managers[0];
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            if (canUpdate)
            {
                var commandText = @"Delete From EPG_DEPT_MANAGERS";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction)
                {
                    CommandType = CommandType.Text
                })
                {
                    sqlCommand.ExecuteNonQuery();
                }

                AddToDeptManagers(transaction, dicDepts);
            }
        }

        private void UpdateDeptCode(SqlTransaction transaction, ref int deptLookupId)
        {
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));

            var commandText = "SELECT ADM_RPE_DEPT_CODE FROM EPG_ADMIN";

            using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
            {
                using (var sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        deptLookupId = (int)sqlDataReader.GetInt32Safely("ADM_RPE_DEPT_CODE");
                    }
                }
            }

            if (deptLookupId <= 0)
            {
                var lookupName = "Department Lookup";
                commandText = "SET NOCOUNT ON;INSERT Into EPGP_LOOKUP_TABLES  (LOOKUP_NAME) Values(@Name);Select @@IDENTITY as NewID";
                var newId = 0;

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", lookupName);

                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            newId = Convert.ToInt32(sqlDataReader["NewID"]);
                        }
                    }
                }

                deptLookupId = newId;

                commandText = @"Update EPG_ADMIN SET ADM_RPE_DEPT_CODE = @LookupUID";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                {
                    sqlCommand.Parameters.AddWithValue("@LookupUID", deptLookupId);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private void AddToDeptManagers(SqlTransaction transaction, Dictionary<int, PFELookup> dicDepts)
        {
            Utilities.ArgumentIsNotNull(dicDepts, nameof(dicDepts));
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));

            var commandText = @"Insert Into EPG_DEPT_MANAGERS (CODE_UID,WRES_ID,CANREAD,CANWRITE) Values (@LV_uid,@wres_id,@canread,@canwrite)";

            using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction)
            {
                CommandType = CommandType.Text
            })
            {
                var pUid = sqlCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                var paramResId = sqlCommand.Parameters.Add("@wres_id", SqlDbType.Int);
                var canRead = sqlCommand.Parameters.Add("@canread", SqlDbType.TinyInt);
                var canWrite = sqlCommand.Parameters.Add("@canwrite", SqlDbType.TinyInt);

                foreach (var deptItem in dicDepts)
                {
                    if (deptItem.Value.Managers != null && deptItem.Value.Managers.Count > 0)
                    {
                        pUid.Value = deptItem.Value.UID;

                        foreach (var manager in deptItem.Value.Managers)
                        {
                            paramResId.Value = manager;
                            canRead.Value = 1;
                            canWrite.Value = 1;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    if (deptItem.Value.Executives != null && deptItem.Value.Executives.Count > 0)
                    {
                        pUid.Value = deptItem.Value.UID;

                        foreach (var executive in deptItem.Value.Executives)
                        {
                            paramResId.Value = executive;
                            canRead.Value = 1;
                            canWrite.Value = 0;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private bool UpdateLookupValues(
            SqlTransaction transaction,
            int deptLookupId,
            Dictionary<int, PFELookup> dicDepts,
            IList<PFELookup> errorDepts,
            ref string errorMessage)
        {
            Utilities.ArgumentIsNotNull(errorMessage, nameof(errorMessage));
            Utilities.ArgumentIsNotNull(errorDepts, nameof(errorDepts));
            Utilities.ArgumentIsNotNull(dicDepts, nameof(dicDepts));
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));

            var canUpdate = true;
            var commandText = "SELECT LOOKUP_UID,LV_UID,LV_EXT_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @LookupUID";

            using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@LookupUID", deptLookupId);

                using (var dataTable = new DataTable())
                {
                    dataTable.Load(sqlCommand.ExecuteReader());

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var lvValue = SqlDb.ReadStringValue(row["LV_VALUE"]);
                            var lvLevel = SqlDb.ReadIntValue(row["LV_LEVEL"]);
                            var lvUid = SqlDb.ReadIntValue(row["LV_UID"]);
                            var lvId = SqlDb.ReadIntValue(row["LV_ID"]);
                            var lvExtId = SqlDb.ReadStringValue(row["LV_EXT_UID"]);
                            var lvFullValue = SqlDb.ReadStringValue(row["LV_FULLVALUE"]);
                            var itemKey = GetItemKey(dicDepts, lvUid, lvValue);

                            if (itemKey > 0)
                            {
                                var value = dicDepts[itemKey];
                                value.bflag = true;
                                value.UID = lvUid;

                                if (lvId != value.ID ||
                                    lvLevel != value.level ||
                                    lvValue != value.name ||
                                    lvFullValue != value.fullname ||
                                    lvExtId != value.ExtId)
                                {
                                    row["LV_VALUE"] = value.name;
                                    row["LV_LEVEL"] = value.level;
                                    row["LV_EXT_UID"] = value.ExtId;
                                    row["LV_ID"] = value.ID;
                                    row["LV_FULLVALUE"] = value.fullname;
                                }
                            }
                            else
                            {
                                canUpdate = false;
                                errorMessage = "Incomplete Lookup List, value missing";
                                var oItemLookup = new PFELookup
                                {
                                    name = lvValue,
                                    UID = lvUid,
                                    ExtId = lvExtId
                                };
                                errorDepts.Add(oItemLookup);
                            }
                        }

                        if (canUpdate)
                        {
                            ApplyUpdateOnEpgpLookupValues(transaction, dataTable);
                        }
                    }
                }
            }

            return canUpdate;
        }
    }
}