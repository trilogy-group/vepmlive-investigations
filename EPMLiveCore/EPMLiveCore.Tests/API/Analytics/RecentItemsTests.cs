using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint.Fakes;
using System.Collections.Generic;
using EPMLiveCore.ReportingProxy.Fakes;
using System.Data;
using System;

namespace EPMLiveCore.API.Tests
{
    [TestClass()]
    public class RecentItemsTests
    {
        //[TestMethod()]
        //public void Create_SPSiteFailed_Test()
        //{
        //    var testParams = "<Data>" +
        //        "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
        //                "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
        //        "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
        //      "</Data>";

        //    Assert.IsTrue(string.IsNullOrEmpty(RecentItems.Create(testParams)));
        //}

        [TestMethod()]
        public void Create_ValidList_Test()
        {
            var testParams = "<Data>" +
                "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                        "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
                "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
              "</Data>";


            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                PrepareShims("Some list");

                Assert.AreEqual(RecentItems.Create(testParams), "ALFKI");
            }
        }

        [TestMethod()]
        public void Create_ErrorQueryExecuting_Test()
        {
            var testParams = "<Data>" +
                "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                        "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
                "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
              "</Data>";


            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                PrepareShims("Some list" , true);

                Assert.AreEqual(RecentItems.Create(testParams), "error: message");
            }
        }

        [TestMethod()]
        public void Create_NoValidList_Test()
        {
            var testParams = "<Data>" +
                "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                        "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
                "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
              "</Data>";


            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                PrepareShims("My Timesheet");

                Assert.IsTrue(string.IsNullOrEmpty(RecentItems.Create(testParams)));
            }
        }

        private static void PrepareShims(string listTitle, bool generateQueryExecutorError = false)
        {
            System.Web.Fakes.ShimHttpContext.AllInstances.ItemsGet =
                            (e) =>
                            {
                                return new Dictionary<string, object>();
                            };

            System.Web.Fakes.ShimHttpContext.CurrentGet = () =>
            {
                return new System.Web.Fakes.ShimHttpContext();
            };

            System.Web.Fakes.ShimHttpContext.AllInstances.DisableCustomHttpEncoderGet = (instance) =>
            {
                return true;
            };

            string expectedTitle = "Test Site";
            ShimSPSite.BehaveAsNotImplemented();
            ShimSPWeb.BehaveAsNotImplemented();
            ShimSPSite.ConstructorString = (instance, url) =>
            {
                ShimSPSite moledInstance = new ShimSPSite(instance);
                moledInstance.Dispose = () => { };
                moledInstance.OpenWeb = () =>
                {
                    ShimSPWeb web = new ShimSPWeb();
                    web.Dispose = () => { };
                    web.UsersGet = () =>
                    {
                        ShimSPUserCollection users = new ShimSPUserCollection();
                        users.CountGet = () => 0;
                        return users;
                    };
                    return web;
                };
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
                            list.TitleGet = () => { return listTitle; };
                            list.HiddenGet = () => { return false; };
                            return list;
                        };

                        return lists;
                    };

                    return web;
                };
            };

            ShimSPSite.AllInstances.Dispose = (instance) => { };
            ShimSPSite.AllInstances.OpenWeb = (instance) =>
            {
                ShimSPWeb web = new ShimSPWeb();
                web.Dispose = () => { };
                web.TitleGet = () => expectedTitle;
                return web;
            };

            ShimQueryExecutor.ConstructorSPWeb = (instance, spweb) =>
                {
                    ShimQueryExecutor moledInstance = new ShimQueryExecutor(instance);
                    //moledInstance.Dispose = () => { };
                    moledInstance.ExecuteEpmLiveQueryStringIDictionaryOfStringObject = 
                    (str1, dict) => 
                    {
                        if (generateQueryExecutorError)
                            throw new NotImplementedException("message");

                        DataTable dt = new DataTable();
                        DataRow newRow = dt.NewRow();
                        DataColumn newColumn = new DataColumn("CustomerID");
                        dt.Columns.Add(newColumn);
                        newRow["CustomerID"] = "ALFKI";
                        
                        dt.Rows.Add(newRow);
                        return dt;
                    };
                };
        }
    }
}