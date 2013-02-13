using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class GenericPickerDialog : PickerDialog
    {
        private GenericEntityPickerPropertyBag propertyBag;
        private SPList list;

        public GenericEntityPickerPropertyBag PropertyBag
        {
            get
            {
                if (propertyBag == null)
                {
                    propertyBag = new GenericEntityPickerPropertyBag(this.EditorControl.CustomProperty);
                }
                return propertyBag;
            }

        }

        public GenericPickerDialog()
            : base(new GenericQueryControl(), new TableResultControl(), new GenericEntityEditor())
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            ArrayList columnDisplayNames = ((TableResultControl)base.ResultControl).ColumnDisplayNames;
            columnDisplayNames.Clear();

            ArrayList columnNames = ((TableResultControl)base.ResultControl).ColumnNames;
            columnNames.Clear();

            ArrayList columnWidths = ((TableResultControl)base.ResultControl).ColumnWidths;
            columnWidths.Clear();           

            using (SPWeb web = SPContext.Current.Site.OpenWeb(PropertyBag.LookupWebID))
            {
                SPList list = web.Lists[propertyBag.LookupListID];

                foreach (SPField field in list.Fields)
                {   
                    if (propertyBag.LookupFieldInternalName == field.InternalName)
                    {
                        columnDisplayNames.Add(field.Title);
                        columnNames.Add(field.Id.ToString());
                    }
                }
            }

            if (columnNames.Count > 0)
            {

                int width = (int)(100 / columnNames.Count);
                for (int i = 0; i < columnNames.Count; i++)
                {
                    columnWidths.Add(width.ToString() + "%");
                }
            }


            base.OnLoad(e);

        }

    }
}
