///////////////////////////////////////////////////////////////////////////////
//  Copyright EPK Group 2002 - 2006
//
//  Module  : CStruct.cs
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace PortfolioEngineCore
{
    public class CStruct
    {
        public static string ConvertXMLToJSON(string sXML)
        {
            CStruct x = new CStruct();
            x.LoadXML(sXML);
            return x.ToJSONString();
        }
        
        private XmlDocument m_oXMLDocument = null;
        private XmlNode m_oNode = null;

        public XmlDocument XMLDocument
        {
            get
            {
                return m_oXMLDocument;
            }
        }

        public void Initialize(string sStructName, CStruct xCompatibleStruct)
        {
            if (xCompatibleStruct != null) m_oXMLDocument = xCompatibleStruct.XMLDocument;
            if (m_oXMLDocument == null) m_oXMLDocument = new XmlDocument();

            m_oNode = m_oXMLDocument.CreateElement(sStructName);
        }

        public void Initialize(string sStructName, XmlDocument oXMLDocument)
        {
            if (oXMLDocument != null) m_oXMLDocument = oXMLDocument;
            if (m_oXMLDocument == null) m_oXMLDocument = new XmlDocument();

            m_oNode = m_oXMLDocument.CreateElement(sStructName);
        }

        public void Initialize(string sStructName)
        {
            m_oXMLDocument = new XmlDocument();
            m_oNode = m_oXMLDocument.CreateElement(sStructName);
        }

        public bool LoadXML(string sXML)
        {
            if (m_oXMLDocument == null) m_oXMLDocument = new XmlDocument();
            m_oXMLDocument.PreserveWhitespace = true;
            if (sXML != string.Empty)
            {
                m_oXMLDocument.LoadXml(sXML);

                foreach (XmlNode oNode in m_oXMLDocument.ChildNodes)
                {
                    if (oNode.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        m_oNode = oNode;
                        return true;
                    }
                }
            }
            return false;
        }


        //public string Name()
        //{
        //    if (m_oNode != null)
        //        return m_oNode.Name.ToString();
        //    else
        //        return "";
        //}

        public string Name
        {
            get
            {
                if (m_oNode != null)
                    return m_oNode.Name.ToString();
                else
                    return "";
            }
        }

        //public string Value()
        //{
        //    if (m_oNode != null)
        //        return m_oNode.Value.ToString();
        //    else
        //        return "";
        //}

        public string Value
        {
            get
            {
                if (m_oNode != null)
                    return m_oNode.Value.ToString();
                else
                    return "";
            }
            set
            {
                if (m_oNode != null)
                    m_oNode.Value = value;
            }
        }

        public string InnerText
        {
            get
            {
                if(m_oNode != null)
                    return m_oNode.InnerText;
                else
                    return "";
            }
            set
            {
                if (m_oNode != null)
                    m_oNode.InnerText = value;
            }
        }

        public XmlNode GetXMLNode()
        {
            return m_oNode;
        }

        public CStruct AppendSubStruct(CStruct xStruct)
        {
            XmlNode oNode = xStruct.GetXMLNode();

            if (oNode == null)
            {
                return null;
            }
            else
            {
                if (oNode.OwnerDocument == m_oXMLDocument)
                    m_oNode.AppendChild(oNode);
                else
                    m_oNode.AppendChild(m_oXMLDocument.ImportNode(oNode, true));

                return xStruct;
            }
        }

        public CStruct CreateSubStruct(string sItemName)
        {
            if (m_oXMLDocument == null) return null;
            XmlNode oNode = m_oXMLDocument.CreateElement(sItemName);
            if (oNode == null)
            {
                return null;
            }
            else
            {
                m_oNode.AppendChild(oNode);
                CStruct oStruct = new CStruct();
                oStruct.Initialize(sItemName, m_oXMLDocument);
                oStruct.SetXMLNode(oNode);
                return oStruct;
            }
        }

        public bool CreateCDataSection(string sData)
        {
            if (m_oXMLDocument == null) return false;
            XmlCDataSection cds = m_oXMLDocument.CreateCDataSection(sData);
            if (cds != null)
            {
                m_oNode.AppendChild(cds);
                return true;
            }
            return false;
        }

        public CStruct GetSubStruct()
        {
            foreach (XmlNode oNode in m_oNode.ChildNodes)
            {
                if (oNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    CStruct oStruct = new CStruct();
                    oStruct.Initialize(oNode.Name, m_oXMLDocument);
                    oStruct.SetXMLNode(oNode);
                    return oStruct;
                }
            }
            return null;
        }

        public CStruct GetSubStruct(string sItemName)
        {
            XmlNode oNode = m_oNode.SelectSingleNode(sItemName);
            if (oNode == null)
            {
                return null;
            }
            else
            {
                CStruct oStruct = new CStruct();
                oStruct.Initialize(sItemName, m_oXMLDocument);
                oStruct.SetXMLNode(oNode);
                return oStruct;
            }
        }

        public bool AppendXML(string sXML)
        {
            CStruct xXML = new CStruct();
            
            if (xXML.LoadXML(sXML))
            {
                this.AppendSubStruct(xXML);
                return true;
            }
            return false;
        }

        public void SetXMLNode(XmlNode oNode)
        {
            if (m_oXMLDocument == null) m_oXMLDocument = new XmlDocument();
            m_oNode = oNode;
        }

        public void SetXMLNode(XmlNode oNode, XmlDocument oXMLDocument)
        {
            m_oXMLDocument = oXMLDocument;
            m_oNode = oNode;
        }

        public string XML()
        {
            return m_oNode.OuterXml;
        }

        public string ToString(bool bEncode)
        {
            // Convert & to &amp;  and < to &lt; and  > to &gt;
            string s = m_oNode.OuterXml;
            if (bEncode)
            {
                s = s.Replace("&", "&amp;");
                s = s.Replace("<", "&lt;");
                s = s.Replace(">", "&gt;");
            }
            return s;
        }

        public string ToJSONString()
        {
            StringBuilder sbJSON = new StringBuilder();
            sbJSON.Append("{ ");
            XmlToJSONnode(sbJSON, (XmlElement)m_oNode, true);
            sbJSON.Append("}");
            return sbJSON.ToString();
        }

        public bool FromString(string s, bool bDecode)
        {
            if (bDecode)
            {
                s = s.Replace("&gt;", ">");
                s = s.Replace("&lt;", "<");
                s = s.Replace("&amp;", "&");
            }
            return LoadXML(s);
        }

        private void AddElement(string sItemName, string sValue)
        {
            if (m_oXMLDocument == null) m_oXMLDocument = new XmlDocument();
            XmlElement oElement = m_oXMLDocument.CreateElement(sItemName);
            oElement.InnerText = sValue;
            m_oNode.AppendChild(oElement);
        }

        private void AddAttribute(string sItemName, string sValue)
        {
            if (m_oXMLDocument == null) m_oXMLDocument = new XmlDocument();
            XmlAttribute oAttrib = m_oXMLDocument.CreateAttribute(sItemName);
            oAttrib.Value = sValue;
            m_oNode.Attributes.SetNamedItem(oAttrib);
        }

        private XmlNode GetNodeInternal(string sItemName)
        {
            // If no name specified then return this node
            if (sItemName == string.Empty)
                return m_oNode;
            else
            {
                XmlNode oNode = m_oNode.SelectSingleNode(sItemName);
                if (oNode == null)
                {
                    if (m_oNode.Name == sItemName)
                        return m_oNode;
                    else
                        return null;
                }
                else
                    return oNode;
            }
        }

        private XmlAttribute GetAttributeInternal(string sItemName)
        {
            XmlAttribute oAttrib = null;
            if (m_oNode.Attributes != null)
                oAttrib = (XmlAttribute)m_oNode.Attributes.GetNamedItem(sItemName);
            return oAttrib;
        }

        private int DecodeXMLInt(string s, int iDefault)
        {
            if (s == string.Empty) return iDefault; else return Int32.Parse(s);
        }

        private double DecodeXMLDouble(string s, double dblDefault)
        {
            if (s == string.Empty) return dblDefault; else return double.Parse(s);
        }

        private decimal DecodeXMLDecimal(string s, decimal decDefault)
        {
            if (s == string.Empty) return decDefault; else return decimal.Parse(s);
        }

        public List<CStruct> GetChildNodeCollection()
        {
            List<CStruct> cln = new List<CStruct>();
            if (m_oNode != null)
            {
                foreach (XmlNode oNode in m_oNode.ChildNodes)
                {
                    CStruct xStruct = new CStruct();
                    xStruct.SetXMLNode(oNode);
                    cln.Add(xStruct);
                }
            }
            return cln;
        }

        public Queue<CStruct> GetCollection(string sItemName)
        {
            Queue<CStruct> cln = new Queue<CStruct>();
            if (m_oNode != null)
            {
                foreach (XmlNode oNode in m_oNode.ChildNodes)
                {
                    if(oNode.Name == sItemName || sItemName == "")
                    {
                        CStruct xStruct = new CStruct();
                        xStruct.SetXMLNode(oNode);
                        cln.Enqueue(xStruct);
                    }
                }
            }
            return cln;
        }

        public System.Collections.Generic.SortedList<string, CStruct> GetListSortedByAttribute(string sItemName, string sAttribute)
        {
            System.Collections.Generic.SortedList<string, CStruct> cln = new SortedList<string, CStruct>();
            if (m_oNode != null)
            {
                foreach (XmlNode oNode in m_oNode.ChildNodes)
                {
                    if (oNode.Name == sItemName)
                    {
                        CStruct xStruct = new CStruct();
                        xStruct.SetXMLNode(oNode, m_oXMLDocument);
                        string sValue = xStruct.GetStringAttr(sAttribute, string.Empty);
                        try { cln.Add(sValue, xStruct); } catch { }
                    }
                }
            }
            return cln;
        }

        public System.Collections.Generic.SortedList<string, CStruct> GetListSortedByItem(string sItemName, string sItem)
        {
            System.Collections.Generic.SortedList<string, CStruct> cln = new SortedList<string, CStruct>();
            if (m_oNode != null)
            {
                foreach (XmlNode oNode in m_oNode.ChildNodes)
                {
                    if (oNode.Name == sItemName)
                    {
                        CStruct xStruct = new CStruct();
                        xStruct.SetXMLNode(oNode, m_oXMLDocument);
                        string sValue = xStruct.GetString(sItem, string.Empty);
                        try { cln.Add(sValue, xStruct); } catch { }
                    }
                }
            }
            return cln;
        }

        public System.Collections.Generic.List<CStruct> GetList(string sItemName)
        {
            System.Collections.Generic.List<CStruct> cln = new List<CStruct>();
            if (m_oNode != null)
            {
                foreach (XmlNode oNode in m_oNode.ChildNodes)
                {
                    if (oNode.Name == sItemName)
                    {
                        CStruct xStruct = new CStruct();
                        xStruct.SetXMLNode(oNode, m_oXMLDocument);
                        cln.Add(xStruct);
                    }
                }
            }
            return cln;
        }

        //public System.Collections.Generic.Hashtable<string,CStruct> GetListKeyedByAttribute(string sItemName, string sAttribute)
        //{
        //    Hashtable cln = new Hashtable();
        //    if (m_oNode != null)
        //    {
        //        foreach (XmlNode oNode in m_oNode.ChildNodes)
        //        {
        //            if (oNode.Name == sItemName)
        //            {
        //                CStruct xStruct = new CStruct();
        //                xStruct.SetXMLNode(oNode, m_oXMLDocument);
        //                string sValue = xStruct.GetStringAttr(sAttribute, string.Empty);
        //                cln.Add(sValue, xStruct);
        //            }
        //        }
        //    }
        //    return cln;
        //}

        public bool GetBoolean(string sItemName)
        {
            return GetBoolean(sItemName, false);
        }

        public bool GetBoolean(string sItemName, bool bDefault)
        {
            XmlNode oNode = GetNodeInternal(sItemName);
            if (oNode != null)
                if (oNode.InnerText == "0") return false; else return true;
            else
                return bDefault;
        }

        public bool GetBooleanAttr(string sItemName)
        {
            return GetBooleanAttr(sItemName, false);
        }

        public bool GetBooleanAttr(string sItemName, bool bDefault)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
                if (oAttrib.InnerText == "0") return false; else return true;
            else
                return bDefault;
        }

        public bool GetBooleanAttr(string sItemName, out bool bTagFound)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
            {
                bTagFound = true;
                if (oAttrib.InnerText == "0") return false; else return true;
            }
            else
            {
                bTagFound = false;
                return false;
            }
        }

        public int GetInt(string sItemName, int iDefault)
        {
            XmlNode oNode = GetNodeInternal(sItemName);
            if (oNode != null)
                return DecodeXMLInt(oNode.InnerText, iDefault);
            else
                return iDefault;
        }

        public int GetInt(string sItemName)
        {
            return GetInt(sItemName, 0);
        }

        public int GetIntAttr(string sItemName)
        {
            return GetIntAttr(sItemName, 0);
        }

        public int GetIntAttr(string sItemName, int iDefault)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
                return DecodeXMLInt(oAttrib.InnerText, iDefault);
            else
                return iDefault;
        }

        public int GetIntAttr(string sItemName, out bool bTagFound)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
            {
                bTagFound = true;
                return DecodeXMLInt(oAttrib.InnerText, 0);
            }
            else
            {
                bTagFound = false;
                return 0;
            }
        }

        public double GetDoubleAttr(string sItemName, double dblDefault)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
                return DecodeXMLDouble(oAttrib.InnerText, dblDefault);
            else
                return dblDefault;
        }

        public double GetDoubleAttr(string sItemName, out bool bTagFound)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
            {
                bTagFound = true;
                return DecodeXMLDouble(oAttrib.InnerText, 0);
            }
            else
            {
                bTagFound = false;
                return 0;
            }
        }

        public decimal GetDecimalAttr(string sItemName, decimal decDefault)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
                return DecodeXMLDecimal(oAttrib.InnerText, decDefault);
            else
                return decDefault;
        }

        public decimal GetDecimalAttr(string sItemName, out bool bTagFound)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
            {
                bTagFound = true;
                return DecodeXMLDecimal(oAttrib.InnerText, 0m);
            }
            else
            {
                bTagFound = false;
                return 0m;
            }
        }

        public string GetString(string sItemName, string sDefault)
        {
            XmlNode oNode = GetNodeInternal(sItemName);
            if (oNode != null)
            {
                return oNode.InnerText;
            }
            else
            {
                return sDefault;
            }
        }

        public string GetString(string sItemName)
        {
            return GetString(sItemName, "");
        }

        public DateTime GetDate(string sItemName, out bool bTagFound)
        {
            XmlNode oNode = GetNodeInternal(sItemName);
            if (oNode != null)
            {
                bTagFound = true;
                if (oNode.InnerText.Length > 0)
                {
                    IFormatProvider culture = new CultureInfo(1044, false);
                    string[] formats = new string[]
                    {
                        "yyyy-MM-ddTHH:mm:ss",
                        "yyyy-MM-dd HH:mm:ss",
                        "yyyy-MM-dd"
                    };
                    DateTime result;
                    if (DateTime.TryParseExact(oNode.InnerText, formats, culture, DateTimeStyles.None, out result))
                        return result;
                    else
                        return DateTime.MinValue;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            else
            {
                bTagFound = false;
                return DateTime.MinValue;
            }
        }

        public DateTime GetDate(string sItemName)
        {
            bool bTagFound;
            return GetDate(sItemName, out bTagFound);
        }

        public string GetStringAttr(string sItemName, string sDefault, out bool bTagFound)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
            {
                bTagFound = true;
                return oAttrib.InnerText;
            }
            else
            {
                bTagFound = false;
                return sDefault;
            }
        }

        public string GetStringAttr(string sItemName)
        {
            bool bTagFound;
            return GetStringAttr(sItemName, "", out bTagFound);
        }

        public string GetStringAttr(string sItemName, string sDefault)
        {
            bool bTagFound;
            return GetStringAttr(sItemName, sDefault, out bTagFound);
        }

        public DateTime GetDateAttr(string sItemName, out bool bTagFound)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
            {
                bTagFound = true;
                if (oAttrib.InnerText.Length > 0)
                {
                    IFormatProvider culture = new CultureInfo(1044, false);
                    string[] formats = new string[]
                    {
                        "yyyy-MM-ddTHH:mm:ss",
                        "yyyy-MM-dd HH:mm:ss",
                        "yyyy-MM-dd"
                    };
                    DateTime result;
                    if (DateTime.TryParseExact(oAttrib.InnerText, formats, culture, DateTimeStyles.None, out result))
                        return result;
                    else
                        return DateTime.MinValue;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            else
            {
                bTagFound = false;
                return DateTime.MinValue;
            }
        }

        public DateTime GetDateAttr(string sItemName)
        {
            bool bTagFound;
            return this.GetDateAttr(sItemName, out bTagFound);
        }

        public Guid GetGuid(string sItemName)
        {
            string s = GetString(sItemName, string.Empty);
            if (s != string.Empty)
                return new Guid(s);
            else
                return Guid.Empty;
        }

        public Guid GetGuidAttr(string sItemName)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            if (oAttrib != null)
                return new Guid(oAttrib.InnerText);
            else
                return Guid.Empty;
        }


        public void CreateString(string sItemName, string sValue)
        {
            AddElement(sItemName, sValue);
        }

        public void CreateStringAttr(string sItemName, string sValue)
        {
            AddAttribute(sItemName, sValue);
        }

        public void CreateBoolean(string sItemName, bool bValue)
        {
            if (bValue) AddElement(sItemName, "1"); else AddElement(sItemName, "0");
        }

        public void CreateBooleanAttr(string sItemName, bool bValue)
        {
            if (bValue) AddAttribute(sItemName, "1"); else AddAttribute(sItemName, "0");
        }

        public void CreateShortAttr(string sItemName, short iValue)
        {
            AddAttribute(sItemName, iValue.ToString());
        }

        public void CreateInt(string sItemName, int iValue)
        {
            AddElement(sItemName, iValue.ToString());
        }

        public bool ReplaceInt(string sItemName, int lNewValue)
        {
            XmlNode oNode = GetNodeInternal(sItemName);
            if (oNode != null)
            {
                oNode.InnerText = lNewValue.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateDouble(string sItemName, double dblValue)
        {
            AddElement(sItemName, dblValue.ToString());
        }

        public void CreateIntAttr(string sItemName, int iValue)
        {
            AddAttribute(sItemName, iValue.ToString());
        }

        //public void CreateLongAttr(string sItemName, long lValue)
        //{
        //    AddAttribute(sItemName, lValue.ToString());
        //}

        public void CreateDoubleAttr(string sItemName, double dblValue)
        {
            AddAttribute(sItemName, dblValue.ToString());
        }

        public void CreateDecimalAttr(string sItemName, decimal decValue)
        {
            AddAttribute(sItemName, decValue.ToString());
        }

        public void CreateGuid(string sItemName, Guid guidValue)
        {
            AddElement(sItemName, guidValue.ToString());
        }

        public void CreateGuidAttr(string sItemName, Guid guidValue)
        {
            AddAttribute(sItemName, guidValue.ToString());
        }

        public void CreateDate(string sItemName, DateTime dtValue)
        {
            AddElement(sItemName, dtValue.ToString("yyyy-MM-ddTHH:mm:ss"));
        }

        public void CreateDateAttr(string sItemName, DateTime dtValue)
        {
            AddAttribute(sItemName, dtValue.ToString("yyyy-MM-ddTHH:mm:ss"));
        }

        public void SetBooleanAttr(string sItemName, bool bValue, bool bCreateIfFalse = true)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            bool bFound = false;
            if (oAttrib != null)
            {
                if (bValue) AddAttribute(sItemName, "1"); else AddAttribute(sItemName, "0");
                oAttrib.InnerText = bValue ? "1" : "0";
                bFound = true;
            }
            if (bFound == false)
            {
                if (bValue || bCreateIfFalse)
                    CreateBooleanAttr(sItemName, bValue);
            }
        }

        public void SetStringAttr(string sItemName, string sValue, bool bCreateIfFalse = true)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            bool bFound = false;
            if (oAttrib != null)
            {
                oAttrib.InnerText = sValue;
                bFound = true;
            }
            if (bFound == false)
            {
                if (bCreateIfFalse)
                    CreateStringAttr(sItemName, sValue);
            }
        }

        public void SetIntAttr(string sItemName, int nValue, bool bCreateIfFalse = true)
        {
            XmlAttribute oAttrib = GetAttributeInternal(sItemName);
            bool bFound = false;
            if (oAttrib != null)
            {
                oAttrib.InnerText = nValue.ToString();
                bFound = true;
            }
            if (bFound == false)
            {
                if (bCreateIfFalse)
                    CreateIntAttr(sItemName, nValue);
            }
        }

        //private string XmlToJSON(XmlDocument xmlDoc)
        //{
        //    StringBuilder sbJSON = new StringBuilder();
        //    sbJSON.Append("{ ");
        //    XmlToJSONnode(sbJSON, xmlDoc.DocumentElement, true);
        //    sbJSON.Append("}");
        //    return sbJSON.ToString();
        //}

        //  XmlToJSONnode:  Output an XmlElement, possibly as part of a higher array
        private void XmlToJSONnode(StringBuilder sbJSON, XmlElement node, bool showNodeName)
        {
            if (showNodeName)
                sbJSON.Append("\"" + SafeJSON(node.Name) + "\": ");
            sbJSON.Append("{");
            // Build a sorted list of key-value pairs
            //  where   key is case-sensitive nodeName
            //          value is an ArrayList of string or XmlElement
            //  so that we know whether the nodeName is an array or not.
            SortedList childNodeNames = new SortedList();

            //  Add in all node attributes
            if( node.Attributes!=null)
                foreach (XmlAttribute attr in node.Attributes)
                    StoreChildNode(childNodeNames,attr.Name,attr.InnerText);

            //  Add in all nodes
            foreach (XmlNode cnode in node.ChildNodes)
            {
                if (cnode is XmlText)
                    StoreChildNode(childNodeNames, "value", cnode.InnerText);
                else if (cnode is XmlElement)
                    StoreChildNode(childNodeNames, cnode.Name, cnode);
            }

            // Now output all stored info
            foreach (string childname in childNodeNames.Keys)
            {
                ArrayList alChild = (ArrayList)childNodeNames[childname];
                if (alChild.Count == 1)
                    OutputNode(childname, alChild[0], sbJSON, true);
                else
                {
                    sbJSON.Append(" \"" + SafeJSON(childname) + "\": [ ");
                    foreach (object Child in alChild)
                        OutputNode(childname, Child, sbJSON, false);
                    sbJSON.Remove(sbJSON.Length - 2, 2);
                    sbJSON.Append(" ], ");
                }
            }
            sbJSON.Remove(sbJSON.Length - 2, 2);
            sbJSON.Append(" }");
        }

        //  StoreChildNode: Store data associated with each nodeName
        //                  so that we know whether the nodeName is an array or not.
        private void StoreChildNode(SortedList childNodeNames, string nodeName, object nodeValue)
        {
	        // Pre-process contraction of XmlElement-s
            if (nodeValue is XmlElement)
            {
                // Convert  <aa></aa> into "aa":null
                //          <aa>xx</aa> into "aa":"xx"
                XmlNode cnode = (XmlNode)nodeValue;
                if( cnode.Attributes.Count == 0)
                {
                    XmlNodeList children = cnode.ChildNodes;
                    if( children.Count==0)
                        nodeValue = null;
                    else if (children.Count == 1 && (children[0] is XmlText))
                        nodeValue = ((XmlText)(children[0])).InnerText;
                }
            }
            // Add nodeValue to ArrayList associated with each nodeName
            // If nodeName doesn't exist then add it
            object oValuesAL = childNodeNames[nodeName];
            ArrayList ValuesAL;
            if (oValuesAL == null)
            {
                ValuesAL = new ArrayList();
                childNodeNames[nodeName] = ValuesAL;
            }
            else
                ValuesAL = (ArrayList)oValuesAL;
            ValuesAL.Add(nodeValue);
        }

        private void OutputNode(string childname, object alChild, StringBuilder sbJSON, bool showNodeName)
        {
            if (alChild == null)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                sbJSON.Append("null");
            }
            else if (alChild is string)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                string sChild = (string)alChild;
                sChild = sChild.Trim();
                sbJSON.Append("\"" + SafeJSON(sChild) + "\"");
            }
            else
                XmlToJSONnode(sbJSON, (XmlElement)alChild, showNodeName);
            sbJSON.Append(", ");
        }

        // Make a string safe for JSON
        private string SafeJSON(string sIn)
        {
            StringBuilder sbOut = new StringBuilder(sIn.Length);
            foreach (char ch in sIn)
            {
                if (Char.IsControl(ch) || ch == '\'')
                {
                    int ich = (int)ch;
                    sbOut.Append(@"\u" + ich.ToString("x4"));
                    continue;
                }
                else if (ch == '\"' || ch == '\\' || ch == '/')
                {
                    sbOut.Append('\\');
                }
                sbOut.Append(ch);
            }
            return sbOut.ToString();
        }
    }
}
