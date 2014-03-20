using System.Data.SqlClient;

namespace EPMLiveCore.SocialEngine.Core
{
    internal abstract class BaseManager
    {
        #region Fields (1) 

        private readonly DBConnectionManager _dbConnectionManager;

        #endregion Fields 

        #region Constructors (1) 

        protected BaseManager(DBConnectionManager dbConnectionManager)
        {
            _dbConnectionManager = dbConnectionManager;
        }

        #endregion Constructors 

        #region Methods (1) 

        // Protected Methods (1) 

        protected SqlCommand GetSqlCommand(string sql)
        {
            return new SqlCommand(sql, _dbConnectionManager.SqlConnection);
        }

        #endregion Methods 
    }
}