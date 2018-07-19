using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace EPMLiveCore.SPUtilities
{
    public class SPProjectUtility
    {
        public ProjectInfoResult RequestProjectInfo()
        {
            var result = new ProjectInfoResult();

            string login = SPContext.Current.Web.CurrentUser.LoginName;
            string url = SPContext.Current.Web.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite mysite = new SPSite(url))
                {
                    using (SPWeb myweb = mysite.OpenWeb())
                    {
                        myweb.Site.CatchAccessDeniedException = false;
                        try
                        {
                            if (!myweb.DoesUserHavePermissions(login, SPBasePermissions.ManageSubwebs))
                            {
                                result.StatusCode = HttpStatusCode.Forbidden;
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                            result.StatusCode = HttpStatusCode.Forbidden;
                            return;
                        }

                        result.ServerRelativeUrl = myweb.ServerRelativeUrl;
                        result.BaseUrl = myweb.Url + "/";

                        var lockweb = CoreFunctions.getLockedWeb(myweb);
                        if (lockweb != Guid.Empty)
                        {
                            using (SPWeb web = myweb.Site.AllWebs[lockweb])
                            {
                                result.ValidTemplates = ReadConfigTemplates(web);
                                result.IsNavigationEnabled = ReadConfigNavigationFlag(web);
                                result.IsUnique = ReadConfigUniqueFlag(web);
                                result.IsWorkspaceExisting = ReadConfigWorkspaceFlag(web);
                            }
                        }

                        result.PopulatedTemplates = PopulateTemplates(myweb, result.ValidTemplates);
                    }
                }
            });

            return result;
        }

        public WorkspaceInfoResult RequestWorkspaceInfo(Guid listId, int listItemId)
        {
            var result = new WorkspaceInfoResult();

            string login = SPContext.Current.Web.CurrentUser.LoginName;
            string url = SPContext.Current.Web.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite mysite = new SPSite(url))
                {
                    using (SPWeb myweb = mysite.OpenWeb())
                    {
                        var list = myweb.Lists[listId];
                        var gSettings = new GridGanttSettings(list);

                        try
                        {
                            string[] tRollupLists = gSettings.RollupLists.Split(',');
                            result.ListName = tRollupLists[0].Split('|')[0];
                        }
                        catch (Exception ex)
                        {
                            WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                        }

                        result.WorkspaceName = string.Empty;

                        var li = list.GetItemById(listItemId);
                        result.WorkspaceName = li.Title;
                    }
                }
            });

            return result;
        }

        private bool? ReadConfigWorkspaceFlag(SPWeb web)
        {
            bool? result;

            var wsType = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectWorkspaceType");
            switch (wsType)
            {
                case "New":
                    result = false;
                    break;
                case "Existing":
                    result = true;
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        private bool? ReadConfigUniqueFlag(SPWeb web)
        {
            bool? result;

            var perms = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectPermissions");
            switch (perms)
            {
                case "Unique":
                    result = true;
                    break;
                case "Same":
                    result = false;
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        private bool? ReadConfigNavigationFlag(SPWeb web)
        {
            bool result;

            var nav = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectNavigation");
            if (!bool.TryParse(nav, out result))
            {
                return null;
            }

            return result;
        }

        private IList<string> ReadConfigTemplates(SPWeb web)
        {
            var result = new List<string>();

            var sTemplates = CoreFunctions.getConfigSetting(web, "EPMLiveValidTemplates");
            if (sTemplates != "")
            {
                string[] ssTemplates = sTemplates.Split('|');
                foreach (string sTemplate in ssTemplates)
                {
                    result.Add(sTemplate);
                }
            }

            return result;
        }

        private SortedList PopulateTemplates(SPWeb site, IList<string> validTemplates)
        {
            var result = new SortedList();

            string version = GetWebMajorVersion(site);
            foreach (SPWebTemplate template in site.GetAvailableWebTemplates(site.Language))
            {
                if (!template.IsHidden)
                {
                    if (!template.Title.Contains("EPM Live"))
                    {
                        if (validTemplates.Count == 0)
                        {
                            if (template.IsCustomTemplate && CheckIfValidTemplate(template.Title, version, site))
                            {
                                result.Add(template.Title, template.Name);
                            }
                        }
                        else
                        {
                            if (validTemplates.Contains(template.Title))
                            {
                                result.Add(template.Title, template.Name);
                            }
                        }
                    }
                }
            }

            return result;
        }

        private string GetWebMajorVersion(SPWeb web)
        {
            try
            {
                return web.Properties["TemplateVersion"].Split('.')[0];
            }
            catch(Exception ex)
            {
                WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
            }

            return "1";
        }
        
        private bool CheckIfValidTemplate(string template, string version, SPWeb web)
        {
            switch (version)
            {
                case "2":
                    switch (template)
                    {
                        case "Basic Project Workspace":
                        case "Enterprise Project Management Workgroup":
                            return false;
                        default:
                            break;
                    };
                    break;
                case "1":
                    switch (template)
                    {
                        case "Project Workspace":
                            return false;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return true;
        }

        public class ProjectInfoResult
        {
            public static readonly ProjectInfoResult AccessDenied = new ProjectInfoResult { StatusCode = HttpStatusCode.Forbidden };

            public HttpStatusCode StatusCode = HttpStatusCode.OK;
            public string RedirectUrl;

            public string BaseUrl;
            public string ServerRelativeUrl;
            public bool? IsNavigationEnabled;
            public bool? IsUnique;
            public bool? IsWorkspaceExisting;
            public IList<string> ValidTemplates = new List<string>();
            public SortedList PopulatedTemplates = new SortedList();
        }

        public class WorkspaceInfoResult
        {
            public string ListName;
            public string WorkspaceName;
        }
    }
}
