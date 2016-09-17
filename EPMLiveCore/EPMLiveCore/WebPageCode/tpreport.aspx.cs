using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.IO;
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class tpreport : System.Web.UI.Page
    {

        protected string table;
        private ArrayList arrProjectOC = new ArrayList();
        private ArrayList arrTaskOC = new ArrayList();
        private ArrayList arrResOC = new ArrayList();
        private ArrayList arrPeriods = new ArrayList();
        private SortedList lstResourceCap = new SortedList();
        private Hashtable hshProjectOC = new Hashtable();
        private Hashtable hshResourceOC = new Hashtable();
        private DataTable dt = new DataTable();
        protected GridView Gridview1;

        private class PeriodItem
        {
            public string name;
            public string start;
            public string finish;
            public string capacity;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            {

                SPWeb web = SPContext.Current.Web;
                SPWeb resWeb = null;

                string url = CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL").ToLower();
                try
                {
                    if (url != "")
                    {
                        if (url.StartsWith("/"))
                        {
                            resWeb = site.OpenWeb(url);
                        }
                        else
                        {
                            using (SPSite s = new SPSite(url))
                            {
                                url = s.ServerRelativeUrl + url.Replace(s.Url, "");
                                resWeb = s.OpenWeb(url);
                            }
                        }
                    }
                    if (resWeb != null)
                    {
                        buildColumns(resWeb);
                        processData(web, resWeb);
                    }
                }
                catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                finally
                {
                    if (resWeb != null)
                        resWeb.Dispose();
                }

                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }
        }

        private void processData(SPWeb web, SPWeb resWeb)
        {

            if (CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL").ToLower() != resWeb.ServerRelativeUrl.ToLower())
            {
                return;
            }

            try
            {
                SPList list = web.Lists["EPMLiveTimePhased"];

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='TimePhasedType'/><Value Type='Number'>1</Value></Eq></Where>";

                foreach (SPListItem li in list.GetItems(query))
                {
                    object[] arrDtRow = new object[dt.Columns.Count];
                    string project = li.Title;
                    string task = li["Task"].ToString();
                    string wbs = li["WBS"].ToString();
                    string resource = li["Resource"].ToString();
                    string valuetype = li["ValueType"].ToString();

                    arrDtRow[4] = web.Title;

                    processProjectInfo(web, ref arrDtRow, project);
                    processTaskInfo(web, ref arrDtRow, project, task, wbs);
                    processResourceInfo(resWeb, ref arrDtRow, resource);

                    arrDtRow[3] = valuetype;

                    processPeriods(li, ref arrDtRow);

                    dt.Rows.Add(arrDtRow);
                }
            }
            catch (Exception ex)
            {
                logError(ex.Message + ex.StackTrace);
            }
            try
            {
                if (Request["rollup"] != null && Request["rollup"].ToString() == "true")
                {
                    foreach (SPWeb w in web.Webs)
                    {
                        try
                        {
                            processData(w, resWeb);
                        }
                        catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Others, TraceSeverity.Medium, ex.ToString()); }
                        finally { if (w != null) w.Dispose(); }
                    }
                }
            }
            catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Others, TraceSeverity.Medium, ex.ToString()); }
        }

        private void logError(string error)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                StreamWriter sw = new StreamWriter("C:\\tpreportlog.txt");
                sw.WriteLine(error);
                sw.Close();
            });
        }

        private void processPeriods(SPListItem li, ref object[] arrDtRow)
        {
            int periodcount = 1;
            foreach (PeriodItem period in arrPeriods)
            {
                try
                {
                    arrDtRow[0] = "(" + periodcount.ToString() + ") " + period.name.Replace("_x0020_", " ");
                    arrDtRow[1] = li[li.Fields.GetFieldByInternalName(period.name).Id].ToString();
                    arrDtRow[2] = period.capacity;

                    int cap = int.Parse(period.capacity);
                    int counter = arrProjectOC.Count + arrTaskOC.Count + 8;

                    foreach (string s in arrResOC)
                    {
                        int i = 0;
                        try
                        {
                            i = (int)lstResourceCap[s + "\n" + arrDtRow[counter]];
                            i = i * cap;
                        }
                        catch { }

                        arrDtRow[counter + 1] = i;

                        counter = counter + 2;
                    }

                    dt.Rows.Add(arrDtRow);
                }
                catch { }
                periodcount++;
            }
        }

        private void processResourceInfo(SPWeb web, ref object[] arrDtRow, string resource)
        {
            arrDtRow[arrProjectOC.Count + arrTaskOC.Count + 7] = resource;

            int counter = arrProjectOC.Count + arrTaskOC.Count + 8;

            if (!hshResourceOC.Contains(resource))
            {
                SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\">" + resource + "</Value></Eq></Where>";
                string vals = "";
                if (list.GetItems(query).Count > 0)
                {
                    SPListItem li = list.GetItems(query)[0];
                    foreach (string s in arrResOC)
                    {
                        try
                        {
                            SPField f = list.Fields.GetFieldByInternalName(s);
                            if (f.Type == SPFieldType.Lookup)
                            {
                                string val = li[f.Id].ToString();
                                val = val.Replace(";#", "\n").Split('\n')[1];
                                vals = vals + "\n" + val;
                            }
                            else
                            {
                                vals = vals + "\n" + li[f.Id].ToString();
                            }
                        }
                        catch { vals = vals + "\n" + " "; }
                    }
                    if (vals.Length > 1)
                    {
                        vals = vals.Substring(1);
                    }
                    hshResourceOC.Add(resource, vals);
                }

            }
            if (hshResourceOC.Contains(resource))
            {
                string sValString = hshResourceOC[resource].ToString();
                if (sValString != "")
                {
                    string[] sVals = sValString.Split('\n');
                    foreach (string s in sVals)
                    {
                        arrDtRow[counter] = s;
                        counter += 2;
                    }
                }
            }
        }

        private void processTaskInfo(SPWeb web, ref object[] arrDtRow, string project, string task, string wbs)
        {
            arrDtRow[arrProjectOC.Count + 6] = wbs + " - " + task;

            int counter = arrProjectOC.Count + 7;

            SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveTaskCenter")];
            SPQuery query = new SPQuery();
            query.Query = "<Where><And><And><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\">" + task + "</Value></Eq><Eq><FieldRef Name=\"Project\"/><Value Type=\"Text\">" + project + "</Value></Eq></And><Eq><FieldRef Name=\"WBS\"/><Value Type=\"Text\">" + wbs + "</Value></Eq></And></Where>";

            if (list.GetItems(query).Count > 0)
            {
                SPListItem li = list.GetItems(query)[0];
                foreach (string s in arrTaskOC)
                {
                    try
                    {
                        SPField f = list.Fields.GetFieldByInternalName(s);
                        if (f.Type == SPFieldType.Lookup)
                        {
                            string val = li[f.Id].ToString();
                            val = val.Replace(";#", "\n").Split('\n')[1];
                            arrDtRow[counter] = val;
                        }
                        else
                        {
                            arrDtRow[counter] = li[f.Id].ToString();
                        }
                    }
                    catch { }
                    counter++;
                }
            };


        }

        private void processProjectInfo(SPWeb web, ref object[] arrDtRow, string project)
        {
            int counter = 6;

            arrDtRow[5] = project;

            if (!hshProjectOC.Contains(project))
            {
                SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter")];
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\">" + project + "</Value></Eq></Where>";
                string vals = "";
                if (list.GetItems(query).Count > 0)
                {
                    SPListItem li = list.GetItems(query)[0];
                    foreach (string s in arrProjectOC)
                    {
                        try
                        {
                            SPField f = list.Fields.GetFieldByInternalName(s);
                            if (f.Type == SPFieldType.Lookup)
                            {
                                string val = li[f.Id].ToString();
                                val = val.Replace(";#", "\n").Split('\n')[1];
                                vals = vals + "\n" + val;
                            }
                            else
                            {
                                vals = vals + "\n" + li[f.Id].ToString();
                            }
                        }
                        catch { vals = vals + "\n" + " "; }
                    }
                    if (vals.Length > 1)
                    {
                        vals = vals.Substring(1);
                    }
                }
                hshProjectOC.Add(project, vals);
            }

            string sValString = hshProjectOC[project].ToString();
            if (sValString != "")
            {
                string[] sVals = sValString.Split('\n');
                foreach (string s in sVals)
                {
                    arrDtRow[counter++] = s;
                }
            }
        }

        private void buildResourceCap(SPList list, string field)
        {
            //lstResourceCap

            SortedList lstRes = new SortedList();

            foreach (SPListItem li in list.Items)
            {
                string val = "";
                try
                {
                    val = li[field].ToString();
                }
                catch { }
                if (val != "")
                {
                    if (lstRes.Contains(val))
                    {
                        int i = (int)lstRes[val];
                        i++;
                        lstRes[val] = i;
                    }
                    else
                    {
                        lstRes.Add(val, 1);
                    }
                }
            }

            foreach (DictionaryEntry de in lstRes)
            {
                lstResourceCap.Add(field + "\n" + de.Key, de.Value);
            }
        }

        private void buildColumns(SPWeb web)
        {
            try
            {
                dt.Columns.Add("Period");
                dt.Columns.Add("Value");
                dt.Columns.Add("Capacity");
                dt.Columns.Add("ValueType");

                dt.Columns.Add("Site Name");
                dt.Columns.Add("Project");

                SPList list = web.Lists["EPMLiveOutlineCodes"];
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name=\"OutlineCodeType\"/><Value Type=\"Text\">Project</Value></Eq></Where>";
                foreach (SPListItem li in list.GetItems(query))
                {
                    dt.Columns.Add(li["DisplayName"].ToString());
                    arrProjectOC.Add(li.Title);
                }
                query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name=\"OutlineCodeType\"/><Value Type=\"Text\">Task</Value></Eq></Where>";
                dt.Columns.Add("Task");
                foreach (SPListItem li in list.GetItems(query))
                {
                    dt.Columns.Add(li["DisplayName"].ToString());
                    arrTaskOC.Add(li.Title);
                }

                dt.Columns.Add("Resource");

                list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];

                foreach (SPField f in list.Fields)
                {
                    if (!f.Hidden && !f.ReadOnlyField && f.Type != SPFieldType.Attachments && f.InternalName != "Title" && f.InternalName != "SharePointAccount")
                    {
                        arrResOC.Add(f.InternalName);
                        dt.Columns.Add(f.Title);
                        dt.Columns.Add(f.Title + " Capacity");
                        buildResourceCap(list, f.InternalName);
                    }
                }

                list = web.Lists["EPMLivePeriods"];



                foreach (SPListItem li in list.Items)
                {
                    //dt.Columns.Add(li.Title);
                    PeriodItem pi = new PeriodItem();
                    pi.name = li.Title.Replace(" ", "_x0020_");
                    pi.start = li["StartDate"].ToString();
                    pi.finish = li["EndDate"].ToString();
                    pi.capacity = li["Capacity"].ToString();
                    arrPeriods.Add(pi);
                }

            }
            catch { }
        }

    }
}