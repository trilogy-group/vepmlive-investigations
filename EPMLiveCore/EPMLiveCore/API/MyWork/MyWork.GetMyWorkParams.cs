using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal static class GetMyWorkParams
    {
        internal static List<string> SelectedLists = new List<string>();
        internal static List<string> SelectedFields = new List<string>();
        internal static List<string> SiteUrls = new List<string>();
        internal static bool PerformanceMode = true;
        internal static bool NoListsSelected = true;
        internal static Dictionary<string, SPField> FieldTypes;
        internal static Dictionary<string, string> WorkTypes = new Dictionary<string, string>();
        internal static Dictionary<string, string> WorkSpaces = new Dictionary<string, string>();
        internal static List<Guid> ArchivedWebs;
    }
}