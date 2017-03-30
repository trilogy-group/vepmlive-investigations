using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace NewSiteCollectionWebPart.Layouts.NewSiteCollectionWebPart
{
    public partial class CreateApplication : LayoutsPageBase
    {
        private const string SOLUTION_STORE_PROXY_URL = "/_layouts/EPMLive/SolutionStoreProxy.aspx?";
        private const string MORE_INFO_URL = "/_layouts/EPMLive/MoreInformation.aspx?";

        protected string _baseURL = string.Empty;
        protected string _requestProjectName = string.Empty;
        protected string _solutionStoreServiceProxyUrl = string.Empty;
        protected string _solutionType = string.Empty;
        protected string _templateType = string.Empty;
        protected string _contractLevel = string.Empty;
        protected string _moreInfoUrl = string.Empty;
        protected string _weburl;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitValues();
            Project_InitializeOnlineFilterPnl();
        }

        private void InitValues()
        {
            _solutionType = (!string.IsNullOrEmpty(Request.Params["type"])) ? Request.Params["type"] : string.Empty;
            _templateType = "";
            _baseURL = Web.ServerRelativeUrl == "/" ? Web.ServerRelativeUrl : Web.ServerRelativeUrl + "/";
            _solutionStoreServiceProxyUrl = Web.Url + SOLUTION_STORE_PROXY_URL;
            _contractLevel = EPMLiveAccountManagement.Settings.getContractLevel();
            _moreInfoUrl = Web.Url + MORE_INFO_URL;

            _weburl = _weburl = SPContext.Current.Web.ServerRelativeUrl;
            if (_weburl == "/")
                _weburl = "";

            if (!IsPostBack)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(EPMLiveAccountManagement.Settings.getConnectionString());
                    cn.Open();

                    SqlCommand cmdGetSites;

                    string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
                    if(username.Split('|').Length > 1)
                        username = username.Split('|')[1];

                    cmdGetSites = new SqlCommand("SELECT     dbo.ACCOUNT.accountDescription, dbo.ACCOUNT.account_id FROM         dbo.ACCOUNT INNER JOIN dbo.USERS ON dbo.ACCOUNT.owner_id = dbo.USERS.uid where username like @username", cn);
                    cmdGetSites.Parameters.AddWithValue("@username", username);

                    SqlDataReader dr = cmdGetSites.ExecuteReader();
                    while(dr.Read())
                    {
                        ddlAccount.Items.Add(new ListItem(dr.GetString(0), dr.GetGuid(1).ToString()));
                    }

                    cn.Close();
                    
                });
            }
        }

        private void Project_InitializeOnlineFilterPnl()
        {
            pnlEPMLiveFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlEPMLiveFilterBy.Controls.Add(new LiteralControl("</ul>"));
        }
    }
}
