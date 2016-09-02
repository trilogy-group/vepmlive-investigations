using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Microsoft.SharePoint;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.API.Integration
{
    internal class IntegrationAdmin
    {
        API.Integration.IntegrationCore _core;
        public Guid intlistid;
        public Guid ModuleID;
        public Guid ListId;
        public Hashtable hshProperties;
        private ArrayList ControlCollection;

        internal IntegrationAdmin(API.Integration.IntegrationCore core, Guid Intlistid, Guid Moduleid)
        {
            _core = core;
            this.intlistid = Intlistid;
            this.ModuleID = Moduleid;
            hshProperties = new Hashtable();
            ControlCollection = new ArrayList();

            if(intlistid != Guid.Empty && ModuleID == Guid.Empty)
            {
                Hashtable hshProps = new Hashtable();
                hshProps.Add("intlistid", intlistid);

                DataSet ds = _core.GetDataSet("SELECT MODULE_ID,LIST_ID FROM INT_LISTS where INT_LIST_ID=@intlistid", hshProps);

                try
                {
                    ModuleID = new Guid(ds.Tables[0].Rows[0]["MODULE_ID"].ToString());
                }
                catch { }
                ListId = new Guid(ds.Tables[0].Rows[0]["LIST_ID"].ToString());
            }
        }

        internal bool DeleteIntegration(Guid intlistid, out string message)
        {
            message = "";
            if(_core.RemoveIntegration(intlistid, ListId, out message))
            {

                Hashtable hshProps = new Hashtable();
                hshProps.Add("intlistid", intlistid);


                string sql = "SELECT SITE_ID,WEB_ID,LIST_ID, INT_COLID from INT_LISTS where INT_LIST_ID=@intlistid";

                DataSet ds = _core.GetDataSet(sql, hshProps);
                DataRow dr = ds.Tables[0].Rows[0];
                Guid listid = new Guid(dr["LIST_ID"].ToString());
                string colid = "INTUID" + dr["INT_COLID"].ToString();
                Guid SiteId = new Guid(dr["SITE_ID"].ToString());
                Guid WebId = new Guid(dr["WEB_ID"].ToString());

                sql = "DELETE FROM INT_LISTS where INT_LIST_ID=@intlistid";

                _core.ExecuteQuery(sql, hshProps, false);


                sql = "DELETE FROM INT_LOG where INT_LIST_ID=@intlistid";
                _core.ExecuteQuery(sql, hshProps, false);

                sql = "DELETE FROM INT_COLUMNS where INT_LIST_ID=@intlistid";
                _core.ExecuteQuery(sql, hshProps, false);

                sql = "DELETE FROM INT_PROPS where INT_LIST_ID=@intlistid";
                _core.ExecuteQuery(sql, hshProps, true);

                using(SPSite site = new SPSite(SiteId))
                {
                    using(SPWeb web = site.OpenWeb(WebId))
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.Lists[listid];
                        SPField field = null;
                        try
                        {
                            field = list.Fields.GetFieldByInternalName(colid);
                        }
                        catch { }

                        if(field != null)
                        {
                            field.Hidden = false;
                            field.Update();
                            list.Fields.Delete(field.InternalName);
                        }
                        list.Update();

                        RemoveEventHandlers(list);
                    }
                }

                _core.UpdatePriorityNumbers(listid);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void InstallEventHandlers(SPList list)
        {

            string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
            string className = "EPMLiveCore.IntegrateEvents";

            bool del = false;
            bool add = false;
            bool upd = false;

            SPEventReceiverDefinitionCollection eventColl = list.EventReceivers;

            foreach(SPEventReceiverDefinition eventDef in eventColl)
            {
                if(eventDef.Assembly.Equals(assemblyName) && eventDef.Class.Equals(className))
                {
                    if(eventDef.Type.Equals(SPEventReceiverType.ItemAdded))
                        add = true;

                    if(eventDef.Type.Equals(SPEventReceiverType.ItemUpdated))
                        upd = true;

                    if(eventDef.Type.Equals(SPEventReceiverType.ItemDeleting))
                        del = true;
                }
            }

            if(!add)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemAdded, assemblyName, className);
            }

            if(!upd)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, assemblyName, className);
            }

            if(!del)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, assemblyName, className);
            }

            if(!add || !upd || !del)
                list.Update();

        }


        internal void RemoveEventHandlers(SPList list)
        {
            list.ParentWeb.AllowUnsafeUpdates = true;
            Hashtable hshParam = new Hashtable();
            hshParam.Add("listid", list.ID);

            DataSet dsIntegrations = _core.GetDataSet("SELECT * from INT_LISTS where LIST_ID=@listid", hshParam);
            if(dsIntegrations.Tables[0].Rows.Count <= 0)
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.IntegrateEvents";



                ArrayList arrevents = new ArrayList();

                SPEventReceiverDefinitionCollection eventColl = list.EventReceivers;



                foreach(SPEventReceiverDefinition eventDef in eventColl)
                {
                    if(eventDef.Assembly.Equals(assemblyName) && eventDef.Class.Equals(className))
                    {
                        arrevents.Add(eventDef);
                    }
                }

                foreach(SPEventReceiverDefinition def in arrevents)
                {
                    def.Delete();
                }

                if(arrevents.Count > 0)
                    list.Update();
            }
        }

        internal void CreateIntegration(Guid SiteId, Guid WebId, Guid ListId, string intkey, bool lout, bool lin, bool tout, bool tin)
        {

            intlistid = Guid.NewGuid();

            int colid = 1;
            int priority = 1;
            int sitepriority = 1;

            Hashtable hshProps = new Hashtable();
            hshProps.Add("listid", ListId);

            //==========Get COLID========
            DataSet dsColid = _core.GetDataSet("SELECT TOP 1 int_colid from INT_LISTS where LIST_ID=@listid order by int_colid desc", hshProps);
            if(dsColid.Tables[0].Rows.Count > 0)
            {
                try
                {
                    colid = int.Parse(dsColid.Tables[0].Rows[0]["INT_COLID"].ToString()) + 1;
                }
                catch { }
            }


            //==========Get Priority========

            DataSet dspriority = _core.GetDataSet("SELECT TOP 1 Priority from INT_LISTS where LIST_ID=@listid order by Priority desc", hshProps);
            if(dspriority.Tables[0].Rows.Count > 0)
            {
                try
                {
                    priority = int.Parse(dspriority.Tables[0].Rows[0]["Priority"].ToString()) + 1;
                }
                catch { }
            }

            hshProps = new Hashtable();
            hshProps.Add("siteid", SiteId);
            DataSet dssitepriority = _core.GetDataSet("SELECT TOP 1 Site_Priority from INT_LISTS where SITE_ID=@siteid order by Site_Priority desc", hshProps);
            if(dssitepriority.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sitepriority = int.Parse(dssitepriority.Tables[0].Rows[0]["Site_Priority"].ToString()) + 1;
                }
                catch { }
            }

            //=============

            hshProps = new Hashtable();
            hshProps.Add("intlistid", intlistid);
            hshProps.Add("siteid", SiteId);
            hshProps.Add("webid", WebId);
            hshProps.Add("listid", ListId);
            hshProps.Add("intkey", intkey);
            hshProps.Add("lout", lout);
            hshProps.Add("lin", lin);
            hshProps.Add("tout", tout);
            hshProps.Add("tin", tin);
            hshProps.Add("moduleid", ModuleID);
            hshProps.Add("colid", colid);
            hshProps.Add("priority", priority);
            hshProps.Add("sitepriority", sitepriority);

            _core.ExecuteQuery("INSERT INTO INT_LISTS (INT_LIST_ID, MODULE_ID, LIST_ID,WEB_ID, SITE_ID, INT_COLID, PRIORITY, INT_KEY, SITE_PRIORITY, LIVEOUTGOING, LIVEINCOMING, TIMEOUTGOING, TIMEINCOMING) VALUES (@intlistid, @moduleid, @listid, @webid, @siteid, @colid, @priority, @intkey, @sitepriority, @lout, @lin, @tout, @tin)", hshProps, true);


            string colname = "INTUID" + colid.ToString();

            using(SPSite site = new SPSite(SiteId))
            {
                using(SPWeb web = site.OpenWeb(WebId))
                {
                    web.AllowUnsafeUpdates = true;
                    site.AllowUnsafeUpdates = true;
                    SPList list = web.Lists[ListId];
                    SPField field = null;
                    try
                    {
                        field = list.Fields.GetFieldByInternalName(colname);
                    }catch{}

                    if(field == null)
                    {
                        colname = list.Fields.Add(colname, SPFieldType.Text, false);
                        field = list.Fields.GetFieldByInternalName(colname);
                        field.Hidden = true;
                        field.Update();
                    }
                    list.Update();

                    field = null;
                    try
                    {
                        field = list.Fields.GetFieldByInternalName("INTUIDSYS");
                    }
                    catch { }

                    if(field == null)
                    {
                        colname = list.Fields.Add("INTUIDSYS", SPFieldType.Text, false);
                        field = list.Fields.GetFieldByInternalName("INTUIDSYS");
                        field.Hidden = true;
                        field.Update();
                    }
                    list.Update();



                    InstallEventHandlers(list);
                }
            }

            _core.UpdatePriorityNumbers(ListId);
        }

        internal void UpdateIntegration(Guid intlistid, string intkey, bool lout, bool lin, bool tout, bool tin)
        {

            Hashtable hshProps = new Hashtable();

            hshProps = new Hashtable();
            hshProps.Add("intlistid", intlistid);
            hshProps.Add("intkey", intkey);
            hshProps.Add("lout", lout);
            hshProps.Add("lin", lin);
            hshProps.Add("tout", tout);
            hshProps.Add("tin", tin);

            _core.ExecuteQuery("UPDATE INT_LISTS SET INT_KEY=@intkey, LIVEOUTGOING=@lout, LIVEINCOMING=@lin, TIMEOUTGOING=@tout, TIMEINCOMING = @tin where INT_LIST_ID=@intlistid", hshProps, true);

        }

        internal void SaveProperties(Hashtable hshNewProps)
        {
            foreach(Control c in ControlCollection)
            {
                if(c.GetType() == typeof(TextBox))
                {
                    if(((TextBox)c).TextMode == TextBoxMode.Password)
                    {
                        if(((TextBox)c).Text != "")
                        {
                            string enc = CoreFunctions.Encrypt(((TextBox)c).Text, "kKGBJ768d3q78^#&^dsas");
                            hshNewProps.Add(c.ID, enc);
                        }
                    }
                    else
                        hshNewProps.Add(c.ID, ((TextBox)c).Text);
                }
                else if(c.GetType() == typeof(DropDownList))
                {
                    hshNewProps.Add(c.ID, ((DropDownList)c).SelectedValue);
                }
                else if(c.GetType() == typeof(CheckBox))
                {
                    hshNewProps.Add(c.ID, ((CheckBox)c).Checked.ToString());
                }
            }

            _core.SaveProperties(intlistid, hshNewProps);

            
        }

        internal Hashtable GetCurrentPageProperties()
        {
            Hashtable hshNewProps = new Hashtable();

            foreach(Control c in ControlCollection)
            {
                if(c.GetType() == typeof(TextBox))
                {
                    hshNewProps.Add(c.ID, ((TextBox)c).Text);
                }
                else if(c.GetType() == typeof(DropDownList))
                {
                    hshNewProps.Add(c.ID, ((DropDownList)c).SelectedValue);
                }
                else if(c.GetType() == typeof(CheckBox))
                {
                    hshNewProps.Add(c.ID, ((CheckBox)c).Checked.ToString());
                }
            }

            return hshNewProps;
        }

        private string GetNodeAttribute(XmlNode nd, string Property)
        {
            try
            {
                return nd.Attributes[Property].Value;
            }
            catch { }
            return "";
        }

        internal Panel GetPropertyPanel(XmlNode ndProps, Hashtable hshProps, LayoutsPageBase page)
        {
            Panel pnl = new Panel();
            pnl.Controls.Add(new LiteralControl("<table width=\"100%\">"));

            hshProperties = hshProps;

            foreach(XmlNode ndProperty in ndProps.SelectNodes("Input"))
            {

                string Property = GetNodeAttribute(ndProperty, "Property");
                string Title = GetNodeAttribute(ndProperty, "Title");
                string Type = GetNodeAttribute(ndProperty, "Type");
                string ParentProperty = GetNodeAttribute(ndProperty, "ParentProperty");


                InputFormSection section = (InputFormSection)page.LoadControl("~/_controltemplates/InputFormSection.ascx");
                section.ID = Property + "_Section";
                section.Title = Title;

                IntegrationDescriptionTemplate controlDescription = new IntegrationDescriptionTemplate(ndProperty.InnerText);
                section.Template_Description = controlDescription;

                string curVal = "";

                if(page.IsPostBack)
                    curVal = page.Request[""];
                else
                {
                    try
                    {
                        curVal = hshProps[Property].ToString();
                    }
                    catch { }
                }

                hshProps[Property] = curVal;

                Control c = null;



                switch(Type.ToLower())
                {
                    case "text":
                        TextBox txt = new TextBox();
                        txt.ID = Property;
                        txt.Text = curVal;
                        c = txt;
                        break;
                    case "password":
                        TextBox txt1 = new TextBox();
                        txt1.ID = Property;
                        txt1.TextMode = TextBoxMode.Password;
                        if(page.IsPostBack)
                            txt1.Text = curVal;

                        c = txt1;
                        break;
                    case "textarea":
                        TextBox txt4 = new TextBox();
                        txt4.ID = Property;
                        txt4.TextMode = TextBoxMode.MultiLine;
                        txt4.Columns = 30;
                        txt4.Rows = 4;
                        txt4.Text = curVal;
                        c = txt4;
                        break;
                    case "select":
                        DropDownList ddl = new DropDownList();
                        ddl.ID = Property;
                        //TODO: parent property
                        Dictionary<String, String> props = _core.GetDropDownProperties(ModuleID, intlistid, new Guid(page.Request["List"]), Property, "");
                        foreach(KeyValuePair<String, String> prop in props)
                        {
                            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(prop.Value.ToString(), prop.Key.ToString());
                            if(curVal == prop.Key.ToString())
                                li.Selected = true;

                            ddl.Items.Add(li);
                        }
                        ddl.EnableViewState = true;
                        c = ddl;
                        break;
                    case "checkbox":
                        CheckBox chk = new CheckBox();
                        chk.ID = Property;
                        try
                        {
                            chk.Checked = bool.Parse(curVal);
                        }
                        catch { }
                        c = chk;
                        break;
                    default:
                        TextBox txt3 = new TextBox();
                        txt3.ID = Property;
                        txt3.Text = curVal;
                        c = txt3;
                        break;
                }

                ControlCollection.Add(c);

                IntegrationControlTemplate controlTemplate = new IntegrationControlTemplate(c, page, Title);
                section.Template_InputFormControls = controlTemplate;
                
                pnl.Controls.Add(section);

            }

            pnl.Controls.Add(new LiteralControl("</table>"));

            return pnl;
        }

        internal string GetIntegrationHeader()
        {
            string sql = "";
            //if(intlistid == Guid.Empty)
                sql = "SELECT title, description,icon FROM INT_MODULES where module_id=@moduleid";
            //else
            //    sql = "SELECT   title, description,icon  FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID where int_list_id=@intlistid";

            Hashtable hshParams = new Hashtable();

            //if(intlistid == Guid.Empty)
            hshParams.Add("moduleid", ModuleID);
            //else
            //    hshParams.Add("intlistid", intlistid);

            DataSet ds = _core.GetDataSet(sql, hshParams);
            DataTable dt = ds.Tables[0];

            StringBuilder sb = new StringBuilder();

            if(dt.Rows.Count > 0)
            {
                string icon = "base.png";
                string desc = "";

                DataRow dr = dt.Rows[0];

                if(dr["Icon"].ToString() != "")
                    icon = dr["Icon"].ToString();
                if(dr["Description"].ToString() != "")
                    desc = dr["Description"].ToString();

                sb.Append("<table border=\"0\" width=\"100%\"><tr><td width=\"64\"><img src=\"/_layouts/epmlive/images/integration/");
                sb.Append(icon);
                sb.Append("\"></td><td valign=\"center\"><h4>");
                sb.Append(dr["Title"].ToString());
                sb.Append("</h4>");

                if(desc != "")
                {
                    sb.Append("<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;work-wrap:break-word;\">");
                    sb.Append(desc);
                    sb.Append("</div>");
                }
                sb.Append("</td></tr></table>");

            }

            return sb.ToString();
        }

    }
}
