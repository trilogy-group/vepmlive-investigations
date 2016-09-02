using System;

namespace WorkEnginePPM.Core.Entities
{
    public class Holiday
    {
        #region Properties (5) 

        public string Date { get; set; }

        public double Hours { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public Guid UniqueId { get; set; }

        #endregion Properties 
    }
}