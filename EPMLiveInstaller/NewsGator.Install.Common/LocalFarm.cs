using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using NewsGator.Install.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NewsGator.Install.Common
{
    internal static class LocalFarm
    {
        private const string Key2010 = @"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\14.0\Secure\ConfigDB";
        private const string Key2013 = @"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\15.0\Secure\ConfigDB";
        private const string Key2016 = @"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\16.0\Secure\ConfigDB";
        private const string Key2010WOW = @"SOFTWARE\Wow6432Node\Microsoft\Shared Tools\Web Server Extensions\14.0\Secure\ConfigDB";
        private const string Key2013WOW = @"SOFTWARE\Wow6432Node\Microsoft\Shared Tools\Web Server Extensions\15.0\Secure\ConfigDB";
        private const string Key2016WOW = @"SOFTWARE\Wow6432Node\Microsoft\Shared Tools\Web Server Extensions\16.0\Secure\ConfigDB";
        private const string PropertyDSN = "dsn";

        private static List<string> ConfigDBKeys = new List<string> { Key2016, Key2016WOW, Key2013, Key2013WOW, Key2010, Key2010WOW };

        internal static SPFarm Get()
        {
            var connectionString = string.Empty;
            var exceptions = new List<Exception>();
            
            var localMachine = Registry.LocalMachine;

            ConfigDBKeys.ForEach((key) => {
                if (string.IsNullOrEmpty(connectionString))
                {
                    try
                    {
                        var subkey = localMachine.OpenSubKey(key);
                        if (null != subkey)
                        {
                            connectionString = (string) subkey.GetValue(PropertyDSN);
                        }
                    }
                    catch (Exception exception)
                    {
                        exceptions.Add(exception);
                    }
                }
            });

            if (string.IsNullOrEmpty(connectionString))
            {
                var exString = string.Empty;
                foreach (var exception in exceptions)
                {
                    exString += ParseException(exception);
                }
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, Exceptions.SPFarmException, exString));                
            }

            return SPFarm.Open(connectionString);
        }

        private const string _logExceptionFormat = "### Exception ###\r\nMessage:\r\n{0} \r\n\r\nDetails:\r\n{1} \r\n\r\nStack Trace:\r\n{2}";
        private const string _logExceptionFileLoadFormat = "\r\n\r\nFile Name:\r\n{0} \r\n\r\nFusion Log:\r\n{1}";
        private const string _logExceptionFileLoadDataFormat = "\r\n\r\nData:\r\nKey: '{0}' - Value: '{1}";
        private const string _logExceptionInnerFormat = "\r\n\r\n### Inner Exception ###\r\n{0}";

        private static string ParseException(Exception exception)
        {
            var exceptionString = string.Format(CultureInfo.InvariantCulture, _logExceptionFormat, exception.Message, exception.ToString(), exception.StackTrace);

            var fileLoadException = exception as FileLoadException;
            if (fileLoadException != null)
            {
                exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionFileLoadFormat, fileLoadException.FileName, fileLoadException.FusionLog);
                if (fileLoadException.Data != null)
                {
                    foreach (DictionaryEntry entry in fileLoadException.Data)
                    {
                        exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionFileLoadDataFormat, entry.Key, entry.Value);
                    }
                }
            }

            if (exception.InnerException != null && exception != exception.InnerException)
                exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionInnerFormat, ParseException(exception.InnerException));

            return exceptionString;
        }        
    }
}
