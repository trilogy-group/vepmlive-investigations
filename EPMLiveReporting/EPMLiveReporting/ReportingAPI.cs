using EPMLiveCore.API;
using EPMLiveReportsAdmin.API;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public class ReportingAPI
    {
        #region Methods (4) 

        // Public Methods (4) 

        /// <summary>
        ///     Gets all reports.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetAllReports(string data, SPWeb spWeb)
        {
            try
            {
                string allReports;

                using (var reportManager = new ReportManager(spWeb))
                {
                    allReports = reportManager.GetAllReports(data);
                }

                return Response.Success(allReports);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public string GetReportsByFolder(string data, SPWeb spWeb)
        {
            try
            {
                string allReports;

                using (var reportManager = new ReportManager(spWeb))
                {
                    allReports = reportManager.GetReportsByFolder(data);
                }

                return Response.Success(allReports);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        ///     Gets my work data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetMyWorkData(string data, SPWeb spWeb)
        {
            try
            {
                var reportingDataManager = new DataManager(spWeb);
                return Response.Success(reportingDataManager.GetMyWorkData(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        ///     Gets my work fields.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetMyWorkFields(string data, SPWeb spWeb)
        {
            try
            {
                var reportingDataManager = new DataManager(spWeb);
                return Response.Success(reportingDataManager.GetMyWorkFields(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        ///     Refreshes all.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string RefreshAll(string data, SPWeb spWeb)
        {
            try
            {
                var reportingDataManager = new DataManager(spWeb);
                return Response.Success(reportingDataManager.RefreshAll());
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods 
    }
}