using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;
using OfficeOpenXml.Drawing;

using System.Diagnostics;
using System.Data.SqlClient;
using System.Transactions;

namespace LoadZuoraProducts
{
    class Program
    {
        private const string _LicenseScriptPath = "Scripts/LicenseScript.sql";
        static void Main(string[] args)
        {
            try
            {
                var options = new Options();

                if (!CommandLine.Parser.Default.ParseArguments(args, options)) return;

                if (!ValidateInputFilesPath(options.ExportFile, options.LicenseScript)) return;
                
                WriteToConsole("Reading xlsx file...");

                var xlsxFile = new FileInfo(options.ExportFile);
                using (var package = new ExcelPackage(xlsxFile))
                {
                    var excelValues = GetExcelValues(package);
                    
                    WriteToConsole("Updating database...");
                    UpdatedDb(excelValues.ValuesList, excelValues.SKUIndex, excelValues.ProducNameIndex, options.LicenseScript, CreateConnString(options));
                    WriteToConsole("SUCESS!", MessageType.Sucess);
                }
            }
            catch (Exception exc)
            {
                WriteToConsole($"ERROR! {exc.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static ExcelProperties GetExcelValues(ExcelPackage package)
        {
            if (package.Workbook.Worksheets["Product"] == null)
                throw new Exception($"ERROR! Could not find a sheet named as 'Product' in excel file provided.");

            var worksheet = package.Workbook.Worksheets["Product"];
            var dtb = WorksheetToDataTable(worksheet);

            if (dtb.Rows.Count == 0)
                throw new Exception("ERROR! Could not find lines in 'Product' sheet from xlsx file.");

            var skuId = GetColumnIndex(dtb.Rows[0], "SKU", dtb.Columns.Count);
            var productNameId = GetColumnIndex(dtb.Rows[0], "PRODUCT NAME", dtb.Columns.Count);

            if (skuId == -1)
                throw  new Exception("ERROR! Could not find columns named as 'Sku' in xlsx file, 'Product' sheet.");

            if (productNameId == -1)
                throw new Exception("ERROR! Could not find columns named as 'Product Name' in xlsx file, 'Product' sheet.");

            return new ExcelProperties()
            {
                ProducNameIndex = productNameId,
                SKUIndex = skuId,
                ValuesList = dtb
            };
        }

        private static bool ValidateInputFilesPath(string exportFilePath, string licenseFilePath)
        {
            if (!File.Exists(exportFilePath))
            {
                WriteToConsole($"ERROR! Could not find input product catalog file: {exportFilePath}.\nEnsure that file is inside same folder of this executable or you provided full path.", MessageType.Error);
                return false;
            }

            string fileExtension = Path.GetExtension(exportFilePath)?.ToUpper().Trim();
            if (fileExtension != ".XLSX")
            {
                WriteToConsole($"ERROR! File has '{fileExtension}' as extension but expected 'XLSX'.", MessageType.Error);
                return false;
            }

            licenseFilePath = string.IsNullOrEmpty(licenseFilePath)
                                ? Program._LicenseScriptPath
                                : licenseFilePath;
            if (!File.Exists(licenseFilePath))
            {
                WriteToConsole($"ERROR! Could not find file license script: {licenseFilePath}.\nEnsure that file is inside 'Script' folder or you provided full path.", MessageType.Error);
                return false;
            }

            return true;
        }

        private static void WriteToConsole(string message, MessageType type = MessageType.Default)
        {
            Console.ResetColor();

            switch (type)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.Sucess:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        private static void UpdatedDb(DataTable dtb, int skuId, int productNameId, string licenseScriptPath, string connString, string skuEPMLiveOnline = "SKU-00000020")
        {
            using (var scope = new TransactionScope())
            {
                using (var cn = new SqlConnection(connString))
                {
                    cn.Open();

                    var cmdText = string.Empty;
                    for (var i = 1; i < dtb.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dtb.Rows[i][skuId]?.ToString())) continue;

                        var active = dtb.Rows[i][productNameId]?.ToString().Trim().ToUpper() == "EPM LIVE ONLINE"
                            ? 1
                            : 0;
                        cmdText += $"IF EXISTS (SELECT * FROM [LICENSEPRODUCTS] WHERE sku='{dtb.Rows[i][skuId]}') UPDATE [LICENSEPRODUCTS] SET name='{dtb.Rows[i][productNameId]}', active={active} where sku='{dtb.Rows[i][skuId]}'; ELSE INSERT [dbo].[LICENSEPRODUCTS] ([sku], [name], [active]) VALUES (N'{dtb.Rows[i][skuId]}', N'{dtb.Rows[i][productNameId]}', {active}); ";
                    }

                    var cmd = new SqlCommand(cmdText, cn) {CommandType = CommandType.Text};
                    cmd.ExecuteNonQuery();

                    // will permite to throw exception case there are more than 1 'EPM Live Online' product.
                    cmdText =
                        $"UPDATE [ORDERS] SET product_id=(SELECT product_id FROM [LICENSEPRODUCTS] WHERE sku='{skuEPMLiveOnline}') WHERE product_id IS NULL;";
                    cmd = new SqlCommand(cmdText, cn) {CommandType = CommandType.Text};
                    cmd.ExecuteNonQuery();

                    cmdText =
                        File.ReadAllText(string.IsNullOrEmpty(licenseScriptPath)
                            ? Program._LicenseScriptPath
                            : licenseScriptPath);
                    cmd = new SqlCommand(cmdText, cn) {CommandType = CommandType.Text};
                    cmd.ExecuteNonQuery();
                }

                scope.Complete();
            }
        }

        private static string CreateConnString(Options opt)
        {
            return $"server={opt.Server};database={opt.Database};User ID={opt.User};Password={opt.Password}";
        }

        private static int GetColumnIndex(DataRow row, string columnName, int columnsCount)
        {
            for (var i = 0; i < columnsCount; i++)
            {
                if (row[i]?.ToString().ToUpper().Trim() == columnName)
                    return i;
            }

            return -1;
        }

        private static DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
        {
            var totalRows = oSheet.Dimension.End.Row;
            var totalCols = oSheet.Dimension.End.Column;
            var dt = new DataTable(oSheet.Name);
            DataRow dr = null;
            for (var i = 1; i <= totalRows; i++)
            {
                if (i > 0) dr = dt.Rows.Add();
                for (var j = 1; j <= totalCols; j++)
                {
                    if (i == 1)
                        dt.Columns.Add(oSheet.Cells[i, j].Value?.ToString());
                    
                    if (dr != null) dr[j - 1] = oSheet.Cells[i, j].Value?.ToString();
                }
            }
            return dt;
        }
        private class Options
        {
            [Option('e', "exportFile", Required = true,
              HelpText = "Path to product catalog exported file.")]
            public string ExportFile { get; set; }

            [Option('l', "licensescript", Required = false,
              HelpText = "Path to the license script.")]
            public string LicenseScript { get; set; }

            [Option('s', "server", Required = true,
              HelpText = "Database server name.")]
            public string Server { get; set; }

            [Option('d', "database", Required = true,
              HelpText = "Database name.")]
            public string Database { get; set; }

            [Option('u', "user", Required = true,
              HelpText = "Database username.")]
            public string User { get; set; }

            [Option('p', "password", Required = true,
              HelpText = "Database password. WARNING: the password should be passed inside \"quotations marks\". Example: -p \"abc1234!@#\"")]
            public string Password { get; set; }

            [Option('v', "verbose", DefaultValue = true,
              HelpText = "Prints all messages to standard output.")]
            public bool Verbose { get; set; }

            [ParserState]
            public IParserState LastParserState { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this,
                  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }

        private class ExcelProperties
        {
            public int SKUIndex;
            public int ProducNameIndex;
            public DataTable ValuesList;
        }

        private enum MessageType
        {
            Sucess = 1,
            Error = -1,
            Default = 0
        }
    }
}
