using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AdminSite
{
    public class CrmHelper
    {
        public CrmHelper()
        {

        }
        public static MSCRM.CrmService getCRMService()
        {
            MSCRM.CrmService msCrm = new MSCRM.CrmService();

            MSCRM.CrmAuthenticationToken token = new MSCRM.CrmAuthenticationToken();
            token.AuthenticationType = 0;
            token.OrganizationName = "EPMLive";

            msCrm.Url = "http://crm.epmlive.com/mscrmservices/2007/crmservice.asmx";

            msCrm.CrmAuthenticationTokenValue = token;
            //msCrm.Credentials = System.Net.CredentialCache.DefaultCredentials;
            msCrm.Credentials = new System.Net.NetworkCredential("sophia.king", "LMR$password", "epm");

            return msCrm;
        }
    }
}