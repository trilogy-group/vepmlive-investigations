using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs
{
    public class AdSynchJob : API.BaseJob
    {
        public void execute(SPSite osite, SPWeb oweb, string data)
        {
            try
            {
                ADSync synch = new ADSync();
                synch.InitiateSync(osite, out sErrors, out bErrors, base.JobUid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oweb != null)
                    oweb.Dispose();
                if (osite != null)
                    osite.Dispose();
                data = null;
            }

        }
    }
}
