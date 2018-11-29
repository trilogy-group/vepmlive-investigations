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
using System.Diagnostics;

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
        StringBuilder sbErrors = null;
        public void execute(SPSite osite, SPWeb oweb, string data)
        {
            sbErrors = new StringBuilder();
            DataSet resources = null;
            try
            {
                var docNew = LoadDocument(data);
                CreateAttributes(docNew);

                var attachedItemsOnly = true;
                var mapping = new Hashtable();
                var id = ItemID.ToString();
                var planner = string.Empty;
                var list = string.Empty;

                GetList(ref list, docNew);
                GetPlanner(ref planner);
                GetAttachedItemsOnly(ref attachedItemsOnly, docNew);
                PopulateListField(docNew, mapping);
                ExecuteAndHandleErrors(oweb, planner, id, list, ref resources, attachedItemsOnly, docNew, mapping);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                bErrors = true;
                sbErrors.Append(string.Format("Error importing list: {0}", ex.Message));
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;

                resources?.Dispose();
                oweb?.Dispose();
                osite?.Dispose();
            }

        }

        private void ExecuteAndHandleErrors(
            SPWeb oweb,
            string planner,
            string id,
            string list,
            ref DataSet resources,
            bool attachedItemsOnly,
            XmlDocument docNew,
            Hashtable mapping)
        {
            if (planner == string.Empty)
            {
                bErrors = true;
                sbErrors.Append("No Planner Specified");
            }
            else if (id == string.Empty)
            {
                bErrors = true;
                sbErrors.Append("No ID Specified");
            }
            else if (list == string.Empty)
            {
                bErrors = true;
                sbErrors.Append("No List Specified");
            }
            else
            {
                var spList = oweb.Lists.TryGetList(list);

                if (spList != null)
                {
                    var props = WorkPlannerAPI.getSettings(oweb, planner);
                    resources = GetResources(oweb, props, id);
                    ImportTasks(oweb, spList, props, planner, id, attachedItemsOnly, docNew, mapping, resources);
                }
                else
                {
                    bErrors = true;
                    sbErrors.Append("List could not be found.");
                }
            }
        }

        private void ImportTasks(
            SPWeb spWeb,
            SPList spList,
            WorkPlannerAPI.PlannerProps props,
            string planner,
            string id,
            bool attachedItemsOnly,
            XmlDocument docNew,
            Hashtable mapping,
            DataSet resources)
        {
            var taskCenter = string.Equals(spList.Title, props.sListTaskCenter, StringComparison.CurrentCultureIgnoreCase);

            var docPlanInfo = new XmlDocument();
            docPlanInfo.LoadXml(string.Format("<GetTasks Planner=\"{0}\" ID=\"{1}\" View=\"\"/>", planner, id));

            var docPlan = new XmlDocument();
            docPlan.LoadXml(WorkPlannerAPI.GetTasks(docPlanInfo, spWeb));

            if (attachedItemsOnly)
            {
                var query = new SPQuery
                {
                    Query = string.Format(
                        "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>{0}</Value></Eq></Where>",
                        id)
                };

                if (spList.Fields.ContainsField("taskorder"))
                {
                    query.Query += "<OrderBy><FieldRef Name='taskorder'/></OrderBy>";
                }

                ImportTasksFromListTasks(spList.GetItems(query), docNew, mapping, resources, taskCenter, docPlan);
            }
            else
            {
                ImportTasksFromListTasks(spList.Items, docNew, mapping, resources, taskCenter, docPlan);
            }

            var docRet = new XmlDocument();
            docRet.LoadXml(WorkPlannerAPI.ImportTasks(docNew, spWeb));

            if (docRet.FirstChild.Attributes["Status"].Value == "1")
            {
                bErrors = true;
            }

            sbErrors.Append(docRet.OuterXml);
        }

        private static DataSet GetResources(SPWeb oweb, WorkPlannerAPI.PlannerProps props, string id)
        {
            DataSet resources;
            var projectList = oweb.Lists[props.sListProjectCenter];
            resources = new DataSet();
            resources = WorkPlannerAPI.GetResourceTable(props, projectList.ID, id, oweb);
            return resources;
        }

        private static void PopulateListField(XmlDocument docNew, Hashtable mapping)
        {
            try
            {
                var columns = docNew.FirstChild.SelectSingleNode("Columns");
                foreach (XmlNode ndField in columns.SelectNodes("Column"))
                {
                    var listField = getAttribute(ndField, "ListField");
                    var plannerField = getAttribute(ndField, "PlannerField");

                    if (!string.IsNullOrWhiteSpace(listField) && !string.IsNullOrWhiteSpace(plannerField))
                    {
                        if (!mapping.ContainsKey(listField) && !mapping.ContainsValue(plannerField))
                        {
                            mapping.Add(listField, plannerField);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void GetAttachedItemsOnly(ref bool attachedItemsOnly, XmlDocument docNew)
        {
            try
            {
                attachedItemsOnly = bool.Parse(docNew.FirstChild.Attributes["AttachedItemsOnly"].Value);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private void GetPlanner(ref string planner)
        {
            try
            {
                planner = key;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void GetList(ref string list, XmlDocument docNew)
        {
            try
            {
                list = docNew.FirstChild.Attributes["List"].Value;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private void CreateAttributes(XmlDocument docNew)
        {
            var attribute = docNew.CreateAttribute("UIDColumn");
            attribute.Value = "ID";
            docNew.FirstChild.Attributes.Append(attribute);

            attribute = docNew.CreateAttribute("ID");
            attribute.Value = ItemID.ToString();
            docNew.FirstChild.Attributes.Append(attribute);

            attribute = docNew.CreateAttribute("Planner");
            attribute.Value = key;
            docNew.FirstChild.Attributes.Append(attribute);
        }

        private static XmlDocument LoadDocument(string data)
        {
            var docNew = new XmlDocument();
            docNew.LoadXml(data);
            return docNew;
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
            return WorkPlannerAPI.FieldValue(li, oField, dsResources, false);
        }
    }
}
