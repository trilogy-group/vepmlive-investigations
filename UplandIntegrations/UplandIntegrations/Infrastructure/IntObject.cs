using System;

namespace UplandIntegrations.Infrastructure
{
    internal class IntObject
    {
        #region Fields (3) 

        private readonly Exception _exception;
        private readonly object _item;
        private readonly string _itemId;

        #endregion Fields 

        #region Constructors (2) 

        public IntObject(string itemId, object item)
        {
            _itemId = itemId;
            _item = item;
        }

        public IntObject(string itemId, Exception exception)
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

        public string ItemId
        {
            get { return _itemId; }
        }

        #endregion Properties 
    }
}