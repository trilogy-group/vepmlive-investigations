using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using PortfolioEngineCore.Analyzers;

namespace PortfolioEngineCore.Tests.Testables
{
    public class BaseDetailRowDataTestable : BaseDetailRowData
    {
        public new double[] oCosts
        {
            get
            {
                return base.oCosts;
            }
            set
            {
                base.oCosts = value;
            }
        }

        public new double[] oUnits
        {
            get
            {
                return base.oUnits;
            }
            set
            {
                base.oUnits = value;
            }
        }

        public new double[] oFTE
        {
            get
            {
                return base.oFTE;
            }
            set
            {
                base.oFTE = value;
            }
        }

        public new int[] BurnDuration
        {
            get
            {
                return base.BurnDuration;
            }
            set
            {
                base.BurnDuration = value;
            }
        }

        public new double[] Burnrate
        {
            get
            {
                return base.Burnrate;
            }
            set
            {
                base.Burnrate = value;
            }
        }

        public new double[] UseBurnrate
        {
            get
            {
                return base.UseBurnrate;
            }
            set
            {
                base.UseBurnrate = value;
            }
        }

        public new double[] OutsideAdj
        {
            get
            {
                return base.OutsideAdj;
            }
            set
            {
                base.OutsideAdj = value;
            }
        }

        public new double[] Budget
        {
            get
            {
                return base.Budget;
            }
            set
            {
                base.Budget = value;
            }
        }

        public BaseDetailRowDataTestable(int arraysize) : base(arraysize)
        {
        }

        public void CopyData(BaseDetailRowDataTestable source)
        {
            base.CopyData(source);
        }

        public new void CaptureBurnRates(IEnumerable<IPeriodData> periods)
        {
            base.CaptureBurnRates(periods);
        }

        public new int CalculateOverlapLocal(DateTime barStart, DateTime barFinish, DateTime periodStart, DateTime periodFinish)
        {
            return base.CalculateOverlapLocal(barStart, barFinish, periodStart, periodFinish);
        }
    }
}
