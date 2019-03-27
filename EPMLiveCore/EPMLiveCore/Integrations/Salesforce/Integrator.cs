using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using EPMLiveCore.SalesforcePartnerService;
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Salesforce
{
    public partial class Integrator
    {
        private static Dictionary<string, string> BuildIdMap(DataTable items, out List<string> ids)
        {
            var idMap = new Dictionary<string, string>();
            ids = new List<string>();

            foreach (DataRow dataRow in items.Rows)
            {
                var idValue = dataRow["ID"];

                if (idValue == null || idValue == DBNull.Value)
                {
                    continue;
                }

                var id = idValue.ToString();
                if (ids.Contains(id))
                {
                    continue;
                }

                ids.Add(id);
                idMap.Add(id, dataRow["SPID"].ToString());
            }

            return idMap;
        }

        private static Type TranslateFieldType(fieldType type)
        {
            switch (type)
            {
                case fieldType.@double:
                case fieldType.percent:
                    return typeof(double);
                case fieldType.@int:
                    return typeof(int);
                case fieldType.boolean:
                    return typeof(bool);
                case fieldType.currency:
                    return typeof(decimal);
                case fieldType.date:
                case fieldType.datetime:
                case fieldType.time:
                    return typeof(DateTime);
                default:
                    return typeof(string);
            }
        }
    }
}