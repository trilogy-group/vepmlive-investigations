using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.SiteCollectionSetupWizard
{
    [ToolboxItemAttribute(false)]
    public class SiteCollectionSetupWizard : WebPart
    {
        protected override void CreateChildControls()
        {

        }

        public override BorderStyle BorderStyle
        {
            get
            {
                return BorderStyle.None;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            SPUser user = SPContext.Current.Web.CurrentUser;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPContext.Current.Web;

                string webguid = "";

                if (web.Properties.ContainsKey("workenginewizard"))
                {
                    webguid = web.Properties["workenginewizard"];
                }
                try
                {
                    if (webguid != web.ID.ToString())
                    {
                        writer.WriteLine(@"<script language=""javascript"">
                        function loadWizard(){
                            setTimeout(""loadWizard2()"", 1000);
                        }

                        function loadWizard2()
                        {
                            var tag = document.getElementsByTagName('object');
                            
                            for(var i = tag.length-1;i>=0;i--)
                                tag[i].style.display='none';
                            
        
                            function myCallback(dialogResult, returnValue) 
                            {
                                var tag = document.getElementsByTagName('object');
                            
                                for(var i = tag.length-1;i>=0;i--)
                                    tag[i].style.display='';
                            }

                            var options = {url: """ + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + @"/_layouts/epmlive/tlwizard.aspx"", width: 500, dialogReturnValueCallback:myCallback};
                            SP.UI.ModalDialog.showModalDialog(options);
                        }

                        SP.SOD.executeOrDelayUntilScriptLoaded(loadWizard, ""sp.ui.dialog.js"");

                        </script>");
                    }
                    
                }
                catch { }
            });
        }
    }
}
