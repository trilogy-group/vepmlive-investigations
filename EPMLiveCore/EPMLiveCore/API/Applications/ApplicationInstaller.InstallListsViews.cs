using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private const string Fields = "Fields";
        private const string Query = "Query";
        private const string Joins = "Joins";
        private const string RowLimit = "RowLimit";
        private const string ProjectedFields = "ProjectedFields";
        private const string MakeDefault = "MakeDefault";
        private const char SeparatorComma = ',';

        private void InstallListsViews(SPList list, XmlNode nodeList, int parentMessageId)
        {
            var nodeViews = nodeList.SelectSingleNode("Views");

            if (nodeViews != null)
            {
                parentMessageId = addMessage(0, bVerifyOnly ? "Checking Views" : "Updating Views", string.Empty, parentMessageId);

                foreach (XmlNode nodeView in nodeViews.SelectNodes("View"))
                {
                    var name = getAttribute(nodeView, "Name");

                    bool overWrite;
                    bool.TryParse(getAttribute(nodeView, "Overwrite"), out overWrite);

                    SPView view = null;
                    try
                    {
                        view = list.Views[name];
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }

                    if (bVerifyOnly)
                    {
                        AddMessage(parentMessageId, name, overWrite, view);
                    }
                    else
                    {
                        InstallListsViews(list, parentMessageId, nodeView, name, overWrite, view);
                    }
                }
            }
        }

        private void InstallListsViews(SPList list, int parentMessageId, XmlNode nodeView, string name, bool overWrite, SPView view)
        {
            if (list != null)
            {
                if (view == null)
                {
                    try
                    {
                        InstallListsViews(list, parentMessageId, nodeView, name);
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, name, "Error adding view: " + ex.Message, parentMessageId);
                        Trace.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    if (overWrite)
                    {
                        try
                        {
                            InstallListsViews(list, parentMessageId, nodeView, name, view);
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, name, "Error updating view: " + ex.Message, parentMessageId);
                            Trace.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        addMessage(ErrorLevels.Warning, name, "View exists but can't overwrite", parentMessageId);
                    }
                }
            }
        }

        private void AddMessage(int parentMessageId, string name, bool overWrite, SPView view)
        {
            if (view == null)
            {
                addMessage(0, name, string.Empty, parentMessageId);
            }
            else
            {
                if (overWrite)
                {
                    addMessage(ErrorLevels.Upgrade, name, "View exists and will overwrite", parentMessageId);
                }
                else
                {
                    addMessage(ErrorLevels.Warning, name, "View exists but can't overwrite", parentMessageId);
                }
            }
        }

        private void InstallListsViews(SPList list, int parentMessageId, XmlNode nodeView, string name)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (nodeView == null)
            {
                throw new ArgumentNullException(nameof(nodeView));
            }
            var fields = new StringCollection();
            fields.AddRange(nodeView.SelectSingleNode(Fields).InnerText.Split(SeparatorComma));
            var query = getChildNodeText(nodeView, Query);
            var projectedFields = getChildNodeText(nodeView, ProjectedFields);
            var joins = getChildNodeText(nodeView, Joins);

            uint rowLimit;
            uint.TryParse(getAttribute(nodeView, RowLimit), out rowLimit);

            bool isDefault;
            bool.TryParse(getAttribute(nodeView, MakeDefault), out isDefault);

            list.Views.Add(name, fields, query, joins, projectedFields, rowLimit, false, isDefault, SPViewCollection.SPViewType.Html, false);

            addMessage(0, name, string.Empty, parentMessageId);            
        }

        private void InstallListsViews(SPList list, int parentMessageId, XmlNode nodeView, string name, SPView view)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (nodeView == null)
            {
                throw new ArgumentNullException(nameof(nodeView));
            }
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }
            var fields = nodeView.SelectSingleNode(Fields).InnerText.Split(SeparatorComma);
            var query = getChildNodeText(nodeView, Query);
            var projectedFields = getChildNodeText(nodeView, ProjectedFields);
            var joins = getChildNodeText(nodeView, Joins);

            uint iRowLimit = 0;
            uint.TryParse(getAttribute(nodeView, RowLimit), out iRowLimit);

            var bDefault = false;
            bool.TryParse(getAttribute(nodeView, MakeDefault), out bDefault);

            view.ViewFields.DeleteAll();

            foreach (var sField in fields)
            {
                SPField oField = null;
                try
                {
                    oField = list.Fields.GetFieldByInternalName(sField);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                if (oField != null)
                {
                    view.ViewFields.Add(oField);
                }
            }

            view.Query = query;
            view.ProjectedFields = projectedFields;
            view.Joins = joins;
            view.RowLimit = iRowLimit;
            view.DefaultView = bDefault;
            view.Update();

            addMessage(ErrorLevels.Upgrade, name, "View exists and will overwrite", parentMessageId);
        }
    }
}