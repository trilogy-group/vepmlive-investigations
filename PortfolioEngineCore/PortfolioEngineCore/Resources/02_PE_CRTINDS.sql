/****************************************************************************************************
**   Copyright 2012 EPM Live
**
**   Filename  : 02_PE_CRTINDS.SQL
**
**   This script will create the PortfolioEngine SQL Server table indexes
**
**   Privileges needed: member of db_owner or db_ddladmin
**
****************************************************************************************************/
-- Drop existing indexes --

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_DELEGATES'), N'I_EPG_DELEGATES', N'IndexId')) is not null
DROP INDEX dbo.EPG_DELEGATES.I_EPG_DELEGATES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_EXT_MAPPING'), N'I_EPG_EXT_MAPPING', N'IndexId')) is not null
DROP INDEX dbo.EPG_EXT_MAPPING.I_EPG_EXT_MAPPING


--IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_MEMBERS'), N'I_EPG_GROUP_MEMBERS', N'IndexId')) is not null
--DROP INDEX dbo.EPG_GROUP_MEMBERS.I_EPG_GROUP_MEMBERS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_NONWORK_HOURS'), N'I_EPG_GROUP_NONWORK_HOURS', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_NONWORK_HOURS.I_EPG_GROUP_NONWORK_HOURS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_NONWORK_ITEMS'), N'I_EPG_GROUP_NONWORK_ITEMS', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_NONWORK_ITEMS.I_EPG_GROUP_NONWORK_ITEMS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_PERMISSIONS'), N'I_EPG_GROUP_PERMISSIONS', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_PERMISSIONS.I_EPG_GROUP_PERMISSIONS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_TSLIMITS'), N'I_EPG_GROUP_TSLIMITS', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_TSLIMITS.I_EPG_GROUP_TSLIMITS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_WEEKLYHOURS'), N'I_EPG_GROUP_WEEKLYHOURS', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_WEEKLYHOURS.I_EPG_GROUP_WEEKLYHOURS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUPS'), N'I_EPG_GROUPS', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUPS.I_EPG_GROUPS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_JOB_MSGS'), N'I_EPG_JOB_MSGS', N'IndexId')) is not null
DROP INDEX dbo.EPG_JOB_MSGS.I_EPG_JOB_MSGS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_JOBS'), N'I_EPG_JOBS', N'IndexId')) is not null
DROP INDEX dbo.EPG_JOBS.I_EPG_JOBS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_MSP_FIELDS'), N'I_EPG_MSP_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPG_MSP_FIELDS.I_EPG_MSP_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_MY_RESOURCES'), N'I_EPG_MY_RESOURCES', N'IndexId')) is not null
DROP INDEX dbo.EPG_MY_RESOURCES.I_EPG_MY_RESOURCES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_NONWORK_HOURS'), N'I_EPG_NONWORK_HOURS', N'IndexId')) is not null
DROP INDEX dbo.EPG_NONWORK_HOURS.I_EPG_NONWORK_HOURS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_NONWORK_ITEMS'), N'I_EPG_NONWORK_ITEMS', N'IndexId')) is not null
DROP INDEX dbo.EPG_NONWORK_ITEMS.I_EPG_NONWORK_ITEMS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_NOTE_THREADS'), N'I_EPG_NOTE_THREADS', N'IndexId')) is not null
DROP INDEX dbo.EPG_NOTE_THREADS.I_EPG_NOTE_THREADS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_NOTES'), N'I_EPG_NOTES', N'IndexId')) is not null
DROP INDEX dbo.EPG_NOTES.I_EPG_NOTES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_PERIODS'), N'I_EPG_PERIODS', N'IndexId')) is not null
DROP INDEX dbo.EPG_PERIODS.I_EPG_PERIODS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_PERMISSIONS'), N'I_EPG_PERMISSIONS', N'IndexId')) is not null
DROP INDEX dbo.EPG_PERMISSIONS.I_EPG_PERMISSIONS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_PROJ_TASKS'), N'I_EPG_PROJ_TASKS', N'IndexId')) is not null
DROP INDEX dbo.EPG_PROJ_TASKS.I_EPG_PROJ_TASKS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_RD_VIEWS'), N'I_EPG_RD_VIEWS', N'IndexId')) is not null
DROP INDEX dbo.EPG_RD_VIEWS.I_EPG_RD_VIEWS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_RESOURCES'), N'I_EPG_RESOURCES', N'IndexId')) is not null
DROP INDEX dbo.EPG_RESOURCES.I_EPG_RESOURCES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_SHORTCUTS'), N'I_EPG_SHORTCUTS', N'IndexId')) is not null
DROP INDEX dbo.EPG_SHORTCUTS.I_EPG_SHORTCUTS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_SITEMAP'), N'I_EPG_SITEMAP', N'IndexId')) is not null
DROP INDEX dbo.EPG_SITEMAP.I_EPG_SITEMAP


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_SYSTEM_COLORS'), N'I_EPG_SYSTEM_COLORS', N'IndexId')) is not null
DROP INDEX dbo.EPG_SYSTEM_COLORS.I_EPG_SYSTEM_COLORS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TASKSTATUS'), N'I_EPG_TASKSTATUS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TASKSTATUS.I_EPG_TASKSTATUS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_ACTUALHOURS'), N'I_EPG_TS_ACTUALHOURS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_ACTUALHOURS.I_EPG_TS_ACTUALHOURS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_ADJUSTMENTHOURS'), N'I_EPG_TS_ADJUSTMENTHOURS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_ADJUSTMENTHOURS.I_EPG_TS_ADJUSTMENTHOURS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_ADJUSTMENTS'), N'I_EPG_TS_ADJUSTMENTS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_ADJUSTMENTS.I_EPG_TS_ADJUSTMENTS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_APPROVERS'), N'I_EPG_TS_APPROVERS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_APPROVERS.I_EPG_TS_APPROVERS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_CATEGORY_VALUES'), N'I_EPG_TS_CATEGORY_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_CATEGORY_VALUES.I_EPG_TS_CATEGORY_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_CHARGES'), N'I_EPG_TS_CHARGES', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_CHARGES.I_EPG_TS_CHARGES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_CHARGES'), N'IX_EPG_TS_CHARGES', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_CHARGES.IX_EPG_TS_CHARGES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_CHARGES'), N'IXX_EPG_TS_CHARGES', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_CHARGES.IXX_EPG_TS_CHARGES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_DEPTS'), N'I_EPG_TS_DEPTS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_DEPTS.I_EPG_TS_DEPTS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_PROGRESS'), N'I_EPG_TS_PROGRESS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_PROGRESS.I_EPG_TS_PROGRESS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_TS_TIMESHEETS'), N'I_EPG_TS_TIMESHEETS', N'IndexId')) is not null
DROP INDEX dbo.EPG_TS_TIMESHEETS.I_EPG_TS_TIMESHEETS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_USERINFO'), N'I_EPG_USERINFO', N'IndexId')) is not null
DROP INDEX dbo.EPG_USERINFO.I_EPG_USERINFO


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_VIEW_FIELDS'), N'I_EPG_VIEW_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPG_VIEW_FIELDS.I_EPG_VIEW_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGC_RESOURCE_MV_VALUES'), N'I_EPGC_RESOURCE_MV_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGC_RESOURCE_MV_VALUES.I_EPGC_RESOURCE_MV_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_AVAIL_CATEGORIES'), N'I_EPGP_AVAIL_CATEGORIES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_AVAIL_CATEGORIES.I_EPGP_AVAIL_CATEGORIES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COMMITMENTS'), N'I_EPGP_COMMITMENTS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COMMITMENTS.I_EPGP_COMMITMENTS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COMMITMENTS'), N'I_EPGP_COMMITMENTS_01', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COMMITMENTS.I_EPGP_COMMITMENTS_01


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_RESOURCEPLANS'), N'I_EPG_RESOURCEPLANS', N'IndexId')) is not null
DROP INDEX dbo.EPG_RESOURCEPLANS.I_EPG_RESOURCEPLANS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_RESOURCEPLANS'), N'I_EPG_RESOURCEPLANS_01', N'IndexId')) is not null
DROP INDEX dbo.EPG_RESOURCEPLANS.I_EPG_RESOURCEPLANS_01


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_RESOURCEPLANS_HOURS'), N'I_EPG_RESOURCEPLANS_HOURS', N'IndexId')) is not null
DROP INDEX dbo.EPG_RESOURCEPLANS_HOURS.I_EPG_RESOURCEPLANS_HOURS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_BREAKDOWN_ATTRIBS'), N'I_EPGP_COST_BREAKDOWN_ATTRIBS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_BREAKDOWN_ATTRIBS.I_EPGP_COST_BREAKDOWN_ATTRIBS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_BREAKDOWNS'), N'I_EPGP_COST_BREAKDOWNS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_BREAKDOWNS.I_EPGP_COST_BREAKDOWNS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_CALC'), N'I_EPGP_COST_CALC', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_CALC.I_EPGP_COST_CALC


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_CATEGORIES'), N'I_EPGP_CATEGORIES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_CATEGORIES.I_EPGP_CATEGORIES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_CATEGORIES'), N'I_EPGP_COST_CATEGORIES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_CATEGORIES.I_EPGP_COST_CATEGORIES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_CATEGORIES'), N'I_EPGP_COST_CATEGORIES_BC_UID', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_CATEGORIES.I_EPGP_COST_CATEGORIES_BC_UID


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_CUSTOM_FIELDS'), N'I_EPGP_COST_CUSTOM_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_CUSTOM_FIELDS.I_EPGP_COST_CUSTOM_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_DETAILS'), N'I_EPGP_COST_DETAILS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_DETAILS.I_EPGP_COST_DETAILS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_DETAIL_VALUES'), N'I_EPGP_DETAIL_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_DETAIL_VALUES.I_EPGP_DETAIL_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_MODEL_COST_DETAILS'), N'I_EPGP_MODEL_COST_DETAILS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_MODEL_COST_DETAILS.I_EPGP_MODEL_COST_DETAILS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_MODEL_DETAIL_VALUES'), N'I_EPGP_MODEL_DETAIL_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_MODEL_DETAIL_VALUES.I_EPGP_MODEL_DETAIL_VALUES



IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_TYPES'), N'I_EPGP_COST_TYPES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_TYPES.I_EPGP_COST_TYPES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_TYPES'), N'I_EPGP_COST_TYPES_Name', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_TYPES.I_EPGP_COST_TYPES_Name


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_VALUES'), N'I_EPGP_COST_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_VALUES.I_EPGP_COST_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_VALUES'), N'I_EPGP_COST_VALUES_01', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_VALUES.I_EPGP_COST_VALUES_01


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_VALUES'), N'I_EPGP_COST_BC_UID', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_VALUES.I_EPGP_COST_BC_UID


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_VALUES'), N'I_EPGP_COST_CT_ID', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_VALUES.I_EPGP_COST_CT_ID


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_VALUES_INFO'), N'I_EPGP_COST_VALUES_INFO', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_VALUES_INFO.I_EPGP_COST_VALUES_INFO


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_COST_XREF'), N'I_EPGP_COST_XREF', N'IndexId')) is not null
DROP INDEX dbo.EPGP_COST_XREF.I_EPGP_COST_XREF


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_LAYOUT_FIELDS'), N'I_EPGP_LAYOUT_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_LAYOUT_FIELDS.I_EPGP_LAYOUT_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_LAYOUT_GROUPS'), N'I_EPGP_LAYOUT_GROUPS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_LAYOUT_GROUPS.I_EPGP_LAYOUT_GROUPS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_LAYOUT_PAGES'), N'I_EPGP_LAYOUT_PAGES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_LAYOUT_PAGES.I_EPGP_LAYOUT_PAGES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_LOOKUP_TABLES'), N'I_EPGP_LOOKUP_TABLES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_LOOKUP_TABLES.I_EPGP_LOOKUP_TABLES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_LOOKUP_VALUES'), N'I_EPGP_LOOKUP_VALUES_1', N'IndexId')) is not null
DROP INDEX dbo.EPGP_LOOKUP_VALUES.I_EPGP_LOOKUP_VALUES_1


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_LOOKUP_VALUES'), N'I_EPGP_LOOKUP_VALUES_2', N'IndexId')) is not null
DROP INDEX dbo.EPGP_LOOKUP_VALUES.I_EPGP_LOOKUP_VALUES_2


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PI_PROGS'), N'I_EPGP_PI_PROGS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PI_PROGS.I_EPGP_PI_PROGS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PI_PROGS_FISCAL'), N'I_EPGP_PI_PROGS_FISCAL', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PI_PROGS_FISCAL.I_EPGP_PI_PROGS_FISCAL


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PI_WORKITEM_LOGIC'), N'I_EPGP_PI_WORKITEM_LOGIC', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PI_WORKITEM_LOGIC.I_EPGP_PI_WORKITEM_LOGIC


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PI_WORKITEM_TSWORK'), N'I_EPGP_PI_WORKITEM_TSWORK', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PI_WORKITEM_TSWORK.I_EPGP_PI_WORKITEM_TSWORK


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROG_DATE_VALUES'), N'I_EPGP_PROG_DATE_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROG_DATE_VALUES.I_EPGP_PROG_DATE_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROG_DEC_VALUES'), N'I_EPGP_PROG_DEC_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROG_DEC_VALUES.I_EPGP_PROG_DEC_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROG_INFOS'), N'I_EPGP_PROG_INFOS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROG_INFOS.I_EPGP_PROG_INFOS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROG_INT_VALUES'), N'I_EPGP_PROG_INT_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROG_INT_VALUES.I_EPGP_PROG_INT_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROG_NTEXT_VALUES'), N'I_EPGP_PROG_NTEXT_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROG_NTEXT_VALUES.I_EPGP_PROG_NTEXT_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROG_TEXT_VALUES'), N'I_EPGP_PROG_TEXT_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROG_TEXT_VALUES.I_EPGP_PROG_TEXT_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROJECT_CT_STATUS'), N'I_EPGP_PROJECT_CT_STATUS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROJECT_CT_STATUS.I_EPGP_PROJECT_CT_STATUS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROJECT_CT_STATUS'), N'I_EPGP_PROJECT_CT_STATUS_01', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROJECT_CT_STATUS.I_EPGP_PROJECT_CT_STATUS_01


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROJECT_GROUP_SECURITY'), N'I_EPGP_PROJECT_GROUP_SECURITY', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROJECT_GROUP_SECURITY.I_EPGP_PROJECT_GROUP_SECURITY


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROJECT_RESOURCE_SECURITY'), N'I_EPGP_PROJECT_RESOURCE_SECURITY', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROJECT_RESOURCE_SECURITY.I_EPGP_PROJECT_RESOURCE_SECURITY


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_PROJECT_STAGES'), N'I_EPGP_PROJECT_STAGES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_PROJECT_STAGES.I_EPGP_PROJECT_STAGES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_RATE_TYPES'), N'I_EPGP_RATE_TYPES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_RATE_TYPES.I_EPGP_RATE_TYPES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_RD_FIELDS'), N'I_EPGP_RD_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_RD_FIELDS.I_EPGP_RD_FIELDS

if EXISTS(select * from sys.indexes where name = 'I_EPGP_RP_CATEGORY_VALUES')
begin
DROP INDEX dbo.EPGP_RP_CATEGORY_VALUES.I_EPGP_RP_CATEGORY_VALUES
end

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_STAGE_FIELDS'), N'I_EPGP_STAGE_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_STAGE_FIELDS.I_EPGP_STAGE_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_STAGES'), N'I_EPGP_STAGES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_STAGES.I_EPGP_STAGES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_MODEL_TARGET_DETAILS'), N'I_EPGP_MODEL_TARGET_DETAILS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_MODEL_TARGET_DETAILS.I_EPGP_MODEL_TARGET_DETAILS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_MODEL_TARGET_VALUES'), N'I_EPGP_MODEL_TARGET_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_MODEL_TARGET_VALUES.I_EPGP_MODEL_TARGET_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_MODEL_TARGETS'), N'I_EPGP_MODEL_TARGETS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_MODEL_TARGETS.I_EPGP_MODEL_TARGETS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_VERSIONS'), N'I_EPGP_VERSIONS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_VERSIONS.I_EPGP_VERSIONS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_WI_FRAGMENT_LOGIC'), N'I_EPGP_WI_FRAGMENT_LOGIC', N'IndexId')) is not null
DROP INDEX dbo.EPGP_WI_FRAGMENT_LOGIC.I_EPGP_WI_FRAGMENT_LOGIC


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_WSS_LISTS'), N'I_EPGP_WSS_LISTS', N'IndexId')) is not null
DROP INDEX dbo.EPGP_WSS_LISTS.I_EPGP_WSS_LISTS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_FIELDS'), N'I_EPGT_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGT_FIELDS.I_EPGT_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_LOCALVIEWS'), N'I_EPGT_LOCALVIEWS', N'IndexId')) is not null
DROP INDEX dbo.EPGT_LOCALVIEWS.I_EPGT_LOCALVIEWS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_RES_FIELDS'), N'I_EPGT_RES_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGT_RES_FIELDS.I_EPGT_RES_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_USERBUTTONS'), N'I_EPGT_USERBUTTONS', N'IndexId')) is not null
DROP INDEX dbo.EPGT_USERBUTTONS.I_EPGT_USERBUTTONS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_BAR'), N'I_EPGT_VIEW_BAR', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_BAR.I_EPGT_VIEW_BAR


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_BUDSPEC'), N'I_EPGT_VIEW_BUDSPEC', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_BUDSPEC.I_EPGT_VIEW_BUDSPEC


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_BUDSPEC_BAND'), N'I_EPGT_VIEW_BUDSPEC_BAND', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_BUDSPEC_BAND.I_EPGT_VIEW_BUDSPEC_BAND


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_COSTVIEW_COST_TYPES'), N'I_EPGT_COSTVIEW_COST_TYPES', N'IndexId')) is not null
DROP INDEX dbo.EPGT_COSTVIEW_COST_TYPES.I_EPGT_COSTVIEW_COST_TYPES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_DISPLAY'), N'I_EPGT_VIEW_DISPLAY', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_DISPLAY.I_EPGT_VIEW_DISPLAY


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_FIELDS'), N'I_EPGT_VIEW_FIELDS', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_FIELDS.I_EPGT_VIEW_FIELDS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_FILTERS'), N'I_EPGT_VIEW_FILTERS', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_FILTERS.I_EPGT_VIEW_FILTERS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_GANTT'), N'I_EPGT_VIEW_GANTT', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_GANTT.I_EPGT_VIEW_GANTT


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_GRAPHIND'), N'I_EPGT_VIEW_GRAPHIND', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_GRAPHIND.I_EPGT_VIEW_GRAPHIND


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_GRAPHIND_RULES'), N'I_EPGT_VIEW_GRAPHIND_RULES', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_GRAPHIND_RULES.I_EPGT_VIEW_GRAPHIND_RULES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_GROUP'), N'I_EPGT_VIEW_GROUP', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_GROUP.I_EPGT_VIEW_GROUP


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_GROUP_LEVEL'), N'I_EPGT_VIEW_GROUP_LEVEL', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_GROUP_LEVEL.I_EPGT_VIEW_GROUP_LEVEL


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_MILESTONE'), N'I_EPGT_VIEW_MILESTONE', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_MILESTONE.I_EPGT_VIEW_MILESTONE


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_DATA_SECURITY'), N'I_EPGP_DATA_SECURITY', N'IndexId')) is not null
DROP INDEX dbo.EPGP_DATA_SECURITY.I_EPGP_DATA_SECURITY


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGT_VIEW_SORT'), N'I_EPGT_VIEW_SORT', N'IndexId')) is not null
DROP INDEX dbo.EPGT_VIEW_SORT.I_EPGT_VIEW_SORT


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJ_DATE_VALUES'), N'I_EPGX_PROJ_DATE_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJ_DATE_VALUES.I_EPGX_PROJ_DATE_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJ_DEC_VALUES'), N'I_EPGX_PROJ_DEC_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJ_DEC_VALUES.I_EPGX_PROJ_DEC_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJ_INT_VALUES'), N'I_EPGX_PROJ_INT_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJ_INT_VALUES.I_EPGX_PROJ_INT_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJ_NTEXT_VALUES'), N'I_EPGX_PROJ_NTEXT_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJ_NTEXT_VALUES.I_EPGX_PROJ_NTEXT_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJ_TEXT_VALUES'), N'I_EPGX_PROJ_TEXT_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJ_TEXT_VALUES.I_EPGX_PROJ_TEXT_VALUES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJECT_ASSN'), N'I_EPGX_PROJECT_ASSN', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJECT_ASSN.I_EPGX_PROJECT_ASSN


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJECT_LOGIC'), N'I_EPGX_PROJECT_LOGIC', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJECT_LOGIC.I_EPGX_PROJECT_LOGIC


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJECT_RESOURCES'), N'I_EPGX_PROJECT_RESOURCES', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJECT_RESOURCES.I_EPGX_PROJECT_RESOURCES


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJECT_TASKS'), N'I_EPGX_PROJECT_TASKS', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJECT_TASKS.I_EPGX_PROJECT_TASKS


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJECT_TSWORK'), N'I_EPGX_PROJECT_TSWORK', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJECT_TSWORK.I_EPGX_PROJECT_TSWORK


IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGX_PROJECT_VERSIONS'), N'I_EPGX_PROJECT_VERSIONS', N'IndexId')) is not null
DROP INDEX dbo.EPGX_PROJECT_VERSIONS.I_EPGX_PROJECT_VERSIONS

--New
IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_MEMBERS'), N'I_EPG_GROUP_MEMBERS_GROUP_ID', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_MEMBERS.I_EPG_GROUP_MEMBERS_GROUP_ID

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_GROUP_MEMBERS'), N'I_EPG_GROUP_MEMBERS_UID', N'IndexId')) is not null
DROP INDEX dbo.EPG_GROUP_MEMBERS.I_EPG_GROUP_MEMBERS_UID

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_CAPACITY_VALUES'), N'I_EPGP_CAPACITY_VALUES', N'IndexId')) is not null
DROP INDEX dbo.EPGP_CAPACITY_VALUES.I_EPGP_CAPACITY_VALUES

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_PERIODS'), N'I_EPG_PERIODS_PRD_ID', N'IndexId')) is not null
DROP INDEX dbo.EPG_PERIODS.I_EPG_PERIODS_PRD_ID

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPGP_CAPACITY_VALUES'), N'I_EPGP_CAPACITY_VALUES_WRES_ID', N'IndexId')) is not null
DROP INDEX dbo.EPGP_CAPACITY_VALUES.I_EPGP_CAPACITY_VALUES_WRES_ID

IF (SELECT INDEXPROPERTY(object_id(N'dbo.EPG_PROJECT_RATES'), N'IX_EPG_PROJECT_RATES_PROJECT_ID', N'IndexId')) is not null
DROP INDEX dbo.EPG_PROJECT_RATES.IX_EPG_PROJECT_RATES_PROJECT_ID
--

CREATE CLUSTERED INDEX I_EPG_DELEGATES ON dbo.EPG_DELEGATES (WRES_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_EXT_MAPPING ON dbo.EPG_EXT_MAPPING (EXM_UID,EXM_ENTITY)


--CREATE CLUSTERED INDEX I_EPG_GROUP_MEMBERS ON dbo.EPG_GROUP_MEMBERS (GROUP_ID)


CREATE CLUSTERED INDEX I_EPG_GROUP_NONWORK_HOURS ON dbo.EPG_GROUP_NONWORK_HOURS (GROUP_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_GROUP_NONWORK_ITEMS ON dbo.EPG_GROUP_NONWORK_ITEMS (GROUP_ID)


CREATE CLUSTERED INDEX I_EPG_GROUP_PERMISSIONS ON dbo.EPG_GROUP_PERMISSIONS (GROUP_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_GROUP_TSLIMITS ON dbo.EPG_GROUP_TSLIMITS (GROUP_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_GROUP_WEEKLYHOURS ON dbo.EPG_GROUP_WEEKLYHOURS (GROUP_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_GROUPS ON dbo.EPG_GROUPS (GROUP_ID)


CREATE CLUSTERED INDEX I_EPG_JOB_MSGS ON dbo.EPG_JOB_MSGS(JOB_GUID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_JOBS ON dbo.EPG_JOBS(JOB_GUID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_MSP_FIELDS ON dbo.EPG_MSP_FIELDS(MSF_UID)


CREATE CLUSTERED INDEX I_EPG_MY_RESOURCES ON dbo.EPG_MY_RESOURCES (WRES_ID)


CREATE CLUSTERED INDEX I_EPG_NONWORK_HOURS ON dbo.EPG_NONWORK_HOURS (NWI_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_NONWORK_ITEMS ON dbo.EPG_NONWORK_ITEMS (NWI_ID)


CREATE CLUSTERED INDEX I_EPG_NOTE_THREADS ON dbo.EPG_NOTE_THREADS (NT_CONTEXT)


CREATE UNIQUE CLUSTERED INDEX I_EPG_NOTES ON dbo.EPG_NOTES (NOTE_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_PERIODS ON dbo.EPG_PERIODS (CB_ID,PRD_ID)


CREATE CLUSTERED INDEX I_EPG_PERMISSIONS ON dbo.EPG_PERMISSIONS (PERM_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_PROJ_TASKS ON dbo.EPG_PROJ_TASKS (PT_WPROJ_ID ASC, PT_TASK_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_RD_VIEWS ON dbo.EPG_RD_VIEWS (WRES_ID,VIEW_NAME)


CREATE UNIQUE CLUSTERED INDEX I_EPG_RESOURCES ON dbo.EPG_RESOURCES (WRES_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_SHORTCUTS ON dbo.EPG_SHORTCUTS (SHC_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_SITEMAP ON dbo.EPG_SITEMAP (SM_UID)


CREATE CLUSTERED INDEX I_EPG_SYSTEM_COLORS ON dbo.EPG_SYSTEM_COLORS (REF_CONTEXT)


CREATE UNIQUE CLUSTERED INDEX I_EPG_TASKSTATUS ON dbo.EPG_TASKSTATUS (TKS_UID)


CREATE CLUSTERED INDEX I_EPG_TS_ACTUALHOURS ON dbo.EPG_TS_ACTUALHOURS (CHG_UID, AH_DATE)


CREATE CLUSTERED INDEX I_EPG_TS_ADJUSTMENTHOURS ON dbo.EPG_TS_ADJUSTMENTHOURS (ADJ_UID,TS_UID,CHG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_TS_ADJUSTMENTS ON dbo.EPG_TS_ADJUSTMENTS (ADJ_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_TS_APPROVERS ON dbo.EPG_TS_APPROVERS (CODE_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_TS_CATEGORY_VALUES ON dbo.EPG_TS_CATEGORY_VALUES (CAT_CHG_UID)


CREATE CLUSTERED INDEX I_EPG_TS_CHARGES ON dbo.EPG_TS_CHARGES (TS_UID ASC, CHG_ID)


CREATE NONCLUSTERED INDEX IX_EPG_TS_CHARGES ON dbo.EPG_TS_CHARGES (WPROJ_ID)


CREATE NONCLUSTERED INDEX IXX_EPG_TS_CHARGES ON dbo.EPG_TS_CHARGES (CHG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_TS_DEPTS ON dbo.EPG_TS_DEPTS (TSD_DEPT_UID,TSD_PRD_ID)


CREATE CLUSTERED INDEX I_EPG_TS_PROGRESS ON dbo.EPG_TS_PROGRESS (TS_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPG_TS_TIMESHEETS ON dbo.EPG_TS_TIMESHEETS (TS_UID)


CREATE CLUSTERED INDEX I_EPG_USERINFO ON dbo.EPG_USERINFO (WRES_ID,UINF_CONTEXT)


CREATE CLUSTERED INDEX I_EPG_VIEW_FIELDS ON dbo.EPG_VIEW_FIELDS (VIEW_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGC_RESOURCE_MV_VALUES ON dbo.EPGC_RESOURCE_MV_VALUES (WRES_ID,MVR_FIELD_ID,MVR_UID)


CREATE CLUSTERED INDEX I_EPGP_AVAIL_CATEGORIES ON dbo.EPGP_AVAIL_CATEGORIES (CT_ID)


--CREATE CLUSTERED INDEX I_EPGP_COMMITMENTS ON dbo.EPGP_COMMITMENTS (PROJECT_ID)
--
--
--CREATE INDEX I_EPGP_COMMITMENTS_01 ON dbo.EPGP_COMMITMENTS (CMT_UID)
--
--
--CREATE CLUSTERED INDEX I_EPGP_COMMITMENTS_HOURS ON dbo.EPGP_COMMITMENTS_HOURS (CMT_UID)
--

CREATE CLUSTERED INDEX I_EPG_RESOURCEPLANS ON dbo.EPG_RESOURCEPLANS (PROJECT_ID)


CREATE INDEX I_EPG_RESOURCEPLANS_01 ON dbo.EPG_RESOURCEPLANS (CMT_UID)


CREATE CLUSTERED INDEX I_EPG_RESOURCEPLANS_HOURS ON dbo.EPG_RESOURCEPLANS_HOURS (CMT_UID)


CREATE CLUSTERED INDEX I_EPGP_COST_BREAKDOWN_ATTRIBS ON dbo.EPGP_COST_BREAKDOWN_ATTRIBS (CB_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_COST_BREAKDOWNS ON dbo.EPGP_COST_BREAKDOWNS (CB_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_COST_CALC ON dbo.EPGP_COST_CALC (CT_ID,CL_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_CATEGORIES ON dbo.EPGP_CATEGORIES (CA_UID)


CREATE INDEX I_EPGP_COST_CATEGORIES ON dbo.EPGP_COST_CATEGORIES (MC_UID,CA_UID,BC_UID)


CREATE NONCLUSTERED INDEX I_EPGP_COST_CATEGORIES_BC_UID ON dbo.EPGP_COST_CATEGORIES ([BC_UID]) INCLUDE ([BC_NAME],[BC_ID])


CREATE UNIQUE CLUSTERED INDEX I_EPGP_COST_CUSTOM_FIELDS ON dbo.EPGP_COST_CUSTOM_FIELDS (CT_ID,CF_ID)


CREATE CLUSTERED INDEX I_EPGP_COST_DETAILS ON dbo.EPGP_COST_DETAILS (CB_ID,CT_ID,PROJECT_ID)


CREATE CLUSTERED INDEX I_EPGP_DETAIL_VALUES ON dbo.EPGP_DETAIL_VALUES (CB_ID,CT_ID,PROJECT_ID)


CREATE CLUSTERED INDEX I_EPGP_MODEL_COST_DETAILS ON dbo.EPGP_MODEL_COST_DETAILS (MODEL_UID,MODEL_VERSION_UID,CB_ID,CT_ID,PROJECT_ID)


CREATE CLUSTERED INDEX I_EPGP_MODEL_DETAIL_VALUES ON dbo.EPGP_MODEL_DETAIL_VALUES (MODEL_UID,MODEL_VERSION_UID,CB_ID,CT_ID,PROJECT_ID)


CREATE INDEX I_EPGP_COST_TYPES ON dbo.EPGP_COST_TYPES (CT_ID)


CREATE INDEX I_EPGP_COST_TYPES_Name ON dbo.EPGP_COST_TYPES (CT_NAME ASC)


CREATE INDEX I_EPGP_COST_VALUES ON dbo.EPGP_COST_VALUES (CB_ID,CT_ID)


CREATE INDEX I_EPGP_COST_BC_UID ON [dbo].[EPGP_COST_VALUES](BC_UID)


CREATE INDEX I_EPGP_COST_CT_ID ON [dbo].[EPGP_COST_VALUES](CT_ID)


CREATE INDEX I_EPGP_COST_VALUES_01 ON dbo.EPGP_COST_VALUES (PROJECT_ID,CB_ID,CT_ID)


CREATE CLUSTERED INDEX I_EPGP_COST_VALUES_INFO ON dbo.EPGP_COST_VALUES_INFO (CB_ID,CT_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_COST_XREF ON dbo.EPGP_COST_XREF (WRES_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_LAYOUT_FIELDS ON dbo.EPGP_LAYOUT_FIELDS (TAB_ID,TABGROUP_ID,FIELD_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_LAYOUT_GROUPS ON dbo.EPGP_LAYOUT_GROUPS (TAB_ID,TABGROUP_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_LAYOUT_PAGES ON dbo.EPGP_LAYOUT_PAGES (TAB_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_LOOKUP_TABLES ON dbo.EPGP_LOOKUP_TABLES (LOOKUP_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_LOOKUP_VALUES_1 ON dbo.EPGP_LOOKUP_VALUES (LV_UID)


CREATE INDEX I_EPGP_LOOKUP_VALUES_2 ON dbo.EPGP_LOOKUP_VALUES (LOOKUP_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PI_PROGS ON dbo.EPGP_PI_PROGS (FIELD_ID,PROJECT_ID,PROG_UID)


CREATE CLUSTERED INDEX I_EPGP_PI_PROGS_FISCAL ON dbo.EPGP_PI_PROGS_FISCAL (FIELD_ID,PROJECT_ID,PROG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PI_WORKITEM_LOGIC ON dbo.EPGP_PI_WORKITEM_LOGIC (PROJECT_ID,WORKITEM_PRED_ID,WORKITEM_SUCC_ID)


CREATE CLUSTERED INDEX I_EPGP_PI_WORKITEM_TSWORK ON dbo.EPGP_PI_WORKITEM_TSWORK (PROJECT_ID,WRES_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROG_DATE_VALUES ON dbo.EPGP_PROG_DATE_VALUES (FIELD_ID,PROG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROG_DEC_VALUES ON dbo.EPGP_PROG_DEC_VALUES (FIELD_ID,PROG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROG_INFOS ON dbo.EPGP_PROG_INFOS (FIELD_ID,PROG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROG_INT_VALUES ON dbo.EPGP_PROG_INT_VALUES (FIELD_ID,PROG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROG_NTEXT_VALUES ON dbo.EPGP_PROG_NTEXT_VALUES (FIELD_ID,PROG_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROG_TEXT_VALUES ON dbo.EPGP_PROG_TEXT_VALUES (FIELD_ID,PROG_UID)


CREATE CLUSTERED INDEX I_EPGP_PROJECT_CT_STATUS ON dbo.EPGP_PROJECT_CT_STATUS (CB_ID,CT_ID)


CREATE INDEX I_EPGP_PROJECT_CT_STATUS_01 ON dbo.EPGP_PROJECT_CT_STATUS (PROJECT_ID,CB_ID,CT_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROJECT_GROUP_SECURITY ON dbo.EPGP_PROJECT_GROUP_SECURITY (PROJECT_ID,GROUP_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_PROJECT_RESOURCE_SECURITY ON dbo.EPGP_PROJECT_RESOURCE_SECURITY (PROJECT_ID,WRES_ID)


CREATE CLUSTERED INDEX I_EPGP_PROJECT_STAGES ON dbo.EPGP_PROJECT_STAGES (PROJECT_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_RATE_TYPES ON dbo.EPGP_RATE_TYPES (RT_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_RD_FIELDS ON dbo.EPGP_RD_FIELDS (CONTEXT_ID,FIELD_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_RP_CATEGORY_VALUES ON dbo.EPGP_RP_CATEGORY_VALUES (CAT_CMT_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_STAGE_FIELDS ON dbo.EPGP_STAGE_FIELDS (STAGE_ID,FIELD_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_STAGES ON dbo.EPGP_STAGES (STAGE_ID)


CREATE CLUSTERED INDEX I_EPGP_MODEL_TARGET_DETAILS ON dbo.EPGP_MODEL_TARGET_DETAILS (TARGET_ID)


CREATE CLUSTERED INDEX I_EPGP_MODEL_TARGET_VALUES ON dbo.EPGP_MODEL_TARGET_VALUES (TARGET_ID)


CREATE CLUSTERED INDEX I_EPGP_MODEL_TARGETS ON dbo.EPGP_MODEL_TARGETS (TARGET_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_VERSIONS ON dbo.EPGP_VERSIONS (VERSION_ID)


CREATE CLUSTERED INDEX I_EPGP_WI_FRAGMENT_LOGIC ON dbo.EPGP_WI_FRAGMENT_LOGIC (FRAGMENT_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGP_WSS_LISTS ON dbo.EPGP_WSS_LISTS (WSS_LIST_ID)


CREATE CLUSTERED INDEX I_EPGT_FIELDS ON dbo.EPGT_FIELDS (FIELD_ID,FIELD_VIEWTYPE_ID)


CREATE CLUSTERED INDEX I_EPGT_LOCALVIEWS ON dbo.EPGT_LOCALVIEWS (WRES_ID,WAU_UID,UINF_CONTEXT)


CREATE CLUSTERED INDEX I_EPGT_RES_FIELDS ON dbo.EPGT_RES_FIELDS (FIELD_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_USERBUTTONS ON dbo.EPGT_USERBUTTONS (BTN_PAGE,BTN_SEQ)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_BAR ON dbo.EPGT_VIEW_BAR (GANTT_UID,BAR_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_BUDSPEC ON dbo.EPGT_VIEW_BUDSPEC (BUDSP_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_BUDSPEC_BAND ON dbo.EPGT_VIEW_BUDSPEC_BAND (BUDSP_UID,BAND_ID)


CREATE CLUSTERED INDEX I_EPGT_COSTVIEW_COST_TYPES ON dbo.EPGT_COSTVIEW_COST_TYPES (VIEW_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_DISPLAY ON dbo.EPGT_VIEW_DISPLAY (VIEW_UID)


CREATE CLUSTERED INDEX I_EPGT_VIEW_FIELDS ON dbo.EPGT_VIEW_FIELDS (VIEW_UID,FIELD_ID)


CREATE CLUSTERED INDEX I_EPGT_VIEW_FILTERS ON dbo.EPGT_VIEW_FILTERS (VIEW_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_GANTT ON dbo.EPGT_VIEW_GANTT (GANTT_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_GRAPHIND ON dbo.EPGT_VIEW_GRAPHIND (GRAPHIND_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_GRAPHIND_RULES ON dbo.EPGT_VIEW_GRAPHIND_RULES (GRAPHIND_UID,GRULE_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGT_VIEW_GROUP ON dbo.EPGT_VIEW_GROUP (GROUP_UID)


CREATE CLUSTERED INDEX I_EPGT_VIEW_GROUP_LEVEL ON dbo.EPGT_VIEW_GROUP_LEVEL (GROUP_UID)


CREATE CLUSTERED INDEX I_EPGT_VIEW_MILESTONE ON dbo.EPGT_VIEW_MILESTONE (GANTT_UID)


CREATE CLUSTERED INDEX I_EPGP_DATA_SECURITY ON dbo.EPGP_DATA_SECURITY (DS_CONTEXT,DS_UID)


CREATE CLUSTERED INDEX I_EPGT_VIEW_SORT ON dbo.EPGT_VIEW_SORT (VIEW_UID,WRES_ID)


CREATE INDEX I_EPGX_PROJ_DATE_VALUES ON dbo.EPGX_PROJ_DATE_VALUES (PROJECT_ID,WPROJ_ID)


CREATE INDEX I_EPGX_PROJ_DEC_VALUES ON dbo.EPGX_PROJ_DEC_VALUES (PROJECT_ID,WPROJ_ID)


CREATE INDEX I_EPGX_PROJ_INT_VALUES ON dbo.EPGX_PROJ_INT_VALUES (PROJECT_ID,WPROJ_ID)


CREATE INDEX I_EPGX_PROJ_NTEXT_VALUES ON dbo.EPGX_PROJ_NTEXT_VALUES (PROJECT_ID,WPROJ_ID)


CREATE INDEX I_EPGX_PROJ_TEXT_VALUES ON dbo.EPGX_PROJ_TEXT_VALUES (PROJECT_ID,WPROJ_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGX_PROJECT_ASSN ON dbo.EPGX_PROJECT_ASSN (WPROJ_ID,TASK_UID,WRES_ID,LOCAL_WRES_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGX_PROJECT_LOGIC ON dbo.EPGX_PROJECT_LOGIC (WPROJ_ID,LG_TASK_SUCC_UID,LG_TASK_PRED_UID)


CREATE UNIQUE CLUSTERED INDEX I_EPGX_PROJECT_RESOURCES ON dbo.EPGX_PROJECT_RESOURCES (WPROJ_ID,WRES_ID,EXRES_ID)


CREATE UNIQUE CLUSTERED INDEX I_EPGX_PROJECT_TASKS ON dbo.EPGX_PROJECT_TASKS (WPROJ_ID,TASK_UID)


CREATE CLUSTERED INDEX I_EPGX_PROJECT_TSWORK ON dbo.EPGX_PROJECT_TSWORK (WPROJ_ID,WRES_ID)


CREATE UNIQUE INDEX I_EPGX_PROJECT_VERSIONS ON dbo.EPGX_PROJECT_VERSIONS (WPROJ_ID)

--New
CREATE NONCLUSTERED INDEX [I_EPG_GROUP_MEMBERS_GROUP_ID] ON [dbo].[EPG_GROUP_MEMBERS] (	[GROUP_ID] ASC )

CREATE NONCLUSTERED INDEX [I_EPG_GROUP_MEMBERS_UID] ON [dbo].[EPG_GROUP_MEMBERS] (	[MEMBER_UID] ASC ) INCLUDE ([GROUP_ID]) 

CREATE NONCLUSTERED INDEX [I_EPGP_CAPACITY_VALUES] ON [dbo].[EPGP_CAPACITY_VALUES] ([CB_ID],[BD_PERIOD]) INCLUDE ([WRES_ID],[CS_AVAIL],[CS_OFF])

CREATE NONCLUSTERED INDEX I_EPG_PERIODS_PRD_ID ON [dbo].[EPG_PERIODS]([PRD_ID])

CREATE NONCLUSTERED INDEX I_EPGP_CAPACITY_VALUES_WRES_ID ON [dbo].[EPGP_CAPACITY_VALUES]([WRES_ID])

CREATE NONCLUSTERED INDEX [IX_EPG_PROJECT_RATES_PROJECT_ID] ON [dbo].[EPG_PROJECT_RATES] ([PROJECT_ID] ASC)
--