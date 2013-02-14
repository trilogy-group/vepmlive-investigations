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

namespace EPMLiveSynch
{
    public partial class GetListViews : System.Web.UI.Page
    {
        private SPWeb web;
        private XmlDocument doc = new XmlDocument();
        private XmlNode mainNode;
        private XmlNode headNode;
        protected string data;
        private string sIconFileName = "16doc.GIF";
        private string sViewIconFileName = "menuaddview.gif"; // "usage.gif";
        private string sTotalSettingsIconFileName = "admintitlegraphic.gif"; // "wizhtml16.gif";
        private string sGridGanttIconFileName = "ganttview.gif";  //"exitgrid.gif";
        private string sEPMLiveSynchedViews = "";
        private bool bHasSynchedItems = false;
        private char[] chrCRSeparator = new char[] { '\r' };
        private char[] chrCommaSeparator = new char[] { ',' };


        /***********************************************
        * Procedure: protected void Page_Load()
        * Purpose: Create header of xml file
        * Parameters In: object sender, EventArgs e
        * Parameters Out: void
        ***********************************************/
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPWeb web = SPContext.Current.Web)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Expires = -1;

                Response.ContentType = "text/xml";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                web.Site.CatchAccessDeniedException = false;

                try
                {
                    if (Request["ListId"] != null && Request["ListId"].ToString().Length > 0)
                    {
                        string sListId = Request["ListId"].ToString();

                        SPList lst = web.Lists[new Guid(sListId)];

                        if (lst != null)
                        {
                            doc.LoadXml("<rows></rows>");

                            mainNode = doc.ChildNodes[0];
                            headNode = doc.CreateNode(XmlNodeType.Element, "head", doc.NamespaceURI);
                            XmlNode ndSettings = doc.CreateNode(XmlNodeType.Element, "settings", doc.NamespaceURI);
                            XmlNode ndColwith = doc.CreateNode(XmlNodeType.Element, "colwidth", doc.NamespaceURI);
                            ndColwith.InnerText = "%";
                            ndSettings.AppendChild(ndColwith);
                            headNode.AppendChild(ndSettings);

                            mainNode.AppendChild(headNode);

                            XmlAttribute attrTypeEdit = doc.CreateAttribute("type");
                            attrTypeEdit.Value = "ch";
                            XmlAttribute attrWidthEdit = doc.CreateAttribute("width");
                            attrWidthEdit.Value = "7";
                            XmlAttribute attrAlignEdit = doc.CreateAttribute("align");
                            attrAlignEdit.Value = "center";
                            XmlNode newNodeEdit = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeEdit.Attributes.Append(attrTypeEdit);
                            newNodeEdit.Attributes.Append(attrWidthEdit);
                            newNodeEdit.Attributes.Append(attrAlignEdit);
                            newNodeEdit.InnerText = "#master_checkbox";

                            headNode.AppendChild(newNodeEdit);

                            XmlAttribute attrType = doc.CreateAttribute("type");
                            attrType.Value = "tree";
                            XmlAttribute attrWidth = doc.CreateAttribute("width");
                            attrWidth.Value = "91";
                            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNode.Attributes.Append(attrType);
                            newNode.Attributes.Append(attrWidth);
                            newNode.InnerText = "Views";

                            headNode.AppendChild(newNode);

                            if (web.Properties.ContainsKey("EPMLiveSynchedViews-" + sListId))
                            {
                                sEPMLiveSynchedViews = web.Properties["EPMLiveSynchedViews-" + sListId].ToString();
                                sEPMLiveSynchedViews = sEPMLiveSynchedViews.Replace("<br>", "\r");
                                if (sEPMLiveSynchedViews.Length > 0)
                                {
                                    bHasSynchedItems = true;
                                }
                            }

                            try
                            {
                                //XmlNode viewsNode = createViewsNode(lst, mainNode);
                                addViews(web, lst, mainNode);
                            }
                            catch { }
                        }
                        data = doc.OuterXml;
                    }
                }
                catch (Exception exc)
                {
                    data = exc.Message;
                }
            }
        }

        private XmlNode createViewsNode(SPList lst, XmlNode parentNode)
        {
            try
            {
                XmlNode listsNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

                XmlAttribute attrExpand = doc.CreateAttribute("open");
                attrExpand.Value = "1";
                listsNode.Attributes.Append(attrExpand);

                XmlAttribute attrId = doc.CreateAttribute("id");
                attrId.Value = lst.Title;
                listsNode.Attributes.Append(attrId);

                XmlNode ndSync = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                ndSync = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                listsNode.AppendChild(ndSync);
                if (!bHasSynchedItems)
                {
                    ndSync.InnerText = "1";
                }

                XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                XmlAttribute attrImage = doc.CreateAttribute("image");
                attrImage.Value = sIconFileName;
                newCell.Attributes.Append(attrImage);

                newCell.InnerText = " Views";
                listsNode.AppendChild(newCell);

                parentNode.AppendChild(listsNode);

                return listsNode;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        private void addViews(SPWeb web, SPList lst, XmlNode parentNode)
        {
            try
            {
                foreach (SPView v in lst.Views)
                {
                    try
                    {
                        if (v.Title != null && v.Title.Length != 0)
                        {
                            XmlNode newViewNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

                            XmlAttribute attrViewId = doc.CreateAttribute("id");
                            attrViewId.Value = v.ID.ToString();
                            newViewNode.Attributes.Append(attrViewId);

                            XmlNode ndViewSync = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            ndViewSync = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                            if (doesSynchedListRowContainSyncItem(v.ID.ToString()))
                            {
                                ndViewSync.InnerText = "1";
                            }
                            else if (!bHasSynchedItems)
                            {
                                ndViewSync.InnerText = "0";
                            }
                            else
                            {
                                ndViewSync.InnerText = "0";
                            }
                            newViewNode.AppendChild(ndViewSync);

                            XmlNode ndViewKey = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            ndViewKey = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            ndViewKey.InnerText = "|VIEW:" + v.ID.ToString();
                            XmlAttribute attrViewKey = doc.CreateAttribute("name");
                            attrViewKey.Value = "key";
                            ndViewKey.Attributes.Append(attrViewKey);
                            newViewNode.AppendChild(ndViewKey);

                            XmlNode newViewCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            newViewCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                            XmlAttribute attrViewImage = doc.CreateAttribute("image");
                            attrViewImage.Value = sViewIconFileName;
                            newViewCell.Attributes.Append(attrViewImage);

                            string sURLparams = System.Web.HttpUtility.UrlEncode("{") + lst.ID.ToString().ToUpper().Replace("-", "%2D") + System.Web.HttpUtility.UrlEncode("}") + "&View=" + System.Web.HttpUtility.UrlEncode("{") + v.ID.ToString().ToUpper().Replace("-", "%2D") + System.Web.HttpUtility.UrlEncode("}");
                            newViewCell.InnerText = " <a href=\"javascript:newWin('" + web.Url + "/_layouts/ViewEdit.aspx?List=" + sURLparams + "')\"  >" + v.Title + "</a>";
                            newViewNode.AppendChild(newViewCell);

                            parentNode.AppendChild(newViewNode);
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }

        private bool doesSynchedListRowContainSyncItem(string sSyncItem)
        {
            try
            {
                string[] arrSynchedViews = sEPMLiveSynchedViews.Split(chrCommaSeparator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string sSyncSettingItem in arrSynchedViews)
                {
                    if (sSyncSettingItem.Contains(sSyncItem))
                    {
                        return true;
                    }
                }
            }
            catch (Exception exc)
            {
                return false;
            }
            return false;
        }
    
    }
}