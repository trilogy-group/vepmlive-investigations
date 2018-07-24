
using System.Web.UI.WebControls;

namespace EPMLiveCore.Tests.Testables
{
    public class NewAppTestable : newapp
    {
        public string Url => base.URL;
        public string BaseUrl => base.baseURL;
        public new DropDownList DdlGroup => base.DdlGroup;
        public new RadioButton rdoTopLinkYes => base.rdoTopLinkYes;
        public new RadioButton rdoTopLinkNo => base.rdoTopLinkNo;
        public new RadioButton rdoInherit => base.rdoInherit;
        public new RadioButton rdoUnique => base.rdoUnique;
        public new Panel pnlTitle => base.pnlTitle;
        public new Panel pnlURL => base.pnlURL;
        public new Panel pnlURLBad => base.pnlURLBad;
        public new TextBox txtTitle => base.txtTitle;
        public new TextBox txtURL => base.txtURL;
        public new Label label1 => base.label1;
        public new Panel Panel2 => base.Panel2;

        public NewAppTestable()
        {
            btnOK = new Button();
            base.DdlGroup = new DropDownList();
            base.DdlGroup.Items.Add("test");
            base.DdlGroup.SelectedIndex = 0;

            base.rdoTopLinkYes = new RadioButton();
            base.rdoTopLinkNo = new RadioButton();
            base.rdoInherit = new RadioButton();
            base.rdoUnique = new RadioButton();
            base.txtTitle = new TextBox();
            base.txtURL = new TextBox();
            base.pnlTitle = new Panel();
            base.pnlURL = new Panel();
            base.pnlURLBad = new Panel();
            base.label1 = new Label();
            base.Panel2 = new Panel();
            base.inpName = new InputFormSectionTestable();
            Page = new System.Web.UI.Page();
        }

        public void Page_Load()
        {
            base.Page_Load(this, null);
        }

        public void BtnOK_Click()
        {
            base.BtnOK_Click(this, null);
        }
    }
}
