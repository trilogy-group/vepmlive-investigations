using System;
using System.Linq;
using EPMLiveCore.SocialEngine.Contracts;
using EPMLiveCore.SocialEngine.Events;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Modules
{
    internal class DataDecorator : ISocialEngineModule
    {
        #region Methods (1) 

        // Private Methods (1) 

        private void OnActivityRegistrationRequest(ProcessActivityEventArgs args)
        {
            SPRegionalSettings regionalSettings = args.ContextWeb.CurrentUser.RegionalSettings ??
                                                  args.ContextWeb.RegionalSettings;

            string[] keys = args.Data.Keys.ToArray();

            foreach (string key in keys)
            {
                object data = args.Data[key];

                if (data == null) return;

                if (data is DateTime)
                {
                    args.Data[key] = regionalSettings.TimeZone.LocalTimeToUTC((DateTime) data);
                }
            }
        }

        #endregion Methods 

        #region Implementation of ISocialEngineModule

        public void Initialize(SocialEngineEvents events)
        {
            events.OnActivityRegistrationRequest += OnActivityRegistrationRequest;
        }

        #endregion
    }
}