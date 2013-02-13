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

namespace EPMLiveWebParts
{
    public partial class getresourcepool : getgriditems
    {

        protected override void outputXml()
        {

            XmlNode ndCol = docXml.SelectSingleNode("//head/column");
            XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newCol.InnerText = "#master_checkbox";
            XmlAttribute attrType = docXml.CreateAttribute("type");
            attrType.Value = "ch";
            XmlAttribute attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "25";
            XmlAttribute attrId = docXml.CreateAttribute("id");
            attrId.Value = "check";
            XmlAttribute attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";
            newCol.Attributes.Append(attrType);
            newCol.Attributes.Append(attrWidth);
            newCol.Attributes.Append(attrId);
            newCol.Attributes.Append(attrAlign);

            docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCol);

            XmlNodeList ndl = docXml.SelectNodes("//row");
            foreach (XmlNode nd in ndl)
            {
                XmlNode newnd = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                nd.InsertBefore(newnd,nd.FirstChild);
                nd.Attributes.Remove(nd.Attributes["locked"]);
            }

            XmlNode ndHeader = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
            ndHeader.InnerXml = ndHeader.InnerXml.Replace("<![CDATA[","<![CDATA[,");

            try
            {
                XmlNode ndTitle = docXml.SelectSingleNode("//column[@id='Title']");
                string strWidth = ndTitle.Attributes["width"].Value;
                double width = double.Parse(strWidth) - 5;
                if (width > 5)
                {
                    ndTitle.Attributes["width"].Value = width.ToString();
                }
            }
            catch { }
            data = docXml.OuterXml;
        }

        public override void getParams(SPWeb curWeb)
        {
            try
            {

                base.strlist = "Lists/Resources/DispForm.aspx";
                strview = Request["view"];
                usewbs = "";
                executive = "";
                linktype = "";

                filterfield = "";
                filtervalue = "";
                gridname = Request["gridname"];
                additionalgroups = "";
                expandlevel = 0;

                isResPlan = true;

                list = curWeb.GetListFromUrl(strlist);
                view = list.Views[strview];
            }
            catch { }
        }
    }

}
