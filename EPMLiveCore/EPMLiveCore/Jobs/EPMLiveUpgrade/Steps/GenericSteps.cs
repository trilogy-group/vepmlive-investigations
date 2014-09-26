using System;
using System.Reflection;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.GENERIC, Order = 1.0, Description = "Upgrading PFE DB")]
    internal class UpgradePfeDb : UpgradeStep
    {
        #region Constructors (1) 

        public UpgradePfeDb(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        #endregion Constructors 

        #region Methods (2) 

        // Public Methods (1) 

        public override bool Perform()
        {
            try
            {
                if (IsPfeSite)
                {
                    LogTitle(GetWebInfo(Web), 1);
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
                else
                {
                    LogMessage("This is not a PFE site.", MessageKind.FAILURE, 2);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
            }

            return true;
        }

        // Private Methods (1) 

        private void UpgradePfeDatabase()
        {
            string basePath = CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epkbasepath");

            Assembly assembly =
                Assembly.Load("PortfolioEngineCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            Type type = assembly.GetType("PortfolioEngineCore.Setup.SetupSite", true, true);
            MethodInfo methodInfo = type.GetMethod("UpgradeDB");
            object instance = Activator.CreateInstance(type);
            methodInfo.Invoke(instance, new object[] {basePath});

            bool setupErrors = false;
            string setupMessage = string.Empty;

            foreach (PropertyInfo propertyInfo in instance.GetType().GetProperties())
            {
                if (propertyInfo.Name.Equals("SetupErrors"))
                {
                    setupErrors = (bool) propertyInfo.GetValue(instance, null);
                }
                else if (propertyInfo.Name.Equals("SetupMessage"))
                {
                    setupMessage = propertyInfo.GetValue(instance, null) as string;
                }
            }

            string setupMsg = SPHttpUtility.HtmlDecode(setupMessage);

            if (setupErrors)
            {
                LogMessage(setupMsg, MessageKind.FAILURE, 2);
            }
            else
            {
                setupMsg = setupMsg.Replace("<br><br>", "<br>");
                foreach (string message in setupMsg.Split(new[] {"<br>"}, StringSplitOptions.None))
                {
                    LogMessage(message, 2);
                }
            }
        }

        #endregion Methods 
    }
}