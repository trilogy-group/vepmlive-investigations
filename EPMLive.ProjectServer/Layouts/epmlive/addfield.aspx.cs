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
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
    public partial class addfield : System.Web.UI.Page
    {
        protected ListBox ListBox1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!SPContext.Current.Web.Users[HttpContext.Current.User.Identity.Name].IsSiteAdmin)
            //if (!SPContext.Current.Web.Users[SPContext.Current.Web.CurrentUser.LoginName].IsSiteAdmin)
            if(!SPContext.Current.Web.UserIsSiteAdmin)
                Response.Redirect(SPContext.Current.Site.Url + "/_layouts/accessdenied.aspx");
            
            //Guid siteGuid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    if (!IsPostBack)
                    {

                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                        cn.Open();

                        if (Request["type"] == "1" || Request["type"] == "2")
                        {
                            if (Request["pj"] == "1")
                            {
                                SqlCommand cmd = new SqlCommand("SELECT fieldname,displayname from customfields where fieldcategory=@type and pjvisible=0 order by displayname", cn);
                                cmd.Parameters.AddWithValue("@type", Request["type"]);

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                ListBox1.DataSource = ds.Tables[0];
                                ListBox1.DataTextField = "displayname";
                                ListBox1.DataValueField = "fieldname";
                                ListBox1.DataBind();
                            }
                            else
                            {
                                SqlCommand cmd = new SqlCommand("SELECT fieldname,displayname from customfields where fieldcategory=@type and visible=0 order by displayname", cn);
                                cmd.Parameters.AddWithValue("@type", Request["type"]);

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                ListBox1.DataSource = ds.Tables[0];
                                ListBox1.DataTextField = "displayname";
                                ListBox1.DataValueField = "fieldname";
                                ListBox1.DataBind();
                            }
                        }
                        else if (Request["type"] == "3")
                        {
                            string modifier = "";
                            if (Request["pj"] == "1")
                            {
                                modifier = " pjvisible = 1";
                            }
                            else
                                modifier = " visible = 1";

                            WebSvcCustomFields.CustomFields cf = new WebSvcCustomFields.CustomFields();
                            cf.Url = SPContext.Current.Site.Url + "/_vti_bin/PSI/customfields.asmx";
                            cf.UseDefaultCredentials = true;

                            WebSvcCustomFields.CustomFieldDataSet dsF = cf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                            for (int i = 0; i < dsF.CustomFields.Count; i++)
                            {
                                WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow customField = dsF.CustomFields[i];

                                SqlCommand cmd = new SqlCommand("SELECT fieldname from customfields where fieldname=@fieldname and " + modifier, cn);
                                cmd.Parameters.AddWithValue("@fieldname", customField.MD_PROP_ID.ToString());
                                SqlDataReader dr = cmd.ExecuteReader();
                                if (!dr.Read())
                                {
                                    string table = "";
                                    try
                                    {
                                        table = customField.MD_LOOKUP_TABLE_UID.ToString();
                                    }
                                    catch { }
                                    string cfData = "";
                                    string choice = "CHOICE";
                                    if (table == "")
                                        choice = ((PSLibrary.PropertyType)customField.MD_PROP_TYPE_ENUM).ToString();

                                    if (customField.IsMD_PROP_FORMULANull())
                                        cfData = customField.MD_PROP_ID + "#" + choice + "#" + customField.MD_PROP_UID_SECONDARY + "#" + customField.MD_PROP_UID_SECONDARY;
                                    else
                                        cfData = customField.MD_PROP_ID + "#" + choice + "#" + customField.MD_PROP_UID_SECONDARY + "#";

                                    ListItem li = new ListItem(customField.MD_PROP_NAME, cfData);
                                    ListBox1.Items.Add(li);
                                }
                                dr.Close();
                            }
                        }
                        else if (Request["type"] == "4")
                        {
                            string modifier = "";
                            if (Request["pj"] == "1")
                            {
                                modifier = " pjvisible = 1";
                            }
                            else
                                modifier = " visible = 1";

                            WebSvcCustomFields.CustomFields cf = new WebSvcCustomFields.CustomFields();
                            cf.Url = SPContext.Current.Site.Url + "/_vti_bin/PSI/customfields.asmx";
                            cf.UseDefaultCredentials = true;

                            WebSvcCustomFields.CustomFieldDataSet dsF = cf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.ProjectEntity.UniqueId));
                            for (int i = 0; i < dsF.CustomFields.Count; i++)
                            {
                                WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow customField = dsF.CustomFields[i];

                                SqlCommand cmd = new SqlCommand("SELECT fieldname from customfields where fieldname=@fieldname and " + modifier, cn);
                                cmd.Parameters.AddWithValue("@fieldname", customField.MD_PROP_ID.ToString());
                                SqlDataReader dr = cmd.ExecuteReader();
                                if (!dr.Read())
                                {
                                    string table = "";
                                    try
                                    {
                                        table = customField.MD_LOOKUP_TABLE_UID.ToString();
                                    }
                                    catch { }
                                    string cfData = "";
                                    if (table == "")
                                        cfData = customField.MD_PROP_ID + "#" + ((PSLibrary.PropertyType)customField.MD_PROP_TYPE_ENUM).ToString() + "##";
                                    else
                                        cfData = customField.MD_PROP_ID + "#CHOICE##";

                                    

                                    ListItem li = new ListItem(customField.MD_PROP_NAME, cfData);
                                    ListBox1.Items.Add(li);
                                }
                                dr.Close();
                            }
                        }

                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            });
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Guid siteGuid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();
                string isPj = "0";
                try
                {
                    isPj = Request["pj"].ToString();
                }
                catch { }

                foreach (ListItem li in ListBox1.Items)
                {
                    if (li.Selected)
                    {
                        string fieldName = "";
                        string displayname = "";
                        string fieldtype = "";
                        string wssFieldName = "";
                        string assnfieldname = "";
                        string assnupdatefield = "";

                        if (Request["type"] == "3" || Request["type"] == "4")
                        {
                            string[] sData = li.Value.Split('#');
                            string xml = "";
                            switch (sData[1])
                            {
                                case "NumberEng96":
                                    xml = "NUMBER";
                                    break;
                                case "CostEng96":
                                    xml = "CURRENCY";
                                    break;
                                case "StringEng96":
                                    xml = "TEXT";
                                    break;
                                case "YesNoEng96":
                                    xml = "BOOLEAN";
                                    break;
                                case "DurationEng96":
                                    xml = "DURATION";
                                    break;
                                case "StartDateEng96":
                                    xml = "DATETIME";
                                    break;
                                case "CHOICE":
                                    xml = "CHOICE";
                                    break;
                            }

                            wssFieldName = "ENT" + sData[0];

                            fieldName = sData[0];
                            displayname = li.Text;
                            fieldtype = xml;
                            assnfieldname = sData[2];
                            assnupdatefield = sData[3];
                        }
                        else
                            fieldName = li.Value;

                        SqlCommand cmd = new SqlCommand("spShowField", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fieldname", fieldName);
                        cmd.Parameters.AddWithValue("@displayname", displayname);
                        cmd.Parameters.AddWithValue("@fieldtype", fieldtype);
                        cmd.Parameters.AddWithValue("@wssfieldname", wssFieldName);
                        cmd.Parameters.AddWithValue("@assnfieldname", assnfieldname);
                        cmd.Parameters.AddWithValue("@isPj", isPj);
                        cmd.Parameters.AddWithValue("@fieldcategory", Request["type"].ToString());
                        if(assnupdatefield != "")
                            cmd.Parameters.AddWithValue("@assnupdatefield", assnupdatefield);


                        cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();

                RegisterStartupScript("closeindow", "<script language=\"javascript\">opener.location.href='enterprisefields.aspx';window.close();</script>");
            });
        }
    }
}