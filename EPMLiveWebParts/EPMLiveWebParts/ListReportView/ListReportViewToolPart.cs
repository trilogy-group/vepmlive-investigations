using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.Collections;
using System.Data;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class ListReportViewToolPart : ToolPart
    {
        //static SPGridView gridviewwithcheckbox = null;
        Hashtable _hashedNames = null;
        Hashtable _selectedHashNames = null;
        public ListReportViewToolPart()
        {
            this.AllowMinimize = true;
            this.UseDefaultStyles = true;
            this.Title = "List & Libraries";
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            base.RenderToolPart(output);
            ToolPane tp = this.ParentToolPane;
            ListReportView myWP =
                (ListReportView)tp.SelectedWebPart;
            
            //output.Write("<div>");
            output.Write("<div class=\"UserSectionTitle\">");
            output.Write("<table style=\"PADDING-LEFT: 5px\" cellPadding=\"1\">");
            output.Write("<tbody>");
            output.Write("<tr>");

            //output.Write("<td>List(s)<br/>");
            //output.Write("<textarea class=\"ms-input\" rows=\"5\" cols=\"25\" name=\"reportViewLists\">" +
            //    ((!string.IsNullOrEmpty(myWP.ViewLists)) ? myWP.ViewLists.Replace("|", "\r\n") : string.Empty) +
            //    "</textarea>");
            //output.Write("</td>");
            //output.Write("</tr>");
            //output.Write("<tr>");

            output.Write("<td>");
            if (myWP.ExpandView)
            {
                output.Write("<input type=\"checkbox\" name=\"cbExpandView\" checked=\"checked\" value=\"true\" />Expand View");
            }
            else
            {
                output.Write("<input type=\"checkbox\" name=\"cbExpandView\" value=\"true\" />Expand View");
            }
            output.Write("</td>");
            output.Write("</tr>");
            output.Write("</tbody>");
            output.Write("</table>");
            output.Write("</div>");
        }

        protected override void CreateChildControls()
        {
            var gridviewwithcheckbox = new SPGridView();

            gridviewwithcheckbox.ID = "mySPGridViewControl";
            gridviewwithcheckbox.RowDataBound += new GridViewRowEventHandler(gridviewwithcheckbox_RowDataBound);
            gridviewwithcheckbox.AutoGenerateColumns = false; // must be false
            createGridViewWithCheckBox(ref  gridviewwithcheckbox);
            PopulateDisplayNames((ListReportView)this.ParentToolPane.SelectedWebPart, ref gridviewwithcheckbox);
            EnsureChildControls();
            this.Controls.Add(gridviewwithcheckbox);
           
        }

        public override void ApplyChanges()
        {
            ToolPane tp = this.ParentToolPane;
            ListReportView myWP =
                (ListReportView)tp.SelectedWebPart;
            var gridviewwithcheckbox = (SPGridView)this.FindControl("mySPGridViewControl");

            //string newVal = Page.Request["reportViewLists"];
            //if (!string.IsNullOrEmpty(newVal.Trim()))
            //{
            //    newVal = newVal.Replace("\r\n", "|");
            //}
            //myWP.ViewLists = newVal;

            bool result = false;
            bool.TryParse(Page.Request["cbExpandView"], out result);
            myWP.ExpandView = result;
           
            StoreSortListByDisplayName(myWP, gridviewwithcheckbox);
            _selectedHashNames = myWP.GetListNamesInHashtable(myWP.SelectedListNames);
            SortListByDisplayName(_selectedHashNames, myWP);
            
        }

        // end of method
        public void createGridViewWithCheckBox(ref SPGridView grv)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("internalName", typeof(string));

                SPWeb web = SPContext.Current.Web;
                SPListCollection lists = web.Lists;
                DataRow row;
                foreach (SPList oList in lists)
                {
                    if (!oList.Hidden)
                    {
                        row = dt.Rows.Add();
                        row["internalName"] = oList.Title;
                        //if (oList.BaseType != SPBaseType.DocumentLibrary)
                        //{
                        //    row = dt.Rows.Add();
                        //    row["internalName"] = oList.Title;
                        //}
                        //else
                        //{
                        //    SPDocumentLibrary oDocumentLibrary = (SPDocumentLibrary)oList;
                        //   // if (!oDocumentLibrary.IsCatalog && oList.BaseTemplate != SPListTemplateType.XMLForm && oList.BaseTemplate != SPListTemplateType.WebPageLibrary && )
                        //if (oList.BaseType == SPBaseType.DocumentLibrary)
                        //{
                        //    SPDocumentLibrary oDocumentLibrary = (SPDocumentLibrary)oList;
                        //    if (!oDocumentLibrary.IsCatalog && oList.BaseTemplate == SPListTemplateType.DocumentLibrary)
                        //    {
                        //        //SPListItemCollection collListItems = oDocumentLibrary.Items;
                        //        string testName = "";
                        //        //foreach (SPListItem oListItem in collListItems)
                        //        //{
                        //        //    testName += oListItem.Name + "--" + oListItem.DisplayName + "--" + oListItem.File.Title;
                        //        //}
                        //        //string title2 = testName;
                        //        SPListItemCollection folders = oDocumentLibrary.Folders;

                        //        //foreach (SPListItem folder in folders)
                        //        //{
                        //        //    string link = folder.Url;
                        //        //    string displayName = folder.DisplayName;
                        //        //}

                        //        //foreach (SPListItem item in oDocumentLibrary.Items)
                        //        //{
                        //        //    //string sFileLink = item.Url;
                        //        //    //string fileName = item.DisplayName;
                                   
                        //        //    SPFile oFile = item.File;
                        //        //    string sFileLink = oFile.ServerRelativeUrl;
                        //        //    string fileName = oFile.ParentFolder.Name;
                                  
                                   
                        //        //}
                        //        //foreach (SPFolderCollection folders in oDocumentLibrary.RootFolder.SubFolders)
                        //        //{
                        //        //    //string sTempFolderName = fItem.Name;
                        //        //    foreach (SPFolder item in folders)
                        //        //    {
                        //        //        string sURL = item.Url;
                        //        //        string sLink = sURL + item.Title;
                        //        //    }
                        //        //}
                        //    }
                        //}
                        //}
                    }
                }

                TemplateField selectTaskColumn = new TemplateField();
                selectTaskColumn.HeaderText = "";
                selectTaskColumn.ItemTemplate = new CheckBoxTemplate(ListItemType.Item, "", "");
                grv.Columns.Add(selectTaskColumn);
                SPBoundField field;
                field = new SPBoundField();
                //field.
                field.HeaderText = "List & Libraries";
                field.DataField = "internalName";
                field.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                field.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                field.ItemStyle.Wrap = false;
                //grv.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                grv.Columns.Add(field);
                TemplateField displayListColumn = new TemplateField();
                displayListColumn.ItemTemplate = new CheckBoxTemplate(ListItemType.EditItem, "", "test");
                displayListColumn.HeaderText = "Display Name";
                displayListColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                grv.Columns.Add(displayListColumn);

                grv.AutoGenerateColumns = false;
                grv.DataSource = dt.DefaultView;
                grv.DataBind();
            }
            catch { }
        }
        // end of createGridViewWithCheckBox

        private void gridviewwithcheckbox_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left; 
                DataRowView data = (DataRowView)e.Row.DataItem;
                string sListName = data["internalName"].ToString();
                HtmlInputHidden listid = (HtmlInputHidden)e.Row.FindControl("listIdItem");
                if (listid != null)
                {
                    listid.Value = data["internalName"].ToString();
                }
            }
        }
        // end of method
             
        private void PopulateDisplayNames(ListReportView wp, ref SPGridView grv)
        {
            if (!string.IsNullOrEmpty(wp.DisplayListNames))
                _hashedNames = wp.GetListNamesInHashtable(wp.DisplayListNames);
            if (!string.IsNullOrEmpty(wp.SelectedListNames))
                _selectedHashNames = wp.GetListNamesInHashtable(wp.SelectedListNames);    
            for (int idx = 0; idx < grv.Rows.Count; idx++)
            {
                CheckBox selectCtl = (CheckBox)grv.Rows[idx].FindControl("selectedList");
                TextBox txtBox = (TextBox)grv.Rows[idx].FindControl("selectDisplayName");
                HtmlInputHidden listHiddenName = (HtmlInputHidden)grv.Rows[idx].FindControl("listIdItem");
                
                if (_selectedHashNames != null && _selectedHashNames.Count > 0)
                {
                    if ( _selectedHashNames.ContainsKey(listHiddenName.Value.ToString()) )
                        selectCtl.Checked = true;
                }
                string sDisplayName = listHiddenName.Value.ToString();
                if (_hashedNames != null && _hashedNames.Count > 0)
                {
                    if (_hashedNames.ContainsKey(sDisplayName))
                    {
                        sDisplayName = _hashedNames[sDisplayName].ToString();
                    }
                }
                txtBox.Text = sDisplayName;             
            }
        }
        // end of method
        private void StoreSortListByDisplayName(ListReportView wp, SPGridView grv)
        {
            wp.DisplayListNames = string.Empty;
            wp.SelectedListNames = string.Empty;

            try
            {
                for (int idx = 0; idx < grv.Rows.Count; idx++)
                {
                    CheckBox selectCtl = (CheckBox)grv.Rows[idx].FindControl("selectedList");
                    TextBox txtBox = (TextBox)grv.Rows[idx].FindControl("selectDisplayName");
                    HtmlInputHidden listHiddenName = (HtmlInputHidden)grv.Rows[idx].FindControl("listIdItem");
                    string sDisplayName = txtBox.Text;
                    foreach (string name in txtBox.Text.Split(','))
                    {
                        sDisplayName = name;
                        break;
                    }
                    wp.DisplayListNames += listHiddenName.Value.ToString() + "::" + sDisplayName + "|";
                    if (selectCtl.Checked)
                        wp.SelectedListNames += listHiddenName.Value.ToString() + "::" + sDisplayName + "|";

                }
                //remove last | character
                int lastPos = wp.DisplayListNames.LastIndexOf("|");
                if (lastPos > -1)
                    wp.DisplayListNames = wp.DisplayListNames.Remove(lastPos, 1);
                lastPos = string.IsNullOrEmpty(wp.SelectedListNames) ? -1 : wp.SelectedListNames.LastIndexOf("|");
                if (lastPos > -1)
                    wp.SelectedListNames = wp.SelectedListNames.Remove(lastPos, 1);
            }
            catch
            {
                wp.DisplayListNames = string.Empty;
                wp.SelectedListNames = string.Empty;
            }
        }
        // end of method
        private void SortListByDisplayName(Hashtable selectedHashList, ListReportView wp)
        {
            wp.ViewLists = string.Empty;
            if (selectedHashList != null && selectedHashList.Count > 0)
            {        
                var result = new List<DictionaryEntry>(selectedHashList.Count);
                foreach (DictionaryEntry entry in selectedHashList)
                {
                    result.Add(entry);
                }
                result.Sort((x, y) =>
                {
                    IComparable comparable = x.Value as IComparable;
                    if (comparable != null)
                    {
                        return comparable.CompareTo(y.Value);
                    }
                    return 0;
                });
                foreach (DictionaryEntry entry in result)
                {
                    // Console.WriteLine(entry.Key.ToString() + ":" + entry.Value.ToString()); 
                    wp.ViewLists += "|" + entry.Key.ToString();
                }
                if (wp.ViewLists.Length > 0 && wp.ViewLists.IndexOf("|", 0) >= 0)
                    wp.ViewLists = wp.ViewLists.Remove(0, 1);
                wp.ViewLists += "|" + "Report Library";
            }
        }
        // end of method
       
        //private Hashtable GetListNamesInHashtable(string sortListName, ListReportView wp)
        //{
        //    Hashtable oNames = null;
        //    if (!string.IsNullOrEmpty(sortListName))
        //    {
        //        oNames = new Hashtable();
        //        try
        //        {
        //            foreach (string concatName in sortListName.Split('|'))
        //            {
        //                string[] keyValaues = Regex.Split(concatName, "::");
        //                if (!oNames.ContainsKey(keyValaues[0]))
        //                    oNames.Add(keyValaues[0], keyValaues[1]);
        //            }
        //        }
        //        catch
        //        {
        //            oNames = null;
        //            wp.DisplayListNames = string.Empty;
        //            wp.SelectedListNames = string.Empty;
        //        }
        //    }

        //    return oNames;
        //}
        // end of method
        //private Hashtable GetSelectedHashtableNames(string selectedNames, ListReportView wp)
        //{
        //    Hashtable oNames = null;
        //    if (!string.IsNullOrEmpty(selectedNames))
        //    {
        //        oNames = new Hashtable();
        //        try
        //        {
        //            foreach (string concatName in selectedNames.Split('|'))
        //            {
        //                string[] keyValaues = Regex.Split(concatName, "::");
        //                if (!oNames.ContainsKey(keyValaues[0]))
        //                    oNames.Add(keyValaues[0], keyValaues[1]);
        //            }
        //        }
        //        catch
        //        {
        //            oNames = null;
        //            wp.SelectedListNames = string.Empty;
        //        }
        //    }
        //    return oNames;
        //}
        // end of methos
    }
}
