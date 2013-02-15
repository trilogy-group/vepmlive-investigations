using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using PortfolioEngineCore;
using System.Globalization;


namespace ResourceValues
{
    internal enum ResCenterRequest : int
    {
        ResourceValuesForDepts = 1,
        ResourceValuesForPIsinDept = 2,
        ResourceValuesForPIs = 3,
        ResourceValuesForResources = 4,
        ResourceValuesForPIinDept = 5,
        GetAvailFromMsp = 10,
        CapacityNames = 11,
        CheckCapacity = 12,
        CapacityValues = 13,
        PIsForMyGuys = 14,
        ReadDeptResources = 17,
        ReadGenericResources = 18,
        ReadResources = 19,
        ReadCBCTCombinations = 20,
        ReadRoleHours = 21,
        Depts = 31,
        FiscalCals = 32,
        fields = 33,
        ResourceInformation = 40,
        GenericInformation = 41,
        RPInformation = 42,
        RAInformation = 43,
        WEInformation = 44
    }

    [Serializable()]
    internal class clsCatItem
    {
        public int UID, ID, Level, Role_UID, Mode, PID, MajorCategory, Category;
        public string sUID, UoM, Name, FullName;
    }

    [Serializable()]
    internal class CPeriod
    {
        public string PeriodName;
        public int PeriodID;
        public DateTime StartDate;
        public DateTime FinishDate;
    }

    [Serializable()]
    internal class clsEPKItem
    {
        public string Name = "";
        public string Desc = "";
        public int ID = 0;
        public int UID = 0;
        public int level = 0, Flag = 0;
    }

    [Serializable()]
    internal class clsListItem
    {
        public string FullName = "";
        public string Name = "";
        public string Desc = "";
        public string ExtUID = "";
        public int ID = 0;
        public int UID = 0;
        public int Level = 0;
        public int PID = 0;
        public bool Inactive = false;
    }


    [Serializable()]
    internal class clsPIData
    {
        public string ProjectGUID = "";
        public string PIName = "";
        public string ItemManager = "", LinkedProject = "", StageOwner = "", Stage = "", WSSSite = "";
        public int ProjectID = 0;
        public DateTime start = DateTime.MinValue, finish = DateTime.MinValue;
        public int Priority = 0;

        public int ItemManagerWresID = 0, WprojID = 0, Published = 0, ResourcePlan = 0;
        public bool bIsRealPI = true;

        public List<string> CustomFields;
    }

    [Serializable()]
    internal class clsResCap
    {
        public int ID, DeptUID, RoleUID, RT_UID, BC_UID_Role, BC_UID_CC;
        public string Name;
        public bool IsResource, IsGeneric, Inactive;
        public List<string> CustomFields = new List<string>();

    }

    [Serializable()]
    internal class clsCommitment
    {
        public int UID, ID, ProjectID, BC_UID_Role, BC_UID_CC, RoleUID, WResID, DeptUID, Status, Dragable;
        public string Group, RateType, MajorCategory;
        public double HoursInWindow, Rate, cost;
        public DateTime StartDate = DateTime.MinValue, FinishDate = DateTime.MinValue;
        public List<string> CustomFields = new List<string>();

    }

    [Serializable()]
    internal class clsPortField
    {
        public int ID, Fieldtype, LookupID, CFTable, CFField;
        public string Name,FullGenName, GivenName;
    }

    [Serializable()]
    internal class clsCommitmentHours
    {
        public int UID, CAUID, MCUID, PeriodID, FTES;
        public double Hours;
    }

    [Serializable()]
    internal class clsViewTargetColours
    {
        public int ID, rgb_val;
        public double low_val, high_val;
        public string Desc;
    }

    [Serializable()]
    internal class clsLookupList
    {
        public int FieldID, LeafOnly, Lookup;
        public string Name, Desc;
        public Dictionary<int, clsListItem> ListItems = null;
    }
    [Serializable()]
    internal class clsResAvail
    {
        public int WResID, PeriodID, FTES;
        public double Hours;
    }
    [Serializable()]
    internal class clsCapacityValue
    {
        public int ID, PeriodID, FTES, DeptUID, RoleUID;
        public double Hours;
    }
    [Serializable()]
    internal class clsNWValue
    {
        public int UID, PeriodID, FTES, WResID;
        public double Hours;
    }

    [Serializable()]
    internal class clsSchedWork
    {
        public int ProjectID, PeriodID, FTES, WResID;
        public double Hours;
        public string MajorCategory;
    }

    [Serializable()]
    internal class clsFTEConv
    {
        public int Cat_UID, PeriodID, FTEConv;

    }

    [Serializable()]
    internal class clsResourceValues
    {
        public int CalendarID;
        public int FromPeriodID;
        public int ToPeriodID;
        //public int GetScheduleWork;          //' will be flag from client to say - Yes we do want Schedule Work - then back to Analyzer
        //public int CalcFTE;                  // ' will be flag from client to say - Yes we do want calc FTE values
        //public int CalcOpenReq;              // ' will be flag from client to say - Yes we do want calc Remaining Req'ts
        public string ResExamView;           //'  Saved User View for this mode of Resource Values

        public int gpPMOAdmin;

        public int CommitmentsOpMode;
        public int lRequestNo = 0;
        public string CalendarName;
        public int PlanningCalendarID;
        public int RoleFieldID;
        public int MajorCategoryFieldID;

        public Dictionary<int, clsCatItem> CostCategories;      //    collection of clsCatItem objects
        public Dictionary<int, clsCatItem> Rates;               //    collection of clsCatItem objects
        public Dictionary<int, CPeriod> Periods;                //    collection of CPeriod objects
        public Dictionary<int, clsEPKItem> Departments;         //    collection of clsEPKItem objects
        public Dictionary<int, clsPIData> PIs;                 //    collection of clsPIData objects
        public Dictionary<int, clsResCap> Resources;           // collection of clsResCap objects
        public Dictionary<int, clsListItem> Roles;             //   ' collection of clsListItem objects

        public Dictionary<int, clsCommitment> Commitments;    //  ' collection of clsCommitment objects
        public List<clsCommitmentHours> CommitmentHours;      // ' collection of clsCommitmentHours objects
        public List<clsSchedWork> SchedWorkHours;             //' collection of clsSchedWork objects
        public List<clsSchedWork> ActualWorkHours;             //' collection of clsSchedWork objects

        public Dictionary<int, clsEPKItem> NWItems;            // ' collection of clsEPKItem objects

        public List<clsNWValue> ResNWValues;          //  ' collection of clsNWValue objects
        public List<clsResAvail> ResAvail;            // ' collection of clsResAvail objects

        public Dictionary<int, clsEPKItem> CapacityTargets;    // collection of clsEPKItem objects

        public List<clsCapacityValue> CapacityTargetValues;  // ' collection of clsCapacityValue objects
        public Dictionary<int, clsViewTargetColours> TargetColors;  //           ' collection of clsViewTargetColours objects

        public Dictionary<int, clsCommitment> OpenReqs;      //' collection of clsCommitment objects
        public List<clsCommitmentHours> OpenReqHours;        // ' collection of clsCommitmentHours objects

        public List<clsPortField> PlanFields;          //   ' collection of clsPortField objects
        public List<clsPortField> PIFields;             //   ' collection of clsPortField objects
        public List<clsPortField> ResFields;            //   ' collection of clsPortField objects
        public Dictionary<int, clsLookupList> Lookups; //  ' collection of clsLookupList objects
        public List<clsFTEConv> FTEConvData;            // collection of clsFTEConv objects

        public int lRatMaxLevel = 0;

        public string XML()
        {
            CStruct xResourceValues = new CStruct();
            xResourceValues.Initialize("ResourceValues");
            CStruct xOptions = xResourceValues.CreateSubStruct("Options");
            xOptions.CreateInt("CalendarID", CalendarID);
            xOptions.CreateInt("PlanningCalendarID", PlanningCalendarID);
            xOptions.CreateInt("FromPeriodID", FromPeriodID);
            xOptions.CreateInt("ToPeriodID", ToPeriodID);
            xOptions.CreateInt("gpPMOAdmin", gpPMOAdmin);
            xOptions.CreateInt("CommitmentsOpMode", CommitmentsOpMode);
            xOptions.CreateInt("RequestNo", lRequestNo);
            xOptions.CreateInt("RoleFieldID", RoleFieldID);
            xOptions.CreateInt("MajorCategoryFieldID", MajorCategoryFieldID);
            xOptions.CreateString("CalendarName", CalendarName);

            if (CostCategories != null)
            {
                CStruct xCategories = xResourceValues.CreateSubStruct("CostCategories");
                foreach (KeyValuePair<int, clsCatItem> oCatItemValue in CostCategories)
                {
                    CStruct xCat = xCategories.CreateSubStruct("Cat");
                    xCat.CreateIntAttr("UID", oCatItemValue.Value.UID);
                    xCat.CreateIntAttr("MC", oCatItemValue.Value.MajorCategory);
                    xCat.CreateIntAttr("CC", oCatItemValue.Value.Category);
                    xCat.CreateIntAttr("ID", oCatItemValue.Value.ID);
                    xCat.CreateIntAttr("LVL", oCatItemValue.Value.Level);
                    xCat.CreateIntAttr("Role", oCatItemValue.Value.Role_UID);
                    xCat.CreateIntAttr("PID", oCatItemValue.Value.PID);
                    xCat.CreateStringAttr("Name", oCatItemValue.Value.Name);
                    xCat.CreateStringAttr("FName", oCatItemValue.Value.FullName);
                }
            }

            if (Rates != null)
            {
                CStruct xRates = xResourceValues.CreateSubStruct("Rates");
                foreach (KeyValuePair<int, clsCatItem> oRatItemValue in Rates)
                {
                    CStruct xRat = xRates.CreateSubStruct("Rate");
                    xRat.CreateIntAttr("UID", oRatItemValue.Value.UID);
                    xRat.CreateIntAttr("ID", oRatItemValue.Value.ID);
                    xRat.CreateIntAttr("LVL", oRatItemValue.Value.Level);
                    xRat.CreateIntAttr("PID", oRatItemValue.Value.PID);
                    xRat.CreateStringAttr("Name", oRatItemValue.Value.Name);
                    xRat.CreateStringAttr("FName", oRatItemValue.Value.FullName);
                }
            }

            if (Periods != null)
            {
                CStruct xPeriods = xResourceValues.CreateSubStruct("Periods");
                foreach (KeyValuePair<int, CPeriod> oPeriodItemValue in Periods)
                {
                    CStruct xPeriod = xPeriods.CreateSubStruct("PD");
                    xPeriod.CreateIntAttr("ID", oPeriodItemValue.Value.PeriodID);
                    xPeriod.CreateDateAttr("St", oPeriodItemValue.Value.StartDate);
                    xPeriod.CreateDateAttr("End", oPeriodItemValue.Value.FinishDate);
                    xPeriod.CreateStringAttr("Name", oPeriodItemValue.Value.PeriodName);
                }
            }

            if (Departments != null)
            {
                CStruct xDepts = xResourceValues.CreateSubStruct("Depts");
                foreach (KeyValuePair<int, clsEPKItem> oDeptItemValue in Departments)
                {
                    CStruct xDept = xDepts.CreateSubStruct("Dept");
                    xDept.CreateIntAttr("ID", oDeptItemValue.Value.ID);
                    xDept.CreateStringAttr("Name", oDeptItemValue.Value.Name);
                    xDept.CreateStringAttr("Desc", oDeptItemValue.Value.Desc);
                }
            }

            if (PIs != null)
            {
                CStruct xPIs = xResourceValues.CreateSubStruct("PIs");
                foreach (KeyValuePair<int, clsPIData> oPIItemValue in PIs)
                {
                    CStruct xPI = xPIs.CreateSubStruct("PI");
                    xPI.CreateIntAttr("ProjID", oPIItemValue.Value.ProjectID);
                    xPI.CreateIntAttr("WProjID", oPIItemValue.Value.WprojID);
                    xPI.CreateStringAttr("Name", oPIItemValue.Value.PIName);
                    xPI.CreateStringAttr("LP", oPIItemValue.Value.LinkedProject);
                    xPI.CreateStringAttr("IM", oPIItemValue.Value.ItemManager);
                    xPI.CreateStringAttr("SO", oPIItemValue.Value.StageOwner);
                    xPI.CreateStringAttr("Stage", oPIItemValue.Value.Stage);
                    xPI.CreateStringAttr("WSS", oPIItemValue.Value.WSSSite);
                    xPI.CreateIntAttr("IMID", oPIItemValue.Value.ItemManagerWresID);
                    xPI.CreateIntAttr("Pri", oPIItemValue.Value.Priority);
                    xPI.CreateDateAttr("St", oPIItemValue.Value.start);
                    xPI.CreateDateAttr("Fin", oPIItemValue.Value.finish);

                    if (oPIItemValue.Value.CustomFields != null)
                    {
                        CStruct xCFs = xPI.CreateSubStruct("CFs");
                        foreach (string sCField in oPIItemValue.Value.CustomFields)
                        {
                            CStruct xCF = xCFs.CreateSubStruct("CF");
                            xCF.CreateStringAttr("Fld", sCField);
                        }
                    }
                }
            }

            if (Resources != null)
            {
                CStruct xResources = xResourceValues.CreateSubStruct("Resources");
                foreach (KeyValuePair<int, clsResCap> oResItemValue in Resources)
                {
                    CStruct xRes = xResources.CreateSubStruct("Res");
                    xRes.CreateIntAttr("ID", oResItemValue.Value.ID);
                    xRes.CreateStringAttr("Name", oResItemValue.Value.Name);
                    xRes.CreateIntAttr("DeptUID", oResItemValue.Value.DeptUID);
                    xRes.CreateIntAttr("RoleUID", oResItemValue.Value.RoleUID);
                    xRes.CreateIntAttr("RTUID", oResItemValue.Value.RT_UID);
                    xRes.CreateIntAttr("BC_Role", oResItemValue.Value.BC_UID_Role);
                    xRes.CreateIntAttr("BC_CC", oResItemValue.Value.BC_UID_CC);

                    if (oResItemValue.Value.CustomFields != null)
                    {
                        CStruct xCFs = xRes.CreateSubStruct("CFs");
                        foreach (string sCField in oResItemValue.Value.CustomFields)
                        {
                            CStruct xCF = xCFs.CreateSubStruct("CF");
                            xCF.CreateStringAttr("Fld", sCField);
                        }
                    }
                }
            }

            if (Roles != null)
            {
                CStruct xRoles = xResourceValues.CreateSubStruct("Roles");
                foreach (KeyValuePair<int, clsListItem> oRoleItemValue in Roles)
                {
                    CStruct xRole = xRoles.CreateSubStruct("Role");
                    xRole.CreateIntAttr("ID", oRoleItemValue.Value.ID);
                    xRole.CreateStringAttr("Name", oRoleItemValue.Value.Name);
                }
            }

            if (Commitments != null)
            {
                CStruct xCmts = xResourceValues.CreateSubStruct("Cmts");
                foreach (KeyValuePair<int, clsCommitment> oCmtItemValue in Commitments)
                {
                    CStruct xCmt = xCmts.CreateSubStruct("Cmt");
                    xCmt.CreateIntAttr("UID", oCmtItemValue.Value.UID);
                    xCmt.CreateIntAttr("ID", oCmtItemValue.Value.ID);
                    xCmt.CreateIntAttr("ProjID", oCmtItemValue.Value.ProjectID);
                    xCmt.CreateIntAttr("WresID", oCmtItemValue.Value.WResID);
                    xCmt.CreateIntAttr("BC_Role", oCmtItemValue.Value.BC_UID_Role);
                    xCmt.CreateIntAttr("BC_CC", oCmtItemValue.Value.BC_UID_CC);
                    xCmt.CreateIntAttr("RoleUID", oCmtItemValue.Value.RoleUID);
                    xCmt.CreateIntAttr("DeptUID", oCmtItemValue.Value.DeptUID);
                    xCmt.CreateIntAttr("Status", oCmtItemValue.Value.Status);
                    xCmt.CreateIntAttr("Dragable", oCmtItemValue.Value.Dragable);
                    xCmt.CreateDoubleAttr("Rate", oCmtItemValue.Value.Rate);
                    xCmt.CreateDoubleAttr("Cost", oCmtItemValue.Value.cost);
                    xCmt.CreateDateAttr("St", oCmtItemValue.Value.StartDate);
                    xCmt.CreateDateAttr("Fin", oCmtItemValue.Value.FinishDate);
                    xCmt.CreateStringAttr("RT", oCmtItemValue.Value.RateType);
                    xCmt.CreateStringAttr("MC", oCmtItemValue.Value.MajorCategory);
                    xCmt.CreateStringAttr("GP", oCmtItemValue.Value.Group);

                    if (oCmtItemValue.Value.CustomFields != null)
                    {
                        CStruct xCFs = xCmt.CreateSubStruct("CFs");
                        foreach (string sCField in oCmtItemValue.Value.CustomFields)
                        {
                            CStruct xCF = xCFs.CreateSubStruct("CF");
                            xCF.CreateStringAttr("Fld", sCField);
                        }
                    }
                }
            }

            if (CommitmentHours != null)
            {
                CStruct xCHs = xResourceValues.CreateSubStruct("CHs");
                foreach (clsCommitmentHours oCHItem in CommitmentHours)
                {
                    CStruct xCH = xCHs.CreateSubStruct("CH");
                    xCH.CreateIntAttr("UID", oCHItem.UID);
                    xCH.CreateIntAttr("PD", oCHItem.PeriodID);
                    xCH.CreateIntAttr("FTES", oCHItem.FTES);
                    xCH.CreateDoubleAttr("Hrs", oCHItem.Hours);
                }
            }

            if (OpenReqs != null)
            {
                CStruct xCmts = xResourceValues.CreateSubStruct("OReqts");
                foreach (KeyValuePair<int, clsCommitment> oCmtItemValue in OpenReqs)
                {
                    CStruct xCmt = xCmts.CreateSubStruct("OReqt");
                    xCmt.CreateIntAttr("UID", oCmtItemValue.Value.UID);
                    xCmt.CreateIntAttr("ID", oCmtItemValue.Value.ID);
                    xCmt.CreateIntAttr("ProjID", oCmtItemValue.Value.ProjectID);
                    xCmt.CreateIntAttr("WresID", oCmtItemValue.Value.WResID);
                    xCmt.CreateIntAttr("BC_Role", oCmtItemValue.Value.BC_UID_Role);
                    xCmt.CreateIntAttr("BC_CC", oCmtItemValue.Value.BC_UID_CC);
                    xCmt.CreateIntAttr("RoleUID", oCmtItemValue.Value.RoleUID);
                    xCmt.CreateIntAttr("DeptUID", oCmtItemValue.Value.DeptUID);
                    xCmt.CreateIntAttr("Status", oCmtItemValue.Value.Status);
                    xCmt.CreateDoubleAttr("Rate", oCmtItemValue.Value.Rate);
                    xCmt.CreateDoubleAttr("Cost", oCmtItemValue.Value.cost);
                    xCmt.CreateDateAttr("St", oCmtItemValue.Value.StartDate);
                    xCmt.CreateDateAttr("Fin", oCmtItemValue.Value.FinishDate);
                    xCmt.CreateStringAttr("RT", oCmtItemValue.Value.RateType);
                    xCmt.CreateStringAttr("MC", oCmtItemValue.Value.MajorCategory);
                    xCmt.CreateStringAttr("GP", oCmtItemValue.Value.Group);

                    if (oCmtItemValue.Value.CustomFields != null)
                    {
                        CStruct xCFs = xCmt.CreateSubStruct("CFs");
                        foreach (string sCField in oCmtItemValue.Value.CustomFields)
                        {
                            CStruct xCF = xCFs.CreateSubStruct("CF");
                            xCF.CreateStringAttr("Fld", sCField);
                        }
                    }
                }
            }

            if (OpenReqHours != null)
            {
                CStruct xCHs = xResourceValues.CreateSubStruct("ORs");
                foreach (clsCommitmentHours oCHItem in OpenReqHours)
                {
                    CStruct xCH = xCHs.CreateSubStruct("OR");
                    xCH.CreateIntAttr("UID", oCHItem.UID);
                    xCH.CreateIntAttr("PD", oCHItem.PeriodID);
                    xCH.CreateIntAttr("FTES", oCHItem.FTES);
                    xCH.CreateDoubleAttr("Hrs", oCHItem.Hours);
                }
            }


            if (SchedWorkHours != null)
            {
                CStruct xSWs = xResourceValues.CreateSubStruct("SWs");
                foreach (clsSchedWork oSWItem in SchedWorkHours)
                {
                    CStruct xSW = xSWs.CreateSubStruct("SW");
                    xSW.CreateIntAttr("ProjID", oSWItem.ProjectID);
                    xSW.CreateIntAttr("WresID", oSWItem.WResID);
                    xSW.CreateIntAttr("PD", oSWItem.PeriodID);
                    xSW.CreateStringAttr("MC", oSWItem.MajorCategory);
                    xSW.CreateIntAttr("FTES", oSWItem.FTES);
                    xSW.CreateDoubleAttr("Hrs", oSWItem.Hours);
                }
            }

            if (ActualWorkHours != null)
            {
                CStruct xSWs = xResourceValues.CreateSubStruct("ActWs");
                foreach (clsSchedWork oSWItem in ActualWorkHours)
                {
                    CStruct xSW = xSWs.CreateSubStruct("ActW");
                    xSW.CreateIntAttr("ProjID", oSWItem.ProjectID);
                    xSW.CreateIntAttr("WresID", oSWItem.WResID);
                    xSW.CreateIntAttr("PD", oSWItem.PeriodID);
                    xSW.CreateStringAttr("MC", oSWItem.MajorCategory);
                    xSW.CreateIntAttr("FTES", oSWItem.FTES);
                    xSW.CreateDoubleAttr("Hrs", oSWItem.Hours);
                }
            }

            if (NWItems != null)
            {
                CStruct xNWs = xResourceValues.CreateSubStruct("NWs");
                foreach (KeyValuePair<int, clsEPKItem> oNWItemValue in NWItems)
                {
                    CStruct xNW = xNWs.CreateSubStruct("NW");
                    xNW.CreateIntAttr("ID", oNWItemValue.Value.ID);
                    xNW.CreateStringAttr("Name", oNWItemValue.Value.Name);
                }
            }

            if (ResNWValues != null)
            {
                CStruct xNWHs = xResourceValues.CreateSubStruct("NWHs");
                foreach (clsNWValue oNWItem in ResNWValues)
                {
                    CStruct xNWH = xNWHs.CreateSubStruct("NWH");
                    xNWH.CreateIntAttr("UID", oNWItem.UID);
                    xNWH.CreateIntAttr("WresID", oNWItem.WResID);
                    xNWH.CreateIntAttr("PD", oNWItem.PeriodID);
                    xNWH.CreateIntAttr("FTES", oNWItem.FTES);
                    xNWH.CreateDoubleAttr("Hrs", oNWItem.Hours);
                }
            }

            if (ResAvail != null)
            {
                CStruct xRAVs = xResourceValues.CreateSubStruct("RAVs");
                foreach (clsResAvail oRAVItem in ResAvail)
                {
                    CStruct xRAV = xRAVs.CreateSubStruct("RAV");
                    xRAV.CreateIntAttr("WresID", oRAVItem.WResID);
                    xRAV.CreateIntAttr("PD", oRAVItem.PeriodID);
                    xRAV.CreateIntAttr("FTES", oRAVItem.FTES);
                    xRAV.CreateDoubleAttr("Hrs", oRAVItem.Hours);
                }
            }

            if (CapacityTargets != null)
            {
                CStruct xTgts = xResourceValues.CreateSubStruct("Tgts");
                foreach (KeyValuePair<int, clsEPKItem> oTgtItemValue in CapacityTargets)
                {
                    CStruct xTgt = xTgts.CreateSubStruct("Tgt");
                    xTgt.CreateIntAttr("UID", oTgtItemValue.Value.UID);
                    xTgt.CreateIntAttr("ID", oTgtItemValue.Value.ID);
                    xTgt.CreateStringAttr("Name", oTgtItemValue.Value.Name);
                }
            }

            if (CapacityTargetValues != null)
            {
                CStruct xTgtVs = xResourceValues.CreateSubStruct("TgtVs");
                foreach (clsCapacityValue oTgtVItem in CapacityTargetValues)
                {
                    CStruct xTgtV = xTgtVs.CreateSubStruct("TgtV");
                    xTgtV.CreateIntAttr("ID", oTgtVItem.ID);
                    xTgtV.CreateIntAttr("PD", oTgtVItem.PeriodID);
                    xTgtV.CreateIntAttr("DeptUID", oTgtVItem.DeptUID);
                    xTgtV.CreateIntAttr("RoleUID", oTgtVItem.RoleUID);
                    xTgtV.CreateIntAttr("FTES", oTgtVItem.FTES);
                    xTgtV.CreateDoubleAttr("Hrs", oTgtVItem.Hours);
                }
            }

            if (TargetColors != null)
            {
                CStruct xTgtCs = xResourceValues.CreateSubStruct("TgtCs");
                foreach (KeyValuePair<int, clsViewTargetColours> oTgtCItemValue in TargetColors)
                {
                    CStruct xTgtC = xTgtCs.CreateSubStruct("TgtC");
                    xTgtC.CreateIntAttr("ID", oTgtCItemValue.Value.ID);
                    xTgtC.CreateDoubleAttr("LV", oTgtCItemValue.Value.low_val);
                    xTgtC.CreateDoubleAttr("HV", oTgtCItemValue.Value.high_val);
                    xTgtC.CreateIntAttr("RGB", oTgtCItemValue.Value.rgb_val);
                    xTgtC.CreateStringAttr("Desc", oTgtCItemValue.Value.Desc);
                }
            }

            if (PlanFields != null)
            {
                CStruct xRPFlds = xResourceValues.CreateSubStruct("RPFlds");
                foreach (clsPortField oRPFldItem in PlanFields)
                {
                    CStruct xRPFld = xRPFlds.CreateSubStruct("RPFld");
                    xRPFld.CreateIntAttr("ID", oRPFldItem.ID);
                    xRPFld.CreateIntAttr("Type", oRPFldItem.Fieldtype);
                    xRPFld.CreateStringAttr("Name", oRPFldItem.Name);
                    xRPFld.CreateStringAttr("GivenName", oRPFldItem.GivenName);
                }
            }

            if (PIFields != null)
            {
                CStruct xPIFlds = xResourceValues.CreateSubStruct("PIFlds");
                foreach (clsPortField oPIFldItem in PIFields)
                {
                    CStruct xPIFld = xPIFlds.CreateSubStruct("PIFld");
                    xPIFld.CreateIntAttr("ID", oPIFldItem.ID);
                    xPIFld.CreateIntAttr("Type", oPIFldItem.Fieldtype);
                    xPIFld.CreateStringAttr("Name", oPIFldItem.Name);
                    xPIFld.CreateStringAttr("GivenName", oPIFldItem.GivenName);
                }
            }


            if (ResFields != null)
            {
                CStruct xResFlds = xResourceValues.CreateSubStruct("ResFlds");
                foreach (clsPortField oResFldItem in ResFields)
                {
                    CStruct xResFld = xResFlds.CreateSubStruct("ResFld");
                    xResFld.CreateIntAttr("ID", oResFldItem.ID);
                    xResFld.CreateIntAttr("Type", oResFldItem.Fieldtype);
                    xResFld.CreateStringAttr("Name", oResFldItem.Name);
                    xResFld.CreateStringAttr("GivenName", oResFldItem.GivenName);
                }
            }

            if (Lookups != null)
            {
                CStruct xLookups = xResourceValues.CreateSubStruct("Lookups");
                foreach (KeyValuePair<int, clsLookupList> oLookupItemValue in Lookups)
                {
                    CStruct xLookup = xLookups.CreateSubStruct("Lookup");
                    xLookup.CreateIntAttr("ID", oLookupItemValue.Value.FieldID);
                    //xLookup.CreateIntAttr("LeafOnly", oLookupItemValue.Value.LeafOnly);
                    //xLookup.CreateIntAttr("Lookup", oLookupItemValue.Value.Lookup);
                    //xLookup.CreateStringAttr("Name", oLookupItemValue.Value.Name);
                    //xLookup.CreateStringAttr("Desc", oLookupItemValue.Value.Desc);

                    if (oLookupItemValue.Value.ListItems != null)
                    {
                        CStruct xLIs = xLookup.CreateSubStruct("LIs");
                        foreach (KeyValuePair<int, clsListItem> oListItemValue in oLookupItemValue.Value.ListItems)
                        {
                            CStruct xLI = xLIs.CreateSubStruct("LI");
                            xLI.CreateIntAttr("UID", oListItemValue.Value.UID);
                            xLI.CreateIntAttr("ID", oListItemValue.Value.ID);
                            xLI.CreateIntAttr("Level", oListItemValue.Value.Level);
                            xLI.CreateBooleanAttr("Inactive", oListItemValue.Value.Inactive);
                            xLI.CreateStringAttr("Name", oListItemValue.Value.Name);
                            //  need to set Full names on decode
                        }
                    }
                }
            }


            if (FTEConvData != null)
            {
                CStruct xFTEConvs = xResourceValues.CreateSubStruct("FTEConvs");
                foreach (clsFTEConv ofte in FTEConvData)
                {
                    CStruct xFTEConv = xFTEConvs.CreateSubStruct("FTEConv");
                    xFTEConv.CreateIntAttr("CAT_ID", ofte.Cat_UID);
                    xFTEConv.CreateIntAttr("Period_ID", ofte.PeriodID);
                    xFTEConv.CreateIntAttr("FTE", ofte.FTEConv);
                    
                }
            }



            return xResourceValues.XML();
        }

        public bool LoadFromXML(string sXML)
        {
            CStruct xXMLDatas = new CStruct();
            xXMLDatas.LoadXML(sXML);

            CStruct xOptions = xXMLDatas.GetSubStruct("Options");
            CalendarID = xOptions.GetInt("CalendarID");
            PlanningCalendarID = xOptions.GetInt("PlanningCalendarID");
            FromPeriodID = xOptions.GetInt("FromPeriodID");
            ToPeriodID = xOptions.GetInt("ToPeriodID");
            gpPMOAdmin = xOptions.GetInt("gpPMOAdmin");

            CommitmentsOpMode = xOptions.GetInt("CommitmentsOpMode");
            lRequestNo = xOptions.GetInt("RequestNo");
            RoleFieldID = xOptions.GetInt("RoleFieldID");
            MajorCategoryFieldID = xOptions.GetInt("MajorCategoryFieldID");
            CalendarName = xOptions.GetString("CalendarName");

            List<CStruct> listentries;
            CStruct xList;

            xList = xXMLDatas.GetSubStruct("CostCategories");
            if (xList != null)
            {
                int lCatMaxLevel = 0;
                listentries = xList.GetList("Cat");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (CostCategories == null) CostCategories = new Dictionary<int, clsCatItem>();
                        clsCatItem oCatItem = new clsCatItem();
                        oCatItem.UID = xListEntry.GetIntAttr("UID");
                        oCatItem.MajorCategory = xListEntry.GetIntAttr("MC");
                        oCatItem.Category = xListEntry.GetIntAttr("CC");
                        oCatItem.ID = xListEntry.GetIntAttr("ID");
                        oCatItem.Level = xListEntry.GetIntAttr("LVL");
                        oCatItem.Role_UID = xListEntry.GetIntAttr("Role");
                        oCatItem.PID = xListEntry.GetIntAttr("PID");
                        oCatItem.Name = xListEntry.GetStringAttr("Name");
                        oCatItem.FullName = xListEntry.GetStringAttr("FName");
                        CostCategories.Add(oCatItem.UID, oCatItem);
                        if (oCatItem.Level > lCatMaxLevel) lCatMaxLevel = oCatItem.Level;
                    }
                }
                SetFullNames(CostCategories, lCatMaxLevel);
            }

            xList = xXMLDatas.GetSubStruct("Rates");
            if (xList != null)
            {
                listentries = xList.GetList("Rate");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (Rates == null) Rates = new Dictionary<int, clsCatItem>();
                        clsCatItem oRatItem = new clsCatItem();
                        oRatItem.UID = xListEntry.GetIntAttr("UID");
                        oRatItem.ID = xListEntry.GetIntAttr("ID");
                        oRatItem.Level = xListEntry.GetIntAttr("LVL");
                        oRatItem.PID = xListEntry.GetIntAttr("PID");
                        oRatItem.Name = xListEntry.GetStringAttr("Name");
                        oRatItem.FullName = xListEntry.GetStringAttr("FName");
                        Rates.Add(oRatItem.UID, oRatItem);
                        if (oRatItem.Level > lRatMaxLevel) lRatMaxLevel = oRatItem.Level;
                    }
                    SetFullNames(Rates, lRatMaxLevel);
                }
            }

            xList = xXMLDatas.GetSubStruct("Periods");
            if (xList != null)
            {
                listentries = xList.GetList("PD");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (Periods == null) Periods = new Dictionary<int, CPeriod>();
                        CPeriod oPeriod = new CPeriod();
                        oPeriod.PeriodID = xListEntry.GetIntAttr("ID");
                        oPeriod.StartDate = xListEntry.GetDateAttr("St");
                        oPeriod.FinishDate = xListEntry.GetDateAttr("End");
                        oPeriod.PeriodName = xListEntry.GetStringAttr("Name");
                        Periods.Add(oPeriod.PeriodID, oPeriod);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("Depts");
            if (xList != null)
            {
                listentries = xList.GetList("Dept");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (Departments == null) Departments = new Dictionary<int, clsEPKItem>();
                        clsEPKItem oDeptItem = new clsEPKItem();
                        oDeptItem.ID = xListEntry.GetIntAttr("ID");
                        oDeptItem.Name = xListEntry.GetStringAttr("Name");
                        oDeptItem.Desc = xListEntry.GetStringAttr("Desc");
                        Departments.Add(oDeptItem.ID, oDeptItem);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("PIs");
            if (xList != null)
            {
                listentries = xList.GetList("PI");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (PIs == null) PIs = new Dictionary<int, clsPIData>();
                        clsPIData oPIData = new clsPIData();
                        oPIData.ProjectID = xListEntry.GetIntAttr("ProjID");
                        oPIData.WprojID = xListEntry.GetIntAttr("WProjID");
                        oPIData.PIName = xListEntry.GetStringAttr("Name");
                        oPIData.LinkedProject = xListEntry.GetStringAttr("LP");
                        oPIData.ItemManager = xListEntry.GetStringAttr("IM");
                        oPIData.StageOwner = xListEntry.GetStringAttr("SO");
                        oPIData.Stage = xListEntry.GetStringAttr("Stage");
                        oPIData.WSSSite = xListEntry.GetStringAttr("WSS");
                        oPIData.ItemManagerWresID = xListEntry.GetIntAttr("IMID");
                        oPIData.Priority = xListEntry.GetIntAttr("Pri");
                        oPIData.start = xListEntry.GetDateAttr("St");
                        oPIData.finish = xListEntry.GetDateAttr("Fin");

                        oPIData.CustomFields = new List<string>();
                        CStruct xCFs = xListEntry.GetSubStruct("CFs");
                        if (xCFs != null)
                        {
                            List<CStruct> listCFs = xCFs.GetList("CF");
                            if (listCFs != null)
                            {
                                foreach (CStruct xCFEntry in listCFs)
                                {
                                    string sCF = xCFEntry.GetStringAttr("Fld");
                                    oPIData.CustomFields.Add(sCF);
                                }
                            }
                        }
                        PIs.Add(oPIData.ProjectID, oPIData);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("Resources");
            if (xList != null)
            {
                listentries = xList.GetList("Res");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (Resources == null) Resources = new Dictionary<int, clsResCap>();
                        clsResCap oResource = new clsResCap();
                        oResource.ID = xListEntry.GetIntAttr("ID");
                        oResource.Name = xListEntry.GetStringAttr("Name");
                        oResource.DeptUID = xListEntry.GetIntAttr("DeptUID");
                        oResource.RoleUID = xListEntry.GetIntAttr("RoleUID");
                        oResource.RT_UID = xListEntry.GetIntAttr("RTUID");
                        oResource.BC_UID_Role = xListEntry.GetIntAttr("BC_Role");
                        oResource.BC_UID_CC = xListEntry.GetIntAttr("BC_CC");

                        oResource.CustomFields = new List<string>();
                        CStruct xCFs = xListEntry.GetSubStruct("CFs");
                        if (xCFs != null)
                        {
                            List<CStruct> listCFs = xCFs.GetList("CF");
                            if (listCFs != null)
                            {
                                foreach (CStruct xCFEntry in listCFs)
                                {
                                    string sCF = xCFEntry.GetStringAttr("Fld");
                                    oResource.CustomFields.Add(sCF);
                                }
                            }
                        }
                        Resources.Add(oResource.ID, oResource);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("Roles");
            if (xList != null)
            {
                listentries = xList.GetList("Role");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (Roles == null) Roles = new Dictionary<int, clsListItem>();
                        clsListItem oRole = new clsListItem();
                        oRole.ID = xListEntry.GetIntAttr("ID");
                        oRole.Name = xListEntry.GetStringAttr("Name");
                        Roles.Add(oRole.ID, oRole);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("Cmts");
            if (xList != null)
            {
                listentries = xList.GetList("Cmt");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (Commitments == null) Commitments = new Dictionary<int, clsCommitment>();
                        clsCommitment oCommitment = new clsCommitment();
                        oCommitment.UID = xListEntry.GetIntAttr("UID");
                        oCommitment.ID = xListEntry.GetIntAttr("ID");
                        oCommitment.ProjectID = xListEntry.GetIntAttr("ProjID");
                        oCommitment.WResID = xListEntry.GetIntAttr("WresID");
                        oCommitment.BC_UID_Role = xListEntry.GetIntAttr("BC_Role");
                        oCommitment.BC_UID_CC = xListEntry.GetIntAttr("BC_CC");
                        oCommitment.RoleUID = xListEntry.GetIntAttr("RoleUID");
                        oCommitment.DeptUID = xListEntry.GetIntAttr("DeptUID");
                        oCommitment.Status = xListEntry.GetIntAttr("Status");
                        oCommitment.Dragable = xListEntry.GetIntAttr("Dragable");
                        oCommitment.Rate = xListEntry.GetDoubleAttr("Rate", 0);
                        oCommitment.cost = xListEntry.GetDoubleAttr("Cost", 0);
                        oCommitment.StartDate = xListEntry.GetDateAttr("St");
                        oCommitment.FinishDate = xListEntry.GetDateAttr("Fin");
                        oCommitment.RateType = xListEntry.GetStringAttr("RT");
                        oCommitment.MajorCategory = xListEntry.GetStringAttr("MC");
                        oCommitment.Group = xListEntry.GetStringAttr("GP");

                        oCommitment.CustomFields = new List<string>();
                        CStruct xCFs = xListEntry.GetSubStruct("CFs");
                        if (xCFs != null)
                        {
                            List<CStruct> listCFs = xCFs.GetList("CF");
                            if (listCFs != null)
                            {
                                foreach (CStruct xCFEntry in listCFs)
                                {
                                    string sCF = xCFEntry.GetStringAttr("Fld");
                                    oCommitment.CustomFields.Add(sCF);
                                }
                            }
                        }
                        Commitments.Add(oCommitment.UID, oCommitment);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("CHs");
            if (xList != null)
            {
                listentries = xList.GetList("CH");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (CommitmentHours == null) CommitmentHours = new List<clsCommitmentHours>();
                        clsCommitmentHours oCommitmentHours = new clsCommitmentHours();
                        oCommitmentHours.UID = xListEntry.GetIntAttr("UID");
                        oCommitmentHours.PeriodID = xListEntry.GetIntAttr("PD");
                        oCommitmentHours.FTES = xListEntry.GetIntAttr("FTES");
                        oCommitmentHours.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        CommitmentHours.Add(oCommitmentHours);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("OReqts");
            if (xList != null)
            {
                listentries = xList.GetList("OReqt");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (OpenReqs == null) OpenReqs = new Dictionary<int, clsCommitment>();
                        clsCommitment oCommitment = new clsCommitment();
                        oCommitment.UID = xListEntry.GetIntAttr("UID");
                        oCommitment.ID = xListEntry.GetIntAttr("ID");
                        oCommitment.ProjectID = xListEntry.GetIntAttr("ProjID");
                        oCommitment.WResID = xListEntry.GetIntAttr("WresID");
                        oCommitment.BC_UID_Role = xListEntry.GetIntAttr("BC_Role");
                        oCommitment.BC_UID_CC = xListEntry.GetIntAttr("BC_CC");
                        oCommitment.RoleUID = xListEntry.GetIntAttr("RoleUID");
                        oCommitment.DeptUID = xListEntry.GetIntAttr("DeptUID");
                        oCommitment.Status = xListEntry.GetIntAttr("Status");
                        oCommitment.Rate = xListEntry.GetDoubleAttr("Rate", 0);
                        oCommitment.cost = xListEntry.GetDoubleAttr("Cost", 0);
                        oCommitment.StartDate = xListEntry.GetDateAttr("St");
                        oCommitment.FinishDate = xListEntry.GetDateAttr("Fin");
                        oCommitment.RateType = xListEntry.GetStringAttr("RT");
                        oCommitment.MajorCategory = xListEntry.GetStringAttr("MC");
                        oCommitment.Group = xListEntry.GetStringAttr("GP");

                        oCommitment.CustomFields = new List<string>();
                        CStruct xCFs = xListEntry.GetSubStruct("CFs");
                        if (xCFs != null)
                        {
                            List<CStruct> listCFs = xCFs.GetList("CF");
                            if (listCFs != null)
                            {
                                foreach (CStruct xCFEntry in listCFs)
                                {
                                    string sCF = xCFEntry.GetStringAttr("Fld");
                                    oCommitment.CustomFields.Add(sCF);
                                }
                            }
                        }
                        OpenReqs.Add(oCommitment.UID, oCommitment);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("ORs");
            if (xList != null)
            {
                listentries = xList.GetList("OR");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (OpenReqHours == null) OpenReqHours = new List<clsCommitmentHours>();
                        clsCommitmentHours oCommitmentHours = new clsCommitmentHours();
                        oCommitmentHours.UID = xListEntry.GetIntAttr("UID");
                        oCommitmentHours.PeriodID = xListEntry.GetIntAttr("PD");
                        oCommitmentHours.FTES = xListEntry.GetIntAttr("FTES");
                        oCommitmentHours.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        OpenReqHours.Add(oCommitmentHours);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("SWs");
            if (xList != null)
            {
                listentries = xList.GetList("SW");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (SchedWorkHours == null) SchedWorkHours = new List<clsSchedWork>();
                        clsSchedWork oSchedWork = new clsSchedWork();
                        oSchedWork.ProjectID = xListEntry.GetIntAttr("ProjID");
                        oSchedWork.WResID = xListEntry.GetIntAttr("WresID");
                        oSchedWork.PeriodID = xListEntry.GetIntAttr("PD");
                        oSchedWork.FTES = xListEntry.GetIntAttr("FTES");
                        oSchedWork.MajorCategory = xListEntry.GetStringAttr("MC");
                        oSchedWork.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        SchedWorkHours.Add(oSchedWork);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("ActWs");
            if (xList != null)
            {
                listentries = xList.GetList("ActW");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (ActualWorkHours == null) ActualWorkHours = new List<clsSchedWork>();
                        clsSchedWork oSchedWork = new clsSchedWork();
                        oSchedWork.ProjectID = xListEntry.GetIntAttr("ProjID");
                        oSchedWork.WResID = xListEntry.GetIntAttr("WresID");
                        oSchedWork.PeriodID = xListEntry.GetIntAttr("PD");
                        oSchedWork.FTES = xListEntry.GetIntAttr("FTES");
                        oSchedWork.MajorCategory = xListEntry.GetStringAttr("MC");
                        oSchedWork.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        ActualWorkHours.Add(oSchedWork);
                    }
                }
            }


            xList = xXMLDatas.GetSubStruct("NWs");
            if (xList != null)
            {
                listentries = xList.GetList("NW");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (NWItems == null) NWItems = new Dictionary<int, clsEPKItem>();
                        clsEPKItem oNWItem = new clsEPKItem();
                        oNWItem.ID = xListEntry.GetIntAttr("ID");
                        oNWItem.Name = xListEntry.GetStringAttr("Name");
                        NWItems.Add(oNWItem.ID, oNWItem);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("NWHs");
            if (xList != null)
            {
                listentries = xList.GetList("NWH");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (ResNWValues == null) ResNWValues = new List<clsNWValue>();
                        clsNWValue oNWValue = new clsNWValue();
                        oNWValue.UID = xListEntry.GetIntAttr("UID");
                        oNWValue.WResID = xListEntry.GetIntAttr("WresID");
                        oNWValue.PeriodID = xListEntry.GetIntAttr("PD");
                        oNWValue.FTES = xListEntry.GetIntAttr("FTES");
                        oNWValue.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        ResNWValues.Add(oNWValue);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("RAVs");
            if (xList != null)
            {
                listentries = xList.GetList("RAV");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (ResAvail == null) ResAvail = new List<clsResAvail>();
                        clsResAvail oResAvail = new clsResAvail();
                        oResAvail.WResID = xListEntry.GetIntAttr("WresID");
                        oResAvail.PeriodID = xListEntry.GetIntAttr("PD");
                        oResAvail.FTES = xListEntry.GetIntAttr("FTES");
                        oResAvail.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        ResAvail.Add(oResAvail);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("Tgts");
            if (xList != null)
            {
                listentries = xList.GetList("Tgt");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (CapacityTargets == null) CapacityTargets = new Dictionary<int, clsEPKItem>();
                        clsEPKItem oCapacityItem = new clsEPKItem();
                        oCapacityItem.UID = xListEntry.GetIntAttr("UID");
                        oCapacityItem.ID = xListEntry.GetIntAttr("ID");
                        oCapacityItem.Name = xListEntry.GetStringAttr("Name");
                        CapacityTargets.Add(oCapacityItem.ID, oCapacityItem);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("TgtVs");
            if (xList != null)
            {
                listentries = xList.GetList("TgtV");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (CapacityTargetValues == null) CapacityTargetValues = new List<clsCapacityValue>();
                        clsCapacityValue oCapacityValue = new clsCapacityValue();
                        oCapacityValue.ID = xListEntry.GetIntAttr("ID");
                        oCapacityValue.PeriodID = xListEntry.GetIntAttr("PD");
                        oCapacityValue.DeptUID = xListEntry.GetIntAttr("DeptUID");
                        oCapacityValue.RoleUID = xListEntry.GetIntAttr("RoleUID");
                        oCapacityValue.FTES = xListEntry.GetIntAttr("FTES");
                        oCapacityValue.Hours = xListEntry.GetDoubleAttr("Hrs", 0);
                        CapacityTargetValues.Add(oCapacityValue);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("TgtCs");
            if (xList != null)
            {
                listentries = xList.GetList("TgtC");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (TargetColors == null) TargetColors = new Dictionary<int, clsViewTargetColours>();
                        clsViewTargetColours oTargetColor = new clsViewTargetColours();
                        oTargetColor.ID = xListEntry.GetIntAttr("ID");
                        oTargetColor.low_val = xListEntry.GetDoubleAttr("LV", 0);
                        oTargetColor.high_val = xListEntry.GetDoubleAttr("HV", 0);
                        oTargetColor.rgb_val = xListEntry.GetIntAttr("RGB");
                        oTargetColor.Desc = xListEntry.GetStringAttr("Desc");
                        TargetColors.Add(oTargetColor.ID, oTargetColor);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("RPFlds");
            if (xList != null)
            {
                listentries = xList.GetList("RPFld");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (PlanFields == null) PlanFields = new List<clsPortField>();
                        clsPortField oFieldItem = new clsPortField();
                        oFieldItem.ID = xListEntry.GetIntAttr("ID");
                        oFieldItem.Fieldtype = xListEntry.GetIntAttr("Type");
                        oFieldItem.Name = xListEntry.GetStringAttr("Name");
                        oFieldItem.GivenName = xListEntry.GetStringAttr("GivenName");
                        PlanFields.Add(oFieldItem);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("PIFlds");
            if (xList != null)
            {
                listentries = xList.GetList("PIFld");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (PIFields == null) PIFields = new List<clsPortField>();
                        clsPortField oFieldItem = new clsPortField();
                        oFieldItem.ID = xListEntry.GetIntAttr("ID");
                        oFieldItem.Fieldtype = xListEntry.GetIntAttr("Type");
                        oFieldItem.Name = xListEntry.GetStringAttr("Name");
                        oFieldItem.GivenName = xListEntry.GetStringAttr("GivenName");
                        PIFields.Add(oFieldItem);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("ResFlds");
            if (xList != null)
            {
                listentries = xList.GetList("ResFld");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        if (ResFields == null) ResFields = new List<clsPortField>();
                        clsPortField oFieldItem = new clsPortField();
                        oFieldItem.ID = xListEntry.GetIntAttr("ID");
                        oFieldItem.Fieldtype = xListEntry.GetIntAttr("Type");
                        oFieldItem.Name = xListEntry.GetStringAttr("Name");
                        oFieldItem.GivenName = xListEntry.GetStringAttr("GivenName");
                        ResFields.Add(oFieldItem);
                    }
                }
            }

            xList = xXMLDatas.GetSubStruct("Lookups");
            if (xList != null)
            {
                listentries = xList.GetList("Lookup");
                if (listentries != null)
                {
                    foreach (CStruct xLookupEntry in listentries)
                    {
                        if (Lookups == null) Lookups = new Dictionary<int, clsLookupList>();
                        clsLookupList oLookup = new clsLookupList();
                        int lMaxLevel = 0;
                        oLookup.FieldID = xLookupEntry.GetIntAttr("ID");
                        //oLookup.LeafOnly = xLookupEntry.GetIntAttr("LeafOnly");
                        //oLookup.Lookup = xLookupEntry.GetIntAttr("Lookup");
                        //oLookup.Name = xLookupEntry.GetStringAttr("Name");
                        //oLookup.Desc = xLookupEntry.GetStringAttr("Desc");

                        oLookup.ListItems = new Dictionary<int, clsListItem>();
                        CStruct xLIs = xLookupEntry.GetSubStruct("LIs");
                        if (xLIs != null)
                        {
                            List<CStruct> listLIs = xLIs.GetList("LI");
                            if (listLIs != null)
                            {
                                foreach (CStruct xLIEntry in listLIs)
                                {
                                    clsListItem oListItem = new clsListItem();
                                    oListItem.UID = xLIEntry.GetIntAttr("UID");
                                    oListItem.ID = xLIEntry.GetIntAttr("ID");
                                    oListItem.Level = xLIEntry.GetIntAttr("Level");
                                    oListItem.Inactive = xLIEntry.GetBooleanAttr("Inactive");
                                    oListItem.Name = xLIEntry.GetStringAttr("Name");
                                    oLookup.ListItems.Add(oListItem.UID, oListItem);
                                    if (oListItem.Level > lMaxLevel) lMaxLevel = oListItem.Level;
                                }
                            }
                        }
                        Lookups.Add(oLookup.FieldID, oLookup);
                        SetFullNames(oLookup.ListItems, lMaxLevel);
                    }
                }
            }

            FTEConvData = new List<clsFTEConv>();

            xList = xXMLDatas.GetSubStruct("FTEConvs");
            if (xList != null)
            {
                listentries = xList.GetList("FTEConv");
                if (listentries != null)
                {
                    foreach (CStruct xListEntry in listentries)
                    {
                        clsFTEConv oFTEConc = new clsFTEConv();
                        oFTEConc.Cat_UID = xListEntry.GetIntAttr("CAT_ID");
                        oFTEConc.PeriodID = xListEntry.GetIntAttr("Period_ID");
                        oFTEConc.FTEConv = xListEntry.GetIntAttr("FTE");
                        FTEConvData.Add(oFTEConc);
                    }
                }
            }

            return true;
        }

        internal void SetFullNames(Dictionary<int, clsListItem> ListItems, int lMaxLevel)
        {
            string[] ParentNodes;
            string s = "";
            int i = 0;

            if (ListItems.Count > 0 && lMaxLevel > 0)
            {
                ParentNodes = new string[lMaxLevel + 2];
                foreach (clsListItem oListItem in ListItems.Values)
                {
                    s = "";
                    for (i = 1; i <= (oListItem.Level - 1); i++)
                    {
                        if (s.Length < 1) s = ParentNodes[i]; else s += "." + ParentNodes[i];
                    }
                    if (s.Length < 1) oListItem.FullName = oListItem.Name; else oListItem.FullName = s + "." + oListItem.Name;

                    if (oListItem.FullName.Length > 250) oListItem.FullName = oListItem.FullName.Substring(0, 250) + "....";
                    ParentNodes[oListItem.Level] = oListItem.Name;
                }
            }
            return;
        }

        internal void SetFullNames(Dictionary<int, clsCatItem> ListItems, int lMaxLevel)
        {
            string[] ParentNodes;
            string s = "";
            int i = 0;

            if (ListItems.Count > 0 && lMaxLevel > 0)
            {
                ParentNodes = new string[lMaxLevel + 2];
                foreach (clsCatItem oListItem in ListItems.Values)
                {
                    s = "";
                    for (i = 1; i <= (oListItem.Level - 1); i++)
                    {
                        if (s.Length < 1) s = ParentNodes[i]; else s += "." + ParentNodes[i];
                    }
                    if (s.Length < 1) oListItem.FullName = oListItem.Name; else oListItem.FullName = s + "." + oListItem.Name;

                    if (oListItem.FullName.Length > 250) oListItem.FullName = oListItem.FullName.Substring(0, 250) + "....";
                    ParentNodes[oListItem.Level] = oListItem.Name;
                }
            }
            return;
        }
    }
}
