using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.reporting.izenda
{
    public partial class Manage : LayoutsPageBase
    {
        private const string NameColumn = "Name";
        private const string CategoryColumn = "Category";
        private const string ShortNameColumn = "ShortName";

        protected void Page_Load(object sender, EventArgs e)
        {
            MenuTemplate propertyNameListMenu = new MenuTemplate();

            propertyNameListMenu.ID = "PropertyNameListMenu";


            MenuItemTemplate testMenu = new MenuItemTemplate("Edit Report", "/_layouts/epmlive/images/integration/editcon.png");

            testMenu.ClientOnClickNavigateUrl = "edit.aspx?name=%NAME%";

            propertyNameListMenu.Controls.Add(testMenu);

            this.Controls.Add(propertyNameListMenu);


            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var connection = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id)))
                {
                    connection.Open();

                    using (var command = new SqlCommand("SELECT * FROM IzendaAdHocReports where TenantID=@siteid order by Name", connection))
                    {
                        command.Parameters.AddWithValue("@siteid", Convert.ToString(Web.ID));

                        using (var dataSet = new DataSet())
                        {
                            using (var dataReader = new SqlDataAdapter(command))
                            {
                                dataReader.Fill(dataSet);

                                dataSet.Tables[0].Columns.Add(CategoryColumn);
                                dataSet.Tables[0].Columns.Add(ShortNameColumn);

                                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                                {
                                    if (dataRow[NameColumn].ToString().Contains("\\"))
                                    {
                                        var names = dataRow[NameColumn].ToString().Split('\\');
                                        dataRow[ShortNameColumn] = names[1];
                                        dataRow[CategoryColumn] = names[0];
                                    }
                                    else
                                    {
                                        dataRow[ShortNameColumn] = dataRow[NameColumn];
                                        dataRow[CategoryColumn] = "Uncategorized";
                                    }

                                    dataRow[NameColumn] = HttpUtility.UrlEncode(dataRow[NameColumn].ToString());
                                }

                                var dataTable = dataSet.Tables[0]
                                    .AsEnumerable()
                                    .GroupBy(x => x[CategoryColumn])
                                    .SelectMany(g => g.OrderBy(v => v[ShortNameColumn]))
                                    .CopyToDataTable();

                                gvReports.DataSource = dataTable;
                                gvReports.DataBind();
                            }
                        }
                    }
                }
            });
        }
    }
}
