using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveWebParts
{
    public class SharepointService : ISharepointService
    {
        /// <summary>
        /// Gets a collection of Sharepoint files in a particular list of the desired file extension.
        /// </summary>
        /// <param name="documentLibraryName">Name of the list to pull the files from.</param>
        /// <param name="fileExtension">The file extension of the desired files.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <returns>A list of SPFile objects from the specified document library.</returns>
        public List<SPFile> GetSharepointFilesFromDocumentLibrary(string documentLibraryName, string fileExtension, string siteUrl)
        {
            var filesToReturn = new List<SPFile>();
            
            using(var siteCollection = new SPSite(siteUrl))
            {
                var rootWeb = siteCollection.RootWeb;
                SPFolder documentLibaryFolder;
                try
                {
                    documentLibaryFolder = rootWeb.Folders[siteUrl + "/" + documentLibraryName];
                }
                catch (Exception)
                {
                    return null;
                }

                var files = documentLibaryFolder.Files;

                if (files.Count < 1) return null;

                filesToReturn = (from SPFile file in files
                                     where file.Name.Contains(fileExtension)
                                     select file).ToList();
            }

            return filesToReturn;
        }

        /// <summary>
        /// Gets the HTML from an ODC file.
        /// </summary>
        /// <param name="odcFile">The odc file.</param>
        /// <returns>The HTML from inside the ODC file.</returns>
        public string GetOdcFileHtml(SPFile odcFile)
        {
            var byteArray = odcFile.OpenBinary();
            var encoding = new ASCIIEncoding();
            var odcHtml = encoding.GetString(byteArray);

            return odcHtml;
        }

        /// <summary>
        /// Adds a file to a SharePoint library and overwrites if it already exists.
        /// </summary>
        /// <param name="file">The file to obtain path information from.</param>
        /// <param name="bytes">The bytes to write to a file in the document library.</param>
        public void AddFileToLibraryAndOverwrite(SPFile file, byte[] bytes)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
                                                     {
                                                        using (var es = new SPSite(SPContext.Current.Site.Url))
                                                        {
                                                            using (var ew = es.OpenWeb())
                                                            {
                                                                es.AllowUnsafeUpdates = true;
                                                                ew.AllowUnsafeUpdates = true;
                                                                es.RootWeb.AllowUnsafeUpdates = true;
                                                                ew.Update();
                                                                var f = ew.GetFile(file.UniqueId);
                                                                var linkFilename = f.Item["LinkFilename"] as string;
                                                                f.ParentFolder.Files.Add(linkFilename, bytes, true);
                                                            }
                                                        }
                                                     });
        }
    }
}