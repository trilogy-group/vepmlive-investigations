using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.JSGrid;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace EPMLiveWebParts
{
    public class GridData : getgriditems
    {
        SortedList arrAggregationDef = new SortedList();
        SPList _spList;
        SPView _spView;
        DataTable _columnDefinitions = new DataTable();
        XmlDocument _xmlDoc = new XmlDocument();
        Random _rand = new Random();

        Hashtable _htGanttParams;
        Hashtable _htNodeData = new Hashtable();
        Hashtable _htImages = new Hashtable();

        //int _groupLevel = 1;
        int _globalIndex = 0;

        List<string> _fieldNames = new List<string>();
        List<string> _images = new List<string>();
        List<string> _imageColumns = new List<string>();
        List<string> _fieldsAddedToView = new List<string>();
        List<string> _reqdfields = new List<string>();

        bool _useCurrent = false;


        string _wbs = string.Empty;
        string _ganttStartField = string.Empty;
        string _ganttFinishField = string.Empty;
        string _ganttMilestone = string.Empty;
        string _pctComplete = string.Empty;
        string _linkTitle = string.Empty;
        string _workspaceUrl = string.Empty;
        string _assignedTo = string.Empty;
        string _linkTitleNoMenu = string.Empty;
        string _linkTitleColumnName = string.Empty;
        string _linkTitleNoMenuColumnName = string.Empty;
        string _orderByField = string.Empty;
        string _imagesClientSide = string.Empty;
        string _ganttParams64bit = "";

        string[] _rollupLists = null;
        string[] _rollupSites = null;
        string[] _filterByFields = null;
        string[] _groupByFields = null;

        DateTime _ganttStartDate;
        DateTime _ganttFinishDate;

        System.Collections.Specialized.StringCollection _spvwFields = null;

        static private Dictionary<Guid, PlannerMenus> hshMenus = new Dictionary<Guid, PlannerMenus>();

        private struct PlannerMenus
        {
            public bool agile;
            public bool workplan;
            public bool project;
        }

        //Properties Start
        public System.Collections.Specialized.StringCollection ViewFields
        {
            get { return _spvwFields; }
        }

        public string LinkTitle
        {
            get { return _linkTitle; }
            set { _linkTitle = value; }
        }

        public string WorkspaceUrl
        {
            get { return _workspaceUrl; }
            set { _workspaceUrl = value; }
        }

        public string AssignedTo
        {
            get { return _assignedTo; }
            set { _assignedTo = value; }
        }

        public string Images
        {
            get { return _imagesClientSide; }
        }

        public List<string> ImageNames
        {
            get { return _images; }
            set { _images = value; }
        }

        public string OrderByField
        {
            get { return _orderByField; }
            set { _orderByField = value; }
        }

        public Hashtable GanttImages
        {
            get { return _htImages; }
            set { _htImages = value; }
        }

        public string[] GroupByFields
        {
            get { return _groupByFields; }
            set { _groupByFields = value; }
        }

        public string LinkTitleNoMenu
        {
            get { return _linkTitleNoMenu; }
            set { _linkTitleNoMenu = value; }
        }

        public string[] RollupLists
        {
            get { return _rollupLists; }
        }

        public string[] RollupSites
        {
            get { return _rollupSites; }
        }

        public string[] FilterByFields
        {
            get { return _filterByFields; }
        }

        public DateTime GanttStart
        {
            get { return _ganttStartDate; }
            set { _ganttStartDate = value; }
        }

        public DateTime GanttFinish
        {
            get { return _ganttFinishDate; }
            set { _ganttFinishDate = value; }
        }

        public string GanttMilestone
        {
            get { return _ganttMilestone; }
            set { _ganttMilestone = value; }
        }

        public string GanttStartField
        {
            get { return _ganttStartField; }
            set { _ganttStartField = value; }
        }

        public string GanttFinishField
        {
            get { return _ganttFinishField; }
            set { _ganttFinishField = value; }
        }

        public string PctComplete
        {
            get { return _pctComplete; }
            set { _pctComplete = value; }
        }

        public string WBS
        {
            get { return _wbs; }
            set { _wbs = value; }
        }

        public bool UseCurrent
        {
            get { return _useCurrent; }
            set { _useCurrent = value; }
        }

        public SPList List
        {
            get { return _spList; }
            set { _spList = value; }
        }

        public SPView View
        {
            get { return _spView; }
            set { _spView = value; }
        }

        public string GanttParams64bitString
        {
            get { return _ganttParams64bit; }
            set { _ganttParams64bit = value; }
        }
        //Properties End

        public static Guid GetListID(Guid siteId, Guid webid, string listname)
        {
            Guid listId = Guid.Empty;
            try
            {
                SPSite site = new SPSite(siteId);
                SPWeb web = site.AllWebs[webid];
                SPList list = web.Lists[listname];
                listId = list.ID;
            }
            catch (Exception ex)
            {

            }
            return listId;
        }

        public string UsePopup()
        {
            return _htGanttParams["UsePopup"].ToString();
        }

        public string GetAction()
        {
            return _htGanttParams["LType"].ToString();
        }

        //public DataRow GetSingleItemJSON(string siteid, string webid, string listid, string itemid, string viewUrl)
        //{
        //    string json = string.Empty;
        //    InitGanttParams(_ganttParams64bit);
        //    DataRow dr = null;
        //    using (SPSite site = new SPSite(new Guid(siteid)))
        //    {
        //        using (SPWeb web = site.AllWebs[new Guid(webid)])
        //        {
        //            string select = "ID=" + itemid;
        //            _spList = web.Lists[new Guid(listid)];

        //            //GridUtilities.List = _spList;
        //            //GridUtilities.View = web.GetViewFromUrl(viewUrl);
        //            //GridUtilities.InitViewFields();
        //            dr = _spList.Items.GetDataTable().Select(select)[0];
        //            //GridUtilities.InitGanttImages(dr.Table);

        //            DataTable tmp = dr.Table.Clone();
        //            DataRow drTmp = tmp.NewRow();

        //            drTmp.ItemArray = dr.ItemArray;
        //            tmp.Rows.Add(drTmp);

        //            //tmp = GridUtilities.FormatColumnData(tmp);
        //            tmp = RemoveNonViewFields(tmp, true);
        //            dr = null;
        //            dr = tmp.Rows[0];
        //        }
        //    }
        //    return dr;
        //}

        //private DataTable InitDataTable(out bool isRollup)
        //{
        //    DataTable dt = null;
        //    isRollup = false;
        //    try
        //    {
        //        InitGanttParams(_ganttParams64bit);
        //        string list = _htGanttParams["List"].ToString();
        //        string view = _htGanttParams["View"].ToString();

        //        //Rollup list check
        //        if (GridUtilities.RollUpLists != null)
        //        {
        //            if (GridUtilities.RollUpSites != null)
        //            {
        //                try
        //                {
        //                    if (GridUtilities.RollUpSites.Contains(SPContext.Current.Site.Url))
        //                    {
        //                        _spList = SPContext.Current.Web.GetListFromUrl(list);
        //                        _spView = SPContext.Current.Web.GetListFromUrl(list).Views[view];
        //                    }
        //                    else
        //                    {
        //                        SPSite site = new SPSite(GridUtilities.RollUpSites[0]);
        //                        SPWeb web = site.OpenWeb();
        //                        _spList = web.GetListFromUrl(list);
        //                        _spView = _spList.Views[view];
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    GridUtilities.AddError("Message: " + ex.Message + " Stack: " + ex.StackTrace);
        //                }
        //            }
        //            else
        //            {
        //                _spList = SPContext.Current.Web.GetListFromUrl(list);
        //                string[] rSites = new string[1];
        //                rSites[0] = SPContext.Current.Site.Url;
        //                GridUtilities.RollUpSites = rSites;
        //                GridUtilities.UseCurrent = true;
        //            }
        //            isRollup = true;
        //        }
        //        else
        //        {
        //            _spList = SPContext.Current.Web.GetListFromUrl(list);
        //        }

        //        _spView = _spList.Views[view];

        //        SPListItemCollection listItems = _spList.Items;
        //        GridUtilities.View = _spView;
        //        GridUtilities.List = _spList;
        //        GridUtilities.InitViewFields();

        //        if (GridUtilities.HasFilter("<List>" + _spView.Query + "</List>"))
        //        {
        //            string[] filterFields = GridUtilities.FilterByFields;
        //            Hashtable _filterFields = GridUtilities.Filters;
        //        }

        //        //Check to see IF rollup list
        //        if (isRollup)
        //        {
        //            //Get rollup list data
        //            dt = GetRollUpListData();
        //        }
        //        else
        //        {
        //            //Gets single site list data                   

        //            string spquery = _spView.Query;
        //            //Remove GROUP BY "LOGIC" from query -- start                                             
        //            XmlDocument querydoc = new XmlDocument();
        //            querydoc.LoadXml("<Query>" + spquery + "</Query>");

        //            XmlDocument xmlQuery = new XmlDocument();
        //            xmlQuery.LoadXml("<Query>" + spquery + "</Query>");

        //            XmlNode ndGroupBy = querydoc.SelectSingleNode("//GroupBy");
        //            ndGroupBy = xmlQuery.SelectSingleNode("//GroupBy");
        //            if (ndGroupBy != null)
        //            {
        //                xmlQuery.ChildNodes[0].RemoveChild(ndGroupBy);
        //            }
        //            spquery = xmlQuery.ChildNodes[0].InnerXml;
        //            // -- end

        //            SPQuery query = new SPQuery();
        //            query.Query = spquery;
        //            dt = _spList.GetItems(query).GetDataTable();

        //            if (dt != null)
        //            {
        //                DataColumn c = new DataColumn("siteid", Type.GetType("System.Guid"));
        //                c.DefaultValue = _spList.ParentWeb.Site.ID;
        //                dt.Columns.Add(c);

        //                DataColumn c1 = new DataColumn("siteUrl");
        //                c1.DefaultValue = _spList.ParentWeb.Url;
        //                dt.Columns.Add(c1);

        //                DataColumn c2 = new DataColumn("listid", Type.GetType("System.Guid"));
        //                c2.DefaultValue = _spList.ID;
        //                dt.Columns.Add(c2);

        //                DataColumn c3 = new DataColumn("WebId");
        //                c3.DefaultValue = _spList.ParentWeb.ID;
        //                dt.Columns.Add(c3);

        //                dt.TableName = string.Empty;
        //            }
        //            //dt = _spList.Items.GetDataTable();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    if (dt != null && dt.Columns.Contains("ListId"))
        //    {
        //        dt.Columns["ListId"].ColumnName = "listid";
        //    }
        //    return dt;
        //}

        public DataTable Data()
        {
            bool isRollup = false;
            InitRoutine(out isRollup);

            InitializeReqdFields();
            //SPWeb curWeb = AddReqdFieldsToView();
            SPWeb curWeb = SPContext.Current.Web;
            return ConvertXmlToDatatable(GetGridData(_ganttParams64bit, curWeb, (string[])_reqdfields.ToArray()));

            //return dt;
        }

        public IList<GridColumn> GetGridColumns(DataTable table)
        {
            List<GridColumn> r = new List<GridColumn>();
            System.Collections.Specialized.StringCollection fields = this.ViewFields;
            string fieldName;
            foreach (DataColumn iterator in table.Columns)
            {
                fieldName = GetInternalName(iterator.ColumnName);
                if (iterator.ColumnName != "Key" && iterator.ColumnName != GridSerializer.DefaultGanttBarStyleIdsColumnName // Used for the gantt how-to. Albert
                        && iterator.ColumnName != GridSerializer.DefaultGridRowStyleIdColumnName
                        && iterator.ColumnName != "DependencyType"
                        && iterator.ColumnName != "HierarchyParentKey"
                        && iterator.ColumnName != "GroupingParentKey"
                   )
                {
                    GridColumn col = new GridColumn();

                    col.FieldKey = iterator.ColumnName;
                    col.Name = GetDisplayName(fieldName);

                    if (!_spvwFields.Contains(fieldName) && fieldName != "PPMItem")
                    {
                        col.IsVisible = false;
                    }

                    if (!_spvwFields.Contains(fieldName))
                    {
                        col.IsSortable = true;
                        col.IsAutoFilterable = true;
                    }

                    //define the column width
                    if (table.Columns[0].ColumnName == iterator.ColumnName)
                    {
                        if (table.Columns[0].ColumnName == "Edit")
                        {
                            col.Width = 50;
                        }
                        else
                        {
                            col.Width = 250;
                        }
                    }
                    else
                    {
                        col.Width = 100;
                    }

                    //add the column
                    r.Add(col);
                }
            }
            return r;
        }

        public IList<GridField> GetGridFields(DataTable table)
        {
            List<GridField> r = new List<GridField>();
            foreach (DataColumn iterator in table.Columns)
            {
                GridField field = new GridField();
                field = formatGridField(field, iterator);
                if (_imageColumns != null && _imageColumns.Contains(iterator.ColumnName) || iterator.ColumnName == "Edit")
                {
                    if (table.Rows.Count > 0)
                    {
                        LookupTypeInfo lookupTypeInfo = GanttUtilities.GanttImage(GanttImages, _images);
                        if (lookupTypeInfo != null)
                        {
                            field.AssociateWithLookupTypeInfo(GanttUtilities.GanttImage(GanttImages, _images));
                            field.DefaultCellStyleId = "halign";
                        }
                    }
                }

                string internalName = GetInternalName(iterator.ColumnName);
                if (field.DefaultCellStyleId != null)
                {
                    if (field.DefaultCellStyleId.ToString() != "halign" && internalName != "Title" && internalName != "LinkTitleNoMenu" && internalName != "LinkTitleVersionNoMenu" && internalName != "LinkTitle" && internalName != "WorkspaceUrl")
                        field.DefaultCellStyleId = "ralign";
                }
                else
                {
                    if (internalName != "Title" && internalName != "LinkTitleNoMenu" && internalName != "LinkTitleVersionNoMenu" && internalName != "LinkTitle")
                        field.DefaultCellStyleId = "ralign";
                }

                r.Add(field);
            }
            return r;
        }

        private GridField formatGridField(GridField gf, DataColumn dc)
        {
            //set field key name
            gf.FieldKey = dc.ColumnName;

            //when in doubt serialize the data value
            gf.SerializeDataValue = true;

            string fieldName = GetInternalName(dc.ColumnName);
            if (
                    dc.ColumnName != "Key" && dc.ColumnName != GridSerializer.DefaultGanttBarStyleIdsColumnName  // Used for gantt how-to. Albert
                    && dc.ColumnName != GridSerializer.DefaultGridRowStyleIdColumnName
                    && dc.ColumnName != "DependencyType"
                    && dc.ColumnName != "HierarchyParentKey"
                    && dc.ColumnName != "GroupingParentKey"
                )
            {
                //check if it’s a time phased field
                try
                {
                    if (dc.ColumnName.Substring(0, 5) == "costq")
                    {
                    }
                    if (dc.ColumnName.Substring(0, 5) == "Quarter")
                    {
                        /*make sure the timephased column headers are always read only despite the grid settings*/
                        gf.EditMode = EditMode.ReadOnly;
                    }
                }
                catch (Exception ex)
                {

                }

                //add properties based on the type
                if (dc.DataType == typeof(String))
                {
                    gf.PropertyTypeId = "String";
                    /*The Localizer determines how we render the underlying data on screen */
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    /*The Serialization type is a required property */
                    gf.SerializeLocalizedValue = true;
                    gf.SerializeDataValue = true;
                }
                else if (dc.DataType == typeof(Int32))
                {
                    gf.PropertyTypeId = "JSNumber";
                    /*The Localizer determines how we render the underlying data on screen */
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    /*The Serialization type is a required property */
                    gf.SerializeLocalizedValue = true;
                    gf.SerializeDataValue = true;
                }
                else if (dc.DataType == typeof(LookupTypeItem))
                {
                    gf.PropertyTypeId = "GanttImage";
                    /*The Localizer determines how we render the underlying data on screen */
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    /*The Serialization type is a required property */
                    gf.SerializeLocalizedValue = true;
                    gf.SerializeDataValue = true;
                }
                else if (dc.DataType == typeof(Hyperlink))
                {
                    gf.PropertyTypeId = "Hyperlink";
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    gf.SerializeLocalizedValue = false;
                    gf.SerializeDataValue = true;
                }
                else if (dc.DataType == typeof(bool))
                {
                    gf.PropertyTypeId = "CheckBoxBoolean";
                    gf.SerializeDataValue = true;
                    gf.SerializeLocalizedValue = false;
                }
                else if (dc.DataType == typeof(DateTime))
                {
                    gf.PropertyTypeId = "JSDateTime";
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    gf.SerializeDataValue = true;
                    gf.SerializeLocalizedValue = true;
                }
                else if (dc.DataType == typeof(Double))
                {
                    gf.PropertyTypeId = "JSNumber";
                    /*The Localizer determines how we render the underlying data on screen */
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    /*The Serialization type is a required property */
                    gf.SerializeLocalizedValue = true;
                    gf.SerializeDataValue = false;
                }
                else if (dc.DataType == typeof(Guid))
                {
                    gf.PropertyTypeId = "String";
                    /*The Localizer determines how we render the underlying data on screen */
                    gf.Localizer = (ValueLocalizer)delegate(DataRow row, object toConvert)
                    {
                        return toConvert == null ? "" : toConvert.ToString();
                    };
                    /*The Serialization type is a required property */
                    gf.SerializeLocalizedValue = true;
                    gf.SerializeDataValue = false;
                }
                else
                    throw new Exception("No PropTypeId defined for this datatype" + dc.DataType);
            }
            gf.EditMode = EditMode.ReadOnly;
            gf.TextDirection = TextDirection.LeftToRight;



            //Need to do get field's internalName by index from the view.
            //Doing this to handle the scenario where there are multiple title columns in view.
            //---START---//
            string intFieldName = string.Empty;
            int colIndex = dc.Ordinal;
            if (_fieldNames.Contains("master_checkbox2"))
            {
                if (colIndex > 0)
                    colIndex--;

                if (colIndex < ViewFields.Count && fieldName != "master_checkbox2")
                    intFieldName = ViewFields[colIndex];
            }
            //---STOP---//

            if (intFieldName.ToLower() == _linkTitleColumnName.ToLower() || 
                intFieldName.ToLower() == _linkTitleNoMenuColumnName.ToLower() || 
                intFieldName.ToLower() == "linktitle" || 
                intFieldName.ToLower() == "linktitlenomenu" || 
                intFieldName.ToLower() == _workspaceUrl.ToLower() ||
                intFieldName.ToLower() == _assignedTo.ToLower())
            {
                if (_spvwFields.Contains("LinkTitleVersionNoMenu") || _spvwFields.Contains("LinkTitleNoMenu") || _spvwFields.Contains("LinkTitle"))
                {
                    gf.DefaultCellStyleId = "link";
                }
            }
            return gf;
        }

        private string GetInternalName(string displayName)
        {
            string name = displayName;
            if (_spList != null && _spList.Fields.ContainsField(displayName))
            {
                name = _spList.Fields.GetField(displayName).InternalName;
            }
            return name;
        }

        private string GetOrderByField()
        {
            string sortByField = string.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<sortByField>" + _spView.Query + "</sortByField>");
                string xPath = "//OrderBy";

                //Order by fields from view
                if (doc.SelectSingleNode(xPath) == null)
                {
                    sortByField = "ID";//_view.ViewFields[0];
                }
                else
                {
                    XmlNode sortField = doc.SelectSingleNode(xPath);
                    XmlNodeList fieldRefs = sortField.ChildNodes;
                    sortByField = fieldRefs[0].Attributes["Name"].Value;
                }

                if (_spList.Title == "Task Center")
                {
                    if (_wbs != null && _wbs != string.Empty)
                    {
                        if (_wbs.ToLower() == "wbs")
                        {
                            sortByField = _wbs;
                        }
                        else
                        {
                            sortByField = "Outline Number";
                        }
                    }
                    else
                    {
                        sortByField = "Task ID";
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return sortByField;
        }

        public void InitRoutine(out bool isRollup)
        {

            isRollup = false;
            try
            {
                InitGanttParams(_ganttParams64bit);
                string list = _htGanttParams["List"].ToString();
                string view = _htGanttParams["View"].ToString();

                //Rollup list check
                if (_rollupLists != null)
                {
                    if (_rollupSites != null)
                    {
                        try
                        {
                            if (_rollupSites.Contains(SPContext.Current.Site.Url))
                            {
                                _spList = SPContext.Current.Web.GetListFromUrl(list);
                                _spView = SPContext.Current.Web.GetListFromUrl(list).Views[view];
                            }
                            else
                            {
                                SPSite site = new SPSite(_rollupSites[0]);
                                SPWeb web = site.OpenWeb();
                                _spList = web.GetListFromUrl(list);
                                _spView = _spList.Views[view];
                            }
                        }
                        catch (Exception ex)
                        {
                            //GridUtilities.AddError("Message: " + ex.Message + " Stack: " + ex.StackTrace);
                        }
                    }
                    else
                    {
                        _spList = SPContext.Current.Web.GetListFromUrl(list);
                        string[] rSites = new string[1];
                        rSites[0] = SPContext.Current.Site.Url;
                        _rollupSites = rSites;
                        _useCurrent = true;
                    }
                    isRollup = true;
                }
                else
                {
                    _spList = SPContext.Current.Web.GetListFromUrl(list);
                }

                _spView = _spList.Views[view];
                SPListItemCollection listItems = _spList.Items;
                _spvwFields = _spView.ViewFields.ToStringCollection();
                //string origOrderByField = GetInternalName(GetOrderByField());

            }
            catch (Exception ex)
            {

            }
        }

        //START -- Modules Created To Handle GridDataXML -- as NEW the datasource
        private DataTable ConvertXmlToDatatable(string xml)
        {
            //Create datatable
            DataTable data = new DataTable();

            //Initialize required fields
            //InitializeReqdFields();

            //Add view fields to view
            // AddReqdFieldsToView();

            //Initialize column definitions (displayname, internalname, isImage, isHyperLink metadata etc.)
            InitializeColumnDefs(xml);

            //Add view fields/columns to datatable
            AddColumns(data);

            //Populate datatable from xmldoc
            LoadData(data);

            //Here we add grid hierarchy, predecessors and ordering
            FinalizeData(data);

            InitializeGanttStartAndFinish(data);

            //Remove fields added to view
            //RemoveReqdFieldsFromView();

            return data;
        }

        private void InitGanttParams()
        {

            if (_htGanttParams.ContainsKey("Start"))
            {
                GanttStartField = _htGanttParams["Start"].ToString();
            }

            if (_htGanttParams.ContainsKey("Finish"))
            {
                GanttFinishField = _htGanttParams["Finish"].ToString();
            }

            if (_htGanttParams.ContainsKey("Percent"))
            {
                PctComplete = _htGanttParams["Percent"].ToString();
            }

            if (_htGanttParams.ContainsKey("Milestone"))
            {
                GanttMilestone = _htGanttParams["Milestone"].ToString();
            }

            if (_htGanttParams.ContainsKey("WBS"))
            {
                WBS = _htGanttParams["WBS"].ToString();
            }

            //Init rollup values
            //InitRollupLists();
            //InitRollupSites();
        }

        private void InitializeGanttStartAndFinish(DataTable dt)
        {
            _ganttStartDate = GetStartDate(dt, _spList);
            _ganttFinishDate = GetFinishDate(dt, _spList);
        }

        public string GetDisplayName(string internalName)
        {
            string name = internalName;
            if (_spList != null && _spList.Fields.ContainsField(internalName))
            {
                name = _spList.Fields.GetField(internalName).Title;
                SPField field = _spList.Fields.GetField(internalName);
            }
            return name;
        }

        private DateTime GetStartDate(DataTable dt, SPList splist)
        {
            DateTime start = DateTime.Now;
            string fieldName = GetDisplayName(GanttStartField);
            string selectScript = fieldName + " NOT IS NULL";

            try
            {
                object value = dt.Compute("MIN(" + fieldName + ")", selectScript);
                start = DateTime.Parse(value.ToString());
            }
            catch (Exception ex) { }
            return start;
        }

        private DateTime GetFinishDate(DataTable dt, SPList splist)
        {
            DateTime finish = DateTime.Now;
            string fieldName = GetDisplayName(GanttFinishField);
            string selectScript = fieldName + " NOT IS NULL";

            try
            {
                object value = dt.Compute("MAX(" + fieldName + ")", selectScript);
                finish = DateTime.Parse(value.ToString());
            }
            catch (Exception ex) { }

            return finish;
        }

        //private void FinalizeData(DataTable convertedXMLdata)
        //{
        //    convertedXMLdata.Columns.Add("idno");
        //    int i = 0;
        //    foreach (DataRow row in convertedXMLdata.Rows)
        //    {
        //        AddRowHierarchy(row, convertedXMLdata, (XmlNode)_htNodeData[i]);
        //        AddRowPredecessors(row, convertedXMLdata);
        //        row["idno"] = i.ToString();
        //        i++;
        //    }
        //    GanttUtilities.ImageNames = _images;

        //    //Image string used clientside
        //    string simages = string.Empty;
        //    foreach (string img in _images)
        //    {
        //        simages = simages + img + ",";
        //    }

        //    if (simages != null && simages.Contains(","))
        //    {
        //        simages = simages.Remove(simages.LastIndexOf(","));
        //    }
        //   _imagesClientSide = simages;
        //    //--end
        //}

        private void FinalizeData(DataTable convertedXMLdata)
        {
            convertedXMLdata.Columns.Add("idno", Type.GetType("System.Int32"));
            int i = 0;
            foreach (DataRow row in convertedXMLdata.Rows)
            {
                if (i > 0)
                    AddRowHierarchy(row, convertedXMLdata, (XmlNode)_htNodeData[i]);
                else
                {
                    row["HierarchyParentKey"] = row["Key"];
                    AddRowPredecessors(row, convertedXMLdata);
                    i++;
                    row["idno"] = i;
                    continue;
                }

                AddRowPredecessors(row, convertedXMLdata);
                row["idno"] = i;

                i++;
            }
            GanttUtilities.ImageNames = _images;

            //Image string used clientside
            string simages = string.Empty;
            foreach (string img in _images)
            {
                simages = simages + img + ",";
            }

            if (simages != null && simages.Contains(","))
            {
                simages = simages.Remove(simages.LastIndexOf(","));
            }
            _imagesClientSide = simages;
            //--end
        }

        //private void AddRowHierarchy(DataRow dr, DataTable data, XmlNode nodeData)
        //{
        //    XmlNode parent = nodeData.ParentNode;
        //    if (parent != null && parent.Name.ToString() != "rows")
        //    {                
        //        string rowid = parent.Attributes["id"].Value;
        //        dr["HierarchyParentKey"] = data.Select("rowid='" + rowid + "'")[0]["Key"];                
        //    }
        //    else
        //        dr["HierarchyParentKey"] = dr["Key"];
        //}

        private void AddRowHierarchy(DataRow dr, DataTable data, XmlNode nodeData)
        {
            if (nodeData != null)
            {
                XmlNode parent = nodeData.ParentNode;
                if (parent != null && parent.Name.ToString() != "rows")
                {
                    string rowid = parent.Attributes["id"].Value;
                    dr["HierarchyParentKey"] = data.Select("rowid='" + rowid + "'")[0]["Key"];
                }
                else
                    dr["HierarchyParentKey"] = dr["Key"];
            }
        }

        private void GetPredecessors(DataRow curTask, DataTable allTasks)
        {
            string[] predecessors = null;
            if (curTask["Predecessors"] != null && curTask["Predecessors"].ToString() != string.Empty)
            {
                if (curTask["Predecessors"].ToString().Contains(","))
                {
                    predecessors = curTask["Predecessors"].ToString().Split(",".ToCharArray()[0]);
                }
                else
                {
                    predecessors = new string[1];
                    predecessors[0] = curTask["Predecessors"].ToString();
                }
            }


            if (predecessors != null)
            {
                Dependency[] allPredecessors = new Dependency[predecessors.Length];
                int i = 0;
                while (i < predecessors.Length)
                {
                    string predecessor = predecessors[i];
                    string taskId = GetTaskId(predecessor);
                    LinkType LT = GetLinkType(predecessor);


                    if (predecessor != string.Empty)
                    {
                        DataRow[] predecessorTask;
                        string select = string.Empty;
                        if (_rollupLists != null && _rollupLists.Length != 0) //Means its a rollup list and the ListId column will be present.
                        {
                            if (!_spList.Fields.ContainsField("Project"))
                            {
                                select = "[task id]='" + taskId + "' AND ListId='" + curTask["ListId"].ToString() + "'";
                                predecessorTask = allTasks.Select(select);
                            }
                            else
                            {
                                if (curTask["Project"].ToString() != "")
                                {
                                    select = "[task id]='" + taskId + "' AND ListId='" + curTask["ListId"].ToString() + "' AND Project='" + curTask["Project"].ToString() + "'";
                                    predecessorTask = allTasks.Select(select);
                                }
                                else
                                {
                                    select = "[task id]='" + taskId + "' AND ListId='" + curTask["ListId"].ToString() + "' AND Project IS NULL";
                                    predecessorTask = allTasks.Select(select);
                                }

                            }
                        }
                        else
                        {
                            if (!_spList.Fields.ContainsField("Project"))
                            {
                                select = "[task id]='" + taskId + "'";
                                predecessorTask = allTasks.Select(select);
                            }
                            else
                            {
                                if (curTask["Project"].ToString() != "")
                                {
                                    select = "[task id]='" + taskId + "' AND Project='" + curTask["Project"].ToString() + "'";
                                    predecessorTask = allTasks.Select(select);
                                }
                                else
                                {
                                    select = "[task id]='" + taskId + "' AND Project IS NULL";
                                    predecessorTask = allTasks.Select(select);
                                }
                            }
                        }


                        if (predecessorTask != null && predecessorTask.Length > 0)
                        {
                            Dependency predObj = new Dependency();
                            predObj.Key = predecessorTask[0]["Key"];
                            predObj.Type = LT;
                            allPredecessors[i] = predObj;
                        }
                    }
                    i++;
                }
                curTask["DependencyType"] = allPredecessors;
            }
        }

        //private string GetTaskId(string predecessorString)
        //{
        //    string taskId = string.Empty;
        //    int index = -1;
        //    if (predecessorString.Contains("F") || predecessorString.Contains("S"))
        //    {
        //        index = predecessorString.IndexOfAny("FS".ToCharArray());
        //    }

        //    if (index != -1)
        //    {
        //        taskId = predecessorString.Remove(index);
        //    }
        //    else
        //    {
        //        taskId = predecessorString;
        //    }
        //    return taskId;
        //}

        private string GetTaskId(string predecessorString)
        {
            string taskId = string.Empty;
            int index = -1;
            if (predecessorString.Contains("F") || predecessorString.Contains("S"))
            {
                index = predecessorString.IndexOfAny("FS".ToCharArray());
            }

            if (index != -1)
            {
                taskId = predecessorString.Remove(index);
            }
            else
            {
                if (predecessorString.Contains("+") || predecessorString.Contains("-"))
                {
                    index = predecessorString.IndexOfAny("+-".ToCharArray());
                    taskId = predecessorString.Remove(index);
                }
                else
                {
                    taskId = predecessorString;
                }
            }
            return taskId;
        }

        private LinkType GetLinkType(string predecessorString)
        {
            string linkType = string.Empty;
            LinkType type;
            int index = -1;

            if (predecessorString.Contains("F") || predecessorString.Contains("S"))
            {
                index = predecessorString.IndexOfAny("FS".ToCharArray());
            }

            if (index != -1)
            {
                linkType = predecessorString.Substring(index, 2);
            }
            else
            {
                linkType = "FS"; //Default linktype
            }

            switch (linkType)
            {
                case "FS":
                    type = LinkType.FinishStart;
                    break;

                case "SS":
                    type = LinkType.StartStart;
                    break;

                case "SF":
                    type = LinkType.StartFinish;
                    break;

                case "FF":
                    type = LinkType.FinishFinish;
                    break;

                default:
                    type = LinkType.FinishStart;
                    break;
            }
            return type;
        }

        private void AddRowPredecessors(DataRow dr, DataTable data)
        {
            try
            {
                GetPredecessors(dr, data);
            }
            catch (Exception ex)
            {
                string ermsg = ex.Message;
            }
        }

        private void InitializeReqdFields()
        {
            if (_spList.Fields.ContainsField("Predecessors"))
                _reqdfields.Add("Predecessors");

            if (_spList.Fields.ContainsField("Critical"))
                _reqdfields.Add("Critical");

            if (_spList.Fields.ContainsField("Project"))
                _reqdfields.Add("Project");

            if (_spList.Fields.ContainsField("taskorder"))
                _reqdfields.Add("taskorder");

            if (_spList.Fields.ContainsField("ID"))
                _reqdfields.Add("ID");

            if (_spList.Fields.ContainsField(_ganttStartField))
                _reqdfields.Add(_ganttStartField);

            if (_spList.Fields.ContainsField(_ganttFinishField))
                _reqdfields.Add(_ganttFinishField);

            if (_spList.Fields.ContainsField(_pctComplete))
                _reqdfields.Add(_pctComplete);

            if (_spList.Fields.ContainsField(_ganttMilestone))
                _reqdfields.Add(_ganttMilestone);
        }

        private SPWeb AddReqdFieldsToView()
        {
            SPWeb curWeb = SPContext.Current.Web;
            strlist = _htGanttParams["List"].ToString();
            //string viewname = SPContext.Current.ViewContext.View.Title;
            //SPList list = SPContext.Current.List;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite s = new SPSite(curWeb.Url))
                {
                    using (SPWeb web = s.OpenWeb())
                    {
                        string viewname = _htGanttParams["View"].ToString();
                        SPList list = web.GetListFromUrl(strlist);
                        SPView view = list.Views[viewname];

                        //list = web.GetListFromUrl(strlist);
                        web.AllowUnsafeUpdates = true;
                        //SPView view = list.Views[viewname];
                        System.Collections.Specialized.StringCollection vwflds = view.ViewFields.ToStringCollection();
                        view.ViewFields.DeleteAll();

                        foreach (string fld in vwflds)
                        {
                            if (list.Fields.ContainsField(fld))
                                view.ViewFields.Add(fld);
                        }

                        foreach (string fld in _reqdfields)
                        {
                            if (!vwflds.Contains(fld))
                            {
                                if (list.Fields.ContainsField(fld))
                                {
                                    view.ViewFields.Add(fld);
                                    _fieldsAddedToView.Add(fld);
                                }
                            }
                        }

                        //Adding title as last field in view. IF it's not already present
                        if (!vwflds.Contains("Title"))
                        {
                            view.ViewFields.Add("Title");
                            _fieldsAddedToView.Add("Title");
                        }

                        view.Update();
                        list.Update();
                        web.Update();
                        web.AllowUnsafeUpdates = false;
                    }
                }
            });
            return SPContext.Current.Web;
        }

        private void RemoveReqdFieldsFromView()
        {
            SPWeb curWeb = SPContext.Current.Web;
            string viewname = _htGanttParams["View"].ToString();//SPContext.Current.ViewContext.View.Title;
            SPList list = _spList;//curWeb.Lists[strlist]; //SPContext.Current.List;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite s = new SPSite(curWeb.Url))
                {
                    using (SPWeb w = s.OpenWeb())
                    {
                        list = w.GetListFromUrl(strlist);
                        w.AllowUnsafeUpdates = true;
                        SPView view = list.Views[viewname];
                        System.Collections.Specialized.StringCollection vwflds = view.ViewFields.ToStringCollection();

                        foreach (string fld in _reqdfields)
                        {
                            if (list.Fields.ContainsField(fld) && _fieldsAddedToView.Contains(fld))
                            {
                                view.ViewFields.Delete(fld);
                            }
                        }

                        view.Update();
                        list.Update();
                        w.Update();
                        w.AllowUnsafeUpdates = false;
                    }
                }
            });
        }

        private void InitializeColumnDefs(string xml)
        {
            _columnDefinitions.Columns.Add("DisplayName");
            _columnDefinitions.Columns.Add("InternalName");
            _columnDefinitions.Columns.Add("IsImage");
            _columnDefinitions.Columns.Add("IsHyperLink");
            _columnDefinitions.Columns.Add("ColumnType");

            _xmlDoc = new XmlDocument();
            _xmlDoc.LoadXml(xml);

            //***NOTE: Loading viewfields here directly from the xml
            InitViewFieldNames();

            foreach (string fieldName in _fieldNames)
            {
                DataRow colInfo = _columnDefinitions.NewRow();
                if (!fieldName.Contains("|"))
                {
                    colInfo["DisplayName"] = fieldName;
                }
                else
                {
                    //Need to do get field's internalName by index from the view.
                    //Doing this to handle the scenario where there are multiple title columns in view.
                    //---START---//
                    string intFieldName = string.Empty;
                    int index = 0;
                    if (_fieldNames.Contains("master_checkbox2"))
                    {
                        if (index > 0)
                            index--;

                        if (index < ViewFields.Count && fieldName != "master_checkbox2")
                            intFieldName = ViewFields[index];
                    }
                    //---STOP---//

                    colInfo["DisplayName"] = fieldName;
                    colInfo["InternalName"] = intFieldName;
                }

                if (IsHyperLink(fieldName, _fieldNames.IndexOf(fieldName)))
                    colInfo["IsHyperLink"] = "true";

                if (_spList.Fields.ContainsField(fieldName))
                {
                    SPField viewField = _spList.Fields.GetField(fieldName);
                    colInfo["InternalName"] = viewField.InternalName;

                    if (viewField.Description.ToLower().Contains("indicator"))
                    {
                        colInfo["IsImage"] = "true";
                        _imageColumns.Add(fieldName);
                    }
                }

                _columnDefinitions.Rows.Add(colInfo);
            }

            //***NOTE: Default columns are loaded in the AddColumns() module.

        }

        private void LoadData(DataTable data)
        {
            XmlNodeList rows = _xmlDoc.FirstChild.SelectNodes("./row");
            foreach (XmlNode row in rows)
            {
                if (_globalIndex == 0)
                    _htNodeData.Add(_globalIndex, row);
                else
                {
                    _globalIndex++;
                    _htNodeData.Add(_globalIndex, row);
                }
                ProcessNode(row, data);
            }
        }

        private void ProcessNode(XmlNode nodeData, DataTable dt)
        {
            PopulateFieldValues(nodeData, dt);
            ProcessChildRows(nodeData, dt);
        }

        private DataTable AddColumns(DataTable data)
        {

            //Add viewfield columns
            foreach (DataRow colDef in _columnDefinitions.Rows)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = colDef["DisplayName"].ToString();

                //if (dc.ColumnName.ToLower() == "workspaceurl")
                //{
                //    data.Columns.Add(dc.ColumnName, typeof(Hyperlink));
                //    continue;
                //}

                if (colDef["IsImage"].ToString() == "true")
                {
                    data.Columns.Add(dc.ColumnName, typeof(int));
                    continue;
                }

                data.Columns.Add(dc);
            }


            //Add default columns
            data.Columns.Add(new DataColumn(GridSerializer.DefaultGanttBarStyleIdsColumnName, typeof(GanttUtilities.CustomBarStyle[])));
            DataRow colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = GridSerializer.DefaultGanttBarStyleIdsColumnName;
            colInfo["ColumnType"] = typeof(GanttUtilities.CustomBarStyle[]).ToString();
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn(GridSerializer.DefaultGridRowStyleIdColumnName, typeof(String)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = GridSerializer.DefaultGridRowStyleIdColumnName;
            colInfo["ColumnType"] = "string";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("groupoutlinenumber", typeof(String)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "groupoutlinenumber";
            colInfo["ColumnType"] = "string";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("Key", typeof(Guid)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "Key";
            colInfo["ColumnType"] = "guid";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("HierarchyParentKey", typeof(Guid)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "HierarchyParentKey";
            colInfo["ColumnType"] = "guid";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("CompleteThrough", typeof(DateTime)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "CompleteThrough";
            colInfo["ColumnType"] = "datetime";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("ganttStart", typeof(DateTime)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "ganttStart";
            colInfo["ColumnType"] = "datetime";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("ganttFinish", typeof(DateTime)));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "ganttFinish";
            colInfo["ColumnType"] = "datetime";
            _columnDefinitions.Rows.Add(colInfo);

            data.Columns.Add(new DataColumn("DependencyType", typeof(Dependency[])));
            colInfo = _columnDefinitions.NewRow();
            colInfo["DisplayName"] = "DependencyType";
            colInfo["ColumnType"] = typeof(Dependency[]).ToString();
            _columnDefinitions.Rows.Add(colInfo);

            if (!data.Columns.Contains("listid"))
            {
                data.Columns.Add(new DataColumn("listid", typeof(Guid)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "listid";
                colInfo["ColumnType"] = "guid";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("siteid"))
            {
                data.Columns.Add(new DataColumn("siteid", typeof(Guid)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "siteid";
                colInfo["ColumnType"] = "guid";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("WebId"))
            {
                data.Columns.Add(new DataColumn("WebId", typeof(Guid)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "WebId";
                colInfo["ColumnType"] = "guid";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("ID"))
            {
                data.Columns.Add(new DataColumn("ID", typeof(Int32)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "ID";
                colInfo["ColumnType"] = "int";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("siteUrl"))
            {
                data.Columns.Add(new DataColumn("siteUrl", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "siteUrl";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("viewMenus"))
            {
                data.Columns.Add(new DataColumn("viewMenus", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "viewMenus";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("viewUrl"))
            {
                data.Columns.Add(new DataColumn("viewUrl", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "viewUrl";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("rowid"))
            {
                data.Columns.Add(new DataColumn("rowid", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "rowid";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("title"))
            {
                data.Columns.Add(new DataColumn("title", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "title";
                colInfo["InternalName"] = "title";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("AssignedToData"))
            {
                data.Columns.Add(new DataColumn("AssignedToData", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "AssignedToData";
                colInfo["InternalName"] = "AssignedToData";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            if (!data.Columns.Contains("WorkspaceUrlData"))
            {
                data.Columns.Add(new DataColumn("WorkspaceUrlData", typeof(String)));
                colInfo = _columnDefinitions.NewRow();
                colInfo["DisplayName"] = "WorkspaceUrlData";
                colInfo["InternalName"] = "WorkspaceUrlData";
                colInfo["ColumnType"] = "string";
                _columnDefinitions.Rows.Add(colInfo);
            }

            return data;
        }

        private void PopulateFieldValues(XmlNode nodeData, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            PopulateViewFieldValues(nodeData, dr);
            PopulateDefaultFieldValues(nodeData, dr, dt);
            dt.Rows.Add(dr);
        }

        private void PopulateViewFieldValues(XmlNode nodeData, DataRow dr)
        {
            XmlNodeList fieldvalues = nodeData.SelectNodes("./cell");
            int i = 0;

            foreach (XmlNode fldVal in fieldvalues)
            {
                string fldName = _fieldNames[i];
                DataRow colInfo = _columnDefinitions.Select("DisplayName='" + fldName.Trim() + "'")[0];
                if (fldName.ToLower() == "workspaceurl")
                {
                    if (!string.IsNullOrEmpty(fldVal.InnerText))
                    {
                        //string rawText = fldVal.InnerText;
                        //rawText = rawText.Replace("<", " ");
                        //rawText = rawText.Replace(">", " ");
                        //string url = string.Empty;
                        //string[] matches = fldVal.InnerText.Split(' ');
                        //foreach (string m in matches)
                        //{
                        //    if (m.StartsWith("href", StringComparison.CurrentCulture))
                        //    {
                        //        string[] pair = m.Split('=');
                        //        url = pair[1];
                        //        break;
                        //    }
                        //}

                        string str = fldVal.InnerText;
                        str = str.Substring(str.IndexOf(">") + 1);
                        str = str.Remove(str.IndexOf("<"));
                        dr[fldName] = str;
                    }
                }
                else if (colInfo["IsImage"].ToString() != "true")
                {
                    if (colInfo["IsHyperLink"].ToString() != "true")
                    {
                        dr[fldName] = fldVal.InnerText;
                    }
                    else
                    {
                        dr[fldName] = fldVal.InnerText;
                        //dr[fldName] = dr[_columnDefinitions.Select("InternalName='Title'")[0]["DisplayName"].ToString()].ToString();
                    }
                }
                else
                {
                    string img = fldVal.InnerText.Substring(fldVal.InnerText.LastIndexOf("/") + 1).Replace("\">", "");
                    if (_images.Contains(img))
                    {
                        dr[fldName] = _images.IndexOf(img);
                    }
                    else
                    {
                        if (img != string.Empty)
                        {
                            _images.Add(img);
                            dr[fldName] = _images.IndexOf(img); ;
                            _htImages.Add(img, _images.IndexOf(img));
                        }
                    }

                    i++;
                    continue;
                }
                i++;
            }
        }

        private void PopulateDefaultFieldValues(XmlNode nodeData, DataRow dr, DataTable data)
        {
            XmlNodeList fieldvalues = nodeData.SelectNodes("./userdata");
            foreach (XmlNode fldVal in fieldvalues)
            {
                string fldName = fldVal.Attributes["name"].Value;
                if (dr.Table.Columns.Contains(fldName))
                {
                    string colType = _columnDefinitions.Select("DisplayName='" + fldName + "'")[0]["ColumnType"].ToString();
                    switch (colType)
                    {
                        case "guid":
                            dr[fldName] = new Guid(fldVal.InnerText);
                            break;

                        case "int":
                            dr[fldName] = int.Parse(fldVal.InnerText);
                            break;

                        case "string":
                            dr[fldName] = fldVal.InnerText;
                            break;

                        case "datetime":
                            PopulateGanttStartAndDates(dr, nodeData);
                            break;
                    }
                }
            }

            ApplyGanttStyle(dr, nodeData);
            PopulateGanttStartAndDates(dr, nodeData);

            dr["Key"] = Guid.NewGuid();
            dr["viewUrl"] = _spView.Url;
            dr["siteUrl"] = SPContext.Current.Site.Url;
            //dr["groupoutlinenumber"] = _groupLevel.ToString();
            dr["rowid"] = nodeData.Attributes["id"].Value;

            //AddRowHierarchy(dr, data, nodeData);
            //data.Columns.Add(new DataColumn("HierarchyParentKey", typeof(Guid)));  ***            
            //data.Columns.Add(new DataColumn("DependencyType", typeof(Dependency[]))); *** 

            //TODO: GroupHeaderRows aren't being returned.
            //TODO: Implement row sorting / orderbyfield
        }

        private void PopulateGanttStartAndDates(DataRow dr, XmlNode node)
        {
            dr["ganttStart"] = GetGanttStartDate(node);
            dr["ganttFinish"] = GetGanttFinishDate(node);
            dr["completeThrough"] = CalcPercentComplete(dr);
        }

        private DateTime CalcPercentComplete(DataRow item)
        {
            DateTime CompletedThru = new DateTime();
            double pctComplete = 0;
            double dayCount = 0;
            int totalDuration = 0;

            try
            {
                string pctField = _spList.Fields.GetField(PctComplete).Title;
                string startfield = _spList.Fields.GetField(GanttStartField).Title;
                string endfield = _spList.Fields.GetField(GanttFinishField).Title;
                string fieldValue = item[pctField].ToString().Replace("%", "");

                if (fieldValue != string.Empty)
                    pctComplete = double.Parse(item[pctField].ToString().Replace("%", ""));
                else
                    pctComplete = 0;

                //fieldName = _spList.Fields.GetField(GanttStartField).Title;
                DateTime start = DateTime.Parse(item[startfield].ToString());

                //fieldName = _spList.Fields.GetField(GanttEndField).Title;
                DateTime end = DateTime.Parse(item[endfield].ToString());
                TimeSpan ts = new TimeSpan();
                ts = end - start;
                totalDuration = ts.Days;

                if (pctComplete <= 1)
                {
                    dayCount = totalDuration * pctComplete;
                }
                else
                {
                    double tmpPct = pctComplete / 100;
                    dayCount = totalDuration * tmpPct;
                }

                CompletedThru = DateTime.Parse(item[startfield].ToString());
                CompletedThru = CompletedThru.AddDays(dayCount);

                //Update % complete
                if (pctComplete <= 1)
                {
                    pctComplete = pctComplete * 100;
                    item[pctField] = pctComplete;
                }
            }
            catch (Exception ex)
            {

            }

            return CompletedThru;
        }

        private DateTime GetGanttStartDate(XmlNode node)
        {
            DateTime datetime = new DateTime();
            XmlNodeList itemvalues = node.SelectNodes("./cell");

            try
            {
                SPField start = _spList.Fields.GetField(GanttStartField);
                datetime = DateTime.Parse(itemvalues[_fieldNames.IndexOf(start.Title)].InnerText.ToLower());
            }
            catch (Exception ex)
            {
                datetime = DateTime.Now;
            }
            return datetime;
        }

        private DateTime GetGanttFinishDate(XmlNode node)
        {
            DateTime datetime = new DateTime();
            XmlNodeList itemvalues = node.SelectNodes("./cell");

            try
            {
                SPField end = _spList.Fields.GetField(GanttFinishField);
                datetime = DateTime.Parse(itemvalues[_fieldNames.IndexOf(end.Title)].InnerText.ToLower());
            }
            catch (Exception ex)
            {
                datetime = DateTime.Now;
            }
            return datetime;
        }

        private void ApplyGanttStyle(DataRow dr, XmlNode node)
        {
            XmlNodeList itemvalues = node.SelectNodes("./cell");
            //Groupheader


            XmlNode attribute = node.Attributes["style"];

            if (attribute != null)
            {
                if (attribute.Value.ToString().ToLower().Contains("font-weight:bold;") && dr["ID"].ToString() == string.Empty)
                {
                    //_groupLevel++;
                    ApplyGanttStyles(dr, "groupheader");
                    dr[GridSerializer.DefaultGridRowStyleIdColumnName] = "H1";
                    return;
                }
            }

            if (attribute != null)
            {
                if (attribute.Value.ToString().ToLower().Contains("font-weight:bold;"))
                {
                    if (_fieldNames.IndexOf("Critical") >= 0 && itemvalues[_fieldNames.IndexOf("Critical")].InnerText.ToLower() == "yes")
                    {
                        //Critical Summary
                        ApplyGanttStyles(dr, "critical summary");
                        dr[GridSerializer.DefaultGridRowStyleIdColumnName] = "H1";
                    }
                    else
                    {
                        //Summary
                        ApplyGanttStyles(dr, "summary");
                        dr[GridSerializer.DefaultGridRowStyleIdColumnName] = "H1";
                    }
                    return;
                }
            }

            if (_fieldNames.IndexOf("Critical") >= 0 && itemvalues[_fieldNames.IndexOf("Critical")].InnerText.ToLower() == "yes")
            {
                //Critical
                ApplyGanttStyles(dr, "critical");
            }
            else
            {
                //Standard
                ApplyGanttStyles(dr, "standard");
            }
        }

        public void ApplyGanttStyles(DataRow item, string type)
        {
            bool isMilestone = false;
            if (GanttMilestone != string.Empty && _spList.Fields.ContainsField(GanttMilestone))
            {
                if (item.Table.Columns.Contains(GanttMilestone) && item[GanttMilestone].ToString().ToLower().Trim() == "yes")
                {
                    isMilestone = true;
                }
            }

            //GanttUtilities.CustomBarStyle: 0 = Summary, 1 = Standard, 2 = Milestone, 3 = Pct Complete, 4 = Critical Standard, 5 = Critical Summary
            switch (type)
            {
                case "groupheader":
                    item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[1] { (GanttUtilities.CustomBarStyle)(0) };
                    break;

                case "summary":
                    item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[2] { (GanttUtilities.CustomBarStyle)(0), (GanttUtilities.CustomBarStyle)(3) };
                    break;

                case "standard":
                    if (isMilestone)
                    {
                        item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[1] { (GanttUtilities.CustomBarStyle)(2) };
                    }
                    else
                    {
                        item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[2] { (GanttUtilities.CustomBarStyle)(1), (GanttUtilities.CustomBarStyle)(3) };
                    }
                    break;

                case "critical":
                    if (isMilestone)
                    {
                        item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[1] { (GanttUtilities.CustomBarStyle)(2) };
                    }
                    else
                    {
                        item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[2] { (GanttUtilities.CustomBarStyle)(4), (GanttUtilities.CustomBarStyle)(3) };
                    }
                    break;

                case "critical summary":
                    item[GridSerializer.DefaultGanttBarStyleIdsColumnName] = new GanttUtilities.CustomBarStyle[1] { (GanttUtilities.CustomBarStyle)(5) };
                    break;
            }
        }

        private XmlNode GetNodeByName(string name, XmlNodeList nl)
        {
            XmlNode nd = null;
            foreach (XmlNode n in nl)
            {
                if (n.Attributes["name"].Value.ToString().ToLower() == name.ToLower())
                {
                    return n;
                }
            }
            return nd;
        }

        private void ProcessChildRows(XmlNode nodeData, DataTable dt)
        {
            XmlNodeList childrows = nodeData.SelectNodes("./row");
            if (childrows.Count > 0)
            {
                //Add grouperheader styling
                dt.Rows[dt.Rows.Count - 1][GridSerializer.DefaultGridRowStyleIdColumnName] = "H1";

                //Process child rows
                foreach (XmlNode childrow in childrows)
                {
                    _globalIndex++;
                    _htNodeData.Add(_globalIndex, childrow);
                    ProcessNode(childrow, dt);
                }

            }
        }

        private bool IsHyperLink(string fieldName, int fieldIndexInView)
        {
            bool isHyperlink = false;
            //Need to do get field's internalName by index from the view.
            //Doing this to handle the scenario where there are multiple title columns in view.
            //---START---//
            string intFieldName = string.Empty;
            if (_fieldNames.Contains("master_checkbox2"))
            {
                if (fieldIndexInView > 0)
                    fieldIndexInView--;

                if (fieldIndexInView < ViewFields.Count && fieldName != "master_checkbox2")
                    intFieldName = ViewFields[fieldIndexInView];
            }
            //---STOP---//

            switch (intFieldName.ToLower())
            {
                case "linktitle":
                    LinkTitle = fieldName;
                    isHyperlink = true;
                    break;

                case "linktitlenomenu":
                    LinkTitleNoMenu = fieldName;
                    isHyperlink = true;
                    break;

                case "linktitleedit":
                    LinkTitleNoMenu = fieldName;
                    isHyperlink = true;
                    break;

                case "edit":
                    isHyperlink = true;
                    break;

                case "workspaceurl":
                    WorkspaceUrl = fieldName;
                    isHyperlink = true;
                    break;

                case "assignedto":
                    AssignedTo = fieldName;
                    isHyperlink = true;
                    break;

                default:
                    break;
            }

            return isHyperlink;
        }

        //protected void InitViewFieldNames()
        //{
        //    XmlNodeList fields = _xmlDoc.SelectNodes("//column");
        //    foreach (XmlNode field in fields)
        //    {
        //        string fldname = field.InnerText.Replace("#", "").Replace("<", "").Replace(">", "").Trim();
        //        if (!_fieldNames.Contains(fldname))
        //        {
        //            _fieldNames.Add(fldname);
        //        }
        //        else
        //        {
        //            _fieldNames.Add(GetDupFieldName(fldname));
        //        }
        //    }
        //}

        protected void InitViewFieldNames()
        {
            XmlNodeList fields = _xmlDoc.SelectNodes("//column");
            foreach (XmlNode field in fields)
            {
                string fldname = field.InnerText.Replace("#", "");

                if (fldname.Contains("<"))
                {
                    fldname = fldname.Substring(fldname.IndexOf(">") + 1);
                    fldname = fldname.Remove(fldname.IndexOf("<"));
                }

                if (!_fieldNames.Contains(fldname))
                {
                    _fieldNames.Add(fldname);
                }
                else
                {
                    _fieldNames.Add(GetDupFieldName(fldname));
                }
            }
        }

        private string GetDupFieldName(string name)
        {
            string fldname = string.Empty;
            int i = 0;
            int count = 5;

            while (i < count)
            {
                string newName = name + "|" + i.ToString();
                if (!_fieldNames.Contains(newName))
                {
                    fldname = newName;
                    break;
                }
                i++;
            }

            return fldname;
        }

        //END --  Modules Created To Handle GridDataXML -- as NEW the datasource

        private DataTable RemoveNonViewFields(DataTable data)
        {
            string colName;
            string internalName;
            string displayName;
            string linkTitleDisplayName = string.Empty;

            int i = 0;
            int viewfieldCount = ViewFields.Count + 5;
            DataColumn column;

            //Default fields
            ViewFields.Add("listid");
            ViewFields.Add("siteUrl");
            ViewFields.Add("WebId");
            ViewFields.Add("siteid");
            ViewFields.Add("ID");

            //Add groupby fields
            //string[] grpByFields = GroupByFields;
            foreach (string grpField in GroupByFields)
            {
                if (!ViewFields.Contains(grpField))
                {
                    ViewFields.Add(GetInternalName(grpField));
                    viewfieldCount++;
                }
            }


            //Conditional field
            if (_spList.Title == "My Work")
            {
                ViewFields.Add("Work Type");
                viewfieldCount++;
            }

            //Conditional field
            if (OrderByField != null)
            {
                ViewFields.Add(OrderByField);
                viewfieldCount++;
            }

            //Remove non-view fields
            while (data.Columns.Count != viewfieldCount)
            {
                if (i >= data.Columns.Count)
                {
                    i = 0;
                }

                column = data.Columns[i];
                internalName = GetInternalName(column.ColumnName);
                displayName = GetDisplayName(column.ColumnName);

                //Check to see if field is in the view or if its a default field
                if (ViewFields.Contains(internalName))
                {
                    if (column.ColumnName.ToLower() == "linktitle" || column.ColumnName.ToLower() == "linktitleedit" || column.ColumnName.ToLower() == "linktitlenomenu")
                    {
                        linkTitleDisplayName = displayName;
                        if (data.Columns.Contains(linkTitleDisplayName))
                        {
                            data.Columns.Remove(linkTitleDisplayName);
                            colName = linkTitleDisplayName;
                            column.ColumnName = colName;
                        }
                    }
                }
                else
                {
                    if (!ViewFields.Contains(internalName))
                    {
                        if (column.ColumnName != linkTitleDisplayName)
                        {
                            if (column.ColumnName != OrderByField)
                            {
                                data.Columns.Remove(column.ColumnName);
                            }
                        }
                    }
                }
                i++;
            }
            return data;
        }

        public Hashtable GanttParams
        {
            get { return _htGanttParams; }
        }

        protected void InitGanttParams(string value)
        {
            _htGanttParams = new Hashtable();

            byte[] encodedDataAsBytes = System.Convert.FromBase64String(value);
            string[] props = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

            foreach (string s in props)
            {
                _htGanttParams.Add(s.Split('\t')[0], s.Split('\t')[1]);
            }
            InitGanttParams();
            // -- PARAMETERS --  START //
            //"Start"
            //"Finish"
            //"Percent"
            //"WBS"
            //"Milestone"
            //"Executive"
            //"Info"
            //"LType"
            //"RLists"
            //"RSites"
            //"List"
            //"View"
            //"FilterField"
            //"FilterValue"
            //"GridName"
            //"AGroups"
            //"Expand"
            // -- PARAMETERS --  END -- //
        }

    }
}

