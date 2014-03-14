using System;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class Transaction
    {
        #region Constructors (2) 

        public Transaction(Guid id, Guid webId, Guid listId, int itemId, string component, DateTime time)
        {
            Component = component;
            ItemId = itemId;
            ListId = listId;
            WebId = webId;
            Id = id;
            Time = time;
        }

        public Transaction(Guid webId, Guid listId, int itemId, string component, DateTime time)
            : this(Guid.NewGuid(), webId, listId, itemId, component, time) { }

        #endregion Constructors 

        #region Properties (6) 

        public string Component { get; private set; }

        public Guid Id { get; private set; }

        public int ItemId { get; private set; }

        public Guid ListId { get; private set; }

        public DateTime Time { get; private set; }

        public Guid WebId { get; private set; }

        #endregion Properties 
    }
}