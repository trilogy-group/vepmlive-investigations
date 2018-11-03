using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    internal class ReportXmlBuilder
    {
        private readonly ResourcePoolManager _resourcePoolManager;
        private readonly string _elementName;
        private readonly IDictionary<string, string> formatDictionary = new Dictionary<string, string>();
        private readonly IDictionary<object, string[]> lookupValues = new Dictionary<object, string[]>();
        private readonly IDictionary<object, string[]> userValues = new Dictionary<object, string[]>();
        private readonly IList<string> lookupColumns = new List<string>();

        public ReportXmlBuilder(ResourcePoolManager resourcePoolManager, string elementName)
        {
            _resourcePoolManager = resourcePoolManager;
            _elementName = elementName;
        }

        internal List<XElement> BuildXmlElements(
            bool includeHidden,
            bool includeReadOnly,
            IEnumerable<DataRow> rowCollection,
            IList<SPField> spFieldCollection,
            DataColumnCollection dataColumnCollection,
            DataTable resources,
            out Dictionary<string, object[]> valueDictionary)
        {
            EnsureArgumentNotNull(rowCollection, nameof(rowCollection));

            var elements = new List<XElement>();
            valueDictionary = new Dictionary<string, object[]>();

            foreach (DataRow row in rowCollection)
            {
                var itemElement = new XElement(_elementName);
                itemElement.Add(new XAttribute("ID", row["ID"]));

                EnsureArgumentNotNull(spFieldCollection, nameof(spFieldCollection));
                foreach (var spField in spFieldCollection)
                {
                    var internalName = spField.InternalName;
                    var isHidden = spField.Hidden;
                    var isReadOnly = spField.ReadOnlyField;

                    if (!internalName.Equals("EXTID"))
                    {
                        if (isHidden && !includeHidden)
                        {
                            continue;
                        }

                        if (isReadOnly && !includeReadOnly)
                        {
                            continue;
                        }
                    }

                    var objectValues = GetObjectValues(dataColumnCollection, resources, row, spField, internalName);
                    var stringValue = objectValues.ToString().Trim();

                    string fieldEditValue;
                    string fieldTextValue;
                    string fieldHtmlValue;
                    var processHtmlValue = GetFieldValues(
                        valueDictionary,
                        spField,
                        objectValues,
                        stringValue,
                        out fieldEditValue,
                        out fieldTextValue,
                        out fieldHtmlValue);

                    if (!formatDictionary.ContainsKey(internalName))
                    {
                        formatDictionary.Add(internalName, Utils.GetFormat(spField));
                    }

                    itemElement.Add(new XElement("Data", new XAttribute("Field", internalName),
                        new XAttribute("Type", spField.Type),
                        new XAttribute("Format", formatDictionary[internalName]),
                        new XAttribute("Hidden", isHidden),
                        new XAttribute("ReadOnly", isReadOnly),
                        new XAttribute("TextValue", fieldTextValue),
                        new XAttribute("HtmlValue", fieldHtmlValue),
                        new XAttribute("EditValue", fieldEditValue),
                        new XAttribute("ProcessHtmlValue", processHtmlValue),
                        new XCData(stringValue)));
                }

                elements.Add(itemElement);
            }

            return elements;
        }

        private bool GetFieldValues(
            IDictionary<string, object[]> valueDictionary,
            SPField spField,
            object objectValues,
            string stringValue,
            out string fieldEditValue,
            out string fieldTextValue,
            out string fieldHtmlValue)
        {
            var processHtmlValue = false;

            switch (spField.Type)
            {
                case SPFieldType.Lookup:
                    GetLookupFieldValues(
                        valueDictionary,
                        spField,
                        objectValues,
                        stringValue,
                        out fieldEditValue,
                        out fieldTextValue,
                        out fieldHtmlValue);

                    processHtmlValue = true;
                    break;
                case SPFieldType.User:
                    if (!userValues.ContainsKey(objectValues))
                    {
                        _resourcePoolManager.GetFieldSpecialValues(
                            spField,
                            stringValue,
                            objectValues,
                            out fieldEditValue,
                            out fieldTextValue,
                            out fieldHtmlValue);

                        userValues.Add(
                            objectValues,
                            new[]
                            {
                                fieldTextValue,
                                fieldEditValue,
                                fieldHtmlValue
                            });
                    }
                    else
                    {
                        var userValue = userValues[objectValues];

                        fieldTextValue = userValue[0];
                        fieldEditValue = userValue[1];
                        fieldHtmlValue = userValue[2];
                    }
                    break;
                case SPFieldType.DateTime:
                    string specialValue = string.IsNullOrWhiteSpace(stringValue)
                        ? string.Empty
                        : ((DateTime)objectValues).ToString("yyyy-MM-dd HH:mm:ss");

                    fieldTextValue = specialValue;
                    fieldHtmlValue = specialValue;
                    fieldEditValue = specialValue;
                    break;
                default:
                    fieldTextValue = stringValue;
                    fieldEditValue = stringValue;
                    fieldHtmlValue = stringValue;
                    break;
            }

            return processHtmlValue;
        }

        private void GetLookupFieldValues(
            IDictionary<string, object[]> valueDictionary,
            SPField spField,
            object objectValues,
            string stringValue,
            out string fieldEditValue,
            out string fieldTextValue,
            out string fieldHtmlValue)
        {
            var spFieldLookup = (SPFieldLookup)spField;
            var key = $"{spFieldLookup.LookupList}{spFieldLookup.LookupField}{stringValue}";

            if (!lookupValues.ContainsKey(key))
            {
                _resourcePoolManager.GetFieldSpecialValues(
                    spField,
                    stringValue,
                    objectValues,
                    out fieldEditValue,
                    out fieldTextValue,
                    out fieldHtmlValue);

                fieldHtmlValue = key;

                lookupValues.Add(
                    key,
                    new[]
                    {
                        fieldTextValue,
                        fieldEditValue,
                        fieldHtmlValue
                    });

                valueDictionary.Add(
                    key,
                    new[]
                    {
                        spField,
                        objectValues
                    });
            }
            else
            {
                var lookupValue = lookupValues[key];

                fieldTextValue = lookupValue[0];
                fieldEditValue = lookupValue[1];
                fieldHtmlValue = lookupValue[2];
            }
        }

        private object GetObjectValues(
            DataColumnCollection dataColumnCollection,
            DataTable resources,
            DataRow row,
            SPField spField,
            string internalName)
        {
            object objectValues = null;
            EnsureArgumentNotNull(dataColumnCollection, nameof(dataColumnCollection));
            if (dataColumnCollection.Contains(internalName))
            {
                objectValues = row[internalName];
                if (objectValues == null || objectValues == DBNull.Value)
                {
                    objectValues = string.Empty;
                }

                return objectValues;
            }
            else
            {
                if (!lookupColumns.Contains(internalName))
                {
                    EnsureArgumentNotNull(resources, nameof(resources));
                    if (resources.Columns.Contains($"{internalName}ID"))
                    {
                        lookupColumns.Add(internalName);
                    }
                }

                if (lookupColumns.Contains(internalName))
                {
                    var idValue = row[$"{internalName}ID"];
                    var textValue = row[$"{internalName}Text"];

                    return TryGetObjectValues(spField, idValue, textValue);
                }
            }

            return string.Empty;
        }

        private static string TryGetObjectValues(SPField spField, object idValue, object textValue)
        {
            // MultiChoice handling is removed, as the code was unreachable.
            // Jira ticket: CC-78277
            if (spField.Type != SPFieldType.MultiChoice)
            {
                if (idValue == null 
                    || idValue == DBNull.Value 
                    || textValue == null 
                    || textValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    var ids = idValue.ToString().Split(',');
                    var values = textValue.ToString().Split(',');
                    var list = new List<string>();

                    for (var i = 0; i < ids.Length; i++)
                    {
                        try
                        {
                            list.Add(ids[i]);
                            list.Add(values[i]);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }
                    }

                    return string.Join(";#", list.ToArray());
                }
            }

            return string.Empty;
        }

        private void EnsureArgumentNotNull(object obj, string objectName)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(objectName);
            }
        }
    }
}
