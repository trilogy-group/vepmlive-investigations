using EPMLiveCore.API;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs
{
    public class CreateWorkspaceJob : BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            WorkspaceController wsCon = new WorkspaceController(data);
            wsCon.CreateWorkspace();
        }
    }
}
