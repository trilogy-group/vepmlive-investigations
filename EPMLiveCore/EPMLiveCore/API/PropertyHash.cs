using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EPMLiveCore.API
{
    public class PropertyHash : IDictionary<int, Dictionary<object, object>>
    {

        private Dictionary<int, Dictionary<object, object>> _props = new Dictionary<int, Dictionary<object, object>>();
        private string _CollectionSeperator;
        private char _ItemSeperator;
        private char _KeySeperator;

        public IEnumerator<KeyValuePair<int, Dictionary<object, object>>> GetEnumerator()
        {
            return _props.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary)this).GetEnumerator();
        }

        public void Add(KeyValuePair<int, Dictionary<object, object>> pair)
        {
            _props.Add(pair.Key, pair.Value);
        }

        public void Add(int key, Dictionary<object, object> value)
        {
            _props.Add(key, value);
        }

        public void Add(string values)
        {
            Dictionary<object, object> d = new Dictionary<object, object>();
            int counter = 0;
            foreach(string value in values.Split(_ItemSeperator))
            {
                if(_KeySeperator != '\0')
                {
                    string[] sVals = value.Split(_KeySeperator);
                    if(sVals.Length > 1)
                    {
                        d.Add(sVals[0], sVals[1]);
                    }
                    else
                    {
                        d.Add(counter++, value);
                    }
                }
                else
                    d.Add(counter++, value);
            }
            KeyValuePair<int, Dictionary<object, object>> oLasts = _props.Last();

            _props.Add(oLasts.Key + 1, d);
        }

        public ICollection<int> Keys
        {
            get
            {
                return _props.Keys;
            }
        }

        public ICollection<Dictionary<object, object>> Values
        {
            get
            {
                return _props.Values;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Update(int key, string val)
        {
            Dictionary<object, object> d = new Dictionary<object, object>();
            int counter = 0;
            foreach(string v in val.Split(_ItemSeperator))
            {
                if(_KeySeperator != '\0')
                {
                    string[] sVals = v.Split(_KeySeperator);
                    if(sVals.Length > 1)
                    {
                        d.Add(sVals[0], sVals[1]);
                    }
                    else
                    {
                        d.Add(counter++, v);
                    }
                }
                else
                    d.Add(counter++, v);
            }

            _props[key] = d; 
            
        }

        public Dictionary<object, object> this[int val] 
        {
            get { return _props[val]; }
            set { _props[val] = value; } 
        }

        public bool Remove(KeyValuePair<int, Dictionary<object, object>> pair)
        {
            return _props.Remove(pair.Key);
        }

        public bool Remove(int key)
        {
            if(_props.ContainsKey(key))
            {
                _props.Remove(key);
                return true;
            }
            else
                return false;
        }

        public void Clear()
        {
            _props.Clear();
        }

        public bool TryGetValue(int key, out Dictionary<object, object> val)
        {
            return _props.TryGetValue(key, out val);
        }

        public bool Contains(KeyValuePair<int, Dictionary<object, object>> pair)
        {
            return false;
        }

        public void CopyTo(KeyValuePair<int, Dictionary<object, object>>[] pair, int i)
        {
            throw new Exception("Not Implemented");
        }

        public bool ContainsKey(int key)
        {
            return _props.ContainsKey(key);
        }

        public int Count
        {
            get
            {
                return _props.Keys.Count;
            }
        }

        public PropertyHash(string values, string CollectionSeperator, char ItemSeperator, char KeySeperator)
        {
            loadProps(values, CollectionSeperator, ItemSeperator, KeySeperator);
        }

        public PropertyHash(string values)
        {
            loadProps(values, ";#", '|', '\0');
        }

        private void loadProps(string values, string CollectionSeperator, char ItemSeperator, char KeySeperator)
        {

            _CollectionSeperator = CollectionSeperator;
            _ItemSeperator = ItemSeperator;
            _KeySeperator = KeySeperator;

            int counter = 0;
            foreach(string value in values.Replace(CollectionSeperator,"\n").Split('\n'))
            {
                _props.Add(counter, GetKeyValue(value, ItemSeperator, KeySeperator));
                counter++;
            }
        }

        private Dictionary<object, object> GetKeyValue(string values, char ItemSeperator, char KeySeperator)
        {
            Dictionary<object, object> _p = new Dictionary<object, object>();

            int counter = 0;

            if(values != "")
            {
                foreach(string value in values.Split(ItemSeperator))
                {
                    if(KeySeperator != '\0' && value != "")
                    {
                        string[] sVals = value.Split(KeySeperator);
                        if(sVals.Length > 1)
                        {
                            _p.Add(sVals[0], sVals[1]);
                        }
                        else
                        {
                            _p.Add(counter++, value);
                        }
                    }
                    else
                        _p.Add(counter++, value);
                }
            }

            return _p;
        }

        override public string ToString()
        {
            StringBuilder sbStr = new StringBuilder();

            foreach(KeyValuePair<int, Dictionary<object, object>> de in _props)
            {
                sbStr.Append(_CollectionSeperator);

                StringBuilder sbProps = new StringBuilder();

                //foreach(Dictionary<object, object> de2 in de.Value)
                {
                    foreach(KeyValuePair<object,object> item in ((Dictionary<object, object>)de.Value))
                    {
                        if(_KeySeperator != '\0')
                        {
                            sbProps.Append(item.Key);
                            sbProps.Append(_KeySeperator);
                            sbProps.Append(item.Value);
                        }
                        else
                            sbProps.Append(item.Value);
                        sbProps.Append(_ItemSeperator);
                    }
                }

                sbStr.Append(sbProps.ToString().Trim(_ItemSeperator));
            }
            return sbStr.ToString().Trim(_CollectionSeperator.ToCharArray());
        }
    }
}
