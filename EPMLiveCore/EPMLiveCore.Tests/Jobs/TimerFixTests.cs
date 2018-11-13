using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass]
    public class TimerFixTests
    {
        private TimerFix timerFix;
        private IDisposable shimsContext;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            timerFix = new TimerFix();
            privateObject = new PrivateObject(timerFix);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimResourcePlan.BuildResourceInfoDataTable = () => new DataTable();
            ShimResourcePlan.BuildResourceLinkDataTable = () => new DataTable();
            ShimTimerFix.AllInstances.storeResPlanInfo = _ => { };
        }

        [TestMethod]
        public void Execute_OnSuccess_ExecuteCorrectly()
        {
            // Arrange
            var expectedCommands = new List<string>
            {
                "update queue set status = 2, dtfinished=GETDATE() where timerjobuid=@timerjobuid",
                "DELETE FROM EPMLIVE_LOG where timerjobuid=@timerjobuid",
                "INSERT INTO EPMLIVE_LOG (timerjobuid,result,resulttext) VALUES (@timerjobuid,@result,@resulttext)",
                "DELETE FROM RESINFO where siteid=@siteid",
                "DELETE FROM RESLINK where siteid=@siteid or siteid in (select siteid from reslink where weburl=@weburl)",
                "select timerjobuid from vwQueueTimer where siteguid=@siteguid and jobtype=1"
            };
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 1,
                        WorkDayEndHourGet = () => 2,
                        WorkDaysGet = () => 2
                    }
                },
                AllWebsGet = () => 
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            };
            var web = new ShimSPWeb();
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = ProcessWeb;
            ShimTimerFix.AllInstances.processResPlanSPWebStringGuidInt32String = 
                (_, spWeb, lists, id, hours, days) => { };
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimBaseJob.AllInstances.initJobSPSite = (_, spSite) => true;
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, setting) => "";
            ShimBaseJob.AllInstances.CreateConnection = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executedCommands.Add(command.CommandText);
                return new ShimSqlDataReader
                {
                    Read = () => true,
                    GetGuidInt32 = index => Guid.NewGuid()
                };
            };

            // Act
            timerFix.execute(site, web, string.Empty);

            // Assert
            expectedCommands.All(cmd => executedCommands.Contains(cmd)).ShouldBeTrue();
        }


        [TestMethod]
        public void Execute_OnException_ExecutesCorrectly()
        {
            // Arrange
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 1,
                        WorkDayEndHourGet = () => 2,
                        WorkDaysGet = () => 2
                    }
                },
                AllWebsGet = () =>
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            };
            var web = new ShimSPWeb();
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = ProcessWeb;
            ShimTimerFix.AllInstances.processResPlanSPWebStringGuidInt32String =
                (_, spWeb, lists, id, hours, days) => { };
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimBaseJob.AllInstances.initJobSPSite = (_, spSite) => true;
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, setting) => "";
            ShimBaseJob.AllInstances.CreateConnection = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => 
            {
                throw new Exception();
            };
            ShimResourcePlan.BuildResourceLinkDataTable = () =>
            {
                throw new Exception();
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executedCommands.Add(command.CommandText);
                return new ShimSqlDataReader
                {
                    Read = () => true,
                    GetGuidInt32 = index => Guid.NewGuid()
                };
            };

            // Act
            timerFix.execute(site, web, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => timerFix.bErrors.ShouldBeTrue(),
                () => timerFix.sErrors.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void Execute_OnGeneralException_ShoudlThrowException()
        {
            // Arrange
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () =>
                {
                    throw new Exception();
                }
            };
            var web = new ShimSPWeb();

            // Act
            Action action = () => timerFix.execute(site, web, string.Empty);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void Execute_InitiJobFalse_NoActionTaken()
        {
            // Arrange
            var executedCommands = new List<string>();
            var site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 1,
                        WorkDayEndHourGet = () => 2,
                        WorkDaysGet = () => 2
                    }
                },
                AllWebsGet = () =>
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb()
                    }.AsEnumerable();
                    return new ShimSPWebCollection().Bind(list);
                }
            };
            var web = new ShimSPWeb();
            ShimBaseJob.AllInstances.initJobSPSite = (_, spSite) => false;
            ShimTimerFix.AllInstances.processWebSPWebStringSingleRef = ProcessWeb;
            ShimTimerFix.AllInstances.processResPlanSPWebStringGuidInt32String =
                (_, spWeb, lists, id, hours, days) => { };
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, setting) => "";
            ShimBaseJob.AllInstances.CreateConnection = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executedCommands.Add(command.CommandText);
                return new ShimSqlDataReader
                {
                    Read = () => true,
                    GetGuidInt32 = index => Guid.NewGuid()
                };
            };

            // Act
            timerFix.execute(site, web, string.Empty);

            // Assert
            executedCommands.ShouldBeEmpty();
        }

        private void ProcessWeb(TimerFix arg1, SPWeb arg2, string arg3, ref float @ref)
        {
            @ref++;
        }
    }
}
