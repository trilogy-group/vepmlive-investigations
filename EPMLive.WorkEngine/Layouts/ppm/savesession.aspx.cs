using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class savesession : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies.Get("EPKSessionInfo");
            
            if(cok == null)
            {
                cok = new HttpCookie("EPKSessionInfo");
                cok.Expires = DateTime.Now.AddMinutes(30);
                cok.Values.Add("Username", Request["UserName"]);
                cok.Values.Add("Password", Request["Password"]);
                cok.Values.Add("Domain", Request["Domain"]);

                Response.Cookies.Add(cok);

            }
            else
            {
                cok["Username"] = Request["UserName"];
                cok["Password"] = Request["Password"];
                cok["Domain"] = Request["Domain"];
                cok.Expires = DateTime.Now.AddMinutes(30);
            }
        }
    }
}
