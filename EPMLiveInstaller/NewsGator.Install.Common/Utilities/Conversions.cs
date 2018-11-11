using System.Collections;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.SharePoint;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Conversions
    {
        internal static Collection<SharePointProperty> GetSharePointPropertiesFromHashtable(Hashtable hashtable)
        {
            if (hashtable == null)
                return null;

            var properties = new Collection<SharePointProperty>();
            var keys = hashtable.Keys;

            foreach (var key in keys)
            {
                var value = hashtable[key];
                properties.Add(new SharePointProperty()
                {
                    Name = key.ToString(),
                    Value = value
                });
            }

            return properties;
        }
    }
}
