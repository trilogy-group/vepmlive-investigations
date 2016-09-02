using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace EPMLiveCore.Layouts.epmlive.reporting.izenda
{
    public partial class Manage : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuTemplate propertyNameListMenu = new MenuTemplate();

            propertyNameListMenu.ID = "PropertyNameListMenu";


            MenuItemTemplate testMenu = new MenuItemTemplate("Edit Report", "/_layouts/epmlive/images/integration/editcon.png");

            testMenu.ClientOnClickNavigateUrl = "edit.aspx?name=%NAME%";

            propertyNameListMenu.Controls.Add(testMenu);

            this.Controls.Add(propertyNameListMenu);


            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM IzendaAdHocReports where TenantID=@siteid order by Name", cn);
                cmd.Parameters.AddWithValue("@siteid", Convert.ToString(Web.ID));

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                ds.Tables[0].Columns.Add("Category");
                ds.Tables[0].Columns.Add("ShortName");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["Name"].ToString().Contains("\\"))
                    {
                        string[] sName = dr["Name"].ToString().Split('\\');
                        dr["ShortName"] = sName[1];
                        dr["Category"] = sName[0];
                    }
                    else
                    {
                        dr["ShortName"] = dr["Name"];
                        dr["Category"] = "Uncategorized";
                    }

                    dr["Name"] = System.Web.HttpUtility.UrlEncode(dr["Name"].ToString());
                }

                DataTable dt = ds.Tables[0];                
                dt = dt.AsEnumerable().GroupBy(x => x["Category"]).SelectMany(g => g.OrderBy(v => v["ShortName"])).CopyToDataTable();
                
                gvReports.DataSource = dt;
                gvReports.DataBind();

                cn.Close();
            });
        }
    }
}
