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
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;

namespace EPMLiveWorkPlanner
{
    public partial class updatetask : System.Web.UI.Page
    {
        protected string output;
        protected bool useResourcePool;
        private Hashtable hshResources = new Hashtable();

        int startHour;
        int endHour;

        SPView view;
        SortedList slResources = new SortedList();

        StringBuilder sbUpdatedRows = new StringBuilder();

        SPList lstProjectCenter;
        SPList lstTaskCenter;
        string sResourcePoolUrl;
        string sResourceList;
        string wpFields;
        SPWeb resWeb;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            {

                web.AllowUnsafeUpdates = true;

                string calc = "";
                string baseline = "";

                Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
                if (lockWeb == Guid.Empty || lockWeb == web.ID)
                {
                    lstProjectCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPProjectCenter")];
                    lstTaskCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPTaskCenter")];
                    try
                    {
                        useResourcePool = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPUseResPool"));
                    }
                    catch { }
                    sResourcePoolUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                    sResourceList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool");
                    wpFields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWorkPlannerFields");
                }
                else
                {
                    SPSite site = SPContext.Current.Site;
                    {
                        using (SPWeb w = site.OpenWeb(lockWeb))
                        {
                            lstProjectCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPProjectCenter")];
                            lstTaskCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPTaskCenter")];
                            try
                            {
                                useResourcePool = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPUseResPool"));
                            }
                            catch { }
                            sResourcePoolUrl = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourceURL", true, false);
                            sResourceList = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourcePool");
                            wpFields = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWorkPlannerFields");
                        }
                    }
                }

                //string url = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWorkPlannerURL");
                //string resURL = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");
                
                //if (url == "")
                //    url = web.Url;
                //if (resURL != "")
                //    useResourcePool = true;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    startHour = web.Site.RootWeb.RegionalSettings.WorkDayStartHour / 60;
                    endHour = web.Site.RootWeb.RegionalSettings.WorkDayEndHour / 60;

                });

                //using (SPSite oSiteCollection = new SPSite(url))
                //{
                //    using (SPWeb oWebsite = oSiteCollection.OpenWeb())
                //    {
                //        SPWeb workplannerweb = web;
                //        if (oWebsite.Url.ToLower() == url.ToLower())
                //            workplannerweb = oWebsite;
                //        if (workplannerweb.Properties["EPMLiveWPUseResource"] == "True")
                //            useResourcePool = true;
                //    }
                //}

                try
                {

                    if (useResourcePool)
                    {
                        //string resURL = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");

                        //if (resURL == "")
                        //    resURL = web.Url;
                        using (SPSite oSiteCollection = new SPSite(sResourcePoolUrl))
                        {
                            using (SPWeb oWebsite = oSiteCollection.OpenWeb())
                            {
                                resWeb = oWebsite;
                                try
                                {
                                    SPList resList = oWebsite.Lists[sResourceList];
                                    foreach (SPListItem li in resList.Items)
                                    {
                                        try
                                        {
                                            if (!slResources.Contains(li.Title))
                                                slResources.Add(li.Title, li.ID);
                                            if (li["SharePointAccount"].ToString() != "")
                                                hshResources.Add(li.ID, li["SharePointAccount"].ToString());
                                        }
                                        catch { }
                                    }
                                }
                                catch { }

                            }
                        }
                    }
                }
                catch { }


                try
                {
                    if (Request["savebaseline"] == "" || Request["savebaseline"] == null)
                    {
                        if (Request["calc"] == "1")
                        {
                            if (Request["ids"] == null)
                                Response.Write("Success");
                            calc = "True";
                        }
                        else
                        {
                            try
                            {
                                calc = lstProjectCenter.GetItemById(int.Parse(Request["projectId"]))["AutoCalculate"].ToString();
                            }
                            catch
                            {
                                calc = "true";
                            }
                        }
                    }
                    else
                    {
                        if (Request["ids"] == null)
                            Response.Write("Success");
                        baseline = Request["savebaseline"];
                    }
                }
                catch { }

                view = lstTaskCenter.Views[new Guid(Request["view"].ToString())];

                if (Request["ids"] != null)
                {
                    Response.ContentType = "text/xml";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;


                    string[] ids = Request["ids"].Split(',');


                    if (!lstTaskCenter.Fields.ContainsField("WorkPlanUpdate"))
                    {
                        lstTaskCenter.Fields.Add("WorkPlanUpdate", SPFieldType.Boolean, false);
                        SPField f = lstTaskCenter.Fields["WorkPlanUpdate"];
                        f.Hidden = true;
                        f.DefaultValue = "0";
                        f.Update();
                    }

                    output = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><data>";

                    foreach (string id in ids)
                    {
                        if (id != "")
                        {
                            processItem(id, web, lstTaskCenter, view);
                            
                        }
                    }

                    //output += "<action type='alldatareturned'><rows>";
                    //output += sbUpdatedRows;
                    //output += "</rows></action>";
                    output += "</data>";
                }

                if (calc.ToLower() == "true")
                {
                    TaskCenterCalculate tc = new TaskCenterCalculate();

                    tc.Calculate(lstTaskCenter, Request["projectId"], lstProjectCenter, wpFields);
                }
                if (baseline == "1")
                {
                    TaskCenterCalculate tc = new TaskCenterCalculate();

                    tc.setBaseline(lstTaskCenter, Request["projectId"], lstProjectCenter);
                }
            }
            if (resWeb != null)
                resWeb.Close();
        }

        private void processItem(string gr_id, SPWeb web, SPList list, SPView  view)
        {
            
            string status = "";
            string ignore = "";
            string moved = "";
            string SharePointId = "";
            string predecessors = "";
            try
            {
                status = Request[gr_id + "_!nativeeditor_status"].ToString();
            }
            catch { }
            try
            {
                ignore = Request[gr_id + "_ignore"].ToString();
            }
            catch { }
            try
            {
                moved = Request[gr_id + "_moved"].ToString();
            }
            catch { }
            try
            {
                SharePointId = Request[gr_id + "_SharePointId"].ToString();
            }
            catch { }
            try
            {
                predecessors = Request[gr_id + "_Predecessors"].ToString();
            }
            catch { }

            System.Globalization.NumberFormatInfo nf = new System.Globalization.NumberFormatInfo();
            nf.NumberDecimalSeparator = ".";
            SPListItem li;

            if (gr_id == "_SummaryTask_")
            {
                output += "<action type='update' sid='" + gr_id + "' tid='" + gr_id + "'/>";
            }
            else if (ignore == "1")
            {
                output += "<action type='delete' sid='" + gr_id + "'/>";
            }
            else
            {
                list.ParentWeb.AllowUnsafeUpdates = true;
                if (status.Contains("inserted") && moved == "")
                {
                    li = list.Items.Add();
                    li["Project"] = Request["projectId"];
                }
                else
                {
                    li = list.GetItemById(int.Parse(SharePointId));
                }

                if (status == "deleted")
                {
                    list.Items.DeleteItemById(int.Parse(SharePointId));
                    output += "<action type='delete' sid='" + gr_id + "'/>";
                }
                else
                {
                    if (li.Fields.ContainsField("IsAssignment"))
                    {
                        li["IsAssignment"] = "0";
                    }
                    li["WBS"] = Request[gr_id + "_WBS"];
                    if (li.Fields.ContainsField("OutlineNumber"))
                        li["OutlineNumber"] = Request[gr_id + "_WBS"];

                    li["taskorder"] = Request[gr_id + "_taskorder"];
                    li["WorkPlanUpdate"] = "1";
                    try
                    {
                        if (list.Fields.GetFieldByInternalName("Predecessors") != null)
                        {
                            li["Predecessors"] = predecessors;
                        }
                    }
                    catch { }

                    SPViewFieldCollection vfc = view.ViewFields;

                    int counter = 1;

                    try
                    {
                        foreach (string f in vfc)
                        {
                            string columnName = gr_id + "_c" + counter.ToString();
                            SPField field = list.Fields.GetFieldByInternalName(f);
                            if (field.InternalName == "WBS" || field.InternalName == "taskorder" || field.InternalName == "Predecessors" || field.InternalName == "_ModerationStatus")
                            {

                            }
                            else if (field.InternalName == "LinkTitle")
                            {
                                li["Title"] = Request[columnName].ToString().Trim();
                            }
                            else if (field.ReadOnlyField)
                            {

                            }
                            else if (field.InternalName == "OutlineNumber")
                            {

                            }
                            else if (useResourcePool && (field.InternalName == "ResourceNames" || field.InternalName == "AssignedTo"))
                            {
                                string []resources = Request[columnName].ToString().Replace(";#", "\n").Split('\n');
                                string resString = "";

                                SPFieldUserValueCollection lvc = new SPFieldUserValueCollection();

                                if (resources.Length > 1)
                                {
                                    for (int i = 0; i < resources.Length; i = i + 2)
                                    {
                                        string res = resources[i];
                                        if (hshResources.Contains(int.Parse(res)))
                                        {
                                            try
                                            {
                                                SPFieldLookupValue lv = new SPFieldLookupValue(hshResources[int.Parse(res)].ToString());
                                                SPUser u = resWeb.SiteUsers.GetByID(lv.LookupId);
                                                SPUser newUser = null;
                                                try
                                                {
                                                     newUser = web.SiteUsers[u.LoginName];
                                                }
                                                catch { }
                                                if (newUser == null)
                                                {
                                                    try
                                                    {
                                                        web.SiteUsers.Add(u.LoginName, u.Email, u.Name, u.Notes);
                                                        newUser = web.SiteUsers[u.LoginName];
                                                    }
                                                    catch { }
                                                }
                                                if (newUser != null)
                                                {
                                                    SPFieldUserValue uv = new SPFieldUserValue(web, newUser.ID, newUser.Name);

                                                    lvc.Add(uv);
                                                }
                                            }
                                            catch { }
                                        }
                                        resString += ", " + resources[i + 1];
                                    }
                                }
                                //SPFieldLookupValueCollection lvcTemp = new SPFieldLookupValueCollection(resources);
                                

                                //foreach (SPFieldLookupValue lvTemp in lvcTemp)
                                //{
                                //    resString += ", " + lvTemp.LookupValue;
                                //    if (hshResources.Contains(lvTemp.LookupId))
                                //    {
                                //        lvc.Add(new SPFieldLookupValue(hshResources[lvTemp.LookupValue].ToString()));
                                //    }
                                //}

                                if (resString.Length > 2)
                                    resString = resString.Substring(2);

                                if (list.Fields.ContainsField("AssignedTo"))
                                    li[list.Fields.GetFieldByInternalName("AssignedTo").Id] = lvc;

                                li[list.Fields.GetFieldByInternalName("ResourceNames").Id] = resString;
                            }
                            else
                            {
                                switch (field.Type)
                                {
                                    case SPFieldType.Calculated:
                                        break;
                                    case SPFieldType.User:
                                        //if (field.TypeAsString == "UserMulti")
                                        //{
                                        //    string regExp = @"\d+\s-\s[^,]*";
                                        //    string ldata = Request[columnName].ToString();

                                        //    MatchCollection mc = Regex.Matches(ldata, regExp);
                                        //    string data = "";
                                        //    try
                                        //    {
                                        //        foreach (Match m in mc)
                                        //        {
                                        //            string val = m.Value;
                                        //            int index = val.IndexOf(" - ");
                                        //            val = val.Substring(0, index) + ";#" + val.Substring(index + 3).Replace(";", ",");
                                        //            data += ";#" + val;
                                        //        }
                                        //        data = data.Substring(2);
                                        //    }
                                        //    catch { }

                                        //    li[field.Id] = data;
                                        //}
                                        //else
                                        //{
                                        //    li[field.Id] = Request[columnName].ToString();
                                        //}
                                        string valu = Request[columnName].ToString();
                                        if (valu == "")
                                        {
                                            li[field.Id] = null;
                                        }
                                        else
                                        {
                                            if (field.TypeAsString == "UserMulti")
                                            {
                                                string[] sUsers = valu.Split('\n');
                                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection();
                                                for (int i = 0; i < sUsers.Length; i = i + 2)
                                                {
                                                    SPUser u = web.AllUsers[sUsers[i]];
                                                    SPFieldUserValue uv = new SPFieldUserValue(web, u.ID + ";#" + u.Name);
                                                    uvc.Add(uv);
                                                }
                                                li[field.Id] = uvc;
                                            }
                                            else
                                            {
                                                string[] sUsers = valu.Split('\n');
                                                if (sUsers.Length > 0)
                                                {
                                                    SPUser u = web.AllUsers[sUsers[0]];
                                                    SPFieldUserValue uv = new SPFieldUserValue(web, u.ID + ";#" + u.Name);
                                                    li[field.Id] = uv;
                                                }
                                            }
                                        }
                                        break;
                                    case SPFieldType.Currency:
                                        if (Request[columnName].ToString() == "")
                                        {
                                            li[field.Id] = null;
                                        }
                                        else
                                        {
                                            
                                            float fl = float.Parse(Request[columnName].ToString(), nf);
                                            li[field.Id] = fl;
                                        }
                                        break;
                                    case SPFieldType.Number:
                                        if (Request[columnName].ToString() == "")
                                        {
                                            li[field.Id] = null;
                                        }
                                        else
                                        {
                                            if (field.SchemaXml.Contains("Percentage=\"TRUE\""))
                                            {
                                                try
                                                {
                                                    float val = float.Parse(Request[columnName].ToString(), nf) / 100;
                                                    li[field.Id] = val;
                                                }
                                                catch { }

                                            }
                                            else
                                            {
                                                float fl = float.Parse(Request[columnName].ToString(), nf);
                                                li[field.Id] = fl;
                                            }
                                        }
                                        break;
                                    case SPFieldType.MultiChoice:

                                        string[] choices = Request[columnName].Split('\n');
                                        string cval = ";#";
                                        foreach (string choice in choices)
                                        {
                                            cval += choice.Replace(";#", "\n").Split('\n')[0] + ";#";
                                        }
                                        li[field.Id] = cval;
                                        break;
                                    case SPFieldType.Lookup:
                                        //if (field.SchemaXml.Contains("Mult=\"TRUE\""))
                                        //{
                                        //    string regExp = @"\d+\s-\s[^,]*";
                                        //    string ldata = Request[columnName].ToString();

                                        //    MatchCollection mc = Regex.Matches(ldata, regExp);
                                        //    string data = "";
                                        //    try
                                        //    {
                                        //        foreach (Match m in mc)
                                        //        {
                                        //            string val = m.Value;
                                        //            int index = val.IndexOf(" - ");
                                        //            val = val.Substring(0, index) + ";#" + val.Substring(index + 3);
                                        //            data += ";#" + val;
                                        //        }
                                        //        data = data.Substring(2);
                                        //    }
                                        //    catch { }

                                        //    li[field.Id] = data;
                                        //}
                                        //else
                                        //{
                                        //    li[field.Id] = Request[columnName].ToString();
                                        //}
                                        li[field.Id] = Request[columnName].Replace("\n", ";#");
                                        break;
                                    case SPFieldType.DateTime:
                                        if (Request[columnName].ToString() == "")
                                            li[field.Id] = null;
                                        else
                                        {
                                            DateTime dt = DateTime.Parse(Request[columnName].ToString());
                                            if (field.InternalName == "StartDate")
                                            {
                                                dt = new DateTime(dt.Year, dt.Month, dt.Day, startHour, 0, 0);

                                            }
                                            else if (field.InternalName == "DueDate")
                                            {
                                                dt = new DateTime(dt.Year, dt.Month, dt.Day, endHour, 0, 0);
                                            }
                                            li[field.Id] = dt;
                                        }
                                        break;
                                    default:
                                        //if (Request[columnName].ToString() != "")
                                        {
                                            string data = HttpUtility.HtmlDecode(Request[columnName].ToString());
                                            if (data == "")
                                                li[field.Id] = null;
                                            else
                                                li[field.Id] = data;
                                        }
                                        break;
                                };
                            }
                            counter++;
                        }
                        if (li.ModerationInformation != null)
                            li.ModerationInformation.Status = SPModerationStatusType.Approved;
                        li.ParentList.ParentWeb.AllowUnsafeUpdates = true;
                        li.ParentList.ParentWeb.Site.AllowUnsafeUpdates = true;

                        li.Update();

                        sbUpdatedRows.Append("<row id='" + gr_id + "'>");
                        sbUpdatedRows.Append("<userdata name='SharePointId'>" + li.ID + "</userdata>");
                        sbUpdatedRows.Append(getCellData(li));
                        sbUpdatedRows.Append("</row>");

                        if (status == "inserted" && moved == "")
                            output += "<action type='insert' sid='" + gr_id + "' tid='" + gr_id + "'/>";
                        else
                            output += "<action type='update' sid='" + gr_id + "' tid='" + gr_id + "'/>";
                    }
                    catch (Exception ex)
                    {
                        output += "<action type='error100' sid='" + gr_id + "'>" + ex.Message + "</action>";
                    }
                }
            }

        }

        private string getCellData(SPListItem li)
        {
            StringBuilder sb = new StringBuilder();
            SPViewFieldCollection vfc = view.ViewFields;

            System.Globalization.NumberFormatInfo nf = new System.Globalization.NumberFormatInfo();
            nf.NumberDecimalSeparator = ".";
            nf.NumberGroupSeparator = ",";

            sb.Append("<cell/>");
            foreach (string f in vfc)
            {
                try
                {
                    string strF = f;
                    if (li.ParentList.Title == lstProjectCenter.Title)
                    {
                        if (f == "StartDate")
                            strF = "Start";
                        if (f == "DueDate")
                            strF = "Finish";
                    }
                    SPField field = li.ParentList.Fields.GetFieldByInternalName(strF);
                    XmlDocument fieldXml = new XmlDocument();
                    fieldXml.LoadXml(field.SchemaXml);
                    string data = "";
                    try
                    {
                        data = li[field.Id].ToString();
                    }
                    catch { }
                    if (field.InternalName == "_ModerationStatus")
                    {
                        switch (li[field.Id].ToString())
                        {
                            case "0":
                                sb.Append("<cell>Approved</cell>");
                                break;
                            case "1":
                                sb.Append("<cell>Rejected</cell>");
                                break;
                            case "2":
                                sb.Append("<cell>Pending</cell>");
                                break;
                        };

                    }
                    else if (useResourcePool && field.InternalName == "ResourceNames")
                    {
                        string[] strResources = data.Split(',');
                        string strFinalResources = "";
                        foreach (string strResource in strResources)
                        {
                            if (slResources.Contains(strResource.Trim()))
                                strFinalResources += "\n" + slResources[strResource.Trim()].ToString() + ";#" + strResource.Trim();
                        }
                        if (strFinalResources.Length > 1)
                            strFinalResources = strFinalResources.Substring(1);
                        sb.Append("<cell><![CDATA[" + strFinalResources + "]]></cell>");
                    }
                    else if (field.InternalName != "LinkTitle" && field.InternalName != "Title")
                    {
                        string displayValue = "";
                        switch (field.Type)
                        {
                            case SPFieldType.User:

                                if (useResourcePool)
                                {
                                    SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(data);
                                    data = "";
                                    foreach (SPFieldLookupValue lv in lvc)
                                    {
                                        data += "," + lv.LookupValue;
                                    }
                                    if (data.Length > 1)
                                        data = data.Substring(1);
                                    sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                }
                                else
                                {
                                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.Web, data);

                                    foreach (SPFieldUserValue uv in uvc)
                                    {
                                        displayValue += "\n" + uv.User.LoginName + "\n" + uv.User.Name;
                                    }
                                    if (displayValue.Length > 1)
                                        displayValue = displayValue.Substring(1);

                                    //displayValue += "\t";

                                    //if (hshComboCells.Contains(field.InternalName + "-" + li.Web.ID.ToString()))
                                    //{
                                    //    displayValue += hshComboCells[field.InternalName + "-" + li.Web.ID.ToString()].ToString();
                                    //}
                                    //else
                                    //{
                                    //    string mode = "";
                                    //    try
                                    //    {
                                    //        mode = fieldXml.FirstChild.Attributes["UserSelectionMode"].Value;
                                    //    }
                                    //    catch { }

                                    //    string userList = getMultiUser(mode, li.Web);
                                    //    hshComboCells[field.InternalName + "-" + li.Web.ID.ToString()] = userList;
                                    //    displayValue += userList;
                                    //}
                                    sb.Append("<cell><![CDATA[" + displayValue + "]]></cell>");
                                }
                                break;
                            case SPFieldType.Currency:
                                try
                                {
                                    float fl = float.Parse(data);
                                    data = fl.ToString(nf); 
                                }
                                catch {  }
                                sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                break;
                            case SPFieldType.DateTime:
                                try
                                {
                                    data = DateTime.Parse(data).ToShortDateString();
                                }
                                catch { }
                                sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                break;
                            case SPFieldType.Number:
                                if (field.SchemaXml.Contains("Percentage=\"TRUE\""))
                                {
                                    try
                                    {
                                        float val = float.Parse(data) * 100;
                                        data = val.ToString(nf);

                                    }
                                    catch { }
                                    sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                }
                                else
                                {
                                    try
                                    {
                                        float val = float.Parse(data);
                                        data = val.ToString(nf);

                                    }
                                    catch { }
                                    sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                }
                                break;
                            case SPFieldType.Calculated:
                                data = li.Fields.GetFieldByInternalName(f).GetFieldValueAsText(data);
                                try
                                {
                                    data = data.Replace(";#", "\n").Split('\n')[1];
                                }
                                catch { }
                                if (field.Description == "Indicator")
                                {
                                    sb.Append("<cell><![CDATA[<img src=\"" + li.Web.Url + "/_layouts/images/" + data + "\">]]></cell>");
                                }
                                else
                                {
                                    sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                }

                                break;
                            case SPFieldType.MultiChoice:
                                //try
                                //{
                                //    data = data.Replace(";#", ",");
                                //    data = data.Substring(1, data.Length - 2);
                                //}
                                //catch { }
                                //sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                //string cval;
                                if (data != "")
                                {
                                    SPFieldMultiChoiceValue mcv = new SPFieldMultiChoiceValue(data);

                                    //string choices = data;
                                    //choices = choices.Replace(";#", "\n");
                                    for (int i = 0; i < mcv.Count; i++)
                                    {
                                        string choice = mcv[i];
                                        displayValue += "\n" + choice + ";#" + choice;
                                    }
                                    if (displayValue.Length > 1)
                                        displayValue = displayValue.Substring(1);
                                }
                                sb.Append("<cell><![CDATA[" + displayValue + "]]></cell>");
                                break;
                            case SPFieldType.Lookup:
                                if (field.TypeAsString == "LookupMulti")
                                {
                                    sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                }
                                else
                                {
                                    data = data.Replace(";#", "\n").Split('\n')[0];
                                    sb.Append("<cell><![CDATA[" + data + "]]></cell>");
                                }

                                break;
                            case SPFieldType.Boolean:
                                if (data == "True")
                                    sb.Append("<cell>1</cell>");
                                else
                                    sb.Append("<cell>0</cell>");
                                break;
                            default:
                                sb.Append("<cell><![CDATA[" + HttpUtility.HtmlEncode(data) + "]]></cell>");
                                break;
                        }
                    }
                    else
                    {
                        sb.Append("<cell image=\"blank.gif\"><![CDATA[" + li.Title + "]]></cell>");
                    }
                }
                catch { sb.Append("<cell/>"); }
            }
            return sb.ToString();
        }
    }
}