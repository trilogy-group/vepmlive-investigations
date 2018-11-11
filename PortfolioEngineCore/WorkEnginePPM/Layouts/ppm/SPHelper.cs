using System;
using System.Web.UI.WebControls;
using System.Xml;

namespace WorkEnginePPM
{
    public class SPHelper
    {
        internal static bool ExecuteProcess(string context, string xmlRequest, out XmlNode node)
        {
            node = null;
            return ExecuteProcessEx(context, xmlRequest, out node);
        }

        internal static bool ExecuteProcessEx(string context, string xmlRequest, out XmlNode node)
        {
            node = null;
            using (var integration = new Integration())
            {
                node = integration.execute(context, xmlRequest);
            }
            return true;
        }

        internal static void PopulateStatus(
            Label errorLabel,
            Label lastRunLabel,
            Label lastRunResultLabel,
            Label statusLabel,
            Label logLabel = null)
        {
            XmlNode statusNode;
            if (ExecuteProcess("GetTimerStatus", "<Status Schedule=\"10\"/>", out statusNode) == false)
            {
                if(errorLabel == null)
                {
                    throw new InvalidOperationException(string.Format("{0} is null", nameof(errorLabel)));
                }
                errorLabel.Text = "Error populateStatus : GetTimerStatus";
                errorLabel.Visible = true;
                return;
            }
            if (statusNode.Attributes["Status"].Value == "0")
            {
                var ndTimer = statusNode.SelectSingleNode("Timer");
                if (ndTimer != null)
                {
                    if (statusLabel != null)
                    {
                        switch (ndTimer.Attributes["Status"].Value)
                        {
                            case "0":
                                statusLabel.Text = "Queued";
                                break;
                            case "1":
                                statusLabel.Text = string.Format("Processing ({0}%)", ndTimer.Attributes["PercentComplete"].Value);
                                break;
                            case "2":
                                statusLabel.Text = "Complete";
                                break;
                        }
                    }

                    if (lastRunLabel != null)
                    {
                        lastRunLabel.Text = ndTimer.Attributes["LastRun"].Value;
                    }
                    if (lastRunResultLabel != null)
                    {
                        lastRunResultLabel.Text = ndTimer.Attributes["LastResult"].Value;
                    }
                    if (logLabel != null)
                    {
                        logLabel.Text = ndTimer.InnerText;
                    }
                }
            }
            else
            {
                if (errorLabel != null)
                {
                    errorLabel.Text = string.Format("Error Getting Status: {0}", statusNode.SelectSingleNode("Error").InnerText);
                    errorLabel.Visible = true;
                }
            }
        }
    }
}