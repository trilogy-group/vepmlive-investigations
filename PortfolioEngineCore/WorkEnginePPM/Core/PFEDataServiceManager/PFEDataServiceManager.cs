using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.Entities;
using WorkEnginePPM.DataServiceModules;
using PortfolioEngineCore;
using WorkEnginePPM.WebServices.Core;
using System.Xml;

namespace WorkEnginePPM.Core.PFEDataServiceManager
{
    public class PFEDataServiceManager : BaseManager
    {

        public PFEDataServiceManager(SPWeb spWeb) : base(spWeb) { }

        public string ScheduleDataImport(string data)
        {

            try
            {
                if (data == null) throw new Exception("Cannot find the data element.");

                ScheduleDataImportRequest scheduleDataImportRequest = PFEDataServiceUtils.JsonDeserialize<ScheduleDataImportRequest>(data);
                ScheduleDataImportResponse scheduleDataImportResponse = new ScheduleDataImportResponse();
                SPSite spSite = Web.Site;

                Guid jobId = EPMLiveCore.API.Timer.AddTimerJob(spSite.ID, Web.ID, "PFE Import-Export Data", 25, data, string.Empty, -1, 9, string.Empty);

                EPMLiveCore.API.Timer.Enqueue(jobId, 0, spSite);

                scheduleDataImportResponse.JobId = jobId;

                return Response.Success(PFEDataServiceUtils.JsonSerializer(scheduleDataImportResponse));
            }
            catch (Exception ex)
            {
                return Response.Failure((int)APIError.ScheduleDataImport, ex);
            }

        }

        public string CollectDataImportResult(string data)
        {

            try
            {
                if (data == null) throw new Exception("Cannot find the data element.");

                XmlNode timerJobStatus = EPMLiveCore.API.Timer.GetTimerJobStatus(Web, new Guid(data));

                XmlNode node = timerJobStatus.FirstChild;
                if (node != null)
                {
                    return Response.Success(node.Value);
                }
                return Response.Success("");
            }
            catch (Exception ex)
            {
                return Response.Failure((int)APIError.CollectDataImportResult, ex);
            }

        }
    }
}