using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Collections;
using Microsoft.SharePoint;
using System.Security.Principal;
using System.Data;
using System.Data.SqlClient;
using EPMLiveCore.ReportHelper;

namespace EPMLiveCore
{
    public class ADSync
    {
        string _groupName;
        string _fullDomain;
        string _domain;
        string _processLog = "";

        SPWeb _web;
        SPList _list;
        DataTable _resourcePool;
        DataTable _adUsers;

        string[] _adGroups;
        ArrayList _adExclusions;

        List<string> _processedUsers = new List<string>();
        List<string> _disableUsers = new List<string>();
        List<string> _adFieldMappings = new List<string>();
        Hashtable _adFieldMappingValues = new Hashtable();
        Hashtable _adGroupNameAndPath = new Hashtable();

        bool _hasSID = false;
        bool _deleteUser = false;

        List<string> _ExecutionLogs = new List<string>();
        bool _hasErrors = false;

        Guid _tuid;
        EPMData _DAO;

        public Hashtable htGroupPaths
        {
            get
            {
                return _adGroupNameAndPath;
            }
        }

        public void InitiateSync(SPSite site, out string processLog, out bool hasErrors, Guid tuid)
        {
            try
            {
                _ExecutionLogs.Add("AD Sync process started at: " + DateTime.Now.ToString());
                _tuid = tuid;
                _DAO = new EPMData(site.ID);
                using(SPWeb web = site.OpenWeb())
                {
                    Initialize(web);
                }
                
                ProcessAllGroups();
                UpdateResourcePool();

                //Checking for any "Disabled" "Active Directory" users.
                if (_disableUsers.Count > 0)
                {
                    DisableUsers();
                }

                //If Resourcepool contained SID field initially, THEN audit Resourcepool and
                //delete or disable (depending on "Disabled" config setting) users.
                if (_hasSID)
                {
                    AuditResourcePool();
                }
                WriteOutLog();
                _DAO.Dispose();
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: InitiateSync() -- Message: " + ex.Message);
                _hasErrors = true;
            }
            processLog = _processLog;
            hasErrors = _hasErrors;
        }

        private void AuditResourcePool()
        {
            int iResCounter = 0;
            int iResCount = _list.Items.Count;
            string sid = string.Empty;
            while (iResCounter < iResCount)
            {
                try
                {
                    object obj = _list.Items[iResCounter]["SID"];
                    //IF the resource was NOT processed THEN DELETE the resource FROM the RESOURCEPOOL.
                    if (_list.Items[iResCounter]["SID"] != null && !_processedUsers.Contains(_list.Items[iResCounter]["SID"].ToString()))
                    {
                        sid = _list.Items[iResCounter]["SID"].ToString();
                        if (sid != string.Empty && !_disableUsers.Contains(sid))
                        {
                            if (userDeleted(sid) || _deleteUser)
                            {
                                _list.Items[iResCounter].Delete();
                                iResCounter--;
                            }
                            else
                            {
                                SPListItem li = _list.Items[iResCounter];
                                li["Disabled"] = true;
                                li.Update();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _ExecutionLogs.Add("     ERROR -- Location: AuditResourcePool() -- SID:" + sid + " -- Message: " + ex.Message);
                    _hasErrors = true;
                }
                iResCounter++;
                iResCount = _list.Items.Count;
            }
        }

        private void DisableUsers()
        {
            int iDisableCounter = 0;
            int iDisableCount = _disableUsers.Count;
            SPQuery caml;
            SPListItemCollection result;
            SPListItem li;
            while (iDisableCounter < iDisableCount)
            {
                try
                {
                    caml = new SPQuery();
                    caml.Query = "<Where><Eq><FieldRef Name='SID'/><Value Type='Text'>" + _disableUsers[iDisableCounter] + "</Value></Eq></Where>";
                    result = _list.GetItems(caml);
                    if (result != null && result.Count > 0)
                    {
                        li = result[0];
                        li["Disabled"] = true;
                        li.Update();
                    }
                }
                catch (Exception ex)
                {
                    _ExecutionLogs.Add("     ERROR -- Location: DisableUsers() -- SID: " + _disableUsers[iDisableCounter] + " -- Message: " + ex.Message);
                    _hasErrors = true;
                }
                iDisableCounter++;
            }
        }

        private bool userDeleted(string sid)
        {
            string path = "LDAP://<SID=" + sid + ">";
            DirectoryEntry user = new DirectoryEntry(path);
            if (user != null)
            {
                return false;
            }
            return true;
        }

        private bool userDisabled(string sid)
        {
            string path = "LDAP://<SID=" + sid + ">";
            DirectoryEntry user = new DirectoryEntry(path);
            DirectorySearcher ds = new DirectorySearcher(user);
            SearchResult sr;
            ds.Filter = "(&(userAccountControl:1.2.840.113556.1.4.803:=2))";
            sr = ds.FindOne();
            if (sr != null)
            {
                return true;
            }
            return false;
        }

        private void UpdateResourcePool()
        {
            decimal totalUserCount = (decimal)(_adUsers.Rows.Count / .25); //Handicap to compensate for group processing. Group processing = 25% of total processing
            decimal userCount = 0;
            decimal pctComplete = 0;
            foreach (DataRow adUser in _adUsers.Rows)
            {
                try
                {
                    if (!_processedUsers.Contains(adUser["SID"].ToString()))
                    {
                        UpdateResource(GetResourcepoolItem(adUser["SID"].ToString()), adUser);
                    }
                    userCount++;
                    pctComplete = (userCount / totalUserCount) * 100;
                    pctComplete = pctComplete + (pctComplete * (decimal).25); //Add handicap back to get total processing complete %.
                    UpdatePercentComplete(pctComplete);
                }
                catch (Exception ex)
                {
                    _ExecutionLogs.Add("     ERROR -- Location: UpdateResourcePool() -- SID: " + adUser["SID"].ToString() + " -- Message: " + ex.Message);
                    _hasErrors = true;
                }
            }
        }

        private bool UpdatePercentComplete(decimal pctComplete)
        {

            _DAO.Command = "UPDATE QUEUE SET percentComplete = " + pctComplete.ToString() + " WHERE timerjobuid='" + _tuid + "'";
            _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
            return true;
        }

        private SPListItem GetResourcepoolItem(string sid)
        {
            SPListItem li = null;
            //Check for SID IF present, then try to update the resource.
            if (_hasSID && _resourcePool.Rows.Count > 0)
            {
                try
                {
                    string filter = "SID='" + sid + "'";
                    DataRow[] result = _resourcePool.Select(filter);

                    //If resource found, get resourcepool item
                    if (result != null && result.Length > 0)
                    {
                        int itemID = int.Parse(_resourcePool.Select(filter)[0]["ID"].ToString());
                        li = _list.GetItemById(itemID);
                    }
                    else // Add resource.
                    {
                        li = _list.Items.Add();
                    }
                }
                catch (Exception ex)
                {
                    _ExecutionLogs.Add("     ERROR -- Location: GetResourcepoolItem() -- SID: " + sid + " -- Message: " + ex.Message);
                    _hasErrors = true;
                }
            }
            else // Add resource.
            {
                li = _list.Items.Add();
            }
            return li;
        }

        private static int GetSizeLimit()
        {
            int sizeLimit;

            try
            {
                var sizeLimitAsString = CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLIVEadSizeLimit");
                sizeLimit = int.Parse(sizeLimitAsString);
            }
            catch (Exception)
            {
                sizeLimit = 0;
            }

            return sizeLimit;
        }


        private void ProcessAllGroups()
        {
            List<string> allGroups = GetGroups("LDAP://" + _fullDomain); //This call initializes the groups ad path            
            foreach (string group in _adGroups)
            {
                if (group != string.Empty)
                {
                    _groupName = group;
                    PopulateAllGroupUserAttributes();
                }
            }
        }

        public List<string> GetGroups(string path)
        {
            DirectoryEntry objADAM = default(DirectoryEntry);
            DirectoryEntry objGroupEntry = default(DirectoryEntry);
            DirectorySearcher objSearchADAM = default(DirectorySearcher);
            SearchResultCollection objSearchResults = default(SearchResultCollection);
            List<string> result = new List<string>();

            try
            {
                objADAM = new DirectoryEntry(path);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                _ExecutionLogs.Add("     WARNING -- Location: GetGroups() -- Path:" + path + " -- Message:" + e.Message);
            }

            // Get search object, specify filter and scope,  
            // perform search.  
            try
            {
                objSearchADAM = new DirectorySearcher(objADAM);
                objSearchADAM.Filter = "(&(objectClass=group))";
                objSearchADAM.PageSize = GetSizeLimit();
                objSearchADAM.SearchScope = SearchScope.Subtree;
                objSearchResults = objSearchADAM.FindAll();
            }
            catch (Exception e)
            {
                _ExecutionLogs.Add("     WARNING -- Location: GetGroups() -- Path:" + path + " -- Message:" + e.Message);
            }

            // Enumerate groups  
            try
            {
                if (objSearchResults.Count != 0)
                {
                    //SearchResult objResult = default(SearchResult);
                    foreach (SearchResult objResult in objSearchResults)
                    {

                        objGroupEntry = objResult.GetDirectoryEntry();
                        if (objGroupEntry.Name.Replace("CN=", "") != "Domain Users")
                        {
                            result.Add(objGroupEntry.Name.Replace("CN=", ""));
                            _adGroupNameAndPath.Add(objGroupEntry.Name.Replace("CN=", ""), objGroupEntry.Path);
                        }
                    }
                }
                else
                {
                    _ExecutionLogs.Add("     WARNING -- Location: GetGroups() -- Path:" + path + " -- Message: No groups found.");
                }
            }
            catch (Exception e)
            {
                _ExecutionLogs.Add("     WARNING -- Location: GetGroups() -- Path:" + path + " -- Message:" + e.Message);
            }

            if (objSearchResults != null) objSearchResults.Dispose();

            return result;
        }

        private void UpdateResource(SPListItem li, DataRow userADproperties)
        {
            foreach (string field in _adFieldMappings)
            {
                string spFieldName = string.Empty;
                string adFieldName = string.Empty;
                try
                {
                    spFieldName = _adFieldMappingValues[field].ToString(); //For debugging only...remove
                    adFieldName = field; //For debugging only...remove
                    if (spFieldName.ToLower() != "sharepointaccount")
                    {
                        li[spFieldName] = userADproperties[spFieldName].ToString();
                    }
                    else
                    {
                        li[spFieldName] = GetSharepointAccount(userADproperties[spFieldName].ToString(), string.Empty, userADproperties["Title"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    _ExecutionLogs.Add("     ERROR -- Location: UpdateResource() -- SID: " + li["SID"].ToString() + " SPField: " + spFieldName + " ADField:" + adFieldName + " -- Message: " + ex.Message);
                    _hasErrors = true;
                }
            }
            li["SID"] = userADproperties["SID"].ToString();
            li["Disabled"] = false;
            li.Update();
            _processedUsers.Add(userADproperties["SID"].ToString());
        }

        private SPUser GetSharepointAccount(string acctName, string email, string displayName)
        {
            SPUser user = null;
            if (!acctName.Contains("\\"))
            {
                string tmp = acctName;
                acctName = _domain + "\\" + tmp;
            }

            try
            {
                user = _web.AllUsers[acctName];
            }
            catch (Exception ex)
            {

            }

            if (user == null)
            {
                try
                {
                    _web.AllUsers.Add(acctName, email, displayName, string.Empty);
                    user = _web.AllUsers[acctName];
                }
                catch (Exception ex)
                {

                }
            }
            return user;
        }

        private void Initialize(SPWeb web)
        {
            try
            {
                _web = web;
                string resWebUrl = EPMLiveCore.CoreFunctions.getConfigSetting(_web, "EPMLiveResourceURL", true, true);
                using(SPWeb rWeb = _web.Site.AllWebs[resWebUrl])
                {
                    _list = rWeb.Lists["Resources"];
                }
                PopulateConfigSettings();
                CheckForSIDandDisableColumn();
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: Initialize() -- Message: " + ex.Message);
                _hasErrors = true;
            }
        }

        private bool CheckForSIDandDisableColumn()
        {
            try
            {
                if (!_list.Fields.ContainsField("SID"))
                {
                    _list.Fields.Add("SID", SPFieldType.Text, false);
                    SPField sid = _list.Fields["SID"];
                    sid.ShowInEditForm = false;
                    sid.ShowInNewForm = false;

                    if (_list.Items.Count > 0)
                    {
                        _adUsers = _list.Items.GetDataTable().Clone();
                    }
                    else
                    {
                        SPListItem li = _list.Items.Add();
                        li["SID"] = Guid.NewGuid();
                        li.Update();
                        _adUsers = _list.Items.GetDataTable().Clone();
                        _list.Items.Delete(0);
                        _list.Update();
                    }
                    //No need to init. res datatable -- because all users will be ADDED to the list.
                }
                else
                {
                    //Init. res datatable -- will be used to compare sid's to UPDATE resourcepool list data.
                    if (_list.Items.Count > 0)
                    {
                        _resourcePool = _list.Items.GetDataTable();
                    }
                    else
                    {
                        SPListItem li = _list.Items.Add();
                        li["SID"] = Guid.NewGuid();
                        li.Update();
                        _resourcePool = _list.Items.GetDataTable().Clone();
                        _list.Items.Delete(0);
                        _list.Update();
                    }
                    _adUsers = _resourcePool.Clone();
                    _hasSID = true;
                }

                if (!_list.Fields.ContainsField("Disabled"))
                {
                    _list.Fields.Add("Disabled", SPFieldType.Boolean, false);
                }
                _list.Update();
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: CheckForSIDandDisableColumn() -- List: " + _list.Title + " -- Message: " + ex.Message);
                _hasErrors = true;
                return false;
            }
            return true;
        }

        private void PopulateConfigSettings()
        {
            string fieldmappings = EPMLiveCore.CoreFunctions.getConfigSetting(_web, "EPMLIVEadfields");
            string[] adFieldMappings = fieldmappings.Split("|".ToCharArray()[0]);
            _adExclusions = new ArrayList();
            _adGroups = EPMLiveCore.CoreFunctions.getConfigSetting(_web, "EPMLIVEadgroups").Split('|');
            _adExclusions.AddRange(EPMLiveCore.CoreFunctions.getConfigSetting(_web, "EPMLIVEadexclusions").Split(';'));
            _deleteUser = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(_web, "EPMLIVEaddelete"));

            _fullDomain = GetFullDomain();

            foreach (string field in adFieldMappings)
            {
                string[] keyValue = field.Split(";".ToCharArray()[0]);
                if (keyValue.Length > 1 && !_adFieldMappingValues.Contains(keyValue[1]))
                {
                    _adFieldMappingValues.Add(keyValue[1], keyValue[0]);
                    _adFieldMappings.Add(keyValue[1]);
                }
                else if (keyValue.Length > 1)
                {
                    _ExecutionLogs.Add(keyValue[1] + " is already mapped.");
                }
            }
        }

        private bool PopulateAllGroupUserAttributes()
        {
            string sid = string.Empty;
            string cn = string.Empty;
            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://" + _fullDomain);
                de.AuthenticationType = AuthenticationTypes.Secure;
                var ds = new DirectorySearcher(de, "(objectClass=person)") { PageSize = GetSizeLimit() };

                if (_adGroupNameAndPath.ContainsKey(_groupName))
                {
                    ds.Filter = "(memberOf=" + _adGroupNameAndPath[_groupName].ToString().Replace("(", "").Replace("LDAP://", "") + ")";
                    AddProperties(ds);
                    foreach (SearchResult sr in ds.FindAll())
                    {
                        try
                        {
                            // don't update disabled users
                            sid = GetUserSID(sr.Path).ToUpper();
                            //Array exclusions = _adExclusions.ToArray();                           
                            if (!_adExclusions.Contains(sid)) //Skip exclusions
                            {
                                if (!userDisabled(sid))
                                {
                                    AddResourceToDataTable(sr.Path);
                                }
                                else
                                {
                                    _disableUsers.Add(sid);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _ExecutionLogs.Add("     ERROR -- Location: PopulateAllGroupUserAttributes() resource level -- SID: " + sid + " -- Message: " + ex.Message);
                            _hasErrors = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: PopulateAllGroupUserAttributes() module level -- Message: " + ex.Message);
                _hasErrors = true;
            }
            return true;
        }

        public List<string> GetADGroupUserAttributes(string domain, string groupName)
        {
            //DEFAULT ATTRIBUTES
            List<string> userAttributes = new List<string>();
            //userAttributes.Add("cn");
            //userAttributes.Add("description");
            //userAttributes.Add("displayname");
            //userAttributes.Add("distinguishedname");
            //userAttributes.Add("givenname");
            //userAttributes.Add("name");
            //userAttributes.Add("samaccountname");
            //userAttributes.Add("sn");
            //userAttributes.Add("useraccountcontrol");
            //userAttributes.Add("userprincipalname");
            //userAttributes.Add("mail");
            //userAttributes.Add("c");
            //userAttributes.Add("company");
            //userAttributes.Add("department");
            //userAttributes.Add("homephone");
            //userAttributes.Add("l");
            //userAttributes.Add("location");
            //userAttributes.Add("manager");
            //userAttributes.Add("mobile");
            //userAttributes.Add("postalcode");
            //userAttributes.Add("st");
            //userAttributes.Add("streetaddress");
            //userAttributes.Add("telephonenumber");
            //userAttributes.Add("title");

            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://" + domain);
                DirectorySearcher ds = new DirectorySearcher(de, "(objectClass=person)");
                //ds.Filter = "(CN=User,CN=Schema,CN=Configuration,DC=dev2008,DC=com)";
                SearchResult sr = ds.FindOne();
                //System.DirectoryServices.ResultPropertyCollection prop = sr.Properties;
                //ICollection coll = prop.PropertyNames;
                //IEnumerator enu = coll.GetEnumerator();

                DirectoryEntry de2 = new DirectoryEntry(sr.Path);
                de2.RefreshCache(new string[] { "allowedAttributes" });

                SortedList lstProps = new SortedList();

                foreach (string sprop in de2.Properties["allowedAttributes"])
                {
                    lstProps.Add(sprop, "");
                }

                foreach(DictionaryEntry deProp in lstProps)
                {
                    if (!userAttributes.Contains(deProp.Key.ToString().ToLower()))
                    {
                        userAttributes.Add(deProp.Key.ToString().ToLower());
                    }
                }
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: GetADGroupUserAttributes() -- Message: " + ex.Message);
                _hasErrors = true;
            }
            return userAttributes;
        }

        public bool AddTimerJob(SPWeb web, int iTime, int iScheduleType, string days, bool runNow)
        {
            SqlConnection con = null;
            bool passed = true;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    Guid timerjobuid = Guid.Empty;
                    if (_DAO == null)
                        _DAO = new EPMData(web.Site.ID);

                    _DAO.Command = "select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=8";
                    _DAO.AddParam("@siteguid", web.Site.ID.ToString());
                    object oResult = _DAO.ExecuteScalar(_DAO.GetEPMLiveConnection);

                    if (oResult != null)
                    {
                        timerjobuid = (Guid)oResult;
                        _DAO.Command = "UPDATE TIMERJOBS SET runtime = @runtime, scheduleType = @scheduletype, days = @days WHERE jobtype=8";
                        _DAO.AddParam("@runtime", iTime);
                        _DAO.AddParam("@scheduletype", iScheduleType);
                        _DAO.AddParam("@days", days);
                        _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                    }
                    else
                    {
                        timerjobuid = Guid.NewGuid();
                        _DAO.Command = "INSERT INTO TIMERJOBS (timerjobuid,jobname,siteguid,webguid,listguid,jobtype,enabled,runtime,scheduletype,days,jobdata,lastqueuecheck,parentjobuid) VALUES (@timerjobuid,@jobname,@siteguid,@webguid,NULL,@jobtype,@enabled,@runtime,@scheduletype,@days,@jobdata,@lastqueuecheck,@parentjobuid)";
                        _DAO.AddParam("@timerjobuid", timerjobuid);
                        _DAO.AddParam("@jobname", "EPMLiveADSync");
                        _DAO.AddParam("@siteguid", web.Site.ID.ToString());
                        _DAO.AddParam("@webguid", web.Site.RootWeb.ID.ToString());
                        _DAO.AddParam("@jobtype", 8);
                        _DAO.AddParam("@enabled", true);
                        _DAO.AddParam("@runtime", iTime);
                        _DAO.AddParam("@scheduletype", iScheduleType);
                        _DAO.AddParam("@days", days);
                        _DAO.AddParam("@jobdata", web.Site.RootWeb.Url);
                        _DAO.AddParam("@lastqueuecheck", DBNull.Value);
                        _DAO.AddParam("@parentjobuid", DBNull.Value);
                        _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                    }

                    if (runNow && timerjobuid != Guid.Empty)
                        EPMLiveCore.CoreFunctions.enqueue(timerjobuid, 0);
                });
            }
            catch (Exception ex)
            {
                passed = false;
                _ExecutionLogs.Add("     ERROR -- Location: AddTimerJob() -- Message: " + ex.Message);
                _hasErrors = true;
            }
            finally
            {
                _DAO.Dispose();
            }
            return passed;
        }

        private void AddResourceToDataTable(string userPath)
        {
            try
            {
                DataRow dr = _adUsers.NewRow();
                DirectoryEntry de = new DirectoryEntry(userPath);
                DirectorySearcher ds = new DirectorySearcher(de, "(objectClass=user)");
                SearchResult sr = ds.FindOne();
                string spFieldName = string.Empty;
                string adFieldName = string.Empty;

                foreach (string field in _adFieldMappings)
                {
                    try
                    {
                        spFieldName = _adFieldMappingValues[field].ToString(); //For testing only...remove
                        adFieldName = field; //For testing only...remove
                        dr[spFieldName] = sr.Properties[field][0].ToString();
                    }
                    catch (Exception ex)
                    {
                        _ExecutionLogs.Add("     INFO -- Location: AddResourceToDataTable() SPField:" + spFieldName + " ADField:" + adFieldName + " -- Message: " + adFieldName + " property not set for " + userPath + ".");
                    }
                }
                dr["SID"] = GetUserSID(userPath);
                _adUsers.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: AddResourceToDataTable() module level -- Message: " + ex.Message);
                _hasErrors = true;
            }
        }

        private void WriteOutLog()
        {

            StringBuilder sb = new StringBuilder();            //StreamWriter SW;
            //SW = File.AppendText(@"C:\EPMLive\EPMLiveADSyncProcessLog.txt");
            foreach (string entry in _ExecutionLogs)
            {
                //SW.WriteLine(entry);
                sb.Append(entry + "<br/>");
            }
            //SW.WriteLine("\nEPMLive -- AD Sync process finished at:" + DateTime.Now.ToString());
            //SW.Close();
            //SW.Dispose();
            sb.Append("AD Sync process finished at:" + DateTime.Now.ToString() + "<br/>");
            _processLog = sb.ToString();
        }

        //private void CreateExecutionLog()
        //{
        //    StreamWriter SW;
        //    if (Directory.Exists(@"C:\EPMLive"))
        //    {
        //        if (File.Exists(@"C:\EPMLive\EPMLiveADSyncProcessLog.txt"))
        //        {
        //            try
        //            {
        //                File.Delete(@"C:\EPMLive\EPMLiveADSyncProcessLog.txt");
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }
        //    }
        //    else
        //    {
        //        Directory.CreateDirectory(@"C:\EPMLive");
        //    }

        //    SW = File.CreateText(@"C:\EPMLive\EPMLiveADSyncProcessLog.txt");
        //    SW.Close();
        //    SW.Dispose();
        //    _ExecutionLogs.Add("EPMLive -- AD Sync process started at: " + DateTime.Now.ToString());
        //}        

        private void AddProperties(DirectorySearcher ds)
        {
            try
            {
                foreach (string propName in _adFieldMappings)
                {
                    ds.PropertiesToLoad.Add(propName);
                }

                if (!ds.PropertiesToLoad.Contains("userAccountControl"))
                {
                    ds.PropertiesToLoad.Contains("userAccountControl");
                }

            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: AddProperties() module level -- Message: " + ex.Message);
                _hasErrors = true;
            }
        }

        public string GetFullDomain()
        {
            string domain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().ToString();
            string retVal = string.Empty;
            if (domain.Contains("."))
            {
                string[] DCvals = domain.Split(".".ToCharArray()[0]);
                foreach (string val in DCvals)
                {
                    retVal = retVal + "DC=" + val + ",";
                }
                retVal = retVal.Remove(retVal.LastIndexOf(","));
            }

            if (retVal.Contains(","))
            {
                string[] temp = retVal.Split(",".ToCharArray()[0]);
                domain = temp[0].Replace("DC=", "");
            }
            else
            {
                domain = retVal.Replace("DC=", "");
            }
            _domain = domain;
            return retVal; //Full domain
        }

        public string GetUserSIDByCN(string CN, string fullDomain)
        {
            string sid = string.Empty;
            try
            {
                string path = "LDAP://CN=" + CN + ",CN=Users," + fullDomain;
                DirectoryEntry root = new DirectoryEntry(path, null, null, AuthenticationTypes.Secure);
                sid = new SecurityIdentifier((byte[])root.Properties["objectSid"][0], 0).Value.ToUpper();
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: GetUserSIDByCN() -- CN: " + CN + " -- Domain: " + fullDomain + " -- Message: " + ex.Message);
                _hasErrors = true;
            }
            return sid;
        }

        private string GetUserSID(string path)
        {
            string sid = string.Empty;
            try
            {
                DirectoryEntry root = new DirectoryEntry(path, null, null, AuthenticationTypes.Secure);
                sid = new SecurityIdentifier((byte[])root.Properties["objectSid"][0], 0).Value;
            }
            catch (Exception ex)
            {
                _ExecutionLogs.Add("     ERROR -- Location: GetUserSID() -- Path: " + path + " -- Message: " + ex.Message);
                _hasErrors = true;
            }
            return sid;
        }

    }
}
