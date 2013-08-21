using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public abstract class NavLinkProvider : INavLinkProvider
    {
        #region Fields (1) 

        protected readonly SPWeb SPWeb;

        #endregion Fields 

        #region Constructors (1) 

        protected NavLinkProvider(SPWeb spWeb)
        {
            SPWeb = spWeb;
        }

        #endregion Constructors 

        #region Implementation of INavLinkProvider

        public abstract IEnumerable<INavObject> GetLinks();

        #endregion
    }
}