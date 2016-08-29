using System;

namespace EPMLiveCore.TagManager
{
    internal class Tag
    {
        #region Constructors (2) 

        public Tag(Guid id)
        {
            Id = id;
        }

        public Tag()
        {
        }

        #endregion Constructors 

        #region Properties (5) 

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public int ResourceId { get; set; }

        public Guid SiteId { get; set; }

        public int Type { get; set; }

        #endregion Properties 
    }
}