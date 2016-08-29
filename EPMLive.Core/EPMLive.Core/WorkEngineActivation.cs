using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Collections;
using System.Data;

namespace EPMLiveCore
{
    public class WorkEngineActivation : SPJobDefinition
    {
        public WorkEngineActivation() : base()
        {
        }

        public WorkEngineActivation(string jobName, SPService service, SPServer server, SPJobLockType targetType) : base(jobName, service, server, targetType)
        {
        }

        public WorkEngineActivation(string jobName, SPWebApplication webApplication) : base(jobName, webApplication, null, SPJobLockType.ContentDatabase)
        {
            this.Title = "WorkEngine Activation";
        }

        public override void Execute(Guid contentDbId)
        {
            // get a reference to the current site collection's content database
            SPWebApplication webApplication = this.Parent as SPWebApplication;

            string[] arrUsers = new string[20];

            string LevelUsers = "";

            bool mustprocess = false;

            int actType = 0;

            SortedList LevelList = Act.GetAllAvailableLevels(out actType);

            if(actType == 3)
            {
                mustprocess = true;
            }
            else
            {
                for(int i = 0; i < 20; i++)
                {
                    string scount = "";
                    try
                    {
                        scount = CoreFunctions.getFeatureLicenseUserCount(i);
                        if(scount != "Unlimited" && scount != "0")
                            mustprocess = true;
                    }
                    catch { }
                    arrUsers[i] = "";

                }
            }

            if (!mustprocess)
                return;

            foreach (SPSite site in webApplication.Sites)
            {
                if(actType == 3)
                {
                    string sLevelUsers = "";
                    try
                    {
                        sLevelUsers = site.RootWeb.Properties["workengineusers1000"].ToString();
                    }
                    catch { }
                    if(sLevelUsers != "")
                    {
                        site.RootWeb.Properties["workengineusers1000"] = "";
                        site.RootWeb.Properties.Update();
                        LevelUsers = LevelUsers + "," + sLevelUsers;
                    }
                }
                else
                {
                    for(int i = 0; i < 20; i++)
                    {
                        string sUsers = "";
                        try
                        {
                            sUsers = site.RootWeb.Properties["workengineusers" + i].ToString();
                        }
                        catch { }
                        if(sUsers != "")
                        {
                            site.RootWeb.Properties["workengineusers" + i] = "";
                            site.RootWeb.Properties.Update();
                            arrUsers[i] = arrUsers[i] + "," + sUsers;
                        }
                    }
                }
                

                site.Dispose();
            }
            SPFarm farm = webApplication.Farm;

            if(actType == 3)
            {
                ProcessV3Users(farm, LevelUsers, LevelList);
            }
            else
            {
                for(int i = 0; i < 20; i++)
                {
                    ProcessUsers(farm, arrUsers[i], i);
                }
            }
            
        }

        private void ProcessUsers(SPFarm farm, string users, int ID)
        {
            if(users != "")
            {
                string scount = CoreFunctions.getFeatureLicenseUserCount(ID);
                if(scount != "Unlimited")
                {
                    int count = 0;
                    int.TryParse(scount, out count);
                    UserManager _chrono = farm.GetChild<UserManager>("UserManager" + ID);
                    if(_chrono == null)
                    {
                        _chrono = new UserManager("UserManager" + ID, farm, Guid.NewGuid());
                        _chrono.Update();
                        farm.Update();
                    }
                    ArrayList lstUsers = _chrono.UserList;
                    string[] arrFeatureUsers = users.Split(',');
                    foreach(string arrFeatureUser in arrFeatureUsers)
                    {
                        if(arrFeatureUser != "")
                        {
                            if(lstUsers.Count >= count)
                                break;
                            if(!lstUsers.Contains(arrFeatureUser))
                                lstUsers.Add(arrFeatureUser);
                        }
                    }
                    _chrono.UserList = lstUsers;
                    _chrono.Update();
                    farm.Update();
                }
            }
        }

        private void ProcessV3Users(SPFarm farm, string users, SortedList LevelList)
        {
            if(users != "")
            {

                UserManager _chrono = farm.GetChild<UserManager>("UserManager1000");
                if(_chrono == null)
                {
                    _chrono = new UserManager("UserManager1000", farm, Guid.NewGuid());
                    _chrono.Update();
                    farm.Update();
                }
                ArrayList lstUsers = _chrono.UserList;

                DataTable dt = new DataTable();
                dt.Columns.Add("Username");
                dt.Columns.Add("Level");

                foreach(string sUser in lstUsers)
                {
                    if(sUser != "")
                        dt.Rows.Add(sUser.Split(':'));
                }
                lstUsers.Clear();

                string[] arrFeatureUsers = users.Split(',');
                foreach(string arrFeatureUser in arrFeatureUsers)
                {
                    if(arrFeatureUser != "")
                    {
                        string[] sUserFeatureInfo = arrFeatureUser.Split(':');

                        DataRow[] dr = dt.Select("Username = '" + sUserFeatureInfo[0] + "'");

                        if(dr.Length > 0)
                        {
                            if(dr[0][1] != sUserFeatureInfo[1])
                            {
                                if(LevelList.ContainsKey(int.Parse(sUserFeatureInfo[1])))
                                {
                                    DataRow[] drLevelCount = dt.Select("Level = '" + sUserFeatureInfo[1] + "'");

                                    if(drLevelCount.Length < (int)LevelList[int.Parse(sUserFeatureInfo[1])])
                                    {
                                        dr[0][0] = sUserFeatureInfo[0];
                                        dr[0][1] = sUserFeatureInfo[1];
                                    }
                                }
                            }

                        }
                        else if(LevelList.ContainsKey(int.Parse(sUserFeatureInfo[1])))
                        {
                            DataRow[] drLevelCount = dt.Select("Level = '" + sUserFeatureInfo[1] + "'");

                            if(drLevelCount.Length < (int)LevelList[int.Parse(sUserFeatureInfo[1])])
                            {
                                dt.Rows.Add(sUserFeatureInfo);
                            }
                        }
                    }
                }

                foreach(DataRow dr in dt.Rows)
                {
                    lstUsers.Add(dr[0] + ":" + dr[1]);
                }

                _chrono.UserList = lstUsers;
                _chrono.Update();
                farm.Update();
                
            }
        }
    }
}
