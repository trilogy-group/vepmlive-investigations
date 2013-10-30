using System.Collections.Generic;
using System.Data;
using RestSharp;
using UplandIntegrations.PowerSteering.Entities;
using UplandIntegrations.PowerSteering.Infrastructure;

namespace UplandIntegrations.PowerSteering.Managers
{
    internal class TaskManager : ObjectManager
    {
        #region Constructors (1) 

        public TaskManager(RestClient client) : base(client, "/taskservice/v1", "upland/task") { }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override Dictionary<string, string> MappedColumns
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"owner", "AssignedTo"},
                    {"scheduledStartDate", "StartDate"},
                    {"scheduledEndDate", "DueDate"}
                };
            }
        }

        protected override void BuildObjects(DataTable items, List<string> columns, List<Entity> newEntities,
            List<Entity> existingEntities)
        {
            foreach (DataRow row in items.Rows)
            {
                string id = row["ID"].ToString();

                Entity o = FindById(id, "task") ?? new Entity("Task");

                FillObjects(columns, newEntities, existingEntities, o, row);

                foreach (var entity in newEntities)
                {
                    entity.Fields.Add("parent", entity.Fields["project"]);
                }

                foreach (var entity in existingEntities)
                {
                    entity.Fields.Add("parent", entity.Fields["project"]);
                }
            }
        }

        #endregion
    }
}