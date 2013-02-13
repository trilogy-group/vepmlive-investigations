using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text;
using System.Xml;
using System.Data.SqlClient;

namespace EPMLiveWebParts
{
    public partial class getedititem : EPMLiveWebParts.getgriditems
    {
        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            inEditMode = true;
            usePerformance = false;
        }

        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {
            string siteid = Request["siteid"];
            string webid = Request["webid"];
            string listid = Request["listid"];
            string itemid = Request["itemid"];

            using (SPSite site = new SPSite(new Guid(siteid)))
            {
                using (SPWeb web = site.OpenWeb(new Guid(webid)))
                {
                    SPList list = web.Lists[new Guid(listid)];
                    SPListItem li = list.GetItemById(int.Parse(itemid));
                    arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID, new string[1] { null });
                    queueAllItems.Enqueue(li);
                }
            }
            
        }
        protected override void outputXml()
        {
            XmlNode nd = docXml.SelectSingleNode("/rows/row");
            nd.Attributes["id"].Value = Request["rowid"];
            nd.RemoveChild(nd.SelectSingleNode("cell"));

            XmlNode ndRows = docXml.SelectSingleNode("/rows");
            XmlNode ndHead = ndRows.SelectSingleNode("head");
            ndRows.RemoveChild(ndHead);

            base.outputXml();
        }
    }

}
