using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLicensing.Api.Data
{
    public partial class LICENSEPRODUCT
    {
        public bool CanBeDeleted => ORDERS.Count == 0;
    }
}
