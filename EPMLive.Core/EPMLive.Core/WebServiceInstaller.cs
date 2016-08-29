using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using System.IO;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    class WebServicesInstaller : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            //try
            //{
            //    DirectoryInfo myFeature = new DirectoryInfo(properties.Definition.RootDirectory);
            //    DirectoryInfo Hive12 = myFeature.Parent.Parent.Parent;

            //    SPWebServiceDeployer wsd = new SPWebServiceDeployer(properties.Feature.Definition.DisplayName,
            //        Hive12.FullName);
            //    wsd.GenWebService();

            //}
            //catch { }
            SPFarm.Local.Services.GetValue<SPWebService>().ApplyApplicationContentToLocalServer(); 

        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            //DirectoryInfo myFeature = new DirectoryInfo(properties.Definition.RootDirectory);
            //DirectoryInfo Hive12 = myFeature.Parent.Parent.Parent;
            //SPWebServiceDeployer wsd = new SPWebServiceDeployer(properties.Feature.Definition.DisplayName,
            //     Hive12.FullName);
            //wsd.RemoveWebService("EPMLiveTimePhased.asmx");
        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            //The manifest (solution) should install NO FILES. All webservice .asmx files 
            //should be in the FEATURE. This allows the webservice to be brought on/offline as needed.
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            //Not implementing but not throwing an error.
        }
    }
}
