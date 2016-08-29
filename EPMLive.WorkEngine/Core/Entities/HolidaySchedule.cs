using System;
using System.Collections.Generic;

namespace WorkEnginePPM.Core.Entities
{
    public class HolidaySchedule
    {
        #region Properties (6) 

        public string ExtId { get; set; }

        public List<Holiday> Holidays { get; set; }

        public int? Id { get; set; }

        public bool IsDefault { get; set; }

        public string Title { get; set; }

        public Guid UniqueId { get; set; }

        #endregion Properties 
    }
}