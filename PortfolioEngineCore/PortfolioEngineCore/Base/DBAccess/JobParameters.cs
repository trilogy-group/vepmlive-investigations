using System;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class JobParameters
    {
        public string Comment { get; internal set; }

        public SqlConnection Connection { get; internal set; }

        public int Context { get; internal set; }

        public string ContextData { get; internal set; }

        public Guid Guid { get; internal set; }

        public string Session { get; internal set; }

        public SqlTransaction Transaction { get; internal set; }

        public int UserId { get; internal set; }
    }
}