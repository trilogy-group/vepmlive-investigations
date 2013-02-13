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
using System.Text.RegularExpressions;
using System.Xml;

namespace EPMLiveWebParts
{
    public partial class savegrid : getgriditems
    {
        private string output;
        private string []strFields;
        protected bool useResourcePool;
        private Hashtable hshResources = new Hashtable();

        private Hashtable hshSaveGroups = new Hashtable();

        /*protected void Page_Load(object sender, EventArgs e)
        {
            output = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><data>";
            try
            {
                Guid webGuid = new Guid();
                Guid siteGuid = new Guid();
                Guid listGuid = new Guid();
                SPWeb iWeb = null;
                SPSite iSite = null;
                SPList iList = null;

                if (Request["ids"] != null)
                {
                    Response.ContentType = "text/xml";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;

                    string[] ids = Request["ids"].Split(',');

                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(Request["columns"]);

                    strFields = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

                    foreach (string id in ids)
                    {
                        if (id != "")
                        {
                            string strWebId = "";
                            string strListId = "";
                            string strSiteId = "";
                            try
                            {
                                strWebId = Request[id + "_webid"].ToString();
                            }
                            catch { }
                            try
                            {
                                strListId = Request[id + "_listid"].ToString();
                            }
                            catch { }
                            try
                            {
                                strSiteId = Request[id + "_siteid"].ToString();
                            }
                            catch { }
                            if (strWebId != "" && strListId != "" && strSiteId != "")
                            {
                                try
                                {
                                    Guid wGuid = new Guid(strWebId);
                                    Guid lGuid = new Guid(strListId);
                                    Guid sGuid = new Guid(strSiteId);
                                    if (siteGuid != sGuid)
                                    {
                                        if (iWeb != null)
                                        {
                                            iWeb.Close();
                                            iWeb = null;
                                            iSite.Close();
                                        }
                                        iSite = new SPSite(sGuid);
                                        siteGuid = iSite.ID;
                                    }
                                    if (webGuid != wGuid)
                                    {
                                        if (iWeb != null)
                                        {
                                            iWeb.Close();
                                            iWeb = iSite.OpenWeb(wGuid);
                                        }
                                        else
                                            iWeb = iSite.OpenWeb(wGuid);
                                        webGuid = iWeb.ID;
                                    }
                                    if (listGuid != lGuid)
                                    {
                                        iList = iWeb.Lists[lGuid];
                                        listGuid = iList.ID;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    output += "<action type='error100'>Item: " + Request[id + "_title"].ToString() + " Message: " + ex.Message + "</action>";
                                }
                                processItem(id, iWeb, iList);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                output += "<action type='error500'>Message: " + ex.Message + ex.StackTrace + "</action>";
            }
            output += "</data>";
        }
        */

        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {

        }

        private void processItem(string gr_id, SPWeb web, SPList list)
        {
            web.AllowUnsafeUpdates = true;
            string status = "";
            string title = "";
            string id = "";
            try
            {
                status = Request[gr_id + "_!nativeeditor_status"].ToString();
            }
            catch { }
            try
            {
                title = Request[gr_id + "_title"].ToString();
            }
            catch { }
            try
            {
                id = Request[gr_id + "_itemid"].ToString();
            }
            catch { }

            int counter = 1;
            if (!inEditMode)
                counter = 0;
            if (showCheckboxes)
                counter++;

            string curField = "";

            try
            {
                SPListItem li = null;
                //bool added = false;
                try
                {
                    if(id != "0")
                    {
                        li = list.GetItemById(int.Parse(id));
                    }
                }
                catch{}
                if(li == null)
                {
                   // added = true;
                    li = list.Items.Add();
                }
                if (status == "deleted")
                {
                    li.Delete();
                    output += "<action type='delete' sid='" + gr_id + "'/>";
                }
                else
                {
                    bool reqField = false;
                    foreach (string strField in strFields)
                    {
                        curField = strField;
                        string columnName = gr_id + "_c" + counter.ToString();
                        if (list.Fields.ContainsField(strField))
                        {
                            SPField field = list.Fields.GetFieldByInternalName(strField);
                            string val = Request[columnName].ToString();
                            if (field.Required && val == "")
                            {
                                reqField = true;
                                output += "<action type='error100' sid='" + gr_id + "'><![CDATA[Field Required: " + field.Title + "]]></action>";
                                break;
                            }
                            else
                            {
                                if (!field.ReadOnlyField && (field.ShowInEditForm == null || field.ShowInEditForm.Value))
                                {
                                    if (val == "")
                                    {
                                        li[field.Id] = null;
                                    }
                                    else
                                    {
                                        switch (field.Type)
                                        {
                                            case SPFieldType.Calculated:
                                                break;
                                            case SPFieldType.User:
                                                if (field.TypeAsString == "UserMulti")
                                                {
                                                    string[] sUsers = val.Split('\n');
                                                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection();
                                                    for (int i = 0; i < sUsers.Length; i = i + 2)
                                                    {
                                                        int iGroup = 0;
                                                        if (int.TryParse(sUsers[i], out iGroup))
                                                        {
                                                            SPFieldUserValue uv = new SPFieldUserValue(web, sUsers[i] + ";#" + sUsers[i + 1]);
                                                            uvc.Add(uv);
                                                        }
                                                        else
                                                        {
                                                            SPUser u = web.AllUsers[sUsers[i]];
                                                            SPFieldUserValue uv = new SPFieldUserValue(web, u.ID + ";#" + u.Name);
                                                            uvc.Add(uv);
                                                        }
                                                    }
                                                    li[field.Id] = uvc;
                                                }
                                                else
                                                {
                                                    int iGroup = 0;
                                                    string[] sUsers = val.Split('\n');
                                                    if (sUsers.Length > 0)
                                                    {
                                                        if (int.TryParse(sUsers[0], out iGroup))
                                                        {
                                                            SPFieldUserValue uv = new SPFieldUserValue(web, sUsers[0] + ";#" + sUsers[1]);
                                                            li[field.Id] = uv;
                                                        }
                                                        else
                                                        {
                                                            SPUser u = web.AllUsers[sUsers[0]];
                                                            SPFieldUserValue uv = new SPFieldUserValue(web, u.ID + ";#" + u.Name);
                                                            li[field.Id] = uv;
                                                        }
                                                    }
                                                }
                                                break;
                                            case SPFieldType.Number:
                                                if (field.SchemaXml.Contains("Percentage=\"TRUE\""))
                                                {
                                                    try
                                                    {
                                                        double fval = double.Parse(val.Replace("%", "")) / 100;
                                                        val = fval.ToString();
                                                    }
                                                    catch { }
                                                }
                                                double fVal = 0;
                                                if (double.TryParse(val, out fVal))
                                                    li[field.Id] = fVal;
                                                else
                                                    li[field.Id] = null;
                                                break;
                                            case SPFieldType.Lookup:
                                                li[strField] = val.Replace("\n", ";#");
                                                break;
                                            case SPFieldType.Choice:
                                                if (val != "")
                                                    li[strField] = val.Replace(";#", "\n").Split('\n')[0];
                                                else
                                                    val = null;
                                                break;
                                            case SPFieldType.MultiChoice:
                                                string[] choices = val.Split('\n');
                                                val = ";#";
                                                foreach (string choice in choices)
                                                {
                                                    val += choice.Replace(";#", "\n").Split('\n')[0] + ";#";
                                                }
                                                li[strField] = val;
                                                break;
                                            case SPFieldType.URL:
                                                break;
                                            case SPFieldType.DateTime:
                                                DateTime dt = DateTime.Parse(val);
                                                li[strField] = dt;
                                                break;
                                            default:
                                                if (field.InternalName == "ContentType")
                                                {
                                                    li[strField] = val.Replace(";#", "\n").Split('\n')[0];
                                                }
                                                else
                                                {
                                                    switch (field.TypeAsString)
                                                    {
                                                        case "FilteredLookup":
                                                            li[strField] = val.Replace("\n", ";#");
                                                            break;
                                                        default:
                                                            li[strField] = val;
                                                            break;
                                                    }
                                                }
                                                break;
                                        };
                                    }
                                }
                            }
                        }
                        counter++;
                    }
                    curField = "";
                    if (!reqField)
                    {

                        li.Update();
                        arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID, new string[1] { null });
                        queueAllItems.Enqueue(li);
                        hshSaveGroups.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + ".1", gr_id);

                        gr_id = HttpUtility.UrlEncode(gr_id);

                        //if(added)
                        //    output += "<action type='update' sid='" + gr_id + "' tid='." + li.ParentList.ID + "." + li.ID + "'/>";
                        //else

                        output += "<action type='update' sid='" + gr_id + "' tid='" + gr_id + "'/>";
                    }
                }
            }
            catch (Exception ex)
            {
                gr_id = HttpUtility.UrlEncode(gr_id);
                if(curField != "")
                    output += "<action type='error100' sid='" + gr_id + "'><![CDATA[Field: " + curField + "<br>Error: " + ex.Message + "]]></action>";
                else
                    output += "<action type='error100' sid='" + gr_id + "'><![CDATA[" + ex.Message + "]]></action>";
            }
            
            
        }

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);

            try
            {
                Guid webGuid = new Guid();
                Guid siteGuid = new Guid();
                Guid listGuid = new Guid();
                SPWeb iWeb = null;
                SPSite iSite = null;
                SPList iList = null;

                if (Request["ids"] != null)
                {
                    Response.ContentType = "text/xml";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;

                    string[] ids = Request["ids"].Split(',');

                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(Request["columns"]);

                    strFields = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

                    foreach (string id in ids)
                    {
                        if (id != "")
                        {
                            string strWebId = "";
                            string strListId = "";
                            string strSiteId = "";
                            try
                            {
                                strWebId = Request[id + "_webid"].ToString();
                            }
                            catch { }
                            try
                            {
                                strListId = Request[id + "_listid"].ToString();
                            }
                            catch { }
                            try
                            {
                                strSiteId = Request[id + "_siteid"].ToString();
                            }
                            catch { }
                            if (strWebId != "" && strListId != "" && strSiteId != "")
                            {
                                try
                                {
                                    Guid wGuid = new Guid(strWebId);
                                    Guid lGuid = new Guid(strListId);
                                    Guid sGuid = new Guid(strSiteId);
                                    if (siteGuid != sGuid)
                                    {
                                        if (iWeb != null)
                                        {
                                            iWeb.Close();
                                            iWeb = null;
                                            iSite.Close();
                                        }
                                        iSite = new SPSite(sGuid);
                                        siteGuid = iSite.ID;
                                    }
                                    if (webGuid != wGuid)
                                    {
                                        if (iWeb != null)
                                        {
                                            iWeb.Close();
                                            iWeb = iSite.OpenWeb(wGuid);
                                        }
                                        else
                                            iWeb = iSite.OpenWeb(wGuid);
                                        webGuid = iWeb.ID;
                                    }
                                    if (listGuid != lGuid)
                                    {
                                        iList = iWeb.Lists[lGuid];
                                        listGuid = iList.ID;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    output += "<action type='error100'><![CDATA[Item: " + Request[id + "_title"].ToString() + " Message: " + ex.Message + "]]></action>";
                                }
                                processItem(id, iWeb, iList);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                output += "<action type='error500'><![CDATA[Message: " + ex.Message + ex.StackTrace + "]]></action>";
            }


        }
        protected override void outputXml()
        {
            XmlNode ndRows = docXml.SelectSingleNode("//rows");
            XmlNode ndHead = ndRows.SelectSingleNode("head");
            ndRows.RemoveChild(ndHead);
            docXml.RemoveChild(ndRows);
                
            XmlNode ndData = docXml.CreateNode(XmlNodeType.Element, "data", docXml.NamespaceURI);
            ndData.InnerXml = output;
            docXml.AppendChild(ndData);
            XmlNode ndAllData = docXml.CreateNode(XmlNodeType.Element, "action", docXml.NamespaceURI);
            XmlAttribute attrType = docXml.CreateAttribute("type");
            attrType.Value = "alldatareturned";
            ndAllData.Attributes.Append(attrType);
            ndAllData.AppendChild(ndRows);

            ndData.AppendChild(ndAllData);

            foreach (XmlNode ndRow in ndRows)
            {
                string id = ndRow.Attributes["id"].Value;
                if (hshSaveGroups.Contains(id))
                {
                    ndRow.Attributes["id"].Value = hshSaveGroups[id].ToString();
                }
            }

            //base.outputXml();
            data = docXml.OuterXml;
        }
    }
}