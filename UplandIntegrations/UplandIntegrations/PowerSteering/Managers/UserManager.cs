using System.Collections.Generic;
using System.Data;
using RestSharp;
using UplandIntegrations.PowerSteering.Entities;
using UplandIntegrations.PowerSteering.Infrastructure;

namespace UplandIntegrations.PowerSteering.Managers
{
    internal class UserManager : ObjectManager
    {
        #region Constructors (1) 

        public UserManager(RestClient client) : base(client, "/userservice/v1", "upland/user") { }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override Dictionary<string, string> MappedColumns
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"firstName", "FirstName"},
                    {"lastName", "LastName"},
                    {"emailAddress", "Email"}
                };
            }
        }

        protected override void BuildObjects(DataTable items, List<string> columns, List<Entity> newEntities,
            List<Entity> existingEntities)
        {
            foreach (DataRow row in items.Rows)
            {
                string id = row["ID"].ToString();

                Entity o = FindById(id, "user") ?? new Entity("User");

                FillObjects(columns, newEntities, existingEntities, o, row);
            }
        }

        #endregion
    }
}