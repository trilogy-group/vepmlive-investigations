using System;
using System.Collections.Generic;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System.Linq;
using EPMLiveCore.ReportHelper;
using System.Data.SqlClient;
using System.Text;
using EPMLiveCore.Properties;
using System.Data;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade
{
    public class Upgrader : BaseJob
    {
        #region Methods (1)

        // Public Methods (1) 
       
        public void execute(SPSite site, SPWeb web, string data)
        {
           
            try
            {
                string[] passedParams =  data.Split(new char[] { '|' });
                string secondParameter = passedParams.Length > 1 ? passedParams[1] : string.Empty;
                Dictionary<long, Type> upgradeSteps = UpgradeUtilities.GetUpgradeSteps(passedParams.Length > 0? passedParams[0]:string.Empty);
                if (!string.IsNullOrWhiteSpace(secondParameter) && secondParameter.ToLower().Trim().Equals("mark"))
                {
                    web.AllowUnsafeUpdates = true;
                    var steps = upgradeSteps.Where(item => item.Key > 0).OrderBy(item => item.Key).ToList();
                    if (steps.Count > 0)
                    {
                        web.AllProperties["LastVersionedUpgrade"] = steps[steps.Count - 1].Key.ToString();
                    }
                    steps = upgradeSteps.Where(item => item.Key < 0).OrderBy(item => item.Key).ToList();
                    if (steps.Count > 0)
                    {
                        web.AllProperties["LastGenericUpgrade"] = steps[0].Key.ToString();
                    }
                    
                    web.AllowUnsafeUpdates = false;
                    web.Update();
                }
                else
                {
                    
                    bool isPfeSite = site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null;
                    List<KeyValuePair<long,Type>> steps = null;
                    int genericStartIndex = 0;
                    if (!string.IsNullOrWhiteSpace(secondParameter) && secondParameter.ToLower().Trim().Equals("force"))
                    {
                        
                        steps = upgradeSteps.Where(item => item.Key > 0).OrderBy(item => item.Key).ToList();
                        genericStartIndex = steps.Count;
                        steps.AddRange(upgradeSteps.Where(item => item.Key < 0).OrderByDescending(item => item.Key).ToList());
                    }
                    else
                    {
                        long lastVersionedSequence = web.AllProperties.ContainsKey("LastVersionedUpgrade") ? long.Parse((string)web.AllProperties["LastVersionedUpgrade"]) : 0;
                        if (lastVersionedSequence < 1000000000L)
                            lastVersionedSequence = lastVersionedSequence * 100;
                        long lastGenericSequence = web.AllProperties.ContainsKey("LastGenericUpgrade") ? long.Parse((string)web.AllProperties["LastGenericUpgrade"]) : 0;

                        steps = upgradeSteps.Where(item => item.Key > lastVersionedSequence).OrderBy(item => item.Key).ToList();
                        genericStartIndex = steps.Count;
                        steps.AddRange(upgradeSteps.Where(item => item.Key < lastGenericSequence).OrderByDescending(item => item.Key).ToList());
                    }
                    totalCount = steps.Count;
                    int progressCounter = 1;
                    foreach (var upgradeStep in steps)
                    {
                        var step = Activator.CreateInstance(upgradeStep.Value, new object[] { web, isPfeSite }) as IUpgradeStep;

                        if (step == null) continue;

                        bool success = step.Perform();
                        sErrors += step.Log;

                        updateProgress(progressCounter++);

                        if (success)
                        {
                            web.AllowUnsafeUpdates = true;
                            if (progressCounter - 2 < genericStartIndex)
                            {
                                web.AllProperties["LastVersionedUpgrade"] = upgradeStep.Key.ToString();
                            }
                            else
                            {
                                web.AllProperties["LastGenericUpgrade"] = upgradeStep.Key.ToString();
                            }
                            web.Update();
                            web.AllowUnsafeUpdates = false;
                            continue;
                        }
                        bErrors = true;
                        break;
                    }
                }

                #region Database checks
                EPMData epmdata = new EPMData(site.ID);
                StringBuilder sbErrors = new StringBuilder();
                try
                {
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Database checks", string.Format("Started Database checks for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    CheckReqSP(epmdata.GetClientReportingConnection);
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Database checks", string.Format("Completed Database checks for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception exReqSP)
                {
                    var message = exReqSP.InnerException != null ? exReqSP.InnerException.Message : exReqSP.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while checking SPRequirement: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Database checks", string.Format("Error while checking SPRequirement for site: {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                try
                {

                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job updating schema", string.Format("Started updating schema for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    CheckSchema(epmdata.GetClientReportingConnection);
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job updating schema", string.Format("Completed updating schema for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception exSchema)
                {
                    var message = exSchema.InnerException != null ? exSchema.InnerException.Message : exSchema.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while updating schema: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job updating schema", string.Format("Error while updating schema for site: {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sErrors = sErrors + bErrors.ToString();
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
               
            }
        }

        private void CheckSchema(SqlConnection cn)
        {
            using (var cmd = new SqlCommand(Resources.CheckSchema, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        private void CheckReqSP(SqlConnection cn)
        {
            using (var cmd = new SqlCommand(Resources.CheckReqSP, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        #endregion Methods
    }
}