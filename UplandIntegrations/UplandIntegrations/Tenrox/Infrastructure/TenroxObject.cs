using System;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal sealed class TenroxObject
    {
        #region Fields (3) 

        private readonly Exception _exception;
        private readonly object _item;
        private readonly int _itemId;

        #endregion Fields 

        #region Constructors (2) 

        public TenroxObject(int itemId, object item)
        {
            _itemId = itemId;
            _item = item;
        }

        public TenroxObject(int itemId, Exception exception)
        {
            _itemId = itemId;
            _exception = exception;
        }

        #endregion Constructors 

        #region Properties (3) 

        public Exception Exception
        {
            get { return _exception; }
        }

        public object Item
        {
            get { return _item; }
        }

        public int ItemId
        {
            get { return _itemId; }
        }

        #endregion Properties 
    }
}