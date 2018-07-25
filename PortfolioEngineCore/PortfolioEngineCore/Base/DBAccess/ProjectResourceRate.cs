using System;

namespace PortfolioEngineCore.Base.DBAccess
{
    public class ProjectResourceRate
    {
        public int ProjectId { get; set; }

        public int ResourceId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public decimal Rate { get; set; }
    }
}