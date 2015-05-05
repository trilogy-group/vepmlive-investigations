﻿namespace WorkEnginePPM.WebServices.Core
{
    internal enum APIError
    {
        Execute = 1000,
        ExecuteJSON,
        UploadFile,
        ScheduleDataImport,
        CollectDataImportResult,
        ReadPermissionGroups = 2000,
        UpdateResources,
        ReadResources,
        ReadResourcePermissionGroups,
        DeleteResourceCheck,
        DeleteResources,
        ReadResourceCostCategoryRole,
        GenerateDataTicket = 3000,
        PFEAdmin = 4000,
        UpdateDepartments,
        GetDepartments,
        DeleteDepartments,
        UpdateRoles,
        DeleteRoles,
        RefreshRoles,
        UpdateWorkSchedule,
        GetWorkSchedules,
        DeleteWorkSchedule,
        UpdateHolidaySchedules,
        GetHolidaySchedules,
        DeleteHolidaySchedules,
        UpdatePersonalItems,
        GetPersonalItems,
        DeletePersonalItems,
        UpdateResourceTimeOff,
        DeleteResourceTimeOff,
        PostTimesheetData,
        ExecuteReportExtract,
        UpdateScheduledWork,
        UpdateListWork,
        DeleteListWork,
        DeletePIListWork,
        GetCostCategoryRoles,
        SetDatabaseVersion,
        PostCostValues
    }
}
