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

        /// <summary>
        /// Gets all the enabled features for a particular product.
        /// </summary>
        /// <param name="productId">The id of the product to get the features from</param>
        /// <returns>Returns an <see cref="IEnumerable{LicenseFeature}"/> containing all the features in a product.</returns>
        public static IEnumerable<LicenseFeature> GetLicenseProductFeatures(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var enabledFeatures = context.LICENSEDETAILs.Where(ld => ld.product_id == productId).ToList().AsEnumerable();

                foreach (var item in enabledFeatures)
                {
                    yield return new LicenseFeature
                    {
                        Id = Convert.ToInt32(item.detail_type_id),
                        Name = context.DETAILTYPES.SingleOrDefault(d => d.detail_type_id == item.detail_type_id).detail_name
                    };
                }
            }
        }

        /// <summary>
        /// Gets all the active products.
        /// </summary>
        /// <returns>Returns an IEnumerable<LICENSEPRODUCT> containing all the active products.</returns>
        public static IEnumerable<LICENSEPRODUCT> GetAllActiveProducts()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LICENSEPRODUCTS.Where(p => p.active == true).ToList().AsEnumerable();
            }
        }
    }
}
