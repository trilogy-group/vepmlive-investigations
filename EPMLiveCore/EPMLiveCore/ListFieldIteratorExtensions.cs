using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public static class ListFieldIteratorExtensions
    {
        public static FormField GetFormFieldByField(this ListFieldIterator listFieldIterator, SPField field)
        {
            return GetFormField(listFieldIterator, GetFormFields(listFieldIterator), field);
        }

        public static List<FormField> GetFormFieldByType(this ListFieldIterator listFieldIterator, Type fieldType)
        {
            return GetFormField(listFieldIterator, GetFormFields(listFieldIterator), fieldType);
        }

        public static List<FormField> GetFormField(this ListFieldIterator listFieldITerator, List<FormField> formFields, Type fieldType)
        {
            List<FormField> fields = (from form in formFields
                where form.Field.GetType().Equals(fieldType)
                select form).ToList<FormField>();

            return fields;
        }

        public static FormField GetFormField(this ListFieldIterator listFieldITerator, List<FormField> formFields, SPField field)
        {
            FormField ff = (from form in formFields
                where form.Field.Equals(field)
                select form).FirstOrDefault();

            return ff;
        }

        public static List<FormField> GetFormFields(this ListFieldIterator listFieldIterator)
        {
            if (listFieldIterator == null)
            {
                return null;
            }

            return FindFieldFormControls(listFieldIterator);
        }

        private static List<FormField> FindFieldFormControls(System.Web.UI.Control root)
        {
            List<FormField> baseFieldControls = new List<FormField>();

            foreach (System.Web.UI.Control control in root.Controls)
            {
                if (control is FormField && control.Visible)
                {
                    FormField formField = control as FormField;
                    if (formField.Field.FieldValueType == typeof(DateTime))
                    {
                        //HandleDateField(formField);
                    }

                    baseFieldControls.Add(formField);
                }
                else
                {
                    baseFieldControls.AddRange(FindFieldFormControls(control));
                }
            }

            return baseFieldControls;
        }
    }
}