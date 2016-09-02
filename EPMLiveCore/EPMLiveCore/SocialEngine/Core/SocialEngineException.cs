using System;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class SocialEngineException : Exception
    {
        #region Fields (1) 

        private readonly LogKind _logKind;

        #endregion Fields 

        #region Constructors (1) 

        public SocialEngineException(string message, LogKind logKind = LogKind.Error) : base(message)
        {
            _logKind = logKind;
        }

        #endregion Constructors 

        #region Properties (1) 

        public LogKind LogKind
        {
            get { return _logKind; }
        }

        #endregion Properties 
    }
}