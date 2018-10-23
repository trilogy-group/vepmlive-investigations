using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class queuejobs : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SPSite oSite = SPContext.Current.Site;
                {
                    using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(oSite.WebApplication.Id)))
                    {
                        SPSecurity.RunWithElevatedPrivileges(() => sqlConnection.Open());

                        var dataTable = new DataTable();

                        using (var sqlCommand = new SqlCommand(
                            "select jobname as [Job Name],timerjobuid,percentComplete as [% Complete],status as [Job Status],dtcreated as [Created Date],dtstarted as [Started Date],dtfinished as [Finished Date],result as [Status], case result when 'Errors' then resulttext else '' end as [Error Description] from vwQueueTimerLog where DATEDIFF(DAY,[dtcreated],GETDATE()) <= 7 and siteguid=@siteId order by dtcreated desc",
                            sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@siteId", oSite.ID);

                            using (var dataReader = sqlCommand.ExecuteReader())
                            {
                                dataTable.Load(dataReader);
                            }
                        }

                        var html = new StringBuilder("<div class='row-fluid' id='jobqueuedetailslog-wrap'>")
                           .Append("<table class='table-bordered' id='jobqueuedetailslog'>")
                           .Append("<thead>")
                           .Append("<tr>");

                        foreach (DataColumn column in dataTable.Columns)
                        {
                            html.Append("<th>")
                               .Append(column.ColumnName)
                               .Append("</th>");
                        }

                        html.Append("</tr>")
                           .Append("</thead>");

                        foreach (DataRow row in dataTable.Rows)
                        {
                            html.Append("<tr>");

                            foreach (DataColumn column in dataTable.Columns)
                            {
                                html.Append("<td>");

                                if (column.ColumnName.Equals("Job Status"))
                                {
                                    if (row[column.ColumnName].ToString() == "0")
                                    {
                                        html.Append("Queued");
                                    }
                                    else if (row[column.ColumnName].ToString() == "1")
                                    {
                                        html.Append("Processing");
                                    }
                                    else if (row[column.ColumnName].ToString() == "2")
                                    {
                                        html.Append("Complete");
                                    }
                                }
                                else
                                {
                                    html.Append(row[column.ColumnName]);
                                }

                                html.Append("</td>");
                            }

                            html.Append("</tr>");
                        }

                        html.Append("</table>")
                           .Append("</div>");

                        queuejobsPlaceHolder.Controls.Add(new Literal { Text = html.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
