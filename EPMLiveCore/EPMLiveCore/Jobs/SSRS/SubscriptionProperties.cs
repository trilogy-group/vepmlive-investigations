using EPMLiveCore.SSRS2010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs.SSRS
{
    public class SubscriptionProperties : Subscription
    {
        public SubscriptionProperties() { }

        public ParameterValue[] ReportParams { get; set; }
        public string MatchData { get; set; }
    }
}
