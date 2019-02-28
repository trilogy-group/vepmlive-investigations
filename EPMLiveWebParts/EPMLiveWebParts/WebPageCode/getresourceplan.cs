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
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using static System.Diagnostics.Trace;

namespace EPMLiveWebParts
{
    public partial class getresourceplan : getgantttasks
    {
        private string resources;

        public override void getParams(SPWeb curWeb)
        {
            GetParams(
                str =>
                {
                    usePopup = false;
                    bool.TryParse(str, out usePopup);
                },
                Request,
                hshLists,
                ref isResourcePlan,
                ref strlist,
                ref strview,
                ref start,
                ref finish,
                ref progress,
                ref wbsfield,
                ref milestone,
                ref executive,
                ref information,
                ref linktype,
                ref rolluplists,
                ref filterfield,
                ref filtervalue,
                ref rollupsites,
                ref resources);
        }

        internal static void GetParams(
            Action<string> usePopAction,
            HttpRequest httpRequest,
            Hashtable hashLists,
            ref bool isResourcePlan,
            ref string strList,
            ref string strView,
            ref string start,
            ref string finish,
            ref string progress,
            ref string wbsField,
            ref string milestone,
            ref string executive,
            ref string information,
            ref string linkType,
            ref string[] rollUpLists,
            ref string filterField,
            ref string filterValue,
            ref string[] rollUpSites,
            ref string resources)
        {
            try
            {
                isResourcePlan = true;
                var encodedDataAsBytes = Convert.FromBase64String(httpRequest["data"]);
                var data = Encoding.ASCII.GetString(encodedDataAsBytes).Split('\n');
                strList = data[0];
                strView = data[1];
                start = data[2];
                finish = data[3];
                progress = data[4];
                wbsField = data[5];
                milestone = data[6];
                executive = "on";
                information = data[8];
                linkType = data[9];
                if (!string.IsNullOrWhiteSpace(data[10]))
                {
                    var tRollupLists = data[10].Split(',');
                    rollUpLists = new string[tRollupLists.Length];
                    for (var i = 0; i < tRollupLists.Length; i++)
                    {
                        var rollUpList = tRollupLists[i].Split('|');
                        rollUpLists[i] = rollUpList[0];
                        var icon = string.Empty;
                        try
                        {
                            icon = rollUpList[1];
                        }
                        catch (Exception ex)
                        {
                            TraceError("Exception Suppressed {0}", ex);
                        }
                        hashLists.Add(rollUpLists[i], icon);
                    }
                }

                filterField = data[11];
                filterValue = data[12];

                if (!string.IsNullOrWhiteSpace(data[13]))
                {
                    rollUpSites = data[13].Split(',');
                }
                resources = data[14];

                usePopAction?.Invoke(data[15]);
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}", ex);
            }
        }

        protected override void outputData()
        {
            foreach (XmlNode nd in docComplete.SelectNodes("//Bar"))
            {
                try
                {
                    if (nd.Attributes["Name"].Value == "Summary" || nd.Attributes["EPMLiveRW"].Value == "True")
                    {
                        XmlAttribute attrMove = docComplete.CreateAttribute("CanMove");
                        attrMove.Value = "1";
                        nd.Attributes.Append(attrMove);

                        XmlAttribute attrResize = docComplete.CreateAttribute("CanResize");
                        attrResize.Value = "1";
                        nd.Attributes.Append(attrResize);
                    }
                }
                catch { }

                try
                {
                    double work = 0;

                    try
                    {
                        DateTime st = DateTime.Parse(nd.Attributes["Start"].Value);
                        DateTime fn = DateTime.Parse(nd.Attributes["End"].Value);
                        TimeSpan tsReal = fn - st;

                        //////TimeSpan tsFull = new DateTime(fn.Year, fn.Month, fn.Day, 23, 59, 59) - new DateTime(st.Year, st.Month, st.Day, 0, 0, 0);

                        //////double totalDays = Math.Floor(tsFull.TotalDays) + 1;
                        //////double actualDays = totalDays;

                        //////if (totalDays > 7)
                        //////{
                        //////    double weekdiff = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.WeekOfYear, st, fn, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFullWeek);
                        //////    double nonworkingDays = 0;
                        //////    double initialNonWork = 0;
                        //////    int j = 0;
                        //////    for (j = 0; st.AddDays(j).DayOfWeek != fn.DayOfWeek; j++)
                        //////    {
                        //////        if (!workdays[(int)st.AddDays(j).DayOfWeek])
                        //////            initialNonWork++;
                        //////    }

                        //////    for (int i = 1; i < 7; i++)
                        //////    {
                        //////        if (!workdays[(int)st.AddDays(i+j).DayOfWeek])
                        //////            nonworkingDays++;
                        //////    }

                        //////    actualDays -= (nonworkingDays * weekdiff + initialNonWork);
                        //////}
                        //////else
                        //////{
                            
                        //////    for (int i = 0; i < totalDays; i++)
                        //////    {
                        //////        if (!workdays[(int)st.AddDays(i).DayOfWeek])
                        //////            actualDays--;
                        //////    }


                        //////}

                        //weekdiff *= nonWork;

                        //if (weekdiff != 0)
                        //{
                        //    double daydiff = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.DayOfYear, st, fn, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFullWeek);

                        //    mult = daydiff / (daydiff - weekdiff);
                        //}

                        

                        
                        work = double.Parse(nd.Attributes["EPMLiveWork"].Value);

                        //work per resource
                        //work = ((totalDays / actualDays) * (work / filterResources.Count)) / (endHour - startHour - 1);

                        //work = work / (actualDays * (endHour - startHour - 1)) * tsReal.TotalDays;

                        if(tsReal.TotalDays >= 1)
                            work = work / (endHour - startHour - 1);
                        else
                            work = work / 24;

                        work = work / filterResources.Count;
                        //if (work > 1)
                        //    work -= (24.0 - (endHour - startHour)) / 24.0;
                        //else if (work > 0)
                        //    work *= (endHour - startHour) / 24.0;
                        //
                        //double totalAvailableHours = ts.TotalHours - workingDays * weekdiff;
                        //
                        //if (weekdiff == 0)
                        //{
                        //    for (int i = 0; st.AddDays(i) < fn; i++)
                        //    {
                        //        if (!workdays[(int)st.AddDays(i).DayOfWeek])
                        //            totalAvailableHours--;
                        //    }
                        //}
                    }
                    catch { }
                    //work = 2;
                    //((endHour - startHour) * filterResources.Count) * mult;

                    //Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.WeekOfYear
                    if (work != 0)
                    {
                        //work = 2;
                        XmlAttribute attrEffort = docComplete.CreateAttribute("Effort");
                        attrEffort.Value = work.ToString();
                        nd.Attributes.Append(attrEffort);

                        attrEffort = docComplete.CreateAttribute("KeepWorkingCount");
                        attrEffort.Value = work.ToString();
                        nd.Attributes.Append(attrEffort);
                    }
                    try
                    {
                        nd.Attributes.Remove(nd.Attributes["EPMLiveRW"]);
                        nd.Attributes.Remove(nd.Attributes["EPMLiveWork"]);
                    }
                    catch { }
                    //work.ToString();
                }
                catch { }
            }

            base.outputData();
        }
        private string getAssignedTo()
        {
            filterResources = new ArrayList();
            string[] arrResources = resources.Replace(";#","\n").Split('\n');
            string strAssignedTo = "";
            foreach (string resource in arrResources)
            {
                string res = HttpUtility.UrlDecode(resource);
                filterResources.Add(res);
                if (strAssignedTo == "")
                    strAssignedTo = "<Eq><FieldRef Name=\"AssignedTo\" /><Value Type=\"User\">" + res + "</Value></Eq>";
                else
                    strAssignedTo = "<Or>" + strAssignedTo + "<Eq><FieldRef Name=\"AssignedTo\" /><Value Type=\"User\">" + res + "</Value></Eq>" + "</Or>";
            }
            return strAssignedTo;
        }
        public override string getQuery()
        {
            string query = base.getQuery();

            XmlDocument docQuery = new XmlDocument();
            docQuery.LoadXml("<Query>" + query + "</Query>");

            XmlNode ndWhere = docQuery.SelectSingleNode("//Where");
            if (ndWhere != null)
            {
                XmlNode ndCurWhere = ndWhere.FirstChild;

                XmlNode ndNew = docQuery.CreateNode(XmlNodeType.Element, "And", docQuery.NamespaceURI);
                ndNew.InnerXml = getAssignedTo();
                ndNew.AppendChild(ndCurWhere);

                ndWhere.AppendChild(ndNew);
            }
            else
            {
                ndWhere = docQuery.CreateNode(XmlNodeType.Element, "Where", docQuery.NamespaceURI);
                ndWhere.InnerXml = getAssignedTo();


                docQuery.FirstChild.AppendChild(ndWhere);
            }
            query = docQuery.FirstChild.InnerXml;

            return query;
        }
    }
}
