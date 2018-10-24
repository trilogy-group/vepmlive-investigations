using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using EPMLiveCore.Helpers;

namespace PortfolioEngineCore
{
    public partial class Admininfos
    {
        public bool UpdateCategoriesFromRoles()
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                var majorCategoryLookup = 0;
                var commandText = "Select ADM_MC_LOOKUP From EPG_ADMIN";
                var sqlCommand = new SqlCommand(commandText, _sqlConnection);

                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    if (sqlReader.Read())
                    {
                        majorCategoryLookup = SqlDb.ReadIntValue(sqlReader["ADM_MC_LOOKUP"]);
                    }
                }

                var numberCategoriesWithUom = CountCategories();
                var roles = EpGpLookupValues();

                if (roles.Count == 0)
                {
                    return true;
                }

                string sUom;
                int lNextUid;
                var lCaUid = 0;
                MaxUidFromEdGpCostCategories(out sUom, out lNextUid);
                var lInsertAfter = 1;
                var foundLevel = 0;

                if (numberCategoriesWithUom == 0)
                {
                    lCaUid = lNextUid;
                    lNextUid++;
                    var lCaId = 1;
                    sUom = "hrs";
                    commandText = "INSERT Into EPGP_CATEGORIES (CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM) Values (@UId,@Name,@ID,1,0,@UOM)";
                    sqlCommand = new SqlCommand(commandText, _sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@UId", lCaUid);
                    sqlCommand.Parameters.AddWithValue("@Name", "Labor");
                    sqlCommand.Parameters.AddWithValue("@ID", lCaId);
                    sqlCommand.Parameters.AddWithValue("@UOM", sUom);
                    sqlCommand.ExecuteNonQuery();
                    lInsertAfter = 1;
                }
                else
                {
                    AddNewCcs(ref lCaUid, ref sUom);

                    if (lCaUid <= 0)
                    {
                        return false;
                    }

                    InsertIdSequence(lCaUid, ref foundLevel, ref lInsertAfter);
                }

                ProcessEpGpCategories(lInsertAfter, roles, lNextUid, foundLevel, sUom, majorCategoryLookup);

                AdminFunctions.CalcAllDefaultFTEs(_dba);
                string temp;
                AdminFunctions.CalcCategoryRates(_dba, out temp);

                return true;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new PFEException((int)PFEError.UpdateCategoriesFromRoles, exception.GetBaseMessage());
            }
            finally
            {
                _sqlConnection?.Close();
            }
        }

        private void AddNewCcs(ref int lCaUid, ref string sUom)
        {
            var nLevel = 0;
            var commandText = "Select CA_UID,CA_ID,CA_UOM,CA_LEVEL From EPGP_CATEGORIES Where (CA_ROLE=0 Or CA_ROLE=NULL) And LEN(CA_UOM)>0";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    var ltCaUid = SqlDb.ReadIntValue(sqlReader["CA_UID"]);
                    SqlDb.ReadIntValue(sqlReader["CA_ID"]);
                    var stUom = SqlDb.ReadStringValue(sqlReader["CA_UOM"]);
                    var ltLevel = SqlDb.ReadIntValue(sqlReader["CA_LEVEL"]);

                    if (ltLevel > nLevel)
                    {
                        nLevel = ltLevel;
                        lCaUid = ltCaUid;
                        sUom = stUom;
                    }
                }
            }
        }

        private void InsertIdSequence(int lCaUid, ref int foundLevel, ref int lInsertAfter)
        {
            var commandText = "SELECT CA_UID,CA_ID,CA_LEVEL From EPGP_CATEGORIES Order By CA_ID";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                var found = false;

                while (sqlReader.Read())
                {
                    var readIntValue = SqlDb.ReadIntValue(sqlReader["CA_UID"]);
                    var intValue = SqlDb.ReadIntValue(sqlReader["CA_ID"]);
                    var value = SqlDb.ReadIntValue(sqlReader["CA_LEVEL"]);

                    if (found && value <= foundLevel)
                    {
                        break;
                    }

                    if (readIntValue == lCaUid)
                    {
                        found = true;
                        foundLevel = value;
                    }

                    lInsertAfter = intValue;
                }
            }
        }

        private int CountCategories()
        {
            var commandText = "Select COUNT(*) as CountCategories From EPGP_CATEGORIES Where (CA_ROLE=0 Or CA_ROLE=NULL) And LEN(CA_UOM)>0";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                var numberCategoriesWithUom = sqlReader.Read()
                    ? SqlDb.ReadIntValue(sqlReader["CountCategories"])
                    : 0;
                return numberCategoriesWithUom;
            }
        }

        private void MaxUidFromEdGpCostCategories(out string sUom, out int lNextUid)
        {
            sUom = string.Empty;

            var commandText = "Select MAX(BC_UID) as Max_UID From EPGP_COST_CATEGORIES";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                lNextUid = sqlReader.Read()
                    ? SqlDb.ReadIntValue(sqlReader["Max_UID"]) + 1
                    : 1;
            }
        }

        private IList<PfECategory> EpGpLookupValues()
        {
            var commandText = "Select LV_UID,LV_VALUE From EPGP_LOOKUP_VALUES Where LOOKUP_UID=(Select ADM_ROLE_CODE From EPG_ADMIN) And LV_UID Not In (Select DISTINCT CA_ROLE From EPGP_CATEGORIES) ORDER BY LV_ID";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                var roles = new List<PfECategory>();

                while (sqlReader.Read())
                {
                    var role = new PfECategory
                    {
                        Uid = SqlDb.ReadIntValue(sqlReader["LV_UID"]),
                        Name = SqlDb.ReadStringValue(sqlReader["LV_VALUE"])
                    };
                    roles.Add(role);
                }

                return roles;
            }
        }

        private void ProcessEpGpCategories(
            int lInsertAfter,
            IList<PfECategory> roles,
            int lNextUid,
            int foundLevel,
            string sUom,
            int majorCategoryLookup)
        {
            Guard.ArgumentIsNotNull(roles, nameof(roles));

            var transaction = _sqlConnection.BeginTransaction();
            var commandText = "Update EPGP_CATEGORIES Set CA_ID = CA_ID + @Incr Where CA_ID > @Insertafter";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
            sqlCommand.Parameters.AddWithValue("@Insertafter", lInsertAfter);
            sqlCommand.Parameters.AddWithValue("@Incr", roles.Count);
            sqlCommand.ExecuteNonQuery();

            var lNewId = lInsertAfter + 1;
            commandText = "INSERT Into EPGP_CATEGORIES (CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM) Values (@UId,@Name,@ID,@Level,@Role,@UOM)";
            sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
            var paraUid = sqlCommand.Parameters.Add("@UId", SqlDbType.Int);
            var paraName = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar);
            var paraId = sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
            var paraLevel = sqlCommand.Parameters.Add("@Level", SqlDbType.Int);
            var paraRole = sqlCommand.Parameters.Add("@Role", SqlDbType.Int);
            var paraUom = sqlCommand.Parameters.Add("@UOM", SqlDbType.VarChar);

            foreach (var role in roles)
            {
                paraUid.Value = lNextUid;
                lNextUid++;
                paraName.Value = role.Name;
                paraLevel.Value = foundLevel + 1;
                paraId.Value = lNewId;
                lNewId++;
                paraRole.Value = role.Uid;
                paraUom.Value = sUom;
                sqlCommand.ExecuteNonQuery();
            }

            if (majorCategoryLookup <= 0)
            {
                commandText = "Delete From EPGP_COST_CATEGORIES";
                sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
                sqlCommand.ExecuteNonQuery();

                commandText =
                    "Insert Into EPGP_COST_CATEGORIES (BC_UID,BC_NAME,BC_ID,BC_LEVEL,BC_ROLE,BC_UOM,MC_UID,CA_UID) Select CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM,0,CA_UID as CC From EPGP_CATEGORIES";
                sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                var lMaxUid = 0;
                var pfECategories = DeleteEpGpCostCategories(transaction, ref lMaxUid);

                commandText = "Select LV_UID,LV_VALUE From EPGP_LOOKUP_VALUES Where LOOKUP_UID=@MCUID ORDER BY LV_ID";
                sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
                sqlCommand.Parameters.AddWithValue("@MCUID", majorCategoryLookup);
                var eCategories = new List<PfECategory>();

                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        var category = new PfECategory
                        {
                            Uid = SqlDb.ReadIntValue(sqlReader["LV_UID"]),
                            Name = SqlDb.ReadStringValue(sqlReader["LV_VALUE"])
                        };
                        eCategories.Add(category);
                    }
                }

                IList<PfECategory> categories;
                AddPfECategoriesList(transaction, out categories, ref lMaxUid);
                InsertEpGpCostCategories(categories, transaction, eCategories, pfECategories, lMaxUid);
            }

            transaction.Commit();
        }

        private void AddPfECategoriesList(
            SqlTransaction transaction,
            out IList<PfECategory> categories,
            ref int lMaxUid)
        {
            var commandText = "Select CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM From EPGP_CATEGORIES ORDER BY CA_ID";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                categories = new List<PfECategory>();

                while (sqlReader.Read())
                {
                    var category = new PfECategory
                    {
                        Uid = SqlDb.ReadIntValue(sqlReader["CA_UID"]),
                        ID = SqlDb.ReadIntValue(sqlReader["CA_ID"]),
                        Level = SqlDb.ReadIntValue(sqlReader["CA_LEVEL"]),
                        Role = SqlDb.ReadIntValue(sqlReader["CA_ROLE"]),
                        Name = SqlDb.ReadStringValue(sqlReader["CA_NAME"]),
                        UOM = SqlDb.ReadStringValue(sqlReader["CA_UOM"])
                    };
                    categories.Add(category);

                    if (category.Uid > lMaxUid)
                    {
                        lMaxUid = category.Uid;
                    }
                }
            }
        }

        private IList<PfECategory> DeleteEpGpCostCategories(
            SqlTransaction transaction,
            ref int lMaxUid)
        {
            var commandText = "Select BC_UID,BC_NAME,MC_UID,CA_UID From EPGP_COST_CATEGORIES ORDER BY BC_ID";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
            var pfECategories = new List<PfECategory>();

            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    var category = new PfECategory
                    {
                        Uid = SqlDb.ReadIntValue(sqlReader["BC_UID"]),
                        mc_Uid = SqlDb.ReadIntValue(sqlReader["MC_UID"]),
                        ID = SqlDb.ReadIntValue(sqlReader["CA_UID"]),
                        Name = SqlDb.ReadStringValue(sqlReader["BC_NAME"])
                    };

                    pfECategories.Add(category);

                    if (category.Uid > lMaxUid)
                    {
                        lMaxUid = category.Uid;
                    }
                }
            }

            commandText = "Delete From EPGP_COST_CATEGORIES";
            sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction)
            {
                CommandType = CommandType.Text
            };
            sqlCommand.ExecuteNonQuery();

            return pfECategories;
        }

        private void InsertEpGpCostCategories(
            IList<PfECategory> categories,
            SqlTransaction transaction,
            IList<PfECategory> pfECategoryList,
            IList<PfECategory> pfECategories,
            int lMaxUid)
        {
            Guard.ArgumentIsNotNull(pfECategoryList, nameof(pfECategoryList));
            Guard.ArgumentIsNotNull(categories, nameof(categories));

            var lMasterCount = categories.Count + 1;
            var commandText =
                "Insert Into EPGP_COST_CATEGORIES (BC_UID,BC_NAME,BC_ID,BC_LEVEL,BC_ROLE,BC_UOM,MC_UID,CA_UID) Values (@UID,@NAME,@ID,@LEVEL,@ROLE,@UOM,@MCUID,@CAUID)";
            var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction);
            var addUid = sqlCommand.Parameters.Add("@UID", SqlDbType.Int);
            var addName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar, 255);
            var addId = sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
            var addLevel = sqlCommand.Parameters.Add("@LEVEL", SqlDbType.Int);
            var addRole = sqlCommand.Parameters.Add("@ROLE", SqlDbType.Int);
            var addUom = sqlCommand.Parameters.Add("@UOM", SqlDbType.NVarChar, 255);
            var addMcUid = sqlCommand.Parameters.Add("@MCUID", SqlDbType.Int);
            var addCaUid = sqlCommand.Parameters.Add("@CAUID", SqlDbType.Int);

            foreach (var category in categories)
            {
                addUid.Value = category.Uid;
                addName.Value = category.Name;
                addId.Value = category.ID;
                addLevel.Value = category.Level;
                addRole.Value = category.Role;
                addUom.Value = category.UOM;
                addMcUid.Value = 0;
                addCaUid.Value = category.Uid;
                sqlCommand.ExecuteNonQuery();
            }

            var lMajorIndex = 1;

            foreach (var pfECategory in pfECategoryList)
            {
                addUid.Value = GetUID(pfECategories.ToList(), pfECategory.Uid, 0, ref lMaxUid);
                addName.Value = pfECategory.Name;
                addId.Value = lMajorIndex * lMasterCount;
                addLevel.Value = 1;
                addRole.Value = 0;
                addUom.Value = string.Empty;
                addMcUid.Value = pfECategory.Uid;
                addCaUid.Value = 0;
                sqlCommand.ExecuteNonQuery();

                foreach (var category in categories)
                {
                    addUid.Value = GetUID(pfECategories.ToList(), pfECategory.Uid, category.Uid, ref lMaxUid);
                    addName.Value = category.Name;
                    addId.Value = lMajorIndex * lMasterCount + category.ID;
                    addLevel.Value = category.Level + 1;
                    addRole.Value = category.Role;
                    addUom.Value = category.UOM;
                    addMcUid.Value = pfECategory.Uid;
                    addCaUid.Value = category.Uid;
                    sqlCommand.ExecuteNonQuery();
                }

                lMajorIndex++;
            }
        }
    }
}