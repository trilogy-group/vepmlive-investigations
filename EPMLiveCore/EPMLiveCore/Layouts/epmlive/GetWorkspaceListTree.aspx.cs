using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;
using static System.Diagnostics.Trace;

namespace EPMLiveCore
{
    public partial class GetWorkspaceListTree : LayoutsPageBase
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;
        private SPSite _unelevatedSite;
        private SPWeb _unelevatedWeb;
        private string _exec = string.Empty;
        private string _strSite = string.Empty;

        /***********************************************
        * Procedure: protected void Page_Load()
        * Purpose: Create header of xml file
        * Parameters In: object sender, EventArgs e
        * Parameters Out: void
        ***********************************************/
        protected void Page_Load(object sender, EventArgs e)
        {
            string exec = Request["executive"];
            string strSite = Request["site"];

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            if (exec == "true")
            {
                Guid siteid = SPContext.Current.Site.ID;
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite site = new SPSite(siteid))
                    {
                        SPWeb web = site.RootWeb;//No need to dispose
                        if (strSite == "false")
                        {
                            web = site.OpenWeb(SPContext.Current.Web.ID);
                        }

                        web.Site.CatchAccessDeniedException = false;

                        doc.LoadXml("<rows></rows>");

                        XmlNode mainNode = doc.ChildNodes[0];
                        XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "head", doc.NamespaceURI);
                        XmlNode ndSettings = doc.CreateNode(XmlNodeType.Element, "settings", doc.NamespaceURI);
                        XmlNode ndColwith = doc.CreateNode(XmlNodeType.Element, "colwidth", doc.NamespaceURI);
                        ndColwith.InnerText = "%";
                        ndSettings.AppendChild(ndColwith);
                        headNode.AppendChild(ndSettings);

                        mainNode.AppendChild(headNode);

                        XmlAttribute attrType = doc.CreateAttribute("type");
                        attrType.Value = "tree";
                        XmlAttribute attrWidth = doc.CreateAttribute("width");
                        attrWidth.Value = "100";
                        XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                        newNode.Attributes.Append(attrType);
                        newNode.Attributes.Append(attrWidth);
                        newNode.InnerText = "";

                        headNode.AppendChild(newNode);

                        addWebs(web, mainNode);

                        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "iso-8859-1", null);
                        doc.InsertBefore(xmlDeclaration, doc.DocumentElement);

                        data = doc.OuterXml;
                    }
                });
            }
            else
            {
                Guid siteid = SPContext.Current.Site.ID;
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite tSite = new SPSite(siteid))
                    {
                        AddMainNode(
                            tSite,
                            strSite,
                            string.Empty,
                            doc,
                            (web, mainNode) => addWebs(web, mainNode),
                            ref data,
                            document =>
                            {
                                var xmlDeclaration = document.CreateXmlDeclaration("1.0", "iso-8859-1", null);
                                document.InsertBefore(xmlDeclaration, doc.DocumentElement);
                            });
                    }
                });

            }
        }

        public static void AddMainNode(
            SPSite spSite,
            string site,
            string innerNodeText,
            XmlDocument xmlDocument,
            Action<SPWeb, XmlNode> AddWebsFunc,
            ref string data,
            Action<XmlDocument> insertDeclarationAction = null)
        {
            var web = spSite.RootWeb;
            if (string.Equals(site, "false", StringComparison.OrdinalIgnoreCase))
            {
                web = SPContext.Current.Web;
            }
            web.Site.CatchAccessDeniedException = false;

            xmlDocument.LoadXml("<rows></rows>");

            var mainNode = xmlDocument.ChildNodes[0];
            var headNode = xmlDocument.CreateNode(XmlNodeType.Element, "head", xmlDocument.NamespaceURI);
            var settings = xmlDocument.CreateNode(XmlNodeType.Element, "settings", xmlDocument.NamespaceURI);
            var colWidth = xmlDocument.CreateNode(XmlNodeType.Element, "colwidth", xmlDocument.NamespaceURI);
            colWidth.InnerText = "%";
            settings.AppendChild(colWidth);
            headNode.AppendChild(settings);

            mainNode.AppendChild(headNode);

            var attrType = xmlDocument.CreateAttribute("type");
            attrType.Value = "tree";
            var width = xmlDocument.CreateAttribute("width");
            width.Value = "100";
            var newNode = xmlDocument.CreateNode(XmlNodeType.Element, "column", xmlDocument.NamespaceURI);
            newNode.Attributes.Append(attrType);
            newNode.Attributes.Append(width);
            newNode.InnerText = innerNodeText;

            headNode.AppendChild(newNode);

            try
            {
                AddWebsFunc?.Invoke(web, mainNode);
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}",ex);
            }

            insertDeclarationAction?.Invoke(xmlDocument);

            data = xmlDocument.OuterXml;
        }

        /***********************************************
        * Procedure: private void addWebs()
        * Purpose: Build internal xml with sites and links
        * Parameters In: SPWeb web, XmlNode parentNode
        * Parameters Out: void
        ***********************************************/
        private List<XmlNode> addWebs(SPWeb web, XmlNode parentNode)
        {
            List<XmlNode> childNodeList = new List<XmlNode>();
            List<XmlNode> returnList = new List<XmlNode>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite tempSite = new SPSite(web.Site.Url))
                {
                    using (SPWeb tempWeb = tempSite.OpenWeb(web.ServerRelativeUrl))
                    {
                        // build new node
                        // ===============================================================
                        XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

                        XmlAttribute attrHasAccess = doc.CreateAttribute("hasAccess");
                        attrHasAccess.Value = tempWeb.DoesUserHavePermissions(Web.CurrentUser.LoginName, SPBasePermissions.ViewPages).ToString();
                        newNode.Attributes.Append(attrHasAccess);

                        XmlAttribute attrExpand = doc.CreateAttribute("open");
                        attrExpand.Value = "1";
                        newNode.Attributes.Append(attrExpand);

                        XmlAttribute attrLocked = doc.CreateAttribute("locked");
                        attrLocked.Value = "1";
                        newNode.Attributes.Append(attrLocked);

                        XmlAttribute attrId = doc.CreateAttribute("id");
                        attrId.Value = tempWeb.ServerRelativeUrl;
                        newNode.Attributes.Append(attrId);

                        XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);

                        newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                        XmlAttribute attrImage = doc.CreateAttribute("image");
                        attrImage.Value = "team.png";
                        newCell.Attributes.Append(attrImage);

                        if (tempWeb.ID == Web.ID)
                        {
                            newCell.InnerText = tempWeb.DoesUserHavePermissions(Web.CurrentUser.LoginName, SPBasePermissions.ViewPages) ?
                                " <a href='" + tempWeb.ServerRelativeUrl + "'><b>" + tempWeb.Title + " (you are here)</b></a>" : " <span style=\"color:gray\"><b>" + tempWeb.Title + " (you are here)</b></span>";
                        }
                        else
                        {
                            newCell.InnerText = tempWeb.DoesUserHavePermissions(Web.CurrentUser.LoginName, SPBasePermissions.ViewPages) ?
                                " <a href='" + tempWeb.ServerRelativeUrl + "'>" + tempWeb.Title + " </a>" : " <span style=\"color:gray\">" + tempWeb.Title + "</span>";
                        }

                        newNode.AppendChild(newCell);

                        foreach (SPWeb w in tempWeb.Webs)
                        {
                            try
                            {
                                childNodeList.AddRange(addWebs(w, newNode));
                            }
                            catch(Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                            finally { if (w != null) w.Dispose(); }

                        }

                        if (childNodeList.Count > 0)
                        {
                            foreach (XmlNode child in childNodeList)
                            {
                                newNode.AppendChild(child);
                            }

                            parentNode.AppendChild(newNode);
                        }
                        else if (tempWeb.ID == Web.ID)
                        {
                            parentNode.AppendChild(newNode);
                        }

                        // when not on leaf, all child nodes needs to be added to the tree
                        // to continue to the leaf level
                        if (tempWeb.Webs.Count > 0 && childNodeList.Count > 0)
                        {
                            returnList.Add(newNode);
                        }
                        // if we're on leaf node, only add if has access
                        else
                        {
                            if (tempWeb.DoesUserHavePermissions(Web.CurrentUser.LoginName, SPBasePermissions.ViewPages))
                            {
                                returnList.Add(newNode);
                            }
                        }
                    }
                }
            });

            return returnList;
        }

        private bool ValidateUserAccess(SPUser user, SPWeb web)
        {
            bool hasAccess = false;

            try
            {
                hasAccess = web.DoesUserHavePermissions(user.LoginName, SPBasePermissions.ViewPages);
            }
            catch (UnauthorizedAccessException x)
            {
                hasAccess = false;
            }

            return hasAccess;
        }

    }
}
