using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Web.Services.Protocols;
using System.Net;
using System.Threading;

namespace EPMLiveEnterprise
{
    public partial class getpsproject : LayoutsPageBase
    {
       
        protected int itemId;

        protected string pwaUrl;
        protected string projectName;

        protected enum ActiveViewIndex
        {
            LoadingView = 0,
            TemplateView = 1,
            ProjectView = 2
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            // Grab ItemId from querystring
            itemId = Convert.ToInt32(Request["ID"]);

            if (!IsPostBack)
            {
                using (SPWeb spWeb = SPContext.Current.Web)
                {
                    SPList list = spWeb.Lists[new Guid(Request["ListId"])];
                    spWeb.AllowUnsafeUpdates = true;
                    if (!list.Fields.ContainsField("projectguid"))
                    {
                        list.Fields.Add("projectguid", SPFieldType.Text, false);
                        SPField field = list.Fields["projectguid"];
                        field.Hidden = true;
                        field.Update();
                        list.Update();
                    }
                    // Find the item by ID
                    SPListItem item;
                    try
                    {
                        item = list.Items.GetItemById(itemId);
                    }
                    catch
                    {
                        return;
                    }

                    // Get the Project Name
                    ViewState["projectName"] = item.Title;
                    projectName = item.Title;
                    // Get the Site URL
                    ViewState["siteURL"] = GetPWAURL();
                    pwaUrl = ViewState["siteURL"].ToString();

                    // Create instance of Project
                    WebSvcProject.Project project = new WebSvcProject.Project();
                    project.Url = ViewState["siteURL"] + "/_vti_bin/psi/project.asmx";
                    project.UseDefaultCredentials = true;

                    if (item["projectguid"] != null && item["projectguid"].ToString().Length > 0)
                    {
                        Guid projectGuid = new Guid(item["projectguid"].ToString());

                        try
                        {
                            WebSvcProject.ProjectDataSet projectDs = new WebSvcProject.ProjectDataSet();
                            // Read project from PS using project GUID
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                projectDs = project.ReadProject(projectGuid, WebSvcProject.DataStoreEnum.WorkingStore);
                            });
                            // Does it exist?
                            if (projectDs != null && projectDs.Tables.Count > 0)
                            {
                                pnlOpenProject.Visible = true;
                            }
                            else
                            {
                                pnlNewProject.Visible = true;
                                PopulateListbox(project);
                            }
                            lblError.Visible = false;
                        }
                        catch (WebException wEx)
                        {
                            lblError.Visible = true;
                            if (wEx.Message.Contains("Object moved"))
                                lblError.Text = "Error: This site is not configured for use with Project Server.";
                            else
                                lblError.Text = "Error: " + wEx.Message;
                        }
                        catch (Exception ex)
                        {
                            lblError.Visible = true;
                            if (ex.Message.Contains("The request failed with an empty response"))
                                lblError.Text = "Error: This site is not configured for use with Project Server.";
                            else
                                lblError.Text = "Error: " + ex.Message;
                        }
                    }
                    else
                    {
                        pnlNewProject.Visible = true;
                        PopulateListbox(project);
                    }
                }
            }
        }

        protected void PopulateListbox(WebSvcProject.Project project)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    WebSvcProject.ProjectDataSet readTemplateDs = project.ReadProjectList();

                    // Create <Blank Project> item
                    ListItem newItem = new ListItem("<Blank Project>", Guid.Empty.ToString());
                    ListBox1.Items.Add(newItem);

                    foreach (WebSvcProject.ProjectDataSet.ProjectRow row in readTemplateDs.Project)
                    {
                        WebSvcProject.ProjectDataSet dsproject = project.ReadProject(row.PROJ_UID, WebSvcProject.DataStoreEnum.WorkingStore);
                        if (dsproject != null && dsproject.Project[0].PROJ_TYPE == (int)PSLibrary.Project.ProjectType.Template)
                        {
                            newItem = new ListItem(dsproject.Project[0].PROJ_NAME, dsproject.Project[0].PROJ_UID.ToString());
                            ListBox1.Items.Add(newItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    if (ex.Message.Contains("The request failed with an empty response"))
                        lblError.Text = "Error: This site is not configured for use with Project Server.";
                    else
                        lblError.Text = "Error: " + ex.Message;
                }
            });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Get the template Guid from the selected item in the list
                Guid templateGuid = new Guid(ListBox1.SelectedValue);

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWeb spWeb = SPContext.Current.Web;
                    {
                        // Create instance of Project
                        WebSvcProject.Project project = new WebSvcProject.Project();
                        project.Url = ViewState["siteURL"] + "/_vti_bin/psi/project.asmx";
                        project.UseDefaultCredentials = true;

                        // Guid for new project
                        Guid newProjectGuid = Guid.NewGuid();

                        if (templateGuid == Guid.Empty)
                        {
                            WebSvcProject.ProjectDataSet dsProjectDataSet = new WebSvcProject.ProjectDataSet();
                            WebSvcProject.ProjectDataSet.ProjectRow projectRow = dsProjectDataSet.Project.NewProjectRow();
                            projectRow.PROJ_UID = newProjectGuid;
                            projectRow.PROJ_NAME = ViewState["projectName"].ToString();
                            projectRow.PROJ_INFO_START_DATE = System.DateTime.Now;
                            projectRow.PROJ_TYPE = 0; //0 is for project and 1 is for template
                            dsProjectDataSet.Project.AddProjectRow(projectRow);

                            //create a project 
                            Guid job = Guid.NewGuid();
                            project.QueueCreateProject(job, dsProjectDataSet, false);
                            WaitForQueue(job);

                            job = Guid.NewGuid();
                            project.QueuePublish(job, newProjectGuid, true, spWeb.Url);
                            WaitForQueue(job);
                        }
                        else
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                Guid owner = getResourceUid();
                                newProjectGuid = project.CreateProjectFromTemplate(templateGuid, ViewState["projectName"].ToString());

                                WebSvcProject.ProjectDataSet templateProject;
                                Guid jobGuid = Guid.NewGuid();
                                Guid sessionGuid = Guid.NewGuid();

                                project.CheckOutProject(newProjectGuid, sessionGuid, "");
                                templateProject = project.ReadProject(newProjectGuid, WebSvcProject.DataStoreEnum.WorkingStore);
                                WebSvcProject.ProjectDataSet temp = ((WebSvcProject.ProjectDataSet)(templateProject.Copy()));


                                temp.Tables[temp.Project.TableName].Rows[0][temp.Project.ProjectOwnerIDColumn] = owner;
                                WebSvcProject.ProjectDataSet updateProjectDataSet = new WebSvcProject.ProjectDataSet();
                                updateProjectDataSet.Project.Merge(temp.Tables[temp.Project.TableName], true);
                                updateProjectDataSet = ((WebSvcProject.ProjectDataSet)updateProjectDataSet.GetChanges(DataRowState.Modified));

                                project.QueueUpdateProject(jobGuid, sessionGuid, updateProjectDataSet, false);
                                WaitForQueue(jobGuid);

                                jobGuid = Guid.NewGuid();
                                project.QueueCheckInProject(jobGuid, newProjectGuid, true, sessionGuid, "");
                                WaitForQueue(jobGuid);
                            });
                        }

                        SPList list = spWeb.Lists["Project Center"];
                        spWeb.AllowUnsafeUpdates = true;
                        // Find the item by ID
                        SPListItem item = list.Items.GetItemById(itemId);
                        // Set the new project Guid in the List
                        item["projectguid"] = newProjectGuid;
                        item.SystemUpdate();
                        pwaUrl = ViewState["siteURL"].ToString();
                        projectName = item.Title;
                        // Add record to PublisherCheck Table
                        InsertRowIntoPublisherCheck(newProjectGuid);

                        pnlOpenProject.Visible = true;
                        pnlNewProject.Visible = false;
                    }
                });
            }
            catch (SoapException ex)
            {
                PSLibrary.PSClientError error = new PSLibrary.PSClientError(ex);
                PSLibrary.PSErrorInfo[] errors = error.GetAllErrors();
                string errMess = "Error: ";
                for (int i = 0; i < errors.Length; i++)
                {
                    errMess += ex.Message.ToString() + "  ";
                    errMess += "PSCLientError Output: ";
                    errMess += errors[i].ErrId.ToString() + "  ";

                    for (int j = 0; j < errors[i].ErrorAttributes.Length; j++)
                    {
                        errMess += "  " + errors[i].ErrorAttributeNames()[j] + ": " + errors[i].ErrorAttributes[j];
                    }
                }
                lblError.Text = errMess;
            }
            catch (WebException ex)
            {
                string errMess = ex.Message.ToString() +
                   "\n\nLog on, or check the Project Server Queuing Service";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "<script language='javascript'>alert('" + errMess + "');</script>");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "<script language='javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        private void WaitForQueue(Guid jobId)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                WebSvcQueueSystem.QueueSystem q = new EPMLiveEnterprise.WebSvcQueueSystem.QueueSystem();
                q.Url = ViewState["siteURL"] + "/_vti_bin/psi/queuesystem.asmx";
                q.UseDefaultCredentials = true;
                WebSvcQueueSystem.JobState jobState;
                const int QUEUE_WAIT_TIME = 2; // two seconds
                bool jobDone = false;
                string xmlError = string.Empty;
                int wait = 0;

                //Wait for the project to get through the queue
                // - Get the estimated wait time in seconds
                wait = q.GetJobWaitTime(jobId);

                // - Wait for it
                Thread.Sleep(wait * 1000);
                // - Wait until it is done.

                do
                {
                    // - Get the job state
                    jobState = q.GetJobCompletionState(jobId, out xmlError);

                    if (jobState == WebSvcQueueSystem.JobState.Success)
                    {
                        jobDone = true;
                    }
                    else
                    {
                        if (jobState == WebSvcQueueSystem.JobState.Unknown
                        || jobState == WebSvcQueueSystem.JobState.Failed
                        || jobState == WebSvcQueueSystem.JobState.FailedNotBlocking
                        || jobState == WebSvcQueueSystem.JobState.CorrelationBlocked
                        || jobState == WebSvcQueueSystem.JobState.Canceled)
                        {
                            // If the job failed, error out
                            throw (new ApplicationException("Queue request " + jobState + " for Job ID " + jobId + ".\r\n" + xmlError));
                        }
                        else
                        {
                            Thread.Sleep(QUEUE_WAIT_TIME * 1000);
                        }
                    }
                }
                while (!jobDone);
            });
        }


        private Guid getResourceUid()
        {
            WebSvcResource.Resource re = new EPMLiveEnterprise.WebSvcResource.Resource();
            re.Url = ViewState["siteURL"] + "/_vti_bin/PSI/resource.asmx";
            re.UseDefaultCredentials = true;
            return re.GetCurrentUserUid();
        }

        private void InsertRowIntoPublisherCheck(Guid projectGuid)
        {
            // prepare command string
            string insertString = @"INSERT INTO [PUBLISHERCHECK] 
                ([projectguid]
                           ,[webguid]                           
                           ,[checkbit]
                           ,[weburl])
                     VALUES
                           (@projectguid,
                            @webguid,  
                            @checkbit,                        
                            @weburl)";

            SPSecurity.RunWithElevatedPrivileges(
                delegate()
                {
                    // Get Site ID
                    SPSite site = null;
                    Guid siteID;
                    try
                    {
                        site = new SPSite(ViewState["siteURL"].ToString());
                        siteID = site.ID;
                    }
                    finally
                    {
                        if (site != null)
                        {
                            site.Close();
                        }
                    }

                    // Instantiate the connection
                    SqlConnection conn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));

                    try
                    {
                        // Open the connection
                        conn.Open();

                        // Instantiate a new command with a query and connection
                        SqlCommand cmd = new SqlCommand(insertString, conn);

                        // Add Parameters
                        cmd.Parameters.Add("@projectguid", SqlDbType.UniqueIdentifier, 16);
                        cmd.Parameters.Add("@webguid", SqlDbType.UniqueIdentifier, 16);
                        cmd.Parameters.Add("@weburl", SqlDbType.VarChar, 255);
                        cmd.Parameters.Add("@checkbit", SqlDbType.Bit, 1);

                        // Set Parameter values
                        cmd.Parameters["@projectguid"].Value = projectGuid;
                        cmd.Parameters["@webguid"].Value = siteID;
                        cmd.Parameters["@weburl"].Value = SPContext.Current.Web.Url;
                        cmd.Parameters["@checkbit"].Value = false;

                        // Call ExecuteNonQuery to send command
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        // Close the connection
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                });
        }

        private string GetPWAURL()
        {
            string siteURL = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(
                delegate()
                {
                    using (SPWeb spWeb = SPContext.Current.Web)
                    {
                        spWeb.Site.CatchAccessDeniedException = false;

                        siteURL = EPMLiveCore.CoreFunctions.getConfigSetting(spWeb, "EPMLiveProjectServerURL");

                        if (siteURL == "")
                        {
                            siteURL = spWeb.Site.Url;
                        }
                    }
                }
            );

            return siteURL;
        }
    }
}
