using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.ServiceModel.Channels;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class ProjectManager : ObjectManager
    {
        #region Fields (1) 

        private readonly UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public ProjectManager(Binding binding, string endpointAddress, TenroxAuthService.UserToken token)
            : base(binding, endpointAddress, "projects.svc", token,
                typeof (Project), typeof (UserToken), typeof (ProjectsClient))
        {
            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"},
                {"StartDate", "Start"},
                {"EndDate", "End"},
                {"ClientId", "Account"}
            };

            ObjectId = 2;

            _token = (UserToken) Token;
        }

        #endregion Constructors 

        #region Methods (1) 

        // Protected Methods (1) 

        protected override void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newProjects, List<object> existingProjects)
        {
            var projectsClient = (ProjectsClient) client;

            foreach (DataRow row in items.Rows)
            {
                Project project = null;

                try
                {
                    project = projectsClient.QueryByUniqueId(_token, int.Parse(row["ID"].ToString()));
                }
                catch { }

                if (project == null)
                {
                    try
                    {
                        DateTime now = DateTime.Now;

                        project = projectsClient.CreateNew(_token);
                        project.Id = row["SPID"].ToString();
                        project.AccessType = 0;
                        project.IsBillable = 0;
                        project.IsCapitalized = 0;
                        project.IsCosted = 0;
                        project.IsFunded = 0;
                        project.IsPlaceholder = 0;
                        project.IsRandD = 0;
                        project.ManagerId = -1;
                        project.OverrideBillable = 0;
                        project.ParentId = 3;
                        project.PortfolioId = 2;
                        project.ProjectWorkflowMapId = 112;
                        project.StartDate = now.Date;
                        project.ReleaseAlias = string.Format(@"UPL-INT-{0}-{1:yyMMddHHmmss}", project.Id, now);
                    }
                    catch { }
                }

                if (project == null) continue;

                string email = null;
                try
                {
                    email = row["ManagerId"].ToString().Split(',')[0].Trim();
                }
                catch { }

                if (!string.IsNullOrEmpty(email))
                {
                    row["ManagerId"] = TranslateEmailToUserId(email).ToString(CultureInfo.InvariantCulture);
                }

                FillObjects(columns, newProjects, existingProjects, project, row);
            }
        }

        #endregion Methods 
    }
}