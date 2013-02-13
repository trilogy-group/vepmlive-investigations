using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.TagManager
{
    internal class TagRepository
    {
        #region Fields (2) 

        private readonly QueryExecutor _queryExecutor;
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
            _queryExecutor = new QueryExecutor(_spWeb);
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

            _queryExecutor.ExecuteEpmLiveNonQuery(
                "INSERT INTO Tags (Name, Type, ResourceId, SiteId) VALUES (@Name, @Type, @ResourceId, @SiteId)",
                new Dictionary<string, object>
                    {
                        {"@Name", tag.Name},
                        {"@Type", tag.Type},
                        {"@ResourceId", tag.ResourceId},
                        {"@SiteId", tag.SiteId}
                    });

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
            DataTable tags =
                _queryExecutor.ExecuteEpmLiveQuery(
                    "SELECT * FROM Tags WHERE Type = @TagType AND ResourceId = @ResourceId AND SiteId = @SiteId",
                    new Dictionary<string, object>
                        {
                            {"@TagType", tagType},
                            {"@ResourceId", resourceId},
                            {"@SiteId", siteId}
                        });

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

            return new Tag(Guid.Empty);
        }

        #endregion Methods 
    }
}