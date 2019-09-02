using System;
using System.Linq;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SharePoint;
using EPMLiveCore;

namespace TimeSheets
{
    class SaveDataJob : BaseJob
    {
        private const int MaxTaskFailures = 32;
        private const int SaveConflictErrorCode = unchecked((int)0x81020037);

        private string NonUpdatingColumns = "Project,AssignedTo";
        SPList WorkList;

        public void execute(SPSite site, string data)
        {
            DataTable dtItems = null;
            int userid = 0;
            WebAppId = site.WebApplication.Id;
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    cn.Open();
                    try
                    {
                        WorkList = site.RootWeb.Lists["My Work"];
                    }
                    catch { }

                    XmlDocument docTimesheet = new XmlDocument();
                    docTimesheet.LoadXml(data);

                    using (SqlCommand cmd = new SqlCommand("SELECT     dbo.TSUSER.USER_ID FROM         dbo.TSUSER INNER JOIN dbo.TSTIMESHEET ON dbo.TSUSER.TSUSERUID = dbo.TSTIMESHEET.TSUSER_UID WHERE TS_UID=@tsuid", cn))
                    {
                        cmd.Parameters.AddWithValue("@tsuid", base.TSUID);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                userid = dr.GetInt32(0);
                            }
                        }
                    }

                    //bool SaveAndSubmit = false;
                    //try
                    //{
                    //    SaveAndSubmit = bool.Parse(docTimesheet.FirstChild.Attributes["SaveAndSubmit"].Value);
                    //}
                    //catch { }

                    bool liveHours = false;

                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSLiveHours"), out liveHours);

                    if (userid != 0)
                    {
                        SPUser user = TimesheetAPI.GetUser(site.RootWeb, userid.ToString());

                        if (user.ID != userid)
                        {
                            bErrors = true;
                            sErrors = "You do not have access to edit that timesheet.";
                        }
                        else
                        {
                            using (SqlCommand cmd1 = new SqlCommand("update TSQUEUE set percentcomplete=1 where TSQUEUE_ID=@QueueUid", cn))
                            {
                                cmd1.Parameters.AddWithValue("@queueuid", QueueUid);
                                cmd1.ExecuteNonQuery();
                            }

                            TimesheetSettings settings = new TimesheetSettings(site.RootWeb);

                            DataSet dsItems = new DataSet();

                            SPUser editUser = site.RootWeb.AllUsers.GetByID(base.userid);

                            using (var cache = SaveDataJobExecuteCache.InitializeCache(site))
                            {
                                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM TSITEM WHERE TS_UID=@tsuid", cn))
                                {
                                    cmd2.Parameters.AddWithValue("@tsuid", base.TSUID);
                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd2))
                                    {
                                        da.Fill(dsItems);
                                        dtItems = dsItems.Tables[0];

                                        XmlNodeList ndItems = docTimesheet.FirstChild.SelectNodes("Item");

                                        float percent = 0;
                                        float count = 0;
                                        float total = ndItems.Count;

                                        using (SqlCommand cmd3 = new SqlCommand("update TSQUEUE set percentcomplete=2 where TSQUEUE_ID=@QueueUid",
                                            cn))
                                        {
                                            cmd3.Parameters.AddWithValue("@queueuid", QueueUid);
                                            cmd3.ExecuteNonQuery();
                                        }

                                        string preloadErrors;
                                        var preloadHasErrors =
                                            cache.PreloadListItems(ndItems.Cast<XmlNode>().Select(i => new SaveDataJobExecuteCache.ListItemInfo
                                            {
                                                WebId = iGetAttribute(i, "WebID"),
                                                ListId = iGetAttribute(i, "ListID"),
                                                ListItemId = iGetAttribute(i, "ItemID")
                                            }), out preloadErrors);
                                        if (preloadHasErrors)
                                        {
                                            bErrors = true;
                                            sErrors += preloadErrors;
                                        }

                                        foreach (XmlNode ndItem in ndItems)
                                        {
                                            string worktype = "";

                                            try
                                            {
                                                worktype = ndItem.Attributes["WorkTypeField"].Value;
                                            }
                                            catch
                                            {
                                            }

                                            ProcessItemRow(ndItem, dtItems, cn, site, settings, liveHours, worktype == settings.NonWorkList);

                                            count++;
                                            float pct = count / total * 98;

                                            if (pct >= percent + 10)
                                            {
                                                using (SqlCommand cmd4 =
                                                    new SqlCommand("update TSQUEUE set percentcomplete=@pct where TSQUEUE_ID=@QueueUid", cn))
                                                {
                                                    cmd4.Parameters.AddWithValue("@queueuid", QueueUid);
                                                    cmd4.Parameters.AddWithValue("@pct", pct);
                                                    cmd4.ExecuteNonQuery();
                                                }

                                                percent = pct;
                                            }
                                        }
                                    }
                                }

                                if (liveHours)
                                {
                                    sErrors += processProjectWork(cn, TSUID.ToString(), site, true, false);
                                }
                            }
                        }
                    }
                    else
                    {
                        bErrors = true;
                        sErrors = "Timesheet does not exist";
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors = "Error: " + ex.ToString();
                }
                finally
                {
                    if (dtItems != null)
                        dtItems.Dispose();
                    if (site != null)
                        site.Dispose();
                    data = null;
                }
            }
        }

        private void ProcessItemRow(XmlNode ndRow, DataTable dtItems, SqlConnection cn, SPSite site, TimesheetSettings settings, bool liveHours, bool bSkipSP)
        {
            string id = iGetAttribute(ndRow, "UID");
            if (id != "")
            {
                DataRow[] drItem = dtItems.Select("TS_ITEM_UID='" + id + "'");

                try
                {
                    string webid = iGetAttribute(ndRow, "WebID");
                    string listid = iGetAttribute(ndRow, "ListID");
                    string itemid = iGetAttribute(ndRow, "ItemID");

                    string itemtypeid = iGetAttribute(ndRow, "ItemTypeID");

                    if (itemtypeid == "")
                        itemtypeid = "1";

                    if (webid != "")
                    {
                        if (listid != "")
                        {
                            if (itemid != "")
                            {
                                try
                                {
                                    var web = SaveDataJobExecuteCache.Cache.GetWeb(webid);
                                    SPListItem li = null;

                                    var list = web.Lists[new Guid(listid)];

                                    var failures = 0;
                                    while (true)
                                    {
                                    try
                                    {
                                        try
                                        {
                                                li = SaveDataJobExecuteCache.Cache.GetListItem(web.ServerRelativeUrl, list.ID, int.Parse(itemid), refresh: failures > 0);
                                        }
                                        catch
                                        {
                                        }

                                        if (li != null)
                                        {
                                            int projectid = 0;
                                            string project = "";
                                            string projectlist = "";
                                            try
                                            {
                                                SPFieldLookupValue lv =
                                                    new SPFieldLookupValue(li[list.Fields.GetFieldByInternalName("Project").Id].ToString());
                                                projectid = lv.LookupId;
                                                project = lv.LookupValue;
                                            }
                                            catch
                                            {
                                            }

                                            if (liveHours)
                                            {
                                                if (!processLiveHours(li, list.ID))
                                                {
                                                    return;
                                                }

                                                if (li.Fields.ContainsFieldWithInternalName("PercentComplete") &&
                                                    li.Fields.ContainsFieldWithInternalName("Status"))
                                                {
                                                    SPField percentCompleteField = li.Fields.GetFieldByInternalName("PercentComplete");
                                                    SPField statusField = li.Fields.GetFieldByInternalName("Status");
                                                    if (percentCompleteField != null && statusField != null)
                                                    {
                                                        Double value = Convert.ToDouble(li[percentCompleteField.InternalName]);
                                                        if (value == 0)
                                                        {
                                                            li[statusField.InternalName] = "Not Started";
                                                        }
                                                        else if (value > 0 & value < 1)
                                                        {
                                                            li[statusField.InternalName] = "In Progress";
                                                        }
                                                        else if (value == 1)
                                                        {
                                                            li[statusField.InternalName] = "Completed";
                                                        }
                                                    }

                                                }
                                            }

                                                SPSecurity.RunWithElevatedPrivileges(delegate { li.Update(); });
                                            }
                                        }
                                        catch (SPException ex) when (ex.HResult == SaveConflictErrorCode && ++failures < MaxTaskFailures)
                                        {
                                            continue;
                                    }
                                    catch (Exception ex)
                                    {
                                        bErrors = true;
                                        sErrors += "Item (" + id + ") Error: " + ex.ToString();
                                    }

                                        break;
                                    }
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                bErrors = true;
                                sErrors += "Item (" + id + ") missing item id";
                            }
                        }
                        else
                        {
                            bErrors = true;
                            sErrors += "Item (" + id + ") missing list id";
                        }
                    }
                    else
                    {
                        bErrors = true;
                        sErrors += "Item (" + id + ") missing web id";
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors += "Item (" + id + ") Error x2: " + ex.ToString();
                }
                finally
                {
                    if (drItem.Length > 0)
                    {
                        dtItems.Rows.Remove(drItem[0]);
                    }
                }
            }
            else
            {
                bErrors = true;
                sErrors += "Could not get id for item";
            }
        }

        private bool processLiveHours(SPListItem li, Guid listguid)
        {

            double hours = 0;
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    cn.Open();
                    if (li != null)
                    {
                        using (SqlCommand cmdHours =
                            new SqlCommand("select cast(sum(hours) as float) from vwTSHoursByTask where list_uid=@listuid and item_id = @itemid", cn))
                        {
                            cmdHours.Parameters.AddWithValue("@listuid", listguid);
                            cmdHours.Parameters.AddWithValue("@itemid", li.ID);
                            using (SqlDataReader dr1 = cmdHours.ExecuteReader())
                            {
                                if (dr1.Read())
                                    if (!dr1.IsDBNull(0))
                                        hours = dr1.GetDouble(0);
                                dr1.Close();
                            }

                            if (li["TimesheetHours"] as double? != hours)
                            {
                                li["TimesheetHours"] = hours;
                                return true;
                            }
                        }

                    }
                }
                catch
                {
                    return true; // Perform update if no TimesheetHours field, e.g. for non-work items
                }
            }

            return false;
        }

        private static string processProjectWork(SqlConnection cn, string tsuid, SPSite site, bool bApprovalScreen, bool bApproved)
        {
            string error = "";
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //using (SPSite site = new SPSite(s.ID, s.SystemAccount.UserToken))
            {
                //string sql = "SELECT * FROM vwTSItemHoursByTS where ts_uid=@ts_uid order by web_uid,list_uid";
                //if(!bApprovalScreen)
                //    sql = "SELECT * FROM vwTSItemHoursByMyTS where ts_uid=@ts_uid order by web_uid,list_uid";


                using (SqlCommand cmd = new SqlCommand("spTSGetProjectsHours", cn))
                {
                    cmd.Parameters.AddWithValue("@TSUID", tsuid);
                    cmd.Parameters.AddWithValue("@approved", bApproved);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataSet dsProjects = new DataSet();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsProjects);

                        //cmd = new SqlCommand(sql, cn);
                        //cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                        //SqlDataReader dr = cmd.ExecuteReader();

                        SPWeb iWeb = null;

                        string preloadErrors;
                        var preloadHasErrors =
                            SaveDataJobExecuteCache.Cache.PreloadListItems(dsProjects.Tables[0].Rows.Cast<DataRow>().Select(r =>
                            {
                                var listItemId = r["Project_id"].ToString();
                                return new SaveDataJobExecuteCache.ListItemInfo
                                {
                                    WebId = r["WEB_UID"].ToString(),
                                    ListId = r["PROJECT_LIST_UID"].ToString(),
                                    ListItemId = listItemId != "0" ? listItemId : null
                                };
                            }), out preloadErrors);
                        if (preloadHasErrors)
                        {
                            error += preloadErrors;
                        }

                        foreach (DataRow drProject in dsProjects.Tables[0].Rows)
                        {
                            try
                            {
                                if (drProject["PROJECT_LIST_UID"].ToString() != "")
                                {
                                    Guid lGuid = new Guid(drProject["PROJECT_LIST_UID"].ToString());

                                    iWeb = SaveDataJobExecuteCache.Cache.GetWeb(drProject["WEB_UID"].ToString());
                                    if (iWeb != null)
                                    {
                                        iWeb.AllowUnsafeUpdates = true;
                                        string project = drProject["Project_id"].ToString();
                                        if (project != "0")
                                        {
                                            try
                                            {
                                                SPSecurity.RunWithElevatedPrivileges(delegate ()
                                                {
                                                var liProject = SaveDataJobExecuteCache.Cache.GetListItem(iWeb.ServerRelativeUrl, lGuid, int.Parse(project));
                                                var newHours = drProject["Hours"].ToString();
                                                if (liProject["TimesheetHours"]?.ToString() != newHours)
                                                {
                                                    liProject["TimesheetHours"] = newHours;
                                                        liProject.Update();
                                                }
                                                });
                                            }
                                            catch(Exception ex) {
                                                Trace.TraceError("Exception Suppressed: {0}", ex);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                error += "Error: " + exception.ToString() + "<br>SharePoint User: " + iWeb?.CurrentUser.Name + "<br><br><br>";
                            }
                        }

                    }
                }
            }
            //});\
            return error;
        }

        private static string iGetAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }
    }
}