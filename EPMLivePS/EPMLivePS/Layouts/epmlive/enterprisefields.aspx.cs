using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveEnterprise.Layouts.epmlive
{
    public partial class enterprisefields : LayoutsPageBase
    {
        //protected string standardFields;
        protected string customFields;
        protected string enterpriseFields;

        //protected string pjstandardFields;
        protected string pjcustomFields;
        protected string pjenterpriseFields;
        protected string pjpjenterpriseFields;

        protected string serverUrl;

        protected Label lblLastSyncResults;
        protected Label lblLastSyncTime;

        protected InputFormControl inpSynch;

        protected void Page_Load(object sender, EventArgs e)
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    Response.Write("INSERT INTO CUSTOMFIELDS (fieldname, editable, displayName, fieldCategory, wssFieldName, visible, sealed, fieldtype, assnfieldname) VALUES     ('" + (188744006 + i).ToString() + "', 0, 'Text" + (i + 20) + "', 2, 'TEXT" + (i + 20) + "', 0, 0, 'TEXT','" + (255869047 + i).ToString() + "')<br>");
            //}



            serverUrl = SPContext.Current.Site.Url;

            if (!SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                Response.Redirect(serverUrl + "/_layouts/accessdenied.aspx");

            try
            {
                if (!IsPostBack)
                {
                    fillGrid();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void fillGrid()
        {
            Guid siteGuid = SPContext.Current.Site.ID;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();

                using (var command = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=9", cn))
                {
                    command.Parameters.AddWithValue("@siteguid", siteGuid);

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            if (!dataReader.IsDBNull(3))
                            {
                                if (dataReader.GetInt32(3) == 0)
                                {
                                    lblLastSyncResults.Text = "Queued";
                                    inpSynch.Visible = false;
                                }
                                else if (dataReader.GetInt32(3) == 1)
                                {
                                    lblLastSyncResults.Text = "Processing (" + dataReader.GetInt32(2).ToString("##0") + "%)";
                                    inpSynch.Visible = false;
                                }
                                else if (!dataReader.IsDBNull(5))
                                {
                                    lblLastSyncResults.Text = dataReader.GetString(5);
                                }
                                else
                                {
                                    lblLastSyncResults.Text = "No Results";
                                }
                            }

                            if (!dataReader.IsDBNull(4))
                                lblLastSyncTime.Text = dataReader.GetDateTime(4).ToString();
                        }
                    }
                }


                if (Request["d"] != null)
                {
                    string isPj = "0";
                    try
                    {
                        isPj = Request["pj"].ToString();
                    }
                    catch { }

                    {
                        using (var command = new SqlCommand("spHideField", cn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@fieldname", Request["d"]);
                            command.Parameters.AddWithValue("@isPj", isPj);
                            command.Parameters.AddWithValue("@type", Request["type"]);
                            command.ExecuteNonQuery();
                        }
                    }

                    Response.Redirect(serverUrl + "/_layouts/epmlive/enterprisefields.aspx?" + Guid.NewGuid());
                }

                //cmd = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=1 and visible=1 order by displayname", cn);
                //SqlDataReader dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    standardFields = standardFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
                //    standardFields = standardFields + dr.GetString(2);
                //    standardFields = standardFields + "</td><td align=\"center\" class=\"cell\">";
                //    standardFields = standardFields + "<input type=\"hidden\" name=\"fields\" value=\"" + dr.GetString(0) + "\">";

                //    standardFields = standardFields + "<input class=\"checkbox\" type=\"checkbox\" name=\"" + dr.GetString(0) + "\" ";

                //    if (!dr.IsDBNull(10))
                //    {
                //        if (dr.GetBoolean(1))
                //            standardFields = standardFields + "checked";
                //        standardFields = standardFields + ">";
                //    }
                //    else
                //    {
                //        if (dr.GetBoolean(1))
                //            standardFields = standardFields + "checked";
                //        standardFields = standardFields + " disabled>";
                //    }
                //    standardFields = standardFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";

                //    if (!dr.GetBoolean(6))
                //        standardFields = standardFields + "<a href=enterprisefields.aspx?d=" + dr.GetString(0) + "&type=1>delete</a>";
                //    else
                //        standardFields = standardFields + "&nbsp;";

                //    standardFields = standardFields + "</font></td></tr>";
                //}

                //dr.Close();
                //====================Custom Fields================
                using (var command = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=2 and visible=1 order by displayname", cn))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customFields = customFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
                            customFields = customFields + dataReader.GetString(2);
                            //customFields = customFields + "</td><td align=\"center\" class=\"cell\">";
                            //customFields = customFields + "<input type=\"hidden\" name=\"fields\" value=\"" + dr.GetString(0) + "\">";
                            //customFields = customFields + "<input class=\"checkbox\" type=\"checkbox\" name=\"" + dr.GetString(0) + "\" ";
                            //if (dr.GetBoolean(1))
                            //    customFields = customFields + "checked";

                            //customFields = customFields + ">";
                            customFields = customFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";

                            if (!dataReader.GetBoolean(6))
                                customFields = customFields + "<a href=enterprisefields.aspx?d=" + dataReader.GetString(0) + "&type=2>delete</a>";
                            else
                                customFields = customFields + "&nbsp;";

                            customFields = customFields + "</font></td></tr>";
                        }
                    }
                }
                //====================Enterprise===================

                using (var command = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=3 and visible=1 order by displayname", cn))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            enterpriseFields = enterpriseFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
                            enterpriseFields = enterpriseFields + dataReader.GetString(2);
                            //enterpriseFields = enterpriseFields + "</td><td align=\"center\" class=\"cell\">";
                            //enterpriseFields = enterpriseFields + "<input type=\"hidden\" name=\"fields\" value=\"" + dr.GetString(0) + "\">";
                            //enterpriseFields = enterpriseFields + "<input class=\"checkbox\" type=\"checkbox\" name=\"" + dr.GetString(0) + "\" ";
                            //if (dr.GetBoolean(1))
                            //    enterpriseFields = enterpriseFields + "checked";

                            //if (dr.IsDBNull(10))
                            //    enterpriseFields = enterpriseFields + " disabled=\"disabled\"";

                            //enterpriseFields = enterpriseFields + "/>";
                            enterpriseFields = enterpriseFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";

                            if (!dataReader.GetBoolean(6))
                                enterpriseFields = enterpriseFields + "<a href=enterprisefields.aspx?d=" + dataReader.GetString(0) + "&type=3>delete</a>";
                            else
                                enterpriseFields = enterpriseFields + "&nbsp;";

                            enterpriseFields = enterpriseFields + "</font></td></tr>";
                        }
                    }
                }

                loadPjFields(cn);

                cn.Close();
            });
        }



        private void loadPjFields(SqlConnection cn)
        {
            //SqlCommand cmd = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=1 and pjvisible=1 order by displayname", cn);
            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    pjstandardFields = pjstandardFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
            //    pjstandardFields = pjstandardFields + dr.GetString(2);
            //    pjstandardFields = pjstandardFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";

            //    if (!dr.GetBoolean(6))
            //        pjstandardFields = pjstandardFields + "<a href=enterprisefields.aspx?d=" + dr.GetString(0) + "&type=1&pj=1>delete</a>";
            //    else
            //        pjstandardFields = pjstandardFields + "&nbsp;";

            //    pjstandardFields = pjstandardFields + "</font></td></tr>";
            //}

            //dr.Close();
            //====================Custom Fields================
            using (var command = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=2 and pjvisible=1 order by displayname", cn))
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        pjcustomFields = pjcustomFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
                        pjcustomFields = pjcustomFields + dataReader.GetString(2);
                        pjcustomFields = pjcustomFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";
                        pjcustomFields = pjcustomFields + "<a href=enterprisefields.aspx?d=" + dataReader.GetString(0) + "&type=2&pj=1>delete</a>";
                        pjcustomFields = pjcustomFields + "</font></td></tr>";
                    }
                }
            }
            ////====================Enterprise===================

            using (var command = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=3 and pjvisible=1", cn))
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        pjenterpriseFields = pjenterpriseFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
                        pjenterpriseFields = pjenterpriseFields + dataReader.GetString(2);
                        pjenterpriseFields = pjenterpriseFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";
                        pjenterpriseFields = pjenterpriseFields + "<a href=enterprisefields.aspx?d=" + dataReader.GetString(0) + "&type=3&pj=1>delete</a>";
                        pjenterpriseFields = pjenterpriseFields + "</font></td></tr>";
                    }
                }
            }
            ////====================pjEnterprise===================

            using (var command = new SqlCommand("Select * from CUSTOMFIELDS where fieldcategory=4 and pjvisible=1", cn))
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        pjpjenterpriseFields = pjpjenterpriseFields + "<tr><td class=\"ms-descriptiontext cell\" style=\"padding-left: 20px\">";
                        pjpjenterpriseFields = pjpjenterpriseFields + dataReader.GetString(2);
                        pjpjenterpriseFields = pjpjenterpriseFields + "</td><td align=\"center\" class=\"cell\"><font class=\"ms-descriptiontext\">";
                        pjpjenterpriseFields = pjpjenterpriseFields + "<a href=enterprisefields.aspx?d=" + dataReader.GetString(0) + "&type=3&pj=1>delete</a>";
                        pjpjenterpriseFields = pjpjenterpriseFields + "</font></td></tr>";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(SPContext.Current.Web.Url + "/_layouts/settings.aspx");
            //Guid siteGuid = SPContext.Current.Site.ID
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //    SqlConnection cn = new SqlConnection(EPMLiveHelperClasses.getEPMLiveConnectionString(siteGuid));
            //    cn.Open();
            //    string[] fields = Request["fields"].Split(',');

            //    SqlCommand cmd;

            //    foreach (string field in fields)
            //    {
            //        string fieldVal = Request[field];

            //        if (fieldVal == null)
            //        {
            //            cmd = new SqlCommand("UPDATE CUSTOMFIELDS set editable = 0 where fieldname=@fieldname", cn);
            //            cmd.Parameters.AddWithValue("@fieldname", field);
            //            cmd.ExecuteNonQuery();
            //        }
            //        else
            //        {
            //            cmd = new SqlCommand("UPDATE CUSTOMFIELDS set editable = 1 where fieldname=@fieldname", cn);
            //            cmd.Parameters.AddWithValue("@fieldname", field);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    cn.Close();
            //});
            //fillGrid();
        }
    }
}
