using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Reflection;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class acttest : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Type comObjectType = Type.GetTypeFromProgID("ActivationCom.Activation");

            object comObject = Activator.CreateInstance(comObjectType);

            object[] myparams = new object[] { "Test", 1 };

            string s = (string)comObjectType.InvokeMember("SetUserLevel",
                BindingFlags.InvokeMethod,
                null,
                comObject,
                myparams); 

            comObject = null;

            lblMain.Text = s;




        }
    }
}
