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
            string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "routeditems?projectid=" + _webprops.Properties["Folder"].ToString() + "&userid=0&routedobjecttype=6&fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

            dynamic c = System.Web.Helpers.Json.Decode(resp);

            for (int i = 0; i < c.Length; i++)
            {

                DataRow dr = Items.NewRow();

                Items.Rows.Add(ProcessAssignmentRow(dr, c[i], Items.Columns));

            }
        
            return Items;
        }

        private DataRow ProcessAssignmentRow(DataRow dr, dynamic o, DataColumnCollection Columns)
        {
            foreach (DataColumn dc in Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    dr[dc.ColumnName] = o.routedItemId;
                }
                else if (dc.ColumnName == "relFileId")
                {
                    dr[dc.ColumnName] = o.relFileId;
                }
                else if (dc.ColumnName == "comment")
                {
                    dr[dc.ColumnName] = "You have a Workflow Task. Use the Worklow buttons to accept or reject your task.<br><br>Item: " + o.field[1];
                }
                else if (dc.ColumnName == "stepName")
                {
                    dr[dc.ColumnName] = o.stepName;
                }
                else if (dc.ColumnName == "userId")
                {

                    dr[dc.ColumnName] = o.userId;
                    try
                    {
                        WebClient wc = new WebClient();
                        string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "users/" + o.userId + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

                        dynamic c = System.Web.Helpers.Json.Decode(resp);


                    }
                    catch { }

                }
                else if (dc.ColumnName == "dueDate")
                {
                    dr[dc.ColumnName] = o.dueDate;
                }
                else if (dc.ColumnName.StartsWith("itemfield:"))
                {
                    dr[dc.ColumnName] = o.field[int.Parse(dc.ColumnName.Substring(10))];
                }
            }

            return dr;
        }

        public DataTable GetItem(DataTable Items, string ItemID)
        {
            WebClient wc = new WebClient();
            string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "files/" + ItemID + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

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
                                dr[dc.ColumnName] = c.field[field - 1];
                            }
                            catch { }
                        }
                    }


                }
                Items.Rows.Add(dr);


            }

            return Items;
        }


        public DataTable GetAssignment(DataTable Items, string ItemID)
        {
            WebClient wc = new WebClient();
            string resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "routedItems/" + ItemID + "?fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

            dynamic c = System.Web.Helpers.Json.Decode(resp);
            
            DataRow dr = Items.NewRow();

            Items.Rows.Add(ProcessAssignmentRow(dr, c[0], Items.Columns));

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
            string r = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                r = streamReader.ReadToEnd();
            }

            resp = wc.DownloadString(_webprops.Properties["APIUrl"].ToString() + "routeditems?projectid=" + _webprops.Properties["Folder"].ToString() + "&userid=0&routedobjecttype=6&filter=routedobjectid_" + docId + "&fbsite=" + _webprops.Properties["SiteUrl"].ToString() + "&guid=" + cn.FBGUID);

            c = System.Web.Helpers.Json.Decode(resp);

            if (_webprops.IntegrationAPIUrl != "")
            {
                try
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[0].userId.ToString() != "0")
                        {
                            IntegrationAPI.Integration integ = new IntegrationAPI.Integration();
                            integ.Url = _webprops.IntegrationAPIUrl;
                            integ.PostItemSimple(_webprops.Properties["RelatedAssign"].ToString(), c[0].userId);
                        }
                    }
                }
                catch { }
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
