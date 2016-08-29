using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Project.Server.Events;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
    public class Status : StatusingEventReceiver
    {
        public override void OnApplied(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, StatusingPostApplyEventArgs e)
        {
            try
            {
                foreach (Guid assnid in e.AcceptedAssignments)
                {
                    HandleWSSUpdate(contextInfo, "Accepted", assnid, e.ProjectID);
                }

                foreach (Guid assnid in e.RejectedAssignments)
                {
                    HandleWSSUpdate(contextInfo, "Rejected", assnid, e.ProjectID);
                }
            }
            catch (System.Web.Services.Protocols.SoapException ex1)
            {
                string logEntry = "Soap Error: " + ex1.Message + ex1.Detail;
                ErrorTrap(3003, logEntry);

            }
            catch (Exception ex)
            {
                string logEntry = "Error: " + ex.Message + ex.StackTrace;
                ErrorTrap(3002, logEntry);

            }

            base.OnApplied(contextInfo, e);
        }

        public void HandleWSSUpdate(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, string acceptdecline, Guid assnid, Guid projectid)
        {
            try
            {
                string thenotes = "";

                SPSite site = new SPSite(contextInfo.SiteGuid);

                Guid trackingGuid = Guid.NewGuid();
                string lcid = "1033";
                StatusingDerived.SetImpersonationContext(true, contextInfo.UserName, contextInfo.UserGuid, trackingGuid, contextInfo.SiteGuid, lcid);
                StatusingDerived statusing = new StatusingDerived();
                statusing.Url = site.Url + "/_vti_bin/psi/statusing.asmx";

                WebSvcStatusing.StatusingDataSet ds = statusing.ReadStatus(assnid, DateTime.MinValue, DateTime.MaxValue);

                //Guid userguid = new Guid(ds.Tables[0].Rows[0]["RES_UID"].ToString());

                DataTable dt = ds.Tables["Tasks"];
                string taskid = "";
                foreach (DataRow dr in dt.Rows)
                {
                    taskid = dr["Task_Published_UID"].ToString();
                    break;
                }

                WebSvcStatusing.StatusApprovalDataSet statusingDs2 = statusing.ReadStatusApprovalsInProcess(contextInfo.UserGuid);
                WebSvcStatusing.StatusApprovalDataSet.StatusApprovalsRow[] statusingRow = (WebSvcStatusing.StatusApprovalDataSet.StatusApprovalsRow[])statusingDs2.Tables[0].Select("ASSN_UID = '" + assnid + "'");

                if (statusingRow.Length > 0)
                {
                    string impersonateuser = GetWindowsAccountByResGUID(statusingRow[0].RES_UID.ToString(), contextInfo, site.Url);

                    //impersonate
                    Guid trackingGuid2 = Guid.NewGuid();
                    string lcid2 = "1033";
                    StatusingDerived.SetImpersonationContext(true, impersonateuser, statusingRow[0].RES_UID, trackingGuid2, contextInfo.SiteGuid, lcid2);
                    //StatusingDerived statusing2 = new StatusingDerived();
                    //statusing2.Url = site.Url + "/_vti_bin/psi/statusing.asmx";
                    WebSvcStatusing.AssnHistoryDataSet statusingDs4 = statusing.ReadAssignmentHistory(statusingRow[0].ASSN_TRANS_UID, WebSvcStatusing.AssnHistoryItemType.SingleTransaction);
                    WebSvcStatusing.AssnHistoryDataSet.HistoryRow[] historyRows = (WebSvcStatusing.AssnHistoryDataSet.HistoryRow[])statusingDs4.Tables[0].Select("ASSN_TRANS_UID = '" + statusingRow[0].ASSN_TRANS_UID + "'");

                    foreach (WebSvcStatusing.AssnHistoryDataSet.HistoryRow row in historyRows)
                    {
                        if ((int)row.ASSN_TRANS_COMMENT_TYPE_ENUM == 1 || (int)row.ASSN_TRANS_COMMENT_TYPE_ENUM == 2) //1=Accepted, 2=Rejected
                        {
                            thenotes = row.ASSN_TRANS_COMMENT.ToString();

                            string publishSiteUrl = RetrieveWebURL(projectid.ToString(), contextInfo.SiteGuid);

                            SPSite mySite = new SPSite(contextInfo.SiteGuid);

                            int indSlash = publishSiteUrl.IndexOf("/", 9);
                            publishSiteUrl = publishSiteUrl.Substring(indSlash);

                            SPWeb myWeb = mySite.OpenWeb(publishSiteUrl);
                            //Impersonate the Project Manager
                            SPUser user = myWeb.AllUsers[getResourceUsername(mySite.Url, getProjectOwner(mySite.Url, projectid))];

                            SPUserToken token = user.UserToken;
                            //reopen the web with the new user credentials
                            mySite = new SPSite(mySite.ID, token);

                            myWeb = mySite.OpenWeb(publishSiteUrl);

                            myWeb.AllowUnsafeUpdates = true;
                            SPList taskList = myWeb.Lists["Task Center"];
                            SPQuery queryFilter = new SPQuery();

                            queryFilter.Query = "<Where><Eq><FieldRef Name='taskuid'/><Value Type='Text'><![CDATA[" + taskid + "." + assnid.ToString() + "]]></Value></Eq></Where>";

                            Guid CommentsFieldId = taskList.Fields.GetFieldByInternalName("Publisher_x0020_Approval_x0020_C").Id;
                            Guid StatusFieldId = taskList.Fields.GetFieldByInternalName("Publisher_x0020_Approval_x0020_S").Id;

                            foreach (SPListItem item in taskList.GetItems(queryFilter))
                            {
                                item[CommentsFieldId] = thenotes;
                                item[StatusFieldId] = acceptdecline;
                                item.Update();
                            }

                            myWeb.Close();
                            mySite.Close();
                        }
                    }
                }
            }
            catch (System.Web.Services.Protocols.SoapException ex1)
            {
                string logEntry = "Soap Error: " + ex1.Message + ex1.Detail;
                ErrorTrap(3001, logEntry);
            }
            catch (Exception ex)
            {
                string logEntry = "Error: " + ex.Message + ex.StackTrace;
                ErrorTrap(3000, logEntry);
            }
        }

        public string RetrieveWebURL(string projguid, Guid ssiteGuid)
        {
            string url = "";
            try
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(ssiteGuid))
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("spRetrieveWebURL", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@projid", projguid);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            url = dr.GetString(0);
                        }

                        cn.Close();
                    }
                });

            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    string logEntry = DateTime.Now.ToString() + "\tRetrieveWebURL()\t" + ex.Message.ToString();
                    ErrorTrap(3004, logEntry);
                });
            }
            return url;
        }
        private Guid getProjectOwner(string url, Guid projectuid)
        {
            try
            {
                WebSvcProject.Project pService = new WebSvcProject.Project();
                pService.Url = url + "/_vti_bin/psi/project.asmx";
                pService.UseDefaultCredentials = true;

                WebSvcProject.ProjectDataSet pDs = new WebSvcProject.ProjectDataSet();
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    pDs = pService.ReadProject(projectuid, WebSvcProject.DataStoreEnum.PublishedStore);
                });

                return pDs.Project[0].ProjectOwnerID;
            }
            catch (Exception ex)
            {
                string logEntry = "Error: " + ex.Message;
                ErrorTrap(3002, logEntry);
            }
            return new Guid();
        }

        private string getResourceUsername(string url, Guid RES_GUID)
        {
            try
            {
                WebSvcResource.Resource pResource = new WebSvcResource.Resource();
                pResource.Url = url + "/_vti_bin/psi/resource.asmx";
                pResource.UseDefaultCredentials = true;
                WebSvcResource.ResourceDataSet rDs = new WebSvcResource.ResourceDataSet();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    rDs = pResource.ReadResource(RES_GUID);
                });

                if (rDs.Resources.Count > 0)
                {
                    if (rDs.Resources[0].RES_IS_WINDOWS_USER)
                    {
                        return rDs.Resources[0].WRES_ACCOUNT;
                    }
                }

            }
            catch (Exception ex)
            {
                string logEntry = "Error: " + ex.Message;
                ErrorTrap(3003, logEntry);
            }
            return "";
        }

        public void ErrorTrap(int eventId, string logEntry)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                EventLog myLog = new EventLog("Epm Live", ".", "Publisher Statusing");
                myLog.WriteEntry(logEntry, EventLogEntryType.Error, eventId);
            });
        }

        //Get Resource from Resource GUID
        private string GetWindowsAccountByResGUID(string ls_guid, Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, string url)
        {

            try
            {
                Guid trackingGuid = Guid.NewGuid();
                string lcid = "1033";

                ResourceDerived.SetImpersonationContext(true, contextInfo.UserName, contextInfo.UserGuid, trackingGuid, contextInfo.SiteGuid, lcid);
                ResourceDerived Resource = new ResourceDerived();
                Resource.Url = url + "/_vti_bin/psi/resource.asmx";

                //WebSvcResource.Resource Resource = new WebSvcResource.Resource();
                WebSvcResource.ResourceDataSet lo_resDS = new WebSvcResource.ResourceDataSet();
                //Resource.Credentials = System.Net.CredentialCache.DefaultCredentials;

                string nameColumn = lo_resDS.Resources.RES_UIDColumn.ColumnName;

                string resAccount = lo_resDS.Resources.WRES_ACCOUNTColumn.ColumnName;

                PSLibrary.Filter.FieldOperationType equal = PSLibrary.Filter.FieldOperationType.Equal;
                PSLibrary.Filter lo_filter = new PSLibrary.Filter();

                lo_filter.FilterTableName = lo_resDS.Resources.TableName;
                lo_filter.Fields.Add(new PSLibrary.Filter.Field(resAccount));
                lo_filter.Criteria = new PSLibrary.Filter.FieldOperator(equal, nameColumn, ls_guid);
                lo_resDS = Resource.ReadResources(lo_filter.GetXml(), false);
                return (string)lo_resDS.Tables[lo_resDS.Resources.TableName].Rows[0][1];
            }
            catch (Exception ex)
            {
                string logEntry = "Error: " + ex.Message + ex.StackTrace;
                ErrorTrap(3010, logEntry);
                return "";
            }
        }
    }
}
