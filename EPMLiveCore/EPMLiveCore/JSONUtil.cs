using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace EPMLiveCore
{
    public class JSONUtil
    {
        public static string ConvertXmlToJson(string xml, string idlist)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ArrayList arr = new ArrayList(idlist.Split(','));

            return "{" + processNode(doc.FirstChild, arr, "") + "}";
        }

        private static string processNode(XmlNode nd, ArrayList idlist, string nodename)
        {

            int nodeCounter = 1;

            StringBuilder sb = new StringBuilder();

            if(nodename == "")
                nodename = getNodeName(nd, idlist, new ArrayList(), ref nodeCounter);

            sb.Append(nodename);
            
            sb.Append(":{");

            StringBuilder sbAttributes = new StringBuilder();

            ArrayList arrAttributes = new ArrayList();

            foreach(XmlAttribute attr in nd.Attributes)
            {
                if(!idlist.Contains(attr.Name))
                {
                    string name = getAttributeName(attr.Name, arrAttributes);
                    arrAttributes.Add(name);

                    sbAttributes.Append(name);
                    sbAttributes.Append(":\"");
                    sbAttributes.Append(System.Web.HttpUtility.HtmlEncode(attr.Value).Replace("\"", "\\\"").Replace("\n", "").Replace("\r", ""));
                    sbAttributes.Append("\",");
                }
            }

            
            ArrayList arrUsedNodes = new ArrayList();

            foreach(XmlNode ndChild in nd.ChildNodes)
            {
                if(ndChild.Attributes == null || (ndChild.ChildNodes.Count == 0 && ndChild.Attributes.Count == 0) || (ndChild.ChildNodes.Count == 1 && ndChild.ChildNodes[0].Name == "#cdata-section" && ndChild.Attributes.Count == 0))
                {
                    string name = getAttributeName(ndChild.Name, arrAttributes);

                    if(ndChild.Name == "#cdata-section")
                        name = "InnerText";
                    
                    if(ndChild.Name == "#text")
                        name = "Text";

                    arrAttributes.Add(name);

                    sbAttributes.Append(name);
                    sbAttributes.Append(":\"");
                    sbAttributes.Append(System.Web.HttpUtility.HtmlEncode(ndChild.InnerText).Replace("\"", "\\\"").Replace("\n", "").Replace("\r", ""));
                    sbAttributes.Append("\",");
                }
                else
                {
                    string newnodename = getNodeName(ndChild, idlist, arrUsedNodes, ref nodeCounter);
                    arrUsedNodes.Add(newnodename);
                    sbAttributes.Append(processNode(ndChild, idlist, newnodename));
                    sbAttributes.Append(",");
                }
            }

            sb.Append(sbAttributes.ToString().Trim(','));

            sb.Append("}");

            return sb.ToString();
        }

        private static string getAttributeName(string name, ArrayList arrAttributes)
        {
            string tempname = name;
            int namecounter = 1;
            while(arrAttributes.Contains(tempname))
            {
                tempname = name + namecounter;
                namecounter++;
            }

            return tempname;
        }

        private static string getNodeName(XmlNode nd, ArrayList idlist, ArrayList arrUsedNodes, ref int nodeCounter)
        {
            string sTempNodeName = nd.Name;

            foreach(string id in idlist)
            {
                if(id != "")
                {
                    if(nd.Attributes[id] != null)
                        sTempNodeName += nd.Attributes[id].Value;
                }
            }

            string nodeName = sTempNodeName;

            while(arrUsedNodes.Contains(nodeName))
            {
                nodeName = sTempNodeName + nodeCounter;
                nodeCounter++;
            }

            return nodeName;
        }
    }
}
