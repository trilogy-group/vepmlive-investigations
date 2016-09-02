using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMLiveCore
{
    public class EnhancedLookupConfigValuesHelper
    {
        public Dictionary<string, LookupConfigData> _fieldsData;
        private List<string> _parents;

        public EnhancedLookupConfigValuesHelper(string rawValue)
        {
            InitFieldsData(rawValue);
        }

        private void InitFieldsData(string rawValue)
        {
            _parents = new List<string>();

            if (_fieldsData == null)
            {
                _fieldsData = new Dictionary<string, LookupConfigData>();

                string[] fieldData = rawValue.Split('|');
                if (fieldData.Length > 0)
                {
                    foreach (string s in fieldData)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            LookupConfigData c = new LookupConfigData(s);
                            _fieldsData.Add(c.Field, c);
                            if (!string.IsNullOrEmpty(c.Parent))
                            {
                                _parents.Add(c.Parent.ToLower());
                            }
                        }
                    }
                }
            }
        }

        public LookupConfigData GetFieldData(string fieldIntName)
        {
            LookupConfigData result = null;

            if (_fieldsData != null)
            {
                if (_fieldsData.ContainsKey(fieldIntName))
                {
                    result = _fieldsData[fieldIntName];
                }
            }

            return result;
        }

        public List<string> GetSecuredFields()
        {
            List<string> result = null;

            if (_fieldsData != null)
            {
                result = (from KeyValuePair<string, LookupConfigData> d in _fieldsData
                          where d.Value.Security
                          select d.Value.Field).ToList();
            }

            return result;
        }

        public bool ContainsKey(string name)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(name) && _fieldsData != null)
            {
                result = _fieldsData.ContainsKey(name);
            }

            return result;
        }

        public bool IsParentField(string name)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(name) && _parents != null && _parents.Count > 0)
            {
                result = _parents.Contains(name.ToLower());
            }

            return result;
        }
    }

    public class LookupConfigData
    {
        private const string delimiter = "^";

        private string _field = string.Empty;
        private string _type = string.Empty;
        private string _parent = string.Empty;
        private string _parentListField = string.Empty;
        private bool _security = false;
        private bool _isParent = false;

        public string Field {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        public string ParentListField
        {
            get
            {
                return _parentListField;
            }
            set
            {
                _parentListField = value;
            }
        }
        public bool Security
        {
            get
            {
                return _security;
            }
            set
            {
                _security = value;
            }
        }

        public bool IsParent
        {
            get
            {
                return _isParent;
            }
            set
            {
                _isParent = value;
            }
        }

        public LookupConfigData()
        {
            Field = "";
            Type = "dropdown";
            Parent = "";
            ParentListField = "";
            Security = false;
            IsParent = false;
        }

        public LookupConfigData(string data)
        {
            string[] fieldData = data.Split(new[] { delimiter }, StringSplitOptions.None);
            Field = fieldData[0];
            Type = fieldData[1];
            Parent = fieldData[2];
            ParentListField = fieldData[3];
            try
            {
                Security = bool.Parse(fieldData[4]);
            }
            catch { }
        }
    }
}
