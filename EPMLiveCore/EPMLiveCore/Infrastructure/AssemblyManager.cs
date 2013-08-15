using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPMLiveCore.Infrastructure
{
    public sealed class AssemblyManager
    {
        public static volatile AssemblyManager Instance;
        public static object Locker = new Object();
        private readonly IEnumerable<Type> _types;

        private AssemblyManager()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
        }

        public static AssemblyManager Current
        {
            get
            {
                if (Instance != null) return Instance;

                lock (Locker)
                {
                    if (Instance == null)
                    {
                        Instance = new AssemblyManager();
                    }
                }

                return Instance;
            }
        }

        public IEnumerable<Type> GetTypes()
        {
            return _types;
        }
    }
}