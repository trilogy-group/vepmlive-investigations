namespace EPMLiveCore.API
{
    using System.Text;

    internal class ProjectData
    {
        internal ProjectData(
            StringBuilder sqlGetListHeaders,
            StringBuilder listAssociatedItemsDivStringBuilder,
            string projectLinkedField,
            string sourceUrl)
        {
            SqlGetListHeaders = sqlGetListHeaders;
            ListAssociatedItemsDivStringBuilder = listAssociatedItemsDivStringBuilder;
            ProjectLinkedField = projectLinkedField;
            SourceUrl = sourceUrl;
        }

        internal StringBuilder SqlGetListHeaders { get; private set; }
        internal StringBuilder ListAssociatedItemsDivStringBuilder { get; private set; }
        internal string ProjectLinkedField { get; set; }
        internal string SourceUrl { get; private set; }
    }
}