using System.Data.SqlClient;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;

namespace ReportFiltering.Repositories
{
    public class ReportFilterUserSettingsRepository : IReportFilterUserSettingsRepository
    {
        private readonly SPWeb _web;
        private const string Key = "ReportFilterWebPartSelections";

        public ReportFilterUserSettingsRepository(SPWeb web)
        {
            _web = web;
        }

        public void PersistUserSettings(ReportFilterUserSettings userSettings)
        {
            var searchCriteria = new ReportFilterSearchCriteria
                                     {
                                         WebPartId = userSettings.WebPartId,
                                         SiteId = userSettings.SiteId,
                                         WebId = userSettings.WebId,
                                         UserId = userSettings.UserId
                                     };

            if (UserHasPersistedSettings(searchCriteria))
            {
                UpdateUserSettings(userSettings);
            }
            else
            {
                InsertUserSettings(userSettings);
            }
         }

         private bool UserHasPersistedSettings(ReportFilterSearchCriteria userSettings)
         {
             var searchResults = GetUserSettings(userSettings);

             return searchResults.IsValid;
         }

        private void UpdateUserSettings(ReportFilterUserSettings userSettings)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(_web.Site.WebApplication.Id)))
                {
                    cn.Open();

                    var cmd = new SqlCommand("UPDATE PERSONALIZATIONS set value=@value, listid=@listid where FK=@FK and userid=@userid and webid=@webid and siteid=@siteid", cn);
                    cmd.Parameters.AddWithValue("@FK", userSettings.WebPartId);
                    cmd.Parameters.AddWithValue("@siteid", userSettings.SiteId);
                    cmd.Parameters.AddWithValue("@webid", userSettings.WebId);
                    cmd.Parameters.AddWithValue("@userid", userSettings.UserId);
                    cmd.Parameters.AddWithValue("@listid", userSettings.ListId);
                    cmd.Parameters.AddWithValue("@key", Key);
                    cmd.Parameters.AddWithValue("@value", userSettings.Value);
                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
            });
        }

        private void InsertUserSettings(ReportFilterUserSettings userSettings)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(_web.Site.WebApplication.Id)))
                {
                    cn.Open();

                    var cmd = new SqlCommand("INSERT INTO PERSONALIZATIONS (FK, userid, [key], value, siteid, webid, listid) VALUES (@FK, @userid, @key, @value, @siteid, @webid, @listid)", cn);
                    cmd.Parameters.AddWithValue("@FK", userSettings.WebPartId);
                    cmd.Parameters.AddWithValue("@siteid", userSettings.SiteId);
                    cmd.Parameters.AddWithValue("@webid", userSettings.WebId);
                    cmd.Parameters.AddWithValue("@userid", userSettings.UserId);
                    cmd.Parameters.AddWithValue("@listid", userSettings.ListId);
                    cmd.Parameters.AddWithValue("@key", Key);
                    cmd.Parameters.AddWithValue("@value", userSettings.Value);
                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
            });
        }

        public ReportFilterUserSettings GetUserSettings(ReportFilterSearchCriteria searchCriteria)
        {
            var userSettingsToReturn = new ReportFilterUserSettings();

            SqlConnection cn;
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(_web.Site.WebApplication.Id)))
                {
                    cn.Open();

                    var cmd = new SqlCommand("SELECT * FROM PERSONALIZATIONS WHERE FK=@FK and UserId=@userid and [Key]=@key and SiteId=@siteid and WebId=@webid", cn);
                    cmd.Parameters.AddWithValue("@FK", searchCriteria.WebPartId.ToString());
                    cmd.Parameters.AddWithValue("@siteid", searchCriteria.SiteId.ToString());
                    cmd.Parameters.AddWithValue("@webid", searchCriteria.WebId.ToString());
                    cmd.Parameters.AddWithValue("@userid", searchCriteria.UserId);
                    cmd.Parameters.AddWithValue("@key", Key);
                    var reader = cmd.ExecuteReader();

                    userSettingsToReturn.Hydrate(reader);

                    cn.Close();
                }
            });

            return userSettingsToReturn;
        }
    }
}