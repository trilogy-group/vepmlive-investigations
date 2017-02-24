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
        static void Main(string[] args)
        {
            try
            {
                var options = new Options();

                if (!CommandLine.Parser.Default.ParseArguments(args, options)) return;

                if (!File.Exists(options.InputFile))
                {
                    WriteToConsole($"ERROR! Could not find file: {options.InputFile}.\nEnsure that file is inside same folder of this executable or you provided full path.", MessageType.Error);
                    return;
                }

                WriteToConsole("Reading xlsx file...");
                var xlsxFile = new FileInfo(options.InputFile);

                using (var package = new ExcelPackage(xlsxFile))
                {
                    var worksheet = package.Workbook.Worksheets["Product"];
                    var dtb = WorksheetToDataTable(worksheet);

                    if (dtb.Rows.Count > 0)
                    {
                        var skuID = GetColumnIndex(dtb.Rows[0], "SKU", dtb.Columns.Count);
                        var productNameID = GetColumnIndex(dtb.Rows[0], "PRODUCT NAME", dtb.Columns.Count);

                        if (skuID != -1 && productNameID != -1)
                        {
                            WriteToConsole("Updating database...");
                            UpdatedDb(dtb, skuID, productNameID, options.LicenseScript);
                            WriteToConsole("SUCESS!", MessageType.Sucess);
                        }
                        else
                            WriteToConsole("ERROR! Could not find columns named as 'Sku' and 'Product Name' in xlsx file, 'Product' sheet.", MessageType.Error);
                    }
                    else
                        WriteToConsole("ERROR! Could not find lines in 'Product' sheet from xlsx file.");
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
                case MessageType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        private const string _SkuEPMLiveOnline = "SKU-00000020";
        private const string _LicenseScriptPath = "Scripts/LicenseScript.sql";

        private static void UpdatedDb(DataTable dtb, int skuId, int productNameId, string licenseScriptPath)
        {
            using (var scope = new TransactionScope())
            {
                using (var cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString()))
                {
                    cn.Open();

                    var cmdText = string.Empty;
                    for (var i = 1; i < dtb.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dtb.Rows[i][skuId]?.ToString())) continue;

                        var active = dtb.Rows[i][productNameId]?.ToString().Trim().ToUpper() == "EPM LIVE ONLINE"
                            ? 1
                            : 0;
                        cmdText += $"IF EXISTS (SELECT * FROM [LICENSEPRODUCTS] WHERE sku='{dtb.Rows[i][skuId]}') UPDATE [LICENSEPRODUCTS] SET name='{dtb.Rows[i][productNameId]}', active=1 where sku='{dtb.Rows[i][skuId]}'; ELSE INSERT [dbo].[LICENSEPRODUCTS] ([sku], [name], [active]) VALUES (N'{dtb.Rows[i][skuId]}', N'{dtb.Rows[i][productNameId]}', {active}); ";
                    }

                    var cmd = new SqlCommand(cmdText, cn) {CommandType = CommandType.Text};
                    cmd.ExecuteNonQuery();

                    // will permite to throw exception case there are more than 1 'EPM Live Online' product.
                    cmdText =
                        $"UPDATE [ORDERS] SET product_id=(SELECT product_id FROM [LICENSEPRODUCTS] WHERE sku='{_SkuEPMLiveOnline}') WHERE product_id IS NULL;";
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
            [Option('f', "file", Required = true,
              HelpText = "Path to the Input file to be processed.")]
            public string InputFile { get; set; }

            [Option('l', "licensescript", Required = false,
              HelpText = "Path to the license script.")]
            public string LicenseScript { get; set; }

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

        private enum MessageType
        {
            Sucess = 1,
            Error = -1,
            Default = 0
        }
    }
}
