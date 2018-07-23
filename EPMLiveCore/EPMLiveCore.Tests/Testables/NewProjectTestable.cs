using System.Web.UI.WebControls;

namespace EPMLiveCore.Tests.Testables
{
    public class NewProjectTestable : newproject
    {
        public string Url => base.URL;
        public string BaseUrl => base.baseURL;
        public new DropDownList DdlGroup => base.DdlGroup;
        public new RadioButton rdoTopLinkYes => base.rdoTopLinkYes;
        public new RadioButton rdoTopLinkNo => base.rdoTopLinkNo;
        public new RadioButton rdoInherit => base.rdoInherit;
        public new RadioButton rdoUnique => base.rdoUnique;

        public NewProjectTestable()
        {
            btnOK = new Button();
            base.DdlGroup = new DropDownList();
            base.rdoTopLinkYes = new RadioButton();
            base.rdoTopLinkNo = new RadioButton();
            base.rdoInherit = new RadioButton();
            base.rdoUnique = new RadioButton();
            Page = new System.Web.UI.Page();
        }

        public void Page_Load()
        {
            base.Page_Load(this, null);
        }
    }
}
