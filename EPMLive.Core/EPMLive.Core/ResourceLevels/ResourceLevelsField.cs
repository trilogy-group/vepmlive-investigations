using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;
using System.Security;

namespace EPMLiveCore
{
    class ResourceLevelsField : SPFieldText
    {
        #region constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="fieldName"></param>
        public ResourceLevelsField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="typeName"></param>
        /// <param name="displayName"></param>
        public ResourceLevelsField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
        }
        #endregion

        public override BaseFieldControl FieldRenderingControl
        {
            [SecurityCritical]
            get
            {
                BaseFieldControl fieldControl = new ResourceLevelsFieldControl();
                fieldControl.FieldName = this.InternalName;

                return fieldControl;
            }
        }

    }


}
