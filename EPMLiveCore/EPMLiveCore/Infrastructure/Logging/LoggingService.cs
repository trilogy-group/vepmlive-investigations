using Microsoft.SharePoint.Administration;
using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure.Logging
{
    /// <summary>
    /// Provides logging capabilities for sharepoint solutions.  
    /// </summary>
    public class LoggingService : SPDiagnosticsServiceBase
    {
        /// <summary>
        /// Defines EPMLive solution under the hood. Represents custom diagnostic logging category with monitoring in central admin.
        /// </summary>
        public static class Area
        {
            public static string EPMLiveCore = "EPM Live Core";
            public static string EPMLiveWebParts = "EPM Live WebParts";
            public static string EPMLiveWorkPlanner = "EPM Live Work Planner";
            public static string EPMLivePortfolioEngineCore = "EPM Live Portfolio Engine Core";
            public static string EPMLiveReporting = "EPM Live Reporting";
            public static string EPMLiveProjectServer = "EPM Live Project Server";
            public static string EPMLiveTimesheets = "EPM Live Timesheets";
            public static string EPMLiveIntegrationService = "EPM Live Integration Service";
            public static string EPMLiveWorkEnginePPM = "EPM Live WorkEngine PPM";
            public static string EPMLiveDashboards = "EPM Live Dashboards";
            public static string EPMLiveSynch = "EPM Live Synch";
            public static string EPMLiveUplandIntegrations = "EPM Live Upland Integrations";
        }
        /// <summary>
        /// Represents custom sub category under the Area.
        /// </summary>
        public static class Categories
        {
            /// <summary>
            /// Represents EPM Live core solution
            /// </summary>
            public static class EPMLiveCore
            {
                public static string Api = "Api";
                public static string Control = "Control";
                public static string ControlTemplate = "Control Template";
                public static string IntegrationCore = "Integration Core";
                public static string TimerJob = "Timer Job";
                public static string LayoutPage = "Layout Page";
                public static string Upgrader = "Upgrader";
                public static string Event = "Event";
                public static string Webservice = "Webservice";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live webparts solution
            /// </summary>
            public static class EPMLiveWebParts
            {
                public static string Api = "Api";
                public static string Control = "Control";
                public static string LayoutPage = "Layout Page";
                public static string WebPartPage = "WebPart Page";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live work planner solution
            /// </summary>
            public static class EPMLiveWorkPlanner
            {
                public static string TimerJob = "Timer Job";
                public static string LayoutPage = "Layout Page";
                public static string Webservice = "Webservice";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live portfolio engine core solution
            /// </summary>
            public static class EPMLivePortfolioEngineCore
            {
                public static string ControlTemplate = "Control Template";
                public static string DataService = "Data Service";
                public static string Event = "Event";
                public static string TimerJob = "Timer Job";
                public static string LayoutPage = "Layout Page";
                public static string Webservice = "Webservice";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live reporting solution
            /// </summary>
            public static class EPMLiveReporting
            {
                public static string Api = "Api";
                public static string TimerJob = "Timer Job";
                public static string LayoutPage = "Layout Page";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live project server solution
            /// </summary>
            public static class EPMLiveProjectServer
            {
                public static string Event = "Event";
                public static string LayoutPage = "Layout Page";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live timesheet solution
            /// </summary>
            public static class EPMLiveTimesheets
            {
                public static string Api = "Api";
                public static string ControlTemplate = "Control Template";
                public static string TimerJob = "Timer Job";
                public static string LayoutPage = "Layout Page";
                public static string WebPartPage = "WebPart Page";
                public static string Others = "Others";
            }
            /// <summary>
            /// Represents EPM Live integration services solution
            /// </summary>
            public static class EPMLiveIntegrationService
            {
                public static string WebPage = "Web Page";
                public static string WebService = "Web Service";
                public static string Others = "Others";
            }


            /// <summary>
            /// Represents EPM Live workengine ppm solution
            /// </summary>
            public static class EPMLiveWorkEnginePPM
            {
                public static string ControlTemplate = "Control Template";
                public static string Event = "Event";
                public static string TimerJob = "Timer Job";
                public static string WebPartPage = "WebPart Page";
                public static string LayoutPage = "Layout Page";
                public static string Webservice = "Webservice";
                public static string Others = "Others";
            }

            /// <summary>
            /// Represents EPM Live dashboards solution
            /// </summary>
            public static class EPMLiveDashboards
            {
                public static string WebPartPage = "WebPart Page";
                public static string Others = "Others";
            }

            /// <summary>
            /// Represents EPM Live livesynch solution
            /// </summary>
            public static class EPMLiveSynch
            {
                public static string TimerJob = "Timer Job";
                public static string WebPage = "Web Page";
                public static string Others = "Others";
            }

            /// <summary>
            /// Represents EPM Live upland integrations solution
            /// </summary>
            public static class EPMLiveUplandIntegrations
            {
                public static string Service = "Service";
                public static string Integrator = "Integrator";
                public static string Others = "Others";
            }
        }

        public static LoggingService Local
        {
            get
            {
                return SPFarm.Local.Services.GetValue<LoggingService>(DefaultName);
            }
        }

        public static string DefaultName
        {
            get
            {
                return "EPMLive Logging Service";
            }
        }

        public LoggingService()
            : base(DefaultName, SPFarm.Local)
        {
        }

        protected override IEnumerable<SPDiagnosticsArea> ProvideAreas()
        {
            List<SPDiagnosticsArea> areas = new List<SPDiagnosticsArea>
            {
                new SPDiagnosticsArea(Area.EPMLiveCore, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.Api, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.Control, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.ControlTemplate, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.IntegrationCore, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.Upgrader, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.Event, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.Webservice, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveCore.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveWebParts, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveWebParts.Api, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWebParts.Control, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWebParts.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWebParts.WebPartPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWebParts.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveWorkPlanner, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkPlanner.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkPlanner.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkPlanner.Webservice, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkPlanner.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLivePortfolioEngineCore, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.ControlTemplate, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.DataService, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.Event, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.Webservice, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLivePortfolioEngineCore.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                  new SPDiagnosticsArea(Area.EPMLiveReporting, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveReporting.Api, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveReporting.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveReporting.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveReporting.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveProjectServer, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveProjectServer.Event, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveProjectServer.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveProjectServer.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveTimesheets, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveTimesheets.Api, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveTimesheets.ControlTemplate, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveTimesheets.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveTimesheets.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveTimesheets.WebPartPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveTimesheets.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveIntegrationService, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveIntegrationService.WebPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveIntegrationService.WebService, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveIntegrationService.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                  new SPDiagnosticsArea(Area.EPMLiveWorkEnginePPM, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.ControlTemplate, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.Event, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.WebPartPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.LayoutPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.Webservice, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveWorkEnginePPM.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveDashboards, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveDashboards.WebPartPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveDashboards.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveSynch, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveSynch.TimerJob, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveSynch.WebPage, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveSynch.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
                 new SPDiagnosticsArea(Area.EPMLiveUplandIntegrations, 0, 0, false, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(Categories.EPMLiveUplandIntegrations.Service, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveUplandIntegrations.Integrator, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                    new SPDiagnosticsCategory(Categories.EPMLiveUplandIntegrations.Others, null, TraceSeverity.Medium, EventSeverity.Information, 0, 0, false, true),
                }),
            };

            return areas;
        }

        /// <summary>
        /// Write tarce to sharepoint log.
        /// If the given value in the severity parameter is less than the currently configured value for
        /// the category's Trace Level property, the trace is not written to the log.
        /// </summary>
        public static void WriteTrace(string areaName, string categoryName, TraceSeverity traceSeverity, string format, params string[] arg)
        {
            WriteTrace(areaName, categoryName, traceSeverity, string.Format(format, arg));
        }

        /// <summary>
        /// Write tarce to sharepoint log.
        /// If the given value in the severity parameter is less than the currently configured value for
        /// the category's Trace Level property, the trace is not written to the log.
        /// </summary>
        public static void WriteTrace(string areaName, string categoryName, TraceSeverity traceSeverity, string message)
        {

            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                LoggingService service = Local;
                if (service != null)
                {
                    SPDiagnosticsCategory category = service.Areas[areaName].Categories[categoryName];
                    service.WriteTrace(1, category, traceSeverity, message);
                }
            }
            catch { }
        }

        /// <summary>
        /// Write tarce to system's application eventlog.
        /// If the given value in the severity parameter is less than the currently configured value for
        /// the category's Event Level property, the trace is not written to the eventlog.
        /// </summary>
        public static void WriteEvent(string areaName, string categoryName, EventSeverity eventSeverity, string format, params string[] arg)
        {
            WriteEvent(areaName, categoryName, eventSeverity, string.Format(format, arg));
        }

        /// <summary>
        /// Write tarce to system's application eventlog.
        /// If the given value in the severity parameter is less than the currently configured value for
        /// the category's Event Level property, the trace is not written to the eventlog.
        /// </summary>
        public static void WriteEvent(string areaName, string categoryName, EventSeverity eventSeverity, string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            try
            {
                LoggingService service = Local;
                if (service != null)
                {
                    SPDiagnosticsCategory category = service.Areas[areaName].Categories[categoryName];
                    service.WriteEvent(1, category, eventSeverity, message);
                }
            }
            catch { }
        }
    }
}
