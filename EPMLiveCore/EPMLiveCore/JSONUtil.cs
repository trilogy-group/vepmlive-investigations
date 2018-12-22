using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Collections;

namespace EPMLiveCore
{
    public class JSONUtil
    {
        public static string ConvertXmlToJson(string xml, string idlist)
        {
            return JsonUtilHelper.ConvertXmlToJSon(xml, idlist, false);
        }

        private static string processNode(XmlNode nd, ArrayList idlist, string nodename)
        {
            return JsonUtilHelper.ProcessNode(nd, idlist, nodename, false);
        }

        private static string getAttributeName(string name, ArrayList arrAttributes)
        {
            return JsonUtilHelper.GetAttributeName(name, arrAttributes);
        }

        private static string getNodeName(XmlNode nd, ArrayList idlist, ArrayList arrUsedNodes, ref int nodeCounter)
        {
            return JsonUtilHelper.GetNodeName(nd, idlist, arrUsedNodes, ref nodeCounter);
        }
    }
}
