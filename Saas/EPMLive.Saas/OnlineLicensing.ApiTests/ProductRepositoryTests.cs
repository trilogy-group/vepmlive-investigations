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
            var sampleProducts = new ProductRepository(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProducts()).GetAllProducts();
            Assert.IsNotNull(sampleProducts);
            Assert.IsTrue(sampleProducts.Any(), "No sample products found.");
        }

        [TestMethod()]
        public void GetEnabledLicenseProductFeaturesTest()
        {
            var enabledLicenseProductFeatures = new ProductRepository(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProductsAndFeatures()).GetEnabledLicenseProductFeatures(1);
            Assert.IsNotNull(enabledLicenseProductFeatures);
        }

        [TestMethod()]
        public void GetProductTest()
        {
            var firstSampleProduct = new ProductRepository(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProducts()).GetProduct(1);
            Assert.IsNotNull(firstSampleProduct);
            Assert.IsNotNull(firstSampleProduct.name);
        }

        [TestMethod()]
        public void GetLicenseProductFeaturesTest()
        {
            var enabledLicenseProductFeatures = new ProductRepository(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProductsAndFeatures()).GetLicenseProductFeatures(1);
            Assert.IsNotNull(enabledLicenseProductFeatures);
            Assert.IsTrue(enabledLicenseProductFeatures.Any(), "no product features found.");
        }

        [TestMethod()]
        public void GetAllDetailTypesTest()
        {
            var allDetailTypes = new ProductRepository(new SampleTestDataGenerator().GenerateLicensingModelWithSampleDetailTypes()).GetAllProducts();
            Assert.IsNotNull(allDetailTypes);
        }

        [TestMethod()]
        public void GetAllActiveProductsTest()
        {
            var activeProducts = new ProductRepository(new SampleTestDataGenerator().GenerateLicensingModelWithSampleProducts()).GetAllActiveProducts();
            Assert.IsNotNull(activeProducts);
        }
    }
}