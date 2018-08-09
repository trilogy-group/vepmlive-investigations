using System;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Entities.Installer
{
    [Serializable]
    internal class Prerequisite
    {
        internal string Title { get; set; }
        internal string Name { get; set; }
        internal bool RequiredForInstall { get; set; }
        internal bool RequiredForConsumingFarmInstall { get; set; }
        internal PrerequisiteStatus Status { get; set; }
        internal string StatusDescription { get; set; }
        internal int Order { get; set; }
    }
}
