using System.Collections.Generic;
using Tenrox.Application.SDK;
using UplandIntegrations.Tenrox.Infrastructure;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class ProjectManager : ObjectManager
    {
        #region Constructors (1) 

        public ProjectManager() : base(typeof (Project))
        {
            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"},
                {"StartDate", "Start"},
                {"EndDate", "End"},
            };
        }

        #endregion Constructors 
    }
}