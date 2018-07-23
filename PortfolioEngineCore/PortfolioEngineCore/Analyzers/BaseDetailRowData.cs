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
            zCost = new double[arraysize + 1];
            zValue = new double[arraysize + 1];
            zFTE = new double[arraysize + 1];
            oCosts = new double[arraysize + 1];
            oUnits = new double[arraysize + 1];
            oFTE = new double[arraysize + 1];
            for (int i = 0; i <= mxdim; i++)
            {
                zCost[i] = 0;
                zValue[i] = 0;
            }

            BurnDuration = new int[arraysize + 1];
            Burnrate = new double[arraysize + 1];
            UseBurnrate = new double[arraysize + 1];
            OutsideAdj = new double[arraysize + 1];
            Budget = new double[arraysize + 1];

            OCVal = new int[6];
            Text_OCVal = new string[6];
            TXVal = new string[6];
        }

        protected void CopyData(BaseDetailRowData src)
        {
            CB_ID = src.CB_ID;
            CT_ID = src.CT_ID;
            PROJECT_ID = src.PROJECT_ID;
            BC_UID = src.BC_UID;
            BC_ROLE_UID = src.BC_ROLE_UID;
            BC_SEQ = src.BC_SEQ;
            MC_Val = src.MC_Val;
            CAT_UID = src.CAT_UID;
            Det_Start = src.Det_Start;
            Det_Finish = src.Det_Finish;
            oDet_Start = src.oDet_Start;
            oDet_Finish = src.oDet_Finish;
            bHadPData = src.bHadPData;
            PI_Name = src.PI_Name;
            CT_Name = src.CT_Name;
            Scen_Name = src.Scen_Name;
            Cat_Name = src.Cat_Name;
            Role_Name = src.Role_Name;
            MC_Name = src.MC_Name;
            FullCatName = src.FullCatName;
            Scenario_ID = src.Scenario_ID;
            b_PIOver = src.b_PIOver;
            LinkedToPI = src.LinkedToPI;
            m_mode = src.m_mode;
            CC_Name = src.CC_Name;
            FullCCName = src.FullCCName;

            OCVal = src.OCVal;
            Text_OCVal = src.Text_OCVal;
            TXVal = src.TXVal;
            m_PI_Format_Extra_data = src.m_PI_Format_Extra_data;
            m_tot1 = src.m_tot1;
            m_tot2 = src.m_tot2;
            m_tot3 = src.m_tot3;
            m_rt = src.m_rt;
            m_rt_name = src.m_rt_name;
            bSelected = src.bSelected;
            bRealone = src.bRealone;
            lUoM = src.lUoM;
            HasValues = src.HasValues;
            bUseCosts = src.bUseCosts;

            for (int i = 1; i <= mxdim; i++)
            {
                zCost[i] = src.zCost[i];
                zValue[i] = src.zValue[i];
                zFTE[i] = src.zFTE[i];

                oCosts[i] = src.oCosts[i];
                oUnits[i] = src.oUnits[i];
                zFTE[i] = src.oFTE[i];

                BurnDuration[i] = src.BurnDuration[i];
                Burnrate[i] = src.Burnrate[i];
                UseBurnrate[i] = src.UseBurnrate[i];

                OutsideAdj[i] = src.OutsideAdj[i];
                oUnits[i] = src.oUnits[i];
                Budget[i] = src.Budget[i];
            }
        }
    }
}
