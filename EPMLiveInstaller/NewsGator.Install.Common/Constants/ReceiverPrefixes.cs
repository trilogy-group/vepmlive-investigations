using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Constants
{
    internal static class ReceiverPrefixes
    {
        internal static Collection<ReceiverPrefix> Get()
        {
            return new Collection<ReceiverPrefix>
	            {
                    new ReceiverPrefix { SolutionSet = SolutionSet.SocialPlatform, Prefix = "SocialSites.Core.ApplicationServices"},
                    new ReceiverPrefix { SolutionSet = SolutionSet.SocialPlatform, Prefix = "NewsGator.Social"},
                    new ReceiverPrefix { SolutionSet = SolutionSet.Enrich, Prefix = "NewsGator.Learning"},
                    new ReceiverPrefix { SolutionSet = SolutionSet.VideoStream, Prefix = "NewsGator.VideoStream"},
				    new ReceiverPrefix { SolutionSet = SolutionSet.Innovation, Prefix = "NewsGator.Innovation"}
                };
        }
    }
}
