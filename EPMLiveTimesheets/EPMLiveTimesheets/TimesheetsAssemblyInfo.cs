using System;

namespace TimeSheets
{
    public class TimesheetsAssemblyInfo
    {
        public static string FileVersion()
        {
            var assembly = typeof(TimesheetsAssemblyInfo).Assembly;
            var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.FileVersion.ToString();
        }
    }
}