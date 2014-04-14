using System;
using System.Collections.Generic;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    public class Logs
    {
        #region Constructors (1) 

        public Logs()
        {
            collection = new List<Log>();
            users = new List<SEActivities.User>();
            webs = new List<SEActivities.Web>();
        }

        #endregion Constructors 

        #region Properties (4) 

        public List<Log> collection { get; set; }

        public Error error { get; set; }

        public List<SEActivities.User> users { get; set; }

        public List<SEActivities.Web> webs { get; set; }

        #endregion Properties 

        #region Nested Classes (1) 

        public class Log
        {
            #region Properties (8) 

            public string details { get; set; }

            public Guid id { get; set; }

            public string kind { get; set; }

            public string message { get; set; }

            public string stackTrace { get; set; }

            public DateTime time { get; set; }

            public int user { get; set; }

            public Guid web { get; set; }

            #endregion Properties 
        }

        #endregion Nested Classes 
    }
}