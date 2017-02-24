UPDATE [epmlivedb].[dbo].[ORDERS]
SET [activation]=[dtcreated]
where [dtcreated] is not null and [activation] is null;

SELECT newid() as 'history_id'
	  ,[order_id]
	  ,[account_ref]
	  ,[plimusReferenceNumber]
	  ,[quantity]
	  ,[diskspace]
	  ,[projects]
	  ,[activation]
	  ,[expiration]
	  ,[plimusAccountId]
	  ,[version]
	  ,[dtcreated]
	  ,[poId]
	  ,[crmuid]
	  ,[crmorderid]
	  ,[crmorderuid]
	  ,[crminvoiceuid]
	  ,[enabled]
	  ,[contractid]
	  ,[billingsystem]
	  ,[product_id]
	  ,0 as 'reason'
	  ,'' as 'reason_comment'
INTO #EXPIREDORDERS
FROM [ORDERS]
WHERE [expiration] < GETDATE()
	and [order_id] not in (select distinct([order_id]) from [ORDERHISTORY]);

INSERT INTO [dbo].[ORDERHISTORY]
		   ([history_id]
		   ,[order_id]
		   ,[account_ref]
		   ,[plimusReferenceNumber]
		   ,[quantity]
		   ,[diskspace]
		   ,[projects]
		   ,[activation]
		   ,[expiration]
		   ,[plimusAccountId]
		   ,[version]
		   ,[dtcreated]
		   ,[poId]
		   ,[crmuid]
		   ,[crmorderid]
		   ,[crmorderuid]
		   ,[crminvoiceuid]
		   ,[enabled]
		   ,[contractid]
		   ,[billingsystem]
		   ,[product_id]
		   ,[reason]
		   ,[reason_comment])
SELECT * FROM #EXPIREDORDERS;

INSERT INTO [dbo].[ORDERDETAILHIST]
		   ([history_id]
		   ,[order_detail_id]
		   ,[order_id]
		   ,[detail_type_id]
		   ,[quantity])
	SELECT eo.[history_id]
		   ,od.[order_detail_id]
		   ,od.[order_id]
		   ,od.[detail_type_id]
		   ,od.[quantity]
	FROM [ORDERDETAIL] od inner join #EXPIREDORDERS eo on od.[order_id]=eo.[order_id];

DELETE FROM [ORDERDETAIL] WHERE [order_id] in (select distinct ([order_id]) from #EXPIREDORDERS);
DELETE FROM [ORDERS] WHERE [order_id] in (SELECT DISTINCT([order_id]) FROM #EXPIREDORDERS);

DROP TABLE #EXPIREDORDERS;