using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    public partial class regionalsetng : LayoutsPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            if(!CoreFunctions.DoesCurrentUserHaveFullControl(web))
            {
                Microsoft.SharePoint.Utilities.SPUtility.TransferToErrorPage("Access denied.");
            }

            if(!IsPostBack)
            {

                foreach(Microsoft.SharePoint.SPTimeZone tz in Microsoft.SharePoint.SPRegionalSettings.GlobalTimeZones)
                {
                    DdlwebTimeZone.Items.Add(new ListItem(tz.Description, tz.ID.ToString()));
                }

                foreach(SPLocale l in web.RegionalSettings.Locales)
                {
                    DdlwebLCID.Items.Add(new ListItem(l.DisplayName, l.LCID.ToString()));
                }


                DdlwebTimeZone.SelectedValue = web.RegionalSettings.TimeZone.ID.ToString();
                DdlwebLCID.SelectedValue = web.RegionalSettings.LocaleId.ToString();

                int work = web.RegionalSettings.WorkDays;
                for(byte x = 0; x < 7; x++)
                {
                    if(((work >> x) & 0x01) == 0x01)
                    {
                        ChkListWeeklyMultiDays.Items[x].Selected = true;
                    }
                    //if(!(((work >> x) & 0x01) == 0x01))
                    //    nonwork++;
                }

                DdlFirstDayOfWeek.SelectedValue = web.RegionalSettings.FirstDayOfWeek.ToString();
                DdlFirstWeekOfYear.SelectedValue = web.RegionalSettings.FirstWeekOfYear.ToString();
                if(web.RegionalSettings.Time24)
                    DdlTimeFormat.SelectedValue = "1";
                else
                    DdlTimeFormat.SelectedValue = "0";

                for(int i = 0; i < 24; i++)
                {
                    ListItem li = new ListItem(i.ToString("00") + ":00", (i * 60).ToString());
                    DdlStartTime.Items.Add(li);

                    li = new ListItem(i.ToString("00") + ":00", (i * 60).ToString());
                    DdlEndTime.Items.Add(li);
                }

                DdlStartTime.SelectedValue = web.RegionalSettings.WorkDayStartHour.ToString();
                DdlEndTime.SelectedValue = web.RegionalSettings.WorkDayEndHour.ToString();
            }
        }

        protected void BtnUpdateRegionalSettings_Click(object sender, EventArgs e)
        {
            SPWeb w = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(w.Site.ID))
                {
                    using(SPWeb web = site.OpenWeb(w.ID))
                    {
                        web.AllowUnsafeUpdates = true;
                        web.RegionalSettings.TimeZone.ID = ushort.Parse(DdlwebTimeZone.SelectedValue);
                        web.RegionalSettings.LocaleId = ushort.Parse(DdlwebLCID.SelectedValue);

                        web.RegionalSettings.FirstDayOfWeek = uint.Parse(DdlFirstDayOfWeek.SelectedValue);
                        web.RegionalSettings.FirstWeekOfYear = short.Parse(DdlFirstWeekOfYear.SelectedValue);

                        web.RegionalSettings.WorkDayStartHour = short.Parse(DdlStartTime.SelectedValue);
                        web.RegionalSettings.WorkDayEndHour = short.Parse(DdlEndTime.SelectedValue);

                        if(DdlTimeFormat.SelectedValue == "0")
                            web.RegionalSettings.Time24 = false;
                        else
                            web.RegionalSettings.Time24 = true;

                        short work = 0;

                        for(short i = 0; i < 7; i++)
                        {
                            if(ChkListWeeklyMultiDays.Items[i].Selected)
                            {
                                work += short.Parse(Math.Pow(2, i).ToString());
                            }
                        }

                        web.RegionalSettings.WorkDays = work;

                        web.Update();
                    }
                }
            });

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        protected void CancelButtonClick(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        protected void DdlWebLCIDIndex_Changed(object sender, EventArgs e)
        {

        }

        protected void DdlwebCalTypeWithROCIndex_Changed(object sender, EventArgs e)
        {

        }

        protected void DdlwebCalTypeIndex_Changed(object sender, EventArgs e)
        {

        }
        
        
    }
}
