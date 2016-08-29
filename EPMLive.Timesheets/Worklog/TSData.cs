using System;
using System.Data;

namespace TimeSheets
{
    public class TSData : EPMData
    {
        public int GetPeriodId(DateTime date, Guid siteid)
        {
            var row = GetPeriod(date, siteid);
            if (row == null)
                return 0;

            return (int) row["PERIOD_ID"];
        }

        public DataRow GetPeriod(DateTime date, Guid siteid)
        {
            AddParam("@Date", date.Date);
            AddParam("@site_id", siteid);
            Command =
                @"select [PERIOD_ID]
                  ,[PERIOD_START]
                  ,[PERIOD_END]
                  ,[LOCKED]
                  ,[SITE_ID]
                from [TSPERIOD]
                where @Date >= [PERIOD_START] and @Date <= [PERIOD_END] and site_id=@site_id";
            return GetRow();
        }

        public Guid? GetTimesheetId(int periodId, Guid siteId, string username)
        {
            var row = GetTimesheet(periodId, siteId, username);
            if(row == null)
                return null;

            return new Guid(row["TS_UID"].ToString());
        }

        public DataRow GetTimesheet(int periodId, Guid siteId, string username)
        {
            AddParam("@PeriodId", periodId);
            AddParam("@SiteId", siteId);
            AddParam("@UserName", username);
            Command =
                @"select [TS_UID]
                  ,[USERNAME]
                  ,[RESOURCENAME]
                  ,[PERIOD_ID]
                  ,[LOCKED]
                  ,[SITE_UID]
                  ,[SUBMITTED]
                  ,[APPROVAL_STATUS]
                  ,[APPROVAL_NOTES]
                  ,[LASTMODIFIEDBYU]
                  ,[LASTMODIFIEDBYN]
                  from [TSTIMESHEET]
                  where [USERNAME] = @UserName and [SITE_UID] = @SiteId and [PERIOD_ID] = @PeriodId";
            return GetRow();
        }

        /// <summary>
        /// Create new timesheet for this user in this period. Timesheet items from most recent period are copied over.
        /// </summary>
        public Guid? CreateTimesheet(string userName, string name, int periodId, Guid siteId)
        {
            Guid? timesheetId = Guid.NewGuid();
            AddParam("@TimesheetId", timesheetId);
            AddParam("@UserName", userName);
            AddParam("@Name", name);
            AddParam("@PeriodId", periodId);
            AddParam("@SiteId", siteId);
            Command = @"
                declare @LASTTSUID uniqueidentifier

                insert into [TSTIMESHEET]
                   ([TS_UID]
                   ,[USERNAME]
                   ,[RESOURCENAME]
                   ,[PERIOD_ID]
                   ,[LOCKED]
                   ,[SITE_UID]
                   ,[SUBMITTED]
                   ,[APPROVAL_STATUS]
                   ,[APPROVAL_NOTES]
                   ,[LASTMODIFIEDBYU]
                   ,[LASTMODIFIEDBYN])
                 values
                   (@TimesheetId
                   ,@UserName
                   ,@Name
                   ,@PeriodId
                   ,0
                   ,@SiteId
                   ,0
                   ,0
                   ,NULL
                   ,@UserName
                   ,@Name
                   )

                select
                    top 1 @LASTTSUID = t.TS_UID
                from TSITEM i
                join TSTIMESHEET t
                    on t.TS_UID = i.TS_UID
                where i.ITEM_TYPE = 1
                    and t.PERIOD_ID < @PeriodId
                    and t.USERNAME = @UserName
                order by t.PERIOD_ID desc


               IF (@LASTTSUID != NULL)
BEGIN
                insert into TSITEM
                select
                    @TimesheetId as TS_UID
                    ,NEWID() as TS_ITEM_UID
                    ,i.WEB_UID, i.LIST_UID
                    ,i.ITEM_TYPE
                    ,i.ITEM_ID
                    ,i.TITLE
                    ,i.PROJECT
                    ,i.PROJECT_ID
                    ,i.LIST
                    ,i.APPROVAL_STATUS
                    ,i.PROJECT_LIST_UID
                    ,NULL as AssignedToID
                from TSITEM i
                join TSTIMESHEET t
                    on t.TS_UID = i.TS_UID
                where i.ITEM_TYPE = 1
                    and t.TS_UID = @LASTTSUID
 END
                    ";
            return ExecuteNonQuery() ? timesheetId : null;

        }

        public Guid? GetTimesheetItemId(Guid timesheetId, Guid listId, int itemId)
        {
            var row = GetTimesheetItem(timesheetId, listId, itemId);
            if (row == null)
                return null;

            return new Guid(row["TS_ITEM_UID"].ToString());
        }

        public DataRow GetTimesheetItem(Guid timesheetId, Guid listId, int itemId)
        {
            AddParam("@TimesheetId", timesheetId);
            AddParam("@ListId", listId);
            AddParam("@ItemId", itemId);
            Command = 
                    @"select [TS_UID]
                      ,[TS_ITEM_UID]
                      ,[WEB_UID]
                      ,[LIST_UID]
                      ,[ITEM_TYPE]
                      ,[ITEM_ID]
                      ,[TITLE]
                      ,[PROJECT]
                      ,[PROJECT_ID]
                      ,[LIST]
                      ,[APPROVAL_STATUS]
                      from [TSITEM]
                      where [TS_UID] = @TimesheetId and [LIST_UID] = @ListId and [ITEM_ID] = @ItemId";
            return GetRow();
        }

        public Guid? CreateTimesheetItem(Guid timesheetId, Guid webId, Guid listId, int itemType, int itemId, string title, 
            string project, int projectId, string listName)
        {
            Guid? timesheetItemId = Guid.NewGuid();

            AddParam("@TimesheetId", timesheetId);
            AddParam("@TimesheetItemId", timesheetItemId);
            AddParam("@WebId", webId);
            AddParam("@ListId", listId);
            AddParam("@ItemType", itemType);
            AddParam("@ItemId", itemId);
            AddParam("@Title", title);
            AddParam("@Project", project);
            AddParam("@ProjectId", projectId);
            AddParam("@ListName", listName);
            AddParam("@Approval", 0);

            Command =
                @"insert into [TSITEM]
                   ([TS_UID]
                   ,[TS_ITEM_UID]
                   ,[WEB_UID]
                   ,[LIST_UID]
                   ,[ITEM_TYPE]
                   ,[ITEM_ID]
                   ,[TITLE]
                   ,[PROJECT]
                   ,[PROJECT_ID]
                   ,[LIST]
                   ,[APPROVAL_STATUS])
                 values
                   (@TimesheetId
                   ,@TimesheetItemId
                   ,@WebId
                   ,@ListId
                   ,@ItemType
                   ,@ItemId
                   ,@Title
                   ,@Project
                   ,@ProjectId
                   ,@ListName
                   ,@Approval)";
            return ExecuteNonQuery() ? timesheetItemId : null;
        }

        public bool InsertUpdateItemHours(Guid itemId, DateTime date, float hours, int type)
        {
            AddParam("@ItemId", itemId);
            AddParam("@Date", date.Date);
            AddParam("@Hours", hours);
            AddParam("@Type", type);
            Command =
                @"
                if(exists (
                select * from [TSITEMHOURS]
                  where [TS_ITEM_UID] = @ItemId 
                  and [TS_ITEM_DATE] = @Date
                  and [TS_ITEM_TYPE_ID] = @Type 
                ))
                begin
                  update [TSITEMHOURS]
                  set [TS_ITEM_HOURS] = @Hours, [TS_ITEM_TYPE_ID] = @Type
                  where [TS_ITEM_UID] = @ItemId and [TS_ITEM_DATE] = @Date and [TS_ITEM_TYPE_ID] = @Type
                end
                else
                begin
                  insert into [TSITEMHOURS] (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_HOURS, TS_ITEM_TYPE_ID)
                  values(@ItemId, @Date, @Hours, @Type)
                end ";
            return ExecuteNonQuery();
        }

        public DataTable GetWorkTypes(Guid siteId)
        {
            AddParam("@SiteId", siteId);
            Command =
                @"select [TSTYPE_ID]
                ,[SITE_UID]
                ,[TSTYPE_NAME]
                from [TSTYPE]
                where [SITE_UID] = @SiteId";
            return GetTable();
        }

        public bool InsertUpdateNotes(Guid itemId, DateTime date, string notes)
        {
            AddParam("@ItemId", itemId);
            AddParam("@Date", date);
            AddParam("@Notes", notes);
            Command =
                @"
                if(exists (
                select * from [TSNOTES]
                  where [TS_ITEM_UID] = @ItemId 
                  and [TS_ITEM_DATE] = @Date
                ))
                begin
                  update [TSNOTES]
                  set [TS_ITEM_NOTES] = @Notes
                  where [TS_ITEM_UID] = @ItemId and [TS_ITEM_DATE] = @Date
                end
                else
                begin
                  insert into [TSNOTES] (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_NOTES)
                  values(@ItemId, @Date, @Notes)
                end ";
            return ExecuteNonQuery();
        }

        /// <summary>
        /// Get a table of item hours by date for each type
        /// </summary>
        /// <param name="itemId">Timesheet ItemId</param>
        /// <param name="date">Date</param>
        public DataTable GetItemHoursByDate(Guid itemId, DateTime date)
        {
            AddParam("@ItemId", itemId);
            AddParam("@Date", date.Date);
            Command =
                @"select [TS_ITEM_UID]
                ,[TS_ITEM_HOURS]
                ,[TS_ITEM_TYPE_ID]
                ,[TS_UID]
                ,[USERNAME]
                ,[TS_ITEM_NOTES]
                from [vwTSItemHoursDetails]
                where [TS_ITEM_UID] = @ItemId and [TS_ITEM_DATE] = @Date";
            return GetTable();
        }

        /// <summary>
        /// Get hours for item, exclude this date so it can be totalled dynamically
        /// </summary>
        /// <param name="itemId">Timesheet ItemId</param>
        /// <param name="date">Date</param>
        public DataRow GetTotalItemHoursByDate(Guid itemId, DateTime date)
        {
            AddParam("@ItemId", itemId);
            AddParam("@Date", date.Date);
            Command = @"
                    select sum(h.TS_ITEM_HOURS) as WorkDone
                    from TSITEM i join tsitemhours h
                        on i.TS_ITEM_UID = h.TS_ITEM_UID
                    where i.TS_ITEM_UID = @ItemId
                        and h.TS_ITEM_DATE <> @Date
                    ";
            return GetRow();
        }

        /// <summary>
        /// Get hours for list item (for all users and timesheets)
        /// </summary>
        /// <param name="listId">ListId</param>
        /// <param name="listItemId">ItemId</param>
        public DataRow GetTotalListItemHours(Guid listId, int listItemId)
        {
            AddParam("@ListId", listId);
            AddParam("@ListItemId", listItemId);
            Command = @"
                    select  sum(h.TS_ITEM_HOURS) as WorkDone
                    from TSITEM i join tsitemhours h
                        on i.TS_ITEM_UID = h.TS_ITEM_UID
                    where i.LIST_UID = @ListId
                        and i.ITEM_ID = @ListItemId
                    ";
            return GetRow();
        }

        public DataRow GetDailyTotalByUser(string userName, DateTime date)
        {
            AddParam("@UserName", userName);
            AddParam("@Date", date);
            Command = @"
                    select  SUM(h.TS_ITEM_HOURS) as DailyWork
                    from TSITEM i join tsitemhours h
                        on i.TS_ITEM_UID = h.TS_ITEM_UID
                    join TSTIMESHEET t
                        on t.TS_UID = i.TS_UID
                    where t.USERNAME = @UserName
                        and h.TS_ITEM_DATE = @Date
                    ";
            return GetRow();
        }
    }
}