using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace EPMLiveCore.Infrastructure
{
    public sealed class CacheStore : IDisposable
    {
        #region Fields (7) 

        private static volatile CacheStore _instance;
        private static readonly object Locker = new Object();
        private readonly List<string> _indefiniteKeys;
        private readonly Dictionary<string, Tuple<CacheStoreCategory, CachedValue>> _store;
        private readonly Timer _timer;
        private bool _disposed;
        private long _ticks;

        #endregion Fields 

        #region Constructors (2) 

        private CacheStore()
        {
            _store = new Dictionary<string, Tuple<CacheStoreCategory, CachedValue>>();
            _indefiniteKeys = new List<string>();
            _ticks = DateTime.Now.Ticks;
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

        // Public Methods (3) 

        public CachedValue Get(string key, CacheStoreCategory category, Func<object> getValue,
            bool keepIndefinite = false)
        {
            string originalKey = key;
            key = BuildKey(key);

            if (_store.ContainsKey(key)) return _store[key].Item2;

            Set(originalKey, getValue(), category, keepIndefinite);

            return _store[key].Item2;
        }

        public void Remove(string key)
        {
            key = BuildKey(key);

            if (!_store.ContainsKey(key)) return;

            lock (Locker)
            {
                _store.Remove(key);
            }
        }

        public void Set(string key, object value, CacheStoreCategory category, bool keepIndefinite = false)
        {
            if (keepIndefinite)
            {
                if (!_indefiniteKeys.Contains(key))
                {
                    lock (Locker)
                    {
                        _indefiniteKeys.Add(key);
                    }
                }
            }

            key = BuildKey(key);

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

        // Private Methods (3) 

        private string BuildKey(string key)
        {
            return _indefiniteKeys.Contains(key) ? key : key + "_" + _ticks;
        }

        private void Cleanup(object state)
        {
            Debugger.Break();

            long ticks = _ticks;

            lock (Locker)
            {
                _ticks = DateTime.Now.Ticks;
            }

            // Wait for 30 seconds just in-case if 
            // something is still using an old key

            Thread.Sleep(30000);

            string oldTicks = "_" + ticks;

            IEnumerable<string> keys = _store.Keys.Where(key => key.EndsWith(oldTicks));

            lock (Locker)
            {
                foreach (string key in keys)
                {
                    _store.Remove(key);
                }
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