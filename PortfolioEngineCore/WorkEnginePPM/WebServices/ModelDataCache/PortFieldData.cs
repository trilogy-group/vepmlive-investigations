using System;

namespace ModelDataCache
{
    [Serializable()]
    class PortFieldData
    {
        public int ID, Editable, Required, Identity, Visible, Frozen, Sequence;
        public string Name, GivenName;
    }
}
