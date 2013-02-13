using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Microsoft.SharePoint;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Microsoft.SharePoint.WebControls;


namespace EPMLiveCore.API.Integration
{
    public class IntegrationControlTemplate : ITemplate
    {
        private Control control;
        private Page page;
        private string title;

        public IntegrationControlTemplate(Control c, Page page, string title)
        {
            control = c;
            this.page = page;
            this.title = title;
        }

        public void InstantiateIn(Control container)
        {
            InputFormControl formControl = (InputFormControl)page.LoadControl("~/_controltemplates/InputFormControl.ascx");
            formControl.LabelText = title;
            IntegrationControls iControl = new IntegrationControls(control);

            formControl.Template_Control = iControl;

            container.Controls.Add(formControl);
            
        }
    }
}
