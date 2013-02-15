using System.Collections.Generic;
using System.Web.UI;

namespace EPMLiveReportsAdmin
{
    public class EPMMenu
    {
        private List<EPMMenuItem> _items = new List<EPMMenuItem>();
        private string _name;

        private string formatString =
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"35\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"{0}Controls\" largeIconMode=\"false\">{2}</menu></span><span title=\"Open Menu\"><div  id=\"{0}_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('{0}Controls'), MMU_GetMenuFromClientId('{0}'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('{0}')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"{0}\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('{0}Controls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('{0}Controls'), MMU_GetMenuFromClientId('{0}'), event);\" onclick=\" MMU_Open(byid('{0}Controls'), MMU_GetMenuFromClientId('{0}'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID={0},TEMPLATECLIENTID={0}Controls\" serverclientid=\"{0}\">{1}<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>";

        public EPMMenu(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<EPMMenuItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public string Render()
        {
            string items = "";
            foreach (var item in _items)
            {
                items += item.Render();
            }
            return string.Format(formatString, _name + "Menu", _name, items);
        }

        public void Render(Control control)
        {
            control.Controls.Add(new LiteralControl(Render()));
        }
    }

    public class EPMMenuItem
    {
        private const string FormatString = "<ie:menuitem id=\"{0}\" type=\"option\" iconSrc=\"{1}\" onMenuClick=\"{2}\" text=\"{3}\" menuGroupId=\"{4}\"></ie:menuitem>";
        private string _groupId;
        private string _icon;
        private string _id;
        private string _onMenuClick;
        private string _text;
        private bool _enabled;

        public EPMMenuItem(string id, string icon, string onMenuClick, string text, string groupId, bool enabled)
        {
            _id = id;
            _icon = icon;
            _onMenuClick = enabled ? onMenuClick : "javascript:alert('This site is not currently configured to allow list mapping');return false;";
            _text = text;
            _groupId = groupId;
            _enabled = enabled;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string OnMenuClick
        {
            get { return _onMenuClick; }
            set { _onMenuClick = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public string Render()
        {
            return string.Format(FormatString, _id, _icon, _onMenuClick, _text, _groupId);
        }
    }
}
