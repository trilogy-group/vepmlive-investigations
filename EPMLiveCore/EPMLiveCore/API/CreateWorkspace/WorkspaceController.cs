using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.API
{
    /// <summary>
    /// the client that operates on abstract workspace factories
    /// and exposes functionality
    /// </summary>
    public class WorkspaceController
    {
        private WorkspaceFactory wsFact;
        private string createParams = string.Empty;
        private ICreatedWorkspaceInfo createResults;

        public WorkspaceController(string data)
        {
            Init(data);
        }

        private void Init(string data)
        {
            createParams = data;
            wsFact = GetFactory(data);
        }

        private WorkspaceFactory GetFactory(string data)
        {
            WorkspaceFactory factory = null;
            TemplateSource tType = GetTempType(data);
            switch (tType)
            {
                case TemplateSource.online:
                    factory = new OnlineTempWorkspaceFactory(data);
                    break;
                case TemplateSource.downloaded:
                    factory = new DownloadedTempWorkspaceFactory(data);
                    break;
                default:
                    break;
            }

            return factory;
        }

        private TemplateSource GetTempType(string data)
        {
            TemplateSource t = TemplateSource.online;
            XMLDataManager mgr = new XMLDataManager(data);
            string type = mgr.GetPropVal("TemplateSource");
            if (!string.IsNullOrEmpty(type))
            {
                t = (TemplateSource)Enum.Parse(typeof(TemplateSource), type);
            }
            return t;
        }

        public ICreatedWorkspaceInfo CreateWorkspace()
        {   
            createResults = wsFact.CreateWorkspace();
            return createResults;
        }

    }
}
