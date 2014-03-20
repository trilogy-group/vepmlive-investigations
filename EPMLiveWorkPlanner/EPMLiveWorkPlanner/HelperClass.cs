using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using Microsoft.SharePoint;

namespace EPMLiveWorkPlanner
{
    public class PlannerCore
    {
        public static string getResourceList(string input, SPWeb oWeb)
        {
            StringBuilder sbResources = new StringBuilder();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(EPMLiveCore.WorkEngineAPI.GetTeam(input, oWeb));

            foreach(XmlNode nd in doc.FirstChild.SelectSingleNode("//Team").ChildNodes)
            {
                sbResources.Append("T");
                sbResources.Append(nd.Attributes["ID"].Value);
                sbResources.Append(":");
                sbResources.Append("{");

                StringBuilder sbAttr = new StringBuilder();
                foreach(XmlAttribute attr in nd.Attributes)
                {
                    if(attr.Name != "ID")
                    {
                        string val = attr.Value;
                        val = val.Replace("\\", "\\\\");
                        val = val.Replace("\"", "\\\"");
                        
                        sbAttr.Append(attr.Name);
                        sbAttr.Append(":\"");
                        sbAttr.Append(val);
                        sbAttr.Append("\",");
                    }
                }
                sbResources.Append(sbAttr.ToString().Trim(','));
                sbResources.Append("},");
            }

            return sbResources.ToString().Trim(',');
        }

        public class WorkPlannerProperty
        {
            public string field;
            public string val;
        }

        [Serializable]
        public class WorkPlannerProperties
        {

            SortedList hshProperties = new SortedList();

            public int count()
            {
                return hshProperties.Count;
            }
            public WorkPlannerProperties(string data)
            {
                if(data != null && data != "")
                {
                    string[] sProps = data.Split('\n');
                    foreach(string sProp in sProps)
                    {
                        string[] sField = sProp.Split('|');
                        hshProperties.Add(sField[0], sField[1]);
                    }
                }
            }
            public void set(string key, string val)
            {
                if(hshProperties.Contains(key))
                    hshProperties[key] = val;
                else
                    hshProperties.Add(key, val);
            }
            public void delete(string key)
            {
                if(hshProperties.Contains(key))
                    hshProperties.Remove(key);
            }
            public WorkPlannerProperty get(string key)
            {
                WorkPlannerProperty wp = null;
                if(hshProperties.Contains("key"))
                {
                    wp = new WorkPlannerProperty();
                    wp.field = key;
                    wp.val = hshProperties[key].ToString();
                }
                return wp;
            }
            public WorkPlannerProperty GetByIndex(int i)
            {
                WorkPlannerProperty wp = new WorkPlannerProperty();
                wp.field = hshProperties.GetKey(i).ToString();
                wp.val = hshProperties.GetByIndex(i).ToString();
                return wp;
            }
            public override string ToString()
            {
                string output = "";
                foreach(DictionaryEntry de in hshProperties)
                {
                    output += "\n" + de.Key + "|" + de.Value;
                }
                if(output.Length > 1)
                    output = output.Substring(1);
                return output;
            }

        }

        internal static SortedList getFieldInfo(SPWeb web, string planner)
        {
            SortedList arrFields = new SortedList();
            string []fields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "StatusFields").Split(',');
            
            foreach(string sField in fields)
            {
                if(!arrFields.Contains(sField))
                    arrFields.Add(sField, false);
            }

            string statusmode = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "StatusMethod");

            switch(statusmode)
            {
                case "1":
                    if(!arrFields.Contains("ActualWork"))
                        arrFields.Add("ActualWork",true);
                    if(!arrFields.Contains("RemainingWork"))
                        arrFields.Add("RemainingWork",true);
                    if(!arrFields.Contains("PercentComplete"))
                        arrFields.Add("PercentComplete", false);
                    if(!arrFields.Contains("Status"))
                        arrFields.Add("Status", false);
                    break;
                case "2":
                    if(!arrFields.Contains("RemainingWork"))
                        arrFields.Add("RemainingWork",true);
                    if(!arrFields.Contains("PercentComplete"))
                        arrFields.Add("PercentComplete", false);
                    if(!arrFields.Contains("Status"))
                        arrFields.Add("Status", false);
                    if(!arrFields.Contains("Complete"))
                        arrFields.Add("Complete", false);
                    break;
                case "3":
                    if(!arrFields.Contains("Status"))
                        arrFields.Add("Status",true);
                    if(!arrFields.Contains("PercentComplete"))
                        arrFields.Add("PercentComplete", false);
                    if(!arrFields.Contains("Complete"))
                        arrFields.Add("Complete", false);
                    break;
                case "4":
                    if(!arrFields.Contains("Complete"))
                        arrFields.Add("Complete",true);
                    if(!arrFields.Contains("PercentComplete"))
                        arrFields.Add("PercentComplete", false);
                    if(!arrFields.Contains("Status"))
                        arrFields.Add("Status", false);
                    break;
            };

            return arrFields;
        }

        public static string getStatusMethod(SPWeb w, string list)
        {
            string method = "";
            try
            {
                Guid lWeb = EPMLiveCore.CoreFunctions.getLockedWeb(w);
                if(lWeb == Guid.Empty)
                    lWeb = w.ID;

                using(SPSite site = w.Site)
                {
                    using(SPWeb web = site.OpenWeb(lWeb))
                    {
                        string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");

                        foreach(string planner in planners.Split(','))
                        {
                            if(planner != "")
                            {
                                string[] sPlanner = planner.Split('|');
                                string taskcenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter");

                                if(String.Equals(taskcenter, list, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    method = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "StatusMethod");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return method;
        }

        public static SortedList getWorkPlannerStatusFields(SPWeb w, string list)
        {
            SortedList arrFields = new SortedList();

            try
            {
                Guid lWeb = EPMLiveCore.CoreFunctions.getLockedWeb(w);
                if(lWeb == Guid.Empty)
                    lWeb = w.ID;

                using(SPSite site = w.Site)
                {
                    using(SPWeb web = site.OpenWeb(lWeb))
                    {
                        string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");

                        foreach(string planner in planners.Split(','))
                        {
                            if(planner != "")
                            {
                                string[] sPlanner = planner.Split('|');
                                string taskcenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter");

                                if(String.Equals(taskcenter, list, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    arrFields = getFieldInfo(web, sPlanner[0]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return arrFields;
        }

        public static string getWorkPlannerFromTaskList(SPWeb w, string list)
        {
            string splanner = "";

            try
            {
                Guid lWeb = EPMLiveCore.CoreFunctions.getLockedWeb(w);
                if(lWeb == Guid.Empty)
                    lWeb = w.ID;

                using(SPSite site = w.Site)
                {
                    using(SPWeb web = site.OpenWeb(lWeb))
                    {
                        string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");

                        foreach(string planner in planners.Split(','))
                        {
                            if(planner != "")
                            {
                                string[] sPlanner = planner.Split('|');
                                string taskcenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter");

                                if(taskcenter != "")
                                {
                                    splanner = sPlanner[0];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return splanner;
        }
    }
}
