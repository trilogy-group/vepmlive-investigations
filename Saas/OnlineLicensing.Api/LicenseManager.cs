using OnlineLicensing.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLicensing.Api
{
    public class LicenseManager : IDisposable
    {
        protected bool Disposed { get; private set; }

        public static IEnumerable<LicenseOder> GetAllActiveLicenses(int accountRef)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var orders = context.ORDERS.Where(l => l.account_ref == accountRef && l.enabled == true &&  l.activation <= DateTime.Now && l.expiration > DateTime.Now).ToList();

                foreach (var item in orders)
                {
                    var productName = item.product_id != null ? context.LICENSEPRODUCTS.SingleOrDefault(l => l.product_id == item.product_id).name ?? string.Empty : string.Empty;

                    var featureDetails = new StringBuilder();

                    foreach (var itemDetails in context.ORDERDETAILs.Where(o => o.order_id == item.order_id).ToList())
                    {
                        var featureName = context.DETAILTYPES.SingleOrDefault(d => d.detail_type_id == itemDetails.detail_type_id).detail_name;
                        featureDetails.Append(featureName);
                        featureDetails.Append(":");
                        featureDetails.Append(' ', 90);
                        featureDetails.Append(itemDetails.quantity);
                        featureDetails.Append("<br />");
                    }

                    yield return new LicenseOder
                    { 
                        Product = productName,
                        Features = featureDetails.ToString(),
                        ExpirationDate = item.expiration.ToShortDateString()
                    };
                }


            }
        }

        public void AddLicense(int accountRef, DateTime activationDate, DateTime expirationDate, int productId,List<Tuple<int,int>> FeatureList)
        {
            using (var context = ConnectionHelper.CreateLicensingModel("server=win-6j09gf4nbp8;database=EPMLIVEdb;User ID=epmlivedb;Password=MCjhfd4562D^7"))
            {
                var orderToAdd = new ORDER()
                {
                    order_id = Guid.NewGuid(),
                    account_ref = accountRef, 
                    activation = activationDate, 
                    expiration = expirationDate,
                    product_id = productId,
                     
                    contractid = "50000010",
                    plimusReferenceNumber = "00000",
                    dtcreated = DateTime.Now, 
                    quantity = 1,
                    version = 2,
                    enabled = true,
                    billingsystem = 3
            };

                foreach (var item in FeatureList)
                {
                    orderToAdd.ORDERDETAILs.Add(AddLicenseDetails(orderToAdd.order_id, item));
                }
                
                context.ORDERS.Add(orderToAdd);
                context.SaveChanges();

            }
        }

        public ORDERDETAIL AddLicenseDetails(Guid orderId, Tuple<int,int> Feature )
        {
            return new ORDERDETAIL
            {
                order_detail_id = Guid.NewGuid(),
                order_id = orderId,
                detail_type_id = Feature.Item1, //this is the license type, full user, can be hardcoded 
                quantity = Feature.Item2 //this value should come as a parameter
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }
    }

    public class LicenseOder
    {
        public string Product { get; set; }
        public string Features { get; set; }
        public string ExpirationDate { get; set; }
    }
}
