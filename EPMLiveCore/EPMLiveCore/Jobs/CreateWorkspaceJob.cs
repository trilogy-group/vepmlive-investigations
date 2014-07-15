using System;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs
{
    public class CreateWorkspaceJob : BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            try
            {
                var wsCon = new WorkspaceController(data);
                wsCon.CreateWorkspace();
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors = "General Error: " + ex.Message;
            }
        }
    }
}