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

namespace UplandIntegrations
{
    public class FileBound : IIntegrator, IIntegratorControls
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

            return l;
        }
        public string GetURL(WebProperties WebProps, IntegrationLog Log, string control, string url)
        {
            return "";
        }
        public string GetControlCode(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control)
        {
            return "";
        }

        #region properties

        string FBGUID = "";

        #endregion

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
            TransactionTable table = new TransactionTable();


            
            
            return table;
        }

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            TransactionTable trans = new TransactionTable();

            try
            {
                GetFBGuid(WebProps);

                foreach(DataRow dr in Items.Rows)
                {
                    WebClient wc = new WebClient();
                    string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "files/" + dr["ID"].ToString() + "?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);

                    dynamic c = System.Web.Helpers.Json.Decode(resp);

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebProps.Properties["APIUrl"].ToString() + "files/" + dr["ID"].ToString() + "?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "PUT";

                    int indexOfField = resp.IndexOf("\"field\":[");
                    int indexOfEndField = resp.IndexOf("\"],", indexOfField);

                    string firstResp = resp.Substring(0, indexOfField + 9);
                    string lastResp = resp.Substring(indexOfEndField + 1);

                    string field = "";

                    for (int i = 0; i < 21; i++)
                    {
                        string val = "";
                        try
                        {
                            val = dr[i.ToString()].ToString();
                        }
                        catch { }
                        field += "\"" + val + "\",";
                    }
                    field = field.Trim(',');

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(firstResp + field + lastResp);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseText = streamReader.ReadToEnd();
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
                GetFBGuid(WebProps);

                WebClient wc = new WebClient();
                string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "projects/" + WebProps.Properties["Folder"].ToString() + "/fields?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);

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
                GetFBGuid(WebProps);

                WebClient wc = new WebClient();
                string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "projects/" + WebProps.Properties["Folder"].ToString() + "/files?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);

                dynamic c = System.Web.Helpers.Json.Decode(resp);
                 
                for (int i = 0; i < c.Length; i++)
                {
                    DataRow dr = Items.NewRow();

                    foreach (DataColumn dc in Items.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            dr[dc.ColumnName] = c[i].fileId;
                        }
                        else
                        {
                            int field = 0;
                            int.TryParse(dc.ColumnName, out field);
                            if (field != 0)
                            {
                                try
                                {
                                    dr[dc.ColumnName] = c[i].field[field];
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

        public DataTable GetItem(WebProperties WebProps, IntegrationLog Log, string ItemID, DataTable Items)
        {
            try
            {
                GetFBGuid(WebProps);

                WebClient wc = new WebClient();
                string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "files/" + ItemID + "?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);

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
                GetFBGuid(WebProps);

                switch (Property)
                {
                    case "Folder":
                        WebClient wc = new WebClient();
                        string resp = wc.DownloadString(WebProps.Properties["APIUrl"].ToString() + "projects?fbsite=" + WebProps.Properties["SiteUrl"].ToString() + "&guid=" + FBGUID);

                        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                        dynamic obj = serializer.Deserialize(resp, typeof(object));

                        //dynamic c = System.Web.Helpers.Json.Decode(resp);

                        for(int i = 0; i<obj.Length;i++)
                        {
                            DDls.Add(obj[i]["projectId"].ToString(), obj[i]["name"].ToString());
                        }

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
                GetFBGuid(WebProps);

                Message = FBGUID;

                return true;
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
                return false;
            }
            
        }



        #region helpers

        private string GetFBGuid(WebProperties WebProps)
        {
            if (FBGUID == "")
            {
                using (WebClient client = new WebClient())
                {
                    NameValueCollection parameters = new NameValueCollection();
                    parameters.Add("username",  WebProps.Properties["Username"].ToString());
                    parameters.Add("password", WebProps.Properties["Password"].ToString());

                    byte[] responseBytes = client.UploadValues(WebProps.Properties["APIUrl"].ToString() + "login?fbsite=" + WebProps.Properties["SiteUrl"].ToString(), "POST", parameters);
                    string responseBody = (new System.Text.UTF8Encoding()).GetString(responseBytes);

                    // remove the double quotes around the guid:
                    if (responseBody.Length > 0 && responseBody.EndsWith("\"")) responseBody = responseBody.Remove(responseBody.Length - 1);
                    if (responseBody.Length > 0 && responseBody.StartsWith("\"")) responseBody = responseBody.Remove(0, 1);
                    FBGUID = responseBody;
                }
            }

            return FBGUID;
            
        }

        #endregion

    }
}
