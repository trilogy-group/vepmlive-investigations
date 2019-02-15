using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Text;
using EPMLiveEnterprise.EPMLivePortfolioEngine;
using EPMLiveEnterprise.WebSvcProject;
using EPMLiveEnterprise.WebSvcWssInterop;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
        private void linkProjectWss()
        {
            var dsCurrentWssInfo = new WssSettingsDataSet();
            SPSecurity.RunWithElevatedPrivileges(() => dsCurrentWssInfo = pWssInterop.ReadWssSettings());

            if (dsCurrentWssInfo.WssAdmin.Count < 1)
            {
                throw new InvalidOperationException("Invalid WssAdmin Count");
            }

            var adminRow = dsCurrentWssInfo.WssAdmin[0];
            var serverUid = adminRow.WADMIN_CURRENT_STS_SERVER_UID;
            var siteUrl = publishSiteUrl;
            var slash = siteUrl.IndexOf(Slash, 9);
            siteUrl = siteUrl.Substring(slash + 1);

            try
            {
                try { }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);

                    using (var sqlConnection = new SqlConnection(EPMLiveHelperClasses.getProjectServerPublishedConnectionString(mySiteGuid)))
                    {
                        sqlConnection.Open();

                        using (var cmd = new SqlCommand(
                            "UPDATE MSP_PROJECTS set WPROJ_STS_SUBWEB_NAME=@web,WSTS_SERVER_UID=@sts,PROJ_READ_COUNT=0 where PROJ_UID=@projuid",
                            sqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@web", siteUrl);
                            cmd.Parameters.AddWithValue("@sts", serverUid);
                            cmd.Parameters.AddWithValue("@projuid", projectGuid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry($"Error in linkProjectWss(): {ex.Message}{ex.StackTrace}{ex.InnerException}", EventLogEntryType.Error, 315);
            }
        }

        private string getProjectWss(string pwaUrl, Guid projectUid)
        {
            try
            {
                var wssInterop = new WssInterop
                {
                    Url = $"{pwaUrl}/_vti_bin/psi/wssinterop.asmx",
                    Credentials = CredentialCache.DefaultCredentials
                };

                var projectWssInfoDataSet = new ProjectWSSInfoDataSet();

                SPSecurity.RunWithElevatedPrivileges(() => projectWssInfoDataSet = wssInterop.ReadWssData(projectUid));

                if (projectWssInfoDataSet.ProjWssInfo.Count > 0)
                {
                    return projectWssInfoDataSet.ProjWssInfo[0].PROJECT_WORKSPACE_URL;
                }
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Error in getProjectWss(): {exception.Message}{exception.StackTrace}{exception.InnerException}",
                    EventLogEntryType.Error,
                    315);
            }

            return string.Empty;
        }

        private int publishProjectCenter(ProjectDataSet projectDataSet)
        {
            try
            {
                var lProjectCenter = mySiteToPublish.Lists[ProjectCenter];

                if (projectDataSet.Project.Count < 0)
                {
                    throw new InvalidOperationException("Invalid Project Count");
                }

                var query = new SPQuery
                {
                    Query = $"<Where><Eq><FieldRef Name=\'Title\'/><Value Type=\'Text\'>{projectDataSet.Project[0].PROJ_NAME}</Value></Eq></Where>"
                };

                SPListItem listItem;

                if (lProjectCenter.GetItems(query).Count > 0)
                {
                    listItem = lProjectCenter.GetItems(query)[0];

                    try
                    {
                        if (listItem[IsProjectServer].ToString() != bool.TrueString)
                        {
                            return 0;
                        }
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }
                }
                else
                {
                    listItem = lProjectCenter.Items.Add();
                    listItem[IsProjectServer] = "1";
                }

                var taskRow = (ProjectDataSet.TaskRow)projectDataSet.Task.Select("TASK_ID=0")[0];

                listItem[lProjectCenter.Fields.GetFieldByInternalName(Title).Id] = projectDataSet.Project[0].PROJ_NAME;
                listItem[ProjectGuid] = projectDataSet.Project[0].PROJ_UID.ToString();
                listItem[PublishToPwa] = "0";
                listItem[SharePointProject] = "0";
                listItem[IsProjectServer] = "1";
                listItem[ProjectServerUrl] = projectServerUrl;

                try
                {
                    listItem[lProjectCenter.Fields.GetFieldByInternalName(AssignedTo).Id] =
                        getResourceWssId(projectDataSet.Project[0].ProjectOwnerID);
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                processProjectCenterFields(projectDataSet, arrPJFieldsToPublish, ref listItem);
                processTask(taskRow, projectDataSet, arrPJFieldsToPublish, listItem, hshProjectCenterFields, string.Empty, 2);
                hshTaskHierarchy.Add(taskRow.TASK_UID, string.Empty);

                return listItem.ID;
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Error in publishProjectCenter(): {exception.Message}{exception.StackTrace}{exception.InnerException}",
                    EventLogEntryType.Error,
                    315);
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
                ProjectDataSet projectDataSet = null;
                var lstName = ProjectCenter;

                SPSecurity.RunWithElevatedPrivileges(() => projectDataSet = pService.ReadProject(projectGuid, DataStoreEnum.PublishedStore));

                var stringBuilder = new StringBuilder(
                    $"<UpdateScheduledWork><Params Worktype=\"1\"/><Data><Project ID=\'{projectId}\' List=\'{lstName}\'>");

                foreach (ProjectDataSet.AssignmentRow assignmentRow in projectDataSet.Assignment)
                {
                    var resourceId = getResourceResId(assignmentRow.RES_UID_OWNER);

                    if (resourceId > 0)
                    {
                        stringBuilder.Append($"<Resource Id=\"{resourceId}\">");

                        var assnStartDate = assignmentRow.ASSN_START_DATE;
                        var assnFinishDate = assignmentRow.ASSN_FINISH_DATE;
                        var interval = (assnFinishDate - assnStartDate).Days;
                        var hour = assignmentRow.ASSN_WORK;
                        var loopStDate = assnStartDate;

                        while (loopStDate <= assnFinishDate)
                        {
                            var individualHour = hour / (interval + 1) / assignmentRow.ASSN_UNITS / 6;
                            stringBuilder.Append($"<Work Date=\"{DateTime.Parse(loopStDate.ToString()):s}\" Hours=\"{individualHour}\"/>");
                            loopStDate = loopStDate.AddDays(1);
                        }

                        stringBuilder.Append("</Resource>");
                    }
                }

                stringBuilder.Append("</Project></Data></UpdateScheduledWork>");

                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        var portfolioEngineApi = new PortfolioEngineAPI
                        {
                            Url = $"{mySiteToPublish.Url}/_vti_bin/portfolioengine.asmx",
                            UseDefaultCredentials = true
                        };
                        portfolioEngineApi.Execute("UpdateScheduledWork", stringBuilder.ToString());
                    });
            }
            catch (Exception exception)
            {
                myLog.WriteEntry($"Error in ProcessPFEWork {exception.Message}{exception.StackTrace}", EventLogEntryType.Error, 305);
            }
        }

        private void processProjectCenterFields(ProjectDataSet projectDataSet, IEnumerable arrFToPublish, ref SPListItem listItem)
        {
            try
            {
                foreach (string field in arrFToPublish)
                {
                    var fieldSplit = field.Split(FieldSplitChar);

                    if (fieldSplit.Length < 6)
                    {
                        throw new InvalidOperationException("Invalid fieldSplit length");
                    }

                    var fieldName = fieldSplit[0];
                    var wssFieldName = fieldSplit[1];
                    var fieldCategory = fieldSplit[3];
                    var fieldType = fieldSplit[4];
                    var multiplier = fieldSplit[5];

                    if (fieldCategory == "4")
                    {
                        var drAssn = projectDataSet.ProjectCustomFields.Select($"MD_PROP_ID=\'{fieldName}\'");

                        if (drAssn.Length >= 1)
                        {
                            var fieldData = GetFieldData(fieldType, drAssn, fieldName, true);
                            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Error processing Project Center Enterprise Fields: {exception.Message}{exception.StackTrace}",
                    EventLogEntryType.Error,
                    330);
            }

            listItem.Update();
        }
    }
}