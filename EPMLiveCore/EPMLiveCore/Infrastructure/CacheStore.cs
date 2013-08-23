using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EPMLiveCore.Infrastructure
{
    public sealed class CacheStore : IDisposable
    {
        #region Fields (5) 

        private static volatile CacheStore _instance;
        private static readonly object Locker = new Object();
        private readonly Dictionary<string, Tuple<CacheStoreCategory, CachedValue>> _store;
        private readonly Timer _timer;
        private bool _disposed;

        #endregion Fields 

        #region Constructors (2) 

        private CacheStore()
        {
            _store = new Dictionary<string, Tuple<CacheStoreCategory, CachedValue>>();
            _timer = new Timer(Cleanup, null, 300000, 300000);
        }

        ~CacheStore()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (1) 

        public static CacheStore Current
        {
            get
            {
                if (_instance != null) return _instance;

                lock (Locker)
                {
                    if (_instance == null)
                    {
                        _instance = new CacheStore();
                    }
                }

                return _instance;
            }
        }

        #endregion Properties 

        #region Methods (6) 

        // Public Methods (4) 

        public CachedValue Get(string key)
        {
            return _store.ContainsKey(key) ? _store[key].Item2 : null;
        }

        public CachedValue Get(string key, CacheStoreCategory category, Func<object> getValue)
        {
            if (_store.ContainsKey(key)) return _store[key].Item2;

            Set(key, getValue(), category);

            return _store[key].Item2;
        }

        public void Remove(string key)
        {
            if (!_store.ContainsKey(key)) return;

            lock (Locker)
            {
                _store.Remove(key);
            }
        }

        public void Set(string key, object value, CacheStoreCategory category)
        {
            lock (Locker)
            {
                if (!_store.ContainsKey(key))
                {
                    _store.Add(key, new Tuple<CacheStoreCategory, CachedValue>(category, new CachedValue(value)));
                }
                else
                {
                    _store[key].Item2.Value = value;
                }
            }
        }

        // Private Methods (2) 

        private void Cleanup(object state)
        {
            var dateTime = new DateTime();

            lock (Locker)
            {
                var locker = new object();

                var keys = new List<string>();

                Parallel.ForEach(_store, pair =>
                {
                    if ((dateTime - pair.Value.Item2.LastReadAt).Minutes <= 5) return;

                    lock (locker)
                    {
                        keys.Add(pair.Key);
                    }
                });

                Parallel.ForEach(keys, k => _store.Remove(k));
            }
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _timer.Dispose();
            }

            _disposed = true;
        }

        #endregion Methods 

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    public class CachedValue
    {
        #region Fields (1) 

        private object _value;

        #endregion Fields 

        #region Constructors (1) 

        public CachedValue(object value)
        {
            CreatedAt = DateTime.Now;
            Value = value;
        }

        #endregion Constructors 

        #region Properties (4) 

        public DateTime CreatedAt { get; private set; }

        public DateTime LastReadAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public object Value
        {
            get
            {
                LastReadAt = DateTime.Now;
                return _value;
            }
            set
            {
                _value = value;
                UpdatedAt = DateTime.Now;
            }
        }

        #endregion Properties 
    }
}