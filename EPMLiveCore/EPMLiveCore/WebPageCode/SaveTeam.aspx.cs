using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class SaveTeam : System.Web.UI.Page
    {
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Request["team"]);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Team HasResAccess=\"" + Request["HasResAccess"] + "\" ListId=\"" + Request["ListId"] + "\" ItemId=\"" + Request["ItemId"] + "\"/>");

            foreach(XmlNode nd in doc.SelectNodes("//I"))
            {
                XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "Member", docOut.NamespaceURI);

                XmlAttribute nattr = docOut.CreateAttribute("ID");
                nattr.Value = nd.Attributes["id"].Value;
                ndNew.Attributes.Append(nattr);

                nattr = docOut.CreateAttribute("Permissions");
                nattr.Value = nd.Attributes["Permissions"].Value;
                ndNew.Attributes.Append(nattr);

                docOut.FirstChild.AppendChild(ndNew);
            }

            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(WorkEngineAPI.SaveTeam(docOut.OuterXml, SPContext.Current.Web));

            if(doc1.FirstChild.Attributes["Status"].Value == "0")
            {
                data = "Success";
            }
            else
            {
                data = doc1.FirstChild.SelectSingleNode("//Error").InnerText;
            }

        }
            
    }
}