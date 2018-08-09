using System;
using System.Threading;
using Microsoft.Win32;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Utilities
{
    internal static class DebuggerRegistry
    {
        private static string _key1 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AeDebug";
        private static string _key1Property = "Debugger";
        private static string _key2 = "SOFTWARE\\Microsoft\\.NETFramework";
        private static string _key2Property = "DbgManagedDebugger";
        private static string _key3 = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion\\AeDebug";
        private static string _key3Property = "Debugger";
        private static string _key4 = "SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework";
        private static string _key4Property = "DbgManagedDebugger";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue DisableJustInTimeDebugger()
        {
            var outputQueue = new OutputQueue();
            try
            {
                outputQueue.Add(UserDisplay.DebuggerDisabling);

                var localMachine = Registry.LocalMachine;

                var key1 = localMachine.OpenSubKey(_key1, true);
                if (key1 != null)
                {
                    var key1value = key1.GetValue(_key1Property) as string;
                    if (!string.IsNullOrEmpty(key1value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key1, key1value, "null"));
                        key1.SetValue(_key1Property + "BAK", key1value);
                        key1.DeleteValue(_key1Property);
                    }
                    key1.Close();
                }

                var key2 = localMachine.OpenSubKey(_key2, true);
                if (key2 != null)
                {
                    var key2value = key2.GetValue(_key2Property) as string;
                    if (!string.IsNullOrEmpty(key2value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key2, key2value, "null"));
                        key2.SetValue(_key2Property + "BAK", key2value);
                        key2.DeleteValue(_key2Property);
                    }
                    key2.Close();
                }

                var key3 = localMachine.OpenSubKey(_key3, true);
                if (key3 != null)
                {
                    var key3value = key3.GetValue(_key3Property) as string;
                    if (!string.IsNullOrEmpty(key3value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key3, key3value, "null"));
                        key3.SetValue(_key3Property + "BAK", key3value);
                        key3.DeleteValue(_key3Property);
                    }
                    key3.Close();
                }

                var key4 = localMachine.OpenSubKey(_key4, true);
                if (key4 != null)
                {
                    var key4value = key4.GetValue(_key4Property) as string;
                    if (!string.IsNullOrEmpty(key4value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key4, key4value, "null"));
                        key4.SetValue(_key4Property + "BAK", key4value);
                        key4.DeleteValue(_key4Property);
                    }
                    key4.Close();
                }
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DebuggerDisableError, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue EnableJustInTimeDebugger()
        {
            var outputQueue = new OutputQueue();
            try
            {
                outputQueue.Add(UserDisplay.DebuggerEnabling);

                var localMachine = Registry.LocalMachine;

                var key1 = localMachine.OpenSubKey(_key1, true);
                if (key1 != null)
                {
                    var key1value = key1.GetValue(_key1Property + "BAK") as string;
                    if (!string.IsNullOrEmpty(key1value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key1, "null", key1value));
                        key1.SetValue(_key1Property, key1value);
                        key1.DeleteValue(_key1Property + "BAK");
                    }
                    key1.Close();
                }

                var key2 = localMachine.OpenSubKey(_key2, true);
                if (key2 != null)
                {
                    var key2value = key2.GetValue(_key2Property + "BAK") as string;
                    if (!string.IsNullOrEmpty(key2value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key2, "null", key2value));
                        key2.SetValue(_key2Property, key2value);
                        key2.DeleteValue(_key2Property + "BAK");
                    }
                    key2.Close();
                }

                var key3 = localMachine.OpenSubKey(_key3, true);
                if (key3 != null)
                {
                    var key3value = key3.GetValue(_key3Property + "BAK") as string;
                    if (!string.IsNullOrEmpty(key3value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key3, "null", key3value));
                        key3.SetValue(_key3Property, key3value);
                        key3.DeleteValue(_key3Property + "BAK");
                    }
                    key3.Close();
                }

                var key4 = localMachine.OpenSubKey(_key4, true);
                if (key4 != null)
                {
                    var key4value = key4.GetValue(_key4Property + "BAK") as string;
                    if (!string.IsNullOrEmpty(key4value))
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RegistryKeyUpdate, _key4, "null", key4value));
                        key4.SetValue(_key4Property, key4value);
                        key4.DeleteValue(_key4Property + "BAK");
                    }
                    key4.Close();
                }
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DebuggerEnableError, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }
    }
}
