using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 31)]

    public class TimeOff : Step
    {
        public TimeOff(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Updating Time Off List"; }
        }

        public override bool Perform()
        {
            LogMessage("Processing Time Off Data");

            SPList oNonWork = SPWeb.Lists.TryGetList("Non Work");
            SPList oTimeOff = SPWeb.Lists.TryGetList("Time Off");

            if(oNonWork == null)
            {
                LogMessage("", "Non Work list missing", 3);
            }
            else if(oTimeOff == null)
            {
                LogMessage("", "Time Off list missing", 3);
            }
            else
            {

                SPField oTimeOffType = null;
                try
                {
                    oTimeOffType = oTimeOff.Fields.GetFieldByInternalName("TimeOffType");
                }
                catch (Exception ex)
                {
                    LogMessage("", ex.Message, 3);
                    return true;
                }

                if(oTimeOffType.Type == SPFieldType.Choice)
                {
                    if(oTimeOffType.Sealed)
                    {
                        oTimeOffType.Sealed = false;
                        oTimeOffType.Update();
                    }
                    oTimeOffType.AllowDeletion = true;
                    oTimeOffType.Update();
                    oTimeOffType.Delete();

                    oTimeOff.Fields.AddLookup("TimeOffType", oNonWork.ID, true);
                    SPFieldLookup oTimeOffTypeL = (SPFieldLookup)oTimeOff.Fields.GetFieldByInternalName("TimeOffType");
                    oTimeOffTypeL.LookupField = "Title";
                    oTimeOffTypeL.Sealed = true;
                    oTimeOffTypeL.Title = "Time Off Type";
                    oTimeOffTypeL.Update();

                    try
                    {
                        oTimeOffType = oTimeOff.Fields.GetFieldByInternalName("TimeOffType");
                    }
                    catch { }
                }

                if(oTimeOffType.Type == SPFieldType.Lookup)
                {

                    DataTable dt = oNonWork.Items.GetDataTable();

                    foreach(SPListItem li in oTimeOff.Items)
                    {
                        try
                        {
                            DataRow[] dr = dt.Select("Title='" + li["TempType"].ToString() + "'");

                            if(dr.Length > 0)
                            {

                                SPFieldLookupValue lv = new SPFieldLookupValue(int.Parse(dr[0]["ID"].ToString()), li["TempType"].ToString());

                                li[oTimeOffType.Id] = lv;
                                li.Update();

                                LogMessage("\tUpdate: " + li.Title);
                            }
                        }
                        catch(Exception ex)
                        {
                            LogMessage("\t", "Update: " + li.Title  + ": " + ex.Message, 3);
                        }
                    }
                }
                

            }

            return true;
        }
    }
}
