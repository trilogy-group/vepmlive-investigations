using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;


namespace EPMLiveCore
{
    public class PCFieldIterator : ListFieldIterator
    {
        protected override bool IsFieldExcluded(SPField field)
        {
            SPListItem li = SPContext.Current.ListItem;
            SPList list = SPContext.Current.List;

            string fieldName = field.InternalName;

            if (getVal(li, "IsProjectServer") == "True")
            {
                if(fieldName == "SharePointProject" || fieldName == "PublishToPWA" || fieldName == "Title")
                    return true;
            }

            if (getVal(li,"SharePointProject") == "True" || li.ID==0)
            {
                if (fieldName.Length > 3)
                {
                    if (fieldName.Substring(0, 3) == "ENT" && getFieldInt(fieldName.Substring(3)) > 0)
                    {
                        return false;
                    }
                }
            }
            return base.IsFieldExcluded(list.Fields.GetFieldByInternalName(field.InternalName));
        }

        private string getVal(SPListItem li, string field)
        {
            try
            {
                return li[field].ToString();
            }
            catch { }
            return "";
        }

        private int getFieldInt(string f)
        {
            try
            {
                return int.Parse(f);
            }
            catch
            {
                return 0;
            }
        }
    }
}
