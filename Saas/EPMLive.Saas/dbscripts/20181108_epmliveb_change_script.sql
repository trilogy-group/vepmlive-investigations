IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IDX_ACCOUNT_ACCOUNT_ID' AND object_id = OBJECT_ID('dbo.[ACCOUNT]'))
BEGIN
	CREATE NONCLUSTERED INDEX [IDX_ACCOUNT_ACCOUNT_ID]
	ON [dbo].[ACCOUNT] ([account_id])
	INCLUDE ([maxusers],[dtCreated],[monthsfree])
END