using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PortfolioEngineCore
{
    internal class CTSFieldDefinition
    {
        public int FieldID;
        public string Title;
        public TSFieldFormatEnum Format;
        public TSFieldAlignEnum Align;

        public bool IsCategory;
        public int CategoryListID;
        public bool CategorySelectListLeafOnly;
        public bool CategoryUseFullName;
        public bool CategoryIsIdentity;
        public bool CategoryIsTSAdmin;

        public bool Hidden;
        public bool Frozen;
        public string SQLName;

        //public Collection ListValues;

        public SortTypeEnum Sort;
        public int Width;

        protected CTSFieldDefinition Clone()
        {
            CTSFieldDefinition oClone;
            oClone = new CTSFieldDefinition();

            oClone.FieldID = FieldID;
            oClone.Title = Title;
            oClone.Format = Format;
            oClone.Align = Align;
            oClone.IsCategory = IsCategory;
            oClone.CategoryListID = CategoryListID;
            oClone.CategorySelectListLeafOnly = CategorySelectListLeafOnly;
            oClone.CategoryUseFullName = CategoryUseFullName;
            oClone.CategoryIsIdentity = CategoryIsIdentity;
            oClone.CategoryIsTSAdmin = CategoryIsTSAdmin;
            oClone.Hidden = Hidden;
            oClone.Frozen = Frozen;
            oClone.SQLName = SQLName;
            //oClone.ListValues = ListValues;
            oClone.Sort = Sort;
            oClone.Width = Width;

            return oClone;
        }

        protected bool UsesEnterpriseCode()
        {
            bool bUsesEnterpriseCode = false;
            bUsesEnterpriseCode = false;
            if (CategoryListID > 0)
            {
                if (CategoryListID > 100000000)
                    bUsesEnterpriseCode = true;
            }
            return bUsesEnterpriseCode;
        }

        public XmlNode XMLEncode(XmlDocument oXMLDocument)
        {
            return XMLEncode2(oXMLDocument).GetXMLNode();
        }

        protected CStruct XMLEncode2(XmlDocument oXMLDocument)
        {
            CStruct xField = null;
            try
            {
                xField = new CStruct();
                xField.Initialize("Field", oXMLDocument);
                xField.CreateIntAttr("ID", FieldID);
                xField.CreateStringAttr("Title", Title);
                xField.CreateIntAttr("Format", (int)Format);
                xField.CreateIntAttr("Align", (int)Align);
                if (Hidden)
                    xField.CreateBooleanAttr("Hidden", Hidden);
                if (Frozen)
                    xField.CreateBooleanAttr("Frozen", Frozen);
                if (Sort != SortTypeEnum.stNone)
                    xField.CreateIntAttr("Sort", (int)Sort);
                if (IsCategory)
                {
                    xField.CreateBooleanAttr("IsCategory", IsCategory);
                    xField.CreateIntAttr("CatListID", CategoryListID);
                    xField.CreateBooleanAttr("CatLeafOnly", CategorySelectListLeafOnly);
                    xField.CreateBooleanAttr("UseFullName", CategoryUseFullName);
                    xField.CreateBooleanAttr("CatIsIdentity", CategoryIsIdentity);
                    xField.CreateBooleanAttr("CatIsTSAdmin", CategoryIsTSAdmin);
                }
                if (Width > 0)
                    xField.CreateIntAttr("Width", Width);
            }
            catch
            {
                //dba.HandleException("XMLEncode2", (StatusEnum)99999, ex);
            }
            return xField;
        }

        protected bool XMLDecode(XmlNode oXMLNode)
        {
            if (oXMLNode != null)
            {
                CStruct xField;
                xField = new CStruct();
                xField.SetXMLNode(oXMLNode);
                FieldID = xField.GetIntAttr("ID");
                Title = xField.GetStringAttr("Title");
                Format = (TSFieldFormatEnum)xField.GetIntAttr("Format");
                Align = (TSFieldAlignEnum)xField.GetIntAttr("Align");
                Hidden = xField.GetBooleanAttr("Hidden");
                Frozen = xField.GetBooleanAttr("Frozen");
                Sort = (SortTypeEnum)xField.GetIntAttr("Sort", (int)SortTypeEnum.stNone);
                IsCategory = xField.GetBooleanAttr("IsCategory");
                CategoryListID = xField.GetIntAttr("CatListID");
                CategorySelectListLeafOnly = xField.GetBooleanAttr("CatLeafOnly");
                CategoryUseFullName = xField.GetBooleanAttr("UseFullName");
                CategoryIsIdentity = xField.GetBooleanAttr("CatIsIdentity");
                CategoryIsTSAdmin = xField.GetBooleanAttr("CatIsTSAdmin");
                Width = xField.GetIntAttr("Width");
            }
            return true;
        }

    }
}
