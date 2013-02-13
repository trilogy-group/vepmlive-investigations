using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;

namespace EPMLiveCore
{
    public class GenericPublishEvent : SPItemEventReceiver
    {
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            bool allHidden = true;

            try
            {
                foreach(System.Collections.DictionaryEntry sField in properties.AfterProperties)
                {
                    if(!properties.List.Fields.GetFieldByInternalName(sField.Key.ToString()).Hidden)
                    {
                        allHidden = false;
                        break;
                    }
                }
            }
            catch { allHidden = false; }

            if(properties.AfterProperties["Publisher_x0020_Approval_x0020_S"] != null)
                return;

            if(!allHidden && properties.AfterProperties["IsPublished"] == null)
            {
                properties.AfterProperties["IsPublished"] = "0";

                try
                {
                    SPFieldLookupValue lv = new SPFieldLookupValue(properties.ListItem["Project"].ToString());

                    SPField f = properties.List.Fields.GetFieldByInternalName("Project");
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(f.SchemaXml);

                    string listid = doc.FirstChild.Attributes["List"].Value;

                    SPList list = properties.Web.Lists[new Guid(listid)];
                    SPListItem li = list.GetItemById(lv.LookupId);

                    if(list.Fields.ContainsFieldWithInternalName("PendingUpdates"))
                    {
                        SPField fPend = list.Fields.GetFieldByInternalName("PendingUpdates");

                        string pending = "";
                        try
                        {
                            pending = fPend.GetFieldValueAsText(li[fPend.Id].ToString());
                        }catch{}

                        if(pending != "Yes")
                        {
                            li[fPend.Id] = 1;
                            li.SystemUpdate();

                            ArrayList arr = new ArrayList();

                            SPFieldUserValue uv = new SPFieldUserValue(properties.Web, li["Author"].ToString());
                            arr.Add(uv.LookupId);

                            try
                            {
                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(properties.Web, li["Planners"].ToString());
                                foreach(SPFieldUserValue u in uvc)
                                {
                                    if(!arr.Contains(u.LookupId))
                                        arr.Add(u.LookupId);
                                }
                            }catch{}

                            Hashtable hshProps = new Hashtable();
                            hshProps.Add("ProjectName", li.Title);
                            hshProps.Add("ListId", list.ID.ToString());
                            hshProps.Add("ItemId", li.ID.ToString());

                            //string body = Properties.Resources.txtPendingUpdateEmail;
                            //body = body.Replace("{ProjectName}", li.Title);
                            //body = body.Replace("{ListId}", list.ID.ToString());
                            //body = body.Replace("{ItemId}", li.ID.ToString());

                            foreach(int i in arr)
                            {
                                try
                                {
                                    //SPSecurity.RunWithElevatedPrivileges(delegate()
                                    //{
                                        SPUser u = properties.Web.SiteUsers.GetByID(1073741823);
                                        API.APIEmail.QueueItemMessage(5, true, hshProps, new string[] { i.ToString() },null, false, true, li, u, false);
                                    //});
                                    //API.APIEmail.sendEmailHideReply(5, properties.SiteId, properties.Web.ID, properties.Web.CurrentUser, properties.Web.SiteUsers.GetByID(i), hshProps);
                                }
                                catch { }
                            }
                            
                        }
                    }
                }
                catch { }
            }
        }
    }
}
