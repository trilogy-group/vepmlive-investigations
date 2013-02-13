using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;

namespace EPMLiveCore
{
    public class WEPickerDialog : Microsoft.SharePoint.WebControls.PickerDialog
    {
        private Dictionary<string, string> getColumns(SPWeb web)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            SPList list = web.Lists.TryGetList("Resources");
            if(list != null)
            {
                foreach(SPField f in list.Fields)
                {
                    if(!f.Hidden && f.Reorderable)
                    {
                        d.Add(f.InternalName, f.Title);
                    }
                }
            }
            return d;
        }

        public WEPickerDialog() : base(new WEPeopleQuery(SPContext.Current.Web.ID), new TableResultControl(), new WEPeopleEditor())
        {
            ArrayList columnDisplayNames = ((TableResultControl)base.ResultControl).ColumnDisplayNames;
            columnDisplayNames.Clear();

            ArrayList columnNames = ((TableResultControl)base.ResultControl).ColumnNames;
            columnNames.Clear();

            ArrayList columnWidths = ((TableResultControl)base.ResultControl).ColumnWidths;
            columnWidths.Clear();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                try
                {
                    using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        using(SPWeb web = site.OpenWeb(SPContext.Current.Web.ID))
                        {
                            string resUrl = CoreFunctions.getLockConfigSetting(web, "EPMLiveResourceURL", false);

                            Dictionary<string, string> arrCols;

                            if(resUrl.ToLower() == web.ServerRelativeUrl.ToLower())
                            {
                                arrCols = getColumns(web);
                            }
                            else
                            {
                                using(SPSite rsite = new SPSite(resUrl))
                                {
                                    using(SPWeb w = rsite.OpenWeb())
                                    {
                                        arrCols = getColumns(w);
                                    }
                                }
                            }

                            if(arrCols != null)
                            {
                                foreach(string k in arrCols.Keys)
                                {
                                    columnDisplayNames.Add(arrCols[k]);
                                    columnNames.Add(k);
                                    columnWidths.Add("180px");
                                }
                            }
                        }
                    }
                }
                catch { }
            });

        }

    }
}
