using System;
using System.Data;
using System.IO;
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

namespace EPMLiveCore
{
    public partial class viewrollup : System.Web.UI.Page
    {
        protected GridView listGrid;

        private DataTable dtRollup;

        private SPWeb curWeb;

        private string[] lists;

        SPList list = null;
        SPView view = null;

        private ArrayList arrFields = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                curWeb = SPContext.Current.Web;
                curWeb.Site.CatchAccessDeniedException = false;
                //HttpContext.Current.Session["ListGUID"] = Request["List"];
                list = curWeb.Lists[new Guid(Request["List"])];
                //HttpContext.Current.Session["ViewGUID"] = Request["View"];
                view = list.Views[new Guid(Request["View"])];

                string []tLists = Request["Lists"].Split(';');
                lists = new string[tLists.Length];

                for(int i = 0;i<lists.Length;i++)
                {
                    lists[i] = tLists[i].Split(',')[0];
                }

                SPQuery query = new SPQuery();
                query.Query = view.Query;
                query.ViewFields = view.ViewFields.SchemaXml;

                dtRollup = new DataTable();
                SPViewFieldCollection vfc = view.ViewFields;

                foreach (string strField in vfc)
                {
                    SPField f = getRealField(list.Fields.GetFieldByInternalName(strField));
                    dtRollup.Columns.Add(f.InternalName);
                    arrFields.Add(f.InternalName);
                }
                XmlDocument xmlQuery = new XmlDocument();
                xmlQuery.LoadXml("<Query>" + view.Query + "</Query>");

                XmlNode ndGroupBy = xmlQuery.SelectSingleNode("//GroupBy");
                if (ndGroupBy != null)
                {
                    foreach (XmlNode nd in ndGroupBy.ChildNodes)
                    {
                        SPField f = getRealField(list.Fields.GetFieldByInternalName(nd.Attributes["Name"].Value));
                        if (!dtRollup.Columns.Contains(f.InternalName))
                        {
                            dtRollup.Columns.Add(f.InternalName);
                            arrFields.Add(f.InternalName);
                        }
                    }

                    xmlQuery.ChildNodes[0].RemoveChild(ndGroupBy);
                }
                string squery = xmlQuery.ChildNodes[0].InnerXml;

                processSite(curWeb, squery);

                foreach (string strField in arrFields)
                {
                    try
                    {
                        SPField f = getRealField(list.Fields.GetFieldByInternalName(strField));
                        dtRollup.Columns[f.InternalName].ColumnName = f.Title;
                    }
                    catch { }
                }
                //foreach (XmlNode nd in ndGroupBy.ChildNodes)
                //{
                //    SPField f = getRealField(list.Fields.GetFieldByInternalName(nd.InnerText));
                //    dtRollup.Columns.Add(f.InternalName);
                //    arrFields.Add(nd.InnerText);
                //}
                
                listGrid.DataSource = dtRollup;
                listGrid.DataBind();

            }

        }

        private void processSite(SPWeb web, string spquery)
        {
            foreach (string slist in lists)
            {
                try
                {
                    SPQuery query = new SPQuery();
                    query.Query = spquery;
                    //query.ViewFields = view.ViewFields.SchemaXml;

                    SPList list = web.Lists[slist];

                    SPListItemCollection colListItems = list.GetItems(query);

                    int counter = 0;
                    foreach (SPListItem li in colListItems)
                    {
                        string[] fldVals = new string[li.Fields.Count];
                        DataRow dr = dtRollup.NewRow();
                        foreach (string strField in arrFields)
                        {
                            try
                            {
                                if (strField == "Site")
                                {
                                    dr[strField] = li.ParentList.ParentWeb.Title;
                                }
                                else if (strField == "List")
                                {
                                    dr[strField] = slist;
                                }
                                else
                                {
                                    SPField field = getRealField(li.Fields.GetFieldByInternalName(strField));
                                    if (li[field.Id] != null)
                                    {
                                        string val = li[field.Id].ToString();
                                        try
                                        {
                                            val = field.GetFieldValueAsText(val);
                                        }
                                        catch { }
                                        dr[field.InternalName] = val;

                                    }
                                }
                            }
                            catch { }


                            //fldVals[counter] = val;
                            counter += 1;
                        }

                        dtRollup.Rows.Add(dr);

                    }
                }
                catch { }
            }
            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    processSite(w, spquery);
                }
                catch { }
                w.Close();
            }
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
    }
}
