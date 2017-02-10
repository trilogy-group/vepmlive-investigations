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

        public static IEnumerable<vwAccountOrder> GetAllLicenses()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.vwAccountOrders.ToList().AsEnumerable(); //for that particular order
            }
            
        }

        public void AddLicense(int accountRef, DateTime activationDate, DateTime expirationDate, List<Tuple<int,int>> FeatureList)
        {
            using (var context = ConnectionHelper.CreateLicensingModel("server=win-6j09gf4nbp8;database=EPMLIVEdb;User ID=epmlivedb;Password=MCjhfd4562D^7"))
            {
                var orderToAdd = new ORDER()
                {
                    order_id = Guid.NewGuid(),
                    account_ref = accountRef, 
                    activation = activationDate, 
                    expiration = expirationDate, 
                    contractid = "50000010",

                    plimusReferenceNumber = "00000", 
                    quantity = 1,
                    version = 2,
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
}
