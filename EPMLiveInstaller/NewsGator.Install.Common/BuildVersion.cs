using System;

namespace NewsGator.Install.Common
{
    public static class BuildVersion
    {
#if DEBUG
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static Version Version = new Version("5.3.0.0");
#else
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static Version Version = new Version("@BuildVersion@"); // @BuildVersion@
#endif
    }
}
