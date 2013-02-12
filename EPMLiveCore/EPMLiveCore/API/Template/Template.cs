using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class Template
    {
        #region Methods (2) 

        // Private Methods (1) 

        /// <summary>
        /// Generates the XML element.
        /// </summary>
        /// <param name="xElement">The x element.</param>
        /// <param name="spWeb">The web.</param>
        /// <param name="spList">The list.</param>
        /// <param name="spListItem">The sp list item.</param>
        private static void GenerateXmlElement(XElement xElement, SPWeb spWeb, SPList spList, SPListItem spListItem)
        {
            foreach (SPField spField in spList.Fields)
            {
                string internalName = spField.InternalName;
                object val = spListItem[internalName];

                if (string.IsNullOrEmpty(val as string)) continue;

                string value = val.ToString();
                string fieldName = internalName.Slugify();

                switch (spField.Type)
                {
                    case SPFieldType.DateTime:
                        xElement.Add(new XElement(fieldName, DateTime.Parse(value).ToRegionalDateTime(spWeb)));
                        break;
                    case SPFieldType.Note:
                    case SPFieldType.Text:
                        xElement.Add(new XElement(fieldName, new XCData(value)));
                        break;
                    case SPFieldType.Lookup:
                        if (value.Contains("\n") || value.Contains("\r"))
                        {
                            xElement.Add(new XElement(fieldName, new XCData(value)));
                        }
                        else
                        {
                            try
                            {
                                DateTime dateTime = DateTime.Parse(value);
                                xElement.Add(new XElement(fieldName, DateTime.Parse(value).ToRegionalDateTime(spWeb)));
                            }
                            catch
                            {
                                xElement.Add(new XElement(fieldName, value));
                            }
                        }
                        break;
                    default:
                        xElement.Add(new XElement(fieldName, value));
                        break;
                }
            }
        }

        // Internal Methods (1) 

        /// <summary>
        /// Gets the template information.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetTemplateInformation(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("Template"));

                SPWeb web = SPContext.Current.Web;

                using (var spSite = new SPSite(web.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(spSite.RootWeb.ID))
                    {
                        SPList spList = spWeb.Lists.TryGetList("Template Gallery");

                        if (spList != null)
                        {
                            SPListItem listItem = (from SPListItem spListItem in spList.Items
                                                   let spFieldUrlValue =
                                                       new SPFieldUrlValue(spListItem["URL"].ToString())
                                                   where
                                                       new Uri(spFieldUrlValue.Url).AbsolutePath.ToLower().Equals(
                                                           web.ServerRelativeUrl.ToLower())
                                                   select spListItem).FirstOrDefault();

                            if (listItem != null)
                            {
                                // ReSharper disable PossibleNullReferenceException

                                GenerateXmlElement(result.Root, web, spList, listItem);

                                result.Root.Add(new XElement("WebLastItemModifiedDate",
                                                             web.LastItemModifiedDate.ToRegionalDateTime(web)));

                                SPList list = spWeb.GetCatalog(SPListTemplateType.SolutionCatalog);

                                if (list != null)
                                {
                                    string templateName =
                                        Path.GetFileName(string.Format("{0}.wsp", web.SafeServerRelativeUrl()));

                                    foreach (SPListItem spListItem in list.Items)
                                    {
                                        if (!spListItem.File.Name.Equals(templateName)) continue;

                                        var xElement = new XElement("Solution");

                                        GenerateXmlElement(xElement, web, list, spListItem);

                                        result.Root.Add(xElement);
                                        break;
                                    }
                                }
                                else
                                {
                                    throw new APIException(10603,
                                                           string.Format(
                                                               @"Can not find the ""Solution Gallery"" list at: {0}",
                                                               spWeb.SafeServerRelativeUrl()));
                                }

                                // ReSharper restore PossibleNullReferenceException
                            }
                            else
                            {
                                throw new APIException(10602,
                                                       string.Format(@"""{0}"" is not a template site.",
                                                                     web.SafeServerRelativeUrl()));
                            }
                        }
                        else
                        {
                            throw new APIException(10601,
                                                   string.Format(@"Can not find the ""Template Gallery"" list at: {0}",
                                                                 spWeb.SafeServerRelativeUrl()));
                        }
                    }
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException(10600, exception.Message);
            }
        }

        #endregion Methods 
    }
}