using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class ControlDataBuilder
    {
        private IDictionary<string, string> _parameters = new Dictionary<string, string>();

        public ControlDataBuilder AddParameter(string key, object value)
        {
            // TODO: (CC-76591, 2018-07-10) Consider using formatters for non-string types
            _parameters.Add(key, value.ToString());
            return this;
        }

        public ControlDataBuilder AddParametersForLookupField(SPFieldLookup lookupField)
        {
            return AddParameter("ParentWebID", lookupField.ParentList.ParentWeb.ID)
                  .AddParameter("LookupWebID", lookupField.LookupWebId)
                  .AddParameter("LookupListID", lookupField.LookupList)
                  .AddParameter("LookupFieldInternalName", lookupField.LookupField)
                  .AddParameter("LookupFieldID", lookupField.Id)
                  .AddParameter("IsMultiSelect", lookupField.AllowMultipleValues)
                  .AddParameter("Required", lookupField.Required);
        }

        public ControlDataBuilder AddParmetersForField(SPField field, bool allowMultipleValues)
        {
            var valueFormatString = string.Join(string.Empty,
                field.InternalName,
                "_",
                field.Id.ToString(),
                "{0}"
            );

            if (allowMultipleValues)
            {
                // need control id for the addbutton, removeButton, selectCandidate, selectResult controls
                AddParameter("SelectCandidateID", string.Format(valueFormatString, "_SelectCandidate"));
                AddParameter("AddButtonID", string.Format(valueFormatString, "_AddButton"));
                AddParameter("RemoveButtonID", string.Format(valueFormatString, "_RemoveButton"));
                AddParameter("SelectResultID", string.Format(valueFormatString, "_SelectResult"));
            }
            // in the case of a single select
            // we just need the input or the dropdown
            // controls id to post back data
            else
            {
                AddParameter("SourceDropDownID", string.Format(valueFormatString, "_$" + field.FieldRenderingControl.GetType().Name));
                AddParameter("SourceControlID", string.Format(valueFormatString, "_$" + field.FieldRenderingControl.GetType().Name));
            }

            return this;
        }

        public ControlDataBuilder AddParametersForLookupData(LookupConfigData lookupData)
        {
            return AddParameter("Field", lookupData.Field)
                   .AddParameter("ControlType", lookupData.Type)
                   .AddParameter("Parent", lookupData.Parent)
                   .AddParameter("ParentListField", lookupData.ParentListField);
        }

        public string BuildControlData()
        {
            return string.Format("<Data>{0}</Data>",
                string.Join(string.Empty,
                    _parameters.Select(parameter =>
                        string.Format("<Param key=\"{0}\">{1}</Param>",
                            System.Security.SecurityElement.Escape(parameter.Key),
                            System.Security.SecurityElement.Escape(parameter.Value)
                        )
                    )
                ));
        }
    }
}
