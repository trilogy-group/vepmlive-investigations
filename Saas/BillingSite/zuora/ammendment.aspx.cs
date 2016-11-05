using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSite.ZuoraAPI;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.Collections;

namespace BillingSite.zuora
{
    public partial class ammendment : System.Web.UI.Page
    {
        private bool bIsDedicated = false;
        private StringBuilder sbDescription = new StringBuilder();
        private const string sAssignedTo = "13;#David DeGunther";
        private decimal iUsers = 0;

        private bool IsDedicatedItem(string sAccountingCode)
        {
            switch(sAccountingCode)
            {
                case "DED_APP":
                case "DED_SQL":
                case "P_DED_SQL":
                case "DED": 
                    return true;
            };
            return false;
        }

        private bool ValidEndDate(RatePlanCharge rpc, DateTime ContractDate)
        {
            if(rpc.EffectiveEndDateSpecified)
            {
                if(rpc.EffectiveEndDate <= ContractDate)
                    return false;
                return true;
            }
            else
            {
                return true;
            }
        }

        private void ProcessRatePlanCharge(ZuoraHelper zuora, RatePlanCharge rpc, bool bIsUltimate, int version, DateTime ContractDate, string SKU)
        {
            if(ValidEndDate(rpc, ContractDate))
            {
                if(SKU == "SKU-00000020")
                {
                    iUsers += rpc.Quantity.Value;

                    QueryResult qrPRPC = zuora.RunQuery("select Name from ProductRatePlanCharge where Id = '" + rpc.ProductRatePlanChargeId + "'");
                    if(qrPRPC.records.Length > 0 && qrPRPC.records[0] != null)
                    {
                        ProductRatePlanCharge prpc = (ProductRatePlanCharge)qrPRPC.records[0];

                        sbDescription.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + prpc.Name + ": ");
                        sbDescription.Append(rpc.Quantity.Value);
                    }
                }
                else if(rpc.AccountingCode == "Users")
                {
                    iUsers = rpc.Quantity.Value;
                    sbDescription.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Users: ");
                    sbDescription.Append(rpc.Quantity.Value);
                }
                else
                {
                    if(IsDedicatedItem(rpc.AccountingCode))
                        bIsDedicated = true;

                    sbDescription.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbDescription.Append(rpc.Name);
                    sbDescription.Append(": ");
                    sbDescription.Append(rpc.Quantity);
                }
                sbDescription.Append("<br>");
            }
        }

        private void ProcessRatePlan(ZuoraHelper zuora, RatePlan rp, int version, DateTime ContractDate)
        {
            QueryResult qrPRP = zuora.RunQuery("select Name, ProductId, DisplayName__c, ContractId__c from ProductRatePlan where Id = '" + rp.ProductRatePlanId + "'");

            if(qrPRP.records.Length > 0 && qrPRP.records[0] != null)
            {
                ProductRatePlan prp = (ProductRatePlan)qrPRP.records[0];

                QueryResult qrP = zuora.RunQuery("select Name, SKU from Product where Id = '" + prp.ProductId + "'");

                if(qrP.records.Length > 0 && qrP.records[0] != null)
                {
                    Product product = (Product)qrP.records[0];

                    sbDescription.Append("<b>");
                    sbDescription.Append(product.Name);
                    sbDescription.Append(" (");
                    sbDescription.Append(prp.DisplayName__c);
                    sbDescription.Append(")</b><br>");

                    bool bIsUltimate = false;

                    if(prp.DisplayName__c == "Ultimate" || prp.ContractId__c == "50000009")
                    {
                        bIsDedicated = true;
                        bIsUltimate = true;
                    }

                    QueryResult qrRPC = zuora.RunQuery("select Quantity,ProductRatePlanChargeId, Name, AccountingCode,Version,EffectiveStartDate,EffectiveEndDate,Segment from RatePlanCharge where RatePlanId = '" + rp.Id + "' and Quantity > 0");

                    for(int i = 0; i < qrRPC.records.Length; i++)
                    {
                        if(qrRPC.records[i] != null)
                        {
                            ProcessRatePlanCharge(zuora, (RatePlanCharge)qrRPC.records[i], bIsUltimate, version, ContractDate, product.SKU);
                        }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ZuoraHelper zuora = new ZuoraHelper();

            QueryResult qrAmmendment = zuora.RunQuery("select SubscriptionId, ContractEffectiveDate from Amendment where id = '" + Request["AmendmentID"] + "'");

            DateTime ContractStart = DateTime.Now;
            string ZuoraUrl = "";
            string sTitle = "";
            string accountnumber = "";

            if(qrAmmendment.records.Length > 0 && qrAmmendment.records[0] != null)
            {
                Amendment amm = (Amendment)qrAmmendment.records[0];

                if(amm.ContractEffectiveDate.HasValue)
                    ContractStart = amm.ContractEffectiveDate.Value;

            }
                
            QueryResult qrSub = zuora.RunQuery("select AccountId, Version, ContractEffectiveDate from Subscription where id = '" + Request["SubscriptionId"] + "'");

            if(qrSub.records.Length > 0 && qrSub.records[0] != null)
            {
                Subscription sub = (Subscription)qrSub.records[0];

                if(sub.ContractEffectiveDateSpecified)
                {

                    int version = sub.Version.Value;

                    QueryResult qrA = zuora.RunQuery("select Name, AccountRef__c from Account where Id = '" + sub.AccountId + "'");

                    if(qrA.records.Length > 0 && qrA.records[0] != null)
                    {
                        Account acc = (Account)qrA.records[0];

                        sTitle = acc.Name + " (Dedicated)";
                        accountnumber = acc.AccountRef__c;
                    }

                    ZuoraUrl = "https://www.zuora.com/apps/Subscription.do?method=view&id=" + Request["SubscriptionId"];

                    QueryResult qrRP = zuora.RunQuery("select Name,ProductRatePlanId from RatePlan where SubscriptionId = '" + Request["SubscriptionId"] + "'");

                    for(int i = 0; i < qrRP.records.Length; i++)
                    {
                        if(qrRP.records[i] != null)
                        {
                            ProcessRatePlan(zuora, (RatePlan)qrRP.records[i], version, ContractStart);
                        }
                    }

                    if(bIsDedicated)
                    {


                        PortalLists.Lists lists = new PortalLists.Lists();
                        lists.Credentials = new System.Net.NetworkCredential("portfarm", "EPM$olutions", "EPM");

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml("<Root/>");

                        System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

                        elBatch.SetAttribute("OnError", "Continue");
                        elBatch.SetAttribute("ListVersion", "1");

                        //elBatch.InnerXml = "<Method ID='1' Cmd='New'><Field Name='Title'>" + sTitle + "</Field><Field Name='Description'><![CDATA[" + sbDescription.ToString() + "]]></Field><Field Name='StartDate'>" + DateTime.Now.ToString("s") + "</Field></Method>";
                        elBatch.InnerXml = "<Method ID='1' Cmd='New'><Field Name='Title'>" + sTitle + "</Field><Field Name='Users'>" + iUsers.ToString() + "</Field><Field Name='Body'><![CDATA[" + sbDescription.ToString() + "]]></Field><Field Name='StartDate'>" + DateTime.Now.ToString("u") + "</Field><Field Name='DueDate'>" + ContractStart.ToString("u") + "</Field><Field Name='AssignedTo'>" + sAssignedTo + "</Field><Field Name='Priority'>(1) High</Field><Field Name='Timesheet'>1</Field><Field Name='ServerType'>Production</Field><Field Name='Status'>Not Started</Field><Field Name='ZuoraSubscription'><![CDATA[" + ZuoraUrl + ", " + ZuoraUrl + "]]></Field><Field Name='AccountNumber'>" + accountnumber + "</Field></Method>";

                        XmlNode ndItems = lists.UpdateListItems("Dedicated Server Requests", elBatch);

                    }

                    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                    message.To.Add("jhughes@epmlive.com");
                    message.To.Add("tognall@epmlive.com");
                    message.Subject = "Zuora Subscription Automated Notification";
                    message.From = new System.Net.Mail.MailAddress("no-reply@epmlive.com");
                    message.Body = sTitle + "<br><br>" + sbDescription.ToString() + "<br><br>" + ZuoraUrl;
                    message.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("epmliveapp1");
                    smtp.Send(message);



                }
            }
        }
    }
}