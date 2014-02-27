using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.SocialEngine.Entities
{
    internal class Activity
    {
        #region Properties (4) 

        public string Data { get; set; }

        public ActivityKind Kind { get; set; }

        public Thread Thread { get; set; }

        public int UserId { get; set; }

        #endregion Properties 
    }
}