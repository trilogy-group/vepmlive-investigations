using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class AppNavFixUp : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            try
            {
                SPWeb web = (SPWeb)properties.Feature.Parent;

                API.Applications.GenerateQuickLaunchFromApp(web);
            }
            catch { }
        }
    }
}
