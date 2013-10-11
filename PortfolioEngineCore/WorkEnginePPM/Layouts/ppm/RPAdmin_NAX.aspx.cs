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
    public partial class RPAdmin_NAX : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.InitializePage();
            //this.Master.SetTitle("Resource Field Mappings");
        //}

        //protected void Page_LoadComplete(object sender, EventArgs e)
        //{

            if (!IsPostBack)
            {
                DBAccess dba = null;
                try
                {
                    string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                    DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                    dba = da.dba;

                    if (dba.Open() == StatusEnum.rsSuccess)
                    {
                        populateFields(dba);
                        dba.Close();
                    }
                }
                catch (PFEException pex)
                {
                    if (pex.ExceptionNumber == 9999)
                        Response.Redirect(this.Site.Url + "/_layouts/ppm/NoPerm.aspx?requesturl='" + Request.RawUrl + "'");
                    lblGeneralError.Text = "PFE Exception : " + pex.ExceptionNumber.ToString() + " - " + pex.Message;
                    lblGeneralError.Visible = true;
                }
                catch (Exception ex)
                {
                    lblGeneralError.Text = ex.Message;
                    lblGeneralError.Visible = true;
                }
                finally
                {
                    if (dba != null)
                        dba.Close();
                }
            }
        }

        private void populateFields(DBAccess dba)
        {
            CAdmin oAdmin = new CAdmin();
            if (oAdmin.GetAdminInfo(dba) != StatusEnum.rsSuccess)
                goto Exit_Function;
            ListItem li;
            DataTable dt;
            dbaRPAdmin.SelectLookupTables(dba, out dt);
            foreach (DataRow row in dt.Rows)
            {
                int id = DBAccess.ReadIntValue(row["LOOKUP_UID"]);
                string name = DBAccess.ReadStringValue(row["LOOKUP_NAME"]);
                li = new ListItem(name, id.ToString("0"));
                if (oAdmin.RPDeptCode == id)
                    li.Selected = true;
                ddlDepartments.Items.Add(li);
                li = new ListItem(name, id.ToString("0"));
                if (oAdmin.RoleCode == id)
                    li.Selected = true;
                ddlResourceRoles.Items.Add(li);
            }
            dbaCalendars.SelectCalendars(dba, out dt);
            foreach (DataRow row in dt.Rows)
            {
                int id = DBAccess.ReadIntValue(row["CB_ID"]);
                string name = DBAccess.ReadStringValue(row["CB_NAME"]);
                li = new ListItem(name, id.ToString("0"));
                if (oAdmin.PortfolioCommitmentsCalendarUID == id)
                    li.Selected = true;
                ddlCalendar.Items.Add(li);
            }

            AddItemToList(ddldisplayMode, "Hours", 0, oAdmin.PortfolioCommitmentsMode);
            AddItemToList(ddldisplayMode, "FTE", 1, oAdmin.PortfolioCommitmentsMode);
            AddItemToList(ddldisplayMode, "FTE Percent", 2, oAdmin.PortfolioCommitmentsMode);

            AddItemToList(ddlOperationMode, "Full Negotiation", 0, oAdmin.PortfolioCommitmentsOpMode);
            AddItemToList(ddlOperationMode, "No Negotiation", 1, oAdmin.PortfolioCommitmentsOpMode);

            dbaCustomFields.SelectRPTotalHoursCustomFieldCandidates(dba, out dt);
            ddlTotalHours.Items.Add(new ListItem("[None]", "0"));
            foreach (DataRow row in dt.Rows)
            {
                int id = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                string name = DBAccess.ReadStringValue(row["FA_NAME"]);
                li = new ListItem(name, id.ToString("0"));
                if (oAdmin.ProjectResourceHoursCFID == id)
                    li.Selected = true;
                ddlTotalHours.Items.Add(li);
            }
Exit_Function:
            if (dba.Status != StatusEnum.rsSuccess)
            {
                lblGeneralError.Text = "Status Error " + ((int) dba.Status).ToString() + " : " + dba.StatusText;
                lblGeneralError.Visible = true;
            }
        }

        private static void AddItemToList(DropDownList ddl, string name, int id, int selectedId)
        {
            ListItem li = new ListItem(name, id.ToString("0"));
            if (selectedId == id)
                li.Selected = true;
            ddl.Items.Add(li);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sBaseInfo = WebAdmin.BuildBaseInfo(this.Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            dba.Open();

            // need to recalculate availabilities if the RP Calendar has changed so grab the old one before update
            int nOldRPCalendar = dbaRPAdmin.GetRPCalendar(dba);
            
            int deptuid = Int32.Parse(ddlDepartments.SelectedValue);
            int roleuid =  Int32.Parse(this.ddlResourceRoles.SelectedValue);
            int caluid =  Int32.Parse(this.ddlCalendar.SelectedValue);
            int mode = Int32.Parse(this.ddldisplayMode.SelectedValue);
            int opmode = Int32.Parse(this.ddlOperationMode.SelectedValue); 
            int hoursuid = Int32.Parse(this.ddlTotalHours.SelectedValue);
            dbaRPAdmin.UpdateRPAdminInfo(dba, deptuid, roleuid, caluid, mode, opmode, hoursuid);

            if (nOldRPCalendar != caluid)
            {
                // this is useful for test
                //AdminFunctions.CalcRPAllAvailabilities(dba);
                
                // use Job Server
                CStruct xQueue;
                xQueue = new CStruct();
                xQueue.Initialize("Queue");
                xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcCalcAvailability);
                xQueue.CreateString("Context", "Edit Calendar");
                xQueue.CreateString("Comment", "Calculate Availability");
                xQueue.CreateString("Data", "No Context Data");
                AdminFunctions.SubmitJobRequest(dba, dba.UserWResID, xQueue.XML());
            }
            dba.Close();
        }
    }
}