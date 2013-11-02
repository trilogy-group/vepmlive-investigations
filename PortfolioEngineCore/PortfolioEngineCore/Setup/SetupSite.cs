using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;

namespace PortfolioEngineCore.Setup
{
    public class UserInformation
    {
        public string Username;
        public string DisplayName;
        public string Email;
        public string extid;
    }
    public class DataScript
    {
        public string ScriptName;
        public string Script;
    }

    public class SetupSite
    {
        private bool _errors = false;
        private string _message = "";
        private SqlConnection _CN = null;
        private string _dbcon = "";

        public bool SetupErrors
        {
            get{
                return _errors;
            }
        }

        public string SetupMessage
        {
            get
            {
                return _message;
            }
        }

        private void OpenMaster(string DBSERVER)
        {
            _message += "<br>Opening master Database";

            try
            {
                _CN = new SqlConnection();
                _CN.ConnectionString = "SERVER = " + DBSERVER + "; DATABASE = master;Trusted_Connection=True";
                _CN.Open();
            }
            catch(Exception ex)
            {
                _errors = true;
                _message += "...Error: " + ex.Message;
            }

            _message += "...Success";
        }

        private void createDB(string DBSERVER, string DB, string DBUsername, string DBPassword)
        {
            if(_CN != null && _CN.State == System.Data.ConnectionState.Open)
            {
                _message += "<br>Creating Database";

                SqlCommand cmd = new SqlCommand("Select * from sys.databases where [name] = '" + DB + "'", _CN);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    _errors = true;
                    _message += "...Error: Database Exists";
                }
                dr.Close();

                if(!_errors)
                {
                    try
                    {
                        cmd = new SqlCommand("CREATE DATABASE " + DB, _CN);
                        cmd.ExecuteNonQuery();
                        _message += "...Success";
                    }
                    catch(Exception ex)
                    {
                        _errors = true;
                        _message += "...Error: " + ex.Message;
                    }
                }

                if(!_errors)
                {
                    _message += "<br>Creating Login";
                    try
                    {
                        cmd = new SqlCommand("CREATE LOGIN [" + DBUsername + "] WITH PASSWORD = '" + DBPassword + "', CHECK_POLICY = OFF", _CN);
                        cmd.ExecuteNonQuery();
                        _message += "...Success";
                    }
                    catch(Exception ex)
                    {
                        if(ex.Message.Contains("The server principal '" + DBUsername + "' already exists"))
                        {
                            _message += "...Skipping: Username exists";
                        }
                        else
                        {
                            _errors = true;
                            _message += "...Error: " + ex.Message;
                        }
                    }
                }

                if(!_errors)
                {
                    _message += "<br>Granting Permissions To Login";
                    try
                    {
                        _CN.Close();
                        _CN.ConnectionString = "SERVER = " + DBSERVER + "; DATABASE = " + DB + ";Trusted_Connection=True";
                        _CN.Open();

                        _dbcon = "Provider=SQLOLEDB;Initial Catalog=" + DB + ";Data Source=" + DBSERVER + ";UID=" + DBUsername + ";PWD=" + DBPassword;
                        
                        cmd = new SqlCommand("CREATE USER [" + DBUsername + "] FOR LOGIN [" + DBUsername + "]", _CN);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("sp_addrolemember", _CN);
                        cmd.Parameters.AddWithValue("@rolename", "db_owner");
                        cmd.Parameters.AddWithValue("@membername", DBUsername);
                        
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        _message += "...Success";
                    }
                    catch(Exception ex)
                    {
                        _errors = true;
                        _message += "...Error: " + ex.Message;
                    }
                }
            }
            else
            {
                _errors = true;
                _message += "<br>Error: master Database not open";
            }
        }

        private void RunDBScripts(DataScript[] DataScripts, string ServiceAccount, UserInformation[] AdditionalAdmins, string siteurl)
        {

            _message += "<br>Running Scripts";

            RunDBScript("01_CRTTBLS", Properties.Resources._01_PE_CRTTBLS);
            RunDBScript("02_CRTINDS", Properties.Resources._02_PE_CRTINDS);
            RunDBScript("04_CRTSPS", Properties.Resources._04_PE_CRTSPS);
            RunDBScript("05_CRTVWS", Properties.Resources._05_PE_CRTVWS);
            RunDBScript("07_DATA", Properties.Resources._07_PE_DATA);

            foreach(DataScript script in DataScripts)
            {
                RunDBScript(script.ScriptName, script.Script);
            }

            RunDBScript("99_FixSvcAcct", "UPDATE EPG_RESOURCES set WRES_NT_ACCOUNT='" + ServiceAccount + "' where WRES_ID=1");

            int counter = 100;
            int membercounter = 10000;

            foreach(UserInformation sAdditonalAdmin in AdditionalAdmins)
            {
                RunDBScript(counter + "_ADDADMIN", "INSERT INTO EPG_RESOURCES (WRES_ID,RES_NAME, WRES_USE_NT_LOGON, WRES_NT_ACCOUNT, WRES_CAN_LOGIN, WRES_IS_RESOURCE, WRES_EMAIL, WRES_EXT_UID) VALUES (" + membercounter + ",'" + sAdditonalAdmin.DisplayName + "',1,'" + sAdditonalAdmin.Username + "', 1, 1, '" + sAdditonalAdmin.Email + "', '" + sAdditonalAdmin.extid + "')");
                RunDBScript(counter + "_ADDADMINGRP", "INSERT INTO EPG_GROUP_MEMBERS (GROUP_ID, MEMBER_UID) VALUES (1," + membercounter + ")");
                counter++;
                membercounter++;
            }

            RunDBScript("UPDATEURL", "UPDATE EPG_ADMIN SET ADM_WE_SERVERURL = '" + siteurl + "'");
        }

        private void OpenDB()
        {
            try
            {
                _CN = new SqlConnection(_dbcon.Replace("Provider=SQLOLEDB;", ""));
                _CN.Open();
            }
            catch(Exception ex)
            {
                _errors = true;
                _message += "...Error: " + ex.Message;
            }
        }

        private void RunDBUpgradeScripts()
        {

            _message += "<br>Running Scripts";

            RunDBScript("01_CRTTBLS", Properties.Resources._01_PE_CRTTBLS);
            RunDBScript("02_CRTINDS", Properties.Resources._02_PE_CRTINDS);
            RunDBScript("04_CRTSPS", Properties.Resources._04_PE_CRTSPS);
            RunDBScript("05_CRTVWS", Properties.Resources._05_PE_CRTVWS);
            RunDBScript("07_DATA", Properties.Resources._07_PE_DATA);
        }

        private void RunDBScript(string scriptname, string script)
        {
            _message += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Running Script: " + scriptname;

            try
            {
                int indexOfGo = script.IndexOf("\r\nGO\r\n");

                SqlCommand cmd = new SqlCommand("exec ('" + script.Replace("'","''") + "')", _CN);
                cmd.ExecuteNonQuery();
                _message += "...Success";
            }
            catch(Exception ex)
            {
                _errors = true;
                _message += "...Error: " + ex.Message;
            }
        }

        public RegistryKey GetBaseKey(string server)
        {
            RegistryKey key = Registry.LocalMachine;

            if(server != "")
                key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, server);

            if(key.OpenSubKey("Software", true).OpenSubKey("Wow6432Node", true) != null)
            {
                key = key.OpenSubKey("Software", true).OpenSubKey("Wow6432Node", true);
            }
            else
            {
                key = key.OpenSubKey("Software", true);
            }

            RegistryKey subkey = key.OpenSubKey("EPMLive", true);
            if(subkey == null)
                key = key.CreateSubKey("EPMLive");
            else
                key = subkey;

            subkey = key.OpenSubKey("PortfolioEngine", true);
            if(subkey == null)
                key = key.CreateSubKey("PortfolioEngine");
            else
                key = subkey;

            return key;
        }

        public void AddServer(string server, string basepath, string CN, string PID)
        {
            if(server != "")
            {
                RegistryKey key = GetBaseKey(server);

                key = key.CreateSubKey(basepath);

                key.SetValue("CN", CN);
                key.SetValue("PID", PID);
                key.SetValue("ConnectionString", _dbcon);
                key.SetValue("QMActive", "Yes");
            }
        }

        public void AddRegistryEntries(string basepath, string CN, string PID)
        {
            _message += "<br>Adding Registry Entries";

            try
            {
                RegistryKey key = GetBaseKey("");
                

                key = key.CreateSubKey(basepath);

                key.SetValue("CN", CN);
                key.SetValue("PID", PID);
                key.SetValue("ConnectionString", _dbcon);
                key.SetValue("QMActive", "Yes");

                _message += "...Success";
            }
            catch(Exception ex)
            {
                _errors = true;
                _message += "...Error: " + ex.Message;
            }
        }

        public void UpgradeDB(string basepath)
        {
            _message += "Checking BasePath";
            if(MakeSureBasePathExists(basepath))
            {
                _message += "...Success";
                Debugger debug = new Debugger(false);

                _message += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Opening Database";
                OpenDB();

                if(!_errors)
                {
                    _message += "...Success";
                    RunDBUpgradeScripts();
                }

                if(!_errors)
                {
                    SetVersionInDB();
                }

                if(!_errors)
                {
                    
                    _message += "<br><br>Upgrade Successful";
                }

                try
                {
                    _CN.Close();
                }
                catch { }
            }
            else
            {
                _errors = true;
                _message += "...Error: BasePath registry entry not found.";
            }


        }

        private string GetAssemblyVersion()
        {
            string result = string.Empty;
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                result = string.Join(".", new string[] { fvi.ProductMajorPart.ToString(), fvi.ProductMinorPart.ToString(), fvi.ProductBuildPart.ToString(), fvi.ProductPrivatePart.ToString() });
            }
            catch { }

            return result;
        }

        private void SetVersionInDB()
        {
            //RunDBScript("UPDATEVERSION", "INSERT INTO EPG_SYSTEM (SY_VERSION, SY_INSTALLED) VALUES (" + GetAssemblyVersion().Replace(".","") + ",GETDATE())");
        }

        public void Setup(string basepath, string PID, string CN, string DBSERVER, string DB, string DBUsername, string DBPassword, DataScript[] DataScripts, string ServiceAccount, UserInformation[] AdditionalAdmins, string spweburl)
        {
            _message += "Checking BasePath";
            if(CheckBasePath(basepath))
            {
                _message += "...Success";
                Debugger debug = new Debugger(false);
                _message += "<br>Checking Activation";
                try
                {
                    Activation act = new Activation(debug);
                    act.checkActivation("", PID, CN);
                    _message += "...Success";
                }
                catch(PFEException ex)
                {
                    _errors = true;
                    _message += "...Error: " + ex.Message;
                }

                if(!_errors)
                {
                    OpenMaster(DBSERVER);

                    if(!_errors)
                        createDB(DBSERVER, DB, DBUsername, DBPassword);

                    if(!_errors)
                        RunDBScripts(DataScripts, ServiceAccount, AdditionalAdmins, spweburl);

                    SetVersionInDB();

                    if(!_errors)
                        AddRegistryEntries(basepath, CN, PID);



                    try
                    {
                        _CN.Close();
                    }
                    catch { }
                }
            }
            else
            {
                 _errors = true;
                 _message += "...Error: BasePath already in use.";
            }
        }

        public bool CheckBasePath(string basepath)
        {
            try
            {
                RegistryKey key = null;
                if(Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey("Wow6432Node", true) != null)
                {
                    key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey("Wow6432Node",true).OpenSubKey("EPMLive", true).OpenSubKey("PortfolioEngine", true).OpenSubKey(basepath);
                }
                else
                {
                    key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey("EPMLive", true).OpenSubKey("PortfolioEngine", true).OpenSubKey(basepath);
                }
                if(key == null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }

        public bool MakeSureBasePathExists(string basepath)
        {
            try
            {
                RegistryKey key = null;
                if(Registry.LocalMachine.OpenSubKey("Software", false).OpenSubKey("Wow6432Node", false) != null)
                {
                    key = Registry.LocalMachine.OpenSubKey("Software", false).OpenSubKey("Wow6432Node", false).OpenSubKey("EPMLive", false).OpenSubKey("PortfolioEngine", false).OpenSubKey(basepath);
                }
                else
                {
                    key = Registry.LocalMachine.OpenSubKey("Software", false).OpenSubKey("EPMLive", false).OpenSubKey("PortfolioEngine", false).OpenSubKey(basepath);
                    
                }
                if(key != null)
                {
                    _dbcon = key.GetValue("ConnectionString").ToString();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public void RenamePermissions(string basepath,Dictionary<string,string> permissionsDictionary)
        {
            _message += "Checking BasePath";

            if (MakeSureBasePathExists(basepath))
            {
                _message += "...Success";
                var debug = new Debugger(false);

                _message += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Opening Database";

                OpenDB();

                if (!_errors)
                {
                    _message += "...Success";
                    RenamePFEPermissions(permissionsDictionary);
                }

                if (!_errors)
                {
                    _message += "<br><br>All permissions renamed successfully";
                }

                try
                {
                    _CN.Close();
                }
                catch { }
            }
            else
            {
                _errors = true;
                _message += "...Error: BasePath registry entry not found.";
            }
        }

        private void RenamePFEPermissions(Dictionary<string, string> permissionsDictionary)
        {
            _message += "<br>Renaming Permissions";

            foreach (KeyValuePair<string, string> keyValuePair in permissionsDictionary)
            {
                string oldValue = keyValuePair.Key;
                string newValue = keyValuePair.Value;

                _message += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Renaming " + oldValue + " to " + newValue;

                try
                {
                    using (var cmd = new SqlCommand("UPDATE EPG_GROUPS SET GROUP_NAME = @New WHERE GROUP_NAME = @Old AND GROUP_ENTITY = 1", _CN))
                    {
                        cmd.Parameters.AddWithValue("@New", newValue);
                        cmd.Parameters.AddWithValue("@Old", oldValue);

                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }

                    _message += "...Success";
                }
                catch (Exception ex)
                {
                    _errors = true;
                    _message += "...Error: " + ex.Message;
                }
            }
        }
    }
}
