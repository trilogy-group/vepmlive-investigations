using System;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class DisabledItemEventScope : SPItemEventReceiver, IDisposable
    {
        #region Fields (1) 

        private readonly bool _oldValue;

        #endregion Fields 

        #region Constructors (1) 

        public DisabledItemEventScope()
        {
            _oldValue = EventFiringEnabled;
            EventFiringEnabled = false;
        }

        #endregion Constructors 

        #region Implementation of IDisposable

        public void Dispose()
        {
            EventFiringEnabled = _oldValue;
        }

        #endregion
    }
}