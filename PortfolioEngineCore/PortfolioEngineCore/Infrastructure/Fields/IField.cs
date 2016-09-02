namespace PortfolioEngineCore.Infrastructure.Fields
{
    public interface IField
    {
        #region Data Members (2) 

        int Id { get; }

        string Name { get; }

        #endregion Data Members 

        #region Operations (2) 

        object GetValue();

        void SetValue(object value);

        #endregion Operations 
    }
}