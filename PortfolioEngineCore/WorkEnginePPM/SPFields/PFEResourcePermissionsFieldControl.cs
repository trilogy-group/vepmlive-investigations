using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using WorkEnginePPM.WebServices.Core;
using WSC = WorkEnginePPM.WebServices.Core;

namespace WorkEnginePPM.SPFields
{
    public class PFEResourcePermissionsFieldControl : BaseFieldControl
    {
        #region Fields (1) 

        private CheckBoxList _checkBoxList;

        #endregion Fields 

        #region Properties (2) 

        /// <summary>
        /// Gets the name of the default rendering template.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> object that names a rendering template. </returns>
        protected override string DefaultTemplateName
        {
            get { return "PFEResourcePermissionsFieldControl"; }
        }

        /// <summary>
        /// When overridden in a derived class, gets or sets the value of the field in the UI.
        /// </summary>
        /// <returns>When overridden in a derived class, a <see cref="T:System.Object"/> that represents the value of the field in the UI. Typically, this is the text of a child control, such as a label or text box, that actually renders the field. </returns>
        public override object Value
        {
            get
            {
                var list = new List<string>();

                foreach (ListItem listItem in _checkBoxList.Items.Cast<ListItem>()
                    .Where(listItem => listItem.Selected)
                    .Where(listItem => !list.Contains(listItem.Value)))
                {
                    list.Add(listItem.Value);
                }

                return string.Join(", ", list.ToArray());
            }
            set { base.Value = value; }
        }

        #endregion Properties 

        #region Methods (3) 

        // Public Methods (1) 

        /// <summary>
        /// Updates the underlying value of the field to the latest user-set value.
        /// </summary>
        public override void UpdateFieldValueInItem()
        {
            EnsureChildControls();

            var list = new List<string>();

            foreach (ListItem listItem in _checkBoxList.Items.Cast<ListItem>()
                .Where(listItem => listItem.Selected)
                .Where(listItem => !list.Contains(listItem.Value)))
            {
                list.Add(listItem.Value);
            }

            ItemFieldValue = string.Join(",", list.ToArray());
        }

        // Protected Methods (2) 

        /// <summary>
        /// Creates any child controls necessary to render the field, such as a label control, link control, or text box control.
        /// </summary>
        protected override void CreateChildControls()
        {
            if (Field == null) return;

            base.CreateChildControls();

            if (ControlMode == SPControlMode.Display) return;

            Guid dataId = Guid.NewGuid();

            var dataTable = new DataTable();
            dataTable.Columns.Add("GroupId");
            dataTable.Columns.Add("GroupName");

            var currentPermissions = new List<string>();

            try
            {
                XDocument permissionGroupsDocument;
                XDocument resourcePermissionsDocument;

                using (var resourceManager = new ResourceManager(SPContext.Current.Web))
                {
                    permissionGroupsDocument = XDocument.Parse(resourceManager.ReadPermissionGroups());

                    string resourcePermXml =
                        string.Format(
                            @"<ReadResourcePermissionGroups><Data><Resource ExtId=""{0}"" DataId=""{1}""/></Data></ReadResourcePermissionGroups>",
                            Item.ID, dataId);

                    resourcePermissionsDocument =
                        XDocument.Parse(resourceManager.ReadResourcePermissionGroups(resourcePermXml));
                }

                // ReSharper disable PossibleNullReferenceException

                XElement dataElement = permissionGroupsDocument.Root.Element("Data");

                foreach (XElement groupElement in dataElement.Elements("PermissionGroup"))
                {
                    dataTable.Rows.Add(new object[]
                                           {
                                               groupElement.Attribute("Id").Value,
                                               groupElement.Attribute("Name").Value
                                           });
                }

                dataElement = resourcePermissionsDocument.Root.Element("Data");
                XElement resourceElement = dataElement.Elements("Resource").FirstOrDefault();

                currentPermissions.AddRange(
                    resourceElement.Elements("PermissionGroup").Select(
                        groupElement => groupElement.Attribute("Id").Value));

                // ReSharper restore PossibleNullReferenceException
            }
            catch
            {
            }

            _checkBoxList = (CheckBoxList) TemplateContainer.FindControl("PFEResourcePermissionsFieldCheckBoxList");

            _checkBoxList.DataValueField = "GroupId";
            _checkBoxList.DataTextField = "GroupName";
            _checkBoxList.DataSource = dataTable;
            _checkBoxList.DataBind();

            foreach (ListItem listItem in
                _checkBoxList.Items.Cast<ListItem>().Where(listItem => currentPermissions.Contains(listItem.Value)))
            {
                listItem.Selected = true;
            }
        }

        /// <summary>
        /// Renders the field for noneditable display.
        /// </summary>
        /// <param name="output">The object that writes the HTML that is to be rendered.</param>
        protected override void RenderFieldForDisplay(HtmlTextWriter output)
        {
            if (ItemFieldValue != null) output.Write(Field.GetFieldValueAsHtml(ItemFieldValue).Replace(",", ", "));
            else base.RenderFieldForDisplay(output);
        }

        #endregion Methods 
    }
}