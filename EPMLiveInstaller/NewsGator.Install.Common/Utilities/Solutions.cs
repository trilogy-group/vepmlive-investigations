using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;
using System.Collections.Generic;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Solutions
    {
        /// <summary>
        /// Wait, up to 20 minutes, for the current timer job for the SharePoint solution to complete.
        /// </summary>
        /// <param name="solutionName"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        internal static void WaitForSolutionJob(string solutionName, int timeout)
        {
            LocalFarm.Get().TryUpdate();

            // Ensure solution exists
            if (LocalFarm.Get().Solutions[solutionName] == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionNotAddedToFarm, solutionName));

            var solution = LocalFarm.Get().Solutions[solutionName];
            var jobName = GenerateJobName(solution.Name, solution.Id, 0);

            var time = DateTime.Now.AddMilliseconds(timeout);
            var complete = false;
            while (!complete && DateTime.Now < time)
            {
                solution = LocalFarm.Get().Solutions[solutionName];

                var waitTimerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                complete = !(waitTimerService.JobDefinitions.Any(p => p.Name.Equals(jobName, StringComparison.OrdinalIgnoreCase)))
                    && !solution.JobExists;

                if (!complete)
                {
                    LocalFarm.Get().TryUpdate();
                    Thread.Sleep(10000);
                }
            }

            if (!complete)
            {
                var timerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                var jobs = timerService.JobDefinitions.Where(p => p.Name.Equals(jobName, StringComparison.OrdinalIgnoreCase));

                foreach (var job in jobs)
                {
                    job.Delete();
                }

                throw new TimeoutException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionJobTimeout, solutionName));
            }

            //Func<bool> wait = () =>
            //    {
            //        var complete = false;
            //        while (!complete)
            //        {
            //            var waitTimerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
            //            complete = !(waitTimerService.JobDefinitions.Any(p => p.Name.Equals(jobName, StringComparison.OrdinalIgnoreCase)));

            //            if (!complete)
            //            {
            //                LocalFarm.Get().TryUpdate();
            //                Thread.Sleep(10000);
            //            }
            //        }

            //        return complete;
            //    };
                    
            //var success = Threading.WaitFor<bool>.Run(TimeSpan.FromMilliseconds(timeout), wait);
            //if (!success)
            //{
            //    var timerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
            //    var jobs = timerService.JobDefinitions.Where(p => p.Name.Equals(jobName, StringComparison.OrdinalIgnoreCase));

            //    foreach (var job in jobs)
            //    {
            //        job.Delete();
            //    }

            //    throw new TimeoutException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionJobTimeout, solutionName));
            //}
        }

        // Copied from Microsoft.SharePoint.Administration.SPSolutionDeploymentJobDefinition
        private static string GenerateJobName(string solutionName, Guid solutionId, uint lcid)
        {
            return ("solution-deployment-" + (((solutionName.Length < 50) || (solutionId == Guid.Empty)) ? solutionName : (solutionName.Substring(0, 0x19) + "-" + solutionId.ToString("D"))) + "-" + lcid.ToString(NumberFormatInfo.InvariantInfo));
        }

        /// <summary>
        /// Borrowed from Microsoft.SharePoint.ApplicationPages.SolutionStatusPage.OperationResultDescription
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        internal static string GetOperationResultDescription(SPSolutionOperationResult result)
        {
            string str = SPResource.GetString(CultureInfo.CurrentCulture, "SolutionNoOperation", new object[0]);
            switch (result)
            {
                case SPSolutionOperationResult.RetractionSucceeded:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionRetractionSucceeded", new object[0]);

                case SPSolutionOperationResult.DeploymentSucceeded:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionDeploymentSucceeded", new object[0]);

                case SPSolutionOperationResult.RetractionWarningsOccurred:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionRetractionWarningsOccurred", new object[0]);

                case SPSolutionOperationResult.DeploymentWarningsOccurred:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionDeploymentWarningsOccurred", new object[0]);

                case SPSolutionOperationResult.DeploymentFailedCabExtraction:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionCabExtractionFailed", new object[0]);

                case SPSolutionOperationResult.DeploymentSolutionValidationFailed:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionValidationFailed", new object[0]);

                case SPSolutionOperationResult.DeploymentFailedFileCopy:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionDeploymentFailedFileCopy", new object[0]);

                case SPSolutionOperationResult.DeploymentFailedFeatureInstall:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionDeploymentFailedFeatureInstall", new object[0]);

                case SPSolutionOperationResult.RetractionFailedCouldNotRemoveFile:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionRetractionFailedCouldNotRemoveFile", new object[0]);

                case SPSolutionOperationResult.RetractionFailedCouldNotRemoveFeature:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionRetractionFailedCouldNotRemoveFeature", new object[0]);

                case SPSolutionOperationResult.DeploymentFailedCallout:
                    return SPResource.GetString(CultureInfo.CurrentCulture, "SolutionDeploymentFailedCallout", new object[0]);
            }
            str = str.Replace("\\r\\n", "\r\n");
            return str;
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static bool IsSolutionInstalled(SocialSitesSolution solution)
        {
            if (solution == null)
                return false;
            return LocalFarm.Get().Solutions[solution.SolutionName] != null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue ProcessSolutionsStatus(ref Collection<SocialSitesSolution> solutions, string literalPath, bool ignoreMissingSolutions = false)
        {
            var outputQueue = new OutputQueue();

            if (solutions == null)
                solutions = new Collection<SocialSitesSolution>();

            // Check for WSP files
            var filePaths = Directory.GetFiles(literalPath, "*.wsp");
            foreach (var filePath in filePaths)
            {
                var knownSolution = false;
                var solutionName = Path.GetFileName(filePath);

                if (string.IsNullOrEmpty(solutionName)) continue;

                // Known Solution
                foreach (var solution in solutions.Where(solution => string.Equals(solutionName.Trim(), solution.SolutionName.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    if (!solution.Ignore)
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.KnownSolutionFound, solution.SolutionName));
                    else
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.KnownSolutionFoundIgnoring, solution.SolutionName));

                    solution.IsWspAvailable = true;
                    knownSolution = true;
                }

                // Unknown Solution
                if (!knownSolution)
                {
                    outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.UnknownSolutionFound, solutionName));
                    var solution = new SocialSitesSolution()
                    {
                        IsWspAvailable = true,
                        SolutionName = solutionName,
                        SolutionSet = SolutionSet.Unknown,
                        InstallOrder = 99
                    };
                    var majorVersion = 0;
                    outputQueue.Add(Files.SolutionManifestVersion(solution, literalPath, out majorVersion));
                    if (majorVersion >= 14)
                        solution.MinimumVersion = majorVersion;
                    solutions.Add(solution);
                }
            }

            // Check if WSP files are installed
            var farm = LocalFarm.Get();
            if (solutions != null)
            {
                foreach (var solution in solutions)
                {
                    solution.IsInstalled = IsSolutionInstalled(solution);
                }
            }

            // Validate Required Solutions are Available
            if (!ignoreMissingSolutions)
            {
                var majorVersion = farm.BuildVersion.Major;
                var missingCoreSolutions = solutions.Where(p => (p.SolutionSet == SolutionSet.SocialPlatform) && (!p.IsWspAvailable) && (p.MinimumVersion <= majorVersion) && (p.Required) && (!p.Ignore));
                if (missingCoreSolutions.Count() > 0)
                {
                    var missingSolutions = string.Empty;
                    foreach (var solution in missingCoreSolutions)
                    {
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.MissingSolution, solution.SolutionName), OutputType.Error);
                        missingSolutions += string.Format(CultureInfo.CurrentCulture, Exceptions.SolutionMissingFormat, solution.SolutionName);
                    }

                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.RequiredSolutionsMissing, missingSolutions));
                }

                var missingInstalledSolutions = solutions.Where(p => (p.IsInstalled) && (!p.IsWspAvailable) && (!p.Ignore));
                if (missingInstalledSolutions.Count() > 0)
                {
                    var missingSolutions = string.Empty;
                    foreach (var solution in missingInstalledSolutions)
                    {
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.MissingSolution, solution.SolutionName), OutputType.Error);
                        missingSolutions += string.Format(CultureInfo.CurrentCulture, Exceptions.SolutionMissingFormat, solution.SolutionName);
                    }

                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.InstalledSolutionsMissing, missingSolutions));
                }
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue ProcessSolutionSetsStatus(ref Collection<SolutionSet> sets, Collection<SocialSitesSolution> solutions)
        {
            var outputQueue = new OutputQueue();

            if (sets == null)
                sets = new Collection<SolutionSet>();

            var majorVersion = LocalFarm.Get().BuildVersion.Major;

            outputQueue.Add(UserDisplay.SolutionsSetsChecking);

            // Core
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetCore));
            var coreSolutions = solutions.WhereSolutionSet(SolutionSet.SocialPlatform, majorVersion);

            if (!coreSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetCore));
            }
            else if (!coreSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetCore));
                sets.Add(SolutionSet.SocialPlatform);
            }

            // Ideas 
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetIdeas));
            var ideaSolutions = solutions.WhereSolutionSet(SolutionSet.IdeaStream, majorVersion);
            if (!ideaSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetIdeas));
            }
            else if (!ideaSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetIdeas));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetIdeas, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetIdeas));
                sets.Add(SolutionSet.IdeaStream);
            }

            // Spotlight

            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetSpotlight));
            var spotlightSolutions = solutions.WhereSolutionSet(SolutionSet.Spotlight, majorVersion);
            if (!spotlightSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetSpotlight));
            }
            else if (!spotlightSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetSpotlight));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetSpotlight, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetSpotlight));
                sets.Add(SolutionSet.Spotlight);
            }
            
            // InterComm
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetInterComm));
            var interCommSolutions = solutions.WhereSolutionSet(SolutionSet.InterComm, majorVersion);
            if (!interCommSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetInterComm));
            }
            else if (!interCommSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetInterComm));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetInterComm, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetInterComm));
                sets.Add(SolutionSet.InterComm);
            }

            // News
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetNews));
            var newsSolutions = solutions.WhereSolutionSet(SolutionSet.NewsStream, majorVersion);
            if (!newsSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetNews));
            }
            else if (!newsSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetNews));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetNews, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetNews));
                sets.Add(SolutionSet.NewsStream);
            }

            // Pivot Viewer
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetPivotViewer));
            var pivotSolutions = solutions.WhereSolutionSet(SolutionSet.PivotViewer, majorVersion);
            if (!pivotSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetPivotViewer));
            }
            else if (!pivotSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetPivotViewer));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetPivotViewer, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetPivotViewer));
                sets.Add(SolutionSet.PivotViewer);
            }

            // Scorecard
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetScorecard));
            var scorecardSolutions = solutions.WhereSolutionSet(SolutionSet.Scorecard, majorVersion);
            if (!scorecardSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetScorecard));
            }
            else if (!scorecardSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetScorecard));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetScorecard, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetScorecard));
                sets.Add(SolutionSet.Scorecard);
            }

            // CA Common
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetCanada));
            var canadaSolutions = solutions.WhereSolutionSet(SolutionSet.CanadaCommon, majorVersion);
            if (!canadaSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetCanada));
            }
            else if (!canadaSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetCanada));
            }
            else if (!sets.Contains(SolutionSet.SocialPlatform))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetCanada, UserDisplay.SolutionsSetCore));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetCanada));
                sets.Add(SolutionSet.CanadaCommon);
            }

            // Video
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetVideo));
            var videoSolutions = solutions.WhereSolutionSet(SolutionSet.VideoStream, majorVersion);
            if (!videoSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetVideo));
            }
            else if (!videoSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetVideo));
            }
            else if (!sets.Contains(SolutionSet.CanadaCommon))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetVideo, UserDisplay.SolutionsSetCanada));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetVideo));
                sets.Add(SolutionSet.VideoStream);
            }

            // Video ScreenCast
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetScreenCast));
            var videoScreenCastSolutions = solutions.WhereSolutionSet(SolutionSet.VideoScreenCast, majorVersion);
            if (!videoScreenCastSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetScreenCast));
            }
            else if (!videoScreenCastSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetScreenCast));
            }
            else if (!sets.Contains(SolutionSet.VideoStream))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetScreenCast, UserDisplay.SolutionsSetVideo));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetScreenCast));
                sets.Add(SolutionSet.VideoScreenCast);
            }

            // Enrich
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetLearning));
            var learningSolutions = solutions.WhereSolutionSet(SolutionSet.Enrich, majorVersion);
            if (!learningSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetLearning));
            }
            else if (!learningSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetLearning));
            }
            else if (!sets.Contains(SolutionSet.CanadaCommon))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetLearning, UserDisplay.SolutionsSetCanada));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetLearning));
                sets.Add(SolutionSet.Enrich);
            }

            // Enrich Video Scenarios
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetVideoLearning));
            var videoLearningSolutions = solutions.WhereSolutionSet(SolutionSet.EnrichVideoScenarios, majorVersion);
            if (!videoLearningSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetVideoLearning));
            }
            else if (!videoLearningSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetVideoLearning));
            }
            else if (!sets.Contains(SolutionSet.VideoStream))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetVideoLearning, UserDisplay.SolutionsSetVideo));
            }
            else if (!sets.Contains(SolutionSet.Enrich))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetVideoLearning, UserDisplay.SolutionsSetLearning));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetVideoLearning));
                sets.Add(SolutionSet.EnrichVideoScenarios);
            }

            // Innovation
            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetChecking, UserDisplay.SolutionsSetInnovation));
            var innovationSolutions = solutions.WhereSolutionSet(SolutionSet.Innovation, majorVersion);
            if (!innovationSolutions.Any(p => p.IsWspAvailable))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetNotFound, UserDisplay.SolutionsSetInnovation));
            }
            else if (!innovationSolutions.IsSolutionSetComplete())
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetIncomplete, UserDisplay.SolutionsSetInnovation));
            }
            else if (!sets.Contains(SolutionSet.CanadaCommon))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetInnovation, UserDisplay.SolutionsSetCanada));
            }
            else if (!sets.Contains(SolutionSet.IdeaStream))
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFoundMissingPrerequisiteSet, UserDisplay.SolutionsSetInnovation, UserDisplay.SolutionsSetIdeas));
            }
            else
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.SolutionsSetFound, UserDisplay.SolutionsSetInnovation));
                sets.Add(SolutionSet.Innovation);
            }
            outputQueue.Add(UserDisplay.SolutionsSetsCheckingComplete);

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue RemoveExistingJob(SPSolution solution)
        {
            var outputQueue = new OutputQueue();

            if (solution == null || !solution.JobExists)
                return outputQueue;

            if (solution.JobStatus == SPRunningJobStatus.Initialized)
                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.DeploySolutionError, solution.Name, Exceptions.DeploySolutionJobAlreadyRunning), OutputType.Warning);

            var jobs = GetSolutionJobs(solution);
            foreach (var jobid in jobs.Keys)
            {
                var jobDefinition = jobs[jobid];
                if (jobDefinition != null)
                {
                    try
                    {
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.DeploySolutionRemoveJob, jobDefinition.DisplayName, solution.Name));
                        jobDefinition.Delete();
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.DeploySolutionRemoveJobFailed, jobDefinition.DisplayName, solution.Name, exception), OutputType.Warning);
                    }
                }
            }

            return outputQueue;
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        private static Dictionary<Guid, SPJobDefinition> GetSolutionJobs(SPSolution solution)
        {
            var jobs = new Dictionary<Guid, SPJobDefinition>();
            SPFarm localFarm = LocalFarm.Get();
            SPTimerService service = localFarm.TimerService;
            foreach (SPJobDefinition definition in service.JobDefinitions)
            {
                if (definition.Title != null && CultureInfo.InvariantCulture.CompareInfo.IndexOf(definition.Title, solution.Name, CompareOptions.IgnoreCase) != -1)
                {
                    jobs.Add(definition.Id, definition);
                }
            }
            return jobs;
        }
    }
}
