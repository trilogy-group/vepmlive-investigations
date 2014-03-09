using System;
using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.SocialEngine.Entities
{
    public class Activity
    {
        #region Properties (7) 

        public string Data { get; set; }

        public DateTime Date { get; set; }

        public Guid Id { get; set; }

        public bool IsMassOperation { get; set; }

        public ActivityKind Kind { get; set; }

        public Thread Thread { get; set; }

        public int UserId { get; set; }

        #endregion Properties 
    }
}