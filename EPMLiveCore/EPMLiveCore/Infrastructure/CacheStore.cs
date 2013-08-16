using System;
using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure
{
    public sealed class CacheStore
    {
        private static volatile CacheStore _instance;
        private static readonly object Locker = new Object();

        private readonly Dictionary<string, object> _store;

        private CacheStore()
        {
            _store = new Dictionary<string, object>();
        }

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

        public object Get(string key)
        {
            return _store.ContainsKey(key) ? _store[key] : null;
        }

        public void Set(string key, object val)
        {
            lock (Locker)
            {
                if (!_store.ContainsKey(key))
                {
                    _store.Add(key, val);
                }
                else
                {
                    _store[key] = val;
                }
            }
        }

        public void Remove(string key)
        {
            if (!_store.ContainsKey(key)) return;

            lock (Locker)
            {
                _store.Remove(key);
            }
        }
    }
}