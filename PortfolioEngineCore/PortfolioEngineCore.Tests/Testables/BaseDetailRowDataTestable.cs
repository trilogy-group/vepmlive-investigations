using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioEngineCore.Analyzers;

namespace PortfolioEngineCore.Tests.Testables
{
    public class BaseDetailRowDataTestable : BaseDetailRowData
    {
        public double[] oCosts
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

        public double[] oUnits
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

        public double[] oFTE
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

        public int[] BurnDuration
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

        public double[] Burnrate
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

        public double[] UseBurnrate
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

        public double[] OutsideAdj
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

        public double[] Budget
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
    }
}
