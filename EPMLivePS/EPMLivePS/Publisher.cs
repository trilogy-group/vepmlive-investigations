using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using EPMLiveCore;
using EPMLiveCore.Helpers;
using EPMLiveEnterprise.WebSvcCustomFields;
using EPMLiveEnterprise.WebSvcLookupTables;
using EPMLiveEnterprise.WebSvcProject;
using EPMLiveEnterprise.WebSvcResource;
using EPMLiveEnterprise.WebSvcStatusing;
using EPMLiveEnterprise.WebSvcWssInterop;
using Microsoft.SharePoint;
using ProjectDataSet = EPMLiveEnterprise.WebSvcProject.ProjectDataSet;
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
    internal partial class Publisher : IDisposable
    {
        private const string ResourceNames = "ResourceNames";
        private const string TaskCenter = "Task Center";
        private const string TransUid = "transuid";
        private const string TaskHierarchy = "TaskHierarchy";
        private const string IsAssignment = "IsAssignment";
        private const string Title = "Title";
        private const string TaskUid = "taskuid";
        private const string TaskOrder = "taskorder";
        private const string Summary = "Summary";
        private const string Notes = "Notes";
        private const string LastPublished = "LastPublished";
        private const string Wbs = "WBS";
        private const string AssignedTo = "AssignedTo";
        private const string ProjectText = "Project";
        private const int PubTypeOne = 1;
        private const int PubTypeTwo = 2;
        private const int PubTypeThree = 3;
        private EventLog myLog = new EventLog("EPM Live", ".", "EPM Live Publisher");
        private Guid taskEntity = new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId);
        private bool _disposed;

        private WebSvcCustomFields.CustomFields pCf;
        private WebSvcResource.Resource pResource;
        private WebSvcProject.Project pService;
        private WebSvcCustomFields.CustomFieldDataSet cfDs;
        private WebSvcLookupTables.LookupTable psiLookupTable;
        private WebSvcStatusing.Statusing Statusing;
        private WebSvcWssInterop.WssInterop pWssInterop;

        private string publishSiteUrl;
        private string projectServerUrl;
        private SPSite mySite;
        private SPWeb mySiteToPublish;
        private Guid projectGuid;
        private Guid mySiteGuid;
        private SqlConnection cn;
        private Hashtable hshCurTasks;
        private ArrayList arrDelTasks;
        private ArrayList arrDelNewTasks;
        private DataTable dtFieldsToPublish;
        private ArrayList arrFieldsToPublish;
        private ArrayList arrPJFieldsToPublish;
        private Hashtable hshTaskCenterFields;
        private Hashtable hshProjectCenterFields;
        private Hashtable hshTaskHierarchy;
        private ProjectWorkspaceSynch workspaceSynch;
        private Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo;
        private Microsoft.Office.Project.Server.Events.ProjectPostPublishEventArgs eventArgs;
        private Guid lastTransUid = new Guid();

        private WebSvcResource.ResourceDataSet rDs;
        private WebSvcCustomFields.CustomFieldDataSet dsFields;
        private WebSvcLookupTables.LookupTableDataSet dsLt;

        private string strTimesheetField = "";

        private StringBuilder sbErrors = new StringBuilder();

        private double pctComplete = 0;

        public Publisher(Microsoft.Office.Project.Server.Library.PSContextInfo c, Microsoft.Office.Project.Server.Events.ProjectPostPublishEventArgs e)
        {
            contextInfo = c;
            eventArgs = e;
            mySiteGuid = contextInfo.SiteGuid;
            myLog.EntryWritten += new EntryWrittenEventHandler(myLog_EntryWritten);
        }

        void myLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            string message = e.Entry.Message;
            sbErrors.Append(message.Replace("\r\n","<br>") + "<br><br><br><br>");
        }

        ~Publisher()
        {
            myLog.Close();
        }

        public void doPublish()
        {
            try
            {
                var dtStart = DateTime.Now;
                arrFieldsToPublish = new ArrayList();
                arrPJFieldsToPublish = new ArrayList();
                hshCurTasks = new Hashtable();
                arrDelTasks = new ArrayList();
                hshTaskCenterFields = new Hashtable();
                hshProjectCenterFields = new Hashtable();
                arrDelNewTasks = new ArrayList();
                mySite = new SPSite(mySiteGuid);

                cn = new SqlConnection(CoreFunctions.getConnectionString(mySite.WebApplication.Id));
                cn.Open();

                using (var sqlCommand = new SqlCommand(
                    "UPDATE publishercheck set percentcomplete=2,laststatusdate=getdate() where projectguid=@projectguid",
                    cn))
                {
                    sqlCommand.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                    sqlCommand.ExecuteNonQuery();
                }

                using (var sqlCommand = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetField'", cn))
                {
                    using (var dReader = sqlCommand.ExecuteReader())
                    {
                        if (dReader.Read())
                        {
                            strTimesheetField = dReader.GetString(0);
                        }
                    }
                }

                PopulatePublisherCheck();

                UpdatePublisherCheck(dtStart);

                cn.Close();
            }
            catch (SoapException soapException)
            {
                myLog.WriteEntry($"Soap Error: {soapException.Message}{soapException.Detail}", EventLogEntryType.Error, 302);
                HandleException(soapException, "Soap Error: ");
            }
            catch (Exception exception)
            {
                myLog.WriteEntry($"Error: {exception.Message}{exception.StackTrace}", EventLogEntryType.Error, 300);
                HandleException(exception, "Error: ");
            }
        }

        private void HandleException(Exception exception, string errorText)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (cn != null && cn.State == ConnectionState.Open)
            {
                using (var cmd = new SqlCommand(
                    "update publishercheck set logtext=@logtext, checkbit=0,status=4,percentcomplete=0,laststatusdate=getdate() where projectguid=@projectguid",
                    cn))
                {
                    cmd.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                    cmd.Parameters.AddWithValue("@logtext", $"{errorText}{exception.Message}{exception.StackTrace}");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdatePublisherCheck(DateTime dtStart)
        {
            if (dtStart == null)
            {
                throw new ArgumentNullException(nameof(dtStart));
            }

            using (var sqlCommand = new SqlCommand("select pubType,weburl,transuid from publishercheck where projectguid=@projectguid", cn))
            {
                sqlCommand.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);

                using (var dr = sqlCommand.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        var pubType = dr.GetInt32(0);
                        publishSiteUrl = HttpUtility.UrlDecode(dr.GetString(1));

                        if (!dr.IsDBNull(2))
                        {
                            lastTransUid = dr.GetGuid(2);
                        }

                        if (string.IsNullOrWhiteSpace(publishSiteUrl))
                        {
                            publishSiteUrl = getProjectWss(mySite.Url, eventArgs.ProjectGuid);

                            using (var sqlCommand1 = new SqlCommand("UPDATE publishercheck set weburl=@weburl where projectguid=@projectguid", cn))
                            {
                                sqlCommand1.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                                sqlCommand1.Parameters.AddWithValue("@weburl", publishSiteUrl);
                                sqlCommand1.ExecuteNonQuery();
                            }
                        }

                        projectServerUrl = mySite.Url;
                        projectGuid = eventArgs.ProjectGuid;

                        hshCurTasks = new Hashtable();
                        hshTaskHierarchy = new Hashtable();

                        UpdatePublisherCheckPercentCompleteFive(pubType, dtStart);
                    }
                }
            }
        }

        private void UpdatePublisherCheckPercentCompleteFive(int pubType, DateTime dtStart)
        {
            if (dtStart == null)
            {
                throw new ArgumentNullException(nameof(dtStart));
            }

            using (var pubSite = new SPSite(publishSiteUrl))
            {
                mySiteToPublish = pubSite.OpenWeb();

                pCf = new CustomFields
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/customfields.asmx",
                    UseDefaultCredentials = true
                };
                cfDs = new CustomFieldDataSet();

                psiLookupTable = new LookupTable
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/lookuptable.asmx",
                    UseDefaultCredentials = true
                };

                pResource = new Resource
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/resource.asmx",
                    UseDefaultCredentials = true
                };

                pService = new Project
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/project.asmx",
                    UseDefaultCredentials = true
                };

                Statusing = new Statusing
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/statusing.asmx",
                    UseDefaultCredentials = true
                };

                pWssInterop = new WssInterop
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/wssinterop.asmx",
                    UseDefaultCredentials = true
                };

                linkProjectWss();

                var trackingGuid = Guid.NewGuid();
                const string Lcid = "1033";
                StatusingDerived.SetImpersonationContext(true, contextInfo.UserName, contextInfo.UserGuid, trackingGuid, contextInfo.SiteGuid, Lcid);

                workspaceSynch = new ProjectWorkspaceSynch(mySiteGuid, publishSiteUrl, projectGuid, contextInfo.UserName);
                workspaceSynch.setUpGroups();
                workspaceSynch.processTaskCenter();
                workspaceSynch.processProjectCenter();
                workspaceSynch.processResources();

                using (var sqlCommand1 = new SqlCommand(
                    "UPDATE publishercheck set percentcomplete=5,laststatusdate=getdate() where projectguid=@projectguid",
                    cn))
                {
                    sqlCommand1.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                    sqlCommand1.ExecuteNonQuery();
                }

                loadFields();

                LoadCurrentTasks(pubType, dtStart);
            }
        }

        private void PopulatePublisherCheck()
        {
            using (var sqlCommand = new SqlCommand("select pubType,weburl,transuid from publishercheck where projectguid=@projectguid", cn))
            {
                sqlCommand.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);

                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    if (!dataReader.Read())
                    {
                        var pubType = CoreFunctions.getConfigSetting(mySite.RootWeb, "EPMLivePub-Type");

                        if (!string.IsNullOrWhiteSpace(pubType))
                        {
                            var wssUrl = getProjectWss(mySite.Url, eventArgs.ProjectGuid);

                            if (!string.IsNullOrWhiteSpace(wssUrl))
                            {
                                using (var sqlCommand1 = new SqlCommand(
                                    "INSERT INTO publishercheck (projectguid,checkbit,pubType,weburl, projectname,percentcomplete,status,laststatusdate) VALUES (@projectguid,1,@pubtype,@weburl,@projectname,2,1,GETDATE())",
                                    cn))
                                {
                                    sqlCommand1.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                                    sqlCommand1.Parameters.AddWithValue("@pubtype", pubType);
                                    sqlCommand1.Parameters.AddWithValue("@weburl", wssUrl);
                                    sqlCommand1.Parameters.AddWithValue("@projectname", eventArgs.ProjectName);
                                    sqlCommand1.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoadCurrentTasks(int pubType, DateTime dtStart)
        {
            if (dtStart == null)
            {
                throw new ArgumentNullException(nameof(dtStart));
            }

            if (loadCurrentTasks(eventArgs.ProjectName))
            {
                var newTransUid = Guid.NewGuid();

                using (var sqlCommand1 = new SqlCommand("SELECT * from CUSTOMFIELDS where visible=1", cn))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand1))
                    {
                        using (var dataSet = new DataSet())
                        {
                            sqlDataAdapter.Fill(dataSet);
                            dtFieldsToPublish = dataSet.Tables[0];
                        }
                    }
                }

                var projectDataSet = new ProjectDataSet();
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        projectDataSet = pService.ReadProject(projectGuid, DataStoreEnum.PublishedStore);
                        rDs = pResource.ReadResources(string.Empty, false);
                        dsFields = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                        dsLt = psiLookupTable.ReadLookupTables(string.Empty, false, 0);
                    });

                var projectId = publishProjectCenter(projectDataSet);

                if (projectId != 0)
                {
                    publishTasks(projectId, pubType, newTransUid, lastTransUid);
                    AssignGroupsToTasks(projectId, pubType, projectDataSet);
                }

                ProcessPFEWork(projectId);

                var status = 2;

                var dtFinish = DateTime.Now;
                var timeSpan = dtFinish - dtStart;

                if (!string.IsNullOrWhiteSpace(sbErrors.ToString()))
                {
                    status = 3;
                    sbErrors.Append("<br><br>");
                }

                sbErrors.Append($"Publishing Time: {timeSpan.TotalSeconds:#.0} seconds.");

                using (var sqlCommand1 = new SqlCommand(
                    "update publishercheck set webguid=@webguid,logtext=@logtext, checkbit=0,transuid=@transuid,status=@status,percentcomplete=0,laststatusdate=getdate() where projectguid=@projectguid",
                    cn))
                {
                    sqlCommand1.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                    sqlCommand1.Parameters.AddWithValue("@webguid", mySiteToPublish.ID);
                    sqlCommand1.Parameters.AddWithValue("@transuid", newTransUid);
                    sqlCommand1.Parameters.AddWithValue("@status", status);
                    sqlCommand1.Parameters.AddWithValue("@logtext", sbErrors.ToString());
                    sqlCommand1.ExecuteNonQuery();
                }

                mySiteToPublish.Close();
            }
        }

        private void linkProjectWss()
        {
            WebSvcWssInterop.WssSettingsDataSet dsCurrentWssInfo = new WebSvcWssInterop.WssSettingsDataSet();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                dsCurrentWssInfo = pWssInterop.ReadWssSettings();
            });
            WebSvcWssInterop.WssSettingsDataSet.WssAdminRow adminRow = dsCurrentWssInfo.WssAdmin[0];

            Guid serverUid = adminRow.WADMIN_CURRENT_STS_SERVER_UID;

            string sUrl = publishSiteUrl;
            int slash = sUrl.IndexOf("/", 9);
            sUrl = sUrl.Substring(slash + 1);

            try
            {
                try
                {
                    //pService.UpdateProjectWorkspaceAddress(projectGuid, sUrl, serverUid);
                }
                catch
                {
                    
                    SqlConnection cn = new SqlConnection(EPMLiveHelperClasses.getProjectServerPublishedConnectionString(mySiteGuid));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE MSP_PROJECTS set WPROJ_STS_SUBWEB_NAME=@web,WSTS_SERVER_UID=@sts,PROJ_READ_COUNT=0 where PROJ_UID=@projuid", cn);
                    cmd.Parameters.AddWithValue("@web", sUrl);
                    cmd.Parameters.AddWithValue("@sts", serverUid);
                    cmd.Parameters.AddWithValue("@projuid", projectGuid);
                    //cmd.ExecuteNonQuery();

                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error in linkProjectWss(): " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 315);
            }
        }


        private string getProjectWss(string pwaUrl, Guid projectUID)
        {


            try
            {
                WebSvcWssInterop.WssInterop wssInterop = new WebSvcWssInterop.WssInterop();
                wssInterop.Url = pwaUrl + "/_vti_bin/psi/wssinterop.asmx";
                wssInterop.Credentials = System.Net.CredentialCache.DefaultCredentials;

                WebSvcWssInterop.ProjectWSSInfoDataSet ds = new WebSvcWssInterop.ProjectWSSInfoDataSet();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    ds = wssInterop.ReadWssData(projectUID);
                });

                if (ds.ProjWssInfo.Count > 0)
                {
                    return ds.ProjWssInfo[0].PROJECT_WORKSPACE_URL;
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error in getProjectWss(): " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 315);
            }
            return "";
        }

        private bool canDelete(string fieldname)
        {
            if (fieldname == "LastPublished" || fieldname == "ContentType" || fieldname == "Modified" || fieldname == "Publisher_x0020_Approval_x0020_C" || fieldname == "Created" || fieldname == "taskorder" || fieldname == "Title" || fieldname == "WBS" || fieldname == "Publisher_x0020_Approval_x0020_S" || fieldname == "_UIVersionString")
                return false;
            return true;
        }

        private void setPubPercent(double total, double count)
        {
            double pct = count / total * 95 + 5;
            if (pct > pctComplete + 10)
            {
                SqlCommand cmd = new SqlCommand("UPDATE publishercheck set percentcomplete=@pct,laststatusdate=getdate() where projectguid=@projectguid", cn);
                cmd.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                cmd.Parameters.AddWithValue("@pct", pct);
                cmd.ExecuteNonQuery();
                pctComplete = pct;
            }
        }

        private int publishProjectCenter(WebSvcProject.ProjectDataSet pDs)
        {
            try
            {
                SPList lProjectCenter = mySiteToPublish.Lists["Project Center"];
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + pDs.Project[0].PROJ_NAME + "</Value></Eq></Where>";

                SPListItem listItem;

                if (lProjectCenter.GetItems(query).Count > 0)
                {
                    listItem = lProjectCenter.GetItems(query)[0];
                    try
                    {
                        if (listItem["IsProjectServer"].ToString() != "True")
                        {
                            return 0;                                                        
                        }
                    }catch{}
                }
                else
                {
                    listItem = lProjectCenter.Items.Add();
                    listItem["IsProjectServer"] = "1";
                }

                WebSvcProject.ProjectDataSet.TaskRow taskRow = (WebSvcProject.ProjectDataSet.TaskRow)pDs.Task.Select("TASK_ID=0")[0];

                listItem[lProjectCenter.Fields.GetFieldByInternalName("Title").Id] = pDs.Project[0].PROJ_NAME;
                listItem["projectguid"] = pDs.Project[0].PROJ_UID.ToString();
                listItem["PublishToPWA"] = "0";
                listItem["SharePointProject"] = "0";
                listItem["IsProjectServer"] = "1";
                listItem["ProjectServerURL"] = projectServerUrl;
                try
                {
                    listItem[lProjectCenter.Fields.GetFieldByInternalName("AssignedTo").Id] = getResourceWssId(pDs.Project[0].ProjectOwnerID);
                }
                catch { }
                processProjectCenterFields(pDs, arrPJFieldsToPublish, ref listItem);
                processTask(taskRow, pDs, arrPJFieldsToPublish, listItem, hshProjectCenterFields, "", 2);

                hshTaskHierarchy.Add(taskRow.TASK_UID, "");

                return listItem.ID;
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error in publishProjectCenter(): " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 315);
            }
            return 0;
        }

        /// <summary>
        /// This method used to insert the data into EPMLive PFE.
        /// </summary>
        /// <param name="projectId">project id</param>
        private void ProcessPFEWork(int projectId)
        {
            try
            {
                WebSvcProject.ProjectDataSet pDs = null;
                string lstName = "Project Center";

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    pDs = pService.ReadProject(projectGuid, WebSvcProject.DataStoreEnum.PublishedStore);
                });

                string str = "<UpdateScheduledWork><Params Worktype=\"1\"/><Data><Project ID='" + projectId + "' List='" + lstName + "'>";

                foreach (WebSvcProject.ProjectDataSet.AssignmentRow assn in pDs.Assignment)
                {
                    Int64 resId = 0;
                    resId = getResourceResId(assn.RES_UID_OWNER);
                    if (resId > 0)
                    {
                        str += "<Resource Id=\"" + resId + "\">";

                        DateTime assnSTDate = assn.ASSN_START_DATE;
                        DateTime assnFDate = assn.ASSN_FINISH_DATE;
                        var interavl = (assnFDate - assnSTDate).Days;
                        var hour = assn.ASSN_WORK;
                        DateTime loopStDate = assnSTDate;

                        while (loopStDate <= assnFDate)
                        {
                            var indvHour = ((hour / (interavl + 1)) / assn.ASSN_UNITS) / 6;  // logically devide the hours to each day (Right now it equally seprate hours to each day).
                            str += "<Work Date=\"" + DateTime.Parse(loopStDate.ToString()).ToString("s") + "\" Hours=\"" + indvHour + "\"/>";
                            loopStDate = loopStDate.AddDays(1);
                        }

                        str += "</Resource>";
                    }
                }

                str += "</Project></Data></UpdateScheduledWork>";

                //calling portfolioengineAPI
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EPMLivePortfolioEngine.PortfolioEngineAPI pfe = new EPMLivePortfolioEngine.PortfolioEngineAPI();
                    pfe.Url = mySiteToPublish.Url + "/_vti_bin/portfolioengine.asmx";
                    pfe.UseDefaultCredentials = true;
                    string ret = pfe.Execute("UpdateScheduledWork", str);
                });
            }
            catch (Exception ex) 
            {
                //Need to change event number accordingly.
                myLog.WriteEntry("Error in ProcessPFEWork " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 305);
            }
        }

        private void AssignGroupsToTasks(int projectId, int pubType, WebSvcProject.ProjectDataSet pDs)
        {
            SPGroup addMemGrp = null; SPGroup addVisitGrp = null;            
            string strProjAssignTo = string.Empty;

            try
            {

                mySiteToPublish.AllowUnsafeUpdates = true;
                SPList lstPC = mySiteToPublish.Lists["Project Center"];
                SPListItem lstPCItem;                
                lstPCItem = lstPC.GetItemById(projectId);

                strProjAssignTo = (Convert.ToString(lstPCItem["AssignedTo"]) != string.Empty ? Convert.ToString(lstPCItem["AssignedTo"]) : "");

                if (lstPCItem != null && lstPCItem.HasUniqueRoleAssignments == true)
                {
                    foreach (SPRoleAssignment role in lstPCItem.RoleAssignments)
                    {
                        try
                        {
                            if (role.Member.GetType() == typeof(SPGroup))
                            {
                                SPGroup tempGrp = (SPGroup)role.Member;

                                if (tempGrp.Name.Contains("Member"))
                                {
                                    addMemGrp = (SPGroup)role.Member;
                                }

                                if (tempGrp.Name.Contains("Visitor"))
                                {
                                    addVisitGrp = (SPGroup)role.Member;
                                }
                            }
                        }
                        catch { }
                    }    
                    foreach (WebSvcProject.ProjectDataSet.ProjectResourceRow pr in pDs.ProjectResource)
                    {
                        try
                        {                                
                            if (!pr.IsWRES_ACCOUNTNull())
                            {
                                string email = "";
                                try
                                {
                                    email = pr.WRES_EMAIL;
                                }
                                catch { }

                                var assignRes = from assgRow in pDs.Assignment.AsEnumerable()
                                                where assgRow.Field<Guid>("Res_UID") == pr.RES_UID
                                                select assgRow;

                                if (assignRes.Count() > 0)
                                    addMemGrp.AddUser(pr.WRES_ACCOUNT, email, pr.RES_NAME, "");                                        
                                else
                                    addVisitGrp.AddUser(pr.WRES_ACCOUNT, email, pr.RES_NAME, "");

                                if (!strProjAssignTo.Contains(";#" + (mySiteToPublish.AllUsers[pr.WRES_ACCOUNT].ID + ";#" + getResourceName(pr.RES_UID, pDs))))
                                    strProjAssignTo += ";#" + (mySiteToPublish.AllUsers[pr.WRES_ACCOUNT].ID + ";#" + getResourceName(pr.RES_UID, pDs));
                                                                         
                            }                                
                        }
                        catch { }
                    }                    
                    addVisitGrp.Update();
                    addMemGrp.Update();
                    lstPCItem["AssignedTo"] = strProjAssignTo;
                    lstPCItem.Update();
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error in AssignGroupsToTasks " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 305);
            }
        }

        private void loadFields()
        {
            try
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cfDs = pCf.ReadCustomFieldsByEntity(taskEntity);
                    });
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry("Error in publishProject() Reading Custom Fields: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 320);
                }

                SPList taskCenter = mySiteToPublish.Lists["Task Center"];
                foreach (SPField spField in taskCenter.Fields)
                {
                    hshTaskCenterFields.Add(spField.InternalName, spField.Id);
                    if (isValidField(spField))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT fieldname,wssfieldname,coalesce(assnfieldname,'') as assnfieldname,fieldcategory,fieldtype,multiplier FROM CUSTOMFIELDS where wssfieldname like @wssfieldname", cn);
                        cmd.Parameters.AddWithValue("@wssfieldname", spField.InternalName);
                        SqlDataReader drField = cmd.ExecuteReader();
                        string rolldown = "false";
                        if (drField.Read())
                        {
                            try
                            {
                                if (drField.GetInt32(3) == 3)
                                {
                                    WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] dr = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + drField.GetString(0));
                                    if (dr.Length > 0)
                                    {
                                        rolldown = dr[0].MD_PROP_ROLLDOWN_TO_ASSN.ToString().ToLower();
                                    }
                                }
                            }
                            catch { }
                            arrFieldsToPublish.Add(drField.GetString(0) + "#" + spField.InternalName + "#" + drField.GetString(2) + "#" + drField.GetInt32(3) + "#" + drField.GetString(4) + "#" + drField.GetInt32(5) + "#" + spField.Id + "#" + rolldown);
                        }
                        else
                        {
                            if (spField.InternalName.Length > 3)
                            {
                                string fieldName = spField.InternalName.Substring(3);
                                int temp = 0;
                                if (int.TryParse(fieldName,out temp))
                                {
                                    WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] dr = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + fieldName);
                                    if (dr.Length > 0)
                                    {
                                        if(dr[0].IsMD_LOOKUP_TABLE_UIDNull())
                                            arrFieldsToPublish.Add(dr[0].MD_PROP_ID + "#" + spField.InternalName + "#" + dr[0].MD_PROP_UID_SECONDARY + "#3#" + getType(((PSLibrary.PropertyType)dr[0].MD_PROP_TYPE_ENUM).ToString()) + "#1#" + spField.Id + "#" + rolldown); 
                                        else
                                            arrFieldsToPublish.Add(dr[0].MD_PROP_ID + "#" + spField.InternalName + "#" + dr[0].MD_PROP_UID_SECONDARY + "#3#CHOICE#1#" + spField.Id + "#" + rolldown);
                                    }
                                }
                            }
                        }
                        drField.Close();
                    }
                }

                SPList projectCenter = mySiteToPublish.Lists["Project Center"];
                foreach (SPField spField in projectCenter.Fields)
                {
                    hshProjectCenterFields.Add(spField.InternalName, spField.Id);
                    if (isValidField(spField))
                    {
                        string sFieldName = spField.InternalName;

                        if (sFieldName == "Start")
                            sFieldName = "StartDate";
                        if (sFieldName == "Finish")
                            sFieldName = "DueDate";

                        SqlCommand cmd = new SqlCommand("SELECT fieldname,wssfieldname,coalesce(assnfieldname,'') as assnfieldname,fieldcategory,fieldtype,multiplier FROM CUSTOMFIELDS where wssfieldname like @wssfieldname", cn);
                        cmd.Parameters.AddWithValue("@wssfieldname", sFieldName);
                        SqlDataReader drField = cmd.ExecuteReader();
                        if (drField.Read())
                        {
                            arrPJFieldsToPublish.Add(drField.GetString(0) + "#" + spField.InternalName + "#" + drField.GetString(2) + "#" + drField.GetInt32(3) + "#" + drField.GetString(4) + "#" + drField.GetInt32(5) + "#" + spField.Id);
                        }
                        else
                        {
                            if (spField.InternalName.Length > 3)
                            {
                                string fieldName = spField.InternalName.Substring(3);
                                int temp = 0;
                                if (int.TryParse(fieldName, out temp))
                                {
                                    WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] dr = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + fieldName);
                                    if (dr.Length > 0)
                                    {
                                        if (dr[0].IsMD_LOOKUP_TABLE_UIDNull())
                                            arrPJFieldsToPublish.Add(dr[0].MD_PROP_ID + "#" + spField.InternalName + "#" + dr[0].MD_PROP_UID_SECONDARY + "#3#" + getType(((PSLibrary.PropertyType)dr[0].MD_PROP_TYPE_ENUM).ToString()) + "#1#" + spField.Id);
                                        else
                                            arrPJFieldsToPublish.Add(dr[0].MD_PROP_ID + "#" + spField.InternalName + "#" + dr[0].MD_PROP_UID_SECONDARY + "#3#CHOICE#1#" + spField.Id);
                                    }
                                }
                            }
                        }
                        drField.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error reading fields\r\n\r\n" + ex.Message + ex.StackTrace, EventLogEntryType.Error, 334);
            }
        }

        private string getType(string type)
        {
            string xml = "";
            switch (type)
            {
                case "NumberEng96":
                    xml = "NUMBER";
                    break;
                case "CostEng96":
                    xml = "CURRENCY";
                    break;
                case "StringEng96":
                    xml = "TEXT";
                    break;
                case "YesNoEng96":
                    xml = "BOOLEAN";
                    break;
                case "DurationEng96":
                    xml = "DURATION";
                    break;
                case "StartDateEng96":
                    xml = "DATETIME";
                    break;
                case "CHOICE":
                    xml = "CHOICE";
                    break;
            }
            return xml;
        }

        private bool loadCurrentTasks(string projectName)
        {
            try
            {
                SPList taskCenter = mySiteToPublish.Lists["Task Center"];

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name=\"Project\"/><Value Type=\"Text\"><![CDATA[" + projectName + "]]></Value></Eq></Where>";

                foreach (SPListItem li in taskCenter.GetItems(query))
                {
                    string taskuid = "";
                    string transuid = "";
                    try
                    {
                        taskuid = li["taskuid"].ToString();
                    }
                    catch { }
                    try
                    {
                        transuid = li["transuid"].ToString();
                    }
                    catch { }
                    if (taskuid != "")
                        hshCurTasks.Add(taskuid.ToUpper(), li.UniqueId);
                    else
                    {
                        if (lastTransUid.ToString().ToLower() == transuid.ToLower())
                        {
                            arrDelNewTasks.Add(li.UniqueId);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Could not load current tasks, Task Center list may not exist or be configured correctly at (" + publishSiteUrl + "):\r\n\r\n " + ex.Message + ex.StackTrace, EventLogEntryType.Warning, 210);
                return false;
            }
        }

        private bool isValidField(SPField spField)
        {
            if (spField.Hidden || spField.ReadOnlyField)
                return false;

            if (spField.Type == SPFieldType.Attachments || spField.Type == SPFieldType.Calculated || spField.Type == SPFieldType.User)
                return false;

            switch (spField.InternalName)
            {
                case "taskuid":
                case "taskorder":
                case "Publisher_x0020_Approval_x0020_C":
                case "Publisher_x0020_Approval_x0020_S":
                case "LastPublished":
                case "WBS":
                case "Notes":
                case "Status":
                case "Priority":
                case "Title":
                case "AssignedTo":
                    return false;
            }

            return true;
        }

        private string multiplyField(string fieldVal, string multiplier)
        {
            try
            {
                float newVal = float.Parse(fieldVal) / float.Parse(multiplier);
                return newVal.ToString();
            }
            catch { }
            return fieldVal;
        }

        private void processAssignment(WebSvcProject.ProjectDataSet.AssignmentRow assn, WebSvcProject.ProjectDataSet pDs, SPListItem listItem)
        {
            

            //StringBuilder sb = new StringBuilder();
            WebSvcProject.ProjectDataSet.TaskRow taskRow = (WebSvcProject.ProjectDataSet.TaskRow)pDs.Task.Select("TASK_UID='" + assn.TASK_UID + "'")[0];

            try
            {

                DateTime lp = DateTime.Now;
                listItem[listItem.Fields.GetFieldByInternalName("TaskHierarchy").Id] = getHierarchy(pDs, taskRow.TASK_PARENT_UID);
                listItem[listItem.Fields.GetFieldByInternalName("IsAssignment").Id] = "1";
                listItem[listItem.Fields.GetFieldByInternalName("Title").Id] = taskRow.TASK_NAME;
                listItem[listItem.Fields.GetFieldByInternalName("WBS").Id] = taskRow.TASK_WBS;
                listItem[listItem.Fields.GetFieldByInternalName("taskuid").Id] = taskRow.TASK_UID + "." + assn.ASSN_UID;
                listItem[listItem.Fields.GetFieldByInternalName("taskorder").Id] = taskRow.TASK_ID;
                if (!assn.IsASSN_NOTESNull())
                    listItem[listItem.Fields.GetFieldByInternalName("Notes").Id] = assn.ASSN_NOTES;
                listItem[listItem.Fields.GetFieldByInternalName("LastPublished").Id] = DateTime.Now; //lp.Year.ToString() + "-" + lp.Month.ToString() + "-" + lp.Day.ToString() + " " + lp.Hour.ToString() + ":" + lp.Minute.ToString() + ":" + lp.Second.ToString();
                int resId = getResourceWssId(assn.RES_UID_OWNER);
                if (resId != 0)
                    listItem[listItem.Fields.GetFieldByInternalName("AssignedTo").Id] = resId;
                listItem["Summary"] = taskRow.TASK_IS_SUMMARY.ToString();

                foreach (string sField in arrFieldsToPublish)
                {
                    
                        string[] sFieldSplit = sField.Split('#');
                        string fieldName = sFieldSplit[0];
                        string wssFieldName = sFieldSplit[1];
                        string assnFieldName = sFieldSplit[2];
                        string fieldCategory = sFieldSplit[3];
                        string fieldType = sFieldSplit[4];
                        string multiplier = sFieldSplit[5];
                        string rolldown = sFieldSplit[7];
                    try
                    {
                        if (fieldName == "TASK_RESNAMES")
                        {
                            listItem[listItem.Fields.GetFieldByInternalName("ResourceNames").Id] = getResourceName(assn.RES_UID, pDs);
                        }
                        else if (fieldName == "TASK_PCT_COMP")
                        {

                            float pct = assn.ASSN_PCT_WORK_COMPLETE;
                            pct = pct / (float)100.00;
                            listItem[listItem.Fields.GetFieldByInternalName("PercentComplete").Id] = pct;
                            //sb.Append("<Field Name='" + wssFieldName + "'>" + pct + "</Field>");
                        }
                        else
                        {
                            if (fieldCategory == "3")
                            {
                                string fieldData = null;
                                DataRow[] drAssn = pDs.AssignmentCustomFields.Select("ASSN_UID='" + assn.ASSN_UID.ToString() + "' AND MD_PROP_UID='" + assnFieldName + "'");
                                if (drAssn.Length >= 1)
                                {
                                    switch (fieldType)
                                    {
                                        case "DATETIME":
                                            fieldData = drAssn[0]["DATE_VALUE"].ToString();
                                            //fieldData = DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString();
                                            break;
                                        case "DURATION":
                                            fieldData = drAssn[0]["DUR_VALUE"].ToString();
                                            try
                                            {
                                                fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                                            }
                                            catch { }
                                            break;
                                        case "NUMBER":
                                            fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                            break;
                                        case "CURRENCY":
                                            fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                            try
                                            {
                                                fieldData = (float.Parse(fieldData) / 100).ToString();
                                            }
                                            catch { }
                                            break;
                                        case "BOOLEAN":
                                            fieldData = drAssn[0]["FLAG_VALUE"].ToString();
                                            break;
                                        case "TEXT":
                                            fieldData = drAssn[0]["TEXT_VALUE"].ToString();
                                            break;
                                        case "CHOICE":
                                            fieldData = drAssn[0]["CODE_VALUE"].ToString();
                                            fieldData = getLookupValue(fieldName, fieldData);
                                            break;
                                    }

                                    //sb.Append("<Field Name='" + wssFieldName + "'>" + fieldData + "</Field>");
                                }
                                else if (rolldown == "true")
                                {
                                    DataRow[] drTask = pDs.TaskCustomFields.Select("TASK_UID='" + taskRow.TASK_UID.ToString() + "' AND MD_PROP_ID='" + fieldName + "'");
                                    if (drTask.Length >= 1)
                                    {
                                        switch (fieldType)
                                        {
                                            case "DATETIME":
                                                fieldData = drTask[0]["DATE_VALUE"].ToString();
                                                //fieldData = DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString();
                                                break;
                                            case "DURATION":
                                                fieldData = drTask[0]["DUR_VALUE"].ToString();
                                                try
                                                {
                                                    fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                                                }
                                                catch { }
                                                break;
                                            case "NUMBER":
                                                fieldData = drTask[0]["NUM_VALUE"].ToString();
                                                break;
                                            case "CURRENCY":
                                                fieldData = drTask[0]["NUM_VALUE"].ToString();
                                                try
                                                {
                                                    fieldData = (float.Parse(fieldData) / 100).ToString();
                                                }
                                                catch { }
                                                break;
                                            case "BOOLEAN":
                                                fieldData = drTask[0]["FLAG_VALUE"].ToString();
                                                break;
                                            case "TEXT":
                                                fieldData = drTask[0]["TEXT_VALUE"].ToString();
                                                break;
                                            case "CHOICE":
                                                fieldData = drTask[0]["CODE_VALUE"].ToString();
                                                fieldData = getLookupValue(fieldName, fieldData);
                                                break;
                                        }
                                    }
                                }
                                listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                            }
                            else if (fieldCategory == "2")
                            {
                                DataRow[] drAssn = pDs.AssignmentCustomFields.Select("ASSN_UID='" + assn.ASSN_UID.ToString() + "' AND MD_PROP_ID='" + assnFieldName + "'");
                                if (drAssn.Length >= 1)
                                {

                                    string fieldData = "";
                                    switch (fieldType)
                                    {
                                        case "DATETIME":
                                            fieldData = drAssn[0]["DATE_VALUE"].ToString();
                                            //fieldData = DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString();
                                            break;
                                        case "DURATION":
                                            fieldData = drAssn[0]["DUR_VALUE"].ToString();
                                            try
                                            {
                                                fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                                            }
                                            catch { }
                                            break;
                                        case "NUMBER":
                                            fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                            break;
                                        case "CURRENCY":
                                            fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                            try
                                            {
                                                fieldData = (float.Parse(fieldData) / 100).ToString();
                                            }
                                            catch { }
                                            break;
                                        case "BOOLEAN":
                                            fieldData = drAssn[0]["FLAG_VALUE"].ToString();
                                            break;
                                        case "TEXT":
                                            fieldData = drAssn[0]["TEXT_VALUE"].ToString();
                                            break;
                                        case "CHOICE":
                                            fieldData = drAssn[0]["CODE_VALUE"].ToString();
                                            fieldData = getLookupValue(fieldName, fieldData);
                                            break;
                                    }
                                    listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                                    //sb.Append("<Field Name='" + wssFieldName + "'>" + fieldData + "</Field>");
                                }
                            }
                            else if (fieldCategory == "1")
                            {
                                if (fieldName == "TASK_PREDECESSORS")
                                {
                                    string preds = "";
                                    DataRow[] drPreds = pDs.Dependency.Select("LINK_SUCC_UID='" + taskRow.TASK_UID.ToString() + "'");
                                    foreach (DataRow drPred in drPreds)
                                    {
                                        WebSvcProject.ProjectDataSet.TaskRow[] drTask = (WebSvcProject.ProjectDataSet.TaskRow[])pDs.Task.Select("TASK_UID='" + drPred["LINK_PRED_UID"] + "'");
                                        if (drTask.Length > 0)
                                        {
                                            preds += "," + drTask[0].TASK_ID;
                                            switch (drPred["LINK_TYPE"].ToString())
                                            {
                                                case "0":
                                                    preds += "FF";
                                                    break;
                                                case "2":
                                                    preds += "SF";
                                                    break;
                                                case "3":
                                                    preds += "SS";
                                                    break;
                                            };
                                        }
                                    }
                                    if (preds.Length > 1)
                                        preds = preds.Substring(1);
                                    listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = preds;
                                }
                                else
                                {
                                    string fieldData = "";
                                    try
                                    {
                                        fieldData = assn[assnFieldName].ToString();
                                    }
                                    catch
                                    {
                                        fieldData = taskRow[fieldName].ToString();
                                    }
                                    if (fieldType == "DATETIME")
                                    {
                                        if (fieldData.Trim() != "")
                                            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                                    }
                                    else
                                    {
                                        if (multiplier != "1")
                                        {
                                            fieldData = multiplyField(fieldData, multiplier);
                                        }
                                        listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error processing Assignment (" + taskRow.TASK_NAME + ") Field (" + fieldName + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
                    }
                }
                if (strTimesheetField != "")
                {
                    if (listItem.Fields.ContainsField("Timesheet"))
                    {
                        DataRow[] drAssn = pDs.TaskCustomFields.Select("TASK_UID='" + taskRow.TASK_UID.ToString() + "' AND MD_PROP_UID='" + strTimesheetField + "'");
                        if (drAssn.Length > 0)
                            listItem["Timesheet"] = drAssn[0]["FLAG_VALUE"].ToString();
                        else
                            listItem["Timesheet"] = 0;
                    }
                }
                listItem.Update();
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error processing Assignment (" + taskRow.TASK_NAME + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);

            }
            //return sb.ToString();
        }

        private void processProjectCenterFields(WebSvcProject.ProjectDataSet pDs, ArrayList arrFToPublish, ref SPListItem listItem)
        {
            //StringBuilder sb = new StringBuilder();
            try
            {

                foreach (string sField in arrFToPublish)
                {
                    string[] sFieldSplit = sField.Split('#');
                    string fieldName = sFieldSplit[0];
                    string wssFieldName = sFieldSplit[1];
                    string fieldCategory = sFieldSplit[3];
                    string fieldType = sFieldSplit[4];
                    string multiplier = sFieldSplit[5];

                    if (fieldCategory == "4")
                    {
                        DataRow[] drAssn = pDs.ProjectCustomFields.Select("MD_PROP_ID='" + fieldName + "'");
                        if (drAssn.Length >= 1)
                        {

                            string fieldData = "";
                            switch (fieldType)
                            {
                                case "DATETIME":
                                    fieldData = drAssn[0]["DATE_VALUE"].ToString();
                                    fieldData = DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString();
                                    break;
                                case "DURATION":
                                    fieldData = drAssn[0]["DUR_VALUE"].ToString();
                                    try
                                    {
                                        fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                                    }
                                    catch { }
                                    break;
                                case "NUMBER":
                                    fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                    break;
                                case "CURRENCY":
                                    fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                    try
                                    {
                                        fieldData = (float.Parse(fieldData) / 100).ToString();
                                    }
                                    catch { }
                                    break;
                                case "BOOLEAN":
                                    fieldData = drAssn[0]["FLAG_VALUE"].ToString();
                                    break;
                                case "TEXT":
                                    fieldData = drAssn[0]["TEXT_VALUE"].ToString();
                                    break;
                                case "CHOICE":
                                    fieldData = drAssn[0]["CODE_VALUE"].ToString();
                                    fieldData = getLookupValue(fieldName, fieldData);
                                    break;
                            }
                            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                            // sb.Append("<Field Name='" + wssFieldName + "'>" + fieldData + "</Field>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error processing Project Center Enterprise Fields: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);

            }
            listItem.Update();
        }

        private string getHierarchy(WebSvcProject.ProjectDataSet pDs, Guid taskuid)
        {
            if (hshTaskHierarchy.Contains(taskuid))
                return hshTaskHierarchy[taskuid].ToString();

            WebSvcProject.ProjectDataSet.TaskRow taskRow = (WebSvcProject.ProjectDataSet.TaskRow)pDs.Task.Select("TASK_UID='" + taskuid + "'")[0];
            
            string hierarchy = getHierarchy(pDs, taskRow.TASK_PARENT_UID) + " > " + taskRow.TASK_NAME;

            if (hierarchy[1] == '>')
                hierarchy = hierarchy.Substring(3);

            hshTaskHierarchy.Add(taskRow.TASK_UID, hierarchy);

            return hierarchy;
        }

        private void processTask(WebSvcProject.ProjectDataSet.TaskRow taskRow, WebSvcProject.ProjectDataSet pDs, ArrayList arrFToPublish, SPListItem listItem, Hashtable hshFields1, string taskuid, int pubType)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (string sField in arrFToPublish)
                {
                    string[] sFieldSplit = sField.Split('#');
                    string fieldName = sFieldSplit[0];
                    string wssFieldName = sFieldSplit[1];
                    string fieldCategory = sFieldSplit[3];
                    string fieldType = sFieldSplit[4];
                    string multiplier = sFieldSplit[5];
                    string fieldData = null;

                    try
                    {
                        if (fieldCategory == "3")
                        {
                            DataRow[] drAssn = pDs.TaskCustomFields.Select("TASK_UID='" + taskRow.TASK_UID.ToString() + "' AND MD_PROP_ID='" + fieldName + "'");
                            if (drAssn.Length >= 1)
                            {
                                switch (fieldType)
                                {
                                    case "DATETIME":
                                        fieldData = drAssn[0]["DATE_VALUE"].ToString();
                                        //fieldData = DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString();
                                        break;
                                    case "DURATION":
                                        fieldData = drAssn[0]["DUR_VALUE"].ToString();
                                        try
                                        {
                                            fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                                        }
                                        catch { }
                                        break;
                                    case "NUMBER":
                                        fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                        break;
                                    case "CURRENCY":
                                        fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                        try
                                        {
                                            fieldData = (float.Parse(fieldData) / 100).ToString();
                                        }
                                        catch { }
                                        break;
                                    case "BOOLEAN":
                                        fieldData = drAssn[0]["FLAG_VALUE"].ToString();
                                        break;
                                    case "TEXT":
                                        fieldData = drAssn[0]["TEXT_VALUE"].ToString();
                                        break;
                                    case "CHOICE":
                                        fieldData = drAssn[0]["CODE_VALUE"].ToString();
                                        fieldData = getLookupValue(fieldName, fieldData);
                                        break;
                                }
                                //listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                                //sb.Append("<Field Name='" + wssFieldName + "'>" + fieldData + "</Field>");
                            }
                            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                        }
                        else if (fieldCategory == "2")
                        {
                            DataRow[] drAssn = pDs.TaskCustomFields.Select("TASK_UID='" + taskRow.TASK_UID.ToString() + "' AND MD_PROP_ID='" + fieldName + "'");
                            if (drAssn.Length >= 1)
                            {

                                switch (fieldType)
                                {
                                    case "DATETIME":
                                        fieldData = drAssn[0]["DATE_VALUE"].ToString();
                                        fieldData = DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString();
                                        break;
                                    case "DURATION":
                                        fieldData = drAssn[0]["DUR_VALUE"].ToString();
                                        try
                                        {
                                            fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                                        }
                                        catch { }
                                        break;
                                    case "NUMBER":
                                        fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                        break;
                                    case "CURRENCY":
                                        fieldData = drAssn[0]["NUM_VALUE"].ToString();
                                        try
                                        {
                                            fieldData = (float.Parse(fieldData) / 100).ToString();
                                        }
                                        catch { }
                                        break;
                                    case "BOOLEAN":
                                        fieldData = drAssn[0]["FLAG_VALUE"].ToString();
                                        break;
                                    case "TEXT":
                                        fieldData = drAssn[0]["TEXT_VALUE"].ToString();
                                        break;
                                    case "CHOICE":
                                        fieldData = drAssn[0]["CODE_VALUE"].ToString();
                                        fieldData = getLookupValue(fieldName, fieldData);
                                        break;
                                }
                                listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                                //sb.Append("<Field Name='" + wssFieldName + "'>" + fieldData + "</Field>");
                            }
                        }
                        else if (fieldCategory == "1")
                        {
                            if (fieldName == "TASK_RESNAMES")
                            {

                            }
                            else if (fieldName == "TASK_PREDECESSORS")
                            {
                                string preds = "";
                                DataRow[] drPreds = pDs.Dependency.Select("LINK_SUCC_UID='" + taskRow.TASK_UID.ToString() + "'");
                                foreach (DataRow drPred in drPreds)
                                {
                                    WebSvcProject.ProjectDataSet.TaskRow[] drTask = (WebSvcProject.ProjectDataSet.TaskRow[])pDs.Task.Select("TASK_UID='" + drPred["LINK_PRED_UID"] + "'");
                                    if (drTask.Length > 0)
                                    {
                                        preds += "," + drTask[0].TASK_ID;

                                        switch (drPred["LINK_TYPE"].ToString())
                                        {
                                            case "0":
                                                preds += "FF";
                                                break;
                                            case "2":
                                                preds += "SF";
                                                break;
                                            case "3":
                                                preds += "SS";
                                                break;
                                        };
                                    }
                                }
                                if (preds.Length > 1)
                                    preds = preds.Substring(1);
                                listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = preds;
                            }
                            else
                            {
                                try
                                {
                                    fieldData = taskRow[fieldName].ToString();
                                }
                                catch
                                {

                                }
                                if (fieldType == "DATETIME")
                                {
                                    if (fieldData.Trim() != "")
                                    {
                                        //fieldData = .ToString("Z");

                                        listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = DateTime.Parse(fieldData);
                                    }
                                    else
                                        listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = null;
                                    //sb.Append("<Field Name='" + wssFieldName + "'>" + DateTime.Parse(fieldData).Year.ToString() + "-" + DateTime.Parse(fieldData).Month.ToString() + "-" + DateTime.Parse(fieldData).Day.ToString() + " " + DateTime.Parse(fieldData).Hour.ToString() + ":" + DateTime.Parse(fieldData).Minute.ToString() + ":" + DateTime.Parse(fieldData).Second.ToString() + "</Field>");
                                }
                                else
                                {
                                    if (multiplier != "1")
                                    {
                                        fieldData = multiplyField(fieldData, multiplier);
                                    }
                                    listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                                    //sb.Append("<Field Name='" + wssFieldName + "'>" + fieldData + "</Field>");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error setting field (" + fieldName + ") fieldValue (" + fieldData + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 335);
                    }
                }
                if (taskuid != "")
                    listItem["taskuid"] = taskuid;

                if (strTimesheetField != "")
                {
                    if (listItem.Fields.ContainsField("Timesheet"))
                    {
                        if (pubType == 1)
                        {
                            listItem["Timesheet"] = 0;
                        }
                        else
                        {
                            DataRow[] drAssn = pDs.TaskCustomFields.Select("TASK_UID='" + taskRow.TASK_UID.ToString() + "' AND MD_PROP_UID='" + strTimesheetField + "'");
                            if (drAssn.Length > 0)
                                listItem["Timesheet"] = drAssn[0]["FLAG_VALUE"].ToString();
                            else
                                listItem["Timesheet"] = 0;
                        }
                    }
                }
                listItem.Update();
            }
            catch (SPException ex1)
            {
                myLog.WriteEntry("SPException: Error processing Task (" + taskRow.TASK_NAME + "): " + ex1.Message + ex1.StackTrace, EventLogEntryType.Error, 331);
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error processing Task (" + taskRow.TASK_NAME + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
            
            //return sb.ToString();
        }

        private int getResourceWssId(Guid RES_GUID)
        {
            DataRow[] drRes = rDs.Resources.Select("RES_UID='" + RES_GUID + "'");
            if (drRes.Length > 0)
            {
                if (drRes[0]["RES_IS_WINDOWS_USER"].ToString() == "True")
                {
                    string username = drRes[0]["WRES_ACCOUNT"].ToString();
                    try
                    {
                        return mySiteToPublish.AllUsers[username].ID;
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// this method used to return resource Id.
        /// </summary>
        /// <param name="RES_GUID"></param>
        /// <returns></returns>
        private Int64 getResourceResId(Guid RES_GUID)
        {
            DataRow[] drRes = rDs.Resources.Select("RES_UID='" + RES_GUID + "'");
            if (drRes.Length > 0)
            {
                if (drRes[0]["RES_IS_WINDOWS_USER"].ToString() == "True")
                {
                    Int64 ResId = Convert.ToInt64(drRes[0]["Res_ID"]);
                    return ResId;
                }
            }
            return 0;
        }

        private string getResourceName(Guid RES_GUID, WebSvcProject.ProjectDataSet pDs)
        {
            DataRow[] drRes = rDs.Resources.Select("RES_UID='" + RES_GUID + "'");
            if (drRes.Length > 0)
            {
                if (drRes[0]["RES_IS_WINDOWS_USER"].ToString() == "True")
                {
                    string username = drRes[0]["WRES_ACCOUNT"].ToString();
                    try
                    {
                        return mySiteToPublish.AllUsers[username].Name;
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return Convert.ToString(drRes[0]["RES_NAME"]);
                }
            }
            else
            {
                DataRow[] dr = pDs.ProjectResource.Select("RES_UID='" + RES_GUID + "'");
                if (dr.Length > 0)
                    return dr[0]["RES_NAME"].ToString();
            }
            return "";
        }

        private string getResourceUsername(Guid RES_GUID)
        {
            DataRow[] drRes = rDs.Resources.Select("RES_UID='" + RES_GUID + "'");
            if (drRes.Length > 0)
            {
                if (drRes[0]["RES_IS_WINDOWS_USER"].ToString() == "True")
                {
                    return drRes[0]["WRES_ACCOUNT"].ToString();
                }
            }
            return "";
        }

        private string getLookupValue(string fieldName, string lv_id)
        {
            try
            {

                WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow []ds = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow [])dsFields.CustomFields.Select("MD_PROP_ID=" + fieldName);

                if (ds.Length <= 0)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        dsFields = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.ProjectEntity.UniqueId));
                    });
                    ds = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])dsFields.CustomFields.Select("MD_PROP_ID=" + fieldName);

                }

                WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[] tr = (WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[])dsLt.LookupTableTrees.Select("LT_STRUCT_UID = '" + lv_id + "'");

                switch ((PSLibrary.PSDataType)ds[0].MD_PROP_TYPE_ENUM)
                {
                    case PSLibrary.PSDataType.STRING:
                        return tr[0].LT_VALUE_TEXT;
                    case PSLibrary.PSDataType.NUMBER:
                        return tr[0].LT_VALUE_NUM.ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Reading Lookup Table for field (" + fieldName + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
            return "";
        }

        public bool IsAssignedTaskSaved(Guid assnid)
        {
            try
            {
                StatusingDerived status = new StatusingDerived();
                status.Url = mySite.Url + "/_vti_bin/psi/statusing.asmx";
                WebSvcStatusing.StatusApprovalTransactionDetailsDataSet sa2Ds = status.ReadStatusApprovalDetails(assnid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            cn?.Dispose();
        }
    }
}
