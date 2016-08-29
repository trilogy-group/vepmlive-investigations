using System;

namespace EPMLiveCore.TagManager
{
    internal class TagOrder
    {
        #region Constructors (2) 

        public TagOrder(Guid id)
        {
            Id = id;
        }

        public TagOrder()
        {
        }

        #endregion Constructors 

        #region Properties (5) 

        public Guid Id { get; private set; }

        public int ItemId { get; set; }

        public Guid ListId { get; set; }

        public int Order { get; set; }

        public Guid TagId { get; set; }

        #endregion Properties 
    }
}