using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;

namespace EPMLiveCore.API
{
    internal class ListCommands
    {
        public static bool EnableTeamFeatures(SPList list)
        {
            bool success = true;
            success = TryAddField(list, "AssignedTo", SPFieldType.User, "Assigned To", false);
            return success;
        }

        public static void EnableTimesheets(SPList list, SPWeb web)
        {
            TryAddField(list, "Timesheet", SPFieldType.Boolean, "Timesheet", false);
            TryAddField(list, "TimesheetHours", SPFieldType.Number, "Timesheet Hours", false);

            SPField field = list.Fields.GetFieldByInternalName("TimesheetHours");
            field.ShowInEditForm = false;
            field.ShowInNewForm = false;
            field.Hidden = false;
            field.Update();

            field = list.Fields.GetFieldByInternalName("Timesheet");
            field.Hidden = false;
            field.Update();

            try
            {
                SPWeb rootWeb = web.Site.RootWeb;

                ArrayList lists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "EPMLiveTSLists").Replace("\r\n", "\n").Split('\n')); ;

                if(!lists.Contains(list.Title))
                {
                    lists.Add(list.Title);

                    EPMLiveCore.CoreFunctions.setConfigSetting(rootWeb, "EPMLiveTSLists", String.Join("\n", (string[])lists.ToArray(typeof(string))).Replace("\n", "\r\n"));
                }
            }
            catch { }
        }

        public static void DisableTimesheets(SPList list, SPWeb web)
        {
            TryHideField(list, "Timesheet");
            TryHideField(list, "TimesheetHours");

            try
            {
                SPWeb rootWeb = web.Site.RootWeb;

                ArrayList lists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "EPMLiveTSLists").Replace("\r\n", "\n").Split('\n')); ;

                if(lists.Contains(list.Title))
                {
                    lists.Remove(list.Title);

                    EPMLiveCore.CoreFunctions.setConfigSetting(rootWeb, "EPMLiveTSLists", String.Join("\n", (string[])lists.ToArray(typeof(string))).Replace("\n", "\r\n"));
                }
            }
            catch { }
        }

        private static bool TryDeleteField(SPList list, string InternalName)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(InternalName);
            }
            catch { }

            if(field != null)
            {
                try
                {
                    if(field.Sealed)
                    {
                        field.Sealed = false;
                        field.Update();
                    }
                    field.Delete();
                    list.Update();
                    return true;
                }
                catch { return false; }
            }
            else
                return true;
        }

        private static bool TryHideField(SPList list, string InternalName)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(InternalName);
            }
            catch { }

            if(field != null)
            {
                try
                {
                    if(field.Sealed)
                    {
                        field.Sealed = false;
                        field.Update();
                    }
                    field.Hidden = true;
                    field.Update();
                    list.Update();
                    return true;
                }
                catch { return false; }
            }
            else
                return true;
        }

        private static bool TryAddField(SPList list, string InternalName, SPFieldType type, string Title, bool Hidden)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(InternalName);
            }
            catch { }

            if(field == null)
            {
                try
                {
                    string sField = list.Fields.Add(InternalName, type, false);
                    field = list.Fields.GetFieldByInternalName(InternalName);
                    field.Title = Title;
                    field.Hidden = Hidden;
                    field.Update();
                    return true;
                }
                catch { return false; }
            }
            else
                return true;
        }
    }
}
