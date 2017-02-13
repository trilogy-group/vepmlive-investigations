using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EPMLive.OnlineLicensing.Api.Data;
using EPMLive.OnlineLicensing.Api.Exceptions;

namespace EPMLive.OnlineLicensing.Api
{
    public class ProductCatalogManager
    {
        public static IEnumerable<LicenseProduct> GetAllProducts()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LicenseProducts.Include(o => o.Orders).Include(d => d.LicenseDetails).OrderBy(x => x.sku).ToList().AsEnumerable();
            }
        }

        /// <summary>
        /// Gets all the enabled features for a particular product.
        /// </summary>
        /// <param name="productId">The id of the product to get the features from</param>
        /// <returns>Returns an <see cref="IEnumerable{LicenseFeature}"/> containing all the features in a product.</returns>
        public static IEnumerable<LicenseFeature> GetEnabledLicenseProductFeatures(int productId)
        {
            var enabledFeatures = GetLicenseProductFeatures(productId);

            foreach (var item in enabledFeatures)
            {
                yield return new LicenseFeature
                {
                    Id = item.detail_type_id ?? 0,
                    Name = item.DetailType.detail_name
                };
            }
        }

        /// <summary>
        /// Get product based on id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static LicenseProduct GetProduct(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LicenseProducts.SingleOrDefault(p => p.product_id == productId);
            }
        }


        /// <summary>
        /// Add new License Product to Database
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="name"></param>
        /// <param name="active"></param>
        public static void AddProduct(string sku, string name, bool active)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var newProduct = new LicenseProduct { sku = sku, name = name, active = active };
                context.LicenseProducts.Add(newProduct);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Save changes to an existing License Product in Database
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        public static void UpdateProduct(int productId, string name, bool active)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {

                var existingProduct = context.LicenseProducts.SingleOrDefault(p => p.product_id == productId);
                if (existingProduct != null)
                {
                    existingProduct.name = name;
                    existingProduct.active = active;
                    context.LicenseProducts.Attach(existingProduct);
                    context.Entry(existingProduct).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public static bool CheckForSkuDuplicate(string sku)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingProduct = context.LicenseProducts.SingleOrDefault(p => p.sku.Equals(sku));
                return existingProduct != null;
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingOrdersForProduct = context.Orders.FirstOrDefault(o => o.product_id == productId);
                if (existingOrdersForProduct != null) throw new LicenseProductInUseException();
                var existingProduct = context.LicenseProducts.SingleOrDefault(p => p.product_id == productId);
                context.Entry(existingProduct).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Get a list of assigned features for indicated product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static IEnumerable<LicenseDetail> GetLicenseProductFeatures(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LicenseDetails.Include(o => o.DetailType).Include(l => l.LicenseProduct).Where(f => f.product_id == productId).ToList().AsEnumerable();
            }
        }

        public static IEnumerable<DetailType> GetAllDetailTypes()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.DetailTypes.ToList().AsEnumerable();
            }
        }


        /// <summary>
        /// Check if a feature has already been added to a License Product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="detailTypeId"></param>
        /// <returns></returns>
        public static bool CheckForFeatureDuplicate(int productId, int detailTypeId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingProduct = context.LicenseDetails.SingleOrDefault(p => p.detail_type_id == detailTypeId && p.product_id == productId);
                return existingProduct != null;
            }
        }

        public static void AddProductFeature(int productId, int detailTypeId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var newProductFeature = new LicenseDetail { product_id = productId, detail_type_id = detailTypeId };
                context.LicenseDetails.Add(newProductFeature);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets all the active products.
        /// </summary>
        /// <returns>Returns an <see cref="IEnumerable{LicenseProduct}"/> containing all the active products.</returns>
        public static IEnumerable<LicenseProduct> GetAllActiveProducts()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LicenseProducts.Where(p => p.active == true).ToList().AsEnumerable();

            }
        }

        ///<summary>
        /// Delete a feature from a License product.
        /// </summary>
        /// <param name="licenseFeatureId"></param>
        public static void DeleteProductFeature(int licenseFeatureId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingProductFeature = context.LicenseDetails.SingleOrDefault(p => p.license_detail_id == licenseFeatureId);
                context.Entry(existingProductFeature).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
