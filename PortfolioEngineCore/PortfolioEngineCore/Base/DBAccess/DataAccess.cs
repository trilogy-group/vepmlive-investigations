using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace PortfolioEngineCore
{
    public class DataAccess : PFEBase
    {
        public DataAccess(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading DataAccess Class");
        }

        public DataAccess(string sBaseInfo, SecurityLevels secLevel = SecurityLevels.Base)
            : base(sBaseInfo, secLevel)
        {
            debug.AddMessage("Loading DataAccess Class");
        }

        public DBAccess dba
        {
            get
            {
                return _dba;
            }
        }
    }
}
