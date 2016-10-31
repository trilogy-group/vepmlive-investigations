using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace BillingSite.appstore
{
    public class ProductService : ShopifyService
    {
        #region Constructors (1) 

        public ProductService(string apiKey, string password, string accountId, string tableName,
                              string connectionString) : base(apiKey, password, accountId, tableName, connectionString)
        {
        }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        /// <summary>
        /// Gets the request uris.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        private IEnumerable<Uri> GetRequestUris(string id, IEnumerable<string> fields)
        {
            var uris = new[]
                           {
                               new Uri("products/" + id + ".xml", UriKind.Relative),
                               new Uri("products/" + id + "/metafields.xml", UriKind.Relative)
                           };

            fields = fields.ToArray();

            if (fields.Any())
            {
                uris[0] = new Uri(uris[0].OriginalString + "?fields=" + string.Join(",", fields.ToArray()),
                                  UriKind.Relative);
            }

            return uris;
        }

        #endregion Methods 

        #region Overrides of ShopifyService

        /// <summary>
        /// Reterives the product by specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public override string Reterive(string id, IEnumerable<string> fields = null)
        {
            var responseXml = new XElement("Product");

            Uri[] requestUris = GetRequestUris(id, fields).ToArray();

            XElement productRootElement = XDocument.Parse(Request(requestUris[0])).Root;
            if (productRootElement != null)
            {
                foreach (XElement xElement in productRootElement.Elements())
                {
                    if (xElement.Elements().Any()) continue;

                    string key = xElement.Name.LocalName.Replace("-", string.Empty);
                    responseXml.Add(new XElement(key, new XCData(xElement.Value)));
                }
            }

            var metafieldsElement = new XElement("Metafields");

            XElement metafieldsRootElement = XDocument.Parse(Request(requestUris[1])).Root;
            if (metafieldsRootElement != null)
            {
                foreach (XElement xElement in metafieldsRootElement.Elements())
                {
                    string key = null;
                    string value = null;
                    bool add = true;

                    XElement keyElement = xElement.Element("key");

                    if (keyElement != null)
                    {
                        key = keyElement.Value.Replace("-", string.Empty);

                        XElement valueElement = xElement.Element("value");
                        if (valueElement != null) value = valueElement.Value;
                    }

                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) continue;

                    if (fields != null && fields.Any()) add = fields.Contains(key);
                    if (add) metafieldsElement.Add(new XElement(key, new XCData(value)));
                }
            }

            if (metafieldsElement.Elements().Any()) responseXml.Add(metafieldsElement);

            return responseXml.ToString();
        }

        /// <summary>
        /// Saves the specified data XML.
        /// </summary>
        /// <param name="dataXml">The data XML.</param>
        /// <param name="additionalData">The additional data.</param>
        public void Save(XDocument dataXml, Dictionary<string, string> additionalData = null)
        {
            Save(dataXml.ToString(), additionalData);
        }

        #endregion
    }
}