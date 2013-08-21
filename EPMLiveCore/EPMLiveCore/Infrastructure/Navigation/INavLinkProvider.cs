using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public interface INavLinkProvider
    {
        #region Operations (1) 

        IEnumerable<INavObject> GetLinks();

        #endregion Operations 
    }
}