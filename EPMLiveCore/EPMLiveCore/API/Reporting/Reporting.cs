using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;

namespace EPMLiveCore.API
{
    internal class Reporting
    {
        public static void ProcessReportDataSources(SPWeb web, string FileList)
        {
            XmlDocument docFiles = new XmlDocument();
            docFiles.LoadXml("<Files/>");

            try
            {
                docFiles.LoadXml(FileList);
            }
            catch { }

            string ssrsurl = EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL");

            SSRS2006.ReportingService2006 SSRS = new SSRS2006.ReportingService2006();
            SSRS.Url = ssrsurl + "/ReportService2006.asmx";
            SSRS.UseDefaultCredentials = true;

            SPDocumentLibrary list = (SPDocumentLibrary)web.Lists["Report Library"];

            SPListItemCollection folders = list.GetItemsInFolder(list.DefaultView, list.RootFolder);

            SSRS2006.DataSourceReference dsr = new SSRS2006.DataSourceReference();
            dsr.Reference = web.Url + "/Report Library/Data Sources/EPMLiveReportDB.rsds";

            foreach(SPListItem li in folders)
            {
                processRDL(SSRS, web, li, dsr, list, docFiles);
            }
        }

        private static bool CanProcessFile(SPWeb web, SPListItem li, XmlDocument docFiles)
        {
            if(docFiles.FirstChild.ChildNodes.Count == 0)
                return true;

            string url = li.File.ServerRelativeUrl;

            if(web.ServerRelativeUrl != "/")
                url = url.Replace(web.ServerRelativeUrl, "").Substring(1);

            XmlNode nd = docFiles.SelectSingleNode("//File[@FullFile='" + url + "']");
            if(nd != null)
                return true;

            return false;

        }

        private static void processRDL(SSRS2006.ReportingService2006 SSRS, SPWeb web, SPListItem folder, SSRS2006.DataSourceReference dsr, SPDocumentLibrary list, XmlDocument docFiles)
        {
            foreach(SPListItem li in list.GetItemsInFolder(list.DefaultView, folder.Folder))
            {
                if(li.FileSystemObjectType == SPFileSystemObjectType.Folder)
                {
                    processRDL(SSRS, web, li, dsr, list, docFiles);
                }
                else
                {
                    if(CanProcessFile(web, li, docFiles))
                    {
                        try
                        {
                            SSRS2006.DataSource[] dsstl = SSRS.GetItemDataSources(web.Url + "/" + li.Url);
                            for(int i = 0; i < dsstl.Length; i++)
                            {
                                if(dsstl[i].Name == "EPMLiveReportDB")
                                {
                                    dsstl[i].Item = dsr;
                                }
                            }
                            SSRS.SetItemDataSources(web.Url + "/" + li.Url, dsstl);
                        }
                        catch { }
                    }
                }
            }

        }
    }
}
