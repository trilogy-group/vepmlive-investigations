using System;
using System.Data;
using System.Data.SqlClient;
using AdminSite.ZuoraAPI;

namespace AdminSite
{
    public partial class createzuoraaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT account_ref,accountdescription,owner_id from account where account_id=@accountid", cn);
            cmd.Parameters.AddWithValue("@accountid", Request["Accountid"]);
            SqlDataReader dr = cmd.ExecuteReader();

            string account_ref = "";
            string accountdescription = "";
            string ownerid = "";

            if(dr.Read())
            {
                account_ref = dr.GetInt32(0).ToString();
                accountdescription = dr.GetString(1);
                ownerid = dr.GetGuid(2).ToString();
            }
            dr.Close();



            ZuoraHelper zuora = new ZuoraHelper();

            Account acc = new Account();
            acc.Name = accountdescription;
            acc.Batch = "Batch1";
            acc.PaymentTerm = "Due Upon Receipt";
            acc.BillCycleDay = DateTime.Now.Day;
            acc.BillCycleDaySpecified = true;
            acc.AllowInvoiceEdit = true;
            acc.Currency = "USD";
            acc.Status = "Draft";
            acc.AccountRef__c = account_ref;
            acc.DefaultPaymentMethodId = "4028e48832dcc1b30132df2f871712e8";
                
                
            zObject[] objs = new zObject[1];
            objs[0] = acc;

            SaveResult[] resp = zuora.Create(objs);

            string email = "";
            string phone = "";

            if(resp[0].Success)
            {
                string accountid = resp[0].Id;

                if(processContact(zuora, accountid, ownerid, cn, out email, out phone))
                {
                    if(processPaymentMethod(zuora, accountid, email, phone))
                    {
                        if(activateAccount(zuora, accountid))
                        {
                            Response.Redirect("editaccount.aspx?account_id=" + Request["Account_id"]);
                        }
                    }
                }
            }

            cn.Close();


            
        }

        private bool activateAccount(ZuoraHelper zuora, string accountid)
        {
            Account acc = new Account();
            acc.Id = accountid;
            acc.Status = "Active";
            acc.InvoiceTemplateId = "4028e487336cf73001338b20f72b50ff";
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
                Response.Write("Error activating account payment: " + resp[0].Errors[0].Message);
                return false;
            }
        }

        private bool processPaymentMethod(ZuoraHelper zuora, string accountid, string email, string phone)
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

            pm.Email = email;
            pm.Phone = phone;

            zObject[] objs = new zObject[1];
            objs[0] = pm;

            SaveResult[] resp = zuora.Create(objs);

            if(resp[0].Success)
            {
                return true;
            }
            else
            {
                Response.Write("Error creating payment method: " + resp[0].Errors[0].Message);
                return false;
            }

            return true;
        }

        private bool processContact(ZuoraHelper zuora, string accountid,string ownerid, SqlConnection cn, out string email, out string phone)
        {
            SqlCommand cmd = new SqlCommand("select * from USERS where uid=@uid", cn);
            cmd.Parameters.AddWithValue("@uid", ownerid);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            phone = ds.Tables[0].Rows[0]["phone"].ToString();
            email = ds.Tables[0].Rows[0]["email"].ToString();

            QueryResult result = zuora.RunQuery("select AccountId,Id from Contact where WorkEmail = '" + ds.Tables[0].Rows[0]["email"].ToString() + "' and accountid='" + accountid + "'");
            if(result.records.Length > 0 && result.records[0] != null)
            {
                Contact contact = (Contact)result.records[0];

                contact.FirstName = ds.Tables[0].Rows[0]["firstname"].ToString();
                contact.LastName = ds.Tables[0].Rows[0]["lastname"].ToString();
                contact.Address1 = ds.Tables[0].Rows[0]["address1"].ToString();
                contact.Address2 = ds.Tables[0].Rows[0]["address2"].ToString();
                contact.City = ds.Tables[0].Rows[0]["city"].ToString();

                string country = ds.Tables[0].Rows[0]["country"].ToString();
                if(country == "USA")
                    country = "US";

                if(country == "US" || country == "CA")
                    contact.State = ds.Tables[0].Rows[0]["state"].ToString();

                contact.PostalCode = ds.Tables[0].Rows[0]["ZIP"].ToString();
                contact.Country = country;
                contact.WorkPhone = ds.Tables[0].Rows[0]["phone"].ToString();
                contact.WorkEmail = ds.Tables[0].Rows[0]["email"].ToString();

                zObject[] objs2 = new zObject[1];
                objs2[0] = contact;

                SaveResult[] respContact = zuora.Update(objs2);

                if(respContact[0].Success)
                {
                    return true;
                }
                else
                {
                    Response.Write("Error updating contact: " + respContact[0].Errors[0].Message);
                    return false;
                }
            }
            else
            {

                Contact contact = new Contact();
                contact.AccountId = accountid;
                contact.FirstName = ds.Tables[0].Rows[0]["firstname"].ToString();
                contact.LastName = ds.Tables[0].Rows[0]["lastname"].ToString();
                contact.Address1 = ds.Tables[0].Rows[0]["address1"].ToString();
                contact.Address2 = ds.Tables[0].Rows[0]["address2"].ToString();
                contact.City = ds.Tables[0].Rows[0]["city"].ToString();

                string country = ds.Tables[0].Rows[0]["country"].ToString();
                if(country == "USA")
                    country = "US";

                if(country == "US" || country == "CA")
                    contact.State = ds.Tables[0].Rows[0]["state"].ToString();

                contact.PostalCode = ds.Tables[0].Rows[0]["zip"].ToString();
                contact.Country = country;
                contact.WorkPhone = ds.Tables[0].Rows[0]["phone"].ToString();
                contact.WorkEmail = ds.Tables[0].Rows[0]["email"].ToString();

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
                        Response.Write("Error updating bill to: " + resp[0].Errors[0].Message);
                        return false;
                    }
                }
                else
                {
                    Response.Write("Error creating contact: " + respContact[0].Errors[0].Message);
                    return false;
                }
            }
        }
    }
}