using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using Microsoft.SharePoint.Administration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace EPMLiveCore
{

    public enum ActFeature { WebParts = 0, WorkPlanner = 1, ResourcePlanner = 2, Timesheets = 3, ProjectServer=4, Reporting=5, AgilePlanner=6, PortfolioEngine=7, MyWork=8, AppsAndCommunities = 9};

    public class ActLevel
    {
        public int id;
        public string name;
        public int totalactivations;
        public int availableactivations;
        public bool isUserInLevel = false;
    }

    public class Act
    {
        private SPWeb _web;
        private bool _bIsOnline = false;
        public string OwnerUsername = "";
        public string bLatestError = "";

        public Act(SPWeb web)
        {
            _web = web;

            if(_web.Site.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
            {
                _bIsOnline = true;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    MethodInfo m;

                    Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                    Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                    m = thisClass.GetMethod("getConnectionStringByWebApp");
                    string sConn = (string)m.Invoke(null, new object[] { web.Site.WebApplication.Name });

                    SqlConnection cn = new SqlConnection(sConn);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                    cmd.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel(web.Site));

                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        OwnerUsername = dr.GetString(13);
                    }
                    dr.Close();
                    cn.Close();
                });
            }

        }

        public bool IsOnline
        {
            get
            {
                return _bIsOnline;
            }
        }

        public string translateStatus(int status)
        {
            switch(status)
            {
                case 1:
                    return "This feature has not been activated.";
                case 2:
                    return "Too many users activated for this feature.";
                case 3:
                    return "Server not licensed.";
                case -1:
                    return "Unable to retrieve activation status.";

                case 5:
                    return "You have not purchased this feature";
                case 6:
                    return "You have not been given access to this feature";
                case 7:
                    return "You trial has expired";
                case 8:
                    return "The EPM Live Core Feature is not activated";
                case 1000:
                    return bLatestError;
                default:
                    return "General license failure.";
            };
        }



        private int CheckOnlineFeatureLicense(ActFeature feature, string username, SPSite site)
        {

            MethodInfo m;

            Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.AccountManagement", true, true);

            m = thisClass.GetMethod("GetActivationInfo");
            DataSet dsInfo = (DataSet)m.Invoke(null, new object[] { _web.Site.ID, CoreFunctions.GetRealUserName(username, site) });

            int ActivationType = 0;

            try
            {
                ActivationType = int.Parse(dsInfo.Tables[0].Rows[0][0].ToString());
            }
            catch { }
            
            UserLevels uls = new UserLevels();

            switch(ActivationType)
            {
                case 0:
                    return 7;
                case 1: //old purchase method
                    {
                        int contractlevel = 2;

                        try
                        {
                            contractlevel = int.Parse(dsInfo.Tables[1].Rows[0]["Level"].ToString());
                        }
                        catch { }

                        UserLevel userlevel = uls.GetById(1);
                        if(contractlevel == 2)
                            userlevel = uls.GetById(2);
                        else if(contractlevel == 4)
                            userlevel = uls.GetById(3);

                        if(userlevel.levels.Contains((int)feature))
                        {

                            if(username.ToLower() == "sharepoint\\system")
                                return 0;
                            try
                            {
                                if(dsInfo.Tables[2].Rows[0][0].ToString() == "1")
                                {
                                    return 0;
                                }
                            }
                            catch { }
                            return 6;
                        }
                        return 5;
                    }
                case 2: //Trial
                    if(username.ToLower() == "sharepoint\\system")
                        return 0;

                    if(dsInfo.Tables[2].Rows[0][0].ToString() == "1")
                    {
                        return 0;
                    }
                    return 6;

                case 3: //New purchase method
                    {
                        bool HasPurchased = false;
                        bool HasAccess = false;

                        int userLevel = 0;

                        foreach(DataRow dr in dsInfo.Tables[1].Rows)
                        {
                            ArrayList arrFeatures = new ArrayList(dr["Features"].ToString().Split(','));
                            if(arrFeatures.Contains(((int)feature).ToString()))
                            {
                                HasPurchased = true;
                                if(username.ToLower() == "sharepoint\\system")
                                    return 0;
                                break;
                            }
                        }

                        try
                        {
                            userLevel = int.Parse(dsInfo.Tables[2].Rows[0][0].ToString());
                        }
                        catch { }
                        if(userLevel == 9999)
                        {
                            return 0;
                        }
                        else
                        {
                            DataRow[] drs = dsInfo.Tables[1].Select("ResLevel='" + userLevel + "'");
                            if(drs.Length > 0)
                            {

                                int usercount = 0;
                                int maxusers = 0;
                                try
                                {
                                    usercount = int.Parse(drs[0]["UserCount"].ToString());
                                }
                                catch { }
                                try
                                {
                                    maxusers = int.Parse(drs[0]["quantity"].ToString());
                                }
                                catch { }

                                if(maxusers >= usercount)
                                {

                                    ArrayList arrFeatures = new ArrayList(drs[0]["Features"].ToString().Split(','));
                                    if(arrFeatures.Contains(((int)feature).ToString()))
                                    {
                                        HasAccess = true;
                                    }
                                }
                                else
                                    return 2;
                            }
                        }

                        if(HasAccess)
                            return 0;
                        else if(HasPurchased)
                            return 6;
                        else
                            return 5;
                    }

            }
            return -1;
        }

        private int SetUserActivation(int feature, string username, SPSite site)
        {
            int retVal = -1;
            SPSecurity.RunWithElevatedPrivileges(delegate(){
                
                using(SPSite oSite = new SPSite(site.ID))
                {
                    if(oSite.WebApplication.ApplicationPool.Username == SPAdministrationWebApplication.Local.ApplicationPool.Username)
                    {
                        try
                        {
                            Licensing lic = new Licensing();
                            retVal = lic.SetUserLevel(username, feature);
                        }
                        catch(Exception ex)
                        {
                            bLatestError = ex.Message;
                            retVal = 1000;
                        }
                    }
                    else
                    {
                        try
                        {
                            var url = SPAdministrationWebApplication.Local.Sites[0].Url;
                            ActLicensing.Licensing lic = new ActLicensing.Licensing();
                            lic.UseDefaultCredentials = true;
                            lic.Url = url + "/_vti_bin/lic/licensing.asmx";
                            retVal = lic.SetUserLevel(username, feature);
                        }
                        catch(Exception ex)
                        {
                            bLatestError = ex.Message;
                            retVal = 1001;
                        }

                    }
                }
            });

            return retVal;
        }

        private int CheckOnsiteFeatureLicense(ActFeature feature, string username, SPSite site)
        {
            int ActivationType = 0;

            SortedList slAvailable = GetAllAvailableLevels(out ActivationType);

            switch(ActivationType)
            {
                case 1:
                case 2:
                    if(slAvailable.ContainsKey((int)feature))
                    {
                        if((int)slAvailable[(int)feature] == 0)
                        {
                            return 0;
                        }
                        else
                        {
                            if(username.ToLower() == "sharepoint\\system")
                                return 0;
                            else
                                return SetUserActivation((int)feature, username, site);
                        }
                    }
                    else
                    {
                        return 5;
                    }
                case 3:
                    bool HasPurchased = false;
                    bool HasAccess = false;
                    
                    UserLevels uls = new UserLevels();

                    foreach(System.Collections.Generic.KeyValuePair<int, UserLevel> ul in uls)
                    {
                        UserLevel oUl = (UserLevel)ul.Value;

                        if(slAvailable.Contains(oUl.id))
                        {
                            if(oUl.levels.Contains((int)feature))
                            {
                                if(username.ToLower() == "sharepoint\\system")
                                    return 0;

                                HasPurchased = true;

                                ArrayList arrUsers = GetFeatureUsers(1000);

                                bool userAlreadyIn = false;

                                int featureUserCount = 0;

                                foreach(string sUser in arrUsers)
                                {
                                    string[] sUserInfo = sUser.Split(':');

                                    if(sUserInfo[1] == oUl.id.ToString())
                                        featureUserCount++;

                                    if(sUserInfo[0] == username && sUserInfo[1] == oUl.id.ToString() && oUl.levels.Contains((int)feature))
                                    {
                                        userAlreadyIn = true;
                                    }
                                }

                                if(userAlreadyIn)
                                {
                                    if(featureUserCount > (int)slAvailable[oUl.id])
                                        return 2;
                                    HasAccess = true;
                                }
                            }
                        }
                    }

                    if(HasAccess)
                        return 0;
                    else if(HasPurchased)
                        return 6;
                    else
                        return 5;

            }

            return 1;

        }

        public int CheckFeatureLicense(ActFeature feature)
        {
            int act = -1;
            
            string user = CoreFunctions.GetRealUserName(_web.CurrentUser.LoginName, _web.Site);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(_web.Site.ID))
                {
                    if(IsOnline)
                    {
                        act = CheckOnlineFeatureLicense(feature, user, site);
                    }
                    else
                    {
                        act = CheckOnsiteFeatureLicense(feature, user, site);
                    }
                }
            });
            return act;
        }

        public void SetUserLevelV3(string username, int level)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(_web.Site.ID))
                {
                    if(IsOnline)
                    {

                        MethodInfo m;

                        Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                        Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.AccountManagement", true, true);

                        m = thisClass.GetMethod("SetAccountUserLevel");
                        bool processed = (bool)m.Invoke(null, new object[] { _web.Site.ID, CoreFunctions.GetRealUserName(username, _web.Site), level });

                    }
                    else
                    {
                        int actType = 0;

                        ArrayList Levels = GetLevelsFromSite(out actType, username);

                        if(actType == 3)
                        {
                            bool bCanAdd = false;

                            foreach(ActLevel alevel in Levels)
                            {
                                if(alevel.id == level)
                                {

                                    if(alevel.availableactivations > 0 && !alevel.isUserInLevel)
                                        bCanAdd = true;
                                }
                            }

                            if(bCanAdd)
                            {
                                int ret = SetUserActivation(1000, username + ":" + level, site);
                                if(ret != 0)
                                {
                                    throw new Exception("Error setting level: " + bLatestError);
                                }
                            }
                        }
                    }
                }
            });

        }

        public ArrayList GetLevelsFromSite(out int ActivationType, string username)
        {
            ArrayList Levels = new ArrayList();

            SortedList slAvailable = new SortedList();

            ActivationType = 0;

            if(IsOnline)
            {

                MethodInfo m;

                Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.AccountManagement", true, true);

                m = thisClass.GetMethod("GetActivationInfo");
                DataSet dsInfo = (DataSet)m.Invoke(null, new object[] { _web.Site.ID, CoreFunctions.GetRealUserName(username, _web.Site) });

                try
                {
                    ActivationType = int.Parse(dsInfo.Tables[0].Rows[0][0].ToString());
                }
                catch { }

                switch(ActivationType)
                {
                    case 1:
                        {
                            ActLevel level = new ActLevel();
                            level.id = 0;
                            level.name = "No Access";
                            level.availableactivations = 1;
                            level.totalactivations = 0;
                            level.isUserInLevel = true;
                            Levels.Add(level);

                            level = new ActLevel();
                            level.id = 2;
                            level.name = "Standard User";
                            level.availableactivations = 0;
                            level.totalactivations = 0;
                            level.isUserInLevel = false;

                            try
                            {
                                if(dsInfo.Tables[1].Rows[0]["Level"].ToString() == "4")
                                {
                                    level.name = "PortfolioEngine";
                                    level.id = 3;
                                }
                                else if(dsInfo.Tables[1].Rows[0]["Level"].ToString() == "2")
                                {
                                    level.id = 2;
                                    level.name = "WorkEngine";
                                }

                                int max = int.Parse(dsInfo.Tables[1].Rows[0]["MaxUsers"].ToString());
                                int usercount = int.Parse(dsInfo.Tables[1].Rows[0]["UserCount"].ToString());

                                level.totalactivations = usercount;
                                level.availableactivations = max - usercount;
                                
                            }
                            catch { }

                            try
                            {
                                if(dsInfo.Tables[2].Rows[0][0].ToString() == "1")
                                {
                                    level.isUserInLevel = true;
                                    ((ActLevel)Levels[0]).isUserInLevel = false;
                                }

                            }catch{}
                            Levels.Add(level);
                        }
                        break;
                    case 2:
                        {
                            ActLevel level = new ActLevel();
                            level.id = 0;
                            level.name = "No Access";
                            level.availableactivations = 1;
                            level.totalactivations = 0;
                            level.isUserInLevel = true;
                            Levels.Add(level);

                            level = new ActLevel();
                            level.id = 2;
                            level.name = "Trial User";
                            level.availableactivations = 0;
                            level.totalactivations = 0;
                            level.isUserInLevel = false;

                            try
                            {
                                int max = int.Parse(dsInfo.Tables[1].Rows[0]["MaxUsers"].ToString());
                                int usercount = int.Parse(dsInfo.Tables[1].Rows[0]["UserCount"].ToString());

                                level.totalactivations = usercount;
                                level.availableactivations = max - usercount;

                            }
                            catch { }

                            try
                            {
                                if(dsInfo.Tables[2].Rows[0][0].ToString() == "1")
                                {
                                    ((ActLevel)Levels[0]).isUserInLevel = false;
                                    level.isUserInLevel = true;
                                }

                            }
                            catch { }
                            Levels.Add(level);
                        }
                        break;
                    case 3:
                        {
                            ActLevel level = new ActLevel();
                            level.id = 0;
                            level.name = "No Access";
                            level.availableactivations = 1;
                            level.totalactivations = 0;
                            level.isUserInLevel = false;
                            Levels.Add(level);

                            bool isUserInOtherLevel = false;

                            foreach(DataRow dr in dsInfo.Tables[1].Rows)
                            {

                                level = new ActLevel();
                                level.id = int.Parse(dr["ResLevel"].ToString());
                                level.name = dr["LevelName"].ToString();
                                level.availableactivations = 0;
                                level.totalactivations = 0;
                                level.isUserInLevel = false;

                                try
                                {
                                    int max = int.Parse(dr["Quantity"].ToString());
                                    int usercount = int.Parse(dr["UserCount"].ToString());

                                    level.totalactivations = usercount;
                                    level.availableactivations = max - usercount;

                                }
                                catch { }

                                try
                                {
                                    if(dsInfo.Tables[2].Rows[0][0].ToString() == level.id.ToString())
                                    {
                                        isUserInOtherLevel = true;
                                        level.isUserInLevel = true;
                                    }

                                }
                                catch { }

                                Levels.Add(level);
                            }

                            if(isUserInOtherLevel)
                                ((ActLevel)Levels[0]).isUserInLevel = true;
                        }
                        break;
                }

                ActivationType = 3;
            }
            else
            {
                slAvailable = GetAllAvailableLevels(out ActivationType);

                switch(ActivationType)
                {
                    case 1:
                    case 2:
                        foreach(DictionaryEntry de in slAvailable)
                        {
                            ArrayList CurrentActivatedUsers = GetFeatureUsers((int)de.Key);

                            int availAct = 0;
                            
                            ActLevel level = new ActLevel();

                            if(CurrentActivatedUsers.Contains(username) && username != "")
                            {
                                availAct = 1;
                                level.isUserInLevel = true;
                            }
                            else
                            {
                                availAct = (int)de.Value - CurrentActivatedUsers.Count;
                            }

                           
                            level.id = (int)de.Key;
                            level.name = GetFeatureName(de.Key.ToString());
                            level.totalactivations = (int)de.Value;
                            level.availableactivations = availAct;

                            Levels.Add(level);
                        }
                        break;
                    case 3:
                        UserLevels uls = new UserLevels();
                        
                        ArrayList CurrentActivatedUsers1 = GetFeatureUsers(1000);

                        foreach(System.Collections.Generic.KeyValuePair<int, UserLevel> ul in uls)
                        {
                            UserLevel oUl = (UserLevel)ul.Value;

                            

                            int activatedusers = 0;

                            foreach(string sUser in CurrentActivatedUsers1)
                            {
                                string[] sU = sUser.Split(':');
                                if(sU[1] == oUl.id.ToString())
                                    activatedusers++;
                            }

                            int availAct = 0;

                            ActLevel level = new ActLevel();

                            int totalCount = 0;

                            if(slAvailable.ContainsKey(oUl.id))
                                totalCount = (int)slAvailable[oUl.id];

                            if(totalCount > 0 || oUl.id == 0)
                            {
                                if(CurrentActivatedUsers1.Contains(username + ":" + oUl.id) && username != "")
                                {
                                    availAct = 1;
                                    level.isUserInLevel = true;
                                }
                                else
                                {
                                    availAct = totalCount - activatedusers;
                                }
                            }
                            
                            level.id = oUl.id;
                            level.name = oUl.name;
                            level.totalactivations = totalCount;
                            if(oUl.id == 0)
                                level.availableactivations = 1;
                            else
                                level.availableactivations = availAct;

                            Levels.Add(level);
                            
                        }
                        break;
                }
            }

            return Levels;
        }

        private ArrayList GetFeatureUsers(int featureid)
        {
            ArrayList arr = GetFarmFeatureUsers(featureid);

            //string userlist = "";
            //try
            //{
            //    userlist = _web.Site.RootWeb.Properties["workengineusers" + featureid].ToString();
            //}
            //catch { }
            //if(userlist != "")
            //{
            //    if(arr[0].ToString() != "")
            //        arr.AddRange(userlist.Split(','));
            //    else
            //        arr = new ArrayList(userlist.Split(','));
            //}

            if(arr.Count == 1 && arr[0].ToString() == "")
                arr = new ArrayList();

            return arr;
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

        public ArrayList GetActivatedLevels()
        {
            ArrayList arrLevels = new ArrayList();
            if(IsOnline)
            {

                MethodInfo m;

                Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.AccountManagement", true, true);

                m = thisClass.GetMethod("GetActivatedFeatures");
                arrLevels = (ArrayList)m.Invoke(null, new object[] { _web.Site.ID });

            }
            else
            {
                int type = 0;

                SortedList slAvailable = GetAllAvailableLevels(out type);

                if(type == 3)
                {
                    UserLevels uls = new UserLevels();

                    foreach(System.Collections.Generic.KeyValuePair<int, UserLevel> ul in uls)
                    {
                        UserLevel oUl = (UserLevel)ul.Value;

                        if(slAvailable.Contains(oUl.id))
                        {
                            foreach(int level in oUl.levels)
                            {
                                if(!arrLevels.Contains(level.ToString()))
                                {
                                    arrLevels.Add(level.ToString());
                                }
                            }
                        }
                    }
                }
                else
                {

                    foreach(DictionaryEntry de in slAvailable)
                    {
                        arrLevels.Add(de.Key.ToString());
                    }
                }
            }

            return arrLevels;
        }

        public static SortedList GetAllAvailableLevels(out int ActivationType)
        {
            SortedList slLevels = new SortedList();

            ActivationType = 0;

            string keys = "";

            try
            {
                keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
            }
            catch { }
            if(keys != "")
            {
                string[] arrKeys = keys.Split('\t');
                for(int i = 0; i < arrKeys.Length; i = i + 2)
                {
                    if(arrKeys[i] != "")
                    {
                        string val = arrKeys[i];
                        string s = arrKeys[i + 1];
                        if(farmEncode(val) == s)
                        {
                            string feature = CoreFunctions.Decrypt(val, "jLHKJH5416FL>1dcv3#I");
                            string[] features = feature.Split('\n');
                            if(features[0][0] == '*')
                            {

                                if(features[0][1] == '2' && (ActivationType == 2 || ActivationType == 0))
                                {
                                    ActivationType = 2;

                                    string expiration = features[4];
                                    bool goodFeatureExp = false;
                                    if(expiration == "NA")
                                    {
                                        goodFeatureExp = true;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            System.Globalization.CultureInfo eng = new System.Globalization.CultureInfo(1033);
                                            DateTime dtEng = DateTime.Parse(expiration, eng);
                                            if(new DateTime(dtEng.Year, dtEng.Month, dtEng.Day) > DateTime.Now)
                                            {
                                                goodFeatureExp = true;
                                            }
                                        }
                                        catch { }
                                    }

                                    if(goodFeatureExp)
                                    {
                                        string[] featureNames = features[3].Split(',');
                                        foreach(string featureName in featureNames)
                                        {
                                            string[] sFeatureName = featureName.Split(':');

                                            int featureId = int.Parse(sFeatureName[0]);
                                            int userCount = int.Parse(sFeatureName[1]);

                                            if(slLevels.Contains(featureId))
                                                slLevels[featureId] = (int)slLevels[featureId] + userCount;
                                            else
                                                slLevels.Add(featureId, userCount);
                                        }
                                        return slLevels;
                                    }
                                    
                                }
                                else if(features[0][1] == '3' && (ActivationType == 3 || ActivationType == 0))
                                {
                                    ActivationType = 3;

                                    string expiration = features[4];
                                    bool goodFeatureExp = false;
                                    if(expiration == "NA")
                                    {
                                        goodFeatureExp = true;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            System.Globalization.CultureInfo eng = new System.Globalization.CultureInfo(1033);
                                            DateTime dtEng = DateTime.Parse(expiration, eng);
                                            if(new DateTime(dtEng.Year, dtEng.Month, dtEng.Day) > DateTime.Now)
                                            {
                                                goodFeatureExp = true;
                                            }
                                        }
                                        catch { }
                                    }

                                    if(goodFeatureExp)
                                    {
                                        string[] featureNames = features[3].Split(',');
                                        foreach(string featureName in featureNames)
                                        {
                                            string[] sFeatureName = featureName.Split(':');

                                            int featureId = int.Parse(sFeatureName[0]);
                                            int userCount = int.Parse(sFeatureName[1]);

                                            if(slLevels.Contains(featureId))
                                                slLevels[featureId] = (int)slLevels[featureId] + userCount;
                                            else
                                                slLevels.Add(featureId, userCount);
                                        }
                                        return slLevels;
                                    }
                                    
                                }
                                
                            }
                            else if(ActivationType == 1 || ActivationType == 0)
                            {
                                ActivationType = 1;

                                string expiration = features[4];
                                bool goodFeatureExp = false;
                                if(expiration == "NA")
                                {
                                    goodFeatureExp = true;
                                }
                                else
                                {
                                    try
                                    {
                                        System.Globalization.CultureInfo eng = new System.Globalization.CultureInfo(1033);
                                        DateTime dtEng = DateTime.Parse(expiration, eng);
                                        if(new DateTime(dtEng.Year, dtEng.Month, dtEng.Day) > DateTime.Now)
                                        {
                                            goodFeatureExp = true;
                                        }
                                    }
                                    catch { }
                                }
                                
                                int userCount = int.Parse(features[2]);

                                if(goodFeatureExp)
                                {
                                    string[] featureNames = features[1].Split(',');
                                    foreach(string featureName in featureNames)
                                    {
                                        int featureId = int.Parse(featureName);

                                        if(slLevels.Contains(featureId))
                                            slLevels[featureId] = (int)slLevels[featureId] + userCount;
                                        else
                                            slLevels.Add(featureId, userCount);
                                    }
                                }
                            }


                        }
                    }
                }
            }
            
            return slLevels;

        }

        private static string farmEncode(string code)
        {
            string computer = SPFarm.Local.Id.ToString();
            string actCode = "";
            int counter = 0;
            for(int i = 0; i < code.Length; i++)
            {
                if(counter + 1 >= computer.Length)
                    counter = 0;
                actCode = actCode + (computer[counter++] ^ code[i]);
            }
            return actCode;
        }

        public static string GetFeatureNameV2(string featureid)
        {
            switch(featureid)
            {
                case "1":
                    return "Team Member";
                case "2":
                    return "Project Manager";
                case "3":
                    return "Full User";
                default:
                    return "Unknown User Type";
            }
        }

        public static string GetFeatureName(string featureid)
        {
            switch(featureid)
            {
                case "0":
                    return "WebPart Base";
                case "1":
                    return "Work Planner";
                case "2":
                    return "Resource Planner";
                case "3":
                    return "Timesheets";
                case "4":
                    return "Enterprise Base";
                case "5":
                    return "Reporting";
                case "6":
                    return "Agile Planner";
                case "7":
                    return "PortfolioEngine Core";
                case "8":
                    return "MyWork WebPart";
                case "9":
                    return "Communities and Applications";
                default:
                    return "Unknown Feature";
            };
        }

    }
}
