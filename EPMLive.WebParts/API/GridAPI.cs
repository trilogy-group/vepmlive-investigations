using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SharePoint;
using System.Collections;

namespace EPMLiveWebParts.API
{
    internal class GridAPI
    {
        private XmlDocument doc;
        private string _params;

        private string _list;
        private string _view;
        private string _gridname;

        private string _cols;

        private SPList oList;
        private SPView oView;

        private bool bUseReporting;
        private int iPageSize;
        private int iPage = 0;

        private XmlNode ndHeader;

        public GridAPI(string parameters, SPWeb web)
        {
            _params = parameters;
            LoadParams(web);


            doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.txtGridLayout.Replace("#gridid#", _gridname));
            XmlNode ndLeftCols = doc.FirstChild.SelectSingleNode("//LeftCols");
            XmlNode ndCols = doc.FirstChild.SelectSingleNode("//Cols");
            XmlNode ndRightCols = doc.FirstChild.SelectSingleNode("//RightCols");
            ndHeader = doc.FirstChild.SelectSingleNode("//Header");
            XmlNode ndBody = doc.FirstChild.SelectSingleNode("//Body/B");

            try
            {

                
                XmlNode ndCurCols = ndLeftCols;

                foreach (string sCol in _cols.Split(','))
                {
                    SPField field = getRealField(oList.Fields.GetFieldByInternalName(sCol));

                    ndCurCols.AppendChild(GetColumn(field, sCol));

                    if (field.InternalName == "Title")
                    {
                        ndCurCols = ndCols;
                    }
                }


            }
            catch (Exception ex) {
                ndLeftCols.RemoveAll();
                ndCols.RemoveAll();
                ndRightCols.RemoveAll();


                XmlNode nd = doc.CreateNode(XmlNodeType.Element, "C", doc.NamespaceURI);
                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = "Error";
                nd.Attributes.Append(attr);

                ndLeftCols.AppendChild(nd);


                nd = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);
                attr = doc.CreateAttribute("Error");
                attr.Value = System.Web.HttpUtility.HtmlEncode(ex.Message);
                nd.Attributes.Append(attr);

                ndBody.AppendChild(nd);
            }
        }

        private XmlNode GetColumn(SPField oField, string sFieldName)
        {
            //Header Text
            XmlAttribute attr = doc.CreateAttribute(oField.InternalName);
            attr.Value = oField.Title;

            ndHeader.Attributes.Append(attr);


            //Field Stuff
            XmlNode nd = doc.CreateNode(XmlNodeType.Element, "C", doc.NamespaceURI);
            attr = doc.CreateAttribute("Name");
            attr.Value = oField.InternalName;
            nd.Attributes.Append(attr);

            switch (oField.Type)
            {
                case SPFieldType.Currency:
                    attr = doc.CreateAttribute("Align");
                    attr.Value = "Right";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("MinWidth");
                    attr.Value = "80";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("Width");
                    attr.Value = "80";
                    nd.Attributes.Append(attr);
                    break;
                case SPFieldType.DateTime:
                    attr = doc.CreateAttribute("Align");
                    attr.Value = "Right";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("MinWidth");
                    attr.Value = "80";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("Width");
                    attr.Value = "80";
                    nd.Attributes.Append(attr);
                    break;
                case SPFieldType.Number:
                    attr = doc.CreateAttribute("Align");
                    attr.Value = "Right";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("MinWidth");
                    attr.Value = "100";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("Width");
                    attr.Value = "100";
                    nd.Attributes.Append(attr);
                    break;
                case SPFieldType.Boolean:
                    attr = doc.CreateAttribute("Align");
                    attr.Value = "Left";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("MinWidth");
                    attr.Value = "60";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("Width");
                    attr.Value = "60";
                    nd.Attributes.Append(attr);
                    break;
                case SPFieldType.Choice:
                case SPFieldType.Lookup:
                case SPFieldType.MultiChoice:
                case SPFieldType.Note:
                case SPFieldType.URL:
                case SPFieldType.User:
                default:
                    attr = doc.CreateAttribute("Align");
                    attr.Value = "Left";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("MinWidth");
                    attr.Value = "100";
                    nd.Attributes.Append(attr);
                    attr = doc.CreateAttribute("RelWidth");
                    attr.Value = "1";
                    nd.Attributes.Append(attr);
                    break;
            }



            if (oField.Title == "Title")
            {
                nd.Attributes["MinWidth"].Value = "600";
                nd.Attributes["RelWidth"].Value = "2";
            }
            
            return nd;
        }

        private SPField getRealField(SPField field)
        {
            try
            {
                if (field.Type == SPFieldType.Computed)
                {
                    {
                        XmlDocument fieldXml = new XmlDocument();
                        fieldXml.LoadXml(field.SchemaXml);

                        string parentField = "";
                        try
                        {
                            parentField = fieldXml.FirstChild.Attributes["DisplayNameSrcField"].Value;
                        }
                        catch { }
                        if (parentField != "")
                        {
                            try
                            {
                                field = field.ParentList.Fields.GetFieldByInternalName(parentField);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            return field;
        }

        private void LoadParams(SPWeb oWeb)
        {
            try
            {

                string []fullParamList = _params.Split('|');
                _cols = fullParamList[1];

                Hashtable hshParams = new Hashtable();

                byte[] encodedDataAsBytes = System.Convert.FromBase64String(fullParamList[0]);

                string[] props = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

                foreach (string s in props)
                {
                    hshParams.Add(s.Split('\t')[0], s.Split('\t')[1]);
                }

                _list = hshParams["List"].ToString();
                _view = hshParams["View"].ToString();
                _gridname = hshParams["GridName"].ToString();

                SPList tempList = null;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite s = new SPSite(oWeb.Url))
                    {
                        using (SPWeb w = s.OpenWeb())
                        {
                            tempList = w.GetListFromUrl(_list);
                        }
                    }
                });

                oList = oWeb.Lists[tempList.ID];
                oView = oList.Views[_view];

                try
                {
                    bUseReporting = bool.Parse(hshParams["UseReporting"].ToString());
                }
                catch { }
                try
                {
                    iPageSize = int.Parse(hshParams["PageSize"].ToString());
                }
                catch { }
                try
                {
                    iPage = int.Parse(fullParamList[2].ToString());
                }
                catch { }

                /*try
                {
                    ReportID = hshParams["ReportID"].ToString();
                }
                catch { }
                try
                {
                    usewbs = hshParams["WBS"].ToString();
                }
                catch { }
                try
                {
                    executive = hshParams["Executive"].ToString();
                }
                catch { }
                try
                {
                    linktype = hshParams["LType"].ToString();
                }
                catch { }
                try
                {
                    lookupFilterField = hshParams["LookupField"].ToString();
                }
                catch { }
                try
                {
                    lookupFilterFieldList = hshParams["LookupFieldList"].ToString();
                }
                catch { }

                try
                {
                    sSearchField = Request["searchfield"].ToString();
                }
                catch { }
                try
                {
                    sSearchValue = Request["searchvalue"].ToString();
                }
                catch { }
                try
                {
                    sSearchType = Request["searchtype"].ToString();
                }
                catch { }

                try
                {
                    if (hshParams["RLists"].ToString() != "")
                    {
                        string[] tRollupLists = hshParams["RLists"].ToString().Split(',');
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
                }
                catch { }

                filterfield = hshParams["FilterField"].ToString();
                filtervalue = hshParams["FilterValue"].ToString();

                try
                {
                    LookupFilterField = hshParams["LookupFilterField"].ToString();
                }
                catch { }
                try
                {
                    LookupFilterValue = hshParams["LookupFilterValue"].ToString();
                }
                catch { }

                try
                {
                    if (hshParams["RSites"].ToString() != "")
                    {
                        rollupsites = hshParams["RSites"].ToString().Split(',');
                    }
                }
                catch { }
                
                try
                {
                    additionalgroups = hshParams["AGroups"].ToString();
                }
                catch { }
                expandlevel = 0;
                try
                {
                    expandlevel = int.Parse(hshParams["Expand"].ToString());
                }
                catch { }

                try
                {
                    InfoField = hshParams["Info"].ToString();
                }
                catch { }
                try
                {
                    StartDateField = hshParams["Start"].ToString();
                }
                catch { }
                try
                {
                    DueDateField = hshParams["Finish"].ToString();
                }
                catch { }
                try
                {
                    ProgressField = hshParams["Percent"].ToString();
                }
                catch { }

                SPList tempList = null;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite s = new SPSite(curWeb.Url))
                    {
                        using (SPWeb w = s.OpenWeb())
                        {
                            tempList = w.GetListFromUrl(strlist);
                        }
                    }
                });

                
                try
                {
                    inEditMode = bool.Parse(Request["edit"]);
                }
                catch { }
                try
                {
                    showinsertrow = bool.Parse(hshParams["ShowInsert"].ToString());
                }
                catch { }
                try
                {
                    usePerformance = false;
                    usePerformance = bool.Parse(hshParams["UsePerf"].ToString());
                }
                catch { }
                try
                {
                    usePopup = false;
                    usePopup = bool.Parse(hshParams["UsePopup"].ToString());
                }
                catch { }
                try
                {
                    requestsenabled = false;
                    requestsenabled = bool.Parse(hshParams["Requests"].ToString());
                }
                catch { }
                try
                {
                    showCheckboxes = false;
                    showCheckboxes = bool.Parse(hshParams["ShowCheckboxes"].ToString());
                }
                catch { }
                try
                {
                    bUseReporting = bool.Parse(hshParams["UseReporting"].ToString());
                }
                catch { }
                try
                {
                    iPageSize = int.Parse(hshParams["PageSize"].ToString());
                }
                catch { }
                try
                {
                    iPage = int.Parse(Request["Page"].ToString());
                }
                catch { }
                try
                {
                    WPID = hshParams["WPID"].ToString();
                }
                catch { }*/
            }
            catch { }

        }

        public override string ToString()
        {
            return doc.OuterXml;
        }
    }
}
