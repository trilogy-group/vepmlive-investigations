using System;
using System.Collections.Generic;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System.Linq;

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
                Dictionary<double, Type> upgradeSteps = UpgradeUtilities.GetUpgradeSteps(passedParams.Length > 0? passedParams[0]:string.Empty);
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
                    List<KeyValuePair<double,Type>> steps = null;
                    int genericStartIndex = 0;
                    if (!string.IsNullOrWhiteSpace(secondParameter) && secondParameter.ToLower().Trim().Equals("force"))
                    {
                        
                        steps = upgradeSteps.Where(item => item.Key > 0).OrderBy(item => item.Key).ToList();
                        genericStartIndex = steps.Count;
                        steps.AddRange(upgradeSteps.Where(item => item.Key < 0).OrderByDescending(item => item.Key).ToList());
                    }
                    else
                    {
                        double lastVersionedSequence = web.AllProperties.ContainsKey("LastVersionedUpgrade") ? double.Parse((string)web.AllProperties["LastVersionedUpgrade"]) : 0.0;
                        double lastGenericSequence = web.AllProperties.ContainsKey("LastGenericUpgrade") ? double.Parse((string)web.AllProperties["LastGenericUpgrade"]) : 0.0;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
               
            }
        }

        #endregion Methods
    }
}