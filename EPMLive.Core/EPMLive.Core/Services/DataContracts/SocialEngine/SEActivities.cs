using System;
using System.Collections.Generic;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    public class SEActivities
    {
        #region Constructors (1) 

        public SEActivities()
        {
            threads = new List<Thread>();
            webs = new List<Web>();
            lists = new List<ItemList>();
            users = new List<User>();
        }

        #endregion Constructors 

        #region Properties (6) 

        public Error error { get; set; }

        public List<ItemList> lists { get; set; }

        public Guid suid { get; set; }

        public List<Thread> threads { get; set; }

        public List<User> users { get; set; }

        public List<Web> webs { get; set; }

        #endregion Properties 

        #region Nested Classes (4) 

        public class ItemList
        {
            #region Properties (4) 

            public string icon { get; set; }

            public Guid id { get; set; }

            public string name { get; set; }

            public string url { get; set; }

            #endregion Properties 
        }

        public class Thread
        {
            #region Constructors (1) 

            public Thread()
            {
                activities = new List<Activity>();
                comments = new List<Activity>();
            }

            #endregion Constructors 

            #region Properties (13) 

            public List<Activity> activities { get; set; }

            public List<Activity> comments { get; set; }

            public string firstActivityOn { get; set; }

            public Guid id { get; set; }

            public int? itemId { get; set; }

            public string kind { get; set; }

            public string lastActivityOn { get; set; }

            public Guid? listId { get; set; }

            public string title { get; set; }

            public int totalActivities { get; set; }

            public int totalComments { get; set; }

            public string url { get; set; }

            public Guid webId { get; set; }

            #endregion Properties 

            #region Nested Classes (1) 

            public class Activity
            {
                #region Properties (7) 

                public string data { get; set; }

                public Guid id { get; set; }

                public bool isBulkOperation { get; set; }

                public string key { get; set; }

                public string kind { get; set; }

                public string time { get; set; }

                public int userId { get; set; }

                #endregion Properties 
            }

            #endregion Nested Classes 
        }

        public class User
        {
            #region Properties (4) 

            public string displayName { get; set; }

            public int id { get; set; }

            public string name { get; set; }

            public string picture { get; set; }

            #endregion Properties 
        }

        public class Web
        {
            #region Properties (3) 

            public Guid id { get; set; }

            public string title { get; set; }

            public string url { get; set; }

            #endregion Properties 
        }

        #endregion Nested Classes 
    }
}