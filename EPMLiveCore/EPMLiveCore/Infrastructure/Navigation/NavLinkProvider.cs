using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public abstract class NavLinkProvider : INavLinkProvider
    {
        protected readonly SPWeb SPWeb;

        protected NavLinkProvider(SPWeb spWeb)
        {
            SPWeb = spWeb;
        }

        #region Implementation of INavLinkProvider

        public abstract IEnumerable<INavObject> GetLinks();

        #endregion
    }
}