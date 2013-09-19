using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveIntegration;
using System.Net;
using System.IO;
using System.Data;

namespace UplandIntegrations.FileBound
{
    internal class FileBoundSystem
    {
        private WebProperties _webprops;
        private IntegrationLog _log;
        private FBConnection cn;

        public FileBoundSystem(WebProperties WebProps, IntegrationLog log)
        {
            _webprops = WebProps;
            _log = log;

            cn = new FBConnection(_webprops, _log);
        }

        public DataTable GetAssignments(DataTable Items, DateTime lastSynch)
        {

            WebClient wc = new WebClient();
            string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "routeditems?projectID=" + _webprops.Properties["Folder"].ToString() + "&fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

            dynamic c = System.Web.Helpers.Json.Decode(resp);

            for (int i = 0; i < c.Length; i++)
            {

                DataRow dr = Items.NewRow();

                foreach (DataColumn dc in Items.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        dr[dc.ColumnName] = c[i].taskId;
                    }
                    else if (dc.ColumnName == "itemId")
                    {
                        dr[dc.ColumnName] = c[i].fileId;
                    }
                    else if (dc.ColumnName == "itemName")
                    {
                        dr[dc.ColumnName] = c[i].fileId + " - Workflow Task";
                    }
                    else if (dc.ColumnName == "Body")
                    {
                        dr[dc.ColumnName] = "You have a Workflow Task. Use the Worklow buttons to accept or reject your task.<br><br>Item: " + c[i].fileId;
                    }
                }

                Items.Rows.Add(dr);

            }
        
            return Items;
        }

        public DataTable GetItems(DataTable Items, DateTime lastSynch)
        {
            WebClient wc = new WebClient();
            string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "projects/" + _webprops.Properties["Folder"].ToString() + "/files?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

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
                                dr[dc.ColumnName] = c[i].field[field - 1];
                            }
                            catch { }
                        }
                    }


                }
                Items.Rows.Add(dr);
            }

            return Items;
        }

        public void UpdateAssignment(DataRow dr, ref TransactionTable trans)
        {

        }

        public void UpdateItem(DataRow dr, ref TransactionTable trans)
        {
            string field = "\"field\":[";

            for (int i = 1; i <= 20; i++)
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
            field = field + "]";

            if (dr["ID"].ToString() != "")
            {
                bool bFound = false;

                try
                {
                    WebClient wc = new WebClient();
                    string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "files/" + dr["ID"].ToString() + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

                    dynamic c = System.Web.Helpers.Json.Decode(resp);

                    bFound = true;
                }
                catch { }

                if (bFound)
                {
                    string id = "";

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(_webprops.Properties["APIUrl"].ToString() + "files/" + dr["ID"].ToString() + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write("{" + field + "}");
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        id = streamReader.ReadToEnd();
                    }

                    if (id != "0")
                        trans.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.UPDATE);
                    else
                        trans.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.FAILED);
                }
                else
                {
                    trans.AddRow(dr["SPID"].ToString(), AddItem(field), TransactionType.INSERT);
                }
            }
            else
            {
                trans.AddRow(dr["SPID"].ToString(), AddItem(field), TransactionType.INSERT);
            }
        }

        private string AddDocument(string id)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_webprops.Properties["APIUrl"].ToString() + "documents?fileId=" + id + "&name=workflowdoc&fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "PUT";

            string docId = "";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("");
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                docId = streamReader.ReadToEnd();
            }

            return docId;
        }

        private void StartWorkflow(string docId)
        {

            WebClient wc = new WebClient();
            string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "routes/" + _webprops.Properties["Folder"].ToString() + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

            dynamic c = System.Web.Helpers.Json.Decode(resp);

            string routeId = c[0].id.ToString();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_webprops.Properties["APIUrl"].ToString() + "routes/" + routeId + "?documentid=" + docId + "&fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("");
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var id = streamReader.ReadToEnd();
            }

        }

        public void DeleteItem(DataRow dr, ref TransactionTable trans)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_webprops.Properties["APIUrl"].ToString() + "files/" + dr["ID"].ToString() + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "DELETE";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("");
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var id = streamReader.ReadToEnd();
                if (id == "true")
                {
                    trans.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.DELETE);
                }
                else
                {
                    trans.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.FAILED);
                }
            }

        }

        public void DeleteAssignment(DataRow dr, ref TransactionTable trans)
        {

        }


        private string AddItem(string fields)
        {
            string id = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_webprops.Properties["APIUrl"].ToString() + "files?projectid=" + _webprops.Properties["Folder"].ToString() + "&fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("{" + fields + "}");
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                id = streamReader.ReadToEnd();
            }


            if (id != "0")
            {

                string docId = AddDocument(id);
                if (docId != "0")
                {

                    StartWorkflow(docId);

                }


                return id;
            }
            else
                throw new Exception("Unable to Add Item");
        }
    }
}
