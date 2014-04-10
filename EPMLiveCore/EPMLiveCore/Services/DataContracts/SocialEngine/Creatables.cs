using System.Collections.Generic;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    public class Creatables
    {
        #region Constructors (1) 

        public Creatables()
        {
            collection = new List<Creatable>();
        }

        #endregion Constructors 

        #region Properties (2) 

        public List<Creatable> collection { get; set; }

        public Error error { get; set; }

        #endregion Properties 

        #region Nested Classes (1) 

        public class Creatable
        {
            #region Properties (3) 

            public string icon { get; set; }

            public string id { get; set; }

            public string title { get; set; }

            #endregion Properties 
        }

        #endregion Nested Classes 
    }
}