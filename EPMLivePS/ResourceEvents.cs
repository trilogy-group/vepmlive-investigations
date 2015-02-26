using System;
using System.Collections.Generic;
using System.Text;

namespace EPMLiveEnterprise
{
    public class ResourceEvents : Microsoft.Office.Project.Server.Events.ResourceEventReceiver
    {
        public override void OnCreated(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ResourceCreatePostEventArgs e)
        {
            ResourceSyncher rSynch = new ResourceSyncher(contextInfo.SiteGuid);
            foreach (Guid g in e.CreatedResources)
            {
                rSynch.synchResource(g);
            }
            rSynch.end();
        }

        public override void OnChanged(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ResourceUpdatePostEventArgs e)
        {
            ResourceSyncher rSynch = new ResourceSyncher(contextInfo.SiteGuid);
            foreach (Guid g in e.UpdatedResources)
            {
                rSynch.synchResource(g);
            }
            rSynch.end();
        }

        public override void OnDeleting(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ResourceDeletePreEventArgs e)
        {
            ResourceSyncher rSynch = new ResourceSyncher(contextInfo.SiteGuid);
            foreach (Guid g in e.DeletedResources)
            {
                rSynch.deleteResource(g);
            }
            rSynch.end();
        }
    }
}
