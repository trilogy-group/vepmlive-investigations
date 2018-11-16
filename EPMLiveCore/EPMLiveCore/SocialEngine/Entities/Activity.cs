using System;
using System.Web.Script.Serialization;
using EPMLiveCore.SocialEngine.Core;

namespace EPMLiveCore.SocialEngine.Entities
{
    public class Activity
    {
        #region Fields (2) 

        private string _data;
        private string _key;

        #endregion Fields 

        #region Properties (7) 

        public DateTime Date { get; set; }

        public Guid Id { get; set; }

        public bool IsMassOperation { get; set; }

        public string Key
        {
            get { return !string.IsNullOrEmpty(_key) ? _key.ToUpper() : _key; }
            set { _key = !string.IsNullOrEmpty(value) ? value.ToUpper() : value; }
        }

        public ActivityKind Kind { get; set; }

        public Thread Thread { get; set; }

        public int UserId { get; set; }

        #endregion Properties 

        #region Methods (2) 

        // Public Methods (2) 

        public object GetData(bool raw = false)
        {
            return !raw
                ? (!string.IsNullOrEmpty(_data) ? new JavaScriptSerializer().Deserialize<dynamic>(_data) : null)
                : _data;
        }

        public void SetData(object data, bool isRaw = false)
        {
            if (isRaw) _data = (string) data;
            else
            {
                if (data != null)
                {
                    _data = new JavaScriptSerializer().Serialize(data);
                }
            }
        }

        #endregion Methods 
    }
}