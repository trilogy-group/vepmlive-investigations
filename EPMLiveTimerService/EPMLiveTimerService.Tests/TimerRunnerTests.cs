﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using Microsoft.QualityTools.Testing.Fakes;
using System.Threading;

namespace TimerService.Tests
{
   [TestClass]
   //TODO: Change test
    public class TimerRunnerTests
    {
        [TestMethod]
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
                
                ShimProcessorBase.GetWebApplications = () =>
                {
                    SPWebApplicationCollection webapp = new SPWebApplicationCollection(new SPWebService());
                    webapp.Add(new ShimSPWebApplication());
                    webapp.Add(new ShimSPWebApplication());
                    return webapp;
                };
                
                TimerRunner tr = new TimerRunner();
                tr.startTimer();
                Thread.Sleep(60000);
                tr.stopTimer();
                Thread.Sleep(3000);


            }
        }
        [TestMethod]
        public void FaultyTasksTest()
        {
            TestTimerRunner runner = new TestTimerRunner();
            runner.startTimer();
            Thread.Sleep(60000);
            runner.stopTimer();
            Thread.Sleep(3000);
        }
    }
}