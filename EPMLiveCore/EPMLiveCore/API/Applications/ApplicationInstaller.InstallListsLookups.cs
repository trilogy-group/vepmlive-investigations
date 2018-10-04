using System;
using System.Diagnostics;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void iInstallListsLookups(SPList list, XmlNode ndList, int parentMessageId)
        {
            if (ndList == null)
            {
                throw new ArgumentNullException(nameof(ndList));
            }
            var ndParent = ndList.ParentNode;

            var ndLookups = ndList.SelectSingleNode("Lookups");

            if (ndLookups != null)
            {
                parentMessageId = addMessage(0, bVerifyOnly ? "Checking Lookups" : "Fixing Lookups", string.Empty, parentMessageId);

                foreach (XmlNode ndLookup in ndLookups.SelectNodes("Lookup"))
                {
                    var internalName = ApplicationInstallerHelpers.getAttribute(ndLookup, "InternalName");

                    try
                    {
                        ProcessNode(list, parentMessageId, ndParent, ndLookup, internalName);
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, internalName, "Error processing: " + ex.Message, parentMessageId);
                        Trace.WriteLine(ex.ToString());
                    }
                }
            }
        }

        private void ProcessNode(SPList list, int parentMessageId, XmlNode ndParent, XmlNode ndLookup, string internalName)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var listValue = ApplicationInstallerHelpers.getAttribute(ndLookup, "List");
            var field = ApplicationInstallerHelpers.getAttribute(ndLookup, "Field");
            var displayName = ApplicationInstallerHelpers.getAttribute(ndLookup, "DisplayName");
            var advancedLookup = ApplicationInstallerHelpers.getAttribute(ndLookup, "AdvancedLookup");

            bool overwrite;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndLookup, "Overwrite"), out overwrite);

            bool required;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndLookup, "Required"), out required);

            bool deleteIfNoList;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndLookup, "DeleteIfNoList"), out deleteIfNoList);

            var tList = oWeb.Lists.TryGetList(listValue);
            SPField spField = null;
            try
            {
                spField = list.Fields.GetFieldByInternalName(internalName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            if (tList != null) 
            {
                int messageId;

                if (spField == null)
                {
                    messageId = AddField(list, parentMessageId, internalName, field, displayName, required, tList.ID);
                }
                else
                {
                    messageId = FieldExist(parentMessageId, internalName, field, overwrite, tList.ID.ToString("B"), spField);
                }

                if (!string.IsNullOrEmpty(advancedLookup))
                {
                    SaveGridGantSettings(list, internalName, advancedLookup, messageId);
                }
            }
            else
            {
                ParentListIsNotFound(list, parentMessageId, ndParent, internalName, listValue, deleteIfNoList, spField);
            }
        }

        private int AddField(SPList list, int parentMessageId, string internalName, string field, string displayName, bool required, Guid listId)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            int messageId;
            if (!bVerifyOnly)
            {
                try
                {
                    list.Fields.AddLookup(internalName, listId, required);
                    var fieldLookup = (SPFieldLookup)list.Fields.GetFieldByInternalName(internalName);
                    if (!string.IsNullOrWhiteSpace(displayName))
                    {
                        fieldLookup.Title = displayName;
                    }
                    fieldLookup.LookupField = field;

                    fieldLookup.Update();
                    messageId = addMessage(0, internalName, "Field added", parentMessageId);
                }
                catch (Exception ex)
                {
                    messageId = addMessage(ErrorLevels.Error, internalName, "Error adding field: " + ex.Message, parentMessageId);
                    Trace.WriteLine(ex.ToString());
                }
            }
            else
            {
                messageId = addMessage(0, internalName, string.Empty, parentMessageId);
            }

            return messageId;
        }

        private int FieldExist(int parentMessageId, string internalName, string field, bool overwrite, string listId, SPField spField)
        {
            if (spField == null)
            {
                throw new ArgumentNullException(nameof(spField));
            }

            int messageId;

            if (spField.Type == SPFieldType.Lookup)
            {
                if (bVerifyOnly)
                {
                    if (overwrite)
                    {
                        messageId = addMessage(ErrorLevels.Upgrade, internalName, "Field exists and will overwrite", parentMessageId);
                    }
                    else
                    {
                        messageId = addMessage(ErrorLevels.Error, internalName, "Field exists and will not overwrite", parentMessageId);
                    }
                }
                else
                {
                    if (overwrite)
                    {
                        try
                        {
                            var doc = new XmlDocument();
                            doc.LoadXml(spField.SchemaXml);

                            doc.FirstChild.Attributes["List"].Value = listId;
                            doc.FirstChild.Attributes["ShowField"].Value = field;

                            spField.SchemaXml = doc.FirstChild.OuterXml;
                            spField.Update(true);

                            messageId = addMessage(0, internalName, "Field updated", parentMessageId);
                        }
                        catch (Exception ex)
                        {
                            messageId = addMessage(ErrorLevels.Error, internalName, "Error updating field: " + ex.Message, parentMessageId);
                            Trace.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        messageId = addMessage(ErrorLevels.Error, internalName, "Field exists and will not overwrite", parentMessageId);
                    }
                }
            }
            else
            {
                messageId = addMessage(ErrorLevels.Error, internalName, "Field exists and is not currently a lookup field", parentMessageId);
            }

            return messageId;
        }

        private void SaveGridGantSettings(SPList list, string internalName, string advancedLookup, int messageId)
        {
            var gSettings = new GridGanttSettings(list);

            var LookupArray = gSettings.Lookups.Split('|');

            var output = string.Empty;

            foreach (var sLookup in LookupArray)
            {
                if (sLookup != string.Empty)
                {
                    var sLookupInfo = sLookup.Split('^');

                    if (sLookupInfo[0] != internalName)
                    {
                        output += "|" + sLookup;
                    }
                }
            }

            output += "|" + internalName + "^" + advancedLookup;

            gSettings.Lookups = output.Trim('|');
            gSettings.SaveSettings(list);

            addMessage(ErrorLevels.NoError, "Enabled Advanced Lookup", string.Empty, messageId);
        }

        private void ParentListIsNotFound(SPList list, int parentMessageId, XmlNode ndParent, string internalName, string listValue, bool deleteIfNoList, SPField spField)
        {
            if (ndParent == null)
            {
                throw new ArgumentNullException(nameof(ndParent));
            }

            if (bVerifyOnly)
            {
                if (ndParent.SelectSingleNode("List[@Name='" + listValue + "']") != null)
                {
                    addMessage(0, internalName, string.Empty, parentMessageId);
                }
                else
                {
                    if (deleteIfNoList)
                    {
                        addMessage(ErrorLevels.Upgrade, internalName, "Lookup List missing (" + listValue + ") field will be deleted",
                            parentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Upgrade, internalName, "Lookup List missing (" + listValue + ") field ignored",
                            parentMessageId);
                    }
                }
            }
            else
            {
                Delete(list, parentMessageId, internalName, listValue, deleteIfNoList, spField);
            }
        }

        private void Delete(
            SPList list, 
            int parentMessageId, 
            string internalName, 
            string listValue, 
            bool deleteIfNoList, 
            SPField spField)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (deleteIfNoList && spField != null)
            {
                try
                {
                    spField.Delete();
                    list.Update();

                    addMessage(ErrorLevels.Upgrade, internalName, "Lookup List missing (" + listValue + ") field deleted",
                        parentMessageId);
                }
                catch (Exception ex)
                {
                    addMessage(ErrorLevels.Error, internalName, "Lookup List missing (" + listValue + ") field failed to delete: " + ex.Message, parentMessageId);
                }
            }
            else
            {
                addMessage(ErrorLevels.Upgrade, internalName, "Lookup List missing (" + listValue + ") field ignored", parentMessageId);
            }
        }
    }
}