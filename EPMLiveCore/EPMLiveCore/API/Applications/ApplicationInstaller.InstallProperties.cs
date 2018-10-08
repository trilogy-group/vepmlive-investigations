using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private const string Seperator = "Seperator";

        private void InstallProperties()
        {
            var webNode = appDef.ApplicationXml.FirstChild.SelectSingleNode("Web");
            if (webNode != null)
            {
                var propertyNodes = webNode.SelectSingleNode("Properties");
                if (propertyNodes != null)
                {
                    var parentMessageId = 0;

                    parentMessageId = addMessage(0, bVerifyOnly ? "Checking Properties" : "Installing Properties", string.Empty, 0);

                    var listProperties = propertyNodes.SelectNodes("Property");
                    float max = listProperties.Count;
                    float counter = 0;

                    foreach (XmlNode propertyNode in listProperties)
                    {
                        try
                        {
                            var propertyName = propertyNode.Attributes["Name"].Value;
                            var propertyValue = propertyNode.Attributes["Value"].Value;
                            bool append;
                            bool overWrite;
                            bool isLockWeb;

                            bool.TryParse(ApplicationInstallerHelpers.getAttribute(propertyNode, "Append"), out append);
                            bool.TryParse(ApplicationInstallerHelpers.getAttribute(propertyNode, "Overwrite"), out overWrite);
                            bool.TryParse(ApplicationInstallerHelpers.getAttribute(propertyNode, "LockWebProperty"), out isLockWeb);

                            if (append)
                            {
                                InstallProperty(parentMessageId, propertyNode, propertyName, propertyValue, overWrite, isLockWeb);
                            }
                            else
                            {
                                InstallProperty(parentMessageId, propertyName, propertyValue, overWrite, isLockWeb);
                            }
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, propertyNode.Attributes["Name"].Value, ex.Message, parentMessageId);

                            Trace.WriteLine(ex.ToString());
                        }

                        counter++;
                        var percent = counter / max;
                        updateLIPercent(percent);
                    }
                }
            }
        }

        private void InstallProperty(
            int parentMessageId, 
            XmlNode propertyNode, 
            string propertyName, 
            string propertyValue, 
            bool overWrite, 
            bool isLockWeb)
        {
            if (oWeb.Properties.ContainsKey(propertyName))
            {
                var separator = GetSeparator(propertyNode);

                var duplicateRegEx = ApplicationInstallerHelpers.getAttribute(propertyNode, "DuplicateRegEx");

                var curProp = iInstallPropertiesGet(propertyName, isLockWeb);

                if (separator == '\r')
                {
                    curProp = curProp.Replace("\r\n", "\r");
                }

                var currentValues = curProp.Split(separator);

                if (string.IsNullOrWhiteSpace(duplicateRegEx))
                {
                    duplicateRegEx = propertyValue;
                }

                var found = GetFound(duplicateRegEx, currentValues);

                if (found)
                {
                    InstallProperty(
                        parentMessageId, 
                        propertyName, 
                        propertyValue, 
                        overWrite, 
                        isLockWeb, 
                        separator, 
                        duplicateRegEx, 
                        currentValues);
                }
                else
                {
                    InstallProperty(parentMessageId, propertyName, propertyValue, isLockWeb, separator);
                }
            }
            else
            {
                if (!bVerifyOnly)
                {
                    iInstallPropertiesSet(propertyName, propertyValue, isLockWeb);
                }

                addMessage(ErrorLevels.NoError, propertyName, string.Empty, parentMessageId);
            }
        }

        private static char GetSeparator(XmlNode propertyNode)
        {
            var separator = ApplicationInstallerHelpers.getAttribute(propertyNode, Seperator)[0];
            if (ApplicationInstallerHelpers.getAttribute(propertyNode, Seperator) == "\\n")
            {
                separator = '\n';
            }

            if (ApplicationInstallerHelpers.getAttribute(propertyNode, Seperator) == "\\r")
            {
                separator = '\r';
            }

            if (separator == '\0')
            {
                separator = ',';
            }

            return separator;
        }

        private static bool GetFound(string duplicateRegEx, string[] currentValues)
        {
            if (currentValues == null)
            {
                throw new ArgumentNullException(nameof(currentValues));
            }

            var found = false;

            foreach (var curValue in currentValues)
            {
                var match = Regex.Match(curValue, duplicateRegEx);
                if (match.Length > 0)
                {
                    found = true;
                }
            }

            return found;
        }

        private void InstallProperty(
            int parentMessageId, 
            string propertyName, 
            string propertyValue, 
            bool overWrite, 
            bool isLockWeb, 
            char separator, 
            string duplicateRegEx, 
            string[] currentValues)
        {
            if (overWrite)
            {
                if (!bVerifyOnly)
                {
                    var newVal = GetNewValue(propertyValue, separator, duplicateRegEx, currentValues);

                    iInstallPropertiesSet(propertyName, newVal, isLockWeb);
                }

                addMessage(ErrorLevels.NoError, propertyName, "Property found and will append", parentMessageId);
            }
            else
            {
                addMessage(ErrorLevels.Warning, propertyName, "Cannot append value, value already exists", parentMessageId);
            }
        }

        private static string GetNewValue(string propertyValue, char separator, string duplicateRegEx, string[] currentValues)
        {
            if (currentValues == null)
            {
                throw new ArgumentNullException(nameof(currentValues));
            }

            var builder = new StringBuilder();

            foreach (var curVal in currentValues)
            {
                var match = Regex.Match(curVal, duplicateRegEx);
                if (match.Length > 0)
                {
                    if (separator == '\r')
                    {
                        builder.Append("\r\n")
                            .Append(propertyValue);
                    }
                    else
                    {
                        builder.Append(separator)
                            .Append(propertyValue);
                    }
                }
                else
                {
                    if (separator == '\r')
                    {
                        builder.Append("\r\n")
                            .Append(curVal);
                    }
                    else
                    {
                        builder.Append(separator)
                            .Append(curVal);
                    }
                }
            }
            var newVal = string.Empty;
            if (separator == '\r')
            {
                newVal = builder.ToString().Trim('\n').Trim('\r');
            }
            else
            {
                newVal = builder.ToString().Trim(separator);
            }

            return newVal;
        }

        private void InstallProperty(
            int parentMessageId, 
            string propertyName, 
            string propertyValue, 
            bool isLockWeb, 
            char separator)
        {
            if (!bVerifyOnly)
            {
                var newVal = iInstallPropertiesGet(propertyName, isLockWeb);

                if (separator == '\r')
                {
                    newVal += "\r\n" + propertyValue;
                }
                else
                {
                    newVal += separator + propertyValue;
                }

                if (separator == '\r')
                {
                    newVal = newVal.Trim('\n').Trim('\r');
                }
                else
                {
                    newVal = newVal.Trim(separator);
                }

                iInstallPropertiesSet(propertyName, newVal, isLockWeb);
            }

            addMessage(ErrorLevels.NoError, propertyName, string.Empty, parentMessageId);
        }

        private void InstallProperty(int parentMessageId, string propertyName, string propertyValue, bool overWrite, bool isLockWeb)
        {
            if (overWrite)
            {
                if (bVerifyOnly)
                {
                    if (oWeb.Properties.ContainsKey(propertyName) && iInstallPropertiesGet(propertyName, isLockWeb) != propertyValue)
                    {
                        addMessage(ErrorLevels.Upgrade, propertyName, "Property already exists and will overwrite", parentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.NoError, propertyName, string.Empty, parentMessageId);
                    }
                }
                else
                {
                    iInstallPropertiesSet(propertyName, propertyValue, isLockWeb);

                    addMessage(ErrorLevels.NoError, propertyName, string.Empty, parentMessageId);
                }
            }
            else
            {
                if (oWeb.Properties.ContainsKey(propertyName) && iInstallPropertiesGet(propertyName, isLockWeb) != propertyValue)
                {
                    addMessage(ErrorLevels.Warning, propertyName, "Property already exists and cannot overwrite", parentMessageId);
                }
                else
                {
                    if (!bVerifyOnly)
                    {
                        iInstallPropertiesSet(propertyName, propertyValue, isLockWeb);
                    }

                    addMessage(ErrorLevels.NoError, propertyName, string.Empty, parentMessageId);
                }
            }
        }
    }
}