using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Types
    {
        private const string _sharePoint16 = @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.dll";
        private const string _sharePoint16Format = "{0}, Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c";
        private const string _sharePoint15 = @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.dll";
        private const string _sharePoint15Format = "{0}, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c";
        private const string _sharePoint14 = @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\ISAPI\Microsoft.SharePoint.dll";
        private const string _sharePoint14Format = "{0}, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static Type TryGetType(string className, string assembly)
        {
            Type type = null;
            var evidence = AppDomain.CurrentDomain.Evidence;

            if (!string.IsNullOrEmpty(className)
                && !string.IsNullOrEmpty(assembly))
            {
                if (type == null)
                {
                    try
                    {
                        type = Type.GetType(className + ", " + assembly, false, true);
                    }
                    catch
                    {
                        type = null;
                    }
                }

	            if (type == null)
                {
                    try
                    {
                        type = Assembly.Load(assembly, evidence).GetType(className);
                    }
                    catch
                    {
                        type = null;
                    }
                }

                if (type == null)
                {
                    try
                    {
                        var assemblyName = assembly.Substring(0, assembly.IndexOf(",", StringComparison.OrdinalIgnoreCase));
                        var gacPath35 = "C:\\Windows\\Assembly\\GAC_MSIL\\" + assemblyName;
                        var gacPath40 = "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\" + assemblyName;
                        var gacPath = Directory.Exists(gacPath35) ? gacPath35 : Directory.Exists(gacPath40) ? gacPath40 : null;
                        if ((!string.IsNullOrEmpty(gacPath)) && (Directory.Exists(gacPath)))
                        {
                            var directory = new DirectoryInfo(gacPath);
                            if (directory.GetDirectories().Any())
                            {
                                var pathName = directory.GetDirectories()[0].FullName;
                                if (!pathName.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                                    pathName = pathName + "\\";

                                var filePath = new FileInfo(pathName + assemblyName + ".dll").FullName;
                                type = Assembly.Load(filePath, evidence).GetType(className);
                            }
                        }
                    }
                    catch
                    {
                        type = null;
                    }
                }
            }

            return type;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static Type TryGetType(string typeName)
        {
            try
            {
                return Type.GetType(typeName);
            }
            catch
            {
                return null;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom")]
        internal static Type GetSharePointType(string className)
        {
            var assemblyFile = string.Empty;
            var typeName = string.Empty;

            if (File.Exists(_sharePoint16))
            {
                assemblyFile = _sharePoint16;
                typeName = string.Format(CultureInfo.InvariantCulture, _sharePoint16Format, className);
            }
            else if (File.Exists(_sharePoint15))
            {
                assemblyFile = _sharePoint15;
                typeName = string.Format(CultureInfo.InvariantCulture, _sharePoint15Format, className);
            }
            else if (File.Exists(_sharePoint14))
            {
                assemblyFile = _sharePoint14;
                typeName = string.Format(CultureInfo.InvariantCulture, _sharePoint14Format, className);
            }
            else
                return null;

            Type type = null;

            try
            {
                type = Type.GetType(typeName);
            }
            catch
            {
                try
                {
                    type = Assembly.LoadFrom(assemblyFile).GetType(className);
                }
                catch
                {
                    type = null;
                }
            }

            return type;
        }
    }
}
