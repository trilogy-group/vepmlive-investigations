﻿using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using static EPMLiveCore.Helpers.WebServicesHelper;

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
        private const int AccessLicense = 0;
        private const int OldPurchaseMethod = 1;
        private const int Trial = 2;
        private const int NewPurchaseMethod = 3;
        private const int PurchasedLicense = 6;
        private const string LevelColumn = "Level";
        private const string SharepointSystemUser = "sharepoint\\system";
        private const string EPMLiveAccountManagementAssembly = "EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
        private const string FeaturesColumn = "Features";
        private const string UserCountColumn = "UserCount";
        private const string QuantityColumn = "quantity";
        private const string NotAvailableString = "NA";
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

                    using (var sqlConnection = new SqlConnection(sConn))
                    {
                        sqlConnection.Open();

                        var sqlCommand = new SqlCommand("2010SP_GetSiteAccountNums", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@siteid", web.Site.ID);
                        sqlCommand.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel(web.Site));

                        using (var dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                OwnerUsername = dataReader.GetString(13);
                            }
                        }
                    }
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
            var assemblyInstance = Assembly.Load(EPMLiveAccountManagementAssembly);
            var thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.AccountManagement", true, true);

            var methodInfo = thisClass.GetMethod("GetActivationInfo");
            var dsInfo = (DataSet)methodInfo.Invoke(
                null, 
                new object[]
                {
                    _web.Site.ID,
                    CoreFunctions.GetRealUserName(username, site)
                });

            if (dsInfo.Tables.Count == 0 || dsInfo.Tables[0].Rows.Count == 0 || dsInfo.Tables[0].Columns.Count == 0)
            {
                throw new InvalidOperationException("dsInfo.Tables[0].Rows[0][0] should not be null.");
            }

            int activationType;
            if (!int.TryParse(dsInfo.Tables[0].Rows[0][0]?.ToString(), out activationType))
            {
                activationType = 0;
            }

            switch (activationType)
            {
                case AccessLicense:
                    return 7;
                case OldPurchaseMethod:
                    return CheckOldPurchaseMethod(feature, username, dsInfo);
                case Trial:
                    return HasAccess(username, dsInfo)
                        ? AccessLicense
                        : PurchasedLicense;
                case NewPurchaseMethod:
                    return CheckNewPurchaseMethod(feature, username, dsInfo);
                default:
                    Trace.WriteLine("Unexpected activationType: " + activationType);
                    break;
            }

            return -1;
        }

        private int CheckNewPurchaseMethod(ActFeature feature, string username, DataSet dsInfo)
        {
            if (dsInfo.Tables.Count < 3)
            {
                throw new ArgumentException("dsInfo.Tables should have at least 3 tables.", nameof(dsInfo));
            }
            var hasPurchased = false;
            var hasAccess = false;
            var userLevel = 0;

            foreach (DataRow dataRow in dsInfo.Tables[1].Rows)
            {
                var arrFeatures = new ArrayList(dataRow[FeaturesColumn]?.ToString().Split(','));
                if (arrFeatures.Contains(((int)feature).ToString()))
                {
                    hasPurchased = true;
                    if (SharepointSystemUser.Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        return AccessLicense;
                    }
                    break;
                }
            }

            if (!int.TryParse(dsInfo.Tables[2].Rows[0][0].ToString(), out userLevel))
            {
                Trace.WriteLine("Unable to parse dsInfo.Tables[2].Rows[0][0]");
            }

            if (userLevel == 9999)
            {
                return AccessLicense;
            }
            else
            {
                var dataRows = dsInfo.Tables[1].Select($"ResLevel='{userLevel}'");
                if (dataRows.Any())
                {
                    int usercount;
                    int maxusers;
                    if (!int.TryParse(dataRows[0][UserCountColumn]?.ToString(), out usercount))
                    {
                        usercount = 0;
                    }
                    if (!int.TryParse(dataRows[0][QuantityColumn]?.ToString(), out maxusers))
                    {
                        maxusers = 0;
                    }

                    if (maxusers >= usercount)
                    {
                        var arrFeatures = new ArrayList(dataRows[0][FeaturesColumn]?.ToString().Split(','));
                        if (arrFeatures.Contains(((int)feature).ToString()))
                        {
                            hasAccess = true;
                        }
                    }
                    else
                    {
                        return Trial;
                    }
                }
            }

            return GetLicenseValue(hasPurchased, hasAccess);
        }

        private static int GetLicenseValue(bool hasPurchased, bool hasAccess)
        {
            if (hasAccess)
            {
                return AccessLicense;
            }
            else if (hasPurchased)
            {
                return PurchasedLicense;
            }

            return 5;
        }

        private static int CheckOldPurchaseMethod(ActFeature feature, string username, DataSet dsInfo)
        {
            if (dsInfo.Tables.Count < 2 || dsInfo.Tables[1].Rows.Count == 0 || !dsInfo.Tables[1].Columns.Contains(LevelColumn))
            {
                throw new InvalidOperationException($"dsInfo.Tables[1].Rows[0][{LevelColumn}] should not be null");
            }

            int contractlevel;
            if (!int.TryParse(dsInfo.Tables[1].Rows[0][LevelColumn]?.ToString(), out contractlevel))
            {
                contractlevel = 2;
            }

            var userLevels = new UserLevels();
            var userLevel = userLevels.GetById(1);
            if (contractlevel == 2)
            {
                userLevel = userLevels.GetById(2);
            }
            else if (contractlevel == 4)
            {
                userLevel = userLevels.GetById(3);
            }

            if (userLevel == null || userLevel.levels == null)
            {
                throw new InvalidOperationException("userLevel.levels should not be null.");
            }
            if (userLevel.levels.Contains((int)feature))
            {
                if (HasAccess(username, dsInfo))
                {
                    return AccessLicense;
                }
                return 6;
            }

            return 5;
        }

        private static bool HasAccess(string username, DataSet dsInfo)
        {
            if (SharepointSystemUser.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            try
            {
                if (dsInfo.Tables[2].Rows[0][0].ToString() == "1")
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return false;
        }

        private int SetUserActivation(int feature, string username, SPSite site)
        {
            int retVal = -1;
            SPSecurity.RunWithElevatedPrivileges(delegate(){
                
                using(SPSite oSite = new SPSite(site.ID))
                {
                    //if(oSite.WebApplication.ApplicationPool.Username == SPAdministrationWebApplication.Local.ApplicationPool.Username)
                    //{
                    //    try
                    //    {
                    //        Licensing lic = new Licensing();
                    //        retVal = lic.SetUserLevel(username, feature);
                    //    }
                    //    catch(Exception ex)
                    //    {
                    //        bLatestError = ex.Message;
                    //        retVal = 1000;
                    //    }
                    //}
                    //else
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
                                    try
                                    {
                                        string[] sUserInfo = sUser.Split(':');

                                        if (sUserInfo[1] == oUl.id.ToString())
                                            featureUserCount++;

                                        if (sUserInfo[0] == username && sUserInfo[1] == oUl.id.ToString() && oUl.levels.Contains((int) feature))
                                        {
                                            userAlreadyIn = true;
                                        }
                                    }
                                    catch { }
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
            var levels = new ArrayList();

            ActivationType = 0;

            if (IsOnline)
            {
                ProcessActivationTypeOnline(ref ActivationType, username, levels);
            }
            else
            {
                ProcessActivationTypeOffline(out ActivationType, username, levels);
            }

            return levels;
        }

        private void ProcessActivationTypeOnline(ref int ActivationType, string username, ArrayList levels)
        {
            DataSet dataSetsInfo;
            GetActivationInfo(username, ref ActivationType, out dataSetsInfo);

            switch (ActivationType)
            {
                case 1:
                {
                    HandleOnlineCase1(levels, dataSetsInfo);
                }
                    break;
                case 2:
                {
                    HandleOnlineCase2(levels, dataSetsInfo);
                }
                    break;
                case 3:
                {
                    HandleOnlineCase3(levels, dataSetsInfo);
                }
                    break;
            }

            ActivationType = 3;
        }

        private void ProcessActivationTypeOffline(out int ActivationType, string username, ArrayList levels)
        {
            var sortedAvailableLevels = GetAllAvailableLevels(out ActivationType);

            switch (ActivationType)
            {
                case 1:
                case 2:
                    HandleOfflineCases1and2(username, sortedAvailableLevels, levels);
                    break;
                case 3:
                    HandleOfflineCase3(username, sortedAvailableLevels, levels);
                    break;
            }
        }

        private static void HandleOnlineCase1(ArrayList levels, DataSet dataSetsInfo)
        {
            var level = new ActLevel
            {
                id = 0,
                name = "No Access",
                availableactivations = 1,
                totalactivations = 0,
                isUserInLevel = true
            };
            levels.Add(level);

            level = new ActLevel
            {
                id = 2,
                name = "Standard User",
                availableactivations = 0,
                totalactivations = 0,
                isUserInLevel = false
            };

            try
            {
                if (dataSetsInfo.Tables[1].Rows[0]["Level"].ToString() == "4")
                {
                    level.name = "PortfolioEngine";
                    level.id = 3;
                }
                else if (dataSetsInfo.Tables[1].Rows[0]["Level"].ToString() == "2")
                {
                    level.id = 2;
                    level.name = "WorkEngine";
                }

                var max = int.Parse(dataSetsInfo.Tables[1].Rows[0]["MaxUsers"].ToString());
                var userCount = int.Parse(dataSetsInfo.Tables[1].Rows[0]["UserCount"].ToString());

                level.totalactivations = userCount;
                level.availableactivations = max - userCount;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }

            try
            {
                if (dataSetsInfo.Tables[2].Rows[0][0].ToString() == "1")
                {
                    level.isUserInLevel = true;
                    ((ActLevel)levels[0]).isUserInLevel = false;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            levels.Add(level);
        }

        private static void HandleOnlineCase2(ArrayList levels, DataSet dataSetsInfo)
        {
            var level = new ActLevel
            {
                id = 0,
                name = "No Access",
                availableactivations = 1,
                totalactivations = 0,
                isUserInLevel = true
            };
            levels.Add(level);

            level = new ActLevel
            {
                id = 2,
                name = "Trial User",
                availableactivations = 0,
                totalactivations = 0,
                isUserInLevel = false
            };

            try
            {
                var max = int.Parse(dataSetsInfo.Tables[1].Rows[0]["MaxUsers"].ToString());
                var userCount = int.Parse(dataSetsInfo.Tables[1].Rows[0]["UserCount"].ToString());

                level.totalactivations = userCount;
                level.availableactivations = max - userCount;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }

            try
            {
                if (dataSetsInfo.Tables[2].Rows[0][0].ToString() == "1")
                {
                    ((ActLevel)levels[0]).isUserInLevel = false;
                    level.isUserInLevel = true;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            levels.Add(level);
        }

        private static void HandleOnlineCase3(ArrayList levels, DataSet dataSetsInfo)
        {
            var level = new ActLevel
            {
                id = 0,
                name = "No Access",
                availableactivations = 1,
                totalactivations = 0,
                isUserInLevel = false
            };
            levels.Add(level);

            var isUserInOtherLevel = false;

            foreach (DataRow dr in dataSetsInfo.Tables[1].Rows)
            {
                level = new ActLevel
                {
                    id = int.Parse(dr["ResLevel"].ToString()),
                    name = dr["LevelName"].ToString(),
                    availableactivations = 0,
                    totalactivations = 0,
                    isUserInLevel = false
                };

                try
                {
                    var max = int.Parse(dr["Quantity"].ToString());
                    var userCount = int.Parse(dr["UserCount"].ToString());

                    level.totalactivations = userCount;
                    level.availableactivations = max - userCount;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }

                try
                {
                    if (dataSetsInfo.Tables[2].Rows[0][0].ToString() == level.id.ToString())
                    {
                        isUserInOtherLevel = true;
                        level.isUserInLevel = true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }

                levels.Add(level);
            }

            if (isUserInOtherLevel)
            {
                ((ActLevel)levels[0]).isUserInLevel = true;
            }
        }

        private void HandleOfflineCases1and2(string username, SortedList sortedAvailableLevels, ArrayList levels)
        {
            foreach (DictionaryEntry de in sortedAvailableLevels)
            {
                var currentActivatedUsers = GetFeatureUsers((int)de.Key);

                var level = new ActLevel();

                int availAct;
                if (!string.IsNullOrWhiteSpace(username) && currentActivatedUsers.Contains(username))
                {
                    availAct = 1;
                    level.isUserInLevel = true;
                }
                else
                {
                    availAct = (int)de.Value - currentActivatedUsers.Count;
                }

                level.id = (int)de.Key;
                level.name = GetFeatureName(de.Key.ToString());
                level.totalactivations = (int)de.Value;
                level.availableactivations = availAct;

                levels.Add(level);
            }
        }

        private void HandleOfflineCase3(string username, SortedList sortedAvailableLevels, ArrayList levels)
        {
            var userLevels = new UserLevels();

            var currentActivatedUsers = GetFeatureUsers(1000);

            foreach (var userLevel in userLevels)
            {
                var userLevelValue = userLevel.Value;

                var activatedUsers = 0;

                foreach (string sUser in currentActivatedUsers)
                {
                    try
                    {
                        var user = sUser.Split(':');
                        if (user[1] == userLevelValue.id.ToString())
                        {
                            activatedUsers++;
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                }

                var availAct = 0;

                var level = new ActLevel();

                var totalCount = 0;

                if (sortedAvailableLevels.ContainsKey(userLevelValue.id))
                {
                    totalCount = (int)sortedAvailableLevels[userLevelValue.id];
                }

                if (totalCount > 0 || userLevelValue.id == 0)
                {
                    if (!string.IsNullOrWhiteSpace(username) && currentActivatedUsers.Contains(string.Format("{0}:{1}", username, userLevelValue.id)))
                    {
                        availAct = 1;
                        level.isUserInLevel = true;
                    }
                    else
                    {
                        availAct = totalCount - activatedUsers;
                    }
                }

                level.id = userLevelValue.id;
                level.name = userLevelValue.name;
                level.totalactivations = totalCount;
                level.availableactivations = userLevelValue.id == 0
                    ? 1
                    : availAct;

                levels.Add(level);
            }
        }

        private void GetActivationInfo(string username, ref int activationType, out DataSet dataSetsInfo)
        {
            var assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            var thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.AccountManagement", true, true);

            var methodInfo = thisClass.GetMethod("GetActivationInfo");
            dataSetsInfo = (DataSet)methodInfo.Invoke(
                null,
                new object[]
                {
                    _web.Site.ID,
                    CoreFunctions.GetRealUserName(username, _web.Site)
                });

            try
            {
                activationType = int.Parse(dataSetsInfo.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
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
            return FarmFeatureUsers(featureId);
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
            var levels = new SortedList();

            ActivationType = 0;

            var keysString = string.Empty;

            try
            {
                keysString = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            if (keysString != string.Empty)
            {
                var keys = keysString.Split('\t');
                for (var i = 0; i < keys.Length; i = i + 2)
                {
                    if (keys[i] != string.Empty)
                    {
                        var keyValue = keys[i];
                        var keyChar = keys[i + 1];
                        if (farmEncode(keyValue) == keyChar)
                        {
                            const string PassPhrase = "jLHKJH5416FL>1dcv3#I";
                            var feature = CoreFunctions.Decrypt(keyValue, PassPhrase);
                            var features = feature.Split('\n');
                            if (features[0][0] == '*')
                            {
                                if (features[0][1] == '2' && (ActivationType == 2 || ActivationType == 0))
                                {
                                    var sortedList = AddFeaturesActivationType2(out ActivationType, features, levels);
                                    if (sortedList != null)
                                    {
                                        return sortedList;
                                    }
                                }
                                else if (features[0][1] == '3' && (ActivationType == 3 || ActivationType == 0))
                                {
                                    var allAvailableLevels = AddFeatureActivationType3(out ActivationType, features, levels);
                                    if (allAvailableLevels != null)
                                    {
                                        return allAvailableLevels;
                                    }
                                }
                            }
                            else if (ActivationType == 1 || ActivationType == 0)
                            {
                                AddFeatureActivationType1(out ActivationType, features, levels);
                            }
                        }
                    }
                }
            }

            return levels;

        }

        private static SortedList AddFeaturesActivationType2(out int ActivationType, string[] features, SortedList levels)
        {
            ActivationType = 2;

            var expiration = features[4];
            var goodFeatureExp = false;
            if (expiration == NotAvailableString)
            {
                goodFeatureExp = true;
            }
            else
            {
                try
                {
                    var engCulture = new CultureInfo(1033);
                    var dateTime = DateTime.Parse(expiration, engCulture);
                    if (new DateTime(dateTime.Year, dateTime.Month, dateTime.Day) > DateTime.Now)
                    {
                        goodFeatureExp = true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }

            var allAvailableLevels = AddOrUpdateFeatures(goodFeatureExp, features, levels);
            return allAvailableLevels;
        }

        private static SortedList AddOrUpdateFeatures(bool goodFeatureExp, string[] features, SortedList levels)
        {
            if (goodFeatureExp)
            {
                var featureNames = features[3].Split(',');
                foreach (var featureName in featureNames)
                {
                    var nameParts = featureName.Split(':');

                    var featureId = int.Parse(nameParts[0]);
                    var userCount = int.Parse(nameParts[1]);

                    if (levels.Contains(featureId))
                    {
                        levels[featureId] = (int)levels[featureId] + userCount;
                    }
                    else
                    {
                        levels.Add(featureId, userCount);
                    }
                }
                return levels;
            }
            return null;
        }

        private static SortedList AddFeatureActivationType3(out int ActivationType, string[] features, SortedList levels)
        {
            ActivationType = 3;

            var expiration = features[4];
            var goodFeatureExp = false;
            if (expiration == "NA")
            {
                goodFeatureExp = true;
            }
            else
            {
                try
                {
                    var engCulture = new CultureInfo(1033);
                    var dateTime = DateTime.Parse(expiration, engCulture);
                    if (new DateTime(dateTime.Year, dateTime.Month, dateTime.Day) > DateTime.Now)
                    {
                        goodFeatureExp = true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }

            var allAvailableLevels = AddOrUpdateFeatures(goodFeatureExp, features, levels);
            return allAvailableLevels;
        }

        private static void AddFeatureActivationType1(out int ActivationType, string[] features, SortedList levels)
        {
            ActivationType = 1;

            var goodFeatureExp = GetIsGoodFeatureExp(features);
            var userCount = int.Parse(features[2]);

            AddGoodFeature(goodFeatureExp, features, levels, userCount);
        }

        private static bool GetIsGoodFeatureExp(string[] features)
        {
            var expiration = features[4];
            var goodFeatureExp = false;
            if (expiration == "NA")
            {
                goodFeatureExp = true;
            }
            else
            {
                try
                {
                    var engCulture = new CultureInfo(1033);
                    var dateTime = DateTime.Parse(expiration, engCulture);
                    if (new DateTime(dateTime.Year, dateTime.Month, dateTime.Day) > DateTime.Now)
                    {
                        goodFeatureExp = true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }
            return goodFeatureExp;
        }

        private static void AddGoodFeature(bool goodFeatureExp, string[] features, SortedList levels, int userCount)
        {
            if (goodFeatureExp)
            {
                var featureNames = features[1].Split(',');
                foreach (var featureId in featureNames.Select(featureName => int.Parse(featureName)))
                {
                    if (levels.Contains(featureId))
                    {
                        levels[featureId] = (int)levels[featureId] + userCount;
                    }
                    else
                    {
                        levels.Add(featureId, userCount);
                    }
                }
            }
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
