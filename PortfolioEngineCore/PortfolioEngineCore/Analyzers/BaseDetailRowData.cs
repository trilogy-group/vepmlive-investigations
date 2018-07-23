using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioEngineCore.Analyzers
{
    // (CC-76855, 2018-07-23) Field names should be refactored on extraction, but I have no idea what most of them mean.
    // Because of this and for the sake of naming consistency across the project, not changing
    public abstract class BaseDetailRowData
    {
        public int CB_ID;
        public int CT_ID;
        public int PROJECT_ID;
        public int Internal_ID;
        public int BC_UID;
        public int BC_ROLE_UID;
        public int BC_SEQ;
        public string MC_Val;
        public int CAT_UID;
        public DateTime Det_Start;
        public DateTime Det_Finish;
        public DateTime oDet_Start;
        public DateTime oDet_Finish;
        public bool bHadPData;
        public string PI_Name, CT_Name, Scen_Name, Cat_Name, Role_Name, MC_Name, FullCatName, CC_Name, FullCCName;
        public int Scenario_ID;
        public bool b_PIOver;
        public bool LinkedToPI;
        public int m_mode;   //' bitwise field 1 = no edit - data cannot move be changed
                             //   '               2 = can move it but not save it...
                             //   '               4 = Don't recalc the values for cost here
        public double m_tot1;
        public double m_tot2;
        public double m_tot3;
        public int m_rt;
        public string m_rt_name;
        public bool bSelected;
        public int m_uid;
        public int m_total_to;
        public int m_par;
        public bool bRealone;
        public bool bGotChildren;
        public string sName;
        public string sUoM;
        public bool bRollupTouched;
        public int m_sort_id;
        public int lUoM;
        public bool HasValues;
        public int m_lev, m_index;
        public bool bUseCosts;
        public double[] zCost, zValue, zFTE;
        protected double[] oCosts, oUnits, oFTE;
        protected int[] BurnDuration;
        protected double[] Burnrate;
        protected double[] UseBurnrate;
        protected double[] OutsideAdj;
        protected double[] Budget;
        public bool bCapture;
        public int mxdim;
        public int[] OCVal;
        public string[] Text_OCVal;
        public string[] TXVal;
        public string[] m_PI_Format_Extra_data;
        private int arraysize;

        public BaseDetailRowData(int arraysize)
        {
            PI_Name = string.Empty;
            CT_Name = string.Empty;
            Scen_Name = string.Empty;
            Cat_Name = string.Empty;
            Role_Name = string.Empty;
            MC_Name = string.Empty;
            FullCatName = string.Empty;
            FullCCName = string.Empty;
            CC_Name = string.Empty;
            m_rt_name = string.Empty;
            HasValues = false;
            LinkedToPI = false;

            mxdim = arraysize;
            var actualArraySize = arraysize + 1;

            zCost = new double[actualArraySize];
            zValue = new double[actualArraySize];
            zFTE = new double[actualArraySize];
            oCosts = new double[actualArraySize];
            oUnits = new double[actualArraySize];
            oFTE = new double[actualArraySize];
            for (int i = 0; i <= mxdim; i++)
            {
                zCost[i] = 0;
                zValue[i] = 0;
            }

            BurnDuration = new int[actualArraySize];
            Burnrate = new double[actualArraySize];
            UseBurnrate = new double[actualArraySize];
            OutsideAdj = new double[actualArraySize];
            Budget = new double[actualArraySize];

            OCVal = new int[6];
            Text_OCVal = new string[6];
            TXVal = new string[6];
        }

        protected void CopyData(BaseDetailRowData source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            CB_ID = source.CB_ID;
            CT_ID = source.CT_ID;
            PROJECT_ID = source.PROJECT_ID;
            BC_UID = source.BC_UID;
            BC_ROLE_UID = source.BC_ROLE_UID;
            BC_SEQ = source.BC_SEQ;
            MC_Val = source.MC_Val;
            CAT_UID = source.CAT_UID;
            Det_Start = source.Det_Start;
            Det_Finish = source.Det_Finish;
            oDet_Start = source.oDet_Start;
            oDet_Finish = source.oDet_Finish;
            bHadPData = source.bHadPData;
            PI_Name = source.PI_Name;
            CT_Name = source.CT_Name;
            Scen_Name = source.Scen_Name;
            Cat_Name = source.Cat_Name;
            Role_Name = source.Role_Name;
            MC_Name = source.MC_Name;
            FullCatName = source.FullCatName;
            Scenario_ID = source.Scenario_ID;
            b_PIOver = source.b_PIOver;
            LinkedToPI = source.LinkedToPI;
            m_mode = source.m_mode;
            CC_Name = source.CC_Name;
            FullCCName = source.FullCCName;

            OCVal = source.OCVal;
            Text_OCVal = source.Text_OCVal;
            TXVal = source.TXVal;
            m_PI_Format_Extra_data = source.m_PI_Format_Extra_data;
            m_tot1 = source.m_tot1;
            m_tot2 = source.m_tot2;
            m_tot3 = source.m_tot3;
            m_rt = source.m_rt;
            m_rt_name = source.m_rt_name;
            bSelected = source.bSelected;
            bRealone = source.bRealone;
            lUoM = source.lUoM;
            HasValues = source.HasValues;
            bUseCosts = source.bUseCosts;

            for (int i = 1; i <= mxdim; i++)
            {
                zCost[i] = source.zCost[i];
                zValue[i] = source.zValue[i];
                zFTE[i] = source.zFTE[i];

                oCosts[i] = source.oCosts[i];
                oUnits[i] = source.oUnits[i];
                zFTE[i] = source.oFTE[i];

                BurnDuration[i] = source.BurnDuration[i];
                Burnrate[i] = source.Burnrate[i];
                UseBurnrate[i] = source.UseBurnrate[i];

                OutsideAdj[i] = source.OutsideAdj[i];
                oUnits[i] = source.oUnits[i];
                Budget[i] = source.Budget[i];
            }
        }
    }
}
