using EPMLiveCore;
using EPMLiveCore.API;

namespace TimeSheets
{
    internal class MyTimesheetProperties
    {
        internal string FullGridId { get; set; }
        internal string DataParam { get; set; } = string.Empty;
        internal string LayoutParam { get; set; } = string.Empty;
        internal string PeriodId { get; set; } = string.Empty;
        internal string PeriodName { get; set; } = string.Empty;
        internal string PeriodList { get; set; } = string.Empty;
        internal int ColumnType { get; set; } = 1;
        internal string Notes { get; set; } = "false";
        internal string TypeObject { get; set; } = string.Empty;
        internal string Columns { get; set; } = string.Empty;
        internal string DataColumns { get; set; } = string.Empty;
        internal bool IsCurrentTimesheetPeriod { get; set; } = false;
        internal int CurrentPeriodId { get; set; } = 0;
        internal string CurrentPeriodName { get; set; } = string.Empty;
        internal bool IsLocked { get; set; } = false;
        internal string Status { get; set; } = "Unsubmitted";
        internal string Delegates { get; set; } = string.Empty;
        internal string DelegateId { get; set; } = string.Empty;
        internal string UserId { get; set; } = string.Empty;
        internal string CurrentDelegate { get; set; } = string.Empty;
        internal int Editable { get; set; } = 1;
        internal TimesheetSettings Settings { get; set; }
        internal int NextPeriodId { get; set; } = 0;
        internal int PreviousPeriodId { get; set; } = 0;
        internal ViewManager Views { get; set; }
        internal string CurrentView { get; set; } = string.Empty;
        internal string CurrentViewId { get; set; } = string.Empty;
        internal Act Act { get; set; }
        internal int Activation { get; set; } = 0;
        internal bool HasPeriods { get; set; } = false;
        internal bool CanEditViews { get; set; } = false;
        internal int GridType { get; set; } = 0;
        internal string Url { get; set; }
        internal string CurrentUrl { get; set; }
        internal string RelativeUrl { get; set; }
        internal string Qualifier { get; set; }
    }
}
