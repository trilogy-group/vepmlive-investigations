using System;
using System.Data;
using System.Data.SqlClient;
using EPMLiveReportsAdmin;
using Microsoft.SharePoint;

namespace EPMLiveCore.TagManager
{
    internal class TagRepository
    {
        #region Fields (1) 

        private readonly SPWeb _spWeb;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="TagRepository" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public TagRepository(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (2) 

        // Public Methods (2) 

        /// <summary>
        ///     Adds the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public Guid Add(Tag tag)
        {
            Tag t = Find(tag.Type, tag.ResourceId, tag.SiteId);

            if (t.Id != Guid.Empty) return t.Id;

            Guid siteId = _spWeb.Site.ID;

            var epmData = new EPMData(siteId)
                              {
                                  Command =
                                      "INSERT INTO Tags (Name, Type, ResourceId, SiteId) VALUES (@Name, @Type, @ResourceId, @SiteId)",
                                  CommandType = CommandType.Text
                              };

            epmData.Params.Add(new SqlParameter("@Name", tag.Name));
            epmData.Params.Add(new SqlParameter("@Type", tag.Type));
            epmData.Params.Add(new SqlParameter("@ResourceId", tag.ResourceId));
            epmData.Params.Add(new SqlParameter("@SiteId", tag.SiteId));

            epmData.ExecuteNonQuery(epmData.GetClientReportingConnection);

            return Find(tag.Type, tag.ResourceId, siteId).Id;
        }

        /// <summary>
        ///     Finds the specified tag.
        /// </summary>
        /// <param name="tagType">Type of the tag.</param>
        /// <param name="resourceId">The resource id.</param>
        /// <param name="siteId">The site id.</param>
        /// <returns></returns>
        public Tag Find(int tagType, int resourceId, Guid siteId)
        {
            using (var myWorkReportData = new MyWorkReportData(_spWeb.Site.ID))
            {
                DataTable tags =
                    myWorkReportData.ExecuteSql(string.Format(
                        "SELECT * FROM Tags WHERE Type = {0} AND ResourceId = {1} AND SiteId = '{2}'", tagType,
                        resourceId, siteId));

                if (tags.Rows.Count > 0)
                {
                    DataRow row = tags.Rows[0];

                    var tag = new Tag((Guid) row["TagId"]);

                    object name = row["Name"];
                    if (name != DBNull.Value && name != null)
                    {
                        tag.Name = (string) name;
                    }

                    object type = row["Type"];
                    if (type != DBNull.Value && type != null)
                    {
                        tag.Type = (int) type;
                    }

                    object resId = row["ResourceId"];
                    if (resId != DBNull.Value && resId != null)
                    {
                        tag.ResourceId = (int) resId;
                    }

                    object sId = row["SiteId"];
                    if (sId != DBNull.Value && sId != null)
                    {
                        tag.SiteId = (Guid) sId;
                    }

                    return tag;
                }
            }

            return new Tag(Guid.Empty);
        }

        #endregion Methods 
    }
}