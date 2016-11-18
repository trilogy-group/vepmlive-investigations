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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected string []strMenus;
    protected string strCurrentUser;
    protected string curPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        strMenus = new string[15];
        strCurrentUser = HttpContext.Current.User.Identity.Name;
        curPage = Path.GetFileName(Page.Request.Path).ToLower();

        
        switch (curPage)
        {
            case "default.aspx":
            case "editaccount.aspx":
                checkPermissions(1);
                strMenus[0] = "current";
                break;
            case "createaccount.aspx":
                strMenus[1] = "current";
                break;
            case "edituser.aspx":
            case "users.aspx":
                checkPermissions(2);
                strMenus[2] = "current";
                break;
            case "signups.aspx":
                checkPermissions(10);
                strMenus[14] = "current";
                break;
            case "oldsignups.aspx":
                checkPermissions(10);
                strMenus[3] = "current";
                break;
            case "editcustomer.aspx":
                checkPermissions(9);
                strMenus[4] = "current";
                break;
            case "customers.aspx":
                checkPermissions(8);
                strMenus[4] = "current";
                break;
            case "versions.aspx":
                strMenus[5] = "current";
                break;
            case "partnerrequests.aspx":
                checkPermissions(5);
                strMenus[6] = "current";
                break;
            case "activepartners.aspx":
                checkPermissions(5);
                strMenus[7] = "current";
                break;
            case "perms.aspx":
                checkPermissions(6);
                strMenus[8] = "current";
                break;
            case "addemail.aspx":
            case "emailtemplates.aspx":
                checkPermissions(4);
                strMenus[9] = "current";
                break;
            case "reports.aspx":
                checkPermissions(7);
                strMenus[10] = "current";
                break;
            case "addcustomer.aspx":
                checkPermissions(9);
                strMenus[12] = "current";
                break;
            case "fullfill.aspx":
                checkPermissions(9);
                strMenus[13] = "current";
                break;
            case "newzuoraorder.aspx":
                checkPermissions(11);
                strMenus[0] = "current";
                break;
        }        
    }

    private void checkPermissions(int level)
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
        cn.Open();

        bool hasPermissions = AdminSite.Helper.checkPermissions(level, cn);

        cn.Close();
        return;
        if(hasPermissions)
            return;
        else
            Response.Redirect("AccessDenied.aspx");
    }
}
