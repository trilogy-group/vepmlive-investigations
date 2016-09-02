using System.Data.SqlClient;
using EPMLiveWebParts.Personalization.DomainModel;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.Personalization.Repositories
{
    public class PersonalizationDataRepository : IPersonalizationDataRepository
    {
        private readonly SPWeb _web;
        private readonly string _personalizationKey;

        public PersonalizationDataRepository(SPWeb web, string personalizationKey)
        {
            _web = web;
            _personalizationKey = personalizationKey;
        }

        public void PersistUserSettings(PersonalizationData userSettings)
        {
            var searchCriteria = new PersonalizationSearchCriteria
                                     {
                                         WebPartId = userSettings.ForeignKey,
                                         SiteId = userSettings.SiteId,
                                         WebId = userSettings.WebId,
                                         UserId = userSettings.UserId,
                                         Key = _personalizationKey
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

        private bool UserHasPersistedSettings(PersonalizationSearchCriteria personalizationSearchCriteria)
         {
             var searchResults = GetUserSettings(personalizationSearchCriteria);
             return !string.IsNullOrEmpty(searchResults.Key);
         }

        private void UpdateUserSettings(PersonalizationData personalizationData)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(_web.Site.WebApplication.Id)))
                {
                    cn.Open();

                    var cmd = new SqlCommand("UPDATE PERSONALIZATIONS set value=@value, listid=@listid where FK=@FK and userid=@userid and webid=@webid and siteid=@siteid", cn);
                    cmd.Parameters.AddWithValue("@FK", personalizationData.ForeignKey);
                    cmd.Parameters.AddWithValue("@siteid", personalizationData.SiteId);
                    cmd.Parameters.AddWithValue("@webid", personalizationData.WebId);
                    cmd.Parameters.AddWithValue("@userid", personalizationData.UserId);
                    cmd.Parameters.AddWithValue("@listid", personalizationData.ListId);
                    cmd.Parameters.AddWithValue("@key", personalizationData.Key);
                    cmd.Parameters.AddWithValue("@value", personalizationData.Value);
                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
            });
        }

        private void InsertUserSettings(PersonalizationData userSettings)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(_web.Site.WebApplication.Id)))
                {
                    cn.Open();

                    var cmd = new SqlCommand("INSERT INTO PERSONALIZATIONS (FK, userid, [key], value, siteid, webid, listid) VALUES (@FK, @userid, @key, @value, @siteid, @webid, @listid)", cn);
                    cmd.Parameters.AddWithValue("@FK", userSettings.ForeignKey);
                    cmd.Parameters.AddWithValue("@siteid", userSettings.SiteId);
                    cmd.Parameters.AddWithValue("@webid", userSettings.WebId);
                    cmd.Parameters.AddWithValue("@userid", userSettings.UserId);
                    cmd.Parameters.AddWithValue("@listid", userSettings.ListId);
                    cmd.Parameters.AddWithValue("@key", _personalizationKey);
                    cmd.Parameters.AddWithValue("@value", userSettings.Value);
                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
            });
        }

        public PersonalizationData GetUserSettings(PersonalizationSearchCriteria searchCriteria)
        {
            var userSettingsToReturn = new PersonalizationData();

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
                    cmd.Parameters.AddWithValue("@key", _personalizationKey);
                    var reader = cmd.ExecuteReader();

                    userSettingsToReturn.Hydrate(reader);

                    cn.Close();
                }
            });

            return userSettingsToReturn;
        }
    }
}