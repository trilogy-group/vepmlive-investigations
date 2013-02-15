using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM.SPFields
{
    public class PFEResourcePermissionsField : SPFieldText
    {
        #region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="PFEResourcePermissionsField"/> class.
        /// </summary>
        /// <param name="fields">An <see cref="T:Microsoft.SharePoint.SPFieldCollection"/> object that represents the field collection.</param>
        /// <param name="typeName">A string that contains the name of the field type, which can be a string representation of an <see cref="T:Microsoft.SharePoint.SPFieldType"/> value.</param>
        /// <param name="displayName">A string that contains the display name of the field.</param>
        public PFEResourcePermissionsField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PFEResourcePermissionsField"/> class.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <param name="fieldName">Name of the field.</param>
        public PFEResourcePermissionsField(SPFieldCollection fields, string fieldName) : base(fields, fieldName)
        {
        }

        #endregion Constructors 

        #region Properties (1) 

        /// <summary>
        /// Gets the field type control that is used to render the field.
        /// </summary>
        /// <returns>A <see cref="T:Microsoft.SharePoint.WebControls.BaseFieldControl"/> object that represents the control.</returns>
        public override BaseFieldControl FieldRenderingControl
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            get { return new PFEResourcePermissionsFieldControl {FieldName = InternalName}; }
        }

        #endregion Properties 

        #region Methods (1) 

        // Public Methods (1) 

        /// <summary>
        /// Returns the field value in HTML format in order to render the field value directly on the page.
        /// </summary>
        /// <param name="value">An object that represents the value to convert.</param>
        /// <returns>
        /// A string that contains the value in HTML format.
        /// </returns>
        public override string GetFieldValueAsHtml(object value)
        {
            if (value != null) value = value.ToString().Replace(",", ", ");

            return base.GetFieldValueAsHtml(value);
        }

        #endregion Methods 
    }
}