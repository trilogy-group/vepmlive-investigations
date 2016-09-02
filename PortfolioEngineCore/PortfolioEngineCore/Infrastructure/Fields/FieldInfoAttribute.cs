using System;

namespace PortfolioEngineCore.Infrastructure.Fields
{
    public class FieldInfoAttribute : Attribute
    {
        #region Properties (2) 

        public int Id { get; set; }

        public string Name { get; set; }

        #endregion Properties 
    }
}