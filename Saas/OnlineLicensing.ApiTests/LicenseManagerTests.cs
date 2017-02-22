using EPMLive.OnlineLicensing.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLive.OnlineLicensing.ApiTests
{
    [TestClass]
    public class LicenseManagerTests
    {
        [TestMethod]
        public void GetAllActiveLicenses()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetOrder()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetOrderDetails()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void AddLicense()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void RenewLicense()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void DeleteLicense()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void ExtendLicense()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void ValidateSingleActiveLicenseForProduct()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void ValidLicensePeriod_ReturnsFalseIfExpirationDateNotGreaterThanActivationDate()
        {
            //arrange
            var licenseManager = new LicenseManager();
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
            var licenseManager = new LicenseManager();
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
            var licenseManager = new LicenseManager();
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
            var licenseManager = new LicenseManager();
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
        public void ValidateNewLicenseExtension()
        {
            //arrange
            var licenseManager = new LicenseManager();

            //act
            //licenseManager.ValidateNewLicenseExtension();

            //assert
            Assert.IsTrue(false);
        }
    }
}
