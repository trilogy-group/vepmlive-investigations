using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Services.Protocols;
using EPMLiveCore;
using EPMLiveEnterprise.WebSvcCustomFields;
using EPMLiveEnterprise.WebSvcLookupTables;
using EPMLiveEnterprise.WebSvcProject;
using EPMLiveEnterprise.WebSvcResource;
using EPMLiveEnterprise.WebSvcStatusing;
using EPMLiveEnterprise.WebSvcWssInterop;
using Microsoft.SharePoint;
using ProjectDataSet = EPMLiveEnterprise.WebSvcProject.ProjectDataSet;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
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
                        dsFields = pCf.ReadCustomFieldsByEntity(
                            new Guid(Microsoft.Office.Project.Server.Library.EntityCollection.Entities.TaskEntity.UniqueId));
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
    }
}