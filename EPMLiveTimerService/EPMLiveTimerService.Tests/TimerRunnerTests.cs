using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint.Administration;
using TimerService.Fakes;
using Microsoft.SharePoint.Administration.Fakes;

namespace TimerService.Tests
{
    [TestClass()]
    public class TimerRunnerTests
    {
        [TestMethod()]
        public void startTimerTest()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {

                int opencon = 0;
                int closecon = 0;
                ShimSqlConnection.AllInstances.Open = (instance) =>
                {
                    opencon++;
                };
                ShimSqlConnection.AllInstances.Close = (instance) =>
                {
                    closecon++;
                };
                
                ShimTimerRunner.GetWebApplications = () =>
                {
                    SPWebApplicationCollection webapp = new SPWebApplicationCollection(new SPWebService());
                    webapp.Add(new ShimSPWebApplication());
                    webapp.Add(new ShimSPWebApplication());
                    return webapp;
                };
                
                TimerRunner tr = new TimerRunner();
                tr.startTimer();

              
            }
        }
    }
}