using System;

namespace EPMLiveCore.Infrastructure
{
    public static class WEFeatures
    {
        #region Fields (1) 

        public static readonly Feature WEWebParts = new Feature(new Guid("b0af9b25-76d3-419d-9cfb-12e3b33fac2a"), "Work Engine Web Parts", Scope.Site);

        #endregion Fields 

        #region Enums (1) 

        public enum Scope
        {
            WebApplication,
            Site,
            Web
        }

        #endregion Enums 

        #region Nested Classes (1) 

        public class Feature
        {
            #region Constructors (1) 

            public Feature(Guid id, string title, Scope scope)
            {
                Id = id;
                Title = title;
                Scope = scope;
            }

            #endregion Constructors 

            #region Properties (3) 

            public Guid Id { get; private set; }

            public Scope Scope { get; private set; }

            public string Title { get; private set; }

            #endregion Properties 
        }

        #endregion Nested Classes 
    }
}