using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Xml;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public partial class GetTsApprovals
    {
        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {
            if (arrGTemp == null)
            {
                throw new ArgumentNullException(nameof(arrGTemp));
            }
            if (curWeb == null)
            {
                throw new ArgumentNullException(nameof(curWeb));
            }
            if (resWeb == null)
            {
                return;
            }

            var spquery = new SPQuery
            {
                Query = "<Where><Eq><FieldRef Name='TimesheetManager'/><Value Type='User'><UserID/></Value></Eq></Where>"
            };

            var dtItems = new DataTable();
            dtItems.Columns.Add("WebId");
            dtItems.Columns.Add("ListId");
            dtItems.Columns.Add("ItemId");
            dtItems.Columns.Add("Username");
            dtItems.Columns.Add("Name");

            var resources = resWeb.Lists["Resources"];

            foreach (SPListItem listItem in resources.GetItems(spquery))
            {
                if (listItem["SharePointAccount"] != null)
                {
                    FillItems(arrGTemp, curWeb, dtItems, listItem);
                }
            }

            foreach (var dataRow in dtItems.Select(string.Empty, "WebId, ListId"))
            {
                try
                {
                    AddListItem(arrGTemp, dataRow);
                }
                catch (Exception ex)
                {
                    // here we catch more than few exceptions
                    // listing all of them might kill simplicty
                    Debug.WriteLine(ex);
                }
            }
        }

        private void FillItems(IDictionary arrGTemp, SPWeb curWeb, DataTable dtItems, SPListItem listItem)
        {
            if (arrGTemp == null)
            {
                throw new ArgumentNullException(nameof(arrGTemp));
            }
            if (dtItems == null)
            {
                throw new ArgumentNullException(nameof(dtItems));
            }
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }
            var userValue = new SPFieldUserValue(curWeb, listItem["SharePointAccount"].ToString());
            if (userValue.User == null)
            {
                return;
            }

            var dataRowsTimeSheetTask = dsTimesheetTasks.Tables[0].Select($"username = '{userValue.User.LoginName}'");

            var dataRowsTimeSheet = dsTimesheets.Tables[0].Select($"username = '{userValue.User.LoginName} '");

            if (!arrGTemp.Contains(listItem.Title))
            {
                arrGTemp.Add(listItem.Title, string.Empty);
            }

            var newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
            var attrId = docXml.CreateAttribute("id");
            attrId.InnerText = listItem.Title;
            newNode.Attributes.Append(attrId);

            var status = string.Empty;
            var notes = string.Empty;

            if (dataRowsTimeSheet.Length > 0)
            {
                AddColumn(newNode, dataRowsTimeSheet[0][TsUid].ToString(), "tsuid");
                string locked;
                GetValues(dataRowsTimeSheet, out status, out locked);
                AddColumn(newNode, locked, "nosub");
                notes = dataRowsTimeSheet[0][ApprovalNotes].ToString();
            }
            else
            {
                AddColumn(newNode, string.Empty, "tsuid");
                AddColumn(newNode, "1", "nosub");
            }

            AddCells(listItem, newNode, status, notes);

            ndMainParent.AppendChild(newNode);

            hshItemNodes.Add(listItem.Title, newNode);

            foreach (var dataRow in dataRowsTimeSheetTask)
            {
                var array = new string[] {
                    dataRow[WebUid].ToString(),
                    dataRow[ListUid].ToString(),
                    dataRow[ItemId].ToString(),
                    dataRow[UserName].ToString(),
                    listItem.Title };

                dtItems.Rows.Add(array);
            }
        }

        private void AddCells(SPListItem listItem, XmlNode newNode, string status, string notes)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }
            AddCell(newNode, string.Empty);
            AddCell(newNode, notes);

            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerXml = status;
            var attrStyle = docXml.CreateAttribute("style");
            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
            newCell.Attributes.Append(attrStyle);
            newNode.AppendChild(newCell);

            AddCell(newNode, string.Empty);

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = listItem.Title;
            attrStyle = docXml.CreateAttribute("style");
            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
            newNode.Attributes.Append(attrStyle);
            newNode.AppendChild(newCell);
        }
    }
}