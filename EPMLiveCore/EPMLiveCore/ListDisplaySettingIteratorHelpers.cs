using System;
using System.Diagnostics;
using System.Reflection;
using System.Web.UI;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public class ListDisplaySettingIteratorHelpers
    {
        public static void ClearCache()
        {
            try
            {
                try
                {
                    new RecentItemsLinkProvider(SPContext.Current.Site.ID, SPContext.Current.Web.ID, SPContext.Current.Web.CurrentUser.LoginName).ClearCache();
                }
                catch
                {
                    CacheStore.Current.RemoveCategory(new CacheStoreCategory().Navigation);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public static void ProcessControl(HtmlTextWriter writer, Control parentControl, int index)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (parentControl == null)
            {
                throw new ArgumentNullException(nameof(parentControl));
            }

            var value = GetFormField(parentControl, index).ItemFieldValue.ToString();

            var stringValue = string.Empty;
            try
            {
                stringValue = GetFieldLabel(parentControl, 1).Field.GetFieldValueAsHtml(value);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            if (stringValue.IndexOf(".gif", StringComparison.InvariantCultureIgnoreCase) > 0 ||
                stringValue.IndexOf(".jpg", StringComparison.InvariantCultureIgnoreCase) > 0)
            {
                writer.Write($"<img src=\"{SPContext.Current.Web.Url}/_layouts/images/{stringValue}\">");
            }
            else if (stringValue == string.Empty)
            {
                writer.Write("&nbsp;");
            }
            else
            {
                writer.Write(stringValue);
            }
        }

        private static Control GetControl(FieldMetadata formField)
        {
            return formField.FindControlRecursive(x => x.GetType() == GetChildControlBasedOnFieldType(formField.Field.FieldRenderingControl));
        }

        private static Type GetChildControlBasedOnFieldType(object field)
        {
            if (field.GetType().Equals(typeof(MultipleLookupField)))
            {
                return typeof(MultipleLookupField);
            }

            if (field.GetType().Equals(typeof(LookupField)))
            {
                return typeof(LookupField);
            }

            return null;
        }

        public static void SetFieldName(TemplateContainer child, string fieldName)
        {
            try
            {
                PropertyInfo property = child.GetType().GetProperty("FieldName", BindingFlags.NonPublic | BindingFlags.Instance);
                property.SetValue(child, fieldName, null);
            }
            catch (Exception) { }
        }

        public static void SetControlMode(TemplateContainer child, SPControlMode controlMode)
        {
            try
            {
                PropertyInfo property = child.GetType().GetProperty("ControlMode", BindingFlags.NonPublic | BindingFlags.Instance);
                property.SetValue(child, controlMode, null);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public static SPFieldLookup GetFieldLookup(FormField formField)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }

            return formField.Field as SPFieldLookup;
        }

        public static void RenderDisabledLookup(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("<script language=\"javascript\">");
            writer.WriteLine("function CustomPreSaveAction(){");
            writer.WriteLine("var tags = document.getElementsByTagName('input');");
            writer.WriteLine("for (var i = 0; i < tags.length; i++) {");
            writer.WriteLine("var tagIdStr = tags[i].id;");
            writer.WriteLine(" if (tagIdStr.indexOf(\"Title_\") == 0 && tagIdStr.lastIndexOf(\"_$TextField\" == tagIdStr.length - \"_$TextField\".length)) {");
            writer.WriteLine("var col = tags[i];");
            writer.WriteLine("if (col != null && col.value != null && col.value != \"\") {");
            writer.WriteLine("var title = col.value.replace(/[^a-zA-Z0-9 ]/g, \"\");");
            writer.WriteLine(" if (title.length == 0) {");
            writer.WriteLine("alert(\"At least one alpha-numeric character is required for \" + col.title);");
            writer.WriteLine(" return false;");
            writer.WriteLine("}");
            writer.WriteLine(" }");
            writer.WriteLine("}");
            writer.WriteLine("}");
            writer.WriteLine(" return true;");
            writer.WriteLine("  }");
            writer.WriteLine("</script>");
        }
        public static void RenderCheckSpecialCharacters(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteLine("<script language=\"javascript\">");
            writer.WriteLine("function checkSpecialCharacters(objectName,object){");
            writer.WriteLine("var checkPattern = /[\\|\\\\\"\'\\/\\[\\]\\:\\<\\>\\+\\=\\,\\;\\?\\*\\@]/");
            writer.WriteLine("if(checkPattern.test(object.value)) { alert(objectName + ' cannot contain any of the following characters ' + '| \\\\ \" \\' / [ ] : < > + = , ; ? * @'); object.value = ''; setTimeout(function(){object.focus();}, 1); }");
            writer.WriteLine("}");

            writer.WriteLine("function checkSpecialCharactersForNonGeneric(objectName,object){");
            writer.WriteLine("var checkPattern = /[\\|\\\\\"\\/\\[\\]\\:\\<\\>\\+\\=\\,\\;\\?\\*\\@]/");
            writer.WriteLine("if(checkPattern.test(object.value)) { alert(objectName + ' cannot contain any of the following characters ' + '| \\\\ \" \\/ [ ] : < > + = , ; ? * @'); object.value = ''; setTimeout(function(){object.focus();}, 1); }");
            writer.WriteLine("}");
        }

        public static FieldLabel GetFieldLabel(Control control, int index1, int index2, int index3)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (FieldLabel)control.Controls[index1].Controls[index2].Controls[index3];
        }

        public static FormField GetFormField(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (FormField)control.Controls[index];
        }

        public static FieldLabel GetFieldLabel(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (FieldLabel)control.Controls[index];
        }

        public static CompositeField GetCompositeField(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (CompositeField)control.Controls[index];
        }

        public static string GetControlType(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return control.Controls[index].GetType().ToString();
        }        
    }
}