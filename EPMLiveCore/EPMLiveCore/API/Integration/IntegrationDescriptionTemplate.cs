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
    public class IntegrationDescriptionTemplate : ITemplate
    {
        private Label lbl;
        private string _text;

        public IntegrationDescriptionTemplate(string text)
        {
            _text = text;
        }

        public void InstantiateIn(Control container)
        {
            lbl = new Label(); ;
            lbl.Text = _text;
            container.Controls.Add(lbl);
        }
    }
}
