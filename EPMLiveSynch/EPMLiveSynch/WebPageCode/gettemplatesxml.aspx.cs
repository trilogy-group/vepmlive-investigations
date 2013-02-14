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
    public partial class GetTemplatesXML : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;
        private string EPMLiveSiteTemplateIDs = "";
        private string sSiteGuid = "";
        private string sMaxListSyncDate = "";

        /***********************************************
        * Procedure: protected void Page_Load()
        * Purpose: Create header of xml file
        * Parameters In: object sender, EventArgs e
        * Parameters Out: void
        ***********************************************/
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPSite site = SPContext.Current.Site)
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        if (Request["maxlistsyncdate"] != null) sMaxListSyncDate = Request["maxlistsyncdate"];
                        if (Request["ttype"] != null && Request["ttype"].ToString() == "tmpltcolonly")
                        {
                            EPMLiveSiteTemplateIDs = web.Properties["EPMLiveSiteTemplateIDs"];
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Expires = -1;

                            Response.ContentType = "text/xml";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;

                            web.Site.CatchAccessDeniedException = false;

                            doc.LoadXml("<rows></rows>");

                            XmlNode mainNode = doc.ChildNodes[0];
                            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "head", doc.NamespaceURI);

                            mainNode.AppendChild(headNode);

                            XmlAttribute attrType = doc.CreateAttribute("type");
                            attrType.Value = "tree";
                            XmlAttribute attrWidth = doc.CreateAttribute("width");
                            attrWidth.Value = "598";
                            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNode.Attributes.Append(attrType);
                            newNode.Attributes.Append(attrWidth);
                            newNode.InnerText = "Sites";

                            headNode.AppendChild(newNode);

                            try
                            {
                                addSynchedTemplatesColumn(web, mainNode);
                            }
                            catch { }
                            data = doc.OuterXml;

                        }
                        else if (Request["ttype"] != null && Request["ttype"].ToString() == "non")
                        {
                            EPMLiveSiteTemplateIDs = web.Properties["EPMLiveSiteTemplateIDs"];
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Expires = -1;

                            Response.ContentType = "text/xml";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;

                            web.Site.CatchAccessDeniedException = false;

                            doc.LoadXml("<rows></rows>");

                            XmlNode mainNode = doc.ChildNodes[0];
                            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "head", doc.NamespaceURI);

                            mainNode.AppendChild(headNode);

                            XmlAttribute attrType = doc.CreateAttribute("type");
                            attrType.Value = "tree";
                            XmlAttribute attrWidth = doc.CreateAttribute("width");
                            attrWidth.Value = "298";
                            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNode.Attributes.Append(attrType);
                            newNode.Attributes.Append(attrWidth);
                            newNode.InnerText = "Sites";

                            headNode.AppendChild(newNode);

                            try
                            {
                                addNonSynchedTemplates(web, mainNode);
                            }
                            catch { }
                            data = doc.OuterXml;

                        }
                        else
                        {
                            EPMLiveSiteTemplateIDs = web.Properties["EPMLiveSiteTemplateIDs"];
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Expires = -1;

                            Response.ContentType = "text/xml";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;

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
                            attrWidth.Value = "25";
                            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNode.Attributes.Append(attrType);
                            newNode.Attributes.Append(attrWidth);
                            newNode.InnerText = "Sites";

                            headNode.AppendChild(newNode);

                            XmlAttribute attrTypeEdit = doc.CreateAttribute("type");
                            attrTypeEdit.Value = "ro";
                            XmlAttribute attrWidthEdit = doc.CreateAttribute("width");
                            attrWidthEdit.Value = "12";
                            XmlAttribute attrEditTemplateAlign = doc.CreateAttribute("align");
                            attrEditTemplateAlign.Value = "center";
                            XmlNode newNodeEdit = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeEdit.Attributes.Append(attrTypeEdit);
                            newNodeEdit.Attributes.Append(attrWidthEdit);
                            newNodeEdit.Attributes.Append(attrEditTemplateAlign);
                            newNodeEdit.InnerText = "Edit";

                            headNode.AppendChild(newNodeEdit);

                            XmlAttribute attrTypeSave = doc.CreateAttribute("type");
                            attrTypeSave.Value = "ro";
                            XmlAttribute attrWidthSave = doc.CreateAttribute("width");
                            attrWidthSave.Value = "12";
                            XmlAttribute attrSaveTemplateAlign = doc.CreateAttribute("align");
                            attrSaveTemplateAlign.Value = "center";
                            XmlNode newNodeSave = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeSave.Attributes.Append(attrTypeSave);
                            newNodeSave.Attributes.Append(attrWidthSave);
                            newNodeSave.Attributes.Append(attrSaveTemplateAlign);
                            newNodeSave.InnerText = "Save";

                            headNode.AppendChild(newNodeSave);

                            XmlAttribute attrTypeRename = doc.CreateAttribute("type");
                            attrTypeRename.Value = "ro";
                            XmlAttribute attrWidthRename = doc.CreateAttribute("width");
                            attrWidthRename.Value = "12";
                            XmlAttribute attrRenameTemplateAlign = doc.CreateAttribute("align");
                            attrRenameTemplateAlign.Value = "center";
                            XmlNode newNodeRename = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeRename.Attributes.Append(attrTypeRename);
                            newNodeRename.Attributes.Append(attrWidthRename);
                            newNodeRename.Attributes.Append(attrRenameTemplateAlign);
                            newNodeRename.InnerText = "Rename";

                            headNode.AppendChild(newNodeRename);

                            XmlAttribute attrTypeDelete = doc.CreateAttribute("type");
                            attrTypeDelete.Value = "ro";
                            XmlAttribute attrWidthDelete = doc.CreateAttribute("width");
                            attrWidthDelete.Value = "12";
                            XmlAttribute attrRemoveTemplateAlign = doc.CreateAttribute("align");
                            attrRemoveTemplateAlign.Value = "center";
                            XmlNode newNodeDelete = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeDelete.Attributes.Append(attrTypeDelete);
                            newNodeDelete.Attributes.Append(attrWidthDelete);
                            newNodeDelete.Attributes.Append(attrRemoveTemplateAlign);
                            newNodeDelete.InnerText = "Remove";

                            headNode.AppendChild(newNodeDelete);

                            //XmlAttribute attrTypeSync = doc.CreateAttribute("type");
                            //attrTypeSync.Value = "ro";
                            //XmlAttribute attrWidthSync = doc.CreateAttribute("width");
                            //attrWidthSync.Value = "7";
                            //XmlAttribute attrLastSaveTemplateAlign = doc.CreateAttribute("align");
                            //attrLastSaveTemplateAlign.Value = "center";
                            //XmlNode newNodeSync = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            //newNodeSync.Attributes.Append(attrTypeSync);
                            //newNodeSync.Attributes.Append(attrWidthSync);
                            //newNodeSync.Attributes.Append(attrLastSaveTemplateAlign);
                            //newNodeSync.InnerText = "Synchronize";

                            //headNode.AppendChild(newNodeSync);

                            XmlAttribute attrTypeSaveStatus = doc.CreateAttribute("type");
                            attrTypeSaveStatus.Value = "ro";
                            XmlAttribute attrWidthSaveStatus = doc.CreateAttribute("width");
                            attrWidthSaveStatus.Value = "12";
                            XmlNode newNodeSaveStatus = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeSaveStatus.Attributes.Append(attrTypeSaveStatus);
                            newNodeSaveStatus.Attributes.Append(attrWidthSaveStatus);
                            newNodeSaveStatus.InnerText = "Save Status";

                            headNode.AppendChild(newNodeSaveStatus);

                            XmlAttribute attrTypeLastSave = doc.CreateAttribute("type");
                            attrTypeLastSave.Value = "ro";
                            XmlAttribute attrWidthLastSave = doc.CreateAttribute("width");
                            attrWidthLastSave.Value = "15";
                            XmlNode newNodeLastSave = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            newNodeLastSave.Attributes.Append(attrTypeLastSave);
                            newNodeLastSave.Attributes.Append(attrWidthLastSave);
                            newNodeLastSave.InnerText = "Last Saved";

                            headNode.AppendChild(newNodeLastSave);

                            //XmlAttribute attrTypeSyncStatus = doc.CreateAttribute("type");
                            //attrTypeSyncStatus.Value = "ro";
                            //XmlAttribute attrWidthSyncStatus = doc.CreateAttribute("width");
                            //attrWidthSyncStatus.Value = "5";
                            //XmlNode newNodeSyncStatus = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            //newNodeSyncStatus.Attributes.Append(attrTypeSyncStatus);
                            //newNodeSyncStatus.Attributes.Append(attrWidthSyncStatus);
                            //newNodeSyncStatus.InnerText = "Sync Status";

                            //headNode.AppendChild(newNodeSyncStatus);

                            //XmlAttribute attrTypeResults = doc.CreateAttribute("type");
                            //attrTypeResults.Value = "ro";
                            //XmlAttribute attrWidthResults = doc.CreateAttribute("width");
                            //attrWidthResults.Value = "20";
                            //XmlNode newNodeResults = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                            //newNodeResults.Attributes.Append(attrTypeResults);
                            //newNodeResults.Attributes.Append(attrWidthResults);
                            //newNodeResults.InnerText = "Sync Results";

                            //headNode.AppendChild(newNodeResults);

                            try
                            {
                                addWebs(web, mainNode);
                            }
                            catch { }
                            data = doc.OuterXml;
                        }
                    }
                    catch (Exception exc)
                    {
                        data = exc.Message;
                    }
                    finally
                    {
                        GC.Collect();
                        web.Close();
                    }
                }
            }
        }

        /***********************************************
        * Procedure: private void addWebs()
        * Purpose: Build internal xml with sites and links
        * Parameters In: SPWeb web, XmlNode parentNode
        * Parameters Out: void
        ***********************************************/
        private bool addWebs(SPWeb web, XmlNode parentNode)
        {
            bool bIsTemplate = false;
            bool hasChildTemplate = false;
            string sIconFileName = "STSICON.GIF";
           
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

            try
            {
                foreach (SPWeb w in web.Webs)
                {
                    try
                    {
                        if (w.DoesUserHavePermissions(SPBasePermissions.ViewPages))
                        {
                            hasChildTemplate = addWebs(w, newNode) | hasChildTemplate;
                        }
                    }
                    catch { }
                    w.Close();
                    w.Dispose();
                }

            }
            catch { }

            try
            {
                if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                {
                    string sIDs = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                    if (sIDs != null && sIDs.Contains(web.ID.ToString()))
                    {
                        bIsTemplate = true;
                        sIconFileName = "ICODCT.GIF";
                    }
                }

                if (bIsTemplate | hasChildTemplate)
                {
                    sSiteGuid = web.Site.ID.ToString();

                    XmlAttribute attrExpand = doc.CreateAttribute("open");
                    attrExpand.Value = "1";
                    newNode.Attributes.Append(attrExpand);

                    XmlAttribute attrLocked = doc.CreateAttribute("locked");
                    attrLocked.Value = "1";

                    XmlAttribute attrId = doc.CreateAttribute("id");
                    attrId.Value = web.ServerRelativeUrl;

                    newNode.Attributes.Append(attrLocked);
                    newNode.Attributes.Append(attrId);

                    XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                    XmlAttribute attrImage = doc.CreateAttribute("image");
                    attrImage.Value = sIconFileName;
                    newCell.Attributes.Append(attrImage);

                    newCell.InnerText = " " + web.Title + "</a>";
                    newNode.AppendChild(newCell);

                    XmlNode ndEditTemplate = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndEditTemplate = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    if (bIsTemplate)
                    {
                        ndEditTemplate.InnerText = " <a href='" + web.Url + "' target='_blank'>Edit</a>";
                    }
                    else
                    {
                        ndEditTemplate.InnerText = " ";
                    }
                    newNode.AppendChild(ndEditTemplate);

                    XmlNode ndSaveTemplate = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndSaveTemplate = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    if (bIsTemplate)
                    {
                        ndSaveTemplate.InnerText = " <a href='#' onclick=\"showSaveTemplateForm('" + web.Url + "');return false\">Save</a>";
                    }
                    else
                    {
                        ndSaveTemplate.InnerText = " ";
                    }
                    newNode.AppendChild(ndSaveTemplate);

                    XmlNode ndRenameTemplate = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndRenameTemplate = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    if (bIsTemplate)
                    {
                        ndRenameTemplate.InnerText = " <a href='#' onclick=\"showRenameTemplateForm('" + web.Title + "','" + web.Url + "');return false\">Rename</a>";
                    }
                    else
                    {
                        ndRenameTemplate.InnerText = " ";
                    }
                    newNode.AppendChild(ndRenameTemplate);

                    XmlNode ndDeleteTemplate = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndDeleteTemplate = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    if (bIsTemplate)
                    {
                        ndDeleteTemplate.InnerText = " <a href='#' onclick=\"delTemplate('" + web.ServerRelativeUrl + "');return false\">Remove</a>";
                    }
                    else
                    {
                        ndDeleteTemplate.InnerText = " ";
                    }
                    newNode.AppendChild(ndDeleteTemplate);

                    //XmlNode ndSyncTemplate = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    //ndSyncTemplate = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    //if (bIsTemplate)
                    //{
                    //    ndSyncTemplate.InnerText = " <a href='#' onclick=\"syncTemplate('" + web.ServerRelativeUrl + "');return false\">Synchronize</a>";
                    //}
                    //else
                    //{
                    //    ndSyncTemplate.InnerText = " ";
                    //}
                    //newNode.AppendChild(ndSyncTemplate);

                    DateTime dtTimeLastModified = new DateTime (1900,1,1);
                    DateTime dtMaxListSyncDate;
                    DateTime.TryParse(sMaxListSyncDate, out dtMaxListSyncDate);

                    XmlNode ndLastSaveTemplate = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndLastSaveTemplate = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    XmlAttribute attrLastSaveTemplateAlign = doc.CreateAttribute("align");
                    attrLastSaveTemplateAlign.Value = "center";
                    ndLastSaveTemplate.Attributes.Append(attrLastSaveTemplateAlign);
                    if (bIsTemplate)
                    {
                        //SPWebTemplateCollection oWebTmpltCol = web.Site.RootWeb.GetAvailableWebTemplates((uint)web.Locale.LCID);
                        try
                        {
                            //SPWebTemplate oWebTmplt = oWebTmpltCol[web.Title];
                            //string sFileName = oWebTmplt.Name;

                            SPFile fTmplt = web.Site.RootWeb.GetFile(web.Site.RootWeb.Site.Url + "/_catalogs/solutions/" + web.Title + ".wsp");
                            if (fTmplt != null && fTmplt.Exists)
                            {
                                dtTimeLastModified = fTmplt.TimeLastModified.ToLocalTime();
                                ndLastSaveTemplate.InnerText = fTmplt.TimeLastModified.ToLocalTime().ToString();
                            }
                            else
                            {
                                ndLastSaveTemplate.InnerText = " ";
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        ndLastSaveTemplate.InnerText = " ";
                    }

                    XmlNode ndSaveStatus = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndSaveStatus = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    XmlAttribute attrSaveStatusAlign = doc.CreateAttribute("align");
                    attrSaveStatusAlign.Value = "center";
                    ndSaveStatus.Attributes.Append(attrSaveStatusAlign);
                    if (bIsTemplate)
                    {
                        if (dtTimeLastModified != null)
                        {
                            try
                            {
                                XmlAttribute attrSaveStatusTooltip = doc.CreateAttribute("title");
                                if (DateTime.Compare(dtTimeLastModified, dtMaxListSyncDate) > 0 && dtMaxListSyncDate != DateTime.MinValue)
                                {
                                    ndSaveStatus.InnerText = "<img src=\"/_layouts/images/green.gif\" alt=\"\" title=\"Based on the date/time of the last Enterprise List Synchronization, this template is up to date.\" >";
                                    attrSaveStatusTooltip.Value = "Based on the date/time of the last Enterprise List Synchronization, this template is up to date.";
                                }
                                else
                                {
                                    ndSaveStatus.InnerText = "<img src=\"/_layouts/images/yellow.gif\" alt=\"\" title=\"Based on the date/time of the last Enterprise List Synchronization, it is possible that this template is outdated and a synchronization is recommended.\" >";
                                    attrSaveStatusTooltip.Value = "Based on the date/time of the last Enterprise List Synchronization, it is possible that this template is outdated and a synchronization is recommended.";
                                }
                                ndSaveStatus.Attributes.Append(attrSaveStatusTooltip);
                            }
                            catch (Exception ex) 
                            {
                                ndSaveStatus.InnerText = " ";
                            }
                        }
                    }
                    else
                    {
                        ndSaveStatus.InnerText = " ";
                    }

                    newNode.AppendChild(ndSaveStatus);
                    newNode.AppendChild(ndLastSaveTemplate);

                    string sLastResults = "";
                    XmlNode ndLastResults = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    ndLastResults = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    if (bIsTemplate)
                    {
                        LogHelper logHlpr = new LogHelper();
                        logHlpr.CurrWeb = web;
                        logHlpr.Action = "synchtemplate";
                        string sServerRelativeUrl = "";
                        if (web.ServerRelativeUrl.Trim() == "/")
                        {
                            sServerRelativeUrl = "";
                        }
                        else
                        {
                            sServerRelativeUrl = web.ServerRelativeUrl;
                        }
                        logHlpr.Source = sSiteGuid + sServerRelativeUrl;
                        sLastResults = logHlpr.GetLastResult;
                        ndLastResults.InnerText = " <a href='" + SPContext.Current.Web.Url + "/_layouts/epmlive/viewlogentry.aspx?logaction=synchtemplate&logsource=" + sSiteGuid + web.ServerRelativeUrl + "' >" + sLastResults + "</a>";
                    }
                    else
                    {
                        ndLastResults.InnerText = " ";
                    }

                    //XmlNode ndSyncStatus = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    //ndSyncStatus = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                    //XmlAttribute attrSyncStatusAlign = doc.CreateAttribute("align");
                    //attrSyncStatusAlign.Value = "center";
                    //ndSyncStatus.Attributes.Append(attrSyncStatusAlign);
                    //string sImg;
                    //if (bIsTemplate)
                    //{
                    //    if (sLastResults.Contains("Success") || sLastResults == "")
                    //    {
                    //        sImg = "<img src=\"/_layouts/images/green.gif\" alt=\"\" >";
                    //    }
                    //    else
                    //    {
                    //        sImg = "<img src=\"/_layouts/images/yellow.gif\" alt=\"\" >";
                    //    }
                    //    ndSyncStatus.InnerText = sImg;
                    //}
                    //else
                    //{
                    //    ndSyncStatus.InnerText = " ";
                    //}
                    //newNode.AppendChild(ndSyncStatus);
                    //newNode.AppendChild(ndLastResults);

                    parentNode.AppendChild(newNode);
                }
            }
            catch { }

            return bIsTemplate | hasChildTemplate;
        }

        private bool addNonSynchedTemplates(SPWeb web, XmlNode parentNode)
        {
            bool bIsNonTemplate = false;
            bool hasNonTemplateChildSites = false;
            string sIconFileName = "STSICON.GIF";

            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

            try
            {
                foreach (SPWeb w in web.Webs)
                {
                    try
                    {
                        if (w.DoesUserHavePermissions(SPBasePermissions.ViewPages))
                        {
                            hasNonTemplateChildSites = addNonSynchedTemplates(w, newNode) | hasNonTemplateChildSites;
                        }
                    }
                    catch { }
                    w.Close();
                    w.Dispose();
                }

            }
            catch { }

            try
            {
                if (!web.Properties.ContainsKey("EPMLiveTemplateID"))
                {
                    bIsNonTemplate = true;
                }
                else
                {
                    string sIDs = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                    if (sIDs != null)
                    {
                        if (!sIDs.Contains(web.ID.ToString()))
                        {
                            bIsNonTemplate = true;
                        }
                    }
                    else
                    {
                        bIsNonTemplate = true;
                    }
                }


                if (bIsNonTemplate | hasNonTemplateChildSites)
                {
                    XmlAttribute attrExpand = doc.CreateAttribute("open");
                    attrExpand.Value = "1";
                    newNode.Attributes.Append(attrExpand);

                    XmlAttribute attrLocked = doc.CreateAttribute("locked");
                    attrLocked.Value = "1";

                    XmlAttribute attrId = doc.CreateAttribute("id");
                    attrId.Value = web.ID.ToString();

                    newNode.Attributes.Append(attrLocked);
                    newNode.Attributes.Append(attrId);

                    XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                    XmlAttribute attrImage = doc.CreateAttribute("image");
                    attrImage.Value = sIconFileName;
                    newCell.Attributes.Append(attrImage);

                    newCell.InnerText = " " + web.Title + "</a>";
                    newNode.AppendChild(newCell);

                    parentNode.AppendChild(newNode);
                }
            }
            catch { }

            return bIsNonTemplate | hasNonTemplateChildSites;
        }

        private bool addSynchedTemplatesColumn(SPWeb web, XmlNode parentNode)
        {
            bool bIsTemplate = false;
            string sEPMLiveTemplateID = "";
            bool hasChildTemplate = false;
            string sIconFileName = "STSICON.GIF";

            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

            try
            {
                foreach (SPWeb w in web.Webs)
                {
                    try
                    {
                        if (w.DoesUserHavePermissions(SPBasePermissions.ViewPages))
                        {
                            hasChildTemplate = addSynchedTemplatesColumn(w, newNode) | hasChildTemplate;
                        }
                    }
                    catch { }
                    w.Close();
                    w.Dispose();
                }

            }
            catch { }

            try
            {
                if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                {
                    sEPMLiveTemplateID = web.Properties["EPMLiveTemplateID"].ToString();
                    string sIDs = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                    if (sIDs != null && sIDs.Contains(web.ID.ToString()))
                    {
                        bIsTemplate = true;
                        sIconFileName = "ICODCT.GIF";
                    }
                }

                if (bIsTemplate | hasChildTemplate)
                {
                    XmlAttribute attrExpand = doc.CreateAttribute("open");
                    attrExpand.Value = "1";
                    newNode.Attributes.Append(attrExpand);

                    XmlAttribute attrLocked = doc.CreateAttribute("locked");
                    attrLocked.Value = "1";

                    XmlAttribute attrId = doc.CreateAttribute("id");
                    if (bIsTemplate)
                    {
                        attrId.Value = sEPMLiveTemplateID;
                    }
                    else
                    {
                        attrId.Value = "---" + web.Title + "---";
                    }

                    newNode.Attributes.Append(attrLocked);
                    newNode.Attributes.Append(attrId);

                    XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                    newCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);

                    XmlAttribute attrImage = doc.CreateAttribute("image");
                    attrImage.Value = sIconFileName;
                    newCell.Attributes.Append(attrImage);

                    newCell.InnerText = " " + web.Title + "</a>";
                    newNode.AppendChild(newCell);

                    parentNode.AppendChild(newNode);
                }
            }
            catch { }

            return bIsTemplate | hasChildTemplate;
        }

        //private DateTime getTemplateLastSavedDate(SPWeb web)
        //{
        //    SPWebTemplateCollection oWebTmpltCol = web.GetAvailableWebTemplates((uint)web.Locale.LCID);
        //    try
        //    {
        //        SPWebTemplate oWebTmplt = oWebTmpltCol[web.Title];
        //        string sFileName = oWebTmplt.Name;

        //        using (SPSite site = SPContext.Current.Site)
        //        {
        //            using (SPWeb rootWeb = site.RootWeb)
        //            {
        //                //SPSecurity.RunWithElevatedPrivileges(delegate()
        //                //{
        //                //    SPFile fTmplt = rootWeb.GetFile(rootWeb.Site.Url + "/_catalogs/wt/" + sFileName);
        //                //    if (fTmplt != null && fTmplt.Exists)
        //                //    {
        //                //        return fTmplt.TimeLastModified;
        //                //    }
        //                //});
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }
}