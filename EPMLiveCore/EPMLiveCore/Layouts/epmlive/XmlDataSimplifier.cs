using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    internal static class XmlDataSimplifier
    {
        internal static IList<string> CompLevels;
        internal static string SolutionType;

        internal static string SimplifySPGetListItemsXml(XmlNode data)
        {
            var result = new StringBuilder();
            var currentWeb = SPContext.Current.Web;
            using (var writer = XmlWriter.Create(result, GetDefaultXMLWriterSettings()))
            {
                writer.WriteStartElement("Templates");
                var rawMetaInfo = string.Empty;

                foreach (XmlNode node in data.FirstChild.NextSibling.ChildNodes)
                {
                    if (node.NodeType != XmlNodeType.Whitespace)
                    {
                        // grab metainfo string and parse needed information
                        rawMetaInfo = node.Attributes["ows_MetaInfo"].Value;
                        var infos = new List<string>(rawMetaInfo.Split(
                            new string[] { "\r\n" },
                            StringSplitOptions.None));

                        if (!string.IsNullOrWhiteSpace(SolutionType)
                            && !SolutionType.Equals("SiteCollection", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // This is the value from solution store
                            // "Compatible Site Collection Templates"
                            var siteTemplates = GetInfoStartsWith(infos, "SiteTemplates");

                            if (node.Attributes["ows_SiteTemplates"] != null
                                && !string.IsNullOrWhiteSpace(node.Attributes["ows_SiteTemplates"].Value))
                            {
                                siteTemplates = node.Attributes["ows_SiteTemplates"].Value;
                            }

                            // if siteTemplates value is blank,
                            // bring back all templates
                            var isCompatible = true;
                            if (string.IsNullOrWhiteSpace(siteTemplates))
                            {
                                siteTemplates = "99";
                            }

                            isCompatible = false;
                            var templateCompLevels = siteTemplates.Split(',');
                            foreach (var level in templateCompLevels)
                            {
                                if (CompLevels.Contains(level.Trim()))
                                {
                                    isCompatible = true;
                                    break;
                                }
                            }

                            // if not compatible, 
                            // skip this template
                            if (!isCompatible)
                            {
                                continue;
                            }
                        }

                        var description = GetInfoStartsWith(infos, "Description");
                        var tempCategory = GetInfoStartsWith(infos, "TemplateCategory");
                        var salesInfo = GetInfoStartsWith(infos, "SalesInfo");

                        WriteData(currentWeb, writer, node, description, tempCategory, salesInfo);
                    }
                }
                // <Templates>
                writer.WriteEndElement();
                writer.Flush();
            }

            return result.ToString();
        }

        private static void WriteData(
            SPWeb currentWeb, 
            XmlWriter writer, 
            XmlNode node, 
            string description, 
            string tempCategory, 
            string salesInfo)
        {
            // <Solution Id="<val>" DisplayInStore="<val>">
            writer.WriteStartElement("Template");
            writer.WriteAttributeString("Id", node.Attributes["ows_ID"].Value);
            writer.WriteAttributeString("Active", node.Attributes["ows_Visible"].Value);
            writer.WriteAttributeString("IncludeContent", "false");

            // <Title><![CDATA[<val>]]></Title>
            writer.WriteStartElement("Title");
            var title = node.Attributes["ows_LinkFilename"] != null
                ? node.Attributes["ows_LinkFilename"].Value
                : string.Empty;
            writer.WriteCData(title);
            writer.WriteEndElement();

            // <Description><![CDATA[<val>]]></Description>
            writer.WriteStartElement("Description");
            writer.WriteCData(description ?? string.Empty);
            writer.WriteEndElement();

            writer.WriteStartElement("Levels");
            var levels = node.Attributes["ows_Level"] != null
                ? node.Attributes["ows_Level"].Value
                : string.Empty;
            writer.WriteCData(levels);
            writer.WriteEndElement();

            writer.WriteStartElement("SalesInfo");
            writer.WriteCData(salesInfo);
            writer.WriteEndElement();

            try
            {
                var rawTypesVal = string.Empty;
                rawTypesVal = node.Attributes["ows_TemplateType"].Value;
                writer.WriteStartElement("TemplateType");
                writer.WriteCData(rawTypesVal);
                writer.WriteEndElement();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            writer.WriteStartElement("TemplateCategory");
            writer.WriteCData(tempCategory ?? string.Empty);
            writer.WriteEndElement();

            writer.WriteStartElement("ImageUrl");
            var imageUrl = node.Attributes["ows_Icon"] != null
                ? node.Attributes["ows_Icon"].Value
                : string.Empty;

            imageUrl = !string.IsNullOrWhiteSpace(imageUrl)
                ? imageUrl.Trim()
                : (currentWeb.ServerRelativeUrl == "/"
                    ? string.Empty
                    : currentWeb.ServerRelativeUrl) + "/_layouts/EPMLive/images/blanktemplate.png";
            writer.WriteCData(imageUrl);
            writer.WriteEndElement();

            // </Template>
            writer.WriteEndElement();
        }

        private static string GetInfoStartsWith(List<string> infos, string token)
        {
            var rawData = infos.Where(s => s.StartsWith(token)).SingleOrDefault();
            return !string.IsNullOrWhiteSpace(rawData)
                ? rawData.Split('|')[1]
                : string.Empty;
        }

        internal static string SimplifySPGetListXml(XmlNode data)
        {
            var result = new StringBuilder();
            var currentWeb = SPContext.Current.Web;
            using (var writer = XmlWriter.Create(result, GetDefaultXMLWriterSettings()))
            {
                writer.WriteStartElement("FilterFields");

                var filterFields =  data.FirstChild.ChildNodes.Cast<XmlNode>()
                    .Where(field => field.Attributes["DisplayName"].Value == "Template Type" 
                            || field.Attributes["DisplayName"].Value == "Template Category");

                foreach (XmlNode node in filterFields)
                {
                    if (node.NodeType != XmlNodeType.Whitespace)
                    {
                        // <Solution Id="<val>" DisplayInStore="<val>">
                        writer.WriteStartElement("Filter");
                        writer.WriteAttributeString("DisplayName", node.Attributes["DisplayName"].Value);
                        writer.WriteAttributeString("StaticName", node.Attributes["StaticName"].Value);
                        writer.WriteStartElement("Choices");

                        var choices = new StringBuilder();
                        foreach (XmlNode element in node.ChildNodes)
                        {
                            if (element.Name.Equals("Choices", StringComparison.CurrentCultureIgnoreCase))
                            {
                                foreach (XmlNode child in element.ChildNodes)
                                {
                                    choices.AppendFormat("{0};#", child.InnerText);
                                }
                                break;
                            }
                        }

                        writer.WriteCData(choices.ToString());
                        writer.WriteEndElement();

                        // </Filter>
                        writer.WriteEndElement();
                    }
                }
                // <FilterFields>
                writer.WriteEndElement();
                writer.Flush();
            }

            return result.ToString();
        }

        private static XmlWriterSettings GetDefaultXMLWriterSettings()
        {
            return new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
                NewLineOnAttributes = true
            };
        }
    }
}
