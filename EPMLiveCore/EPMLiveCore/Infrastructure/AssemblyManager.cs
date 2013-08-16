using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPMLiveCore.Infrastructure
{
    public sealed class AssemblyManager
    {
        private static volatile AssemblyManager _instance;
        private static readonly object Locker = new Object();
        private readonly IEnumerable<Type> _types;

        private AssemblyManager()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
        }

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

        public IEnumerable<Type> GetTypes()
        {
            return _types;
        }
    }
}