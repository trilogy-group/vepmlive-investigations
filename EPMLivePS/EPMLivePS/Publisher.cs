using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EPMLiveCore.Helpers;
using Microsoft.Office.Project.Server.Events;
using Microsoft.SharePoint;
using ProjectDataSet = EPMLiveEnterprise.WebSvcProject.ProjectDataSet;
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
    internal partial class Publisher : IDisposable
    {
        public Publisher(PSLibrary.PSContextInfo psContextInfo, ProjectPostPublishEventArgs projectPostPublishEventArgs)
        {
            contextInfo = psContextInfo ?? throw new ArgumentNullException(nameof(psContextInfo));
            eventArgs = projectPostPublishEventArgs ?? throw new ArgumentNullException(nameof(projectPostPublishEventArgs));
            mySiteGuid = contextInfo.SiteGuid;
            myLog.EntryWritten += myLog_EntryWritten;
        }

        private void myLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            var message = e.Entry.Message;
            sbErrors.Append($"{message.Replace("\r\n", "<br>")}<br><br><br><br>");
        }

        ~Publisher()
        {
            myLog.Close();
        }

        private bool canDelete(string fieldName)
        {
            return fieldName != "LastPublished" &&
                fieldName != "ContentType" &&
                fieldName != "Modified" &&
                fieldName != "Publisher_x0020_Approval_x0020_C" &&
                fieldName != "Created" &&
                fieldName != "taskorder" &&
                fieldName != "Title" &&
                fieldName != "WBS" &&
                fieldName != "Publisher_x0020_Approval_x0020_S" &&
                fieldName != "_UIVersionString";
        }

        private void setPubPercent(double total, double count)
        {
            var complete = count / total * 95 + 5;

            if (complete > pctComplete + 10)
            {
                using (var cmd = new SqlCommand(
                    "UPDATE publishercheck set percentcomplete=@pct,laststatusdate=getdate() where projectguid=@projectguid",
                    cn))
                {
                    cmd.Parameters.AddWithValue("@projectguid", eventArgs.ProjectGuid);
                    cmd.Parameters.AddWithValue("@pct", complete);
                    cmd.ExecuteNonQuery();
                    pctComplete = complete;
                }
            }
        }

        private void AssignGroupsToTasks(int projectId, int pubType, ProjectDataSet projectDataSet)
        {
            SPGroup addMemGrp = null;
            SPGroup addVisitGrp = null;

            try
            {
                mySiteToPublish.AllowUnsafeUpdates = true;
                var projectCenterList = mySiteToPublish.Lists[ProjectCenter];
                var pcItem = projectCenterList.GetItemById(projectId);

                var projAssignTo = !string.IsNullOrWhiteSpace(Convert.ToString(pcItem[AssignedTo]))
                    ? Convert.ToString(pcItem[AssignedTo])
                    : string.Empty;

                if (pcItem?.HasUniqueRoleAssignments == true)
                {
                    foreach (SPRoleAssignment role in pcItem.RoleAssignments)
                    {
                        try
                        {
                            if (role.Member is SPGroup)
                            {
                                var tempGrp = (SPGroup)role.Member;

                                if (tempGrp.Name.Contains(Member))
                                {
                                    addMemGrp = tempGrp;
                                }

                                if (tempGrp.Name.Contains(Visitor))
                                {
                                    addVisitGrp = tempGrp;
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }

                    var projAssignToBuilder = new StringBuilder(projAssignTo);

                    foreach (ProjectDataSet.ProjectResourceRow projectResourceRow in projectDataSet.ProjectResource)
                    {
                        try
                        {
                            if (!projectResourceRow.IsWRES_ACCOUNTNull())
                            {
                                var email = string.Empty;

                                try
                                {
                                    email = projectResourceRow.WRES_EMAIL;
                                }
                                catch (Exception exception)
                                {
                                    Trace.WriteLine(exception);
                                }

                                var assignRes = from assgRow in projectDataSet.Assignment.AsEnumerable()
                                    where assgRow.Field<Guid>(ResourceUid) == projectResourceRow.RES_UID
                                    select assgRow;

                                if (assignRes.Any())
                                {
                                    addMemGrp.AddUser(projectResourceRow.WRES_ACCOUNT, email, projectResourceRow.RES_NAME, string.Empty);
                                }
                                else
                                {
                                    addVisitGrp.AddUser(projectResourceRow.WRES_ACCOUNT, email, projectResourceRow.RES_NAME, string.Empty);
                                }

                                if (!projAssignToBuilder.ToString().Contains(
                                    $";#{mySiteToPublish.AllUsers[projectResourceRow.WRES_ACCOUNT].ID};#{getResourceName(projectResourceRow.RES_UID, projectDataSet)}"))
                                {
                                    projAssignToBuilder.Append($";#{mySiteToPublish.AllUsers[projectResourceRow.WRES_ACCOUNT].ID};#{getResourceName(projectResourceRow.RES_UID, projectDataSet)}");
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }

                    addVisitGrp.Update();
                    addMemGrp.Update();
                    pcItem[AssignedTo] = projAssignToBuilder.ToString();
                    pcItem.Update();
                }
            }
            catch (Exception exception)
            {
                myLog.WriteEntry($"Error in AssignGroupsToTasks {exception.Message}{exception.StackTrace}", EventLogEntryType.Error, 305);
            }
        }

        private bool loadCurrentTasks(string projectName)
        {
            try
            {
                var taskCenter = mySiteToPublish.Lists["Task Center"];

                var query = new SPQuery
                {
                    Query = $"<Where><Eq><FieldRef Name=\"Project\"/><Value Type=\"Text\"><![CDATA[{projectName}]]></Value></Eq></Where>"
                };

                foreach (SPListItem spListItem in taskCenter.GetItems(query))
                {
                    var taskUid = string.Empty;
                    var transUid = string.Empty;

                    try
                    {
                        taskUid = spListItem[TaskUid].ToString();
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    try
                    {
                        transUid = spListItem[TransUidText].ToString();
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    if (!string.IsNullOrWhiteSpace(taskUid))
                    {
                        hshCurTasks.Add(taskUid.ToUpper(), spListItem.UniqueId);
                    }
                    else
                    {
                        if (lastTransUid.ToString().Equals(transUid, StringComparison.OrdinalIgnoreCase))
                        {
                            arrDelNewTasks.Add(spListItem.UniqueId);
                        }
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Could not load current tasks, Task Center list may not exist or be configured correctly at ({publishSiteUrl}):\r\n\r\n {exception.Message}{exception.StackTrace}",
                    EventLogEntryType.Warning,
                    210);
                return false;
            }
        }

        private bool isValidField(SPField spField)
        {
            if (spField.Hidden || spField.ReadOnlyField)
            {
                return false;
            }

            if (spField.Type == SPFieldType.Attachments || spField.Type == SPFieldType.Calculated || spField.Type == SPFieldType.User)
            {
                return false;
            }

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
                case Title:
                case AssignedTo:
                    return false;
                default:
                    return true;
            }
        }

        private string multiplyField(string fieldVal, string multiplier)
        {
            try
            {
                var newValue = float.Parse(fieldVal) / float.Parse(multiplier);
                return newValue.ToString();
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            return fieldVal;
        }

        public bool IsAssignedTaskSaved(Guid guid)
        {
            Guard.ArgumentIsNotNull(guid, nameof(guid));

            try
            {
                var status = new StatusingDerived
                {
                    Url = $"{mySite.Url}/_vti_bin/psi/statusing.asmx"
                };
                status.ReadStatusApprovalDetails(guid);
                return true;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
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