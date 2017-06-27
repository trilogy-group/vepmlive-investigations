using System;
using System.Net;
using System.Web;
using EPMLiveCore;
using EPMLiveCore.Layouts.epmlive;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using EPMLiveWebParts.SSRS2010;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data;
using System.Text;
using System.Linq;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class SSRSNativeReportViewer : LayoutsPageBase
    {
        private string webUrl = string.Empty;
        private string itemUrl = string.Empty;
        private bool isNativeMode = false;
        
        private string _reportingServicesUrl = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["weburl"]))
            {
                webUrl = Request["weburl"];
            }

            if (!string.IsNullOrEmpty(Request["itemurl"]))
            {
                itemUrl = Request["itemurl"];
            }

            if (!string.IsNullOrEmpty(Request["isNativeMode"]))
            {
                bool.TryParse(Request["isNativeMode"], out isNativeMode);
            }
        }

        private static ReportingService2010 SetupSSRSService()
        {
            ReportingService2010 srs2010;
            var username = "";
            var password = "";
            var chrono = SPContext.Current.Site.WebApplication.GetChild<ReportAuth>("ReportAuth");
            if (chrono != null)
            {
                username = chrono.Username;
                password = CoreFunctions.Decrypt(chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
            }

            srs2010 = new ReportingService2010 { UseDefaultCredentials = true };
            var rptWs = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL") + "/ReportService2010.asmx";
            srs2010.Url = rptWs;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (password == "") return;
                srs2010.UseDefaultCredentials = false;
                if (username.Contains("\\"))
                    srs2010.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                else
                    srs2010.Credentials = new NetworkCredential(username, password);
            });
            
            return srs2010;
        }

        [WebMethod]
        public static string GetRegs()
        {
            var itemUrlRequest = HttpContext.Current.Request.QueryString["itemurl"];
            var reportURL = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");
            var addresses = $"{$"{reportURL}/Pages/ReportViewer.aspx?{itemUrlRequest}&rs:Command=Render"}|reportbuilder:Action=Edit&ItemPath={itemUrlRequest}&Endpoint={reportURL}";
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(addresses);
        }

        [WebMethod]
        public static string GetSubscriptions()
        {
            var itemUrlRequest = HttpContext.Current.Request.QueryString["itemurl"];
            var reportURL = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");
            var addresses = $"{reportURL}/{itemUrlRequest}";

            var srs2010 = SetupSSRSService();
            var subsList = srs2010.ListMySubscriptions(itemUrlRequest);

            var ds = new DataSet("Subscriptions");
            System.Data.DataTable table = new System.Data.DataTable("Table");
            //table.Columns.Add("Check");
            table.Columns.Add("Type");
            table.Columns.Add("DeliveryExtension");
            table.Columns.Add("Description");
            table.Columns.Add("Event");
            table.Columns.Add("LastRun");

            foreach (Subscription subsc in subsList)
            {
                table.Rows.Add(subsc.EventType, subsc.DeliverySettings.Extension, subsc.Description, subsc.Status, subsc.LastExecuted);
            }
            //GetAddSubscriptionsFilters();
            ds.Tables.Add(table);
            return DataSetToJSON(ds);
        }

        [WebMethod]
        public static string GetReportParameters()
        {
            var itemUrlRequest = HttpContext.Current.Request.QueryString["itemurl"];
            var reportURL = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");
            var addresses = $"{reportURL}/{itemUrlRequest}";
            var srs2010 = SetupSSRSService();
            
            //string historyId = null;
            //ParameterValue[] parameterValues = null;
            //DataSourceCredentials[] datasourceCred = null;

            //all the parameters of the report will be filled to out parameter 'itemParameter'
            var itemParameters = srs2010.GetItemParameters(itemUrlRequest, null, true, null, null);
            StringBuilder htmlToLoad = new StringBuilder();
            htmlToLoad.Append("<table><tr><th>Parameter</th><th>Source of Value</th><th>Value/Field</th></tr>");

            //string fieldValueHtml = string.Empty;
            //iterate through parameters
            int i = 0;
            foreach (var ip in itemParameters)
            {                         
                htmlToLoad.Append("<tr>");

                htmlToLoad.Append($"<td><p>{ip.Prompt}</p></td>");

                htmlToLoad.Append($"<td><select {(ip.DefaultValues == null ? "disabled" : string.Empty)} id=\"EnterFieldID{i}\" name=\"EnterFieldID{i}\" onchange=\"EnterFieldChange('{i}')\">");
                htmlToLoad.Append($"<option value=\"enter\" {(ip.DefaultValues == null ? "selected" : string.Empty)}>Enter value</option>");
                htmlToLoad.Append($"<option value=\"default\" {(ip.DefaultValues != null ? "selected" : string.Empty)}>Use default value</option>");
                htmlToLoad.Append("</select></td>");

                htmlToLoad.Append("<td>");

                var isDefaultValue = false;
                switch (ip.ParameterTypeName.ToUpper())
                {
                    case "BOOLEAN":
                        htmlToLoad.Append($"<select {(ip.DefaultValues != null ? "disabled" : string.Empty)} {(ip.MultiValue ? "multiple" : string.Empty)} id=\"ValueFieldID{i}\" name=\"ValueFieldID{i}\">");

                        isDefaultValue = (ip.DefaultValues != null && ip.DefaultValues.ToList().Any(x => x != null && x.ToUpper() == "TRUE"));
                        htmlToLoad.Append($"<option value=\"true\" ");
                        htmlToLoad.Append(isDefaultValue ? "selected" : string.Empty);
                        htmlToLoad.Append(">True</option>");

                        isDefaultValue = (ip.DefaultValues != null && ip.DefaultValues.ToList().Any(x => x != null && x.ToUpper() == "FALSE"));
                        htmlToLoad.Append($"<option value=\"false\" ");
                        htmlToLoad.Append(isDefaultValue ? "selected" : string.Empty);
                        htmlToLoad.Append(">False</option>");

                        htmlToLoad.Append("</select>");
                        break;
                    case "STRING":
                    case "INTEGER":
                    case "FLOAT":
                    case "DATETIME":
                        if (ip.ValidValues != null)
                        {
                            htmlToLoad.Append($"<select {(ip.DefaultValues != null ? "disabled" : string.Empty)} {(ip.MultiValue ? "multiple" : string.Empty)}>");
                            ip.ValidValues?.ToList().ForEach(x =>
                            {
                                isDefaultValue = (ip.DefaultValues != null && ip.DefaultValues.ToList().Any(defValue => defValue != null && defValue.ToUpper() == x.Value));

                                htmlToLoad.Append($"<option value=\"{x.Value}\" ");
                                htmlToLoad.Append(ip.DefaultValues != null && isDefaultValue ? "selected" : string.Empty);
                                htmlToLoad.Append($">{x.Value}</option>");
                            });
                            htmlToLoad.Append("</select>");
                        }
                        else
                        {
                            var defaultValues = string.Empty;
                            ip.DefaultValues?.ToList().ForEach(x => defaultValues += x + "||");
                            htmlToLoad.Append($"<input type=\"{(ip.ParameterTypeName.ToUpper() == "DATETIME" ? "datetime-local" : "text")}\" defaultValue=\"{defaultValues}\"/>");
                        }
                        break;
                }

                htmlToLoad.Append("</td>");

                htmlToLoad.Append("</tr>");

                ////check for the parameter I want to get default and available values for
                ////if (pName == ip.Name)
                //{
                //    //get default values
                //    string[] defValues = ip.DefaultValues;

                //    //get valid/available values
                //    ValidValue[] validValues = ip.ValidValues;
                //    foreach (ValidValue vValue in validValues)
                //    {
                //        //ValidValue has Label property and Value property
                //        //if you check the parameters in report designer, every parameter has Label field and Value field
                //        //ddlParamValues.Items.Add(new ListItem(vValue.Label, vValue.Value));
                //    }
                //}

                i++;
            }

            htmlToLoad.Append("</table>");
            //var serverReport = new Microsoft.Reporting.WebForms.ServerReport()
            //{
            //    ReportServerUrl = new Uri(reportURL),
            //    ReportPath = itemUrlRequest,
            //    ReportServerCredentials = new 
            //};

            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(htmlToLoad.ToString());
            //var parameters = serverReport.GetParameters();

            //var extensions = srs2010.ListExtensionTypes();
        }
        

        public static string DataSetToJSON(DataSet ds)
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (System.Data.DataTable dt in ds.Tables)
            {
                object[] arr = new object[dt.Rows.Count + 1];

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    arr[i] = dt.Rows[i].ItemArray;
                }

                dict.Add(dt.TableName, arr);
            }

            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(dict);
        }
    }
}
