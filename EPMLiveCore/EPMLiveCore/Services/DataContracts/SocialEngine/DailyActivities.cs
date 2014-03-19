using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    public class DailyActivities
    {
        #region Properties (6) 

        public List<Activity> activities { get; set; }

        public List<Day> days { get; set; }

        public List<ItemList> lists { get; set; }

        public List<Thread> threads { get; set; }

        public List<User> users { get; set; }

        public List<Web> webs { get; set; }

        #endregion Properties 

        #region Nested Classes (7) 

        public class Activity
        {
            #region Properties (8) 

            public string metaData { get; set; }

            public Guid id { get; set; }

            public bool isMassOperation { get; set; }

            public string key { get; set; }

            public string kind { get; set; }

            public Guid thread { get; set; }

            public string time { get; set; }

            public int user { get; set; }

            #endregion Properties 
        }

        public class Day
        {
            #region Properties (2) 

            public List<Guid> threads { get; set; }

            public string id { get; set; }

            #endregion Properties 
        }

        public class ItemList
        {
            #region Properties (4) 

            public Guid id { get; set; }

            public string name { get; set; }

            public string icon { get; set; }

            public List<Guid> threads { get; set; }

            public string url { get; set; }

            #endregion Properties 
        }

        public class Thread
        {
            #region Properties (11) 

            public List<Guid> activities { get; set; }

            public List<string> days { get; set; }

            public Guid id { get; set; }

            public int? itemId { get; set; }

            public string kind { get; set; }

            public string lastActivityOn { get; set; }

            public Guid? list { get; set; }

            public string title { get; set; }

            public string url { get; set; }

            public Guid web { get; set; }

            #endregion Properties 
        }

        public class User
        {
            #region Properties (5) 

            public string account { get; set; }

            public List<Guid> activities { get; set; }

            public string avatar { get; set; }

            public int id { get; set; }

            public string name { get; set; }

            #endregion Properties 
        }

        public class Web
        {
            #region Properties (4) 

            public Guid id { get; set; }

            public List<Guid> threads { get; set; }

            public string title { get; set; }

            public string url { get; set; }

            #endregion Properties 
        }

        #endregion Nested Classes 
    }
}