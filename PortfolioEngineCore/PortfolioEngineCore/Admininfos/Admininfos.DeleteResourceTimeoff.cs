using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public partial class Admininfos
    {
        /// <summary>
        /// Deletes Non Work entries for Personal Items for a resource.
        /// </summary>
        /// <param name="data">xml defn of the resources, Categories, and items.</param>
        /// <returns></returns>
        public bool DeleteResourceTimeoff(string data, out string result)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteResourceTimeoff", "Input", data);

                var resource = new CStruct();
                resource.LoadXML(data);

                var resourceId = resource.GetIntAttr("Id");
                var extId = resource.GetStringAttr("ExtId");
                var dataId = resource.GetStringAttr("DataId");

                var canUpdate = true;
                var cStruct = new CStruct();
                cStruct.Initialize("Resource");
                cStruct.CreateIntAttr("Id", resourceId);
                cStruct.CreateStringAttr("DataId", dataId);
                cStruct.CreateStringAttr("ExtId", extId);

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                var errorMessage = CheckIfResourceExists(extId, ref resourceId);

                if (errorMessage.Length > 0)
                {
                    canUpdate = false;
                    var status = cStruct.CreateSubStruct("Result");
                    status.CreateIntAttr("Status", 1);
                    status.CreateCDataSection(errorMessage);
                }

                UpdateDeleteResourceTimeoff(canUpdate, resource, cStruct, resourceId);

                _sqlConnection.Close();
                result = cStruct.XML();
                return canUpdate;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Trace.WriteLine(exception);
                throw new PFEException((int)PFEError.DeleteResourceTimeoff, exception.GetBaseMessage());
            }
        }

        private void UpdateDeleteResourceTimeoff(bool canUpdate, CStruct resource, CStruct cStruct, int resourceId)
        {
            Utilities.ArgumentIsNotNull(cStruct, nameof(cStruct));
            Utilities.ArgumentIsNotNull(resource, nameof(resource));

            if (canUpdate)
            {
                var categoryLists = resource.GetList("Category");

                foreach (var selectedCategory in categoryLists)
                {
                    var catId = selectedCategory.GetIntAttr("Id");
                    var catExtId = selectedCategory.GetStringAttr("ExtId");

                    var catResult = cStruct.CreateSubStruct("Category");
                    catResult.CreateIntAttr("Id", catId);
                    catResult.CreateStringAttr("ExtId", catExtId);

                    var canUpdateCategory = true;
                    var listItems = selectedCategory.GetList("Item");
                    var totalRows = 0;

                    foreach (var selectedItem in listItems)
                    {
                        var dHol = DateTime.Parse(selectedItem.GetStringAttr("Date"));

                        var command = "DELETE FROM EPG_NONWORK_HOURS Where NWI_ID=@NWI_uid And WRES_ID=@WresId And NWH_DATE=@date";

                        using (var sqlCommand = new SqlCommand(command, _sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@NWI_uid", catId);
                            sqlCommand.Parameters.AddWithValue("@WresId", resourceId);
                            sqlCommand.Parameters.AddWithValue("@date", dHol);
                            var rowsAffected = sqlCommand.ExecuteNonQuery();
                            totalRows += rowsAffected;

                            if (rowsAffected == 0)
                            {
                                canUpdateCategory = false;
                            }
                        }
                    }

                    var status = catResult.CreateSubStruct("Result");

                    if (canUpdateCategory)
                    {
                        status.CreateIntAttr("Status", 0);
                    }
                    else
                    {
                        status.CreateIntAttr("Status", 1);
                        status.CreateCDataSection($"Rows deleted for this category = {totalRows:0}");
                    }
                }
            }
        }
    }
}