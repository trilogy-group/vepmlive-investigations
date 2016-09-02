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

namespace EPMLiveWebParts
{
    public partial class getresourcecheckplan : getgantttasks
    {
        private string resources;

        public override void getParams(SPWeb curWeb)
        {
            try
            {
                isResourcePlan = true;
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(Request["data"]);
                string[] data = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');
                strlist = data[0];
                strview = data[1];
                start = data[2];
                finish = data[3];
                progress = data[4];
                wbsfield = data[5];
                milestone = data[6];
                executive = "on";
                information = data[8];
                linktype = data[9];
                if (data[10] != "")
                {
                    string[] tRollupLists = data[10].Split(',');
                    rolluplists = new string[tRollupLists.Length];
                    for (int i = 0; i < tRollupLists.Length; i++)
                    {
                        string[] tRlist = tRollupLists[i].Split('|');
                        rolluplists[i] = tRlist[0];
                        string icon = "";
                        try
                        {
                            icon = tRlist[1];
                        }
                        catch { }
                        hshLists.Add(rolluplists[i], icon);
                    }
                }


                filterfield = data[11];
                filtervalue = data[12];

                if (data[13] != "")
                {
                    rollupsites = data[13].Split(',');
                }
                resources = data[14];

            }
            catch { }
        }
        protected override void outputData()
        {
            

            XmlNode ndItems = docComplete.SelectSingleNode("//Items");

            //=============
            string start = Request["startdate"];
            string finish = Request["enddate"];
            string ework = Request["work"];

            DateTime dtStart = DateTime.Parse(start);
            dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, startHour, 0, 0);
            DateTime dtFinish = DateTime.Parse(finish);
            dtFinish = new DateTime(dtFinish.Year, dtFinish.Month, dtFinish.Day, endHour, 0, 0);

            start = dtStart.ToString();
            finish = dtFinish.ToString();

            XmlNode ndTempItem = docComplete.CreateNode(XmlNodeType.Element, "Item", docComplete.NamespaceURI);
            foreach (string field in view.ViewFields)
            {
                SPField f = getRealField(list.Fields.GetFieldByInternalName(field));
                string value = "";
                switch (f.InternalName)
                {
                    case "Title":
                        value = "<b>" + Request["title"] + "</b>";
                        break;
                    case "StartDate":
                        value = Request["startdate"];
                        break;
                    case "DueDate":
                        value = Request["enddate"];
                        break;
                    case "Work":
                        value = Request["work"];
                        break;
                };
                XmlNode ndCell1 = docComplete.CreateNode(XmlNodeType.Element, "Cell", docComplete.NamespaceURI);
                XmlAttribute attrValue1 = docComplete.CreateAttribute("Value");
                attrValue1.Value = value;
                ndCell1.Attributes.Append(attrValue1);
                XmlAttribute attrValueFormat1 = docComplete.CreateAttribute("ValueFormat");
                attrValueFormat1.Value = "1";
                ndCell1.Attributes.Append(attrValueFormat1);
                ndTempItem.AppendChild(ndCell1);
            }

            XmlNode ndBars = docComplete.CreateNode(XmlNodeType.Element, "Bars", docComplete.NamespaceURI);
            ndTempItem.AppendChild(ndBars);
            
            XmlNode ndBar = docComplete.CreateNode(XmlNodeType.Element, "Bar", docComplete.NamespaceURI);
            XmlAttribute attrName = docComplete.CreateAttribute("Name");
            attrName.Value = "TaskP";
            ndBar.Attributes.Append(attrName);
            XmlAttribute attrStart = docComplete.CreateAttribute("Start");
            attrStart.Value = start;
            ndBar.Attributes.Append(attrStart);
            XmlAttribute attrEnd = docComplete.CreateAttribute("End");
            attrEnd.Value = finish;
            ndBar.Attributes.Append(attrEnd);
            XmlAttribute attrCanMove = docComplete.CreateAttribute("CanMove");
            attrCanMove.Value = "1";
            ndBar.Attributes.Append(attrCanMove);
            XmlAttribute attrCanResize = docComplete.CreateAttribute("CanResize");
            attrCanResize.Value = "1";
            ndBar.Attributes.Append(attrCanResize);
            XmlAttribute attrEffort1 = docComplete.CreateAttribute("EPMLiveWork");
            attrEffort1.Value = ework;
            ndBar.Attributes.Append(attrEffort1);

            XmlAttribute attrTemp = docComplete.CreateAttribute("EPMLiveTemp");
            attrTemp.Value = "1";
            ndBar.Attributes.Append(attrTemp);

            ndBars.AppendChild(ndBar);

            //<Bar Name="TaskP" Start="03/31/2009" End="04/07/2009" Caption="" Percent="0.05" HAlignCaption="18" EPMLiveWork="40" CanMove="0" CanResize="0" Effort="3.5" /> 

            //=============

            XmlNode ndNew = docComplete.CreateNode(XmlNodeType.Element, "Item", docComplete.NamespaceURI);
            XmlNode ndCell = docComplete.CreateNode(XmlNodeType.Element, "Cell", docComplete.NamespaceURI);
            XmlAttribute attrValue = docComplete.CreateAttribute("Value");
            attrValue.Value = "<b>All Other Work</b>";
            ndCell.Attributes.Append(attrValue);
            XmlAttribute attrValueFormat = docComplete.CreateAttribute("ValueFormat");
            attrValueFormat.Value = "1";
            ndCell.Attributes.Append(attrValueFormat);
            ndNew.AppendChild(ndCell);

            XmlNode ndNewItems = docComplete.CreateNode(XmlNodeType.Element, "Items", docComplete.NamespaceURI);
            ndNew.AppendChild(ndNewItems);

            foreach (XmlNode nd in docComplete.SelectNodes("/Content/Items/Item"))
            {
                ndNewItems.AppendChild(nd);
            }
            ndItems.AppendChild(ndTempItem);
            ndItems.AppendChild(ndNew);

            ndBars = docComplete.CreateNode(XmlNodeType.Element, "Bars", docComplete.NamespaceURI);
            ndTempItem.AppendChild(ndBars);

            ndBar = docComplete.CreateNode(XmlNodeType.Element, "Bar", docComplete.NamespaceURI);
            attrName = docComplete.CreateAttribute("Name");
            attrName.Value = "Summary";
            ndBar.Attributes.Append(attrName);

            ndBars.AppendChild(ndBar);

            ndNew.AppendChild(ndBars);


            foreach (XmlNode nd in docComplete.SelectNodes("//Bar"))
            {
                if (nd.Attributes["EPMLiveTemp"] == null)
                {
                    XmlAttribute attrMove = docComplete.CreateAttribute("CanMove");
                    attrMove.Value = "0";
                    nd.Attributes.Append(attrMove);

                    XmlAttribute attrResize = docComplete.CreateAttribute("CanResize");
                    attrResize.Value = "0";
                    nd.Attributes.Append(attrResize);
                }
                try
                {
                    double work = 0;

                    try
                    {
                        

                        work = double.Parse(nd.Attributes["EPMLiveWork"].Value);

                        work = work / (endHour - startHour - 1);
                    }
                    catch { }

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
                }
                catch { }
            }

            XmlNode ndChart = docComplete.SelectSingleNode("//Chart");
            if (ndChart.Attributes["FirstVisibleDate"] == null)
            {
                XmlAttribute attrStart1 = docComplete.CreateAttribute("FirstVisibleDate");
                attrStart1.Value = start;
                ndChart.Attributes.Append(attrStart1);
            }
            else
                ndChart.Attributes["FirstVisibleDate"].Value = start;

            base.outputData();
        }

        

        private string getAssignedTo()
        {
            filterResources = new ArrayList();
            string[] arrResources = resources.Replace(";#","\n").Split('\n');
            string strAssignedTo = "";
            foreach (string resource in arrResources)
            {
                
                string sresource = EPMLiveCore.CoreFunctions.GetJustUsername(resource);
                filterResources.Add(sresource);
                if (strAssignedTo == "")
                    strAssignedTo = "<Eq><FieldRef Name=\"AssignedTo\" /><Value Type=\"User\">" + sresource + "</Value></Eq>";
                else
                    strAssignedTo = "<Or>" + strAssignedTo + "<Eq><FieldRef Name=\"AssignedTo\" /><Value Type=\"User\">" + sresource + "</Value></Eq>" + "</Or>";
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
