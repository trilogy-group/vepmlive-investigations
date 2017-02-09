using System;
using OnlineLicensing.Api.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineLicensing.Api.Exceptions;

namespace OnlineLicensing.Api
{
    public class ProductCatalogManager
    {
        public static IEnumerable<LICENSEPRODUCT> GetAllProducts()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LICENSEPRODUCTS.Include(o => o.ORDERS).OrderBy(x => x.sku).ToList().AsEnumerable();
            }
        }

        public static void GenerateProductDetail(int productId)
        {

        }

        /// <summary>
        /// Get product based on id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static LICENSEPRODUCT GetProduct(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LICENSEPRODUCTS.SingleOrDefault(p => p.product_id == productId);
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
                var newProduct = new LICENSEPRODUCT { sku = sku, name = name, active = active };
                context.LICENSEPRODUCTS.Add(newProduct);
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

                var existingProduct = context.LICENSEPRODUCTS.SingleOrDefault(p => p.product_id == productId);
                if (existingProduct != null)
                {
                    existingProduct.name = name;
                    existingProduct.active = active;
                    context.LICENSEPRODUCTS.Attach(existingProduct);
                    context.Entry(existingProduct).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public static bool CheckForSkuDuplicate(string sku)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingProduct = context.LICENSEPRODUCTS.SingleOrDefault(p => p.sku.Equals(sku));
                return existingProduct != null;
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingOrdersForProduct = context.ORDERS.FirstOrDefault(o => o.product_id == productId);
                if (existingOrdersForProduct != null) throw new LicenseProductInUseException();
                var existingProduct = context.LICENSEPRODUCTS.SingleOrDefault(p => p.product_id == productId);
                context.Entry(existingProduct).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Get a list of assigned features for indicated product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static IEnumerable<LICENSEDETAIL> GetLicenseProductFeatures(int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.LICENSEDETAILs.Include(o=>o.DETAILTYPE).Include(l=>l.LICENSEPRODUCT).Where(f=>f.product_id == productId).ToList().AsEnumerable();
            }
        }

        public static IEnumerable<DETAILTYPE> GetAllDetailTypes()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.DETAILTYPES.ToList().AsEnumerable();
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
                var existingProduct = context.LICENSEDETAILs.SingleOrDefault(p => p.detail_type_id == detailTypeId && p.product_id == productId);
                return existingProduct != null;
            }
        }

        public static void AddProductFeature(int productId, int detailTypeId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var newProductFeature = new LICENSEDETAIL { product_id = productId, detail_type_id = detailTypeId };
                context.LICENSEDETAILs.Add(newProductFeature);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a feature from a License product.
        /// </summary>
        /// <param name="licenseFeatureId"></param>
        public static void DeleteProductFeature(int licenseFeatureId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var existingProductFeature = context.LICENSEDETAILs.SingleOrDefault(p => p.license_detail_id == licenseFeatureId);
                context.Entry(existingProductFeature).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
