using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace EPMLiveCore.Jobs
{
    public class Integration : API.BaseJob
    {

        public void execute(SPSite site, SPWeb web, string data)
        {

            try
            {
                Guid intlistid = new Guid(base.key);

                API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(site.ID, web.ID);
                Hashtable hshParms = new Hashtable();
                hshParms.Add("intlistid", intlistid);
                DateTime dtStarted = DateTime.Now;

                DataSet DS = core.GetDataSet("SELECT * FROM INT_LISTS where INT_LIST_ID=@intlistid", hshParms);
                DataRow drIntegration = DS.Tables[0].Rows[0];
                Hashtable hshProperties = null;
                DataSet dsColumns = null;
                DataTable dtCols = null;
                DataTable dtItem = null;
                DataSet dsUserFields = null;
                DataTable dtUserFields = null;
                Hashtable hshUserMap = null;
                DataTable dtRet = null;
                DataSet dsItem = null;
                try
                {
                    hshProperties = core.GetProperties(intlistid);

                    dsColumns = core.GetDataSet("SELECT * FROM INT_COLUMNS where INT_LIST_ID=@intlistid", hshParms);
                    dtCols = dsColumns.Tables[0];
                    
                    dtItem = new DataTable();
                    dtItem.Columns.Add("ID");
                    foreach (DataRow drCol in dtCols.Rows)
                    {
                        dtItem.Columns.Add(drCol["IntegrationColumn"].ToString());
                    }

                    DateTime dtLastSynch = new DateTime(1900, 1, 1);

                    try
                    {
                        dtLastSynch = DateTime.Parse(drIntegration["LASTSYNCH"].ToString());
                    }
                    catch { }

                    if (drIntegration["TIMEINCOMING"].ToString() == "True")
                    {

                        dtItem = core.PullData(dtItem, intlistid, new Guid(drIntegration["LIST_ID"].ToString()), dtLastSynch);

                        base.totalCount = dtItem.Rows.Count + 1;

                        int count = 0;

                        bool allowAdd = false;

                        try
                        {
                            allowAdd = bool.Parse(hshProperties["AllowAddList"].ToString());
                        }
                        catch { }

                        SPList list = web.Lists[new Guid(drIntegration["LIST_ID"].ToString())];

                        GridGanttSettings settings = new GridGanttSettings(list);

                        bool bBuildTeamSec = settings.BuildTeamSecurity;

                        dsUserFields = core.GetDataSet(list, "", intlistid);
                        dtUserFields = dsUserFields.Tables[1];
                        if (dtUserFields.Select("Type='1'").Length > 0 || bBuildTeamSec)
                        {
                            hshUserMap = core.GetUserMap(drIntegration["INT_LIST_ID"].ToString(), true);
                        }

                        bool bSPCol = false;
                        try
                        {
                            if (hshProperties["SPColumn"].ToString() != "")
                                bSPCol = true;
                        }
                        catch { }

                        dtRet = new DataTable();
                        dtRet.Columns.Add("ID");

                        if (bSPCol)
                            dtRet.Columns.Add(hshProperties["SPColumn"].ToString());

                        foreach (DataRow dr in dtItem.Rows)
                        {
                            int spid = core.iProcessItemRow(dr, list, dtCols, hshProperties, drIntegration["INT_COLID"].ToString(), intlistid, new Guid(drIntegration["MODULE_ID"].ToString()), allowAdd, dtUserFields, hshUserMap);

                            try
                            {
                                if (spid != 0 && bSPCol)
                                {
                                    dtRet.Rows.Add(new string[] { dr["ID"].ToString(), spid.ToString() });
                                }
                            }
                            catch { }

                            base.updateProgress(count++);
                        }

                        if (bSPCol)
                            core.PostIntegrationUpdateToExternal(dtRet, intlistid, list.ID);

                        core.LogMessage(intlistid.ToString(), drIntegration["LIST_ID"].ToString(), "Timer: Imported " + dtItem.Rows.Count + " Items", 1);
                    }
                    else if (drIntegration["TIMEOUTGOING"].ToString() == "True")
                    {

                        SPList list = web.Lists[new Guid(drIntegration["LIST_ID"].ToString())];
                        core.OpenConnection();
                        dsItem = core.GetDataSet(list, "", intlistid);

                        SPQuery query = new SPQuery();
                        query.Query = "<Where><Gt><FieldRef Name=\"Modified\" /><Value IncludeTimeValue=\"TRUE\" Type=\"DateTime\">" + Microsoft.SharePoint.Utilities.SPUtility.CreateISO8601DateTimeFromSystemDateTime(dtLastSynch) + "</Value></Gt></Where>";
                        SPListItemCollection lic = list.GetItems(query);

                        base.totalCount = lic.Count * 2;
                        int count = 0;
                        foreach (SPListItem li in lic)
                        {
                            core.ProcessItem(dsItem, li, list);
                            updateProgress(count++);
                        }

                        core.PostIntegration(dsItem.Tables[0].Copy(), dsItem.Tables[1], dsItem.Tables[2], list);

                        core.LogMessage(intlistid.ToString(), drIntegration["LIST_ID"].ToString(), "Timer: Exported " + lic.Count + " Items", 1);

                    }

                    hshParms.Add("lastsynch", dtStarted.ToString());
                    core.ExecuteQuery("UPDATE INT_LISTS set lastsynch=@lastsynch where INT_LIST_ID=@intlistid", hshParms, true);

                    core.CloseConnection(true);
                }
                catch (Exception ex)
                {
                    core.LogMessage(intlistid.ToString(), drIntegration["LIST_ID"].ToString(), "Timer: " + ex.Message, 3);
                    sErrors += "General Error: " + ex.Message;
                    bErrors = true;
                }
                finally
                {
                    hshParms = null;
                    hshUserMap = null;
                    hshProperties = null;
                    if (DS != null)
                        DS.Dispose();
                    if (dsColumns != null)
                        dsColumns.Dispose();
                    if (dtCols != null)
                        dtCols.Dispose();
                    if (dtItem != null)
                        dtItem.Dispose();
                    if (dsUserFields != null)
                        dsUserFields.Dispose();
                    if (dtUserFields != null)
                        dtUserFields.Dispose();
                    if (dtRet != null)
                        dtRet.Dispose();
                    if (dsItem != null)
                        dsItem.Dispose();
                }

            }
            catch (Exception ex)
            {
                sErrors += "General Error: " + ex.Message;
                bErrors = true;
            }
            finally
            {
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }

        }


    }
}
