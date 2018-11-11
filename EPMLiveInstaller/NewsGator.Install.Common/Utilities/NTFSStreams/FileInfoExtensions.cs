/*
* It was Canada's idea: http://www.codeproject.com/Articles/2670/Accessing-alternative-data-streams-of-files-on-an
*/

using System;
using System.IO;

namespace NewsGator.Install.Common.Utilities.NTFSStreams
{
    public static class FileInfoExtensions
    {
        private const string ZoneIdentifierStreamName = "Zone.Identifier";

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static bool IsBlocked(this FileSystemInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }

            if (!file.Exists)
            {
                throw new FileNotFoundException("Unable to find the specified file.", file.FullName);
            }

            return file.Exists && file.AlternateDataStreamExists(ZoneIdentifierStreamName);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static void Unblock(this FileSystemInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }

            if (!file.Exists)
            {
                throw new FileNotFoundException("Unable to find the specified file.", file.FullName);
            }

            if (file.Exists && file.AlternateDataStreamExists(ZoneIdentifierStreamName))
            {
                file.DeleteAlternateDataStream(ZoneIdentifierStreamName);
            }
        }
    }
}
