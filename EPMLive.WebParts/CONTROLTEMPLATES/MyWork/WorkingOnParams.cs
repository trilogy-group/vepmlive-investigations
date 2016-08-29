namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    public class WorkingOnParams
    {
        #region Fields (1) 

        private readonly string _gridId;

        #endregion Fields 

        #region Constructors (1) 

        public WorkingOnParams(string gridId)
        {
            _gridId = gridId;
        }

        #endregion Constructors 

        #region Properties (1) 

        public string GridId
        {
            get { return _gridId; }
        }

        #endregion Properties 
    }
}