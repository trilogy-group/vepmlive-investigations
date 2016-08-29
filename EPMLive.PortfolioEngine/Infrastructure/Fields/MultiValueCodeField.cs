using System.Collections.Generic;
using System.Linq;

namespace PortfolioEngineCore.Infrastructure.Fields
{
    public class MultiValueCodeField : PFEField
    {
        #region Fields (1) 

        private Dictionary<int, string> _value;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiValueCodeField"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public MultiValueCodeField(int id, string name) : base(id, name)
        {
            _value = new Dictionary<int, string>();
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
            _value = (Dictionary<int, string>) value;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            List<string> list =
                _value.Select(keyValuePair => string.Format("{0}:{1}", keyValuePair.Key, keyValuePair.Value)).ToList();

            return string.Join(",", list.ToArray());
        }

        #endregion Methods 
    }
}