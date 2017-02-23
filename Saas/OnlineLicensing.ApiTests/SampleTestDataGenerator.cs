using EPMLive.OnlineLicensing.Api.Data;

namespace EPMLive.OnlineLicensing.ApiTests
{
    public sealed class SampleTestDataGenerator
    {
        private const int MaxProducts = 5;
        public TestLicensingModel GenerateLicensingModelWithSampleProducts()
        {
            var licModel = new TestLicensingModel();

            for (var i = 0; i < MaxProducts; i++)
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
                    product_id = licenseProduct.product_id,
                    detail_type_id = 1,
                    license_detail_id = licDetailId++,
                    contract_id = 50008,
                    DetailType = new DetailType() { detail_name = "Full user", detail_type_id = 1, externalusers = false }
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
    }
}
