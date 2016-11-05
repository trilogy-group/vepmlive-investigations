using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSite.ZuoraAPI;
using System.Data;
using System.Data.SqlClient;

namespace BillingSite.zuora
{
    public partial class invoicepostedapi : System.Web.UI.Page
    {
        private bool bProcessed = false;

        private void processWE(ZuoraHelper zuora, RatePlan rate, string subscriptionid, DateTime expdate, string accountref, string contractid)
        {
            bProcessed = true;
            QueryResult qr = zuora.RunQuery("select Id, Name, IncludedUnits from ProductRatePlanCharge where ProductRatePlanId = '" + rate.ProductRatePlanId + "' and ChargeModel = 'Overage Pricing'");

            decimal storage = 10;

            foreach(ProductRatePlanCharge rpC in qr.records)
            {
                if(rpC != null)
                {
                    qr = zuora.RunQuery("select EndingUnit from ProductRatePlanChargeTier where ProductRatePlanChargeId = '" + rpC.Id + "'");
                    ProductRatePlanChargeTier tier = (ProductRatePlanChargeTier)qr.records[0];
                    decimal qty = tier.EndingUnit.Value;
                    if(qty == 1000000)
                        qty = -1;

                    switch(rpC.Name)
                    {
                        case "Storage":
                            storage = qty;
                            break;
                    };
                }
            }

            qr = zuora.RunQuery("select Quantity,IsLastSegment from RatePlanCharge where RatePlanId = '" + rate.Id + "' and ChargeType = 'Recurring' And Name = 'Users'");
            RatePlanCharge rpc = null;

            foreach(RatePlanCharge rpCTemp in qr.records)
            {
                if(rpCTemp.IsLastSegment.Value)
                {
                    rpc = rpCTemp;
                    break;
                }
            }

            if(rpc != null)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmliveaccounts"].ConnectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand("delete from orders where account_ref=@accountref and contractid=@contractid", cn);
                cmd.Parameters.AddWithValue("@accountref", accountref);
                cmd.Parameters.AddWithValue("@contractid", contractid);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO orders (account_ref, plimusReferenceNumber, quantity, diskspace, projects, expiration, version, enabled, contractid, plimusAccountId, billingsystem) VALUES (@accountref, @ref, @qty, @disk, 0, @expdate, 2, 1, @contractid, 0, 2)", cn);
                cmd.Parameters.AddWithValue("@accountref", accountref);
                cmd.Parameters.AddWithValue("@ref", subscriptionid);
                cmd.Parameters.AddWithValue("@qty", rpc.Quantity.Value);
                cmd.Parameters.AddWithValue("@disk", storage);
                cmd.Parameters.AddWithValue("@expdate", expdate.AddDays(2));
                cmd.Parameters.AddWithValue("@contractid", contractid);

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        private void processEPMLive(ZuoraHelper zuora, RatePlan rate, string subscriptionid, DateTime expdate, string accountref)
        {
            bProcessed = true;
            QueryResult qr = zuora.RunQuery("SELECT ProductId, ContractId__c from ProductRatePlan where Id='" + rate.ProductRatePlanId + "'");
            if(qr.records.Length > 0 && qr.records[0] != null)
            {
                ProductRatePlan prp = (ProductRatePlan)qr.records[0];

                if(!string.IsNullOrEmpty(prp.ContractId__c))
                {
                    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmliveaccounts"].ConnectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(@"delete from orders where order_id in (SELECT     order_id
                                                        FROM         dbo.ORDERS INNER JOIN
                                                                                dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER JOIN
                                                                                dbo.CONTRACTLEVEL_TITLES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTLEVEL_TITLES.CONTRACTLEVEL
                                                        WHERE     (dbo.CONTRACTLEVEL_TITLES.GroupId = 2) AND (dbo.ORDERS.account_ref = @account_ref))", cn);
                    cmd.Parameters.AddWithValue("@account_ref", accountref);
                    cmd.ExecuteNonQuery();

                    Guid orderid = Guid.NewGuid();

                    cmd = new SqlCommand("INSERT INTO ORDERS (order_id, account_ref, plimusReferenceNumber, quantity, expiration, plimusaccountid, version, contractid, billingsystem) VALUES (@order_id, @account_ref, @ref, @quantity, @expiration, 0, 2, @contractid, 2)", cn);
                    cmd.Parameters.AddWithValue("@order_id", orderid);
                    cmd.Parameters.AddWithValue("@account_ref", accountref);
                    cmd.Parameters.AddWithValue("@ref", subscriptionid);
                    cmd.Parameters.AddWithValue("@quantity", 1);
                    cmd.Parameters.AddWithValue("@expiration", expdate.AddDays(2));
                    cmd.Parameters.AddWithValue("@contractid", prp.ContractId__c);
                    cmd.ExecuteNonQuery();

                    qr = zuora.RunQuery("select Quantity,IsLastSegment,ProductRatePlanChargeId from RatePlanCharge where RatePlanId = '" + rate.Id + "' and ChargeType = 'Recurring'");

                    foreach(RatePlanCharge rpCTemp in qr.records)
                    {
                        if(rpCTemp.IsLastSegment.Value)
                        {
                            QueryResult qr2 = zuora.RunQuery("select DetailId__c from ProductRatePlanCharge where Id = '" + rpCTemp.ProductRatePlanChargeId + "'");

                            if(qr2.records.Length > 0 && qr2.records[0] != null)
                            {
                                ProductRatePlanCharge prpc = (ProductRatePlanCharge)qr2.records[0];

                                if(rpCTemp.Quantity.HasValue && !string.IsNullOrEmpty(prpc.DetailId__c))
                                {
                                    cmd = new SqlCommand("INSERT INTO ORDERDETAIL (order_id, detail_type_id, quantity) VALUES (@order_id, @detailid, @quantity)", cn);
                                    cmd.Parameters.AddWithValue("@order_id", orderid);
                                    cmd.Parameters.AddWithValue("@detailid", prpc.DetailId__c);
                                    cmd.Parameters.AddWithValue("@quantity", rpCTemp.Quantity.Value);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }



                    cn.Close();
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ZuoraHelper zuora = new ZuoraHelper();

            QueryResult qr = zuora.RunQuery("select AutoPay, AccountRef__c from account where id = '" + Request["AccountID"] + "'");

            if(qr.records.Length > 0 && qr.records[0] != null)
            {
                 Account acct = (Account)qr.records[0];

                 string accountref = acct.AccountRef__c;
                 string accountid = acct.Id;

                 if(!acct.AutoPay.Value)
                 {
                     qr = zuora.RunQuery("SELECT SubscriptionId,Id,ServiceEndDate,ProductId,ProductName,ChargeName,ChargeNumber,RatePlanChargeId from InvoiceItem where InvoiceId='" + Request["InvoiceId"] + "'");
                     
                     foreach(InvoiceItem item in qr.records)
                     {
                         
                         DateTime expdate = item.ServiceEndDate.Value.AddDays(2);
                         string subscriptionid = item.SubscriptionId;

                         //qr = zuora.RunQuery("SELECT OriginalId,Id from subscription where Id='" + subscriptionid + "'");

                         //Subscription tSub = (Subscription)qr.records[0];
                         
                         //qr = zuora.RunQuery("SELECT ProductRatePlanId, Id from RatePlan where SubscriptionId='" + subscriptionid + "'");

                         ////if(qr.records.Length > 0 && qr.records[0] != null)
                         //foreach(RatePlan rate in qr.records )
                         //{
                         //    //RatePlan rate = (RatePlan)qr.records[0];
                         QueryResult qr2 = zuora.RunQuery("SELECT Name, Id, IsLastSegment,RatePlanId from RatePlanCharge where Id='" + item.RatePlanChargeId + "'");

                        foreach(RatePlanCharge rpc in qr2.records)
                        {
                            if(rpc.IsLastSegment.Value)
                            {
                                qr = zuora.RunQuery("SELECT ProductRatePlanId, Id from RatePlan where Id='" + rpc.RatePlanId + "'");
                                if(qr.records.Length > 0 && qr.records[0] != null)
                                {
                                    RatePlan rate = (RatePlan)qr.records[0];

                                    qr = zuora.RunQuery("SELECT ProductId from ProductRatePlan where Id='" + rate.ProductRatePlanId + "'");
                                    if(qr.records.Length > 0 && qr.records[0] != null)
                                    {
                                        ProductRatePlan prp = (ProductRatePlan)qr.records[0];
                                        qr = zuora.RunQuery("SELECT SKU from Product where Id='" + prp.ProductId + "'");

                                        if(qr.records.Length > 0 && qr.records[0] != null)
                                        {
                                            Product product = (Product)qr.records[0];

                                            switch(product.SKU)
                                            {
                                                case "SKU-40000000":
                                                    if(rpc.Name == "Users")
                                                        processWE(zuora, rate, subscriptionid, expdate, accountref, "555666777");
                                                    break;
                                                case "SKU-20000000":
                                                    if(rpc.Name == "Users")
                                                        processWE(zuora, rate, subscriptionid, expdate, accountref, "222333444");
                                                    break;
                                                case "SKU-10000000":
                                                    if(rpc.Name == "Users")
                                                        processWE(zuora, rate, subscriptionid, expdate, accountref, "111222333");
                                                    break;
                                                case "SKU-00000002":
                                                    //processPE(zuora, rate, subscriptionid, expdate, accountref);
                                                    break;
                                                case "SKU-00000020":
                                                    processEPMLive(zuora, rate, subscriptionid, expdate, accountref);
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            if(bProcessed)
                                break;
                        }                             
                        if(bProcessed)
                            break;
                    }
                }
            }
        }
    }
}