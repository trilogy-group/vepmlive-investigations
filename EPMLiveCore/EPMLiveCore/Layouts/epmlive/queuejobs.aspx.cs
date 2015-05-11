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
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(oSite.WebApplication.Id));
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cn.Open();
                    });

                    SqlCommand cmd = new SqlCommand("select jobname as JobName,timerjobuid,percentComplete as PercentComplete,status as JobStatus,dtcreated as DateCreated,dtstarted as DateStarted,dtfinished as DateFinished from vwQueueTimerLog", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dr);

                    StringBuilder html = new StringBuilder();

                    html.Append("<div class='row-fluid' id='jobqueuedetailslog-wrap'>");
                    html.Append("<table class='table table-bordered' id='jobqueuedetailslog'>");
                    html.Append("<thead>");
                    html.Append("<tr>");

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    html.Append("</thead>");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        html.Append("<tr>");
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            html.Append("<td>");

                            if (column.ColumnName.Equals("JobStatus"))
                            {
                                switch (row[column.ColumnName].ToString())
                                {
                                    case "0":
                                        html.Append("Queued");
                                        break;
                                    case "1":
                                        html.Append("Processing");
                                        break;
                                    case "2":
                                        html.Append("Complete");
                                        break;
                                };
                            }
                            else
                            {
                                html.Append(row[column.ColumnName]);
                            }
                            html.Append("</td>");
                        }
                        html.Append("</tr>");
                    }

                    html.Append("</table>");
                    html.Append("</div>");

                    queuejobsPlaceHolder.Controls.Add(new Literal { Text = html.ToString() });

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
