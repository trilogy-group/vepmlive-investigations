using System.IO;
using System.Text;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class ExcelConnectionUpdatorService
    {
        private readonly ExcelConnectionInfo _connectionInfo;
        private readonly ISharepointService _sharepointService;
        private const string ExcelNamespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";

        public ExcelConnectionUpdatorService(ExcelConnectionInfo connectionInfo, ISharepointService sharepointService)
        {
            _connectionInfo = connectionInfo;
            _sharepointService = sharepointService;
        }

        /// <summary>
        /// Opens the ODC files in a document library and replaces the connection information in them.
        /// </summary>
        public void ProcessOdcFiles()
        {
            var odcFiles = _sharepointService.GetSharepointFilesFromDocumentLibrary(_connectionInfo.DataConnectionLibraryName, ".odc", _connectionInfo.SiteUrl);
            if (odcFiles == null) return;

            foreach (var odcFile in odcFiles)
            {
                var odcHtml = _sharepointService.GetOdcFileHtml(odcFile);
                var odcHtmlWithReplacedTokens = GetOdcFileHtmlWithReplacedTokens(odcHtml);

                var htmlAsByteArray = new ASCIIEncoding().GetBytes(odcHtmlWithReplacedTokens);
                _sharepointService.AddFileToLibraryAndOverwrite(odcFile, htmlAsByteArray);
            }
        }

        /// <summary>
        /// Opens the Excel files in a document library and replaces the connection information in them.
        /// </summary>
        public void ProcessExcelFiles()
        {
            var excelFiles = _sharepointService.GetSharepointFilesFromDocumentLibrary(_connectionInfo.ExcelFileLibraryName, ".xls", _connectionInfo.SiteUrl);
            if (excelFiles == null) return;

            foreach (var excelFile in excelFiles)
            {
                var byteArray = excelFile.OpenBinary();
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(byteArray, 0, byteArray.Length);

                    using (var excelDoc = SpreadsheetDocument.Open(memoryStream, true))
                    {
                        UpdateConnectionsInExcelFile(excelDoc);
                    }

                    _sharepointService.AddFileToLibraryAndOverwrite(excelFile, memoryStream.ToArray());
                }
            }
        }

        /// <summary>
        /// Updates the connection information in an excel file.
        /// </summary>
        /// <param name="excelDoc">The excel doc.</param>
        internal void UpdateConnectionsInExcelFile(SpreadsheetDocument excelDoc)
        {
            var nameTable = new NameTable();
            var namespaceManager = new XmlNamespaceManager(nameTable);

            namespaceManager.AddNamespace("sh", ExcelNamespace);
            var xmlDoc = new XmlDocument(nameTable);
            xmlDoc.Load(excelDoc.WorkbookPart.ConnectionsPart.GetStream());

            if (!xmlDoc.InnerXml.Contains(_connectionInfo.ReportDatabaseToken)) return;

            xmlDoc.InnerXml = ReplaceTokens(xmlDoc.InnerXml);

            xmlDoc.Save(excelDoc.WorkbookPart.ConnectionsPart.GetStream());
        }

        internal string GetOdcFileHtmlWithReplacedTokens(string odcFileHtml)
        {
            return ReplaceTokens(odcFileHtml);
        }

        /// <summary>
        /// Replaces the connection tokens in a string containing.
        /// </summary>
        /// <param name="tokenString">The string containing tokens.</param>
        /// <returns>Then string with the tokens replaced with connection values.</returns>
        internal string ReplaceTokens(string tokenString)
        {
            var returnString = tokenString;

            if (!string.IsNullOrEmpty(_connectionInfo.ReportDatabaseToken) && !string.IsNullOrEmpty(_connectionInfo.DataConnectionReportDbName))
            {
                returnString = returnString.Replace(_connectionInfo.ReportDatabaseToken, _connectionInfo.DataConnectionReportDbName);
            }

            if (!string.IsNullOrEmpty(_connectionInfo.ReportServerToken) && !string.IsNullOrEmpty(_connectionInfo.DataConnectionServerName))
            {
                returnString = returnString.Replace(_connectionInfo.ReportServerToken, _connectionInfo.DataConnectionServerName);
            }

            if (!string.IsNullOrEmpty(_connectionInfo.UserNameToken) && !string.IsNullOrEmpty(_connectionInfo.DataConnectionUserName))
            {
                returnString = returnString.Replace(_connectionInfo.UserNameToken, _connectionInfo.DataConnectionUserName);
            }

            if (!string.IsNullOrEmpty(_connectionInfo.PasswordToken) && !string.IsNullOrEmpty(_connectionInfo.DataConnectionUserPassword))
            {
                returnString = returnString.Replace(_connectionInfo.PasswordToken, _connectionInfo.DataConnectionUserPassword);
            }

            if (!string.IsNullOrEmpty(_connectionInfo.SiteUrlToken) && !string.IsNullOrEmpty(_connectionInfo.SiteUrl))
            {
                returnString = returnString.Replace(_connectionInfo.SiteUrlToken, _connectionInfo.SiteUrl);
            }
            
            if (!string.IsNullOrEmpty(_connectionInfo.DataConnectionLibraryToken) && !string.IsNullOrEmpty(_connectionInfo.DataConnectionLibraryName))
            {
                returnString = returnString.Replace(_connectionInfo.DataConnectionLibraryToken, _connectionInfo.DataConnectionLibraryName);
            }

            return returnString;
        }
    }
}
