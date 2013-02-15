namespace PortfolioEngineCore.Infrastructure.Fields
{
    public abstract class PFEField : IField
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="PFEField"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        protected PFEField(int id, string name)
        {
            Id = id;
            Name = name.Replace(" ", string.Empty);
        }

        #endregion Constructors 

        #region Implementation of IField

        public int Id { get; private set; }
        public string Name { get; private set; }
        public abstract object GetValue();
        public abstract void SetValue(object value);

        #endregion
    }
}