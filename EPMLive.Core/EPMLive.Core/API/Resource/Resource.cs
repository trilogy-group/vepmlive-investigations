using System;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class Resource
    {
        #region Methods (7) 

        // Private Methods (4) 

        /// <summary>
        /// Decodes the grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static string DecodeGridData(string data)
        {
            string decodedData = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));
            if (decodedData == null)
            {
                throw new APIException(15900, "Unable to decode the layout data.");
            }

            return decodedData;
        }

        /// <summary>
        /// Gets the field special values.
        /// </summary>
        /// <param name="spField">The sp field.</param>
        /// <param name="stringValue">The string value.</param>
        /// <param name="value">The value.</param>
        /// <param name="fieldEditValue">The field edit value.</param>
        /// <param name="fieldTextValue">The field text value.</param>
        /// <param name="fieldHtmlValue">The field HTML value.</param>
        private static void GetFieldSpecialValues(SPField spField, string stringValue, object value,
                                                  out string fieldEditValue,
                                                  out string fieldTextValue, out string fieldHtmlValue)
        {
            fieldTextValue = string.IsNullOrEmpty(stringValue)
                                 ? string.Empty
                                 : spField.GetFieldValueAsText(value) ?? string.Empty;

            fieldHtmlValue = string.IsNullOrEmpty(stringValue)
                                 ? string.Empty
                                 : spField.GetFieldValueAsHtml(value) ?? string.Empty;

            fieldEditValue = string.IsNullOrEmpty(stringValue)
                                 ? string.Empty
                                 : spField.GetFieldValueForEdit(value) ?? string.Empty;
        }

        /// <summary>
        /// Gets the resources list.
        /// </summary>
        /// <returns></returns>
        private static SPList GetResourcesList()
        {
            SPWeb spWeb = SPContext.Current.Web;

            SPList resourcesList = spWeb.Lists.TryGetList("Resources");
            if (resourcesList == null)
                throw new APIException(15906,
                                       string.Format(@"Cannot find the ""Resources"" list at {0}",
                                                     spWeb.ServerRelativeUrl));

            return resourcesList;
        }

        /// <summary>
        /// Registers the grid id.
        /// </summary>
        /// <param name="resultXml">The result XML.</param>
        /// <param name="dataXml">The data XML.</param>
        private static void RegisterGridId(XDocument resultXml, XDocument dataXml)
        {
            if (dataXml == null)
            {
                throw new APIException(15901, "Layout data cannot be null.");
            }

            if (resultXml.Root == null)
            {
                throw new APIException(15902, "Cannot find the Root element of the grid layout.");
            }

            if (dataXml.Root == null)
            {
                throw new APIException(15904, "Cannot find the Root element of the layout data.");
            }

            XElement idElement = dataXml.Root.Element("Id");
            if (idElement == null)
            {
                throw new APIException(15905, "Cannot find the Id element of the layout data.");
            }

            var cfgElement = new XElement("Cfg");
            cfgElement.Add(new XAttribute("id", idElement.Value));

            resultXml.Root.Add(cfgElement);
        }

        // Internal Methods (3) 

        /// <summary>
        /// Gets the resource data grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourceDataGrid(string data)
        {
            return GetResources(data);
        }

        /// <summary>
        /// Gets the resource layout grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourceLayoutGrid(string data)
        {
            try
            {
                XDocument dataXml = XDocument.Parse(DecodeGridData(data));

                XDocument resultXml = XDocument.Parse(Resources.ResourceGridLayout);
                RegisterGridId(resultXml, dataXml);

                return resultXml.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(15200, e.Message);
            }
        }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResources(string data)
        {
            try
            {
                SPList resourcesList = GetResourcesList();

                var resultXml = new XDocument();
                resultXml.Add(new XElement("Resources"));

                XElement resourcesElement = resultXml.Element("Resources");

                foreach (SPListItem spListItem in resourcesList.Items)
                {
                    var resourceElement = new XElement("Resource");

                    foreach (SPField spField in resourcesList.Fields)
                    {
                        if (spField.Hidden) continue;

                        string internalName = spField.InternalName;
                        object value = spListItem[internalName] ?? string.Empty;
                        string stringValue = value.ToString().Trim();

                        string fieldEditValue;
                        string fieldTextValue;
                        string fieldHtmlValue;
                        GetFieldSpecialValues(spField, stringValue, value, out fieldEditValue, out fieldTextValue, out fieldHtmlValue);

                        var dataElement = new XElement("Data", new XCData(stringValue));

                        dataElement.Add(new XAttribute("Field", internalName));
                        dataElement.Add(new XAttribute("Type", spField.Type));
                        dataElement.Add(new XAttribute("Format", Utils.GetFormat(spField)));
                        dataElement.Add(new XAttribute("TextValue", fieldTextValue));
                        dataElement.Add(new XAttribute("HtmlValue", fieldHtmlValue));
                        dataElement.Add(new XAttribute("EditValue", fieldEditValue));

                        resourceElement.Add(dataElement);
                    }

                    resourcesElement.Add(resourceElement);
                }

                return resultXml.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(15000, e.Message);
            }
        }

        #endregion Methods 
    }
}