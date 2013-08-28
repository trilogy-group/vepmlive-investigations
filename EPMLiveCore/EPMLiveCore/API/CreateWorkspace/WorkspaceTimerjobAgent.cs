using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.API
{
    /// <summary>
    /// static class that triages the 
    /// workspace creation logic
    /// </summary>
    public static class WorkspaceTimerjobAgent
    {
        public static string QueueCreateWorkspace(string xmlData)
        {
            string result = string.Empty;
            XMLDataManager mgr = new XMLDataManager(xmlData);
            Guid sid = new Guid(mgr.GetPropVal("SiteId"));
            Guid wid = new Guid(mgr.GetPropVal("WebId"));
            Guid listguid = Guid.Empty;
            if (!string.IsNullOrEmpty(mgr.GetPropVal("AttachedItemListGuid")))
            {
                listguid = new Guid(mgr.GetPropVal("AttachedItemListGuid"));
            }
            int itemid = -1;
            if (!string.IsNullOrEmpty(mgr.GetPropVal("AttachedItemId")))
            {
                itemid = int.Parse(mgr.GetPropVal("AttachedItemId"));
            }
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite site = new SPSite(sid))
                {
                    using (SPWeb web = site.OpenWeb(wid))
                    {
                        using (SqlConnection con = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                        {
                            con.Open();
                            Guid timerjobguid = Guid.NewGuid();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, listguid, itemid, jobdata) VALUES (@timerjobuid,@siteguid, 100, 'Create Workspace', 0, @webguid, @listguid, @itemid, @jobdata)";
                            cmd.Parameters.Add(new SqlParameter("@timerjobuid", timerjobguid));
                            cmd.Parameters.Add(new SqlParameter("@siteguid", site.ID.ToString()));
                            cmd.Parameters.Add(new SqlParameter("@webguid", web.ID.ToString()));
                            cmd.Parameters.Add(new SqlParameter("@listguid", listguid.ToString()));
                            cmd.Parameters.Add(new SqlParameter("@itemid", itemid.ToString()));
                            cmd.Parameters.Add(new SqlParameter("@jobdata", xmlData));
                            cmd.ExecuteNonQuery();
                           
                            EPMLiveCore.CoreFunctions.enqueue(timerjobguid, 0, site);
                            result = "Successfully queued create workspace job.";
                        }
                    }
                }
            });
            
            return result;
        }
    }
}
