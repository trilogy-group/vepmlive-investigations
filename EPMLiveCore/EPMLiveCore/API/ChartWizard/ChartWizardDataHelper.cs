using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;
using System.Data;
using EPMLiveCore.ReportingProxy;

namespace EPMLiveCore.API
{
    internal sealed class ChartWizardDataHelper
    {
        public static string GetListsAndViewsGridData(string xml, SPWeb oWeb)
        {
            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Grid><Body><B></B></Body></Grid>");

            XmlNode ndBody = docOut.FirstChild.SelectSingleNode("//B");

            try
            {
                DataTable dtMappedLists = GetMappedLists();

                foreach (DataRow r in dtMappedLists.Rows)
                {
                    string sListName = r["ListName"].ToString(); 
                    string sListId = r["RPTListId"].ToString();

                    SPList list = null;
                    
                    try
                    {
                        list = oWeb.Lists[new Guid(sListId)];
                    }
                    catch {}

                    if (list != null)
                    {
                        XmlNode ndNewList = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                        XmlAttribute nattr = docOut.CreateAttribute("NoColorState");
                        nattr.Value = "1";
                        ndNewList.Attributes.Append(nattr);

                        XmlAttribute aTitle = docOut.CreateAttribute("Title");
                        aTitle.Value = list.Title;
                        ndNewList.Attributes.Append(aTitle);

                        XmlAttribute aExp = docOut.CreateAttribute("Expanded");
                        aExp.Value = "0";
                        ndNewList.Attributes.Append(aExp);

                        XmlAttribute aCanFocus = docOut.CreateAttribute("CanFocus");
                        aCanFocus.Value = "0";
                        ndNewList.Attributes.Append(aCanFocus);

                        XmlAttribute aGuid = docOut.CreateAttribute("Guid");
                        aGuid.Value = list.ID.ToString();
                        ndNewList.Attributes.Append(aGuid);

                        foreach (SPView v in list.Views)
                        {
                            if (v.Hidden)
                            {
                                continue;
                            }

                            XmlNode ndNewView = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                            XmlAttribute viewTitle = docOut.CreateAttribute("Title");
                            viewTitle.Value = v.Title;
                            ndNewView.Attributes.Append(viewTitle);

                            XmlAttribute viewGuid = docOut.CreateAttribute("Guid");
                            viewGuid.Value = v.ID.ToString();
                            ndNewView.Attributes.Append(viewGuid);

                            XmlAttribute parentListTitle = docOut.CreateAttribute("ParentListTitle");
                            parentListTitle.Value = list.Title;
                            ndNewView.Attributes.Append(parentListTitle);

                            XmlAttribute parentListGuid = docOut.CreateAttribute("ParentListGuid");
                            parentListGuid.Value = list.ID.ToString();
                            ndNewView.Attributes.Append(parentListGuid);

                            XmlAttribute viewQuery = docOut.CreateAttribute("Query");
                            viewQuery.Value = v.Query;
                            ndNewView.Attributes.Append(viewQuery);

                            ndNewList.AppendChild(ndNewView);
                        }

                        ndBody.AppendChild(ndNewList);
                    }
                }
            }
            catch { }

            return docOut.OuterXml;
        }

        public static string GetListsAndViewsGridLayout(string xml, SPWeb oWeb)
        {
            return Properties.Resources.ChartWizardDataSourceGridLayout;
        }

        private static DataTable GetMappedLists()
        {
            DataTable result = new DataTable();
            QueryExecutor qExec = new QueryExecutor(SPContext.Current.Web);
            string sql = @"SELECT ListName, RPTListId FROM RPTList WHERE TableName IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES)";
            result = qExec.ExecuteReportingDBQuery(sql, new Dictionary<string, object>());
            return result;
        }
    }
}
