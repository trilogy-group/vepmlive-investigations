using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Net;
using EPMLiveCore;
using System.Web;

namespace EPMLiveCore
{
    public partial class CommentsProxy : LayoutsPageBase
    {
        #region Fields
        Guid _listId;
        string _itemId;
        string _userId;
        string _command;
        string _comment;
        string _newComment;
        string _commentItemId;
        private bool _statusUpdate;
        private string _statusUpdateId;
        #endregion

        private void CreateComment()
        {
            SPSite currentSite = SPContext.Current.Site;
            SPWeb currentWeb = SPContext.Current.Web;

            string xmlData = "<Data>" +
                             "<Param key=\"ListId\">" + _listId.ToString("D") + "</Param>" +
                             "<Param key=\"ItemId\">" + _itemId + "</Param>" +
                             "<Param key=\"Comment\"><![CDATA[" + _comment + "]]></Param>" +
                             "<Param key=\"StatusUpdate\"><![CDATA[" + _statusUpdate + "]]></Param>" +
                             "<Param key=\"StatusUpdateId\"><![CDATA[" + _statusUpdateId + "]]></Param>" +
                             "</Data>";

            string svcCallResult = string.Empty;

            //WorkEngineService.WorkEngine workEngineSvc = new WorkEngineService.WorkEngine();
            
            //workEngineSvc.UseDefaultCredentials = true;
            //workEngineSvc.Url = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_vti_bin/workengine.asmx";
            //svcCallResult = workEngineSvc.Execute("CreateComment", xmlData);
            svcCallResult = WorkEngineAPI.CreateComment(xmlData, currentWeb);
            //Response.Output.WriteLine(JSONUtil.ConvertXmlToJson(svcCallResult, ""));
            Response.Output.WriteLine(svcCallResult);
        }

        private void UpdateComment()
        {
            SPSite currentSite = SPContext.Current.Site;
            SPWeb currentWeb = SPContext.Current.Web;

            string xmlData = "<Data>" +
                             "<Param key=\"ListId\">" + _listId.ToString("D") + "</Param>" +
                             "<Param key=\"ItemId\">" + _itemId + "</Param>" +
                             "<Param key=\"CommentItemId\">" + _commentItemId + "</Param>" +
                             "<Param key=\"Comment\"><![CDATA[" + _newComment + "]]></Param>" +
                             "<Param key=\"StatusUpdate\"><![CDATA[" + _statusUpdate + "]]></Param>" +
                             "<Param key=\"StatusUpdateId\"><![CDATA[" + _statusUpdateId + "]]></Param>" +
                             "</Data>";

            string svcCallResult = string.Empty;
            //using (WorkEngineService.WorkEngine workEngineSvc = new WorkEngineService.WorkEngine())
            //{
            //    workEngineSvc.Credentials = CredentialCache.DefaultCredentials;
            //    workEngineSvc.Url = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_vti_bin/WorkEngine.asmx";

            //    svcCallResult = workEngineSvc.Execute("UpdateComment", xmlData);
            //}

            svcCallResult = WorkEngineAPI.UpdateComment(xmlData, currentWeb);

            //Response.Output.WriteLine(JSONUtil.ConvertXmlToJson(svcCallResult, ""));
            Response.Output.WriteLine(svcCallResult);
        }

        private void ReadComment()
        {
            SPSite currentSite = SPContext.Current.Site;
            SPWeb currentWeb = SPContext.Current.Web;

            string xmlData = "<Data>" +
                             "<Param key=\"ListId\">" + _listId.ToString("D") + "</Param>" +
                             "<Param key=\"ItemId\">" + _itemId + "</Param>" +
                             "<Param key=\"CommentItemId\">" + _commentItemId + "</Param>" +
                             "<Param key=\"StatusUpdate\"><![CDATA[" + _statusUpdate + "]]></Param>" +
                             "<Param key=\"StatusUpdateId\"><![CDATA[" + _statusUpdateId + "]]></Param>" +
                             "</Data>";

            string svcCallResult = string.Empty;
            //using (WorkEngineService.WorkEngine workEngineSvc = new WorkEngineService.WorkEngine())
            //{
            //    
            //    workEngineSvc.Credentials = CredentialCache.DefaultCredentials;
            //    workEngineSvc.Url = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_vti_bin/WorkEngine.asmx";

            //    svcCallResult = workEngineSvc.Execute("ReadComment", xmlData);
            //}

            svcCallResult = WorkEngineAPI.ReadComment(xmlData, currentWeb);

            //Response.Output.WriteLine(JSONUtil.ConvertXmlToJson(svcCallResult, ""));
            Response.Output.WriteLine(svcCallResult);
        }

        private void DeleteComment()
        {
            SPSite currentSite = SPContext.Current.Site;
            SPWeb currentWeb = SPContext.Current.Web;

            string xmlData = "<Data>" +
                             "<Param key=\"ListId\">" + _listId.ToString("D") + "</Param>" +
                             "<Param key=\"ItemId\">" + _itemId + "</Param>" +
                             "<Param key=\"CommentItemId\">" + _commentItemId + "</Param>" +
                             "<Param key=\"StatusUpdate\"><![CDATA[" + _statusUpdate + "]]></Param>" +
                             "<Param key=\"StatusUpdateId\"><![CDATA[" + _statusUpdateId + "]]></Param>" +
                             "</Data>";

            string svcCallResult = string.Empty;
            //using (WorkEngineService.WorkEngine workEngineSvc = new WorkEngineService.WorkEngine())
            //{
            //    
            //    workEngineSvc.Credentials = CredentialCache.DefaultCredentials;
            //    workEngineSvc.Url = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_vti_bin/WorkEngine.asmx";

            //    svcCallResult = workEngineSvc.Execute("DeleteComment", xmlData);
            //}

            svcCallResult = WorkEngineAPI.DeleteComment(xmlData, currentWeb);
            //Response.Output.WriteLine(JSONUtil.ConvertXmlToJson(svcCallResult, ""));
            Response.Output.WriteLine(svcCallResult);
        }

        private void ManageFields()
        {
            string s = Request["command"];
            _command = !string.IsNullOrEmpty(s) ? s : string.Empty;

            s = Request["comment"];
            _comment = !string.IsNullOrEmpty(s) ? s : string.Empty;

            s = Request["newcomment"];
            _newComment = !string.IsNullOrEmpty(s) ? s : string.Empty;

            s = Request["itemId"];
            _itemId = !string.IsNullOrEmpty(s) ? s : string.Empty;

            s = Request["commentItemId"];
            _commentItemId = !string.IsNullOrEmpty(s) ? s : string.Empty;

            s = Request["userId"];
            _userId = !string.IsNullOrEmpty(s) ? s : string.Empty;

            s = Request["kind"];
            _statusUpdate = (s ?? string.Empty).ToLower().Equals("statusupdate");

            s = Request["suid"];
            _statusUpdateId = !string.IsNullOrEmpty(s) ? s : string.Empty;

            if (!string.IsNullOrEmpty(Request["listId"]))
            {
                _listId = new Guid(Request["listId"]);
            }
        }

        private void HandleAjaxCalls()
        {
            switch (_command)
            {
                case "CreateComment":
                    CreateComment();
                    break;
                case "ReadComment":
                    ReadComment();
                    break;
                case "UpdateComment":
                    UpdateComment();
                    break;
                case "DeleteComment":
                    DeleteComment();
                    break;
                default:
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ManageFields();
            HandleAjaxCalls();
        }
    }
}
