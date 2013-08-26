using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly Dictionary<string, Tuple<string, CachedValue>> _store;
        private readonly Timer _timer;
        private bool _disposed;
        private long _ticks;

        #endregion Fields 

        #region Constructors (2) 

        private CacheStore()
        {
            _store = new Dictionary<string, Tuple<string, CachedValue>>();
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

        #region Methods (9) 

        // Public Methods (5) 

        public CachedValue Get(string key, string category, Func<object> getValue,
            bool keepIndefinite = false)
        {
            string originalKey = key;
            key = BuildKey(key);

            if (_store.ContainsKey(key)) return _store[key].Item2;

            Set(originalKey, getValue(), category, keepIndefinite);

            return _store[keepIndefinite ? originalKey : key].Item2;
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("Key", typeof (string));
            dataTable.Columns.Add("Value", typeof (object));
            dataTable.Columns.Add("Category", typeof (string));
            dataTable.Columns.Add("CreatedAt", typeof (DateTime));
            dataTable.Columns.Add("UpdatedAt", typeof (DateTime));
            dataTable.Columns.Add("LastReadAt", typeof (DateTime));

            foreach (var pair in _store.OrderBy(p => p.Value.Item2.CreatedAt))
            {
                DataRow row = dataTable.NewRow();

                row["Key"] = pair.Key;
                row["Value"] = pair.Value.Item2.Value;
                row["Category"] = pair.Value.Item1;
                row["CreatedAt"] = pair.Value.Item2.CreatedAt;
                row["UpdatedAt"] = pair.Value.Item2.UpdatedAt;
                row["LastReadAt"] = pair.Value.Item2.LastReadAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
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

        public void RemoveCategory(string category)
        {
            List<string> keys = (from p in _store where p.Value.Item1.Equals(category) select p.Key).ToList();
            RemoveKeys(keys);
        }

        public void Set(string key, object value, string category, bool keepIndefinite = false)
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
                    _store.Add(key, new Tuple<string, CachedValue>(category, new CachedValue(value)));
                }
                else
                {
                    _store[key].Item2.Value = value;
                }
            }
        }

        // Private Methods (4) 

        private string BuildKey(string key)
        {
            return _indefiniteKeys.Contains(key) ? key : key + "_" + _ticks;
        }

        private void Cleanup(object state)
        {
            long ticks = _ticks;

            lock (Locker)
            {
                _ticks = DateTime.Now.Ticks;
            }

            // Wait for 30 seconds just in-case if 
            // something is still using an old key

            Thread.Sleep(30000);

            string oldTicks = "_" + ticks;

            IEnumerable<string> keys = _store.Keys.Where(key => key.EndsWith(oldTicks)).ToList();

            RemoveKeys(keys);
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

        private void RemoveKeys(IEnumerable<string> keys)
        {
            lock (Locker)
            {
                foreach (string key in keys)
                {
                    try
                    {
                        _store.Remove(key);
                    }
                    catch { }
                }
            }
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