using EPMLiveCore.SocialEngine.Events;

namespace EPMLiveCore.SocialEngine.Contracts
{
    internal interface ISocialEngineModule
    {
        #region Operations (1) 

        void Initialize(SocialEngineEvents events);

        #endregion Operations 
    }
}