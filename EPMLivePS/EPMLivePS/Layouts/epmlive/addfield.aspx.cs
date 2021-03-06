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
using EPMLiveEnterprise.WebSvcCustomFields;
using Microsoft.SharePoint;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveEnterprise
{
    public partial class addfield : System.Web.UI.Page
    {
        private const string TypeParameter = "type";
        private const string Type1 = "1";
        protected ListBox ListBox1;
        private string Type2;

        public addfield()
        {
            Type2 = "2";
        }

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
                        using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
                        {
                            connection.Open();

                            if (Request[TypeParameter] == Type1 || Request[TypeParameter] == Type2)
                            {
                                if (Request["pj"] == Type1)
                                {
                                    using (var command = new SqlCommand("SELECT fieldname,displayname from customfields where fieldcategory=@type and pjvisible=0 order by displayname", connection))
                                    {
                                        command.Parameters.AddWithValue("@type", Request[TypeParameter]);

                                        using (var adapter = new SqlDataAdapter(command))
                                        {
                                            var dataSet = new DataSet();
                                            adapter.Fill(dataSet);

                                            ListBox1.DataSource = dataSet.Tables[0];
                                            ListBox1.DataTextField = "displayname";
                                            ListBox1.DataValueField = "fieldname";
                                            ListBox1.DataBind();
                                        }
                                    }
                                }
                                else
                                {
                                    using (var command = new SqlCommand("SELECT fieldname,displayname from customfields where fieldcategory=@type and visible=0 order by displayname", connection))
                                    {
                                        command.Parameters.AddWithValue("@type", Request[TypeParameter]);

                                        using (var adapter = new SqlDataAdapter(command))
                                        {
                                            var dataSet = new DataSet();
                                            adapter.Fill(dataSet);

                                            ListBox1.DataSource = dataSet.Tables[0];
                                            ListBox1.DataTextField = "displayname";
                                            ListBox1.DataValueField = "fieldname";
                                            ListBox1.DataBind();
                                        }
                                    }
                                }
                            }
                            else if (Request[TypeParameter] == "3")
                            {
                                string modifier = "";
                                if (Request["pj"] == Type1)
                                {
                                    modifier = " pjvisible = 1";
                                }
                                else
                                {
                                    modifier = " visible = 1";
                                }

                                CustomFields cf = new CustomFields();
                                cf.Url = SPContext.Current.Site.Url + "/_vti_bin/PSI/customfields.asmx";
                                cf.UseDefaultCredentials = true;

                                CustomFieldDataSet dsF = cf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                                for (int i = 0; i < dsF.CustomFields.Count; i++)
                                {
                                    CustomFieldDataSet.CustomFieldsRow customField = dsF.CustomFields[i];

                                    using (var command = new SqlCommand("SELECT fieldname from customfields where fieldname=@fieldname and " + modifier, connection))
                                    {
                                        command.Parameters.AddWithValue("@fieldname", customField.MD_PROP_ID.ToString());
                                        using (var reader = command.ExecuteReader())
                                        {
                                            if (!reader.Read())
                                            {
                                                var table = string.Empty;
                                                try
                                                {
                                                    table = customField.MD_LOOKUP_TABLE_UID.ToString();
                                                }
                                                catch (Exception ex)
                                                {
                                                    SystemTrace.WriteLine(ex.ToString());
                                                }
                                                var cfData = string.Empty;
                                                var choice = "CHOICE";
                                                if (table == string.Empty)
                                                {
                                                    choice = ((PSLibrary.PropertyType)customField.MD_PROP_TYPE_ENUM).ToString();
                                                }

                                                if (customField.IsMD_PROP_FORMULANull())
                                                {
                                                    cfData = $"{customField.MD_PROP_ID}#{choice}#{customField.MD_PROP_UID_SECONDARY}#{customField.MD_PROP_UID_SECONDARY}";
                                                }
                                                else
                                                {
                                                    cfData = customField.MD_PROP_ID + "#" + choice + "#" + customField.MD_PROP_UID_SECONDARY + "#";
                                                }

                                                var listItem = new ListItem(customField.MD_PROP_NAME, cfData);
                                                ListBox1.Items.Add(listItem);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (Request[TypeParameter] == "4")
                            {
                                string modifier = string.Empty;
                                if (Request["pj"] == Type1)
                                {
                                    modifier = " pjvisible = 1";
                                }
                                else
                                {
                                    modifier = " visible = 1";
                                }

                                var cf = new CustomFields();
                                cf.Url = SPContext.Current.Site.Url + "/_vti_bin/PSI/customfields.asmx";
                                cf.UseDefaultCredentials = true;

                                CustomFieldDataSet dsF = cf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.ProjectEntity.UniqueId));
                                for (int i = 0; i < dsF.CustomFields.Count; i++)
                                {
                                    CustomFieldDataSet.CustomFieldsRow customField = dsF.CustomFields[i];

                                    using (var command = new SqlCommand("SELECT fieldname from customfields where fieldname=@fieldname and " + modifier, connection))
                                    {
                                        command.Parameters.AddWithValue("@fieldname", customField.MD_PROP_ID.ToString());

                                        using (var reader = command.ExecuteReader())
                                        {
                                            if (!reader.Read())
                                            {
                                                var table = string.Empty;
                                                try
                                                {
                                                    table = customField.MD_LOOKUP_TABLE_UID.ToString();
                                                }
                                                catch (Exception ex)
                                                {
                                                    SystemTrace.WriteLine(ex.ToString());
                                                }
                                                var cfData = string.Empty;
                                                if (table == string.Empty)
                                                {
                                                    cfData = customField.MD_PROP_ID + "#" + ((PSLibrary.PropertyType)customField.MD_PROP_TYPE_ENUM).ToString() + "##";
                                                }
                                                else
                                                {
                                                    cfData = customField.MD_PROP_ID + "#CHOICE##";
                                                }

                                                var listItem = new ListItem(customField.MD_PROP_NAME, cfData);
                                                ListBox1.Items.Add(listItem);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    SystemTrace.WriteLine(ex.ToString());
                }
            });
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Guid siteGuid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
                {
                    connection.Open();
                    string isPj = "0";
                    try
                    {
                        isPj = Request["pj"].ToString();
                    }
                    catch (Exception ex)
                    {
                        SystemTrace.WriteLine(ex.ToString());
                    }

                    foreach (ListItem listItem in ListBox1.Items)
                    {
                        if (listItem.Selected)
                        {
                            var fieldName = string.Empty;
                            var displayname = string.Empty;
                            var fieldtype = string.Empty;
                            var wssFieldName = string.Empty;
                            var assnfieldname = string.Empty;
                            var assnupdatefield = string.Empty;

                            if (Request[TypeParameter] == "3" || Request[TypeParameter] == "4")
                            {
                                string[] sData = listItem.Value.Split('#');
                                var xml = string.Empty;
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
                                    default:
                                        SystemTrace.WriteLine("Argument out of range: sData[1] = {0}", sData[1]);
                                        break;
                                }

                                wssFieldName = $"ENT{sData[0]}";

                                fieldName = sData[0];
                                displayname = listItem.Text;
                                fieldtype = xml;
                                assnfieldname = sData[2];
                                assnupdatefield = sData[3];
                            }
                            else
                            {
                                fieldName = listItem.Value;
                            }

                            using (var command = new SqlCommand("spShowField", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@fieldname", fieldName);
                                command.Parameters.AddWithValue("@displayname", displayname);
                                command.Parameters.AddWithValue("@fieldtype", fieldtype);
                                command.Parameters.AddWithValue("@wssfieldname", wssFieldName);
                                command.Parameters.AddWithValue("@assnfieldname", assnfieldname);
                                command.Parameters.AddWithValue("@isPj", isPj);
                                command.Parameters.AddWithValue("@fieldcategory", Request[TypeParameter].ToString());
                                if (assnupdatefield != string.Empty)
                                {
                                    command.Parameters.AddWithValue("@assnupdatefield", assnupdatefield);
                                }
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                RegisterStartupScript("closeindow", "<script language=\"javascript\">opener.location.href='enterprisefields.aspx';window.close();</script>");
            });
        }
    }
}