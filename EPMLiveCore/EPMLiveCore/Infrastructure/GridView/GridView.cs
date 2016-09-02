using EPMLiveCore.API;

namespace EPMLiveCore.Infrastructure
{
    public sealed class GridView
    {
        #region Fields (2) 

        public string Definition;
        private string _id;

        #endregion Fields 

        #region Properties (2) 

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(_id))
                {
                    _id = value;
                }
                else
                {
                    throw new APIException((int) Errors.GridViewCannotChangeId, "The GridView Id cannot be changed.");
                }
            }
        }

        public int Version { get; set; }

        #endregion Properties 
    }
}