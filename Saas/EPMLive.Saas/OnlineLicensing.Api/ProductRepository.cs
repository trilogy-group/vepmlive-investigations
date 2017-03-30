using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EPMLive.OnlineLicensing.Api.Data;
using EPMLive.OnlineLicensing.Api.Exceptions;

namespace EPMLive.OnlineLicensing.Api
{
    public class ProductRepository
    {
        private readonly ILicensingModel _licensingModel;

        public ProductRepository(ILicensingModel licensingModel)
        {
            this._licensingModel = licensingModel;
        }

        public IEnumerable<LicenseProduct> GetAllProducts()
        {
            return _licensingModel.LicenseProducts.Include(o => o.Orders).Include(d => d.LicenseDetails).OrderBy(x => x.sku).ToList().AsEnumerable();
        }

        /// <summary>
        /// Gets all the enabled features for a particular product.
        /// </summary>
        /// <param name="productId">The id of the product to get the features from</param>
        /// <returns>Returns an <see cref="IEnumerable{LicenseFeature}"/> containing all the features in a product.</returns>
        public IEnumerable<LicenseFeature> GetEnabledLicenseProductFeatures(int productId)
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
        public LicenseProduct GetProduct(int productId)
        {
            return _licensingModel.LicenseProducts.SingleOrDefault(p => p.product_id == productId);
        }



        /// <summary>
        /// Add new License Product to Database
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="name"></param>
        /// <param name="active"></param>
        public void AddProduct(string sku, string name, bool active)
        {
            var newProduct = new LicenseProduct { sku = sku, name = name, active = active };
            _licensingModel.LicenseProducts.Add(newProduct);
            _licensingModel.SaveChanges();
        }

        /// <summary>
        /// Save changes to an existing License Product in Database
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="active"></param>
        public void UpdateProduct(int productId, string name, bool active)
        {

            var existingProduct = _licensingModel.LicenseProducts.SingleOrDefault(p => p.product_id == productId);
            if (existingProduct != null)
            {
                existingProduct.name = name;
                existingProduct.active = active;
                _licensingModel.LicenseProducts.Attach(existingProduct);
                _licensingModel.MarkAsModified(existingProduct);
            }
            _licensingModel.SaveChanges();
        }

        public bool CheckForSkuDuplicate(string sku)
        {
            var existingProduct = _licensingModel.LicenseProducts.SingleOrDefault(p => p.sku.Equals(sku));
            return existingProduct != null;
        }

        public void DeleteProduct(int productId)
        {
            var existingOrdersForProduct = _licensingModel.Orders.FirstOrDefault(o => o.product_id == productId);
            if (existingOrdersForProduct != null) throw new LicenseProductInUseException();
            var existingProduct = _licensingModel.LicenseProducts.SingleOrDefault(p => p.product_id == productId);
            _licensingModel.MarkAsDeleted(existingProduct);
            _licensingModel.SaveChanges();
        }



        /// <summary>
        /// Get a list of assigned features for indicated product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IEnumerable<LicenseDetail> GetLicenseProductFeatures(int productId)
        {
            return _licensingModel.LicenseDetails.Include(o => o.DetailType).Include(l => l.LicenseProduct).Where(f => f.product_id == productId).ToList().AsEnumerable();
        }

        public IEnumerable<DetailType> GetAllDetailTypes()
        {
            return _licensingModel.DetailTypes.ToList().AsEnumerable();
        }


        /// <summary>
        /// Check if a feature has already been added to a License Product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="detailTypeId"></param>
        /// <returns></returns>
        public bool CheckForFeatureDuplicate(int productId, int detailTypeId)
        {
            var existingProduct = _licensingModel.LicenseDetails.SingleOrDefault(p => p.detail_type_id == detailTypeId && p.product_id == productId);
            return existingProduct != null;
        }

        public void AddProductFeature(int productId, int detailTypeId)
        {
            var newProductFeature = new LicenseDetail { product_id = productId, detail_type_id = detailTypeId };
            _licensingModel.LicenseDetails.Add(newProductFeature);
            _licensingModel.SaveChanges();
        }

        /// <summary>
        /// Delete a feature from a License product.
        /// </summary>
        /// <param name="licenseFeatureId"></param>
        public void DeleteProductFeature(int licenseFeatureId)
        {
            var existingProductFeature = _licensingModel.LicenseDetails.SingleOrDefault(p => p.license_detail_id == licenseFeatureId);
            _licensingModel.MarkAsDeleted(existingProductFeature);
            _licensingModel.SaveChanges();
        }

        /// <summary>
        /// Gets all the active products.
        /// </summary>
        /// <returns>Returns an <see cref="IEnumerable{LicenseProduct}"/> containing all the active products.</returns>
        public IEnumerable<LicenseProduct> GetAllActiveProducts()
        { 
            return _licensingModel.LicenseProducts.Where(p => p.active == true).ToList().AsEnumerable();
        }
    }
}