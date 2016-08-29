using System.Collections.Generic;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class DataValidator
    {
        #region Fields (1) 

        private readonly Dictionary<string, object> _data;

        #endregion Fields 

        #region Constructors (1) 

        public DataValidator(Dictionary<string, object> data)
        {
            _data = data;
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public void Validate(Dictionary<string, DataType> rules)
        {
            foreach (var rule in rules)
            {
                if (!_data.ContainsKey(rule.Key)) throw new SocialEngineException(rule.Key + " is required.");

                object value = _data[rule.Key];

                switch (rule.Value)
                {
                    case DataType.String:
                        if (!value.IsNonEmptyString())
                            throw new SocialEngineException(value + " is not a valid string.");
                        break;
                    case DataType.Int:
                        if (!value.IsInt()) throw new SocialEngineException(value + " is not a valid integer.");
                        break;
                    case DataType.Guid:
                        if (!value.IsGuid()) throw new SocialEngineException(value + " is not a valid GUID.");
                        break;
                    case DataType.DateTime:
                        if (!value.IsDateTime()) throw new SocialEngineException(value + " is not a valid date time.");
                        break;
                }
            }
        }

        #endregion Methods 
    }
}