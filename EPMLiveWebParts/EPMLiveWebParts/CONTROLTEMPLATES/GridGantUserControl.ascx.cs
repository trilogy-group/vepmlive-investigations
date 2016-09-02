using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint.JSGrid;
using Microsoft.SharePoint.JsonUtilities;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;
using System.Collections.Generic;

namespace EPMLiveWebParts
{

    public partial class GridGantUserControl : UserControl
    {
        bool errorLoadingData = false;
        string errMessage;
        string _ganttUID = string.Empty;
        
        protected string gridID;
        public string ganttParams;
        public string postUrl;
        public string edit;
        public string width;
        public string datavals; 
        public string insertrow;
        public string source; 
        
        //Webpage variables
        protected string _linkTitle;
        protected string _linkTitleNoMenu;
        protected string _usePopup;
        protected string _action;
        protected string _images;
        protected string _gridHeight = "100";       
        protected string webUrl;
        protected string _fullWebUrl;
        protected string _workspaceurl = string.Empty;
        protected string _assignedTo = string.Empty;
        
        
        public bool DataLoaded
        {
            get
            {
                return errorLoadingData;
            }
        }

        public string Message
        {
            get
            {
                return errMessage;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            /*try
            {
                //Will be used client-side for XMLHTTP post
                webUrl = SPContext.Current.Site.RootWeb.Url + "/_layouts/epmlive/ajaxpost.aspx";

                _fullWebUrl = SPContext.Current.Web.Url;

                //Get list items
                GridData gd = new GridData();
                gd.GanttParams64bitString = ganttParams;
                DataTable data = gd.Data();
                //string xml = data.GetGridData();

                //Will be used client-side for XMLHTTP post
                if (gd.ViewFields.Contains("LinkTitleVersionNoMenu") || gd.ViewFields.Contains("LinkTitleNoMenu") || gd.ViewFields.Contains("LinkTitle"))
                {
                    _linkTitle = gd.LinkTitle;
                    _linkTitleNoMenu = gd.LinkTitleNoMenu;
                }

                if (!string.IsNullOrEmpty(gd.WorkspaceUrl))
                {
                    _workspaceurl = gd.WorkspaceUrl;
                }

                if (!string.IsNullOrEmpty(gd.AssignedTo))
                {
                    _assignedTo = gd.AssignedTo;
                }

                _usePopup = gd.UsePopup();
                _action = gd.GetAction();

                if (_action == string.Empty)
                {
                    if (gd.ViewFields.Contains("LinkTitle"))
                    {
                        _action = "edit";
                    }
                }

                //EPK -- Checkbox 
                if (data != null && gd.List.Title.ToLower() == "projectcenter")
                {
                    data.Columns.Add("PPMItem", typeof(bool));
                    data.Columns["PPMItem"].SetOrdinal(0);
                }
                else
                {
                    lnk_checkAll.Visible = false;
                }
                
                if (data != null && data.Rows.Count > 0)
                {
                    //Init. gantt params
                    GridSerializer gds = new GridSerializer(SerializeMode.Full,
                        data, "Key", new FieldOrderCollection(new String[] { "idno" }),
                        gd.GetGridFields(data), gd.GetGridColumns(data));
            
                    //Register status images
                    LookupTypeInfo gi = GanttUtilities.GanttImage(gd.GanttImages, gd.ImageNames);
                    if (gi != null)
                    {
                        gds.RegisterPropLookupType(gi);
                    }                   

                    //Point the grid serializer at the grid serializer data
                    _grid.GridDataSerializer = gds;

                    //Tell the grid to listen to the GridManager controller.
                    _grid.JSControllerClassName = "GridManager";

                    gridID = _grid.ClientID;

                    int rowHeight = 50;
                    rowHeight = rowHeight + (data.Rows.Count * 20);
                    if (rowHeight < 500)
                        _grid.Height = rowHeight;
                    
                    //Enable the gantt chart.
                    if (gd.GanttStartField != null)
                    {
                        gds.EnableGantt(gd.GanttStart, gd.GanttFinish, GanttUtilities.GetStyleInfo(), "DependencyType");
                    }
                    
                    //image string used clientside one.gif,two.gif etc.
                    string imgs = gd.Images;
                    if (imgs != null && imgs != string.Empty)
                    {
                        _images = imgs;
                    }
                    //Add group header stying
                    CellStyle cs = new CellStyle();
                    cs.FontWeight = "bold";
                    gds.CellStyles.Add("H1", cs);

                    CellStyle cs1 = new CellStyle();
                    cs1.TextAlign = "center";
                    gds.CellStyles.Add("halign", cs1);

                    CellStyle cs2 = new CellStyle();
                    cs2.TextColor = "blue";
                    cs2.TextAlign = "center";
                    gds.CellStyles.Add("link", cs2);

                    CellStyle cs3 = new CellStyle();
                    cs3.TextAlign = "right";
                    gds.CellStyles.Add("ralign", cs3);

                    string titlecolumn = gd.List.Fields.GetFieldByInternalName("Title").Title;
                    if (data.Columns.Contains(titlecolumn))
                    {
                        gds.EnableHierarchy(null, "HierarchyParentKey", titlecolumn, false);
                    }
                    else
                    {
                        if (data.Columns.Contains(titlecolumn))
                        {
                            gds.EnableHierarchy(null, "HierarchyParentKey", titlecolumn, false);
                        }
                        else
                        {
                            gds.EnableHierarchy(null, "HierarchyParentKey", data.Columns[0].ColumnName, false);
                        }                        
                    }

                    //Init expansion level
                    string level = gd.GanttParams["Expand"].ToString();
                    if (level == string.Empty)
                    {
                        if (gd.View.SchemaXml.ToLower().Contains("collapse=\"false\""))
                        {
                            level = "4";
                        }
                    }

                    switch (level)
                    {
                        case "1":
                            gds.SetHierarchyStateExpandedToLevel(1);
                            break;

                        case "2":
                            gds.SetHierarchyStateExpandedToLevel(2);
                            break;

                        case "3":
                            gds.SetHierarchyStateExpandedToLevel(3);
                            break;

                        case "4":
                            gds.SetHierarchyStateExpandedToLevel(100);
                            break;

                        default:
                            gds.SetHierarchyStateExpandedToLevel(0);
                            break;
                    }

                    _grid.ShowLoadingIndicator = true;
                    gd = null;
                }
                else
                {
                    //Init. EMPTY DATABLE
                    data = new DataTable();
                    data.Columns.Add("Message");
                    data.Columns.Add("Key");
                    foreach (string field in gd.ViewFields)
                    {
                        if (!data.Columns.Contains(field))
                        {
                            data.Columns.Add(field);
                        }
                    }

                    if (!data.Columns.Contains("listid"))
                    {
                        data.Columns.Add(new DataColumn("listid", typeof(Guid)));
                    }

                    if (!data.Columns.Contains("siteid"))
                    {
                        data.Columns.Add(new DataColumn("siteid", typeof(Guid)));
                    }

                    if (!data.Columns.Contains("webid"))
                    {
                        data.Columns.Add(new DataColumn("webid", typeof(Guid)));
                    }

                    if (!data.Columns.Contains("ID"))
                    {
                        data.Columns.Add(new DataColumn("ID", typeof(Int32)));
                    }

                    if (!data.Columns.Contains("siteurl"))
                    {
                        data.Columns.Add(new DataColumn("siteurl", typeof(String)));
                    }

                    if (!data.Columns.Contains("viewMenus"))
                    {
                        data.Columns.Add(new DataColumn("viewMenus", typeof(String)));
                    }

                    if (!data.Columns.Contains("viewUrl"))
                    {
                        data.Columns.Add(new DataColumn("viewUrl", typeof(String)));
                    }

                    //Init. default values
                    string webid = SPContext.Current.Site.RootWeb.ID.ToString();
                    string siteid = SPContext.Current.Site.ID.ToString();
                    string siteurl = SPContext.Current.Site.Url;
                    string listid = SPContext.Current.List.ID.ToString();

                    gd.ViewFields.Add("Message");
                    GridSerializer gds = new GridSerializer(SerializeMode.Full,
                    data, "Key", new FieldOrderCollection(new String[] { "ID" }),
                    gd.GetGridFields(data), gd.GetGridColumns(data));

                    //Point the grid serializer at the grid serializer data
                    _grid.GridDataSerializer = gds;

                    //Tell the grid to listen to the GridManager controller.
                    _grid.JSControllerClassName = "GridManager";
                    gd.Dispose();
                }        
            }
            catch (Exception ex)
            {
                Response.Write("The following error has occurred: <br />" + ex.Message);                
            }*/
        }
    }
}
