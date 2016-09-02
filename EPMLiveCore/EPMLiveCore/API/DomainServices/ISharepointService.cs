using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public interface ISharepointService
    {
        List<SPFile> GetSharepointFilesFromDocumentLibrary(string documentLibraryName, string fileExtension, string siteUrl);
        string GetOdcFileHtml(SPFile odcFile);
        void AddFileToLibraryAndOverwrite(SPFile file, byte[] bytes);
    }
}