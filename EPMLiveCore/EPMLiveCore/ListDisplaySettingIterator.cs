using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Linq;
using System.Globalization;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace EPMLiveCore
{
	public class ListDisplaySettingIterator : ListFieldIterator
	{
	    private const string FeatureId1 = "e97da3cd-4c42-44cd-ba51-2bfbb2c397cb";
	    private const string FeatureId2 = "19e6ae14-9e68-44fa-9a08-c1c4514bf12e";
	    private const string ModeParam = "Mode";
	    private const string LookupFieldParam = "LookupField";
	    private const string LookupValueParam = "LookupValue";
	    private const string SourceParam = "Source";
	    private Dictionary<string, Dictionary<string, string>> fieldProperties = null;
		private SPList list = null;
		private SPControlMode mode = 0;
		private SortedList arrwpFields = new SortedList();
		private bool isResList = false;
		private bool isOnline = false;
		private string lookupField = string.Empty;
		private string lookupValue = string.Empty;

		#region ResourceList
		List<string> userPanelItems = new List<string>() { "FirstName", "LastName", "Email", "Generic", "Title", "SharePointAccount" };
		List<string> permissionPanelItems = new List<string>() { "Permissions", "ResourceLevel", "Approved", "TimesheetAdministrator", "Active", "Disable" };
		StringBuilder userPanelSb = new StringBuilder();
		HtmlTextWriter userPanel;
		StringBuilder profilePanelSb = new StringBuilder();
		HtmlTextWriter profilePanel;
		StringBuilder permissionPanelSb = new StringBuilder();
		HtmlTextWriter permissionPanel;
		#endregion

		private Dictionary<string, string> dControls = new Dictionary<string, string>();

		int max = 0;
		int count = 0;
		float width = 0;
		string barcolor = "";
		string ownerusername = "";
		string ownername = "";
		Guid accountid;
		bool isWorkList = true;
		int billingtype = 0;
		int userpanelRequiredCount = 0;
		int permissionPanelRequiredCount = 0;
		int profilepanelRequiredCount = 0;

		GenericEntityEditor picker;

		private bool isFeatureActivated = false;

		private bool DisplayFormRedirect = false;

		private bool bUseTeam = false;

		private int ActivationType = 0;

		private void FindSaveButtons(Control Parent, ref ArrayList Controls)
		{
			foreach (Control child in Parent.Controls)
			{
				if (child.GetType().ToString() == "Microsoft.SharePoint.WebControls.SaveButton")
				{
					Controls.Add(child);
				}

				FindSaveButtons(child, ref Controls);
			}
		}

		protected void CustomHandler(object sender, EventArgs e)
		{
			if (SaveButton.SaveItem(SPContext.Current, this.list.BaseTemplate == SPListTemplateType.DocumentLibrary, ""))
			{
				string sUrl = (List.ParentWeb.ServerRelativeUrl == "/") ? "" : List.ParentWeb.ServerRelativeUrl;

				RedirectUrl = String.Concat(sUrl, "/", List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url, @"?ID=", ListItem.ID, @"&Source=", ListItem.ParentList.DefaultViewUrl);

				ProcessNewItemRecent(ListItem);
			}
			else
			{
				//We cannot check validations prior to SaveButton.SaveItem event - Because validation setting is set on List level!
				//this means SaveItem is unsuccessful - Let's check for validation settings for New and Edit form mode
				//If item won't saved due to some other reason then that thing is already handled in respective ItemAdding/ItemUpdating event and throws proper exception on screen.
				//Here, we have handled this special case for List Validation Settings because this page is inherit from ListFieldIterator class.
				if (mode == SPControlMode.New || mode == SPControlMode.Edit)
				{
					if (!string.IsNullOrEmpty(list.ValidationFormula))
					{
						HtmlGenericControl divValidationErrorMessage = new HtmlGenericControl("div");
						divValidationErrorMessage.InnerHtml = "<span id='Error_WPQ2ClientFormPlaceholder' class='ms-formvalidation ms-csrformvalidation'>" + list.ValidationMessage + "</span>";
						this.Controls.Add(divValidationErrorMessage);
					}
				}
			}
		}

		protected void HandleNewItemRecent(object sender, EventArgs e)
		{
			if (SaveButton.SaveItem(SPContext.Current, this.list.BaseTemplate == SPListTemplateType.DocumentLibrary, ""))
			{
				ProcessNewItemRecent(SPContext.Current.ListItem);

			}
			else
			{
				//We cannot check validations prior to SaveButton.SaveItem event - Because validation setting is set on List level!
				//this means SaveItem is unsuccessful - Let's check for validation settings for New and Edit form mode
				//If item won't saved due to some other reason then that thing is already handled in respective ItemAdding/ItemUpdating event and throws proper exception on screen.
				//Here, we have handled this special case for List Validation Settings because this page is inherit from ListFieldIterator class.
				if (mode == SPControlMode.New || mode == SPControlMode.Edit)
				{
					if (!string.IsNullOrEmpty(list.ValidationFormula))
					{
						HtmlGenericControl divValidationErrorMessage = new HtmlGenericControl("div");
						divValidationErrorMessage.InnerHtml = "<span id='Error_WPQ2ClientFormPlaceholder' class='ms-formvalidation ms-csrformvalidation'>" + list.ValidationMessage + "</span>";
						this.Controls.Add(divValidationErrorMessage);
					}
				}
			}
		}

		protected void ProcessNewItemRecent(SPListItem i)
		{
			try
			{
				var queryCreateRecentItem =
					@"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @")
                    BEGIN
                        UPDATE FRF SET [F_Date] = GETDATE() 
                        WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @" 
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @"
                    END
                    ELSE
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Date])
                        VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.Recent) + @", GETDATE())
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @"
                    END

                    IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 2) > 20)
                    BEGIN
	                    DELETE FROM FRF 
	                    WHERE [Type] = 2 
	                    AND [F_Date] NOT IN (SELECT TOP 20 [F_Date] FROM FRF WHERE [Type] = 2 ORDER BY [F_Date] DESC)
                    END
                    ";

				var qParams = new Dictionary<string, object>
				{
					{"@siteid", i.ParentList.ParentWeb.Site.ID},
					{"@webid", i.ParentList.ParentWeb.ID},
					{"@listid", i.ParentList.ID},
					{"@itemid", i.ID},
					{"@userid", i.ParentList.ParentWeb.CurrentUser.ID},
					{"@icon", new GridGanttSettings(i.ParentList).ListIcon},
					{"@title", i.ParentList.Title.Contains("Template Gallery") ? new SPFieldUrlValue(i["URL"].ToString()).Description : i.Title},
				};

				var exec = new QueryExecutor(SPContext.Current.Web);
				exec.ExecuteEpmLiveQuery(queryCreateRecentItem, qParams);
				ClearCache();
			}
			catch { }
		}

		private static void ClearCache()
		{
			try
			{
				try
				{
					new RecentItemsLinkProvider(SPContext.Current.Site.ID, SPContext.Current.Web.ID, SPContext.Current.Web.CurrentUser.LoginName).ClearCache();
				}
				catch
				{
					CacheStore.Current.RemoveCategory(new CacheStoreCategory().Navigation);
				}
			}
			catch { }
		}
        
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
                Init();

                if (mode == SPControlMode.New || 
                    (list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrWhiteSpace(Page.Request[ModeParam]) && 
                    Page.Request[ModeParam] == "Upload" && mode == SPControlMode.Edit))
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

        private void Init()
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
                        if (list.Title == "Resources")
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
                        mode = (SPControlMode)int.Parse(Page.Request["mode"]);
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

            if (DisplayFormRedirect && ControlMode == SPControlMode.New && Page.Request["IsDlg"] != "1")
            {
                SPContext.Current.FormContext.OnSaveHandler += new EventHandler(CustomHandler);
            }
            else if (!string.IsNullOrWhiteSpace(Page.Request[SourceParam]))
            {
                RedirectUrl = Page.Request[SourceParam];
                SPContext.Current.FormContext.OnSaveHandler += new EventHandler(HandleNewItemRecent);
            }
            else
            {
                SPContext.Current.FormContext.OnSaveHandler += new EventHandler(HandleNewItemRecent);
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
                list = SPContext.Current.Web.Lists[new Guid(Page.Request["ListId"])];
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
        
        public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
		{
			string sRelUrl = ((base.Web.ServerRelativeUrl == "/") ? "" : base.Web.ServerRelativeUrl);

			if (isResList)
			{
				writer.WriteLine(" <script>$(document).ready(function () {$(\".imgArrow\").addClass(\"hideImage\"); $(\".upheader\").click(function () {$header = $(this);$arrowImage = $header.find(\".imgArrow\");$downArrowImage = $header.find(\".imgDownArrow\");$content = $header.next();");
				writer.Write("$content.slideToggle(100,function (){  if ($arrowImage.hasClass(\"hideImage\")) {$downArrowImage.addClass(\"hideImage\");$arrowImage.removeClass(\"hideImage\");$(\"#onetIDListForm\").attr(\"style\",\"width:95%\");}else {$arrowImage.addClass(\"hideImage\");$downArrowImage.removeClass(\"hideImage\");}});});});</script>");

				userPanel = new HtmlTextWriter(new System.IO.StringWriter(userPanelSb, System.Globalization.CultureInfo.InvariantCulture));
				userPanel.Write(CreateHtmlPanelText("User"));

				profilePanel = new HtmlTextWriter(new System.IO.StringWriter(profilePanelSb, System.Globalization.CultureInfo.InvariantCulture));
				profilePanel.Write(CreateHtmlPanelText("Profile"));

				if (CoreFunctions.DoesCurrentUserHaveFullControl(Web))
				{
					permissionPanel = new HtmlTextWriter(new System.IO.StringWriter(permissionPanelSb, System.Globalization.CultureInfo.InvariantCulture));
					permissionPanel.Write(CreateHtmlPanelText("Permissions"));
				}
			}

			if (isFeatureActivated)
			{
                
                bool outofusers = false;
                #region Display
                if (base.ControlMode == SPControlMode.Display)
				{
					string editURL = base.List.Forms[PAGETYPE.PAGE_EDITFORM].Url;
					editURL = ((base.Web.ServerRelativeUrl == "/") ? "" : base.Web.ServerRelativeUrl) + "/" + editURL;
					string extraParams = "";

					if (!string.IsNullOrEmpty(Page.Request["IsDlg"]))
					{
						extraParams += "&isDlg=" + Page.Request["IsDlg"];
					}

					writer.WriteLine("<script language=\"javascript\">");
					//writer.WriteLine("WETitle = \"" + base.ListItem.Title.Replace("\"", "&quot;") + "\";");
					writer.WriteLine("WETitle = \"" + HttpUtility.JavaScriptStringEncode(base.ListItem.Title) + "\";");
					writer.WriteLine("WEWebUrl = '" + sRelUrl + "';");
					writer.WriteLine("WEWebId = '" + Web.ID + "';");
					writer.WriteLine("WEEditForm = '" + editURL + "';");
					writer.WriteLine("WEExtraParams = '" + extraParams.Trim('&') + "';");
					writer.WriteLine("WEListId = '" + base.ListId + "';");
					writer.WriteLine("WEItemId = '" + base.ItemId + "';");
					writer.WriteLine("WESource = '" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()).Replace("+", "%20") + "';");
					writer.WriteLine("WEUseTeam = " + bUseTeam.ToString().ToLower() + ";");
					writer.WriteLine("WEDLG = '" + Page.Request["IsDlg"] + "';");
					writer.WriteLine("</script>");
				}
                #endregion
                
                #region Online

                bool disablerequests = false;
				try
				{
					disablerequests = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "OnlineDisableResReq"));
				}
				catch { }
				bool isadmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
				if (isOnline && isResList)
				{
					if (!isadmin && !disablerequests)
					{
						writer.Write(@"<tr><td colspan='2'>
                        <table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" class=""tblResourceWarningMessages"">
                        <tr>
                        <td>Once you fill out this form the resource will be requested and must be approved by an administrator before the user can login.</td>
                        </tr>
                        </table><br>
                        </td></tr>");
					}
					else
					{
                        #region ActivationType
                        if (ActivationType != 3)
						{
							if (count >= max && max != -1 && billingtype != 2)
							{
								if (EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower() == ownerusername.ToLower())
								{
									writer.Write(@"<tr><td colspan='2'><table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" class=""tblResourceWarningMessages"">
                                    <tr>
                                    <td>You cannot create a new user that has login access because your account limit of " + max + @" has been reached.  Purchasing additional accounts is easy, just click <a href=""" + ((SPContext.Current.Web.ServerRelativeUrl == "/") ? "" : SPContext.Current.Web.ServerRelativeUrl) + @"/_layouts/epmlive/purchase.aspx?accountid=" + accountid + @""">Purchase Accounts</a>.</tr>
                                    </table><br></td></tr>");
								}
								else
								{
									writer.Write(@"<tr><td colspan='2'>
                                    <table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" class=""tblResourceWarningMessages"">
                                    <tr>
                                    <td>The account limit of " + max + @" has been reached.  Until the Account Owner (" + ownername + @")
                                    purchases additional accounts, creating user accounts with login access
                                    will be in the form of ""requests"", which you can approve once the owner purchases additional accounts.</td>
                                    </tr>
                                    </table><br>
                                    </td></tr>");
								}

							}
							else
							{
								if (max != -1 && billingtype != 2)
								{
									writer.Write("<tr><td colspan='2'><div id=\"divuCount\">User usage: " + count + " of " + max + "</div></td></tr>");
								}
							}
						}
                        #endregion
                    }

                }
				#endregion


				#region processControls

				foreach (System.Web.UI.Control tc in base.Controls)
				{
					try
					{
                        SPField field = GetFieldLabel(tc, 1, 0, 1).Field; // ((FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field;


                        if (field.Required == true)
						{
							if (userPanelItems.Contains(field.InternalName))
							{
								userpanelRequiredCount++;
							}
							else if (permissionPanelItems.Contains(field.InternalName))
							{
								permissionPanelRequiredCount++;
							}
							else
							{
								profilepanelRequiredCount++;
							}
						}
                        #region InternalName
                        Control parentControl = tc.Controls[1].Controls[0];
						if (field.InternalName == "Due")
						{
							AddControlsToWriter(tc.Controls[0], writer, field.InternalName);
							for (int i = 0; i < parentControl.Controls.Count; i++)
							{
								//if (parentControl.Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FormField")
                                if (GetControlType(parentControl, i) == "Microsoft.SharePoint.WebControls.FormField")
								{
									writer.Write(CoreFunctions.GetDueField(base.ListItem));
								}
								else
									AddControlsToWriter(parentControl.Controls[i], writer, field.InternalName);
							}
							AddControlsToWriter(tc.Controls[2], writer, field.InternalName);
						}
						else if (field.InternalName == "DaysOverdue")
						{
							AddControlsToWriter(tc.Controls[0], writer, field.InternalName);
							for (int i = 0; i < parentControl.Controls.Count; i++)
							{
                                //if (parentControl.Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FormField")
                                if (GetControlType(parentControl, i) == "Microsoft.SharePoint.WebControls.FormField")
                                {
									writer.Write(CoreFunctions.GetDaysOverdueField(base.ListItem));
								}
								else
									AddControlsToWriter(parentControl.Controls[i], writer, field.InternalName);
							}
							AddControlsToWriter(tc.Controls[2], writer, field.InternalName);
						}
						else if (field.InternalName == "ScheduleStatus")
						{
							AddControlsToWriter(tc.Controls[0], writer, field.InternalName);
							for (int i = 0; i < parentControl.Controls.Count; i++)
							{
                                //if (parentControl.Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FormField")
                                if (GetControlType(parentControl, i) == "Microsoft.SharePoint.WebControls.FormField")
                                {
									string color = CoreFunctions.GetScheduleStatusField(base.ListItem);
									if (color != "")
										writer.Write(@"<img src=""/_layouts/images/" + color + @""">");
									else
									{
                                        string val = GetFormField(parentControl, i).ItemFieldValue.ToString(); //((FormField)parentControl.Controls[i]).ItemFieldValue.ToString();

                                        string sVal = "";
										try
										{
                                            sVal = GetFieldLabel(parentControl, 1).Field.GetFieldValueAsHtml(val); //((FieldLabel)parentControl.Controls[1]).Field.GetFieldValueAsHtml(val);
                                        }
										catch { }
										if (sVal.ToLower().Contains(".gif") || sVal.ToLower().Contains(".jpg"))
											writer.Write("<img src=\"" + SPContext.Current.Web.Url + "/_layouts/images/" + sVal + "\">");
										else if (sVal == "")
											writer.Write("&nbsp;");
										else
											writer.Write(sVal);
									}
								}
								else
									AddControlsToWriter(parentControl.Controls[i], writer, field.InternalName);
							}
							AddControlsToWriter(tc.Controls[2], writer, field.InternalName);
                        }
                        #endregion
                        #region field.Type 
                        else if (field.Type == SPFieldType.Calculated)
						{
							AddControlsToWriter(tc.Controls[0], writer, field.InternalName);
							for (int i = 0; i < parentControl.Controls.Count; i++)
							{
                                //if (parentControl.Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FormField")
                                if (GetControlType(parentControl, i) == "Microsoft.SharePoint.WebControls.FormField")
                                {
                                    string val = GetFormField(parentControl, i).ItemFieldValue.ToString(); // ((FormField)parentControl.Controls[i]).ItemFieldValue.ToString();

                                    string sVal = "";
									try
									{
                                        sVal = GetFieldLabel(parentControl, 1).Field.GetFieldValueAsHtml(val); //((FieldLabel)parentControl.Controls[1]).Field.GetFieldValueAsHtml(val);
                                    }
									catch { }
									if (sVal.ToLower().Contains(".gif") || sVal.ToLower().Contains(".jpg"))
										writer.Write("<img src=\"" + SPContext.Current.Web.Url + "/_layouts/images/" + sVal + "\">");
									else if (sVal == "")
										writer.Write("&nbsp;");
									else
										writer.Write(sVal);
								}
								else
									AddControlsToWriter(parentControl.Controls[i], writer, field.InternalName);
							}

							AddControlsToWriter(tc.Controls[2], writer, field.InternalName);
						}
						else if (field.Type == SPFieldType.Lookup)
						{
							AddControlsToWriter(tc, writer, field.InternalName);
						}
                        #endregion
                        else if (arrwpFields.Contains(field.InternalName) && (bool)arrwpFields[field.InternalName])
						{
							AddControlsToWriter(tc.Controls[0], writer, field.InternalName);
							for (int i = 0; i < parentControl.Controls.Count; i++)
							{
                                //if (parentControl.Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FieldLabel")
                                if (GetControlType(parentControl, i) == "Microsoft.SharePoint.WebControls.FieldLabel")
                                {
                                    // writer.Write(((FieldLabel)parentControl.Controls[1]).Field.Title + " <font color=\"#007C17\">*</font>");
                                    writer.Write((GetFieldLabel(parentControl, 1).Field.Title + " <font color=\"#007C17\">*</font>"));
                                    // if (((FieldLabel)parentControl.Controls[1]).Field.Required)
                                    if ((GetFieldLabel(parentControl, 1).Field.Required))
                                        writer.Write(" <font class=\"ms-formvalidation\">*</font>");
								}
								else
									//parentControl.Controls[i].RenderControl(writer);
									AddControlsToWriter(parentControl.Controls[i], writer, field.InternalName);
							}
							AddControlsToWriter(tc.Controls[2], writer, field.InternalName);

						}
						else
						{

							try
							{
                                //SPField f = ((CompositeField)tc.Controls[1]).Field;
                                SPField f = GetCompositeField(tc, 1).Field;
                                string fname = f.InternalName + "_" + f.Id.ToString() + "_$" + f.TypeAsString + "Field";

								if (f.Type == SPFieldType.User)
									fname = f.InternalName + "_" + f.Id.ToString() + "_$ClientPeoplePicker";
								else if (f.TypeAsString == "ResourcePermissions" || f.TypeAsString == "ResourceLevels")
								{
									if (base.ControlMode == SPControlMode.Display)
									{
										fname = parentControl.Controls[13].ClientID;
									}
									else
									{
										fname = parentControl.Controls[9].Controls[0].Controls[0].Controls[1].ClientID;
									}
								}
								else if (f.InternalName == "Status")
									fname = f.InternalName + "_" + f.Id.ToString() + "_$DropDownChoice";

								dControls.Add(field.InternalName, fname);

								AddControlsToWriter(tc, writer, field.InternalName);
							}
							catch { }
							// tc.RenderControl(writer);
						}
					}
					catch(Exception ex)
					{
						AddControlsToWriter(tc, writer);
					}
				}
                #endregion

                if (isResList)
				{
					userPanel.Write("</table></div></div></td></tr>");
					writer.Write(userPanelSb.ToString());
					profilePanel.Write("</table></div></div></td></tr>");
					writer.Write(profilePanelSb.ToString());

					if (CoreFunctions.DoesCurrentUserHaveFullControl(Web))
					{
						permissionPanel.Write("</table></div></div></td></tr>");
						writer.Write(permissionPanelSb.ToString());
					}
				}

				#region worklist
				if (isWorkList)
				{
					string pctControl = "";
					string compControl = "";
					string statusControl = "";

					try
					{
						pctControl = dControls["PercentComplete"];
					}
					catch { }
					try
					{
						compControl = dControls["Complete"];
					}
					catch { }
					try
					{
						statusControl = dControls["Status"];
					}
					catch { }

					writer.WriteLine("<script language=\"javascript\">");
					writer.WriteLine("_spBodyOnLoadFunctionNames.push(\"InitStatusingControls('" + compControl + "', '" + pctControl + "', '" + statusControl + "')\");");
					//writer.WriteLine("AddFormEvents();");
					writer.WriteLine("</script>");
				}
				#endregion

				
				if (isResList)
				{
                    #region ResList
                    try
                    {
						writer.WriteLine("<script language=\"javascript\">");
						writer.WriteLine("function checkSpecialCharacters(objectName,object){");
						writer.WriteLine("var checkPattern = /[\\|\\\\\"\'\\/\\[\\]\\:\\<\\>\\+\\=\\,\\;\\?\\*\\@]/");
						writer.WriteLine("if(checkPattern.test(object.value)) { alert(objectName + ' cannot contain any of the following characters ' + '| \\\\ \" \\' / [ ] : < > + = , ; ? * @'); object.value = ''; setTimeout(function(){object.focus();}, 1); }");
						writer.WriteLine("}");

						writer.WriteLine("function checkSpecialCharactersForNonGeneric(objectName,object){");
						writer.WriteLine("var checkPattern = /[\\|\\\\\"\\/\\[\\]\\:\\<\\>\\+\\=\\,\\;\\?\\*\\@]/");
						writer.WriteLine("if(checkPattern.test(object.value)) { alert(objectName + ' cannot contain any of the following characters ' + '| \\\\ \" \\/ [ ] : < > + = , ; ? * @'); object.value = ''; setTimeout(function(){object.focus();}, 1); }");
						writer.WriteLine("}");

						writer.WriteLine("function setLicenseType(){");
						if (dControls.ContainsKey("ResourceLevel"))
						{
							writer.WriteLine("var id = '';");
							writer.WriteLine("if(document.getElementById('" + dControls["ResourceLevel"] + "') !== null){");
							writer.WriteLine("var tbl = document.getElementById('" + dControls["ResourceLevel"] + "');");
							writer.WriteLine("for (var rIdx = 0; rIdx < tbl.rows.length; rIdx++) {");
							writer.WriteLine("var row = tbl.rows[rIdx];");
							writer.WriteLine("for (var cIdx = 0; cIdx < row.cells.length; cIdx++) {");
							writer.WriteLine("var cell = row.cells[cIdx];");
							writer.WriteLine("for (var idx = 0; idx < cell.childNodes.length; idx++) {");
							writer.WriteLine("var child = cell.childNodes[idx];");
							writer.WriteLine("if (child.nodeName != null && child.nodeName != undefined && child.nodeName.toUpperCase() == 'INPUT') {");
							writer.WriteLine("if(child.nextSibling != null && child.nextSibling != undefined && child.nextSibling.innerHTML.toUpperCase()  == 'NO ACCESS') {");
							writer.WriteLine("id = child.id;");
							writer.WriteLine("}");
							writer.WriteLine("if(child.checked){");
							writer.WriteLine("defaultLicenseTypeId = child.id;");
							writer.WriteLine("}");
							writer.WriteLine("}");
							writer.WriteLine("}");
							writer.WriteLine("}");
							writer.WriteLine("}");
							writer.WriteLine("document.getElementById(id).checked = true;");
							writer.WriteLine("}");
						}
						writer.WriteLine("}");

						writer.WriteLine("function cleanupfields(){");
						try
						{
							if (outofusers)
							{

							}
							else
							{
								if (dControls.ContainsKey("CanLogin"))
								{
									writer.WriteLine("  try{");
									try
									{
										writer.WriteLine("      if(document.getElementById('" + dControls["CanLogin"] + "').checked){");
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["Generic"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
										}
										catch { }
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["Generic"] + "').checked = false;}catch(e){}");
										}
										catch { }
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
										}
										catch { }
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
										}
										catch { }
										writer.WriteLine("      try{document.getElementById('divRequest').parentNode.parentNode.style.display='';}catch(e){}");
										writer.WriteLine("      try{document.getElementById('divuCount').parentNode.parentNode.style.display='';}catch(e){}");
										writer.WriteLine("      }else{");
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["Generic"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
										}
										catch { }
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
										}
										catch { }
										try
										{
											writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
										}
										catch { }
										writer.WriteLine("      try{document.getElementById('divRequest').parentNode.parentNode.style.display='none';}catch(e){}");
										//writer.WriteLine("      try{document.getElementById('divuCount').parentNode.parentNode.style.display='none';}catch(e){}");
										writer.WriteLine("      }");
									}
									catch { }
									writer.WriteLine("  }catch(e){}");
								}
							}

							if (dControls.ContainsKey("Generic"))
							{
								writer.WriteLine("  if(document.getElementById('" + dControls["Generic"] + "').checked){");
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["FirstName"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
								}
								catch { }
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["LastName"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
								}
								catch { }
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["Email"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
								}
								catch { }

								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["TimesheetAdministrator"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
								}
								catch { }

								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["SharePointAccount"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
								}
								catch { }

								if (dControls.ContainsKey("FirstName"))
								{
									try
									{
										writer.WriteLine("      try{document.getElementById('" + dControls["Title"] + "').parentNode.parentNode.parentNode.style.display='';document.getElementById('" + dControls["Title"] + "').onblur = function() { checkSpecialCharacters('Display Name',document.getElementById('" + dControls["Title"] + "')); }}catch(e){}");
									}
									catch { }
								}
								if (dControls.ContainsKey("Permissions"))
								{
									try
									{
										writer.WriteLine(" try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
									}
									catch { }
								}
								try
								{
									writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
								}
								catch { }
								if (dControls.ContainsKey("CanLogin"))
								{
									try
									{
										writer.WriteLine("          try{document.getElementById('" + dControls["CanLogin"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
									}
									catch { }
								}
								writer.WriteLine("  }else{");
								writer.WriteLine("try{document.getElementById(defaultLicenseTypeId).checked = true;}catch(e){}");
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["FirstName"] + "').parentNode.parentNode.parentNode.style.display='';document.getElementById('" + dControls["FirstName"] + "').onblur = function() { checkSpecialCharactersForNonGeneric('First Name',document.getElementById('" + dControls["FirstName"] + "')); }}catch(e){}");
								}
								catch { }
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["LastName"] + "').parentNode.parentNode.parentNode.style.display='';document.getElementById('" + dControls["LastName"] + "').onblur = function() { checkSpecialCharactersForNonGeneric('Last Name',document.getElementById('" + dControls["LastName"] + "')); }}catch(e){}");
								}
								catch { }
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["Email"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
								}
								catch { }
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["TimesheetAdministrator"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
								}
								catch { }
								if (dControls.ContainsKey("FirstName"))
								{
									try
									{
										writer.WriteLine("      try{document.getElementById('" + dControls["Title"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
									}
									catch { }
								}
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["SharePointAccount"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
								}
								catch { }
								if (dControls.ContainsKey("Permissions"))
								{
									try
									{
										writer.WriteLine("try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.style.display='';}catch(e){}");
									}
									catch { }
								}
								try
								{
									writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
								}
								catch { }
								if (dControls.ContainsKey("CanLogin"))
								{
									try
									{
										writer.WriteLine("          try{document.getElementById('" + dControls["CanLogin"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
									}
									catch { }
								}
								writer.WriteLine("  }");
							}
							//to check validtion for special character at the time of edit resources
							else if ((dControls.ContainsKey("FirstName") || dControls.ContainsKey("LastName")))
							{
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["FirstName"] + "').parentNode.parentNode.parentNode.style.display='';document.getElementById('" + dControls["FirstName"] + "').onblur = function() { checkSpecialCharactersForNonGeneric('First Name',document.getElementById('" + dControls["FirstName"] + "')); }}catch(e){}");
									writer.WriteLine("      try{document.getElementById('" + dControls["LastName"] + "').parentNode.parentNode.parentNode.style.display='';document.getElementById('" + dControls["LastName"] + "').onblur = function() { checkSpecialCharactersForNonGeneric('Last Name',document.getElementById('" + dControls["LastName"] + "')); }}catch(e){}");
								}
								catch { }
							}
							else if (dControls.ContainsKey("Title"))
							{
								try
								{
									writer.WriteLine("      try{document.getElementById('" + dControls["Title"] + "').parentNode.parentNode.parentNode.style.display='';document.getElementById('" + dControls["Title"] + "').onblur = function() { checkSpecialCharacters('Display Name',document.getElementById('" + dControls["Title"] + "')); }}catch(e){}");
								}
								catch { }
							}
						}
						catch { }
						writer.WriteLine("}");

						writer.WriteLine("function InitFields(){");

						try
						{
							writer.WriteLine("document.getElementById('" + dControls["Generic"] + "').onclick = function() {cleanupfields();};");
						}
						catch { }
						try
						{
							writer.WriteLine("document.getElementById('" + dControls["CanLogin"] + "').onclick = function() {cleanupfields();};");
						}
						catch { }

						writer.WriteLine("cleanupfields();");
						writer.WriteLine("try { setLicenseType(); }catch(e){}");
						// To make default collapsed div, if there isnt any mandatory field in it
						writer.WriteLine("$(document).ready(function () {var defaultLicenseTypeId = '';var headers = $('.upheader');$.each(headers, function (i, val) {if ($(this).find('span').text() == 'Permissions' && " + permissionPanelRequiredCount + " == '0') {if('" + Convert.ToString(this.ListItem["Generic"]) + "' == 'True'){ $($(this).next()).hide(); $(this).hide(); }else{ $(this).next().slideUp();$(this).find('.imgArrow').removeClass('hideImage');$(this).find('.imgDownArrow').addClass('hideImage');}} if ($(this).find('span').text() == 'Profile' && " + profilepanelRequiredCount + " == '0' ) { $(this).next().slideUp();$(this).find('.imgArrow').removeClass('hideImage');$(this).find('.imgDownArrow').addClass('hideImage');}  });});");
						writer.WriteLine("}_spBodyOnLoadFunctionNames.push(\"InitFields\");");


						if (isOnline)
						{
							if (dControls.ContainsKey("Generic"))
							{
								writer.WriteLine("function CustomPreSaveAction(){");
								writer.WriteLine("  if(!document.getElementById('" + dControls["Generic"] + "').checked){");
								writer.WriteLine("      var f = document.getElementById('" + dControls["FirstName"] + "').value;");
								writer.WriteLine("      var l = document.getElementById('" + dControls["LastName"] + "').value;");
								writer.WriteLine("      var e = document.getElementById('" + dControls["Email"] + "').value;");
								writer.WriteLine("      if(f == \"\" || l == \"\" || e == \"\"){");
								writer.WriteLine("          alert('You must enter a First Name, Last Name, and Email');return false;");
								writer.WriteLine("      }else{return true;}");
								writer.WriteLine("  }else{");
								writer.WriteLine("      var f = document.getElementById('" + dControls["Title"] + "').value;");
								writer.WriteLine("      if(f == \"\"){");
								writer.WriteLine("          alert('You must enter a Display Name');return false;");
								writer.WriteLine("      }else{return true;}");
								writer.WriteLine("  }");
								writer.WriteLine("}");
							}
						}

						writer.WriteLine("</script>");

					}
					catch { }
                    #endregion
                }
                else
				{
					//this method is required when lookup field is disable in any list for all special character
					writer.WriteLine("<script language=\"javascript\">");
					writer.WriteLine("function CustomPreSaveAction(){");
					writer.WriteLine("var tags = document.getElementsByTagName('input');");
					writer.WriteLine("for (var i = 0; i < tags.length; i++) {");
					writer.WriteLine("var tagIdStr = tags[i].id;");
					writer.WriteLine(" if (tagIdStr.indexOf(\"Title_\") == 0 && tagIdStr.lastIndexOf(\"_$TextField\" == tagIdStr.length - \"_$TextField\".length)) {");
					writer.WriteLine("var col = tags[i];");
					writer.WriteLine("if (col != null && col.value != null && col.value != \"\") {");
					writer.WriteLine("var title = col.value.replace(/[^a-zA-Z0-9 ]/g, \"\");");
					writer.WriteLine(" if (title.length == 0) {");
					writer.WriteLine("alert(\"At least one alpha-numeric character is required for \" + col.title);");
					writer.WriteLine(" return false;");
					writer.WriteLine("}");
					writer.WriteLine(" }");
					writer.WriteLine("}");
					writer.WriteLine("}");
					writer.WriteLine(" return true;");
					writer.WriteLine("  }");
					writer.WriteLine("</script>");
				}
				
				string newLocation = "";
				bool bDialog = false;
				if (Page.Request["IsDlg"] == "1")
					bDialog = true;


				if (Page.Request["GetLastID"] == "true")
				{
					if (bDialog)
						newLocation = "close";
					else
						newLocation = Page.Request[SourceParam];
				}

                
                if (!string.IsNullOrEmpty(newLocation))
				{
                    #region newLocation
                    if (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && base.ControlMode == SPControlMode.Edit)
					{
						writer.WriteLine(@"<script>
                    
                                            $(document).ready(function() {
                                                var button = $('input[id$=SaveItem]');
                                                button.removeAttr('onclick');
                                                button.click(function() {
                                                    var elementName = $(this).attr('name');
                                                    var aspForm = $('#aspnetForm');
                    
                                                    var editPostbackUrl = '" + Web.Url + "/" + list.Forms[PAGETYPE.PAGE_EDITFORM].Url + "?id=" + this.ListItem.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Web.Url + "/_layouts/15/epmlive/getlastid.aspx?BackTo=" + System.Web.HttpUtility.UrlEncode(newLocation) + "&listid=" + list.ID + ((bDialog) ? "&isdlg=1" : "")) + @"';
                    
                                                    if (!PreSaveItem()) return false;
                                                    if (SPClientForms.ClientFormManager.SubmitClientForm('WPQ2')) return false;
                    
                                                    WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(elementName, '', true, '', editPostbackUrl, false, true));
                                                });
                                            });
                                             </script>");
					}
					else
					{
						writer.WriteLine(@"<script>

                        $(document).ready(function() {
                            var button = $('input[id$=SaveItem]');
                            button.removeAttr('onclick');
                            button.click(function() {
                                var elementName = $(this).attr('name');
                                var aspForm = $('#aspnetForm');

                                var newPostbackUrl = '" + Web.Url + "/" + list.Forms[PAGETYPE.PAGE_NEWFORM].Url + "?Source=" + System.Web.HttpUtility.UrlEncode(Web.Url + "/_layouts/15/epmlive/getlastid.aspx?BackTo=" + System.Web.HttpUtility.UrlEncode(newLocation) + "&listid=" + list.ID + ((bDialog) ? "&isdlg=1" : "")) + @"';

                               if (!PreSaveItem()) return false;
                                if (SPClientForms.ClientFormManager.SubmitClientForm('WPQ2')) return false;

                                WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(elementName, '', true, '', newPostbackUrl, false, true));
                            });
                        });
                         </script>");
					}
                    #endregion
                }
                else
				{
					if (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && base.ControlMode == SPControlMode.New)
					{
						writer.WriteLine(@"<script>

                        $(document).ready(function() {
                           if($('input[id$=SaveItem]').length > 1){                        
                                $('.ms-formline').hide();
                                $('input[id$=SaveItem]').last().hide();
                                $('input[id$=GoBack]').last().hide();
                            }
                         });
                         </script>");

					}
				}
            }
            else
				base.RenderControl(writer);
		}

        #region resourcepool methods

        private void AddControlsToWriter(Control control, HtmlTextWriter writer, string internalName = "")
		{
			if (isResList)
			{
				if (userPanelItems.Contains(internalName))
				{
					control.RenderControl(userPanel);
				}
				else if (permissionPanelItems.Contains(internalName))
				{
					control.RenderControl(permissionPanel);
				}
				else
				{
					control.RenderControl(profilePanel);
				}
			}
			else
			{
				control.RenderControl(writer);
			}

		}

		private string CreateHtmlPanelText(string panelTitle)
		{
			return "<tr><td colspan=\"2\"><div class=\"upcontainer\"><div class=\"upheader\"><img src=\"/_layouts/15/epmlive/images/navigation/collapse.png\" class=\"image_margin imgDownArrow\" alt=\"downArrow\" /><img src=\"/_layouts/15/epmlive/images/navigation/expand.png\" class=\"image_margin imgArrow\" alt=\"arrow\" /><span>" + panelTitle + "</span></div><div class=\"upcontent\"><table>";
		}

		#endregion

		protected override void CreateChildControls()
		{

			if (isFeatureActivated)
			{
				try
				{
					for (int i = 0; i < Fields.Count; i++)
					{
						SPField field = Fields[i];
						if (arrwpFields.Contains(field.InternalName) && mode == SPControlMode.Edit)
						{
							if ((bool)arrwpFields[field.InternalName])
							{
								TemplateContainer child = new TemplateContainer();
								Controls.Add(child);

								SetFieldName(child, field.InternalName);
								SetControlMode(child, mode);

								ControlTemplate.InstantiateIn(child);
							}
						}
						else if (!IsFieldExcluded(field))
						{

							string editable = "";
							try
							{
								editable = fieldProperties[field.InternalName]["Editable"];
								editable = editable.Split(";".ToCharArray())[0].ToLower();
							}
							catch { }

							if ((editable == "never" || editable == "where" || field.Type == SPFieldType.Calculated) && mode != SPControlMode.New)
							{
								if (editable == "where" && EditableFieldDisplay.canEdit(field, fieldProperties, this.ListItem))
								{
									TemplateContainer child = new TemplateContainer();
									Controls.Add(child);

									SetFieldName(child, field.InternalName);
									SetControlMode(child, mode);

									ControlTemplate.InstantiateIn(child);
								}
								else
								{
									TemplateContainer child = new TemplateContainer();
									Controls.Add(child);

									SetFieldName(child, field.InternalName);
									SetControlMode(child, SPControlMode.Display);

									ControlTemplate.InstantiateIn(child);
								}
							}
							else
							{
								TemplateContainer child = new TemplateContainer();
								Controls.Add(child);

								SetFieldName(child, field.InternalName);
								SetControlMode(child, mode);



								ControlTemplate.InstantiateIn(child);
							}
						}
					}
				}
				catch { }
				// prepopulate lookup fields with query string values

				InsertLookupValueByQueryString();

				// Add EPMLive custom entity picker control to 
				// lookup fields
				if (Fields != null)
				{
					foreach (SPField f in Fields)
					{
						AddTypeAheadFieldControls(f);
					}
				}
				//AddEntityPickersToLookups();
			}
			else
				base.CreateChildControls();

		}

		private void InsertLookupValueByQueryString()
		{
			if (mode == SPControlMode.New || (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrEmpty(Page.Request[ModeParam]) && Page.Request[ModeParam] == "Upload" && mode == SPControlMode.Edit))
			{
				// assume single lookup
				bool valIsMulti = false;
				List<int> ids = new List<int>();
				if (!string.IsNullOrEmpty(this.lookupValue))
				{
					valIsMulti = (this.lookupValue.IndexOf(',') != -1);
					if (valIsMulti)
					{
						string[] sIds = this.lookupValue.Split(',');
						foreach (string s in sIds)
						{
							if (!string.IsNullOrEmpty(s.Trim()))
							{
								ids.Add(int.Parse(s));
							}
						}
					}
				}

				List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
				List<FormField> modCandidates = new List<FormField>();
				foreach (FormField fld in formFields)
				{
					if (!string.IsNullOrEmpty(lookupField) && fld.Field.InternalName.Equals(lookupField))
					{
						modCandidates.Add(fld);
					}
				}

				for (int index = 0; index < modCandidates.Count; index++)
				{
					SPField spFld = modCandidates[index].Field;
					SPFieldLookup lookupFld = modCandidates[index].Field as SPFieldLookup;
					bool isMulti = lookupFld.AllowMultipleValues;

					// insert single value to single lookup field
					if (!isMulti && !valIsMulti)
					{
						int itemID = int.Parse(lookupValue.Trim());
						SPFieldLookupValue lookupVal = new SPFieldLookupValue(itemID, GetLookupItemValue(lookupFld, itemID));
						this.ListItem[spFld.Id] = lookupVal;
					}
					// insert multi lookup value to multi lookup field
					else if (isMulti && valIsMulti)
					{
						SPFieldLookupValueCollection lookupValCol = new SPFieldLookupValueCollection();
						foreach (int itemID in ids)
						{
							SPFieldLookupValue lookupVal = new SPFieldLookupValue(itemID, GetLookupItemValue(lookupFld, itemID));
							lookupValCol.Add(lookupVal);
						}
						this.ListItem[spFld.Id] = lookupValCol;
					}
				}
			}
		}

		private string GetLookupItemValue(SPFieldLookup lookupFld, int lookupItemID)
		{
			string result = string.Empty;
			SPSecurity.RunWithElevatedPrivileges(delegate ()
			{
				using (SPSite es = new SPSite(SPContext.Current.Site.ID))
				{
					using (SPWeb ew = es.OpenWeb(lookupFld.LookupWebId))
					{
						SPList targetList = ew.Lists[new Guid(lookupFld.LookupList)];
						SPListItem targetItem = targetList.GetItemById(lookupItemID);
						result = targetItem[targetList.Fields.GetFieldByInternalName(lookupFld.LookupField).Id].ToString();
					}
				}
			});

			return result;
		}

		private SPFieldLookupValueCollection GetQueryStringLookupVal(FormField currentFld)
		{
			if (string.IsNullOrEmpty(lookupField) || !currentFld.Field.InternalName.Equals(lookupField))
			{
				return null;
			}

			SPFieldLookupValueCollection result = new SPFieldLookupValueCollection();
			// assume single lookup
			bool valIsMulti = false;
			List<int> ids = new List<int>();
			if (!string.IsNullOrEmpty(this.lookupValue))
			{
				valIsMulti = this.lookupValue.Contains(',');
				if (valIsMulti)
				{
					string[] sIds = this.lookupValue.Split(',');
					foreach (string s in sIds)
					{
						if (!string.IsNullOrEmpty(s.Trim()))
						{
							ids.Add(int.Parse(s));
						}
					}
				}
			}

			//List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
			List<FormField> modCandidates = new List<FormField>() { currentFld };

			for (int index = 0; index < modCandidates.Count; index++)
			{
				SPField spFld = modCandidates[index].Field;
				SPFieldLookup lookupFld = modCandidates[index].Field as SPFieldLookup;
				bool isMulti = lookupFld.AllowMultipleValues;

				// insert single value to single lookup field
				if (!isMulti && !valIsMulti)
				{
					int itemId;
					if (int.TryParse(lookupValue.Trim(), out itemId))
					{
						result.Add(new SPFieldLookupValue(itemId, GetLookupItemValue(lookupFld, itemId)));
					}
				}
				// insert multi lookup value to multi lookup field
				else if (isMulti && valIsMulti)
				{
					foreach (int id in ids)
					{
						result.Add(new SPFieldLookupValue(id, GetLookupItemValue(lookupFld, id)));
					}
				}
			}

			return result;
		}


		private SPFieldLookupValueCollection GetQueryStringLookupVal(SPField fld)
		{
			if (string.IsNullOrEmpty(lookupField) || !fld.InternalName.Equals(lookupField))
			{
				return null;
			}

			SPFieldLookupValueCollection result = new SPFieldLookupValueCollection();
			// assume single lookup
			bool valIsMulti = false;
			List<int> ids = new List<int>();
			if (!string.IsNullOrEmpty(this.lookupValue))
			{
				valIsMulti = this.lookupValue.Contains(',');
				if (valIsMulti)
				{
					string[] sIds = this.lookupValue.Split(',');
					foreach (string s in sIds)
					{
						if (!string.IsNullOrEmpty(s.Trim()))
						{
							ids.Add(int.Parse(s));
						}
					}
				}
			}

			SPFieldLookup lookupFld = fld as SPFieldLookup;
			bool isMulti = lookupFld.AllowMultipleValues;

			// insert single value to single lookup field
			if (!isMulti && !valIsMulti)
			{
				int itemId;
				if (int.TryParse(lookupValue.Trim(), out itemId))
				{
					result.Add(new SPFieldLookupValue(itemId, GetLookupItemValue(lookupFld, itemId)));
				}
			}
			// insert multi lookup value to multi lookup field
			else if (isMulti && valIsMulti)
			{
				foreach (int id in ids)
				{
					result.Add(new SPFieldLookupValue(id, GetLookupItemValue(lookupFld, id)));
				}
			}
			return result;
		}

		private void AddTypeAheadFieldControls(SPField fld)
		{
			if (mode == SPControlMode.New || mode == SPControlMode.Edit)
			{
				// this represents a comma separated list of lookup field internal names to modify
				EnhancedLookupConfigValuesHelper valueHelper = null;
				string unprocessedModCandidates = string.Empty;
				GridGanttSettings gSettings = new GridGanttSettings(this.list);

				try
				{
					string rawValue = gSettings.Lookups;
					//string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
					valueHelper = new EnhancedLookupConfigValuesHelper(rawValue);
				}
				catch { }

				if (valueHelper == null)
				{
					return;
				}


				bool isEnhanced = valueHelper.ContainsKey(fld.InternalName);
				bool isParent = valueHelper.IsParentField(fld.InternalName);

				if (!isEnhanced && !isParent)
				{
					return;
				}

				LookupConfigData lookupData = valueHelper.GetFieldData(fld.InternalName);

				if (isParent && !isEnhanced)
				{
					SPFieldLookup lookupFld = fld as SPFieldLookup;
					if (!lookupFld.AllowMultipleValues)
					{
						CascadingLookupRenderControl ctrl = new CascadingLookupRenderControl();
						if (lookupData == null)
						{
							lookupData = new LookupConfigData();
							lookupData.IsParent = true;
						}
						ctrl.LookupData = lookupData;
						ctrl.LookupField = lookupFld;

						string customValue =
						"<Data>" +
						"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
						"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
						"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
						"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
						"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
						"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
						"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
						"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
						"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
						"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
						GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
						"</Data>";

						ctrl.CustomProperty = customValue;
						FormField ff = this.GetFormFieldByField(fld);
						if (ff != null)
						{
							ff.Parent.Controls.AddAfter(ff, ctrl);
						}
					}
				}
				else if (isParent && isEnhanced)
				{
					if (lookupData.Type == "2")
					{
						#region INSERT EPMLIVE GENERIC PICKER CONTROL

						picker = new GenericEntityEditor();
						SPFieldLookup lookupFld = fld as SPFieldLookup;
						picker.MultiSelect = lookupFld.AllowMultipleValues;

						string customValue =
							"<Data>" +
							"<Param key=\"SPFieldType\"></Param>" +
							"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
							"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
							"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
							"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
							"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
							"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
							"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
							"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
							GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
							"<Param key=\"Field\">" + lookupData.Field + "</Param>" +
							"<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
							"<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
							"<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
							"<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
							"</Data>";

						SPFieldLookupValueCollection lookupValCol = null;

						if (mode == SPControlMode.New || (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrEmpty(Page.Request[ModeParam]) && Page.Request[ModeParam] == "Upload" && mode == SPControlMode.Edit))
						{
							lookupValCol = GetQueryStringLookupVal(fld);
						}
						else
						{
							try
							{
								lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
							}
							catch { }
						}

						if (lookupValCol != null && lookupValCol.Count > 0)
						{
							ArrayList alItems = new ArrayList();
							PickerEntity entity;
							foreach (SPFieldLookupValue v in lookupValCol)
							{
								entity = new PickerEntity();
								entity.Key = v.LookupId.ToString();
								entity.DisplayText = v.LookupValue;
								entity.IsResolved = true;
								alItems.Add(entity);
							}
							picker.UpdateEntities(alItems);
						}

						picker.CustomProperty = customValue;

						FormField ff = this.GetFormFieldByField(fld);
						if (ff != null)
						{
							ff.Parent.Controls.AddAfter(ff, picker);
						}

						#endregion
					}
					else if (lookupData.Type == "1")
					{
						#region INSERT MODIFIED SP CONTROL

						SPFieldLookup lookupFld = fld as SPFieldLookup;
						if (!lookupFld.AllowMultipleValues)
						{
							CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
							cclrCtrl.LookupData = lookupData;
							cclrCtrl.LookupField = lookupFld;

							string customValue =
							"<Data>" +
							"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
							"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
							"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
							"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
							"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
							"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
							"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
							"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
							"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
							"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
							GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
							"</Data>";

							cclrCtrl.CustomProperty = customValue;

							FormField ff = this.GetFormFieldByField(fld);
							if (ff != null)
							{
								ff.Parent.Controls.AddAfter(ff, cclrCtrl);
							}
						}

						#endregion
					}
				}
				else if (!isParent && isEnhanced)
				{
					if (lookupData.Type == "2")
					{
						#region INSERT EPMLIVE GENERIC PICKER CONTROL

						picker = new GenericEntityEditor();
						SPFieldLookup lookupFld = fld as SPFieldLookup;
						picker.MultiSelect = lookupFld.AllowMultipleValues;

						string customValue =
							"<Data>" +
							"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
							"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
							"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
							"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
							"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
							"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
							"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
							"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
							"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
							GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
							"<Param key=\"Field\">" + lookupData.Field + "</Param>" +
							"<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
							"<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
							"<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
							"<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
							"</Data>";

						SPFieldLookupValueCollection lookupValCol = null;

						if (mode == SPControlMode.New || (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrEmpty(Page.Request[ModeParam]) && Page.Request[ModeParam] == "Upload" && mode == SPControlMode.Edit))
						{
							lookupValCol = GetQueryStringLookupVal(fld);
						}
						else
						{
							try
							{
								lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
							}
							catch { }
						}

						if (lookupValCol != null && lookupValCol.Count > 0)
						{
							ArrayList alItems = new ArrayList();
							PickerEntity entity;
							foreach (SPFieldLookupValue v in lookupValCol)
							{
								entity = new PickerEntity();
								entity.Key = v.LookupId.ToString();
								entity.DisplayText = v.LookupValue;
								entity.IsResolved = true;
								alItems.Add(entity);
							}
							picker.UpdateEntities(alItems);
						}

						picker.CustomProperty = customValue;

						FormField ff = this.GetFormFieldByField(fld);
						if (ff != null)
						{
							ff.Parent.Controls.AddAfter(ff, picker);
						}


						#endregion
					}
					else if (lookupData.Type == "1")
					{
						#region INSERT MODIFIED SP CONTROL

						SPFieldLookup lookupFld = fld as SPFieldLookup;
						if (!lookupFld.AllowMultipleValues)
						{
							CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
							cclrCtrl.LookupData = lookupData;
							cclrCtrl.LookupField = lookupFld;

							string customValue =
							"<Data>" +
							"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
							"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
							"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
							"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
							"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
							"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
							"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
							"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
							"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
							"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
							GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
							"</Data>";

							cclrCtrl.CustomProperty = customValue;

							FormField ff = this.GetFormFieldByField(fld);
							if (ff != null)
							{
								ff.Parent.Controls.AddAfter(ff, cclrCtrl);
							}
						}
						else
						{
							CascadingMultiLookupRenderControl cclrCtrl = new CascadingMultiLookupRenderControl();
							cclrCtrl.LookupData = lookupData;
							cclrCtrl.LookupField = lookupFld;

							string customValue =
							"<Data>" +
							"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
							"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
							"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
							"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
							"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
							"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
							"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
							"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
							"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
							"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
							GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
							"</Data>";

							cclrCtrl.CustomProperty = customValue;

							FormField ff = this.GetFormFieldByField(fld);
							if (ff != null)
							{
								ff.Parent.Controls.AddAfter(ff, cclrCtrl);
							}
						}

						#endregion
					}
				}
			}
		}


		private void AddEntityPickersToLookups()
		{
			if (mode == SPControlMode.New || mode == SPControlMode.Edit)
			{
				// this represents a comma separated list of lookup field internal names to modify
				EnhancedLookupConfigValuesHelper valueHelper = null;
				string unprocessedModCandidates = string.Empty;
				GridGanttSettings gSettings = new GridGanttSettings(this.list);

				try
				{
					string rawValue = gSettings.Lookups;
					//string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
					valueHelper = new EnhancedLookupConfigValuesHelper(rawValue);
				}
				catch { }

				if (valueHelper == null)
				{
					return;
				}

				List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
				foreach (FormField fld in formFields)
				{
					bool isEnhanced = valueHelper.ContainsKey(fld.Field.InternalName);
					bool isParent = valueHelper.IsParentField(fld.Field.InternalName);

					if (!isEnhanced && !isParent)
					{
						continue;
					}

					LookupConfigData lookupData = valueHelper.GetFieldData(fld.Field.InternalName);

					if (isParent && !isEnhanced)
					{
                        SPFieldLookup lookupFld = GetFieldLookup(fld);
						if (!lookupFld.AllowMultipleValues)
						{
							CascadingLookupRenderControl ctrl = new CascadingLookupRenderControl();
							if (lookupData == null)
							{
								lookupData = new LookupConfigData();
								lookupData.IsParent = true;
							}
							ctrl.LookupData = lookupData;
							ctrl.LookupField = lookupFld;

							string customValue =
							"<Data>" +
							"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
							"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
							"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
							"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
							"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
							"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
							"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
							"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
							"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
							"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
							GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
							"</Data>";

							ctrl.CustomProperty = customValue;
							fld.Controls.Add(ctrl);
						}
					}
					else if (isParent && isEnhanced)
					{
						if (lookupData.Type == "2")
						{
							#region INSERT EPMLIVE GENERIC PICKER CONTROL

							picker = new GenericEntityEditor();
                            SPFieldLookup lookupFld = GetFieldLookup(fld);
                            picker.MultiSelect = lookupFld.AllowMultipleValues;

							string customValue =
								"<Data>" +
								"<Param key=\"SPFieldType\"></Param>" +
								"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
								"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
								"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
								"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
								"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
								"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
								"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
								"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
								GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
								"<Param key=\"Field\">" + lookupData.Field + "</Param>" +
								"<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
								"<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
								"<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
								"<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
								"</Data>";

							SPFieldLookupValueCollection lookupValCol = null;

							if (mode == SPControlMode.New)
							{
								lookupValCol = GetQueryStringLookupVal(fld);
							}
							else
							{
								try
								{
									lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
								}
								catch { }
							}

							if (lookupValCol != null && lookupValCol.Count > 0)
							{
								ArrayList alItems = new ArrayList();
								PickerEntity entity;
								foreach (SPFieldLookupValue v in lookupValCol)
								{
									entity = new PickerEntity();
									entity.Key = v.LookupId.ToString();
									entity.DisplayText = v.LookupValue;
									entity.IsResolved = true;
									alItems.Add(entity);
								}
								picker.UpdateEntities(alItems);
							}

							picker.CustomProperty = customValue;
							fld.Controls.Add(picker);

							#endregion
						}
						else if (lookupData.Type == "1")
						{
							#region INSERT MODIFIED SP CONTROL

							SPFieldLookup lookupFld = GetFieldLookup(fld);
							if (!lookupFld.AllowMultipleValues)
							{
								CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
								cclrCtrl.LookupData = lookupData;
								cclrCtrl.LookupField = lookupFld;

								string customValue =
								"<Data>" +
								"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
								"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
								"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
								"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
								"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
								"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
								"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
								"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
								"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
								"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
								GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
								"</Data>";

								cclrCtrl.CustomProperty = customValue;
								fld.Controls.Add(cclrCtrl);
							}

							#endregion
						}
					}
					else if (!isParent && isEnhanced)
					{
						if (lookupData.Type == "2")
						{
							#region INSERT EPMLIVE GENERIC PICKER CONTROL

							picker = new GenericEntityEditor();
                            SPFieldLookup lookupFld = GetFieldLookup(fld);
                            picker.MultiSelect = lookupFld.AllowMultipleValues;

							string customValue =
								"<Data>" +
								"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
								"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
								"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
								"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
								"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
								"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
								"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
								"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
								"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
								GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
								"<Param key=\"Field\">" + lookupData.Field + "</Param>" +
								"<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
								"<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
								"<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
								"<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
								"</Data>";

							SPFieldLookupValueCollection lookupValCol = null;

							if (mode == SPControlMode.New)
							{
								lookupValCol = GetQueryStringLookupVal(fld);
							}
							else
							{
								try
								{
									lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
								}
								catch { }
							}

							if (lookupValCol != null && lookupValCol.Count > 0)
							{
								ArrayList alItems = new ArrayList();
								PickerEntity entity;
								foreach (SPFieldLookupValue v in lookupValCol)
								{
									entity = new PickerEntity();
									entity.Key = v.LookupId.ToString();
									entity.DisplayText = v.LookupValue;
									entity.IsResolved = true;
									alItems.Add(entity);
								}
								picker.UpdateEntities(alItems);
							}

							picker.CustomProperty = customValue;
							fld.Controls.Add(picker);

							#endregion
						}
						else if (lookupData.Type == "1")
						{
                            #region INSERT MODIFIED SP CONTROL

                            SPFieldLookup lookupFld = GetFieldLookup(fld);
                            if (!lookupFld.AllowMultipleValues)
							{
								CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
								cclrCtrl.LookupData = lookupData;
								cclrCtrl.LookupField = lookupFld;

								string customValue =
								"<Data>" +
								"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
								"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
								"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
								"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
								"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
								"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
								"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
								"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
								"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
								"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
								GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
								"</Data>";

								cclrCtrl.CustomProperty = customValue;
								fld.Controls.Add(cclrCtrl);
							}
							else
							{
								CascadingMultiLookupRenderControl cclrCtrl = new CascadingMultiLookupRenderControl();
								cclrCtrl.LookupData = lookupData;
								cclrCtrl.LookupField = lookupFld;

								string customValue =
								"<Data>" +
								"<Param key=\"SPFieldType\">SPFieldUser</Param>" +
								"<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
								"<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
								"<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
								"<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
								"<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
								"<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
								"<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
								"<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
								"<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
								GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
								"</Data>";

								cclrCtrl.CustomProperty = customValue;
								fld.Controls.Add(cclrCtrl);
							}

							#endregion
						}
					}


				}
			}
		}

        private static SPFieldLookup GetFieldLookup(FormField fld)
        {
            return fld.Field as SPFieldLookup;
        }

        private string GenerateControlDataForLookupField(FormField sourceFld, bool isMulti)
		{
			StringBuilder sbResult = new StringBuilder();
			// in the case of multi select
			// we need the ids of four controls
			// to post back data
			if (isMulti)
			{
				// need control id for the addbutton, removeButton, selectCandidate, selectResult controls
				sbResult.Append("<Param key=\"SelectCandidateID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_SelectCandidate") + "</Param>" +
								"<Param key=\"AddButtonID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_AddButton") + "</Param>" +
								"<Param key=\"RemoveButtonID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_RemoveButton") + "</Param>" +
								"<Param key=\"SelectResultID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_SelectResult") + "</Param>");

			}
			// in the case of a single select
			// we just need the input or the dropdown
			// controls id to post back data
			else
			{
				sbResult.Append("<Param key=\"SourceDropDownID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_$" + sourceFld.Field.FieldRenderingControl.GetType().Name) + "</Param>");
				sbResult.Append("<Param key=\"SourceControlID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_$" + sourceFld.Field.FieldRenderingControl.GetType().Name) + "</Param>");
			}

			return sbResult.ToString();
		}

		private string GenerateControlDataForLookupField(SPField fld, bool isMulti)
		{
			StringBuilder sbResult = new StringBuilder();
			// in the case of multi select
			// we need the ids of four controls
			// to post back data
			if (isMulti)
			{
				// need control id for the addbutton, removeButton, selectCandidate, selectResult controls
				sbResult.Append("<Param key=\"SelectCandidateID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_SelectCandidate") + "</Param>" +
								"<Param key=\"AddButtonID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_AddButton") + "</Param>" +
								"<Param key=\"RemoveButtonID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_RemoveButton") + "</Param>" +
								"<Param key=\"SelectResultID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_SelectResult") + "</Param>");

			}
			// in the case of a single select
			// we just need the input or the dropdown
			// controls id to post back data
			else
			{
				sbResult.Append("<Param key=\"SourceDropDownID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_$" + fld.FieldRenderingControl.GetType().Name) + "</Param>");
				sbResult.Append("<Param key=\"SourceControlID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_$" + fld.FieldRenderingControl.GetType().Name) + "</Param>");
			}

			return sbResult.ToString();
		}

		private static Control GetControl(FieldMetadata formField)
		{
			return formField.FindControlRecursive(x => x.GetType() == GetChildControlBasedOnFieldType(formField.Field.FieldRenderingControl));
		}

		private static Type GetChildControlBasedOnFieldType(object field)
		{
			if (field.GetType().Equals(typeof(MultipleLookupField)))
			{
				return typeof(MultipleLookupField);
			}

			if (field.GetType().Equals(typeof(LookupField)))
			{
				return typeof(LookupField);
			}

			return null;
		}

		private static void SetFieldName(TemplateContainer child, string fieldName)
		{
			try
			{
				PropertyInfo property = child.GetType().GetProperty("FieldName", BindingFlags.NonPublic | BindingFlags.Instance);
				property.SetValue(child, fieldName, null);
			}
			catch (Exception) { }
		}

		private static void SetControlMode(TemplateContainer child, SPControlMode controlMode)
		{
			try
			{
				PropertyInfo property = child.GetType().GetProperty("ControlMode", BindingFlags.NonPublic | BindingFlags.Instance);
				property.SetValue(child, controlMode, null);
			}
			catch (Exception) { }
		}

		protected override bool IsFieldExcluded(SPField field)
		{

			if (isFeatureActivated)
			{
				if (isResList)
				{
					try
					{
						switch (field.InternalName)
						{
							case "ResourceLevel":
								if (Web.CurrentUser.IsSiteAdmin || EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower() == ownerusername.ToLower())
								{
									Act act = new Act(Web);
									int actType = 0;

									ArrayList Levels = act.GetLevelsFromSite(out actType, "");

									if (actType > 2)
									{
										return false;
									}
									return true;
								}
								else
									return true;
							case "Permissions":
								if (this.mode != SPControlMode.New)
								{

									string generic = "";
									try
									{
										generic = this.ListItem["Generic"].ToString();
									}
									catch { }
									if (generic == "False")
										return false;
									else
										return true;

								}
								return false;
							case "Title":
								if (this.mode == SPControlMode.Edit)
								{
									try
									{
										if (!bool.Parse(this.ListItem["Generic"].ToString()))
											return true;
									}
									catch { }
								}
								return false;
							case "FirstName":
							case "LastName":
								if (this.mode == SPControlMode.New)
								{
									return false;
								}
								else
								{
									try
									{
										if (bool.Parse(this.ListItem["Generic"].ToString()))
											return true;
									}
									catch { }
								}
								return false;
							case "Email":
								if (this.mode == SPControlMode.New)
									return false;
								else
									return true;
							case "CanLogin":
								return true;
							case "Generic":
								if (this.mode == SPControlMode.New)
									return false;
								else
									return true;
							case "Approved":
								if (field.ParentList.Fields.ContainsFieldWithInternalName("ResourceLevel"))
									return true;
								else
								{
									string approved = "No";
									try
									{
										approved = this.ListItem["Approved"].ToString();
									}
									catch { }
									if (SPContext.Current.Web.UserIsSiteAdmin && approved == "False" && this.mode != SPControlMode.New)
										return false;
									else
										return true;
								}
							default:
								if (isOnline)
								{
									switch (field.InternalName)
									{
										case "SharePointAccount":
											return true;
									}
								}
								if (!isOnline)
								{
									switch (field.InternalName)
									{
										case "CanLogin":
										case "Email":
											return true;
									}
								}
								break;
						}
					}
					catch { }
				}
				//SPFeature listDisplaySettingFeature = SPContext.Current.Site.Features[new Guid("2EACB61B-4379-46ec-94FA-38B793FDBDD5")];

				//if ((listDisplaySettingFeature != null) && (listDisplaySettingFeature.Definition.Status == Microsoft.SharePoint.Administration.SPObjectStatus.Online))

				{
					if (fieldProperties != null)
					{
						//Dictionary<string, Dictionary<string, string>> fieldProperties = null;
						//fieldProperties = ListDisplayUtils.ConvertFromString(list.ParentWeb.Properties[String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(list.DefaultView.Url))]);
						string displaySettings = string.Empty;

						if (!fieldProperties.ContainsKey(field.InternalName))
							return base.IsFieldExcluded(field);
						else
						{
							switch (mode)
							{
								case SPControlMode.Display:
									displaySettings = fieldProperties[field.InternalName]["Display"];
									if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
									{
										string where = displaySettings.Split(";".ToCharArray())[1];
										string conditionField = "";
										string condition = "";
										string group = "";
										string valueCondition = "";
										if (where.Equals("[Me]"))
										{
											condition = displaySettings.Split(";".ToCharArray())[2];
											group = displaySettings.Split(";".ToCharArray())[3];
										}
										else // [Fielthi
										{
											conditionField = displaySettings.Split(";".ToCharArray())[2];
											condition = displaySettings.Split(";".ToCharArray())[3];
											valueCondition = displaySettings.Split(";".ToCharArray())[4];
										}
										return !EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, this.ListItem);
									}
									else
									{
										return base.IsFieldExcluded(field);
									}
								case SPControlMode.Edit:
									if (!fieldProperties[field.InternalName].ContainsKey("Edit"))
										return base.IsFieldExcluded(field);
									displaySettings = fieldProperties[field.InternalName]["Edit"];
									if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
									{
										string where = displaySettings.Split(";".ToCharArray())[1];
										string conditionField = "";
										string condition = "";
										string group = "";
										string valueCondition = "";
										if (where.Equals("[Me]"))
										{
											condition = displaySettings.Split(";".ToCharArray())[2];
											group = displaySettings.Split(";".ToCharArray())[3];
										}
										else // [Field]
										{
											conditionField = displaySettings.Split(";".ToCharArray())[2];
											condition = displaySettings.Split(";".ToCharArray())[3];
											valueCondition = displaySettings.Split(";".ToCharArray())[4];
										}
										return !EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, this.ListItem);
									}
									else
									{
										if (field.Type == SPFieldType.Calculated && displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("always"))
										{
											return false;
										}
										else
										{
											return base.IsFieldExcluded(field);
										}
									}
								case SPControlMode.New:
									if (!fieldProperties[field.InternalName].ContainsKey("New"))
										return base.IsFieldExcluded(field);
									else
									{
										displaySettings = fieldProperties[field.InternalName]["New"];
										if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
										{
											string where = displaySettings.Split(";".ToCharArray())[1];
											string conditionField = "";
											string condition = "";
											string group = "";
											string valueCondition = "";
											if (where.Equals("[Me]"))
											{
												condition = displaySettings.Split(";".ToCharArray())[2];
												group = displaySettings.Split(";".ToCharArray())[3];
											}
											else // [Field]
											{
												conditionField = displaySettings.Split(";".ToCharArray())[2];
												condition = displaySettings.Split(";".ToCharArray())[3];
												valueCondition = displaySettings.Split(";".ToCharArray())[4];
											}
											return !EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, this.ListItem);
										}
										else
										{
											return base.IsFieldExcluded(field);
										}
									}
								default:
									return base.IsFieldExcluded(field);
							}
						}
					}
					else
						return base.IsFieldExcluded(field);
				}
				//else
				//{
				//    return base.IsFieldExcluded(field);
				//}
			}
			else
				return base.IsFieldExcluded(field);
		}

        private static FieldLabel GetFieldLabel(Control control, int index1, int index2, int index3)
        {
            return (FieldLabel)control.Controls[index1].Controls[index2].Controls[index3];
        }

        private static FormField GetFormField(Control control, int index)
        {
            return (FormField)control.Controls[index];
        }

        private static FieldLabel GetFieldLabel(Control control, int index)
        {
            return (FieldLabel)control.Controls[index];
        }

        private static CompositeField GetCompositeField(Control control, int index)
        {
            return (CompositeField)control.Controls[index];
        }

        private static string GetControlType(Control control, int index)
        {
            return control.Controls[index].GetType().ToString();
        }
    }

	public static class ControlExtensions
	{
		public static Control FindControlRecursive(this Control control, Func<Control, bool> evaluate)
		{
			if (evaluate.Invoke(control))
			{
				return control;
			}

			foreach (Control childControl in control.Controls)
			{
				Control foundControl = FindControlRecursive(childControl, evaluate);
				if (foundControl != null)
				{
					return foundControl;
				}
			}

			return null;
		}
	}

	public static class ControlCollectionExtensions
	{
		public static void AddAfter(this ControlCollection collection, Control after, Control control)
		{
			int indexFound = -1;
			int currentIndex = 0;
			foreach (Control controlToEvaluate in collection)
			{
				if (controlToEvaluate == after)
				{
					indexFound = currentIndex;
					break;
				}

				currentIndex = currentIndex + 1;
			}

			if (indexFound == -1)
			{
				throw new ArgumentOutOfRangeException("control", "Control not found");
			}

			collection.AddAt(indexFound + 1, control);
		}
	}

	public static class ListFieldIteratorExtensions
	{
		public static FormField GetFormFieldByField(this ListFieldIterator listFieldIterator, SPField field)
		{
			return GetFormField(listFieldIterator, GetFormFields(listFieldIterator), field);
		}

		public static List<FormField> GetFormFieldByType(this ListFieldIterator listFieldIterator, Type fieldType)
		{
			return GetFormField(listFieldIterator, GetFormFields(listFieldIterator), fieldType);
		}

		public static List<FormField> GetFormField(this ListFieldIterator listFieldITerator, List<FormField> formFields, Type fieldType)
		{
			List<FormField> fields = (from form in formFields
									  where form.Field.GetType().Equals(fieldType)
									  select form).ToList<FormField>();

			return fields;
		}

		public static FormField GetFormField(this ListFieldIterator listFieldITerator, List<FormField> formFields, SPField field)
		{
			FormField ff = (from form in formFields
							where form.Field.Equals(field)
							select form).FirstOrDefault();

			return ff;
		}

		public static List<FormField> GetFormFields(this ListFieldIterator listFieldIterator)
		{
			if (listFieldIterator == null)
			{
				return null;
			}

			return FindFieldFormControls(listFieldIterator);
		}

		private static List<FormField> FindFieldFormControls(System.Web.UI.Control root)
		{
			List<FormField> baseFieldControls = new List<FormField>();

			foreach (System.Web.UI.Control control in root.Controls)
			{
				if (control is FormField && control.Visible)
				{
					FormField formField = control as FormField;
					if (formField.Field.FieldValueType == typeof(DateTime))
					{
						//HandleDateField(formField);
					}

					baseFieldControls.Add(formField);
				}
				else
				{
					baseFieldControls.AddRange(FindFieldFormControls(control));
				}
			}

			return baseFieldControls;
		}
    }
}
