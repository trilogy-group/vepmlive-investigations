using System;

namespace EPMLiveCore.PfeData
{
    public class ProjectResourceRate
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int ResourceId { get; set; }

        public decimal Rate { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}