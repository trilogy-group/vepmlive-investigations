using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for Connection.
	/// </summary>
	public class Connection
	{
		public Connection()
		{
			
		}

		public static string fullUsername;
		public static string username;
		public static string password;
        
		public static string resUrl;
		public static string domain;
		public static string url;
		public static string webId;
		public static string title;
		public static Microsoft.Office.Interop.MSProject.Application app;
        public static Dictionary<string, SPSAuthentication.AuthenticationMode> dAuthModes = new Dictionary<string, SPSAuthentication.AuthenticationMode>();
        public static Dictionary<string, CookieCollection> dAuthCookies = new Dictionary<string, CookieCollection>();


		public static string getProjectName(Microsoft.Office.Interop.MSProject.Project pj)
		{
			string name = pj.Name;
			int loc = name.LastIndexOf("/");
			if(loc > 0)
			{
				name = name.Substring(loc+1);	
			}
			name = name.Replace(".mpp","");
			name = name.Replace(".MPP","");
			name = name.Replace("%20"," ");
			return name;
		}

        /// <summary>
        /// EPML-5188 : Get Project ID by Project Title.
        /// </summary>
        /// <param name="pj"></param>
        /// <returns>Project Id</returns>
        public static string getProjectIdByTitle(Microsoft.Office.Interop.MSProject.Project pj)
        {
            string projectId = string.Empty;
            SPSLists.Lists spList = Connection.GetListService(url);

            XmlDocument xmlDoc = new System.Xml.XmlDocument();

            XmlNode tmpPJList = spList.GetList("Project Center");
            string pjguid = tmpPJList.Attributes["Name"].Value;

            XmlDocument xmlPJDoc = new System.Xml.XmlDocument();
            XmlNode ndPJQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
            XmlNode ndPJViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
            XmlNode ndPJQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            ndPJViewFields.InnerXml =
                "<FieldRef Name=\"Title\"/><FieldRef Name=\"Id\"/>";

            ndPJQuery.InnerXml = "<Where><Eq><FieldRef Name=\"Title\" /><Value Type=\"Text\"><![CDATA[" + getProjectName(pj) + "]]></Value></Eq></Where>";

            XmlNode ndPJListItems = spList.GetListItems(pjguid, string.Empty, ndPJQuery, ndPJViewFields, "10", ndPJQueryOptions, string.Empty);
            if (ndPJListItems.OuterXml.Trim() != "" && ndPJListItems.ChildNodes[1].Attributes["ItemCount"].Value != "0")
                projectId = ndPJListItems.ChildNodes[1].ChildNodes[1].Attributes["ows_ID"].Value;

            return projectId;
        }

        public static string GetServerUrl(string url)
        {
            try
            {
                return url.Substring(0, url.IndexOf("/", 10)).ToLower();
            }
            catch { }
            return url;
        }

        public static SPSSiteData.SiteData GetSiteDataService(string url)
        {
            SPSSiteData.SiteData spList = new SPSSiteData.SiteData();
            spList.Url = url + "/_vti_bin/sitedata.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;
        }

        public static EPMLivePortfolioEngine.PortfolioEngineAPI GetPortfolioEngineService(string url)
        {
            EPMLivePortfolioEngine.PortfolioEngineAPI spList = new EPMLivePortfolioEngine.PortfolioEngineAPI();
            spList.Url = url + "/_vti_bin/portfolioengine.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;
        }

        public static SPSLists.Lists GetListService(string url)
        {
            SPSLists.Lists spList = new SPSLists.Lists();
            spList.Url = url + "/_vti_bin/lists.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static SPSViews.Views GetViewsService(string url)
        {
            SPSViews.Views spList = new SPSViews.Views();
            spList.Url = url + "/_vti_bin/views.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static EPMLiveTimePhased.EPMLiveTimePhased GetTimePhasedService(string url)
        {
            EPMLiveTimePhased.EPMLiveTimePhased spList = new EPMLiveTimePhased.EPMLiveTimePhased();
            spList.Url = url + "/_vti_bin/epmlivetimephased.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static SPSUserGroup.UserGroup GetUserGroupService(string url)
        {
            SPSUserGroup.UserGroup spList = new SPSUserGroup.UserGroup();
            spList.Url = url + "/_vti_bin/usergroup.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static WSSService.Service GetWSSService(string url)
        {
            WSSService.Service spList = new WSSService.Service();
            spList.Url = url + "/_vti_bin/service.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static EPMLivePublisher.EPMLivePublisher GetPublisherService(string url)
        {
            EPMLivePublisher.EPMLivePublisher spList = new EPMLivePublisher.EPMLivePublisher();
            spList.Url = url + "/_vti_bin/epmlivepublisher.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static EPMLiveIntegration.Integration GetIntegrationService(string url)
        {
            EPMLiveIntegration.Integration spList = new EPMLiveIntegration.Integration();
            spList.Url = url + "/_vti_bin/integration.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }

            return spList;

        }

        public static EPMLiveWorkEngine.WorkEngineAPI GetWorkEngineService(string url)
        {
            EPMLiveWorkEngine.WorkEngineAPI spList = new EPMLiveWorkEngine.WorkEngineAPI();
            spList.Url = url + "/_vti_bin/workengine.asmx";

            url = GetServerUrl(url);

            if(Connection.dAuthModes.ContainsKey(url) && Connection.dAuthModes[url] == SPSAuthentication.AuthenticationMode.Forms)
            {
                spList.CookieContainer = new CookieContainer();
                spList.CookieContainer.Add(dAuthCookies[url]);
            }
            else
            {
                if(Connection.username == "")
                {
                    Connection.username = "";
                    spList.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                    spList.Credentials = nw;
                }
            }
            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                spList.Proxy = pr;
            }
            spList.Timeout = 300000;
            return spList;

        }

        public static void GetAuthMode(string url)
        {
            System.Net.CookieCollection cookies = null;
            string sUrl = GetServerUrl(url);

            try
            {
                if(dAuthCookies.ContainsKey(sUrl))
                {
                    cookies = dAuthCookies[sUrl];
                }
                else
                {
                    cookies = ClaimClientContext.GetAuthenticatedCookies(url, 0, 0);
                    if(cookies != null)
                    {
                        if(!dAuthCookies.ContainsKey(sUrl))
                            dAuthCookies.Add(sUrl, cookies);
                        else
                            dAuthCookies[sUrl] = cookies;
                    }
                }

                if(cookies != null)
                {
                    dAuthModes[sUrl] = SPSAuthentication.AuthenticationMode.Forms;
                    return;
                }
                else
                {
                    throw new Exception("60000");
                }
            }
            catch(Exception ex)
            {
                if(ex.Message != "70000")
                    throw;
            }

            bool autologgedin = false;

            SPSAuthentication.AuthenticationMode m = SPSAuthentication.AuthenticationMode.None;

            SPSAuthentication.Authentication auth = new SPSAuthentication.Authentication();
            auth.Url = url + "/_vti_bin/authentication.asmx";
            if(Connection.username == "")
            {
                autologgedin = true;
                Connection.username = "";
                auth.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            else
            {
                autologgedin = false;
                System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username, Connection.password, Connection.domain);
                auth.Credentials = nw;
            }

            if(RegistryClass.GetSetting("Tr", "UseProxy", "") == "True")
            {
                System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr", "ProxyServer", "") + ":" + RegistryClass.GetSetting("Tr", "ProxyPort", ""), true);
                if(RegistryClass.GetSetting("Tr", "ProxyAuth", "") == "True")
                    if(RegistryClass.GetSetting("Tr", "ProxyUseWindows", "") == "True")
                        pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    else
                        pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr", "ProxyUsername", ""), RegistryClass.GetSetting("Tr", "ProxyPassword", ""));
                auth.Proxy = pr;
            }

            auth.UseDefaultCredentials = true;

            if(!dAuthModes.ContainsKey(GetServerUrl(url)))
            {
                
                m = auth.Mode();

                try
                {
                    SPSUserGroup.UserGroup ug = Connection.GetUserGroupService(url);
                    System.Xml.XmlNode nd = ug.GetCurrentUserInfo();
                }
                catch { autologgedin = false; }

                if(autologgedin)
                    m = SPSAuthentication.AuthenticationMode.Windows;

                dAuthModes.Add(GetServerUrl(url), m);

                if(m == SPSAuthentication.AuthenticationMode.Forms)
                {
                    if(String.IsNullOrEmpty(Connection.username))
                        throw new Exception("100001");

                    doFormsAuth(url, auth);
                }
            }
            else if(dAuthModes[GetServerUrl(url)] == SPSAuthentication.AuthenticationMode.Forms)
            {
                if(String.IsNullOrEmpty(Connection.username))
                    throw new Exception("100001");

                doFormsAuth(url, auth);
            }
        }

        public static void doFormsAuth(string url, SPSAuthentication.Authentication auth)
        {
            auth.CookieContainer = new CookieContainer();

            SPSAuthentication.LoginResult loginResult = auth.Login(Connection.username, Connection.password);
            Cookie cookie = new Cookie();
            //If login is successfull
            if(loginResult.ErrorCode == SPSAuthentication.LoginErrorCode.NoError)
            {
                CookieCollection cookies = auth.CookieContainer.GetCookies(new Uri(auth.Url));
                cookie = cookies[loginResult.CookieName];

                string sUrl = GetServerUrl(url);

                if(!dAuthCookies.ContainsKey(sUrl))
                {
                    cookies = new CookieCollection();
                    cookies.Add(cookie);
                    dAuthCookies.Add(sUrl, cookies);
                }
                else
                {
                    cookies = new CookieCollection();
                    cookies.Add(cookie);
                    dAuthCookies[sUrl] = cookies;
                }
            }
            else
            {
                throw new Exception("100002");
            }
        }

		public static string connect(bool silent, bool createSite, Microsoft.Office.Interop.MSProject.Project pj, string template)
		{
			FormConnect frmCon = null;
			if(!silent)
			{
				frmCon = new FormConnect();
			}
			try
			{
				if(!silent)
				{
					frmCon.label1.Text = url;
					frmCon.Width = frmCon.label1.Width + 20;
					if(frmCon.Width < 300)
						frmCon.Width = 300;
                    frmCon.Height = 100;
					frmCon.Show();
					frmCon.Refresh();
				}
				else
				{
					app.StatusBar = "Connecting to site: " + url;
				}

                GetAuthMode(url);

				//SPSSiteData._sSiteMetadata metaData;
				SPSSiteData._sWebMetadata webMetaData;
				SPSSiteData._sWebWithTime[] webData;
				SPSSiteData._sListWithTime[] listData;
				SPSSiteData._sFPUrl[] spURL;

				string users;
				//string groups;
				string[] vGroups;
				string[] vRoles;

                SPSSiteData.SiteData siteData = GetSiteDataService(url);
				
				string sUrl = "";
				string siteId = "";

				siteData.GetWeb(out webMetaData, out webData, out listData, out spURL, out users, out vRoles, out vGroups);
				siteData.GetSiteUrl(Connection.url, out sUrl, out siteId);
				title = webMetaData.Title;
				webId = webMetaData.WebID;

				siteData.Dispose();
				try
				{
                    EPMLiveTimePhased.EPMLiveTimePhased epmlivetp = GetTimePhasedService(url);
					
					if(!Connect.isProjServer || app.Profiles.ActiveProfile.Server.ToLower() != Connection.url.ToLower())
					{
						if(!epmlivetp.canPublishToSite())
						{
							if(!silent)
							{
								frmCon.Dispose();
							}
							app.StatusBar = false;
							FormTopLevel frmTL = new FormTopLevel();
							frmTL.ShowDialog();
							frmTL.Dispose();
							return "1";
						}
					}
				}
				catch{}
				if(!silent)
				{
					frmCon.Dispose();
				}
				app.StatusBar = false;

				
				string serverUrl = url;
				try
				{
					serverUrl = serverUrl.Substring(0,serverUrl.IndexOf("/",9));
				}
				catch{}
			
				if(!Connect.logins.Contains(serverUrl))
					Connect.logins.Add(serverUrl, username + "\t" + password + "\t" + domain);

				Hashtable logins = new Hashtable();

                if(fullUsername != null && fullUsername != "")
				{
					string usernames = RegistryClass.GetSetting("Tr","logins","");
					if(usernames == "")
					{
						usernames = fullUsername;
					}
					else
					{
						string []arr = usernames.Split(';');
						foreach(string sUsername in arr)
						{
							try
							{
								logins.Add(sUsername,"");
							}
							catch{}
						}

						if(!logins.Contains(fullUsername))
							usernames = usernames + ";" + fullUsername;
					}

					RegistryClass.SaveSetting("Tr","logins",usernames);
					RegistryClass.SaveSetting("Tr","lastUsername",fullUsername);
				}

				return "0";
			}
			catch(Exception ex)
			{
				app.StatusBar = false;
				if(!silent)
				{
					frmCon.Dispose();
				}
                if(ex.Message == "60000")
                {
                    return "-1";
                }
                else if(ex.Message == "60001")
                {
                    MessageBox.Show("Invalid Site");
                    return "-1";
                }
                //else if(ex.Message == "100001" || ex.Message == "100002" || ex.Message.Contains("E_ACCESSDENIED"))
                else if (ex.Message == "100001" || ex.Message == "100002" || ex.Message.Contains("E_ACCESSDENIED") || ex.Message.Contains("Value cannot be null"))
                {
                    FormAuth frmAuth = new FormAuth();
                    if(Connect.isProjServer)
                        frmAuth.defaultUsername = app.Profiles.ActiveProfile.UserName;

                    if(dAuthModes.ContainsKey(GetServerUrl(url)))
                    {
                        if(dAuthModes[GetServerUrl(url)] == SPSAuthentication.AuthenticationMode.Windows)
                            frmAuth.comboAuthType.SelectedIndex = 1;
                        else if(dAuthModes[GetServerUrl(url)] == SPSAuthentication.AuthenticationMode.Forms)
                            frmAuth.comboAuthType.SelectedIndex = 2;
                    }
                    else
                    {
                        frmAuth.comboAuthType.SelectedIndex = 0;
                    }
                    
                    frmAuth.ShowDialog();

                    if(frmAuth.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        string username = frmAuth.txtUsername.Text;

                        Connection.fullUsername = username;
                        string domain = "";
                        int pos = username.IndexOf('\\');
                        if(pos > 0)
                        {
                            domain = username.Substring(0, pos);
                            username = username.Substring(pos + 1);
                        }

                        Connection.username = username;
                        Connection.password = frmAuth.txtPassword.Text;
                        Connection.domain = domain;

                        if(frmAuth.comboAuthType.Text == "Windows")
                        {
                            if(!dAuthModes.ContainsKey(GetServerUrl(url)))
                            {
                                dAuthModes.Add(GetServerUrl(url), SPSAuthentication.AuthenticationMode.Windows);
                            }
                            else
                            {
                                dAuthModes[GetServerUrl(url)] = SPSAuthentication.AuthenticationMode.Windows;
                            }
                        }
                        else if(frmAuth.comboAuthType.Text == "Forms")
                        {
                            if(!dAuthModes.ContainsKey(GetServerUrl(url)))
                            {
                                dAuthModes.Add(GetServerUrl(url), SPSAuthentication.AuthenticationMode.Forms);
                            }
                            else
                                dAuthModes[GetServerUrl(url)] = SPSAuthentication.AuthenticationMode.Forms;
                        }


                        return connect(silent, createSite, pj, template);
                    }
                    else
                        return "-1";
                }
                else if(ex.Message.ToString().IndexOf("401") > 0)
                {
                    if(dAuthModes.ContainsKey(GetServerUrl(url)))
                        dAuthModes[GetServerUrl(url)] = SPSAuthentication.AuthenticationMode.Windows;
                    else
                        dAuthModes.Add(GetServerUrl(url), SPSAuthentication.AuthenticationMode.Windows);

                    FormAuth frmAuth = new FormAuth();

                    if(dAuthModes.ContainsKey(GetServerUrl(url)))
                    {
                        if(dAuthModes[GetServerUrl(url)] == SPSAuthentication.AuthenticationMode.Windows)
                            frmAuth.comboAuthType.SelectedIndex = 1;
                        else if(dAuthModes[GetServerUrl(url)] == SPSAuthentication.AuthenticationMode.Forms)
                            frmAuth.comboAuthType.SelectedIndex = 2;
                    }
                    else
                    {
                        frmAuth.comboAuthType.SelectedIndex = 0;
                    }

                    if(Connect.isProjServer)
                        frmAuth.defaultUsername = app.Profiles.ActiveProfile.UserName;
                    frmAuth.ShowDialog();
                    if(frmAuth.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        string username = frmAuth.txtUsername.Text;

                        Connection.fullUsername = username;
                        string domain = "";
                        int pos = username.IndexOf('\\');
                        if(pos > 0)
                        {
                            domain = username.Substring(0, pos);
                            username = username.Substring(pos + 1);
                        }
                        Connection.username = username;
                        Connection.password = frmAuth.txtPassword.Text;
                        Connection.domain = domain;

                        if(frmAuth.comboAuthType.Text == "Windows")
                        {
                            if(!dAuthModes.ContainsKey(GetServerUrl(url)))
                            {
                                dAuthModes.Add(GetServerUrl(url), SPSAuthentication.AuthenticationMode.Windows);
                            }
                            else
                            {
                                dAuthModes[GetServerUrl(url)] = SPSAuthentication.AuthenticationMode.Windows;
                            }
                        }
                        else if(frmAuth.comboAuthType.Text == "Forms")
                        {
                            if(!dAuthModes.ContainsKey(GetServerUrl(url)))
                            {
                                dAuthModes.Add(GetServerUrl(url), SPSAuthentication.AuthenticationMode.Forms);
                            }
                            else
                                dAuthModes[GetServerUrl(url)] = SPSAuthentication.AuthenticationMode.Forms;
                        }

                        return connect(silent, createSite, pj, template);
                    }
                    else
                        return "-1";
                }
                else if(ex.Message.ToString().IndexOf("remote name could not be resolved") > 0)
                {
                    MessageBox.Show("That site doesn't appear to be valid SharePoint site.");
                    return "-1";
                }
                else if(ex.Message.ToString().IndexOf("501") > 0)
                {
                    MessageBox.Show("That site doesn't appear to be valid SharePoint site. (501)");
                    return "-1";
                }
                else if(ex.Message.ToString().IndexOf("404") > 0)
                {
                    if(createSite)
                    {
                        FormStatus frmStatus = new FormStatus();
                        frmStatus.label1.Text = "Creating Site...";
                        frmStatus.Show();
                        frmStatus.Refresh();

                        bool success = Connection.createSite(url, pj, template);

                        frmStatus.Dispose();

                        if(success)
                            return connect(silent, createSite, pj, template);
                        else
                        {
                            MessageBox.Show("Failed to Create Site");
                            createSite = false;
                            return "-1";
                        }
                    }
                    else
                    {
                        MessageBox.Show("That site doesn't appear to be valid SharePoint site. (404)");
                        return "-1";
                    }
                }
                else if(ex.Message.ToString().IndexOf("Object Moved") > 0)
                {
                    MessageBox.Show("It appears that your site has moved. Please check your URL.");
                    return "-1";
                }
                else
                {
                    MessageBox.Show("Error Connecting: " + ex.Message.ToString());
                    return ex.Message.ToString();
                }
			}
		}

		public static bool createSite(string url, Microsoft.Office.Interop.MSProject.Project pj, string template)
		{
            EPMLivePublisher.EPMLivePublisher pub = GetPublisherService(url);
			pub.Url = pj.Application.Profiles.ActiveProfile.Server + "/_vti_bin/epmlivepublisher.asmx";;
			
			bool ret;
			if(Connect.isVersionGreaterOrEqual(pub.getFileVersion(),"2.2.1.0"))
			{
				if(template == "")
					ret = pub.createSite(url.ToLower(),pj.Title.ToString());
				else
					ret = pub.createSiteWithTemplate(url.ToLower(),pj.Title.ToString(), template);
			}
			else
			{
				if(template == "")
					ret = pub.createSite(url.ToLower().Replace(app.Profiles.ActiveProfile.Server.ToLower(),""),pj.Title.ToString());
				else
					ret = pub.createSiteWithTemplate(url.ToLower().Replace(pj.Application.Profiles.ActiveProfile.Server.ToLower(),""),pj.Title.ToString(), template);
			}
			pub.Dispose();

			
			return ret;
			
		}
	}
}
