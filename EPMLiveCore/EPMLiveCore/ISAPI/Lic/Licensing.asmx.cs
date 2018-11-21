using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.ResourceManagement;
using EPMLiveCore.API.SPAdmin;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using static EPMLiveCore.Helpers.WebServicesHelper;

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

            var retVal = -1;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items["FormDigestValidated"] = true;
            }

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    var arrUsers = GetFarmFeatureUsers(featureId);

                    var farm = SPFarm.Local;

                    const int ExpectedFeatureId = 1000;
                    retVal = featureId == ExpectedFeatureId
                        ? UpdateUserFeature1000(username, featureId, farm)
                        : UpdateUsersOnOtherFeatures(username, featureId, farm);
                });
            return retVal;
        }

        private static int UpdateUserFeature1000(string username, int featureId, SPFarm farm)
        {
            var retVal = -1;
            var _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
            if (_chrono == null)
            {
                _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
                _chrono.Update();
                farm.Update();
            }
            var lstUsers = _chrono.UserList;

            if (lstUsers.Count == 1 && lstUsers[0].ToString() == string.Empty)
            {
                lstUsers = new ArrayList();
            }

            var actType = 0;
            var availableLevels = Act.GetAllAvailableLevels(out actType);
            var userInfos = username.Replace("i:0#.w|", "").Split(':');
            var newFeatureId = int.Parse(userInfos[1]);

            if (availableLevels.Contains(newFeatureId) || newFeatureId == 0)
            {
                int max;
                int.TryParse(availableLevels[newFeatureId].ToString(), out max);

                if (max != 0 || newFeatureId == 0)
                {
                    var counter = 0;

                    var newUsers = new ArrayList();

                    var already = false;

                    ProcessUsers(username, lstUsers, newFeatureId, ref counter, userInfos, newUsers, ref already);

                    retVal = UpdateFarm(username, farm, counter, max, newFeatureId, already, newUsers, _chrono);
                }
            }
            else
            {
                retVal = 2;
            }
            return retVal;
        }

        private static void ProcessUsers(
            string username,
            ArrayList lstUsers,
            int newFeatureId,
            ref int counter,
            string[] userInfos,
            ArrayList newUsers,
            ref bool already)
        {
            foreach (string user in lstUsers)
            {
                var sUserInfo = user.Split(':');

                if (sUserInfo[1] == newFeatureId.ToString())
                {
                    counter++;
                }

                if (user == username)
                {
                    already = true;
                    break;
                }

                if (sUserInfo[0] != userInfos[0])
                {
                    newUsers.Add(user);
                }
            }
        }

        private static int UpdateFarm(
            string username,
            SPFarm farm,
            int counter,
            int max,
            int newFeatureId,
            bool already,
            ArrayList newUsers,
            UserManager _chrono)
        {
            int retVal;
            if (counter < max || newFeatureId == 0)
            {
                if (!already)
                {
                    newUsers.Add(username);

                    _chrono.UserList = newUsers;

                    _chrono.Update();

                    farm.Update();
                }
                retVal = 0;
            }
            else
            {
                retVal = !already
                    ? 1
                    : 0;
            }
            return retVal;
        }

        private static int UpdateUsersOnOtherFeatures(string username, int featureId, SPFarm farm)
        {
            int retVal;
            var userCount = CoreFunctions.getFeatureLicenseUserCount(featureId);
            if (userCount != "Unlimited")
            {
                var count = 0;
                int.TryParse(userCount, out count);
                var _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
                if (_chrono == null)
                {
                    _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
                    _chrono.Update();
                    farm.Update();
                }
                var lstUsers = _chrono.UserList;

                if (lstUsers.Count == 1 && lstUsers[0].ToString() == string.Empty)
                {
                    lstUsers = new ArrayList();
                }

                if (lstUsers.Contains(username) && lstUsers.Count <= count)
                {
                    retVal = 0;
                }
                else
                {
                    if (lstUsers.Count >= count)
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
            {
                retVal = 0;
            }
            return retVal;
        }

        private ArrayList GetFarmFeatureUsers(int featureId)
        {
            return FarmFeatureUsers(featureId);
        }

    }
}
