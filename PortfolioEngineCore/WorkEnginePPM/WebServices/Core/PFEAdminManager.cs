using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.Infrastructure.Entities;
using WorkEnginePPM.Core;
using EPMUtils = EPMLiveCore.API.Utils;
using System.Xml;

namespace WorkEnginePPM.WebServices.Core
{
    internal class PFEAdminManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="PFEAdminManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public PFEAdminManager(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (20) 

        // Private Methods (3) 

        /// <summary>
        /// Builds the cost category tree.
        /// </summary>
        /// <param name="costCategory">The cost category.</param>
        /// <param name="parentElement">The parent element.</param>
        private void BuildCostCategoryTree(PortfolioEngineCore.Infrastructure.Entities.CostCategory costCategory,
                                           ref XElement parentElement)
        {
            var costCategoryElement = new XElement("CostCategory", new XAttribute("Id", costCategory.Id),
                                                   new XAttribute("Name", costCategory.Name));

            foreach (Role role in costCategory.Roles)
            {
                costCategoryElement.Add(new XElement("Role", new XAttribute("Id", role.Id),
                                                     new XAttribute("CostCategoryRoleId", role.CostCategoryRoleId),
                                                     new XAttribute("Name", role.Name)));
            }

            parentElement.Add(costCategoryElement);

            foreach (PortfolioEngineCore.Infrastructure.Entities.CostCategory category in costCategory.CostCategories)
            {
                BuildCostCategoryTree(category, ref costCategoryElement);
            }
        }

        /// <summary>
        /// Gets the admin core.
        /// </summary>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="debugging"> </param>
        /// <returns></returns>
        private Admininfos GetAdminCore(SecurityLevels secLevel, bool debugging = false)
        {
            Admininfos adminClass = null;

            SPSecurity.RunWithElevatedPrivileges(
                () => { adminClass = InitilizeAdminCore(secLevel, debugging, Username); });

            return adminClass;
        }

        /// <summary>
        /// Initilizes the admin core.
        /// </summary>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="debugging">if set to <c>true</c> [debugging].</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private Admininfos InitilizeAdminCore(SecurityLevels secLevel, bool debugging, string username)
        {
            Admininfos adminClass;

            using (var site = new SPSite(Web.Site.ID))
            {
                SPWeb rootWeb = site.RootWeb;

                string basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                string ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                string ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                string ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                adminClass = new Admininfos(basePath, username, ppmId, ppmCompany, ppmDbConn, secLevel, debugging);
            }

            return adminClass;
        }

        // Internal Methods (17) 

        /// <summary>
        /// Deletes department items in lookup and related infos.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteDepartments(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> listDepts = xDataInputElement.GetList("Department");
                if (listDepts == null || listDepts.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xSelDept in listDepts)
                {
                    int UID = xSelDept.GetIntAttr("Id");
                    string dataId = xSelDept.GetStringAttr("DataId");

                    try
                    {
                        string deletemessage;
                        if (adminCore.CanDeleteLookupValue(UID, out deletemessage) == false)
                        {
                            var xdept = new CStruct();
                            xdept.Initialize("Department");
                            xdept.CreateIntAttr("Id", UID);
                            xdept.CreateStringAttr("DataId", dataId);
                            CStruct xresult = xdept.CreateSubStruct("Result");
                            xresult.CreateIntAttr("Status", 1);
                            xresult.CreateCDataSection("Cannot delete item, it is used as follows: " + deletemessage);
                            xdataElement.AppendSubStruct(xdept);
                        }
                        else
                        {
                            bool bDeleted = adminCore.DeleteDepartments(UID);
                            var xdept = new CStruct();
                            xdept.Initialize("Department");
                            xdept.CreateIntAttr("Id", UID);
                            xdept.CreateStringAttr("DataId", dataId);
                            CStruct xresult = xdept.CreateSubStruct("Result");
                            if (bDeleted)
                            {
                                xresult.CreateIntAttr("Status", 0);
                            }
                            else
                            {
                                xresult.CreateIntAttr("Status", 1);
                                xresult.CreateCDataSection("Failed to delete Lookup Value");
                            }
                            xdataElement.AppendSubStruct(xdept);
                        }
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("Department");
                        dataElement.Add(new XAttribute("DataId", dataId));
                        var resultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref resultElement);
                        dataElement.Add(resultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteDepartments, exception);
            }
        }

        /// <summary>
        /// Deletes Holiday Schedule
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteHolidaySchedule(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> dataitems = xDataInputElement.GetList("HolidaySchedule");
                if (dataitems == null || dataitems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xselitem in dataitems)
                {
                    string sresult;
                    try
                    {
                         int UID = xselitem.GetIntAttr("Id");
                        string dataId = xselitem.GetStringAttr("DataId");
                        string deletemessage;
                        if (adminCore.CanDeleteHolidaySchedule(UID, out deletemessage) == false)
                        {
                            var xHOL = new CStruct();
                            xHOL.Initialize("HolidaySchedule");
                            xHOL.CreateIntAttr("Id", UID);
                            xHOL.CreateStringAttr("DataId", dataId);
                            CStruct xresult = xHOL.CreateSubStruct("Result");
                            xresult.CreateIntAttr("Status", 1);
                            xresult.CreateCDataSection("Cannot delete item, it is used as follows: " + deletemessage);
                            xdataElement.AppendSubStruct(xHOL);
                        }
                        else
                        {
                            bool bResult = adminCore.DeleteHolidaySchedule(xselitem.XML(), out sresult);
                            var xresult = new CStruct();
                            xresult.LoadXML(sresult);
                            xdataElement.AppendSubStruct(xresult);
                        }
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("HolidaySchedule");
                        var hsResultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref hsResultElement);
                        dataElement.Add(hsResultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteHolidaySchedules, exception);
            }
        }

        /// <summary>
        /// Deletes Scheduled Work for a PI by Item - Work2 from a SP List(s).
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteListWork(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");

                string sResult = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                try
                {
                    bUpdateOK = adminCore.DeleteListWork(xDataInputElement.XML(), out sResult);
                    bUpdateOK = true; // now whether it worked or not at a data level will be contained in the Result
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteListWork, exception);
            }
        }

        /// <summary>
        /// Deletes individual items from the Personal Items List
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeletePersonalItems(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> listItems = xDataInputElement.GetList("Item");
                if (listItems == null || listItems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xSelItem in listItems)
                {
                    int UID = xSelItem.GetIntAttr("Id");
                    string dataId = xSelItem.GetStringAttr("DataId");

                    try
                    {
                        bool bDeleted = adminCore.DeletePersonalItem(UID);
                        var xrole = new CStruct();
                        xrole.Initialize("Item");
                        xrole.CreateIntAttr("Id", UID);
                        xrole.CreateStringAttr("DataId", dataId);
                        CStruct xresult = xrole.CreateSubStruct("Result");
                        if (bDeleted)
                        {
                            xresult.CreateIntAttr("Status", 0);
                        }
                        else
                        {
                            xresult.CreateIntAttr("Status", 1);
                            xresult.CreateCDataSection("Failed to delete Item");
                        }
                        xdataElement.AppendSubStruct(xrole);
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("Item");
                        dataElement.Add(new XAttribute("DataId", dataId));
                        var resultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref resultElement);
                        dataElement.Add(resultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeletePersonalItems, exception);
            }
        }

        /// <summary>
        /// Deletes All Scheduled Work for a PI  - Work2 from a SP List(s).
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeletePIListWork(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");

                string sResult = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                try
                {
                    bUpdateOK = adminCore.DeletePIListWork(xDataInputElement.XML(), out sResult);
                    bUpdateOK = true; // now whether it worked or not at a data level will be contained in the Result
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeletePIListWork, exception);
            }
        }

        /// <summary>
        /// Deletes Timeoff entries for multiple specified resources
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteResourceTimeoff(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> listItems = xDataInputElement.GetList("Resource");
                if (listItems == null || listItems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xSelItem in listItems)
                {
                    string sresult;
                    try
                    {
                        bool bResult = adminCore.DeleteResourceTimeoff(xSelItem.XML(), out sresult);
                        var xresult = new CStruct();
                        xresult.LoadXML(sresult);
                        xdataElement.AppendSubStruct(xresult);
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("Resource");
                        var resultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref resultElement);
                        dataElement.Add(resultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteResourceTimeOff, exception);
            }
        }

        /// <summary>
        /// Deletes role items in lookup
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteRoles(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                CStruct xSelRole = xDataInputElement.GetSubStruct("Role");
                if (xSelRole == null) throw new Exception("Cannot find the Role element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                int CCUID = 0;
                int UID = xSelRole.GetIntAttr("Id");
                if (UID <= 0) throw new Exception("Cannot find the Role Id.");
                //string dataId = xSelRole.GetStringAttr("DataId");

                string deletemessage;
                string errormessage = "";
                bool bCanDelete = true;
                if (adminCore.CanDeleteLookupValue(UID, out deletemessage) == false)
                {
                    // just one impediment and it is because used as a Cost Category?
                    if (deletemessage == "Cost Categories" + ": " + "Resource Role" + "\n")  
                    {
                        // if > 1 Cost Category with this role we only want to try deleting the one Cost Category identified by CCRId - added Aug 15
                        if (adminCore.CountRoleCategories(UID) <= 1)
                        {
                            // if we can delete the cost category then ok to delete the role which will then also delete the Cost Category
                            if (adminCore.CanDeleteCostCategoryRole(UID, out deletemessage) == false)
                            {
                                errormessage = "Cannot delete Role, it is used as follows: " + deletemessage;
                                bCanDelete = false;
                            }
                        }
                        else
                        {
                            // one last try - see if we can delete just this Cost Category Role
                            CCUID = xSelRole.GetIntAttr("CCRId");
                            if (adminCore.CanDeleteCostCategoryRolebyCCRId(CCUID, UID, out deletemessage) == false)
                            {
                                errormessage = "Cannot delete Role, it is used as follows: " + deletemessage;
                                bCanDelete = false;
                            }
                        }
                    }
                    else
                    {
                        errormessage = "Cannot delete item, it is used as follows: " + deletemessage;
                        bCanDelete = false;
                    }
                }

                if (bCanDelete)
                {
                    bool bDeleted = false;
                    if (CCUID > 0)
                        bDeleted = adminCore.DeleteCCRole(CCUID);
                    else
                        bDeleted = adminCore.DeleteRole(UID);

                    if (bDeleted == false)
                    {
                        errormessage = "Failed to delete item";
                    }
                }

                // Get Cost Category Roles
                string sCCRs = adminCore.GetCCRs();

                if (errormessage.Length > 0)
                {
                    //return Response.Failure(1, errormessage);
                    return "<DeleteRoles> " + Response.Failure(1, errormessage) + " </DeleteRoles>"; ;
                }
                else
                {
                    return Response.Success("", sCCRs);
                }

            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteRoles, exception);
            }
        }

        /// <summary>
        /// Deletes a Work Schedule
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteWorkSchedule(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> dataitems = xDataInputElement.GetList("WorkSchedule");
                if (dataitems == null || dataitems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xselitem in dataitems)
                {
                    string sresult;
                    try
                    {
                        int UID = xselitem.GetIntAttr("Id");
                        string dataId = xselitem.GetStringAttr("DataId");
                        string deletemessage;
                        if (adminCore.CanDeleteWorkSchedule(UID, out deletemessage) == false)
                        {
                            var xWH = new CStruct();
                            xWH.Initialize("WorkSchedule");
                            xWH.CreateIntAttr("Id", UID);
                            xWH.CreateStringAttr("DataId", dataId);
                            CStruct xresult = xWH.CreateSubStruct("Result");
                            xresult.CreateIntAttr("Status", 1);
                            xresult.CreateCDataSection("Cannot delete item, it is used as follows: " + deletemessage);
                            xdataElement.AppendSubStruct(xWH);
                        }
                        else
                        {
                            bool bResult = adminCore.DeleteWorkSchedule(xselitem.XML(), out sresult);
                            var xresult = new CStruct();
                            xresult.LoadXML(sresult);
                            xdataElement.AppendSubStruct(xresult);
                        }
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("WorkSchedule");
                        var wsResultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref wsResultElement);
                        dataElement.Add(wsResultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteWorkSchedule, exception);
            }
        }

        /// <summary>
        /// Gets the cost category roles.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string GetCostCategoryRoles(string data)
        {
            try
            {
                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                var dataElement = new XElement("Data");

                IList<PortfolioEngineCore.Infrastructure.Entities.CostCategory> costCategories =
                    adminCore.GetCostCategoryRoles();

                foreach (PortfolioEngineCore.Infrastructure.Entities.CostCategory costCategory in costCategories)
                {
                    BuildCostCategoryTree(costCategory, ref dataElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.GetCostCategoryRoles, exception);
            }
        }

        /// <summary>
        /// Updates the department lookup and infos.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateDepartments(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                string sResult = "";
                bool bUpdateOK = false;

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                try
                {
                    bUpdateOK = adminCore.UpdateDepartments(xDataInputElement.XML(), out sResult);
                }
                    //catch (Exception exception)  
                    //{
                    //    var deptResultElement = new XElement("Result");
                    //    Utils.SetResultError(exception, ref deptResultElement);
                    //    sResult = deptResultElement.Value;
                    //    bUpdateOK = false;
                    //}
                catch (PFEException pfeException)
                {
                    return Response.PfEFailure(pfeException);
                }
                catch (Exception exception)
                {
                    return Response.Failure((int) APIError.UpdateDepartments, exception);
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateDepartments, exception);
            }
        }

        /// <summary>
        /// gets the department lookup and infos.
        /// </summary>
        /// <returns></returns>
        internal string GetDepartments()
        {
            try
            {
                string sResult = "";

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                string sDepts = adminCore.GetDepts();

                return Response.Success(sDepts);
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.GetDepartments, exception);
            }
        }

        /// <summary>
        /// gets the department lookup and infos.
        /// </summary>
        /// <returns></returns>
        internal string GetHolidaySchedules()
        {
            try
            {
                string sResult = "";

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                string sData = adminCore.GetHOLs();

                return Response.Success(sData);
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.GetHolidaySchedules, exception);
            }
        }

        /// <summary>
        /// gets the department lookup and infos.
        /// </summary>
        /// <returns></returns>
        internal string GetPersonalItems()
        {
            try
            {
                string sResult = "";

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                string sData = adminCore.GetPersonalItems();

                return Response.Success(sData);
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.GetPersonalItems, exception);
            }
        }

        /// <summary>
        /// gets the department lookup and infos.
        /// </summary>
        /// <returns></returns>
        internal string GetWorkSchedules()
        {
            try
            {
                string sResult = "";

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                string sWHs = adminCore.GetWHs();

                return Response.Success(sWHs);
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.GetWorkSchedules, exception);
            }
        }

        /// <summary>
        /// Posts Cost Values for a CB/CT combination
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string PostCostValues(string data)
        {
            //<PostCostValues>
            //  <Params/>
            //    <Data>
            //      <CB Id="1"/>
            //      <CT Id="2"/>
            //      <PI Id="4"/> - not specified means ALL
            //    </Data>
            //</PostCostValues>
            try

            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");

                string sResult = "";
                string sPostInstruction = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                try
                {

                    bUpdateOK = adminCore.PostCostValues(xDataInputElement.XML(), out sResult, out sPostInstruction);
                    if (bUpdateOK)
                    {
                        // check if we need to post back to WorkEngine
                        if (sPostInstruction.Length > 0)
                        {
                            CStruct xPost = new CStruct();
                            xPost.LoadXML(sPostInstruction);
                            CStruct xPIs = xPost.GetSubStruct("PIs");
                            string sPIs = xPIs.GetStringAttr("IDs");

                            // Generate export XML and send to WorkEngine
                            
                            //string sDBConnect = "";
                            string sDBConnect = WebAdmin.GetConnectionString();  //HELP where is Context

                            DBAccess dba = new DBAccess(sDBConnect);
                            if (dba.Open() != StatusEnum.rsSuccess)
                            {
                                sResult = FormatError("PostError0", (int)dba.Status, dba.FormatErrorText());
                                bUpdateOK = false;
                            }
                            else
                            {
                                string sXMLRequest;
                                if (dbaUsers.ExportPIInfo(dba, sPIs, out sXMLRequest) != StatusEnum.rsSuccess)
                                {
                                    sResult = FormatError("PostError1", (int)dba.Status, dba.FormatErrorText());
                                    bUpdateOK = false;
                                }
                                else
                                {
                                    XmlNode xNode;
                                    if (SendXMLToWorkEngine(dba, "UpdateItems", sXMLRequest, out xNode) != StatusEnum.rsSuccess)
                                    {
                                        sResult = FormatError("PostError3", (int)dba.Status, dba.FormatErrorText());
                                        bUpdateOK = false;
                                    }
                                    else
                                    {
                                        if (xNode == null || xNode.OuterXml == "")
                                        {
                                            dba.Status = (StatusEnum)99835;
                                            dba.StatusText = "No response from WorkEngine WebService";
                                            sResult = FormatError("PostError4", (int)dba.Status, dba.FormatErrorText());
                                            bUpdateOK = false;
                                        }
                                        else
                                        {
                                            CStruct xResult = new CStruct();
                                            if (xResult.LoadXML(xNode.OuterXml) == false)
                                            {
                                                dba.Status = (StatusEnum)99834;
                                                dba.StatusText = "Invalid XML response from WorkEngine WebService";
                                                sResult = FormatError("PostError5", (int)dba.Status, dba.FormatErrorText());
                                                bUpdateOK = false;
                                            }
                                            else
                                            {
                                                if (xResult.GetIntAttr("Status") != 0)
                                                {
                                                    CStruct xError = xResult.GetSubStruct("Error");
                                                    if (xError != null)
                                                    {
                                                        string sError = xError.GetStringAttr("ID") + " : " + xError.GetString("");
                                                        dba.Status = (StatusEnum)99833;
                                                        dba.StatusText = "Invalid XML response from WorkEngine WebService. Status=" +
                                                                         xResult.GetStringAttr("Status") + "; Error=" + sError;
                                                        sResult = FormatError("PostError6", (int)dba.Status, dba.FormatErrorText());
                                                        bUpdateOK = false;
                                                    }
                                                    else
                                                    {
                                                        CStruct xItem = xResult.GetSubStruct("Item");
                                                        if (xItem != null)
                                                        {
                                                            string sError = xItem.GetStringAttr("Error") + " : " + xItem.GetString("");
                                                            dba.Status = (StatusEnum)99999;
                                                            dba.StatusText = "Invalid XML response from WorkEngine WebService. Status=" +
                                                                                xResult.GetStringAttr("Status") + "; Error=" + sError;
                                                            sResult = FormatError("PostError7", (int)dba.Status, dba.FormatErrorText());
                                                            bUpdateOK = false;
                                                        }
                                                        else
                                                        {
                                                            dba.Status = (StatusEnum)99999;
                                                            dba.StatusText = "XML response from WorkEngine WebService not recognized";
                                                            sResult = FormatError("PostError8", (int)dba.Status, dba.FormatErrorText());
                                                            bUpdateOK = false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }


                        }
                    }
                    else
                    {
                        bUpdateOK = true; // now w/o Post to WE whether it worked or not at a data level will be contained in the Result
                    }
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.PostCostValues, exception);
            }
        }


        /// <summary>
        /// Updates Holiday Schedules.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateHolidaySchedules(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> dataitems = xDataInputElement.GetList("HolidaySchedule");
                if (dataitems == null || dataitems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");

                foreach (CStruct xSelHS in dataitems)
                {
                    string sresult;
                    try
                    {
                        bool bResult = adminCore.UpdateHolidaySchedule(xSelHS.XML(), out sresult);
                        var xresult = new CStruct();
                        xresult.LoadXML(sresult);
                        xdataElement.AppendSubStruct(xresult);
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("HolidaySchedule");
                        var hsResultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref hsResultElement);
                        dataElement.Add(hsResultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateHolidaySchedules, exception);
            }
        }

        /// <summary>
        /// Updates (Replaces) the Scheduled Work for a PI by Item - Work2 from a SP List(s).
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateListWork(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");

                string sResult = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                try
                {
                    bUpdateOK = adminCore.UpdateListWork(xDataInputElement.XML(), out sResult);
                    bUpdateOK = true; // now whether it worked or not at a data level will be contained in the Result
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateListWork, exception);
            }
        }

        /// <summary>
        /// Updates the Personal Items list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdatePersonalItems(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                string sResult = "";
                string sError = "";
                bool bUpdateOK = false;

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                try
                {
                    bUpdateOK = adminCore.UpdatePersonalItems(xDataInputElement.XML(), out sResult, out sError);
                }
                catch (Exception exception)
                {
                    var deptResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref deptResultElement);
                    sError = deptResultElement.Value;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sError);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdatePersonalItems, exception);
            }
        }

        /// <summary>
        /// Updates Timeoff entries for multiple specified resources
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateResourceTimeoff(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> listItems = xDataInputElement.GetList("Resource");
                if (listItems == null || listItems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xSelItem in listItems)
                {
                    string sresult;
                    try
                    {
                        bool bResult = adminCore.UpdateResourceTimeoff(xSelItem.XML(), out sresult);
                        var xresult = new CStruct();
                        xresult.LoadXML(sresult);
                        xdataElement.AppendSubStruct(xresult);
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("Resource");
                        var resultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref resultElement);
                        dataElement.Add(resultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateResourceTimeOff, exception);
            }
        }

        /// <summary>
        /// Updates the role lookup.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateRoles(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                CStruct xSelRole = xDataInputElement.GetSubStruct("Role");
                if (xSelRole == null) throw new Exception("Cannot find the role element.");

                string sResult = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                bUpdateOK = adminCore.UpdateRoles(xSelRole.XML(), out sResult);

                //if (bUpdateOK) bUpdateOK = adminCore.UpdateCategoriesFromRoles(); -- Update by Munjal. I don't know why you are updating the value of bUpdateOk here.
                //                                                                     I have to comment this out since this results into a Failure response in SP
                //                                                                     even if the Role was added.
                //                                                                     For example, if the Role was added but in "not an autogenerate situation", false is returned.
                //                                                                     That makes bUpdateOk false and outputs a Failure response with an empty error message.


                if (bUpdateOK) adminCore.UpdateCategoriesFromRoles();
 
                if (bUpdateOK == false)
                {
                    return "<UpdateRoles> " + Response.Failure(1, sResult) + " </UpdateRoles>";
                }
                else
                {
                    // Get Cost Category Roles
                    string sCCRs = adminCore.GetCCRs();
                    return Response.Success("", sCCRs);
                }


            }
            catch (PFEException pfeException)
            {
                return "<UpdateRoles> " + Response.PfEFailure(pfeException) + " </UpdateRoles>";
            }
            catch (Exception exception)
            {
                return "<UpdateRoles> " + Response.Failure((int)APIError.UpdateRoles, exception) + " </UpdateRoles>";
            }
        }

        /// <summary>
        /// Updates the role lookup.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateRoles_OLD(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                string sResult = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);
                try
                {
                    bUpdateOK = adminCore.UpdateRoles_OLD(xDataInputElement.XML(), out sResult);
                    // this call moved into UpdateRoles as we have to create CCRs BEFORE we can generate reply
                    //   if (bUpdateOK) bUpdateOK = adminCore.UpdateCategoriesFromRoles();
                }
                catch (PFEException pfeException)
                {
                    return Response.PfEFailure(pfeException);
                }
                catch (Exception exception)
                {
                    return Response.Failure((int)APIError.UpdateRoles, exception);
                }


                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.UpdateRoles, exception);
            }
        }

        /// <summary>
        /// Updates (Replaces) the Scheduled Work for a PI - Work1.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateScheduledWork(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xParmInputElement = xInputData.GetSubStruct("Params");
                if (xParmInputElement == null) throw new Exception("Cannot find the Param element.");
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the Data element.");

                string sResult = "";
                bool bUpdateOK = true;

                Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                try
                {
                    int nWorktype = xParmInputElement.GetIntAttr("Worktype");
                    bUpdateOK = adminCore.UpdateScheduledWork(nWorktype, xDataInputElement.XML(), out sResult);
                    bUpdateOK = true; // now whether it worked or not at a data level will be contained in the Result
                }
                catch (Exception exception)
                {
                    var SWResultElement = new XElement("Result");
                    Utils.SetResultError(exception, ref SWResultElement);
                    sResult = SWResultElement.Value;
                    bUpdateOK = false;
                }

                if (bUpdateOK == false)
                {
                    return Response.Failure(1, sResult);
                }
                else
                {
                    return Response.Success(sResult);
                }
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateScheduledWork, exception);
            }
        }

        /// <summary>
        /// Updates a Work Schedule.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateWorkSchedule(string data)
        {
            try
            {
                var xInputData = new CStruct();
                xInputData.LoadXML(data);
                CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                List<CStruct> dataitems = xDataInputElement.GetList("WorkSchedule");
                if (dataitems == null || dataitems.Count == 0)
                    throw new Exception("No valid data within the data element.");

                Admininfos adminCore = GetAdminCore(SecurityLevels.BaseAdmin);

                var xdataElement = new CStruct();
                xdataElement.Initialize("Data");
                foreach (CStruct xselitem in dataitems)
                {
                    string sresult;
                    try
                    {
                        bool bResult = adminCore.UpdateWorkSchedule(xselitem.XML(), out sresult);
                        var xresult = new CStruct();
                        xresult.LoadXML(sresult);
                        xdataElement.AppendSubStruct(xresult);
                    }
                    catch (Exception exception)
                    {
                        var dataElement = new XElement("WorkSchedule");
                        var wsResultElement = new XElement("Result");
                        Utils.SetResultError(exception, ref wsResultElement);
                        dataElement.Add(wsResultElement);
                        var xresult = new CStruct();
                        xresult.LoadXML(dataElement.ToString());
                        xdataElement.AppendSubStruct(xresult);
                    }
                }
                return Response.Success(xdataElement.XML());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateWorkSchedule, exception);
            }
        }

        #endregion Methods

        private static StatusEnum SendXMLToWorkEngine(DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            try
            {
                Integration weInt = new Integration();
                dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "RPEditor.SendXMLToWorkEngine", "WE Request", "Context=" + sContext, sXMLRequest);
                xNode = weInt.execute(sContext, sXMLRequest);
                if (xNode != null)
                    dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "RPEditor.SendXMLToWorkEngine", "WE Reply", "Context=" + sContext, xNode.OuterXml);
            }
            catch (Exception ex)
            {
                dba.Status = (StatusEnum)99830;
                dba.StatusText = ex.Message;
                dba.StackTrace = ex.StackTrace;
                dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "RPEditor.SendXMLToWorkEngine", "Exception", ex.Message, ex.StackTrace);
            }
            return dba.Status;
        }
        private static string FormatError(string sErrorPosition, int lError, string sErrorText)
        {
            return sErrorPosition + ": " + lError.ToString() + " - " + sErrorText;
        }

    }
}