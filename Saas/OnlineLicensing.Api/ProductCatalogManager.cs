using OnlineLicensing.Api.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLicensing.Api
{
    public class ProductCatalogManager
    {
        public static IEnumerable<LICENSEPRODUCT> GetAllProducts()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LICENSEPRODUCTS.ToList().AsEnumerable();
            }
        }

        public static void GenerateProductDetail(int productId)
        {
            
        }
    }
}
