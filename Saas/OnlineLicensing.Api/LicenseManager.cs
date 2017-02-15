using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EPMLive.OnlineLicensing.Api.Data;

namespace EPMLive.OnlineLicensing.Api
{
    /// <summary>
    /// Class to manage all the license related options.
    /// </summary>
    public class LicenseManager : IDisposable
    {
        protected bool Disposed { get; private set; }

        /// <summary>
        /// Gets all the licences currently active in the account. There should only be one license active per product in the account.
        /// </summary>
        /// <param name="accountRef">The account reference number.</param>
        /// <returns>Return an <see cref="IEnumerable{LicenseOrder}"/> containing all the active licenses in the account.</returns>
        public static IEnumerable<LicenseOrder> GetAllActiveLicenses(int accountRef)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var orders = context.Orders.Include(o => o.LicenseProduct).Where(l => l.account_ref == accountRef && l.enabled == true && l.activation <= DateTime.Now && l.expiration > DateTime.Now).ToList();

                foreach (var item in orders)
                {
                    var productId = item.product_id ?? 0;
                    var productName = item.LicenseProduct != null ? item.LicenseProduct.name : string.Empty;

                    var featureDetails = new StringBuilder();

                    foreach (var itemDetails in context.OrderDetails.Where(o => o.order_id == item.order_id).ToList())
                    {
                        var matchingDetailType = context.DetailTypes.SingleOrDefault(d => d.detail_type_id == itemDetails.detail_type_id);
                        if (matchingDetailType != null)
                        {
                            var featureName = matchingDetailType.detail_name;
                            featureDetails.Append(featureName);
                        }
                        featureDetails.Append(":");
                        featureDetails.Append(' ', 90);
                        featureDetails.Append(itemDetails.quantity);
                        featureDetails.Append("<br />");
                    }

                    yield return new LicenseOrder
                    {
                        ProductId = productId,
                        OrderId = item.order_id.ToString(),
                        Product = productName,
                        Features = featureDetails.ToString(),
                        ExpirationDate = item.expiration.ToShortDateString()
                    };
                }
            }
        }

        public static IEnumerable<LicenseContract> GetAllContractLevelTitles()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.ContractLevelTitles.Include(clt => clt.ContractLevels).Where(c=>c.DETAIL_ID != null).Select(c => new LicenseContract { ContractId = c.ContractLevels.FirstOrDefault().contractId, ContractName = c.TITLE, }).ToList().AsEnumerable();
            }
        }

        /// <summary>
        /// Adds a new license to an account.
        /// </summary>
        /// <param name="accountRef">The account reference number.</param>
        /// <param name="activationDate">The date of activation of the license.</param>
        /// <param name="expirationDate">The date of expiration of the license.</param>
        /// <param name="productId">The id of the purchased product.</param>
        /// <param name="contractid"></param>
        /// <param name="featureList">Contains the quantity of seats for every product feature.</param>
        public void AddLicense(int accountRef, DateTime activationDate, DateTime expirationDate, int productId, string contractid, List<Tuple<int, int>> featureList)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var orderToAdd = new Order()
                {
                    order_id = Guid.NewGuid(),
                    account_ref = accountRef,
                    activation = activationDate,
                    expiration = expirationDate,
                    product_id = productId,
                    contractid = contractid,
                    plimusReferenceNumber = "00000",
                    dtcreated = DateTime.Now,
                    quantity = 1,
                    version = 2,
                    enabled = true,
                    billingsystem = 3
                };

                foreach (var item in featureList)
                {
                    orderToAdd.OrderDetails.Add(AddLicenseDetails(orderToAdd.order_id, item));
                }

                context.Orders.Add(orderToAdd);
                context.SaveChanges();

            }
        }

        /// <summary>
        /// Adds a new order detail to an order. The order details contains the information of how many seats are purchased for that license.
        /// </summary>
        /// <param name="orderId">The id of the related order</param>
        /// <param name="Feature">A tuple of the product feature and the quantity of seats purchased for that product.</param>
        /// <returns>Returns an OrderDetail item to be added to the License/Order object to be created.</returns>
        public OrderDetail AddLicenseDetails(Guid orderId, Tuple<int, int> Feature)
        {
            return new OrderDetail
            {
                order_detail_id = Guid.NewGuid(),
                order_id = orderId,
                detail_type_id = Feature.Item1,
                quantity = Feature.Item2
            };
        }

        public void RenewLicense(Guid orderId, DateTime expirationDate)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var order = context.Orders.Single(o => o.order_id == orderId);
                order.expiration = expirationDate;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Validates whether an account have an active license for the specified product.
        /// </summary>
        /// <param name="ProductID">The id of the product to check for existance.</param>
        /// <param name="accountRef">The reference to the account with active licenses.</param>
        /// <returns>Returns true if there is already an active license for that product. Returns false if there isn't an active license for that product.</returns>
        public bool ValidateSingleActiveLicenseForProduct(int ProductID, int accountRef)
        {
            return GetAllActiveLicenses(accountRef).Any(al => al.ProductId == ProductID);
        }

        /// <summary>
        /// Checks that license is at least 1 day.
        /// </summary>
        /// <returns>Returns false if there is not a valid license period, returns true if the license period is valid</returns>
        public bool ValidLicensePeriod(DateTime activationDate, DateTime expirationDate)
        {
            return ((expirationDate > activationDate) && (expirationDate >= activationDate.AddDays(1)));
        }

        /// <summary>
        /// Check that no quantities are zero.
        /// </summary>
        /// <returns>Returns false if there is quantities for the features are all zero, returns true otherwise.</returns>
        public bool ValidateQuantitiesCannotBeAllZero(List<Tuple<int, int>> featuresAndQuantities)
        {
            return featuresAndQuantities.Any(fq => fq.Item2 > 0);
        }

        public bool ValidateNewLicenseExtension(Guid orderId, DateTime newExpirationDate)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var order = context.Orders.SingleOrDefault(o => o.order_id == orderId);
                return order.expiration < newExpirationDate;
            }
        }

        /// <summary>
        /// Disposes object to the Garbage Collector.
        /// </summary>
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

    /// <summary>
    /// Class to represent the purchased licenses in an account.
    /// </summary>
    public class LicenseOrder
    {
        public int ProductId { get; set; }
        public string OrderId { get; set; }
        public string Product { get; set; }
        public string Features { get; set; }
        public string ExpirationDate { get; set; }
    }

    /// <summary>
    /// Class to represent the available features in a product.
    /// </summary>
    public class LicenseFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// a License Contract: Ultimtate, Professional, etc.
    /// </summary>
    public class LicenseContract
    {
        public string ContractName { get; set; }
        public string ContractId { get; set; }
    }
}
