using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.SharePoint;
using System.Xml;

namespace EPMLiveCore.API
{
    public class ViewManager
    {
        public Dictionary<string, Dictionary<string, string>> Views = new Dictionary<string, Dictionary<string, string>>();

        public ViewManager(SPWeb web, string property)
        {
            Init(CoreFunctions.getConfigSetting(web, property));
        }

        public ViewManager(string propertyBag)
        {
            Init(propertyBag);
        }

        private void Init(string propertyBag)
        {

            if(propertyBag != "")
            {
                string[] sViews = propertyBag.Replace(";#", "\n").Split('\n');

                foreach(string sView in sViews)
                {
                    string[] sViewInfos = sView.Split('`');

                    Dictionary<string, string> ViewProperties = new Dictionary<string, string>();

                    for(int i = 1; i < sViewInfos.Length; i++)
                    {

                        string[] sViewInfoInfos = sViewInfos[i].Split('^');

                        if(sViewInfoInfos.Length >= 2)
                        {
                            ViewProperties.Add(sViewInfoInfos[0], sViewInfoInfos[1]);
                        }
                    }

                    Views.Add(sViewInfos[0], ViewProperties);
                }
            }
        }

        private string GetAttribute(XmlNode nd, string attr)
        {
            try
            {
                return nd.Attributes[attr].Value;
            }
            catch { }
            return "";
        }

        public void AddViewByXmlNode(XmlNode nd)
        {
            string Name = GetAttribute(nd, "Name");
            string Default = GetAttribute(nd, "Default");
            //string Cols = GetAttribute(nd, "Cols");
            //string Filters = GetAttribute(nd, "Filters");
            //string Group = GetAttribute(nd, "Group");
            //string Sort = GetAttribute(nd, "Sort");
            //string Expand = GetAttribute(nd, "Expand");

            if(Name != "")
            {
                bool found = false;
                bool foundDefault = false;

                foreach(KeyValuePair<string, Dictionary<string, string>> key in Views)
                {

                    if(Default.ToLower() == "true")
                    {
                        key.Value["Default"] = "false";
                    }

                    if(key.Key == Name)
                    {
                        found = true;

                        key.Value.Clear();

                        foreach(XmlAttribute attr in nd.Attributes)
                        {
                            if(attr.Name != "Name")
                            {
                                key.Value.Add(attr.Name, attr.Value);
                            }
                        }
                    }

                    try
                    {
                        if(key.Value["Default"].ToLower() == "true")
                        {
                            foundDefault = true;
                        }
                    }
                    catch { }

                }

                if(!found)
                {
                    if(!foundDefault)
                    {
                        nd.Attributes["Default"].Value = "true";
                    }

                    Dictionary<string, string> vInfo = new Dictionary<string, string>();

                    foreach(XmlAttribute attr in nd.Attributes)
                    {
                        if(attr.Name != "Name")
                        {
                            vInfo.Add(attr.Name, attr.Value);
                        }
                    }

                    Views.Add(Name, vInfo);
                }
                else if(!foundDefault)
                {
                    foreach(KeyValuePair<string, Dictionary<string, string>> key in Views)
                    {
                        if(key.Value.ContainsKey("Default"))
                            key.Value["Default"] = "true";
                        else
                            key.Value.Add("Default", "true");
                        break;
                    }
                }
            }
        }

        public void DeleteView(string view)
        {
            try
            {
                Views.Remove(view);
            }
            catch { }
            //foreach(KeyValuePair<string, Dictionary<string, string>> key in Views)
            //{
            //    if(key.Key == view)
            //    {
            //        Views.d
            //    }
            //}
        }

        public void RenameView(string view, string newname, string defaultView)
        {
            try
            {
                if (defaultView.ToLower() == "true")
                {
                    foreach (KeyValuePair<string, Dictionary<string, string>> key in Views)
                    {
                        key.Value["Default"] = "false";
                    }
                }

                Dictionary<string, string> d = Views[view];
                if (d.ContainsKey("Default"))
                {                    
                    d["Default"] = defaultView;
                }
                Views.Remove(view);
                Views.Add(newname, d);
            }
            catch { }
            //try
            //{
            //    Views[view]
            //}
            //catch { }
            //foreach(KeyValuePair<string, Dictionary<string, string>> key in Views)
            //{
            //    if(key.Key == view)
            //    {
            //        Views.d
            //    }
            //}
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(KeyValuePair<string, Dictionary<string, string>> de in Views)
            {
                StringBuilder sbi = new StringBuilder();

                sbi.Append(de.Key);
                sbi.Append('`');

                foreach(KeyValuePair<string, string> dei in de.Value)
                {
                    sbi.Append(dei.Key);
                    sbi.Append('^');
                    sbi.Append(dei.Value);
                    sbi.Append('`');
                }

                sb.Append(sbi.ToString().Trim('`'));
                sb.Append('\n');
            }

            return sb.ToString().Trim('\n').Replace("\n",";#");
        }

        public string ToJSON()
        {
            StringBuilder sb = new StringBuilder();
            
            int i = 0;

            SortedList sl = new SortedList();

            foreach(KeyValuePair<string, Dictionary<string, string>> de in Views)
            {

                sl.Add(de.Key, de.Value);

            }

            foreach(DictionaryEntry de in sl)
            {

                StringBuilder sbi = new StringBuilder();

                sbi.Append("V");
                sbi.Append(i);
                sbi.Append(":{Name:\"");
                sbi.Append(de.Key);
                sbi.Append("\",");

                foreach(KeyValuePair<string, string> dei in (Dictionary<string, string>)de.Value)
                {
                    sbi.Append(dei.Key);
                    sbi.Append(":\"");
                    sbi.Append(dei.Value);
                    sbi.Append("\",");
                }

                sb.Append(sbi.ToString().Trim(',') + "}");

                sb.Append(',');

                i++;
            }

            return "{" + sb.ToString().Trim(',') + "}";
        }
    }
}
