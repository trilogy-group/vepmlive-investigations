using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PortfolioEngineCore.Infrastructure.Entities;

namespace PortfolioEngineCore
{
    public class Resources : PFEBase
    {
        #region Fields (1) 

        private readonly ResourceRepository _resourceRepository;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        /// <param name="basepath">The basepath.</param>
        /// <param name="username">The username.</param>
        /// <param name="pid">The pid.</param>
        /// <param name="company">The company.</param>
        /// <param name="dbcnstring">The dbcnstring.</param>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="bDebug">if set to <c>true</c> [b debug].</param>
        public Resources(string basepath, string username, string pid, string company, string dbcnstring,
                         SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading Resources Class");

            _resourceRepository = new ResourceRepository(_PFECN);
        }

        #endregion Constructors 

        #region Methods (8) 

        // Public Methods (8) 

        /// <summary>
        /// Builds the resource.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        public Resource BuildResource(DataRow dataRow)
        {
            var id = dataRow["Id"] as int?;
            var extId = dataRow["ExtId"] as string;
            var username = dataRow["Username"] as string;

            return _resourceRepository.BuildResource(dataRow, GetPermissionGroups(), username, extId, id);
        }

        /// <summary>
        /// Determines whether this instance can delete the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string CanDelete(Resource resource, out string message)
        {
            return _resourceRepository.CanDelete(resource, out message);
        }

        /// <summary>
        /// Deletes the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="currentUserId">The current user id.</param>
        public void Delete(Resource resource, int currentUserId)
        {
            _resourceRepository.Delete(resource, currentUserId);
        }

        /// <summary>
        /// Finds the resource.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="externalId">The external id.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public Resource FindResource(int? id, string externalId = null, string username = null)
        {
            return _resourceRepository.FindById(_resourceRepository.GetResourceId(id, externalId, username));
        }

        /// <summary>
        /// Gets the permission groups.
        /// </summary>
        /// <returns></returns>
        public IList<Group> GetPermissionGroups()
        {
            var groups = new List<Group>();

            if (_PFECN.State == ConnectionState.Closed)
            {
                _PFECN.Open();
            }

            using (var sqlCommand = new SqlCommand("EPG_SP_ReadGroupType", _PFECN))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@GroupType", SqlDbType.VarChar) {Value = 1});

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var group = new Group();

                    group.Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("GROUP_ID"));
                    group.Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("GROUP_NAME"));
                    group.Description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("GROUP_NOTES"));

                    groups.Add(group);
                }
            }

            _PFECN.Close();

            return groups;
        }

        /// <summary>
        /// Gets the resource cost category role.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="externalId">The external id.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public Role GetResourceCostCategoryRole(int? id, string externalId = null, string username = null)
        {
            try
            {
                var role = new Role();

                int resourceId = _resourceRepository.GetResourceId(id, externalId, username);

                if (_PFECN.State == ConnectionState.Closed)
                {
                    _PFECN.Open();
                }

                const string query =
                    @"SELECT     dbo.EPGP_COST_XREF.BC_UID AS CostCategoryRoleId, dbo.EPGP_CATEGORIES.CA_ROLE AS RoleId, dbo.EPGP_CATEGORIES.CA_NAME AS Name
                      FROM       dbo.EPGP_CATEGORIES 
                      INNER JOIN dbo.EPGP_COST_XREF ON dbo.EPGP_CATEGORIES.CA_UID = dbo.EPGP_COST_XREF.BC_UID
                      WHERE      (dbo.EPGP_COST_XREF.WRES_ID = @ResourceId)";

                using (var sqlCommand = new SqlCommand(query, _PFECN))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResourceId", SqlDbType.VarChar) {Value = resourceId});

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        role.CostCategoryRoleId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("CostCategoryRoleId"));
                        role.Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("RoleId"));
                        role.Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
                    }
                }

                _PFECN.Close();

                return role;
            }
            catch (Exception exception)
            {
                throw new PFEException((int) PFEError.GetResourcePermissions, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Gets the resource permissions.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="externalId">The external id.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public IList<Group> GetResourcePermissionGroups(int? id, string externalId = null, string username = null)
        {
            try
            {
                var groups = new List<Group>();

                int resourceId = _resourceRepository.GetResourceId(id, externalId, username);

                if (_PFECN.State == ConnectionState.Closed)
                {
                    _PFECN.Open();
                }

                using (var sqlCommand = new SqlCommand("EPG_SP_ReadGroupsForMember", _PFECN))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WresID", SqlDbType.VarChar) {Value = resourceId});

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("GROUP_ENTITY")) != 1) continue;

                        var group = new Group
                                        {
                                            Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("GROUP_ID")),
                                            Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("GROUP_NAME"))
                                        };


                        groups.Add(group);
                    }
                }

                _PFECN.Close();

                return groups;
            }
            catch (Exception exception)
            {
                throw new PFEException((int) PFEError.GetResourcePermissions, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Updates the resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public int UpdateResource(Resource resource)
        {
            try
            {
                int resourceId = resource.Id;

                if (resourceId == 0)
                {
                    resourceId = _resourceRepository.Add(resource);
                }
                else
                {
                    _resourceRepository.Update(resource);
                }

                return resourceId;
            }
            catch (Exception exception)
            {
                throw new PFEException((int) PFEError.UpdateResource, exception.GetBaseMessage());
            }
        }

        #endregion Methods 
    }
}