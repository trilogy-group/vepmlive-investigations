using System;
using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure
{
    public sealed class CacheStore
    {
        private static volatile CacheStore _instance;
        private static readonly object Locker = new Object();

        private readonly Dictionary<string, Tuple<string, CachedValue>> _store;

        private CacheStore()
        {
            _store = new Dictionary<string, Tuple<string, CachedValue>>();
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

        public CachedValue Get(string key, string category, Func<object> getValue)
        {
            key = key.Trim().ToUpper();
            category = category.Trim().ToUpper();

            if (_store.ContainsKey(key)) return _store[key].Item2;

            Set(key, getValue(), category);

            return _store[key].Item2;
        }

        public CachedValue Get(string key)
        {
            key = key.Trim().ToUpper();
            return _store.ContainsKey(key) ? _store[key].Item2 : null;
        }

        public void Set(string key, object value, string category)
        {
            key = key.Trim().ToUpper();
            category = category.Trim().ToUpper();

            lock (Locker)
            {
                if (!_store.ContainsKey(key))
                {
                    _store.Add(key, new Tuple<string, CachedValue>(category, new CachedValue(value)));
                }
                else
                {
                    _store[key].Item2.Value = value;
                }
            }
        }

        public void Remove(string key)
        {
            key = key.Trim().ToUpper();

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

        public DateTime UpdatedAt { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime LastReadAt { get; private set; }
    }
}