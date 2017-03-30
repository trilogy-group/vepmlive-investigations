using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace BillingSite.sales
{
    public partial class onlinepricingtool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(IsPostBack)
            {
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


                if(txtUsers.Text == "")
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width=\"300\">");
                    sb.Append("<tr><td>25</td><td>");
                    sb.Append(string.Format("{0:C}", float.Parse(drPricing[ddlVersion.SelectedValue + "25"].ToString()) * float.Parse(ddlContract.SelectedValue)* float.Parse(ddlBilling.SelectedValue)));
                    sb.Append("</td></tr>");

                    decimal standardPrice = decimal.Parse(drPricing["Standard25"].ToString());

                    decimal basePrice = 0;
                    try
                    {
                        basePrice = decimal.Parse(drPricing[ddlVersion.SelectedValue + "Base"].ToString());
                    }
                    catch { }

                    for(int i = 50; i <= 500; i += 50)
                    {
                        sb.Append("<tr><td>");
                        sb.Append(i);
                        sb.Append("</td><td>");
                        if(ddlVersion.SelectedValue != "Standard")
                        {
                            standardPrice *= (decimal).97;

                            sb.Append(string.Format("{0:C}", Math.Round((basePrice / (decimal)i / (decimal)12 + standardPrice) * decimal.Parse(ddlContract.SelectedValue), 2) * decimal.Parse(ddlBilling.SelectedValue)));
                        }
                        else
                        {
                            standardPrice *= (decimal).97;

                            sb.Append(string.Format("{0:C}", standardPrice * decimal.Parse(ddlContract.SelectedValue) * decimal.Parse(ddlBilling.SelectedValue)));
                        }



                        sb.Append("</td></tr>");
                    }
                    sb.Append("</table>");

                    lblOutput.Text += "<br>" + sb.ToString();
                }
                else
                {

                    float userCount = float.Parse(txtUsers.Text);
                    decimal standardPrice = 0;

                    if(userCount <= 25)
                    {
                        if(ddlVersion.SelectedValue != "Standard")
                        {
                            userCount = 25;
                            txtUsers.Text = "25";
                        }

                        standardPrice = decimal.Parse(drPricing[ddlVersion.SelectedValue + "25"].ToString()) * decimal.Parse(ddlContract.SelectedValue);
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

                            //standardPrice = (basePrice / i / 12 + standardPrice * (float).97) * float.Parse(ddlContract.SelectedValue) * float.Parse(ddlBilling.SelectedValue);
                        }
                        else
                        {
                            //standardPrice = standardPrice * (float).97 * float.Parse(ddlContract.SelectedValue) * float.Parse(ddlBilling.SelectedValue);
                            standardPrice = (decimal)Math.Round(standardPrice * (decimal).97 * decimal.Parse(ddlContract.SelectedValue), 2) * decimal.Parse(ddlBilling.SelectedValue);
                        }

                    }

                    //standardPrice = standardPrice * float.Parse(ddlContract.SelectedValue);

                    lblOutput.Text += "<b>Users:</b> " + userCount + "<br><br>";

                    lblOutput.Text += "<b>Price Per User " + ddlBilling.SelectedItem.Text +":</b> " + string.Format("{0:C}", standardPrice) + "<br><br>";

                    lblOutput.Text += "<b>Total " + ddlBilling.SelectedItem.Text + " Cost:</b> " + string.Format("{0:C}", standardPrice * decimal.Parse(txtUsers.Text));

                }
                cn.Close();

            }
        }

    }
}