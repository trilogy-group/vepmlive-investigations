using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPMLiveCore.Infrastructure
{
    public sealed class AssemblyManager
    {
        #region Fields (3) 

        private static volatile AssemblyManager _instance;
        private static readonly object Locker = new Object();
        private readonly IEnumerable<Type> _types;

        #endregion Fields 

        #region Constructors (1) 

        private AssemblyManager()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
        }

        #endregion Constructors 

        #region Properties (1) 

        public static AssemblyManager Current
        {
            get
            {
                if (_instance != null) return _instance;

                lock (Locker)
                {
                    if (_instance == null)
                    {
                        _instance = new AssemblyManager();
                    }
                }

                return _instance;
            }
        }

        #endregion Properties 

        #region Methods (1) 

        // Public Methods (1) 

        public IEnumerable<Type> GetTypes()
        {
            return _types;
        }

        #endregion Methods 
    }
}