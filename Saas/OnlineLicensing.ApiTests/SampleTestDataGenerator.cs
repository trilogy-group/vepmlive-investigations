using EPMLive.OnlineLicensing.Api.Data;
using System;

namespace EPMLive.OnlineLicensing.ApiTests
{
    public sealed class SampleTestDataGenerator
    {
        private const int MAX_PRODUCTS = 5;
        public TestLicensingModel GenerateLicensingModelWithSampleProducts()
        {
            var licModel = new TestLicensingModel();

            for (var i = 0; i < MAX_PRODUCTS; i++)
            {
                licModel.LicenseProducts.Add(
                    new LicenseProduct()
                    {
                        product_id = i + 1,
                        name = $"Sample Product {i + 1}",
                        active = (i % 2) == 1
                    }
                );
            }
            return licModel;

        }

        public TestLicensingModel GenerateLicensingModelWithSampleProductsAndFeatures()
        {
            var licModel = GenerateLicensingModelWithSampleProducts();

            var licDetailId = 1;
            foreach (var licenseProduct in licModel.LicenseProducts)
            {
                licModel.LicenseDetails.Add(new LicenseDetail()
                {
                    product_id =  licenseProduct.product_id,
                    detail_type_id = 1,
                    license_detail_id = licDetailId++,
                    contract_id =  50008
                });
            }
            

            return licModel;

        }

        public TestLicensingModel GenerateLicensingModelWithSampleDetailTypes()
        {
            var licModel = new TestLicensingModel();

            licModel.DetailTypes.Add(new DetailType()
            {
                detail_type_id = 1,
                detail_name = "Full user",
                externalusers = false
            });
            licModel.DetailTypes.Add(new DetailType()
            {
                detail_type_id = 1,
                detail_name = "Team member",
                externalusers = false
            });
            licModel.DetailTypes.Add(new DetailType()
            {
                detail_type_id = 1,
                detail_name = "External user",
                externalusers = true
            });

            return licModel;
        }

        public TestLicensingModel GenerateLicensingModelWithSampleActiveOrder()
        {
            var licModel = new TestLicensingModel();

            licModel.Orders.Add(new Order
            {
                order_id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                account_ref = 11111,
                activation = DateTime.Parse("01/17/2016"),
                expiration = DateTime.Parse("01/17/2018"),
                product_id = 9,
                contractid = "50000010",
                plimusReferenceNumber = "00000",
                dtcreated = DateTime.Now,
                quantity = 1,
                version = 2,
                enabled = true,
                billingsystem = 3
            });

            return licModel;
        }

        public TestLicensingModel GenerateLicensingModelWithSampleActiveOrderAndDetails()
        {
            var licModel = new TestLicensingModel();

            licModel.Orders.Add(new Order
            {
                order_id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                account_ref = 11111,
                activation = DateTime.Parse("01/17/2016"),
                expiration = DateTime.Parse("01/17/2018"),
                product_id = 9,
                contractid = "50000010",
                plimusReferenceNumber = "00000",
                dtcreated = DateTime.Now,
                quantity = 1,
                version = 2,
                enabled = true,
                billingsystem = 3
            });

            licModel.OrderDetails.Add(
                new OrderDetail
                {
                    order_detail_id = Guid.NewGuid(),
                    order_id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    detail_type_id = 1,
                    quantity = 5
                });

            licModel.OrderDetails.Add(
                           new OrderDetail
                           {
                               order_detail_id = Guid.NewGuid(),
                               order_id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                               detail_type_id = 3,
                               quantity = 10
                           });
         

            return licModel;
        }
    }
}
