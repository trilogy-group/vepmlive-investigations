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
using EPMLiveCore.Infrastructure.Logging;
using DebugTrace = System.Diagnostics.Trace;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

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

            AddWebs(web, mainNode);

            data = doc.OuterXml;
        }

        private void AddWebs(SPWeb web, XmlNode parentNode)
        {
            var newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);
            var canPublish = false;
            try
            {
                if (web.DoesUserHavePermissions(SPBasePermissions.ViewPages))
                {
                    var attributeLocked = doc.CreateAttribute("locked");
                    attributeLocked.Value = "1";
                    var attributeExpand = doc.CreateAttribute("open");
                    attributeExpand.Value = "1";
                    var attributeId = doc.CreateAttribute("id");
                    attributeId.Value = web.ServerRelativeUrl;

                    newNode.Attributes.Append(attributeLocked);
                    newNode.Attributes.Append(attributeExpand);
                    newNode.Attributes.Append(attributeId);
                    
                    if (Request["List"] == null)
                    {
                        ProcessUserData(newNode, web);
                        canPublish = true;
                    }
                    else
                    {
                        canPublish = ProcessDataList(web, newNode);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugTrace.TraceError("Exception swallowed: {0}", ex);
            }

            try
            {
                foreach (SPWeb additionalWeb in web.Webs)
                {
                    try
                    {
                        AddWebs(additionalWeb, newNode);
                    }
                    catch (Exception ex)
                    {
                        WriteTrace(Area.EPMLiveCore, 
                            Categories.EPMLiveCore.Event, 
                            TraceSeverity.Medium, 
                            ex.ToString());
                    }
                    finally
                    {
                        additionalWeb?.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugTrace.TraceError("Exception swallowed: {0}", ex);
            }

            if (newNode.SelectSingleNode("row") != null || canPublish)
            {
                parentNode.AppendChild(newNode);
            }
        }

        private bool ProcessDataList(SPWeb web, XmlNode newNode)
        {
            var canPublish = false;
            SPList list = null;
            try
            {
                list = web.Lists[HttpUtility.UrlDecode(Request["List"])];
            }
            catch (Exception ex)
            {
                DebugTrace.TraceError("Exception swallowed: {0}", ex);
            }

            if (list != null)
            {
                if (!list.Hidden)
                {
                    var gSettings = new GridGanttSettings(list);

                    if (gSettings.HideNewButton)
                    {
                        list = null;
                    }
                }
                else
                {
                    list = null;
                }
            }

            var newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
            if (list != null)
            {
                newCell.InnerText = list.Forms[PAGETYPE.PAGE_NEWFORM].ServerRelativeUrl;
                var attrName = doc.CreateAttribute("name");
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
                    canPublish = true;
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
                var attrName = doc.CreateAttribute("name");
                attrName.Value = "webid";
                newCell.Attributes.Append(attrName);
                newNode.AppendChild(newCell);
            }

            return canPublish;
        }

        private void ProcessUserData(XmlNode newNode, SPWeb web)
        {
            var userDataCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
            newNode.AppendChild(userDataCell);
            userDataCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
            userDataCell.InnerText = web.Title;
            newNode.AppendChild(userDataCell);
            userDataCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
            userDataCell.InnerText = web.ServerRelativeUrl;
            newNode.AppendChild(userDataCell);
        }
    }
}