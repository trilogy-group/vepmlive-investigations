/*
* It was Canada's idea: http://www.codeproject.com/Articles/2670/Accessing-alternative-data-streams-of-files-on-an
*/

using System;
using System.Globalization;
using System.IO;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Utilities.NTFSStreams
{
    public static class DirectoryInfoExtensions
    {
        private const string ZoneIdentifierStreamName = "Zone.Identifier";

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static void Unblock(this DirectoryInfo directory)
        {
            directory.Unblock(false);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static void Unblock(this DirectoryInfo directory, bool isRecursive)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(Exceptions.FileIsNull);
            }

            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, "The specified directory '{0}' cannot be found.", directory.FullName));
            }

            if (directory.AlternateDataStreamExists(ZoneIdentifierStreamName))
            {
                directory.DeleteAlternateDataStream(ZoneIdentifierStreamName);
            }

            if (!isRecursive)
            {
                return;
            }

            foreach (DirectoryInfo item in directory.GetDirectories())
            {
                item.Unblock(true);
            }

            foreach (FileInfo item in directory.GetFiles())
            {
                item.Unblock();
            }
        }
    }
}
