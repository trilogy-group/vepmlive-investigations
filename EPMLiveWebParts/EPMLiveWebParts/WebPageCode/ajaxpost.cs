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
using Microsoft.SharePoint;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.SharePoint.JsonUtilities;
using System.Web.Script.Serialization;
using System.Web.Script.Services;


namespace EPMLiveWebParts
{
    public partial class ajaxpost : System.Web.UI.Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["siteid"] != null)
            {
                SPSite site = null;
                SPWeb web = null;
                SPList list = null;
                GridData gd = new GridData();
                bool isRollup = false;
                gd.GanttParams64bitString = Request["params"].ToString();
                gd.InitRoutine(out isRollup);
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    site = new SPSite(new Guid(Request["siteid"].ToString()));
                    web = site.AllWebs[new Guid(Request["webid"].ToString())];
                    list = web.Lists[new Guid(Request["listid"].ToString())];
                    gd.List = list;
                    //GridUtilities.List = list;
                });

                try
                {
                    //GridUtilities.View = web.GetViewFromUrl(Request["viewUrl"].ToString());
                    gd.View = web.GetViewFromUrl(Request["viewUrl"].ToString());
                }
                catch (Exception ex)
                {
                    try
                    {
                        gd.View = web.ParentWeb.GetViewFromUrl(Request["viewUrl"].ToString());
                    }
                    catch (Exception ex2)
                    {
                        //GridUtilities.AddError("Web: " + web.ServerRelativeUrl + " List: " + list.Title + " View: " + Request["viewUrl"].ToString() + " Message: " + ex2.Message);
                    }
                }

                //GridUtilities.InitViewFields();
                SPListItem li = gd.List.Items.GetItemById(int.Parse(Request["itemid"].ToString()));
                ArrayList imgs = new ArrayList();
                if (Request["imgs"].ToString() != string.Empty)
                {
                    imgs.AddRange(Request["imgs"].ToString().Split(",".ToCharArray()));
                }
                string json = "{ \"FieldValues\": [";
                string types = "";
                foreach (string sfield in gd.ViewFields)
                {
                        FieldValues fv = new FieldValues();
                        if (list.Fields.ContainsField(sfield))
                        {
                            SPField spField = list.Fields.GetFieldByInternalName(sfield);
                            types = types + spField.TypeAsString + "|";
                            fv.fieldKey = gd.GetDisplayName(sfield);
                            if (!spField.Description.ToLower().Contains("indicator"))
                            {
                                string type = spField.TypeAsString;
                                string val = string.Empty;
                                switch (type)
                                {
                                    case "Computed":
                                        fv.dataValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        fv.localizedValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        break;

                                    case "Calculated":
                                        fv.dataValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        fv.localizedValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        break;

                                    case "Text":
                                        fv.dataValue = li[spField.Id];
                                        fv.localizedValue = li[spField.Id];
                                        break;

                                    case "Number":
                                        if (li[spField.Id] != null && li[spField.Id].ToString() != "")
                                        {
                                            if (spField.InternalName.ToLower() != "percentcomplete")
                                            {
                                                val = String.Format("{0:#,0.00}", li[spField.Id]);
                                            }
                                            else
                                            {
                                                decimal pct = decimal.Parse(li[spField.Id].ToString());
                                                pct = pct * 100;
                                                val = String.Format("{0:#,0.00}", pct.ToString());
                                                val = val + " %";
                                            }
                                        }

                                        fv.dataValue = val;
                                        fv.localizedValue = val;
                                        break;

                                    case "Currency":
                                        if (li[spField.Id] != null)
                                        {
                                            val = String.Format("{0:C}", li[spField.Id]);
                                        }
                                        fv.dataValue = val;
                                        fv.localizedValue = val;
                                        break;

                                    case "Boolean":
                                        fv.dataValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        fv.localizedValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        break;

                                    case "Note":
                                        fv.dataValue = li[spField.Id];
                                        fv.localizedValue = li[spField.Id];
                                        break;

                                    case "DateTime":
                                        SPFieldDateTime spfdt = (SPFieldDateTime)spField;
                                        if (spfdt.DisplayFormat == SPDateTimeFieldFormatType.DateTime)
                                        {
                                            if (li[spField.Id] != null)
                                            {
                                                val = DateTime.Parse(li[spField.Id].ToString()).ToString();
                                            }
                                            fv.dataValue = val;
                                            fv.localizedValue = val;
                                        }
                                        else
                                        {
                                            if (li[spField.Id] != null)
                                            {
                                                val = DateTime.Parse(li[spField.Id].ToString()).ToShortDateString();
                                            }
                                            fv.dataValue = val;
                                            fv.localizedValue = val;
                                        }
                                        break;

                                    default:
                                        fv.dataValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        fv.localizedValue = spField.GetFieldValueAsText(li[spField.Id]);
                                        break;
                                }
                            }
                            else
                            {
                                string val = spField.GetFieldValueAsText(li[spField.Id]).ToLower();
                                fv.dataValue = imgs.IndexOf(spField.GetFieldValueAsText(li[spField.Id]).ToLower());
                                fv.localizedValue = "";
                            }
                            Serializer s = new Serializer();
                            json = json + fv.ToJson(s) + ",";
                        }
                }
                json = json.Remove(json.LastIndexOf(","));
                json = json + "]}";
                Response.Output.WriteLine(json);
            }
            else
            {
                Response.Output.WriteLine("Failed");
            }
            //GridUtilities.WriteLog();
            //GridUtilities.IDisposable();
        }
    }
} 
