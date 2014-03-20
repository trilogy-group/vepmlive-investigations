using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.SocialEngine.Entities
{
    public class Thread
    {
        #region Properties (12) 

        public List<Activity> Activities { get; set; }

        public bool Deleted { get; set; }

        public DateTime FirstActivityDateTime { get; set; }

        public Guid Id { get; set; }

        public int? ItemId { get; set; }

        public ObjectKind Kind { get; set; }

        public DateTime LastActivityDateTime { get; set; }

        public Guid? ListId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public User[] Users { get; set; }

        public Guid? WebId { get; set; }

        #endregion Properties 
    }
}