using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class ListDisplaySettingIterator
    {
        public override void RenderControl(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            var relativeUrl = Web.ServerRelativeUrl == ForwardSlash ? string.Empty : Web.ServerRelativeUrl;

            if (isResList)
            {
                writer.WriteLine(" <script>$(document).ready(function () {$(\".imgArrow\").addClass(\"hideImage\"); $(\".upheader\").click(function () {$header = $(this);$arrowImage = $header.find(\".imgArrow\");$downArrowImage = $header.find(\".imgDownArrow\");$content = $header.next();");
                writer.Write("$content.slideToggle(100,function (){  if ($arrowImage.hasClass(\"hideImage\")) {$downArrowImage.addClass(\"hideImage\");$arrowImage.removeClass(\"hideImage\");$(\"#onetIDListForm\").attr(\"style\",\"width:95%\");}else {$arrowImage.addClass(\"hideImage\");$downArrowImage.removeClass(\"hideImage\");}});});});</script>");

                userPanel = new HtmlTextWriter(new StringWriter(userPanelSb, CultureInfo.InvariantCulture));
                userPanel.Write(CreateHtmlPanelText(UserTitle));

                profilePanel = new HtmlTextWriter(new StringWriter(profilePanelSb, CultureInfo.InvariantCulture));
                profilePanel.Write(CreateHtmlPanelText(ProfileTitle));

                if (CoreFunctions.DoesCurrentUserHaveFullControl(Web))
                {
                    permissionPanel = new HtmlTextWriter(new StringWriter(permissionPanelSb, CultureInfo.InvariantCulture));
                    permissionPanel.Write(CreateHtmlPanelText(PermissionsTitle));
                }
            }

            if (isFeatureActivated)
            {
                RenderControl(writer, relativeUrl);
            }
            else
            {
                base.RenderControl(writer);
            }
        }

        private void RenderControl(HtmlTextWriter writer, string relativeUrl)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (ControlMode == SPControlMode.Display)
            {
                RenderDisplay(writer, relativeUrl);
            }

            RenderOnline(writer);

            ProcessControls(writer);

            if (isResList)
            {
                RenderResList(writer);
            }

            if (isWorkList)
            {
                RenderWorkList(writer);
            }

            if (isResList)
            {
                RenderResultList(writer, false);
            }
            else
            {
                RenderDisabledLookup(writer);
            }

            var newLocation = string.Empty;
            var isDialog = Page.Request[IsDialogParameter] == ModifiedType;

            if (Page.Request[GetLastIdParameter] == "true")
            {
                newLocation = isDialog ? "close" : Page.Request[SourceParam];
            }

            if (!string.IsNullOrWhiteSpace(newLocation))
            {
                RenderNewLocation(writer, newLocation, isDialog);
            }
            else
            {
                if (list.BaseTemplate == SPListTemplateType.DocumentLibrary && ControlMode == SPControlMode.New)
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

        private void RenderDisplay(HtmlTextWriter writer, string relativeUrl)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            var editUrl = List.Forms[PAGETYPE.PAGE_EDITFORM].Url;
            editUrl = ((Web.ServerRelativeUrl == ForwardSlash) ? string.Empty : Web.ServerRelativeUrl) + ForwardSlash + editUrl;
            var extraParams = string.Empty;

            if (!string.IsNullOrWhiteSpace(Page.Request[IsDialogParameter]))
            {
                extraParams += "&isDlg=" + Page.Request[IsDialogParameter];
            }

            writer.WriteLine("<script language=\"javascript\">");

            writer.WriteLine($"WETitle = \"{HttpUtility.JavaScriptStringEncode(ListItem.Title)}\";");
            writer.WriteLine($"WEWebUrl = '{relativeUrl}';");
            writer.WriteLine($"WEWebId = '{Web.ID}';");
            writer.WriteLine($"WEEditForm = '{editUrl}';");
            writer.WriteLine($"WEExtraParams = '{extraParams.Trim('&')}';");
            writer.WriteLine($"WEListId = '{ListId}';");
            writer.WriteLine($"WEItemId = '{ItemId}';");
            writer.WriteLine($"WESource = '{HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()).Replace("+", "%20")}';");
            writer.WriteLine($"WEUseTeam = {bUseTeam.ToString().ToLower()};");
            writer.WriteLine($"WEDLG = '{Page.Request[IsDialogParameter]}';");
            writer.WriteLine("</script>");
        }

        private void RenderOnline(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            bool disableRequests;
            bool.TryParse(CoreFunctions.getConfigSetting(SPContext.Current.Web, "OnlineDisableResReq"), out disableRequests);
            var isAdmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
            if (isOnline && isResList)
            {
                if (!isAdmin && !disableRequests)
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
                    if (ActivationType != 3)
                    {
                        if (count >= max && max != -1 && billingtype != 2)
                        {
                            if (CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).Equals(ownerusername, StringComparison.InvariantCultureIgnoreCase))
                            {
                                writer.Write(@"<tr><td colspan='2'><table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" class=""tblResourceWarningMessages"">
                                    <tr>
                                    <td>You cannot create a new user that has login access because your account limit of " + max + @" has been reached.  Purchasing additional accounts is easy, just click <a href=""" + ((SPContext.Current.Web.ServerRelativeUrl == ForwardSlash) ? "" : SPContext.Current.Web.ServerRelativeUrl) + @"/_layouts/epmlive/purchase.aspx?accountid=" + accountid + @""">Purchase Accounts</a>.</tr>
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
                                writer.Write($"<tr><td colspan='2'><div id=\"divuCount\">User usage: {count} of {max}</div></td></tr>");
                            }
                        }
                    }
                }
            }
        }

        private void ProcessControls(HtmlTextWriter writer)
        {
            foreach (Control control in Controls)
            {
                try
                {
                    var field = GetFieldLabel(control, 1, 0, 1).Field;

                    if (field.Required)
                    {
                        ProcessRequired(field.InternalName);
                    }

                    var parentControl = control.Controls[1].Controls[0];
                    if (field.InternalName == DueName)
                    {
                        ProcessDue(writer, control, field.InternalName, parentControl);
                    }
                    else if (field.InternalName == DaysOverdueName)
                    {
                        ProcessDaysOverdue(writer, control, field.InternalName, parentControl);
                    }
                    else if (field.InternalName == ScheduleStatusName)
                    {
                        ProcessScheduleStatus(writer, control, field.InternalName, parentControl);
                    }
                    else if (field.Type == SPFieldType.Calculated)
                    {
                        ProcessCalculated(writer, control, field.InternalName, parentControl);
                    }
                    else if (field.Type == SPFieldType.Lookup)
                    {
                        AddControlsToWriter(control, writer, field.InternalName);
                    }
                    else if (arrwpFields.Contains(field.InternalName) && (bool)arrwpFields[field.InternalName])
                    {
                        ProcessControl(writer, control, field.InternalName, parentControl);
                    }
                    else
                    {
                        ProcessOther(writer, control, field.InternalName, parentControl);
                    }
                }
                catch (Exception ex)
                {
                    AddControlsToWriter(control, writer);

                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private void ProcessOther(HtmlTextWriter writer, Control control, string fieldInternalName, Control parentControl)
        {
            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }

            try
            {
                var field = GetCompositeField(control, 1).Field;
                var fieldName = $"{field.InternalName}_{field.Id}_${field.TypeAsString}Field";

                if (field.Type == SPFieldType.User)
                {
                    fieldName = $"{field.InternalName}_{field.Id}_$ClientPeoplePicker";
                }
                else if (field.TypeAsString == "ResourcePermissions" || field.TypeAsString == "ResourceLevels")
                {
                    fieldName = ControlMode == SPControlMode.Display
                        ? parentControl.Controls[13].ClientID
                        : parentControl.Controls[9].Controls[0].Controls[0].Controls[1].ClientID;
                }
                else if (field.InternalName == "Status")
                {
                    fieldName = $"{field.InternalName}_{field.Id}_$DropDownChoice";
                }

                dControls.Add(fieldInternalName, fieldName);

                AddControlsToWriter(control, writer, fieldInternalName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void ProcessControl(HtmlTextWriter writer, Control control, string fieldInternalName, Control parentControl)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }

            AddControlsToWriter(control.Controls[0], writer, fieldInternalName);
            for (var i = 0; i < parentControl.Controls.Count; i++)
            {
                if (GetControlType(parentControl, i) == "Microsoft.SharePoint.WebControls.FieldLabel")
                {
                    writer.Write((GetFieldLabel(parentControl, 1).Field.Title + " <font color=\"#007C17\">*</font>"));
                    if ((GetFieldLabel(parentControl, 1).Field.Required))
                    {
                        writer.Write(" <font class=\"ms-formvalidation\">*</font>");
                    }
                }
                else
                {
                    AddControlsToWriter(parentControl.Controls[i], writer, fieldInternalName);
                }
            }
            AddControlsToWriter(control.Controls[2], writer, fieldInternalName);
        }

        private void ProcessCalculated(HtmlTextWriter writer, Control control, string fieldInternalName, Control parentControl)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }

            AddControlsToWriter(control.Controls[0], writer, fieldInternalName);
            for (var i = 0; i < parentControl.Controls.Count; i++)
            {
                if (GetControlType(parentControl, i) == FormFieldType)
                {
                    ProcessControl(writer, parentControl, i);
                }
                else
                {
                    AddControlsToWriter(parentControl.Controls[i], writer, fieldInternalName);
                }
            }

            AddControlsToWriter(control.Controls[2], writer, fieldInternalName);
        }

        private void ProcessScheduleStatus(HtmlTextWriter writer, Control control, string fieldInternalName, Control parentControl)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }

            AddControlsToWriter(control.Controls[0], writer, fieldInternalName);
            for (var i = 0; i < parentControl.Controls.Count; i++)
            {
                if (GetControlType(parentControl, i) == FormFieldType)
                {
                    var color = CoreFunctions.GetScheduleStatusField(base.ListItem);
                    if (color != string.Empty)
                    {
                        writer.Write(@"<img src=""/_layouts/images/" + color + @""">");
                    }
                    else
                    {
                        ProcessControl(writer, parentControl, i);
                    }
                }
                else
                {
                    AddControlsToWriter(parentControl.Controls[i], writer, fieldInternalName);
                }
            }
            AddControlsToWriter(control.Controls[2], writer, fieldInternalName);
        }

        private static void ProcessControl(HtmlTextWriter writer, Control parentControl, int index)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }

            var value = GetFormField(parentControl, index).ItemFieldValue.ToString();

            var stringValue = string.Empty;
            try
            {
                stringValue = GetFieldLabel(parentControl, 1).Field.GetFieldValueAsHtml(value);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            if (stringValue.IndexOf(".gif", StringComparison.InvariantCultureIgnoreCase) > 0 ||
                stringValue.IndexOf(".jpg", StringComparison.InvariantCultureIgnoreCase) > 0)
            {
                writer.Write($"<img src=\"{SPContext.Current.Web.Url}/_layouts/images/{stringValue}\">");
            }
            else if (stringValue == string.Empty)
            {
                writer.Write("&nbsp;");
            }
            else
            {
                writer.Write(stringValue);
            }
        }

        private void ProcessDaysOverdue(HtmlTextWriter writer, Control control, string fieldInternalName, Control parentControl)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }
            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }
            AddControlsToWriter(control.Controls[0], writer, fieldInternalName);
            for (var i = 0; i < parentControl.Controls.Count; i++)
            {
                if (GetControlType(parentControl, i) == FormFieldType)
                {
                    writer.Write(CoreFunctions.GetDaysOverdueField(ListItem));
                }
                else
                {
                    AddControlsToWriter(parentControl.Controls[i], writer, fieldInternalName);
                }
            }
            AddControlsToWriter(control.Controls[2], writer, fieldInternalName);
        }

        private void ProcessDue(HtmlTextWriter writer, Control control, string fieldInternalName, Control parentControl)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }
            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }
            AddControlsToWriter(control.Controls[0], writer, fieldInternalName);
            for (var i = 0; i < parentControl.Controls.Count; i++)
            {

                if (GetControlType(parentControl, i) == FormFieldType)
                {
                    writer.Write(CoreFunctions.GetDueField(ListItem));
                }
                else
                {
                    AddControlsToWriter(parentControl.Controls[i], writer, fieldInternalName);
                }
            }
            AddControlsToWriter(control.Controls[2], writer, fieldInternalName);
        }

        private void ProcessRequired(string fieldInternalName)
        {
            if (userPanelItems.Contains(fieldInternalName))
            {
                userpanelRequiredCount++;
            }
            else if (permissionPanelItems.Contains(fieldInternalName))
            {
                permissionPanelRequiredCount++;
            }
            else
            {
                profilepanelRequiredCount++;
            }
        }

        private void RenderResList(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

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

        private void RenderWorkList(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            var pctControl = GetValue("PercentComplete");
            var compControl = GetValue("Complete");
            var statusControl = GetValue("Status");

            writer.WriteLine("<script language=\"javascript\">");
            writer.WriteLine($"_spBodyOnLoadFunctionNames.push(\"InitStatusingControls('{compControl}', '{pctControl}', '{statusControl}')\");");
            writer.WriteLine("</script>");
        }

        private string GetValue(string key)
        {
            return dControls.ContainsKey(key) ? dControls[key] : string.Empty;
        }

        private void RenderResultList(HtmlTextWriter writer, bool isOutOfUsers)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            try
            {
                RenderCheckSpecialCharacters(writer);

                writer.WriteLine("function setLicenseType(){");
                if (dControls.ContainsKey(ResourceLevelTitle))
                {
                    RenderResourceLevel(writer);
                }
                writer.WriteLine("}");

                writer.WriteLine("function cleanupfields(){");
                try
                {
                    if (!isOutOfUsers)
                    {
                        if (dControls.ContainsKey(CanLoginTitle))
                        {
                            RenderCanLogin(writer);
                        }
                    }

                    if (dControls.ContainsKey(GenericTitle))
                    {
                        RenderGeneric(writer);
                    }
                    // to check validtion for special character at the time of edit resources
                    else if ((dControls.ContainsKey(FirstNameKey) || dControls.ContainsKey(LastNameKey)))
                    {
                        Render(writer, WhitSpaces6, FirstNameKey, "First Name", "checkSpecialCharactersForNonGeneric");
                        Render(writer, WhitSpaces6, LastNameKey, "Last Name", "checkSpecialCharactersForNonGeneric");
                    }
                    else if (dControls.ContainsKey(TitleKey))
                    {
                        Render(writer, WhitSpaces6, TitleKey, "Display Name", "checkSpecialCharacters");
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                writer.WriteLine("}");

                writer.WriteLine("function InitFields(){");
                RenderOnClick(writer, GenericTitle);
                RenderOnClick(writer, CanLoginTitle);

                writer.WriteLine("cleanupfields();");
                writer.WriteLine("try { setLicenseType(); }catch(e){}");
                // To make default collapsed div, if there isnt any mandatory field in it
                writer.WriteLine("$(document).ready(function () {var defaultLicenseTypeId = '';var headers = $('.upheader');$.each(headers, function (i, val) {if ($(this).find('span').text() == 'Permissions' && " + permissionPanelRequiredCount + " == '0') {if('" + Convert.ToString(this.ListItem[GenericTitle]) + "' == 'True'){ $($(this).next()).hide(); $(this).hide(); }else{ $(this).next().slideUp();$(this).find('.imgArrow').removeClass('hideImage');$(this).find('.imgDownArrow').addClass('hideImage');}} if ($(this).find('span').text() == 'Profile' && " + profilepanelRequiredCount + " == '0' ) { $(this).next().slideUp();$(this).find('.imgArrow').removeClass('hideImage');$(this).find('.imgDownArrow').addClass('hideImage');}  });});");
                writer.WriteLine("}_spBodyOnLoadFunctionNames.push(\"InitFields\");");


                if (isOnline)
                {
                    if (dControls.ContainsKey(GenericTitle))
                    {
                        RenderOnlineGeneric(writer);
                    }
                }

                writer.WriteLine("</script>");

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private static void RenderCheckSpecialCharacters(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("<script language=\"javascript\">");
            writer.WriteLine("function checkSpecialCharacters(objectName,object){");
            writer.WriteLine("var checkPattern = /[\\|\\\\\"\'\\/\\[\\]\\:\\<\\>\\+\\=\\,\\;\\?\\*\\@]/");
            writer.WriteLine("if(checkPattern.test(object.value)) { alert(objectName + ' cannot contain any of the following characters ' + '| \\\\ \" \\' / [ ] : < > + = , ; ? * @'); object.value = ''; setTimeout(function(){object.focus();}, 1); }");
            writer.WriteLine("}");

            writer.WriteLine("function checkSpecialCharactersForNonGeneric(objectName,object){");
            writer.WriteLine("var checkPattern = /[\\|\\\\\"\\/\\[\\]\\:\\<\\>\\+\\=\\,\\;\\?\\*\\@]/");
            writer.WriteLine("if(checkPattern.test(object.value)) { alert(objectName + ' cannot contain any of the following characters ' + '| \\\\ \" \\/ [ ] : < > + = , ; ? * @'); object.value = ''; setTimeout(function(){object.focus();}, 1); }");
            writer.WriteLine("}");
        }

        private void RenderResourceLevel(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("var id = '';");
            writer.WriteLine("if(document.getElementById('" + dControls[ResourceLevelTitle] + "') !== null){");
            writer.WriteLine("var tbl = document.getElementById('" + dControls[ResourceLevelTitle] + "');");
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

        private void RenderCanLogin(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("  try{");
            try
            {
                writer.WriteLine("      if(document.getElementById('" + dControls[CanLoginTitle] + "').checked){");
                RenderDisplay(writer, WhiteSpaces10, GenericTitle, None);
                try
                {
                    writer.WriteLine("          try{document.getElementById('" + dControls[GenericTitle] + "').checked = false;}catch(e){}");
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                RenderDisplay(writer, WhiteSpaces10, PermissionsTitle);
                RenderDisplay(writer, WhiteSpaces10, ResourceLevelTitle);

                writer.WriteLine("      try{document.getElementById('divRequest').parentNode.parentNode.style.display='';}catch(e){}");
                writer.WriteLine("      try{document.getElementById('divuCount').parentNode.parentNode.style.display='';}catch(e){}");
                writer.WriteLine("      }else{");

                RenderDisplay(writer, WhiteSpaces10, GenericTitle);
                RenderDisplay(writer, WhiteSpaces10, PermissionsTitle, None);
                RenderDisplay(writer, WhiteSpaces10, ResourceLevelTitle, None);

                writer.WriteLine("      try{document.getElementById('divRequest').parentNode.parentNode.style.display='none';}catch(e){}");
                writer.WriteLine("      }");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            writer.WriteLine("  }catch(e){}");
        }

        private void RenderOnClick(HtmlTextWriter writer, string elementId)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (dControls.ContainsKey(elementId))
            {
                writer.WriteLine("document.getElementById('" + dControls[elementId] + "').onclick = function() {cleanupfields();};");
            }
        }

        private void RenderGeneric(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("  if(document.getElementById('" + dControls[GenericTitle] + "').checked){");
            RenderDisplay(writer, WhitSpaces6, FirstNameKey, None);
            RenderDisplay(writer, WhitSpaces6, LastNameKey, None);
            RenderDisplay(writer, WhitSpaces6, EmailKey, None);
            RenderDisplay(writer, WhitSpaces6, "TimesheetAdministrator", None);
            RenderDisplay(writer, WhitSpaces6, SharePointAccount, None);

            if (dControls.ContainsKey(FirstNameKey))
            {
                Render(writer, WhitSpaces6, TitleKey, "Display Name", "checkSpecialCharacters");
            }

            RenderWithManyNodes(writer, " ", PermissionsTitle, None);
            RenderDisplay(writer, WhiteSpaces10, ResourceLevelTitle, None);
            RenderDisplay(writer, WhiteSpaces10, CanLoginTitle, None);
            writer.WriteLine("  }else{");
            writer.WriteLine("try{document.getElementById(defaultLicenseTypeId).checked = true;}catch(e){}");
            Render(writer, WhitSpaces6, FirstNameKey, "First Name", "checkSpecialCharactersForNonGeneric");
            Render(writer, WhitSpaces6, LastNameKey, "Last Name", "checkSpecialCharactersForNonGeneric");
            RenderDisplay(writer, WhitSpaces6, EmailKey);
            RenderDisplay(writer, WhitSpaces6, "TimesheetAdministrator");

            if (dControls.ContainsKey(FirstNameKey))
            {
                RenderDisplay(writer, WhitSpaces6, TitleKey, None);
            }

            RenderDisplay(writer, WhitSpaces6, SharePointAccount);
            RenderWithManyNodes(writer, string.Empty, PermissionsTitle);
            RenderDisplay(writer, WhiteSpaces10, ResourceLevelTitle);
            RenderDisplay(writer, WhiteSpaces10, CanLoginTitle);
            writer.WriteLine("  }");
        }

        private void Render(HtmlTextWriter writer, string spaces, string elemenId, string name, string functionName)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (dControls.ContainsKey(elemenId))
            {
                var sb = new StringBuilder();
                sb.Append(spaces)
                    .Append("try{document.getElementById('")
                    .Append(dControls[elemenId])
                    .Append("').parentNode.parentNode.parentNode.style.display='';document.getElementById('")
                    .Append(dControls[elemenId])
                    .Append("').onblur = function() { ")
                    .Append(functionName)
                    .Append("('")
                    .Append(name)
                    .Append("',document.getElementById('")
                    .Append(dControls[elemenId])
                    .Append("')); }}catch(e){}");

                writer.WriteLine(sb.ToString());
            }
        }

        private void RenderDisplay(HtmlTextWriter writer, string spaces, string elemenId, string none = "")
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (dControls.ContainsKey(elemenId))
            {
                var sb = new StringBuilder();
                sb.Append(spaces)
                    .Append("try{document.getElementById('")
                    .Append(dControls[elemenId])
                    .Append("').parentNode.parentNode.parentNode.style.display='")
                    .Append(none)
                    .Append("';}catch(e){}");
                writer.WriteLine(sb.ToString());
            }
        }

        private void RenderWithManyNodes(HtmlTextWriter writer, string spaces, string elemenId, string none = "")
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (dControls.ContainsKey(elemenId))
            {
                var sb = new StringBuilder();
                sb.Append(spaces)
                    .Append("try{document.getElementById('")
                    .Append(dControls[elemenId])
                    .Append("').parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.style.display='")
                    .Append(none)
                    .Append("';}catch(e){}");
                writer.WriteLine(sb.ToString());
            }
        }

        private void RenderOnlineGeneric(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("function CustomPreSaveAction(){");
            writer.WriteLine("  if(!document.getElementById('" + dControls[GenericTitle] + "').checked){");
            writer.WriteLine("      var f = document.getElementById('" + dControls[FirstNameKey] + "').value;");
            writer.WriteLine("      var l = document.getElementById('" + dControls[LastNameKey] + "').value;");
            writer.WriteLine("      var e = document.getElementById('" + dControls[EmailKey] + "').value;");
            writer.WriteLine("      if(f == \"\" || l == \"\" || e == \"\"){");
            writer.WriteLine("          alert('You must enter a First Name, Last Name, and Email');return false;");
            writer.WriteLine("      }else{return true;}");
            writer.WriteLine("  }else{");
            writer.WriteLine("      var f = document.getElementById('" + dControls[TitleKey] + "').value;");
            writer.WriteLine("      if(f == \"\"){");
            writer.WriteLine("          alert('You must enter a Display Name');return false;");
            writer.WriteLine("      }else{return true;}");
            writer.WriteLine("  }");
            writer.WriteLine("}");
        }

        private static void RenderDisabledLookup(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

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

        private void RenderNewLocation(HtmlTextWriter writer, string newLocation, bool isDialog)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (list.BaseTemplate == SPListTemplateType.DocumentLibrary && ControlMode == SPControlMode.Edit)
            {
                writer.WriteLine(@"<script>
                    
                                            $(document).ready(function() {
                                                var button = $('input[id$=SaveItem]');
                                                button.removeAttr('onclick');
                                                button.click(function() {
                                                    var elementName = $(this).attr('name');
                                                    var aspForm = $('#aspnetForm');
                    
                                                    var editPostbackUrl = '" + Web.Url + ForwardSlash + list.Forms[PAGETYPE.PAGE_EDITFORM].Url + "?id=" + ListItem.ID + "&Source=" + HttpUtility.UrlEncode(Web.Url + "/_layouts/15/epmlive/getlastid.aspx?BackTo=" + HttpUtility.UrlEncode(newLocation) + "&listid=" + list.ID + ((isDialog) ? "&isdlg=1" : "")) + @"';
                    
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

                                var newPostbackUrl = '" + Web.Url + ForwardSlash + list.Forms[PAGETYPE.PAGE_NEWFORM].Url + "?Source=" + HttpUtility.UrlEncode(Web.Url + "/_layouts/15/epmlive/getlastid.aspx?BackTo=" + HttpUtility.UrlEncode(newLocation) + "&listid=" + list.ID + ((isDialog) ? "&isdlg=1" : "")) + @"';

                               if (!PreSaveItem()) return false;
                                if (SPClientForms.ClientFormManager.SubmitClientForm('WPQ2')) return false;

                                WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(elementName, '', true, '', newPostbackUrl, false, true));
                            });
                        });
                         </script>");
            }
        }
    }
}