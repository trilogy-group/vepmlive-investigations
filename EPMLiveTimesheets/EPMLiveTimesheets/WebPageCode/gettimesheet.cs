using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using EPMLiveCore;
using EPMLiveCore.Helpers;
using EPMLiveWebParts;
using Microsoft.SharePoint;
using DiagTrace = System.Diagnostics.Trace;

namespace TimeSheets
{
    public partial class gettimesheet : getgriditems
    {
        public override void getParams(SPWeb curWeb)
        {
            Guard.ArgumentIsNotNull(curWeb, nameof(curWeb));

            base.getParams(curWeb);
            isTimesheet = true;

            var strPeriod = Request["period"];
            period = int.Parse(strPeriod);
        }

        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {
            Guard.ArgumentIsNotNull(curWeb, nameof(curWeb));
            Guard.ArgumentIsNotNull(arrGTemp, nameof(arrGTemp));
            Guard.ArgumentIsNotNull(query, nameof(query));

            var dataSet = new DataSet();
            var newTimeSheet = false;

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    var requestedUser = Page.Request["duser"];
                    var resName = string.Empty;

                    if (!string.IsNullOrWhiteSpace(requestedUser))
                    {
                        if (SharedFunctions.canUserImpersonate(username, requestedUser, site.RootWeb, out resName))
                        {
                            username = requestedUser;
                        }
                    }

                    Action<int, string, SqlConnection, DataSet> fillDataSet =
                        (value, cmdText, sql, dataSet1) =>
                        {
                            using (var sqlCommand = new SqlCommand(cmdText, sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            })
                            {
                                sqlCommand.Parameters.AddWithValue(IdUserName, username);
                                sqlCommand.Parameters.AddWithValue(IdSiteGuid, site.ID);
                                sqlCommand.Parameters.AddWithValue(IdPeriod, value);

                                using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                                {
                                    dataAdapter.Fill(dataSet1);
                                }
                            }
                        };

                    try
                    {
                        SqlConnection(curWeb, fillDataSet, ref dataSet, ref newTimeSheet);
                    }
                    catch (Exception exception)
                    {
                        DiagTrace.WriteLine(exception);
                    }

                    ProcessDataRow(arrGTemp, curWeb, dataSet, newTimeSheet);
                });
        }

        private void SqlConnection(SPWeb curWeb, Action<int, string, SqlConnection, DataSet> fillDataSet, ref DataSet dataSet, ref bool newTimeSheet)
        {
            Guard.ArgumentIsNotNull(dataSet, nameof(dataSet));
            Guard.ArgumentIsNotNull(fillDataSet, nameof(fillDataSet));
            Guard.ArgumentIsNotNull(curWeb, nameof(curWeb));

            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(curWeb.Site.WebApplication.Id)))
            {
                sqlConnection.Open();

                fillDataSet(period, SpTsGetTsForSiteText, sqlConnection, dataSet);

                using (var sqlCommand = new SqlCommand(
                    "Select submitted from tstimesheet where username=@username and site_uid=@siteguid and period_id=@period_id",
                    sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(IdUserName, username);
                    sqlCommand.Parameters.AddWithValue(IdSiteGuid, site.ID);
                    sqlCommand.Parameters.AddWithValue(IdPeriod, period);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            submitted = dataReader.GetBoolean(0);
                        }
                    }
                }

                if (dataSet.Tables[0].Rows.Count <= 0)
                {
                    newTimeSheet = true;
                    dataSet = new DataSet();
                    var intPeriod = 1;

                    using (var sqlCommand = new SqlCommand(
                        "SELECT TOP (1) PERIOD_ID FROM TSTIMESHEET WHERE     (USERNAME LIKE @username) and site_uid=@siteid ORDER BY PERIOD_ID DESC",
                        sqlConnection)
                    {
                        CommandType = CommandType.Text
                    })
                    {
                        sqlCommand.Parameters.AddWithValue(IdUserName, username);
                        sqlCommand.Parameters.AddWithValue(IdSite, site.ID);

                        using (var dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                intPeriod = dataReader.GetInt32(0);
                            }
                        }
                    }

                    fillDataSet(intPeriod, SpTsGetTsForSiteText, sqlConnection, dataSet);
                }

                fillDataSet(period, "spTSgetTSHours", sqlConnection, dsTSHours);
                fillDataSet(period, "spTSgetTSMeta", sqlConnection, dsTSMeta);
                TimeSheetTasks(curWeb, sqlConnection);
            }
        }

        private void TimeSheetTasks(SPWeb curWeb, SqlConnection sqlConnection)
        {
            Guard.ArgumentIsNotNull(sqlConnection, nameof(sqlConnection));
            Guard.ArgumentIsNotNull(curWeb, nameof(curWeb));

            using (var sqlCommand = new SqlCommand(
                "select title,project,ts_uid,web_uid,list_uid,item_id,ts_item_uid,approval_status,resourcename,username from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project",
                sqlConnection)
            {
                CommandType = CommandType.Text
            })
            {
                sqlCommand.Parameters.AddWithValue(IdPeriod, period);
                sqlCommand.Parameters.AddWithValue(IdSite, curWeb.Site.ID);
                dsTimesheetTasks = new DataSet();

                using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    dataAdapter.Fill(dsTimesheetTasks);
                }
            }
        }

        private void ProcessDataRow(SortedList arrGTemp, SPWeb curWeb, DataSet dataSet, bool newTimeSheet)
        {
            Guard.ArgumentIsNotNull(dataSet, nameof(dataSet));
            Guard.ArgumentIsNotNull(curWeb, nameof(curWeb));
            Guard.ArgumentIsNotNull(arrGTemp, nameof(arrGTemp));

            var webGuid = new Guid();
            var listGuid = new Guid();
            SPWeb iWeb = null;
            SPList iList = null;

            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                var found = false;

                try
                {
                    var wGuid = new Guid(dr[0].ToString());
                    var lGuid = new Guid(dr[1].ToString());

                    if (webGuid != wGuid)
                    {
                        if (iWeb != null)
                        {
                            iWeb.Close();
                            iWeb = site.OpenWeb(wGuid);
                        }
                        else
                        {
                            iWeb = site.OpenWeb(wGuid);
                        }

                        webGuid = iWeb.ID;
                    }

                    if (listGuid != lGuid)
                    {
                        iList = iWeb.Lists[lGuid];
                        listGuid = iList.ID;
                    }

                    var itemById = iList.GetItemById(int.Parse(dr[2].ToString()));
                    found = true;

                    if (newTimeSheet)
                    {
                        try
                        {
                            if (itemById["Timesheet"].ToString() == TrueText)
                            {
                                addItem(itemById, arrGTemp);
                            }
                        }
                        catch (Exception exception)
                        {
                            DiagTrace.WriteLine(exception);
                        }
                    }
                    else
                    {
                        addItem(itemById, arrGTemp);
                    }
                }
                catch (Exception exception)
                {
                    DiagTrace.WriteLine(exception);
                }

                if (!found && !newTimeSheet)
                {
                    addItem(dr, arrGTemp, curWeb);
                }
            }
        }
    }
}