using Microsoft.SharePoint;

namespace EPMLiveWebParts.ReportFiltering.DomainServices
{
    public class SPFieldTypeHelper
    {
        //TODO: RHS - Refactor this. Ditch string literals. This should live in a class which contains the supported types so it can also be used in the toolpart where it checks supported types.
        public static SPFieldType GetFieldType(string fieldType)
        {
            switch (fieldType.ToLower().Trim())
            {
                case "text":
                    return SPFieldType.Text;
                case "currency":
                    return SPFieldType.Currency;
                case "integer":
                    return SPFieldType.Integer;
                case "number":
                    return SPFieldType.Number;
                case "choice":
                    return SPFieldType.Choice;
                case "lookup":
                    return SPFieldType.Lookup;
                case "datetime":
                    return SPFieldType.DateTime;
                case "user":
                    return SPFieldType.User;
            }

            return SPFieldType.Invalid;
        }
    }
}