using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.ResourceManagement;
using EPMLiveCore.API.SPAdmin;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{


    [ScriptService]
    [WebService(Namespace = "workengine.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Licensing : WebService
    {

        [WebMethod]
        public string GetAdminUser()
        {
            string name = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPFarm farm = SPFarm.Local;
                name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            });
            return name;
        }


        //SetUserLevel
        //Return:   0 = Success
        //          1 = Too Many Users
        [WebMethod]
        public int SetUserLevel(string username, int featureId)
        {
            username = CoreFunctions.GetRealUserName(username);

            int retVal = -1;

            if(System.Web.HttpContext.Current != null)
                System.Web.HttpContext.Current.Items["FormDigestValidated"] = true;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                

                ArrayList arrUsers = GetFarmFeatureUsers(featureId);

                SPFarm farm = SPFarm.Local;

                if(featureId == 1000)
                {
                    UserManager _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
                    if(_chrono == null)
                    {
                        _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
                        _chrono.Update();
                        farm.Update();
                    }
                    ArrayList lstUsers = _chrono.UserList;

                    if(lstUsers.Count == 1 && lstUsers[0].ToString() == "")
                        lstUsers = new ArrayList();

                    int actType = 0;
                    
                    

                    SortedList sl = Act.GetAllAvailableLevels(out actType);

                    string[] sInUserInfo = username.Split(':');

                    int newfeatureid = int.Parse(sInUserInfo[1]);

                    if(sl.Contains(newfeatureid) || newfeatureid == 0)
                    {
                        int max = 0;
                        try
                        {
                            max = int.Parse(sl[newfeatureid].ToString());
                        }
                        catch { }

                        if(max == 0 && newfeatureid != 0)
                        {

                        }
                        else
                        {
                            int counter = 0;

                            

                            ArrayList newUsers = new ArrayList();

                            bool already = false;

                            foreach(string user in lstUsers)
                            {
                                string[] sUserInfo = user.Split(':');

                                if(sUserInfo[1] == newfeatureid.ToString())
                                    counter++;

                                if(user == username)
                                {
                                    already = true;
                                    break;
                                }

                                if(sUserInfo[0] != sInUserInfo[0])
                                    newUsers.Add(user);
                            }

                            if(counter < max || newfeatureid == 0)
                            {
                                if(!already)
                                {
                                    newUsers.Add(username);

                                    _chrono.UserList = newUsers;

                                    _chrono.Update();

                                    farm.Update();
                                }
                                retVal = 0;
                            }
                            else if(!already)
                                retVal = 1;
                            else
                                retVal = 0;
                        }
                    }
                    else
                    {
                        retVal = 2;
                    }
                }
                else
                {
                    string scount = CoreFunctions.getFeatureLicenseUserCount(featureId);
                    if(scount != "Unlimited")
                    {
                        int count = 0;
                        int.TryParse(scount, out count);
                        UserManager _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
                        if(_chrono == null)
                        {
                            _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
                            _chrono.Update();
                            farm.Update();
                        }
                        ArrayList lstUsers = _chrono.UserList;

                        if(lstUsers.Count == 1 && lstUsers[0].ToString() == "")
                            lstUsers = new ArrayList();

                        if(lstUsers.Contains(username) && lstUsers.Count <= count)
                        {
                            retVal = 0;
                        }
                        else
                        {
                            if(lstUsers.Count >= count)
                            {
                                retVal = 1;
                            }
                            else
                            {
                                lstUsers.Add(username);
                                _chrono.UserList = lstUsers;

                                _chrono.Update();

                                farm.Update();


                                retVal = 0;
                            }
                        }
                    }
                    else
                        retVal = 0;
                }

            });
            return retVal;
        }

        private ArrayList GetFarmFeatureUsers(int featureId)
        {
            UserManager _chrono = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPFarm farm = SPFarm.Local;

                    _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
                    if(_chrono == null)
                    {
                        SPWeb web = SPContext.Current.Web;
                        web.AllowUnsafeUpdates = true;
                        SPSite site = web.Site;
                        site.AllowUnsafeUpdates = true;
                        SPWebApplication app = site.WebApplication;
                        farm = app.Farm;
                        _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
                        _chrono.Update();
                        farm.Update();
                    }
                }
                catch { }
            });

            if(_chrono != null)
                return _chrono.UserList;

            return new ArrayList();
        }

    }
}
