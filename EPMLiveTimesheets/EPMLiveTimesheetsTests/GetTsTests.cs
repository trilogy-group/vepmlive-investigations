using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;

namespace TimeSheets.Tests
{
    [TestClass()]
    public class GetTsTests
    {
        string webServerUrl = String.Empty;
        string page = "/_layouts/15/epmlive/viewts.aspx";
        string sharePointWebApplication = "SharePoint - 80";
        Boolean useDefaultCredentials = true;
        string userName = String.Empty;
        string password = String.Empty;

        [TestInitialize]
        public void GetTsInitialize()
        {
            var service = SPFarm.Local.Services.GetValue<SPWebService>(string.Empty);
            foreach (SPWebApplication webApplication in service.WebApplications)
            {
                if (webApplication.Name.Contains(sharePointWebApplication))
                {
                    using (SPSite spSite = webApplication.Sites[0])
                    {
                        webServerUrl = spSite.Url;
                    }
                }
            }
        }

        [TestMethod()]
        public void GetTs_PageLoad_RespondedTest()
        {
            string result = GetPage("period_id=1");
            Assert.IsTrue(result.IndexOf("Delete Timesheet(s)") != -1, "Get Ts responsed.");
        }

        [TestMethod()]
        public void GetTs_PageLoad_Failed_Without_QueryStringTest()
        {
            string result = GetPage(String.Empty);
            Assert.IsTrue(result.IndexOf("Delete Timesheet(s)") == -1, "Get Ts didn't responsed.");
        }

        [TestMethod()]
        public void GetTs_PageLoad_Failed_With_Unwanted_QueryStringTest()
        {
            string result = GetPage("period_id=xyz");
            Assert.IsTrue(result.IndexOf("Delete Timesheet(s)") == -1, "Get Ts didn't responsed.");
        }

        private string GetPage(string queryString)
        {
            if (string.IsNullOrEmpty(webServerUrl))
            {
                Assert.Fail("Sharepoint server or site not found.");
            }
            using (WebClient client = new WebClient())
            {
                if (useDefaultCredentials)
                {
                    client.UseDefaultCredentials = useDefaultCredentials;
                }
                else
                {
                    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    {
                        Assert.Fail("Please provide username and password if not using default credentials.");
                    }
                    client.Credentials = new NetworkCredential(userName, password);
                }
                using (StreamReader reader = new StreamReader(client.OpenRead(string.Format("{0}{1}?{2}", webServerUrl, page, queryString))))
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

    }
}