using System;
using System.Globalization;
using System.Security.Permissions;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Collections;

namespace EPMLiveCore
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ResourcePoolEvent : SPItemEventReceiver
    {
        private bool isOnline = false;
        private int max = 0;
        private int count = 0;
        private bool expired = true;
        //private bool isUserInAccount = false;
        SqlConnection cn = null;
        private string ownerusername = "";
        private string owneremail;
        private Guid accountid;
        private int billingtype = 0;
        private int ActivationType = 0;

        private void loadData(SPList list, Guid siteuid)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    using(SPSite site = new SPSite(siteuid))
                    {
                        if(site.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
                        {
                            isOnline = true;

                            try
                            {
                                MethodInfo m;

                                Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                                Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                                m = thisClass.GetMethod("getConnectionStringByWebApp");
                                string sConn = (string)m.Invoke(null, new object[] { site.WebApplication.Name });

                                cn = new SqlConnection(sConn);
                                cn.Open();


                                SqlCommand cmd = new SqlCommand("2012SP_GetActivationInfo", cn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@siteid", siteuid);
                                cmd.Parameters.AddWithValue("@username", "");

                                DataSet ds = new DataSet();
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                da.Fill(ds);

                                try
                                {
                                    ActivationType = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                }
                                catch { }


                                cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@siteid", siteuid);
                                cmd.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel(site));

                                SqlDataReader dr = cmd.ExecuteReader();

                                if(dr.Read())
                                {
                                    try
                                    {
                                        expired = dr.GetBoolean(6);
                                    }
                                    catch { }
                                    max = dr.GetInt32(0);
                                    count = dr.GetInt32(1);
                                    accountid = dr.GetGuid(2);
                                    ownerusername = dr.GetString(13);
                                    owneremail = dr.GetString(14);
                                    billingtype = dr.GetInt32(11);
                                }
                                dr.Close();
                            }
                            catch
                            {
                                max = 0;
                            }
                        }
                    }
                }
                catch { }
            });
        }

        public override void ItemAdding(SPItemEventProperties properties)
        {
            loadData(properties.List, properties.SiteId);

            processItem(properties, true);

            try
            {
                if(isOnline)
                    cn.Close();
            }
            catch { }
        }

        private string GetProperty(SPItemEventProperties properties, string property)
        {
            try
            {
                if (properties.AfterProperties[property] == null)
                    return properties.ListItem[property].ToString();
                else
                    return properties.AfterProperties[property].ToString();
            }
            catch { }
            return "";
        }

        private void processItem(SPItemEventProperties properties, bool isAdd)
        {
            bool isGeneric = false;

            SPWeb web = properties.Web;

            try
            {
                bool.TryParse(GetProperty(properties, "Generic"), out isGeneric);
            }catch{}
            //try
            //{
            //    bool.TryParse(properties.ListItem["Generic"].ToString(), out isGeneric);
            //}
            //catch { }

            try
            {
                if(isGeneric)
                {
                    properties.AfterProperties["SharePointAccount"] = createGroup(properties);
                    if(properties.List.Fields.ContainsFieldWithInternalName("FirstName") && properties.List.Fields.ContainsFieldWithInternalName("LastName"))
                    {
                        properties.AfterProperties["FirstName"] = "";
                        properties.AfterProperties["LastName"] = "";
                    }

                    if(properties .List.Fields.ContainsFieldWithInternalName("Approved"))
                        properties.AfterProperties["Approved"] = "1";
                }
                else
                {
                    if(isAdd || (properties.ListItem != null && properties.ListItem["SharePointAccount"] != null))
                    {
                        if(isOnline)
                        {
                            if(properties.List.Fields.ContainsFieldWithInternalName("FirstName") && properties.List.Fields.ContainsFieldWithInternalName("LastName"))
                            {
                                try
                                {
                                    if(properties.AfterProperties["FirstName"] == null || properties.AfterProperties["FirstName"].ToString() == "")
                                    {
                                        string title = properties.AfterProperties["Title"].ToString();
                                        string[] sTitle = title.Split(' ');

                                        properties.AfterProperties["FirstName"] = sTitle[0];
                                        properties.AfterProperties["LastName"] = title.Substring(sTitle[0].Length + 1);
                                    }
                                    else
                                    {
                                        properties.AfterProperties["Title"] = properties.AfterProperties["FirstName"].ToString().Trim() + " " + properties.AfterProperties["LastName"].ToString().Trim();
                                    }
                                }
                                catch
                                {

                                }
                            }
                            
                            ProcessOnlineUser(properties, isAdd);
                            CoreFunctions.EnsureNoDuplicates(properties);
                            disableAccount(properties);
                        }
                        else
                        {
                            if(properties.List.Fields.ContainsFieldWithInternalName("FirstName") && properties.List.Fields.ContainsFieldWithInternalName("LastName"))
                            {
                                try
                                {
                                    if(properties.AfterProperties["FirstName"] == null || properties.AfterProperties["FirstName"].ToString() == "")
                                    {
                                        string title = properties.AfterProperties["Title"].ToString();
                                        string[] sTitle = title.Split(' ');

                                        properties.AfterProperties["FirstName"] = sTitle[0];
                                        properties.AfterProperties["LastName"] = title.Substring(sTitle[0].Length + 1);
                                    }
                                    else
                                    {
                                        properties.AfterProperties["Title"] = properties.AfterProperties["FirstName"].ToString().Trim() + " " + properties.AfterProperties["LastName"].ToString().Trim();
                                    }
                                }
                                catch { }
                            }
                            setPermissions(properties, isAdd);
                        }
                        ProcessLevel(properties);
                        ProcessDepartment(properties);

                    }
                }                
            }
            catch(Exception ex)
            {
                properties.Cancel = true;
                properties.ErrorMessage = "Error (2x1000): " + ex.Message;
            }

            try
            {
                int userId = 0;

                SPFieldUserValue uv = new SPFieldUserValue(properties.Web, GetPropertyBeforeOrAfter(properties, "SharePointAccount"));
                if(uv.User != null)
                {
                    userId = uv.LookupId;
                    Guid tJob = API.Timer.AddTimerJob(properties.SiteId, properties.Web.ID, "Process Security", 40, uv.User.ID.ToString(), "", 0, 99, "");
                    API.Timer.Enqueue(tJob, 0, properties.Web.Site);
                }
                else if(uv.LookupId == -1)
                {
                    SPUser u = properties.Web.EnsureUser(uv.LookupValue);
                    Guid tJob = API.Timer.AddTimerJob(properties.SiteId, properties.Web.ID, "Process Security", 40, u.ID.ToString(), "", 0, 99, "");
                    API.Timer.Enqueue(tJob, 0, properties.Web.Site);
                    userId = u.ID; 

                }

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (var site = new SPSite(properties.SiteId))
                    {
                        using (var w = site.OpenWeb())
                        {
                            SPList list = w.Lists["User Information List"];
                            list.GetItemById(userId).SystemUpdate();
                        }
                    }
                });

                


            }catch{}

            

        }

        private void ProcessDepartment(SPItemEventProperties properties)
        {

            string department = GetPropertyBeforeOrAfter(properties, "Department");

            if(department != "")
            {

                try
                {
                    SPList departmentlist = properties.Web.Lists["Departments"];
                    SPFieldLookupValue lv = new SPFieldLookupValue(department);
                    SPListItem li = departmentlist.GetItemById(lv.LookupId);
                    string deptGroup = li["Title"].ToString() + " Visitor";

                    SPGroup group = properties.Web.SiteGroups[deptGroup];
                    if(group != null)
                    {
                        SPFieldUserValue uv = new SPFieldUserValue(properties.Web, GetPropertyBeforeOrAfter(properties, "SharePointAccount"));

                        group.AddUser(uv.User);
                    }
                }
                catch { }

            }

        }

        private void ProcessLevel(SPItemEventProperties properties)
        {
            if(properties.Web.CurrentUser.IsSiteAdmin || (isOnline && EPMLiveCore.CoreFunctions.GetRealUserName(properties.Web.CurrentUser.LoginName, properties.Web.Site).ToLower() == ownerusername.ToLower()))
            {
                string spaccount = GetPropertyBeforeOrAfter(properties, "SharePointAccount");
                string ResLevel = GetPropertyBeforeOrAfter(properties, "ResourceLevel");

                if(!string.IsNullOrEmpty(spaccount) && !string.IsNullOrEmpty(ResLevel))
                {

                    string username = "";
                    try
                    {

                        SPFieldLookupValue uv = new SPFieldLookupValue(spaccount);
                        username = CoreFunctions.GetRealUserName(uv.LookupValue, properties.Web.Site);
                    }
                    catch { }

                    if(username != "")
                    {
                        Act act = new Act(properties.Web);
                        act.SetUserLevelV3(username, int.Parse(ResLevel));
                    }
                }
            }
        }

        private string GetPropertyBeforeOrAfter(SPItemEventProperties properties, string field)
        {
            string propval = "";

            if(properties.AfterProperties[field] != null)
            {
                try
                {
                    propval = properties.AfterProperties[field].ToString();
                }
                catch { }
            }
            else
            {
                try
                {
                    propval = properties.ListItem[field].ToString();
                }
                catch { }
            }

            return propval;
        }

        private void disableAccount(SPItemEventProperties properties)
        {
            bool isDisabled = false;
            try
            {
                isDisabled = bool.Parse(properties.AfterProperties["Disabled"].ToString());
            }
            catch { }
            if(isDisabled)
            {
                if(CoreFunctions.DoesCurrentUserHaveFullControl(properties.Web))
                {
                    properties.AfterProperties["Permissions"] = "";

                    try
                    {
                        SPFieldUserValue uv = null;

                        try
                        {
                            uv = new SPFieldUserValue(properties.Web, properties.AfterProperties["SharePointAccount"].ToString());
                        }
                        catch { }
                        if(uv == null)
                        {
                            try
                            {
                                uv = new SPFieldUserValue(properties.Web, properties.ListItem["SharePointAccount"].ToString());
                            }
                            catch { }
                        }
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using(SPSite oSite = new SPSite(properties.SiteId))
                            {
                                foreach(SPGroup webgroup in oSite.RootWeb.SiteGroups)
                                {
                                    try
                                    {
                                        webgroup.RemoveUser(uv.User);
                                    }
                                    catch { }
                                }
                            }
                        });
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        properties.AfterProperties["disabled"] = properties.ListItem[properties.List.Fields.GetFieldByInternalName("Disabled").Id];
                    }
                    catch { properties.AfterProperties["disabled"] = false; }
                }
            }
        }

        private void ProcessOnlineUser(SPItemEventProperties properties, bool isAdd)
        {
            string location = "1000";

            string sCurUsername = properties.UserLoginName;
            SPUser oCurUser = properties.Web.SiteUsers.GetByID(properties.CurrentUserId);
            bool bIsApproved = false;
            bool bIsNewUser = false;
            bool disablerequests = false;
            try
            {
                disablerequests = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(properties.Web, "OnlineDisableResReq"));
            }
            catch { }
            location = "1001";
            if(expired || max == 0)
            {
                properties.Cancel = true;
                properties.ErrorMessage = "Account is expired";
            }
            else
            {
                try
                {
                    MethodInfo m;

                    Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                    Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.FindOrCreateAccount", true, true);
                    
                    SqlCommand cmd;
                    location = "1002";
                    string newusername = "";
                    string newemail = "";
                    string newusernameclean = "";
                    string prefix = CoreFunctions.getPrefix(properties.Web.Site);
                    

                    if(isAdd)
                    {
                        location = "1003";
                        newemail = properties.AfterProperties["Email"].ToString().Trim();
                        properties.AfterProperties["Email"] = newemail;
                        location = "10031";
                        m = thisClass.GetMethod("FindUserName");
                        string founduser = (string)m.Invoke(null, new object[] { newemail });
                        location = "1004";

                        if(founduser == "")
                        {
                            location = "1005";
                            m = thisClass.GetMethod("CreateAccount");
                            string result = (string)m.Invoke(null, new object[] { properties.AfterProperties["FirstName"], properties.AfterProperties["LastName"], newemail, properties.SiteId, true });
                            location = "1006";
                            if(result.IndexOf("0:") == 0)
                            {
                                newusername = CoreFunctions.getMainDomain() + "\\" + result.Substring(2);
                                newusernameclean = result.Substring(2); 
                                location = "1007";

                                if(prefix != "")
                                    properties.AfterProperties["SharePointAccount"] = addUser(properties, newusernameclean, properties.AfterProperties["Title"].ToString(), newemail.ToString(), prefix);
                                else
                                    properties.AfterProperties["SharePointAccount"] = addUser(properties, newusername, properties.AfterProperties["Title"].ToString(), newemail, prefix);

                                bIsNewUser = true;
                                location = "1008";
                                cmd = new SqlCommand("INSERT INTO NEWACCOUNTEMAIL (username) VALUES (@username)", cn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@username", newusername);
                                cmd.ExecuteNonQuery();
                                location = "1009";
                            }
                            else
                            {
                                properties.Cancel = true;
                                properties.ErrorMessage = result;
                            }
                            location = "1010";
                        }
                        else
                        {
                            location = "1011";
                            newusername = CoreFunctions.getMainDomain() + "\\" + founduser;
                            newusernameclean = founduser;
                            location = "1012";

                            if(prefix != "")
                                properties.AfterProperties["SharePointAccount"] = addUser(properties, founduser, properties.AfterProperties["Title"].ToString(), newemail, prefix);
                            else
                                properties.AfterProperties["SharePointAccount"] = addUser(properties, newusername, properties.AfterProperties["Title"].ToString(), newemail, prefix);
                        }
                    }
                    else
                    {
                        location = "1013-1";

                        SPFieldUserValue uv = new SPFieldUserValue(properties.Web, properties.ListItem["SharePointAccount"].ToString());
                        location = "1014";
                        newusername = CoreFunctions.GetRealUserName(uv.User.LoginName, properties.Web.Site);
                        newusernameclean = CoreFunctions.GetJustUsername(uv.User.LoginName);
                        location = "1015";
                        newemail = uv.User.Email;
                        location = "1016";
                    }
                    location = "1017";
                    cmd = new SqlCommand("SP_IsUserInAccountSite", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@siteuid", properties.SiteId);
                    cmd.Parameters.AddWithValue("@username", newusername);

                    SqlDataReader dr = cmd.ExecuteReader();
                    location = "1018";
                    if(dr.Read())
                    {
                        if(dr.GetInt32(0) == 1)
                        {
                            bIsApproved = true;
                            properties.AfterProperties["Approved"] = "1";
                        }
                    }
                    dr.Close();
                    location = "1019";
                    bool bhaspermsadded = setPermissions(properties, isAdd);
                    location = "1020";
                    if(bIsApproved)//Approved (Already in account)
                    {
                        if(bhaspermsadded)
                        {
                            location = "1021";
                            m = thisClass.GetMethod("sendEmail");
                            bool sent = (bool)m.Invoke(null, new object[] { 2, newemail, new string[] { oCurUser.Name, properties.Web.Url, properties.Web.Title, newusernameclean } });
                        }
                    }
                    else//Assume we are adding user to account
                    {
                        if(oCurUser.IsSiteAdmin || disablerequests || properties.CurrentUserId == 1073741823)//if not in account and user is admin
                        {
                            location = "1022";
                            if(count < max || max == -1 || billingtype == 2 || ActivationType == 3 || GetPropertyBeforeOrAfter(properties, "ResourceLevel") == "0")//if we have enough accounts then we just accept it or billingtype = 2 (flexible recurring) or new v2 licensing or the user is set to no access
                            {
                                location = "1023";
                                bool bCurApproved = false;
                                try
                                {
                                    bCurApproved = bool.Parse(properties.ListItem["Approved"].ToString());
                                }
                                catch { }
                                location = "1024";


                                if(isAdd)
                                    properties.AfterProperties["Approved"] = "1";


                                location = "1025";
                                if((properties.AfterProperties["Approved"] == null || properties.AfterProperties["Approved"].ToString() == "1" || properties.AfterProperties["Approved"].ToString() == "True") && !bCurApproved)
                                {
                                    location = "1026";
                                    cmd = new SqlCommand("SELECT COUNT(*) FROM NEWACCOUNTEMAIL where username = @username", cn);
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@username", newusername);
                                    dr = cmd.ExecuteReader();
                                    location = "1027";
                                    if(dr.Read())
                                    {
                                        if(dr.GetInt32(0) > 0)
                                            bIsNewUser = true;
                                    }
                                    dr.Close();
                                    location = "1028";
                                    if(bIsNewUser)
                                    {
                                        m = thisClass.GetMethod("sendEmail");
                                        bool sent = (bool)m.Invoke(null, new object[] { 4, newemail, new string[] { newusernameclean, getTempPassword(newusername) } });
                                    }
                                    location = "1029";
                                    bool bHasPerms = false;
                                    try
                                    {
                                        if(properties.ListItem["Permissions"].ToString() != "")
                                            bHasPerms = true;
                                    }
                                    catch { }
                                    location = "1030";
                                    if(bhaspermsadded || bHasPerms)
                                    {
                                        m = thisClass.GetMethod("sendEmail");
                                        bool sent = (bool)m.Invoke(null, new object[] { 2, newemail, new string[] { oCurUser.Name, properties.Web.Url, properties.Web.Title, newusernameclean } });
                                    }
                                    location = "1031";
                                }

                                if(ActivationType == 3)
                                {
                                    if(!oCurUser.IsSiteAdmin)
                                        sendRequestEmail(thisClass, properties, oCurUser.Name);
                                }
                                else
                                {
                                    addUserToAccount("", "", newemail, newusername);
                                }
                                location = "1032";
                            }
                            else//if we don't have enough accounts
                            {
                                location = "1033";
                                if(properties.AfterProperties["Approved"] == null || properties.AfterProperties["Approved"].ToString() == "1" || properties.AfterProperties["Approved"].ToString() == "True")//if we are trying to approve an account and we don't have enough
                                {
                                    location = "1034";
                                    if(EPMLiveCore.CoreFunctions.GetRealUserName(sCurUsername, properties.Web.Site).ToLower() != ownerusername.ToLower())
                                    {
                                        sendOwnerEmail(thisClass, properties, oCurUser.Name);
                                    }
                                    else
                                    {
                                        properties.Cancel = true;
                                        properties.ErrorMessage = "Error: You do not have enough accounts.";
                                    }
                                    location = "1035";
                                }
                                properties.AfterProperties["Approved"] = "0";
                            }
                        }
                        else//If not in account and user is not an admin send a request
                        {
                            location = "1036";
                            sendRequestEmail(thisClass, properties, oCurUser.Name);
                        }
                        location = "1037";
                    }
                }
                catch(Exception ex)
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = "Error (" + location + "): " + ex.Message;
                }
            }
        }

        private void addUserToAccount(string firstname, string lastname, string email, string username)
        {
            SqlCommand cmd = new SqlCommand("SP_AddAccountUserByUsername", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@first", firstname);
            cmd.Parameters.AddWithValue("@last", lastname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@account_id", accountid);
            cmd.ExecuteNonQuery();
        }

        private string getTempPassword(string username)
        {
            
            DataSet ds;
            SqlCommand cmdGetPassword;
            SqlDataAdapter da;

            cmdGetPassword = new SqlCommand("SP_GetPassword", cn);
            cmdGetPassword.CommandType = CommandType.StoredProcedure;
            cmdGetPassword.Parameters.AddWithValue("@username", username);

            da = new SqlDataAdapter(cmdGetPassword);
            ds = new DataSet();
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return "";
        }

        private bool setPermissions(SPItemEventProperties properties, bool isAdd)
        {
            if(!properties.List.Fields.ContainsFieldWithInternalName("Permissions"))
            {
                return false;
            }
            string curProps = "";
            string newProps = "";
            bool sendEmail = false;

            try
            {
                
                SPFieldUserValue uv = null;
                if(isAdd)
                    uv = new SPFieldUserValue(properties.Web, properties.AfterProperties["SharePointAccount"].ToString());
                else
                    uv = new SPFieldUserValue(properties.Web, properties.ListItem["SharePointAccount"].ToString());

                SPUser u = uv.User;
                if(u == null)
                {
                    u = properties.Web.EnsureUser(uv.LookupValue);
                }

                try
                {
                    curProps = properties.ListItem["Permissions"].ToString().Trim();
                }
                catch { }

                try
                {
                    newProps = properties.AfterProperties["Permissions"].ToString();
                }
                catch { return false; }

                ArrayList arr = new ArrayList(newProps.Split(','));

                var webGroups = APITeam.GetWebGroups(properties.Web);

                foreach (SPGroup group in webGroups)
                {
                    if (arr.Contains(group.ID.ToString()))
                    {
                        try
                        {
                            group.AddUser(u);
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            group.RemoveUser(u);
                        }
                        catch { }
                    }
                }


                if(!String.IsNullOrEmpty(newProps) && String.IsNullOrEmpty(curProps))
                    sendEmail = true;

                try
                {
                    string perms = "";
                    foreach (SPGroup wGroup in webGroups)
                    {
                        try
                        {
                            SPGroup g = u.Groups.GetByID(wGroup.ID);
                            if(g != null && arr.Contains(g.ID.ToString(CultureInfo.InvariantCulture)))
                                perms += ", " + wGroup.Name;
                        }
                        catch { }   
                    }

                    properties.AfterProperties["Permissions"] = perms.Trim(", ".ToCharArray());
                }
                catch { }
            }
            catch { }

            return sendEmail;
        }
        
        /*private void addRequest(string first, string last, string email, string username, string group, bool newuser, SPWeb mySite, string requestorname)
        {
            SqlCommand cmdAddRequest = new SqlCommand("INSERT INTO REQUESTS (firstname,lastname,email,username,siteguid,webguid,requestor,sitegroup,newuser) VALUES (@first,@last,@email,@username,@siteguid,@webguid,@requestor,@sitegroup,@newuser)", cn);
            cmdAddRequest.CommandType = CommandType.Text;
            cmdAddRequest.Parameters.AddWithValue("@first", first);
            cmdAddRequest.Parameters.AddWithValue("@last", last);
            cmdAddRequest.Parameters.AddWithValue("@email", email);
            cmdAddRequest.Parameters.AddWithValue("@siteguid", mySite.Site.ID);
            cmdAddRequest.Parameters.AddWithValue("@webguid", mySite.ID);
            cmdAddRequest.Parameters.AddWithValue("@requestor", requestorname);
            cmdAddRequest.Parameters.AddWithValue("@sitegroup", group);
            cmdAddRequest.Parameters.AddWithValue("@newuser", newuser);
            cmdAddRequest.Parameters.AddWithValue("@username", username);
            cmdAddRequest.ExecuteNonQuery();
        }*/

        private void sendRequestEmail(Type thisClass, SPItemEventProperties properties, string requestorname)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(properties.SiteId))
                {
                    using(SPWeb tweb = site.OpenWeb())
                    {
                        foreach(SPUser user in tweb.SiteUsers)
                        {
                            if(user.IsSiteAdmin && user.Email != "")
                            {
                                try
                                {
                                    MethodInfo m = thisClass.GetMethod("sendEmail");
                                    bool sent = (bool)m.Invoke(null, new object[] { 24, user.Email, new string[] { requestorname, properties.AfterProperties["Title"].ToString(), CoreFunctions.getLockConfigSetting(properties.Web, "EPMLiveResourceURL", false) } });
                                }
                                catch { }
                            }
                        }
                    }
                }
            });
        }

        private void sendOwnerEmail(Type thisClass, SPItemEventProperties properties, string requestorname)
        {
            MethodInfo m = thisClass.GetMethod("sendEmail");
            bool sent = (bool)m.Invoke(null, new object[] { 25, owneremail, new string[] { requestorname, properties.AfterProperties["Title"].ToString(), CoreFunctions.getLockConfigSetting(properties.Web, "EPMLiveResourceURL", false) } });                      
        }

        private string createGroup(SPItemEventProperties properties)
        {
            SPWeb web = properties.Web;
            string group = GetProperty(properties, "Title");
            web.Site.CatchAccessDeniedException = false;
            try
            {
                SPPrincipal p = null;
                try
                {
                    p = web.SiteGroups["." + group];
                }
                catch { }
                if(p == null)
                {
                    web.SiteGroups.Add("." + group, web.CurrentUser, null, "");
                    p = web.SiteGroups["." + group];
                }

                return p.ID + ";#" + p.Name;
            }
            catch(Exception ex)
            {
                properties.AfterProperties["Approved"] = "0";
            }
            return null;
        }

       private string addUser(SPItemEventProperties properties, string username, string display, string email, string prefix)
       {
           SPPrincipal p = null;
           try
           {
                if(prefix == "")
                    p = properties.Web.AllUsers[prefix + username];
                else
                    p = properties.Web.AllUsers[prefix + username];
           }
           catch { }
           if(p == null)
           {
               SPSecurity.RunWithElevatedPrivileges(delegate()
               {
                   using(SPSite site = new SPSite(properties.SiteId))
                   {
                       using(SPWeb web = site.OpenWeb(properties.Web.ID))
                       {
                           web.AllUsers.Add(prefix + username, email, display, "");

                           p = properties.Web.AllUsers[prefix + username];
                       }
                   }
               });
           }
           if(p != null)
               return p.ID + ";#" + p.Name;

           return "";
       }
       /// <summary>
       /// An item is being updated.
       /// </summary>
       public override void ItemUpdating(SPItemEventProperties properties)
       {

           loadData(properties.List, properties.SiteId);

           processItem(properties, false);

           try
           {
               if(isOnline)
                cn.Close();
           }
           catch { }
       }

       /// <summary>
       /// An item was deleted.
       /// </summary>
       public override void ItemDeleted(SPItemEventProperties properties)
       {
           /*loadData(properties.List, properties.SiteId);
           properties.Cancel = true;
           try
           {
               if(isOnline)
               {
                   
                   cn.Close();
               }
           }
           catch { }*/
       }

       public override void ItemDeleting(SPItemEventProperties properties)
       {

           if(CoreFunctions.DoesCurrentUserHaveFullControl(properties.Web))
           {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SPSite oSite = new SPSite(properties.SiteId))
                    {
                        using(SPWeb oWeb = oSite.OpenWeb())
                        {
                            oWeb.AllowUnsafeUpdates = true;

                            try
                            {
                                SPFieldUserValue uv = new SPFieldUserValue(properties.Web, properties.ListItem["SharePointAccount"].ToString());

                                oWeb.SiteUsers.RemoveByID(uv.LookupId);
                            }
                            catch { }
                        }
                    }
                });
           }
           else
           {
               properties.Cancel = true;
               properties.ErrorMessage = "You do not have permissions to delete users.";
           }
       }
    }
}
