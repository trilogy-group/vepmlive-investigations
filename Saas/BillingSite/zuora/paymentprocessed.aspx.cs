using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSite.ZuoraAPI;
using System.Data;
using System.Data.SqlClient;

namespace BillingSite
{
    public partial class paymentprocessed : System.Web.UI.Page
    {
        private void processPE(ZuoraHelper zuora, RatePlan rate, string subscriptionid, DateTime expdate, string accountref)
        {
            QueryResult qr = zuora.RunQuery("select Id, Name, IncludedUnits from ProductRatePlanCharge where ProductRatePlanId = '" + rate.ProductRatePlanId + "' and ChargeModel = 'Overage Pricing'");

            decimal projects = 1;
            decimal storage = 10;
            decimal users = -1;

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
                        case "Projects":
                            projects = qty;
                            break;
                        case "Storage":
                            storage = qty;
                            break;
                        case "Users":
                            users = qty;
                            break;
                    };
                }
            }

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmliveaccounts"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("delete from orders where account_ref=@accountref and contractid=111821378", cn);
            cmd.Parameters.AddWithValue("@accountref", accountref);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("INSERT INTO orders (account_ref, plimusReferenceNumber, quantity, diskspace, projects, expiration, version, enabled, contractid, plimusAccountId, billingsystem) VALUES (@accountref, @ref, @qty, @disk, @projects, @expdate, 2, 1, 111821378, 0, 2)", cn);
            cmd.Parameters.AddWithValue("@accountref", accountref);
            cmd.Parameters.AddWithValue("@ref", subscriptionid);
            cmd.Parameters.AddWithValue("@qty", users);
            cmd.Parameters.AddWithValue("@disk", storage);
            cmd.Parameters.AddWithValue("@expdate", expdate.AddDays(2));
            cmd.Parameters.AddWithValue("@projects", projects);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void processWE(ZuoraHelper zuora, RatePlan rate, string subscriptionid, DateTime expdate, string accountref, string contractid)
        {
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

            qr = zuora.RunQuery("select Quantity,Name from RatePlanCharge where RatePlanId = '" + rate.Id + "' and ChargeType = 'Recurring' and IsLastSegment=true and Name='Users'");

            RatePlanCharge rpc = (RatePlanCharge)qr.records[0];

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

        private void processInvoice(ZuoraHelper zuora, InvoiceItem item, string accountref, bool onlyv2)
        {
            DateTime expdate = item.ServiceEndDate.Value;
            string subscriptionid = item.SubscriptionId;
            
            QueryResult qr = zuora.RunQuery("SELECT OriginalId,Id from subscription where Id='" + subscriptionid + "'");

            Subscription tSub = (Subscription)qr.records[0];

            qr = zuora.RunQuery("SELECT ProductRatePlanId, Id from RatePlan where SubscriptionId='" + subscriptionid + "'");

            foreach(RatePlan rate in qr.records)
            {
                //RatePlan rate = (RatePlan)qr.records[0];

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
                                if(!onlyv2)
                                    processWE(zuora, rate, subscriptionid, expdate, accountref, "555666777");
                                break;
                            case "SKU-20000000":
                                if(!onlyv2)
                                    processWE(zuora, rate, subscriptionid, expdate, accountref, "222333444");
                                break;
                            case "SKU-00000002":
                                if(!onlyv2)
                                    processPE(zuora, rate, subscriptionid, expdate, accountref);
                                break;
                            case "SKU-00000020":
                                processEPMLive(zuora, rate, subscriptionid, expdate, accountref);
                                break;
                        }

                    }
                }
            }
        }

        private void processEPMLive(ZuoraHelper zuora, RatePlan rate, string subscriptionid, DateTime expdate, string accountref)
        {

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
                if(acct.AutoPay.Value)
                {
                    string accountref = acct.AccountRef__c;
                    string accountid = acct.Id;

                    qr = zuora.RunQuery("SELECT InvoiceId from InvoicePayment where Paymentid='" + Request["PaymentId"] + "'");

                    if(qr.records.Length > 0 && qr.records[0] != null)
                    {
                        InvoicePayment payment = (InvoicePayment)qr.records[qr.records.Length - 1];

                        //qr = zuora.RunQuery("SELECT SubscriptionId,Id,ServiceEndDate,ProductId,ProductName from InvoiceItem where InvoiceId='" + payment.InvoiceId + "' And ProductName='Base Charge'");
                        
                        qr = zuora.RunQuery("SELECT SubscriptionId,Id,ServiceEndDate,ProductId,ProductName,ChargeName from InvoiceItem where InvoiceId='" + payment.InvoiceId + "' And ChargeName='Base Charge'");

                        if(qr.records.Length > 0 && qr.records[0] != null)
                        {
                            InvoiceItem item = (InvoiceItem)qr.records[0];

                            processInvoice(zuora, item, accountref, false);
                        }
                        else
                        {
                            qr = zuora.RunQuery("SELECT SubscriptionId,Id,ServiceEndDate,ProductId,ProductName from InvoiceItem where InvoiceId='" + payment.InvoiceId + "' And ChargeName='Users'");

                            if(qr.records.Length > 0 && qr.records[0] != null)
                            {
                                InvoiceItem item = (InvoiceItem)qr.records[0];

                                processInvoice(zuora, item, accountref, false);
                            }
                            else
                            {
                                qr = zuora.RunQuery("SELECT SubscriptionId,Id,ServiceEndDate,ProductId,ProductName from InvoiceItem where InvoiceId='" + payment.InvoiceId + "'");

                                if(qr.records.Length > 0 && qr.records[0] != null)
                                {
                                    InvoiceItem item = (InvoiceItem)qr.records[0];

                                    processInvoice(zuora, item, accountref, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}