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
using System.IO;

namespace EPMLiveWorkPlanner
{
    public class CsvImportJob : EPMLiveCore.API.BaseJob
    {
        private string[] ConvertFromCSV(string line, int cols)
        {
            string []sRet = new string[cols];

            string[] sSplit = line.Split(',');

            int counter = 0;

            bool processingcomma = false;

            for(int i = 0; i < sSplit.Length && counter <= cols; i++)
            {
                try
                {
                    if(processingcomma)
                    {
                        if(sSplit[i][sSplit[i].Length - 1] == '"')
                        {
                            sRet[counter] += "," + sSplit[i].Substring(0, sSplit[i].Length - 1);
                            processingcomma = false;
                            counter++;
                        }
                        else
                        {
                            sRet[counter] += "," + sSplit[i];
                        }
                    }
                    else if(sSplit[i][0] == '"')
                    {
                        if(sSplit[i][sSplit[i].Length - 1] == '"')
                        {
                            sRet[counter] = sSplit[i].Substring(1, sSplit[i].Length - 2);
                            counter++;
                        }
                        else
                        {
                            sRet[counter] = sSplit[i].Substring(1);
                            processingcomma = true;
                        }
                    }
                    else
                    {
                        sRet[counter] = sSplit[i];
                        counter++;
                    }
                }
                catch { }
            }

            return sRet;
        }

        public void execute(SPSite osite, SPWeb oweb, string data)
        {
            try
            {
                XmlDocument docData = new XmlDocument();
                docData.LoadXml(data);

                string filename = docData.FirstChild.Attributes["FileName"].Value;
                
                

                    XmlDocument docImport = new XmlDocument();
                    docImport.LoadXml("<Import Planner='" + base.key + "' ID='" + base.ItemID + "' ResourceField='Title'/>");

                    string sUID = "";
                    string sSeperator = "CSV";

                    try
                    {
                        XmlAttribute attr = docImport.CreateAttribute("Structure");
                        attr.Value = docData.FirstChild.Attributes["Structure"].Value;
                        docImport.FirstChild.Attributes.Append(attr);
                    }
                    catch { }

                    try
                    {
                        docImport.FirstChild.Attributes["ResourceField"].Value = docData.FirstChild.Attributes["ResourceField"].Value;
                    }
                    catch { }
                
                    try
                    {
                        sSeperator = docData.FirstChild.Attributes["Seperator"].Value;
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


                    Hashtable hshCols = new Hashtable();

                    XmlNode ndCols = docData.FirstChild.SelectSingleNode("Columns");
                    if(ndCols != null)
                    {
                        foreach(XmlNode ndCol in ndCols.SelectNodes("Column"))
                        {
                            try
                            {
                                string ListField = ndCol.Attributes["ImportField"].Value;
                                string PlannerField = ndCol.Attributes["PlannerField"].Value;

                                if(ListField != "" && PlannerField != "")
                                {
                                    if(!hshCols.ContainsKey(ListField) && !hshCols.ContainsValue(PlannerField))
                                    {
                                        hshCols.Add(ListField, PlannerField);
                                    }
                                }
                            }
                            catch { }
                        }
                    }

                    var epmLiveFileStore = new EPMLiveCore.Infrastructure.EPMLiveFileStore(oweb);

                    StreamReader sr = new StreamReader(epmLiveFileStore.GetStream(filename));
                    string firstLine = sr.ReadLine();
                    char seperator = ',';

                    switch(sSeperator)
                    {
                        case "TSV":
                            seperator = '\t';
                            break;
                        case "CSV":
                            seperator = ',';
                            break;
                    };

                    totalCount = 2;

                    string[] headers = firstLine.Split(seperator);

                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string []sLine;

                        if(sSeperator == "CSV")
                        {
                            sLine = ConvertFromCSV(line, headers.Length);
                        }
                        else
                        {
                            sLine = line.Split(seperator);
                        }

                        XmlNode ndRow = docImport.CreateNode(XmlNodeType.Element, "Item", docImport.NamespaceURI);
                        for(int i = 0; i < sLine.Length; i++)
                        {
                            try
                            {
                                if(headers[i] == sUID)
                                {
                                    XmlAttribute attr = docImport.CreateAttribute("EXTID");
                                    attr.Value = sLine[i];
                                    ndRow.Attributes.Append(attr);
                                }
                                else
                                {
                                    string colName = headers[i];
                                    if(hshCols.Contains(colName))
                                        colName = hshCols[colName].ToString();

                                    XmlAttribute attr = docImport.CreateAttribute(colName);
                                    attr.Value = sLine[i];
                                    ndRow.Attributes.Append(attr);
                                }
                            }
                            catch { }
                        }

                        docImport.FirstChild.AppendChild(ndRow);
                    }

                    updateProgress(1);

                    XmlDocument docRet = new XmlDocument();
                    docRet.LoadXml(WorkPlannerAPI.ImportTasks(docImport, oweb));

                    if(docRet.FirstChild.Attributes["Status"].Value == "1")
                    {
                        bErrors = true;
                    }

                    sErrors = docRet.OuterXml;

                try
                {
                    epmLiveFileStore.Delete(filename);
                }
                catch { }
            }
            catch(Exception ex) 
            {
                base.bErrors = true;
                base.sErrors = "Error: " + ex.Message;
            }
        }
    }
}
