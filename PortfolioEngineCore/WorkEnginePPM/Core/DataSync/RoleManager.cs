using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using WorkEnginePPM.Core.Entities;
using WorkEnginePPM.WebServices.Core;

namespace WorkEnginePPM.Core.DataSync
{
    public class RoleManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public RoleManager(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (4) 

        /// <summary>
        /// Adds or updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public List<Role> AddOrUpdate(Role role)
        {
            var requestXml = new XElement("UpdateRoles", new XElement("Params"),
                                          new XElement("Data",
                                                       new XElement("Role",
                                                                    new XAttribute("Id", role.RoleId ?? string.Empty),
                                                                    new XAttribute("Title", role.Title),
                                                                    new XAttribute("ExtId",
                                                                                   (object) role.Id ?? string.Empty))));

            XDocument responseXml;

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                responseXml = XDocument.Parse(portfolioEngineAPI.Execute("UpdateRoles", requestXml.ToString()));
            }

            XElement rootElement = responseXml.Root;

            ValidateResponse(rootElement);

            var roles = new List<Role>();

            foreach (XElement roleElement in rootElement.Element("Data").Elements("Role"))
            {
                string ccrId = null;
                string ccrName = null;
                string roleId = null;
                int? id = null;
                string title = null;

                XAttribute ccrIdAttr = roleElement.Attribute("CCRId");
                if (ccrIdAttr != null) ccrId = ccrIdAttr.Value;

                XAttribute ccrNameAttr = roleElement.Attribute("CCRName");
                if (ccrNameAttr != null) ccrName = ccrNameAttr.Value;

                XAttribute extIdAttr = roleElement.Attribute("ExtId");
                if (extIdAttr != null && !string.IsNullOrEmpty(extIdAttr.Value))
                {
                    int tempId;
                    int.TryParse(extIdAttr.Value, out tempId);
                    if (tempId != 0) id = tempId;
                }

                XAttribute idAttr = roleElement.Attribute("Id");
                if (idAttr != null) roleId = idAttr.Value;

                XAttribute titleAttr = roleElement.Attribute("Title");
                if (titleAttr != null) title = titleAttr.Value;

                roles.Add(new Role {CCRId = ccrId, CCRName = ccrName, RoleId = roleId, Id = id, Title = title});
            }

            return roles;
        }

        /// <summary>
        /// Deletes the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public bool Delete(Role role)
        {
            var request = new XElement("DeleteRoles", new XElement("Params"),
                                       new XElement("Data",
                                                    new XElement("Role",
                                                                 new XAttribute("Id", role.RoleId ?? string.Empty),
                                                                 new XAttribute("CCRId", role.CCRId ?? string.Empty),
                                                                 new XAttribute("ExtId",
                                                                                (object) role.Id ?? string.Empty))));

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("DeleteRoles", request.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);
            }

            return true;
        }

        /// <summary>
        /// Runs the refresh.
        /// </summary>
        /// <returns></returns>
        public string RunRefresh()
        {
            try
            {
                IEnumerable<SPList> spLists = Web.GetListByTemplateId((int) EPMLiveLists.Roles);
                if (spLists == null) throw new Exception("Cannot find the Roles list.");

                SPListItemCollection spListItemCollection = spLists.First().Items;

                if (spListItemCollection.Count > 0)
                {
                    spListItemCollection.List.ParentWeb.AllowUnsafeUpdates = true;
                    spListItemCollection[0].SystemUpdate();
                    spListItemCollection.List.ParentWeb.AllowUnsafeUpdates = false;
                }

                return Response.Success(string.Empty);
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.RefreshRoles, exception);
            }
        }

        /// <summary>
        /// Deletes role from role list when performed delete operation from Cost Categories page
        /// </summary>
        /// <param name="extIds">Role ids to be deleted</param>
        /// <returns>Result</returns>
        public string DeleteRolesByCostCategories(string extIds)
        {
            try
            {
                IEnumerable<SPList> spLists = Web.GetListByTemplateId((int)EPMLiveLists.Roles);
                if (spLists == null) throw new Exception("Cannot find the Roles list.");

                string[] ids = extIds.Split(',');
                Web.AllowUnsafeUpdates = true;
                SPListItemCollection items = spLists.First().GetItems();
                if (items != null && items.Count > 0)
                {
                    IEnumerable<SPListItem> itemsToDelete = from itm in items.OfType<SPListItem>()
                                                            where ids.Contains(itm["EXTID"])
                                                            select itm;

                    List<SPListItem> tempCollection = itemsToDelete.ToList();
                    int count = itemsToDelete.Count();
                    for (int i = count - 1; i >= 0; i--)
                    {
                        tempCollection[i].Delete();
                    }
                }
                Web.AllowUnsafeUpdates = false;

                return Response.Success(string.Empty);
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int)APIError.DeleteRolesByCostCategories, exception);
            }
        }   

        #endregion Methods 
    }
}