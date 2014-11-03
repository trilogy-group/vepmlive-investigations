///////////////////////////////////////////////////////////////////////////////
//  Copyright EPK Group 2002 - 2006
//
//  Module  : AllWorkhours.cs
//
//   for any particular combination of Workhours and Holidays provide to prorate total hours for a target span
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

using System.Data;


namespace PortfolioEngineCore
{
    public class AllWorkhours
    {
        
        private Dictionary<int, Dictionary<DayOfWeek, double>> m_WorkHours;
        private Dictionary<int, Dictionary<int, double>> m_HolidayHours;
        private double[] work;

        public void Initialize(DataTable dtWorkhours, DataTable dtHolidays)
        {
            m_WorkHours = new Dictionary<int, Dictionary<DayOfWeek, double>>();
            m_HolidayHours = new Dictionary<int, Dictionary<int, double>>();


            if (dtWorkhours != null)
            {
                foreach (DataRow row in dtWorkhours.Rows)
                {
                    int groupid = DBAccess.ReadIntValue(row["GROUP_ID"]);
                    Dictionary<DayOfWeek, double> workhours = new Dictionary<DayOfWeek, double>();
                    workhours[DayOfWeek.Sunday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_SUN"]);
                    workhours[DayOfWeek.Monday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_MON"]);
                    workhours[DayOfWeek.Tuesday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_TUE"]);
                    workhours[DayOfWeek.Wednesday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_WED"]);
                    workhours[DayOfWeek.Thursday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_THU"]);
                    workhours[DayOfWeek.Friday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_FRI"]);
                    workhours[DayOfWeek.Saturday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_SAT"]);
                    m_WorkHours.Add(groupid, workhours);
                }
            }

            if (dtHolidays != null)
            {
                int prevgroupid = 0;
                Dictionary<int, double> holidays = new Dictionary<int, double>();
                foreach (DataRow row in dtHolidays.Rows)
                {
                    int groupid = DBAccess.ReadIntValue(row["GROUP_ID"]);
                    DateTime hDate = DBAccess.ReadDateValue(row["NWH_DATE"]);
                    double dHours = DBAccess.ReadDoubleValue(row["NWH_HOURS"]);
                    DateTime dt1900 = DateTime.Parse("1900-01-01");
                    TimeSpan span = hDate.Subtract(dt1900);
                    int days = span.Days;
                    if (prevgroupid > 0 && prevgroupid != groupid)
                    {
                        m_HolidayHours.Add(prevgroupid, holidays);
                        holidays = new Dictionary<int, double>();
                    }
                    // hit a problem here when (in error) we had more than one holidy specification for the same date
                    if (!holidays.ContainsKey(days)) holidays.Add(days, dHours);  // using (days since 1900) as the index into the holiday hours - seemed like fun and better than a date
                    prevgroupid = groupid;
                }
                if (prevgroupid > 0) m_HolidayHours.Add(prevgroupid, holidays);
            }
        }

        // get holiday hours for a target date
        private double GetHolidayHours(Dictionary<int, double> HolidayHours, DateTime targetdate)
        {
            DateTime dt1900 = DateTime.Parse("1900-01-01");
            TimeSpan span = targetdate.Subtract(dt1900);
            int days = span.Days;

            double hours;
            if (!HolidayHours.TryGetValue(days, out hours))
            {
                hours = 0;
            }
            return hours;
        }

        // set up an array containing prorated work values ready to be plucked
        public bool Prorate(int workhourgroup, int holidaygroup, DateTime startdate, DateTime finishdate, double hours)
        {
            TimeSpan span = finishdate.Date.Subtract(startdate.Date);
            int days = span.Days + 1;
            if (days <= 0) return false;

            //work = null;
            work = new double[days];

            Dictionary<DayOfWeek, double> l_workHours = null;
            if (workhourgroup < 0 || !m_WorkHours.TryGetValue(workhourgroup, out l_workHours))
            {
                return false;
            }

            Dictionary<int, double> l_HolidayHours = null;
            bool haveholidays = true;
            if (holidaygroup < 0 || !m_HolidayHours.TryGetValue(holidaygroup, out l_HolidayHours))
            {
                haveholidays = false;
            }

            DateTime thisDate = startdate;
            int index = 0;
            double totalhours = 0;
            while (thisDate <= finishdate)
            {
                work[index] = l_workHours[thisDate.DayOfWeek];
                if (haveholidays)
                {
                    work[index] = work[index] - GetHolidayHours(l_HolidayHours, thisDate);
                    if (work[index] < 0) work[index] = 0;
                }
                totalhours += work[index];
                thisDate = thisDate.AddDays(1);
                index += 1;
            }

            double multiplier = (hours * 100) / totalhours;
            totalhours = 0;
            for (int i = 0; i < work.Length; i++)
            {
                work[i] = Math.Round((work[i] * multiplier), 1);  // 1 dp here really means 3 dps in actual number
                totalhours += work[i];
            }

            double remainder = (hours * 100) - totalhours;
            for (int i = 0; i < work.Length; i++)
            {
                if (remainder == 0) break;
                if (work[i] > 0)
                {
                    work[i] += remainder;
                    if (work[i] < 0)
                    {
                        remainder = work[i];
                        work[i] = 0;
                    }
                    else
                    {
                        remainder = 0;
                    }
                }
            }


            return true;
        }

        // read the work array
        public bool Getwork(int index, out double hours)
        {
            hours = 0;
            if (work.Length <= 0) return false;
            if (!(index < work.Length)) return false;

            hours = work[index];
            return true;
        }

        // figure working hours for a target range
        public double workhours(int workhourgroup, int holidaygroup, DateTime startdate, DateTime finishdate)
        {
            TimeSpan span = finishdate.Date.Subtract(startdate.Date);
            int days = span.Days + 1;
            if (days <= 0) return 0;

            Dictionary<DayOfWeek, double> l_workHours = null;
            if (workhourgroup < 0 || !m_WorkHours.TryGetValue(workhourgroup, out l_workHours))
            {
                return 0;
            }

            Dictionary<int, double> l_HolidayHours = null;
            bool haveholidays = true;
            if (holidaygroup < 0 || !m_HolidayHours.TryGetValue(holidaygroup, out l_HolidayHours))
            {
                haveholidays = false;
            }

            DateTime thisDate = startdate;
            double totalhours = 0;
            double hours;
            while (thisDate <= finishdate)
            {
                hours = l_workHours[thisDate.DayOfWeek];
                if (hours > 0 && haveholidays)
                {
                    hours = hours - GetHolidayHours(l_HolidayHours, thisDate);
                    if (hours < 0) hours = 0;
                }
                totalhours += hours;
                thisDate = thisDate.AddDays(1);
            }
            return totalhours / 100;
        }

        public double offhours(int workhourgroup, int holidaygroup, DateTime startdate, DateTime finishdate)
        {
            TimeSpan span = finishdate.Date.Subtract(startdate.Date);
            int days = span.Days + 1;
            if (days <= 0) return 0;

            Dictionary<DayOfWeek, double> l_workHours = null;
            if (workhourgroup < 0 || !m_WorkHours.TryGetValue(workhourgroup, out l_workHours))
            {
                return 0;
            }

            Dictionary<int, double> l_HolidayHours = null;
            bool haveholidays = true;
            if (holidaygroup < 0 || !m_HolidayHours.TryGetValue(holidaygroup, out l_HolidayHours))
            {
                haveholidays = false;
            }

            DateTime thisDate = startdate;
            double totalhours = 0;
            double hours = 0;
            while (thisDate <= finishdate)
            {
                if (haveholidays)
                {
                    hours = GetHolidayHours(l_HolidayHours, thisDate);
                    if (hours < 0) hours = 0;
                }
                totalhours += hours;
                thisDate = thisDate.AddDays(1);
            }
            return totalhours / 100;
        }
    }
}
