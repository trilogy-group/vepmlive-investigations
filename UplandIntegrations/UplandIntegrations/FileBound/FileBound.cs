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

        public List<string> GetLocalControls(WebProperties WebProps, IntegrationLog Log)
        {
            List<string> l = new List<string>();

            l.Add("WorkflowButtons");

            return l;
        }
        public List<IntegrationControl> GetRemoteControls(WebProperties WebProps, IntegrationLog Log)
        {
            List<IntegrationControl> l = new List<IntegrationControl>();

            IntegrationControl i = new IntegrationControl();
            i.Control = "Docs";
            i.Image = "workflows.png";
            i.Title = "View FB Documents";
            i.Window = true;
            l.Add(i);

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
                FBConnection cn = new FBConnection(WebProps, Log);

                switch (Control)
                {
                    case "WorkflowButtons":
                        return Properties.Resources.txtFBWorkFlow.Replace("#FBGUID#", cn.FBGUID).Replace("#APIUrl#", WebProps.Properties["APIUrl"].ToString()).Replace("#SiteUrl#", WebProps.Properties["SiteUrl"].ToString()).Replace("#fileId#", ItemID).Replace("#projectId#", WebProps.Properties["Folder"].ToString());
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

        private string StartWorkflow(WebProperties WebProps, string docid, string FBGUID)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebProps.Properties["APIUrl"].ToString() + "routes/" + WebProps.Properties["Folder"].ToString() + "?documentId=" + docid + "&notes=startworkflow&fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            string routes = "";
            
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                routes = streamReader.ReadToEnd();
            }

            string routeId = "";

            if (routeId != "")
            {

                httpWebRequest = (HttpWebRequest)WebRequest.Create(WebProps.Properties["APIUrl"].ToString() + "routes/" + routeId + "?documentId=" + docid + "&notes=startworkflow&fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "PUT";

                string wfid = "";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write("");
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    wfid = streamReader.ReadToEnd();
                }

                return wfid;
            }
            return "0";
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
                    p.ColumnName = "taskId";
                    p.DiplayName = "Assignment Id (Unique ID)";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "itemId";
                    p.DiplayName = "Item ID";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "itemName";
                    p.DiplayName = "Item Name";
                    cols.Add(p);

                    p = new ColumnProperty();
                    p.ColumnName = "Body";
                    p.DiplayName = "Description";
                    cols.Add(p);
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
                FBConnection cn = new FBConnection(WebProps, Log);

                WebClient wc = new WebClient();
                string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "files/" + ItemID + "?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

                dynamic c = System.Web.Helpers.Json.Decode(resp);

                //for(int i = 0;i<c.Length;i++)
                {
                    DataRow dr = Items.NewRow();

                    foreach (DataColumn dc in Items.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            dr[dc.ColumnName] = c.fileId;
                        }
                        else
                        {
                            int field = 0;
                            int.TryParse(dc.ColumnName, out field);
                            if (field != 0)
                            {
                                try
                                {
                                    dr[dc.ColumnName] = c.field[field];
                                }
                                catch { }
                            }
                        }


                    }
                    Items.Rows.Add(dr);


                }
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
