using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;

namespace PortfolioEngineCore.Analyzers
{
    // (CC-76855, 2018-07-23) Field names should be refactored on extraction, but I have no idea what most of them mean.
    // Because of this and for the sake of naming consistency across the project, not changing
    public abstract class BaseDetailRowData<TTargetRowData>
        where TTargetRowData : ITargetRowData
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

        protected void CopyData(BaseDetailRowData<TTargetRowData> source)
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

        /// <param name="periodsModes">true if this period should be included in the calc</param>
        public void DragBar(IList<DateTime> periodsStartDates, IList<DateTime> periodsEndDates, IList<int> periodsModes, int minp, int maxp)
        {
            if (periodsStartDates.Count != mxdim + 1)
            {
                throw new ArgumentOutOfRangeException("periodsStartDates");
            }

            if (periodsEndDates.Count != mxdim + 1)
            {
                throw new ArgumentOutOfRangeException("periodsEndDates");
            }

            if (periodsModes.Count != mxdim + 1)
            {
                throw new ArgumentOutOfRangeException("periodsModes");
            }

            // useadj is used to apportion the burn rate - handling the expand and compress affect
            double oDetTimespanDays = oDet_Finish.Subtract(oDet_Start).Days;
            double detTimespanDays = Det_Finish.Subtract(Det_Start).Days;
            double adjustment = oDetTimespanDays <= 0
                ? 1
                : detTimespanDays / oDetTimespanDays;
            if (adjustment == 0)
            {
                adjustment = 0.00001;
            }

            var totalCost = InitializePeriodsBugets(periodsModes);

            ApplyPeriodsBudgetAdjustments(periodsStartDates, periodsEndDates, periodsModes, adjustment);

            // dump overflow into start or end buckets
            for (var periodIndex = 1; periodIndex < minp; periodIndex++)
            {
                Budget[minp] = Budget[minp] + Budget[periodIndex];
                Budget[periodIndex] = 0;
            }

            for (var periodIndex = maxp + 1; periodIndex < mxdim; periodIndex++)
            {
                Budget[maxp] = Budget[maxp] + Budget[periodIndex];
                Budget[periodIndex] = 0;
            }

            double totalBudget = 0;
            for (var periodIndex = minp; periodIndex <= maxp; periodIndex++)
            {
                totalBudget += Budget[periodIndex];
            }

            var totalCostDelta = totalCost - totalBudget;
            if (Det_Start < oDet_Start)
            {
                Budget[minp] = Budget[minp] + totalCostDelta;
            }
            else
            {
                Budget[maxp] = Budget[maxp] + totalCostDelta;
            }

            for (var periodIndex = 1; periodIndex <= mxdim; periodIndex++)
            {
                if (bUseCosts)
                {
                    zCost[periodIndex] = Budget[periodIndex] + OutsideAdj[periodIndex];
                }
                else
                {
                    zValue[periodIndex] = Budget[periodIndex] + OutsideAdj[periodIndex];
                }
            }
        }

        private double InitializePeriodsBugets(IList<int> periodModes)
        {
            double totalCost = 0;
            for (var periodIndex = 1; periodIndex <= mxdim; periodIndex++)
            {
                // only perform these calculations if this period "visible" in the Analyzer view.
                Budget[periodIndex] = 0;

                if (periodModes[periodIndex] != 0)
                {
                    totalCost = totalCost + (bUseCosts ? zCost[periodIndex] : zValue[periodIndex]);
                    OutsideAdj[periodIndex] = 0;
                    UseBurnrate[periodIndex] = Burnrate[periodIndex];
                }
                else
                {
                    OutsideAdj[periodIndex] = (bUseCosts ? zCost[periodIndex] : zValue[periodIndex]);
                    UseBurnrate[periodIndex] = 0;
                }
            }

            return totalCost;
        }

        private void ApplyPeriodsBudgetAdjustments(IList<DateTime> periodsStartDates, IList<DateTime> periodsEndDates, IList<int> periodModes, double adjustment)
        {
            // (CC-77750, 2018-07-23) Not sure if the variables are not reused in the loop due to the difficultly comprehendable logic
            // Therefore not safe to refactor
            double overlapTimespanDays;
            double overlapOffsetDays;
            double useamt;
            int amt, xtraburn;
            for (var periodIndex = 1; periodIndex <= mxdim; periodIndex++)
            {
                // only perform these calculations if this period "visible" in the Analyzer view.
                if (periodModes[periodIndex] != 0)
                {
                    // For each period - calculate the overlap (in days) between the period and the new start and finish dates
                    if (periodIndex == 6)
                    {
                        overlapTimespanDays = 1;
                    }

                    overlapTimespanDays = CalculateOverlapLocal(
                        Det_Start,
                        Det_Finish,
                        periodsStartDates[periodIndex],
                        periodsEndDates[periodIndex]);

                    // we should never get a -ve value but its always worth checking.....
                    if (overlapTimespanDays < 0)
                    {
                        overlapTimespanDays = 0;
                    }

                    // map this span into expanded or compressed amount
                    overlapTimespanDays = overlapTimespanDays / adjustment;
                    if (overlapTimespanDays != 0)
                    {
                        // OK there is some overlap - so now calculate where this overlap starts wrt the new startdate
                        overlapOffsetDays = periodsStartDates[periodIndex].Subtract(Det_Start).Days;
                        if (overlapOffsetDays < 0)
                        {
                            // well the new start is after the period start - so the offest must be 0
                            overlapOffsetDays = 0;
                        }

                        // so now find where this offset starts in the burn duration list....
                        // and map the period offest into expanded/compressed offsets as well
                        overlapOffsetDays = overlapOffsetDays / adjustment;
                        for (int burn = 1; burn <= mxdim; burn++)
                        {
                            if (overlapOffsetDays - BurnDuration[burn] < 0)
                            {
                                // OK this offset starts in this burn period - so calc how many days left in this burn
                                amt = BurnDuration[burn] - (int)(overlapOffsetDays + 0.5);
                                xtraburn = 0;

                                while (overlapTimespanDays > 0)
                                {
                                    if (amt > overlapTimespanDays)
                                    {
                                        useamt = overlapTimespanDays;
                                    }
                                    else
                                    {
                                        useamt = amt;
                                    }

                                    // apply this amts burn to this period
                                    Budget[periodIndex] = Budget[periodIndex] + AFiddler(useamt * UseBurnrate[burn + xtraburn]);
                                    overlapTimespanDays = overlapTimespanDays - useamt;
                                    if (overlapTimespanDays > 0)
                                    {
                                        // step onto the next burn .... if not off the end - other wise use the last periods burn...
                                        if (burn + xtraburn < mxdim)
                                        {
                                            xtraburn = xtraburn + 1;
                                        }
                                        else
                                        {
                                            break;
                                        }

                                        amt = BurnDuration[burn + xtraburn];
                                    }
                                }
                            }
                            else
                            {
                                overlapOffsetDays = overlapOffsetDays - BurnDuration[burn];
                            }
                        }
                    }
                }
            }
        }

        protected int CalculateOverlapLocal(DateTime dtBarStart, DateTime dtBarFinish, DateTime dtPeriodStart, DateTime dtPeriodFinish)
        {
            if (dtBarStart > dtPeriodFinish || dtBarFinish < dtPeriodStart)
            {
                return 0;
            }

            if (dtBarStart <= dtPeriodStart && dtBarFinish >= dtPeriodFinish)
            {
                return dtPeriodFinish.Subtract(dtPeriodStart).Days + 1;
            }

            var maxStartDate = (dtBarStart < dtPeriodStart ? dtPeriodStart : dtBarStart);
            var minEndDate = (dtBarFinish < dtPeriodFinish ? dtBarFinish : dtPeriodFinish);

            if (maxStartDate > minEndDate)
            {
                return 0;
            }

            return minEndDate.Subtract(maxStartDate).Days + 1;
        }

        private double AFiddler(double f)
        {
            return double.Parse(f.ToString("0.00"));
        }

        public void CopyToTargetData(ref TTargetRowData dest)
        {
            if (dest == null)
            {
                throw new ArgumentNullException(nameof(dest));
            }

            dest.CT_ID = CT_ID;
            dest.BC_UID = BC_UID;
            dest.BC_ROLE_UID = BC_ROLE_UID;
            dest.BC_SEQ = BC_SEQ;
            dest.MC_Val = MC_Val;
            dest.CAT_UID = CAT_UID;
            dest.CT_Name = CT_Name;
            dest.Cat_Name = Cat_Name;
            dest.Role_Name = Role_Name;
            dest.MC_Name = MC_Name;
            dest.FullCatName = FullCatName;
            dest.CC_Name = CC_Name;
            dest.FullCCName = FullCCName;
            dest.bGroupRow = false;
            dest.Grouping = string.Empty;
            dest.OCVal = OCVal;
            dest.Text_OCVal = Text_OCVal;
            dest.TXVal = TXVal;
            dest.zCost = new double[mxdim + 1];
            dest.zValue = new double[mxdim + 1];
            dest.zFTE = new double[mxdim + 1];

            for (var i = 1; i <= mxdim; i++)
            {
                dest.zCost[i] = zCost[i];
                dest.zValue[i] = zValue[i];
                dest.zFTE[i] = zFTE[i];
            }
        }
    }
}
