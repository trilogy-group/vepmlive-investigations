using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public interface INavLinkProvider
    {
        IEnumerable<INavObject> GetLinks();
    }
}