namespace PortfolioEngineCore.Infrastructure.Fields
{
    public sealed class TextField : PFEField
    {
        #region Fields (1) 

        private string _value;

        #endregion Fields 

        #region Constructors (1) 

        public TextField(int id, string name) : base(id, name)
        {
            _value = string.Empty;
        }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (3) 

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        public override void SetValue(object value)
        {
            _value = value as string ?? string.Empty;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _value;
        }

        #endregion Methods 
    }
}