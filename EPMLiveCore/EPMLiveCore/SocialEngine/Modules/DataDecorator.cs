using System;
using System.Threading.Tasks;
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

            Parallel.ForEach(args.Data, data =>
            {
                if (data.Value == null) return;

                if (data.Value is DateTime)
                {
                    args.Data[data.Key] = regionalSettings.TimeZone.LocalTimeToUTC((DateTime) data.Value);
                }
            });
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