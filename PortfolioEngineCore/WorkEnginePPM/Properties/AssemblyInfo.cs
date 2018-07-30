using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System;
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("WorkEnginePPM")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("WorkEnginePPM")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("51caf42a-31af-4b74-853f-24b672c185c2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: InternalsVisibleTo("WorkEnginePPM.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b3a27f0bcd65bc516322a2bf7151e4670e28620ea568e56b671de8a8b43de3b3d2844ff7b2ff3b0f38f8381dfa7b64873c65f18b80194a80041e81dcaa44b3c2a7ad0823b691f66dc9fdbb957b683b1e4111c019ff17299ed698d1d14cb6e68e9aaaefed1f17e380a33f841772a350e5f38986654274befcf5ab26ffefd435ec")]

namespace PPM
{
    public class PfEAssemblyInfo
    {
        public static string FileVersion()
        {
            Type clsType = typeof(PfEAssemblyInfo);
            Assembly assy = clsType.Assembly;
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assy.Location);
            return fvi.FileVersion.ToString();
        }
    }
}
