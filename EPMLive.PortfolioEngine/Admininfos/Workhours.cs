///////////////////////////////////////////////////////////////////////////////
//  Copyright EPK Group 2002 - 2006
//
//  Module  : Workhours.cs
//
//   for a particular combination of Workhours and Holidays provide workhours for a target day
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
    public class Workhours
    {
        private Dictionary<DayOfWeek,double> m_WorkHours;
        private Dictionary<int,double> m_HolidayHours;

        public void Initialize(DataTable dtWorkhours, DataTable dtHolidays)
        {
            m_WorkHours = new Dictionary<DayOfWeek, double>();
            m_HolidayHours = new Dictionary<int, double>();


            if (dtWorkhours != null)
            {
                foreach (DataRow row in dtWorkhours.Rows)
                {
                    m_WorkHours[DayOfWeek.Sunday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_SUN"]);
                    m_WorkHours[DayOfWeek.Monday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_MON"]);
                    m_WorkHours[DayOfWeek.Tuesday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_TUE"]);
                    m_WorkHours[DayOfWeek.Wednesday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_WED"]);
                    m_WorkHours[DayOfWeek.Thursday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_THU"]);
                    m_WorkHours[DayOfWeek.Friday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_FRI"]);
                    m_WorkHours[DayOfWeek.Saturday] = DBAccess.ReadDoubleValue(row["GROUP_HOURS_SAT"]);
                }
            }

            if (dtHolidays != null)
            {
                foreach (DataRow row in dtHolidays.Rows)
                {
                    DateTime hDate = DBAccess.ReadDateValue(row["NWH_DATE"]);
                    double dHours = DBAccess.ReadDoubleValue(row["NWH_HOURS"]);
                    DateTime dt1900 = DateTime.Parse("1900-01-01");
                    TimeSpan span = hDate.Subtract(dt1900);
                    int days = span.Days;
                    m_HolidayHours.Add(days, dHours);  // using (days since 1900) as the index into the holiday hours - seemed like fun and better than a date
                }
            }
        }

 // figure working hours for a target date
        public double workhours(DateTime targetdate)
        {
            DateTime dt1900 = DateTime.Parse("1900-01-01");
            TimeSpan span = targetdate.Subtract(dt1900);
            int days = span.Days;

            double workhours = m_WorkHours[targetdate.DayOfWeek];
            double holidayhours = 0;
            if (!m_HolidayHours.TryGetValue(days, out holidayhours))
            {
                holidayhours = 0;
            }
            double hours = workhours - holidayhours;
            if (hours < 0) hours = 0;
            return hours;
        }
    }
}
