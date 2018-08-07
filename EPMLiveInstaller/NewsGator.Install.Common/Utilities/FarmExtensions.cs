using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NewsGator.Install.Common.Utilities
{
    internal static class FarmExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        internal static void TryUpdate(this SPFarm farm)
        {
            if (farm != null)
            {
                try
                {
                    farm.Update();
                }
                catch 
                {
                    try
                    {
                        LocalFarm.Get().Update();
                    }
                    catch { }
                }
            }
        }
    }
}
