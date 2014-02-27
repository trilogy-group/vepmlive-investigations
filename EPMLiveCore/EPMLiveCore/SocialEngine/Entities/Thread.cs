using System;
using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.SocialEngine.Entities
{
    internal class Thread
    {
        #region Properties (9) 

        public bool Deleted { get; set; }

        public Guid Id { get; set; }

        public int? ItemId { get; set; }

        public ObjectKind Kind { get; set; }

        public DateTime LastActivityDateTime { get; set; }

        public Guid? ListId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public Guid? WebId { get; set; }

        #endregion Properties 
    }
}