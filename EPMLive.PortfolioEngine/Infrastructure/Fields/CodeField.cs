namespace PortfolioEngineCore.Infrastructure.Fields
{
    public sealed class CodeField : PFEField
    {
        #region Fields (2) 

        private int _code;
        private string _value;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeField"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public CodeField(int id, string name) : base(id, name)
        {
            _value = string.Empty;
        }

        #endregion Constructors 

        #region Methods (5) 

        // Public Methods (5) 

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <returns></returns>
        public int GetCode()
        {
            return _code;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Sets the code.
        /// </summary>
        /// <param name="code">The code.</param>
        public void SetCode(int code)
        {
            _code = code;
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
            return string.Format("{0}:{1}", _code, _value);
        }

        #endregion Methods 
    }
}