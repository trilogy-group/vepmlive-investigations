using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioEngineCore.Tests
{
    [TestClass()]
    public class AllWorkhoursTests
    {
        [TestMethod()]
        public void InitializeTest()
        {
            AllWorkhours AdmFunc = new AllWorkhours();
            DataTable dtWorkHour = new DataTable();
            DataTable dtHolidayHour = new DataTable();
            DataRow dr = dtWorkHour.NewRow();
            string[] value;
            string[] columns = "GROUP_ID,GROUP_HOURS_MON,GROUP_HOURS_TUE,GROUP_HOURS_WED,GROUP_HOURS_THU,GROUP_HOURS_FRI,GROUP_HOURS_SAT,GROUP_HOURS_SUN".Split(',');
            foreach (string item in columns)
            {
                dtWorkHour.Columns.Add(new DataColumn(item));
            }
            value = "12,800.000000,800.000000,800.000000,800.000000,800.000000,0.000000,0.000000".Split(',');
            dr = dtWorkHour.NewRow();
            for (int i = 0; i < columns.Length; i++)
            {
                dr[columns[i]] = value[i];
            }
            dtWorkHour.Rows.Add(dr);
            dr = dtWorkHour.NewRow();
            value = "15,800.000000,800.000000,800.000000,800.000000,800.000000,0.000000,0.000000".Split(',');
            for (int i = 0; i < columns.Length; i++)
            {
                dr[columns[i]] = value[i];
            }
            dtWorkHour.Rows.Add(dr);

            columns = "GROUP_ID,NWH_DATE,NWH_HOURS,NWH_COMMENT".Split(',');
            foreach (string item in columns)
            {
                dtHolidayHour.Columns.Add(new DataColumn(item));
            }
            value = "14,2013-01-01 00:00:00.000,800.000000,New Year's Day".Split(',');
            dr = dtHolidayHour.NewRow();
            for (int i = 0; i < columns.Length; i++)
            {
                dr[columns[i]] = value[i];
            }
            dtHolidayHour.Rows.Add(dr);

            //Act
            AdmFunc.Initialize(dtWorkHour, dtHolidayHour);

            //Assert
            Dictionary<int, Dictionary<DayOfWeek, double>> m_WorkHours = (Dictionary<int, Dictionary<DayOfWeek, double>>)new PrivateObject(AdmFunc).GetField("m_WorkHours");
            Dictionary<int, Dictionary<int, double>> m_HolidayHours = (Dictionary<int, Dictionary<int, double>>)new PrivateObject(AdmFunc).GetField("m_HolidayHours");

            Assert.IsTrue(m_WorkHours.Count == 2);
            Assert.IsTrue(m_HolidayHours.Count == 1);
        }
    }
}