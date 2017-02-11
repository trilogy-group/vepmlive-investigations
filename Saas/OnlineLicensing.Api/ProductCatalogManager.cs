using OnlineLicensing.Api.Data;
using System;
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

        public static IEnumerable<FeatureList> GenerateProductDetail(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var enabledFeatures = context.LICENSEDETAILs.Where(ld => ld.product_id == productId).ToList().AsEnumerable();

                foreach (var item in enabledFeatures)
                {
                    yield return new FeatureList
                    {
                        Id = Convert.ToInt32(item.detail_type_id),
                        Name = context.DETAILTYPES.SingleOrDefault(d => d.detail_type_id == item.detail_type_id).detail_name
                    };
                }
            }
        }

        public static IEnumerable<LICENSEPRODUCT> GetAllActiveProducts()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LICENSEPRODUCTS.Where(p => p.active == true).ToList().AsEnumerable();
            }
        }
    }
}
