using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets my work grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridLayout(string data)
        {
            try
            {
                var spWeb = SPContext.Current.Web;

                data = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));

                GetSettings(data);

                XDocument result;
                XElement grid;
                var fields = MyWorkFields(data, GetMyWorkParams.SelectedFields, GetMyWorkParams.SelectedLists, spWeb, out result, out grid);
                var rightColElements = grid.Element(RightCols).Elements(CField);
                var leftCols =
                    grid.Element(LeftCols).Elements(CField).Attributes(Name).Select(a => a.Value);
                var centerCols =
                    grid.Element(Cols).Elements(CField).Attributes(Name).Select(a => a.Value);
                var rightCols = rightColElements.Attributes(Name).Select(a => a.Value);
                var fieldTypes = Utils.GetFieldTypes();
                var cols = grid.Element(Cols);

                AddGridLayoutElementValue(fields, leftCols, centerCols, rightCols, fieldTypes, spWeb, cols);

                var workTypeCol = new XElement(CField);
                workTypeCol.Add(new XAttribute(Name, WorkTypeField));
                workTypeCol.Add(new XAttribute(Type, Html));
                workTypeCol.Add(new XAttribute(VisibleText, 0));

                cols.Add(workTypeCol);

                foreach (var rightColElement in rightColElements)
                {
                    cols.Add(rightColElement);
                }

                AddGridLayoutAttributes(grid, fields, leftCols, rightCols, fieldTypes);
                grid.Element(RightCols).RemoveNodes();
                AddWorkingOnElement(data, result, spWeb);

                return result.ToString();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2040, exception.Message);
            }
        }

        private static IList<MyWorkField> MyWorkFields(
            string data,
            IList<string> selectedFields,
            List<string> selectedLists,
            SPWeb spWeb,
            out XDocument result,
            out XElement grid)
        {
            Guard.ArgumentIsNotNull(selectedFields, nameof(selectedFields));
            Guard.ArgumentIsNotNull(selectedLists, nameof(selectedLists));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            var fields = new List<MyWorkField>();

            foreach (var field in selectedFields.Where(field => !fields.Exists(f => f.Name.Equals(field))))
            {
                fields.Add(new MyWorkField {Name = field, DisplayName = field.ToPrettierName(selectedLists, spWeb)});
            }

            result = XDocument.Parse(Resources.MyWorkGridLayout);
            grid = result.Element(GridText);
            var cfgElement = new XElement(Cfg);

            cfgElement.Add(
                new XAttribute(
                    Id,
                    XDocument.Parse(data)
                       .Element(nameof(MyWork))
                       .Element(WebPart)
                       .Attribute(IdText)
                       .Value));
            cfgElement.Add(
                new XAttribute(
                    Css,
                    $"{SPContext.Current.Web.Url}/_layouts/15/epmlive/treegrid/grid/grid.css"));

            grid.Add(cfgElement);
            return fields;
        }

        private static void AddGridLayoutElementValue(
            IList<MyWorkField> fields,
            IEnumerable<string> leftCols,
            IEnumerable<string> centerCols,
            IEnumerable<string> rightCols,
            IDictionary<string, SPField> fieldTypes,
            SPWeb spWeb,
            XElement cols)
        {
            Guard.ArgumentIsNotNull(fields, nameof(fields));
            Guard.ArgumentIsNotNull(leftCols, nameof(leftCols));
            Guard.ArgumentIsNotNull(centerCols, nameof(centerCols));
            Guard.ArgumentIsNotNull(rightCols, nameof(rightCols));
            Guard.ArgumentIsNotNull(fieldTypes, nameof(fieldTypes));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(cols, nameof(cols));

            foreach (var myWorkField in fields.OrderBy(f => f.DisplayName)
               .Where(myWorkField => !leftCols.Contains(myWorkField.Name))
               .Where(myWorkField => !centerCols.Contains(myWorkField.Name))
               .Where(myWorkField => !rightCols.Contains(myWorkField.Name)))
            {
                var internalName = myWorkField.Name;
                string format;
                var type = GetMyWorkFieldType(myWorkField, fieldTypes, out format);
                var element = new XElement(CField);
                element.Add(new XAttribute(Name, Utils.ToGridSafeFieldName(internalName)));
                element.Add(new XAttribute(Type, type));

                if (!string.IsNullOrWhiteSpace(format))
                {
                    var relatedGridFormat = GetRelatedGridFormat(type, format, fieldTypes[internalName], spWeb);
                    element.Add(new XAttribute(Format, relatedGridFormat));

                    if (type.Equals(Date) || type.Equals(Float) && relatedGridFormat.Contains(Percent))
                    {
                        element.Add(new XAttribute(EditFormat, relatedGridFormat));
                    }
                }

                if (type.Equals(IconText))
                {
                    element.Add(new XAttribute(IconAlign, Center));
                }

                element.Add(new XAttribute(VisibleText, 0));

                if (internalName.Equals(DueDateField))
                {
                    element.Add(
                        new XAttribute(
                            ClassFormula,
                            $"calculateDueColor('{DueDateField}',Row)"));
                }

                cols.Add(element);
            }
        }

        private static void AddGridLayoutAttributes(
            XElement grid,
            IList<MyWorkField> fields,
            IEnumerable<string> leftCols,
            IEnumerable<string> rightCols,
            Dictionary<string, SPField> fieldTypes)
        {
            Guard.ArgumentIsNotNull(grid, nameof(grid));
            Guard.ArgumentIsNotNull(fields, nameof(fields));
            Guard.ArgumentIsNotNull(leftCols, nameof(leftCols));
            Guard.ArgumentIsNotNull(rightCols, nameof(rightCols));
            Guard.ArgumentIsNotNull(fieldTypes, nameof(fieldTypes));

            var header = grid.Element(Header);

            foreach (var myWorkField in fields.OrderBy(f => f.DisplayName)
               .Where(myWorkField => !leftCols.Contains(myWorkField.Name))
               .Where(
                    myWorkField => !rightCols.Contains(myWorkField.Name)))
            {
                var name = Utils.ToGridSafeFieldName(myWorkField.Name);
                var value = myWorkField.DisplayName;
                string format;
                var type = GetMyWorkFieldType(myWorkField, fieldTypes, out format);

                if (name.Equals(Author))
                {
                    value = CreatedBy;
                }
                else if (name.Equals(Editor))
                {
                    value = ModifiedBy;
                }

                header.Add(new XAttribute(name, value));

                if (type.Equals(Date) || type.Equals(Float))
                {
                    header.Add(new XAttribute($@"{name}Align", Right));
                }
            }
        }

        private static void AddWorkingOnElement(string data, XDocument result, SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(result, nameof(result));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            var xDocument = XDocument.Parse(data);

            if (xDocument.Element(nameof(MyWork))
               .Descendants()
               .ToList()
               .Exists(
                    e => e.Name.LocalName.Equals(CompleteItemsQuery)))
            {
                if (!bool.Parse(xDocument.Element(nameof(MyWork)).Element(CompleteItemsQuery).Value))
                {
                    result.Element(GridText)
                       .Element(LeftCols)
                       .Elements(CField)
                       .FirstOrDefault(e => e.Attribute(Name).Value.Equals(Complete))
                       .Add(new XAttribute(Tip, MarkComplete));
                }
            }

            if (!ShouldUseReportingDb(spWeb))
            {
                var workingOnElement =
                    (from e in result.Descendants(CField)
                        where e.Attribute(Name).Value.Equals(WorkingOnField)
                        select e).FirstOrDefault();

                workingOnElement?.Add(
                    new XAttribute(CanFilter, 0),
                    new XAttribute(CanGroup, 0),
                    new XAttribute(CanHide, 0));
            }
        }
    }
}