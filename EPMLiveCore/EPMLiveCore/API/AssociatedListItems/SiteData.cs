namespace EPMLiveCore.API
{
    using System;
    using System.Data;

    internal class SiteData
    {
        internal SiteData(string siteUrl, string webId, Guid projectListId, DataTable listNameTable, string projectId, string siteId,
                          string projectTitle)
        {
            SiteUrl = siteUrl;
            WebId = webId;
            ProjectListId = projectListId;
            ListNameTable = listNameTable;
            ProjectId = projectId;
            SiteId = siteId;
            ProjectTitle = projectTitle;
        }

        internal string SiteUrl { get; private set; }
        internal string WebId { get; private set; }
        internal Guid ProjectListId { get; private set; }
        internal DataTable ListNameTable { get; set; }
        internal string ProjectId { get; private set; }
        internal string SiteId { get; private set; }
        internal string ProjectTitle { get; private set; }
    }
}