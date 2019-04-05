using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace PortfolioEngineCore
{
    public class dbaRates
    {
        public static StatusEnum SelectAdminRates(DBAccess dba, out DataTable dt)
        {
            string cmdText = "EPG_SP_ReadAdminRates";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }

        public static StatusEnum SelectResources(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT WRES_ID,RES_NAME FROM EPG_RESOURCES WHERE WRES_INACTIVE = 0 ORDER BY RES_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }

        public static StatusEnum UpdateRatesInfo(DBAccess dba, DataTable dtValues, out string sReply)
        {
            sReply = string.Empty;
            try
            {
                if (dba == null)
                {
                    throw new ArgumentNullException(nameof(dba));
                }
                if (dtValues == null)
                {
                    throw new ArgumentNullException(nameof(dtValues));
                }

                //  Replace Rate Table with new set

                // first establish RT_UID we'll use for any new entries
                int nextUId;
                const string commandText = "Select MAX(RT_UID) as Max_UID From EPG_RATES";
                using (var sqlCommand = new SqlCommand(commandText, dba.Connection))
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nextUId = SqlDb.ReadIntValue(reader["Max_UID"]) + 1;
                    }
                    else
                    {
                        nextUId = 1;
                    }
                }
                var startNextUid = nextUId;

                dba.BeginTransaction();

                ReadRatesTable(dba, dtValues, nextUId);

                if (!ReaddRatesValues(dba, dtValues, startNextUid, ref sReply))
                {
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                ReAddResourceRateAssignments(dba, dtValues, startNextUid);

                dba.CommitTransaction();
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
                sReply = SqlDb.FormatAdminError("exception", "Rates.UpdateRatesInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private static void ReadRatesTable(DBAccess dbAccess, DataTable values, int nextUId)
        {
            var commandText = "DELETE FROM EPG_RATES";
            using (var sqlCommand = new SqlCommand(commandText, dbAccess.Connection, dbAccess.Transaction))
            {
                sqlCommand.ExecuteNonQuery();
            }

            commandText = "INSERT INTO EPG_RATES (RT_UID,RT_NAME,RT_ID,RT_LEVEL) VALUES(@RTUID,@RTNAME,@RTID,@RTLEVEL)";
            using (var sqlCommand = new SqlCommand(commandText, dbAccess.Connection, dbAccess.Transaction))
            {
                var rtUIdParameter = sqlCommand.Parameters.Add("@RTUID", SqlDbType.Int);
                var rtNameParameter = sqlCommand.Parameters.Add("@RTNAME", SqlDbType.VarChar, 255);
                var rtIdParameter = sqlCommand.Parameters.Add("@RTID", SqlDbType.Int);
                var rtLevelParameter = sqlCommand.Parameters.Add("@RTLEVEL", SqlDbType.Int);

                var index = 0;
                foreach (DataRow row in values.Rows)
                {
                    var rtUId = SqlDb.ReadIntValue(row["RT_UID"]);
                    var rtName = SqlDb.ReadStringValue(row["RT_NAME"]);
                    var rtLevel = SqlDb.ReadIntValue(row["RT_LEVEL"]);

                    index++;
                    if (rtUId > 0)
                    {
                        rtUIdParameter.Value = rtUId;
                    }
                    else
                    {
                        rtUIdParameter.Value = nextUId;
                        nextUId++;
                    }
                    rtNameParameter.Value = rtName;
                    rtIdParameter.Value = index;
                    rtLevelParameter.Value = rtLevel;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private static bool ReaddRatesValues(DBAccess dbAccess, DataTable values, int startNextUId, ref string reply)
        {
            var nextUId = startNextUId;

            DeleteRateValues(dbAccess);

            return AddRatesValues(dbAccess, values, nextUId, ref reply);
        }

        private static bool AddRatesValues(DBAccess dbAccess, DataTable values, int nextUId, ref string reply)
        {
            const string commandText =
                "INSERT INTO EPG_RATE_VALUES (RT_UID,RT_EFFECTIVE_DATE,RT_RATE,RT_OVERTIME_RATE) VALUES(@RTUID,@RTDATE,@RTRATE,0)";
            using (var sqlCommand = new SqlCommand(commandText, dbAccess.Connection, dbAccess.Transaction))
            {
                var rtUIdParameter = sqlCommand.Parameters.Add("@RTUID", SqlDbType.Int);
                var rtDateParameter = sqlCommand.Parameters.Add("@RTDATE", SqlDbType.DateTime);
                var rtRateParameter = sqlCommand.Parameters.Add("@RTRATE", SqlDbType.Float);
                rtRateParameter.Precision = 25;
                rtRateParameter.Scale = 6;

                // going through dt again including recalculating any new RT_UIDs
                foreach (DataRow row in values.Rows)
                {
                    var rtUId = SqlDb.ReadIntValue(row["RT_UID"]);
                    var rtName = SqlDb.ReadStringValue(row["RT_NAME"]);
                    var rates = SqlDb.ReadStringValue(row["rates"]);

                    if (rtUId == 0)
                    {
                        rtUId = nextUId;
                        nextUId++;
                    }
                    if (rates.Length > 0)
                    {
                        // before saving the rates make sure the values are valid
                        // can't have two effective dates the same, also base rate must be specified now it is separate on the page
                        List<DateTime> list;
                        if (!CheckEffectiveDates(dbAccess, rates, rtName, ref reply, out list))
                        {
                            return false;
                        }

                        // after sort loop through keys to check for duplicates
                        if (!CheckDuplicateDates(dbAccess, ref reply, list, rtName))
                        {
                            return false;
                        }

                        // we're ok so go ahead and save
                        foreach (var splitEntries in rates.Split(',').Select(entry => entry.Split(':')))
                        {
                            if (splitEntries.Length < 3)
                            {
                                throw new InvalidOperationException("Entry in rates has not value for rate parameter.");
                            }
                            DateTime convertedDate;
                            if (!DateTime.TryParse(splitEntries[0], out convertedDate))
                            {
                                throw new InvalidOperationException("Cannot convert value for effective date.");
                            }
                            double convertedValue;
                            if (!double.TryParse(splitEntries[2], out convertedValue))
                            {
                                throw new InvalidOperationException("Cannot convert value for rate.");
                            }
                            var effectiveDate = convertedDate;
                            var parsedValue = convertedValue;
                            rtUIdParameter.Value = rtUId;
                            rtDateParameter.Value = effectiveDate;
                            rtRateParameter.Value = parsedValue;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            return true;
        }

        private static void DeleteRateValues(DBAccess dbAccess)
        {
            const string commandText = "DELETE FROM EPG_RATE_VALUES";
            using (var sqlCommand = new SqlCommand(commandText, dbAccess.Connection, dbAccess.Transaction))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }

        private static bool CheckDuplicateDates(DBAccess dbAccess, ref string reply, List<DateTime> list, string rtName)
        {
            var prevDate = DateTime.MinValue;
            foreach (var dateKey in list)
            {
                if (dateKey == prevDate && prevDate != DateTime.MinValue)
                {
                    dbAccess.RollbackTransaction();
                    reply = SqlDb.FormatAdminError("error", "Rates.UpdateRates", string.Format("{0}: Effective dates must be unique", rtName));
                    return false;
                }
                prevDate = dateKey;
            }
            return true;
        }

        private static bool CheckEffectiveDates(DBAccess dbAccess, string rates, string rtBame, ref string reply, out List<DateTime> list)
        {
            list = new List<DateTime>();
            foreach (var entry in rates.Split(','))
            {
                var values = entry.Split(':');

                DateTime effectivedate;
                if (!DateTime.TryParse(values[0], out effectivedate))
                {
                    dbAccess.RollbackTransaction();
                    reply = SqlDb.FormatAdminError("error", "Rates.UpdateRates", string.Format("{0}: Effective dates must be specified", rtBame));
                    return false;
                }

                list.Add(effectivedate);
            }
            list.Sort();
            return true;
        }

        private static void ReAddResourceRateAssignments(DBAccess dbAccess, DataTable values, int startNextUId)
        {
            var nextUId = startNextUId;

            var commandText = "DELETE FROM EPGP_COST_RATES";
            var sqlCommand = new SqlCommand(commandText, dbAccess.Connection, dbAccess.Transaction);
            sqlCommand.ExecuteNonQuery();

            commandText = "INSERT INTO EPGP_COST_RATES (TB_UID,RT_UID,WRES_ID) VALUES(0,@RTUID,@RTWRESID)";
            sqlCommand = new SqlCommand(commandText, dbAccess.Connection, dbAccess.Transaction);
            var rtUIdParameter = sqlCommand.Parameters.Add("@RTUID", SqlDbType.Int);
            var rtWResIdParameter = sqlCommand.Parameters.Add("@RTWRESID", SqlDbType.Int);

            //  going through dt again including recalculating any new RT_UIDs
            foreach (DataRow row in values.Rows)
            {
                var rtUid = SqlDb.ReadIntValue(row["RT_UID"]);
                var wResId = SqlDb.ReadStringValue(row["wres_ids"]);

                if (rtUid == 0)
                {
                    rtUid = nextUId;
                    nextUId++;
                }
                if (wResId.Length > 0)
                {
                    foreach (var wResIdValue in wResId.Split(',').Select(entry => int.Parse(entry)).Where(wResIdValue => wResIdValue > 0))
                    {
                        rtUIdParameter.Value = rtUid;
                        rtWResIdParameter.Value = wResIdValue;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}

