using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class signups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtFilterFor.Text != "")
            {
                doSearch();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "vw")
            {
                pnlMain.Visible = false;
                pnlProcess.Visible = true;

                string[] sArgs = e.CommandArgument.ToString().Split('.');
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();
                SqlCommand cmd;
                SqlDataReader dr;

                switch(sArgs[0])
                {
                    case "2":
                        cmd = new SqlCommand("select firstname, lastname, email, company, phone, country, state, status from signups where signup_id=@id ", cn);
                        cmd.Parameters.AddWithValue("@id", sArgs[1]);
                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            lblCompany.Text = dr.GetString(3);
                            lblEmail.Text = dr.GetString(2);
                            lblFirstName.Text = dr.GetString(0);
                            lblLastName.Text = dr.GetString(1);
                            if(!dr.IsDBNull(5))
                                lblCountry.Text = dr.GetString(5);

                            if(!dr.IsDBNull(6))
                                lblState.Text = dr.GetString(6);

                            if(!dr.IsDBNull(4))
                                lblPhone.Text = dr.GetString(4);

                            if(dr.GetInt32(7) != 0)
                            {
                                lblProcess.Text = "Already Processed";
                            }
                            else
                            {
                                lblProcess.Text = "<a href=\"http://signup.workengine.com/completesignup.aspx?id=" + sArgs[1] + "\" target=\"_blank\">Process Now</a>";
                            }
                        }
                        dr.Close();                        break;
                    case "3":
                        cmd = new SqlCommand("select first_name, last_name, email, company, processed from pesignups where id=@id ", cn);
                        cmd.Parameters.AddWithValue("@id", sArgs[1]);
                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            lblCompany.Text = dr.GetString(3);
                            lblEmail.Text = dr.GetString(2);
                            lblFirstName.Text = dr.GetString(0);
                            lblLastName.Text = dr.GetString(1);

                            if(dr.GetBoolean(4))
                            {
                                lblProcess.Text = "Already Processed";
                            }
                            else
                            {
                                lblProcess.Text = "<a href=\"http://signup.projectengine.com/completesignup.aspx?id=" + sArgs[1] + "\" target=\"_blank\">Process Now</a>";
                            }
                        }
                        dr.Close();
                        break;
                    case "4":
                        cmd = new SqlCommand("select firstname, lastname, email, company, phone, country, state, status from signups where signup_id=@id ", cn);
                        cmd.Parameters.AddWithValue("@id", sArgs[1]);
                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            lblCompany.Text = dr.GetString(3);
                            lblEmail.Text = dr.GetString(2);
                            lblFirstName.Text = dr.GetString(0);
                            lblLastName.Text = dr.GetString(1);
                            if(!dr.IsDBNull(5))
                                lblCountry.Text = dr.GetString(5);

                            if(!dr.IsDBNull(6))
                                lblState.Text = dr.GetString(6);

                            if(!dr.IsDBNull(4))
                                lblPhone.Text = dr.GetString(4);

                            if(dr.GetInt32(7) != 0)
                            {
                                lblProcess.Text = "Already Processed";
                            }
                            else
                            {
                                lblProcess.Text = "<a href=\"http://signup.portfolioengine.com/completesignup.aspx?id=" + sArgs[1] + "\" target=\"_blank\">Process Now</a>";
                            }
                        }
                        dr.Close();
                        break;
                    case "5":
                        lblVersion.Text = "Free";
                        showItem(sArgs[1], cn);
                        break;
                    case "6":
                        lblVersion.Text = "Express";
                        showItem(sArgs[1], cn);
                        break;
                    case "7":
                        lblVersion.Text = "Professional";
                        showItem(sArgs[1], cn);
                        break;
                    case "8":
                        lblVersion.Text = "Enterprise";
                        showItem(sArgs[1], cn);
                        break;
                    case "9":
                        lblVersion.Text = "Dedicated";
                        showItem(sArgs[1], cn);
                        break;
                    case "10":
                        lblVersion.Text = "Ultimate";
                        showItem(sArgs[1], cn);
                        break;
                }

                cn.Close();
            }
        }

        private void showItem(string id, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("select firstname, lastname, email, company, phone, country, state, status from signups where signup_id=@id ", cn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                lblCompany.Text = dr.GetString(3);
                lblEmail.Text = dr.GetString(2);
                lblFirstName.Text = dr.GetString(0);
                lblLastName.Text = dr.GetString(1);
                if(!dr.IsDBNull(5))
                    lblCountry.Text = dr.GetString(5);

                if(!dr.IsDBNull(6))
                    lblState.Text = dr.GetString(6);

                if(!dr.IsDBNull(4))
                    lblPhone.Text = dr.GetString(4);

                if(dr.GetInt32(7) != 0)
                {
                    lblProcess.Text = "Already Processed";
                }
                else
                {
                    lblProcess.Text = "<a href=\"http://signup.epmlive.com/completesignup.aspx?id=" + id + "\" target=\"_blank\">Process Now</a>";
                }
            }
            dr.Close();
        }

        private void doSearch()
        {
            GridView1.Visible = true;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            string sql = "";

            if(dllProduct.SelectedValue == "3")
            {
                string filterby = ddlFilterBy.SelectedValue.ToLower();

                if(filterby == "firstname")
                    filterby = "first_name";
                else if(filterby == "lastname")
                    filterby = "last_name";

                sql = "SELECT convert(varchar(1),3) + '.' + convert(varchar(50),id) as signup_id, coalesce(first_Name,'') + ' ' + coalesce(last_Name,'') as name, email, company, dtcreated as dtrequested, processed = case when processed = 1 then 'Yes' else 'No' end  FROM PESIGNUPS WHERE " + filterby + " like '%" + txtFilterFor.Text + "%'";

                if(!chkComplete.Checked)
                    sql += " AND processed = 0";

            }
            else if(dllProduct.SelectedValue == "5")
            {
                sql = "SELECT convert(varchar(1), appversion) + '.' + convert(varchar(50), signup_id) as signup_id, coalesce(firstName,'') + ' ' + coalesce(lastName,'') as name, email, company, dtrequested,  processed = case when status = 0 then 'No' else 'Yes' end, appversion FROM SIGNUPS WHERE (" + ddlFilterBy.SelectedValue + " like '%" + txtFilterFor.Text + "%' and appversion > 4)";

                if(!chkComplete.Checked)
                    sql += " AND status = 0";
            }
            else
            {

                sql = "SELECT convert(varchar(1), appversion) + '.' + convert(varchar(50), signup_id) as signup_id, coalesce(firstName,'') + ' ' + coalesce(lastName,'') as name, email, company, dtrequested,  processed = case when status = 0 then 'No' else 'Yes' end, appversion FROM SIGNUPS WHERE (" + ddlFilterBy.SelectedValue + " like '%" + txtFilterFor.Text + "%' and appversion=" + dllProduct.SelectedValue + ")";

                if(!chkComplete.Checked)
                    sql += " AND status = 0";
            }

            cmdGetSites = new SqlCommand(sql, cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            GridView1.DataSource = ds;
            GridView1.DataBind();

            lblResults.Text = "Number of Results: " + ds.Tables[0].Rows.Count;
        }
    }
}