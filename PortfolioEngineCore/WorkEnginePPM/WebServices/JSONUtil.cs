using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using EPMLiveCore;

namespace WorkEnginePPM
{
    public class JSONUtil
    {
        public static string ConvertXmlToJson(string xml, string idlist)
        {
            return JsonUtilHelper.ConvertXmlToJSon(xml, idlist, true);
        }

        private static string processNode(XmlNode nd, ArrayList idlist, string nodename)
        {
            return JsonUtilHelper.ProcessNode(nd, idlist, nodename, true);
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
