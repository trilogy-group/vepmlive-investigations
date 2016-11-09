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
using System.Data.SqlClient;

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

                var openedConnections = 0;
                var closedConnections = 0;

                ShimSqlConnection.ConstructorString = (instance, connString) =>
                 {
                     var connection = new ShimSqlConnection(instance);
                     connection.Open = () => { openedConnections++; };
                     connection.Close = () => { closedConnections++; };
                 };

                ShimSqlCommand.ConstructorStringSqlConnection = (instance, cmdText, sqlConnection) =>
                {
                    ShimSqlCommand sqlCommand = new ShimSqlCommand(instance);
                    sqlCommand.ParametersGet = () =>
                    {
                        var realSqlCommand = new SqlCommand();
                        return realSqlCommand.Parameters;
                    };
                    ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance1) =>
                   {
                       return 1;
                   };
                };


                ShimCoreFunctions.setConnectionStringGuidStringStringOut = (Guid gWebApp, string cn, out string sError) =>
                   {
                       sError = "";
                       return true;
                   };
                string error = "";
                Assert.IsTrue(createEPMLiveDB.CreateEPMLiveDatabase(webApplicationId, "win-6j09gf4nbp8", "EPMLive2", "", "", out error));
                Assert.AreEqual(openedConnections, closedConnections);
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
                    return "";
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

                string error = "";
                Assert.IsFalse(createEPMLiveDB.CreateEPMLiveDatabase(webApplicationId, "win-6j09gf4nbp8", "EPMLive2", "", "", out error));
            }
        }
    }
}