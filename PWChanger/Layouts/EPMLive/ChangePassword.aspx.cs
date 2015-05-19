using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPMLive
{
  public class ChangePassword : LayoutsPageBase
  {
    protected TextBox oldpassword;
    protected TextBox newpassword;
    protected TextBox checknewpassword;
    protected Button btn_ChangePassword;
    protected Button btn_Cancel;
    private string _domain;
    private string _loginName;
    static string sEventLogSource = "PWChanger";
    static string sEventLogName = "EPM Live";

    public ChangePassword() : base()
    {
        return;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
          
          //this._loginName = ((SPPrincipal)((UnsecuredLayoutsPageBase)this).get_Web().get_CurrentUser()).get_LoginName();
          this._loginName =  ((SPPrincipal)((UnsecuredLayoutsPageBase)this).Web.CurrentUser).LoginName;
      }
      catch (Exception ex)
      {
          LogError(ex.Message, (ex.InnerException != null ? ex.InnerException.Message : ex.Message), EventLogEntryType.Error);
          ((Page)this).ClientScript.RegisterClientScriptBlock(((object)this).GetType(), "clientScript", "<script type=\"text/javascript\">alert(\"Please sign in first.\");</script>");
      }
      this.btn_ChangePassword.Click += new EventHandler(this.btn_ChangePassword_Click);
      this.btn_Cancel.Click += new EventHandler(this.btn_Cancel_Click);
    }

    private void btn_Cancel_Click(object sender, EventArgs e)
    {
      ((Page) this).ClientScript.RegisterClientScriptBlock(((object) this).GetType(), "clientScript", "<script type=\"text/javascript\">window.frameElement.commonModalDialogClose(0, 0);</script>");
    }

    public void btn_ChangePassword_Click(object sender, EventArgs e)
    {
      if (this.newpassword.Text != this.checknewpassword.Text)
        ((Page) this).ClientScript.RegisterClientScriptBlock(((object) this).GetType(), "clientScript", "<script type=\"text/javascript\">alert(\"Passwords do not match.\");</script>");
      else if (!this.ValidateUserPassword(this._loginName, this.oldpassword.Text))
      {
        ((Page) this).ClientScript.RegisterClientScriptBlock(((object) this).GetType(), "clientScript", "<script type=\"text/javascript\">alert(\"Current password is incorrect.\");</script>");
      }
      else
      {
        try
        {
          this.ChangeADPassword(this._loginName, this.oldpassword.Text, this.newpassword.Text);
          this.ReturnStatus("success");
        }
        catch (Exception ex)
        {
            this.LogError(ex.Message, (ex.InnerException != null ? ex.InnerException.Message : ex.Message), EventLogEntryType.Error);
            this.ReturnStatus("fail");
        }
      }
    }

    private void ReturnStatus(string status)
    {
      switch (status.ToLower())
      {
        case "success":
          ((Page) this).ClientScript.RegisterClientScriptBlock(((object) this).GetType(), "clientScript", "<script type=\"text/javascript\">window.frameElement.commonModalDialogClose(1, \"success\");</script>");
          break;
        case "fail":
          ((Page) this).ClientScript.RegisterClientScriptBlock(((object) this).GetType(), "clientScript", "<script type=\"text/javascript\">window.frameElement.commonModalDialogClose(1, \"fail\");</script>");
          break;
        case "cancel":
          ((Page) this).ClientScript.RegisterClientScriptBlock(((object) this).GetType(), "clientScript", "<script type=\"text/javascript\">window.frameElement.commonModalDialogClose(1, \"cancel\");</script>");
          break;
      }
    }

    private bool ValidateUserPassword(string spLoginName, string password)
    {
        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, CoreFunctions.getMainDomain()))
        {
            bool flag = false;
            try
            {
                flag = principalContext.ValidateCredentials(CoreFunctions.GetCleanUserName(spLoginName), password);
            }
            catch (Exception ex)
            {
                this.LogError(ex.Message, (ex.InnerException != null ? ex.InnerException.Message : ex.Message), EventLogEntryType.Error);
            }

            if (!flag)
            {
                this.LogError("Error", "Couldn't authenticate.", EventLogEntryType.Error);
            }

            return flag;
        }
    }

    private bool ChangeADPassword(string spLoginName, string oldPassword, string newPassword)
    {
      string cleanUserName = CoreFunctions.GetCleanUserName(spLoginName);
      DirectoryEntry directoryEntry = new DirectorySearcher(new DirectoryEntry("LDAP://" + this.GetFullDomain(), cleanUserName, oldPassword))
      {
        Filter = ("(SAMAccountName=" + cleanUserName + ")"),
        SearchScope = SearchScope.Subtree
      }.FindOne().GetDirectoryEntry();
      bool flag;
      try
      {
        directoryEntry.Invoke("ChangePassword", (object) oldPassword, (object) newPassword);
        directoryEntry.CommitChanges();
        flag = true;
      }
      catch (Exception ex)
      {
        //this.LogError("Error", ex.Message,EventLogEntryType.Error);
          this.LogError(ex.Message, (ex.InnerException != null ? ex.InnerException.Message : ex.Message), EventLogEntryType.Error);
        throw new Exception(ex.Message);
      }
      return flag;
    }

    public void LogError(string heading, string error, EventLogEntryType logEntryType)
    {
        string sEvent = "Error Type: " + heading + "\r\nError message: " + error;

        SPSecurity.RunWithElevatedPrivileges(delegate()
        {
            try
            {
                if (!EventLog.SourceExists(sEventLogSource))
                    EventLog.CreateEventSource(sEventLogSource, sEventLogName);

                EventLog.WriteEntry(sEventLogSource, sEvent, logEntryType, 234);
            }
            catch (Exception ex) 
            {
                EventLog.WriteEntry(sEventLogSource, (ex.InnerException != null ? ex.InnerException.Message : ex.Message), logEntryType, 234); 
            }
        });
    }

    public string GetFullDomain()
    {
      string str1 = Domain.GetComputerDomain().ToString();
      string str2 = string.Empty;
      if (str1.Contains("."))
      {
        string str3 = str1;
        char[] chArray = new char[1]
        {
          ".".ToCharArray()[0]
        };
        foreach (string str4 in str3.Split(chArray))
          str2 = str2 + "DC=" + str4 + ",";
        str2 = str2.Remove(str2.LastIndexOf(","));
      }
      string str5;
      if (str2.Contains(","))
        str5 = str2.Split(",".ToCharArray()[0])[0].Replace("DC=", "");
      else
        str5 = str2.Replace("DC=", "");
      this._domain = str5;
      return str2;
    }
  }
}
