using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ProjectPublisher2016
{
    public class EPKTools
    {
        public static void processTeam(string project, string commitments, string url, Microsoft.Office.Interop.MSProject.Project pj)
        {
            FormStatus frmStatus = new FormStatus();
            frmStatus.Show();
            frmStatus.label1.Text = "Downloading Team...";
            frmStatus.Refresh();

            EPKWebService.WebService svc = new EPKWebService.WebService();
            //svc.UseDefaultCredentials = true;
            svc.CookieContainer = new System.Net.CookieContainer();
            //svc.Credentials = System.Net.CredentialCache.DefaultCredentials;
            svc.Url = url + "/_vti_bin/WebService.asmx";
            
            string key = "";

            if (Connection.username == "")
            {
                Connection.username = "";
                svc.Credentials = System.Net.CredentialCache.DefaultCredentials;

                System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal prin = new System.Security.Principal.WindowsPrincipal(wi);
                string sAuthType = prin.Identity.AuthenticationType;
                bool bAuth = prin.Identity.IsAuthenticated;
                key = svc.BeginSession("", "", prin.Identity.Name);

                key = EPKSecurity.BuildAuthString("ToolsTeam", key);
            }
            else
            {
                System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                svc.Credentials = nw;

                key = svc.BeginSession("", "", Connection.domain + "\\" + Connection.username);
                key = EPKSecurity.BuildAuthString("ToolsTeam", key);
            }

            if (RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if (RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if (RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                svc.Proxy = pr;
            }

            string file = System.IO.Path.GetFileName(pj.Name);
            if(file.ToLower().EndsWith(".mpp"))
            {
                file = file.Substring(0, file.Length - 4);
            }

            string ret = svc.XMLRequest("EPKRequest", "<Request><EPKGet><EPKAuth>" + key + "</EPKAuth><ToolsTeam ProjectName=\"" + file + "\" IncludeCommitments=\"" + commitments + "\"/></EPKGet></Request>");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ret);

            if(doc.FirstChild.SelectSingleNode("STATUS").InnerText == "0")
                addMembers(doc.FirstChild.SelectSingleNode("//TeamMembers"), frmStatus, pj);
            else
                System.Windows.Forms.MessageBox.Show("Error Downloading: " + doc.FirstChild.SelectSingleNode("STATUS").InnerText);

            frmStatus.Dispose();
        }

        public static void processNonWork(string project, string url, Microsoft.Office.Interop.MSProject.Project pj)
        {
            FormStatus frmStatus = new FormStatus();
            frmStatus.Show();
            frmStatus.label1.Text = "Downloading Non Work...";
            frmStatus.Refresh();

            EPKWebService.WebService svc = new EPKWebService.WebService();
            //svc.UseDefaultCredentials = true;
            svc.CookieContainer = new System.Net.CookieContainer();
            //svc.Credentials = System.Net.CredentialCache.DefaultCredentials;
            svc.Url = url + "/Services/WebService.asmx";

            string key = "";

            if (Connection.username == "")
            {
                Connection.username = "";
                svc.Credentials = System.Net.CredentialCache.DefaultCredentials;

                System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal prin = new System.Security.Principal.WindowsPrincipal(wi);
                string sAuthType = prin.Identity.AuthenticationType;
                bool bAuth = prin.Identity.IsAuthenticated;
                key = svc.BeginSession("", "", prin.Identity.Name);
                key = EPKSecurity.BuildAuthString("ToolsNonWork", key);
            }
            else
            {
                System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                svc.Credentials = nw;

                key = svc.BeginSession("", "", Connection.domain + "\\" + Connection.username);
                key = EPKSecurity.BuildAuthString("ToolsNonWork", key);
            }

            if (RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if (RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if (RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                svc.Proxy = pr;
            }

            string sResources = "";

            foreach (Microsoft.Office.Interop.MSProject.Resource r in pj.Resources)
            {
                sResources += ",'" + r.Name + "'";
            }

            sResources = sResources.Trim(',');

            string ret = svc.XMLRequest("EPKRequest", "<Request><EPKGet><EPKAuth>" + key + "</EPKAuth><ToolsNonWork><ResList>" + sResources + "</ResList></ToolsNonWork></EPKGet></Request>");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ret);

            if (doc.FirstChild.SelectSingleNode("STATUS").InnerText == "0")
            {
                addNonWork(doc.FirstChild.SelectSingleNode("//Resources"), frmStatus, pj);
                frmStatus.Dispose();
            }
            else
            {
                frmStatus.Dispose();
                System.Windows.Forms.MessageBox.Show("Error Downloading: " + doc.FirstChild.SelectSingleNode("Error").InnerText);
            }
        }

        private static void addNonWork(XmlNode ndTeam, FormStatus frmStatus, Microsoft.Office.Interop.MSProject.Project pj)
        {
            try
            {
                XmlNodeList ndTeamMembers = ndTeam.SelectNodes("Resource");
                frmStatus.progressBar1.Maximum = ndTeamMembers.Count;
                int counter = 0;

                foreach (XmlNode ndTeamMember in ndTeamMembers)
                {
                    frmStatus.label1.Text = "Processing " + ndTeamMember.Attributes["ResourceName"].Value;
                    frmStatus.Refresh();

                    XmlNode ndNonWork = ndTeamMember.SelectSingleNode("NonWorkEntries");

                    if (ndNonWork.ChildNodes.Count > 0)
                        addNonWork(pj, ndNonWork, ndTeamMember.Attributes["ResourceName"].Value);

                    counter++;
                    frmStatus.progressBar1.Value = counter;
                    frmStatus.Refresh();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }

        private static void addMembers(XmlNode ndTeam, FormStatus frmStatus, Microsoft.Office.Interop.MSProject.Project pj)
        {
            try
            {
                XmlNodeList ndTeamMembers = ndTeam.SelectNodes("TeamMember");
                frmStatus.progressBar1.Maximum = ndTeamMembers.Count;
                int counter = 0;

                foreach (XmlNode ndTeamMember in ndTeamMembers)
                {
                    frmStatus.label1.Text = "Processing " + ndTeamMember.Attributes["ResourceName"].Value;
                    frmStatus.Refresh();
 
                    bool found = false;

                    foreach (Microsoft.Office.Interop.MSProject.Resource r in pj.Resources)
                    {
                        if (r.Name == ndTeamMember.Attributes["ResourceName"].Value)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        pj.Resources.Add(ndTeamMember.Attributes["ResourceName"].Value, Type.Missing);

                    XmlNode ndCommitments = ndTeamMember.SelectSingleNode("Commitments");

                    if (ndCommitments != null && ndCommitments.ChildNodes.Count > 0)
                        addCommitments(pj, ndCommitments, ndTeamMember.Attributes["ResourceName"].Value);

                    XmlNode ndNonWork = ndTeamMember.SelectSingleNode("NonWork");

                    if (ndNonWork != null && ndNonWork.ChildNodes.Count > 0)
                        addNonWork(pj, ndNonWork, ndTeamMember.Attributes["ResourceName"].Value);

                    counter++;
                    frmStatus.progressBar1.Value = counter;
                    frmStatus.Refresh();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }

        private static void addNonWork(Microsoft.Office.Interop.MSProject.Project p, XmlNode ndNonWorkEntries, string resname)
        {
            foreach (Microsoft.Office.Interop.MSProject.Resource r in p.Resources)
            {
                if (resname == r.Name)
                {
                    foreach (XmlNode nd in ndNonWorkEntries.SelectNodes("NonWorkEntry"))
                    {
                        try
                        {
                            r.Calendar.Exceptions.Add(Microsoft.Office.Interop.MSProject.PjExceptionType.pjDaily, DateTime.Parse(nd.Attributes["WorkDate"].Value), DateTime.Parse(nd.Attributes["WorkDate"].Value));
                        }
                        catch { }
                    }
                }
            }
        }

        private static void addCommitments(Microsoft.Office.Interop.MSProject.Project p, XmlNode ndCommitments, string resname)
        {
            foreach (Microsoft.Office.Interop.MSProject.Resource r in p.Resources)
            {
                if (resname == r.Name)
                {
                    foreach (Microsoft.Office.Interop.MSProject.Availability a in r.Availabilities)
                    {
                        a.Delete();
                    }

                    foreach (Microsoft.Office.Interop.MSProject.Assignment a in r.Assignments)
                    {
                        if (a.Summary == "Yes")
                            a.Delete();
                    }

                    foreach (XmlNode ndCommitment in ndCommitments.ChildNodes)
                    {
                        DateTime start = DateTime.Parse(ndCommitment.Attributes["StartDate"].Value);
                        DateTime finish = DateTime.Parse(ndCommitment.Attributes["FinishDate"].Value);
                        string fte = ndCommitment.Attributes["FTEPct"].Value;

                        r.Availabilities.Add(start.ToString(), finish.ToString(), float.Parse(fte) / 100.00);
                    }
                }
            }
        }
    }
}
