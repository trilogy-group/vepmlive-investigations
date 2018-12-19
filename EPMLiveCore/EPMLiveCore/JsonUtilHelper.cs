using System.Collections;
using System.Text;
using System.Web;
using System.Xml;

namespace EPMLiveCore
{
    public class JsonUtilHelper
    {
        public static string ConvertXmlToJSon(string xml, string idlist, bool appendChildAttributes)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var idList = new ArrayList(idlist.Split(','));

            return string.Format("{{{0}}}", ProcessNode(doc.FirstChild, idList, string.Empty, appendChildAttributes));
        }

        public static string ProcessNode(XmlNode node, ArrayList idList, string nodeName, bool appendChildAttributes)
        {
            var nodeCounter = 1;
            var stringBuilder = new StringBuilder();

            if (nodeName == string.Empty)
            {
                nodeName = GetNodeName(node, idList, new ArrayList(), ref nodeCounter);
            }

            stringBuilder.Append(nodeName)
                .Append(":{");

            var sbAttributes = new StringBuilder();
            var arrAttributes = new ArrayList();

            foreach (XmlAttribute attribute in node.Attributes)
            {
                if (!idList.Contains(attribute.Name))
                {
                    var name = GetAttributeName(attribute.Name, arrAttributes);
                    arrAttributes.Add(name);

                    sbAttributes.Append((string)name)
                        .Append(":\"")
                        .Append(HttpUtility.HtmlEncode(attribute.Value).Replace("\"", "\\\"").Replace("\n", "").Replace("\r", ""))
                        .Append("\",");
                }
            }

            var arrUsedNodes = new ArrayList();

            foreach (XmlNode ndChild in node.ChildNodes)
            {
                if (ndChild.Attributes == null
                    || ndChild.ChildNodes.Count == 0 && ndChild.Attributes.Count == 0
                    || ndChild.ChildNodes.Count == 1 && ndChild.ChildNodes[0].Name == "#cdata-section" && ndChild.Attributes.Count == 0)
                {
                    var name = GetAttributeName(ndChild.Name, arrAttributes);

                    if (ndChild.Name == "#cdata-section")
                    {
                        name = "InnerText";
                    }
                    if (ndChild.Name == "#text")
                    {
                        name = "Text";
                    }

                    arrAttributes.Add(name);

                    sbAttributes.Append(name)
                        .Append(":\"");
                    if (!appendChildAttributes && ndChild.Name == "#cdata-section")
                    {
                        sbAttributes.Append(ndChild.InnerText.Replace("\"", "\\\"").Replace("\n", string.Empty).Replace("\r", string.Empty));
                    }
                    else
                    {
                        sbAttributes.Append(HttpUtility.HtmlEncode(ndChild.InnerText).Replace("\"", "\\\"").Replace("\n", "").Replace("\r", ""));
                    }
                    sbAttributes.Append("\",");
                }
                else
                {
                    var newNodeName = GetNodeName(ndChild, idList, arrUsedNodes, ref nodeCounter);
                    arrUsedNodes.Add(newNodeName);
                    sbAttributes.Append(ProcessNode(ndChild, idList, newNodeName, appendChildAttributes));
                    sbAttributes.Append(",");
                }
            }

            stringBuilder.Append(sbAttributes.ToString().Trim(','))
                .Append("}");
            return stringBuilder.ToString();
        }

        public static string GetAttributeName(string name, ArrayList attributes)
        {
            var tempName = name;
            var nameCounter = 1;
            while (attributes.Contains(tempName))
            {
                tempName = string.Format("{0}{1}", name, nameCounter);
                nameCounter++;
            }

            return tempName;
        }

        public static string GetNodeName(XmlNode node, ArrayList idList, ArrayList useNodes, ref int nodeCounter)
        {
            var tempNodeName = node.Name;
            var stringBuilder = new StringBuilder(tempNodeName);
            foreach (string id in idList)
            {
                if (id != string.Empty && node.Attributes[id] != null)
                {
                    stringBuilder.Append(node.Attributes[id].Value);
                }
            }
            tempNodeName = stringBuilder.ToString();

            var nodeName = tempNodeName;

            while (useNodes.Contains(nodeName))
            {
                nodeName = string.Format("{0}{1}", tempNodeName, nodeCounter);
                nodeCounter++;
            }

            return nodeName;
        }
    }
}