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
    public class IntegrationControls : ITemplate
    {
        private Control control;

        public IntegrationControls(Control c)
        {
            control = c;
        }

        public void InstantiateIn(Control container)
        {
            container.Controls.Add(control);
        }
    }
}
