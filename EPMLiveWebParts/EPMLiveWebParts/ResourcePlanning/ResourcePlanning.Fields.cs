using System.Web.UI.WebControls;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts
{
    public partial class ResourcePlanning
    {
        private const string EpmLiveResourcePlanResources = "EPMLiveResourcePlanResources";
        private SPList reslist;
        private SPList rcList;
        private SPView resview;
        private string resUrl;
        private int activation;
        private ViewToolBar toolbar;
        private SPWeb resWeb;
        private SPWeb curWeb;
        private string viewList = string.Empty;
        private string strAction = string.Empty;
        private LinkButton lnk;
        private Act act;
        private string sResourceList = string.Empty;
        private string error = string.Empty;
        private string sFullGridId = string.Empty;
    }
}