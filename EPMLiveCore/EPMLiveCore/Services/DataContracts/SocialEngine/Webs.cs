using System;
using System.Collections.Generic;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    public class Webs
    {
        #region Constructors (1) 

        public Webs()
        {
            collection = new List<Web>();
        }

        #endregion Constructors 

        #region Properties (2) 

        public List<Web> collection { get; set; }

        public Error error { get; set; }

        #endregion Properties 

        #region Nested Classes (1) 

        public class Web
        {
            #region Properties (2) 

            public Guid id { get; set; }

            public string url { get; set; }

            #endregion Properties 
        }

        #endregion Nested Classes 
    }
}