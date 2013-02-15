using System.Collections.Generic;

namespace PortfolioEngineCore.Infrastructure.Entities
{
    public class CostCategory
    {
        #region Properties (5) 

        public IList<CostCategory> CostCategories { get; set; }

        public int Id { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public IList<Role> Roles { get; set; }

        #endregion Properties 
    }
}