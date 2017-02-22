using System.Linq;
using EPMLive.OnlineLicensing.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLive.OnlineLicensing.ApiTests
{
    [TestClass()]
    public class ProductCatalogManagerTests
    {
        [TestMethod()]
        public void GetAllProductsTest()
        {
            var sampleProducts = new ProductCatalogManager(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProducts).GetAllProducts();
            Assert.IsNotNull(sampleProducts);
            Assert.IsTrue(sampleProducts.Any(), "No sample products found.");
        }

        [TestMethod()]
        public void GetEnabledLicenseProductFeaturesTest()
        {
            var enabledLicenseProductFeatures = new ProductCatalogManager(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProductsAndFeatures).GetEnabledLicenseProductFeatures(1);
            Assert.IsNotNull(enabledLicenseProductFeatures);
            Assert.IsTrue(enabledLicenseProductFeatures.Any(), "no product features found.");
        }

        [TestMethod()]
        public void GetProductTest()
        {
            var firstSampleProduct = new ProductCatalogManager(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProducts).GetProduct(1);
            Assert.IsNotNull(firstSampleProduct);
            Assert.IsNotNull(firstSampleProduct.name);
        }

        [TestMethod()]
        public void AddProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckForSkuDuplicateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLicenseProductFeaturesTest()
        {
            var enabledLicenseProductFeatures = new ProductCatalogManager(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProductsAndFeatures).GetLicenseProductFeatures(1);
            Assert.IsNotNull(enabledLicenseProductFeatures);
            Assert.IsTrue(enabledLicenseProductFeatures.Any(), "no product features found.");
        }

        [TestMethod()]
        public void GetAllDetailTypesTest()
        {
            var allDetailTypes = new ProductCatalogManager(new SampleTestDataGenerator().GenerateLicensingModelWithSampleDetailTypes).GetAllProducts();
            Assert.IsNotNull(allDetailTypes);
            Assert.IsTrue(allDetailTypes.Any(), "No sample products found.");
        }

        [TestMethod()]
        public void CheckForFeatureDuplicateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddProductFeatureTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteProductFeatureTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllActiveProductsTest()
        {
            var activeProducts = new ProductCatalogManager(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProducts).GetAllActiveProducts();
            Assert.IsNotNull(activeProducts);
            Assert.IsTrue(activeProducts.Any(), "No active products found.");
        }
    }
}