using System;
using System.Diagnostics;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void InstallListsFields(SPList list, XmlNode nodeList, int parentMessageId)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (nodeList == null)
            {
                throw new ArgumentNullException(nameof(nodeList));
            }
            var ndFields = nodeList.SelectSingleNode("Fields");

            if (ndFields != null)
            {
                parentMessageId = addMessage(0, bVerifyOnly ? "Checking Fields" : "Updating Fields", string.Empty, parentMessageId);

                foreach (XmlNode ndField in ndFields.SelectNodes("Field"))
                {
                    ProcessField(list, parentMessageId, ndField);
                }
            }
        }

        private void ProcessField(SPList list, int parentMessageId, XmlNode ndField)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (ndField == null)
            {
                throw new ArgumentNullException(nameof(ndField));
            }
            var internalName = ApplicationInstallerHelpers.getAttribute(ndField, "InternalName");
            var internalFieldXml = ndField.SelectSingleNode("Field");
            var typeValue = ApplicationInstallerHelpers.getAttribute(internalFieldXml, "Type");
            bool overwrite;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndField, "Overwrite"), out overwrite);

            var total = ApplicationInstallerHelpers.getAttribute(ndField, "Total");

            SPField spField = null;
            try
            {
                spField = list.Fields.GetFieldByInternalName(internalName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            if (spField == null)
            {
                FieldNewLetsAdd(list, parentMessageId, internalName, internalFieldXml, typeValue);
            }
            else
            {
                FieldExistsSoWeCanUpgrade(
                    list,
                    parentMessageId,
                    internalName,
                    internalFieldXml,
                    typeValue,
                    overwrite,
                    spField);
            }

            if (!string.IsNullOrEmpty(total))
            {
                SaveGridGanttSettings(list, internalName, total);
            }
        }

        private void FieldNewLetsAdd(
            SPList list, 
            int parentMessageId, 
            string internalName, 
            XmlNode internalFieldXml, 
            string typeValue)
        {
            if (bVerifyOnly)
            {
                ApplicationInstallerHelpers.GetFieldTypeByString(typeValue);

                addMessage(ErrorLevels.NoError, internalName, string.Empty, parentMessageId);
            }
            else
            {
                try
                {
                    var spField = ApplicationInstallerHelpers.InstallListFieldsAddField(list, internalName, typeValue, internalFieldXml);
                    try
                    {
                        if (spField != null)
                        {
                            ApplicationInstallerHelpers.InstallListFieldSwapXml(list, spField, internalFieldXml);
                        }

                        addMessage(ErrorLevels.NoError, internalName, string.Empty, parentMessageId);
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, internalName, "Error updating field schema: " + ex.Message, parentMessageId);
                        Trace.WriteLine(ex.ToString());
                    }
                }
                catch (Exception ex)
                {
                    addMessage(ErrorLevels.Error, internalName, "Error adding field: " + ex.Message, parentMessageId);
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private void FieldExistsSoWeCanUpgrade(
            SPList list, 
            int parentMessageId, 
            string internalName, 
            XmlNode internalFieldXml, 
            string typeValue, 
            bool overwrite, 
            SPField spField)
        {
            if (spField == null)
            {
                throw new ArgumentNullException(nameof(spField));
            }
            if (spField.TypeAsString.Equals(typeValue, StringComparison.InvariantCultureIgnoreCase))
            {
                if (overwrite)
                {
                    if (bVerifyOnly)
                    {
                        addMessage(ErrorLevels.Upgrade, internalName, "Field exists and will overwrite", parentMessageId);
                    }
                    else
                    {
                        try
                        {
                            ApplicationInstallerHelpers.InstallListFieldSwapXml(list, spField, internalFieldXml);

                            addMessage(ErrorLevels.NoError, internalName, "Field updated", parentMessageId);
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, internalName, "Error updating field schema: " + ex.Message, parentMessageId);
                            Trace.WriteLine(ex.ToString());
                        }
                    }
                }
                else
                {
                    addMessage(ErrorLevels.Warning, internalName, "Field exists and cannot overwrite", parentMessageId);
                }
            }
            else
            {
                addMessage(ErrorLevels.Error, internalName, "Field type mistmatch", parentMessageId);
            }
        }

        private static void SaveGridGanttSettings(SPList list, string internalName, string total)
        {
            var gridGanttSettings = new GridGanttSettings(list);

            var output = string.Empty;

            var fieldList = gridGanttSettings.TotalSettings.Split('\n');

            foreach (var field in fieldList)
            {
                if (field != string.Empty)
                {
                    var fieldData = field.Split('|');
                    if (fieldData[0] != internalName)
                    {
                        output += "\n" + field;
                    }
                }
            }

            output += "\n" + internalName + "|" + total;

            gridGanttSettings.TotalSettings = output.Trim('\n');
            gridGanttSettings.SaveSettings(list);
        }
    }
}