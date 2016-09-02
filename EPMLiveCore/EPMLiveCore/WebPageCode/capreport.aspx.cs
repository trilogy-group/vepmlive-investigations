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

namespace EPMLiveCore
{
    public partial class capreport : System.Web.UI.Page
    {

        protected string table;

        private ArrayList arrResOC = new ArrayList();
        private SortedList lstPeriods = new SortedList();

        private SortedList lstResourceCap = new SortedList();

        private Hashtable hshResourceWork = new Hashtable();
        private Hashtable hshResourceOCWork = new Hashtable();
        private Hashtable hshResourceOC = new Hashtable();

        private DataTable dt = new DataTable();
        protected GridView Gridview1;

        private class PeriodItem
        {
            public string displayname;
            public string name;
            public string start;
            public string finish;
            public int capacity;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            {
                SPWeb web = SPContext.Current.Web;
                {
                    SPWeb resWeb = null;

                    string url = CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL").ToLower();
                    try
                    {
                        if(url != "")
                        {
                            if(url.StartsWith("/"))
                            {
                                resWeb = site.OpenWeb(url);
                            }
                            else
                            {
                                SPSite s = new SPSite(url);
                                url = s.ServerRelativeUrl + url.Replace(s.Url, "");
                                resWeb = s.OpenWeb(url);
                                s.Close();
                            }
                        }
                    }
                    catch { }

                    if (resWeb != null)
                    {
                        buildColumns(resWeb);
                        processResourceInfo(resWeb);
                        processData(web, resWeb);

                        if (Request["rollup"] != null && Request["rollup"].ToString() == "true")
                        {
                            foreach (SPWeb w in web.Webs)
                            {
                                processData(w, resWeb);
                                w.Close();
                            }
                        }

                        buildGrid();

                        resWeb.Close();
                    }

                }

                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }
        }

        private void buildGrid()
        {
            foreach (DictionaryEntry de in hshResourceWork)
            {
                object[] arrDtRow = new object[dt.Columns.Count];

                string []resper = de.Key.ToString().Split('\n');
                int val = int.Parse(de.Value.ToString());
                string resource = resper[1];
                PeriodItem pi = (PeriodItem)lstPeriods[resper[0]];
                int capacity = pi.capacity;

                arrDtRow[0] = pi.displayname;
                arrDtRow[1] = resource;
                arrDtRow[2] = capacity - val;

                int counter = 0;

                string[] resOcData = hshResourceOC[resource.Trim()].ToString().Split('\n');

                foreach (string oc in arrResOC)
                {
                    //string ocCapString = oc + "\n" + resOcData[ocDataCounter];
                    //int cap = 0;
                    //try
                    //{
                    //    cap = (int)lstResourceCap[ocCapString] * capacity;
                    //}catch{}

                    arrDtRow[counter + 3] = resOcData[counter];
                    //arrDtRow[counter + 1] = cap;


                    counter++;// = counter + 2;
                    //ocDataCounter++;
                }

                dt.Rows.Add(arrDtRow);

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
                query.Query = "<Where><And><Eq><FieldRef Name='TimePhasedType'/><Value Type='Number'>1</Value></Eq><Eq><FieldRef Name='ValueType'/><Value Type='Text'>Work</Value></Eq></And></Where>";

                foreach (SPListItem li in list.GetItems(query))
                {
                    string project = li.Title;

                    processPeriods(li);

                }
            }
            catch { }
        }

        private void processPeriods(SPListItem li)
        {
            string resource = li["Resource"].ToString();
            int periodcount = 1;
            

            foreach (PeriodItem period in lstPeriods.Values)
            {
                try
                {
                    string value = li[li.Fields.GetFieldByInternalName(period.name).Id].ToString();
                    //if (hshResourceWork.Contains(period.name + "\n" + resource))
                    {
                        int val = (int)hshResourceWork[period.name + "\n" + resource.Trim()];
                        val = val + int.Parse(value);
                        hshResourceWork[period.name + "\n" + resource.Trim()] = val;
                    }
                    //else
                    //{
                    //    hshResourceWork.Add(period.name + "\n" + resource, int.Parse(value));
                    //}

                }
                catch { }
                periodcount++;
            }
        }

        private void processResourceInfo(SPWeb web)
        {
            SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];

                

                foreach (SPListItem li in list.Items)
                {
                    string vals = "";
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
                    hshResourceOC.Add(li.Title, vals);
                }

                foreach (PeriodItem period in lstPeriods.Values)
                {
                    foreach (DictionaryEntry de in hshResourceOC)
                    {
                        hshResourceWork.Add(period.name + "\n" + de.Key.ToString(), 0);
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
                dt.Columns.Add("Resource");
                dt.Columns.Add("Remaining Capacity");

                SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];

                foreach(SPField f in list.Fields)
                {
                    if (!f.Hidden && !f.ReadOnlyField && f.Type != SPFieldType.Attachments && f.InternalName != "Title" && f.InternalName != "SharePointAccount")
                    {
                        arrResOC.Add(f.InternalName);
                        dt.Columns.Add(f.Title);
                        //dt.Columns.Add(f.Title + " Remaining Capacity");
                        //buildResourceCap(list, f.InternalName);
                    }
                }

                list = web.Lists["EPMLivePeriods"];

                int counter = 1;

                foreach (SPListItem li in list.Items)
                {
                    //dt.Columns.Add(li.Title);
                    PeriodItem pi = new PeriodItem();
                    pi.name = li.Title.Replace(" ", "_x0020_");
                    pi.displayname = "(" + counter.ToString() + ") " + li.Title;
                    pi.start = li["StartDate"].ToString();
                    pi.finish = li["EndDate"].ToString();
                    try
                    {
                        pi.capacity = int.Parse(li["Capacity"].ToString());
                    }
                    catch { pi.capacity = 0; }
                    lstPeriods.Add(pi.name,pi);
                    counter++;
                }

            }
            catch { }
        }

        

        
    }
}