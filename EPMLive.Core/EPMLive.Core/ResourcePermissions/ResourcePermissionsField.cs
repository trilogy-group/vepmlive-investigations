using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.WebControls;
using System.Security;

namespace EPMLiveCore
{
    internal class ResourcePermissionsField : SPFieldMultiLineText
    {
        #region Properties (1)

        public override BaseFieldControl FieldRenderingControl
        {
            [SecurityCritical]
            get
            {
                BaseFieldControl fieldControl = new ResourcePermissionsFieldControl();
                fieldControl.FieldName = InternalName;

                return fieldControl;
            }
        }

        #endregion Properties

        #region constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="fieldName"></param>
        public ResourcePermissionsField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName) { }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="typeName"></param>
        /// <param name="displayName"></param>
        public ResourcePermissionsField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName) { }

        #endregion
    }
}