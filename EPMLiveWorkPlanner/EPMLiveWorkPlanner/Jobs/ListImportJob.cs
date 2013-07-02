using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.SharePoint;
using System.Xml;
using System.Data;
using System.Collections;

namespace EPMLiveWorkPlanner
{
    public class ListImportJob : EPMLiveCore.API.BaseJob
    {
        private static string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }

        public void execute(SPSite osite, SPWeb oweb, string data)
        {

            try
            {
                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml(data);

                XmlAttribute attr = docNew.CreateAttribute("UIDColumn");
                attr.Value = "ID";
                docNew.FirstChild.Attributes.Append(attr);

                attr = docNew.CreateAttribute("ID");
                attr.Value = base.ItemID.ToString();
                docNew.FirstChild.Attributes.Append(attr);

                attr = docNew.CreateAttribute("Planner");
                attr.Value = base.key;
                docNew.FirstChild.Attributes.Append(attr);

                bool bAttachedItemsOnly = true;
                Hashtable hshMapping = new Hashtable();
                string sID = base.ItemID.ToString();
                string sPlanner = "";
                string sList = "";
                try
                {
                    sList = docNew.FirstChild.Attributes["List"].Value;
                }
                catch { }
                try
                {
                    sPlanner = base.key;
                }
                catch { }

                try
                {
                    bAttachedItemsOnly = bool.Parse(docNew.FirstChild.Attributes["AttachedItemsOnly"].Value);
                }
                catch { }
                try
                {
                    XmlNode ndColumns = docNew.FirstChild.SelectSingleNode("Columns");
                    foreach (XmlNode ndField in ndColumns.SelectNodes("Column"))
                    {
                        string ListField = getAttribute(ndField, "ListField");
                        string PlannerField = getAttribute(ndField, "PlannerField");

                        if (ListField != "" && PlannerField != "")
                        {
                            if (!hshMapping.ContainsKey(ListField) && !hshMapping.ContainsValue(PlannerField))
                            {
                                hshMapping.Add(ListField, PlannerField);
                            }
                        }
                    }
                }
                catch { }

                if (sPlanner == "")
                {
                    bErrors = true;
                    sErrors = "No Planner Specified";
                }
                else if (sID == "")
                {
                    bErrors = true;
                    sErrors = "No ID Specified";
                }
                else if (sList == "")
                {
                    bErrors = true;
                    sErrors = "No List Specified";
                }
                else
                {

                    SPList oList = oweb.Lists.TryGetList(sList);

                    if (oList != null)
                    {
                        WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(oweb, sPlanner);

                        SPList oProjectList = oweb.Lists[props.sListProjectCenter];

                        DataSet dsResources = WorkPlannerAPI.GetResourceTable(props, oProjectList.ID, sID, oweb);

                        bool bMatchingTaskCenter = false;

                        if (oList.Title.ToLower() == props.sListTaskCenter.ToLower())
                            bMatchingTaskCenter = true;

                        XmlDocument docPlanInfo = new XmlDocument();
                        docPlanInfo.LoadXml("<GetTasks Planner=\"" + sPlanner + "\" ID=\"" + sID + "\" View=\"\"/>");

                        XmlDocument docPlan = new XmlDocument();
                        docPlan.LoadXml(WorkPlannerAPI.GetTasks(docPlanInfo, oweb));

                        if (bAttachedItemsOnly)
                        {
                            SPQuery query = new SPQuery();
                            query.Query = "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + sID + "</Value></Eq></Where>";

                            if (oList.Fields.ContainsField("taskorder"))
                                query.Query += "<OrderBy><FieldRef Name='taskorder'/></OrderBy>";

                            ImportTasksFromListTasks(oList.GetItems(query), docNew, hshMapping, dsResources, bMatchingTaskCenter, docPlan);
                        }
                        else
                        {
                            ImportTasksFromListTasks(oList.Items, docNew, hshMapping, dsResources, bMatchingTaskCenter, docPlan);
                        }

                        XmlDocument docRet = new XmlDocument();
                        docRet.LoadXml(WorkPlannerAPI.ImportTasks(docNew, oweb));

                        if (docRet.FirstChild.Attributes["Status"].Value == "1")
                        {
                            bErrors = true;
                        }

                        sErrors = docRet.OuterXml;
                    }
                    else
                    {
                        bErrors = true;
                        sErrors = "List could not be found.";
                    }
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors = "Error importing list: " + ex.Message + "";
            }

        }

        private void ImportTasksFromListTasks(SPListItemCollection lic, XmlDocument docNew, Hashtable hshMapping, DataSet dsResources, bool bMatchingTaskCenter, XmlDocument docPlan)
        {
            base.totalCount = lic.Count;
            float cnt = 0;
            foreach (SPListItem li in lic)
            {

                //if(bMatchingTaskCenter)
                //{
                //    string taskuid = "";
                //    try
                //    {
                //        taskuid = li["taskuid"].ToString();
                //    }
                //    catch { }
                //    if(String.IsNullOrEmpty(taskuid))
                //    {
                //        ImportTasksFromListsTasksProcess(li, docNew, hshMapping, dsResources);
                //    }
                //    else
                //    {
                //        XmlNode ndCurTask = docPlan.SelectSingleNode("//I[@id='" + taskuid + "']");
                //    }
                //}
                //else
                //{
                ImportTasksFromListsTasksProcess(li, docNew, hshMapping, dsResources);
                updateProgress(cnt++);
                //}
            }
        }

        private void ImportTasksFromListsTasksProcess(SPListItem li, XmlDocument docNew, Hashtable hshMapping, DataSet dsResources)
        {
            XmlNode ndNew = docNew.CreateNode(XmlNodeType.Element, "Item", docNew.NamespaceURI);

            XmlAttribute attr = docNew.CreateAttribute("ID");
            attr.Value = li.ParentList.ID + "." + li.ID.ToString();
            ndNew.Attributes.Append(attr);

            ArrayList arrAssn = new ArrayList();

            foreach (SPField field in li.ParentList.Fields)
            {
                if (field.Reorderable)
                {
                    if (hshMapping.ContainsKey(field.InternalName))
                    {
                        attr = docNew.CreateAttribute(hshMapping[field.InternalName].ToString());
                        attr.Value = getFieldValue(li, field, dsResources);
                        ndNew.Attributes.Append(attr);
                    }
                    else
                    {
                        attr = docNew.CreateAttribute(field.InternalName);
                        attr.Value = getFieldValue(li, field, dsResources);
                        ndNew.Attributes.Append(attr);
                    }
                }
            }

            docNew.FirstChild.AppendChild(ndNew);
        }

        public string getFieldValue(SPListItem li, SPField oField, DataSet dsResources)
        {
            string val = "";
            try
            {
                switch (oField.Type)
                {
                    case SPFieldType.DateTime:
                        try
                        {
                            val = DateTime.Parse(li[oField.Id].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        catch { }
                        break;
                    case SPFieldType.User:
                        SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, li[oField.Id].ToString());
                        foreach (SPFieldUserValue uv in uvc)
                        {
                            DataRow[] dr = dsResources.Tables[2].Select("SPAccountInfo = '" + uv.ToString() + "'");
                            if (dr.Length > 0)
                            {
                                val += ";" + dr[0]["ID"].ToString();
                            }
                        }
                        val = val.Trim(';');
                        break;
                    case SPFieldType.Note:
                        try
                        {
                            val = li[oField.Id].ToString();
                        }
                        catch { }
                        break;
                    case SPFieldType.Calculated:
                        SPFieldCalculated c = (SPFieldCalculated)oField;
                        switch (c.OutputType)
                        {
                            case SPFieldType.Number:
                            case SPFieldType.Currency:
                                val = li[oField.Id].ToString();
                                val = val.Replace(";#", "\n").Split('\n')[1];
                                break;
                            default:
                                val = oField.GetFieldValueAsText(li[oField.Id].ToString());
                                break;
                        };
                        break;
                    case SPFieldType.Number:
                        SPFieldNumber num = (SPFieldNumber)oField;
                        if (num.ShowAsPercentage)
                        {
                            try
                            {
                                val = (float.Parse(li[oField.Id].ToString()) * 100).ToString();
                            }
                            catch { val = li[oField.Id].ToString(); }

                        }
                        else
                        {
                            val = li[oField.Id].ToString();
                        }
                        break;
                    case SPFieldType.Currency:
                        val = li[oField.Id].ToString();
                        break;
                    case SPFieldType.Lookup:
                        try
                        {
                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(li[oField.Id].ToString());
                            foreach (SPFieldLookupValue uv in lvc)
                            {
                                val += ";" + uv.LookupId;
                            }
                            val = val.Trim(';');
                        }
                        catch { }
                        break;
                    case SPFieldType.Boolean:
                        try
                        {
                            if (li[oField.Id].ToString().ToLower() == "true")
                                val = "1";
                            else
                                val = "0";
                        }
                        catch { val = "0"; }
                        break;
                    default:
                        val = oField.GetFieldValueAsText(li[oField.Id].ToString());
                        break;

                };

                if (oField.Description == "Indicator")
                {
                    string url = li.ParentList.ParentWeb.ServerRelativeUrl;
                    val = "<img src=\"" + ((url == "/") ? "" : url) + "/_layouts/images/" + val + "\">";
                }
            }
            catch { }

            return val;
        }
    }
}
