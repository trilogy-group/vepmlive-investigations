using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveCore
{
    public partial class getproject : System.Web.UI.Page
    {
        protected string filePath = "";
        protected DropDownList ddlTemplates;
        protected Button btnOk;
        protected string sDocTmpltURL = "";
        protected SPFile newFile = null;
        protected string projectname;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;
                {
                    web.AllowUnsafeUpdates = true;
                    try
                    {
                        SPList list = web.Lists[new Guid(Request["listID"])];
                        SPListItem li = list.GetItemById(int.Parse(Request["ID"]));

                        projectname = li.Title;
                        if (projectname != null)
                        {
                            SPDocumentLibrary oDocLib = null;
                            try
                            {
                                oDocLib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                            }
                            catch { }

                            if (oDocLib != null)
                            {
                                if (oDocLib.RootFolder.Files.Count > 0)
                                {
                                    try
                                    {
                                        newFile = oDocLib.RootFolder.Files[projectname + ".mpp"];
                                    }
                                    catch { }
                                }
                                if (newFile == null)
                                {
                                    if (!oDocLib.AllowContentTypes)
                                    {
                                        sDocTmpltURL = oDocLib.DocumentTemplateUrl;
                                        loadFile(oDocLib, web.Url + "/" + sDocTmpltURL, projectname);
                                        redirect(filePath);

                                    }
                                    else
                                    {
                                        if (oDocLib.ContentTypes.Count == 2) // includes the one default folder in content types
                                        {
                                            sDocTmpltURL = oDocLib.ContentTypes[0].DocumentTemplateUrl;
                                            loadFile(oDocLib, SPContext.Current.Site.MakeFullUrl(sDocTmpltURL), projectname);
                                            redirect(filePath);
                                        }
                                        else if (oDocLib.ContentTypes.Count > 2)
                                        {
                                            foreach (SPContentType oCT in oDocLib.ContentTypes)
                                            {
                                                if (oCT.DocumentTemplate.Trim() != "")
                                                {
                                                    try
                                                    {
                                                        ListItem liTmplt = new ListItem(oCT.Name, SPContext.Current.Site.MakeFullUrl(oCT.DocumentTemplateUrl));
                                                        ddlTemplates.Items.Add(liTmplt);
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    filePath = newFile.ServerRelativeUrl;
                                    redirect(filePath);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    web.AllowUnsafeUpdates = false;
                    //web.Close();
                }
            }
        }

        private void redirect(string filePath)
        {
            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/openprojectplan.aspx?filepath=" + filePath + "&isDlg=1&Source=" + Request["Source"], Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            else
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/openprojectplan.aspx?filepath=" + filePath + "&isDlg=1", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        private void loadFile(SPDocumentLibrary oDocLib, string sDocTmpltURL, string sNewFileName)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
            delegate (
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var webClient = new WebClient())
                {
                    webClient.UseDefaultCredentials = true;

                    webClient.Headers.Add(HttpRequestHeader.Cookie, Request.Headers["Cookie"]);

                    var fileBytes = webClient.DownloadData(sDocTmpltURL);

                    newFile = oDocLib.RootFolder.Files.Add(sNewFileName + ".mpp", fileBytes);
                    try
                    {
                        newFile.ReleaseLock(newFile.LockId);
                    }
                    catch (Exception ex)
                    {
                        SystemTrace.WriteLine(ex.ToString());
                    }

                    filePath = newFile.ServerRelativeUrl;
                }
            });
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string docTmpl = ddlTemplates.SelectedValue;
                string url = SPContext.Current.Web.ServerRelativeUrl;
                projectname = Request["projectname"];
                if (projectname != null)
                {
                    SPWeb web = SPContext.Current.Web;
                    {
                        web.AllowUnsafeUpdates = true;
                        SPDocumentLibrary oDocLib = null;
                        try
                        {
                            oDocLib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                        }
                        catch { }
                        if (oDocLib != null)
                        {
                            loadFile(oDocLib, docTmpl, projectname);
                            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/openprojectplan.aspx?filepath=" + System.Web.HttpUtility.HtmlEncode(filePath) + "&isDlg=1", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                        }
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch { }
        }
    }
}
