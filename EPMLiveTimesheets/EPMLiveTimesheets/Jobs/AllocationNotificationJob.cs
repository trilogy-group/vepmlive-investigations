using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections;
using System.Globalization;
using Microsoft.SharePoint;
using TimeSheets.Models;
using EPMLiveCore.API;

namespace TimeSheets
{
    public class AllocationNotificationJob : BaseJob
    {

        public void execute(SPSite site, string data)
        {
            WebAppId = site.WebApplication.Id;
            try
            {
                using (SqlConnection cn = CreateConnection())
                {

                    CheckNonTeamMemberAllocation(site.RootWeb, base.TSUID.ToString(), cn.ConnectionString, data);

                    if (sErrors != "")
                        bErrors = true;

                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors = "Error: " + ex.Message;
            }
            finally
            {                
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }

        public static void CheckNonTeamMemberAllocation(SPWeb oWeb, string tsuid, string cn, string data)
        {
            List<TimeSheetItem> timeSheetItems;
            double qtdAllocatedHours = 0;

            timeSheetItems = GetTimeSheetItems(data, cn);
            qtdAllocatedHours = CalculateAllocatedHours(timeSheetItems, cn);

            if (qtdAllocatedHours > 0)
                RunPermissionsChecks(timeSheetItems, qtdAllocatedHours, oWeb);

        }

        private static List<TimeSheetItem> GetTimeSheetItems(string data, string connectionString)
        {
            XDocument doc = XDocument.Parse(data);

            var items = doc.Element("Timesheet")?.Elements("Item").ToList();

            var timeSheetItems = (from item in items
                                  select new TimeSheetItem()
                                  {
                                      ItemID = int.Parse(item.Attribute("ItemID")?.Value),
                                      ProjectName = item.Attribute("Project")?.Value,
                                      Uid = Guid.Parse(item.Attribute("UID")?.Value ?? Guid.Empty.ToString()),
                                      Hours = (from hour in item.Element("Hours")?.Elements("Date")
                                               select new TimeSheetHourItem()
                                               {
                                                   Date = DateTime.Parse(hour.Attribute("Value")?.Value),
                                                   Hour = Convert.ToDouble(hour.Element("Time")?.Attribute("Hours")?.Value)
                                               }).ToList(),
                                      Changed = false,
                                      AssignedToID = item.Attribute("AssignedToID")?.Value.ToString(),
                                      ItemTitle = item.Attribute("Title")?.Value.ToString(),
                                      WorkTypeField = item.Attribute("WorkTypeField")?.Value.ToString()
                                  }).ToList();

            return timeSheetItems;
        }

        private static double CalculateAllocatedHours(List<TimeSheetItem> timeSheetItems, string connectionString)
        {
            double result = 0;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    timeSheetItems.ForEach(timeSheetItem =>
                    {
                        List<TimeSheetHourItem> dbHourItems = new List<TimeSheetHourItem>();
                        SqlCommand cmd = new SqlCommand("SELECT TS_ITEM_DATE,TS_ITEM_HOURS  FROM TSITEMHOURS where TS_ITEM_UID=@tsitemuid", cn);
                        cmd.Parameters.AddWithValue("@tsitemuid", timeSheetItem.Uid);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dbHourItems.Add(new TimeSheetHourItem()
                                {
                                    Date = dr.GetDateTime(0),
                                    Hour = dr.GetDouble(1)
                                });
                            }
                        }

                        timeSheetItem.Hours.ForEach(hourItem =>
                        {
                            var dbItem = dbHourItems.FirstOrDefault(x => x.Date == hourItem.Date);
                            if (dbItem == null || dbItem.Hour != hourItem.Hour)
                            {
                                result += hourItem.Hour;
                                timeSheetItem.Changed = true;
                            }
                        });
                    });
                }
            });

            return Math.Round(result * 4, 0) / 4;
        }

        private const string PROJECT_WORK_FIELD_NAME = "Project Center";
        private const string TASK_WORK_FIELD_NAME = "Task Center";
        private const string PORTFLOIO_WORK_FIELD_NAME = "Project Portfolios";
        private const string PROGRAM_WORK_FIELD_NAME = "Project Programs";
        private static void RunPermissionsChecks(List<TimeSheetItem> timeSheetItems, double allocatedHours, SPWeb oWeb)
        {
            timeSheetItems.ForEach(timeSheetItem =>
            {
                if (timeSheetItem.Changed)
                {
                    switch (timeSheetItem.WorkTypeField)
                    {
                        case TASK_WORK_FIELD_NAME:
                            CheckTaskTimeAllocation(oWeb, timeSheetItem, allocatedHours);
                            break;
                        case PROGRAM_WORK_FIELD_NAME:
                            CheckProgramTimeAllocation(oWeb, timeSheetItem, allocatedHours);
                            break;
                        case PROJECT_WORK_FIELD_NAME:
                            CheckProjectTimeAllocation(oWeb, timeSheetItem, allocatedHours);
                            break;
                        case PORTFLOIO_WORK_FIELD_NAME:
                            CheckPortfloioTimeAllocation(oWeb, timeSheetItem, allocatedHours);
                            break;
                    }
                }

            });
        }

        private static void CheckTaskTimeAllocation(SPWeb oWeb, TimeSheetItem timeSheetItem, double allocatedHours)
        {
            SPUserToken systoken = oWeb.Site.SystemAccount.UserToken;
            SPListItem projectItem = null;
            using (SPSite site = new SPSite(oWeb.Site.ID, systoken))
            {
                using (SPWeb webSysAdmin = site.OpenWeb())
                {
                    //var task = IsResourceTeamMember(oWeb, timeSheetItem, TASK_WORK_FIELD_NAME);
                    projectItem = webSysAdmin.Lists[PROJECT_WORK_FIELD_NAME].Items.OfType<SPListItem>()
                .Where(x => x.Name == timeSheetItem.ProjectName).FirstOrDefault();

                    var project = IsResourceTeamMember(oWeb, new TimeSheetItem() { ItemID = projectItem.ID }, PROJECT_WORK_FIELD_NAME);

                    var userTypesTosend = new List<string>() { "Owner", "Planners", "ProjectManagers" };
                    var emailToList = new List<string>();
                    var idToList = new List<int>();

                    if (!project.Item2) // Item2 = isMember
                    {
                        userTypesTosend.ForEach(userType =>
                        {
                            var usersToSendNotification = GetUsersToSendNotification(projectItem, userType, webSysAdmin);
                            emailToList.AddRange(usersToSendNotification.Item1);
                            idToList.AddRange(usersToSendNotification.Item2);
                        });

                        SendNotifications(oWeb, emailToList, idToList, allocatedHours, $"{timeSheetItem.ProjectName} - {timeSheetItem.ItemTitle}",
                            "an outside", "is not currently assigned to the Project Team", PROJECT_WORK_FIELD_NAME);
                    }
                    else if (timeSheetItem.AssignedToID == null || !timeSheetItem.AssignedToID.Split(',').ToList().Contains(oWeb.CurrentUser.ID.ToString()))
                    {
                        userTypesTosend.ForEach(userType =>
                        {
                            var usersToSendNotification = GetUsersToSendNotification(projectItem, userType, webSysAdmin);
                            emailToList.AddRange(usersToSendNotification.Item1);
                            idToList.AddRange(usersToSendNotification.Item2);
                        });

                        SendNotifications(oWeb, emailToList, idToList, allocatedHours, $"{timeSheetItem.ProjectName} - {timeSheetItem.ItemTitle}",
                            "unassigned", "is currently assigned to the project team but has not been assigned to the task where time has been allocated",
                            PROJECT_WORK_FIELD_NAME);
                    }
                }
            }
        }

        private static Tuple<List<string>, List<int>> GetUsersToSendNotification(SPListItem listItem, string fieldName, SPWeb oWeb)
        {
            var emailList = new List<string>();
            var idList = new List<int>();
            int userIdInt;
            SPUser userAux;

            if (listItem.Fields.OfType<SPField>().Where(x => x.Title == fieldName).Any())
            {
                listItem[fieldName]?.ToString().Replace("#", "").Split(';').ToList()
                .Where((item, index) => index % 2 == 0)?.ToList().ForEach(userID =>
                {
                    if (int.TryParse(userID, out userIdInt) && (userAux = oWeb.SiteUsers.GetByID(userIdInt)) != null)
                    {
                        emailList.Add(string.IsNullOrWhiteSpace(userAux.Email) ? GetEmailFromDB(userIdInt, oWeb) : userAux.Email);
                        idList.Add(userIdInt);
                    }
                });
            }

            return new Tuple<List<string>, List<int>>(emailList, idList);
        }

        private static string GetEmailFromDB(int iD, SPWeb oWeb)
        {
            var rptData = new EPMLiveCore.ReportHelper.MyWorkReportData(oWeb.Site.ID);
            var sql = string.Format(@"Select [Email] from [LSTResourcepool] WHERE [SharePointAccountID] = {0}", iD);
            var tblEmail = rptData.ExecuteSql(sql);

            if (tblEmail?.Rows?.Count > 0 && tblEmail.Rows[0][0] != null)
                return tblEmail.Rows[0][0].ToString();
            else
                return string.Empty;
        }

        private static void CheckProgramTimeAllocation(SPWeb oWeb, TimeSheetItem timeSheetItem, double allocatedHours)
        {
            var user = IsResourceTeamMember(oWeb, timeSheetItem, PROGRAM_WORK_FIELD_NAME);
            var emailToList = new List<string>();
            var userTypesTosend = new List<string>() { "Owner" };
            var idToList = new List<int>();

            if (!user.Item2) // Item2 = isMember
            {
                userTypesTosend.ForEach(userType =>
                {
                    var usersToSendNotification = GetUsersToSendNotification(user.Item1, userType, oWeb);
                    emailToList.AddRange(usersToSendNotification.Item1);
                    idToList.AddRange(usersToSendNotification.Item2);
                });

                SendNotifications(oWeb, emailToList, idToList, allocatedHours, $"{ timeSheetItem.ItemTitle } programme",
                    "an outside", "is not currently assigned to the Programme Team", PROGRAM_WORK_FIELD_NAME);
            }
        }

        private static Tuple<SPListItem, bool> IsResourceTeamMember(SPWeb oWeb, TimeSheetItem timeSheetItem, string itemTypeName)
        {
            bool isMember = false;
            var userList = new List<SPUser>();
            var listItem = oWeb.Lists[itemTypeName]?.Items?.OfType<SPListItem>()
                .Where(x => x.ID == timeSheetItem.ItemID).FirstOrDefault();

            if (listItem != null)
            {
                if (itemTypeName != PORTFLOIO_WORK_FIELD_NAME)
                    isMember = listItem.DoesUserHavePermissions(SPBasePermissions.ViewListItems);

                if (!isMember && listItem.Fields.OfType<SPField>().Where(x => x.InternalName == "AssignedTo").Any())
                {
                    var assignedToField = listItem["AssignedTo"]?.ToString().Replace("#", "").Split(';').ToList();
                    assignedToField?.Where((item, index) => index % 2 == 0)?.ToList().ForEach(userGroupID =>
                    {
                        userList = GetUserFromField(userGroupID, oWeb);
                        userList.ForEach(user => isMember = isMember || user.ID == oWeb.CurrentUser.ID);
                    });
                }

                if (!isMember && listItem.Fields.OfType<SPField>().Where(x => x.Title == "Owner").Any())
                {
                    var ownersField = listItem["Owner"]?.ToString().Replace("#", "").Split(';').ToList();
                    ownersField?.Where((item, index) => index % 2 == 0)?.ToList().ForEach(userGroupID =>
                    {
                        userList = GetUserFromField(userGroupID, oWeb);
                        userList.ForEach(user => isMember = isMember || user.ID == oWeb.CurrentUser.ID);
                    });
                }
            }

            return new Tuple<SPListItem, bool>(listItem, isMember);
        }

        private static List<SPUser> GetUserFromField(string value, SPWeb oWeb)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<SPUser>();

            var splitedIDs = value.Split(',').ToList();
            var returnList = new List<SPUser>();
            int id = -1;

            splitedIDs.ForEach(i =>
            {
                if (!string.IsNullOrWhiteSpace(i) && int.TryParse(i, out id))
                {
                    if (oWeb.SiteUsers.OfType<SPUser>().Any(x => x.ID == id))
                        returnList.Add(oWeb.SiteUsers.GetByID(id));
                    else if (oWeb.SiteGroups.OfType<SPGroup>().Any(x => x.ID == id))
                        oWeb.SiteGroups.GetByID(id)?.Users?.OfType<SPUser>()?.ToList()
                            .Where(x => x.Name != "System Account").ToList()
                            .ForEach(x => returnList.Add(x));
                }
            });

            return returnList;
        }

        private const int NON_TEAM_MEMBER_ALLOCATION_EMAIL = 16;
        private const int NON_TEAM_MEMBER_ALLOCATION_GENERAL_NOTIFICATION = 17;
        public static void SendNotifications(SPWeb oWeb, List<string> emailToList, List<int> idToList, double allocatedHours,
            string itemName, string outOrUnassigned, string reasonMessage, string urlCenter)
        {
            emailToList = emailToList.Distinct().Where(i => !string.IsNullOrWhiteSpace(i)).ToList();
            idToList = idToList.Distinct().Where(x => x != 0).ToList();

            if (idToList.Count > 0 && allocatedHours > 0)
            {
                var projecturl = string.Format("{0}?ID={1}", oWeb.Lists[CultureInfo.CurrentCulture.TextInfo.ToTitleCase(urlCenter.ToLower())].DefaultDisplayFormUrl, 1); // TODO remove the 1
                Hashtable hshProps = new Hashtable();
                hshProps.Add("Item_Name", itemName);
                hshProps.Add("Hours", allocatedHours);
                hshProps.Add("Project_Url", projecturl);
                hshProps.Add("CurUser_Email", oWeb.CurrentUser.Email);
                hshProps.Add("Out_Unassigned", outOrUnassigned);
                hshProps.Add("Reason_Message", reasonMessage);

                APIEmail.QueueItemMessage(NON_TEAM_MEMBER_ALLOCATION_GENERAL_NOTIFICATION, false, hshProps,
                    idToList.Select(x => x.ToString()).ToArray(), null, true, true, oWeb, oWeb.CurrentUser, true);
            }

            if (emailToList.Count > 0)
                APIEmail.sendEmail(NON_TEAM_MEMBER_ALLOCATION_EMAIL,
                    new Hashtable() { { "Item_Name", itemName },
                                      { "Resource_Email", GetEmailFromDB(oWeb.CurrentUser.ID, oWeb) },
                                      { "Qty_Hours", allocatedHours },
                                      { "Out_Unassigned", outOrUnassigned },
                                      { "Reason_Message", reasonMessage } },
                    emailToList, string.Empty, oWeb, true);
        }

        private static void CheckProjectTimeAllocation(SPWeb oWeb, TimeSheetItem timeSheetItem, double allocatedHours)
        {
            var user = IsResourceTeamMember(oWeb, timeSheetItem, PROJECT_WORK_FIELD_NAME);
            var emailToList = new List<string>();
            var userTypesTosend = new List<string>() { "Owner", "Planners", "ProjectManagers" };
            var idToList = new List<int>();

            if (!user.Item2) // Item2 = isMember
            {
                userTypesTosend.ForEach(userType =>
                {
                    var usersToSendNotification = GetUsersToSendNotification(user.Item1, userType, oWeb);
                    emailToList.AddRange(usersToSendNotification.Item1);
                    idToList.AddRange(usersToSendNotification.Item2);
                });

                SendNotifications(oWeb, emailToList, idToList, allocatedHours, $"{ timeSheetItem.ItemTitle } project",
                    "an outside", "is not currently assigned to the Project Team", PROJECT_WORK_FIELD_NAME);
            }
        }

        private static void CheckPortfloioTimeAllocation(SPWeb oWeb, TimeSheetItem timeSheetItem, double allocatedHours)
        {
            var user = IsResourceTeamMember(oWeb, timeSheetItem, PORTFLOIO_WORK_FIELD_NAME);
            var emailToList = new List<string>();
            var idToList = new List<int>();
            var userList = new List<SPUser>();

            if (!user.Item2) // Item2 = isMember
            {
                var resourcesToNotify = GetResourceToNotifyPortfolios(timeSheetItem.ItemID, oWeb);

                if (!string.IsNullOrWhiteSpace(resourcesToNotify))
                {
                    resourcesToNotify.Split(',').ToList().ForEach(userGroupID =>
                    {
                        userList = GetUserFromField(userGroupID, oWeb);
                        userList.ForEach(userItem =>
                        {
                            emailToList.Add(string.IsNullOrWhiteSpace(userItem.Email) ? GetEmailFromDB(userItem.ID, oWeb) : userItem.Email);
                            idToList.Add(userItem.ID);
                        });
                    });
                }

                SendNotifications(oWeb, emailToList, idToList, allocatedHours, $"{ timeSheetItem.ItemTitle } portfolio",
                    "an outside", "is not currently assigned to the Portfolio Team", PORTFLOIO_WORK_FIELD_NAME);
            }
        }

        private static string GetResourceToNotifyPortfolios(int portfolioID, SPWeb oWeb)
        {
            var rptData = new EPMLiveCore.ReportHelper.MyWorkReportData(oWeb.Site.ID);
            var epmLPortManagerColumn = EPMLiveCore.CoreFunctions.getConfigSetting(oWeb, "EPMPortManagerColumn");
            var sql = string.Format(@"SELECT [{0}] FROM dbo.LSTProjectPortfolios WHERE [id] = {1}",
                                    string.IsNullOrWhiteSpace(epmLPortManagerColumn) ? "OwnerID" : epmLPortManagerColumn, portfolioID);
            var dataTable = rptData?.ExecuteSql(sql);

            if (dataTable?.Rows?.Count > 0)
                return dataTable.Rows[0][0].ToString();
            else
                return string.Empty;
        }

    }
}
