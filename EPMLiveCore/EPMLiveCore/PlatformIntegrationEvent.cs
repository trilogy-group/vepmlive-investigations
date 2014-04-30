using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class PlatformIntegrationEvent : SPItemEventReceiver
    {
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            base.ItemDeleting(properties);
        }


    }
}
