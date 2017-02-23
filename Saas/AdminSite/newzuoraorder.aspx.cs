using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using AdminSite.ZuoraAPI;
using System.Collections;
namespace AdminSite
{
    public partial class newzuoraorder : System.Web.UI.Page
    {
        private string productSKU = "";
        private string planTerm = "Month";
        private string contractLevel = "";
        private ArrayList arrTiers = new ArrayList();
        private string contractid;
        private string accountref;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            string scriptKey = "OnSubmitScript";
            string javaScript = "sm('divreloading', 150, 50);";
            this.ClientScript.RegisterOnSubmitStatement(this.GetType(), scriptKey, javaScript);

            if(!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now;

                ddlCountry.Attributes.Add("onchange", "javascript:checkCountry()");
            }

            if(ddlProduct.SelectedValue == "15437d9b-80f4-40cc-a656-ce5d7daa157e")
            {
                ddlContract.Visible = false;
                ddlVersion.Visible = false;
                ddlContract.SelectedValue = "1";
                chkDoNotTier.Checked = true;
                ddlVersion.SelectedValue = "Standard";
            }

            switch(ddlContract.SelectedValue)
            {
                case "1.25":
                    ddlBilling.Items[0].Enabled = false;
                    ddlBilling.Items[1].Enabled = false;
                    ddlBilling.SelectedValue = "1";
                    break;
                case "1.1111111111111":
                    ddlBilling.Items[0].Enabled = false;
                    ddlBilling.Items[1].Enabled = true;
                    if(ddlBilling.SelectedValue == "12")
                        ddlBilling.SelectedValue = "3";

                    break;
                case "1":
                    ddlBilling.Items[0].Enabled = true;
                    ddlBilling.Items[1].Enabled = true;
                    break;
                case ".9":
                    ddlBilling.Items[0].Enabled = true;
                    ddlBilling.Items[1].Enabled = true;
                    break;
            }

            if(ddlContract.SelectedValue == ".9")
            {
                ddlBilling.SelectedValue = "12";
                ddlBilling.Enabled = false;
            }
            else
            {
                ddlBilling.Enabled = true;
            }

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("select * from onlineproducts where product_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", ddlProduct.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataRow drPricing = ds.Tables[0].Rows[0];

            lblOutput.Text = "<b>Product:</b> " + ddlProduct.SelectedItem.Text + "<br>";
            lblOutput.Text += "<b>Version:</b> " + ddlVersion.SelectedItem.Text + "<br>";
            lblOutput.Text += "<b>Contract:</b> " + ddlContract.SelectedItem.Text + "<br>";

            if(ddlProduct.SelectedItem.Text == "WorkEngine")
            {
                productSKU = "SKU-20000000";
                contractLevel = "2";
                contractid = "222333444";
            }
            else if(ddlProduct.SelectedItem.Text == "PortfolioEngine")
            {
                productSKU = "SKU-40000000";
                contractLevel = "4";
                contractid = "555666777";
            }
            else if(ddlProduct.SelectedItem.Text == "WorkEngine 2007")
            {
                productSKU = "SKU-10000000";
                contractLevel = "1";
                contractid = "111222333";
            }

            switch(ddlBilling.SelectedValue)
            {
                case "1":
                    planTerm = "Month";
                    break;
                case "3":
                    planTerm = "Quarter";
                    break;
                case "6":
                    planTerm = "Semi-Annual";
                    break;
                case "12":
                    planTerm = "Annual";
                    break;
            }
            if(string.Equals(HttpContext.Current.User.Identity.Name.ToLower(), "epm\\tognall1") || string.Equals(HttpContext.Current.User.Identity.Name.ToLower(), "epm\\jhughes"))
            {
            }
            else
            {
                if(decimal.Parse(txtDiscount.Text) > 20)
                    txtDiscount.Text = "20";
            }

            decimal standardPrice = 0;
            float userCount = float.Parse(txtUsers.Text);

            if(chkDoNotTier.Checked)
            {
                standardPrice = decimal.Parse(drPricing[ddlVersion.SelectedValue + "25"].ToString()) * decimal.Parse(ddlBilling.SelectedValue) * (100 - decimal.Parse(txtDiscount.Text)) / 100;

                RatePlanChargeTier rp = new RatePlanChargeTier();
                rp.StartingUnit = 1;
                rp.StartingUnitSpecified = true;
                rp.Price = Math.Round(decimal.Parse(drPricing[ddlVersion.SelectedValue + "25"].ToString()) * (100 - decimal.Parse(txtDiscount.Text)) / 100 * decimal.Parse(ddlBilling.SelectedValue), 2);
                rp.PriceSpecified = true;
                rp.Tier = 1;
                rp.TierSpecified = true;
                rp.PriceFormat = "PerUnit";

                arrTiers.Add(rp);
            }
            else
            {
                //if(txtUsers.Text == "")
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width=\"300\">");
                    sb.Append("<tr><td>25</td><td>");

                    decimal price = decimal.Parse(drPricing[ddlVersion.SelectedValue + "25"].ToString()) * decimal.Parse(ddlContract.SelectedValue) * decimal.Parse(ddlBilling.SelectedValue);

                    sb.Append(string.Format("{0:C}", price));
                    sb.Append("</td></tr>");

                    RatePlanChargeTier rp = new RatePlanChargeTier();
                    rp.StartingUnit = 1;
                    rp.StartingUnitSpecified = true;
                    rp.EndingUnit = 25;
                    rp.EndingUnitSpecified = true;
                    rp.Price = Math.Round(price * (100 - decimal.Parse(txtDiscount.Text)) / 100, 2);
                    rp.PriceSpecified = true;
                    rp.Tier = 1;
                    rp.TierSpecified = true;
                    rp.PriceFormat = "PerUnit";

                    arrTiers.Add(rp);

                    standardPrice = decimal.Parse(drPricing["Standard25"].ToString());

                    decimal basePrice = 0;
                    try
                    {
                        basePrice = decimal.Parse(drPricing[ddlVersion.SelectedValue + "Base"].ToString());
                    }
                    catch { }

                    int tiercounter = 2;
                    int previousCount = 26;
                    for(int i = 50; i <= 500; i += 50)
                    {
                        sb.Append("<tr><td>");
                        sb.Append(i);
                        sb.Append("</td><td>");
                        if(ddlVersion.SelectedValue != "Standard")
                        {
                            standardPrice *= (decimal).97;
                            price = (decimal)Math.Round((basePrice / i / 12 + standardPrice) * decimal.Parse(ddlContract.SelectedValue), 2) * decimal.Parse(ddlBilling.SelectedValue);

                            sb.Append(string.Format("{0:C}", price));
                        }
                        else
                        {
                            standardPrice *= (decimal).97;
                            price = (decimal)Math.Round(standardPrice * decimal.Parse(ddlContract.SelectedValue), 2) * decimal.Parse(ddlBilling.SelectedValue);
                            sb.Append(string.Format("{0:C}", price));
                        }

                        sb.Append("</td></tr>");

                        rp = new RatePlanChargeTier();
                        rp.StartingUnit = previousCount;
                        rp.StartingUnitSpecified = true;
                        rp.EndingUnit = i;
                        rp.EndingUnitSpecified = true;
                        rp.Price = Math.Round(price * (100 - decimal.Parse(txtDiscount.Text)) / 100, 2);
                        rp.PriceSpecified = true;
                        rp.Tier = tiercounter++;
                        rp.TierSpecified = true;
                        rp.PriceFormat = "PerUnit";

                        arrTiers.Add(rp);

                        previousCount = i + 1;
                    }
                    sb.Append("</table>");

                    //lblOutput.Text += "<br>" + sb.ToString();
                }
                //else
                {


                    standardPrice = 0;

                    if(userCount <= 25)
                    {
                        

                        standardPrice = decimal.Parse(drPricing[ddlVersion.SelectedValue + "25"].ToString()) * decimal.Parse(ddlContract.SelectedValue) * decimal.Parse(ddlBilling.SelectedValue);
                    }
                    else
                    {
                        standardPrice = decimal.Parse(drPricing["Standard25"].ToString());

                        float tUserCount = userCount;

                        if(tUserCount > 500)
                            tUserCount = 500;

                        decimal basePrice = 0;
                        try
                        {
                            basePrice = decimal.Parse(drPricing[ddlVersion.SelectedValue + "Base"].ToString());
                        }
                        catch { }

                        int i = 50;
                        for(i = 50; i < tUserCount; i += 50)
                        {
                            if(ddlVersion.SelectedValue != "Standard")
                            {
                                standardPrice *= (decimal).97;
                            }
                            else
                            {
                                standardPrice *= (decimal).97;
                            }
                        }
                        if(ddlVersion.SelectedValue != "Standard")
                        {
                            standardPrice = standardPrice * (decimal).97;
                            standardPrice = basePrice / (decimal)i / (decimal)12 + standardPrice;
                            standardPrice = Math.Round(standardPrice * decimal.Parse(ddlContract.SelectedValue), 2);
                            standardPrice = standardPrice * decimal.Parse(ddlBilling.SelectedValue);
                        }
                        else
                        {
                            standardPrice = (decimal)Math.Round(standardPrice * (decimal).97 * decimal.Parse(ddlContract.SelectedValue), 2) * decimal.Parse(ddlBilling.SelectedValue);
                        }

                    }
                }
            }

                decimal userCost = (standardPrice * decimal.Parse(txtUsers.Text)) * (100 - decimal.Parse(txtDiscount.Text)) / 100;

                lblOutput.Text += "<b>Users:</b> " + userCount + "<br>";

                lblOutput.Text += "<b>Price Per User Per " + ddlBilling.SelectedItem.Text + ":</b> " + string.Format("{0:C}", standardPrice) + "<br><br>";
                lblOutput.Text += "<b>Discount %:</b> " + txtDiscount.Text + "%<br>";
                lblOutput.Text += "<b>Total User Price" + ddlBilling.SelectedItem.Text + " Cost:</b> " + string.Format("{0:C}", userCost) + "<br>";

                decimal addCost = 0;
                decimal addOTCost = 0;

                foreach(GridViewRow gvr in gvAdditional.Rows)
                {
                    TextBox txt = (TextBox)gvr.FindControl("TextBox1");
                    HiddenField hdn = (HiddenField)gvr.FindControl("HiddenField2");
                    decimal qty = 0;
                    decimal.TryParse(txt.Text, out qty);
                    if(qty > 0)
                    {
                        addCost += qty * decimal.Parse(hdn.Value);
                    }
                }

                foreach(GridViewRow gvr in gvProducts.Rows)
                {
                    TextBox txt = (TextBox)gvr.FindControl("TextBox1");
                    HiddenField hdn = (HiddenField)gvr.FindControl("HiddenField2");
                    decimal qty = 0;
                    decimal.TryParse(txt.Text, out qty);
                    if(qty > 0)
                    {
                        addOTCost += qty * decimal.Parse(hdn.Value);
                    }
                }


                lblOutput.Text += "<b>Additional Reccuring Costs:</b> " + string.Format("{0:C}", addCost) + "<br>";

                lblOutput.Text += "<b>Total Recurring Cost: </b> " + string.Format("{0:C}", addCost + userCost) + "<br><br>";

                lblOutput.Text += "<b>One-Time Costs:</b> " + string.Format("{0:C}", addOTCost) + "<br><br>";

                lblOutput.Text += "<b>TOTAL COST:</b> " + string.Format("{0:C}", addOTCost + addCost + userCost) + "<br>";

                

            if(!IsPostBack)
            {
                SqlCommand cmdGetSites = new SqlCommand("SELECT     maxusers,crmaccountuid,account_id,billingtype, account.account_ref,monthsfree,account.dtcreated,accountdescription,partnerid,account.dedicated, dbo.USERS.*, dbo.BETA1Survey.project_version, dbo.BETA1Survey.sharepoint_version, dbo.BETA1Survey.products, dbo.BETA1Survey.comments FROM         dbo.USERS Left Outer JOIN dbo.BETA1Survey ON dbo.USERS.uid = dbo.BETA1Survey.uid Left Outer JOIN dbo.ACCOUNT ON dbo.USERS.uid = dbo.ACCOUNT.owner_id WHERE account_id like '" + Request["account_id"] + "'", cn);
                cmdGetSites.CommandType = CommandType.Text;

                SqlDataAdapter da2 = new SqlDataAdapter(cmdGetSites);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                DataRow dr2 = ds2.Tables[0].Rows[0];

                StringBuilder sb2 = new StringBuilder();

                txtEditFirstName.Text = dr2["firstname"].ToString();
                txtEditLastName.Text = dr2["lastname"].ToString();
                txtEditEmail.Text = dr2["email"].ToString();
                txtAddress1.Text = dr2["address1"].ToString();
                txtAddress2.Text = dr2["address2"].ToString();
                txtCity.Text = dr2["city"].ToString();
                txtEditPhone.Text = dr2["phone"].ToString();
                txtZip.Text = dr2["zip"].ToString();
                ddlCountry.SelectedValue = dr2["Country"].ToString();
                ddlState.SelectedValue = dr2["State"].ToString();
                    
            }
            cn.Close();

            
            ZuoraHelper zuora = new ZuoraHelper();

            if(Page.Request["__EVENTTARGET"] == "ctl00$ContentPlaceHolderMain$ddlProduct"
                || Page.Request["__EVENTTARGET"] == "ctl00$ContentPlaceHolderMain$ddlVersion"
                || Page.Request["__EVENTTARGET"] == "ctl00$ContentPlaceHolderMain$ddlContract"
                || Page.Request["__EVENTTARGET"] == "ctl00$ContentPlaceHolderMain$ddlBilling"
                || !IsPostBack)
            {
                loadZuoraAdditional(zuora);
                loadZuoraAdditionalProducts(zuora);
            }
        }

        private bool ignoreCharge(string name)
        {
            switch(name)
            {
                case "Users":
                    return true;
            };
            return false;
        }

        private void loadZuoraAdditional(ZuoraHelper zuora)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Price", typeof(decimal));

            

            QueryResult result = zuora.RunQuery("select  Id from Product where SKU = '" + productSKU + "'");
            Product product = (Product)result.records[0];

            result = zuora.RunQuery("select Id,DisplayName__c from ProductRatePlan where DisplayName__c = '" + ddlVersion.SelectedValue + "' and ProductId='" + product.Id + "'");
            foreach(ProductRatePlan productRatePlan in result.records)
            {
                result = zuora.RunQuery("select BillingPeriod,Id,ProductRatePlanId,Name from ProductRatePlanCharge where ProductRatePlanId = '" + productRatePlan.Id + "' and BillingPeriod='" + planTerm + "' and Name='Users'");
                if(result.records.Length > 0 && result.records[0] != null)
                {
                    ProductRatePlanCharge recTemp = (ProductRatePlanCharge)result.records[0];

                    result = zuora.RunQuery("select BillingPeriod,Id,ProductRatePlanId,Name,AccountingCode,ChargeType,ChargeModel,Hidden__c from ProductRatePlanCharge where ProductRatePlanId = '" + productRatePlan.Id + "' and ChargeType='Recurring'");

                    for(int i = 0; i < result.records.Length; i++)
                    {
                        if(result.records[i] != null)
                        {
                            ProductRatePlanCharge rec = (ProductRatePlanCharge)result.records[i];
                            if(!ignoreCharge(rec.Name) && !"Yes".Equals(rec.Hidden__c))
                            {

                                QueryResult result2 = zuora.RunQuery("select Price from ProductRatePlanChargeTier where ProductRatePlanChargeId = '" + rec.Id + "'");

                                if(result2.records[0] != null)
                                {
                                    ProductRatePlanChargeTier prpct = (ProductRatePlanChargeTier)result2.records[0];

                                    dt.Rows.Add(new object[] { rec.Id, rec.Name, prpct.Price });
                                }

                                
                            }
                        }
                    }


                }
            }

            gvAdditional.DataSource = dt;
            gvAdditional.DataBind();
        }


        private void loadZuoraAdditionalProducts(ZuoraHelper zuora)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("PRPID");

            QueryResult result = zuora.RunQuery("select Name, Id from Product where SKU != 'SKU-20000000' AND SKU != 'SKU-40000000' AND SKU != 'SKU-00000002' AND SKU != 'SKU-10000000'");
            
            foreach(Product product in result.records)
            {
                result = zuora.RunQuery("select Name, Id from ProductRatePlan where ProductId='" + product.Id + "'");
                foreach(ProductRatePlan productRatePlan in result.records)
                {
                    result = zuora.RunQuery("select BillingPeriod,Id,ProductRatePlanId,Name from ProductRatePlanCharge where ProductRatePlanId = '" + productRatePlan.Id + "'");
                    if(result.records.Length > 0 && result.records[0] != null)
                    {
                        ProductRatePlanCharge recTemp = (ProductRatePlanCharge)result.records[0];

                        result = zuora.RunQuery("select BillingPeriod,Id,ProductRatePlanId,Name,AccountingCode,ChargeType,ChargeModel,Hidden__c from ProductRatePlanCharge where ProductRatePlanId = '" + productRatePlan.Id + "'");

                        for(int i = 0; i < result.records.Length; i++)
                        {
                            if(result.records[i] != null)
                            {
                                ProductRatePlanCharge rec = (ProductRatePlanCharge)result.records[i];
                                if(!ignoreCharge(rec.Name) && !"Yes".Equals(rec.Hidden__c))
                                {

                                    QueryResult result2 = zuora.RunQuery("select Price from ProductRatePlanChargeTier where ProductRatePlanChargeId = '" + rec.Id + "'");

                                    if(result2.records[0] != null)
                                    {
                                        ProductRatePlanChargeTier prpct = (ProductRatePlanChargeTier)result2.records[0];

                                        dt.Rows.Add(new object[] { rec.Id, product.Name + " - " + productRatePlan.Name, rec.ChargeType, prpct.Price, productRatePlan.Id });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            gvProducts.DataSource = dt;
            gvProducts.DataBind();
        }

        private bool processContact(ZuoraHelper zuora, string accountid, DataRow dsAccount)
        {
            QueryResult result = zuora.RunQuery("select AccountId,Id from Contact where WorkEmail = '" + dsAccount["email"].ToString() + "' and accountid='" + accountid + "'");
            if(result.records.Length > 0 && result.records[0] != null)
            {
                Contact contact = (Contact)result.records[0];

                contact.FirstName = txtEditFirstName.Text;
                contact.LastName = txtEditLastName.Text;
                contact.Address1 = txtAddress1.Text;
                contact.Address2 = txtAddress2.Text;
                contact.City = txtCity.Text;

                if(ddlCountry.SelectedValue == "US")
                    contact.State = ddlState.SelectedValue;
                else if(ddlCountry.SelectedValue == "CA")
                    contact.State = ddlProvince.SelectedValue;

                contact.PostalCode = txtZip.Text;
                contact.Country = ddlCountry.SelectedValue;
                contact.WorkPhone = txtEditPhone.Text;
                contact.WorkEmail = txtEditEmail.Text;

                zObject[] objs2 = new zObject[1];
                objs2[0] = contact;

                SaveResult[] respContact = zuora.Update(objs2);

                if(respContact[0].Success)
                {
                    return true;
                }
                else
                {
                    lblError.Text = "Error updating contact: " + respContact[0].Errors[0].Message;
                    lblError.Visible = true;
                    return false;
                }
            }
            else
            {

                Contact contact = new Contact();
                contact.AccountId = accountid;
                contact.FirstName = txtEditFirstName.Text;
                contact.LastName = txtEditLastName.Text;
                contact.Address1 = txtAddress1.Text;
                contact.Address2 = txtAddress2.Text;
                contact.City = txtCity.Text;

                if(ddlCountry.SelectedValue == "US")
                    contact.State = ddlState.SelectedValue;
                else if(ddlCountry.SelectedValue == "CA")
                    contact.State = ddlProvince.SelectedValue;

                contact.PostalCode = txtZip.Text;
                contact.Country = ddlCountry.SelectedValue;
                contact.WorkPhone = txtEditPhone.Text;
                contact.WorkEmail = txtEditEmail.Text;

                zObject[] objs2 = new zObject[1];
                objs2[0] = contact;

                SaveResult[] respContact = zuora.Create(objs2);

                if(respContact[0].Success)
                {
                    Account acc = new Account();
                    acc.Id = accountid;
                    acc.BillToId = respContact[0].Id;
                    acc.SoldToId = respContact[0].Id;

                    zObject[] objs = new zObject[1];
                    objs[0] = acc;

                    SaveResult[] resp = zuora.Update(objs);

                    if(resp[0].Success)
                    {
                        return true;
                    }
                    else
                    {
                        lblError.Text = "Error updating bill to: " + resp[0].Errors[0].Message;
                        lblError.Visible = true;
                        return false;
                    }
                }
                else
                {
                    lblError.Text = "Error creating contact: " + respContact[0].Errors[0].Message;
                    lblError.Visible = true;
                    return false;
                }
            }
        }

        private bool processPaymentMethod(ZuoraHelper zuora, string accountid, DataRow dsAccount)
        {
            return true;
            QueryResult result = zuora.RunQuery("select Type,Id,CreditCardMaskNumber from PaymentMethod where accountid='" + accountid + "'");

            foreach(PaymentMethod oldPM in result.records)
            {
                if(oldPM != null)
                {
                    return true;
                }
            }

            PaymentMethod pm = new PaymentMethod();
            pm.Type = "Check";
            pm.AccountId = accountid;

            pm.Email = dsAccount["email"].ToString();
            pm.Phone = dsAccount["phone"].ToString();

            zObject[] objs = new zObject[1];
            objs[0] = pm;

            SaveResult[] resp = zuora.Create(objs);

            if(resp[0].Success)
            {
                return true;
                //Account acc = new Account();
                //acc.Id = accountid;
                //acc.DefaultPaymentMethodId = resp[0].Id;
                //acc.AutoPay = true;
                //acc.AutoPaySpecified = true;

                //objs = new zObject[1];
                //objs[0] = acc;

                //resp = zuora.Update(objs);

                //if(resp[0].Success)
                //{
                //    return true;
                //}
                //else
                //{
                //    lblError.Text = "Error updating default payment: " + resp[0].Errors[0].Message;
                //    lblError.Visible = true;
                //    return false;
                //}
            }
            else
            {
                lblError.Text = "Error creating payment method: " + resp[0].Errors[0].Message;
                lblError.Visible = true;
                return false;
            }
                
            return true;
        }

        private bool activateAccount(ZuoraHelper zuora, string accountid)
        {
            Account acc = new Account();
            acc.Id = accountid;
            acc.Status = "Active";
            acc.InvoiceTemplateId = ddlInvoiceTemplate.SelectedValue;
            acc.InvoiceDeliveryPrefsEmail = true;
            acc.InvoiceDeliveryPrefsEmailSpecified = true;
            acc.PaymentTerm = "Net 15";
            
            zObject[] objs = new zObject[1];
            objs[0] = acc;

            SaveResult[] resp = zuora.Update(objs);

            if(resp[0].Success)
            {
                return true;
            }
            else
            {
                lblError.Text = "Error activating account payment: " + resp[0].Errors[0].Message;
                lblError.Visible = true;
                return false;
            }
        }

        private ProductRatePlanCharge []GetProductRatePlanCharge(ZuoraHelper zuora)
        {
            ArrayList arrCharges = new ArrayList();

            QueryResult result = zuora.RunQuery("select Id from Product where SKU = '" + productSKU + "'");
            Product product = (Product)result.records[0];

            result = zuora.RunQuery("select Id from ProductRatePlan where DisplayName__c = '" + ddlVersion.SelectedValue + "' and ProductId='" + product.Id + "'");
            foreach(ProductRatePlan productRatePlan in result.records)
            {
                result = zuora.RunQuery("select BillingPeriod,Id,ProductRatePlanId,Name from ProductRatePlanCharge where ProductRatePlanId = '" + productRatePlan.Id + "' and BillingPeriod='" + planTerm + "' and Name='Users'");
                if(result.records.Length > 0 && result.records[0] != null)
                {
                    ProductRatePlanCharge recTemp = (ProductRatePlanCharge)result.records[0];

                    result = zuora.RunQuery("select BillingPeriod,Id,ProductRatePlanId,Name,AccountingCode from ProductRatePlanCharge where ProductRatePlanId = '" + productRatePlan.Id + "'");

                    for(int i = 0; i < result.records.Length; i++)
                    {
                        if(result.records[i] != null)
                        {
                            ProductRatePlanCharge rec = (ProductRatePlanCharge)result.records[i];

                            arrCharges.Add(rec);
                        }
                    }

                    
                }
            }

            return (ProductRatePlanCharge[])arrCharges.ToArray(typeof(ProductRatePlanCharge));
        }

        private Subscription makeSubscription()
        {

            DateTime calendar = Calendar1.SelectedDate;

            Subscription sub = new Subscription();
            if(contractLevel == "1")
                sub.Name = "WorkEngine2007_" + DateTime.Now.Ticks;
            else if(contractLevel == "2")
                sub.Name = "WorkEngine_" + DateTime.Now.Ticks;
            else if(contractLevel == "4")
                sub.Name = "PortfolioEngine_" + DateTime.Now.Ticks;

            sub.TermStartDate = calendar;
            sub.ContractEffectiveDate = calendar;
            sub.ContractEffectiveDateSpecified = true;
            sub.ContractAcceptanceDate = calendar;
            sub.ContractAcceptanceDateSpecified = true;
            sub.ServiceActivationDate = calendar;
            sub.ServiceActivationDateSpecified = true;

            if(ddlBilling.SelectedValue == "1")
            {
                sub.TermType = "EVERGREEN";
                sub.Status = "Active";
            }
            else
            {
                sub.InitialTerm = int.Parse(ddlBilling.SelectedValue);
                sub.InitialTermSpecified = true;
                sub.RenewalTerm = int.Parse(ddlBilling.SelectedValue);
                sub.RenewalTermSpecified = true;
                sub.AutoRenew = true;
                sub.AutoRenewSpecified = true;
                sub.TermType = "TERMED";
                sub.Status = "Active";
            }

            return sub;
        }

        private RatePlanData[] makeRatePlanData(ProductRatePlanCharge []charges, ZuoraHelper zuora)
        {

            RatePlanData ratePlanData = new RatePlanData();
            RatePlan ratePlan = new RatePlan();
            ratePlanData.RatePlan = ratePlan;
            ratePlan.AmendmentType = "NewProduct";
            ratePlan.ProductRatePlanId = charges[0].ProductRatePlanId;

            ArrayList arrCharges = new ArrayList();

            Hashtable arrAdditional = new Hashtable();

            foreach(GridViewRow gvr in gvAdditional.Rows)
            {
                HiddenField hdn = (HiddenField)gvr.FindControl("HiddenField1");
                TextBox txt = (TextBox)gvr.FindControl("TextBox1");
                int qty = 0;
                int.TryParse(txt.Text, out qty);
                if(qty > 0)
                {
                    arrAdditional.Add(hdn.Value.ToLower(), qty);
                }
            }

            foreach(ProductRatePlanCharge charge in charges)
            {
                RatePlanChargeData ratePlanChargeData = new RatePlanChargeData();
                
                RatePlanCharge ratePlanCharge = new RatePlanCharge();
                ratePlanChargeData.RatePlanCharge = ratePlanCharge;

                ratePlanCharge.ProductRatePlanChargeId = charge.Id;
                ratePlanCharge.TriggerEvent = "ServiceActivation";

                if(charge.AccountingCode == "Users")
                {
                    ratePlanCharge.Quantity = decimal.Parse(txtUsers.Text);
                    ratePlanCharge.QuantitySpecified = true;

                    ratePlanChargeData.RatePlanChargeTier = (RatePlanChargeTier[])arrTiers.ToArray(typeof(RatePlanChargeTier));

                    arrCharges.Add(ratePlanChargeData);
                }
                else
                {
                    if(arrAdditional.Contains(charge.Id.ToLower()))
                    {
                        ratePlanCharge.Quantity = decimal.Parse(arrAdditional[charge.Id.ToLower()].ToString());
                        ratePlanCharge.QuantitySpecified = true;

                        arrCharges.Add(ratePlanChargeData);
                    }
                }
            }

            ratePlanData.RatePlanChargeData = (RatePlanChargeData[])arrCharges.ToArray(typeof(RatePlanChargeData));

            ArrayList arrRatePlanData = new ArrayList();
            arrRatePlanData.Add(ratePlanData);

            foreach(GridViewRow gvr in gvProducts.Rows)
            {
                HiddenField hdn = (HiddenField)gvr.FindControl("HiddenField1");
                HiddenField hdnPRP = (HiddenField)gvr.FindControl("HiddenFieldPRPID");
                TextBox txt = (TextBox)gvr.FindControl("TextBox1");
                int qty = 0;
                int.TryParse(txt.Text, out qty);
                if(qty > 0)
                {
                    RatePlanData ratePlanData2 = new RatePlanData();
                    RatePlan ratePlan2 = new RatePlan();
                    ratePlanData2.RatePlan = ratePlan2;
                    ratePlan2.AmendmentType = "NewProduct";
                    ratePlan2.ProductRatePlanId = hdnPRP.Value;

                    RatePlanChargeData ratePlanChargeData = new RatePlanChargeData();

                    RatePlanCharge ratePlanCharge = new RatePlanCharge();
                    ratePlanChargeData.RatePlanCharge = ratePlanCharge;

                    ratePlanCharge.ProductRatePlanChargeId = hdn.Value;
                    ratePlanCharge.TriggerEvent = "ServiceActivation";

                    ratePlanCharge.Quantity = decimal.Parse(txt.Text);
                    ratePlanCharge.QuantitySpecified = true;

                    ratePlanData2.RatePlanChargeData = new RatePlanChargeData[] { ratePlanChargeData };

                    arrRatePlanData.Add(ratePlanData2);
                }
            }

            return (RatePlanData[])arrRatePlanData.ToArray(typeof(RatePlanData));
                
                //new RatePlanData[] { ratePlanData };
        }

        private bool subscribe(ZuoraHelper zuora, string accountid)
        {
            ProductRatePlanCharge []charges = GetProductRatePlanCharge(zuora);

            Account acc = new Account();
            acc.Id = accountid;

            SubscriptionData sd = new SubscriptionData();

            Subscription subscription = makeSubscription();
            subscription.AccountId = accountid;
            subscription.PO__c = txtPO.Text;

            sd.Subscription = subscription;

            sd.RatePlanData = makeRatePlanData(charges, zuora);

            SubscribeRequest sub = new SubscribeRequest();
            sub.Account = acc;
            sub.SubscriptionData = sd;

            SubscribeOptions opt = new SubscribeOptions();

            opt.GenerateInvoice = true;
            opt.GenerateInvoiceSpecified = true;
            
            sub.SubscribeOptions = opt;
            
            SubscribeRequest[] subscribes = new SubscribeRequest[1];
            subscribes[0] = sub;

            SubscribeResult[] result = zuora.Subscribe(subscribes);

            if(result[0].Success)
            {
                SqlConnection cn2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString);
                cn2.Open();

                SqlCommand cmd = new SqlCommand("delete from orders where account_ref=@accountref and contractid=@contractid", cn2);
                cmd.Parameters.AddWithValue("@accountref", accountref);
                cmd.Parameters.AddWithValue("@contractid", contractid);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO orders (account_ref, plimusReferenceNumber, quantity, diskspace, projects, expiration, version, enabled, contractid, plimusAccountId, billingsystem) VALUES (@accountref, @ref, @qty, @disk, 0, @expdate, 2, 1, @contractid, 0, 2)", cn2);
                cmd.Parameters.AddWithValue("@accountref", accountref);
                cmd.Parameters.AddWithValue("@ref", "Temp Subscription");
                cmd.Parameters.AddWithValue("@qty", txtUsers.Text);
                cmd.Parameters.AddWithValue("@disk", "10000");
                cmd.Parameters.AddWithValue("@expdate", Calendar1.SelectedDate.AddDays(1));
                cmd.Parameters.AddWithValue("@contractid", contractid);

                cmd.ExecuteNonQuery();

                cn2.Close();
                return true;
            }
            else
            {
                lblError.Text = "Error subscribing: " + result[0].Errors[0].Message;
                lblError.Visible = true;
                return false;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString);
            cn.Open();

            SqlCommand cmdGetSites = new SqlCommand("SELECT     maxusers,crmaccountuid,account_id,billingtype, account.account_ref,monthsfree,account.dtcreated,accountdescription,partnerid,account.dedicated, dbo.USERS.*, dbo.BETA1Survey.project_version, dbo.BETA1Survey.sharepoint_version, dbo.BETA1Survey.products, dbo.BETA1Survey.comments FROM         dbo.USERS Left Outer JOIN dbo.BETA1Survey ON dbo.USERS.uid = dbo.BETA1Survey.uid Left Outer JOIN dbo.ACCOUNT ON dbo.USERS.uid = dbo.ACCOUNT.owner_id WHERE account_id like '" + Request["account_id"] + "'", cn);
            cmdGetSites.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmdGetSites);
            DataSet ds = new DataSet();
            da.Fill(ds);

            accountref = ds.Tables[0].Rows[0]["account_ref"].ToString();
            string accountname = ds.Tables[0].Rows[0]["accountdescription"].ToString();

            lblError.Visible = false;

            cn.Close();

            ZuoraHelper zuora = new ZuoraHelper();

            ZuoraAPI.QueryResult qrAccount = zuora.RunQuery("SELECT BillToId, ID from ACCOUNT where accountref__c = '" + accountref + "'");

            if(qrAccount.records.Length > 0 && qrAccount.records[0] != null)
            {
                string accountid = qrAccount.records[0].Id;

                if(processContact(zuora, accountid, ds.Tables[0].Rows[0]))
                {
                    if(processPaymentMethod(zuora, accountid, ds.Tables[0].Rows[0]))
                    {
                        if(subscribe(zuora, accountid))
                        {
                            Response.Redirect("editaccount.aspx?account_id=" + Request["Account_id"] + "&tab=3");
                        }
                    }
                }
            }
            else
            {
                Account acc = new Account();
                acc.Name = accountname;
                acc.Batch = "Batch1";
                acc.PaymentTerm = "Due Upon Receipt";
                acc.BillCycleDay = DateTime.Now.Day;
                acc.BillCycleDaySpecified = true;
                acc.AllowInvoiceEdit = true;
                acc.Currency = "USD";
                acc.Status = "Draft";
                acc.AccountRef__c = accountref;
                acc.DefaultPaymentMethodId = "4028e48832dcc1b30132df2f871712e8";
                
                
                zObject[] objs = new zObject[1];
                objs[0] = acc;

                SaveResult[] resp = zuora.Create(objs);

                if(resp[0].Success)
                {
                    string accountid = resp[0].Id;

                    if(processContact(zuora, accountid, ds.Tables[0].Rows[0]))
                    {
                        if(processPaymentMethod(zuora, accountid, ds.Tables[0].Rows[0]))
                        {
                            if(activateAccount(zuora, accountid))
                            {
                                if(subscribe(zuora, accountid))
                                {
                                    Response.Redirect("editaccount.aspx?account_id=" + Request["Account_id"] + "&tab=3");
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblError.Text = "Error creating account: " + resp[0].Errors[0].Message;
                    lblError.Visible = true;
                }
            }

        }
    }
}