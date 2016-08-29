using System;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.WEIntegration;
using WorkEnginePPM.Core;
using EPMUtils = EPMLiveCore.API.Utils;

namespace WorkEnginePPM.WebServices.Core
{
    internal class WEIntegrationManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="WEIntegrationManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public WEIntegrationManager(SPWeb spWeb)
            : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (4) 

        // Private Methods (2) 

        /// <summary>
        /// Gets the admin core.
        /// </summary>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="debugging"> </param>
        /// <returns></returns>
        private WEIntegration GetAdminCore(SecurityLevels secLevel, bool debugging = false)
        {
            WEIntegration adminClass = null;

            SPSecurity.RunWithElevatedPrivileges(
                () => { adminClass = InitilizeAdminCore(secLevel, debugging, Username); });

            return adminClass;
        }

        /// <summary>
        /// Initilizes the admin core.
        /// </summary>
        ///// <param name="secLevel">The sec level.</param>
        /// <param name="debugging">if set to <c>true</c> [debugging].</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private WEIntegration InitilizeAdminCore(SecurityLevels secLevel, bool debugging, string username)
        {
            WEIntegration adminClass;

            using (var site = new SPSite(Web.Site.ID))
            {
                SPWeb rootWeb = site.RootWeb;

                string basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                string ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                string ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                string ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                adminClass = new WEIntegration(basePath, username, ppmId, ppmCompany, ppmDbConn, debugging);
            }

            return adminClass;
        }

        // Internal Methods (3) 


        /// <summary>
        /// Executes Reporting Extract
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string ExecuteReportExtract(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xParmInputElement = xInputData.GetSubStruct("Params");
                if (xParmInputElement == null) throw new Exception("Cannot find the Param element.");
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");
                CStruct xExtract = xDataInputElement.GetSubStruct("ReportExtract");
                if (xExtract == null) throw new Exception("Cannot find the ReportExtract element.");

                string sResult = "";
                bool bUpdateOK = true;

                WEIntegration adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                try
                {
                    sResult = adminCore.ExecuteReportExtract(data);
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    if (sResult.Length > 0)
                    {
                        var dataElement = new XElement("Data");
                        var resultElement = new XElement("Result");
                        resultElement.Add(new XAttribute("Message", sResult));
                        dataElement.Add(resultElement);
                        sResult = dataElement.ToString();
                    }
                    else
                    {
                        sResult = string.Empty;
                    }
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.ExecuteReportExtract, exception);
            }
        }

        /// <summary>
        /// Imports Timesheet information into WE_CHARGES and WE_ACTUALHOURS
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string PostTimesheetData(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xParmInputElement = xInputData.GetSubStruct("Params");
                if (xParmInputElement == null) throw new Exception("Cannot find the Param element.");
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");
                CStruct xTimesheets = xDataInputElement.GetSubStruct("Timesheets");
                if (xTimesheets == null) throw new Exception("Cannot find the Timesheets element.");

                string sResult = "";
                bool bUpdateOK = true;

                WEIntegration adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                try
                {
                    sResult = adminCore.PostTimesheetData(xTimesheets.XML());
                }
                catch (PFEException pfeException)
                {
                    return Response.PfEFailure(pfeException);
                }
                catch (Exception exception)
                {
                    return Response.Failure((int)APIError.PostTimesheetData, exception);
                    //var SWResultElement = new XElement("Result");
                    //Utils.SetResultError(exception, ref SWResultElement);
                    //sResult = SWResultElement.Value;
                    //bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    if (sResult.Length > 0)
                    {
                        // we're saying the Post worked so have to check for AutoPost
                        //int[,] autoposts = new int[10, 2];
                        //bool bRet = adminCore.GetAutoPosts("Timesheets", ref autoposts);
                        // if we have any autoposts then need to call Post Cost Values - best to use Job Server - can Job Server Post Cost Totals to WE? Needs to and not just for this
                        // if use Job Server then should be done in the fn above (w/different name)
                        // there is a Job Server job (in VB) which reads the AutoPosts so just need to know Y/N needed rather than pass list of Posts
                        // Will need to figure where to put SendXMLToWorkengine when switch to NAX PostCostValues

                        //var dataElement = new XElement("Data");
                        //var resultElement = new XElement("Result");
                        //resultElement.Add(new XAttribute("Message", sResult));
                        //dataElement.Add(resultElement);
                        //sResult = dataElement.ToString();
                    }
                    else
                    {
                        sResult = string.Empty;
                    }
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.PostTimesheetData, exception);
            }
        }


        /// <summary>
        /// Inserts Version info into EPG_SYSTEM
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string SetDatabaseVersion(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xParmInputElement = xInputData.GetSubStruct("Params");
                if (xParmInputElement == null) throw new Exception("Cannot find the Param element.");
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");
                CStruct xDBS = xDataInputElement.GetSubStruct("Database");
                if (xDBS == null) throw new Exception("Cannot find the Database element.");

                string sResult = "";
                bool bUpdateOK = true;

                WEIntegration adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                try
                {
                    sResult = adminCore.SetDatabaseVersion(data);
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    if (sResult.Length > 0)
                    {
                        var dataElement = new XElement("Data");
                        var resultElement = new XElement("Result");
                        resultElement.Add(new XAttribute("Message", sResult));
                        dataElement.Add(resultElement);
                        sResult = dataElement.ToString();
                    }
                    else
                    {
                        sResult = string.Empty;
                    }
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.SetDatabaseVersion, exception);
            }
        }

        #endregion Methods 
    }
}