if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 52)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (52,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.Applications.Uninstall','Application Uninstall',3)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.Applications.Uninstall', [Title]='Application Uninstall', Priority=3 where jobtype_id=52
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 51)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (51,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.Applications.InstallAndConfigure','Application Install',3)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.Applications.InstallAndConfigure', [Title]='Application Install', Priority=3 where jobtype_id=51
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 9)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (9,'EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveWorkPlanner.PublishJob','Publish',1)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveWorkPlanner.PublishJob', [Title]='Publish', Priority=1 where jobtype_id=9
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 8)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (8,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.AdSynchJob','Active Directory Synch',99)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.AdSynchJob', [Title]='Active Directory Synch', Priority=99 where jobtype_id=8
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 3)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (3,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.Notifications','Notifications',99)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.Notifications', [Title]='Notifications', Priority=99 where jobtype_id=3
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 2)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (2,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.TimerFix','Rollup and Calculated Fields',99)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.TimerFix', [Title]='Rollup and Calculated Fields', Priority=99 where jobtype_id=2
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 1)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (1,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.ResourcePlan','Resource Information',99)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.ResourcePlan', [Title]='Resource Information', Priority=99 where jobtype_id=1
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 4)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (4,'EPMLiveSynch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=3ef432eb7a3c56f7','EPMLiveSynch.SynchJob','List Synch Job',50)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveSynch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=3ef432eb7a3c56f7', NetClass='EPMLiveSynch.SynchJob', [Title]='List Synch Job', Priority=50 where jobtype_id=4
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 5)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (5,'EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050','EPMLiveReportsAdmin.Jobs.CollectJob','Reporting Refresh',99)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050', NetClass='EPMLiveReportsAdmin.Jobs.CollectJob', [Title]='Reporting Refresh', Priority=99 where jobtype_id=5
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 7)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (7,'EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050','EPMLiveReportsAdmin.Jobs.SnapshotJob','Reporting Snapshot',50)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050', NetClass='EPMLiveReportsAdmin.Jobs.SnapshotJob', [Title]='Reporting Snapshot', Priority=50 where jobtype_id=7
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 10)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (10,'WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','WorkEnginePPM.Jobs.Cleanup','PPM Cleanup',99)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='WorkEnginePPM.Jobs.Cleanup', [Title]='PPM Cleanup', Priority=99 where jobtype_id=10
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 20)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (20,'EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveWorkPlanner.XLSImportJob','Excel Import',2)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveWorkPlanner.XLSImportJob', [Title]='Excel Import', Priority=2 where jobtype_id=20
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 21)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (21,'EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveWorkPlanner.ListImportJob','List Import',2)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveWorkPlanner.ListImportJob', [Title]='List Import', Priority=2 where jobtype_id=21
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 22)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (22,'EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveWorkPlanner.CsvImportJob','CSV Import',2)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveWorkPlanner.CsvImportJob', [Title]='CSV Import', Priority=2 where jobtype_id=22
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 30)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (30,'TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','TimeSheets.ApprovalJob','Timesheet Approval',0)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='TimeSheets.ApprovalJob', [Title]='Timesheet Approval', Priority=0 where jobtype_id=30
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 80)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (80,'WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','WorkEnginePPM.Jobs.InstallWorkEvents','InstallWorkEvents',5)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='WorkEnginePPM.Jobs.InstallWorkEvents', [Title]='InstallWorkEvents', Priority=5 where jobtype_id=80
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 81)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (81,'WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','WorkEnginePPM.Jobs.PublishWorkPlannerWork','Push Work Into PfE',1)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='WorkEnginePPM.Jobs.PublishWorkPlannerWork', [Title]='Push Work Into PfE', Priority=1 where jobtype_id=81
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 82)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (82,'WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','WorkEnginePPM.Jobs.Setup','Setup PfE',5)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='WorkEnginePPM.Jobs.Setup', [Title]='Setup PfE', Priority=5 where jobtype_id=82
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 200)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (200,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.Upgrades.WE43UpgradeJob','4.3 Upgrade',5)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.Upgrades.WE43UpgradeJob', [Title]='4.3 Upgrade', Priority=5 where jobtype_id=200
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 31)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (31,'TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','TimeSheets.SaveJob','Timesheet Save',0)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='TimeSheets.SaveJob', [Title]='Timesheet Save', Priority=0 where jobtype_id=31
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 40)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (40,'EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050','EPMLiveReportsAdmin.Jobs.RefreshSec','Refresh Security Info',5)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050', NetClass='EPMLiveReportsAdmin.Jobs.RefreshSec', [Title]='Refresh Security Info', Priority=5 where jobtype_id=40
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 60)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (60,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.ResourceImportJob','Resource Import',2)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.ResourceImportJob', [Title]='Resource Import', Priority=2 where jobtype_id=60
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 11)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (11,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.SecurityUpdate','Security Update',1)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.SecurityUpdate', [Title]='Security Update', Priority=1 where jobtype_id=11
end
if not exists (select jobtype_id from TIMERJOBTYPES where jobtype_id = 70)
begin
    INSERT INTO TIMERJOBTYPES (jobtype_id,NetAssembly,NetClass,[Title],priority) VALUES (70,'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5','EPMLiveCore.Jobs.Integration','Integration Job',20)
end
else
begin
    UPDATE TIMERJOBTYPES SET NetAssembly='EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', NetClass='EPMLiveCore.Jobs.Integration', [Title]='Integration Job', Priority=20 where jobtype_id=70
end
