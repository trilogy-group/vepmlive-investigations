using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPMLiveCore;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using WorkEnginePPM.Core.DataSync;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Layouts.ppm.Admin
{
    public partial class InstallDataSyncEvents : LayoutsPageBase
    {
        #region Methods (11) 

        // Protected Methods (5) 

        /// <summary>
        /// Installs the button on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void InstallButtonOnClick(object sender, EventArgs e)
        {
            using (var workEngineAPI = new WorkEngineAPI())
            {
                DataSyncLog.Text = Server.HtmlEncode(workEngineAPI.Execute("AddRemoveFeatureEvents",
                                                                           @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEDataSync"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>"));

                ResourceManagementLog.Text = Server.HtmlEncode(workEngineAPI.Execute("AddRemoveFeatureEvents",
                                                                                     @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEResourceManagement"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>"));
            }

            DataSyncPanel.Visible = true;
            ResourceManagementPanel.Visible = true;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Syncs the lists.
        /// </summary>
        /// <returns></returns>
        protected string SyncLists()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(SyncRoles());
            stringBuilder.AppendLine(SyncWorkHours());
            stringBuilder.AppendLine(SyncHolidaySchedules());
            stringBuilder.AppendLine(SyncPersonalItems());

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Syncs the lists button on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void SyncListsButtonOnClick(object sender, EventArgs e)
        {
            SyncListLog.Text = SyncLists();
            ListSyncPanel.Visible = true;
        }

        /// <summary>
        /// Uns the install button on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void UnInstallButtonOnClick(object sender, EventArgs e)
        {
            using (var workEngineAPI = new WorkEngineAPI())
            {
                DataSyncLog.Text = Server.HtmlEncode(workEngineAPI.Execute("AddRemoveFeatureEvents",
                                                                           @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEDataSync"" Operation=""REMOVE""/></Data></AddRemoveFeatureEvents>"));

                ResourceManagementLog.Text = Server.HtmlEncode(workEngineAPI.Execute("AddRemoveFeatureEvents",
                                                                                     @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEResourceManagement"" Operation=""REMOVE""/></Data></AddRemoveFeatureEvents>"));
            }

            DataSyncPanel.Visible = true;
            ResourceManagementPanel.Visible = true;
        }

        // Private Methods (6) 

        /// <summary>
        /// Builds the heading.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private string BuildHeading(string message)
        {
            return
                string.Format(
                    @"--------------------------------------------------{0}{1}{0}--------------------------------------------------",
                    Environment.NewLine, message.ToUpper());
        }

        /// <summary>
        /// Builds the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private string BuildMessage(string message)
        {
            return string.Format(@" - {0}", message);
        }

        /// <summary>
        /// Syncs the holiday schedules.
        /// </summary>
        /// <returns></returns>
        private string SyncHolidaySchedules()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(BuildHeading("Synchronizing Holiday Schedules"));

            try
            {
                IEnumerable<SPList> spLists = Web.GetListByTemplateId((int) EPMLiveLists.HolidaySchedules);
                if (spLists == null) throw new Exception("Cannot find the HolidaySchedules list.");

                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (var holidayManager = new HolidayManager(spSite.OpenWeb(Web.ID)))
                    {
                        List<HolidaySchedule> holidaySchedules =
                            holidayManager.Synchronize(holidayManager.GetExistingHolidaySchedules(spLists.First().Items));

                        foreach (HolidaySchedule holidaySchedule in holidaySchedules)
                        {
                            stringBuilder.AppendLine(
                                BuildMessage(string.Format(@"SUCCESS. Title: {0}. Holidays: {1}",
                                                           holidaySchedule.Title,
                                                           string.Join(", ",
                                                                       (holidaySchedule.Holidays.Select(h => h.Title)).
                                                                           ToArray()))));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                stringBuilder.AppendLine(BuildMessage(string.Format(@"ERROR. {0}.", exception.Message)));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Syncs the personal items.
        /// </summary>
        /// <returns></returns>
        private string SyncPersonalItems()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(BuildHeading("Synchronizing Personal Items"));

            try
            {
                SPList spList = Web.Lists.TryGetList("Non Work");
                if (spList == null) throw new Exception("Cannot find the Non Work list.");

                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (var personalItemManager = new PersonalItemManager(spSite.OpenWeb(Web.ID)))
                    {
                        foreach (
                            PersonalItem personalItem in
                                personalItemManager.Synchronize(
                                    personalItemManager.GetExistingPersonalItems(spList.Items)))
                        {
                            stringBuilder.AppendLine(
                                BuildMessage(string.Format(@"SUCCESS. Title: {0}.", personalItem.Title)));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                stringBuilder.AppendLine(BuildMessage(string.Format(@"ERROR. {0}.", exception.Message)));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Syncs the roles.
        /// </summary>
        /// <returns></returns>
        private string SyncRoles()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(BuildHeading("Synchronizing Roles"));

            try
            {
                IEnumerable<SPList> spLists = Web.GetListByTemplateId((int) EPMLiveLists.Roles);
                if (spLists == null) throw new Exception("Cannot find the Roles list.");

                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (var roleManager = new RoleManager(spSite.OpenWeb(Web.ID)))
                    {
                        SPListItem spListItem = spLists.First().Items[0];
                        foreach (Role role in roleManager.AddOrUpdate(
                            new Role { Title = spListItem.Title, Id = spListItem.ID, RoleId = (string)spListItem["RoleId"] }))
                        {
                            stringBuilder.AppendLine(
                                BuildMessage(string.Format(@"SUCCESS. Title: {0}. Display Name: {1}.", role.Title,
                                                           role.CCRName)));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                stringBuilder.AppendLine(BuildMessage(string.Format(@"ERROR. {0}.", exception.Message)));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Syncs the work hours.
        /// </summary>
        /// <returns></returns>
        private string SyncWorkHours()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(BuildHeading("Synchronizing Work Hours"));

            try
            {
                IEnumerable<SPList> spLists = Web.GetListByTemplateId((int) EPMLiveLists.WorkHours);
                if (spLists == null) throw new Exception("Cannot find the WorkHours list.");

                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (var workScheduleManager = new WorkScheduleManager(spSite.OpenWeb(Web.ID)))
                    {
                        foreach (WorkSchedule workSchedule in workScheduleManager.Synchronize(
                            workScheduleManager.GetExistingWorkSchedules(spLists.First().Items)))
                        {
                            stringBuilder.AppendLine(
                                BuildMessage(string.Format(@"SUCCESS. Title: {0}.", workSchedule.Title)));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                stringBuilder.AppendLine(BuildMessage(string.Format(@"ERROR. {0}.", exception.Message)));
            }

            return stringBuilder.ToString();
        }

        #endregion Methods 
    }
}