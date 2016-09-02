using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class getworkspacexml : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            
            doc.LoadXml("<rows></rows>");

            XmlNode mainNode = doc.ChildNodes[0];
            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "head", doc.NamespaceURI);
            mainNode.AppendChild(headNode);

            XmlAttribute attrType = doc.CreateAttribute("type");
            attrType.Value = "tree";
            XmlAttribute attrWidth = doc.CreateAttribute("width");
            attrWidth.Value = "250";
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
            newNode.Attributes.Append(attrType);
            newNode.Attributes.Append(attrWidth);
            newNode.InnerText = "Site Name";
            headNode.AppendChild(newNode);
            attrType = doc.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = doc.CreateAttribute("width");
            attrWidth.Value = "300";
            newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
            newNode.Attributes.Append(attrType);
            newNode.Attributes.Append(attrWidth);
            newNode.InnerText = "Site URL";
            headNode.AppendChild(newNode);

            addWebs(web, mainNode);

            data = doc.OuterXml;
        }

        private void addWebs(SPWeb web, XmlNode parentNode)
        {
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);
            bool canpub = false;
            try
            {
                if (web.DoesUserHavePermissions(SPBasePermissions.ViewPages))
                {

                    XmlAttribute attrLocked = doc.CreateAttribute("locked");
                    attrLocked.Value = "1";
                    XmlAttribute attrExpand = doc.CreateAttribute("open");
                    attrExpand.Value = "1";
                    XmlAttribute attrId = doc.CreateAttribute("id");
                    attrId.Value = web.ServerRelativeUrl;
                    
                    newNode.Attributes.Append(attrLocked);
                    newNode.Attributes.Append(attrExpand);
                    newNode.Attributes.Append(attrId);
                    

                    if (Request["List"] == null)
                    {
                        XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                        newNode.AppendChild(newCell);
                        newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                        newCell.InnerText = web.Title;
                        newNode.AppendChild(newCell);
                        newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                        newCell.InnerText = web.ServerRelativeUrl;
                        newNode.AppendChild(newCell);
                        canpub = true;
                    }
                    else
                    {
                        SPList list = null;
                        try
                        {
                            list = web.Lists[HttpUtility.UrlDecode(Request["List"])];
                        }
                        catch { }

                        if(list!=null)
                        {
                            if (!list.Hidden)
                            {
                                GridGanttSettings gSettings = new GridGanttSettings(list);

                                if(gSettings.HideNewButton)
                                {
                                    list = null;
                                }
                            }
                            else
                            {
                                list = null;
                            }
                        }

                        XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                        if (list != null)
                        {
                            newCell.InnerText = list.Forms[PAGETYPE.PAGE_NEWFORM].ServerRelativeUrl;
                            XmlAttribute attrName = doc.CreateAttribute("name");
                            attrName.Value = "NewItemURL";
                            newCell.Attributes.Append(attrName);
                            newNode.AppendChild(newCell);

                            newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            newCell.InnerText = "No";
                            attrName = doc.CreateAttribute("name");
                            attrName.Value = "CanPublish";
                            newCell.Attributes.Append(attrName);

                            if (list.DoesUserHavePermissions(SPBasePermissions.AddListItems))
                            {
                                newCell.InnerText = "Yes";
                                canpub = true;
                            }
                        }

                        newNode.AppendChild(newCell);
                        newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                        newCell.InnerText = web.Title;
                        newNode.AppendChild(newCell);
                        newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                        newCell.InnerText = web.ServerRelativeUrl;
                        newNode.AppendChild(newCell);

                        {
                            newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            newCell.InnerText = web.ID.ToString();
                            XmlAttribute attrName = doc.CreateAttribute("name");
                            attrName.Value = "webid";
                            newCell.Attributes.Append(attrName);
                            newNode.AppendChild(newCell);
                        }
                    }
                }
            }
            catch { }

            try
            {
                foreach (SPWeb w in web.Webs)
                {
                    addWebs(w, newNode);
                    w.Close();
                }
                
            }
            catch { }

            if (newNode.SelectSingleNode("row") != null || canpub)
                parentNode.AppendChild(newNode);
        }
    }
}