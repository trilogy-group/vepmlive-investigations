using System;
using System.Web.Script.Serialization;
using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.SocialEngine.Entities
{
    public class Activity
    {
        #region Properties (8) 

        public string Data { get; private set; }

        public DateTime Date { get; set; }

        public Guid Id { get; set; }

        public bool IsMassOperation { get; set; }

        public ActivityKind Kind { get; set; }

        public dynamic RawData
        {
            get { return new JavaScriptSerializer().Deserialize<dynamic>(Data); }

            set { Data = new JavaScriptSerializer().Serialize(value); }
        }

        public Thread Thread { get; set; }

        public int UserId { get; set; }

        #endregion Properties 
    }
}