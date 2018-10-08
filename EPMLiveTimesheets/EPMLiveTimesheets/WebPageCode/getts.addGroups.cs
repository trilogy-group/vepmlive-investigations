using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace TimeSheets
{
    public partial class getts
    {
        private void addGroups(SPWeb curWeb)
        {
            var arrGTemp = new SortedList();

            processList(curWeb, arrGTemp);

            var timeSpan = periodEnd - periodStart;

            foreach (DictionaryEntry entry in arrGTemp)
            {
                var newItem = entry.Key.ToString();
                var parentInd = newItem.LastIndexOf("\n");
                var parent = string.Empty;

                if (parentInd >= 0)
                {
                    parent = newItem.Substring(0, parentInd);
                    newItem = newItem.Substring(parentInd + 1);
                }

                if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(entry.Key.ToString())) ||
                    (parentInd == -1 && !hshItemNodes.Contains(entry.Key.ToString())))
                {
                    var parentNode = parentInd == -1
                        ? ndMainParent
                        : (XmlNode)hshItemNodes[parent];

                    var newNode = docXml.CreateNode(XmlNodeType.Element, Row, docXml.NamespaceURI);
                    AppendChilds(entry.Key.ToString(), newItem, parentNode, newNode);

                    for (var i = 0; i <= timeSpan.Days; i++)
                    {
                        var showDay = string.Empty;
                        try
                        {
                            showDay = dayDefs[(int)periodStart.AddDays(i).DayOfWeek * 3];
                        }
                        catch (Exception ex)
                        {
                            SystemTrace.WriteLine(ex.ToString());
                        }
                        if (showDay == True)
                        {
                            AppendChild(newNode, string.Empty);
                        }
                    }

                    hshItemNodes.Add(entry.Key.ToString(), newNode);
                }
            }

            while (queueAllItems.Count > 0)
            {
                var listItem = (SPListItem)queueAllItems.Dequeue();
                if (arrItems.Contains(listItem.ID.ToString()))
                {
                    ProcessListItem(curWeb, timeSpan, listItem);
                }
            }
        }

        protected void processList(SPWeb web, SortedList arrGTemp)
        {
            try
            {
                var query = new SPQuery
                {
                    Query = "<OrderBy><FieldRef Name = 'FirstName' Ascending = 'True'/><FieldRef Name = 'LastName' Ascending = 'True'/></OrderBy>"
                };
                var listItems = list.GetItems(query);
                if (listItems != null && listItems.Count > 0)
                {
                    foreach (SPListItem listItem in listItems)
                    {
                        string group = null;
                        if (arrGroupFields != null)
                        {
                            foreach (var groupby in arrGroupFields)
                            {
                                var field = list.Fields.GetFieldByInternalName(groupby);
                                var newgroup = field.GetFieldValueAsText(listItem[field.Id].ToString());

                                if (group == null)
                                {
                                    group = newgroup;
                                }
                                else
                                {
                                    group += "\n" + newgroup;
                                }

                                if (!arrGTemp.Contains(group))
                                {
                                    arrGTemp.Add(group, string.Empty);
                                }
                            }
                        }

                        arrItems.Add(listItem.ID.ToString(), group);
                        queueAllItems.Enqueue(listItem);
                    }
                }
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine(ex.ToString());
            }
        }

        private void AppendChilds(string entryKey, string newItem, XmlNode parentNode, XmlNode newNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException(nameof(parentNode));
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            var attrId = docXml.CreateAttribute(Id);

            attrId.Value = !string.IsNullOrWhiteSpace(entryKey) ? entryKey : Guid.NewGuid().ToString();

            newNode.Attributes.Append(attrId);

            AppendAttribute(newNode, "locked", One);

            AppendAttribute(newNode, Open, One);

            parentNode.AppendChild(newNode);

            AppendChild(newNode, TypeConst, Ro);
            AppendChild(newNode, TypeConst, Ro);

            var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            newCell.InnerText = string.IsNullOrWhiteSpace(newItem) ? "No Value" : newItem;
            newNode.AppendChild(newCell);

            AppendAttribute(newNode, Style, "font-weight:bold;background: #B6C8ED");
            AppendChild(newNode, string.Empty);
        }

        private void ProcessListItem(SPWeb curWeb, TimeSpan timeSpan, SPListItem listItem)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }

            var resName = listItem.Title;
            var realName = string.Empty;
            var loginName = string.Empty;
            try
            {
                var userValue = new SPFieldUserValue(curWeb, listItem["SharePointAccount"].ToString());
                loginName = userValue.User.LoginName;
                realName = userValue.User.Name;
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine(ex.ToString());
            }

            var dataRows = dsTimesheets.Tables[0].Select($"username like '{loginName}'");

            if (!string.IsNullOrWhiteSpace(loginName) && dataRows.Length > 0)
            {
                var groupName = string.Empty;
                if (arrItems[listItem.ID.ToString()] == null)
                {
                    groupName = loginName;
                }
                else
                {
                    groupName = arrItems[listItem.ID.ToString()] + "\n" + loginName;
                }

                var newItem = groupName;
                var parentInd = newItem.LastIndexOf("\n");
                var parent = string.Empty;

                if (parentInd >= 0)
                {
                    parent = newItem.Substring(0, parentInd);
                    newItem = newItem.Substring(parentInd + 1);
                }

                if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(groupName)) ||
                    (parentInd == -1 && !hshItemNodes.Contains(groupName)))
                {
                    ProcessNodes(
                        timeSpan,
                        listItem.ID.ToString(),
                        resName,
                        realName,
                        loginName,
                        dataRows,
                        groupName,
                        parentInd,
                        parent);
                }
            }
        }

        private void ProcessNodes(
            TimeSpan timeSpan,
            string listItemId,
            string resName,
            string realName,
            string loginName,
            DataRow[] dataRows,
            string groupName,
            int parentInd,
            string parent)
        {
            if (dataRows == null)
            {
                throw new ArgumentNullException(nameof(dataRows));
            }

            var parentNode = parentInd == -1
                ? ndMainParent
                : (XmlNode)hshItemNodes[parent];

            var newNode = docXml.CreateNode(XmlNodeType.Element, Row, docXml.NamespaceURI);

            AppendChilds(listItemId, resName, realName, dataRows, parentNode, newNode);

            for (var days = 0; days <= timeSpan.Days; days++)
            {
                var showDay = string.Empty;
                try
                {
                    showDay = dayDefs[(int)periodStart.AddDays(days).DayOfWeek * 3];
                }
                catch (Exception ex)
                {
                    SystemTrace.WriteLine(ex.ToString());
                }
                if (showDay == True)
                {
                    AppendChild(newNode, string.Empty);
                }
            }

            var drTasks = dsTimesheetTasks.Tables[0].Select("ts_uid = '" + dataRows[0][TsUid] + "'");
            var regex = new Regex("[^0-9a-zA-Z]+", RegexOptions.Compiled);
            foreach (var drTask in drTasks)
            {
                ProcessTask(timeSpan, listItemId, newNode, regex, drTask);
            }

            if (!hshItemNodes.Contains(groupName))
            {
                hshItemNodes.Add(groupName, newNode);
            }

            if (!hshResNodes.Contains(loginName))
            {
                hshResNodes.Add(loginName, newNode);
            }
        }
    }
}
