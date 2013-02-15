using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore.Analyzers
{
    public class BaseAnalyzer : PFEBase
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAnalyzer"/> class.
        /// </summary>
        /// <param name="basepath">The basepath.</param>
        /// <param name="username">The username.</param>
        /// <param name="pid">The pid.</param>
        /// <param name="company">The company.</param>
        /// <param name="dbcnstring">The dbcnstring.</param>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="bDebug">if set to <c>true</c> [b debug].</param>
        public BaseAnalyzer(string basepath, string username, string pid, string company, string dbcnstring,
                            SecurityLevels secLevel, bool bDebug)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        /// <summary>
        /// Generates the data ticket.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public Guid GenerateDataTicket(string data)
        {
            object ticketId;

            if (_PFECN.State == ConnectionState.Closed)
            {
                _PFECN.Open();
            }

            using (var sqlCommand = new SqlCommand("PFE_SP_GenerateDataTicket", _PFECN))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Data", data);

                ticketId = sqlCommand.ExecuteScalar();
            }

            _PFECN.Close();

            return ticketId != DBNull.Value ? (Guid) ticketId : Guid.Empty;
        }

        #endregion Methods 
    }
}