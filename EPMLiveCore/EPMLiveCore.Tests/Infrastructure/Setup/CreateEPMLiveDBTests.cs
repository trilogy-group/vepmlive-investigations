using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.Infrastructure.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Administration.Fakes;
using System.Data.SqlClient.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Setup.Fakes;

namespace EPMLiveCore.Infrastructure.Setup.Tests
{
    [TestClass()]
    public class CreateEPMLiveDBTests
    {
        protected string output = string.Empty;
        [TestMethod()]
        public void CreateEPMLiveDBTest_Sucess()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                Guid webApplicationId = Guid.NewGuid();
                CreateEPMLiveDB createEPMLiveDB = new CreateEPMLiveDB();

                ShimSPWebApplication.AllInstances.ApplicationPoolGet = (instance) =>
                {
                    return new ShimSPApplicationPool();
                };

                ShimSPPersistedObject.AllInstances.IdGet = (instance) =>
                {
                    return webApplicationId;
                };

                ShimSPProcessIdentity.AllInstances.UsernameGet = (instance) =>
                {
                    return "epmldev\farmadmin";
                };

                ShimCreateEPMLiveDB.AllInstances.GetWebApplicationGuid = (instance, a) =>
                {
                    return new ShimSPWebApplication();
                };

                ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
                {
                    return 1;
                };

                ShimCoreFunctions.setConnectionStringGuidStringStringOut = (Guid gWebApp, string cn, out string sError) =>
                {
                    sError = "";
                    return true;
                };

                Assert.AreEqual(createEPMLiveDB.CreateEPMLiveDatabase(webApplicationId, "win-6j09gf4nbp8", "EPMLive1", "", ""), "Sucess");
            }
        }

        [TestMethod()]
        public void CreateEPMLiveDBTest_Fail()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                Guid webApplicationId = Guid.NewGuid();
                CreateEPMLiveDB createEPMLiveDB = new CreateEPMLiveDB();

                ShimSPWebApplication.AllInstances.ApplicationPoolGet = (instance) =>
                {
                    return new ShimSPApplicationPool();
                };

                ShimSPPersistedObject.AllInstances.IdGet = (instance) =>
                {
                    return webApplicationId;
                };

                ShimSPProcessIdentity.AllInstances.UsernameGet = (instance) =>
                {
                    return "epmldev\farmadmin";
                };

                ShimCreateEPMLiveDB.AllInstances.GetWebApplicationGuid = (instance, a) =>
                {
                    return new ShimSPWebApplication();
                };

                ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
                {
                    return 1;
                };

                ShimCoreFunctions.setConnectionStringGuidStringStringOut = (Guid gWebApp, string cn, out string sError) =>
                {
                    sError = "Error";
                    return false;
                };

                Assert.AreEqual(Convert.ToString(createEPMLiveDB.CreateEPMLiveDatabase(webApplicationId, "win-6j09gf4nbp8", "EPMLive1", "", "")), "Error Setting String: Error");             
            }
        }
    }
}