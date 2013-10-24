using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Collections;


namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class gotoremote : LayoutsPageBase
    {
        protected string error = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";

            bool bIframe = false;
            string windowStyle = "";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                if (!string.IsNullOrEmpty(Request["listid"]))
                {
                    Guid listId = new Guid(Request["listid"]);

                    API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
                    DataTable dt = core.GetIntegrationControl(listId, Request["Control"]);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        string intid = "";
                        try
                        {
                            SPList list = Web.Lists[listId];
                            SPListItem li = list.GetItemById(int.Parse(Request["itemid"]));

                            intid = li["INTUID" + dr["INT_COLID"].ToString()].ToString();
                        }
                        catch { }
                        windowStyle = dr["WINDOWSTYLE"].ToString();
                        if (intid != "")
                        {
                            url = core.GetControlURL(new Guid(dr["INT_LIST_ID"].ToString()), listId, Request["Control"], intid);
                            
                            if (dr["WINDOWSTYLE"].ToString() == "4")
                            {
                                bIframe = true;
                            }
                        }
                        else
                        {

                            error = "Could not find external itemid";

                        }
                    }
                    else
                    {
                        error = "Could not find control";
                    }
                }
                else
                {
                    API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
                    DataTable dt = core.GetIntegrationControlByIntId(new Guid(Request["integrationid"]), Request["Control"]);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        Hashtable hshParams = new Hashtable();
                        hshParams.Add("intlistuid", Request["integrationid"]);

                        url = core.GetControlURL(new Guid(Request["integrationid"]), new Guid(dr["LIST_ID"].ToString()), Request["Control"], "");


                        if (dr["WINDOWSTYLE"].ToString() == "4")
                        {
                            bIframe = true;
                        }
                    }
                    else
                    {
                        error = "Could not find control";
                    }
                }
            });

            if (!string.IsNullOrEmpty(url))
            {

                if (bIframe)
                {
                    error += "<script language=\"javascript\">\r\n";
                    //error += "function LoadInt2(){\r\n";
                    //error += "OpenIntegrationPage('" + Request["Control"] + ".1','','');\r\n";
                    //if (Request["isdlg"] == "1")
                    //{
                    //        error += "SP.SOD.execute('SP.UI.dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 0, '');";
                    //}
                    //else
                    //{
                    //    if (!System.IO.Path.GetFileName(Request.UrlReferrer.ToString()).StartsWith("gotoremote.aspx"))
                    //        error += "location.href='" + Request.UrlReferrer.ToString() + "';\r\n";
                    //}
                    //error += "}\r\n";
                    //error += "function LoadInt(){\r\n";
                    //error += "var sandboxSupported = \"sandbox\" in document.createElement(\"iframe\");\r\n";
                    //error += "if(sandboxSupported){\r\n";
                    error += "ifrm = document.createElement(\"IFRAME\"); \r\n";
                    error += "ifrm.setAttribute(\"src\", \"" + url + "\");\r\n";
                    error += "ifrm.setAttribute(\"id\", \"frmRemote\");\r\n"; 
                    error += "ifrm.style.width = \"100%\"; \r\n";
                    error += "ifrm.style.height = 600 + \"px\"; \r\n";
                    //error += "ifrm.setAttribute(\"sandbox\", \"allow-scripts allow-forms allow-same-origin allow-popups\");\r\n"; 
                    error += "document.getElementById(\"DeltaPlaceHolderMain\").appendChild(ifrm); \r\n";
                    //error += "}else{\r\n";
                    //error += "ExecuteOrDelayUntilScriptLoaded(LoadInt2, 'EPMLive.js');\r\n";
                    //error += "}}\r\n";
                    //error += "SP.SOD.executeFunc(\"sp.js\", null, LoadInt);\r\n";
                    error += "</script>";
                        
                        //<iframe src=\"" + url + "\" id=\"frmRemote\" style=\"width:100%;height:600px\" sandbox=\"allow-forms allow-scripts\">";
                }
                else
                {
                    Response.Redirect(url);
                    /*if (Request["isdlg"] == "1")
                    {
                        error += "<script language=\"javascript\">\r\n";
                        error += "function LoadInt(){\r\n";
                        error += "var sandboxSupported = \"sandbox\" in document.createElement(\"iframe\");\r\n";
                        error += "if(sandboxSupported){\r\n";
                        error += "ifrm = document.createElement(\"IFRAME\"); \r\n";
                        error += "ifrm.setAttribute(\"src\", \"" + url + "\");\r\n";
                        error += "ifrm.style.width = \"100%\"; \r\n";
                        error += "ifrm.style.height = 600 + \"px\"; \r\n";
                        error += "ifrm.setAttribute(\"sandbox\", \"allow-scripts allow-forms allow-same-origin allow-popups\");\r\n";
                        error += "document.getElementById(\"DeltaPlaceHolderMain\").appendChild(ifrm); \r\n";
                        error += "}else{\r\n";
                        error += "location.href='" + url + "'\r\n";
                        error += "}}\r\n";
                        error += "SP.SOD.executeFunc(\"sp.js\", null, LoadInt);\r\n";
                        error += "</script>";
                    }
                    else if (Request.UrlReferrer == null)
                    {
                        Response.Redirect(url);
                    }
                    else if (error == "")
                    {
                        error = "<script language=\"javascript\">\r\n";
                        error += "function LoadInt1(){\r\n";
                        error += "ExecuteOrDelayUntilScriptLoaded(LoadInt2, 'EPMLive.js');\r\n";
                        error += "}\r\n";
                        error += "function LoadInt2(){\r\n";
                        error += "OpenIntegrationPage('" + Request["Control"] + "." + windowStyle + "','','');\r\n";
                        if (!System.IO.Path.GetFileName(Request.UrlReferrer.ToString()).StartsWith("gotoremote.aspx"))
                            error += "location.href='" + Request.UrlReferrer.ToString() + "';\r\n";
                        error += "}\r\n";
                        error += "SP.SOD.executeFunc(\"sp.js\", null, LoadInt1);\r\n";
                        error += "</script>";
                    }*/
                }
            }
        }

    }
}
