using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EPMLive.OnlineLicensing.Api.Data;
using EPMLive.OnlineLicensing.Api.Exceptions;
using System.Collections;
using System.Data.Entity.Infrastructure;

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
        public IEnumerable<LicenseOrder> GetAllActiveLicenses(int accountRef)
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

        /// <summary>
        /// Gets one specific order / license based on the id of the order.
        /// </summary>
        /// <param name="orderId">The Id of the license to return.</param>
        /// <returns>Returns an <see cref="Order"/> license.</returns>
        public Order GetOrder(Guid orderId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.Orders.Include("OrderDetails").SingleOrDefault(o => o.order_id == orderId);
            }
        }

        /// <summary>
        /// Gets all the order details for a particular order / license.
        /// </summary>
        /// <param name="orderId">The Id of the license to get the details from.</param>
        /// <returns>Return an <see cref="IEnumerable{LicenseFeature}"/> with all the features and quantities set for that order.</returns>
        public IEnumerable<LicenseFeature> GetOrderDetails(Guid orderId, int productId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                ILicensingModel licensingModel = new LicensingModel();

                var productCatalogManager = new ProductCatalogManager(ConnectionHelper.CreateLicensingModel);
                var orderFeatures = productCatalogManager.GetEnabledLicenseProductFeatures(productId);

                foreach (var item in orderFeatures)
                {
                    var feature = context.DetailTypes.SingleOrDefault(d => d.detail_type_id == item.Id);
                    var orderDetails = (context.OrderDetails.SingleOrDefault(o => o.order_id == orderId && o.detail_type_id == item.Id));

                    yield return new LicenseFeature
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        Value = orderDetails != null ? Convert.ToInt32(orderDetails.quantity) : 0
                    };
                }
            }
        }

        /// <summary>
        /// Gets all the licences currently active in the account. There should only be one license active per product in the account.
        /// </summary>
        /// <param name="accountRef">The account reference number.</param>
        /// <returns>Return an <see cref="IEnumerable{LicenseOrder}"/> containing all the active licenses in the account.</returns>
        public static IEnumerable<LicenseOrder> GetAllInactiveLicenses(int accountRef)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var orders = context.OrderHistories.Include(o => o.LicenseProduct).Where(l => l.account_ref == accountRef).ToList();

                foreach (var item in orders)
                {
                    var productId = item.product_id ?? 0;
                    var productName = item.LicenseProduct != null ? item.LicenseProduct.name : string.Empty;
                    var reason = GetArchiveReason(item.reason);
                    var reasonComment = item.reason_comment;
                    var featureDetails = new StringBuilder();

                    foreach (var itemDetails in context.OrderDetailHistories.Where(o => o.order_id == item.order_id).ToList())
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

                    yield return new InactiveLicenseOrder
                    {
                        ProductId = productId,
                        Product = productName,
                        Features = featureDetails.ToString(),
                        ExpirationDate = item.expiration.ToShortDateString(),
                        ReasonText = reason,
                        Comment = reasonComment
                    };
                }
            }
        }

        private static string GetArchiveReason(int itemReason)
        {
            var reasonValue = (LicenseArchiveReasons)itemReason;
            switch (reasonValue)
            {
                case LicenseArchiveReasons.Revoked:
                    return "Revoked";
                case LicenseArchiveReasons.Expired:
                    return "Expired";
                default:
                    throw new InvalidArchiveReasonEnumException();
            }
        }

        public static IEnumerable<LicenseContract> GetAllContractLevelTitles()
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.ContractLevelTitles.Include(clt => clt.ContractLevels).Where(c => c.DETAIL_ID != null).Select(c => new LicenseContract { ContractId = c.ContractLevels.FirstOrDefault().contractId, ContractName = c.TITLE, }).ToList().AsEnumerable();
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
                    orderToAdd.OrderDetails.Add(FormatLicenseDetails(orderToAdd.order_id, item));
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
        public OrderDetail FormatLicenseDetails(Guid orderId, Tuple<int, int> Feature)
        {
            return new OrderDetail
            {
                order_detail_id = Guid.NewGuid(),
                order_id = orderId,
                detail_type_id = Feature.Item1,
                quantity = Feature.Item2
            };
        }

        /// <summary>
        /// Renews the license by creating a new license, setting the values to the current license and increasing the expiration date.
        /// </summary>
        /// <param name="orderId">The Id of the license to extend.</param>
        /// <param name="expirationDate">The new expiration date to set. The new date should be greater that the current date for the license.</param>
        public void RenewLicense(Guid orderId, DateTime expirationDate)
        {
            var order = GetOrder(orderId);

            var orderfeatures = new List<Tuple<int, int>>();

            foreach (var item in order.OrderDetails)
            {
                orderfeatures.Add(new Tuple<int, int>(Convert.ToInt32(item.detail_type_id), Convert.ToInt32(item.quantity)));
            }

            AddLicense(order.account_ref, order.activation.Value, expirationDate, order.product_id.Value, order.contractid, orderfeatures);
            DeleteLicense(order.order_id, string.Empty, LicenseArchiveReasons.Expired);

            //TODO: log the changes to the Account_log table
        }

        /// <summary>
        /// Removes an order from the active licenses list and adds it to the inactive licences list.
        /// </summary>
        /// <param name="orderId">The Id of the order to delete.</param>
        /// <param name="comment">A comment describing a reason for deletion.</param>
        /// <param name="reason">The reason for deletion, either expiration or revocation.</param>
        public void DeleteLicense(Guid orderId, string comment, LicenseArchiveReasons reason = LicenseArchiveReasons.Revoked)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var order = context.Orders.Include("OrderDetails").SingleOrDefault(o => o.order_id == orderId);

                AddOrderHistory(order, context, comment, reason);

                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds an order to the order history table.
        /// </summary>
        /// <param name="order">The order to add.</param>
        /// <param name="context">The current context of the database.</param>
        /// <param name="comment">A comment describing the reason for adding it to the history table.</param>
        /// <param name="reason">The reason for adding it, either expiration or revocation.</param>
        private void AddOrderHistory(Order order, LicensingModel context, string comment, LicenseArchiveReasons reason)
        {
            var orderHistory = new OrderHistory
            {
                history_id = Guid.NewGuid(),
                order_id = order.order_id,
                account_ref = order.account_ref,
                activation = order.activation,
                expiration = order.expiration,
                product_id = order.product_id,
                contractid = order.contractid,
                plimusReferenceNumber = order.plimusReferenceNumber,
                dtcreated = order.dtcreated,
                quantity = order.quantity,
                version = order.version,
                enabled = false,
                billingsystem = order.billingsystem,
                reason_comment = comment,
                reason = (int)reason
            };

            foreach (var item in order.OrderDetails)
            {
                orderHistory.OrderDetailHistories.Add(FormatOrderDetailsHistory(item));
            }

            context.OrderHistories.Add(orderHistory);
            context.SaveChanges();
        }

        /// <summary>
        /// Adding the order details to the history table.
        /// </summary>
        /// <param name="orderDetail">The details of the features being added to the history table.</param>
        /// <param name="context">The current context of the database.</param>
        private OrderDetailHistory FormatOrderDetailsHistory(OrderDetail orderDetail)
        {
            return new OrderDetailHistory
            {
                history_id = Guid.NewGuid(),
                order_detail_id = orderDetail.order_detail_id,
                order_id = (Guid)orderDetail.order_id,
                detail_type_id = orderDetail.detail_type_id,
                quantity = orderDetail.quantity
            }; ;
        }

        /// <summary>
        /// Extends the license by editing its properties.
        /// </summary>
        /// <param name="orderId">The Id of the license to be edited.</param>
        /// <param name="newActivationDate">The new activation date for the order. The activation date should be lower than the expiration date.</param>
        /// <param name="newExpirationDate">The new expiration date for the order. The expiration date should be greater than the activation date.</param>
        /// <param name="features">The list of the features with the quanities set for the order.</param>
        public void ExtendLicense(Guid orderId, DateTime newActivationDate, DateTime newExpirationDate, IEnumerable<Tuple<int, int>> features)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var license = context.Orders.Include("OrderDetails").SingleOrDefault(o => o.order_id == orderId);

                license.activation = newActivationDate;
                license.expiration = newExpirationDate;
                license.OrderDetails = ExtendLicenseDetail(features, license.OrderDetails, license.order_id);

                context.Entry(license).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edits an order details of an order. the order detals contains de information of how many seats are purchased for that license.
        /// </summary>
        /// <param name="features">The Id of the related order.</param>
        /// <param name="orderDetails">The collection of features containing the features and quantity of seats purchased for that product.</param>
        /// <returns>Returns a <see cref="ICollection{OrderDetail}"/>> collection to be edited to the order / license being edited.</returns>
        private ICollection<OrderDetail> ExtendLicenseDetail(IEnumerable<Tuple<int, int>> features, ICollection<OrderDetail> orderDetails, Guid orderId)
        {
            if (features.Count() > 0)
            {
                foreach (var item in features)
                {
                    var orderDetail = orderDetails.SingleOrDefault(o => o.detail_type_id == item.Item1);

                    if (item.Item2 > 0)
                    {
                        if (orderDetail != null)
                        {
                            orderDetail.quantity = item.Item2;
                        }
                        else
                        {
                            orderDetails.Add(new OrderDetail
                            {
                                order_detail_id = Guid.NewGuid(),
                                order_id = orderId,
                                detail_type_id = item.Item1,
                                quantity = item.Item2
                            });
                        }
                    }
                    else
                    {
                        orderDetails.Remove(orderDetail);
                    }
                }
            }

            return orderDetails;
        }

        /// <summary>
        /// Validates whether an account have an active license for the specified product.
        /// </summary>
        /// <param name="productId">The id of the product to check for existance.</param>
        /// <param name="accountRef">The reference to the account with active licenses.</param>
        /// <returns>Returns true if there is already an active license for that product. Returns false if there isn't an active license for that product.</returns>
        public bool ValidateSingleActiveLicenseForProduct(int productId, int accountRef)
        {
            return GetAllActiveLicenses(accountRef).Any(al => al.ProductId == productId);
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

        /// <summary>
        /// Validates that the new expiration date proposed is greater than the current expiration date.
        /// </summary>
        /// <param name="orderId">The Id of the license to renew.</param>
        /// <param name="newExpirationDate">The new expiration date proposed.</param>
        /// <returns>Returns true if the current expiration date is lower than the proposed expiration date. Returns false otherwise.</returns>
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

    public class InactiveLicenseOrder : LicenseOrder
    {
        public string ReasonText { get; set; }
        public string Comment { get; set; }
    }

    /// <summary>
    /// Class to represent the available features in a product.
    /// </summary>
    public class LicenseFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
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
