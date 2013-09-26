using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using EPMLiveIntegration;
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
            : base(binding, endpointAddress, "projects.svc", token, typeof (Project), typeof (UserToken))
        {
            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"},
                {"StartDate", "Start"},
                {"EndDate", "End"},
            };

            _token = (UserToken) Token;
        }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (2) 

        public override IEnumerable<TenroxObject> GetItems(int[] itemIds)
        {
            var tasks = new List<Task<TenroxObject>>();

            using (var projectsClient = new ProjectsClient(Binding, EndpointAddress))
            {
                tasks.AddRange(itemIds.Select(id => Task<TenroxObject>.Factory.StartNew(() =>
                {
                    try
                    {
                        return new TenroxObject(id, projectsClient.QueryByUniqueId(_token, id));
                    }
                    catch (Exception exception)
                    {
                        return new TenroxObject(id, exception);
                    }
                })));

                foreach (var task in tasks)
                {
                    yield return task.Result;
                }
            }
        }

        public override IEnumerable<TenroxUpsertResult> UpsertItems(DataTable items, Guid integrationId)
        {
            using (var projectsClient = new ProjectsClient(Binding, EndpointAddress))
            {
                List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

                var newProjects = new List<Project>();
                var existingProjects = new List<Project>();

                BuildProjects(items, projectsClient, columns, existingProjects, newProjects);

                var tasks = new List<Task<TenroxUpsertResult>>();

                tasks.AddRange(newProjects.Select(proj => Task<TenroxUpsertResult>.Factory.StartNew(() =>
                {
                    try
                    {
                        Project p = projectsClient.Save(_token, proj);
                        UpdateBinding(p.UniqueId, 2, integrationId);

                        return new TenroxUpsertResult(p.UniqueId, TransactionType.INSERT);
                    }
                    catch (Exception exception)
                    {
                        return new TenroxUpsertResult(proj.UniqueId, TransactionType.INSERT, exception.Message);
                    }
                })));

                tasks.AddRange(existingProjects.Select(proj => Task<TenroxUpsertResult>.Factory.StartNew(() =>
                {
                    try
                    {
                        Project p = projectsClient.Save(_token, proj);
                        return new TenroxUpsertResult(p.UniqueId, TransactionType.UPDATE);
                    }
                    catch (Exception exception)
                    {
                        return new TenroxUpsertResult(proj.UniqueId, TransactionType.UPDATE, exception.Message);
                    }
                })));

                foreach (var task in tasks)
                {
                    yield return task.Result;
                }
            }
        }

        // Private Methods (1) 

        private void BuildProjects(DataTable items, ProjectsClient projectsClient, List<string> columns,
            List<Project> existingProjects,
            List<Project> newProjects)
        {
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

                Type type = project.GetType();

                foreach (
                    string column in
                        from column in columns
                        let col = column.ToLower()
                        where !col.Equals("id") && !col.Equals("spid")
                        select column)
                {
                    try
                    {
                        PropertyInfo property = type.GetProperty(column);
                        property.SetValue(project, GetValue(row[column], property));
                    }
                    catch { }
                }


                if (project.UniqueId > 0)
                {
                    existingProjects.Add(project);
                }
                else
                {
                    newProjects.Add(project);
                }
            }
        }

        #endregion Methods 
    }
}