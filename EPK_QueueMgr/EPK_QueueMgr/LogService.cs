using PortfolioEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WE_QueueMgr
{
    public class LogService : PFEBase
    {
        public LogService(string _sBasepath) : base(_sBasepath)
        {

        }

        public void TraceStatusError(string sFunction, StatusEnum eStatus, Exception ex)
        {
            _dba.Open();
            _dba.DBTrace(eStatus, TraceChannelEnum.Exception, "TraceStatusError", sFunction, ex.Message, ex.StackTrace, true);
            _dba.Close();
        }
        public void TraceStatusError(string sFunction, StatusEnum eStatus, string sText)
        {
            _dba.Open();
            _dba.DBTrace(eStatus, TraceChannelEnum.Exception, "TraceStatusError", sFunction, sText, "", true);
            _dba.Close();
        }
        public void TraceLog(string sFunction, StatusEnum eStatus, string sText)
        {
            _dba.Open();
            _dba.DBTrace(eStatus, TraceChannelEnum.None, "TraceLog", sFunction, sText, "", true);
            _dba.Close();
        }
    }
}
