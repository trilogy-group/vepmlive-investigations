using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore
{
    public partial class AsyncNavActions : System.Web.UI.Page
    {
        private string _action = string.Empty;
        private int _appId = -1;
        private int _origUserId = -1;
        private string _title = string.Empty;
        private string _url = string.Empty;
        private string _nodeType = string.Empty;
        private int _headingNodeId = -1;
        private int _nodeId = -1;
        private int _parentNodeId = -1;
        private string _moveInfos = string.Empty;
        private AppSettingsHelper appHelper;
        private string _status = "success";


        private void GetParams()
        {
            _action = Request["action"];
            int.TryParse(Request["appid"], out _appId);
            int.TryParse(Request["origuserid"], out _origUserId);
            _title = Request["title"];
            _url = Request["url"];
            _nodeType = Request["nodetype"];
            int.TryParse(Request["headingnodeid"], out _headingNodeId);
            int.TryParse(Request["nodeId"], out _nodeId);
            int.TryParse(Request["parentnodeid"], out _parentNodeId);
            _moveInfos = Request["moveinfos"];
            appHelper = new AppSettingsHelper();
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            GetParams();
            Execute();
            OutputResult();
        }

        private void Execute()
        {
            switch (_action.ToLower())
            {
                case "createparentnode":
                    try
                    {
                        appHelper.CreateParentNode(_appId, _nodeType, _title, _url, !appHelper.IsUrlInternal(_url), SPContext.Current.Web.AllUsers.GetByID(_origUserId));

                        API.Applications.CreateQuickLaunchXML(_appId, SPContext.Current.Web);
                        API.Applications.CreateTopNavXML(_appId, SPContext.Current.Web);
                    }
                    catch (Exception e)
                    {
                        _status = "error: " + e.Message;
                    }
                    break;

                case "createchildnode":
                    try
                    {
                        appHelper.CreateChildNode(_appId, _nodeType, _title, _url, _headingNodeId, !appHelper.IsUrlInternal(_url), SPContext.Current.Web.AllUsers.GetByID(_origUserId));
                        API.Applications.CreateQuickLaunchXML(_appId, SPContext.Current.Web);
                        API.Applications.CreateTopNavXML(_appId, SPContext.Current.Web);
                    }
                    catch (Exception e)
                    {
                        _status = "error: " + e.Message;
                    }
                    break;

                case "deletenode":
                    try
                    {
                        appHelper.DeleteNode(_appId, _nodeId, _nodeType, SPContext.Current.Web.AllUsers.GetByID(_origUserId));
                        API.Applications.CreateQuickLaunchXML(_appId, SPContext.Current.Web);
                        API.Applications.CreateTopNavXML(_appId, SPContext.Current.Web);
                    }
                    catch (Exception e)
                    {
                        _status = "error: " + e.Message;
                    }

                    break;
                case "editnode":
                    try
                    {
                        appHelper.EditNodeById(_parentNodeId, _nodeId, _title, _url, _appId, _nodeType, SPContext.Current.Web.AllUsers.GetByID(_origUserId));
                        API.Applications.CreateQuickLaunchXML(_appId, SPContext.Current.Web);
                        API.Applications.CreateTopNavXML(_appId, SPContext.Current.Web);
                    }
                    catch (Exception e)
                    {
                        _status = "error: " + e.Message;
                    }
                    break;
                case "movenode":
                    try{
                        appHelper.UpdateNodeOrder(_appId, _nodeType, _moveInfos, SPContext.Current.Web.AllUsers.GetByID(_origUserId));
                        API.Applications.CreateQuickLaunchXML(_appId, SPContext.Current.Web);
                        API.Applications.CreateTopNavXML(_appId, SPContext.Current.Web);
                    }
                    catch (Exception e)
                    {
                        _status = "error: " + e.Message;
                    }
                    break;
                default:
                    break;
            }
        }

        private void OutputResult()
        {
            Response.Output.WriteLine(_status);
        }
    }
}
