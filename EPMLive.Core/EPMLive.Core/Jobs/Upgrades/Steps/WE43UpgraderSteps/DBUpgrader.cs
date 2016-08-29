using System;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 5)]
    public class DBUpgrader : Step
    {
        #region Constructors (1) 

        public DBUpgrader(SPWeb spWeb, string data, int stepNumber, bool bispfe) : base(spWeb, data, stepNumber, bispfe)
        {
        }

        #endregion Constructors 

        #region Methods (2) 

        // Private Methods (2) 

        private void UpgradePFEDatabase()
        {
            string basePath = CoreFunctions.getConfigSetting(SPWeb.Site.RootWeb, "epkbasepath");

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
                LogMessage("\t", setupMsg, 3);
            }
            else
            {
                foreach (string message in setupMsg.Split(new[] {"<br>"}, StringSplitOptions.None))
                {
                    LogMessage("\t", message, 1);
                }
            }
        }

        private void UpgradePFEDB()
        {
            try
            {
                LogMessage("Upgrading PfE database");

                SPSecurity.RunWithElevatedPrivileges(UpgradePFEDatabase);
            }
            catch (Exception e)
            {
                LogMessage("\t", e.Message, 3);
            }
        }

        #endregion Methods 

        #region Overrides of Step

        public override string Description
        {
            get { return "Upgrading the database"; }
        }

        public override bool Perform()
        {
            if (bIsPfe)
            {
                UpgradePFEDB();
            }
            else
            {
                LogMessage("\t", "Not a PfE site.", 2);
            }

            return true;
        }

        #endregion
    }
}