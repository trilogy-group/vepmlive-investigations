using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public partial class SPResourceFieldMapping : LayoutsPageBase
    {
        private string url = null;
        private DataTable dtFields = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.InitializePage();
            //this.Master.SetTitle("Resource Field Mappings");

            //url = LMR_IF.getSiteUrl();
        //}

        //protected void Page_LoadComplete(object sender, EventArgs e)
        //{
            if (!IsPostBack)
            {
                //if (url != "")
                {
                    //pnlNoUrl.Visible = false;
                    //lblUrl.Text = url;
                    string sBaseInfo = WebAdmin.BuildBaseInfo(this.Context);
                    DataAccess da = new DataAccess(sBaseInfo);
                    DBAccess dba = da.dba;
                    populateSharePointFields(dba);
                    populateFieldMap(dba);
                }
                //else
                //{
                //    pnlMain.Visible = false;
                //}
            }
        }

        private void populateSharePointFields(DBAccess dba)
        {
            dtFields.Columns.Add("internalname");
            dtFields.Columns.Add("displayname");
            dtFields.Rows.Add(new object[] { "", "--- Select Field ---" });

            XmlNode ndSettings = null;
            if (ExecuteProcess("GetAvailableFields", "<Fields Key=\"EPK\" List=\"Resources\"/>", out ndSettings) == false) goto ExecuteProcess_Error;
            if (ndSettings.Attributes["Status"].Value != "0")
            {
                lblGeneralError.Text = "Unable to retrieve Fields: " + ndSettings.SelectSingleNode("Error").InnerText;
                lblGeneralError.Visible = true;
            }
            else
            {
                lblGeneralError.Visible = false;

                foreach (string sField in ndSettings.InnerText.Split('|'))
                {
                    if (sField != "")
                    {
                        string[] sFieldData = sField.Split(',');
                        dtFields.Rows.Add(new object[] { sFieldData[0], sFieldData[1] });
                    }
                }

                dtFields.DefaultView.Sort = "displayname";
            }
            return;
ExecuteProcess_Error:
            lblGeneralError.Text = LMR_IF.LastError;
            lblGeneralError.Visible = true;
        }

        private static bool ExecuteProcess(string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            return ExecuteProcessEx("", sContext, sXMLRequest, out xNode);
            return false;
        }

        private static bool ExecuteProcessEx(string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            bool b = true;
            Integration integration = new Integration();
            xNode = integration.execute(sContext, sXMLRequest);
            integration = null;
            return b;
        }

        private void populateFieldMap(DBAccess dba)
        {
            DataTable dtEPKFields = LMR_IF.getResourceFields(dba);
            dtEPKFields.Columns.Add("spField");

            XmlNode ndResPoolUrl = null;
            if (ExecuteProcess("getresourcepoolurl", "", out ndResPoolUrl) == false) goto ExecuteProcess_Error;
            if (ndResPoolUrl.InnerText != "")
            {
                lblResPoolUrl.Text = ndResPoolUrl.InnerText;

                string sUrl = ndResPoolUrl.InnerText; // +"/_vti_bin/Integration.asmx";
                XmlNode ndSettings = null;
                if (ExecuteProcessEx(sUrl, "GetSettings", "<Settings Key=\"EPK\"/>", out ndSettings) == false) goto ExecuteProcess_Error;
                XmlNode ndFields = ndSettings.SelectSingleNode("resourcefields");
                if (ndFields != null)
                {
                    string[] sFields = ndFields.InnerText.Split('|');
                    foreach (string sField in sFields)
                    {
                        string[] sFieldData = sField.Split(',');
                        DataRow[] drs = dtEPKFields.Select("epkFieldId='" + sFieldData[0] + "'");
                        foreach (DataRow dr in drs)
                        {
                            dr["spField"] = sFieldData[1];
                        }

                    }
                }

                GridView1.DataSource = dtEPKFields;
                GridView1.DataBind();

                GridView1.Columns[2].Visible = false;
            }
            else
            {
                lblGeneralError.Text = "Error Getting Fields: Unable to get Resource Pool URL";
                lblGeneralError.Visible = true;
            }
            return;
ExecuteProcess_Error:
            lblGeneralError.Text = LMR_IF.LastError;
            lblGeneralError.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddl = (DropDownList)gvr.Cells[1].FindControl("ddlSPField");
                    if (ddl.SelectedValue != "")
                    {
                        sb.Append("|");
                        sb.Append(gvr.Cells[2].Text);
                        sb.Append(",");
                        sb.Append(ddl.SelectedValue);
                        sb.Append(",");
                        sb.Append(1);

                        DataRow dr = dt.NewRow();
                        int nID;
                        Int32.TryParse(gvr.Cells[2].Text, out nID);
                        dr["EPKID"] = nID;
                        dr["WEID"] = 0;
                        dr["WEName"] = ddl.SelectedValue;
                    }
                }
            }

            string sBaseInfo = WebAdmin.BuildBaseInfo(this.Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (LMR_IF.saveResourceFieldMappings(dba, dt) == false) goto ExecuteProcess_Error;


            StringBuilder sbSend = new StringBuilder("<Settings Key=\"EPK\">");
            sbSend.Append("<ResourceFields>");
            sbSend.Append(sb.ToString().Trim('|'));
            sbSend.Append("</ResourceFields>");
            sbSend.Append("</Settings>");

            XmlNode ndSettings = null;
            if (ExecuteProcess("SetSettings", sbSend.ToString(), out ndSettings) == false) goto ExecuteProcess_Error;

            if (ndSettings.Attributes["Status"].Value == "0")
            {
                //Response.Redirect("spresourcefieldmapping.aspx");
                string url = Request.UrlReferrer.OriginalString;
                Response.Redirect(url);
            }
            else
            {
                lblGeneralError.Text = "Error Mapping Fields: " + ndSettings.InnerText;
                lblGeneralError.Visible = true;
            }
            return;
ExecuteProcess_Error:
            lblGeneralError.Text = LMR_IF.LastError;
            lblGeneralError.Visible = true;
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("adminpages.aspx");
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.Cells[1].FindControl("ddlSPField");
                ddl.DataSource = dtFields.DefaultView;
                ddl.DataTextField = "displayname";
                ddl.DataValueField = "internalname";
                ddl.DataBind();

                string sField = ((DataRowView)e.Row.DataItem).Row["spField"].ToString();
                if (sField != "")
                {
                    ddl.SelectedValue = sField;
                }
            }
        }
    }
}