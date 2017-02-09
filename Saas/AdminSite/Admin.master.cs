using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using AdminSite;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected string []strMenus;
    protected string strCurrentUser;
    protected string curPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        strMenus = new string[16];
        strCurrentUser = HttpContext.Current.User.Identity.Name;
        curPage = Path.GetFileName(Page.Request.Path).ToLower();

        
        switch (curPage)
        {
            case "default.aspx":
            case "editaccount.aspx":
                checkPermissions(AppPermissions.AccountView);
                strMenus[0] = "current";
                break;
            case "createaccount.aspx":
                strMenus[1] = "current";
                break;
            case "edituser.aspx":
            case "users.aspx":
                checkPermissions(AppPermissions.UserView);
                strMenus[2] = "current";
                break;
            case "signups.aspx":
                checkPermissions(AppPermissions.TrialSignups);
                strMenus[14] = "current";
                break;
            case "oldsignups.aspx":
                checkPermissions(AppPermissions.TrialSignups);
                strMenus[3] = "current";
                break;
            case "editcustomer.aspx":
                checkPermissions(AppPermissions.OnsiteCustomerCreateOrEdit);
                strMenus[4] = "current";
                break;
            case "customers.aspx":
                checkPermissions(AppPermissions.ViewReports);
                strMenus[4] = "current";
                break;
            case "versions.aspx":
                strMenus[5] = "current";
                break;
            case "partnerrequests.aspx":
                checkPermissions(AppPermissions.PartnerAdmin);
                strMenus[6] = "current";
                break;
            case "activepartners.aspx":
                checkPermissions(AppPermissions.PartnerAdmin);
                strMenus[7] = "current";
                break;
            case "perms.aspx":
                checkPermissions(AppPermissions.OnsiteCustomerView);
                strMenus[8] = "current";
                break;
            case "addemail.aspx":
            case "emailtemplates.aspx":
                checkPermissions(AppPermissions.EmailTemplateAdmin);
                strMenus[9] = "current";
                break;
            case "reports.aspx":
                checkPermissions(AppPermissions.AdminSitePermissions);
                strMenus[10] = "current";
                break;
            case "addcustomer.aspx":
                checkPermissions(AppPermissions.OnsiteCustomerCreateOrEdit);
                strMenus[12] = "current";
                break;
            case "fullfill.aspx":
                checkPermissions(AppPermissions.OnsiteCustomerCreateOrEdit);
                strMenus[13] = "current";
                break;
            case "newzuoraorder.aspx":
                checkPermissions(AppPermissions.CreateZuoraOrders);
                strMenus[0] = "current";
                break;
            case "manageproducts.aspx":
                checkPermissions(AppPermissions.AdminSitePermissions);
                strMenus[15] = "current";
                break;
        }        
    }

    private void checkPermissions(AppPermissions level)
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
        cn.Open();

        bool hasPermissions = AdminSite.Helper.checkPermissions((int)level, cn);

        cn.Close();
        return;
        if(hasPermissions)
            return;
        else
            Response.Redirect("AccessDenied.aspx");
    }
}
