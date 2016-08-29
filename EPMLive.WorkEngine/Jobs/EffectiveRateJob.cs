using EPMLiveCore;
using EPMLiveCore.Infrastructure.Logging;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using PortfolioEngineCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace WorkEnginePPM.Jobs
{
    class EffectiveRateJob : EPMLiveCore.API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            SPWeb rootWeb = null;
            SqlDataReader reader = null;
            SPList resourceList = null;
            PortfolioEngineCore.AdminFunctions adminFunc = null;
            ReportData reportData = null;
            string username = null;
            string basePath = null;
            string ppmId = null;
            string ppmCompany = null;
            string ppmDbConn = null;
            Boolean listMappingExists = false;
            string tableName = null;
            try
            {
                LoggingService.WriteTrace(Area.EPMLiveWorkEnginePPM, Categories.EPMLiveWorkEnginePPM.TimerJob, TraceSeverity.Monitorable, "Effective Rate Job Started");

                //Refer root web to get pfe details
                rootWeb = site.RootWeb;
                username = site.WebApplication.ApplicationPool.Username;
                basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
                SecurityLevels secLevel = SecurityLevels.AdminCalc;

                reportData = new ReportData(web.Site.ID);
                adminFunc = new PortfolioEngineCore.AdminFunctions(basePath, username, ppmId, ppmCompany, ppmDbConn, secLevel);
                resourceList = web.Lists.TryGetList("Resources");

                if (resourceList != null)
                {
                    listMappingExists = reportData.GetListMapping(resourceList.ID) != null;
                    tableName = reportData.GetTableName(resourceList.ID);

                    SPListItemCollection resourceSPListItemCollection = resourceList.GetItems();
                    foreach (SPListItem item in resourceSPListItemCollection)
                    {
                        decimal pfeRate = adminFunc.CalcResourceRate(Convert.ToInt32(item["EXTID"]));
                        decimal listItemRate = Convert.ToDecimal(item["StandardRate"]);

                        if (listItemRate != pfeRate)
                        {
                            try
                            {
                                item["StandardRate"] = pfeRate;
                                using (DisabledItemEventScope scope = new DisabledItemEventScope())
                                {
                                    item.Update();
                                }
                                if (listMappingExists)
                                {
                                    reportData.UpdateItem(resourceList.ID, item, tableName);
                                }
                            }
                            catch (Exception ex)
                            {
                                LoggingService.WriteTrace(Area.EPMLiveWorkEnginePPM, Categories.EPMLiveWorkEnginePPM.TimerJob, TraceSeverity.High, String.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LoggingService.WriteTrace(Area.EPMLiveWorkEnginePPM, Categories.EPMLiveWorkEnginePPM.TimerJob, TraceSeverity.High, String.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
                sErrors = "Error: " + ex.Message;
            }
            finally
            {
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                if (reader != null)
                    reader.Dispose();
                data = null;

                if (rootWeb != null)
                    rootWeb.Dispose();
                resourceList = null;
                adminFunc = null;
                if (reportData != null)
                    reportData.Dispose();
                username = null;
                basePath = null;
                ppmId = null;
                ppmCompany = null;
                ppmDbConn = null;
                LoggingService.WriteTrace(Area.EPMLiveWorkEnginePPM, Categories.EPMLiveWorkEnginePPM.TimerJob, TraceSeverity.Monitorable, "Effective Rate Job Completed");
            }
        }
    }
}
