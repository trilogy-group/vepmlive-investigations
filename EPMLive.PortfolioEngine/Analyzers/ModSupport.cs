using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;


namespace PortfolioEngineCore
{
    public class ModelSupport : PFEBase
    {

        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields

        public ModelSupport(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ModelSupport Class");
            _sqlConnection = _PFECN;
            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

        public ModelSupport(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading ModelSupport Class");
            _sqlConnection = _PFECN;
        }

        public SqlConnection GetConnection()
        {
            return _sqlConnection;

        }
    }

 

}
