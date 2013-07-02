using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;
using Formula = DocumentFormat.OpenXml.Office.Excel.Formula;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;

namespace EPMLiveCore.API
{
    internal class ResourceExporter
    {
        #region Fields (8) 

        private const string FORMAT_CODE = "_(\"$\"* #,##0.00_);_(\"$\"* \\(#,##0.00\\);_(\"$\"* \"-\"??_);_(@_)";
        private const string MC_SCHEMA = "http://schemas.openxmlformats.org/markup-compatibility/2006";
        private const string R_SCHEMA = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
        private const string X14_AC_SCHEMA = "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac";
        private const string X14_SCHEMA = "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main";
        private const string XM_SCHEMA = "http://schemas.microsoft.com/office/excel/2006/main";
        private readonly SPWeb _spWeb;
        private IEnumerable<string> _permissions;

        #endregion Fields 

        #region Constructors (1) 

        public ResourceExporter(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (21) 

        // Public Methods (1) 

        public bool Export(out string file, out string message)
        {
            file = string.Empty;
            message = string.Empty;

            try
            {
                SPList resourcePool = _spWeb.Lists["Resources"];

                ValidateAccess();

                Dictionary<string, object[]> fieldDictionary = BuildFieldDictionary(resourcePool);
                DataTable dataTable = GetResources(resourcePool);

                using (MemoryStream memoryStream = CreateSpreadsheet(fieldDictionary, dataTable))
                {
                    using (var epmLiveFileStore = new EPMLiveFileStore(_spWeb))
                    {
                        file = epmLiveFileStore.Add(memoryStream.ToArray());
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return false;
            }
        }

        // Private Methods (20) 

        private void AddVbaCode(WorkbookPart workbookPart)
        {
            var vbaProjectPart = workbookPart.AddNewPart<VbaProjectPart>("rId104");
            using (Stream data = GetBinaryDataStream(Resources.ResourceExporterVBA))
            {
                vbaProjectPart.FeedData(data);
            }
        }

        private Dictionary<string, object[]> BuildFieldDictionary(SPList resourcePool)
        {
            var fieldDictionary = new Dictionary<string, object[]>();

            SPFieldCollection spFieldCollection = resourcePool.Fields;
            foreach (SPField spField in from SPField spField in spFieldCollection
                let name = spField.InternalName
                where
                    !name.Equals("ContentType") && !name.Equals("Attachments") &&
                    !name.Equals("TempRole") && !name.Equals("TempDept") &&
                    !name.Equals("Approved") && !name.Equals("EXTID")
                where name.Equals("ID") || (!spField.Hidden && !spField.ReadOnlyField)
                where !fieldDictionary.ContainsKey(name)
                select spField)
            {
                fieldDictionary.Add(spField.InternalName, GetFieldInfo(spField));
            }

            Dictionary<string, object[]> dictionary = new[]
            {
                "ID", "Generic", "Title", "FirstName", "LastName",
                "SharePointAccount", "Email",
                "Permissions", "ResourceLevel", "TimesheetManager",
                "TimesheetDelegates",
                "TimesheetAdministrator", "StandardRate", "Disabled",
                "AvailableFrom",
                "AvailableTo", "HolidaySchedule", "WorkHours", "Role",
                "Department"
            }.Where(fieldDictionary.ContainsKey)
                .ToDictionary(col => col, col => fieldDictionary[col]);

            foreach (var p in fieldDictionary.Where(p => !dictionary.ContainsKey(p.Key)))
            {
                dictionary.Add(p.Key, p.Value);
            }

            return dictionary;
        }

        private Dictionary<string, int> BuildSharedString(Dictionary<string, object[]> fieldDictionary,
            DataTable dataTable)
        {
            var sharedString = new List<string>();

            foreach (var pair in fieldDictionary)
            {
                sharedString.Add(pair.Key);
                sharedString.Add((string) pair.Value[0]);
            }

            sharedString.AddRange(from DataRow dataRow in dataTable.Rows
                from pair in fieldDictionary
                select dataRow[pair.Key].ToString());

            sharedString.AddRange(from pair in fieldDictionary
                where pair.Value[2] != null
                from oLookup in (List<string>) pair.Value[2]
                select oLookup.Split('|')[1]);

            if (fieldDictionary.Any(pair => pair.Key.Equals("Permissions")))
            {
                List<string> s = sharedString;

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var site = new SPSite(_spWeb.Site.ID))
                    {
                        using (SPWeb web = site.OpenWeb(_spWeb.ID))
                        {
                            s.AddRange(_permissions);
                        }
                    }
                });
            }

            sharedString.Add(true.ToString());
            sharedString.Add(false.ToString());

            sharedString = sharedString.Distinct().ToList();

            var sharedStringIndices = new Dictionary<string, int>();

            for (int i = 0; i < sharedString.Count; i++)
            {
                sharedStringIndices.Add(sharedString[i], i);
            }

            return sharedStringIndices;
        }

        private void CreateBValuesWorksheet(WorkbookPart workbookPart)
        {
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>("rId2");

            var worksheet = new Worksheet {MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}};
            worksheet.AddNamespaceDeclaration("r", R_SCHEMA);
            worksheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
            worksheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

            var sheetProperties = new SheetProperties {CodeName = "Sheet2"};
            var sheetDimension = new SheetDimension {Reference = "A1:A2"};

            var sheetData =
                new SheetData(
                    new Row(new Cell(new CellValue {Text = "1"}) {CellReference = "A1", DataType = CellValues.Boolean})
                    {
                        RowIndex = 1U
                    },
                    new Row(new Cell(new CellValue {Text = "0"}) {CellReference = "A2", DataType = CellValues.Boolean})
                    {
                        RowIndex = 2U
                    });

            worksheet.Append(sheetProperties, sheetDimension, sheetData);

            worksheetPart.Worksheet = worksheet;
        }

        private void CreateDisplayNameWorksheet(WorkbookPart workbookPart, int lookupCounter)
        {
            string rId = "rId" + lookupCounter;

            workbookPart.Workbook.Sheets.AppendChild(new Sheet
            {
                Name = "DNValues",
                SheetId = (UInt32Value) (lookupCounter + (0U)),
                Id = rId,
                State = SheetStateValues.Hidden
            });

            var dnWorksheetPart = workbookPart.AddNewPart<WorksheetPart>(rId);

            var dnWorksheet = new Worksheet
            {
                MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}
            };

            dnWorksheet.AddNamespaceDeclaration("r", R_SCHEMA);
            dnWorksheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
            dnWorksheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

            var dnSheetProperties = new SheetProperties {CodeName = "Sheet" + lookupCounter};
            var dnSheetDimension = new SheetDimension {Reference = "A1"};

            dnWorksheet.Append(dnSheetProperties, dnSheetDimension, new SheetData());
            dnWorksheetPart.Worksheet = dnWorksheet;
        }

        private void CreateLookupValueSheets(Dictionary<string, object[]> fieldDictionary, WorkbookPart workbookPart,
            Dictionary<string, int> sharedStringIndices)
        {
            int lookupCounter = 4;

            foreach (var pair in fieldDictionary)
            {
                string key = pair.Key;

                if ((SPFieldType) pair.Value[1] != SPFieldType.Lookup &&
                    (SPFieldType) pair.Value[1] != SPFieldType.Choice && !key.Equals("ResourceLevel")) continue;

                key = key.Replace("_x0020_", "__");

                string id = "rId" + lookupCounter;

                workbookPart.Workbook.Sheets.AppendChild(new Sheet
                {
                    Name = key + "Values",
                    SheetId = (UInt32Value) (lookupCounter + (0U)),
                    Id = id,
                    State = SheetStateValues.Hidden
                });

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>(id);

                var worksheet = new Worksheet
                {
                    MCAttributes =
                        new MarkupCompatibilityAttributes {Ignorable = "x14ac"}
                };
                worksheet.AddNamespaceDeclaration("r", R_SCHEMA);
                worksheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
                worksheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

                var lookups = (List<string>) pair.Value[2];
                int lookupCount = lookups.Count();

                var sheetProperties = new SheetProperties {CodeName = "Sheet" + lookupCounter};
                var sheetDimension = new SheetDimension {Reference = lookupCount > 0 ? "A1:A" + lookupCount : "A1"};

                var sheetData = new SheetData();

                int counter = 0;
                foreach (string lookupValue in from lookup in lookups select lookup.Split('|')[1])
                {
                    counter++;

                    sheetData.AppendChild(new Row(new Cell(
                        new CellValue(
                            sharedStringIndices[lookupValue]
                                .ToString(CultureInfo.InvariantCulture)))
                    {
                        CellReference = "A" + counter,
                        DataType = CellValues.SharedString
                    }) {RowIndex = (UInt32Value) (counter + (0U))});
                }

                worksheet.Append(sheetProperties, sheetDimension, sheetData);

                worksheetPart.Worksheet = worksheet;

                lookupCounter++;
            }

            CreateDisplayNameWorksheet(workbookPart, lookupCounter);
            CreateSettingsWorksheet(workbookPart, lookupCounter + 1, sharedStringIndices);
        }

        private void CreatePermissionsWorksheet(WorkbookPart workbookPart, Dictionary<string, int> sharedStringIndices)
        {
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>("rId3");

            var worksheet = new Worksheet {MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}};
            worksheet.AddNamespaceDeclaration("r", R_SCHEMA);
            worksheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
            worksheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

            var sheetProperties = new SheetProperties {CodeName = "Sheet3"};
            var sheetDimension = new SheetDimension {Reference = "A1:A" + _permissions.Count()};

            var sheetData = new SheetData();

            int counter = 0;
            foreach (string permission in _permissions)
            {
                counter++;

                sheetData.AppendChild(new Row(new Cell(
                    new CellValue(
                        sharedStringIndices[permission]
                            .ToString(CultureInfo.InvariantCulture)))
                {
                    CellReference = "A" + counter,
                    DataType = CellValues.SharedString
                }) {RowIndex = (UInt32Value) (counter + (0U))});
            }

            worksheet.Append(sheetProperties, sheetDimension, sheetData);

            worksheetPart.Worksheet = worksheet;
        }

        private void CreateResourcesWorksheet(Dictionary<string, object[]> fieldDictionary, DataTable dataTable,
            WorkbookPart workbookPart, Dictionary<string, int> sharedStringIndices)
        {
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>("rId1");
            var worksheet = new Worksheet(new SheetProperties {CodeName = "Sheet1"},
                new SheetDimension
                {
                    Reference =
                        string.Format("A1:{0}{1}",
                            GetColId(fieldDictionary.Count - 1),
                            dataTable.Rows.Count + 2)
                }, new SheetViews(
                    new SheetView(
                        new Pane
                        {
                            VerticalSplit = 1D,
                            TopLeftCell = "A3",
                            ActivePane = PaneValues.BottomLeft,
                            State = PaneStateValues.Frozen
                        },
                        new Selection
                        {
                            ActiveCell = "A2",
                            SequenceOfReferences =
                                new ListValue<StringValue> {InnerText = "A2"}
                        },
                        new Selection {Pane = PaneValues.BottomLeft})
                    {
                        TabSelected = true,
                        TopLeftCell = "A2",
                        WorkbookViewId = (UInt32Value) 0U
                    }))
            {
                MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}
            };

            worksheet.AddNamespaceDeclaration("r", R_SCHEMA);
            worksheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
            worksheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

            var columns = new Columns();

            UInt32Value colIndex = 1U;
            foreach (var pair in fieldDictionary)
            {
                var column = new Column
                {
                    Min = colIndex,
                    Max = colIndex,
                    Width = 9.140625D,
                    Style = 1U,
                    BestFit = true,
                    CustomWidth = true
                };

                if (pair.Key.Equals("ID") || pair.Key.Equals("Title"))
                {
                    column.Style = 5U;
                }

                if (pair.Key.Equals("SharePointAccount") && new Act(_spWeb).IsOnline)
                {
                    column.Hidden = true;
                }

                columns.AppendChild(column);

                colIndex++;
            }

            columns.AppendChild(new Column {Min = colIndex, Max = 16384U, Width = 9.140625D, Style = 1U});

            var sheetData = new SheetData();

            for (UInt32Value i = 1; i <= dataTable.Rows.Count + 2; i++)
            {
                var row = new Row {RowIndex = i};
                if (i == 1)
                {
                    row.Hidden = true;
                }
                else if (i == 2)
                {
                    row.StyleIndex = 4U;
                    row.CustomFormat = true;
                }

                var rowId = (int) (i - 1);

                for (int j = 0; j < fieldDictionary.Count; j++)
                {
                    var cellValue = new CellValue();

                    KeyValuePair<string, object[]> pair = fieldDictionary.ElementAt(j);

                    object oValue = null;
                    string value = string.Empty;

                    if (rowId > 1)
                    {
                        oValue = dataTable.Rows[rowId - 2][pair.Key];

                        if (pair.Key.Equals("ResourceLevel"))
                        {
                            foreach (var l in ((IList<string>) pair.Value[2])
                                .Select(level => level.Split('|'))
                                .Where(l => l[0].Equals(oValue.ToString())))
                            {
                                oValue = l[1];
                                break;
                            }
                        }

                        value = oValue.ToString();
                    }

                    switch (rowId)
                    {
                        case 0:
                            cellValue.Text = sharedStringIndices[pair.Key].ToString(CultureInfo.InvariantCulture);
                            break;
                        case 1:
                            cellValue.Text =
                                sharedStringIndices[pair.Value[0].ToString()].ToString(CultureInfo.InvariantCulture);
                            break;
                        default:
                            cellValue.Text = sharedStringIndices[value].ToString(CultureInfo.InvariantCulture);
                            break;
                    }

                    var cell = new Cell {CellReference = GetColId(j) + i, StyleIndex = 1U};

                    if (rowId > 1)
                    {
                        switch ((SPFieldType) pair.Value[1])
                        {
                            case SPFieldType.Counter:
                            case SPFieldType.Integer:
                            case SPFieldType.Number:
                                cellValue.Text = value;
                                break;
                            case SPFieldType.DateTime:
                                cell.StyleIndex = 3U;
                                cellValue.Text = oValue != null && oValue != DBNull.Value
                                    ? ((DateTime) oValue).ToOADate()
                                        .ToString(CultureInfo.InvariantCulture)
                                    : null;
                                break;
                            case SPFieldType.Currency:
                                cell.StyleIndex = 2U;
                                cellValue.Text = value;
                                break;
                            case SPFieldType.Boolean:
                                cell.DataType = CellValues.Boolean;
                                cellValue.Text = value;
                                break;
                            default:
                                cell.DataType = CellValues.SharedString;
                                break;
                        }

                        switch (pair.Key)
                        {
                            case "ID":
                            case "Title":
                            case "Generic":
                            case "SharePointAccount":
                            case "Email":
                                cell.StyleIndex = 5U;
                                break;
                        }
                    }
                    else
                    {
                        cell.DataType = CellValues.SharedString;
                    }

                    if (i == 2)
                    {
                        cell.StyleIndex = 4U;
                    }

                    cell.AppendChild(cellValue);
                    row.AppendChild(cell);
                }

                sheetData.AppendChild(row);
            }

            var worksheetExtensionList = new WorksheetExtensionList();

            var worksheetExtension = new WorksheetExtension {Uri = "{CCE6A557-97BC-4b89-ADB6-D9C93CAAB3DF}"};
            worksheetExtension.AddNamespaceDeclaration("x14", X14_SCHEMA);

            var dataValidations = new X14.DataValidations {Count = 0U};
            dataValidations.AddNamespaceDeclaration("xm", XM_SCHEMA);

            for (int i = 0; i < fieldDictionary.Count; i++)
            {
                string colId = GetColId(i);

                KeyValuePair<string, object[]> pair = fieldDictionary.ElementAt(i);

                var spFieldType = (SPFieldType) pair.Value[1];

                if (spFieldType != SPFieldType.Boolean && spFieldType != SPFieldType.Lookup &&
                    spFieldType != SPFieldType.User && spFieldType != SPFieldType.Choice) continue;

                if (pair.Key.Equals("SharePointAccount")) continue;

                dataValidations.Count++;

                var dataValidation = new X14.DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    ShowInputMessage = true,
                    ShowErrorMessage = true
                };

                string formulaValue = string.Empty;

                switch (spFieldType)
                {
                    case SPFieldType.Boolean:
                        formulaValue = "BValues!$A$1:$A$2";
                        break;
                    case SPFieldType.Lookup:
                    case SPFieldType.Choice:
                        int count = ((List<string>) pair.Value[2]).Count();
                        formulaValue = pair.Key.Replace("_x0020_", "__") + "Values!$A$1" +
                                       (count > 1 ? ":$A$" + count : string.Empty);
                        break;
                    case SPFieldType.User:
                        formulaValue = "DNValues!$D:$D";
                        break;
                }

                var dataValidationForumla = new X14.DataValidationForumla1();
                var formula = new Formula {Text = formulaValue};
                dataValidationForumla.AppendChild(formula);

                var refSeq = new ReferenceSequence {Text = string.Format("{0}3:{0}1048576", colId)};

                dataValidation.Append(dataValidationForumla, refSeq);
                dataValidations.AppendChild(dataValidation);
            }

            worksheetExtension.AppendChild(dataValidations);
            worksheetExtensionList.AppendChild(worksheetExtension);

            worksheet.Append(columns, sheetData, worksheetExtensionList);
            worksheetPart.Worksheet = worksheet;
        }

        private void CreateSettingsWorksheet(WorkbookPart workbookPart, int lookupCounter,
            Dictionary<string, int> sharedStringIndices)
        {
            string rId = "rId" + lookupCounter;

            workbookPart.Workbook.Sheets.AppendChild(new Sheet
            {
                Name = "Settings",
                SheetId = (UInt32Value) (lookupCounter + (0U)),
                Id = rId,
                State = SheetStateValues.Hidden
            });

            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>(rId);

            var worksheet = new Worksheet
            {
                MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}
            };

            worksheet.AddNamespaceDeclaration("r", R_SCHEMA);
            worksheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
            worksheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

            var sheetProperties = new SheetProperties {CodeName = "Sheet" + lookupCounter};
            var sheetDimension = new SheetDimension {Reference = "A1"};
            var sheetData = new SheetData();

            var row = new Row {RowIndex = 1U, Spans = new ListValue<StringValue> {InnerText = "1:1"}, DyDescent = 0.25D};

            var cell = new Cell {CellReference = "A1", DataType = CellValues.SharedString};
            var cellValue = new CellValue
            {
                Text =
                    sharedStringIndices[new Act(_spWeb).IsOnline.ToString()].ToString(
                        CultureInfo.InvariantCulture)
            };

            cell.AppendChild(cellValue);
            row.AppendChild(cell);

            sheetData.AppendChild(row);

            worksheet.Append(sheetProperties, sheetDimension, sheetData);
            worksheetPart.Worksheet = worksheet;
        }

        private void CreateSharedStringTable(Dictionary<string, object[]> fieldDictionary, DataTable dataTable,
            WorkbookPart workbookPart, Dictionary<string, int> sharedStringIndices)
        {
            var sharedStringTablePart = workbookPart.AddNewPart<SharedStringTablePart>("rId100");

            var sharedStringTable = new SharedStringTable
            {
                Count =
                    (UInt32Value)
                        (fieldDictionary.Count*(2 + dataTable.Rows.Count) + 0U),
                UniqueCount = (UInt32Value) (sharedStringIndices.Count + 0U)
            };

            foreach (var pair in sharedStringIndices)
            {
                sharedStringTable.AppendChild(new SharedStringItem(new Text(pair.Key)));
            }

            sharedStringTablePart.SharedStringTable = sharedStringTable;
        }

        private MemoryStream CreateSpreadsheet(Dictionary<string, object[]> fieldDictionary, DataTable dataTable)
        {
            Dictionary<string, int> sharedStringIndices = BuildSharedString(fieldDictionary, dataTable);

            var memoryStream = new MemoryStream();
            using (SpreadsheetDocument d =
                SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.MacroEnabledWorkbook))
            {
                WorkbookPart workbookPart = CreateWorkbook(d);

                CreateStylesheet(workbookPart);

                CreateSharedStringTable(fieldDictionary, dataTable, workbookPart, sharedStringIndices);

                CreateResourcesWorksheet(fieldDictionary, dataTable, workbookPart, sharedStringIndices);
                CreateBValuesWorksheet(workbookPart);
                CreatePermissionsWorksheet(workbookPart, sharedStringIndices);
                CreateLookupValueSheets(fieldDictionary, workbookPart, sharedStringIndices);

                AddVbaCode(workbookPart);
            }

            return memoryStream;
        }

        private void CreateStylesheet(WorkbookPart workbookPart)
        {
            var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>("rId101");

            var stylesheet = new Stylesheet {MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}};
            stylesheet.AddNamespaceDeclaration("mc", MC_SCHEMA);
            stylesheet.AddNamespaceDeclaration("x14ac", X14_AC_SCHEMA);

            var numberingFormats = new NumberingFormats(new NumberingFormat
            {
                NumberFormatId = 44U,
                FormatCode = FORMAT_CODE
            }) {Count = 1U};

            var fonts = new Fonts {Count = 3U, KnownFonts = true};

            var font1 = new Font(new FontSize {Val = 11D}, new Color {Theme = 1U}, new FontName {Val = "Calibri"},
                new FontFamilyNumbering {Val = 2}, new FontScheme {Val = FontSchemeValues.Minor});

            var font2 = new Font(new FontSize {Val = 11D}, new Color {Theme = 1U}, new FontName {Val = "Calibri"},
                new FontFamilyNumbering {Val = 2}, new FontScheme {Val = FontSchemeValues.Minor});

            var font3 = new Font(new Bold(), new FontSize {Val = 11D}, new Color {Theme = 0U},
                new FontName {Val = "Calibri"}, new FontFamilyNumbering {Val = 2},
                new FontScheme {Val = FontSchemeValues.Minor});

            fonts.Append(font1, font2, font3);

            var fills = new Fills {Count = 3U};

            var fill1 = new Fill(new PatternFill {PatternType = PatternValues.None});

            var fill2 = new Fill(new PatternFill {PatternType = PatternValues.Gray125});

            var fill3 = new Fill(new PatternFill(
                new ForegroundColor {Rgb = "FF0070C0"},
                new BackgroundColor {Indexed = 64U}) {PatternType = PatternValues.Solid});

            fills.Append(fill1, fill2, fill3);

            var borders = new Borders(new Border(), new LeftBorder(), new RightBorder(), new TopBorder(),
                new BottomBorder(), new DiagonalBorder()) {Count = 1U};

            var cellStyleFormats = new CellStyleFormats {Count = 2U};
            var cellFormat1 = new CellFormat {NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U};
            var cellFormat2 = new CellFormat
            {
                NumberFormatId = 44U,
                FontId = 1U,
                FillId = 0U,
                BorderId = 0U,
                ApplyFont = false,
                ApplyFill = false,
                ApplyBorder = false,
                ApplyAlignment = false,
                ApplyProtection = false
            };

            cellStyleFormats.Append(cellFormat1, cellFormat2);

            var cellFormats = new CellFormats {Count = 6U};
            var cellFormat3 = new CellFormat
            {
                NumberFormatId = 0U,
                FontId = 0U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 0U
            };

            var cellFormat4 = new CellFormat
            {
                NumberFormatId = 0U,
                FontId = 0U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 0U,
                ApplyProtection = true
            };
            var protection1 = new Protection {Locked = false};

            cellFormat4.AppendChild(protection1);

            var cellFormat5 = new CellFormat
            {
                NumberFormatId = 44U,
                FontId = 0U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 1U,
                ApplyFont = true,
                ApplyProtection = true
            };
            var protection2 = new Protection {Locked = false};

            cellFormat5.AppendChild(protection2);

            var cellFormat6 = new CellFormat
            {
                NumberFormatId = 14U,
                FontId = 0U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 0U,
                ApplyNumberFormat = true,
                ApplyProtection = true
            };
            var protection3 = new Protection {Locked = false};

            cellFormat6.AppendChild(protection3);
            var cellFormat7 = new CellFormat
            {
                NumberFormatId = 0U,
                FontId = 2U,
                FillId = 2U,
                BorderId = 0U,
                FormatId = 0U,
                ApplyFont = true,
                ApplyFill = true,
                ApplyProtection = true
            };
            var cellFormat8 = new CellFormat
            {
                NumberFormatId = 0U,
                FontId = 0U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 0U,
                ApplyProtection = true
            };

            cellFormats.Append(cellFormat3, cellFormat4, cellFormat5, cellFormat6, cellFormat7, cellFormat8);

            var cellStyles = new CellStyles {Count = 2U};
            var cellStyle1 = new CellStyle {Name = "Currency", FormatId = 1U, BuiltinId = 4U};
            var cellStyle2 = new CellStyle {Name = "Normal", FormatId = 0U, BuiltinId = 0U};

            cellStyles.Append(cellStyle1, cellStyle2);

            var differentialFormats = new DifferentialFormats {Count = 0U};

            var tableStyles = new TableStyles
            {
                Count = 0U,
                DefaultTableStyle = "TableStyleMedium2",
                DefaultPivotStyle = "PivotStyleLight16"
            };

            var stylesheetExtensionList = new StylesheetExtensionList();

            var stylesheetExtension = new StylesheetExtension {Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}"};
            stylesheetExtension.AddNamespaceDeclaration("x14",
                X14_SCHEMA);

            var slicerStyles = new X14.SlicerStyles {DefaultSlicerStyle = "SlicerStyleLight1"};
            stylesheetExtension.AppendChild(slicerStyles);

            stylesheetExtensionList.AppendChild(stylesheetExtension);

            stylesheet.Append(numberingFormats, fonts, fills, borders, cellStyleFormats, cellFormats, cellStyles,
                differentialFormats, tableStyles, stylesheetExtensionList);

            workbookStylesPart.Stylesheet = stylesheet;
        }

        private WorkbookPart CreateWorkbook(SpreadsheetDocument spreadsheetDocument)
        {
            WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();

            var sheet1 = new Sheet {Name = "Resources", SheetId = 1U, Id = "rId1"};
            var sheet2 = new Sheet {Name = "BValues", SheetId = 2U, State = SheetStateValues.Hidden, Id = "rId2"};
            var sheet3 = new Sheet {Name = "Permissions", SheetId = 3U, State = SheetStateValues.Hidden, Id = "rId3"};

            workbookPart.Workbook =
                new Workbook(new WorkbookProperties {CodeName = "ThisWorkbook"}, new Sheets(sheet1, sheet2, sheet3),
                    new CalculationProperties {CalculationId = 0U});

            return workbookPart;
        }

        private Stream GetBinaryDataStream(string base64String)
        {
            return new MemoryStream(Convert.FromBase64String(base64String));
        }

        private string GetColId(int index)
        {
            int dividend = index + 1;
            string colId = string.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1)%26;
                colId = Convert.ToChar(65 + modulo).ToString() + colId;
                dividend = ((dividend - modulo)/26);
            }

            return colId;
        }

        private object[] GetFieldInfo(SPField spField)
        {
            object choices = null;

            SPFieldType spFieldType = spField.Type;

            switch (spFieldType)
            {
                case SPFieldType.Choice:
                    choices = new List<string>();
                    foreach (string choice in ((SPFieldChoice) spField).Choices)
                    {
                        ((List<string>) choices).Add("|" + choice);
                    }
                    break;
                case SPFieldType.MultiChoice:
                    choices = new List<string>();
                    foreach (string choice in ((SPFieldMultiChoice) spField).Choices)
                    {
                        ((List<string>) choices).Add("|" + choice);
                    }
                    break;
                case SPFieldType.Lookup:
                    choices = GetLookupChoices(spField);
                    break;
            }

            string internalName = spField.InternalName;

            if (internalName.Equals("ResourceLevel"))
            {
                var list = new List<string>();

                var act = new Act(_spWeb);
                bool isOnline = act.IsOnline;

                if (!isOnline ||
                    ((_spWeb.CurrentUser.IsSiteAdmin ||
                      CoreFunctions.GetRealUserName(_spWeb.CurrentUser.LoginName, _spWeb.Site)
                          .ToLower()
                          .Equals(act.OwnerUsername.ToLower()))))
                {
                    int actType;
                    list.AddRange(from ActLevel l in act.GetLevelsFromSite(out actType, string.Empty)
                        select l.id + "|" + l.name);
                }

                choices = list;

                spFieldType = SPFieldType.Lookup;
            }

            return new[] {spField.Title, spFieldType, choices};
        }

        private IList<string> GetLookupChoices(SPField spField)
        {
            var list = new List<string>();

            var spFieldLookup = (SPFieldLookup) spField;
            string lookupField = spFieldLookup.LookupField;

            using (var spSite = new SPSite(spFieldLookup.ParentList.ParentWeb.Site.ID))
            {
                using (SPWeb spWeb = spSite.OpenWeb(spFieldLookup.LookupWebId))
                {
                    SPList spList = spWeb.Lists[new Guid(spFieldLookup.LookupList)];
                    SPListItemCollection spListItemCollection = spList.GetItems(new[] {lookupField});

                    foreach (string value in spListItemCollection.Cast<SPListItem>()
                        .Select(li => li.ID + "|" + li[lookupField])
                        .Where(value => !list.Contains(value)))
                    {
                        list.Add(value);
                    }
                }
            }

            return list;
        }

        private static IEnumerable<string> GetPermissions(SPWeb web)
        {
            return from SPGroup g in web.Groups
                let eGroup = web.Groups[g.Name]
                let c = eGroup.Roles
                let canUse = c.Cast<SPRole>().Any(r => r.PermissionMask != (SPRights) 134287360)
                where g.CanCurrentUserEditMembership && canUse
                select g.Name;
        }

        private DataTable GetResources(SPList resourcePool)
        {
            var dataTable = new DataTable();

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                _permissions = GetPermissions(resourcePool.ParentWeb).ToList();

                dataTable = resourcePool.GetItems(new SPQuery()).GetDataTable();

                if (dataTable != null) return;

                using (new DisabledItemEventScope())
                {
                    _spWeb.AllowUnsafeUpdates = true;

                    SPListItem spListItem = resourcePool.Items.Add();
                    spListItem["Title"] = "EPMLiveResourceExporter";
                    spListItem.SystemUpdate();

                    dataTable = resourcePool.GetItems(new SPQuery()).GetDataTable();
                    dataTable.Rows[0].Delete();

                    spListItem.Delete();

                    _spWeb.AllowUnsafeUpdates = false;
                }
            });

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SPListItem spListItem = resourcePool.GetItemById((int) dataRow["ID"]);

                var account = (string) (spListItem["SharePointAccount"] ?? string.Empty);
                if (!string.IsNullOrEmpty(account))
                {
                    SPUser spUser = (new SPFieldUserValue(_spWeb, account)).User;
                    dataRow["SharePointAccount"] = spUser != null ? spUser.LoginName : string.Empty;

                    if (spUser != null)
                    {
                        List<string> permissions =
                            (from SPGroup g in spUser.Groups where _permissions.Contains(g.Name) select g.Name).ToList();

                        dataRow["Permissions"] = permissions.Any()
                            ? string.Join(", ", permissions.ToArray())
                            : string.Empty;
                    }
                }
                else
                {
                    dataRow["SharePointAccount"] = string.Empty;
                }
            }

            return dataTable;
        }

        private void ValidateAccess()
        {
            if (!_spWeb.CurrentUser.IsSiteAdmin)
            {
                throw new Exception("You need to be a Site Collection Administrator in order to export resources.");
            }
        }

        #endregion Methods 
    }
}