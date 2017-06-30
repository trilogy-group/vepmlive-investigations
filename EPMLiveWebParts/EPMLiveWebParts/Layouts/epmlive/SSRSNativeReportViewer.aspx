<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSRSNativeReportViewer.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.SSRSNativeReportViewer" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">

</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <link href="styles/NativeReportViewer/nativeviewer.css" rel="stylesheet" />    
    <script src="javascripts/nativeviewer.js"></script>

    <div id="ViewerDiv">
        <div id="upper">
	        <ul>
                <li class="dropdown">
                <a href="javascript:void(0)" class="dropbtn">Actions</a>
                <div class="dropdown-content">
                  <a href="javascript:OpenEditor()">Open with Report Builder</a>
                  <a href="javascript:OpenSubscriptions()">Subscriptions</a>
                </div>
              </li>
            </ul>
        </div>
        <iframe id="ReportFrame" width="100%" height="100%" src=""></iframe>
    </div>
    <div id="SubscribeManagerDiv" style="visibility:hidden">    
        <div id="upperSubscriptionManager">
	        <ul>
                <%--<li><a href="javascript:RedirectAddSubscription()">Add Subscription</a></li>
                <li><a href="javascript:void(0)">Add Data-Driven Subscription</a></li>--%>
                <li><a href="javascript:EnableDisableSubscription(true)" class="disabled" id="chkEnableSub">Enable</a></li>
                <li><a href="javascript:EnableDisableSubscription(false)" class="disabled" id="chkDisableSub">Disable</a></li>
                <li><a href="javascript:DeleteSubscription()" class="disabled" id="chkDeleteSub">Delete</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToViewer()">Back</a></li>
            </ul>
        </div>
        <div id="LoadingDiv">Loading Subscriptions...</div>
        <table id="SubscriptionsTable">
            <tr>
                <th><input type="checkbox" id="chkCheckAll" onclick="CheckAll()"></th>
                <th>Type</th>
                <th>Delivery Extension</th>
                <th>Description</th>
                <th>Status</th>
                <th>Last Run</th>
            </tr>
        </table>
    </div>
    <div id="AddSubscriptionForm" style="visibility:hidden">
        <div id="upperAddSubscription">
	        <ul>
                <li><a href="javascript:SaveSubscription()">Save</a></li>
                <li><a href="javascript:BackToSubsManager()">Cancel</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToSubsManager()">Back</a></li>
            </ul>
        </div>
        <table id="AddSubscriptionTable" style="width:100%;>
            <tr><td colspan="2"><p>Use this page to edit the delivery options for a subscription.</p></td></tr>
            <tr>
                <td><p>Description<br /><span>Specify a description for this subscription.</span></p></td>
                <td><input type="text" id="Description" name="Description"></td>
            </tr>
            <tr>
                <td><p>Delivery Extension *</p></td>
                <td>
                    <select id="DeliveryMethodOptions" onchange="ChangeDeliveryMethod()">
                      
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>Schedule</p><span>Deliver the report on the following schedule.</span></td>
                <td><a id="btnEditSchedule" href="javascript:EditSchedule()">Edit schedule</a></td>
            </tr>
        </table>
        <table id="WindowsFileDelMethod" style="visibility:collapse">
            <tr>
                <td><p>File Name *</p></td>
                <td><input type="text" id="FileName" name="FileName" required></td>
            </tr>
            <tr>
                <td><p>Path *</p></td>
                <td><input type="text" id="Path" name="Path" required></td>
            </tr>
            <tr>
                <td><p>User Name *</p></td>
                <td><input type="text" id="UserNameWindows" name="UserNameWindows"></td>
            </tr>
            <tr>
                <td><p>Password *</p></td>
                <td><input type="password" id="PasswordWindows" name="PasswordWindows"></td>
            </tr>
            <tr>
                <td><p>Render Format *</p></td>
                <td>
                    <select id="RenderFormat">
                        <option value="PDF">PDF</option>
                        <option value="WORD">Word</option>
                        <option value="EXCEL">Excel</option>
                        <option value="POWERPOINT">PowerPoint</option>
                        <option value="TIFF">TIFF file</option>
                        <option value="MHTML">MHTML (web archive)</option>
                        <option value="CSV">CSV (comma delimited)</option>
                        <option value="DATAFEED">Data Feed</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                   <p>File Extension<br /><span>Add a file extension when the file is created.</span></p>
                </td>
                <td>
                    <select id="FileExtensionAdd">
                        <option value="yes">YES</option>
                        <option value="no">NO</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>Overwrite options *</p></td>
                <td>
                    <input type="radio" name="overwriteoptions" value="Overwrite" checked>Overwrite an existing file with a newer version<br/>
                    <input type="radio" name="overwriteoptions" value="Donotoverwrite">Do not overwrite the file if a previous version exists<br/>
                    <input type="radio" name="overwriteoptions" value="Increment">Increment file names as newer versions are added
                </td>
            </tr>   
        </table>
        <br />
        <div id="ReportParameters"></div>
    </div>  
    <div id="EditScheduleForm" style="visibility:collapse">
        <div id="upperEditSchedule">
	        <ul>
                <li><a href="javascript:BackToSubsAdd()">Save</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToSubsAdd()">Back</a></li>
            </ul>
        </div>
        <h1>Schedule details</h1>
        <p>Choose whether to run the report on an hourly, daily, weekly, monthly, or one time basis.</p><br />
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('HourlySchedule')" value="hour" checked>Hour
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('DaylySchedule')" value="day">Day
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('WeeklySchedule')" value="week">Week
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('MonthlySchedule')" value="month">Month
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('OneTimeSchedule')" value="once">Once
        <br /><br />
        <div id="HourlySchedule">
            <h3>Hourly schedule</h3><br />
            Run the schedule every: <input type="text" id="HourlyScheduleHour" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> hours 
            <input type="text" id="HourlyScheduleMinutes" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> minutes
        </div>
        <div id="DaylySchedule" style="display:none">
            <h3>Daily schedule</h3><br />
            <input type="radio" name="dailyoptions" value="followingdays" checked>On the following days: 
            <input type="checkbox" value="Sun"/>Sun
            <input type="checkbox" value="Mon"/>Mon
            <input type="checkbox" value="Tue"/>Tue
            <input type="checkbox" value="Wed"/>Wed
            <input type="checkbox" value="Thu"/>Thu
            <input type="checkbox" value="Fri"/>Fri
            <input type="checkbox" value="Sat"/>Sat<br />
            <input type="radio" name="dailyoptions" value="weekdays">Every weekday <br />
            <input type="radio" name="dailyoptions" value="numbdays">Repeat after this number of days: <input type="text" id="RepeateNmbDays" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>
        </div>
        <div id="WeeklySchedule" style="display:none">
            <h3>Weekly schedule</h3><br />
            Repeat after this number of weeks: <input type="text" id="RepeateNmbWeeks" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/><br />
            On day(s):  
            <input type="checkbox" value="Sun"/>Sun
            <input type="checkbox" value="Mon"/>Mon
            <input type="checkbox" value="Tue"/>Tue
            <input type="checkbox" value="Wed"/>Wed
            <input type="checkbox" value="Thu"/>Thu
            <input type="checkbox" value="Fri"/>Fri
            <input type="checkbox" value="Sat"/>Sat<br />
        </div>
        <div id="MonthlySchedule" style="display:none">
            <h3>Monthly schedule</h3><br />
            Months: <br />
            <input type="checkbox" value="Sun"/>Jan
            <input type="checkbox" value="Mon"/>Feb
            <input type="checkbox" value="Tue"/>Mar
            <input type="checkbox" value="Wed"/>Apr
            <input type="checkbox" value="Thu"/>May
            <input type="checkbox" value="Fri"/>Jun<br />
            <input type="checkbox" value="Sat"/>Jul
            <input type="checkbox" value="Sat"/>Aug
            <input type="checkbox" value="Sat"/>Sep
            <input type="checkbox" value="Sat"/>Oct
            <input type="checkbox" value="Sat"/>Nov
            <input type="checkbox" value="Sat"/>Dec<br />
            
            <input type="radio" name="monthlyoptions" value="onweek" checked>On week of month:
            <select>
                <option value="1st">1st</option>
                <option value="2nd">2nd</option>
                <option value="3rd">3rd</option>
                <option value="4th">4th</option>
                <option value="last">Last</option>
            </select><br />
            &nbsp&nbsp&nbsp On day of week: <input type="checkbox" value="Sun"/>Sun
            <input type="checkbox" value="Mon"/>Mon
            <input type="checkbox" value="Tue"/>Tue
            <input type="checkbox" value="Wed"/>Wed
            <input type="checkbox" value="Thu"/>Thu
            <input type="checkbox" value="Fri"/>Fri
            <input type="checkbox" value="Sat"/>Sat<br />
            <input type="radio" name="monthlyoptions" value="onweek">On calendar day(s): <input type="text" id="OnCalendarDays" 
                style="width:40px" onkeypress='return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 44 || event.charCode == 45'/>
        </div>
        <div id="OneTimeSchedule" style="display:none">
            <h3>One-time schedule</h3><br />
            Schedule runs only once.<br />
        </div>
        <br /><br />
        Start Time: <input type="text" id="StarTimeHour" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>: 
            <input type="text" id="StarTimeMinutes" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> minutes
        <input type="radio" name="starttimeampm" value="am" checked>AM
        <input type="radio" name="starttimeampm" value="pm">PM
    </div>

</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Application Page
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
My Application Page
</asp:content>
