using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml.Linq;

namespace EPMLiveCore
{
    public class GenericEntityPickerPropertyBag
    {
        private XMLDataManager _xmlDataMgr;
        private Guid lookupFieldTargetFieldID;

        public Guid ParentWebID { get; set; }
        public Guid LookupWebID { get; set; }
        public Guid LookupListID { get; set; }
        public string LookupFieldInternalName { get; set; }
        public Guid LookupFieldSourceFieldID { get; set; }
        public string IsMultiSelect { get; set; }
        // properties only valid for a single select lookup
        public string SourceControlID { get; set; }
        public string SourceDropDownID { get; set; }
        // properties only valid for a multi select lookup
        public string SelectCandidateID { get; set; }
        public string AddButtonID { get; set; }
        public string RemoveButtonID { get; set; }
        public string SelectResultID { get; set; }
        public string ControlType { get; set; }
        public string Parent { get; set; }
        public string ParentListField { get; set; }
        public string Field { get; set; }
        public bool Required { get; set; }

        public Guid LookupFieldTargetFieldID
        {
            get
            {   
                if (LookupWebID != null && LookupListID != null)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                        {
                            using (SPWeb ew = es.OpenWeb(LookupWebID))
                            {
                                SPList el = ew.Lists[LookupListID];
                                try
                                {
                                    lookupFieldTargetFieldID = el.Fields.GetFieldByInternalName(LookupFieldInternalName).Id;
                                }
                                catch { }
                            }
                        }
                    });
                }
                
                return lookupFieldTargetFieldID;
            }
        }

        public Guid ListID { get; set; }
        public int ItemID { get; set; } 

        public GenericEntityPickerPropertyBag()
        {
        }

        /// <summary>
        /// format values as such
        /// LookupWebID(string),LookupListID(string),LookupFieldName(string)
        /// </summary>
        /// <param name="value"></param>
        public GenericEntityPickerPropertyBag(string value)
        {
            _xmlDataMgr = new XMLDataManager(value);
            this.ParentWebID = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("ParentWebID")) ? new Guid(_xmlDataMgr.GetPropVal("ParentWebID")) : Guid.Empty ;
            this.LookupWebID = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("LookupWebID")) ? new Guid(_xmlDataMgr.GetPropVal("LookupWebID")) : Guid.Empty ;
            this.LookupListID = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("LookupListID")) ? new Guid(_xmlDataMgr.GetPropVal("LookupListID")) : Guid.Empty ;
            this.LookupFieldInternalName = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("LookupFieldInternalName")) ? _xmlDataMgr.GetPropVal("LookupFieldInternalName") : "";
            this.LookupFieldSourceFieldID = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("LookupFieldID")) ? new Guid(_xmlDataMgr.GetPropVal("LookupFieldID")) : Guid.Empty;
            this.ListID = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("ListID")) ? new Guid(_xmlDataMgr.GetPropVal("ListID")) : Guid.Empty;
            this.ItemID = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("ItemID")) ? int.Parse(_xmlDataMgr.GetPropVal("ItemID")) : -99;
            this.IsMultiSelect = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("IsMultiSelect")) ? _xmlDataMgr.GetPropVal("IsMultiSelect") : "false";
            this.ControlType = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("ControlType")) ? _xmlDataMgr.GetPropVal("ControlType") : "";
            this.Parent = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("Parent")) ? _xmlDataMgr.GetPropVal("Parent") : "";
            this.ParentListField = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("ParentListField")) ? _xmlDataMgr.GetPropVal("ParentListField") : "";
            this.Field = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("Field")) ? _xmlDataMgr.GetPropVal("Field") : "";
            this.Required = !string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("Required")) ? bool.Parse(_xmlDataMgr.GetPropVal("Required")) : false;

            if (bool.Parse(IsMultiSelect))
            {
                this.SelectCandidateID = _xmlDataMgr.GetPropVal("SelectCandidateID");
                this.AddButtonID = _xmlDataMgr.GetPropVal("AddButtonID");
                this.RemoveButtonID = _xmlDataMgr.GetPropVal("RemoveButtonID");
                this.SelectResultID = _xmlDataMgr.GetPropVal("SelectResultID");
                
            }
            else
            {
                this.SourceControlID = _xmlDataMgr.GetPropVal("SourceControlID");
                this.SourceDropDownID = _xmlDataMgr.GetPropVal("SourceDropDownID");
            }

        }

        public override string ToString()
        {
            return  "<Data>" +
                    "<Param key=\"ParentWebID\">" + ParentWebID.ToString() + "</Param>" +
                    "<Param key=\"LookupWebID\">" + LookupWebID.ToString() + "</Param>" +
                    "<Param key=\"LookupListID\">" + LookupListID.ToString() + "</Param>" +
                    "<Param key=\"LookupFieldInternalName\">" + LookupFieldInternalName + "</Param>" +
                    "<Param key=\"LookupFieldID\">" + LookupFieldSourceFieldID.ToString() + "</Param>" +
                    "<Param key=\"IsMultiSelect\">" + IsMultiSelect + "</Param>" +
                    "<Param key=\"ListID\">" + ListID.ToString() + "</Param>" +
                    "<Param key=\"ItemID\">" + ItemID.ToString() + "</Param>" +
                    "<Param key=\"SourceControlID\">" + (!string.IsNullOrEmpty(SourceControlID) ? SourceControlID : string.Empty) + "</Param>" +
                    "<Param key=\"SelectCandidateID\">" + (!string.IsNullOrEmpty(SelectCandidateID) ? SelectCandidateID : string.Empty) + "</Param>" +
                    "<Param key=\"AddButtonID\">" + (!string.IsNullOrEmpty(AddButtonID) ? AddButtonID : string.Empty) + "</Param>" +
                    "<Param key=\"RemoveButtonID\">" + (!string.IsNullOrEmpty(RemoveButtonID) ? RemoveButtonID : string.Empty) + "</Param>" +
                    "<Param key=\"SelectResultID\">" + (!string.IsNullOrEmpty(SelectResultID) ? SelectResultID : string.Empty) + "</Param>" +
                    "<Param key=\"Required\">" + Required.ToString() + "</Param>" +
                    "</Data>";
        }
    }

}
