using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGator.Install.Common.Entities.Installer
{
    [Serializable]
    internal class SocialSitesWSPAssemblyVersion
    {
        internal string SolutionName { get; set; }
        internal Dictionary<string, Version> Assemblies { get; set; }
        internal bool IsCanadaModule { get; set; }
    }
}
