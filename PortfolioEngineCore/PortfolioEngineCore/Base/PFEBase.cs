using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class PFEBase
    {
        #region Fields (10)

        protected SqlConnection _PFECN;
        protected string _basepath;
        protected string _company;
        protected string _dbcnstring;
        protected bool _debug;
        protected string _pid;
        protected string _username;
        protected Debugger debug;
        protected int _userWResID;
        protected int _port;
        protected string _session;
        protected DBAccess _dba;

        #endregion Fields

        #region Constructors (2)

        public PFEBase(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
        {
            PFEBaseCommon(basepath, username, pid, company, dbcnstring, secLevel, bDebug);
        }

        public PFEBase(string sBaseInfo, SecurityLevels secLevel = SecurityLevels.Base, bool bDebug = false)
        {
            CStruct xBaseInfo = new CStruct();
            xBaseInfo.LoadXML(sBaseInfo);

            string basepath = xBaseInfo.GetString("basepath");
            string username = xBaseInfo.GetString("username");
            string pid = xBaseInfo.GetString("pid");
            string company = xBaseInfo.GetString("company");
            string dbcnstring = xBaseInfo.GetString("dbcnstring");
            _port = xBaseInfo.GetInt("port");
            _session = xBaseInfo.GetString("session");

            PFEBaseCommon(basepath, username, pid, company, dbcnstring, secLevel, bDebug);
        }

        private void PFEBaseCommon(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug)
        {
            debug = new Debugger(bDebug);
            debug.AddMessage("Begin Debug PFE BASE");

            _basepath = basepath;
            _username = username;
            _pid = pid;
            _company = company;
            _dbcnstring = dbcnstring;
            _debug = bDebug;

            var act = new Activation(debug);
            act.checkActivation(basepath, PFEEncrypt.Decrypt(pid, "MnjkafjhkAS&*^#@"), company);

            var db = new Database(debug);
            _PFECN = db.OpenDatabase(basepath, PFEEncrypt.Decrypt(dbcnstring, "MnjkafjhkAS&*^#@"));


            try
            {
                _PFECN.Open();

                string cmdText = "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT";
                using (var sqlCommand = new SqlCommand(cmdText, _PFECN) { CommandType = CommandType.Text })
                {
                    var usernameParameter = new SqlParameter("@WRES_NT_ACCOUNT", SqlDbType.NVarChar, 255) { Value = username };

                    sqlCommand.Parameters.Add(usernameParameter);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                        _userWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                }
                _PFECN.Close();

            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CheckSecurity, exception.GetBaseMessage());
            }

            var sec = new BaseSecurity(debug, _PFECN);

            if (!sec.ChecksScurity(username, secLevel))
            {
                throw new PFEException((int)PFEError.BaseAccessDenied, "Access Denied");
            }

            _dbcnstring = db.sCN;
            _dba = new DBAccess(db.sCN, _PFECN);
            _dba.UserWResID = _userWResID;
            _dba.UserName = _username;

            debug.AddMessage("PFE Base Loaded");
        }


        #endregion Constructors

        #region Methods (2)

        // Public Methods (2) 

        public string getDebugInfo()
        {
            return debug.GetMessage();
        }

        public string FormatErrorText()
        {
            if (_dba != null)
            {
                return _dba.FormatErrorText();
            }
            return "";
        }

        #endregion Methods

        #region Properties (3)

        public int Status
        {
            get
            {
                if (_dba != null)
                {
                    return (int)_dba.Status;
                }
                return 0;
            }
        }

        public string StatusText
        {
            get
            {
                if (_dba != null)
                {
                    return _dba.StatusText;
                }
                return "";
            }
        }

        public string StackTrace
        {
            get
            {
                if (_dba != null)
                {
                    return _dba.StackTrace;
                }
                return "";
            }
        }

        public string BasePath
        {
            get
            {
                return _basepath;
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
        }

        public int UserId
        {
            get
            {
                return _userWResID;
            }
        }
        #endregion Properties
    }
}