using System.ComponentModel;
using Microsoft.SharePoint.WebPartPages;

namespace Dashboard
{
    public partial class Dashboard
    {
        // CC-78374 changing private members names are not permitted on EPM
        private string strField;
        private string strIssueField;
        private string strRiskField;

        [Category("State Fields")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Project Center State Field")]
        [Description("")]
        [Browsable(true)]

        // The accessor for this property.
        public string MyState
        {
            get
            {
                if (strField == null || strField.Trim() == string.Empty)
                {
                    return "State";
                }
                return strField;
            }
            set { strField = value; }
        }

        [Category("State Fields")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Issue State Field")]
        [Description("")]
        [Browsable(true)]

        // The accessor for this property.
        public string MyIssueState
        {
            get
            {
                if (strIssueField == null || strIssueField.Trim() == string.Empty)
                {
                    return "Status";
                }
                return strIssueField;
            }
            set { strIssueField = value; }
        }

        [Category("State Fields")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Risk Status Field")]
        [Description("")]
        [Browsable(true)]

        // The accessor for this property.
        public string MyRiskState
        {
            get
            {
                if (strRiskField == null || strRiskField.Trim() == string.Empty)
                {
                    return "Status";
                }
                return strRiskField;
            }
            set { strRiskField = value; }
        }
    }
}