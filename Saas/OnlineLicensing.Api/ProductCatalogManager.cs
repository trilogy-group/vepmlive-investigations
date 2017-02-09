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
    }
}
