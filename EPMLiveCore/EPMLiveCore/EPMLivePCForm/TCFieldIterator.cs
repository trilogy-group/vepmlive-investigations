using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;


namespace EPMLiveCore
{
    public class TCFieldIterator : ListFieldIterator
    {
        protected override bool IsFieldExcluded(SPField field)
        {
            SPListItem li = SPContext.Current.ListItem;

            string fieldName = field.InternalName;

            if (li.ID == 0)
            {
                if (field.InternalName == "AssignedTo")
                {
                    return false;
                }
            }
            else
            {
                if (field.InternalName == "Project")
                {
                    return true;
                }
                if (field.InternalName == "AssignedTo")
                {
                    string project = getVal(li, "Project");

                    SPWeb web = SPContext.Current.Web;

                    try
                    {
                        SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter")];

                        string id = project.Split(";#".ToCharArray())[0];

                        SPQuery query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='ID'/><Value Type='Number'>" + id + "</Value></Eq></Where>";

                        SPListItem projectli = list.GetItemById(int.Parse(id));

                        if (getVal(projectli, "IsProjectServer") == "True")
                            return true;
                        else
                            return false;


                    }
                    catch { }

                }
            }

            return base.IsFieldExcluded(field);
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
