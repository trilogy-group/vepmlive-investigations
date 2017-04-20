using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkEnginePPM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using System.Data.SqlClient.Fakes;
using EPMLiveCore.Fakes;
using System.Data.SqlClient;
namespace WorkEnginePPM.Tests
{
    [TestClass()]
    public class EPKIntegrationEventsTests
    {
        [TestMethod()]
        public void UpdateProjectTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimSPItemEventProperties shimitemeveprop = new ShimSPItemEventProperties()
                {
                    WebGet = () =>
                    {
                        return new ShimSPWeb()
                        {
                            SiteGet = () =>
                            {
                                return new ShimSPSite()
                                {
                                    IDGet = () =>
                                    {
                                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                                    },
                                    WebApplicationGet = () =>
                                    {
                                        var webApp = new ShimSPWebApplication();
                                        var persistedObject = new ShimSPPersistedObject(webApp);
                                        persistedObject.IdGet = () =>
                                        {
                                            return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86DAA");
                                        };
                                        return webApp;
                                    }
                                };
                            }
                        };
                    },
                   
                    ListItemIdGet = () =>
                    {
                        return 5;
                    },
                    AfterPropertiesGet = () =>
                    {
                        return new ShimSPItemEventDataCollection()
                        {
                            ItemGetString = (str) => { return "Title"; }
                        };
                    }
                };
                ShimSqlConnection.ConstructorString = (instance, connString) =>
                {
                    var connection = new ShimSqlConnection(instance);
                    connection.Open = () => { };
                    connection.Close = () => { };
                };
                ShimCoreFunctions.getReportingConnectionStringGuidGuid = (a, b) => { return ""; };
                ShimSqlCommand.ConstructorStringSqlConnection = (instance, cmdText, sqlConnection) =>
                {
                    ShimSqlCommand sqlCommand = new ShimSqlCommand(instance);
                    sqlCommand.ParametersGet = () =>
                    {
                        var realSqlCommand = new SqlCommand();
                        return realSqlCommand.Parameters;
                    };
                    sqlCommand.ExecuteNonQuery = () => { return 0; };
                };
                ShimSqlParameterCollection collection = new ShimSqlParameterCollection();
               
                EPKIntegrationEvents objtotest = new EPKIntegrationEvents();
                ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (instace, a, c) =>
                {
                    return new SqlParameter();
                };
                objtotest.UpdateProject(shimitemeveprop);
            };
            
        }
    }
}
