using System.Windows.Forms;
using System.Runtime.InteropServices;

public class UserNameChecker
{
    public const int Logon32ProviderDefault = 0x0;
    // To validate the account
    public const int Logon32LogonNetwork = 0x3;
    // API declaration for validating user credentials
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out int phToken);
    //API to close the credential token
    [DllImport("kernel32", EntryPoint = "CloseHandle")]
    public static extern long CloseHandle(long hObject);

    public static string CheckUsername(string username, string password)
    {
        string domain;

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

        int hToken;
        bool ret = LogonUser(username, domain, password, Logon32LogonNetwork, Logon32ProviderDefault, out hToken);

        if (ret)
        {
            CloseHandle(hToken);
            return "1";
        }

        MessageBox.Show("Invalid Login.");
        return "3";
    }
}

