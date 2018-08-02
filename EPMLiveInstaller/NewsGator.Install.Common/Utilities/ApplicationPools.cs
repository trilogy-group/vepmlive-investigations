using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;
using System.Globalization;

namespace NewsGator.Install.Common.Utilities
{
    public static class ApplicationPools
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static Collection<SPManagedAccount> GetManagedAccounts()
        {
            var accounts = new Collection<SPManagedAccount>();
            foreach (SPManagedAccount account in new SPFarmManagedAccountCollection(LocalFarm.Get()))
            {
                accounts.Add(account);
            }
            return accounts;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static Collection<string> GetManagedAccountsNames()
        {
            var accounts = new Collection<string>();
            foreach (var account in GetManagedAccounts())
            {
                accounts.Add(account.Username);
            }
            return accounts;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static Collection<SPIisWebServiceApplicationPool> GetServiceApplicationPools()
        {
            var results = new Collection<SPIisWebServiceApplicationPool>();

            Type settingsType = Utilities.Types.GetSharePointType("Microsoft.SharePoint.Administration.SPIisWebServiceSettings");
            PropertyInfo defaultInstance = settingsType.GetProperty("Default");
            var settings = defaultInstance.GetValue(settingsType, null);
            if (settings != null)
            {
                PropertyInfo poolsProperty = settingsType.GetProperty("ApplicationPools", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
                var pools = poolsProperty.GetValue(settings, null) as SPPersistedChildCollection<SPIisWebServiceApplicationPool>;
                foreach (SPIisWebServiceApplicationPool pool in pools)
                {
                    if (pool != null)
                    {
                        results.Add(pool);
                    }
                }
            }

            return results;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static Collection<string> GetServiceApplicationPoolsNames()
        {
            var appPools = new Collection<string>();            

            foreach (var appPool in GetServiceApplicationPools())
            {
                appPools.Add(appPool.Name);
            }

            return appPools;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ApplicationPool"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue GetOrCreateApplicationPool(string name, string username, string password, out SPIisWebServiceApplicationPool applicationPool)
        {
            var outputQueue = new OutputQueue();

            applicationPool = null;

            try
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingExistingServiceApplicationPool, name));
                applicationPool = LocalFarm.Get().GetObject(name, Guid.Empty, typeof(SPIisWebServiceApplicationPool)) as SPIisWebServiceApplicationPool;
                if (applicationPool != null)
                {
                    outputQueue.Add(UserDisplay.ExistingServiceApplicationPoolFound);
                    return outputQueue;
                }

                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CreatingServiceApplicationPool, name));

                Type appPoolType = null;
                Type optionsType = null;

                appPoolType = Type.GetType(string.Format(CultureInfo.InvariantCulture,
                    "Microsoft.SharePoint.Administration.SPIisWebServiceApplicationPool, Microsoft.SharePoint, Version={0}.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c",
                    LocalFarm.Get().BuildVersion.Major));
                optionsType = Type.GetType(string.Format(CultureInfo.InvariantCulture,
                    "Microsoft.SharePoint.Administration.SPIisWebServiceApplicationPoolProvisioningOptions, Microsoft.SharePoint, Version={0}.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c",
                    LocalFarm.Get().BuildVersion.Major));

                if ((appPoolType != null) && (optionsType != null))
                {
                    var noneOption = optionsType.GetField("None").GetValue(optionsType);

                    SPProcessAccount processAccount = LocalFarm.Get().DefaultServiceAccount;

                    if (!string.IsNullOrEmpty(username))
                    {
                        NTAccount account = new NTAccount(username);
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingExistingManagedAccount, username));
                        SPProcessAccount lookupAccount = SPProcessAccount.LookupManagedAccount((SecurityIdentifier)account.Translate(typeof(SecurityIdentifier)));
                        if (lookupAccount != null)
                        {
                            processAccount = lookupAccount;
                        }
                        else if (!string.IsNullOrEmpty(password))
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CreatingManagedAccount, username));
                            var securePassword = password.ToSecureString();
                            var accountConstructor = typeof(SPProcessAccount).GetConstructor(new[] { typeof(NTAccount), typeof(SecureString) });
                            processAccount = (SPProcessAccount)accountConstructor.Invoke(new object[] { account, securePassword });
                            Reflection.ExecuteMethod(processAccount.GetType(), processAccount, "FindOrCreateManagedAccount", new Type[] { }, null);
                        }
                    }

                    MethodInfo beginProvision = appPoolType.GetMethod("BeginProvision", BindingFlags.Instance | BindingFlags.NonPublic);
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.ProvisioningServiceApplicationPool, name));
                    applicationPool = (SPIisWebServiceApplicationPool)Reflection.ExecuteMethod(appPoolType, "Create", new Type[] { typeof(SPFarm), typeof(String), typeof(SPProcessAccount) }, new object[] { LocalFarm.Get(), name, processAccount });
                    applicationPool.Update();
                    beginProvision.Invoke(applicationPool, new object[] { noneOption });
                    WaitAppPoolJob(applicationPool);
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.ProvisioningServiceApplicationPoolComplete, name));
                }
                else
                {
                    throw new InvalidOperationException("ApplicationPool");
                }
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.ApplicationPoolException, name, exception.Message), OutputType.Error, exception.ToString(), exception);
            }

            return outputQueue;
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        private static void WaitAppPoolJob(SPIisWebServiceApplicationPool pool)
        {
            bool wait = true;
            var timeOut = DateTime.Now.AddMinutes(10);
            while (wait)
            {
                if (DateTime.Now > timeOut)
                    throw new TimeoutException();

                SPJobDefinition job = GetJob(pool.Id);
                if (job == null)
                {
                    wait = false;
                }

                //FarmExtensions.ClearFarmCache();
                Thread.Sleep(1000); 
            }
        }

        private static SPJobDefinition GetJob(Guid id)
        {
            var timerService = LocalFarm.Get().TimerService;
            foreach (SPJobDefinition job in timerService.JobDefinitions)
            {
                if (job.Name == id.ToString())
                    return job;
            }
            return null;
        }
    }
}
