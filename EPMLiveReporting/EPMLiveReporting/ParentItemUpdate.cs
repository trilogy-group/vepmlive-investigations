using System;
using System.Collections;
using System.Data.SqlClient;
using EPMLiveCore;
using Microsoft.SharePoint;

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

            using (var connection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    foreach (string sItem in arrProcessItems)
                    {
                        connection.Open();

                        string[] sItemInfo = sItem.Split('.');

                        var found = false;

                        using (var cmd = new SqlCommand("SELECT * FROM ROLLUPQUEUE WHERE listid=@listid and itemid = @itemid and status = 0", connection))
                        {
                            cmd.Parameters.AddWithValue("@listid", sItemInfo[1]);
                            cmd.Parameters.AddWithValue("@itemid", sItemInfo[0]);

                            using (var dataReader = cmd.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    found = true;
                                }
                            }
                        }

                        if (found)
                        {
                            using (var cmd = new SqlCommand(
                                "UPDATE ROLLUPQUEUE SET EVENTTIME=GETDATE() WHERE listid=@listid and itemid=@itemid and status = 0",
                                connection))
                            {
                                cmd.Parameters.AddWithValue("@listid", sItemInfo[1]);
                                cmd.Parameters.AddWithValue("@itemid", sItemInfo[0]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (var cmd = new SqlCommand(
                                "INSERT INTO ROLLUPQUEUE (SiteId, WebId, ListId, ItemId, EventTime, Status) VALUES (@SiteId, @WebId, @ListId, @ItemId, GETDATE(), 0)",
                                connection))
                            {
                                cmd.Parameters.AddWithValue("@SiteId", properties.SiteId);
                                cmd.Parameters.AddWithValue("@WebId", web.ID);
                                cmd.Parameters.AddWithValue("@ListId", sItemInfo[1]);
                                cmd.Parameters.AddWithValue("@ItemId", sItemInfo[0]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                });
            }
        }
    }
}
