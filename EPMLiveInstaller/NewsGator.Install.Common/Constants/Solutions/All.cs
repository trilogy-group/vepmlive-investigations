using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// Return all NewsGator Social Sites SharePoint solutions 
    /// in the appropriate install order
    /// </summary>
    internal static class All
    {
        internal static Collection<SocialSitesSolution> Get()
        {
            var solutions = new Collection<SocialSitesSolution>();

            var orderBase = 1000;

            solutions = ProcessGroup(orderBase, solutions, SocialPlatform.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, IdeaStream.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, InterComm.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, NewsStream.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, PivotViewer.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, Spotlight.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, CanadaCommon.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, Enrich.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, VideoStream.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, VideoScreenCast.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, EnrichVideoScenarios.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, Innovation.All);
            orderBase += 1000;
            solutions = ProcessGroup(orderBase, solutions, Scorecard.All);

            return solutions;
        }

        private static Collection<SocialSitesSolution> ProcessGroup(int orderBase, Collection<SocialSitesSolution> solutions, Collection<SocialSitesSolution> solutionsToProcess)
        {
            foreach (var solution in solutionsToProcess.Where(p => p != null).OrderBy(p => p.InstallOrder))
            {
                solution.InstallOrder = orderBase + solution.InstallOrder;
                solutions.Add(solution);
            }

            return solutions;
        }
    }
}
