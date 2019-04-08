namespace EPMLiveCore.API
{
    internal class AssociatedCountData
    {
        internal AssociatedCountData(string tableName, string rptListId, string listName)
        {
            TableName = tableName;
            RptListId = rptListId;
            ListName = listName;
        }

        internal string TableName { get; private set; }
        internal string RptListId { get; private set; }
        internal string ListName { get; private set; }
    }
}