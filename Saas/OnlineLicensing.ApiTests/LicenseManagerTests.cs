using EPMLive.OnlineLicensing.Api;
using EPMLive.OnlineLicensing.Api.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPMLive.OnlineLicensing.ApiTests
{
    [TestClass]
    public class LicenseManagerTests
    {
        [TestMethod]
        public void GetAllActiveLicenses()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrder();
            var licenseManager = new LicenseManager(context);
            var accountRef = 11111;

            //act
            var result = licenseManager.GetAllActiveLicenses(accountRef);

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetOrder()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrder();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            //act
            var result = licenseManager.GetOrder(OrderId);

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Order));
        }

        [TestMethod]
        public void GetOrderDetails()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrderAndDetails();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var orderFeatures = new List<LicenseFeature>
            {
                new LicenseFeature
                {
                    Id = 1,
                    Name = "Team Member"
                },

                new LicenseFeature
                {
                    Id = 3,
                    Name = "Full User"
                }
            };


            //act 
            var result = licenseManager.GetOrderDetails(OrderId, orderFeatures);

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void AddLicense()
        {
            //arrange
            var licenseManager = new LicenseManager(new TestLicensingModel());
            var accountRef = 11111;
            var activationDate = DateTime.Now;
            var expirationDate = DateTime.Now.AddMonths(5);
            var productId = 1;
            var contractId = "000001";
            var featureList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 5),
                new Tuple<int, int>(3,10)
            };

            //act
            licenseManager.AddLicense(accountRef, activationDate, expirationDate, productId, contractId, featureList);
            var result = licenseManager.GetAllActiveLicenses(accountRef);

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void RenewLicense()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrderAndDetails();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var expirationDate = DateTime.Parse("01/17/2020");
           
            //act
            licenseManager.RenewLicense(OrderId, expirationDate);

            //assert
            Assert.IsFalse(context.Orders.Any(o => o.order_id == OrderId));
            Assert.IsTrue(context.OrderHistories.Any(o => o.order_id == OrderId));
        }

        [TestMethod]
        public void DeleteLicense()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrderAndDetails();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            
            //act
            licenseManager.DeleteLicense(OrderId, string.Empty);

            //assert
            Assert.IsFalse(context.Orders.Any(o => o.order_id == OrderId));
            Assert.IsTrue(context.OrderHistories.Any(o => o.order_id == OrderId));
        }

        [TestMethod]
        public void ExtendLicense()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrderAndDetails();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var activationDate = DateTime.Parse("02/17/2016");
            var expirationDate = DateTime.Parse("02/17/2021");
            var features = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1,100),
                new Tuple<int, int>(3,50)
            };

            //act
            licenseManager.ExtendLicense(OrderId, activationDate, expirationDate, features);
            var result = context.Orders.Include("OrderDetails").SingleOrDefault(o => o.order_id == OrderId);

            //assert
            Assert.AreEqual(activationDate, result.activation);
            Assert.AreEqual(expirationDate, result.expiration);

            foreach (var item in result.OrderDetails)
            {
                Assert.AreEqual(features.SingleOrDefault(f => f.Item1 == item.detail_type_id).Item2, item.quantity);
            }

        }

        [TestMethod]
        public void ValidateSingleActiveLicenseForProduct_ReturnsTrueWhenAnotherLicenseExistsForTheProduct()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrder();
            var licenseManager = new LicenseManager(context);
            var productId = 9;
            var accountRef = 11111;

            //act
            var result = licenseManager.ValidateSingleActiveLicenseForProduct(productId, accountRef);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateSingleActiveLicenseForProduct_ReturnsTrueWhenNoOtherLicenseExistsForTheProduct()
        {
            //arrange
            var licenseManager = new LicenseManager(new TestLicensingModel());
            var productId = 9;
            var accountRef = 11111;

            //act
            var result = licenseManager.ValidateSingleActiveLicenseForProduct(productId, accountRef);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidLicensePeriod_ReturnsFalseIfExpirationDateNotGreaterThanActivationDate()
        {
            //arrange
            var licenseManager = new LicenseManager(new TestLicensingModel());
            var activationDate = DateTime.Now;
            var expirationDate = DateTime.Now;

            //act
            var result = licenseManager.ValidateLicensePeriod(activationDate, expirationDate);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidLicensePeriod_ReturnsTrueIfExpirationDateIsGreaterThanActivationDate()
        {
            //arrange
            var licenseManager = new LicenseManager(new TestLicensingModel());
            var activationDate = DateTime.Now;
            var expirationDate = DateTime.Now.AddDays(1);

            //act
            var result = licenseManager.ValidateLicensePeriod(activationDate, expirationDate);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateQuantitiesCannotBeAllZero_ReturnsFalseWhenAllQuantitiesAreZero()
        {
            //arrange
            var licenseManager = new LicenseManager(new TestLicensingModel());
            var features = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0)
            };

            //act
            var result = licenseManager.ValidateQuantitiesCannotBeAllZero(features);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateQuantitiesCannotBeAllZero_ReturnsTrueWhenAtLeastOneQuantityIsNotZero()
        {
            //arrange
            var licenseManager = new LicenseManager(new TestLicensingModel());
            var features = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 15),
                new Tuple<int, int>(3, 0)
            };

            //act
            var result = licenseManager.ValidateQuantitiesCannotBeAllZero(features);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateNewLicenseExtension_ReturnsFalseWhenNewExpirationDateIsLowerThanOldExpirationDate()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrder();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var expirationDate = DateTime.Parse("01/01/2010");

            //act
            var result = licenseManager.ValidateNewLicenseExtension(OrderId, expirationDate);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateNewLicenseExtension_ReturnsTrueWhenNewExpirationDateIsGreaterThanOldExpirationDate()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleActiveOrder();
            var licenseManager = new LicenseManager(context);
            var OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var expirationDate = DateTime.Parse("01/01/2020");

            //act
            var result = licenseManager.ValidateNewLicenseExtension(OrderId, expirationDate);

            //assert
            Assert.IsTrue(result);
        }
    }
}
