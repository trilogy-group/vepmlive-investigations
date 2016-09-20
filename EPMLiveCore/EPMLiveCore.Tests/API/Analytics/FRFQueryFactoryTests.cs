using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EPMLiveCore.API.Tests
{
    [TestClass()]
    public class FRFQueryFactoryTests
    {
        [TestMethod()]
        public void GetQueryTest()
        {
            var testParams = new string[] { "<Data>" +
                    "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                            "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
                    "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
                  "</Data>", "<Data>" +
                    "<Param key=\"SiteId\">7F316E11-C842-4440-9918-39A8F1C12DA9</Param>" +
                            "<Param key=\"WebId\">1A8F7946-CCA1-4A24-8785-CE8E32D012BE</Param>" +
                    "<Param key=\"ListId\">5D592B57-C072-4B36-8809-11262120484D</Param>" +
                    "<Param key=\"IsItem\">true</Param>" +
                  "</Data>" };

            var aTypes = Enum.GetValues(typeof(AnalyticsType)).Cast<AnalyticsType>();
            var aActions = Enum.GetValues(typeof(AnalyticsAction)).Cast<AnalyticsAction>();

            foreach (var aType in aTypes)
            {
                foreach (var aAction in aActions)
                {
                    foreach (var param in testParams)
                    {
                        var ad = new AnalyticsData(param, aType, aAction);

                        if (aAction == AnalyticsAction.Update && aType == AnalyticsType.Favorite ||
                            aAction == AnalyticsAction.Update && aType == AnalyticsType.FavoriteWorkspace ||
                            aAction == AnalyticsAction.Update && aType == AnalyticsType.Recent ||
                            aAction == AnalyticsAction.Delete && aType == AnalyticsType.Recent ||
                            aAction == AnalyticsAction.Read && aType == AnalyticsType.Recent)
                            Assert.IsTrue(string.IsNullOrEmpty(FRFQueryFactory.GetQuery(ad)));
                        else
                            Assert.IsFalse(string.IsNullOrEmpty(FRFQueryFactory.GetQuery(ad)));
                    }                    
                }
            }
        }
    }
}