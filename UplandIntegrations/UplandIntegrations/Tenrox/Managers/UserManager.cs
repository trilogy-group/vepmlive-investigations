using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Channels;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class UserManager : ObjectManager
    {
        #region Fields (1) 

        private readonly UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public UserManager(Binding binding, string endpointAddress, TenroxAuthService.UserToken token)
            : base(binding, endpointAddress, "users.svc", token,
                typeof (User), typeof (UserToken), typeof (UsersClient))
        {
            ObjectId = 1;
            _token = (UserToken) Token;
        }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newUsers, List<object> existingUsers)
        {
            var usersClient = (UsersClient) client;

            foreach (DataRow row in items.Rows)
            {
                User u = null;

                try
                {
                    u = usersClient.QueryByUniqueId(_token, int.Parse(row["ID"].ToString()));
                }
                catch { }

                if (u == null)
                {
                    try
                    {
                        u = usersClient.CreateNew(_token);
                        u.LoginName = row["Email"].ToString();
                        u.Id = row["SPID"].ToString();
                    }
                    catch { }
                }

                if (u == null) continue;

                FillObjects(columns, newUsers, existingUsers, u, row);
            }
        }

        #endregion
    }
}