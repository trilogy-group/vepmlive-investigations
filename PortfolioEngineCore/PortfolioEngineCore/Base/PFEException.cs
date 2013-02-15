using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioEngineCore
{
    public class PFEException : Exception
    {

        public PFEException(int exceptionNumber, string message)
            : base(message)
        {
            ExceptionNumber = exceptionNumber;
        }

        public int ExceptionNumber { get; set; }

    }
}
