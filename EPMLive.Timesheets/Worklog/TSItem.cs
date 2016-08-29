using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using EPMLibrary;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public class TSItem : TSBiz
    {
        private const int ItemType = 1; //Work (1= Non-work)

        private readonly DateTime _date;
        private readonly SPList _list;
        private readonly SPListItem _listItem;
        private readonly int _periodId;
        private readonly Guid _siteId;
        private readonly bool _validDay = true;
        private float _workAllocated;
        private float _workDoneListItem;
        private float _workDoneTSItem;
        private float _workDoneUser;
        private bool _allowNotes;
        private bool _allowUnassigned;
        private bool _authorized = true;
        private DaySettings _daySettings;
        private bool _isTSList;
        private bool _isTSChecked;
        private string _notes;
        private Guid? _timesheetId;
        private Guid? _timesheetItemId;
        private Dictionary<int, float> _work = new Dictionary<int, float>();
        private float _workNew;
        private DataView _delegateFor;
        private SPWeb _web;
        private string _userLoginName;
        private string _userName;

        public TSItem(Guid listId, int listItemId, DateTime date, string userLoginName, string userName)
        {
            _date = date;
            var site = SPContext.Current.Site;
            _siteId = site.ID;
            var rootWeb = site.RootWeb;
            _web = SPContext.Current.Web;
            _userLoginName = userLoginName;
            _userName = userName;
            _list = _web.Lists[listId];
            _listItem = _list.GetItemById(listItemId);

            // Get EPMLive settings
            PopulateSettings(rootWeb);

            // Check user is assigned if AllowUnassigned not set
            if (!_allowUnassigned)
            {
                CheckAssignedTo();
                if (!_authorized)
                    return;
            }

            // Check list is set-up for timesheets
            if (!CheckList(rootWeb))
                return;

            // Check date falls within a period
            _periodId = TSData.GetPeriodId(_date, _siteId);
            if (_periodId == 0)
                return;

            // Check current day-of-week is allowed
            if (!_daySettings.GetDaySetting(date).Allowed)
            {
                _validDay = false;
                return;
            }

            PopulateWorkTotals();

            // Get TimesheetId if timesheet exists
            _timesheetId = TSData.GetTimesheetId(_periodId, _siteId, _userLoginName);
            if (!_timesheetId.HasValue)
                return;

            // Get TimeSheetItemId if timesheet item exists
            _timesheetItemId = TSData.GetTimesheetItemId(_timesheetId.Value, _list.ID, _listItem.ID);
            if (!_timesheetItemId.HasValue)
                return;

            PopulateExistingWorkAndNotes();
        }

        // Get existing hours and work totals
        private void PopulateExistingWorkAndNotes()
        {
            var rows = TSData.GetItemHoursByDate(_timesheetItemId.Value, _date).Rows;
            _work.Clear();
            foreach (DataRow row in rows)
            {
                _work.Add(int.Parse(row["TS_ITEM_TYPE_ID"].ToString()), float.Parse(row["TS_ITEM_HOURS"].ToString()));
            }
            if (rows.Count > 0)
                _notes = rows[0]["TS_ITEM_NOTES"].ToString();

            var workdoneTSItem = TSData.GetTotalItemHoursByDate(_timesheetItemId.Value, _date);
            if (workdoneTSItem != null)
            {
                var obj = workdoneTSItem["WorkDone"];
                float f;
                if (float.TryParse(obj.ToString(), out f))
                    _workDoneTSItem = f;
            }
        }

        private void PopulateWorkTotals()
        {
            // Get Work from List if it exists
            if (_list.Fields.ContainsField("Work") && _listItem["Work"] != null)
            {
                var obj = _listItem["Work"];
                float f;
                if (float.TryParse(obj.ToString(), out f))
                    _workAllocated = f;
            }

            // Get total work for this item from all users
            var workdoneListItem = TSData.GetTotalListItemHours(_list.ID, _listItem.ID);
            if (workdoneListItem != null)
            {
                var obj = workdoneListItem["WorkDone"];
                float f;
                if (float.TryParse(obj.ToString(), out f))
                    _workDoneListItem = f;
            }

            // Get total work for this user on this date
            var workdoneUser = TSData.GetDailyTotalByUser(_userLoginName, _date);
            if (workdoneUser != null)
            {
                var obj = workdoneUser["DailyWork"];
                float f;
                if (float.TryParse(obj.ToString(), out f))
                    _workDoneUser = f;
            }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public Dictionary<int, float> Work
        {
            get { return _work; }
            set { _work = value; }
        }

        public float WorkAllocated
        {
            get { return _workAllocated; }
        }

        public float WorkDoneTSItem
        {
            get { return _workDoneTSItem; }
        }

        public float WorkDoneListItem
        {
            get { return _workDoneListItem; }
        }

        public float WorkDoneUser
        {
            get { return _workDoneUser; }
        }

        public float WorkNew
        {
            get { return _workNew; }
        }

        public bool WorkNewHoursValid
        {
            get { return _workNew <= Max && _workNew >= Min; }
        }

        public bool AllowNotes
        {
            get { return _allowNotes; }
        }

        public bool AllowUnassigned
        {
            get { return _allowUnassigned; }
        }

        public bool Authorized
        {
            get { return _authorized; }
        }

        public DaySettings DaySettings
        {
            get { return _daySettings; }
        }

        public int Min
        {
            get { return DaySettings.GetDaySetting(_date).Min; }
        }

        public int Max
        {
            get { return DaySettings.GetDaySetting(_date).Max; }
        }

        public bool ValidDay
        {
            get { return _validDay; }
        }

        public bool IsTSList
        {
            get { return _isTSList; }
        }

        public bool IsTSChecked
        {
            get { return _isTSChecked; }
        }

        public Dictionary<int, TextBox> WorkFromInput
        {
            set
            {
                _workNew = 0;
                _work.Clear();
                foreach (KeyValuePair<int, TextBox> tb in value)
                {
                    float hours;
                    if (float.TryParse(tb.Value.Text, out hours))
                    {
                        _work.Add(tb.Key, hours);
                        _workNew += hours;
                    }
                }
            }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public int PeriodId
        {
            get { return _periodId; }
        }

        public SPList List
        {
            get { return _list; }
        }

        public bool DelegateForExists
        {
            get { return _delegateFor.Count > 0; }
        }

        public SPListItem ListItem
        {
            get { return _listItem; }
        }

        public int PercentageSpent
        {
            get
            {
                if (_workDoneTSItem > _workAllocated)
                    return 100;
                if (_workDoneTSItem > 0 && _workAllocated > 0)
                    return (int) (_workDoneTSItem/_workAllocated*100);
                return 0;
            }
        }

        private void CheckAssignedTo()
        {
            _authorized = false;

            if (!_list.Fields.ContainsField("AssignedTo") || _listItem["AssignedTo"] == null)
                return;

            string currentValue = _listItem["AssignedTo"].ToString();
            var field = (SPFieldUser) _list.Fields.GetFieldByInternalName("AssignedTo");
            var fieldValues = field.GetFieldValue(currentValue);
            if (fieldValues is SPFieldUserValueCollection)
                // Multiple Users
                foreach (SPFieldUserValue userValue in fieldValues as SPFieldUserValueCollection)
                {
                    if (userValue.User.LoginName == _userLoginName)
                        _authorized = true;
                }
            else if (fieldValues is SPFieldUserValue)
            {
                // Single User
                if ((fieldValues as SPFieldUserValue).User.LoginName == _userLoginName)
                    _authorized = true;
            }
        }

        private void PopulateSettings(SPWeb rweb)
        {
            var allowNotes = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowNotes");
            _allowNotes = (allowNotes.Trim().ToLower() == "true");

            var allowUnassigned = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowUnassigned");
            _allowUnassigned = (allowUnassigned.Trim().ToLower() == "true");

            _daySettings = new DaySettings(rweb);
        }

        private bool CheckList(SPWeb rweb)
        {
            var tsLists = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSLists");
            if (!_list.Fields.ContainsField("Timesheet") || _listItem["Timesheet"] == null)
                return false;

            if (!bool.TryParse(_listItem["Timesheet"].ToString(), out _isTSChecked))
                return false;

            bool goodList = false;
            foreach (string list in tsLists.Replace("\r\n",",").Split(','))
            {
                if (list.ToLower() == _list.Title.ToLower())
                {
                    goodList = true;
                    break;
                }
            }
            _isTSList = goodList;
            //_isTSList = _isTSList && tsLists.ToLower().Contains(_list.Title.ToLower());
            return _isTSList;
        }

        public bool Update()
        {
            Guid webId = SPContext.Current.Web.ID;

            if (!_timesheetId.HasValue)
            {
                // Create new timesheet
                _timesheetId = TSData.CreateTimesheet(_userLoginName, _userName, _periodId, _siteId);
            }
            if (!_timesheetItemId.HasValue)
            {
                // Create new timesheetId
                var project = "";
                int projectId = 0;
                if (_list.Fields.ContainsField("Project"))
                {
                    var lv = new SPFieldLookupValue(_listItem["Project"].ToString());
                    project = lv.LookupValue;
                    projectId = lv.LookupId;
                }
                _timesheetItemId = TSData.CreateTimesheetItem(_timesheetId.Value, webId, _list.ID, ItemType, _listItem.ID, _listItem.Title, project, projectId, _list.Title);
            }

            bool success = true;
            foreach (KeyValuePair<int, float> work in _work)
            {
                success = success &&
                          TSData.InsertUpdateItemHours(_timesheetItemId.Value, _date, work.Value, work.Key);
            }
            success = success &&
                   TSData.InsertUpdateNotes(_timesheetItemId.Value, _date, _notes);

            PopulateWorkTotals();
            PopulateExistingWorkAndNotes();

            return success;
        }

        public static Dictionary<int, string> GetWorkTypes(Guid siteId)
        {
            var tsd = new TSData();
            var workTypes = new Dictionary<int, string>();
            var table = tsd.GetWorkTypes(siteId);
            foreach (DataRow row in table.Rows)
            {
                workTypes.Add((int) row["TSTYPE_ID"], row["TSTYPE_NAME"].ToString());
            }
            return workTypes;
        }

        public static void GetDelegateFor(DropDownList ddl, SPWeb web, SPUser user)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                var resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                DataView delegateFor = new DataView();
                //using ()
                //var resWeb = Utility.GetResWeb(resUrl, web);

                using(SPSite site = new SPSite(resUrl))
                {
                    using(SPWeb resWeb = site.OpenWeb())
                    {
                        SPList resList = Utility.GetResList(resWeb);

                        foreach (SPListItem li in resList.Items)
                        {
                            if (li["TimesheetDelegates"] != null)
                            {
                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(resWeb, li["TimesheetDelegates"].ToString());
                                foreach (SPFieldUserValue uv in uvc)
                                {
                                    if (uv.User.LoginName == user.LoginName)
                                    {
                                        if (li["SharePointAccount"] != null)
                                        {
                                            SPFieldUserValue uvsp = new SPFieldUserValue(resWeb, li["SharePointAccount"].ToString());
                                            ddl.Items.Add(new ListItem(uvsp.User.Name, uvsp.User.LoginName));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        public static void PopulateDDLUsers(DropDownList ddl, SPWeb web, SPUser user)
        {
            ddl.Items.Add(new ListItem(user.Name, user.LoginName));


            GetDelegateFor(ddl, web, user);

            //foreach (DataRowView df in GetDelegateFor(web, user))
            //{
            //    var fuv = new SPFieldUserValue(web, df["SharePointAccount"].ToString());
            //    if (fuv.User != null)
            //        ddl.Items.Add(new ListItem(fuv.User.Name, fuv.User.LoginName));
            //}
        }
    }
}