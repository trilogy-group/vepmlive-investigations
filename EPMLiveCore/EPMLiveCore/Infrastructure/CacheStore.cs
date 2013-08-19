using System;
using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure
{
    public sealed class CacheStore
    {
        private static volatile CacheStore _instance;
        private static readonly object Locker = new Object();

        private readonly Dictionary<string, CachedValue> _store;

        private CacheStore()
        {
            _store = new Dictionary<string, CachedValue>();
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

        public CachedValue Get(string key)
        {
            return _store.ContainsKey(key) ? _store[key] : null;
        }

        public void Set(string key, object value)
        {
            lock (Locker)
            {
                if (!_store.ContainsKey(key))
                {
                    _store.Add(key, new CachedValue(value));
                }
                else
                {
                    _store[key].Value = value;
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

    public class CachedValue
    {
        private object _value;

        public CachedValue(object value)
        {
            CreatedAt = DateTime.Now;
            Value = value;
        }

        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdatedAt = DateTime.Now;
            }
        }

        public DateTime UpdatedAt { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}