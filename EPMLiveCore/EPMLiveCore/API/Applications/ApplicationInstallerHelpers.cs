using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using EPMLiveCore.WebPartsHelper;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.WebPartPages;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace EPMLiveCore.API
{
    internal static class ApplicationInstallerHelpers
    {
        public static string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return string.Empty;
            }
        }

        public static string getChildNodeText(XmlNode nd, string child)
        {
            try
            {
                return nd.SelectSingleNode(child).InnerText;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return string.Empty;
            }
        }

        public static SPNavigationNode GetNavNode(SPNavigationNodeCollection navNode, string navField, string nodename, SPListItem oLiParent)
        {
            try
            {
                var navs = oLiParent[oLiParent.ParentList.Fields.GetFieldByInternalName(navField).Id].ToString().Split(',');

                foreach (SPNavigationNode ndNav in navNode)
                {
                    if (string.Equals(ndNav.Title, nodename, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (var nav in navs)
                        {
                            if (ndNav.Id == int.Parse(nav))
                            {
                                return ndNav;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return null;
        }

        public static SPListTemplateType GetTemplateType(string sType)
        {
            try
            {
                var iTemplate = 100;

                int.TryParse(sType, out iTemplate);

                return (SPListTemplateType)iTemplate;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return SPListTemplateType.GenericList;
        }

        public  static SPFieldType GetFieldTypeByString(string sType)
        {
            switch (sType)
            {
                case "Boolean":
                    return SPFieldType.Boolean;
                case "Calculated":
                    return SPFieldType.Calculated;
                case "Choice":
                    return SPFieldType.Choice;
                case "Currency":
                    return SPFieldType.Currency;
                case "DateTime":
                    return SPFieldType.DateTime;
                case "MultiChoice":
                    return SPFieldType.MultiChoice;
                case "Note":
                    return SPFieldType.Note;
                case "Number":
                    return SPFieldType.Number;
                case "Text":
                    return SPFieldType.Text;
                case "URL":
                    return SPFieldType.URL;
                case "User":
                    return SPFieldType.User;
                default:
                    return SPFieldType.Invalid;
            }
        }

        public  static bool isValidSchemaAttribute(string attribute)
        {
            switch (attribute)
            {
                case "ID":
                case "SourceID":
                case "Type":
                case "StaticName":
                case "Name":
                case "ColName":
                case "RowOrdinal":
                    return false;
                default:
                    return true;
            }
        }

        public  static bool isValidNewSchemaAttribute(string attribute)
        {
            switch (attribute)
            {
                case "ID":
                case "SourceID":
                case "ColName":
                case "RowOrdinal":
                    return false;
                default:
                    return true;
            }
        }

        public  static SPField InstallListFieldsAddField(SPList list, string sInternalName, string sType, XmlNode ndNewField)
        {
            var oType = GetFieldTypeByString(sType);
            if (oType != SPFieldType.Invalid)
            {
                list.Fields.Add(sInternalName, oType, false);

                var field = list.Fields.GetFieldByInternalName(sInternalName);

                return field;
            }
            try
            {
                var arrAttr = new ArrayList();

                foreach (XmlAttribute attr in ndNewField.Attributes)
                {
                    if (!isValidNewSchemaAttribute(attr.Name))
                    {
                        arrAttr.Add(attr);
                    }
                }

                foreach (XmlAttribute attr in arrAttr)
                {
                    ndNewField.Attributes.Remove(attr);
                }

                var sDisplay = ndNewField.Attributes["DisplayName"].Value;

                ndNewField.Attributes["DisplayName"].Value = sInternalName;


                list.Fields.AddFieldAsXml(ndNewField.OuterXml);
                var field = list.Fields.GetFieldByInternalName(sInternalName);
                field.Title = sDisplay;
                ndNewField.Attributes["DisplayName"].Value = sDisplay;
                return field;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());

                throw new Exception("Error: " + ex.Message);
            }
        }

        public  static void InstallListFieldSwapXml(SPList list, SPField field, XmlNode ndNewField)
        {
            var bIsSealed = field.Sealed;
            if (bIsSealed)
            {
                field.Sealed = false;
                field.Update();
            }

            InstallListFieldSwapXml(list, field.InternalName, ndNewField);

            if (bIsSealed)
            {
                field.Sealed = bIsSealed;
                field.Update(true);
            }
        }

        public  static void InstallListFieldSwapXml(SPList list, string sField, XmlNode ndNewField)
        {
            var field = list.Fields.GetFieldByInternalName(sField);

            if (field.Type == SPFieldType.Calculated)
            {
                var calc = (SPFieldCalculated)field;
                calc.Formula = ndNewField.SelectSingleNode("FormulaDisplayNames").InnerText;
                field.Update();
            }

            if (field.Type == SPFieldType.Choice || field.Type == SPFieldType.MultiChoice)
            {
                ProcessChoice(ndNewField, field);
            }
            else
            {
                var docOldField = new XmlDocument();
                docOldField.LoadXml(field.SchemaXml);

                var ndOldField = docOldField.FirstChild;

                foreach (XmlAttribute attrNew in ndNewField.Attributes)
                {
                    if (isValidSchemaAttribute(attrNew.Name))
                    {
                        if (ndOldField.Attributes[attrNew.Name] == null)
                        {
                            var attr = docOldField.CreateAttribute(attrNew.Name);
                            attr.Value = ndNewField.Attributes[attrNew.Name].Value;
                            ndOldField.Attributes.Append(attr);
                        }
                        else
                        {
                            ndOldField.Attributes[attrNew.Name].Value = ndNewField.Attributes[attrNew.Name].Value;
                        }
                    }
                }
                ndOldField.InnerXml = ndNewField.InnerXml;

                field.SchemaXml = ndOldField.OuterXml;
                field.Update();
            }
        }

        private static void ProcessChoice(XmlNode ndNewField, SPField field)
        {
            var choice = (SPFieldChoice)field;
            choice.Choices.Clear();

            var ndChoices = ndNewField.SelectSingleNode("CHOICES");
            foreach (XmlNode ndChoice in ndChoices.SelectNodes("CHOICE"))
            {
                choice.Choices.Add(ndChoice.InnerText);
            }

            try
            {
                choice.ShowInEditForm = bool.Parse(ndNewField.Attributes["ShowInEditForm"].Value);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            try
            {
                choice.ShowInNewForm = bool.Parse(ndNewField.Attributes["ShowInNewForm"].Value);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            try
            {
                choice.ShowInDisplayForm = bool.Parse(ndNewField.Attributes["ShowInDisplayForm"].Value);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            try
            {
                choice.FillInChoice = bool.Parse(ndNewField.Attributes["FillInChoice"].Value);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            choice.Title = ndNewField.Attributes["DisplayName"].Value;
            choice.Update();
        }

        public  static void ConnectWebPartConsumersToReportFilter(SPLimitedWebPartManager webPartManager)
        {
            // Get the report filter provider.
            var providerWebPart = webPartManager
                .WebParts
                .Cast<WebPart>()
                .FirstOrDefault(e => e.GetType().ToString() == "EPMLiveWebParts.ReportingFilter");

            if (providerWebPart == null)
            {
                return;
            }

            ProviderConnectionPoint providerConnection = null;

            foreach (ProviderConnectionPoint point in webPartManager.GetProviderConnectionPoints(providerWebPart))
            {
                if (point.InterfaceType == typeof(IReportID))
                {
                    providerConnection = point;
                    break;
                }
            }

            // Run through each consumer and connect them to the report filter.
            foreach (Microsoft.SharePoint.WebPartPages.WebPart webPart in webPartManager.WebParts)
            {
                if (webPart == providerWebPart)
                {
                    continue;
                }

                foreach (ConsumerConnectionPoint point in webPartManager.GetConsumerConnectionPoints(webPart))
                {
                    if (point.InterfaceType == typeof(IReportID))
                    {
                        webPartManager.SPConnectWebParts(providerWebPart, providerConnection, webPart, point);

                        break;
                    }
                }
            }
        }
    }
}