using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioEngineCore
{

    internal class Common
    {
        public const int const_HoursMultiplier = 100;

        internal enum CustomFieldTable
        {
            ResourceINT = 101,
            ResourceTEXT = 102,
            ResourceDEC = 103,
            ResourceNTEXT = 104,
            ResourceDATE = 105,
            ResourceMV = 151,
            PortfolioINT = 201,
            PortfolioTEXT = 202,
            PortfolioDEC = 203,
            PortfolioNTEXT = 204,
            PortfolioDATE = 205,
            Program = 251,
            ProjectINT = 301,
            ProjectTEXT = 302,
            ProjectDEC = 303,
            ProjectNTEXT = 304,
            ProjectDATE = 305,
            ProgramText = 402,
            TaskWIINT = 801,
            TaskWITEXT = 802,
            TaskWIDEC = 803
       }


        public static bool IsGUIDInList(string sList, string sGUID)
        {
            string sSearch = "," + sList + ",";
            return (sSearch.Contains("," + sGUID + ","));
        }

        public static bool AddGUIDToList(ref string sList, string sGUID)
        {
            bool bAdded = false;
            if (sGUID != "")
            {
                if (!IsGUIDInList(sList, sGUID))
                {
                    if (sList == "")
                        sList = sGUID;
                    else
                        sList += "," + sGUID;
                    bAdded = true;
                }
            }
            return bAdded;
        }

        public static bool IsIDInList(string sList, int lID)
        {
            string sSearch = "," + sList + ",";
            return (sSearch.Contains("," + lID.ToString() + ","));
        }

        public static bool AddIDToList(ref string sList, int lID)
        {
            bool bAdded = false;
            if (lID > 0)
            {
                if (!IsIDInList(sList, lID))
                {
                    if (sList == "")
                        sList = lID.ToString();
                    else
                        sList += "," + lID.ToString();
                    bAdded = true;
                }
            }
            return bAdded;
        }

        public static string AppendItemToList(string sList, string sItem)
        {
            if (sList == "")
                return sItem;
            else
                return sList + "," + sItem;
        }

        public static string AppendDoubleToList(string sList, double dbl)
        {
            if (dbl == double.MinValue)
                return AppendItemToList(sList, "n");
            else
                return AppendItemToList(sList, dbl.ToString());
        }

        public static string GetFirstItemFromList(ref string sList)
        {
            string s = "";
            string[] sSeps = { "," };
            string[] sArr = sList.Split(sSeps, 2, StringSplitOptions.None);
            if (sArr.GetLength(0) > 1)
            {
                s = sArr[0];
                sList = sArr[1];
            }
            else
            {
                s = sList;
                sList = "";
            }
            return s;
        }

        public static int GetFirstIDFromList(ref string sList)
        {
            string s = GetFirstItemFromList(ref sList);
            int result;
            if (Int32.TryParse(s, out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// Calculates the name of the table field.
        /// </summary>
        /// <param name="fieldId">The field id.</param>
        /// <param name="tableId">The table id.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="fieldName">Name of the field.</param>
        internal static void CalculateTableFieldName(int fieldId, int tableId, out string tableName, out string fieldName)
        {
            tableName = null;
            fieldName = null;

            //var customFieldTable =
            //    (CustomFieldTable)Enum.Parse(typeof(CustomFieldTable), tableId.ToString(CultureInfo.InvariantCulture));

            Common.CustomFieldTable customFieldTable = (Common.CustomFieldTable)tableId;
            switch (customFieldTable)
            {
                case Common.CustomFieldTable.ResourceINT:
                    tableName = "EPGC_RESOURCE_INT_VALUES";
                    fieldName = string.Format("RI_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ResourceTEXT:
                    tableName = "EPGC_RESOURCE_TEXT_VALUES";
                    fieldName = string.Format("RT_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ResourceDEC:
                    tableName = "EPGC_RESOURCE_DEC_VALUES";
                    fieldName = string.Format("RC_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ResourceNTEXT:
                    tableName = "EPGC_RESOURCE_NTEXT_VALUES";
                    fieldName = string.Format("RN_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ResourceDATE:
                    tableName = "EPGC_RESOURCE_DATE_VALUES";
                    fieldName = string.Format("RD_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ResourceMV:
                    tableName = "EPGC_RESOURCE_MV_VALUES";
                    fieldName = "MVR_UID";
                    break;
                case Common.CustomFieldTable.PortfolioINT:
                    tableName = "EPGP_PROJECT_INT_VALUES";
                    fieldName = string.Format("PI_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.PortfolioTEXT:
                    tableName = "EPGP_PROJECT_TEXT_VALUES";
                    fieldName = string.Format("PT_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.PortfolioDEC:
                    tableName = "EPGP_PROJECT_DEC_VALUES";
                    fieldName = string.Format("PC_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.PortfolioNTEXT:
                    tableName = "EPGP_PROJECT_NTEXT_VALUES";
                    fieldName = string.Format("PN_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.PortfolioDATE:
                    tableName = "EPGP_PROJECT_DATE_VALUES";
                    fieldName = string.Format("PD_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.Program:
                    tableName = "EPGP_PI_PROGS";
                    fieldName = "PROG_UID";
                    break;
                case Common.CustomFieldTable.ProjectINT:
                    tableName = "EPGX_PROJ_INT_VALUES";
                    fieldName = string.Format("XI_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ProjectTEXT:
                    tableName = "EPGX_PROJ_TEXT_VALUES";
                    fieldName = string.Format("XT_{0:000}", fieldId);
                    break;
               case Common.CustomFieldTable.ProjectDEC:
                    tableName = "EPGX_PROJ_DEC_VALUES";
                    fieldName = string.Format("XC_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ProjectNTEXT:
                    tableName = "EPGX_PROJ_NTEXT_VALUES";
                    fieldName = string.Format("XN_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ProjectDATE:
                    tableName = "EPGX_PROJ_DATE_VALUES";
                    fieldName = string.Format("XD_{0:000}", fieldId);
                    break;
                case Common.CustomFieldTable.ProgramText:
                    tableName = "EPGP_PI_PROGS";
                    fieldName = string.Format("PROG_PI_TEXT{0:0}", fieldId);
                    break;
                case Common.CustomFieldTable.TaskWIINT:
                    tableName = "EPGP_PI_WORKITEMS";
                    fieldName = string.Format("WORKITEM_FLAG{0:0}", fieldId);
                    break;
                case Common.CustomFieldTable.TaskWITEXT:
                    tableName = "EPGP_PI_WORKITEMS";
                    fieldName = string.Format("WORKITEM_CTEXT{0:0}", fieldId);
                    break;
                case Common.CustomFieldTable.TaskWIDEC:
                    tableName = "EPGP_PI_WORKITEMS";
                    fieldName = string.Format("WORKITEM_NUMBER{0:0}", fieldId);
                    break;
                default:
                    tableName = "Unknown Table";
                    fieldName = "";
                    break;
            }
        }

    }

    internal class vb
    {
        public static object IIf(bool Expression, object TruePart, object FalsePart)
        {
            if (Expression)
                return TruePart;
            else
                return FalsePart;
        }

        public static int val(string sInteger)
        {
            if (string.IsNullOrEmpty(sInteger) == true)
                return 0;
            string sTrimmed = sInteger.Trim();
            string[] sSplit = System.Text.RegularExpressions.Regex.Split(sTrimmed, "[^\\d]");
            //string sVal = string.Join(null, sSplit);
            string sVal = sSplit[0];
            int result;
            Int32.TryParse(sVal, out result);

            return result;
        }

        public static int Max(int p0, int p1)
        {
            return (int)IIf(p0 > p1, p0, p1);
        }

        public static string Left(string s, int nLen)
        {
            if (s.Length > nLen)
                return s.Substring(0, nLen);
            else
                return s;
        }
    }

    internal class CPeriod
    {
        public int PeriodID;
        public string PeriodName;
        public DateTime StartDate;
        public DateTime FinishDate;
        public int Closed;
        public DateTime ClosedDate;
        public string ClosedName;

        //public int Action;   // 2 = close period; 3 = reopen period Action;

        //public int Locked;   // 0 = unlocked; 1 = locked Locked;
    }
}
