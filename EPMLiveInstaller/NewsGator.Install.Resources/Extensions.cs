using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace NewsGator.Install.Resources
{
    public static class Extensions
    {
        public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
        {
            if (destination == null || source == null)
                return;

            foreach (T item in source)
            {
                destination.Add(item);
            }
        }

        public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return null;

            var collection = new Collection<T>();
            foreach (T i in enumerable)
                collection.Add(i);
            return collection;
        }
    }
}
