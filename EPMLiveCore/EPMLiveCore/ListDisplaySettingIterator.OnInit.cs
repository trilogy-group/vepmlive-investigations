using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class ListDisplaySettingIterator
    {
        protected override void OnInit(EventArgs e)
        {
            var siteid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var site = new SPSite(siteid))
                {
                    if (site.Features[new Guid(FeatureId1)] != null ||
                        site.WebApplication.Features[new Guid(FeatureId2)] != null)
                    {
                        isFeatureActivated = true;
                    }
                }
            });

            base.OnInit(e);

            if (isFeatureActivated)
            {
                OnInit();

                if (mode == SPControlMode.New ||
                    (list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrWhiteSpace(Page.Request[ModeParam]) &&
                    Page.Request[ModeParam] == Upload && mode == SPControlMode.Edit))
                {
                    if (!string.IsNullOrWhiteSpace(Page.Request[LookupFieldParam]))
                    {
                        lookupField = Page.Request[LookupFieldParam];
                    }

                    if (!string.IsNullOrWhiteSpace(Page.Request[LookupValueParam]))
                    {
                        lookupValue = Page.Request[LookupValueParam];
                    }
                }
            }
        }

        private void OnInit()
        {
            try
            {
                InitFields();

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (var rsite = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (var web = rsite.OpenWeb(SPContext.Current.Web.ID))
                        {
                            arrwpFields = ReflectionMethods.GetWorkPlannerStatusFields(web, list.Title);
                        }
                    }
                    try
                    {
                        if (list.Title == Resources)
                        {
                            isResList = true;
                            var site1 = SPContext.Current.Site;
                            if (site1.WebApplication.Features[new Guid(FeatureId2)] != null)
                            {
                                InitFeature2();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                });


                if (SPContext.Current.FormContext.FormMode != SPControlMode.Invalid)
                {
                    mode = SPContext.Current.FormContext.FormMode;
                }
                else
                {
                    try
                    {
                        mode = (SPControlMode)int.Parse(Page.Request[Mode]);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void InitFields()
        {
            try
            {
                list = SPContext.Current.List;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            var gridSettings = new GridGanttSettings(list);

            DisplayFormRedirect = gridSettings.DisplayFormRedirect;

            if (DisplayFormRedirect && ControlMode == SPControlMode.New && Page.Request[IsDialogParameter] != ModifiedType)
            {
                SPContext.Current.FormContext.OnSaveHandler += CustomHandler;
            }
            else if (!string.IsNullOrWhiteSpace(Page.Request[SourceParam]))
            {
                RedirectUrl = Page.Request[SourceParam];
                SPContext.Current.FormContext.OnSaveHandler += HandleNewItemRecent;
            }
            else
            {
                SPContext.Current.FormContext.OnSaveHandler += HandleNewItemRecent;
            }

            if (gridSettings.DisplaySettings != string.Empty)
            {
                fieldProperties = ListDisplayUtils.ConvertFromString(gridSettings.DisplaySettings);
            }

            try
            {
                isWorkList = gridSettings.EnableWorkList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            if (isWorkList)
            {
                SPPageContentManager.RegisterClientScriptInclude(
                    this,
                    GetType(),
                    "WorkEngineStatusing",
                    "/_layouts/15/epmlive/WorkEngineStatusing.js");
            }


            if (list == null)
            {
                list = SPContext.Current.Web.Lists[new Guid(Page.Request[Listid])];
            }
        }

        private void InitFeature2()
        {
            isOnline = true;

            try
            {
                SqlConnection connection = null;
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    var assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                    var thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                    var methodInfo = thisClass.GetMethod("getConnectionString");
                    var connectionString = (string)methodInfo.Invoke(null, new object[] { });

                    connection = new SqlConnection(connectionString);
                    connection.Open();
                });

                using (var command = new SqlCommand("2012SP_GetActivationInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                    command.Parameters.AddWithValue("@username", string.Empty);

                    using (var dataSet = new DataSet())
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                        }

                        try
                        {
                            ActivationType = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }
                    }

                    if (ActivationType != 3)
                    {
                        InitActivationType(connection);
                    }
                    else
                    {
                        InitOwner(connection);
                    }
                }
                connection?.Dispose();
            }
            catch (Exception ex)
            {
                max = 0;
                Trace.WriteLine(ex.ToString());
            }
        }

        private void InitActivationType(SqlConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            using (var command = new SqlCommand("2010SP_GetSiteAccountNums", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                command.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        max = reader.GetInt32(0);
                        count = reader.GetInt32(1);
                        width = (count * 100) / max;

                        barcolor = string.Empty; ;

                        if (width > 100)
                        {
                            width = 100;
                        }

                        if ((max - count) <= 1)
                        {
                            barcolor = "FF0000";
                        }
                        else if ((max - count) < 5)
                        {
                            barcolor = "FFFF00";
                        }
                        else
                        {
                            barcolor = "009900";
                        }

                        ownerusername = reader.GetString(13);
                        ownername = reader.GetString(5);

                        accountid = reader.GetGuid(2);

                        billingtype = reader.GetInt32(11);
                    }
                }
            }
        }

        private void InitOwner(SqlConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            using (var command = new SqlCommand("2010SP_GetSiteAccountNums", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                command.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ownerusername = reader.GetString(13);
                        ownername = reader.GetString(5);
                    }
                }
            }
        }
    }
}