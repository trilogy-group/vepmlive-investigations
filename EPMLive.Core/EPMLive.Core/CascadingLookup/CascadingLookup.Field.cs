using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;
using System.Security;

namespace EPMLiveCore
{
    [Guid("0021e891-033c-4ea5-8855-09585eea6f0e")]
    public class CascadingLookupField : SPFieldText
    {
        public class Properties
        {
            public string Url;
            public string List;
            public string Field;
            public string ParentField;
            public string ChildrenField;
            public string FilterValueField;
            public string DefineNone;
        }

        #region Properties
        private static Dictionary<int, Properties> staticPropertyList = new Dictionary<int, Properties>();

        #region Property : (int) ContextId
        private int contextId;
        public int ContextId
        {
            get
            {
                if (SPContext.Current == null && contextId > 0)
                    return contextId;

                return SPContext.Current.GetHashCode();
            }
            set
            {
                contextId = value;
            }
        }
        #endregion

        #region Property : (string) Url
        private string strUrl;
        public string Url
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].Url : strUrl;
            }
            set
            {
                strUrl = value;
            }
        }
        #endregion

        #region Property : (string) List
        private string strList;
        public string List
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].List : strList;
            }
            set
            {
                strList = value;
            }
        }
        #endregion

        #region Property : (string) Field
        private string strField;
        public string Field
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].Field : strField;
            }
            set
            {
                strField = value;
            }
        }
        #endregion

        #region Property : (string) ParentField
        private string strParentField;
        public string ParentField
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].ParentField : strParentField;
            }
            set
            {
                strParentField = value;
            }
        }
        #endregion

        #region Property : (string) ChildrenField
        private string strChildrenField;
        public string ChildrenField
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].ChildrenField : strChildrenField;
            }
            set
            {
                strChildrenField = value;
            }
        }
        #endregion

        #region Property : (string) FilterValueField
        private string strFilterValueField;
        public string FilterValueField
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].FilterValueField : strFilterValueField;
            }
            set
            {
                strFilterValueField = value;
            }
        }
        #endregion

        #region Property : (string) DefineNone
        private string strDefineNone;
        public string DefineNone
        {
            get
            {
                return staticPropertyList.ContainsKey(ContextId) ? staticPropertyList[ContextId].DefineNone : strDefineNone;
            }
            set
            {
                strDefineNone = value;
            }
        }
        #endregion

        public void UpdateMyCustomProperty(string propertyName, string value)
        {
            if (!staticPropertyList.ContainsKey(ContextId))
            {
                staticPropertyList.Add(ContextId, new Properties());
            }

            switch (propertyName)
            {
                case "Url":
                    staticPropertyList[ContextId].Url = value;
                    break;

                case "List":
                    staticPropertyList[ContextId].List = value;
                    break;

                case "Field":
                    staticPropertyList[ContextId].Field = value;
                    break;

                case "ParentField":
                    staticPropertyList[ContextId].ParentField = value;
                    break;

                case "ChildrenField":
                    staticPropertyList[ContextId].ChildrenField = value;
                    break;

                case "FilterValueField":
                    staticPropertyList[ContextId].FilterValueField = value;
                    break;

                case "DefineNone":
                    staticPropertyList[ContextId].DefineNone = value;
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Constructors
        public CascadingLookupField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
            Initialize();
        }

        public CascadingLookupField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.strUrl = this.GetCustomProperty("Url") + string.Empty;
            this.strList = this.GetCustomProperty("List") + string.Empty;
            this.strField = this.GetCustomProperty("Field") + string.Empty;
            this.strParentField = this.GetCustomProperty("ParentField") + string.Empty;
            this.strChildrenField = this.GetCustomProperty("ChildrenField") + string.Empty;
            this.strFilterValueField = this.GetCustomProperty("FilterValueField") + string.Empty;
            this.strDefineNone = this.GetCustomProperty("DefineNone") + string.Empty;
        }
        #endregion

        public override BaseFieldControl FieldRenderingControl
        {
            [SecurityCritical]
            get
            {
                BaseFieldControl fieldControl = new CascadingLookupFieldControl();
                fieldControl.FieldName = this.InternalName;

                return fieldControl;
            }
        }

        public override object GetFieldValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value;
        }

        public override void OnAdded(SPAddFieldOptions op)
        {
            base.OnAdded(op);
            this.Update();
        }

        public override void Update()
        {
            if (!string.IsNullOrEmpty(this.Url))
                this.SetCustomProperty("Url", this.Url);

            if (!string.IsNullOrEmpty(this.List))
                this.SetCustomProperty("List", this.List);

            if (!string.IsNullOrEmpty(this.Field))
                this.SetCustomProperty("Field", this.Field);

            if (!string.IsNullOrEmpty(this.ParentField))
                this.SetCustomProperty("ParentField", this.ParentField);

            if (!string.IsNullOrEmpty(this.ChildrenField))
                this.SetCustomProperty("ChildrenField", this.ChildrenField);

            if (!string.IsNullOrEmpty(this.FilterValueField))
                this.SetCustomProperty("FilterValueField", this.FilterValueField);

            if (!string.IsNullOrEmpty(this.DefineNone))
                this.SetCustomProperty("DefineNone", this.DefineNone);

            base.Update();

            if (staticPropertyList.ContainsKey(this.ContextId))
                staticPropertyList.Remove(this.ContextId);
        }
    }
}
