using System;
using System.Web.UI;
using System.Text;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class Buttonbar : UserControl
    {
        private string m_sButtons = "";
        private string m_sEventHandler = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LiteralControl lit = new LiteralControl(idPersistButtonBar.Value.ToString().Replace("&lt;", "<"));
                this.idButtonBarBody.Controls.Add(lit);
                idPersistButtonBar.Value = "";
            }
        }

        public void EventHandler(string sEventHandler)
        {
            m_sEventHandler = sEventHandler;
        }

        public void AddButton(string id, string caption, string tooltip, string image, string alt, string width, string accessKey, bool bDisabled)
        {
            string sDisabled = "";
            if (bDisabled) sDisabled = " disabled ";
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<td id='" + id + "_frame' class='bb_buttonframe'>");
            sb.AppendLine("<button id='" + id + "' type='button' class='bb_button' style='border:0; width:" + width + ";' title='" + tooltip + "' accesskey='" + accessKey + "' onclick='javascript:" + m_sEventHandler + "(\"" + this.ID + "\", \"onclick\", \"" + id + "\");'" + sDisabled + ">");
            sb.AppendLine("<table class='bb_buttontable' cellspacing='0' cellpadding='0'><tr>");
            if (image != string.Empty)
            {
                sb.AppendLine("<td valign='middle'><img style='cursor:hand;' class='bb_buttonimage' src='" + image + "' alt='" + alt + "'" + sDisabled + "/></td>");
                if (caption != string.Empty)
                    sb.AppendLine("<td style='width: 0.5em;'></td>");
            }
            if (caption != string.Empty)
            {
                sb.AppendLine("<td class='bb_text'>" + caption + "</td>");
            }
            sb.AppendLine("</tr></table></button></td>");
            m_sButtons += sb.ToString();
        }

        public void Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='bb_main'>");
            sb.AppendLine("<table class='bb_buttonbartable' cellspacing='0' cellpadding='0' style='display: block;'><tr>");
            sb.AppendLine(m_sButtons);
            sb.AppendLine("</tr></table></div>");

            LiteralControl lit = new LiteralControl(sb.ToString());
            this.idButtonBarBody.Controls.Add(lit);
        }
    }
}
