using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets my work grid view.
        /// </summary>
        /// <param name="xDocument">The x document.</param>
        /// <returns></returns>
        private static MyWorkGridView GetMyWorkGridView(XDocument xDocument)
        {
            Guard.ArgumentIsNotNull(xDocument, nameof(xDocument));

            if (!xDocument.Elements().ToList().Exists(e => e.Name.LocalName.Equals(nameof(MyWork))))
            {
                throw new InvalidOperationException(CannotFindMyWorkElement);
            }

            var myWorkElement = xDocument.Element(nameof(MyWork));

            if (!myWorkElement.Elements().ToList().Exists(e => e.Name.LocalName.Equals(View)))
            {
                throw new InvalidOperationException(CannotFindViewElement);
            }

            var viewElement = myWorkElement.Element(View);

            foreach (
                var attribute in
                new[]
                    {
                        IdText, Name, DefaultText, Personal, LeftCols, Cols, RightCols, Filters, Grouping,
                        Sorting
                    }
                   .Where(
                        attribute =>
                            !viewElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals(attribute))))
            {
                throw new InvalidOperationException($"{CannotFindAttribute}{attribute}");
            }

            return new MyWorkGridView
            {
                Id = viewElement.Attribute(IdText).Value,
                Name = viewElement.Attribute(Name).Value,
                Default = Convert.ToBoolean(viewElement.Attribute(DefaultText).Value),
                Personal = Convert.ToBoolean(viewElement.Attribute(Personal).Value),
                LeftCols = viewElement.Attribute(LeftCols).Value,
                Cols = viewElement.Attribute(Cols).Value,
                RightCols = viewElement.Attribute(RightCols).Value,
                Filters = viewElement.Attribute(Filters).Value,
                Grouping = viewElement.Attribute(Grouping).Value,
                Sorting = viewElement.Attribute(Sorting).Value,
                HasPermission = Convert.ToBoolean(viewElement.Attribute(HasPermission).Value)
            };
        }

        /// <summary>
        ///     Deletes my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string DeleteMyWorkGridView(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement(nameof(MyWork)));

                var xDocument = XDocument.Parse(data);
                var configWeb = Utils.GetConfigWeb();

                if (!xDocument.Elements().ToList().Exists(e => e.Name.LocalName.Equals(nameof(MyWork))))
                {
                    throw new InvalidOperationException(CannotFindMyWorkElement);
                }

                var myWorkElement = xDocument.Element(nameof(MyWork));

                if (!myWorkElement.Elements().ToList().Exists(e => e.Name.LocalName.Equals(View)))
                {
                    throw new InvalidOperationException(CannotFindViewElement);
                }

                var viewElement = myWorkElement.Element(View);

                foreach (var attribute in new[] { IdText, Personal }.Where(
                    attribute => !viewElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals(attribute))))
                {
                    throw new InvalidOperationException($"{CannotFindAttribute}{attribute}");
                }

                var viewId = viewElement.Attribute(IdText).Value;
                var isViewPersonal = Convert.ToBoolean(viewElement.Attribute(Personal).Value);
                var isViewDefault = Convert.ToBoolean(viewElement.Attribute(DefaultText).Value);

                if (isViewPersonal)
                {
                    DeletePersonalView(viewId, GetPersonalViews(configWeb), configWeb);
                }
                else
                {
                    DeleteGlobalView(viewId, isViewDefault, GetGlobalViews(configWeb), configWeb);
                }

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
                throw new APIException(2035, exception.Message);
            }
        }

        /// <summary>
        ///     Gets my work grid views.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridViews(SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            try
            {
                var result = new XDocument();
                result.Add(new XElement(nameof(MyWork)));
                result.Element(nameof(MyWork)).Add(new XElement(Views));

                var viewsElement = result.Element(nameof(MyWork)).Element(Views);
                var configWeb = Utils.GetConfigWeb();
                var myWorkGridViews = GetGlobalViews(configWeb).ToList();

                if (!myWorkGridViews.ToList().Exists(v => v.Id.Equals(Dv)))
                {
                    var cols = $"Flag:{FlagColWidth},DueDate:{DueDateColWidth},DueDay:{DueDayColWidth}";

                    var myWorkGridView = new MyWorkGridView
                    {
                        Id = Dv,
                        Name = DefaultView,
                        Default = true,
                        Personal = false,
                        LeftCols =
                            $"Complete:{CompleteColWidth},CommentCount:{CommentColWidth},Priority:{PriorityColWidth}Title:{TitleColWidth}",
                        Cols = cols,
                        RightCols = string.Empty,
                        Filters = ZeroVerBar,
                        Grouping = ZeroVerBar,
                        Sorting = DueDate
                    };

                    SaveGlobalViews(myWorkGridView, Utils.GetConfigWeb());
                    myWorkGridViews.Insert(0, myWorkGridView);
                }

                Action<IEnumerable<MyWorkGridView>, string> addViewElements = (workGridViews, typeValue) =>
                {
                    foreach (var myWorkGridView in workGridViews)
                    {
                        var xElement = new XElement(View);

                        xElement.Add(new XAttribute(IdText, myWorkGridView.Id));
                        xElement.Add(new XAttribute(Name, myWorkGridView.Name));
                        xElement.Add(new XAttribute(LeftCols, GetLeftCols(myWorkGridView)));
                        xElement.Add(new XAttribute(Cols, myWorkGridView.Cols));
                        xElement.Add(new XAttribute(RightCols, myWorkGridView.RightCols));
                        xElement.Add(new XAttribute(Grouping, myWorkGridView.Grouping));
                        xElement.Add(new XAttribute(Filters, myWorkGridView.Filters));
                        xElement.Add(new XAttribute(Sorting, myWorkGridView.Sorting));
                        xElement.Add(new XAttribute(DefaultText, myWorkGridView.Default));
                        xElement.Add(new XAttribute(Type, typeValue));

                        viewsElement.Add(xElement);
                    }
                };

                addViewElements(myWorkGridViews, GlobalText);
                addViewElements(GetPersonalViews(configWeb), Personal);

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
                throw new APIException(2080, exception.Message);
            }
        }

        /// <summary>
        ///     Renames my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string RenameMyWorkGridView(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement(nameof(MyWork)));

                var xDocument = XDocument.Parse(data);
                var configWeb = Utils.GetConfigWeb();

                if (!xDocument.Elements().ToList().Exists(e => e.Name.LocalName.Equals(nameof(MyWork))))
                {
                    throw new InvalidOperationException(CannotFindMyWorkElement);
                }

                var myWorkElement = xDocument.Element(nameof(MyWork));

                if (!myWorkElement.Elements().ToList().Exists(e => e.Name.LocalName.Equals(View)))
                {
                    throw new InvalidOperationException(CannotFindViewElement);
                }

                var viewElement = myWorkElement.Element(View);

                foreach (var attribute in new[] { IdText, Name, Personal }.Where(
                    attribute => !viewElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals(attribute))))
                {
                    throw new InvalidOperationException($"{CannotFindAttribute}{attribute}");
                }

                var viewId = viewElement.Attribute(IdText).Value;
                var viewName = viewElement.Attribute(Name).Value;
                var isViewPersonal = Convert.ToBoolean(viewElement.Attribute(Personal).Value);

                if (isViewPersonal)
                {
                    RenamePersonalView(viewId, viewName, GetPersonalViews(configWeb), configWeb);
                }
                else
                {
                    RenameGlobalView(viewId, viewName, GetGlobalViews(configWeb), configWeb);
                }

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
                throw new APIException(2030, exception.Message);
            }
        }

        /// <summary>
        ///     Saves my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string SaveMyWorkGridView(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement(nameof(MyWork)));

                var xDocument = XDocument.Parse(data);
                var configWeb = Utils.GetConfigWeb();
                var myWorkGridView = GetMyWorkGridView(xDocument);
                var myWorkGridViews = GetPersonalViews(configWeb).ToList();

                myWorkGridViews.RemoveAll(v => v.Id.Equals(myWorkGridView.Id));

                if (myWorkGridView.Default)
                {
                    foreach (var gridView in myWorkGridViews)
                    {
                        gridView.Default = false;
                    }
                }

                if (myWorkGridView.Personal)
                {
                    myWorkGridViews.Add(myWorkGridView);
                }

                SavePersonalViews(myWorkGridViews, configWeb);

                if (myWorkGridView.HasPermission)
                {
                    SaveGlobalViews(myWorkGridView, configWeb);
                }

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
                throw new APIException(2090, exception.Message);
            }
        }
    }
}