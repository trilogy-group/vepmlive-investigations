using System;

namespace WorkEnginePPM.Core.Entities
{
    public class WorkSchedule
    {
        #region Properties (12) 

        public string ExtId { get; set; }

        public decimal Friday { get; set; }

        public int? Id { get; set; }

        public bool IsDefault { get; set; }

        public decimal Monday { get; set; }

        public decimal Saturday { get; set; }

        public decimal Sunday { get; set; }

        public decimal Thursday { get; set; }

        public string Title { get; set; }

        public decimal Tuesday { get; set; }

        public Guid UniqueId { get; set; }

        public decimal Wednesday { get; set; }

        #endregion Properties 
    }
}