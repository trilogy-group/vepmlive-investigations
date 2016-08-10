using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


public class UserNameChecker
{
    public const int LOGON32_PROVIDER_DEFAULT = 0x0;
    // To validate the account
    public const int LOGON32_LOGON_NETWORK = 0x3;
    // API declaration for validating user credentials
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out int phToken);
    //API to close the credential token
    [DllImport("kernel32", EntryPoint = "CloseHandle")]
    public static extern long CloseHandle(long hObject);


    public static string CheckUsername(string username, string password)
    {
        string domain = "";

        if (username.Contains("\\"))
        {
            domain = username.Substring(0, username.IndexOf("\\"));
            username = username.Substring(username.IndexOf("\\") + 1);
        }
        else
        {
            MessageBox.Show("Please enter a username in the form of DOMAIN\\Username");
            return "2";
        }
        int hToken = 2;
        bool ret = LogonUser(username, domain, password, LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, out hToken);

        if (ret == true)
        {
            CloseHandle(hToken);
            return "1";
        }
        else
        {
            MessageBox.Show("Invalid Login.");
            return "3";
        }
    }
}

