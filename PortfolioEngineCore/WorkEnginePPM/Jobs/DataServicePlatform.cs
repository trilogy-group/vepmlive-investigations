using EPMLiveCore;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Json;
using WorkEnginePPM.Core.PFEDataServiceManager;
using WorkEnginePPM.DataServiceModules;

namespace WorkEnginePPM.Jobs
{
    public class DataServicePlatform : BaseJob
    {
        private static string basePath;
        private static string ppmId;
        private static string ppmCompany;
        private static string ppmDbConn;
        private static string userName;
        private static SecurityLevels securityLevel;
        private const string UPDATE_LOG_SQL = "UPDATE EPMLIVE_LOG SET resulttext = @ResultText WHERE timerjobuid = @TimerJobUId IF @@ROWCOUNT = 0 INSERT INTO EPMLIVE_LOG (timerjobuid, resulttext) VALUES(@TimerJobUId, @ResultText)";

        public void execute(SPSite spSite, SPWeb spWeb, string data)
        {
            try
            {
                SPWeb rootWeb = spSite.RootWeb;
                securityLevel = SecurityLevels.Base;
                basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
                userName = ConfigFunctions.GetCleanUsername(rootWeb);

                ScheduleDataImportRequest scheduleDataImportRequest = PFEDataServiceUtils.JsonDeserialize<ScheduleDataImportRequest>(data);
                switch (scheduleDataImportRequest.Module)
                {
                    case DSMModule.CostPlanner:
                        var dsmModule = new DSMCostPlanner(spWeb, scheduleDataImportRequest.FileId.ToString(), basePath, userName, ppmId, ppmCompany, ppmDbConn, securityLevel);
                        dsmModule.DSMProgressChanged += DSMProgressChanged;
                        dsmModule.DSMCompleted += DSMCompleted;
                        dsmModule.ImportData();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DSMProgressChanged(object sender, DSMProgressChangedEventHandlerArgs args)
        {
            try
            {
                sErrors = BuildResult(args.UserState);
                UpdateProgress(args.UserState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DSMCompleted(object sender, DSMCompletedEventHandlerArgs args)
        {
            try
            {
                sErrors = BuildResult(args.UserState);
                UpdateProgress(args.UserState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateProgress(object userState)
        {
            try
            {
                DSMResult dSMResult = (DSMResult)userState;
                totalCount = dSMResult.TotalRecords == 0 ? 1 : dSMResult.TotalRecords;
                updateProgress(dSMResult.ProcessedRecords);
                SPSecurity.RunWithElevatedPrivileges(() => cn.Open());
                var cmd = new SqlCommand(UPDATE_LOG_SQL, cn);
                cmd.Parameters.AddWithValue("@ResultText", sErrors);
                cmd.Parameters.AddWithValue("@TimerJobUId", JobUid);
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string BuildResult(object dSMResult)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(DSMResult));
                serializer.WriteObject(memoryStream, dSMResult);
                memoryStream.Position = 0;
                return new StreamReader(memoryStream).ReadToEnd();
            }
        }

    }
}
