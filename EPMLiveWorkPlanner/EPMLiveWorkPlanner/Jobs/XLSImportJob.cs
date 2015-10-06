using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.SharePoint;
using System.Xml;
using System.Data;
using System.Collections;

namespace EPMLiveWorkPlanner
{
    public class XLSImportJob : EPMLiveCore.API.BaseJob
    {
        private string GetCellValue(SpreadsheetDocument document, Cell cell, CellFormats cellFormats)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;

            if (cell.CellValue != null)
            {
                string value = cell.CellValue.InnerXml;

                try
                {
                    if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                    {
                        return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                    }
                    else
                    {
                        if (cell.DataType == null)
                        {
                            CellFormat cf = cellFormats.Descendants<CellFormat>().ElementAt<CellFormat>(Convert.ToInt32(cell.StyleIndex.Value));
                            if (cf.NumberFormatId >= 0 && cf.NumberFormatId <= 13)
                                return Convert.ToDecimal(value).ToString();
                            else if (cf.NumberFormatId >= 14 && cf.NumberFormatId <= 22)
                                return DateTime.FromOADate(Convert.ToDouble(value)).ToString("s");
                            else
                                return value;
                        }
                        else
                            return value;
                    }
                }
                catch { return value; }
            }
            return "";
        }


        public void execute(SPSite osite, SPWeb oweb, string data)
        {
            XmlDocument docData = null;
            Hashtable hshCols = null;
            EPMLiveCore.Infrastructure.EPMLiveFileStore epmLiveFileStore = null;
            try
            {
                docData = new XmlDocument();
                docData.LoadXml(data);

                string filename = docData.FirstChild.Attributes["FileName"].Value;

                string sSheetId = docData.FirstChild.Attributes["SheetId"].Value;

                epmLiveFileStore = new EPMLiveCore.Infrastructure.EPMLiveFileStore(oweb);

                using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(epmLiveFileStore.GetStream(filename), false))
                {
                    WorkbookPart workbookPart = myDoc.WorkbookPart;

                    IEnumerable<Sheet> sheets = myDoc.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sSheetId);
                    if (sheets.Count() == 0)
                        return;

                    WorksheetPart worksheetPart = (WorksheetPart)myDoc.WorkbookPart.GetPartById(sheets.First().Id);
                    Worksheet worksheet = worksheetPart.Worksheet;
                    SheetData oSheetData = worksheet.GetFirstChild<SheetData>();
                    WorkbookStylesPart workbookStylesPart = myDoc.WorkbookPart.GetPartsOfType<WorkbookStylesPart>().First();
                    CellFormats cellFormats = (CellFormats)workbookStylesPart.Stylesheet.CellFormats;

                    IEnumerable<Row> rows = oSheetData.Descendants<Row>();

                    XmlDocument docImport = new XmlDocument();
                    docImport.LoadXml("<Import Planner='" + base.key + "' ID='" + base.ItemID + "' ResourceField='Title'/>");

                    string sUID = "";



                    try
                    {
                        docImport.FirstChild.Attributes["ResourceField"].Value = docData.FirstChild.Attributes["ResourceField"].Value;
                    }
                    catch { }

                    try
                    {
                        XmlAttribute attr = docImport.CreateAttribute("UIDColumn");
                        attr.Value = docData.FirstChild.Attributes["UIDColumn"].Value;
                        sUID = docData.FirstChild.Attributes["UIDColumn"].Value;
                        docImport.FirstChild.Attributes.Append(attr);
                    }
                    catch { }

                    try
                    {
                        XmlAttribute attr = docImport.CreateAttribute("AllowDuplicateRows");
                        attr.Value = docData.FirstChild.Attributes["AllowDuplicateRows"].Value;
                        docImport.FirstChild.Attributes.Append(attr);
                    }
                    catch { }

                    hshCols = new Hashtable();
                    XmlNode ndCols = docData.FirstChild.SelectSingleNode("Columns");
                    if (ndCols != null)
                    {
                        foreach (XmlNode ndCol in ndCols.SelectNodes("Column"))
                        {
                            try
                            {
                                string ListField = ndCol.Attributes["ExcelField"].Value;
                                string PlannerField = ndCol.Attributes["PlannerField"].Value;

                                if (ListField != "" && PlannerField != "")
                                {
                                    if (!hshCols.ContainsKey(ListField))
                                    {
                                        hshCols.Add(ListField, PlannerField);
                                    }
                                }
                            }
                            catch { }
                        }
                    }

                    string[] sCols = new string[rows.ElementAt(0).Descendants<Cell>().Count()];
                    int colcount = 0;

                    foreach (Cell cell in rows.ElementAt(0))
                    {
                        sCols[colcount++] = GetCellValue(myDoc, cell, cellFormats);
                    }

                    totalCount = rows.Count() * 2;
                    float counter = 0;


                    try
                    {
                        if (hshCols.Contains(docData.FirstChild.Attributes["Structure"].Value))
                        {
                            XmlAttribute attr = docImport.CreateAttribute("Structure");
                            attr.Value = hshCols[docData.FirstChild.Attributes["Structure"].Value].ToString();
                            docImport.FirstChild.Attributes.Append(attr);
                        }
                    }
                    catch { }

                    foreach (Row row in rows)
                    {
                        if (counter > 0)
                        {
                            XmlNode ndRow = docImport.CreateNode(XmlNodeType.Element, "Item", docImport.NamespaceURI);
                            for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                            {
                                if (sCols[i] == sUID)
                                {
                                    XmlAttribute attr = docImport.CreateAttribute("EXTID");
                                    attr.Value = GetCellValue(myDoc, row.Descendants<Cell>().ElementAt(i), cellFormats);
                                    ndRow.Attributes.Append(attr);
                                }
                                else
                                {
                                    string colName = sCols[i];
                                    if (hshCols.Contains(colName))
                                    {
                                        colName = hshCols[colName].ToString();

                                        XmlAttribute attr = docImport.CreateAttribute(colName);
                                        attr.Value = GetCellValue(myDoc, row.Descendants<Cell>().ElementAt(i), cellFormats);
                                        ndRow.Attributes.Append(attr);
                                    }
                                }
                            }

                            docImport.FirstChild.AppendChild(ndRow);
                        }
                        updateProgress(counter++);
                    }

                    XmlDocument docRet = new XmlDocument();
                    docRet.LoadXml(WorkPlannerAPI.ImportTasks(docImport, oweb));

                    if (docRet.FirstChild.Attributes["Status"].Value == "1")
                    {
                        bErrors = true;
                    }

                    sErrors = docRet.OuterXml;
                }

                try
                {
                    epmLiveFileStore.Delete(filename);
                }
                catch { }
            }
            catch (Exception ex)
            {
                base.bErrors = true;
                base.sErrors = "Error: " + ex.Message;
            }
            finally
            {
                docData = null;
                hshCols = null;
                if (epmLiveFileStore != null)
                    epmLiveFileStore.Dispose();
                if (oweb != null)
                    oweb.Dispose();
                if (osite != null)
                    osite.Dispose();
                data = null;
            }
        }
    }
}
