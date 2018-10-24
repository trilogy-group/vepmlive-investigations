using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        protected virtual SqlParameter PopulateDefaultColumnValue(string column, SPListItem li)
        {
            Guard.ArgumentIsNotNull(li, nameof(li));
            Guard.ArgumentIsNotNull(column, nameof(column));
            Guard.ArgumentIsNotNull(li, nameof(li));
            Guard.ArgumentIsNotNull(column, nameof(column));
            var param = new SqlParameter();

            switch (column)
            {
                case "siteid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@siteid";
                    param.Value = li.ParentList.ParentWeb.Site.ID;
                    break;
                case "webid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@webid";
                    param.Value = li.ParentList.ParentWeb.ID;
                    break;
                case "listid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@rptlistid";
                    param.Value = li.ParentList.ID;
                    break;
                case "itemid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@itemid";
                    param.Value = li.ID;
                    break;
                case "weburl":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    param.ParameterName = "@weburl";
                    param.Value = li.ParentList.ParentWeb.ServerRelativeUrl;
                    break;
                default:
                    Trace.WriteLine($"Unexpected value : {column}");
                    break;
            }

            return param;
        }

        protected virtual SqlParameter PopulateMandatoryHiddenFldsColumnValue(string column, SPListItem li)
        {
            Guard.ArgumentIsNotNull(li, nameof(li));
            Guard.ArgumentIsNotNull(column, nameof(column));
            Guard.ArgumentIsNotNull(li, nameof(li));
            Guard.ArgumentIsNotNull(column, nameof(column));
            var param = new SqlParameter();
            string tempValue;

            switch (column)
            {
                case "commenters":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@commenters";

                    try
                    {
                        tempValue = li["Commenters"].ToString();
                        param.Value = tempValue;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        param.Value = DBNull.Value;
                    }

                    break;

                case "commentcount":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@commentcount";

                    try
                    {
                        tempValue = li["CommentCount"].ToString();
                        param.Value = Convert.ToInt32(tempValue);
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        param.Value = DBNull.Value;
                    }

                    break;

                case "commentersread":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@commentersread";

                    try
                    {
                        tempValue = li["CommentersRead"].ToString();
                        param.Value = tempValue;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        param.Value = DBNull.Value;
                    }

                    break;

                case "workspaceurl":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@workspaceurl";

                    try
                    {
                        tempValue = li["WorkspaceUrl"].ToString();
                        param.Value = tempValue;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        param.Value = DBNull.Value;
                    }

                    break;
                default:
                    Trace.WriteLine($"Unexpected value : {column}");
                    break;
            }

            return param;
        }
    }
}