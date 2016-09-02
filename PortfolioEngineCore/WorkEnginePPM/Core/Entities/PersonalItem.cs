using System;

namespace WorkEnginePPM.Core.Entities
{
    public class PersonalItem
    {
        #region Properties (4) 

        public string ExtId { get; set; }

        public int? Id { get; set; }

        public string Title { get; set; }

        public Guid UniqueId { get; set; }

        #endregion Properties 
    }
}