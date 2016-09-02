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
using Microsoft.SharePoint;
using System.Text;
using System.Xml;

namespace EPMLiveWorkPlanner
{
    public partial class getmenu : System.Web.UI.Page
    {
        protected string data;

        SPList list;
        SPWeb web;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            web = SPContext.Current.Web;

            list = web.Lists[new Guid(Request["listId"])];

            string xml = "<menu absolutePosition=\"auto\" mode=\"popup\" maxItems=\"8\"  globalCss=\"contextMenu\" globalSecondCss=\"contextMenu\" globalTextCss=\"contextMenuItem\" mixedImages=\"1\">";

            if (list.DoesUserHavePermissions(SPBasePermissions.ViewListItems))
                xml += "<MenuItem name=\"View Item\" id=\"view\" src=\"../../../../images/BLANK.GIF\" withoutImages=\"1\"/>";

            if(list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                xml += "<MenuItem name=\"Edit Item\" src=\"../../../../images/edititem.gif\"  id=\"edit\" imageSize=\"16px\"/>";
                
            if(list.DoesUserHavePermissions(SPBasePermissions.ManagePermissions))
                xml += "<MenuItem name=\"Manage Permissions\" src=\"../../../../images/managePerm.gif\"  id=\"perms\" imageSize=\"16px\"/>";

            if(list.DoesUserHavePermissions(SPBasePermissions.DeleteListItems))
                xml += "<MenuItem name=\"Delete Item\" src=\"../../../../images/delete.gif\"  id=\"delete\" imageSize=\"16px\"/>";

            bool version = false;
            bool workflow = false;
            if (list.EnableVersioning)
                if(list.DoesUserHavePermissions(SPBasePermissions.ViewVersions))
                    version = true;

            if (list.WorkflowAssociations.Count > 0)
                if (list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                    workflow = true;

            if (version || workflow)
                xml += "<divider id=\"divVersions\"/>";
            if(version)
                xml += "<MenuItem name=\"Version History\" src=\"../../../../images/VERSIONS.GIF\"  id=\"versions\" imageSize=\"16px\"/>";
            if (workflow)
                xml += "<MenuItem name=\"Workflows\" src=\"../../../../images/workflows.gif\"  id=\"workflows\" imageSize=\"16px\"/>";
            
            xml += "<divider id=\"div_1\"/>";

            xml += "<MenuItem name=\"Alert Me\" src=\"../../../../images/BELL.GIF\"  id=\"alerts\" imageSize=\"16px\"/>";

            if (list.EnableModeration)
                if (list.DoesUserHavePermissions(SPBasePermissions.ApproveItems))
                    xml += "<MenuItem name=\"Approve/Reject\" src=\"../../../../images/APPRJ.GIF\"  id=\"approve\" imageSize=\"16px\"/>";

            xml += "</menu>";
            data = xml;
        }
    }
}