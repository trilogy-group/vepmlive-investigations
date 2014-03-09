using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class ViewLogDetail : Page
    {
        private EPMData _DAO;
        //protected Panel pnl_results;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sListName = string.Empty;
            string sEntries = string.Empty;
            Literal lit;

            var site = new SPSite(SPContext.Current.Site.ID);
            _DAO = new EPMData(site.ID);
            if (Request.QueryString["uid"] == null)
            {
                //_DAO.Command = string.Format("SELECT ListName, LongMessage FROM RPTLog WHERE RPTListID=@rptListID AND (Timestamp BETWEEN DATEADD(s, - 1, @timestamp) AND DATEADD(s, 2,@timestamp)) AND Type=@type AND CAST(ShortMessage as NVarchar(MAX))='{0}'", Request.QueryString["sm"]); - CAT.NET
                _DAO.Command =
                    "SELECT ListName, LongMessage FROM RPTLog WHERE RPTListID=@rptListID AND (Timestamp BETWEEN DATEADD(s, - 1, @timestamp) AND DATEADD(s, 2,@timestamp)) AND Type=@type AND CAST(ShortMessage as NVarchar(MAX))=@sm";
                    // - CAT.NET false-positive: All single quotes are escaped/removed.                
                _DAO.AddParam("@rptListID", Request.QueryString["id"]);
                _DAO.AddParam("@timestamp",
                    DateTime.Parse(Request.QueryString["ts"]).ToString(CultureInfo.GetCultureInfo("en-US")));
                _DAO.AddParam("@type", Request.QueryString["type"]);
                _DAO.AddParam("@sm", Request.QueryString["sm"]);

                DataTable dt = _DAO.GetTable(_DAO.GetClientReportingConnection);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (sListName != row["ListName"].ToString())
                        {
                            sListName = row["ListName"].ToString();
                            lit = new Literal();
                            lit.Text = "<b>" + sListName + "</b><br/><br/>";
                            pnl_results.Controls.Add(lit);
                        }

                        lit = new Literal();
                        lit.Text = row["LongMessage"].ToString();
                        pnl_results.Controls.Add(lit);
                    }
                }
                else
                {
                    lit = new Literal();
                    lit.Text = "<b> No errors found.</b><br/><br/>";
                    pnl_results.Controls.Add(lit);
                }
            }
            else
            {
                //_DAO.Command = string.Format("SELECT ListName, LongMessage, Timestamp FROM RPTLog WHERE timerjobguid='{0}'", Request.QueryString["uid"]);
                _DAO.Command = "SELECT ListName, LongMessage, Timestamp FROM RPTLog WHERE timerjobguid=@uid";
                _DAO.AddParam("@uid", Request.QueryString["uid"]);
                DataTable dt = _DAO.GetTable(_DAO.GetClientReportingConnection);
                var lists = new ArrayList();

                //Looping thru all rows and adding distinct list names
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!lists.Contains(row["ListName"].ToString()))
                        {
                            lists.Add(row["ListName"].ToString());
                        }
                    }
                }
                else
                {
                    lit = new Literal();
                    lit.Text = "<b> No errors found.</b><br/><br/>";
                    pnl_results.Controls.Add(lit);
                    return;
                }

                //Looping thru all lists
                foreach (string list in lists)
                {
                    sListName = list;
                    sEntries = string.Empty;

                    //Looping thru all list log entries
                    DataRow[] lstEntries = dt.Select("ListName='" + list + "'");
                    foreach (DataRow lstEntry in lstEntries)
                    {
                        sEntries = sEntries + lstEntry["LongMessage"] + " Run on " + lstEntry["Timestamp"] + " <br/>";
                    }

                    lit = new Literal();
                    lit.Text = "<b>" + sListName + "</b><br/>";
                    pnl_results.Controls.Add(lit);

                    lit = new Literal();
                    lit.Text = "&nbsp;&nbsp;&nbsp;" + sEntries;
                    pnl_results.Controls.Add(lit);
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }
    }
}