using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Collections;

namespace EPMLiveWorkPlanner
{
    class TaskCenterCalculate
    {
        ArrayList arrFields = new ArrayList();
        SPList list = null;

        int startHour;
        int endHour;
        BitArray workdays = new BitArray(7);
        int nonWork = 0;

        IFormatProvider culture;

        public void setBaseline(SPList list, string projectid, SPList lstProjectCenter)
        {
            //SPList pc = list.ParentWeb.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveProjectCenter")];
            list.ParentWeb.AllowUnsafeUpdates = true;
            if (!lstProjectCenter.Fields.ContainsField("BaselineSaved"))
            {
                try
                {
                    lstProjectCenter.Fields.Add("BaselineSaved", SPFieldType.DateTime, false);
                    SPField fld = lstProjectCenter.Fields["BaselineSaved"];
                    fld.Title = "Last Baseline Saved";
                    fld.ShowInEditForm = false;
                    fld.ShowInNewForm = false;
                    fld.Sealed = true;
                    fld.Update();
                    lstProjectCenter.Update();
                }
                catch { }
            }

            SPListItem project = lstProjectCenter.GetItemById(int.Parse(projectid));

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>" + project.Title + "</Value></Eq></Where>";

            Hashtable hshFields = new Hashtable();
            foreach (SPField f in list.Fields)
            {
                string fname = f.InternalName;
                if (fname == "StartDate")
                    fname = "Start";
                if (fname == "DueDate")
                    fname = "Finish";

                if (list.Fields.ContainsField("Baseline" + fname))
                {
                    hshFields.Add(f.InternalName, "Baseline" + fname);
                }
            }

            foreach (SPListItem li in list.GetItems(query))
            {
                foreach (DictionaryEntry de in hshFields)
                {
                    li[de.Value.ToString()] = li[de.Key.ToString()];
                }
                li.ParentList.ParentWeb.AllowUnsafeUpdates = true;
                if (li.ModerationInformation != null)
                    li.ModerationInformation.Status = SPModerationStatusType.Approved;
                li.Update();
            }

            foreach (SPField f in lstProjectCenter.Fields)
            {
                string fname = f.InternalName;
                if (fname == "StartDate")
                    fname = "Start";
                if (fname == "DueDate")
                    fname = "Finish";

                if (lstProjectCenter.Fields.ContainsField("Baseline" + fname))
                {
                    project["Baseline" + fname] = project[f.InternalName];
                }
            }
            if (lstProjectCenter.Fields.ContainsField("BaselineSaved"))
                project[lstProjectCenter.Fields.GetFieldByInternalName("BaselineSaved").Id] = DateTime.Now;
            
            project.SystemUpdate(true);
        }

        public void Calculate(SPList splist, string projectid, SPList lstProjectCenter, string sWPFields)
        {

            System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(1033);
            culture = new System.Globalization.CultureInfo(cInfo.Name, true);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPSite site = SPContext.Current.Site;
                {
                    startHour = site.RootWeb.RegionalSettings.WorkDayStartHour / 60;
                    endHour = site.RootWeb.RegionalSettings.WorkDayEndHour / 60;
                    int work = site.RootWeb.RegionalSettings.WorkDays;
                    for (byte x = 0; x < workdays.Count; x++)
                    {
                        workdays[6 - x] = (((work >> x) & 0x01) == 0x01) ? true : false;
                        if (!workdays[6 - x])
                            nonWork++;
                    }
                }
            });


            list = splist;
            SPListItem project = lstProjectCenter.GetItemById(int.Parse(projectid));

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>" + project.Title + "</Value></Eq></Where><OrderBy><FieldRef Name='taskorder'/></OrderBy>";

            DataTable dt = new DataTable("Items");
            dt.Columns.Add("ID");
            dt.Columns.Add("WBS");
            dt.Columns.Add("ParentWBS");
            dt.Columns.Add("Level");
            

            object[] objParams = new object[4];
            objParams[0] = "0";
            objParams[1] = "0";
            objParams[2] = "";
            objParams[3] = "0";
            dt.Rows.Add(objParams);

            //string URL = EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveWorkPlannerURL");

            //if (URL == "")
            //    URL = list.ParentWeb.Url;

            //using (SPSite oSiteCollection = new SPSite(URL))
            //{
            //    using (SPWeb oWebsite = oSiteCollection.OpenWeb())
            //    {
            //        oWebsite.AllowUnsafeUpdates = true;
            //        SPWeb workplannerweb = list.ParentWeb;
            //        if (oWebsite.Url.ToLower() == URL.ToLower())
            //            workplannerweb = oWebsite;
            //        string props = workplannerweb.Properties["EPMLiveWorkPlannerFields"];
                    
            //    }
            //}

            if (sWPFields != null && sWPFields != "")
            {
                string[] sProps = sWPFields.Split('\n');
                foreach (string sProp in sProps)
                {
                    string[] sField = sProp.Split('|');
                    try
                    {
                        SPField field = list.Fields.GetFieldByInternalName(sField[0]);

                        arrFields.Add(sProp);

                        switch (field.Type)
                        {
                            case SPFieldType.DateTime:
                                dt.Columns.Add(sField[0], typeof(DateTime));
                                break;
                            case SPFieldType.Number:
                            case SPFieldType.Currency:
                                dt.Columns.Add(sField[0], typeof(float));
                                break;
                            default:
                                dt.Columns.Add(sField[0], typeof(string));
                                break;
                        };
                        if (sField[0] == "PercentComplete")
                        {
                            try
                            {
                                field = list.Fields.GetFieldByInternalName(sField[1]);

                                if (!arrFields.Contains(sField[1]))
                                    arrFields.Add(sField[1]);

                                switch (field.Type)
                                {
                                    case SPFieldType.DateTime:
                                        dt.Columns.Add(sField[1], typeof(DateTime));
                                        break;
                                    case SPFieldType.Number:
                                    case SPFieldType.Currency:
                                        dt.Columns.Add(sField[1], typeof(float));
                                        break;
                                    default:
                                        dt.Columns.Add(sField[1], typeof(string));
                                        break;
                                };
                            }
                            catch { }
                        }
                    }
                    catch { }

                }
            }

            if (!dt.Columns.Contains("ActualDuration"))
            {
                arrFields.Add("ActualDuration|");
                dt.Columns.Add("ActualDuration", typeof(float));
            }
            if (!dt.Columns.Contains("Duration"))
            {
                arrFields.Add("Duration|");
                dt.Columns.Add("Duration", typeof(float));
            }



            dt.Columns.Add("Predecessors");
            dt.Columns.Add("TaskID");
            dt.Columns.Add("PredCalcDone");
            dt.Columns.Add("TaskChanged");

            int maxLevel = 1;

            foreach (SPListItem li in list.GetItems(query))
            {
                string wbs = "";
                try
                {
                    wbs = li["WBS"].ToString();
                }catch{}
                int lastDot = wbs.LastIndexOf(".");
                string parentwbs = "";
                int level = wbs.Split('.').Length;

                if(lastDot > -1)
                    parentwbs = wbs.Substring(0, lastDot);
                if(level > maxLevel)
                    maxLevel = level;

                objParams = new object[7 + arrFields.Count];
                objParams[0] = li.UniqueId.ToString();
                objParams[1] = "0." + wbs;
                if (parentwbs == "")
                    objParams[2] = "0";
                else
                    objParams[2] = "0." + parentwbs;
                objParams[3] = level.ToString();
                int counter = 4;
                foreach (string field in arrFields)
                {
                    try
                    {
                        string[] fieldinfo = field.Split('|');
                        objParams[counter] = li[fieldinfo[0]].ToString();
                    }
                    catch { }
                    counter++;
                }
                try
                {
                    string preds = "";
                    try
                    {
                        preds =li["Predecessors"].ToString();
                    }catch{}
                    objParams[counter++] = preds;
                    objParams[counter++] = li["taskorder"];
                    if (objParams[counter - 2].ToString() == "")
                        objParams[counter] = "Y";

                }
                catch { }
                dt.Rows.Add(objParams);
            }

            for(int i = maxLevel; i >= 0; i--)
            {
                DataRow[] drs = dt.Select("level=" + i.ToString());
                foreach (DataRow dr in drs)
                {
                    SPListItem li = null;
                    try
                    {
                        if (dr["ID"].ToString() == "0")
                            li = project;
                        else
                            li = list.GetItemByUniqueId(new Guid(dr["ID"].ToString()));
                    }
                    catch { }
                    DataRow []drChildren = dt.Select("ParentWBS='" + dr["WBS"] + "'");
                    if (drChildren.Length <= 0 && dr["ID"].ToString() != "0")
                    {
                        if (li.Fields.ContainsField("Summary"))
                            li["Summary"] = 0;
                        dt = calcItem(li, dr);
                    }
                    else
                    {
                        if (li.Fields.ContainsField("Summary"))
                            li["Summary"] = 1;
                        dt = calcChildren(drChildren, li, dr, lstProjectCenter);
                        if (dr["ID"].ToString() == "0")
                        {
                            if (li.Fields.ContainsField("Duration") && li.Fields.ContainsField("Start") && li.Fields.ContainsField("Finish"))
                            {
                                try
                                {
                                    li[li.Fields.GetFieldByInternalName("Duration").Id] = getDuration(li[li.Fields.GetFieldByInternalName("Start").Id].ToString(), li[li.Fields.GetFieldByInternalName("Finish").Id].ToString());
                                }
                                catch { }
                            }
                            if (li.Fields.ContainsField("ActualDuration") && li.Fields.ContainsField("ActualStart") && li.Fields.ContainsField("ActualFinish"))
                            {
                                try
                                {
                                    li[li.Fields.GetFieldByInternalName("ActualDuration").Id] = getDuration(li[li.Fields.GetFieldByInternalName("ActualStart").Id].ToString(), li[li.Fields.GetFieldByInternalName("ActualFinish").Id].ToString());
                                }
                                catch { }
                            }
                        }
                        else
                            dt = calcDurations(li, dr);
                        if(li != null)
                            li.SystemUpdate();
                    }
                }
            }

            if (dt.Columns.Contains("DueDate") && dt.Columns.Contains("StartDate"))
            {
                foreach (DataRow dr in dt.Select("Predecessors <> ''"))
                {
                    dt = setStartDateForLink(dr);
                }
            }

            foreach (DataRow dr in dt.Select("TaskChanged = 'Y'"))
            {
                SPListItem li = null;
                try
                {
                    li = list.GetItemByUniqueId(new Guid(dr["ID"].ToString()));
                }
                catch { }
                if (li != null)
                {
                    if (dt.Columns.Contains("StartDate"))
                    {
                        if (dr["StartDate"].ToString() == "")
                            li["StartDate"] = null;
                        else
                            li["StartDate"] = dr["StartDate"];
                    }
                    if (dt.Columns.Contains("DueDate"))
                    {
                        if (dr["DueDate"].ToString() == "")
                            li["DueDate"] = null;
                        else
                            li["DueDate"] = dr["DueDate"];
                    }
                    li.SystemUpdate();
                }
            }

        }

        private DataTable setStartDateForLink(DataRow drProc)
        {
            drProc["PredCalcDone"] = "Y";
            string[] strIds = drProc["Predecessors"].ToString().Split(',');
            DateTime dtMax = DateTime.MinValue;
            bool isMilestone = false;
            foreach(string strId in strIds)
            {
                DataRow[] dr = drProc.Table.Select("TaskID = '" + strId + "'");
                if (dr.Length > 0)
                {
                    if (dr[0]["PredCalcDone"].ToString() == "Y")
                    {
                        try
                        {
                            DateTime fn = DateTime.Parse(dr[0]["DueDate"].ToString());
                            if (fn > dtMax)
                            {
                                if (dr[0]["Duration"].ToString() == "0")
                                    isMilestone = true;
                                else
                                    isMilestone = false;
                                dtMax = fn;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        setStartDateForLink(dr[0]);
                        DataRow[] dr2 = drProc.Table.Select("TaskID = '" + strId + "'");
                        if (dr2.Length > 0)
                        {
                            try
                            {
                                DateTime fn = DateTime.Parse(dr2[0]["DueDate"].ToString());
                                if (fn > dtMax)
                                    dtMax = fn;
                            }
                            catch { }
                        }
                    }
                }
            }

            if (dtMax != DateTime.MinValue)
            {
                if (!isMilestone)
                {
                    dtMax = dtMax.AddDays(1);
                    dtMax = new DateTime(dtMax.Year, dtMax.Month, dtMax.Day, startHour, 0, 0);
                }

                for (int i = 0; i < 7; i++)
                {
                    if (!workdays[(int)dtMax.DayOfWeek])
                    {
                        dtMax = dtMax.AddDays(1);
                    }
                    else
                        break;
                }

                try
                {
                    if (drProc["StartDate"] == null || drProc["StartDate"].ToString() == "" || DateTime.Parse(drProc["StartDate"].ToString()).ToShortDateString() != dtMax.ToShortDateString())
                        drProc["TaskChanged"] = "Y";
                }
                catch { }
                drProc["StartDate"] = dtMax.ToString();
                try
                {
                    DateTime fn = getFinish(drProc["StartDate"].ToString(), drProc["Duration"].ToString());
                    if (fn != DateTime.MinValue)
                        drProc["DueDate"] = fn;
                    else
                        drProc["DueDate"] = null;
                }
                catch { }
            }

            return drProc.Table;
        }

        private DataTable calcDurations(SPListItem li, DataRow drParent)
        {
            if (li.Fields.ContainsField("Duration") && li.Fields.ContainsField("StartDate") && li.Fields.ContainsField("DueDate"))
            {
                if (li[li.Fields.GetFieldByInternalName("StartDate").Id] != null && li[li.Fields.GetFieldByInternalName("DueDate").Id] != null)
                    li[li.Fields.GetFieldByInternalName("Duration").Id] = getDuration(li[li.Fields.GetFieldByInternalName("StartDate").Id].ToString(), li[li.Fields.GetFieldByInternalName("DueDate").Id].ToString());
            }

            return drParent.Table;
        }

        private string getDuration(string start, string finish)
        {
            try
            {
                if (start != "" && finish != "")
                {
                    DateTime dtStart = DateTime.Parse(start);
                    DateTime dtFinish = DateTime.Parse(finish);

                    double dur = ((TimeSpan)(dtFinish - dtStart)).Days;

                    dur++;

                    dur -= Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.WeekOfYear, dtStart, dtFinish, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFullWeek) * nonWork;
                    

                    return dur.ToString();
                }
            }
            catch { }
            return null;
        }

        private DataTable calcChildren(DataRow[] drChildren, SPListItem li, DataRow drParent, SPList lstProjectCenter)
        {
            Hashtable hshCalcs = new Hashtable();
            foreach (string field in arrFields)
            {
                try
                {
                    string[] fieldata = field.Split('|');
                    hshCalcs.Add(fieldata[0], "");
                }
                catch { }
            }

            double totalDuration = 0;
            string durationField = "";

            foreach (DataRow dr in drChildren)
            {
                foreach (string field in arrFields)
                {
                    try
                    {
                        string[] fieldata = field.Split('|');
                        SPField spfield = list.Fields.GetFieldByInternalName(fieldata[0]);
                        string previousval = hshCalcs[fieldata[0]].ToString();
                        string newval = dr[fieldata[0]].ToString();
                        
                        if (fieldata[0] == "PercentComplete")
                        {
                            if (dr.Table.Columns.Contains(fieldata[1]))
                            {
                                durationField = fieldata[1];
                                totalDuration += double.Parse(dr[fieldata[1]].ToString());
                            }
                        }
                        else
                        {
                            switch (fieldata[1])
                            {
                                case "Min":
                                    if (newval == "") { }
                                    else if (previousval == "")
                                        hshCalcs[fieldata[0]] = newval;
                                    else
                                    {
                                        if (spfield.Type == SPFieldType.Currency || spfield.Type == SPFieldType.Number)
                                        {
                                            try
                                            {
                                                double prev = double.Parse(previousval);
                                                double newVal = double.Parse(newval);
                                                if (newVal < prev)
                                                    prev = newVal;
                                                newval = prev.ToString();
                                            }
                                            catch { }
                                        }
                                        else if (spfield.Type == SPFieldType.DateTime)
                                        {
                                            try
                                            {
                                                DateTime prev = DateTime.Parse(previousval);
                                                DateTime newVal = DateTime.Parse(newval);
                                                if (newVal < prev)
                                                    prev = newVal;
                                                newval = prev.ToString();
                                            }
                                            catch { }
                                        }
                                        hshCalcs[fieldata[0]] = newval;
                                    }
                                    break;
                                case "Max":

                                    if (newval == "") { }
                                    else if (previousval == "")
                                        hshCalcs[fieldata[0]] = newval;
                                    else
                                    {
                                        if (spfield.Type == SPFieldType.Currency || spfield.Type == SPFieldType.Number)
                                        {
                                            try
                                            {
                                                double prev = double.Parse(previousval);
                                                double newVal = double.Parse(newval);
                                                if (newVal > prev)
                                                    prev = newVal;
                                                newval = prev.ToString();
                                            }
                                            catch { }
                                        }
                                        else if (spfield.Type == SPFieldType.DateTime)
                                        {
                                            try
                                            {
                                                DateTime prev = DateTime.Parse(previousval);
                                                DateTime newVal = DateTime.Parse(newval);
                                                if (newVal > prev)
                                                    prev = newVal;
                                                newval = prev.ToString();
                                            }
                                            catch { }
                                        }
                                        hshCalcs[fieldata[0]] = newval;
                                    }
                                    break;
                                case "Sum":
                                    if (newval == "") { }
                                    else if (previousval == "")
                                        hshCalcs[fieldata[0]] = newval;
                                    else
                                    {
                                        if (spfield.Type == SPFieldType.Currency || spfield.Type == SPFieldType.Number)
                                        {
                                            double prev = double.Parse(previousval);
                                            double newVal = double.Parse(newval);
                                            prev += newVal;
                                            hshCalcs[fieldata[0]] = prev.ToString(); ;
                                        }
                                    }
                                    break;
                                case "Avg":

                                    if (newval == "") { }
                                    else
                                    {
                                        if (spfield.Type == SPFieldType.Currency || spfield.Type == SPFieldType.Number)
                                        {
                                            double newVal = double.Parse(newval);
                                            hshCalcs[fieldata[0]] += "," + newval;
                                        }
                                    }
                                    break;
                            };
                        }
                    }
                    catch { }
                }
            }
            double totalPercent = 0;
            if (durationField != "" && totalDuration != 0)
            {
                foreach (DataRow dr in drChildren)
                {
                    try
                    {
                        totalPercent += double.Parse(dr[durationField].ToString()) / totalDuration * double.Parse(dr["PercentComplete"].ToString());
                    }
                    catch { }
                }
            }

            foreach (string field in arrFields)
            {
                try
                {
                    string[] fieldata = field.Split('|');
                    string data = hshCalcs[fieldata[0]].ToString();
                    string liField = fieldata[0];
                    if (li.ParentList.Title == lstProjectCenter.Title)
                    {
                        if (fieldata[0] == "StartDate")
                            liField = "Start";
                        if (fieldata[0] == "DueDate")
                            liField = "Finish";
                    }
                    SPField f = li.ParentList.Fields.GetFieldByInternalName(liField);
                    if (fieldata[0] == "PercentComplete")
                        data = totalPercent.ToString(culture);
                    if (fieldata[1] == "Avg")
                    {
                        string[] numbers = data.Split(',');
                        double total = 0;
                        if (numbers.Length > 1)
                        {
                            foreach (string number in numbers)
                            {
                                if (number != "")
                                {
                                    try
                                    {
                                        total += double.Parse(number);
                                    }
                                    catch { }
                                }
                            }
                            total = total / (numbers.Length - 1);
                            data = total.ToString();
                        }
                        else
                            data = "0";
                    }
                    if (data == "")
                        li[liField] = null;
                    else
                    {
                        switch (f.Type)
                        {
                            case SPFieldType.DateTime:
                                DateTime dt = DateTime.Parse(data);
                                li[liField] = dt;
                                break;
                            default:
                                li[liField] = data;
                                break;
                        };
                        
                    }
                    drParent[fieldata[0]] = data;
                }
                catch { }
            }
            
            return drParent.Table;
        }

        private DataTable calcItem(SPListItem li, DataRow drItem)
        {
            if (li.Fields.ContainsField("DueDate"))
            {
                if (getField(li, "Duration") == "")
                {
                    if (li.ParentList.Fields.ContainsField("Duration"))
                    {
                        li["Duration"] = getDuration(getField(li, "StartDate"), getField(li, "DueDate"));

                        if (drItem.Table.Columns.Contains("Duration"))
                        {
                            if (li["Duration"] == null)
                                drItem["Duration"] = DBNull.Value;
                            else
                                drItem["Duration"] = li["Duration"];
                        }
                    }
                }
                else
                {
                    DateTime fn = getFinish(getField(li, "StartDate"), getField(li, "Duration"));
                    if (fn != DateTime.MinValue)
                        li["DueDate"] = fn;
                    else
                        li["DueDate"] = null;

                    if (drItem.Table.Columns.Contains("DueDate"))
                    {
                        if (li["DueDate"] == null)
                            drItem["DueDate"] = DBNull.Value;
                        else
                            drItem["DueDate"] = li["DueDate"];
                    }
                }
                
            }

            if (li.Fields.ContainsField("ActualFinish"))
            {
                if (getField(li, "ActualDuration") == "")
                {
                    li["ActualDuration"] = getDuration(getField(li, "ActualStart"), getField(li, "ActualFinish"));

                    if (drItem.Table.Columns.Contains("ActualDuration"))
                    {
                        if (li["ActualDuration"] == null)
                            drItem["ActualDuration"] = DBNull.Value;
                        else
                            drItem["ActualDuration"] = li["ActualDuration"];
                    }
                }
                else
                {
                    DateTime fn = getFinish(getField(li, "ActualStart"), getField(li, "ActualDuration"));
                    if (fn != DateTime.MinValue)
                        li["ActualFinish"] = fn;
                    else
                        li["ActualFinish"] = null;

                    if (drItem.Table.Columns.Contains("ActualFinish"))
                    {
                        if (li["ActualFinish"] == null)
                            drItem["ActualFinish"] = DBNull.Value;
                        else
                            drItem["ActualFinish"] = li["ActualFinish"];
                    }
                }
            }

            li.ParentList.ParentWeb.AllowUnsafeUpdates = true;
            li.ParentList.ParentWeb.Site.AllowUnsafeUpdates = true;
            li.SystemUpdate();
            return drItem.Table;
        }

        private DateTime getFinish(string start, string duration)
        {
            try
            {
                if (start != "" && duration == "0")
                {
                    return DateTime.Parse(start);
                }
                else if (start != "" && duration != "")
                {
                    DateTime dtStart = DateTime.Parse(start);
                    double dur = double.Parse(duration);

                    dur--;
                    double rdur = Math.Floor(dur * 7 / (7 - nonWork));


                    double weeks = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.WeekOfYear, dtStart, dtStart.AddDays(rdur), Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1);

                    if (weeks > 0 && nonWork != 0)
                    {
                        dur += nonWork * weeks;
                    }

                    DateTime dtTemp = dtStart.AddDays(dur);

                    int counted = 0;

                    for (int i = 0; i < 7; i++)
                    {
                        if (!workdays[(int)(dtTemp.AddDays(i)).DayOfWeek])
                        {
                            counted++;
                            dur++;
                        }
                        else
                            break;
                    }

                    //dur += (nonWork - counted);


                    //if (dtTemp.DayOfWeek == DayOfWeek.Saturday)
                    //    dur+=2;
                    //if (dtTemp.DayOfWeek == DayOfWeek.Sunday)
                    //    dur++;

                    DateTime dtNew = dtStart.AddDays(dur);
                    return new DateTime(dtNew.Year, dtNew.Month, dtNew.Day, endHour, 0, 0);
                }
            }
            catch { }
            return DateTime.MinValue;
        }

        private static string getField(SPListItem li, string field)
        {
            try
            {
                return li[field].ToString();
            }
            catch { }
            return "";
        }
    }
}
