using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using System.Data.SqlClient;

namespace EPMLiveReportsAdmin
{
    public class ParentItemUpdate
    {

        public static void UpdateParent(SPItemEventProperties properties)
        {
            ArrayList arrProcessItems = new ArrayList();

            ArrayList lstFixers = new ArrayList();
            string sFixLists = EPMLiveCore.CoreFunctions.getConfigSetting(properties.Site.RootWeb, "EPMLiveFixLists");

            if (sFixLists.Trim().Length > 0)
            {
                lstFixers.AddRange(sFixLists.ToLower().Replace("\r\n", "\n").Split('\n'));
            }

            SPWeb web = properties.Web;

            foreach (SPField field in properties.List.Fields)
            {
                if (field.Type == SPFieldType.Lookup)
                {
                    try
                    {
                        SPFieldLookup lField = (SPFieldLookup)field;
                        Guid gList = new Guid(lField.LookupList);
                        SPList oList = web.Lists[gList];
                        if (lstFixers.Contains(oList.Title.ToLower()))
                        {
                            SPFieldLookupValue lv = new SPFieldLookupValue(properties.ListItem[field.Id].ToString());

                            string parentinfo = lv.LookupId + "." + oList.ID;
                            if(!arrProcessItems.Contains(parentinfo))
                                arrProcessItems.Add(parentinfo);
                        }

                    }
                    catch { }
                }
            }

            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                foreach (string sItem in arrProcessItems)
                {
                    cn.Open();

                    string []sItemInfo = sItem.Split('.');

                    bool found = false;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM ROLLUPQUEUE WHERE listid=@listid and itemid = @itemid and status = 0", cn);
                    cmd.Parameters.AddWithValue("@listid", sItemInfo[1]);
                    cmd.Parameters.AddWithValue("@itemid", sItemInfo[0]);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        found = true;
                    }
                    dr.Close();

                    if (found)
                    {
                        cmd = new SqlCommand("UPDATE ROLLUPQUEUE SET EVENTTIME=GETDATE() WHERE listid=@listid and itemid=@itemid and status = 0", cn);
                        cmd.Parameters.AddWithValue("@listid", sItemInfo[1]);
                        cmd.Parameters.AddWithValue("@itemid", sItemInfo[0]);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO ROLLUPQUEUE (SiteId, WebId, ListId, ItemId, EventTime, Status) VALUES (@SiteId, @WebId, @ListId, @ItemId, GETDATE(), 0)", cn);
                        cmd.Parameters.AddWithValue("@SiteId", properties.SiteId);
                        cmd.Parameters.AddWithValue("@WebId", web.ID);
                        cmd.Parameters.AddWithValue("@ListId", sItemInfo[1]);
                        cmd.Parameters.AddWithValue("@ItemId", sItemInfo[0]);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            });
        }
    }
}
