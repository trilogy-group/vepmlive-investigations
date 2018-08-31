using System;
using System.Data;
using System.Web;
using PortfolioEngineCore;
using System.Diagnostics;

namespace WorkEnginePPM.Layouts.ppm
{
    internal static class CustomFieldHelper
    {
        internal static string CreateCustomFieldRequest(
            HttpContext httpContext, 
            string requestContext, 
            CStruct xData, 
            Func<DBAccess, int, string> readCustomFieldInfo,
            Func<HttpContext, CStruct, string> updateCustomFieldInfo,
            Func<HttpContext, CStruct, string> deleteCustomFieldInfo)
        {
            EnsureNotNull(httpContext, nameof(httpContext));
            EnsureNotNull(requestContext, nameof(requestContext));
            EnsureNotNull(xData, nameof(xData));
            EnsureNotNull(readCustomFieldInfo, nameof(readCustomFieldInfo));
            EnsureNotNull(updateCustomFieldInfo, nameof(updateCustomFieldInfo));
            EnsureNotNull(deleteCustomFieldInfo, nameof(deleteCustomFieldInfo));

            var reply = string.Empty;
            int fieldId;
            string baseInfo;
            switch (requestContext)
            {
                case "ReadCustomfieldInfo":
                    fieldId = int.Parse(xData.InnerText);
                    baseInfo = WebAdmin.BuildBaseInfo(httpContext);
                    using (var dataAccess = new DataAccess(baseInfo))
                    {
                        using (var dataBaseAccess = dataAccess.dba)
                        {
                            if (dataBaseAccess.Open() == StatusEnum.rsSuccess)
                            {
                                reply = readCustomFieldInfo(dataBaseAccess, fieldId);
                            }
                        }
                    }
                    break;
                case "ReadLookup":
                    fieldId = int.Parse(xData.InnerText);
                    baseInfo = WebAdmin.BuildBaseInfo(httpContext);
                    using (var dataAccess = new DataAccess(baseInfo))
                    {
                        using (var dataBaseAccess = dataAccess.dba)
                        {
                            if (dataBaseAccess.Open() == StatusEnum.rsSuccess)
                            {
                                reply = ReadLookup(dataBaseAccess, fieldId);
                            }
                        }
                    }
                    break;
                case "UpdateCustomfieldInfo":
                    reply = updateCustomFieldInfo(httpContext, xData);
                    break;
                case "DeleteCustomfieldInfo":
                    reply = deleteCustomFieldInfo(httpContext, xData);
                    break;
                default:
                    Trace.TraceWarning("Unexpected requestContext '{0}'.", requestContext);
                    break;
            }

            return reply;
        }

        internal static void InitializeColumns(_TGrid grid)
        {
            EnsureNotNull(grid, nameof(grid));

            grid.AddColumn(title: "ID", width: 50, name: "LV_UID", isId: true, hidden: true);
            grid.AddColumn(title: "Name", width: 180, name: "LV_VALUE", maincol: true, editable: true);
            grid.AddColumn(title: "Level", width: 180, name: "LV_LEVEL", mainlevelcol: true, hidden: true);
        }

        internal static string ReadLookup(DBAccess dbAccess, int lookupuId)
        {
            EnsureNotNull(dbAccess, nameof(dbAccess));

            var sReply = string.Empty;
            CStruct xCustomfield = null;
            try
            {
                xCustomfield = new CStruct();
                xCustomfield.Initialize("customfield");
                DataTable table;

                dbaGeneral.SelectLookup(dbAccess, lookupuId, out table);

                var grid = new _TGrid();
                InitializeColumns(grid);
                grid.SetDataTable(table);
                var gridData = string.Empty;
                grid.Build(out gridData);
                xCustomfield.CreateString("tgridData", gridData);
            }
            finally
            {
                dbAccess.Close();
            }

            sReply = xCustomfield.XML();
            return sReply;
        }

        private static void EnsureNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
