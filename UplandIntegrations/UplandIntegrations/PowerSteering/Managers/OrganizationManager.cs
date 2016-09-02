using System.Collections.Generic;
using System.Data;
using RestSharp;
using UplandIntegrations.PowerSteering.Entities;
using UplandIntegrations.PowerSteering.Infrastructure;

namespace UplandIntegrations.PowerSteering.Managers
{
    internal class OrganizationManager : ObjectManager
    {
        #region Constructors (1) 

        public OrganizationManager(RestClient client) : base(client, "/organizationservice/v1", "upland/organization") { }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override Dictionary<string, string> MappedColumns
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"owner", "Owner"},
                    {"clientType", "AccountType"},
                    {"stateProvince", "State"}
                };
            }
        }

        protected override void BuildObjects(DataTable items, List<string> columns, List<Entity> newEntities,
            List<Entity> existingEntities)
        {
            foreach (DataRow row in items.Rows)
            {
                string id = row["ID"].ToString();

                Entity o = FindById(id, "organization") ?? new Entity("Organization");

                FillObjects(columns, newEntities, existingEntities, o, row);
            }
        }

        #endregion
    }
}