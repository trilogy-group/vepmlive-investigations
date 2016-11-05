using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace BillingSite.appstore
{
    public partial class AppStore1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Dictionary<string, string> additional = new Dictionary<string, string>();

                additional.Add("FullName", Request["Name"]);
                additional.Add("Email", Request["Email"]);
                additional.Add("Comment", Request["Comment"]);

                using(var productService = new ProductService("d0f60e34801f03c96dc14b803ff63f90", "34c6334e48513be94a8e88a2f5e6f172", "epmlive", "APPSTOREINFORMATION", System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString))
                {
                    //string[] fields = txtEntityFields.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    XDocument responseXml = XDocument.Parse(productService.Reterive(Request["productid"], new string[] { }));
                    productService.Save(responseXml, additional);

                    //treeView.Nodes.Clear();
                    //FillTreeView(treeView.Nodes, responseXml.Root);
                }
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}