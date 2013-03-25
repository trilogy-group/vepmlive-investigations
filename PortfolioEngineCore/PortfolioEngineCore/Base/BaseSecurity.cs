using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public enum SecurityLevels
    {
        Base = 0,
        AdminCalc = 98,
        BaseAdmin = 3009,
        EditResources = 3028,
        ViewPortfolioItems = 3001,
        EditPortfolioItems = 3012,
        PortAdmin = 3025,
        Portfolio = 3011,
        PMO = 3042,
        DBAUtil = 3003,
        EditResourcePlans = 3026
    }

    internal class BaseSecurity : AllCore
    {
        #region Fields (1) 

        private SqlConnection _cn;

        #endregion Fields 

        #region Constructors (1) 

        public BaseSecurity(Debugger debug, SqlConnection cn)
            : base(debug)
        {
            _cn = cn;
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public bool ChecksScurity(string username, SecurityLevels seclevel)
        {
            debug.AddMessage("Checking Security (" + username + ": " + seclevel + ")");

            if (seclevel == SecurityLevels.Base)
            {
                return true;
            }
            if (seclevel == SecurityLevels.AdminCalc)
            {
                return true;
            }

            try
            {
                _cn.Open();

                bool hasAccess;

                using (var sqlCommand = new SqlCommand("SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)", _cn) {CommandType = CommandType.Text})
                {
                    var usernameParameter = new SqlParameter("@Username", SqlDbType.NVarChar, 255) {Value = username};
                    var securityLevelParameter = new SqlParameter("@SecurityLevel", SqlDbType.Int) { Value = (int)seclevel };

                    sqlCommand.Parameters.Add(usernameParameter);
                    sqlCommand.Parameters.Add(securityLevelParameter);

                    hasAccess = (bool) sqlCommand.ExecuteScalar();
                }

                _cn.Close();

                return hasAccess;
            }
            catch (Exception exception)
            {
                throw new PFEException((int) PFEError.CheckSecurity,exception.GetBaseMessage());
            }
        }

        #endregion Methods 
        
    }
}
