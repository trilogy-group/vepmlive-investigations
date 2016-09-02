using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveIntegration;
using System.Data;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace UplandIntegrations.FileBound
{
    public class Integrator : IIntegrator, IIntegratorControls
    {

        public string GetProxyResult(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control, string Property)
        {

            if (Control == "WorkflowButtons")
            {
                if(Property == "FBGUID")
                {
                    FBConnection cn = new FBConnection(WebProps, Log);

                    return cn.FBGUID;
                }
                return "Invalid Property";
            }
            else
                return "Invalid Control";
        }

        public List<string> GetEmbeddedItemControls(WebProperties WebProps, IntegrationLog Log)
        {
            List<string> l = new List<string>();

            l.Add("WorkflowButtons");

            return l;
        }
        public List<IntegrationControl> GetPageButtons(WebProperties WebProps, IntegrationLog Log, bool Global)
        {
            List<IntegrationControl> l = new List<IntegrationControl>();
            //if (Global)
            //{

            //}
            //else
            //{
            //    IntegrationControl i = new IntegrationControl();
            //    i.Control = "Docs";
            //    i.Image = "workflows.png";
            //    i.Title = "View FB Documents";
            //    i.Window = IntegrationControlWindowStyle.FullWindow;
            //    i.BItemLevel = true;
            //    l.Add(i);
            //}
            return l;
        }
        public string GetURL(WebProperties WebProps, IntegrationLog Log, string control, string itemid)
        {
            switch (control)
            {
                case "Docs":
                    return WebProps.Properties["SiteUrl"].ToString() + "WebViewer/WebView?MultiID=" + itemid + "&DocumentID=0";
            }
            return "";
        }
        public string GetControlCode(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control)
        {
            try
            {
                
                switch (Control)
                {
                    case "WorkflowButtons":
                        if (WebProps.Properties["DataType"].ToString() == "Item")
                        {
                            string relass = "";
                            try
                            {
                                relass = WebProps.Properties["RelatedAssign"].ToString();
                            }catch{}
                            string control = Properties.Resources.txtFBWorkFlow.Replace("#APIUrl#", WebProps.Properties["APIUrl"].ToString()).Replace("#SiteUrl#", WebProps.Properties["SiteUrl"].ToString()).Replace("#fileId#", ItemID).Replace("#projectId#", WebProps.Properties["Folder"].ToString());
                            control = control.Replace("#associatedkey#", relass);
                            control = control.Replace("#inturl#", WebProps.IntegrationAPIUrl.Replace("/integration.asmx","/postitemsimple.aspx"));
                            control = control.Replace("#proxyurl#", WebProps.FullURL + "/_layouts/15/epmlive/integration/proxy.aspx?IntegrationId=" + WebProps.IntegrationId + "&Control=" + Control + "&Property=FBGUID");
                            return control;
                        }
                        else if (WebProps.Properties["DataType"].ToString() == "Assignment")
                        {
                            string control = Properties.Resources.txtFBWorkflowAssignment.Replace("#APIUrl#", WebProps.Properties["APIUrl"].ToString()).Replace("#SiteUrl#", WebProps.Properties["SiteUrl"].ToString()).Replace("#fileId#", ItemID).Replace("#projectId#", WebProps.Properties["Folder"].ToString());

                            control = control.Replace("#associatedkey#", WebProps.IntegrationKey);
                            control = control.Replace("#inturl#", WebProps.IntegrationAPIUrl.Replace("/integration.asmx", "/postitemsimple.aspx"));
                            control = control.Replace("#proxyurl#", WebProps.FullURL + "/_layouts/15/epmlive/integration/proxy.aspx?IntegrationId=" + WebProps.IntegrationId + "&Control=" + Control + "&Property=FBGUID");

                            return control;
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
            return "";
        }

        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            Message = "";
            return true;
        }

        public bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey)
        {
            Message = "";
            return true;
        }


        public TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            TransactionTable trans = new TransactionTable();

            try
            {
                FileBoundSystem fs = new FileBoundSystem(WebProps, Log);

                foreach (DataRow dr in Items.Rows)
                {
                    try
                    {
                        if (WebProps.Properties["DataType"].ToString() == "Item")
                            fs.DeleteItem(dr, ref trans);
                        else if (WebProps.Properties["DataType"].ToString() == "Assignment")
                            fs.DeleteAssignment(dr, ref trans);
                    }
                    catch (Exception ex)
                    {
                        trans.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.FAILED);
                        Log.LogMessage("Error (UpdateItems): " + ex.Message, IntegrationLogType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.LogMessage("Error (DeleteItems): " + ex.Message, IntegrationLogType.Error);
            }

            return trans;
        }

        

        

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            TransactionTable trans = new TransactionTable();
            
            try
            {
                FileBoundSystem fs = new FileBoundSystem(WebProps, Log);

                foreach(DataRow dr in Items.Rows)
                {
                    try
                    {
                        if(WebProps.Properties["DataType"].ToString() == "Item")
                            fs.UpdateItem(dr, ref trans);
                        else if(WebProps.Properties["DataType"].ToString() == "Assignment")
                            fs.UpdateAssignment(dr, ref trans);
                    }
                    catch (Exception ex)
                    {
                        trans.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.FAILED);
                        Log.LogMessage("Error (UpdateItems): " + ex.Message, IntegrationLogType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.LogMessage("Error (GDDV): " + ex.Message, IntegrationLogType.Error);
            }
           
            return trans;
        }


        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {

            List<ColumnProperty> cols = new List<ColumnProperty>();
            try
            {
                FBConnection cn = new FBConnection(WebProps, Log);

                if (WebProps.Properties["DataType"].ToString() == "Item")
                {

                    WebClient wc = new WebClient();
                    string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "projects/" + WebProps.Properties["Folder"].ToString() + "/fields?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

                    ColumnProperty p = new ColumnProperty();
                    p.ColumnName = "id";
                    p.DiplayName = "ID";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "stepName";
                    p.DiplayName = "Current Step";
                    cols.Add(p);

                    dynamic c = System.Web.Helpers.Json.Decode(resp);
                    for (int i = 0; i < c.Length; i++)
                    {
                        p = new ColumnProperty();
                        p.ColumnName = c[i].number.ToString();
                        p.DiplayName = c[i].name.ToString();
                        cols.Add(p);
                    }
                }
                else if (WebProps.Properties["DataType"].ToString() == "Assignment")
                {
                    //WebClient wc = new WebClient();
                    //string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "assignments/fields?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

                    ColumnProperty p = new ColumnProperty();
                    p.ColumnName = "routedItemId";
                    p.DiplayName = "Assignment Id (Unique ID)";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "relFileId";
                    p.DiplayName = "Item Id";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "comment";
                    p.DiplayName = "Comment";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "stepName";
                    p.DiplayName = "Current Step";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "userId";
                    p.DiplayName = "User";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "dueDate";
                    p.DiplayName = "Due Date";
                    cols.Add(p);

                    for (int i = 1; i <= 20; i++)
                    {
                        p = new ColumnProperty();
                        p.ColumnName = "itemfield:" + i;
                        p.DiplayName = "Item Field " + i;
                        cols.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.LogMessage("Error (GDDV): " + ex.Message, IntegrationLogType.Error);
            }
            return cols;
        }

        public DataTable PullData(WebProperties WebProps, IntegrationLog Log, DataTable Items, DateTime LastSynch)
        {
            try
            {
                //FBConnection cn = new FBConnection(WebProps, Log);
                FileBoundSystem fs = new FileBoundSystem(WebProps, Log);

                if (WebProps.Properties["DataType"].ToString() == "Item")
                    return fs.GetItems(Items, LastSynch);
                else if (WebProps.Properties["DataType"].ToString() == "Assignment")
                    return fs.GetAssignments(Items, LastSynch);
            }
            catch (Exception ex)
            {
                Log.LogMessage("Error (GDDV): " + ex.Message, IntegrationLogType.Error);
            }

            return Items;
        }

        public DataTable GetItem(WebProperties WebProps, IntegrationLog Log, string ItemID, DataTable Items)
        {
            try
            {
                FileBoundSystem fs = new FileBoundSystem(WebProps, Log);

                if (WebProps.Properties["DataType"].ToString() == "Item")
                    return fs.GetItem(Items, ItemID);
                else if (WebProps.Properties["DataType"].ToString() == "Assignment")
                    return fs.GetAssignment(Items, ItemID);
                
            }
            catch (Exception ex)
            {
                Log.LogMessage("Error (GDDV): " + ex.Message, IntegrationLogType.Error);
            }

            return Items;
        }

        public Dictionary<String, String> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {

            Dictionary<String, String> DDls = new Dictionary<string, string>();
            try
            {
                FBConnection cn = new FBConnection(WebProps, log);

                switch (Property)
                {
                    case "Folder":
                        WebClient wc = new WebClient();
                        string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "projects?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

                        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                        dynamic obj = serializer.Deserialize(resp, typeof(object));

                        //dynamic c = System.Web.Helpers.Json.Decode(resp);

                        for(int i = 0; i<obj.Length;i++)
                        {
                            DDls.Add(obj[i]["projectId"].ToString(), obj[i]["name"].ToString());
                        }

                        break;
                    case "DataType":
                        DDls.Add("Item", "Item");
                        DDls.Add("Assignment", "Assignment");
                        break;
                    case "UserMapType":
                        DDls.Add("Email", "Email");
                        break;
                }
 
            }
            catch (Exception ex)
            {
                log.LogMessage("Error (GDDV): " + ex.Message, IntegrationLogType.Error);
            }
            return DDls;

        }

        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            Message = "";
            try
            {
                FBConnection cn = new FBConnection(WebProps, Log);

                Message = cn.FBGUID;

                return true;
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
                return false;
            }
            
        }


    }
}
