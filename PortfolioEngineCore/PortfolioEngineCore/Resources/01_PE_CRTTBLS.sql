/****************************************************************************************************
**   Copyright 2012 EPM Live
**   Filename  : 01_PE_CRTTBLS.SQL
**
**   This script will create and update the PortfolioEngine SQL Server tables  
**
**   Privileges needed: member of db_owner or db_ddladmin
**
****************************************************************************************************/

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_SYSTEM')
                begin
                                print 'Creating Table EPG_SYSTEM'
CREATE TABLE dbo.EPG_SYSTEM
	(
	SY_UID int IDENTITY(1,1) NOT NULL,
	SY_INCLUDE nvarchar(255) NULL,
	SY_VERSION int NULL,
	SY_INSTALLED datetime NULL
)                               

                end
else
                begin
                                Print 'Updating Table EPG_SYSTEM'
                end
Insert into dbo.EPG_SYSTEM (SY_VERSION,SY_INSTALLED) VALUES(    4320000, GETDATE())
                
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_SITEMAP')
                begin
                                print 'Creating Table EPG_SITEMAP'

CREATE TABLE dbo.EPG_SITEMAP
 (
	SM_UID int NOT NULL,
	SM_URL nvarchar(255),
	SM_TITLE nvarchar(255),
	SM_DESCRIPTION nvarchar(255),
	SM_PARAMS nvarchar(255),
	SM_KEY nvarchar(255) NULL,
	SM_ID int NOT NULL,
	SM_LEVEL int NOT NULL,
	SM_LEVEL_DEFAULT tinyint NOT NULL DEFAULT 0,
	SM_CONTEXT nvarchar(7) NULL,
	SM_TARGET nvarchar(255) NULL,
	SM_IMAGE nvarchar(255) NULL,
	WRES_ID int NULL,
	PERM_UID int NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_SITEMAP'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_CHUNKER')
                begin
                                print 'Creating Table EPG_CHUNKER'

CREATE TABLE dbo.EPG_CHUNKER
 (
	WRES_ID int NOT NULL,
	CHUNK_ID int NOT NULL,
	CHUNK_DATE datetime NOT NULL,
	CHUNK ntext  NOT NULL 
) 

                end
else
                begin
                                Print 'Updating Table EPG_CHUNKER'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_DATA_CACHE')
                begin
                                print 'Creating Table EPG_DATA_CACHE'

CREATE TABLE dbo.EPG_DATA_CACHE(
	DC_TICKET uniqueidentifier NOT NULL,
	DC_TIMESTAMP datetime NOT NULL,
	DC_DATA ntext NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_DATA_CACHE'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_JOBS')
                begin
                                print 'Creating Table EPG_JOBS'

CREATE TABLE dbo.EPG_JOBS
(
	JOB_GUID uniqueidentifier NOT NULL,
	JOB_AFTER_GUID uniqueidentifier NULL,
	JOB_CONTEXT int NOT NULL,
	JOB_SESSION nvarchar(48) NOT NULL,
	WRES_ID int NOT NULL,
	JOB_SUBMITTED datetime NOT NULL,
	JOB_STARTED datetime NULL,
	JOB_COMPLETED datetime NULL,
	JOB_ERRORCODE int NULL,
	JOB_STATUS int NOT NULL, 
	JOB_COMMENT nvarchar(255) NULL,
	JOB_CONTEXT_DATA ntext NULL, 
	JOB_CONTEXT_RESULT ntext NULL 
) 

                end
else
                begin
                                Print 'Updating Table EPG_JOBS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_JOB_MSGS')
                begin
                                print 'Creating Table EPG_JOB_MSGS'

CREATE TABLE dbo.EPG_JOB_MSGS(
	JMG_UID int IDENTITY(1,1) NOT NULL,
	JOB_GUID uniqueidentifier NOT NULL,
	JMG_TIMESTAMP datetime NOT NULL,
	JMG_MESSAGE nvarchar(255) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_JOB_MSGS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_JOBS_TIMER')
                begin
                                print 'Creating Table EPG_JOBS_TIMER'

CREATE TABLE dbo.EPG_JOBS_TIMER(
	JOT_UID int IDENTITY(1,1) NOT NULL,
	JOT_FIRST_RUN datetime NULL,
	JOT_LAST_RUN datetime NULL,
	JOT_NEXT_RUN datetime NULL,
	JOT_FREQ_MODE int NOT NULL,
	JOT_SESSION nvarchar(48) NOT NULL,
	WRES_ID int NOT NULL,
	JOT_CONTEXT int NOT NULL,
	JOT_CONTEXT_DATA ntext NULL,
	JOT_COMMENT nvarchar(255) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_JOBS_TIMER'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_UPLOADS')
                begin
                                print 'Creating Table EPG_UPLOADS'

CREATE TABLE dbo.EPG_UPLOADS
(
	UPL_CONTEXT int NOT NULL,
	UPL_GUID uniqueidentifier NOT NULL,
	WRES_ID int NOT NULL,
	UPL_CHUNK_ID int NOT NULL,
	UPL_TIMESTAMP datetime NOT NULL,
	UPL_DATA ntext  NOT NULL 
) 

                end
else
                begin
                                Print 'Updating Table EPG_UPLOADS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_ADMIN')
                begin
                                print 'Creating Table EPG_ADMIN'

CREATE TABLE dbo.EPG_ADMIN
(
	ADM_DEPT_CODE int,
	ADM_ROLE_CODE int,
	ADM_PROJ_CHARGENUMBER_CFID int,
	ADM_PROJ_CHARGESTATUS_CFID int,
	ADM_TASK_CHARGENUMBER_CFID int,
	ADM_TASK_CHARGESTATUS_CFID int,
	ADM_PORT_CHARGENUMBER_CFID int,
	ADM_PORT_CHARGESTATUS_CFID int,
	ADM_TASK_ESTIMATEDFINISH_DFID int,
	ADM_WORK_LOOKAHEAD_DAYS int,
	ADM_PORT_COMMITMENTS_CB_ID int,
	ADM_PORT_COMMITMENTS_MODE int,
	ADM_PORT_COMMITMENTS_OPMODE int,
	ADM_RPE_DEPT_CODE int,
	ADM_RPE_VALIDATE_REVENUE_PROCESS tinyint,
	ADM_RPE_EXCLUDE_NONWORKHOURS tinyint,
	ADM_STATUS_DATE datetime,
	ADM_CURRENCY_DIGITS int,
	ADM_CURRENCY_POSITION tinyint,
	ADM_CURRENCY_SYMBOL varchar(10),
	ADM_MINUTES_PER_DAY int,
	ADM_TS_PROJ_VERSION_ID int,
	ADM_DEFAULT_PROJ_VERSION_ID int,
	ADM_TS_RULE_ALLSUBMITTED tinyint,
	ADM_TS_RULE_ALLDEPTAPPROVED tinyint,
	ADM_TS_RULE_ALLPROJAPPROVED tinyint,
	ADM_TS_RULE_ALLDEPTSCLOSED tinyint,
	ADM_PGM_FISCAL tinyint,
	ADM_PGM_TOTALCHECK tinyint,
	ADM_QM_HEARTBEAT_DATE datetime null,
	ADM_WORKFLOW_LOOKUP int,
	ADM_WORKFLOW_PATH int,	
	ADM_MC_LOOKUP int,
	ADM_MC_DEFAULT int,
	ADM_TS_ALLOW_NO_ASSNS tinyint,
	ADM_TS_ALLOW_OTHER_ASSNS tinyint,
	ADM_EV_VERSION_ID int,
	ADM_EV_CB_ID int,
	ADM_EV_NODE_LOOKUP int,	
	ADM_EV_OBS_LOOKUP int,
	ADM_EV_METHOD_LOOKUP int,
	ADM_PI_GROUP_CF1 int,
	ADM_PI_GROUP_CF2 int,
	ADM_WE_SERVERURL nvarchar(400),
	ADM_SERVERURL nvarchar(400),
	ADM_PS_PUBLISHED_DB_CONNECT nvarchar(255),	
	ADM_PS_REPORTING_DB_CONNECT nvarchar(255),	
	ADM_WI_ALLOW_PROV_MEMBERS tinyint,
	ADM_ASSNS_NEED_RM_APPROVAL tinyint,
	ADM_UPLOAD_SCHEDULE_METHOD tinyint,
	ADM_DEF_FTE_WH int,
	ADM_DEF_FTE_HOL int,
	ADM_WE_REPORTING_DB_CONNECT nvarchar(400)
)

                end
else
                begin
                                Print 'Updating Table EPG_ADMIN'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_ADMIN' and column_name = 'ADM_DEF_FTE_WH')
                                begin
                                                Print '     Add Column ADM_DEF_FTE_WH'
                                                ALTER TABLE EPG_ADMIN ADD ADM_DEF_FTE_WH int
                                end
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_ADMIN' and column_name = 'ADM_DEF_FTE_HOL')
                                begin
                                                Print '     Add Column ADM_DEF_FTE_HOL'
                                                ALTER TABLE EPG_ADMIN ADD ADM_DEF_FTE_HOL int
                                end
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_ADMIN' and column_name = 'ADM_WE_REPORTING_DB_CONNECT')
                                begin
                                                Print '     Add Column ADM_WE_REPORTING_DB_CONNECT'
                                                ALTER TABLE EPG_ADMIN ADD ADM_WE_REPORTING_DB_CONNECT nvarchar(400)
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_MAIL_ADMIN')
                begin
                                print 'Creating Table EPG_MAIL_ADMIN'

CREATE TABLE dbo.EPG_MAIL_ADMIN
(
	MAD_MAIL_ENABLED tinyint NOT NULL DEFAULT 0,
	MAD_SEND_USING_PORT tinyint NOT NULL DEFAULT 1,
	MAD_SMTP_SERVER_PORT int,
	MAD_SMTP_SERVER_NAME nvarchar(255),
	MAD_SMTP_AUTH_MODE tinyint NOT NULL DEFAULT 0, /* Anonymous=0; Basic=1; NTLM=2; */
	MAD_SMTP_USER  nvarchar(255),
	MAD_SMTP_PASSWORD  nvarchar(255),
	MAD_SMTP_USE_SSL tinyint NOT NULL DEFAULT 0,
	MAD_PICKUP_DIR nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_MAIL_ADMIN'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_SYSTEM_COLORS')
                begin
                                print 'Creating Table EPG_SYSTEM_COLORS'

CREATE TABLE dbo.EPG_SYSTEM_COLORS
(
	REF_CONTEXT int NOT NULL,
	REF_ID int NOT NULL,
	REF_NAME nvarchar(255) NOT NULL,
	REF_COLOR int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_SYSTEM_COLORS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_USERINFO')
                begin
                                print 'Creating Table EPG_USERINFO'

CREATE TABLE dbo.EPG_USERINFO
(
	WRES_ID int NOT NULL,
	UINF_CONTEXT int NOT NULL,
	UINF_DATA int NOT NULL,
	UINF_XML ntext
)

                end
else
                begin
                                Print 'Updating Table EPG_USERINFO'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_SYSTEM_INFO')
                begin
                                print 'Creating Table EPG_SYSTEM_INFO'

CREATE TABLE dbo.EPG_SYSTEM_INFO
(
	SI_CONTEXT int NOT NULL,
	SI_CONTEXT_ID int NOT NULL,
	SI_XML ntext NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_SYSTEM_INFO'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_PERIODS')
                begin
                                print 'Creating Table EPG_PERIODS'

CREATE TABLE dbo.EPG_PERIODS
(
	PRD_ID int NOT NULL,
	CB_ID int,
	PRD_NAME nvarchar(255) NOT NULL,
	PRD_START_DATE datetime,
	PRD_FINISH_DATE datetime,
	PRD_CLOSED_DATE datetime,
	PRD_CLOSED_NAME nvarchar(255) NULL,
	PRD_IS_CLOSED tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPG_PERIODS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_NOTE_THREADS')
                begin
                                print 'Creating Table EPG_NOTE_THREADS'

CREATE TABLE dbo.EPG_NOTE_THREADS
(
	NT_UID int IDENTITY (1, 1) NOT NULL,
	NT_CONTEXT tinyint NOT NULL DEFAULT 0,
	NT_INDEX_1 int,
	NT_INDEX_2 int,
	NT_INDEX_3 int,
	NT_ACCEPTED tinyint NOT NULL DEFAULT 0,
	NT_NOTE_UID int
)

                end
else
                begin
                                Print 'Updating Table EPG_NOTE_THREADS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_NOTES')
                begin
                                print 'Creating Table EPG_NOTES'

CREATE TABLE dbo.EPG_NOTES
(
	NOTE_UID int IDENTITY (1, 1) NOT NULL,
	NOTE_ACTION tinyint NOT NULL DEFAULT 0,
	NOTE_TIMESTAMP datetime NOT NULL,
	NOTE_AUTHOR_WRES_ID int NOT NULL,
	NOTE_AUTHOR_ROLE tinyint NOT NULL DEFAULT 0,
	NOTE_XML ntext,
	NOTE_RTF ntext
)

                end
else
                begin
                                Print 'Updating Table EPG_NOTES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_TIMESHEETS')
                begin
                                print 'Creating Table EPG_TS_TIMESHEETS'

CREATE TABLE dbo.EPG_TS_TIMESHEETS
(
	TS_UID int IDENTITY (1, 1) NOT NULL,
	PRD_ID int NOT NULL,
	WRES_ID int NOT NULL,
	TS_TIMESTAMP DATETIME NOT NULL,
	TS_SUBMITTED tinyint NOT NULL DEFAULT 0,
	TS_SUBMITTED_WRES_ID INT,
	TS_SUBMITTED_DATE DATETIME,
	TS_DEPT_STATUS tinyint NOT NULL DEFAULT 0,
	TS_DEPT_UID INT,
	TS_DEPT_NAME nvarchar(255),
	TS_DEPT_WRES_ID INT,
	TS_DEPT_DATE DATETIME,
	TS_MANAGER_LOCKED tinyint NOT NULL DEFAULT 0,
	TS_LIMITS_STATUS tinyint NOT NULL DEFAULT 0,
	TS_DELETED tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_TIMESHEETS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_PROJ_TASKS')
                begin
                                print 'Creating Table EPG_PROJ_TASKS'

CREATE TABLE dbo.EPG_PROJ_TASKS
(
	PT_WPROJ_ID int NOT NULL,
	PT_TASK_UID int NOT NULL,
	PT_PROJ_NAME nvarchar(255) NOT NULL,
	PT_TASK_NAME nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_PROJ_TASKS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_CHARGES')
                begin
                                print 'Creating Table EPG_TS_CHARGES'

CREATE TABLE dbo.EPG_TS_CHARGES
(
	CHG_UID int IDENTITY (1, 1) NOT NULL,
	TS_UID int NOT NULL,
	CHG_ID int NOT NULL,
	CHG_CHARGENUMBER nvarchar(255) NULL,
	CHG_CHARGESTATUS nvarchar(255) NULL,
	CHG_MAJORCATEGORY nvarchar(255) NULL,
	PROJECT_ID int NOT NULL DEFAULT 0,
	WPROJ_ID int NOT NULL DEFAULT 0,
	TASK_UID int NOT NULL DEFAULT 0,
	NWI_ID int NOT NULL DEFAULT 0,
	CHG_NORMALHOURS int,
	CHG_OVERTIMEHOURS int,
	CHG_PROJ_STATUS tinyint,
	CHG_PROJ_WRES_ID INT,
	CHG_PROJ_DATE DATETIME,
	CHG_ADJUSTED tinyint,
	CHG_CANNOT_DELETE tinyint
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_CHARGES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_ACTUALHOURS')
                begin
                                print 'Creating Table EPG_TS_ACTUALHOURS'

CREATE TABLE dbo.EPG_TS_ACTUALHOURS
(
	CHG_UID int NOT NULL,
	AH_DATE DATETIME,
	AH_NORMALHOURS int,
	AH_OVERTIMEHOURS int
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_ACTUALHOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_PROGRESS')
                begin
                                print 'Creating Table EPG_TS_PROGRESS'

CREATE TABLE dbo.EPG_TS_PROGRESS
(
	TS_UID int NOT NULL,
	PROJECT_ID int NOT NULL,
	WPROJ_ID int NOT NULL DEFAULT 0,
	TASK_UID int NOT NULL,
	TSP_PCT_COMP smallint NULL,
	TSP_REM_WORK Decimal(25,6) NULL,
	TSP_EXPECTED_FINISH_DATE DATETIME NULL,
	TSP_TIMESTAMP DATETIME NOT NULL,
	TSP_STATUS tinyint NOT NULL DEFAULT 0,
	TSP_STATUS_WRES_ID INT,
	TSP_STATUS_DATE DATETIME
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_PROGRESS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_DEPTS')
                begin
                                print 'Creating Table EPG_TS_DEPTS'

CREATE TABLE dbo.EPG_TS_DEPTS
(
	TSD_DEPT_UID int NOT NULL,
	TSD_PRD_ID int NOT NULL,
	TSD_DEPT_NAME nvarchar(255),
	TSD_STATUS tinyint NOT NULL,
	TSD_WRES_ID int NOT NULL,
	TSD_TIMESTAMP DATETIME NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_DEPTS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_ADJUSTMENTS')
                begin
                                print 'Creating Table EPG_TS_ADJUSTMENTS'

CREATE TABLE dbo.EPG_TS_ADJUSTMENTS
(
	ADJ_UID int  IDENTITY (1, 1) NOT NULL,
	ADJ_TIMESTAMP DATETIME NOT NULL,
	ADJ_ADMIN_WRES_ID int NOT NULL,
	ADJ_COMMENTS nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_ADJUSTMENTS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_ADJUSTMENTHOURS')
                begin
                                print 'Creating Table EPG_TS_ADJUSTMENTHOURS'

CREATE TABLE dbo.EPG_TS_ADJUSTMENTHOURS
(
	ADJ_UID int NOT NULL,
	TS_UID int NOT NULL,
	CHG_UID int NOT NULL,
	ADH_DATE DATETIME NOT NULL,
	ADH_HOURS_FROM int,
	ADH_HOURS_TO int,
	ADH_OT_HOURS_FROM int,
	ADH_OT_HOURS_TO int
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_ADJUSTMENTHOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_PRIOR_ACTUALS')
                begin
                                print 'Creating Table EPG_TS_PRIOR_ACTUALS'

CREATE TABLE dbo.EPG_TS_PRIOR_ACTUALS
(
	PA_UID int IDENTITY (1, 1) NOT NULL,
	WRES_ID int NOT NULL,
	PROJECT_ID int NOT NULL DEFAULT 0,
	WPROJ_ID int NOT NULL DEFAULT 0,
	TASK_UID int NOT NULL DEFAULT 0,
	NWI_ID int NOT NULL DEFAULT 0,
	PA_NORMALHOURS int,
	PA_OVERTIMEHOURS int
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_PRIOR_ACTUALS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VIEW_FIELDS')
                begin
                                print 'Creating Table EPG_VIEW_FIELDS'

CREATE TABLE dbo.EPG_VIEW_FIELDS
(
	VIEW_UID int NOT NULL,
	FIELD_ID int NOT NULL,
	FIELD_COL_ID int,
	FIELD_TITLE nvarchar(255) NULL,
	FIELD_ALIGN int NOT NULL DEFAULT 0,
	FIELD_HIDDEN tinyint NOT NULL DEFAULT 0,
	FIELD_FROZEN tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPG_VIEW_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_APPROVERS')
                begin
                                print 'Creating Table EPG_TS_APPROVERS'

CREATE TABLE dbo.EPG_TS_APPROVERS
(
	CODE_UID int NOT NULL,
	WRES_ID int NOT NULL,
	OCA_TEXT1 nvarchar(255) NULL,
	OCA_TEXT2 nvarchar(255) NULL,
	OCA_TEXT3 nvarchar(255) NULL,
	OCA_TEXT4 nvarchar(255) NULL,
	OCA_TEXT5 nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_APPROVERS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RES_MANAGERS')
                begin
                                print 'Creating Table EPG_RES_MANAGERS'

CREATE TABLE dbo.EPG_RES_MANAGERS
(
	CODE_UID int NOT NULL,
	WRES_ID int NOT NULL,
	OCA_TEXT1 nvarchar(255) NULL,
	OCA_TEXT2 nvarchar(255) NULL,
	OCA_TEXT3 nvarchar(255) NULL,
	OCA_TEXT4 nvarchar(255) NULL,
	OCA_TEXT5 nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_RES_MANAGERS'
                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPG_OBS_MANAGERS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPG_OBS_MANAGERS'
     DROP TABLE dbo.EPG_OBS_MANAGERS
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_OBS_MANAGERS')
--                begin
--                                print 'Creating Table EPG_OBS_MANAGERS'

--CREATE TABLE dbo.EPG_OBS_MANAGERS
--(
--	CODE_UID int NOT NULL,
--	WRES_ID int NOT NULL,
--	OCA_TEXT1 nvarchar(255) NULL,
--	OCA_TEXT2 nvarchar(255) NULL,
--	OCA_TEXT3 nvarchar(255) NULL,
--	OCA_TEXT4 nvarchar(255) NULL,
--	OCA_TEXT5 nvarchar(255) NULL
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPG_OBS_MANAGERS'
--                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TASKSTATUS')
                begin
                                print 'Creating Table EPG_TASKSTATUS'

CREATE TABLE dbo.EPG_TASKSTATUS
(
	TKS_UID int IDENTITY (1, 1) NOT NULL,
	TKS_ID int NOT NULL,
	WRES_ID int NOT NULL,
	WPROJ_ID int NOT NULL,
	TASK_UID int NOT NULL,
	TKS_START_DATE DATETIME,
	TKS_FINISH_DATE DATETIME,
	TKS_PCT_COMP smallint NULL,
	TKS_ACT_WORK Decimal(25,6) NULL,
	TKS_REM_WORK Decimal(25,6) NULL,
	TKS_EXPECTED_FINISH_DATE DATETIME,
	TKS_PRIOR_ACT_WORK Decimal(25,6) NULL,
	TKS_TIMESTAMP DATETIME NOT NULL,
	TKS_STATUS tinyint NOT NULL DEFAULT 0,
	TKS_STATUS_WRES_ID INT,
	TKS_STATUS_DATE DATETIME
)

                end
else
                begin
                                Print 'Updating Table EPG_TASKSTATUS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_DISPLAY')
                begin
                                print 'Creating Table EPGT_VIEW_DISPLAY'

CREATE TABLE dbo.EPGT_VIEW_DISPLAY
(
	VIEW_UID int NOT NULL,
	VIEW_TYPE int NOT NULL,
	VIEW_SUBTYPE int Not Null DEFAULT 0,
	VIEW_NAME nvarchar(255) NULL,
	VIEW_DESC nvarchar(255) NULL,
	GANTT_UID int NULL,
	GROUP_UID int NULL,
	COSTVIEW_UID int NULL,
	VIEW_MILESTONE int NULL,
	VIEW_FIXEDCOLS int NULL,
	VIEW_NSCOUNT int NULL,
	VIEW_VERSION int NULL,
	VIEW_BASELINE_VERSION int NULL,
	VIEW_EXP_INCL int Not Null DEFAULT 0,
	VIEW_EXP_OVERRIDE int Not Null DEFAULT 0,
	VIEW_GANTTSEP int NULL,
	VIEW_GANTTSEPSTYLE int NULL,
	VIEW_GANTTSEPCOLOR int NULL,
	VIEW_GANTTTODAY tinyint NULL,
	VIEW_GANTTTODAYSTYLE int NULL,
	VIEW_GANTTTODAYCOLOR int NULL,
	VIEW_GANTTMARK int NULL,
	VIEW_GANTTMARKDAYSTART int NULL,
	VIEW_GANTTMARKSTYLE int NULL,
	VIEW_GANTTMARKCOLOR int NULL,
	VIEW_GANTTSHADE nvarchar(7) NULL,
	VIEW_GANTTSHADECOLOR int NULL,
	VIEW_PROJTEXTCOLOR int NULL,
	VIEW_PROJBACKCOLOR int NULL,
	VIEW_TASKTEXTCOLOR int NULL,
	VIEW_TASKBACKCOLOR int NULL,
	VIEW_SUMTASKTEXTCOLOR int NULL,
	VIEW_SUMTASKBACKCOLOR int NULL,
	VIEW_EXTTASKTEXTCOLOR int NULL,
	VIEW_EXTTASKBACKCOLOR int NULL,
	VIEW_SELROWTEXTCOLOR int NULL,
	VIEW_SELROWBACKCOLOR int NULL,
	VIEW_SHOWALLGROUPS tinyint NULL,
	VIEW_FILTER_TEXT ntext,
	VIEW_COST_FACTOR int NULL,
	VIEW_SHOW_UNITS int NULL,
	VIEW_SHOW_COST int NULL,
	VIEW_SHOW_COST_TOTALS_ONLY int NULL,
	VIEW_EDIT_ONLY_COSTS int NULL,
	VIEW_LINE_SIZE int Null,
	VIEW_SHOW_INDCOL int Null
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_DISPLAY'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_FIELDS')
                begin
                                print 'Creating Table EPGT_VIEW_FIELDS'

CREATE TABLE dbo.EPGT_VIEW_FIELDS
(
	VIEW_UID int NOT NULL,
	FIELD_ID int NOT NULL,
	FIELD_COL_ID int,
	FIELD_TITLE nvarchar(255) NULL,
	FIELD_ALIGN int NOT NULL DEFAULT 0,
	FIELD_STYLE int NULL,
	GRAPHIND_UID int NULL,
	FIELD_SUMMARYTYPE int NOT NULL DEFAULT 0,
	FIELD_SUMOVERRIDE int NOT NULL DEFAULT 0,
	FIELD_HIDDEN tinyint NOT NULL DEFAULT 0,
	FIELD_MP tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_COSTVIEW_DISPLAY')
                begin
                                print 'Creating Table EPGT_COSTVIEW_DISPLAY'

CREATE TABLE dbo.EPGT_COSTVIEW_DISPLAY
(
	VIEW_UID int NOT NULL,
	VIEW_NAME nvarchar(255) Not NULL,
	VIEW_DESC nvarchar(255) NULL,
	VIEW_COST_BREAKDOWN int Not NULL,
	VIEW_FIRST_PERIOD int NULL,
	VIEW_LAST_PERIOD int NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_COSTVIEW_DISPLAY'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_COSTVIEW_COST_TYPES')
                begin
                                print 'Creating Table EPGT_COSTVIEW_COST_TYPES'

CREATE TABLE dbo.EPGT_COSTVIEW_COST_TYPES
(
	VIEW_UID int NOT NULL,
	VT_ID int NOT NULL,
	CT_ID int NOT NULL,
    CT_ID_COMPARE int NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_COSTVIEW_COST_TYPES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_GANTT')
                begin
                                print 'Creating Table EPGT_VIEW_GANTT'

CREATE TABLE dbo.EPGT_VIEW_GANTT
(
	GANTT_UID int NOT NULL,
	GANTT_NAME nvarchar(255) NULL,
	GANTT_TYPE int NOT NULL DEFAULT 0,
	GANTT_DESC nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_GANTT'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_BAR')
                begin
                                print 'Creating Table EPGT_VIEW_BAR'

CREATE TABLE dbo.EPGT_VIEW_BAR
(
	GANTT_UID int NOT NULL,
	BAR_ID int NOT NULL,
	BAR_STYLE int NOT NULL,
	BAR_COLOR int NOT NULL,
	BAR_DATES int NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_BAR'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_MILESTONE')
                begin
                                print 'Creating Table EPGT_VIEW_MILESTONE'

CREATE TABLE dbo.EPGT_VIEW_MILESTONE
(
	GANTT_UID int NOT NULL,
	MILE_ID int NOT NULL,
	MILE_STYLE int NOT NULL,
	MILE_COLOR int NULL,
	MILE_OP int NULL,
	MILE_VALUE int NULL,
	MILE_DATE int NULL,
	MILE_HIGHCOLOR int NULL,
	MILE_INTERVAL int NULL	
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_MILESTONE'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_GROUP')
                begin
                                print 'Creating Table EPGT_VIEW_GROUP'

CREATE TABLE dbo.EPGT_VIEW_GROUP
(
	GROUP_UID int NOT NULL,
	GROUP_NAME nvarchar(255) NULL,
	GROUP_DESC nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_GROUP'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_GROUP_LEVEL')
                begin
                                print 'Creating Table EPGT_VIEW_GROUP_LEVEL'

CREATE TABLE dbo.EPGT_VIEW_GROUP_LEVEL
(
	GROUP_UID int NOT NULL,
	LEVEL_ID int NOT NULL,
	LEVEL_LEVEL int NOT NULL,
	LEVEL_TEXTCOLOR int NOT NULL,
	LEVEL_BACKCOLOR int NOT NULL,
	LEVEL_FONT int NOT NULL DEFAULT 0,
	LEVEL_BARCOLOR int NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_GROUP_LEVEL'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_SORT')
                begin
                                print 'Creating Table EPGT_VIEW_SORT'

CREATE TABLE dbo.EPGT_VIEW_SORT
(
	VIEW_UID int NOT NULL,
	WRES_ID int NOT NULL,
	SORT_FIELD_ID_1 int NOT NULL,
	SORT_ORDER_1 tinyint NOT NULL DEFAULT 0,
	SORT_GROUPED_1 tinyint NOT NULL DEFAULT 0,
	SORT_DEFAULTLEVEL_1 int NOT NULL DEFAULT 0,
	SORT_FIELD_ID_2 int NOT NULL,
	SORT_ORDER_2 tinyint NOT NULL DEFAULT 0,
	SORT_GROUPED_2 tinyint NOT NULL DEFAULT 0,
	SORT_FIELD_ID_3 int NOT NULL,
	SORT_ORDER_3 tinyint NOT NULL DEFAULT 0,
	SORT_GROUPED_3 tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_SORT'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_FILTERS')
                begin
                                print 'Creating Table EPGT_VIEW_FILTERS'

CREATE TABLE dbo.EPGT_VIEW_FILTERS
(
	VIEW_UID int NOT NULL,
	FILTER_ID int NOT NULL,
	FILTER_FIELD_ID int NOT NULL,
	FILTER_TEXT nvarchar(255) NOT NULL,
	FILTER_OP int NOT NULL,
	FILTER_ANDOR int NOT NULL,
	FILTER_SHORTCUT int Null
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_FILTERS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_GRAPHIND')
                begin
                                print 'Creating Table EPGT_VIEW_GRAPHIND'

CREATE TABLE dbo.EPGT_VIEW_GRAPHIND
(
	GRAPHIND_UID int NOT NULL,
	GRAPHIND_NAME nvarchar(255) NULL,
	GRAPHIND_DESC nvarchar(255) NULL,
	GRAPHIND_MODE int NULL,
	GRAPHIND_DATATYPE int NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_GRAPHIND'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_GRAPHIND_RULES')
                begin
                                print 'Creating Table EPGT_VIEW_GRAPHIND_RULES'

CREATE TABLE dbo.EPGT_VIEW_GRAPHIND_RULES
(
	GRAPHIND_UID int NOT NULL,
	GRULE_ID int NOT NULL,
	GRULE_VALUE_TYPE int NOT NULL,
	GRULE_TEXT_VALUE nvarchar(255) NULL,
	GRULE_DATE_VALUE Datetime NULL,
	GRULE_FIELD_ID int NULL,
	GRULE_NUMBER_VALUE Decimal(25,6) NULL,
	GRULE_GRAPHIND_IND int NULL,
	GRULE_OP int NULL,
	GRULE_TEXTCOLOR int NULL,
	GRULE_BACKCOLOR int NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_GRAPHIND_RULES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_BUDSPEC')
                begin
                                print 'Creating Table EPGT_VIEW_BUDSPEC'

CREATE TABLE dbo.EPGT_VIEW_BUDSPEC
(
	BUDSP_UID int NOT NULL,
	BUDSP_NAME nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_BUDSPEC'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_VIEW_BUDSPEC_BAND')
                begin
                                print 'Creating Table EPGT_VIEW_BUDSPEC_BAND'

CREATE TABLE dbo.EPGT_VIEW_BUDSPEC_BAND
(
	BUDSP_UID int NOT NULL,
	BAND_ID int NOT NULL,
	BAND_BOT Decimal(8,2) NOT NULL DEFAULT 0,
	BAND_TOP Decimal(8,2) NOT NULL DEFAULT 0,
	BAND_BACKCOLOR int NOT NULL,
	BAND_NAME nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_VIEW_BUDSPEC_BAND'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_FIELDS')
                begin
                                print 'Creating Table EPGT_FIELDS'

CREATE TABLE dbo.EPGT_FIELDS
(
	FIELD_ID int NOT NULL,
	FIELD_NAME nvarchar(255) NOT NULL,
	FIELD_NAME_SQL nvarchar(255) NULL,
	FIELD_TABLE_ID int NULL,
	FIELD_NAME_SQL_1 nvarchar(255) NULL,
	FIELD_TABLE_ID_1 int NULL,
	FIELD_FORMAT int NOT NULL DEFAULT 0,
	FIELD_PORT_FORMAT int NULL,
	FIELD_IN_PORT_REGISTER tinyint NOT NULL DEFAULT 0,
	FIELD_IN_PROJ_BROWSER tinyint NOT NULL DEFAULT 0,
	FIELD_IN_PROJLIST_BROWSER tinyint NOT NULL DEFAULT 0,
	FIELD_SORTBY tinyint NOT NULL DEFAULT 0,
	FIELD_FILTERBY tinyint NOT NULL DEFAULT 0,
	FIELD_SUMMARYTYPE int NOT NULL DEFAULT 0,
	FIELD_VIEWTYPE_ID int,
	FIELD_EXPORT int NOT NULL DEFAULT 0,
	FIELD_SEQUENCE nvarchar(8) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_DELEGATES')
                begin
                                print 'Creating Table EPG_DELEGATES'

CREATE TABLE dbo.EPG_DELEGATES
(
	WRES_ID int NOT NULL,
	SURR_ID int NOT NULL,
	SURR_ASSN_DATE datetime,
	SURR_WRES_ID int NOT NULL,
	SURR_CONTEXT int NOT NULL,
	SURR_CONTEXT_VALUE int
)

                end
else
                begin
                                Print 'Updating Table EPG_DELEGATES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_TS_CATEGORY_VALUES')
                begin
                                print 'Creating Table EPG_TS_CATEGORY_VALUES'

CREATE TABLE dbo.EPG_TS_CATEGORY_VALUES
(
	CAT_CHG_UID int NOT NULL,
	CAT_TEXT_1 nvarchar(255) NULL,
	CAT_TEXT_2 nvarchar(255) NULL,
	CAT_TEXT_3 nvarchar(255) NULL,
	CAT_TEXT_4 nvarchar(255) NULL,
	CAT_TEXT_5 nvarchar(255) NULL,
	CAT_CODE_1 int,
	CAT_CODE_2 int,
	CAT_CODE_3 int,
	CAT_CODE_4 int,
	CAT_CODE_5 int
)

                end
else
                begin
                                Print 'Updating Table EPG_TS_CATEGORY_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECTS')
                begin
                                print 'Creating Table EPGP_PROJECTS'

CREATE TABLE dbo.EPGP_PROJECTS
(
	PROJECT_ID int NOT NULL Primary Key,
	PROJECT_NAME nvarchar(255) NOT NULL,
	PROJECT_START_DATE datetime,
	PROJECT_FINISH_DATE datetime,
	PROJECT_PERCENT_COMPLETE int,
	PROJECT_STATUS int,
	PROJECT_STAGE_ID int,
	PROJECT_WORKFLOW int,
	PROJECT_CREATED datetime,
	PROJECT_CREATEDBY int NOT NULL,
	PROJECT_OWNER int NOT NULL,
	PROJECT_MANAGER int NOT NULL,
	PROJECT_PRIORITY int,
	PROJECT_MAJORCATEGORY nvarchar(255),
	PROJECT_CHARGENUMBER nvarchar(255),
	PROJECT_CHARGESTATUS nvarchar(255),
	PROJECT_PLAN_OWNER int NULL,
	PROJECT_PLAN_CHARGESTATUS nvarchar(255),
	PROJECT_IMPORTSTATUS nvarchar(255),
	PROJECT_EV_GROUP int NULL,
	PROJECT_SECURITY tinyint,
	PROJECT_WSS_SITE nvarchar(255) NULL,
	PROJECT_MARKED_DELETION tinyint NOT NULL DEFAULT 0,
	PROJECT_WSS_SERVER_ID int,
	WORKITEM_START_DATE datetime, 
	WORKITEM_FINISH_DATE datetime, 
	WORKITEM_DURATION int, 
	WORKITEM_WORK decimal(25,6), 
	WORKITEM_PERCENT_COMPLETE int,
    PROJECT_CHECKEDOUT tinyint,
    PROJECT_CHECKEDOUT_BY int,
    PROJECT_CHECKEDOUT_DATE datetime,
    PROJECT_EXT_UID nvarchar(128) NULL,
    PROJECT_LIST_ID nvarchar(400) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECTS'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPGP_PROJECTS' and column_name = 'PROJECT_LIST_ID')
                                begin
                                                Print '     Add Column PROJECT_LIST_ID'
                                                ALTER TABLE EPGP_PROJECTS ADD PROJECT_LIST_ID nvarchar(400) NULL
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_TEAMS')
                begin
                                print 'Creating Table EPGP_TEAMS'

CREATE TABLE dbo.EPGP_TEAMS
(
	PROJECT_ID int NOT NULL,
	WRES_ID int NOT NULL,
	RES_IN_PLAN tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGP_TEAMS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_INT_VALUES')
                begin
                                print 'Creating Table EPGP_PROJECT_INT_VALUES'

CREATE TABLE dbo.EPGP_PROJECT_INT_VALUES
(
	PROJECT_ID int NOT NULL Primary Key,
	PI_001 int NULL,
	PI_002 int NULL,
	PI_003 int NULL,
	PI_004 int NULL,
	PI_005 int NULL,
	PI_006 int NULL,
	PI_007 int NULL,
	PI_008 int NULL,
	PI_009 int NULL,
	PI_010 int NULL,
	PI_011 int NULL,
	PI_012 int NULL,
	PI_013 int NULL,
	PI_014 int NULL,
	PI_015 int NULL,
	PI_016 int NULL,
	PI_017 int NULL,
	PI_018 int NULL,
	PI_019 int NULL,
	PI_020 int NULL,
	PI_021 int NULL,
	PI_022 int NULL,
	PI_023 int NULL,
	PI_024 int NULL,
	PI_025 int NULL,
	PI_026 int NULL,
	PI_027 int NULL,
	PI_028 int NULL,
	PI_029 int NULL,
	PI_030 int NULL,
	PI_031 int NULL,
	PI_032 int NULL,
	PI_033 int NULL,
	PI_034 int NULL,
	PI_035 int NULL,
	PI_036 int NULL,
	PI_037 int NULL,
	PI_038 int NULL,
	PI_039 int NULL,
	PI_040 int NULL,
	PI_041 int NULL,
	PI_042 int NULL,
	PI_043 int NULL,
	PI_044 int NULL,
	PI_045 int NULL,
	PI_046 int NULL,
	PI_047 int NULL,
	PI_048 int NULL,
	PI_049 int NULL,
	PI_050 int NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_INT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_TEXT_VALUES')
                begin
                                print 'Creating Table EPGP_PROJECT_TEXT_VALUES'

CREATE TABLE dbo.EPGP_PROJECT_TEXT_VALUES
(
	PROJECT_ID int NOT NULL Primary Key,
	PT_001 nvarchar(255) NULL,
	PT_002 nvarchar(255) NULL,
	PT_003 nvarchar(255) NULL,
	PT_004 nvarchar(255) NULL,
	PT_005 nvarchar(255) NULL,
	PT_006 nvarchar(255) NULL,
	PT_007 nvarchar(255) NULL,
	PT_008 nvarchar(255) NULL,
	PT_009 nvarchar(255) NULL,
	PT_010 nvarchar(255) NULL,
	PT_011 nvarchar(255) NULL,
	PT_012 nvarchar(255) NULL,
	PT_013 nvarchar(255) NULL,
	PT_014 nvarchar(255) NULL,
	PT_015 nvarchar(255) NULL,
	PT_016 nvarchar(255) NULL,
	PT_017 nvarchar(255) NULL,
	PT_018 nvarchar(255) NULL,
	PT_019 nvarchar(255) NULL,
	PT_020 nvarchar(255) NULL,
	PT_021 nvarchar(255) NULL,
	PT_022 nvarchar(255) NULL,
	PT_023 nvarchar(255) NULL,
	PT_024 nvarchar(255) NULL,
	PT_025 nvarchar(255) NULL,
	PT_026 nvarchar(255) NULL,
	PT_027 nvarchar(255) NULL,
	PT_028 nvarchar(255) NULL,
	PT_029 nvarchar(255) NULL,
	PT_030 nvarchar(255) NULL,
	PT_031 nvarchar(255) NULL,
	PT_032 nvarchar(255) NULL,
	PT_033 nvarchar(255) NULL,
	PT_034 nvarchar(255) NULL,
	PT_035 nvarchar(255) NULL,
	PT_036 nvarchar(255) NULL,
	PT_037 nvarchar(255) NULL,
	PT_038 nvarchar(255) NULL,
	PT_039 nvarchar(255) NULL,
	PT_040 nvarchar(255) NULL,
	PT_041 nvarchar(255) NULL,
	PT_042 nvarchar(255) NULL,
	PT_043 nvarchar(255) NULL,
	PT_044 nvarchar(255) NULL,
	PT_045 nvarchar(255) NULL,
	PT_046 nvarchar(255) NULL,
	PT_047 nvarchar(255) NULL,
	PT_048 nvarchar(255) NULL,
	PT_049 nvarchar(255) NULL,
	PT_050 nvarchar(255) NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_TEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_DEC_VALUES')
                begin
                                print 'Creating Table EPGP_PROJECT_DEC_VALUES'

CREATE TABLE dbo.EPGP_PROJECT_DEC_VALUES
(
	PROJECT_ID int NOT NULL Primary Key,
	PC_001 decimal(25,6) NULL,
	PC_002 decimal(25,6) NULL,
	PC_003 decimal(25,6) NULL,
	PC_004 decimal(25,6) NULL,
	PC_005 decimal(25,6) NULL,
	PC_006 decimal(25,6) NULL,
	PC_007 decimal(25,6) NULL,
	PC_008 decimal(25,6) NULL,
	PC_009 decimal(25,6) NULL,
	PC_010 decimal(25,6) NULL,
	PC_011 decimal(25,6) NULL,
	PC_012 decimal(25,6) NULL,
	PC_013 decimal(25,6) NULL,
	PC_014 decimal(25,6) NULL,
	PC_015 decimal(25,6) NULL,
	PC_016 decimal(25,6) NULL,
	PC_017 decimal(25,6) NULL,
	PC_018 decimal(25,6) NULL,
	PC_019 decimal(25,6) NULL,
	PC_020 decimal(25,6) NULL,
	PC_021 decimal(25,6) NULL,
	PC_022 decimal(25,6) NULL,
	PC_023 decimal(25,6) NULL,
	PC_024 decimal(25,6) NULL,
	PC_025 decimal(25,6) NULL,
	PC_026 decimal(25,6) NULL,
	PC_027 decimal(25,6) NULL,
	PC_028 decimal(25,6) NULL,
	PC_029 decimal(25,6) NULL,
	PC_030 decimal(25,6) NULL,
	PC_031 decimal(25,6) NULL,
	PC_032 decimal(25,6) NULL,
	PC_033 decimal(25,6) NULL,
	PC_034 decimal(25,6) NULL,
	PC_035 decimal(25,6) NULL,
	PC_036 decimal(25,6) NULL,
	PC_037 decimal(25,6) NULL,
	PC_038 decimal(25,6) NULL,
	PC_039 decimal(25,6) NULL,
	PC_040 decimal(25,6) NULL,
	PC_041 decimal(25,6) NULL,
	PC_042 decimal(25,6) NULL,
	PC_043 decimal(25,6) NULL,
	PC_044 decimal(25,6) NULL,
	PC_045 decimal(25,6) NULL,
	PC_046 decimal(25,6) NULL,
	PC_047 decimal(25,6) NULL,
	PC_048 decimal(25,6) NULL,
	PC_049 decimal(25,6) NULL,
	PC_050 decimal(25,6) NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_DEC_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_NTEXT_VALUES')
                begin
                                print 'Creating Table EPGP_PROJECT_NTEXT_VALUES'

CREATE TABLE dbo.EPGP_PROJECT_NTEXT_VALUES
(
	PROJECT_ID int NOT NULL Primary Key,
	PN_001 ntext NULL,
	PN_002 ntext NULL,
	PN_003 ntext NULL,
	PN_004 ntext NULL,
	PN_005 ntext NULL,
	PN_006 ntext NULL,
	PN_007 ntext NULL,
	PN_008 ntext NULL,
	PN_009 ntext NULL,
	PN_010 ntext NULL,
	PN_011 ntext NULL,
	PN_012 ntext NULL,
	PN_013 ntext NULL,
	PN_014 ntext NULL,
	PN_015 ntext NULL,
	PN_016 ntext NULL,
	PN_017 ntext NULL,
	PN_018 ntext NULL,
	PN_019 ntext NULL,
	PN_020 ntext NULL,
	PN_021 ntext NULL,
	PN_022 ntext NULL,
	PN_023 ntext NULL,
	PN_024 ntext NULL,
	PN_025 ntext NULL,
	PN_026 ntext NULL,
	PN_027 ntext NULL,
	PN_028 ntext NULL,
	PN_029 ntext NULL,
	PN_030 ntext NULL,
	PN_031 ntext NULL,
	PN_032 ntext NULL,
	PN_033 ntext NULL,
	PN_034 ntext NULL,
	PN_035 ntext NULL,
	PN_036 ntext NULL,
	PN_037 ntext NULL,
	PN_038 ntext NULL,
	PN_039 ntext NULL,
	PN_040 ntext NULL,
	PN_041 ntext NULL,
	PN_042 ntext NULL,
	PN_043 ntext NULL,
	PN_044 ntext NULL,
	PN_045 ntext NULL,
	PN_046 ntext NULL,
	PN_047 ntext NULL,
	PN_048 ntext NULL,
	PN_049 ntext NULL,
	PN_050 ntext NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_NTEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_DATE_VALUES')
                begin
                                print 'Creating Table EPGP_PROJECT_DATE_VALUES'

CREATE TABLE dbo.EPGP_PROJECT_DATE_VALUES
(
	PROJECT_ID int NOT NULL Primary Key,
	PD_001 datetime NULL,
	PD_002 datetime NULL,
	PD_003 datetime NULL,
	PD_004 datetime NULL,
	PD_005 datetime NULL,
	PD_006 datetime NULL,
	PD_007 datetime NULL,
	PD_008 datetime NULL,
	PD_009 datetime NULL,
	PD_010 datetime NULL,
	PD_011 datetime NULL,
	PD_012 datetime NULL,
	PD_013 datetime NULL,
	PD_014 datetime NULL,
	PD_015 datetime NULL,
	PD_016 datetime NULL,
	PD_017 datetime NULL,
	PD_018 datetime NULL,
	PD_019 datetime NULL,
	PD_020 datetime NULL,
	PD_021 datetime NULL,
	PD_022 datetime NULL,
	PD_023 datetime NULL,
	PD_024 datetime NULL,
	PD_025 datetime NULL,
	PD_026 datetime NULL,
	PD_027 datetime NULL,
	PD_028 datetime NULL,
	PD_029 datetime NULL,
	PD_030 datetime NULL,
	PD_031 datetime NULL,
	PD_032 datetime NULL,
	PD_033 datetime NULL,
	PD_034 datetime NULL,
	PD_035 datetime NULL,
	PD_036 datetime NULL,
	PD_037 datetime NULL,
	PD_038 datetime NULL,
	PD_039 datetime NULL,
	PD_040 datetime NULL,
	PD_041 datetime NULL,
	PD_042 datetime NULL,
	PD_043 datetime NULL,
	PD_044 datetime NULL,
	PD_045 datetime NULL,
	PD_046 datetime NULL,
	PD_047 datetime NULL,
	PD_048 datetime NULL,
	PD_049 datetime NULL,
	PD_050 datetime NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_DATE_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_STAGES')
                begin
                                print 'Creating Table EPGP_PROJECT_STAGES'

CREATE TABLE dbo.EPGP_PROJECT_STAGES
(
	PROJECT_ID int,
	STAGE_ID int,
	WRES_ID int,
	STAGE_DATE datetime,
	STAGE_OWNER int
)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_STAGES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_FIELD_ATTRIBS')
                begin
                                print 'Creating Table EPGP_FIELD_ATTRIBS'

CREATE TABLE dbo.EPGP_FIELD_ATTRIBS
(
	FA_FIELD_ID int Primary Key,
	FA_NAME nvarchar(255),
	FA_DESC [nvarchar](255) NULL,
	FA_LOOKUPONLY tinyint,
	FA_LOOKUP_UID int,
	FA_LEAFONLY tinyint,
	FA_USEFULLNAME tinyint,
	FA_VALUE_UNIQUE tinyint,
	FA_ADMIN tinyint
)

                end
else
                begin
                                Print 'Updating Table EPGP_FIELD_ATTRIBS'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPGP_FIELD_ATTRIBS' and column_name = 'FA_DESC')
                                begin
                                                Print '     Add Column FA_DESC'
                                                ALTER TABLE EPGP_FIELD_ATTRIBS ADD FA_DESC [nvarchar](255) NULL
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_LOOKUP_TABLES')
                begin
                                print 'Creating Table EPGP_LOOKUP_TABLES'

CREATE TABLE dbo.EPGP_LOOKUP_TABLES
(
	LOOKUP_UID int IDENTITY (1, 1) NOT NULL,
	LOOKUP_NAME nvarchar(255) NOT NULL,
	LOOKUP_DESC nvarchar(255) NULL,
	LOOKUP_EXT_UID nvarchar(64) NULL,
	LOOKUP_EXT_NAME nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_LOOKUP_TABLES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_LOOKUP_VALUES')
                begin
                                print 'Creating Table EPGP_LOOKUP_VALUES'

CREATE TABLE dbo.EPGP_LOOKUP_VALUES
(
	LOOKUP_UID int,
	LV_UID int IDENTITY (1, 1) NOT NULL,
	LV_EXT_UID nvarchar(64),
	LV_VALUE nvarchar(255),
	LV_FULLVALUE nvarchar(1000),
	LV_ID int NOT NULL,
	LV_LEVEL int NOT NULL,
	LV_INACTIVE tinyint NOT NULL default 0
)

                end
else
                begin
                                Print 'Updating Table EPGP_LOOKUP_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_LAYOUT_PAGES')
                begin
                                print 'Creating Table EPGP_LAYOUT_PAGES'

CREATE TABLE dbo.EPGP_LAYOUT_PAGES
(
	TAB_ID int NOT NULL,
	TAB_NAME nvarchar(255) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_LAYOUT_PAGES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_LAYOUT_GROUPS')
                begin
                                print 'Creating Table EPGP_LAYOUT_GROUPS'

CREATE TABLE dbo.EPGP_LAYOUT_GROUPS
(
	TAB_ID int NOT NULL,
	TABGROUP_ID int NOT NULL,
	TABGROUP_NAME nvarchar(255) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_LAYOUT_GROUPS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_LAYOUT_FIELDS')
                begin
                                print 'Creating Table EPGP_LAYOUT_FIELDS'

CREATE TABLE dbo.EPGP_LAYOUT_FIELDS
(
	TAB_ID int NOT NULL,
	TABGROUP_ID int NOT NULL,
	FIELD_ID int NOT NULL,
	LF_NAME nvarchar(255) NULL,
	LF_DESC nvarchar(255) NULL,
    LF_SEQ int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_LAYOUT_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_STAGES')
                begin
                                print 'Creating Table EPGP_STAGES'

CREATE TABLE dbo.EPGP_STAGES
(
	STAGE_ID int NOT NULL,
	STAGE_SEQ int NOT NULL,
	STAGE_NAME nvarchar(255) NOT NULL,
	STAGE_INACTIVE tinyint,
	STAGE_OWNER_CRIT nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPGP_STAGES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_NEXT_STAGES')
                begin
                                print 'Creating Table EPGP_NEXT_STAGES'

CREATE TABLE dbo.EPGP_NEXT_STAGES
(
	WORKFLOW_PATH int NOT NULL Default 0,
	STAGE_ID int NOT NULL,
	NEXT_STAGE_ID int NOT NULL,
	NEXT_SEQ int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_NEXT_STAGES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_STAGE_FIELDS')
                begin
                                print 'Creating Table EPGP_STAGE_FIELDS'

CREATE TABLE dbo.EPGP_STAGE_FIELDS
(
	STAGE_ID int NOT NULL,
	FIELD_ID int NOT NULL,
	SF_REQUIRED tinyint,
	SF_EDITABLE tinyint,
	SF_VISIBLE tinyint	
)

                end
else
                begin
                                Print 'Updating Table EPGP_STAGE_FIELDS'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_GROUP_SECURITY')
                begin
                                print 'Creating Table EPGP_PROJECT_GROUP_SECURITY'

CREATE TABLE [dbo].[EPGP_PROJECT_GROUP_SECURITY] 
(
	PROJECT_ID int NOT NULL ,
	GROUP_ID int NOT NULL ,
	VIEW_PERMISSION int NOT NULL ,
	EDIT_PERMISSION int NOT NULL ,
	STAGE_PERMISSION int NOT NULL ,
	BUDGET_PERMISSION int NOT NULL,
    SECURITY_PERMISSION int NOT NULL
) 

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_GROUP_SECURITY'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_RESOURCE_SECURITY')
                begin
                                print 'Creating Table EPGP_PROJECT_RESOURCE_SECURITY'

CREATE TABLE [dbo].[EPGP_PROJECT_RESOURCE_SECURITY] 
(
	PROJECT_ID int NOT NULL ,
	WRES_ID int NOT NULL ,
	VIEW_PERMISSION int NOT NULL ,
	EDIT_PERMISSION int NOT NULL ,
	STAGE_PERMISSION int NOT NULL ,
	BUDGET_PERMISSION int NOT NULL, 
    SECURITY_PERMISSION int NOT NULL
) 

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_RESOURCE_SECURITY'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_DATA_SECURITY')
                begin
                                print 'Creating Table EPGP_DATA_SECURITY'

CREATE TABLE [dbo].[EPGP_DATA_SECURITY] 
(
	DS_CONTEXT int NOT NULL ,
	DS_UID int NOT NULL ,
	GROUP_ID int NOT NULL,
	DS_READ tinyint ,
	DS_EDIT tinyint
) 

                end
else
                begin
                                Print 'Updating Table EPGP_DATA_SECURITY'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_NONWORK_ITEMS')
                begin
                                print 'Creating Table EPG_NONWORK_ITEMS'

CREATE TABLE dbo.EPG_NONWORK_ITEMS
(
	NWI_ID int NOT NULL,
	NWI_SEQ int NOT NULL,
	NWI_LEVEL int NOT NULL,
	NWI_IS_ITEM tinyint,
	NWI_TS_ONLY tinyint,
	NWI_NAME nvarchar(255),
	NWI_CHARGENUMBER nvarchar(255) NOT NULL,
	NWI_CHARGESTATUS nvarchar(255),
	NWI_MAJORCATEGORY nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_NONWORK_ITEMS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_NONWORK_HOURS')
                begin
                                print 'Creating Table EPG_NONWORK_HOURS'

CREATE TABLE dbo.EPG_NONWORK_HOURS
(
	NWH_UID int IDENTITY (1, 1) NOT NULL,
	NWI_ID int NOT NULL,
	WRES_ID int,
	NWH_DATE DATETIME,
	NWH_TIMESTAMP DATETIME,
	NWH_ENTEREDBY_WRES_ID int,
	NWH_HOURS Decimal(25,6) NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_NONWORK_HOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RESOURCEPLANS')
                begin
                                print 'Creating Table EPG_RESOURCEPLANS'

CREATE TABLE dbo.EPG_RESOURCEPLANS
(
	CMT_UID int NOT NULL,
	CMT_GUID uniqueidentifier NOT NULL DEFAULT NEWID(),
	RP_PM_STATUS tinyint default 0,
	RP_RM_STATUS tinyint default 0,
	RP_ACTIVE_COMMITMENT tinyint default 0,
	RP_GROUP nvarchar(255),
	PROJECT_ID int NOT NULL,
	WRES_ID int default 0,
	WRES_ID_PENDING int default 0,
	CMT_START_DATE datetime NULL,
	CMT_FINISH_DATE datetime NULL,
	CMT_ALLOCATION Decimal(25,6) NULL,
	CMT_ALLOCATION_MODE int NULL,
	CMT_TIMESTAMP datetime,
	CMT_ENTEREDBY_WRES_ID int,
	CMT_STATUS int NOT NULL,
	BC_UID int,
	PARENT_BC_UID int,
	CMT_ROLE int NOT NULL,
	CMT_DEPT int,
	CMT_HOURS Decimal(25,6) NULL,
	CMT_RATETYPE_UID int,
	CMT_RATE_PRD_ID int,
	CMT_RATE Decimal(25,6) NULL,
    CMT_CALC_TOTAL_COST Decimal(25,6) NULL,
    CMT_TOTAL_COST Decimal(25,6) NULL,
	CMT_MAJORCATEGORY nvarchar(255) NULL,
	CMT_DESC nvarchar(255),
	CMT_RT_UID int NULL,
	CMT_PRIVATE tinyint default 0,
	CMT_LAST_EVENT_CONTEXT tinyint default 0
)

                end
else
                begin
                                Print 'Updating Table EPG_RESOURCEPLANS'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RESOURCEPLANS' and column_name = 'CMT_GUID')
                                begin
                                                Print '     Add Column CMT_GUID and populate with guids'
                                                ALTER TABLE EPG_RESOURCEPLANS ADD [CMT_GUID] [uniqueidentifier] NOT NULL DEFAULT NEWID()
                                end
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RESOURCEPLANS' and column_name = 'CMT_PRIVATE')
                                begin
                                                Print '     Add Column CMT_PRIVATE'
                                                ALTER TABLE EPG_RESOURCEPLANS ADD CMT_PRIVATE [tinyint] DEFAULT 0
                                end
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RESOURCEPLANS' and column_name = 'CMT_LAST_EVENT_CONTEXT')
                                begin
                                                Print '     Add Column CMT_LAST_EVENT_CONTEXT'
                                                ALTER TABLE EPG_RESOURCEPLANS ADD CMT_LAST_EVENT_CONTEXT [tinyint] DEFAULT 0
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RESOURCEPLANS_HOURS')
                begin
                                print 'Creating Table EPG_RESOURCEPLANS_HOURS'

CREATE TABLE dbo.EPG_RESOURCEPLANS_HOURS
(
	CMT_UID int NOT NULL,
	PRD_ID int NOT NULL,
	CMH_HOURS Decimal(25,6) NULL,
	CMH_FTES int NULL,
	CMH_REVENUES Decimal(25,6) NULL,
	CMH_MODE tinyint NULL,
	CMH_PENDING tinyint default 0,
	CMH_ENTEREDBY tinyint NULL	-- 0=PM; 1=RM;
)

                end
else
                begin
                                Print 'Updating Table EPG_RESOURCEPLANS_HOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RPE_NOTES')
	begin
		print 'Creating Table EPG_RPE_NOTES'

		CREATE TABLE dbo.EPG_RPE_NOTES
		(
			RPEN_UID int IDENTITY (1, 1) NOT NULL,
			RPEN_CONTEXT tinyint NOT NULL DEFAULT 0,
			RPEN_EVENT_CONTEXT tinyint NOT NULL DEFAULT 0,
			RPEN_PFE_PROCESSED tinyint NOT NULL DEFAULT 0,
			RPEN_PROJECT_ID int NOT NULL DEFAULT 0,
			RPEN_CMT_GUID uniqueidentifier NOT NULL,
			RPEN_TIMESTAMP datetime NOT NULL,
			RPEN_WRES_ID int NOT NULL,
			RPEN_TO ntext,
			RPEN_TITLE ntext,
			RPEN_HTML ntext
		)

	end
else
	begin
					Print 'Updating Table EPG_RPE_NOTES'
                    if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RPE_NOTES' and column_name = 'RPEN_TO')
                    begin
                                    Print '     Add Column RPEN_TO'
                                    ALTER TABLE EPG_RPE_NOTES ADD RPEN_TO ntext
                    end
                    if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RPE_NOTES' and column_name = 'RPEN_CONTEXT')
                    begin
                                    Print '     Add Column RPEN_CONTEXT'
                                    ALTER TABLE EPG_RPE_NOTES ADD RPEN_CONTEXT tinyint NOT NULL DEFAULT 0
                    end
                    if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RPE_NOTES' and column_name = 'RPEN_EVENT_CONTEXT')
                    begin
                                    Print '     Add Column RPEN_EVENT_CONTEXT'
                                    ALTER TABLE EPG_RPE_NOTES ADD RPEN_EVENT_CONTEXT tinyint NOT NULL DEFAULT 0
                    end
                    if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_RPE_NOTES' and column_name = 'RPEN_PFE_PROCESSED')
                    begin
                                    Print '     Add Column RPEN_PFE_PROCESSED'
                                    ALTER TABLE EPG_RPE_NOTES ADD RPEN_PFE_PROCESSED tinyint NOT NULL DEFAULT 0
                    end
	end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_CATEGORIES')
                begin
                                print 'Creating Table EPGP_CATEGORIES'

CREATE TABLE dbo.EPGP_CATEGORIES
(
	CA_UID int NOT NULL,
	CA_NAME nvarchar(255),
	CA_ID int NOT NULL,
	CA_LEVEL int NOT NULL,
	CA_ROLE int,
	CA_UOM nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPGP_CATEGORIES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_CATEGORIES')
                begin
                                print 'Creating Table EPGP_COST_CATEGORIES'

CREATE TABLE dbo.EPGP_COST_CATEGORIES
(
	BC_UID int NOT NULL,
	BC_NAME nvarchar(255),
	BC_ID int NOT NULL,
	BC_LEVEL int NOT NULL,
	BC_ROLE int,
	BC_UOM nvarchar(255),
	MC_UID int NOT NULL Default 0,
	CA_UID int NOT NULL Default 0
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_CATEGORIES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_BREAKDOWNS')
                begin
                                print 'Creating Table EPGP_COST_BREAKDOWNS'

CREATE TABLE dbo.EPGP_COST_BREAKDOWNS
(
	CB_ID int NOT NULL,
	CB_NAME nvarchar(255),
	CB_DESC [nvarchar](255) NULL,
	CB_LOCK_TO int,
	CB_LOCK_FROM int
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_BREAKDOWNS'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPGP_COST_BREAKDOWNS' and column_name = 'CB_DESC')
                                begin
                                                Print '     Add Column CB_DESC'
                                                ALTER TABLE EPGP_COST_BREAKDOWNS ADD CB_DESC [nvarchar](255) NULL
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_BREAKDOWN_ATTRIBS')
                begin
                                print 'Creating Table EPGP_COST_BREAKDOWN_ATTRIBS'

CREATE TABLE dbo.EPGP_COST_BREAKDOWN_ATTRIBS
(
	CB_ID int NOT NULL,
	BA_RATETYPE_UID int  NOT NULL Default 0,
	BA_CODE_UID int NOT NULL Default 0,
	BA_BC_UID int NOT NULL,
	BA_PRD_ID int NOT NULL,
	BA_FTE_CONV int,
	BA_RATE decimal(15,6)
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_BREAKDOWN_ATTRIBS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_TYPES')
                begin
                                print 'Creating Table EPGP_COST_TYPES'

CREATE TABLE dbo.EPGP_COST_TYPES
(
	CT_ID int IDENTITY (1, 1) NOT NULL,
	CT_NAME nvarchar(255),
	CT_EDIT_MODE int,
	INITIAL_LEVEL int,
	CT_CB_ID int NULL,
	CT_ALLOW_NAMED_RATES tinyint NOT NULL Default 0
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_TYPES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_AVAIL_CATEGORIES')
                begin
                                print 'Creating Table EPGP_AVAIL_CATEGORIES'

CREATE TABLE dbo.EPGP_AVAIL_CATEGORIES
(
	CT_ID int NOT NULL,
	BC_UID int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_AVAIL_CATEGORIES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_BREAKDOWN_COST_TYPES')
                begin
                                print 'Creating Table EPGP_BREAKDOWN_COST_TYPES'

CREATE TABLE dbo.EPGP_BREAKDOWN_COST_TYPES
(
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	BUDGET_TOTAL_FIELD int
)

                end
else
                begin
                                Print 'Updating Table EPGP_BREAKDOWN_COST_TYPES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_CALC')
                begin
                                print 'Creating Table EPGP_COST_CALC'

CREATE TABLE dbo.EPGP_COST_CALC
(
	CT_ID int NOT NULL,
	CL_ID int NOT NULL,
	CL_CT_ID int NOT NULL,
	CL_OP int
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_CALC'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_CALCS')
                begin
                                print 'Creating Table EPGP_CALCS'

CREATE TABLE dbo.EPGP_CALCS
(
	CL_OBJECT int NOT NULL,
	CL_UID int NOT NULL,
	CL_SEQ int NOT NULL,
	CL_RESULT int NOT NULL,
	CL_COMPONENT int NOT NULL,
	CL_RATIO decimal(25,6) NULL,
	CL_OP int,
	CL_PRI tinyint
)

                end
else
                begin
                                Print 'Updating Table EPGP_CALCS'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPGP_CALCS' and column_name = 'CL_PRI')
                                begin
                                                Print '     Add Column CL_PRI'
                                                ALTER TABLE EPGP_CALCS ADD CL_PRI tinyint
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_CUSTOM_FIELDS')
                begin
                                print 'Creating Table EPGP_COST_CUSTOM_FIELDS'

CREATE TABLE dbo.EPGP_COST_CUSTOM_FIELDS
(
	CT_ID int NOT NULL,
	CF_ID int NOT NULL,
	CF_FIELD_ID int NOT NULL,
	CF_EDITABLE tinyint,
	CF_VISIBLE tinyint,
	CF_FROZEN tinyint,
	CF_IDENTITY tinyint,
	CF_REQUIRED tinyint
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_CUSTOM_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_CFFILTER')
                begin
                                print 'Creating Table EPGP_COST_CFFILTER'

CREATE TABLE dbo.EPGP_COST_CFFILTER
(
	CT_ID int NOT NULL,
	CFF_FIELD_ID int NOT NULL,
	CFF_ID int NOT NULL,
	CFF_VALUE nvarchar(255) NULL,
	CFF_FLAG tinyint,
  Primary Key (CT_ID,CFF_FIELD_ID,CFF_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_CFFILTER'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_VALUES')
                begin
                                print 'Creating Table EPGP_COST_VALUES'

CREATE TABLE dbo.EPGP_COST_VALUES
(
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	BC_UID int NOT NULL,
	BD_PERIOD int NOT NULL,
	BD_VALUE decimal(25,6),
	BD_COST decimal(25,6),
	BD_IS_SUMMARY tinyint,
	BD_BATCH nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_DETAILS')
                begin
                                print 'Creating Table EPGP_COST_DETAILS'

CREATE TABLE dbo.EPGP_COST_DETAILS
(
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	BC_UID int NOT NULL,
	BC_SEQ int NOT NULL,
	RT_UID int NULL,
	OC_01 int NULL,
	OC_02 int NULL,
	OC_03 int NULL,
	OC_04 int NULL,
	OC_05 int NULL,
	TEXT_01 nvarchar(255) NULL,
	TEXT_02 nvarchar(255) NULL,
	TEXT_03 nvarchar(255) NULL,
	TEXT_04 nvarchar(255) NULL,
	TEXT_05 nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_DETAILS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_DETAIL_VALUES')
                begin
                                print 'Creating Table EPGP_DETAIL_VALUES'

CREATE TABLE dbo.EPGP_DETAIL_VALUES
(
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	BC_UID int NOT NULL,
	BC_SEQ int NOT NULL,
	BD_PERIOD int NOT NULL,
	BD_VALUE decimal(25,6),
	BD_COST decimal(25,6)
)

                end
else
                begin
                                Print 'Updating Table EPGP_DETAIL_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_XREF')
                begin
                                print 'Creating Table EPGP_COST_XREF'

CREATE TABLE dbo.EPGP_COST_XREF
(
	WRES_ID int,
	BC_UID int
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_XREF'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_MY_RESOURCES')
                begin
                                print 'Creating Table EPG_MY_RESOURCES'

CREATE TABLE dbo.EPG_MY_RESOURCES
(
	WRES_ID int NOT NULL,
	MR_SEQ int NOT NULL,
	MR_WRES_ID int NOT NULL,
	MR_NOTES nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_MY_RESOURCES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_CT_STATUS')
                begin
                                print 'Creating Table EPGP_PROJECT_CT_STATUS'

CREATE TABLE dbo.EPGP_PROJECT_CT_STATUS
(
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	BC_UID int NOT NULL,
	BC_STATUS int NOT NULL	
)

                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_CT_STATUS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_VALUES_INFO')
                begin
                                print 'Creating Table EPGP_COST_VALUES_INFO'

CREATE TABLE dbo.EPGP_COST_VALUES_INFO
(
 CB_ID int NOT NULL,
 CT_ID int NOT NULL,
 CV_INFO nvarchar(255) NULL,
 CV_TIMESTAMP datetime NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_VALUES_INFO'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_VALUES_TOSET')
                begin
                                print 'Creating Table EPGP_COST_VALUES_TOSET'

CREATE TABLE dbo.EPGP_COST_VALUES_TOSET
(
 TOSET_MAINKEY int NULL,
 CB_ID int NOT NULL,
 CT_ID int NOT NULL,
 CV_TIMESTAMP datetime NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_VALUES_TOSET'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_SHORTCUTS')
                begin
                                print 'Creating Table EPG_SHORTCUTS'

CREATE TABLE dbo.EPG_SHORTCUTS
(
	SHC_UID int NOT NULL,
	SHC_NAME nvarchar(255) NOT NULL,
	SHC_USERFIELD int NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_SHORTCUTS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_WORKITEMS')
                begin
                                print 'Creating Table EPGP_PI_WORKITEMS'

CREATE TABLE dbo.EPGP_PI_WORKITEMS
(
	PROJECT_ID int NOT NULL,
	WORKITEM_ID int NOT NULL,
	WORKITEM_SEQ int NOT NULL,
	WORKITEM_LEVEL int,
	WORKITEM_NAME nvarchar(255) NULL,
	WORKITEM_IMPOSED_DATE datetime,
	WORKITEM_START_DATE datetime,
	WORKITEM_FINISH_DATE datetime,
	WORKITEM_BASELINE_START_DATE datetime,
	WORKITEM_BASELINE_FINISH_DATE datetime,
	WORKITEM_DURATION int,
	WORKITEM_IS_MILESTONE int,
	WORKITEM_MILESTONE_LEVEL int,
	WORKITEM_STATUS int,
	WORKITEM_CREATED datetime,
	WORKITEM_CREATEDBY int,
	WORKITEM_OWNER int NOT NULL,
	WORKITEM_WORK decimal(25,6),
	WORKITEM_ACTUAL_START_DATE datetime NULL,
	WORKITEM_ACTUAL_FINISH_DATE datetime NULL,
	WORKITEM_PERCENT_COMPLETE int NULL,
	WORKITEM_CHARGENUMBER nvarchar(255) NULL,
	WORKITEM_CHARGESTATUS nvarchar(255) NULL,
	WORKITEM_MAJORCATEGORY nvarchar(255) NULL,
	WORKITEM_TEXT1 nvarchar(255) NULL,
	WORKITEM_TEXT2 nvarchar(255) NULL,
	WORKITEM_CTEXT1 nvarchar(255) NULL,
	WORKITEM_CTEXT2 nvarchar(255) NULL,
	WORKITEM_CTEXT3 nvarchar(255) NULL,
	WORKITEM_CTEXT4 nvarchar(255) NULL,
	WORKITEM_CTEXT5 nvarchar(255) NULL,
	WORKITEM_CTEXT6 nvarchar(255) NULL,
	WORKITEM_CTEXT7 nvarchar(255) NULL,
	WORKITEM_CTEXT8 nvarchar(255) NULL,
	WORKITEM_CTEXT9 nvarchar(255) NULL,
	WORKITEM_CTEXT10 nvarchar(255) NULL,
    WORKITEM_CTEXT11 nvarchar(255) NULL,
	WORKITEM_CTEXT12 nvarchar(255) NULL,
	WORKITEM_CTEXT13 nvarchar(255) NULL,
	WORKITEM_CTEXT14 nvarchar(255) NULL,
	WORKITEM_CTEXT15 nvarchar(255) NULL,
	WORKITEM_CTEXT16 nvarchar(255) NULL,
	WORKITEM_CTEXT17 nvarchar(255) NULL,
	WORKITEM_CTEXT18 nvarchar(255) NULL,
	WORKITEM_CTEXT19 nvarchar(255) NULL,
	WORKITEM_CTEXT20 nvarchar(255) NULL,
	WORKITEM_FLAG1 tinyint,
	WORKITEM_FLAG2 tinyint,
	WORKITEM_FLAG3 tinyint,
	WORKITEM_FLAG4 tinyint,
	WORKITEM_FLAG5 tinyint,
	WORKITEM_FLAG6 tinyint,
	WORKITEM_FLAG7 tinyint,
	WORKITEM_FLAG8 tinyint,
	WORKITEM_FLAG9 tinyint,
	WORKITEM_FLAG10 tinyint,
	WORKITEM_NUMBER1 decimal(25,6),
	WORKITEM_NUMBER2 decimal(25,6),
	WORKITEM_NUMBER3 decimal(25,6),
	WORKITEM_NUMBER4 decimal(25,6),
	WORKITEM_NUMBER5 decimal(25,6),
	WORKITEM_NUMBER6 decimal(25,6),
	WORKITEM_NUMBER7 decimal(25,6),
	WORKITEM_NUMBER8 decimal(25,6),
	WORKITEM_NUMBER9 decimal(25,6),
	WORKITEM_NUMBER10 decimal(25,6),
        Primary Key (PROJECT_ID,WORKITEM_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_WORKITEMS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_WORKITEM_ASSNS')
                begin
                                print 'Creating Table EPGP_PI_WORKITEM_ASSNS'

CREATE TABLE dbo.EPGP_PI_WORKITEM_ASSNS
(
	PROJECT_ID int NOT NULL,
	WORKITEM_ID int NOT NULL,
	WRES_ID int NOT NULL,
	WIRES_WORK decimal(25,6),
	WIRES_ACTUALWORK decimal(25,6),
	WIRES_PERCENT_COMPLETE int NULL,
	WIRES_ACTUAL_START_DATE datetime NULL,
	WIRES_ACTUAL_FINISH_DATE datetime NULL,
  Primary Key (PROJECT_ID,WORKITEM_ID,WRES_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_WORKITEM_ASSNS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_WORKITEM_LOGIC')
                begin
                                print 'Creating Table EPGP_PI_WORKITEM_LOGIC'

CREATE TABLE dbo.EPGP_PI_WORKITEM_LOGIC
 (
	PROJECT_ID int NOT NULL ,
	WORKITEM_PRED_ID int NOT NULL ,
	WORKITEM_SUCC_ID int NOT NULL ,
	WORKITEM_TYPE int NOT NULL ,
) 

                end
else
                begin
                                Print 'Updating Table EPGP_PI_WORKITEM_LOGIC'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_WORKITEM_TSWORK')
                begin
                                print 'Creating Table EPGP_PI_WORKITEM_TSWORK'

CREATE TABLE dbo.EPGP_PI_WORKITEM_TSWORK
 (
	PROJECT_ID int NOT NULL,
	WRES_ID int NOT NULL,
	TSWORK_MAJORCATEGORY nvarchar(255) NULL,
	TSWORK_DATE datetime NULL,
	TSWORK_WORK decimal(25,6),
	TSWORK_REMAINING_WORK decimal(25,6)
) 

                end
else
                begin
                                Print 'Updating Table EPGP_PI_WORKITEM_TSWORK'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_LOCALVIEWS')
                begin
                                print 'Creating Table EPGT_LOCALVIEWS'

CREATE TABLE dbo.EPGT_LOCALVIEWS
(
	WRES_ID int NULL,
	WAU_UID int NULL,
	UINF_CONTEXT int NULL,
	UINF_DATA int NULL,
	UINF_VIEWNAME nvarchar(255) NULL,
	UINF_XML ntext 
)

                end
else
                begin
                                Print 'Updating Table EPGT_LOCALVIEWS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_WSS_LISTS')
                begin
                                print 'Creating Table EPGP_WSS_LISTS'

CREATE TABLE dbo.EPGP_WSS_LISTS
(
	WSS_LIST_ID int NOT NULL,
	WSS_BASE_TYPE int NOT NULL,
	WSS_TP_TITLE nvarchar(255) NOT NULL,
	WSS_DESC nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_WSS_LISTS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_WSS_FIELD_ATTRIBS')
                begin
                                print 'Creating Table EPGP_WSS_FIELD_ATTRIBS'

CREATE TABLE dbo.EPGP_WSS_FIELD_ATTRIBS
(
	WSS_LIST_ID int NOT NULL,
	WSS_FIELD_ID int NOT NULL,
	WSS_NAME nvarchar(255) NOT NULL,
	WSS_FIELD_TP1 int NULL,
  Primary Key (WSS_LIST_ID,WSS_FIELD_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGP_WSS_FIELD_ATTRIBS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_USERBUTTONS')
                begin
                                print 'Creating Table EPGT_USERBUTTONS'

CREATE TABLE dbo.EPGT_USERBUTTONS
(
	BTN_PAGE int NULL,
	BTN_SEQ int NULL,
	BTN_CAPTION nvarchar(255) NULL,
	BTN_TOOLTIP nvarchar(255) NULL,
	BTN_ACCESSKEY nchar(1) NULL,
	BTN_IMAGE nvarchar(255) NULL,
	BTN_WIDTH nvarchar(255) NULL,
	BTN_XMLTAG nvarchar(255) NULL,
	BTN_PERM int NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_USERBUTTONS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROG_INFOS')
                begin
                                print 'Creating Table EPGP_PROG_INFOS'

CREATE TABLE dbo.EPGP_PROG_INFOS
(
	FIELD_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PROG_START_DATE datetime,
	PROG_FINISH_DATE datetime,
	PROG_MANAGER int NULL,
	PROG_WSS_SITE nvarchar(255) NULL,
	PROG_WSS_SERVER_ID int
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROG_INFOS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROG_INT_VALUES')
                begin
                                print 'Creating Table EPGP_PROG_INT_VALUES'

CREATE TABLE dbo.EPGP_PROG_INT_VALUES
(
	FIELD_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PI_001 int NULL,
	PI_002 int NULL,
	PI_003 int NULL,
	PI_004 int NULL,
	PI_005 int NULL,
	PI_006 int NULL,
	PI_007 int NULL,
	PI_008 int NULL,
	PI_009 int NULL,
	PI_010 int NULL,
	PI_011 int NULL,
	PI_012 int NULL,
	PI_013 int NULL,
	PI_014 int NULL,
	PI_015 int NULL,
	PI_016 int NULL,
	PI_017 int NULL,
	PI_018 int NULL,
	PI_019 int NULL,
	PI_020 int NULL,
	PI_021 int NULL,
	PI_022 int NULL,
	PI_023 int NULL,
	PI_024 int NULL,
	PI_025 int NULL,
	PI_026 int NULL,
	PI_027 int NULL,
	PI_028 int NULL,
	PI_029 int NULL,
	PI_030 int NULL,
	PI_031 int NULL,
	PI_032 int NULL,
	PI_033 int NULL,
	PI_034 int NULL,
	PI_035 int NULL,
	PI_036 int NULL,
	PI_037 int NULL,
	PI_038 int NULL,
	PI_039 int NULL,
	PI_040 int NULL,
	PI_041 int NULL,
	PI_042 int NULL,
	PI_043 int NULL,
	PI_044 int NULL,
	PI_045 int NULL,
	PI_046 int NULL,
	PI_047 int NULL,
	PI_048 int NULL,
	PI_049 int NULL,
	PI_050 int NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PROG_INT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROG_TEXT_VALUES')
                begin
                                print 'Creating Table EPGP_PROG_TEXT_VALUES'

CREATE TABLE dbo.EPGP_PROG_TEXT_VALUES
(
	FIELD_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PT_001 nvarchar(255) NULL,
	PT_002 nvarchar(255) NULL,
	PT_003 nvarchar(255) NULL,
	PT_004 nvarchar(255) NULL,
	PT_005 nvarchar(255) NULL,
	PT_006 nvarchar(255) NULL,
	PT_007 nvarchar(255) NULL,
	PT_008 nvarchar(255) NULL,
	PT_009 nvarchar(255) NULL,
	PT_010 nvarchar(255) NULL,
	PT_011 nvarchar(255) NULL,
	PT_012 nvarchar(255) NULL,
	PT_013 nvarchar(255) NULL,
	PT_014 nvarchar(255) NULL,
	PT_015 nvarchar(255) NULL,
	PT_016 nvarchar(255) NULL,
	PT_017 nvarchar(255) NULL,
	PT_018 nvarchar(255) NULL,
	PT_019 nvarchar(255) NULL,
	PT_020 nvarchar(255) NULL,
	PT_021 nvarchar(255) NULL,
	PT_022 nvarchar(255) NULL,
	PT_023 nvarchar(255) NULL,
	PT_024 nvarchar(255) NULL,
	PT_025 nvarchar(255) NULL,
	PT_026 nvarchar(255) NULL,
	PT_027 nvarchar(255) NULL,
	PT_028 nvarchar(255) NULL,
	PT_029 nvarchar(255) NULL,
	PT_030 nvarchar(255) NULL,
	PT_031 nvarchar(255) NULL,
	PT_032 nvarchar(255) NULL,
	PT_033 nvarchar(255) NULL,
	PT_034 nvarchar(255) NULL,
	PT_035 nvarchar(255) NULL,
	PT_036 nvarchar(255) NULL,
	PT_037 nvarchar(255) NULL,
	PT_038 nvarchar(255) NULL,
	PT_039 nvarchar(255) NULL,
	PT_040 nvarchar(255) NULL,
	PT_041 nvarchar(255) NULL,
	PT_042 nvarchar(255) NULL,
	PT_043 nvarchar(255) NULL,
	PT_044 nvarchar(255) NULL,
	PT_045 nvarchar(255) NULL,
	PT_046 nvarchar(255) NULL,
	PT_047 nvarchar(255) NULL,
	PT_048 nvarchar(255) NULL,
	PT_049 nvarchar(255) NULL,
	PT_050 nvarchar(255) NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROG_TEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROG_DEC_VALUES')
                begin
                                print 'Creating Table EPGP_PROG_DEC_VALUES'

CREATE TABLE dbo.EPGP_PROG_DEC_VALUES
(
	FIELD_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PC_001 decimal(25,6) NULL,
	PC_002 decimal(25,6) NULL,
	PC_003 decimal(25,6) NULL,
	PC_004 decimal(25,6) NULL,
	PC_005 decimal(25,6) NULL,
	PC_006 decimal(25,6) NULL,
	PC_007 decimal(25,6) NULL,
	PC_008 decimal(25,6) NULL,
	PC_009 decimal(25,6) NULL,
	PC_010 decimal(25,6) NULL,
	PC_011 decimal(25,6) NULL,
	PC_012 decimal(25,6) NULL,
	PC_013 decimal(25,6) NULL,
	PC_014 decimal(25,6) NULL,
	PC_015 decimal(25,6) NULL,
	PC_016 decimal(25,6) NULL,
	PC_017 decimal(25,6) NULL,
	PC_018 decimal(25,6) NULL,
	PC_019 decimal(25,6) NULL,
	PC_020 decimal(25,6) NULL,
	PC_021 decimal(25,6) NULL,
	PC_022 decimal(25,6) NULL,
	PC_023 decimal(25,6) NULL,
	PC_024 decimal(25,6) NULL,
	PC_025 decimal(25,6) NULL,
	PC_026 decimal(25,6) NULL,
	PC_027 decimal(25,6) NULL,
	PC_028 decimal(25,6) NULL,
	PC_029 decimal(25,6) NULL,
	PC_030 decimal(25,6) NULL,
	PC_031 decimal(25,6) NULL,
	PC_032 decimal(25,6) NULL,
	PC_033 decimal(25,6) NULL,
	PC_034 decimal(25,6) NULL,
	PC_035 decimal(25,6) NULL,
	PC_036 decimal(25,6) NULL,
	PC_037 decimal(25,6) NULL,
	PC_038 decimal(25,6) NULL,
	PC_039 decimal(25,6) NULL,
	PC_040 decimal(25,6) NULL,
	PC_041 decimal(25,6) NULL,
	PC_042 decimal(25,6) NULL,
	PC_043 decimal(25,6) NULL,
	PC_044 decimal(25,6) NULL,
	PC_045 decimal(25,6) NULL,
	PC_046 decimal(25,6) NULL,
	PC_047 decimal(25,6) NULL,
	PC_048 decimal(25,6) NULL,
	PC_049 decimal(25,6) NULL,
	PC_050 decimal(25,6) NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROG_DEC_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROG_NTEXT_VALUES')
                begin
                                print 'Creating Table EPGP_PROG_NTEXT_VALUES'

CREATE TABLE dbo.EPGP_PROG_NTEXT_VALUES
(
	FIELD_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PN_001 ntext NULL,
	PN_002 ntext NULL,
	PN_003 ntext NULL,
	PN_004 ntext NULL,
	PN_005 ntext NULL,
	PN_006 ntext NULL,
	PN_007 ntext NULL,
	PN_008 ntext NULL,
	PN_009 ntext NULL,
	PN_010 ntext NULL,
	PN_011 ntext NULL,
	PN_012 ntext NULL,
	PN_013 ntext NULL,
	PN_014 ntext NULL,
	PN_015 ntext NULL,
	PN_016 ntext NULL,
	PN_017 ntext NULL,
	PN_018 ntext NULL,
	PN_019 ntext NULL,
	PN_020 ntext NULL,
	PN_021 ntext NULL,
	PN_022 ntext NULL,
	PN_023 ntext NULL,
	PN_024 ntext NULL,
	PN_025 ntext NULL,
	PN_026 ntext NULL,
	PN_027 ntext NULL,
	PN_028 ntext NULL,
	PN_029 ntext NULL,
	PN_030 ntext NULL,
	PN_031 ntext NULL,
	PN_032 ntext NULL,
	PN_033 ntext NULL,
	PN_034 ntext NULL,
	PN_035 ntext NULL,
	PN_036 ntext NULL,
	PN_037 ntext NULL,
	PN_038 ntext NULL,
	PN_039 ntext NULL,
	PN_040 ntext NULL,
	PN_041 ntext NULL,
	PN_042 ntext NULL,
	PN_043 ntext NULL,
	PN_044 ntext NULL,
	PN_045 ntext NULL,
	PN_046 ntext NULL,
	PN_047 ntext NULL,
	PN_048 ntext NULL,
	PN_049 ntext NULL,
	PN_050 ntext NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROG_NTEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROG_DATE_VALUES')
                begin
                                print 'Creating Table EPGP_PROG_DATE_VALUES'

CREATE TABLE dbo.EPGP_PROG_DATE_VALUES
(
	FIELD_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PD_001 datetime NULL,
	PD_002 datetime NULL,
	PD_003 datetime NULL,
	PD_004 datetime NULL,
	PD_005 datetime NULL,
	PD_006 datetime NULL,
	PD_007 datetime NULL,
	PD_008 datetime NULL,
	PD_009 datetime NULL,
	PD_010 datetime NULL,
	PD_011 datetime NULL,
	PD_012 datetime NULL,
	PD_013 datetime NULL,
	PD_014 datetime NULL,
	PD_015 datetime NULL,
	PD_016 datetime NULL,
	PD_017 datetime NULL,
	PD_018 datetime NULL,
	PD_019 datetime NULL,
	PD_020 datetime NULL,
	PD_021 datetime NULL,
	PD_022 datetime NULL,
	PD_023 datetime NULL,
	PD_024 datetime NULL,
	PD_025 datetime NULL,
	PD_026 datetime NULL,
	PD_027 datetime NULL,
	PD_028 datetime NULL,
	PD_029 datetime NULL,
	PD_030 datetime NULL,
	PD_031 datetime NULL,
	PD_032 datetime NULL,
	PD_033 datetime NULL,
	PD_034 datetime NULL,
	PD_035 datetime NULL,
	PD_036 datetime NULL,
	PD_037 datetime NULL,
	PD_038 datetime NULL,
	PD_039 datetime NULL,
	PD_040 datetime NULL,
	PD_041 datetime NULL,
	PD_042 datetime NULL,
	PD_043 datetime NULL,
	PD_044 datetime NULL,
	PD_045 datetime NULL,
	PD_046 datetime NULL,
	PD_047 datetime NULL,
	PD_048 datetime NULL,
	PD_049 datetime NULL,
	PD_050 datetime NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGP_PROG_DATE_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_PROGS')
                begin
                                print 'Creating Table EPGP_PI_PROGS'

CREATE TABLE dbo.EPGP_PI_PROGS
(
	FIELD_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	PROG_UID int NOT NULL,
	PROG_SEQ int NOT NULL,
	PROG_ALLOC decimal(25,6) NOT NULL,
    PROG_PI_TEXT1 nvarchar(255) NULL, 
    PROG_PI_TEXT2 nvarchar(255) NULL, 
    PROG_PI_TEXT3 nvarchar(255) NULL, 
    PROG_PI_TEXT4 nvarchar(255) NULL, 
    PROG_PI_TEXT5 nvarchar(255) NULL 
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_PROGS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_PROGS_FISCAL')
                begin
                                print 'Creating Table EPGP_PI_PROGS_FISCAL'

CREATE TABLE dbo.EPGP_PI_PROGS_FISCAL
(
	FIELD_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	PROG_UID int NOT NULL,
    CB_ID int NOT NULL,
    PERIOD_ID int NOT NULL,
	PERIOD_ALLOC Decimal(25,6) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_PROGS_FISCAL'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGT_RES_FIELDS')
                begin
                                print 'Creating Table EPGT_RES_FIELDS'

CREATE TABLE dbo.EPGT_RES_FIELDS
(
	FIELD_ID int NOT NULL,
	FIELD_NAME nvarchar(255) NOT NULL,
	FIELD_NAME_SQL nvarchar(255) NULL,
	FIELD_TABLE_ID int NULL,
	FIELD_FORMAT int NOT NULL DEFAULT 0,
	FIELD_SUMMARYTYPE int NOT NULL DEFAULT 0,
	FIELD_DISPLAY int NOT NULL DEFAULT 0,
	FIELD_EXPORT int NOT NULL DEFAULT 0,
	FIELD_SEQUENCE nvarchar(8) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGT_RES_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_WI_FRAGMENT_DEFN')
                begin
                                print 'Creating Table EPGP_WI_FRAGMENT_DEFN'

CREATE TABLE dbo.EPGP_WI_FRAGMENT_DEFN
(
	FRAGMENT_ID  int NOT NULL,
	FRAGMENT_NAME nvarchar(255) NOT NULL,
  Primary Key (FRAGMENT_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGP_WI_FRAGMENT_DEFN'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_WI_FRAGMENT_DATA')
                begin
                                print 'Creating Table EPGP_WI_FRAGMENT_DATA'

CREATE TABLE dbo.EPGP_WI_FRAGMENT_DATA
(
	FRAGMENT_ID int NOT NULL,
	WORKITEM_SEQ int NOT NULL,
	WORKITEM_LEVEL int,
	WORKITEM_NAME nvarchar(255) NULL,
	WORKITEM_IS_MILESTONE int,
	WORKITEM_MILESTONE_LEVEL int,
	WORKITEM_START_DATE datetime,
	WORKITEM_FINISH_DATE datetime,
	WORKITEM_WORK decimal(25,6),
	WORKITEM_MAJORCATEGORY nvarchar(255) NULL,
	WORKITEM_TEXT1 nvarchar(255) NULL,
	WORKITEM_TEXT2 nvarchar(255) NULL,
  Primary Key (FRAGMENT_ID ,WORKITEM_SEQ)
)

                end
else
                begin
                                Print 'Updating Table EPGP_WI_FRAGMENT_DATA'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_WI_FRAGMENT_LOGIC')
                begin
                                print 'Creating Table EPGP_WI_FRAGMENT_LOGIC'

CREATE TABLE dbo.EPGP_WI_FRAGMENT_LOGIC
 (
	FRAGMENT_ID int NOT NULL ,
	WORKITEM_PRED_ID int NOT NULL ,
	WORKITEM_SUCC_ID int NOT NULL ,
	WORKITEM_TYPE int NOT NULL ,
) 

                end
else
                begin
                                Print 'Updating Table EPGP_WI_FRAGMENT_LOGIC'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_WI_FRAGMENT_ASSNS')
                begin
                                print 'Creating Table EPGP_WI_FRAGMENT_ASSNS'

CREATE TABLE dbo.EPGP_WI_FRAGMENT_ASSNS
 (
	FRAGMENT_ID int NOT NULL ,
	WORKITEM_SEQ int NOT NULL ,
	WORKITEM_GENERIC_ID int NOT NULL ,
	WORKITEM_WORK decimal(25,6),
  Primary Key (FRAGMENT_ID ,WORKITEM_SEQ,WORKITEM_GENERIC_ID)
) 

                end
else
                begin
                                Print 'Updating Table EPGP_WI_FRAGMENT_ASSNS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_CAPACITY_SETS')
                begin
                                print 'Creating Table EPGP_CAPACITY_SETS'

CREATE TABLE dbo.EPGP_CAPACITY_SETS
(
	CS_ID  int NOT NULL,
	DEPT_UID int NOT NULL Default 0,
	CS_NAME nvarchar(255) NOT NULL,
  Primary Key (CS_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGP_CAPACITY_SETS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_CAPACITY_VALUES')
                begin
                                print 'Creating Table EPGP_CAPACITY_VALUES'

CREATE TABLE dbo.EPGP_CAPACITY_VALUES
(
	CB_ID int NOT NULL,
	BD_PERIOD int NOT NULL,
	WRES_ID int,
	WRES_DEPT int,
	CS_AVAIL decimal(25,6),
  Primary Key (CB_ID,WRES_ID,BD_PERIOD)
)

                end
else
                begin
                                Print 'Updating Table EPGP_CAPACITY_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_ALT_CAPACITY_VALUES')
                begin
                                print 'Creating Table EPGP_ALT_CAPACITY_VALUES'

CREATE TABLE dbo.EPGP_ALT_CAPACITY_VALUES
(
	CB_ID int NOT NULL,
	BD_PERIOD int NOT NULL,
	WRES_ID int,
	WRES_DEPT int,
	CS_AVAIL decimal(25,6),
  Primary Key (CB_ID,WRES_ID,BD_PERIOD)
)

                end
else
                begin
                                Print 'Updating Table EPGP_ALT_CAPACITY_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_CAPACITY_SETVALUES')
                begin
                                print 'Creating Table EPGP_CAPACITY_SETVALUES'

CREATE TABLE dbo.EPGP_CAPACITY_SETVALUES
(
	CS_ID int NOT NULL,
	CB_ID int NOT NULL,
	BD_PERIOD int NOT NULL,
	DEPT_UID int,
	ROLE_ID int,
	CS_AVAIL decimal(25,6),
	CS_FTES int NULL,
  Primary Key (CS_ID,CB_ID,DEPT_UID,ROLE_ID,BD_PERIOD)
)

                end
else
                begin
                                Print 'Updating Table EPGP_CAPACITY_SETVALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_RP_CATEGORY_VALUES')
                begin
                                print 'Creating Table EPGP_RP_CATEGORY_VALUES'

CREATE TABLE dbo.EPGP_RP_CATEGORY_VALUES
(
	CAT_CMT_UID int NOT NULL,
	CAT_TEXT_1 nvarchar(255) NULL,
	CAT_TEXT_2 nvarchar(255) NULL,
	CAT_TEXT_3 nvarchar(255) NULL,
	CAT_TEXT_4 nvarchar(255) NULL,
	CAT_TEXT_5 nvarchar(255) NULL,
	CAT_CODE_1 int,
	CAT_CODE_2 int,
	CAT_CODE_3 int,
	CAT_CODE_4 int,
	CAT_CODE_5 int
)

                end
else
                begin
                                Print 'Updating Table EPGP_RP_CATEGORY_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RD_VIEWS')
                begin
                                print 'Creating Table EPG_RD_VIEWS'

CREATE TABLE dbo.EPG_RD_VIEWS
 (
	WRES_ID int NOT NULL ,
	VIEW_NAME nvarchar(255) NOT NULL,
	VIEW_DEFN ntext  NOT NULL 
) 

                end
else
                begin
                                Print 'Updating Table EPG_RD_VIEWS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_CT_VIEWS')
                begin
                                print 'Creating Table EPG_CT_VIEWS'

CREATE TABLE dbo.EPG_CT_VIEWS
 (
	WRES_ID int NOT NULL ,
	UINF_CONTEXT int NOT NULL ,
	VIEW_NAME nvarchar(255) NOT NULL,
	VIEW_DEFAULT int,
	VIEW_DEFN ntext  NOT NULL 
) 

                end
else
                begin
                                Print 'Updating Table EPG_CT_VIEWS'

                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPG_CT_VIEWS' and column_name = 'VIEW_DEFAULT')
                                begin
                                                Print '     Add Column VIEW_DEFAULT'
                                                ALTER TABLE EPG_CT_VIEWS ADD VIEW_DEFAULT int
                                end
                end             

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_RD_FIELDS')
                begin
                                print 'Creating Table EPGP_RD_FIELDS'

CREATE TABLE dbo.EPGP_RD_FIELDS
(
	CONTEXT_ID int NOT NULL,
	FIELD_ID int NOT NULL,
	FIELD_NAME nvarchar(255) NULL,
	FIELD_SELECT tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPGP_RD_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_RATE_TYPES')
                begin
                                print 'Creating Table EPGP_RATE_TYPES'

CREATE TABLE dbo.EPGP_RATE_TYPES
(
	RT_UID int NOT NULL,
	RT_CALC_METHOD_ID int NOT NULL,
	RT_RATE_TABLE_ID int NULL,
	RT_NAME nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPGP_RATE_TYPES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RESOURCES')
                begin
                                print 'Creating Table EPG_RESOURCES'

CREATE TABLE dbo.EPG_RESOURCES
(
	WRES_ID int NOT NULL,
	RES_NAME nvarchar(255) NOT NULL,
	WRES_PASSWORD nvarchar(255) NULL,
	WRES_USE_NT_LOGON tinyint NOT NULL DEFAULT 0,
	WRES_NT_ACCOUNT nvarchar(255) NULL,
	WRES_CAN_LOGIN tinyint NOT NULL DEFAULT 0,
	WRES_AVAILABLEFROM datetime,
	WRES_AVAILABLETO datetime,
	WRES_EMAIL nvarchar(255),
	WRES_INACTIVE tinyint NOT NULL DEFAULT 0,
	WRES_IS_RESOURCE tinyint NOT NULL DEFAULT 0,
	WRES_IS_GENERIC tinyint NOT NULL DEFAULT 0,
	WRES_TS_INCLUDE tinyint NOT NULL DEFAULT 0,
	WRES_PR_INCLUDE tinyint NOT NULL DEFAULT 0,
	WRES_DEPT int,
	WRES_RP_DEPT int,
	WRES_NOTES nvarchar(255),
	WRES_EXT_UID nvarchar(64) NULL,
	WRES_TRACE int NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPG_RESOURCES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUPS')
                begin
                                print 'Creating Table EPG_GROUPS'

CREATE TABLE dbo.EPG_GROUPS
(
	GROUP_ID int NOT NULL,
	GROUP_NAME nvarchar(255) NOT NULL,
	GROUP_NOTES nvarchar(255),
	GROUP_ENTITY int NOT NULL DEFAULT 1
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUPS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_PERMISSIONS')
                begin
                                print 'Creating Table EPG_PERMISSIONS'

CREATE TABLE dbo.EPG_PERMISSIONS
(
	PERM_UID int NOT NULL,
	PERM_ID int NOT NULL,
	PERM_LEVEL int NOT NULL,
	PERM_NAME nvarchar(255) NOT NULL,
	PERM_NOTES ntext
)

                end
else
                begin
                                Print 'Updating Table EPG_PERMISSIONS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUP_MEMBERS')
                begin
                                print 'Creating Table EPG_GROUP_MEMBERS'

CREATE TABLE dbo.EPG_GROUP_MEMBERS
(
	GROUP_ID int NOT NULL,
	MEMBER_UID int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUP_MEMBERS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUP_PERMISSIONS')
                begin
                                print 'Creating Table EPG_GROUP_PERMISSIONS'

CREATE TABLE dbo.EPG_GROUP_PERMISSIONS
(
	GROUP_ID int NOT NULL,
	PERM_UID int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUP_PERMISSIONS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUP_WEEKLYHOURS')
                begin
                                print 'Creating Table EPG_GROUP_WEEKLYHOURS'

CREATE TABLE dbo.EPG_GROUP_WEEKLYHOURS
(
	GROUP_ID int NOT NULL,
	GROUP_HOURS_MON decimal(25,6),
	GROUP_HOURS_TUE decimal(25,6),
	GROUP_HOURS_WED decimal(25,6),
	GROUP_HOURS_THU decimal(25,6),
	GROUP_HOURS_FRI decimal(25,6),
	GROUP_HOURS_SAT decimal(25,6),
	GROUP_HOURS_SUN decimal(25,6)
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUP_WEEKLYHOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUP_NONWORK_ITEMS')
                begin
                                print 'Creating Table EPG_GROUP_NONWORK_ITEMS'

CREATE TABLE dbo.EPG_GROUP_NONWORK_ITEMS
(
	GROUP_ID int NOT NULL,
	NWI_ID int NOT NULL,
	NWI_CHARGENUMBER nvarchar(255) NOT NULL,
	NWI_MAJORCATEGORY nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUP_NONWORK_ITEMS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUP_NONWORK_HOURS')
                begin
                                print 'Creating Table EPG_GROUP_NONWORK_HOURS'

CREATE TABLE dbo.EPG_GROUP_NONWORK_HOURS
(
	GROUP_ID int NOT NULL,
	NWH_DATE DATETIME,
	NWH_HOURS Decimal(25,6) NULL,
	NWH_COMMENT nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUP_NONWORK_HOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_GROUP_TSLIMITS')
                begin
                                print 'Creating Table EPG_GROUP_TSLIMITS'

CREATE TABLE dbo.EPG_GROUP_TSLIMITS
(
	GROUP_ID int NOT NULL,
	GROUP_ENFORCE_LIMITS tinyint,
	GROUP_MIN_HOURS_PRD int,
	GROUP_MAX_HOURS_PRD int,
	GROUP_ALLOW_OT tinyint,
	GROUP_MAX_OT_HOURS_PRD int,
	GROUP_VISIBLE_SUN tinyint,
	GROUP_MIN_HOURS_SUN int,
	GROUP_MAX_HOURS_SUN int,
	GROUP_VISIBLE_MON tinyint,
	GROUP_MIN_HOURS_MON int,
	GROUP_MAX_HOURS_MON int,
	GROUP_VISIBLE_TUE tinyint,
	GROUP_MIN_HOURS_TUE int,
	GROUP_MAX_HOURS_TUE int,
	GROUP_VISIBLE_WED tinyint,
	GROUP_MIN_HOURS_WED int,
	GROUP_MAX_HOURS_WED int,
	GROUP_VISIBLE_THU tinyint,
	GROUP_MIN_HOURS_THU int,
	GROUP_MAX_HOURS_THU int,
	GROUP_VISIBLE_FRI tinyint,
	GROUP_MIN_HOURS_FRI int,
	GROUP_MAX_HOURS_FRI int,
	GROUP_VISIBLE_SAT tinyint,
	GROUP_MIN_HOURS_SAT int,
	GROUP_MAX_HOURS_SAT int,
	GROUP_DAY_FORMAT nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_GROUP_TSLIMITS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_FIELD_ATTRIBS')
                begin
                                print 'Creating Table EPGC_FIELD_ATTRIBS'

CREATE TABLE dbo.EPGC_FIELD_ATTRIBS
(
	FA_FIELD_ID int IDENTITY(20001,1) Primary Key,
	FA_NAME nvarchar(255) NOT NULL,
	FA_DESC [nvarchar](255) NULL,
	FA_LOOKUPONLY tinyint,
	FA_LOOKUP_UID int,
	FA_LEAFONLY tinyint,
	FA_USEFULLNAME tinyint,
	FA_TABLE_ID int NOT NULL,
	FA_FIELD_IN_TABLE int NOT NULL,
	FA_FORMAT int
)

                end
else
                begin
                                Print 'Updating Table EPGC_FIELD_ATTRIBS'
                                if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPGC_FIELD_ATTRIBS' and column_name = 'FA_DESC')
                                begin
                                                Print '     Add Column FA_DESC'
                                                ALTER TABLE EPGC_FIELD_ATTRIBS ADD FA_DESC [nvarchar](255) NULL
                                end
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_RESOURCE_INT_VALUES')
                begin
                                print 'Creating Table EPGC_RESOURCE_INT_VALUES'

CREATE TABLE dbo.EPGC_RESOURCE_INT_VALUES
(
	WRES_ID int NOT NULL Primary Key,
	RI_001 int,
	RI_002 int,
	RI_003 int,
	RI_004 int,
	RI_005 int,
	RI_006 int,
	RI_007 int,
	RI_008 int,
	RI_009 int,
	RI_010 int,
	RI_011 int,
	RI_012 int,
	RI_013 int,
	RI_014 int,
	RI_015 int,
	RI_016 int,
	RI_017 int,
	RI_018 int,
	RI_019 int,
	RI_020 int,
	RI_021 int,
	RI_022 int,
	RI_023 int,
	RI_024 int,
	RI_025 int,
	RI_026 int,
	RI_027 int,
	RI_028 int,
	RI_029 int,
	RI_030 int,
	RI_031 int,
	RI_032 int,
	RI_033 int,
	RI_034 int,
	RI_035 int,
	RI_036 int,
	RI_037 int,
	RI_038 int,
	RI_039 int,
	RI_040 int,
	RI_041 int,
	RI_042 int,
	RI_043 int,
	RI_044 int,
	RI_045 int,
	RI_046 int,
	RI_047 int,
	RI_048 int,
	RI_049 int,
	RI_050 int
)

                end
else
                begin
                                Print 'Updating Table EPGC_RESOURCE_INT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_RESOURCE_TEXT_VALUES')
                begin
                                print 'Creating Table EPGC_RESOURCE_TEXT_VALUES'

CREATE TABLE dbo.EPGC_RESOURCE_TEXT_VALUES
(
	WRES_ID int NOT NULL Primary Key,
	RT_001 nvarchar(255) NULL,
	RT_002 nvarchar(255) NULL,
	RT_003 nvarchar(255) NULL,
	RT_004 nvarchar(255) NULL,
	RT_005 nvarchar(255) NULL,
	RT_006 nvarchar(255) NULL,
	RT_007 nvarchar(255) NULL,
	RT_008 nvarchar(255) NULL,
	RT_009 nvarchar(255) NULL,
	RT_010 nvarchar(255) NULL,
	RT_011 nvarchar(255) NULL,
	RT_012 nvarchar(255) NULL,
	RT_013 nvarchar(255) NULL,
	RT_014 nvarchar(255) NULL,
	RT_015 nvarchar(255) NULL,
	RT_016 nvarchar(255) NULL,
	RT_017 nvarchar(255) NULL,
	RT_018 nvarchar(255) NULL,
	RT_019 nvarchar(255) NULL,
	RT_020 nvarchar(255) NULL,
	RT_021 nvarchar(255) NULL,
	RT_022 nvarchar(255) NULL,
	RT_023 nvarchar(255) NULL,
	RT_024 nvarchar(255) NULL,
	RT_025 nvarchar(255) NULL,
	RT_026 nvarchar(255) NULL,
	RT_027 nvarchar(255) NULL,
	RT_028 nvarchar(255) NULL,
	RT_029 nvarchar(255) NULL,
	RT_030 nvarchar(255) NULL,
	RT_031 nvarchar(255) NULL,
	RT_032 nvarchar(255) NULL,
	RT_033 nvarchar(255) NULL,
	RT_034 nvarchar(255) NULL,
	RT_035 nvarchar(255) NULL,
	RT_036 nvarchar(255) NULL,
	RT_037 nvarchar(255) NULL,
	RT_038 nvarchar(255) NULL,
	RT_039 nvarchar(255) NULL,
	RT_040 nvarchar(255) NULL,
	RT_041 nvarchar(255) NULL,
	RT_042 nvarchar(255) NULL,
	RT_043 nvarchar(255) NULL,
	RT_044 nvarchar(255) NULL,
	RT_045 nvarchar(255) NULL,
	RT_046 nvarchar(255) NULL,
	RT_047 nvarchar(255) NULL,
	RT_048 nvarchar(255) NULL,
	RT_049 nvarchar(255) NULL,
	RT_050 nvarchar(255) NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGC_RESOURCE_TEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_RESOURCE_DEC_VALUES')
                begin
                                print 'Creating Table EPGC_RESOURCE_DEC_VALUES'

CREATE TABLE dbo.EPGC_RESOURCE_DEC_VALUES
(
	WRES_ID int NOT NULL Primary Key,
	RC_001 decimal(25,6) NULL,
	RC_002 decimal(25,6) NULL,
	RC_003 decimal(25,6) NULL,
	RC_004 decimal(25,6) NULL,
	RC_005 decimal(25,6) NULL,
	RC_006 decimal(25,6) NULL,
	RC_007 decimal(25,6) NULL,
	RC_008 decimal(25,6) NULL,
	RC_009 decimal(25,6) NULL,
	RC_010 decimal(25,6) NULL,
	RC_011 decimal(25,6) NULL,
	RC_012 decimal(25,6) NULL,
	RC_013 decimal(25,6) NULL,
	RC_014 decimal(25,6) NULL,
	RC_015 decimal(25,6) NULL,
	RC_016 decimal(25,6) NULL,
	RC_017 decimal(25,6) NULL,
	RC_018 decimal(25,6) NULL,
	RC_019 decimal(25,6) NULL,
	RC_020 decimal(25,6) NULL,
	RC_021 decimal(25,6) NULL,
	RC_022 decimal(25,6) NULL,
	RC_023 decimal(25,6) NULL,
	RC_024 decimal(25,6) NULL,
	RC_025 decimal(25,6) NULL,
	RC_026 decimal(25,6) NULL,
	RC_027 decimal(25,6) NULL,
	RC_028 decimal(25,6) NULL,
	RC_029 decimal(25,6) NULL,
	RC_030 decimal(25,6) NULL,
	RC_031 decimal(25,6) NULL,
	RC_032 decimal(25,6) NULL,
	RC_033 decimal(25,6) NULL,
	RC_034 decimal(25,6) NULL,
	RC_035 decimal(25,6) NULL,
	RC_036 decimal(25,6) NULL,
	RC_037 decimal(25,6) NULL,
	RC_038 decimal(25,6) NULL,
	RC_039 decimal(25,6) NULL,
	RC_040 decimal(25,6) NULL,
	RC_041 decimal(25,6) NULL,
	RC_042 decimal(25,6) NULL,
	RC_043 decimal(25,6) NULL,
	RC_044 decimal(25,6) NULL,
	RC_045 decimal(25,6) NULL,
	RC_046 decimal(25,6) NULL,
	RC_047 decimal(25,6) NULL,
	RC_048 decimal(25,6) NULL,
	RC_049 decimal(25,6) NULL,
	RC_050 decimal(25,6) NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGC_RESOURCE_DEC_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_RESOURCE_NTEXT_VALUES')
                begin
                                print 'Creating Table EPGC_RESOURCE_NTEXT_VALUES'

CREATE TABLE dbo.EPGC_RESOURCE_NTEXT_VALUES
(
	WRES_ID int NOT NULL Primary Key,
	RN_001 ntext NULL,
	RN_002 ntext NULL,
	RN_003 ntext NULL,
	RN_004 ntext NULL,
	RN_005 ntext NULL,
	RN_006 ntext NULL,
	RN_007 ntext NULL,
	RN_008 ntext NULL,
	RN_009 ntext NULL,
	RN_010 ntext NULL,
	RN_011 ntext NULL,
	RN_012 ntext NULL,
	RN_013 ntext NULL,
	RN_014 ntext NULL,
	RN_015 ntext NULL,
	RN_016 ntext NULL,
	RN_017 ntext NULL,
	RN_018 ntext NULL,
	RN_019 ntext NULL,
	RN_020 ntext NULL,
	RN_021 ntext NULL,
	RN_022 ntext NULL,
	RN_023 ntext NULL,
	RN_024 ntext NULL,
	RN_025 ntext NULL,
	RN_026 ntext NULL,
	RN_027 ntext NULL,
	RN_028 ntext NULL,
	RN_029 ntext NULL,
	RN_030 ntext NULL,
	RN_031 ntext NULL,
	RN_032 ntext NULL,
	RN_033 ntext NULL,
	RN_034 ntext NULL,
	RN_035 ntext NULL,
	RN_036 ntext NULL,
	RN_037 ntext NULL,
	RN_038 ntext NULL,
	RN_039 ntext NULL,
	RN_040 ntext NULL,
	RN_041 ntext NULL,
	RN_042 ntext NULL,
	RN_043 ntext NULL,
	RN_044 ntext NULL,
	RN_045 ntext NULL,
	RN_046 ntext NULL,
	RN_047 ntext NULL,
	RN_048 ntext NULL,
	RN_049 ntext NULL,
	RN_050 ntext NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGC_RESOURCE_NTEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_RESOURCE_DATE_VALUES')
                begin
                                print 'Creating Table EPGC_RESOURCE_DATE_VALUES'

CREATE TABLE dbo.EPGC_RESOURCE_DATE_VALUES
(
	WRES_ID int NOT NULL Primary Key,
	RD_001 datetime NULL,
	RD_002 datetime NULL,
	RD_003 datetime NULL,
	RD_004 datetime NULL,
	RD_005 datetime NULL,
	RD_006 datetime NULL,
	RD_007 datetime NULL,
	RD_008 datetime NULL,
	RD_009 datetime NULL,
	RD_010 datetime NULL,
	RD_011 datetime NULL,
	RD_012 datetime NULL,
	RD_013 datetime NULL,
	RD_014 datetime NULL,
	RD_015 datetime NULL,
	RD_016 datetime NULL,
	RD_017 datetime NULL,
	RD_018 datetime NULL,
	RD_019 datetime NULL,
	RD_020 datetime NULL,
	RD_021 datetime NULL,
	RD_022 datetime NULL,
	RD_023 datetime NULL,
	RD_024 datetime NULL,
	RD_025 datetime NULL,
	RD_026 datetime NULL,
	RD_027 datetime NULL,
	RD_028 datetime NULL,
	RD_029 datetime NULL,
	RD_030 datetime NULL,
	RD_031 datetime NULL,
	RD_032 datetime NULL,
	RD_033 datetime NULL,
	RD_034 datetime NULL,
	RD_035 datetime NULL,
	RD_036 datetime NULL,
	RD_037 datetime NULL,
	RD_038 datetime NULL,
	RD_039 datetime NULL,
	RD_040 datetime NULL,
	RD_041 datetime NULL,
	RD_042 datetime NULL,
	RD_043 datetime NULL,
	RD_044 datetime NULL,
	RD_045 datetime NULL,
	RD_046 datetime NULL,
	RD_047 datetime NULL,
	RD_048 datetime NULL,
	RD_049 datetime NULL,
	RD_050 datetime NULL
	)

                end
else
                begin
                                Print 'Updating Table EPGC_RESOURCE_DATE_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGC_RESOURCE_MV_VALUES')
                begin
                                print 'Creating Table EPGC_RESOURCE_MV_VALUES'

CREATE TABLE dbo.EPGC_RESOURCE_MV_VALUES
(
	WRES_ID int NOT NULL,
	MVR_FIELD_ID int,
	MVR_UID int,
	MVR_SEQ int,
	MVR_WEIGHT int
)

                end
else
                begin
                                Print 'Updating Table EPGC_RESOURCE_MV_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_VERSIONS')
                begin
                                print 'Creating Table EPGP_VERSIONS'

CREATE TABLE dbo.EPGP_VERSIONS
 (
	VERSION_ID int IDENTITY (1, 1) NOT NULL ,
	VERSION_NAME nvarchar(255),
	VERSION_DESC nvarchar(255)
) 

                end
else
                begin
                                Print 'Updating Table EPGP_VERSIONS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_VERSIONS')
                begin
                                print 'Creating Table EPGX_PROJECT_VERSIONS'

CREATE TABLE dbo.EPGX_PROJECT_VERSIONS
 (
	WPROJ_ID int NOT NULL ,
	PROJECT_ID int NOT NULL ,
	VERSION_ID int NOT NULL ,
	PV_PROJECT_NAME nvarchar(255),
	PV_ORIGIN_DESC nvarchar(255),
	PV_START datetime,
	PV_FINISH datetime,
	PV_STATUS_DATE datetime,
	PV_MAJORCATEGORY nvarchar(255),
	PV_CHARGENUMBER nvarchar(255),
	PV_LAST_IMPORTED datetime,
	PV_IMPORTED_BY int,
	PV_CREATED datetime,
	PV_WORK_IMPORTED tinyint NOT NULL default 0,
	PV_EV_IMPORTED tinyint NOT NULL default 0,
	PV_POST tinyint NOT NULL default 0,
  Primary Key (PROJECT_ID,VERSION_ID)
) 

                end
else
                begin
                                Print 'Updating Table EPGX_PROJECT_VERSIONS'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJ_INT_VALUES')
                begin
                                print 'Creating Table EPGX_PROJ_INT_VALUES'

CREATE TABLE dbo.EPGX_PROJ_INT_VALUES
(
	WPROJ_ID int NOT NULL Default 0,
	PROJECT_ID int NOT NULL Default 0,
	XI_001 int NULL,
	XI_002 int NULL,
	XI_003 int NULL,
	XI_004 int NULL,
	XI_005 int NULL,
	XI_006 int NULL,
	XI_007 int NULL,
	XI_008 int NULL,
	XI_009 int NULL,
	XI_010 int NULL,
	XI_011 int NULL,
	XI_012 int NULL,
	XI_013 int NULL,
	XI_014 int NULL,
	XI_015 int NULL,
	XI_016 int NULL,
	XI_017 int NULL,
	XI_018 int NULL,
	XI_019 int NULL,
	XI_020 int NULL,
	XI_021 int NULL,
	XI_022 int NULL,
	XI_023 int NULL,
	XI_024 int NULL,
	XI_025 int NULL,
	XI_026 int NULL,
	XI_027 int NULL,
	XI_028 int NULL,
	XI_029 int NULL,
	XI_030 int NULL,
	XI_031 int NULL,
	XI_032 int NULL,
	XI_033 int NULL,
	XI_034 int NULL,
	XI_035 int NULL,
	XI_036 int NULL,
	XI_037 int NULL,
	XI_038 int NULL,
	XI_039 int NULL,
	XI_040 int NULL,
	XI_041 int NULL,
	XI_042 int NULL,
	XI_043 int NULL,
	XI_044 int NULL,
	XI_045 int NULL,
	XI_046 int NULL,
	XI_047 int NULL,
	XI_048 int NULL,
	XI_049 int NULL,
	XI_050 int NULL,
  Primary Key (WPROJ_ID,PROJECT_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGX_PROJ_INT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJ_TEXT_VALUES')
                begin
                                print 'Creating Table EPGX_PROJ_TEXT_VALUES'

CREATE TABLE dbo.EPGX_PROJ_TEXT_VALUES
(
	WPROJ_ID int NOT NULL Default 0,
	PROJECT_ID int NOT NULL Default 0,
	XT_001 nvarchar(255) NULL,
	XT_002 nvarchar(255) NULL,
	XT_003 nvarchar(255) NULL,
	XT_004 nvarchar(255) NULL,
	XT_005 nvarchar(255) NULL,
	XT_006 nvarchar(255) NULL,
	XT_007 nvarchar(255) NULL,
	XT_008 nvarchar(255) NULL,
	XT_009 nvarchar(255) NULL,
	XT_010 nvarchar(255) NULL,
	XT_011 nvarchar(255) NULL,
	XT_012 nvarchar(255) NULL,
	XT_013 nvarchar(255) NULL,
	XT_014 nvarchar(255) NULL,
	XT_015 nvarchar(255) NULL,
	XT_016 nvarchar(255) NULL,
	XT_017 nvarchar(255) NULL,
	XT_018 nvarchar(255) NULL,
	XT_019 nvarchar(255) NULL,
	XT_020 nvarchar(255) NULL,
	XT_021 nvarchar(255) NULL,
	XT_022 nvarchar(255) NULL,
	XT_023 nvarchar(255) NULL,
	XT_024 nvarchar(255) NULL,
	XT_025 nvarchar(255) NULL,
	XT_026 nvarchar(255) NULL,
	XT_027 nvarchar(255) NULL,
	XT_028 nvarchar(255) NULL,
	XT_029 nvarchar(255) NULL,
	XT_030 nvarchar(255) NULL,
	XT_031 nvarchar(255) NULL,
	XT_032 nvarchar(255) NULL,
	XT_033 nvarchar(255) NULL,
	XT_034 nvarchar(255) NULL,
	XT_035 nvarchar(255) NULL,
	XT_036 nvarchar(255) NULL,
	XT_037 nvarchar(255) NULL,
	XT_038 nvarchar(255) NULL,
	XT_039 nvarchar(255) NULL,
	XT_040 nvarchar(255) NULL,
	XT_041 nvarchar(255) NULL,
	XT_042 nvarchar(255) NULL,
	XT_043 nvarchar(255) NULL,
	XT_044 nvarchar(255) NULL,
	XT_045 nvarchar(255) NULL,
	XT_046 nvarchar(255) NULL,
	XT_047 nvarchar(255) NULL,
	XT_048 nvarchar(255) NULL,
	XT_049 nvarchar(255) NULL,
	XT_050 nvarchar(255) NULL,
  Primary Key (WPROJ_ID,PROJECT_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGX_PROJ_TEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJ_DEC_VALUES')
                begin
                                print 'Creating Table EPGX_PROJ_DEC_VALUES'

CREATE TABLE dbo.EPGX_PROJ_DEC_VALUES
(
	WPROJ_ID int NOT NULL Default 0,
	PROJECT_ID int NOT NULL Default 0,
	XC_001 decimal(25,6) NULL,
	XC_002 decimal(25,6) NULL,
	XC_003 decimal(25,6) NULL,
	XC_004 decimal(25,6) NULL,
	XC_005 decimal(25,6) NULL,
	XC_006 decimal(25,6) NULL,
	XC_007 decimal(25,6) NULL,
	XC_008 decimal(25,6) NULL,
	XC_009 decimal(25,6) NULL,
	XC_010 decimal(25,6) NULL,
	XC_011 decimal(25,6) NULL,
	XC_012 decimal(25,6) NULL,
	XC_013 decimal(25,6) NULL,
	XC_014 decimal(25,6) NULL,
	XC_015 decimal(25,6) NULL,
	XC_016 decimal(25,6) NULL,
	XC_017 decimal(25,6) NULL,
	XC_018 decimal(25,6) NULL,
	XC_019 decimal(25,6) NULL,
	XC_020 decimal(25,6) NULL,
	XC_021 decimal(25,6) NULL,
	XC_022 decimal(25,6) NULL,
	XC_023 decimal(25,6) NULL,
	XC_024 decimal(25,6) NULL,
	XC_025 decimal(25,6) NULL,
	XC_026 decimal(25,6) NULL,
	XC_027 decimal(25,6) NULL,
	XC_028 decimal(25,6) NULL,
	XC_029 decimal(25,6) NULL,
	XC_030 decimal(25,6) NULL,
	XC_031 decimal(25,6) NULL,
	XC_032 decimal(25,6) NULL,
	XC_033 decimal(25,6) NULL,
	XC_034 decimal(25,6) NULL,
	XC_035 decimal(25,6) NULL,
	XC_036 decimal(25,6) NULL,
	XC_037 decimal(25,6) NULL,
	XC_038 decimal(25,6) NULL,
	XC_039 decimal(25,6) NULL,
	XC_040 decimal(25,6) NULL,
	XC_041 decimal(25,6) NULL,
	XC_042 decimal(25,6) NULL,
	XC_043 decimal(25,6) NULL,
	XC_044 decimal(25,6) NULL,
	XC_045 decimal(25,6) NULL,
	XC_046 decimal(25,6) NULL,
	XC_047 decimal(25,6) NULL,
	XC_048 decimal(25,6) NULL,
	XC_049 decimal(25,6) NULL,
	XC_050 decimal(25,6) NULL,
  Primary Key (WPROJ_ID,PROJECT_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGX_PROJ_DEC_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJ_NTEXT_VALUES')
                begin
                                print 'Creating Table EPGX_PROJ_NTEXT_VALUES'

CREATE TABLE dbo.EPGX_PROJ_NTEXT_VALUES
(
	WPROJ_ID int NOT NULL Default 0,
	PROJECT_ID int NOT NULL Default 0,
	XN_001 ntext NULL,
	XN_002 ntext NULL,
	XN_003 ntext NULL,
	XN_004 ntext NULL,
	XN_005 ntext NULL,
	XN_006 ntext NULL,
	XN_007 ntext NULL,
	XN_008 ntext NULL,
	XN_009 ntext NULL,
	XN_010 ntext NULL,
	XN_011 ntext NULL,
	XN_012 ntext NULL,
	XN_013 ntext NULL,
	XN_014 ntext NULL,
	XN_015 ntext NULL,
	XN_016 ntext NULL,
	XN_017 ntext NULL,
	XN_018 ntext NULL,
	XN_019 ntext NULL,
	XN_020 ntext NULL,
	XN_021 ntext NULL,
	XN_022 ntext NULL,
	XN_023 ntext NULL,
	XN_024 ntext NULL,
	XN_025 ntext NULL,
	XN_026 ntext NULL,
	XN_027 ntext NULL,
	XN_028 ntext NULL,
	XN_029 ntext NULL,
	XN_030 ntext NULL,
	XN_031 ntext NULL,
	XN_032 ntext NULL,
	XN_033 ntext NULL,
	XN_034 ntext NULL,
	XN_035 ntext NULL,
	XN_036 ntext NULL,
	XN_037 ntext NULL,
	XN_038 ntext NULL,
	XN_039 ntext NULL,
	XN_040 ntext NULL,
	XN_041 ntext NULL,
	XN_042 ntext NULL,
	XN_043 ntext NULL,
	XN_044 ntext NULL,
	XN_045 ntext NULL,
	XN_046 ntext NULL,
	XN_047 ntext NULL,
	XN_048 ntext NULL,
	XN_049 ntext NULL,
	XN_050 ntext NULL,
  Primary Key (WPROJ_ID,PROJECT_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGX_PROJ_NTEXT_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJ_DATE_VALUES')
                begin
                                print 'Creating Table EPGX_PROJ_DATE_VALUES'

CREATE TABLE dbo.EPGX_PROJ_DATE_VALUES
(
	WPROJ_ID int NOT NULL Default 0,
	PROJECT_ID int NOT NULL Default 0,
	XD_001 datetime NULL,
	XD_002 datetime NULL,
	XD_003 datetime NULL,
	XD_004 datetime NULL,
	XD_005 datetime NULL,
	XD_006 datetime NULL,
	XD_007 datetime NULL,
	XD_008 datetime NULL,
	XD_009 datetime NULL,
	XD_010 datetime NULL,
	XD_011 datetime NULL,
	XD_012 datetime NULL,
	XD_013 datetime NULL,
	XD_014 datetime NULL,
	XD_015 datetime NULL,
	XD_016 datetime NULL,
	XD_017 datetime NULL,
	XD_018 datetime NULL,
	XD_019 datetime NULL,
	XD_020 datetime NULL,
	XD_021 datetime NULL,
	XD_022 datetime NULL,
	XD_023 datetime NULL,
	XD_024 datetime NULL,
	XD_025 datetime NULL,
	XD_026 datetime NULL,
	XD_027 datetime NULL,
	XD_028 datetime NULL,
	XD_029 datetime NULL,
	XD_030 datetime NULL,
	XD_031 datetime NULL,
	XD_032 datetime NULL,
	XD_033 datetime NULL,
	XD_034 datetime NULL,
	XD_035 datetime NULL,
	XD_036 datetime NULL,
	XD_037 datetime NULL,
	XD_038 datetime NULL,
	XD_039 datetime NULL,
	XD_040 datetime NULL,
	XD_041 datetime NULL,
	XD_042 datetime NULL,
	XD_043 datetime NULL,
	XD_044 datetime NULL,
	XD_045 datetime NULL,
	XD_046 datetime NULL,
	XD_047 datetime NULL,
	XD_048 datetime NULL,
	XD_049 datetime NULL,
	XD_050 datetime NULL,
  Primary Key (WPROJ_ID,PROJECT_ID)
)

                end
else
                begin
                                Print 'Updating Table EPGX_PROJ_DATE_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_RESOURCES')
                begin
                                print 'Creating Table EPGX_PROJECT_RESOURCES'

CREATE TABLE dbo.EPGX_PROJECT_RESOURCES
 (
	WPROJ_ID int NOT NULL,
	WRES_ID int NOT NULL, 
	EXRES_ID int NOT NULL default 0, 
	EXRES_NAME nvarchar(255) NOT NULL, 
	EXRES_NT_ACCOUNT nvarchar(255), 
	EXRES_EMAIL nvarchar(255) 
) 

                end
else
                begin
                                Print 'Updating Table EPGX_PROJECT_RESOURCES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_TASKS')
                begin
                                print 'Creating Table EPGX_PROJECT_TASKS'

CREATE TABLE dbo.EPGX_PROJECT_TASKS
 (
	WPROJ_ID int NOT NULL ,
	TASK_UID int NOT NULL ,
	TASK_ID int NOT NULL ,
	TASK_NAME nvarchar(255),
	TASK_OUTLINE_LEVEL int NOT NULL ,
	TASK_TYPE nvarchar(255),
	TASK_IS_EXTERNAL tinyint NOT NULL Default 0,
	TASK_IS_SUMMARY tinyint NOT NULL Default 0,
	TASK_IS_MILESTONE tinyint NOT NULL Default 0,
	TASK_MILESTONE_LEVEL int NOT NULL Default 0,
	TASK_PRIORITY int NOT NULL Default 0,
	TASK_START_DATE datetime,
	TASK_FINISH_DATE datetime,
	TASK_TOTAL_SLACK int,
	TASK_BASELINE_START_DATE datetime,
	TASK_BASELINE_FINISH_DATE datetime,
	TASK_ACTUAL_START_DATE datetime,
	TASK_ACTUAL_FINISH_DATE datetime,
	TASK_PERCENT_WORKCOMPLETE int,
	TASK_WORK Decimal(25,6) NULL,
	TASK_ACT_WORK Decimal(25,6) NULL,
	TASK_REM_WORK Decimal(25,6) NULL,
	TASK_COST Decimal(25,6) NULL,
	TASK_ACT_COST Decimal(25,6) NULL,
	TASK_REM_COST Decimal(25,6) NULL,
	TASK_CHARGENUMBER nvarchar(255),
	TASK_CHARGESTATUS nvarchar(255),
	TASK_EV_WBS_NAME nvarchar(255),
	TASK_EV_WBS_UID int,
	TASK_EV_METHOD nvarchar(255),
	TASK_EV_SUPP_DATA nvarchar(255),
	TASK_EV_PERCENT_COMPLETE int,
	TASK_MAJORCATEGORY nvarchar(255),
	TASK_SUBPROJECTFILE nvarchar(255),
	TASK_RESOURCES nvarchar(4000),
	TASK_DURATION	int,
	TASK_REMAINING_DURATION	int,
	TASK_CTEXT1 nvarchar(255) NULL,
	TASK_CTEXT2 nvarchar(255) NULL,
	TASK_CTEXT3 nvarchar(255) NULL,
	TASK_CTEXT4 nvarchar(255) NULL,
	TASK_CTEXT5 nvarchar(255) NULL,
	TASK_CTEXT6 nvarchar(255) NULL,
	TASK_CTEXT7 nvarchar(255) NULL,
	TASK_CTEXT8 nvarchar(255) NULL,
	TASK_CTEXT9 nvarchar(255) NULL,
	TASK_CTEXT10 nvarchar(255) NULL,
    TASK_CTEXT11 nvarchar(255) NULL,
	TASK_CTEXT12 nvarchar(255) NULL,
	TASK_CTEXT13 nvarchar(255) NULL,
	TASK_CTEXT14 nvarchar(255) NULL,
	TASK_CTEXT15 nvarchar(255) NULL,
	TASK_CTEXT16 nvarchar(255) NULL,
	TASK_CTEXT17 nvarchar(255) NULL,
	TASK_CTEXT18 nvarchar(255) NULL,
	TASK_CTEXT19 nvarchar(255) NULL,
	TASK_CTEXT20 nvarchar(255) NULL,
	TASK_FLAG1 tinyint,
	TASK_FLAG2 tinyint,
	TASK_FLAG3 tinyint,
	TASK_FLAG4 tinyint,
	TASK_FLAG5 tinyint,
	TASK_FLAG6 tinyint,
	TASK_FLAG7 tinyint,
	TASK_FLAG8 tinyint,
	TASK_FLAG9 tinyint,
	TASK_FLAG10 tinyint,
	TASK_NUMBER1 decimal(25,6),
	TASK_NUMBER2 decimal(25,6),
	TASK_NUMBER3 decimal(25,6),
	TASK_NUMBER4 decimal(25,6),
	TASK_NUMBER5 decimal(25,6),
	TASK_NUMBER6 decimal(25,6),
	TASK_NUMBER7 decimal(25,6),
	TASK_NUMBER8 decimal(25,6),
	TASK_NUMBER9 decimal(25,6),
	TASK_NUMBER10 decimal(25,6)	
) 

                end
else
                begin
                                Print 'Updating Table EPGX_PROJECT_TASKS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_LOGIC')
                begin
                                print 'Creating Table EPGX_PROJECT_LOGIC'

CREATE TABLE dbo.EPGX_PROJECT_LOGIC
 (
	WPROJ_ID int NOT NULL ,
	LG_TASK_SUCC_UID int NOT NULL ,
	LG_TASK_PRED_UID int NOT NULL ,
	LG_LAG int ,
	LG_LAG_TYPE int
) 

                end
else
                begin
                                Print 'Updating Table EPGX_PROJECT_LOGIC'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_ASSN')
                begin
                                print 'Creating Table EPGX_PROJECT_ASSN'

CREATE TABLE dbo.EPGX_PROJECT_ASSN
 (
	WPROJ_ID int NOT NULL ,
	TASK_UID int NOT NULL ,
	WRES_ID int NOT NULL, 
	LOCAL_WRES_ID int NOT NULL, 
	ASSN_START_DATE datetime,
	ASSN_FINISH_DATE datetime,
	ASSN_WORK Decimal(25,6) NULL,
	ASSN_PERCENTWORKCOMPLETE int
) 

                end
else
                begin
                                Print 'Updating Table EPGX_PROJECT_ASSN'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_TSWORK')
                begin
                                print 'Creating Table EPGX_PROJECT_TSWORK'

CREATE TABLE dbo.EPGX_PROJECT_TSWORK
 (
 	WPROJ_ID int NOT NULL,
	WRES_ID int NOT NULL,
	EXRES_ID int NOT NULL default 0, 
	TSWORK_MAJORCATEGORY nvarchar(255) NULL,
	TSWORK_DATE datetime NULL,
	TSWORK_WORK decimal(25,6)

 )
 
                end
else
                begin
                                Print 'Updating Table EPGX_PROJECT_TSWORK'
                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGX_PROJECT_PDWORK')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGX_PROJECT_PDWORK'
     DROP TABLE dbo.EPGX_PROJECT_PDWORK
end     

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_PROJECT_PDWORK')
--                begin
--                                print 'Creating Table EPGX_PROJECT_PDWORK'

--CREATE TABLE dbo.EPGX_PROJECT_PDWORK
-- (
-- 	WPROJ_ID int NOT NULL,
--	WRES_ID int NOT NULL,
--	EXRES_ID int NOT NULL default 0, 
--	TASK_UID int NOT NULL, 
--	PDWORK_PRD_ID int NOT NULL,
--	PDWORK_WORK decimal(25,6)

-- )
 
--                end
--else
--                begin
--                                Print 'Updating Table EPGX_PROJECT_PDWORK'
--                end
 
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PROJECT_TSWORK')
                begin
                                print 'Creating Table EPGP_PROJECT_TSWORK'

CREATE TABLE dbo.EPGP_PROJECT_TSWORK
 (
 	PROJECT_ID int NOT NULL,
	WRES_ID int NOT NULL,
	EXRES_ID int NOT NULL default 0, 
	TSWORK_MAJORCATEGORY nvarchar(255) NULL,
	TSWORK_DATE datetime,
	TSWORK_WORK decimal(25,6)

 )
 
                end
else
                begin
                                Print 'Updating Table EPGP_PROJECT_TSWORK'
                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGX_EV_TASK_BCWS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGX_EV_TASK_BCWS'
     DROP TABLE dbo.EPGX_EV_TASK_BCWS
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_EV_TASK_BCWS')
--                begin
--                                print 'Creating Table EPGX_EV_TASK_BCWS'

--CREATE TABLE dbo.EPGX_EV_TASK_BCWS
-- (
-- 	WPROJ_ID int NOT NULL,
--	WRES_ID int NOT NULL,
--	EXRES_ID int NOT NULL default 0, 
--	TASK_UID int NOT NULL, 
--	BC_UID int NOT NULL, 
--	BCWS_EARN_ID int NOT NULL, 
--	BCWS_PRD_ID int NOT NULL,
--	BCWS_VALUE decimal(25,6),
--	BCWS_COST decimal(25,6)

-- )
 
--                end
--else
--                begin
--                                Print 'Updating Table EPGX_EV_TASK_BCWS'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGX_EV_TASK_BCWP')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGX_EV_TASK_BCWP'
     DROP TABLE dbo.EPGX_EV_TASK_BCWP
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_EV_TASK_BCWP')
--                begin
--                                print 'Creating Table EPGX_EV_TASK_BCWP'

--CREATE TABLE dbo.EPGX_EV_TASK_BCWP
-- (
-- 	WPROJ_ID int NOT NULL,
--	WRES_ID int NOT NULL,
--	EXRES_ID int NOT NULL default 0, 
--	TASK_UID int NOT NULL, 
--	BC_UID int NOT NULL, 
--	BCWP_EARN_ID int NOT NULL, 
--	BCWP_PRD_ID int NOT NULL,
--	BCWP_VALUE decimal(25,6),
--	BCWP_COST decimal(25,6)

-- )
 
--                end
--else
--                begin
--                                Print 'Updating Table EPGX_EV_TASK_BCWP'
--                end
 

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGX_EV_TASK_FORC')
--                begin
--                                print 'Creating Table EPGX_EV_TASK_FORC'

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGX_EV_TASK_FORC')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGX_EV_TASK_FORC'
     DROP TABLE dbo.EPGX_EV_TASK_FORC
end

--CREATE TABLE dbo.EPGX_EV_TASK_FORC
-- (
-- 	WPROJ_ID int NOT NULL,
--	WRES_ID int NOT NULL,
--	EXRES_ID int NOT NULL default 0, 
--	TASK_UID int NOT NULL, 
--	BC_UID int NOT NULL, 
--	FORC_PRD_ID int NOT NULL,
--	FORC_VALUE decimal(25,6),
--	FORC_COST decimal(25,6)

-- )
 
--                end
--else
--                begin
--                                Print 'Updating Table EPGX_EV_TASK_FORC'
--                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_WSS_ADMIN')
                begin
                                print 'Creating Table EPG_WSS_ADMIN'

CREATE TABLE dbo.EPG_WSS_ADMIN
 (
	WSA_CURRENT_WSS_SERVER_ID int NOT NULL,
	WSA_TEMPLATE_LCID int,
	WSA_TEMPLATE_ID nvarchar(50) NULL,
	WSA_PRIMARY_OWNER_EMAIL nvarchar(100) NULL,
	WSA_SECONDARY_OWNER_NAME nvarchar(255) NULL,
	WSA_SECONDARY_OWNER_EMAIL nvarchar(100) NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_WSS_ADMIN'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_WSS_SERVERS')
                begin
                                print 'Creating Table EPG_WSS_SERVERS'

CREATE TABLE dbo.EPG_WSS_SERVERS
 (
	WSS_SERVER_ID int IDENTITY (1, 1) NOT NULL,
	WSS_SERVER_NAME nvarchar(255) NULL,
	WSS_SERVER_PORT int NOT NULL,
	WSS_SERVER_IS_SSL tinyint NOT NULL,
	WSS_ADMIN_SERVER_NAME nvarchar(255) NULL,
	WSS_ADMIN_PORT int NOT NULL,
	WSS_ADMIN_IS_SSL tinyint NOT NULL,
	WSS_MANAGED_PATH nvarchar(60) NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_WSS_SERVERS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_WSS_SERVER_DBS')
                begin
                                print 'Creating Table EPG_WSS_SERVER_DBS'

CREATE TABLE dbo.EPG_WSS_SERVER_DBS
(
    WSS_SERVER_ID int NOT NULL,
    WSB_SERVER_NAME nvarchar(255),
    WSB_DB_NAME nvarchar(255),
    WSB_USER_ID nvarchar(255),
    WSB_USER_PWD nvarchar(255)
) 

                end
else
                begin
                                Print 'Updating Table EPG_WSS_SERVER_DBS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_EXT_LINKS')
                begin
                                print 'Creating Table EPG_EXT_LINKS'

CREATE TABLE dbo.EPG_EXT_LINKS
 (
	EXL_UID int NOT NULL,
	EXL_CONTEXT smallint NOT NULL,
	EXL_STATUS smallint NOT NULL,
	EXL_URL nvarchar(255) NULL,
	EXL_CONNECT nvarchar(255) NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_EXT_LINKS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_EXT_MAPPING')
                begin
                                print 'Creating Table EPG_EXT_MAPPING'

CREATE TABLE dbo.EPG_EXT_MAPPING
 (
	EXM_UID int NOT NULL,
	EXM_ENTITY int NOT NULL DEFAULT 0,
	EXM_EPK_FIELD_ID int NOT NULL,
	EXM_EXT_FIELD_ID int NULL,
	EXM_EXT_NAME nvarchar(255) NOT NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_EXT_MAPPING'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_WE_MAPPING')
                begin
                                print 'Creating Table EPG_WE_MAPPING'

CREATE TABLE dbo.EPG_WE_MAPPING
 (
	WEM_UID int NOT NULL,
	WEM_ENTITY int NOT NULL,
	WEM_EPK_FIELD_ID int NOT NULL,
	WEM_WE_FIELD_ID int NULL,
	WEM_WE_NAME nvarchar(255) NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_WE_MAPPING'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_EXT_VIEW_MAPPING')
                begin
                                print 'Creating Table EPG_EXT_VIEW_MAPPING'

CREATE TABLE dbo.EPG_EXT_VIEW_MAPPING
 (
	EXV_UID int NOT NULL,
	EXV_ENTITY int NOT NULL DEFAULT 0,
	EXV_EPK_VIEW_ID int NOT NULL,
	EXV_EXT_VIEW_ID int NULL,
	EXV_EXT_NAME nvarchar(255) NOT NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_EXT_VIEW_MAPPING'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_MSP_FIELDS')
                begin
                                print 'Creating Table EPG_MSP_FIELDS'

CREATE TABLE dbo.EPG_MSP_FIELDS
 (
	MSF_UID int NOT NULL,
	MSF_FIELD_ID int NOT NULL,
	MSF_FIELD_TYPE int NOT NULL,
	MSF_FIELD_NAME nvarchar(255) NOT NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_MSP_FIELDS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RATES')
                begin
                                print 'Creating Table EPG_RATES'

CREATE TABLE dbo.EPG_RATES
 (
	RT_UID int NOT NULL,
	RT_NAME nvarchar(255),
	RT_ID int NOT NULL,
	RT_LEVEL int NOT NULL,
	RT_TOOLTIP nvarchar(255)
) 

                end
else
                begin
                                Print 'Updating Table EPG_RATES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_RATE_VALUES')
                begin
                                print 'Creating Table EPG_RATE_VALUES'

CREATE TABLE dbo.EPG_RATE_VALUES
 (
	RT_UID int NOT NULL,
	RT_EFFECTIVE_DATE datetime,
	RT_RATE decimal(15,6),
	RT_OVERTIME_RATE decimal(15,6)
) 

                end
else
                begin
                                Print 'Updating Table EPG_RATE_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_COST_RATES')
                begin
                                print 'Creating Table EPGP_COST_RATES'

CREATE TABLE dbo.EPGP_COST_RATES
(
	TB_UID int,
	WRES_ID int,
	RT_UID int
)

                end
else
                begin
                                Print 'Updating Table EPGP_COST_RATES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_COST_DETAILS')
                begin
                                print 'Creating Table EPGP_MODEL_COST_DETAILS'

CREATE TABLE dbo.EPGP_MODEL_COST_DETAILS
(
	MODEL_UID int NOT NULL,
	MODEL_VERSION_UID int NOT NULL,
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	SELECTED_FLAG tinyint NOT NULL,
	PROJECT_ID int NOT NULL,
	BC_UID int NOT NULL,
	BC_SEQ int NOT NULL,
	RT_UID int NULL,
	OC_01 int NULL,
	OC_02 int NULL,
	OC_03 int NULL,
	OC_04 int NULL,
	OC_05 int NULL,
	TEXT_01 nvarchar(255) NULL,
	TEXT_02 nvarchar(255) NULL,
	TEXT_03 nvarchar(255) NULL,
	TEXT_04 nvarchar(255) NULL,
	TEXT_05 nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_COST_DETAILS'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_DETAIL_VALUES')
                begin
                                print 'Creating Table EPGP_MODEL_DETAIL_VALUES'

CREATE TABLE dbo.EPGP_MODEL_DETAIL_VALUES
(
	MODEL_UID int NOT NULL,
	MODEL_VERSION_UID int NOT NULL,
	CB_ID int NOT NULL,
	CT_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	BC_UID int NOT NULL,
	BC_SEQ int NOT NULL,
	BD_PERIOD int NOT NULL,
	BD_VALUE decimal(25,6),
	BD_COST decimal(25,6)
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_DETAIL_VALUES'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_TARGETS')
                begin
                                print 'Creating Table EPGP_MODEL_TARGETS'

CREATE TABLE dbo.EPGP_MODEL_TARGETS
(
	TARGET_ID int NOT NULL,
	CB_ID int NOT NULL,
	WRES_ID int NOT NULL,
	TARGET_NAME nvarchar(255),
	TARGET_DESC nvarchar(255)

)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_TARGETS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_TARGET_VALUES')
                begin
                                print 'Creating Table EPGP_MODEL_TARGET_VALUES'

CREATE TABLE dbo.EPGP_MODEL_TARGET_VALUES
(
	TARGET_ID int NOT NULL,
	TARGET_UID int NOT NULL,
	BD_PERIOD int NOT NULL,
	BD_VALUE decimal(25,6),	
	BD_COST decimal(25,6)	
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_TARGET_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_TARGET_DETAILS')
                begin
                                print 'Creating Table EPGP_MODEL_TARGET_DETAILS'

CREATE TABLE dbo.EPGP_MODEL_TARGET_DETAILS
(
	TARGET_ID int NOT NULL,
	TARGET_UID int NOT NULL,
	CT_ID int NOT NULL,
	BC_UID int NOT NULL,
	OC_01 int NULL,
	OC_02 int NULL,
	OC_03 int NULL,
	OC_04 int NULL,
	OC_05 int NULL,
	TEXT_01 nvarchar(255) NULL,
	TEXT_02 nvarchar(255) NULL,
	TEXT_03 nvarchar(255) NULL,
	TEXT_04 nvarchar(255) NULL,
	TEXT_05 nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_TARGET_DETAILS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_SCENARIOS')
                begin
                                print 'Creating Table EPGP_MODEL_SCENARIOS'

CREATE TABLE EPGP_MODEL_SCENARIOS
(
	MODEL_UID int IDENTITY (1, 1) NOT NULL,
	MODEL_NAME nvarchar(255)  NOT NULL,
	MODEL_DESC nvarchar(255),
	MODEL_CB_ID int NOT NULL,
	MODEL_SELECTED_FIELD_ID int
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_SCENARIOS'
                end 

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_CTS')
                begin
                                print 'Creating Table EPGP_MODEL_CTS'

CREATE TABLE EPGP_MODEL_CTS
(
	MODEL_UID int NOT NULL,
	MODEL_CT_ID int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_CTS'
                end 

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_VERSIONS')
                begin
                                print 'Creating Table EPGP_MODEL_VERSIONS'

CREATE TABLE EPGP_MODEL_VERSIONS
(
	MODEL_UID int NOT NULL,
	MODEL_VERSION_UID int NOT NULL,
	MODEL_VERSION_NAME nvarchar(255)  NOT NULL,
	MODEL_VERSION_DESC nvarchar(255),
	MODEL_DEFAULT int
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_VERSIONS'
                end 

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_PROJECT_DATES')
                begin
                                print 'Creating Table EPGP_MODEL_PROJECT_DATES'

CREATE TABLE EPGP_MODEL_PROJECT_DATES
(
	MODEL_UID int NOT NULL,
	MODEL_VERSION_UID int NOT NULL,
	PROJECT_ID int NOT NULL,
	PROJECT_SELECTED int,
    PROJECT_START_DATE datetime,
    PROJECT_FINISH_DATE datetime
)

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_PROJECT_DATES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_MODEL_GROUP_SECURITY')
                begin
                                print 'Creating Table EPGP_MODEL_GROUP_SECURITY'

CREATE TABLE EPGP_MODEL_GROUP_SECURITY 
(
	MODEL_UID int NOT NULL ,
	MODEL_VERSION_UID int NOT NULL ,
	GROUP_ID int NOT NULL ,
	VIEW_PERMISSION int NOT NULL ,
	EDIT_PERMISSION int NOT NULL 
) 

                end
else
                begin
                                Print 'Updating Table EPGP_MODEL_GROUP_SECURITY'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_LOG')
                begin
                                print 'Creating Table EPG_LOG'

CREATE TABLE dbo.EPG_LOG
 (
	LOG_UID int IDENTITY (1, 1) NOT NULL,
	LOG_SESSION nvarchar(48) NOT NULL,
	LOG_WRES_ID int NOT NULL,
	LOG_CHANNEL int NOT NULL,
	LOG_STATUS int NOT NULL, 
	LOG_TIMESTAMP datetime NOT NULL,
	LOG_KEYWORD nvarchar(50) NOT NULL,
	LOG_FUNCTION nvarchar(50) NOT NULL,
	LOG_TEXT nvarchar(255) NULL,
	LOG_DETAILS ntext NULL
) 

                end
else
                begin
                                Print 'Updating Table EPG_LOG'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_JOBS_USER')
                begin
                                print 'Creating Table EPG_JOBS_USER'

CREATE TABLE dbo.EPG_JOBS_USER(
	JOU_UID int IDENTITY(1,1) NOT NULL,
	JOU_TIMESTAMP datetime NOT NULL,
	WRES_ID int NOT NULL,
	JOU_REGISTERED_NAME nvarchar(255) NOT NULL,
	JOU_TITLE nvarchar(255) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_JOBS_USER'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_JOBS_USER_GROUPS')
                begin
                                print 'Creating Table EPG_JOBS_USER_GROUPS'

CREATE TABLE dbo.EPG_JOBS_USER_GROUPS(
	JOU_UID int NOT NULL,
	GROUP_ID int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPG_JOBS_USER_GROUPS'
                end
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_PROJECT_DETAILS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_PROJECT_DETAILS'
     DROP TABLE dbo.EPGP_EV_PROJECT_DETAILS
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_PROJECT_DETAILS')
--                begin
--                                print 'Creating Table EPGP_EV_PROJECT_DETAILS'

--CREATE TABLE dbo.EPGP_EV_PROJECT_DETAILS
--(
--	PROJECT_ID int NOT NULL,
--	PEV_BCWS_DATE datetime NULL,
--	PEV_BCWS_IS_LOCKED tinyint NOT NULL Default 0,
--	PEV_BCWP_DATE datetime NULL,
--	PEV_BCWP_STATUSDATE datetime NULL,	
--	PEV_BCWS_BURDEN_DATE datetime NULL,
--	PEV_BCWP_BURDEN_DATE datetime NULL,
--        Primary Key (PROJECT_ID)
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_PROJECT_DETAILS'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_PROJECT_STATUS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_PROJECT_STATUS'
     DROP TABLE dbo.EPGP_EV_PROJECT_STATUS
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_PROJECT_STATUS')
--                begin
--                                print 'Creating Table EPGP_EV_PROJECT_STATUS'

--CREATE TABLE dbo.EPGP_EV_PROJECT_STATUS
--(
--	PROJECT_ID int NOT NULL,
--	PST_PRD_ID int NOT NULL Default 0,
--	PST_EV_VT_ID int NOT NULL,
--	PST_CALC_DATE datetime NOT NULL,
--	PST_STATUS_DATE datetime NULL,
--	PST_WRES_ID int NOT NULL,
--	PST_LOCKED tinyint NOT NULL Default 0,
--	PST_LOCK_DATE datetime,
--	PST_LOCK_WRES_ID int NULL,
--        Primary Key (PROJECT_ID,PST_PRD_ID,PST_EV_VT_ID)
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_PROJECT_STATUS'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_WBS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_WBS'
     DROP TABLE dbo.EPGP_EV_WBS
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_WBS')
--                begin
--                                print 'Creating Table EPGP_EV_WBS'

--CREATE TABLE dbo.EPGP_EV_WBS
--(
--	PROJECT_ID int NOT NULL,
--	WBS_UID int NOT NULL,
--	WBS_SEQ int NOT NULL,
--	WBS_LEVEL int NOT NULL,
--	WBS_IS_SUMMARY tinyint NOT NULL,
--	WBS_EST_TYPE int NOT NULL,
--	WBS_NODE_TYPE int,
--	WBS_NAME nvarchar(255) NULL,
--	WBS_FULL_NAME nvarchar(255) NULL,
--	WBS_DESC nvarchar(255) NULL,
--	WBS_OWNER int NOT NULL,
--	WBS_VALUE decimal(25,6),
--	WBS_COST decimal(25,6),
--	WBS_EARNEDVALUE decimal(25,6),
--	WBS_EARNEDCOST decimal(25,6),
--	WBS_FORCVALUE decimal(25,6),
--	WBS_FORCCOST decimal(25,6),
--	WBS_ACTUALVALUE decimal(25,6),
--	WBS_ACTUALCOST decimal(25,6),
--	WBS_PERCENT_COMPLETE int NULL,
--	WBS_START_DATE datetime,
--	WBS_FINISH_DATE datetime,
--	WBS_ACTUAL_START_DATE datetime NULL,
--	WBS_ACTUAL_FINISH_DATE datetime NULL,
--    WBS_OBS int NULL,
--	WBS_TEXT_01 nvarchar(255) NULL,
--	WBS_TEXT_02 nvarchar(255) NULL,
--	WBS_TEXT_03 nvarchar(255) NULL,
--	WBS_TEXT_04 nvarchar(255) NULL,
--	WBS_TEXT_05 nvarchar(255) NULL,
--    WBS_OC_01 int NULL,
--    WBS_OC_02 int NULL,
--    WBS_OC_03 int NULL,
--    WBS_OC_04 int NULL,
--    WBS_OC_05 int NULL,
--        Primary Key (PROJECT_ID,WBS_UID)
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_WBS'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_WBS_TEMPLATE_NAMES')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_WBS_TEMPLATE_NAMES'
     DROP TABLE dbo.EPGP_EV_WBS_TEMPLATE_NAMES
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_WBS_TEMPLATE_NAMES')
--                begin
--                                print 'Creating Table EPGP_EV_WBS_TEMPLATE_NAMES'

--CREATE TABLE dbo.EPGP_EV_WBS_TEMPLATE_NAMES
--(
--	WTN_UID int NOT NULL,
--	WTN_NAME nvarchar(255) NULL,
--	WTN_DESC nvarchar(255) NULL
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_WBS_TEMPLATE_NAMES'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_WBS_TEMPLATES')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_WBS_TEMPLATES'
     DROP TABLE dbo.EPGP_EV_WBS_TEMPLATES
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_WBS_TEMPLATES')
--                begin
--                                print 'Creating Table EPGP_EV_WBS_TEMPLATES'

--CREATE TABLE dbo.EPGP_EV_WBS_TEMPLATES
--(
--	WTN_UID int NOT NULL,
--	WT_UID int NOT NULL,
--	WT_SEQ int NOT NULL,
--	WT_LEVEL int NOT NULL,
--	WT_NAME nvarchar(255) NULL,
--	WT_DESC nvarchar(255) NULL
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_WBS_TEMPLATES'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_COST_DETAILS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_COST_DETAILS'
     DROP TABLE dbo.EPGP_EV_COST_DETAILS
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_COST_DETAILS')
--                begin
--                                print 'Creating Table EPGP_EV_COST_DETAILS'

--CREATE TABLE dbo.EPGP_EV_COST_DETAILS
--(
--	PROJECT_ID int NOT NULL,
--	WBS_UID int NOT NULL,
--	EV_UID int NOT NULL,
--	EV_SEQ int NOT NULL,
--	BC_UID int NOT NULL,
--	EV_EST nvarchar(255) NULL,
--        Primary Key (PROJECT_ID,WBS_UID,EV_UID)
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_COST_DETAILS'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_DETAIL_VALUES')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_DETAIL_VALUES'
     DROP TABLE dbo.EPGP_EV_DETAIL_VALUES
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_DETAIL_VALUES')
--                begin
--                                print 'Creating Table EPGP_EV_DETAIL_VALUES'

--CREATE TABLE dbo.EPGP_EV_DETAIL_VALUES
--(
--	PROJECT_ID int NOT NULL,
--	EV_UID int NOT NULL,
--	EV_VT_ID int NOT NULL,
--	EV_PRD_ID int NOT NULL,
--	EV_VALUE decimal(25,6),
--	EV_COST decimal(25,6),
--	EV_TOTAL_COST decimal(25,6),
--	EV_BURDEN01_COST decimal(25,6),
--	EV_BURDEN02_COST decimal(25,6),
--	EV_BURDEN03_COST decimal(25,6),
--	EV_BURDEN04_COST decimal(25,6),
--	EV_BURDEN05_COST decimal(25,6),
--	EV_BURDEN06_COST decimal(25,6),
--	EV_BURDEN07_COST decimal(25,6),
--	EV_BURDEN08_COST decimal(25,6),
--	EV_BURDEN09_COST decimal(25,6),
--	EV_BURDEN10_COST decimal(25,6),
--        Primary Key (PROJECT_ID,EV_UID,EV_VT_ID,EV_PRD_ID)
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_DETAIL_VALUES'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_EV_NOTES')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_EV_NOTES'
     DROP TABLE dbo.EPGP_EV_NOTES
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_EV_NOTES')
--                begin
--                                print 'Creating Table EPGP_EV_NOTES'

--CREATE TABLE dbo.EPGP_EV_NOTES
--(
--	EVN_UID int IDENTITY (1, 1) NOT NULL,
--	PROJECT_ID int NOT NULL,
--	WBS_UID int NOT NULL,
--	EVN_PRD_ID int NOT NULL,
--	EVN_TIMESTAMP datetime NOT NULL,
--	EVN_AUTHOR_WRES_ID int NOT NULL,
--	EVN_RTF ntext
--)

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_EV_NOTES'
--                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_GROUPS')
                begin
                                print 'Creating Table EPGP_PI_GROUPS'

CREATE TABLE dbo.EPGP_PI_GROUPS
(
	GROUP_UID int NOT NULL,
	GROUP_NAME nvarchar(255) NULL,
	GROUP_DESC nvarchar(255) NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_GROUPS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_GROUP_MEMBERS')
                begin
                                print 'Creating Table EPGP_PI_GROUP_MEMBERS'

CREATE TABLE dbo.EPGP_PI_GROUP_MEMBERS
(
	GROUP_UID int NOT NULL,
	PROJECT_ID int NOT NULL,
	PGM_LEVEL int NOT NULL,
	PGM_SEQ int NOT NULL,
	PGM_OFFSET int,
	PGM_OFFSET_TYPE int
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_GROUP_MEMBERS'
                end

--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_BURDEN_GROUPS')
--AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
--Begin
--     print 'Drop Table EPGP_BURDEN_GROUPS'
--     DROP TABLE dbo.EPGP_BURDEN_GROUPS
--end
--
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_BURDEN_GROUPS')
                begin
                                print 'Creating Table EPGP_BURDEN_GROUPS'

CREATE TABLE dbo.EPGP_BURDEN_GROUPS
 (
	BG_ID int IDENTITY (1, 1) NOT NULL,
	BG_NAME nvarchar(255)
) 

                end
else
                begin
                                Print 'Updating Table EPGP_BURDEN_GROUPS'
                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_BURDENS')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_BURDENS'
     DROP TABLE dbo.EPGP_BURDENS
end


--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_BURDENS')
--                begin
--                                print 'Creating Table EPGP_BURDENS'
--CREATE TABLE dbo.EPGP_BURDENS
-- (
--	BG_ID int NOT NULL,
--	BR_UID int NOT NULL,
--	BR_SEQ int NOT NULL,
--	BR_NAME nvarchar(255),
--	BR_TYPE int NOT NULL Default 0,
--	Primary Key (BG_ID,BR_UID)
--) 

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_BURDENS'
--                end

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EPGP_BURDEN_VALUES')
AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
Begin
     print 'Drop Table EPGP_BURDEN_VALUES'
     DROP TABLE dbo.EPGP_BURDEN_VALUES
end

--if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_BURDEN_VALUES')
--                begin
--                                print 'Creating Table EPGP_BURDEN_VALUES'

--CREATE TABLE dbo.EPGP_BURDEN_VALUES
-- (
--	BG_ID int NOT NULL,
--	BR_UID int NOT NULL,
--	BC_UID int NOT NULL,
--	BV_VALUE decimal(25,6),
--	Primary Key (BG_ID,BR_UID,BC_UID)
--) 

--                end
--else
--                begin
--                                Print 'Updating Table EPGP_BURDEN_VALUES'
--                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_NOTIFY_EVENTS')
                begin
                                print 'Creating Table EPG_NOTIFY_EVENTS'


-- System table defining notification events available - initialized by script
CREATE TABLE dbo.EPG_NOTIFY_EVENTS
 (
	NE_UID int NOT NULL,
	NE_NAME nvarchar(255),
	NE_DESC nvarchar(255)) 

                end
else
                begin
                                Print 'Updating Table EPG_NOTIFY_EVENTS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_NOTIFY_ACTIONS')
                begin
                                print 'Creating Table EPG_NOTIFY_ACTIONS'


-- User maintained table specifying actions to be taken when notification event is raised
-- Defaults initialized by script but user definable from thereon
CREATE TABLE dbo.EPG_NOTIFY_ACTIONS
 (
	NEA_UID int NOT NULL,
	NE_UID int NOT NULL,
	NEA_DESC nvarchar(255),	
	NEA_PARAMS nvarchar(255),	-- This contains any qualifying values e.g. PIStage=6; (PIStage is a Param)
	NEA_NOTE_FROM nvarchar(255), -- e.g. [UserName]
	NEA_EMAIL_FROM nvarchar(255), -- e.g. [UserEMail]
	NEA_NOTE_TO_LIST nvarchar(1023), -- e.g. Katie Jordan; Chris Preston; Group=Administrators;
	NEA_EMAIL_TO_LIST nvarchar(1023), -- e.g. nonepkuser@somewhere.net;
	NEA_USER_CAN_VIEW tinyint,	-- flag - does user get to preview the notification?
	NEA_INACTIVE tinyint,	-- flag - turns the action off
	NEA_SUBJECT ntext,	-- plain text single line string with macros e.g. Stage change to [NewStageName}
	NEA_BODY ntext	-- html multi line string with macros
) 

                end
else
                begin
                                Print 'Updating Table EPG_NOTIFY_ACTIONS'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_COST_ADMIN')
                begin
                                print 'Creating Table EPG_COST_ADMIN'

CREATE TABLE dbo.EPG_COST_ADMIN
(
	CDM_COST_TYPE_01 int,
	CDM_COST_TYPE_02 int,
	CDM_COST_TYPE_03 int,
	CDM_COST_TYPE_04 int,
	CDM_COST_TYPE_05 int,
	CDM_CB_ID int,
    CDM_VIEW int,
    CDM_COST_TOTAL_01 nvarchar(255),
    CDM_COST_TOTAL_02 nvarchar(255),
    CDM_COST_TOTAL_03 nvarchar(255),
    CDM_COST_TOTAL_04 nvarchar(255),
    CDM_COST_TOTAL_05 nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_COST_ADMIN'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_WE_CHARGES')
                begin
                                print 'Creating Table EPG_WE_CHARGES'

CREATE TABLE dbo.EPG_WE_CHARGES
(
	WEC_CHG_UID int IDENTITY (1, 1) NOT NULL,
	WRES_ID int NOT NULL,
	PROJECT_ID int NOT NULL,
	WEC_MAJORCATEGORY nvarchar(255) NULL,
	WEC_CATEGORY nvarchar(255) NULL,
	WEC_DEPT_UID INT,
	WEC_DEPT_NAME nvarchar(255)
)

                end
else
                begin
                                Print 'Updating Table EPG_WE_CHARGES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_WE_ACTUALHOURS')
                begin
                                print 'Creating Table EPG_WE_ACTUALHOURS'

CREATE TABLE dbo.EPG_WE_ACTUALHOURS
(
	WEH_CHG_UID int NOT NULL,
	WEH_DATE DATETIME,
	WEH_NORMALHOURS int,
	WEH_OVERTIMEHOURS int
)

                end
else
                begin
                                Print 'Updating Table EPG_WE_ACTUALHOURS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_PRI_COMPONENTS')
                begin
                                print 'Creating Table EPGP_PI_PRI_COMPONENTS'

CREATE TABLE dbo.EPGP_PI_PRI_COMPONENTS
(
	CC_COMPONENT int NOT NULL,
	CC_SEQ int NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_PRI_COMPONENTS'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_PRI_WEIGHTS')
                begin
                                print 'Creating Table EPGP_PI_PRI_WEIGHTS'

CREATE TABLE dbo.EPGP_PI_PRI_WEIGHTS
(
	CW_RESULT int NOT NULL,
	CW_COMPONENT int NOT NULL,
	CW_RATIO decimal(25,6) NOT NULL
)

                end
else
                begin
                                Print 'Updating Table EPGP_PI_PRI_WEIGHTS'
                end
                
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VIEWS')
                begin
                                print 'Creating Table EPG_VIEWS'

CREATE TABLE dbo.EPG_VIEWS
(
 VIEW_GUID uniqueidentifier NOT NULL,
 WRES_ID int NOT NULL DEFAULT 0,
 VIEW_DEFAULT tinyint NOT NULL DEFAULT 0,
 VIEW_NAME nvarchar(255) NOT NULL,
 VIEW_CONTEXT int NOT NULL,
 VIEW_DATA ntext
)

                end
else
                begin
                                Print 'Updating Table EPG_VIEWS'
                end
 
 if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_DEPT_MANAGERS')
                begin
                                print 'Creating Table EPG_DEPT_MANAGERS'

CREATE TABLE dbo.EPG_DEPT_MANAGERS
(
	CODE_UID int NOT NULL,
	WRES_ID int NOT NULL,
	CANREAD tinyint NOT NULL DEFAULT 0,
	CANWRITE tinyint NOT NULL DEFAULT 0
)

                end
else
                begin
                                Print 'Updating Table EPG_DEPT_MANAGERS'
                end
  
  if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_COST_CATEGORY_RATE_VALUES')
                begin
                                print 'Creating Table EPG_COST_CATEGORY_RATE_VALUES'

CREATE TABLE dbo.EPG_COST_CATEGORY_RATE_VALUES
 (
	BC_UID int NOT NULL,
	BC_EFFECTIVE_DATE datetime,
	BC_RATE decimal(15,6),
	BC_OVERTIME_RATE decimal(15,6)
) 

                end
else
                begin
                                Print 'Updating Table EPG_COST_CATEGORY_RATE_VALUES'
                end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_WORK1')
                begin
                                print 'Creating Table EPGP_PI_WORK1'

CREATE TABLE dbo.EPGP_PI_WORK1
 (
	PROJECT_ID int NOT NULL,
	WRES_ID int NOT NULL,
	PW_ITEM_ID nvarchar(255) NULL,
	PW_SOURCE int NULL,
	PW_MAJORCATEGORY nvarchar(255) NULL,
	PW_DATE datetime NULL,
	PW_WORK decimal(25,6)
) 

                end
else
                begin
                                Print 'Updating Table EPGP_PI_WORK1'
                end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPGP_PI_WORK2')
                begin
                                print 'Creating Table EPGP_PI_WORK2'

CREATE TABLE dbo.EPGP_PI_WORK2
 (
	PROJECT_ID int NOT NULL,
	WRES_ID int NOT NULL,
	PW_ITEM_ID nvarchar(255) NULL,
	PW_SOURCE int NULL,
	PW_MAJORCATEGORY nvarchar(255) NULL,
	PW_DATE datetime NULL,
	PW_WORK decimal(25,6)
) 

                end
else
                begin
                                Print 'Updating Table EPGP_PI_WORK2'
                end
                                                            
