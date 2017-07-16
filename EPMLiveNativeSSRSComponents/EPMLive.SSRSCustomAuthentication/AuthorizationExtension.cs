using EPMLive.SSRSCustomAuthentication.Exceptions;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace EPMLive.SSRSCustomAuthentication
{
    public class AuthorizationExtension : IAuthorizationExtension
    {
        private static Hashtable modelItemOperations;
        private static Hashtable modelOperations;
        private static Hashtable catalogOperation;
        private static Hashtable folderOperations;
        private static Hashtable reportOperations;
        private static Hashtable resourceOperations;
        private static Hashtable datasourceOperations;

        private const int reportOperationsCount = 27;
        private const int folderOperationsCount = 10;
        private const int resourceOperationsCount = 7;
        private const int datasourceOperationsCount = 7;
        private const int catalogOperationsCount = 16;
        private const int modelOperationsCount = 11;
        private const int modelItemOperationsCount = 1;

        private string usernames = string.Empty;

        static AuthorizationExtension()
        {
            InitializeMaps();
        }

        public string LocalizedName
        {
            get
            {
                return null;
            }
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, CatalogOperation[] requiredOperations)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            foreach (CatalogOperation operation in requiredOperations)
            {
                if (!CheckAccess(userName, userToken, secDesc, operation))
                    return false;
            }
            return true;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, FolderOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (FolderOperation operation in ace.FolderOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, ResourceOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (ResourceOperation operation in ace.ResourceOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, DatasourceOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (DatasourceOperation operation in ace.DatasourceOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, ModelItemOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (ModelItemOperation operation in ace.ModelItemOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, ModelOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (ModelOperation operation in ace.ModelOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, ResourceOperation[] requiredOperations)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            foreach (ResourceOperation operation in requiredOperations)
            {
                if (!CheckAccess(userName, userToken, secDesc, operation))
                    return false;
            }
            return true;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, FolderOperation[] requiredOperations)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            foreach (FolderOperation operation in requiredOperations)
            {
                if (!CheckAccess(userName, userToken, secDesc, operation))
                    return false;
            }
            return true;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, ReportOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (ReportOperation operation in ace.ReportOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string userName, IntPtr userToken, byte[] secDesc, CatalogOperation requiredOperation)
        {
            if (usernames.Split(',').ToList().Contains(userName))
                return true;

            var acl = DeserializeAcl(secDesc);

            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (CatalogOperation operation in ace.CatalogOperations)
                    {
                        if (operation == requiredOperation)
                            return true;
                    }
                }
            }

            return false;
        }

        public byte[] CreateSecurityDescriptor(AceCollection acl, SecurityItemType itemType, out string stringSecDesc)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var result = new MemoryStream())
            {
                binaryFormatter.Serialize(result, acl);
                stringSecDesc = null;
                return result.GetBuffer();
            }
        }

        public StringCollection GetPermissions(string userName, IntPtr userToken, SecurityItemType itemType, byte[] secDesc)
        {
            if (usernames.Split(',').ToList().Contains(userName))
            {
                return CreateAdminPermissionSet();
            }
            else
            {
                return CreateUserPermissionSet(userName, secDesc);
            }
        }

        private StringCollection CreateUserPermissionSet(string userName, byte[] secDesc)
        {
            var permissions = new StringCollection();
            var acl = DeserializeAcl(secDesc);
            foreach (AceStruct ace in acl)
            {
                if (0 == string.Compare(userName, ace.PrincipalName, true, CultureInfo.CurrentCulture))
                {
                    foreach (ModelItemOperation aclOperation in ace.ModelItemOperations)
                    {
                        if (!permissions.Contains((string)modelItemOperations[aclOperation]))
                            permissions.Add((string)modelItemOperations[aclOperation]);
                    }
                    foreach (ModelOperation aclOperation in ace.ModelOperations)
                    {
                        if (!permissions.Contains((string)modelOperations[aclOperation]))
                            permissions.Add((string)modelOperations[aclOperation]);
                    }
                    foreach (CatalogOperation aclOperation in ace.CatalogOperations)
                    {
                        if (!permissions.Contains((string)catalogOperation[aclOperation]))
                            permissions.Add((string)catalogOperation[aclOperation]);
                    }
                    foreach (ReportOperation aclOperation in ace.ReportOperations)
                    {
                        if (!permissions.Contains((string)reportOperations[aclOperation]))
                            permissions.Add((string)reportOperations[aclOperation]);
                    }
                    foreach (FolderOperation aclOperation in ace.FolderOperations)
                    {
                        if (!permissions.Contains((string)folderOperations[aclOperation]))
                            permissions.Add((string)folderOperations[aclOperation]);
                    }
                    foreach (ResourceOperation aclOperation in ace.ResourceOperations)
                    {
                        if (!permissions.Contains((string)resourceOperations[aclOperation]))
                            permissions.Add((string)resourceOperations[aclOperation]);
                    }
                    foreach (DatasourceOperation aclOperation in ace.DatasourceOperations)
                    {
                        if (!permissions.Contains((string)datasourceOperations[aclOperation]))
                            permissions.Add((string)datasourceOperations[aclOperation]);
                    }
                }
            }

            return permissions;
        }

        private StringCollection CreateAdminPermissionSet()
        {
            var permissions = new StringCollection();

            foreach (CatalogOperation operation in catalogOperation.Keys)
            {
                if (!permissions.Contains((string)catalogOperation[operation]))
                    permissions.Add((string)catalogOperation[operation]);
            }
            foreach (ModelItemOperation operation in modelItemOperations.Keys)
            {
                if (!permissions.Contains((string)modelItemOperations[operation]))
                    permissions.Add((string)modelItemOperations[operation]);
            }
            foreach (ModelOperation operation in modelOperations.Keys)
            {
                if (!permissions.Contains((string)modelOperations[operation]))
                    permissions.Add((string)modelOperations[operation]);
            }
            foreach (CatalogOperation operation in catalogOperation.Keys)
            {
                if (!permissions.Contains((string)catalogOperation[operation]))
                    permissions.Add((string)catalogOperation[operation]);
            }
            foreach (ReportOperation operation in reportOperations.Keys)
            {
                if (!permissions.Contains((string)reportOperations[operation]))
                    permissions.Add((string)reportOperations[operation]);
            }
            foreach (FolderOperation operation in folderOperations.Keys)
            {
                if (!permissions.Contains((string)folderOperations[operation]))
                    permissions.Add((string)folderOperations[operation]);
            }
            foreach (ResourceOperation operation in resourceOperations.Keys)
            {
                if (!permissions.Contains((string)resourceOperations[operation]))
                    permissions.Add((string)resourceOperations[operation]);
            }
            foreach (DatasourceOperation operation in datasourceOperations.Keys)
            {
                if (!permissions.Contains((string)datasourceOperations[operation]))
                    permissions.Add((string)datasourceOperations[operation]);
            }

            return permissions;
        }

        public void SetConfiguration(string configuration)
        {
            var doc = new XmlDocument();
            doc.LoadXml(configuration);
            if (doc.DocumentElement.Name == "AdminConfiguration")
            {
                foreach (XmlNode child in doc.DocumentElement.ChildNodes)
                {
                    if (child.Name == "UserName")
                    {
                        usernames = child.InnerText;
                    }
                }
            }
        }

        private static void InitializeMaps()
        {
            MapModelItemOperation();
            MapModelOperations();
            MapCatalogOperations();
            MapFolderOperations();
            MapReportOperations();
            MapResourceOperations();
            MapDatasourceOperations();
        }

        private static void MapDatasourceOperations()
        {
            datasourceOperations = new Hashtable();
            datasourceOperations.Add(DatasourceOperation.Delete, OperationNames.OperDelete);
            datasourceOperations.Add(DatasourceOperation.ReadProperties, OperationNames.OperReadProperties);
            datasourceOperations.Add(DatasourceOperation.UpdateProperties, OperationNames.OperUpdateProperties);
            datasourceOperations.Add(DatasourceOperation.ReadContent, OperationNames.OperReadContent);
            datasourceOperations.Add(DatasourceOperation.UpdateContent, OperationNames.OperUpdateContent);
            datasourceOperations.Add(DatasourceOperation.ReadAuthorizationPolicy, OperationNames.OperReadAuthorizationPolicy);
            datasourceOperations.Add(DatasourceOperation.UpdateDeleteAuthorizationPolicy, OperationNames.OperUpdateDeleteAuthorizationPolicy);
            if (datasourceOperations.Count != datasourceOperationsCount)
            {
                throw new IncorrectMappingException("Datasource operations not mapped correctly.");
            }
        }

        private static void MapResourceOperations()
        {
            resourceOperations = new Hashtable();
            resourceOperations.Add(ResourceOperation.Delete, OperationNames.OperDelete);
            resourceOperations.Add(ResourceOperation.ReadProperties, OperationNames.OperReadProperties);
            resourceOperations.Add(ResourceOperation.UpdateProperties, OperationNames.OperUpdateProperties);
            resourceOperations.Add(ResourceOperation.ReadContent, OperationNames.OperReadContent);
            resourceOperations.Add(ResourceOperation.UpdateContent, OperationNames.OperUpdateContent);
            resourceOperations.Add(ResourceOperation.ReadAuthorizationPolicy, OperationNames.OperReadAuthorizationPolicy);
            resourceOperations.Add(ResourceOperation.UpdateDeleteAuthorizationPolicy, OperationNames.OperUpdateDeleteAuthorizationPolicy);

            if (resourceOperations.Count != resourceOperationsCount)
            {
                throw new IncorrectMappingException("Resource operations not mapped correctly.");
            }
        }

        private static void MapReportOperations()
        {
            reportOperations = new Hashtable();
            reportOperations.Add(ReportOperation.Delete, OperationNames.OperDelete);
            reportOperations.Add(ReportOperation.ReadProperties, OperationNames.OperReadProperties);
            reportOperations.Add(ReportOperation.UpdateProperties, OperationNames.OperUpdateProperties);
            reportOperations.Add(ReportOperation.UpdateParameters, OperationNames.OperUpdateParameters);
            reportOperations.Add(ReportOperation.ReadDatasource, OperationNames.OperReadDatasources);
            reportOperations.Add(ReportOperation.UpdateDatasource, OperationNames.OperUpdateDatasources);
            reportOperations.Add(ReportOperation.ReadReportDefinition, OperationNames.OperReadReportDefinition);
            reportOperations.Add(ReportOperation.UpdateReportDefinition, OperationNames.OperUpdateReportDefinition);
            reportOperations.Add(ReportOperation.CreateSubscription, OperationNames.OperCreateSubscription);
            reportOperations.Add(ReportOperation.DeleteSubscription, OperationNames.OperDeleteSubscription);
            reportOperations.Add(ReportOperation.ReadSubscription, OperationNames.OperReadSubscription);
            reportOperations.Add(ReportOperation.UpdateSubscription, OperationNames.OperUpdateSubscription);
            reportOperations.Add(ReportOperation.CreateAnySubscription, OperationNames.OperCreateAnySubscription);
            reportOperations.Add(ReportOperation.DeleteAnySubscription, OperationNames.OperDeleteAnySubscription);
            reportOperations.Add(ReportOperation.ReadAnySubscription, OperationNames.OperReadAnySubscription);
            reportOperations.Add(ReportOperation.UpdateAnySubscription, OperationNames.OperUpdateAnySubscription);
            reportOperations.Add(ReportOperation.UpdatePolicy, OperationNames.OperUpdatePolicy);
            reportOperations.Add(ReportOperation.ReadPolicy, OperationNames.OperReadPolicy);
            reportOperations.Add(ReportOperation.DeleteHistory, OperationNames.OperDeleteHistory);
            reportOperations.Add(ReportOperation.ListHistory, OperationNames.OperListHistory);
            reportOperations.Add(ReportOperation.ExecuteAndView, OperationNames.OperExecuteAndView);
            reportOperations.Add(ReportOperation.CreateResource, OperationNames.OperCreateResource);
            reportOperations.Add(ReportOperation.CreateSnapshot, OperationNames.OperCreateSnapshot);
            reportOperations.Add(ReportOperation.ReadAuthorizationPolicy, OperationNames.OperReadAuthorizationPolicy);
            reportOperations.Add(ReportOperation.UpdateDeleteAuthorizationPolicy, OperationNames.OperUpdateDeleteAuthorizationPolicy);
            reportOperations.Add(ReportOperation.Execute, OperationNames.OperExecute);
            reportOperations.Add(ReportOperation.CreateLink, OperationNames.OperCreateLink);

            if (reportOperations.Count != reportOperationsCount)
            {
                throw new IncorrectMappingException("Report operations not mapped correctly.");
            }
        }

        private static void MapFolderOperations()
        {
            folderOperations = new Hashtable();
            folderOperations.Add(FolderOperation.CreateFolder, OperationNames.OperCreateFolder);
            folderOperations.Add(FolderOperation.Delete, OperationNames.OperDelete);
            folderOperations.Add(FolderOperation.ReadProperties, OperationNames.OperReadProperties);
            folderOperations.Add(FolderOperation.UpdateProperties, OperationNames.OperUpdateProperties);
            folderOperations.Add(FolderOperation.CreateReport, OperationNames.OperCreateReport);
            folderOperations.Add(FolderOperation.CreateResource, OperationNames.OperCreateResource);
            folderOperations.Add(FolderOperation.ReadAuthorizationPolicy, OperationNames.OperReadAuthorizationPolicy);
            folderOperations.Add(FolderOperation.UpdateDeleteAuthorizationPolicy, OperationNames.OperUpdateDeleteAuthorizationPolicy);
            folderOperations.Add(FolderOperation.CreateDatasource, OperationNames.OperCreateDatasource);
            folderOperations.Add(FolderOperation.CreateModel, OperationNames.OperCreateModel);
            if (folderOperations.Count != folderOperationsCount)
            {
                throw new IncorrectMappingException("Folder operations not mapped correctly.");
            }
        }

        private static void MapCatalogOperations()
        {
            catalogOperation = new Hashtable();
            catalogOperation.Add(CatalogOperation.CreateRoles, OperationNames.OperCreateRoles);
            catalogOperation.Add(CatalogOperation.DeleteRoles, OperationNames.OperDeleteRoles);
            catalogOperation.Add(CatalogOperation.ReadRoleProperties, OperationNames.OperReadRoleProperties);
            catalogOperation.Add(CatalogOperation.UpdateRoleProperties, OperationNames.OperUpdateRoleProperties);
            catalogOperation.Add(CatalogOperation.ReadSystemProperties, OperationNames.OperReadSystemProperties);
            catalogOperation.Add(CatalogOperation.UpdateSystemProperties, OperationNames.OperUpdateSystemProperties);
            catalogOperation.Add(CatalogOperation.GenerateEvents, OperationNames.OperGenerateEvents);
            catalogOperation.Add(CatalogOperation.ReadSystemSecurityPolicy, OperationNames.OperReadSystemSecurityPolicy);
            catalogOperation.Add(CatalogOperation.UpdateSystemSecurityPolicy, OperationNames.OperUpdateSystemSecurityPolicy);
            catalogOperation.Add(CatalogOperation.CreateSchedules, OperationNames.OperCreateSchedules);
            catalogOperation.Add(CatalogOperation.DeleteSchedules, OperationNames.OperDeleteSchedules);
            catalogOperation.Add(CatalogOperation.ReadSchedules, OperationNames.OperReadSchedules);
            catalogOperation.Add(CatalogOperation.UpdateSchedules, OperationNames.OperUpdateSchedules);
            catalogOperation.Add(CatalogOperation.ListJobs, OperationNames.OperListJobs);
            catalogOperation.Add(CatalogOperation.CancelJobs, OperationNames.OperCancelJobs);
            catalogOperation.Add(CatalogOperation.ExecuteReportDefinition, OperationNames.ExecuteReportDefinition);
            if (catalogOperation.Count != catalogOperationsCount)
            {
                throw new IncorrectMappingException("Catalog operations not mapped correctly.");
            }
        }

        private static void MapModelOperations()
        {
            modelOperations = new Hashtable();
            modelOperations.Add(ModelOperation.Delete, OperationNames.OperDelete);
            modelOperations.Add(ModelOperation.ReadAuthorizationPolicy, OperationNames.OperReadAuthorizationPolicy);
            modelOperations.Add(ModelOperation.ReadContent, OperationNames.OperReadContent);
            modelOperations.Add(ModelOperation.ReadDatasource, OperationNames.OperReadDatasources);
            modelOperations.Add(ModelOperation.ReadModelItemAuthorizationPolicies, OperationNames.OperReadModelItemSecurityPolicies);
            modelOperations.Add(ModelOperation.ReadProperties, OperationNames.OperReadProperties);
            modelOperations.Add(ModelOperation.UpdateContent, OperationNames.OperUpdateContent);
            modelOperations.Add(ModelOperation.UpdateDatasource, OperationNames.OperUpdateDatasources);
            modelOperations.Add(ModelOperation.UpdateDeleteAuthorizationPolicy, OperationNames.OperUpdateDeleteAuthorizationPolicy);
            modelOperations.Add(ModelOperation.UpdateModelItemAuthorizationPolicies, OperationNames.OperUpdateModelItemSecurityPolicies);
            modelOperations.Add(ModelOperation.UpdateProperties, OperationNames.OperUpdatePolicy);

            if (modelOperations.Count != modelOperationsCount)
            {
                throw new IncorrectMappingException("Model operations not mapped correctly.");
            }
        }

        private static void MapModelItemOperation()
        {
            modelItemOperations = new Hashtable();
            modelItemOperations.Add(ModelItemOperation.ReadProperties, OperationNames.OperReadProperties);

            if (modelItemOperations.Count != modelItemOperationsCount)
            {
                throw new IncorrectMappingException("Model item operations not mapped correctly.");
            }
        }

        private AceCollection DeserializeAcl(byte[] secDesc)
        {
            var accessControls = new AceCollection();
            if (secDesc != null)
            {
                var binaryFormatter = new BinaryFormatter();
                using (var securityDescriptorStream = new MemoryStream(secDesc))
                {
                    accessControls = (AceCollection)binaryFormatter.Deserialize(securityDescriptorStream);
                }
            }
            return accessControls;
        }
    }
}