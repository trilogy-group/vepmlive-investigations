using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Fakes;

namespace EPMLiveCore.API.Tests
{
    [TestClass()]
    public class AnalyticsDataTests
    {
        [TestMethod()]
        public void ListIdTest()
        {
            var testParams = "<Data>" +
                "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                        "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
                "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
              "</Data>";

            var analyticsData = new AnalyticsData(testParams, AnalyticsType.Favorite, AnalyticsAction.Read);
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (w) =>
                {
                    w();
                };

                ShimSPSite.ConstructorGuid = (instance, guid) =>
                {
                    ShimSPSite moledInstance = new ShimSPSite(instance);
                    moledInstance.Dispose = () => { };
                    moledInstance.OpenWebGuid = (guid1) =>
                    {
                        ShimSPWeb web = new ShimSPWeb();
                        web.Dispose = () => { };
                        web.UsersGet = () =>
                        {
                            ShimSPUserCollection users = new ShimSPUserCollection();
                            users.CountGet = () => 0;
                            return users;
                        };
                        web.ListsGet = () =>
                        {
                            ShimSPListCollection lists = new ShimSPListCollection();
                            lists.ItemGetGuid = (guid2) =>
                            {
                                ShimSPList list = new ShimSPList();
                                //list.TitleGet = () => { return listTitle; };
                                list.HiddenGet = () => { return false; };
                                return list;
                            };

                            return lists;
                        };

                        return web;
                    };
                };


                Assert.AreEqual(analyticsData.ListId, new Guid("5D592B57-C072-4B36-8809-11262120484D"));
                Assert.AreEqual(analyticsData.WebId, new Guid("1A8F7946-CCA1-4A24-8785-CE8E32D012BE"));
                Assert.AreEqual(analyticsData.SiteId, new Guid("7F316E11-C842-4440-9918-39A8F1C12DA9"));

                //Isolate.Fake.StaticConstructor(typeof(SPSecurity));
                //Isolate.WhenCalled(() => SPSecurity.RunWithElevatedPrivileges(() => { })).DoInstead((ctx) => Console.WriteLine("called"));
                //var fakeSite = Isolate.Fake.NextInstance<SPSite>();

                Assert.AreEqual(analyticsData.Icon, "icon-file-5");
            }
        }

        [TestMethod()]
        public void AnalyticsDataTest()
        {
            var testParams = "<Data>" +
                     "<Param key=\"FString\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                   "</Data>";

            var analyticsData = new AnalyticsData(testParams, AnalyticsType.Favorite, AnalyticsAction.Read);
            Assert.AreEqual(analyticsData.FString, "7F316E11-C842-4440-9918-39A8F1C12DA9");
        }
    }
}