using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        userNameTextbox.Attributes.Add("style", "BORDER-BOTTOM: #dddddd 2px solid; BORDER-LEFT: #dddddd 2px solid; MARGIN-TOP: 15px; BORDER-TOP: #dddddd 2px solid; BORDER-RIGHT: #dddddd 2px solid; LEFT: -2px");
        userNameTextbox.Attributes.Add("placeholder", "Username");

        userPassword.Attributes.Add("style", "BORDER-BOTTOM: #dddddd 2px solid; BORDER-LEFT: #dddddd 2px solid; MARGIN-TOP: 10px; BORDER-TOP: #dddddd 2px solid; BORDER-RIGHT: #dddddd 2px solid; LEFT: -2px");
        userPassword.Attributes.Add("placeholder", "Password");
  
    }
}