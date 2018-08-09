using System;
using System.Reflection;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Reflection
    {
        internal static object ExecuteMethod(Type objectType, string methodName, Type[] parameterTypes, object[] parameterValues)
        {
            return ExecuteMethod(objectType, null, methodName, parameterTypes, parameterValues);
        }

        internal static object ExecuteMethod(Type objectType, object obj, string methodName, Type[] parameterTypes, object[] parameterValues)
        {
            if (objectType == null)
                return null;

            MethodInfo methodInfo = objectType.GetMethod(methodName, AllBindings, null, parameterTypes, null);
            try
            {
                if (methodInfo != null)
                    return methodInfo.Invoke(obj, parameterValues);
                else
                    return null;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

        }

        internal static PropertyInfo[] GetProperties(object obj)
        {
            if (obj == null)
                return null;

            return obj.GetType().GetProperties();
        }

        internal static void SetPropertyValue(object o, string propertyName, object value)
        {
            if (o == null || string.IsNullOrEmpty(propertyName))
                return;

            try
            {
                o.GetType().GetProperty(propertyName, AllBindings).SetValue(o, value, null);
            }
            catch (AmbiguousMatchException)
            {
                Type t = o.GetType();
                while (true)
                {
                    try
                    {
                        t.GetProperty(propertyName, AllBindings | BindingFlags.DeclaredOnly).SetValue(o, value, null);
                        break;
                    }
                    catch (NullReferenceException)
                    {
                        if (t.BaseType == null)
                            return;

                        t = t.BaseType;
                    }
                }
            }
        }

        internal static object GetPropertyValue(Type type, object o, string propertyName)
        {
            if (type == null || o == null || string.IsNullOrEmpty(propertyName))
                return null;

            try
            {
                return type.GetProperty(propertyName, AllBindings).GetValue(o, null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        internal static BindingFlags AllBindings
        {
            get
            {
                return BindingFlags.CreateInstance |
                    BindingFlags.FlattenHierarchy |
                    BindingFlags.GetField |
                    BindingFlags.GetProperty |
                    BindingFlags.IgnoreCase |
                    BindingFlags.Instance |
                    BindingFlags.InvokeMethod |
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.SetField |
                    BindingFlags.SetProperty |
                    BindingFlags.Static;
            }
        }
    }
}
