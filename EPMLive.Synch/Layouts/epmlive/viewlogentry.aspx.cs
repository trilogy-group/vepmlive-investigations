using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;

namespace EPMLiveSynch
{
    public partial class ViewLogEntryPage : LayoutsPageBase
    {
        protected Label lblTitle;
        //protected TextBox txtLogEntry;
        protected Label lblLogEntry;
        protected Label lblLogDateTime;
        protected Button btnShowAllItems;
        protected string sLastResultLogText = "";
        protected string sLastResults = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["logaction"] != null && Request["logsource"] != null)
                {
                    string sLogSource = Request["logsource"].ToString();
                    using (SPWeb currWeb = SPContext.Current.Web)
                    {
                        LogHelper logHlpr = new LogHelper();
                        logHlpr.CurrWeb = currWeb;
                        logHlpr.Action = Request["logaction"].ToString();
                        logHlpr.Source = sLogSource;
                        sLastResultLogText = logHlpr.GetLastResultLogText;
                        sLastResults = logHlpr.GetLastResult;
                        lblLogDateTime.Text = sLastResults;
                        lblLogEntry.Text = sLastResults + "<br>" + sLastResultLogText;
                    }

                    /*if (sLogSource.Contains("/Lists/"))
                    {
                        sLogSource = "Synchronize List (" + sLogSource.Substring(sLogSource.LastIndexOf("/") + 1) + ")";
                    }
                    else
                    {
                        using (SPSite site = SPContext.Current.Site)
                        {
                            string sLogSourceURL = sLogSource.Substring(sLogSource.IndexOf("/"));
                            using(SPWeb w = site.OpenWeb(sLogSourceURL))
                            {
                                sLogSource = "Synchronize Template (" + w.Title + ")";
                            }
                        }
                    }
                    lblTitle.Text = "View Log: " + HttpUtility.HtmlEncode(sLogSource);
                    int iCnt = sLastResultLogText.Split('\r').Length;*/
                    //txtLogEntry.Height = iCnt * 19;
                }

                if (!Page.IsPostBack)
                {
                    ShowOnlyFailedItems();
                }
                else
                {
                    if (btnShowAllItems.Text == "Show Only Failed Items")
                    {
                        ShowOnlyFailedItems();
                        btnShowAllItems.Text = "Show All Items";
                    }
                    else
                    {
                        btnShowAllItems.Text = "Show Only Failed Items";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnShowAllItems_Click(object sender, EventArgs e)
        {

        }

        private void ShowOnlyFailedItems()
        {
            try
            {
                sLastResultLogText = "";
                string sWebLastResultLogText = "";
                string sCurrWeb = "";
                bool bHasFailedItem = false;
                string[] sBRseparator = new string[] { "<br>" };
                string[] sArrResultItems = lblLogEntry.Text.Split(sBRseparator, StringSplitOptions.RemoveEmptyEntries);
                for (int i = sArrResultItems.Length - 1; i > -1; i--)
                {
                    string sItem = sArrResultItems[i];
                    if (sItem.Contains("Web:") || sItem.Contains("List:"))
                    {
                        if (bHasFailedItem)
                        {
                            if (sArrResultItems[i - 1].Contains("Web:"))
                            {
                                sItem = sArrResultItems[i - 1] + "<br>" + sItem;
                                i--;
                            }
                            sLastResultLogText = sItem + "<br>" + sWebLastResultLogText + sLastResultLogText;
                            sWebLastResultLogText = "";
                            bHasFailedItem = false;
                        }
                    }

                    if (sItem.ToUpper().Contains("COLOR=\"BLACK\""))
                    {
                        sWebLastResultLogText += sItem + "<br>";
                        bHasFailedItem = true;
                    }

                }
                lblLogEntry.Text = lblLogDateTime.Text + "<br>" + sLastResultLogText;
            }
            catch (Exception exc)
            {

            }

        }

    }
}
