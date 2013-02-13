/**************************************************
***************************************************
* Class: Public Class getworkspacexml{}
* Purpose: Class that creates XML for 
*   heirachial tree webpart.
* Created By: Johnny Bayard & Jason Hughes
* Date Created: October 21, 2008
* Date Revised: 
***************************************************
***************************************************/
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

namespace EPMLiveWebparts
{
    public partial class getworkspacelist : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;

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
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(siteid))
                    {
                        SPWeb web = site.RootWeb;
                        if (strSite == "false")
                        {
                            web = SPContext.Current.Web;
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
                        newNode.InnerText = "Sites";

                        headNode.AppendChild(newNode);

                        addWebs(web, mainNode);

                        data = doc.OuterXml;
                    }
                });
            }
            else
            {
                SPSite site = SPContext.Current.Site;
                
                SPWeb web = site.RootWeb;
                if (strSite == "false")
                    web = SPContext.Current.Web;
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
                newNode.InnerText = "Sites";

                headNode.AppendChild(newNode);

                try
                {
                    addWebs(web, mainNode);
                }
                catch { }
                data = doc.OuterXml;

            }
        }

        /***********************************************
        * Procedure: private void addWebs()
        * Purpose: Build internal xml with sites and links
        * Parameters In: SPWeb web, XmlNode parentNode
        * Parameters Out: void
        ***********************************************/
        private void addWebs(SPWeb web, XmlNode parentNode)
        {
           
                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);
               
                try
                {

                    SPWeb curWeb = SPContext.Current.Web;
                    {

                        //if (web.Title != "Projects")
                        //{
                        XmlAttribute attrExpand = doc.CreateAttribute("open");
                        attrExpand.Value = "1";
                        newNode.Attributes.Append(attrExpand);

                        //}

                        XmlAttribute attrLocked = doc.CreateAttribute("locked");
                        attrLocked.Value = "1";

                        XmlAttribute attrId = doc.CreateAttribute("id");
                        attrId.Value = web.ServerRelativeUrl;

                        newNode.Attributes.Append(attrLocked);
                        newNode.Attributes.Append(attrId);


                        XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);

                        newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                        if (curWeb.Url == web.Url)
                        {
                            XmlAttribute attrImage = doc.CreateAttribute("image");
                            attrImage.Value = "STSICON.GIF";
                            newCell.Attributes.Append(attrImage);

                            XmlAttribute attrbgColor = doc.CreateAttribute("bgColor");
                            attrbgColor.Value = "beige";
                            newNode.Attributes.Append(attrbgColor);

                        }
                        else
                        {
                            XmlAttribute attrImage = doc.CreateAttribute("image");
                            attrImage.Value = "STSICON.GIF";
                            newCell.Attributes.Append(attrImage);
                        }

                        newCell.InnerText = " <a href='" + web.ServerRelativeUrl + "'>" + web.Title + "</a>";
                        newNode.AppendChild(newCell);

                    }         
                }
                catch { }

                try
                {
                
                        foreach (SPWeb w in web.Webs)
                        {
                            try
                            {
                                if(w.DoesUserHavePermissions(SPBasePermissions.ViewPages))
                                {
                                    addWebs(w, newNode);
                                }
                            }
                            catch { }
                            w.Close();
                        }
                   
                }
                catch { }

                parentNode.AppendChild(newNode);
            
        }
            
             
    }
}