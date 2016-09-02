using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;

namespace EPMLiveWebParts
{

    class CheckBoxTemplate : ITemplate
    {

        private ListItemType _itemType;

        private string _columnName;
        private string _sortName;


        public CheckBoxTemplate(ListItemType itemType, string columnName,string sortName)
        {

            _itemType = itemType;
            _columnName = columnName;
            _sortName = sortName;
        }


        public void InstantiateIn(Control container)
        {

            switch (_itemType)
            {

                case ListItemType.Header:

                    LiteralControl header = new LiteralControl();

                    header.Text = string.Format("<b>{0}</b>", _columnName);

                    container.Controls.Add(header);

                    break;

                case ListItemType.Item:

                    CheckBox checkboxitem = new CheckBox();

                    checkboxitem.ID = "selectedList";

                    checkboxitem.Visible = true;

                    container.Controls.Add(checkboxitem);

                    HtmlInputHidden listIdIdItem = new HtmlInputHidden();

                    listIdIdItem.ID = "listIdItem";

                    container.Controls.Add(listIdIdItem);

                    break;
                case ListItemType.EditItem:

                    TextBox txtBox = new TextBox();
                    txtBox.ID = "selectDisplayName";
                    txtBox.Text = _sortName;
                    txtBox.DataBind();
                    container.Controls.Add(txtBox);
                    break;

                default:

                    break;

            }

        }

    }
}



