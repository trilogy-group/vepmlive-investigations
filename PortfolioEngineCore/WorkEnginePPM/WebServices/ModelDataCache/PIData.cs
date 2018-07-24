using System;

namespace ModelDataCache
{
    [Serializable()]
    class PIData : IComparable<PIData>
    {
        public int PI_ID, ScenarioID, Internal_ID, PISelected, GroupingPosn;
        public DateTime StartDate, FinishDate, oStartDate, oFinishDate;
        public string PI_Name, Scenario_name, GroupingID;
        public string[] m_PI_Extra_data;
        public string[] m_PI_Format_Extra_data;

        public int CompareTo(PIData rhs)
        {
            return PI_Name.CompareTo(rhs.PI_Name);
        }

        public PIData(int arraysize)
        {
            m_PI_Extra_data = new string[arraysize + 1];
            m_PI_Format_Extra_data = new string[arraysize + 1];
            Scenario_name = string.Empty;
            GroupingID = string.Empty;
        }
    }
}
