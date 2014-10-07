namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure
{
    public interface IUpgradeStep
    {
        #region Data Members (1) 

        string Log { get; }

        #endregion Data Members 

        #region Operations (1) 

        bool Perform();

        #endregion Operations 
    }
}