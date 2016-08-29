namespace EPMLiveCore.Jobs.Upgrades.Steps
{
    public interface IStep
    {
        #region Data Members (2) 

        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the log.
        /// </summary>
        string Log { get; }

        #endregion Data Members 

        #region Operations (1) 

        /// <summary>
        /// Performs this instance.
        /// </summary>
        /// <returns></returns>
        bool Perform();

        #endregion Operations 
    }
}