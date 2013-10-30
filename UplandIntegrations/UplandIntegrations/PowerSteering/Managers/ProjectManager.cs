using System.Collections.Generic;
using System.Data;
using RestSharp;
using UplandIntegrations.PowerSteering.Entities;
using UplandIntegrations.PowerSteering.Infrastructure;

namespace UplandIntegrations.PowerSteering.Managers
{
    internal class ProjectManager : ObjectManager
    {
        #region Constructors (1) 

        public ProjectManager(RestClient client) : base(client, "/projectservice/v1", "upland/project") { }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override Dictionary<string, string> MappedColumns
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"owner", "Owner"},
                    {"organization", "Account"},
                    {"scheduledStartDate", "Start"},
                    {"scheduledEndDate", "Finish"}
                };
            }
        }

        protected override void BuildObjects(DataTable items, List<string> columns, List<Entity> newEntities,
            List<Entity> existingEntities)
        {
            foreach (DataRow row in items.Rows)
            {
                string id = row["ID"].ToString();

                Entity o = FindById(id, "project") ?? new Entity("Project");

                FillObjects(columns, newEntities, existingEntities, o, row);
            }
        }

        #endregion
    }
}