using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        private static void AddTables(SPWeb spWeb, DataTable myWorkDataTable, DataTable fieldsTable, DataTable flagsTable, IList<DataTable> tables)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(myWorkDataTable, nameof(myWorkDataTable));
            Guard.ArgumentIsNotNull(fieldsTable, nameof(fieldsTable));
            Guard.ArgumentIsNotNull(flagsTable, nameof(flagsTable));
            Guard.ArgumentIsNotNull(tables, nameof(tables));

            EnumerableRowCollection<DataRow> fieldsTableRows;
            List<string> myWorkFields;
            IDictionary<string, int> colDict;
            Dictionary<string, List<string>> workingOnDict;

            var myWorkDtRows = MyWorkDtRows(
                spWeb,
                myWorkDataTable,
                fieldsTable,
                out fieldsTableRows,
                out myWorkFields,
                out colDict,
                out workingOnDict);

            foreach (var selectedList in GetMyWorkParams.SelectedLists)
            {
                var dataTable = new DataTable();

                foreach (var field in myWorkFields)
                {
                    dataTable.Columns.Add(field, typeof(object));
                }

                if (!dataTable.Columns.Contains(WorkingOnField))
                {
                    dataTable.Columns.Add(WorkingOnField, typeof(object));
                }

                AddRowToDataTable(selectedList, myWorkDtRows, dataTable, myWorkFields, colDict, fieldsTableRows, flagsTable, workingOnDict);
                tables.Add(dataTable);
            }
        }

        private static EnumerableRowCollection<DataRow> MyWorkDtRows(
            SPWeb spWeb,
            DataTable myWorkDataTable,
            DataTable fieldsTable,
            out EnumerableRowCollection<DataRow> fieldsTableRows,
            out List<string> myWorkFields,
            out IDictionary<string, int> colDict,
            out Dictionary<string, List<string>> workingOnDict)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(myWorkDataTable, nameof(myWorkDataTable));
            Guard.ArgumentIsNotNull(fieldsTable, nameof(fieldsTable));

            var myWorkDtRows = myWorkDataTable.AsEnumerable();
            fieldsTableRows = fieldsTable.AsEnumerable();
            myWorkFields = (from r in fieldsTableRows
                    select r[InternalName].ToString()).Distinct()
               .ToList();

            var list = myWorkFields;

            myWorkFields.AddRange(GetMyWorkParams.SelectedFields.Where(item => !list.Contains(item)));

            colDict = GenerateColDictionary(myWorkDataTable, myWorkFields);
            workingOnDict = new Dictionary<string, List<string>>();

            foreach (DataRow dataRow in GetWorkingOn(spWeb).Rows)
            {
                var key = dataRow[ListId].ToString().ToUpper();
                key = key.Replace(OpenCurlyBrace, string.Empty);
                key = key.Replace(ClosedCurlyBrace, string.Empty);

                if (!workingOnDict.ContainsKey(key))
                {
                    workingOnDict.Add(key, new List<string>());
                }

                workingOnDict[key].Add(dataRow[ItemId].ToString());
            }

            return myWorkDtRows;
        }

        private static void AddRowToDataTable(
            string selectedList,
            EnumerableRowCollection<DataRow> myWorkDtRows,
            DataTable dataTable,
            IList<string> myWorkFields,
            IDictionary<string, int> colDict,
            EnumerableRowCollection<DataRow> fieldsTableRows,
            DataTable flagsTable,
            IDictionary<string, List<string>> workingOnDict)
        {
            Guard.ArgumentIsNotNull(myWorkDtRows, nameof(myWorkDtRows));
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            Guard.ArgumentIsNotNull(myWorkFields, nameof(myWorkFields));
            Guard.ArgumentIsNotNull(colDict, nameof(colDict));
            Guard.ArgumentIsNotNull(fieldsTableRows, nameof(fieldsTableRows));
            Guard.ArgumentIsNotNull(flagsTable, nameof(flagsTable));
            Guard.ArgumentIsNotNull(workingOnDict, nameof(workingOnDict));

            var list = selectedList;
            var dataRows = from dataRow in myWorkDtRows
                where dataRow.Field<string>(WorkType).Equals(list)
                select dataRow;

            foreach (var dataRow in dataRows)
            {
                var row = dataTable.NewRow();

                foreach (var selectedField in myWorkFields)
                {
                    row[selectedField] = GetMyWorkFieldValue(
                        selectedField,
                        dataRow,
                        colDict,
                        fieldsTableRows,
                        flagsTable);
                }

                var workingOn = false;
                var key = dataRow[ListId].ToString().ToUpper();
                key = key.Replace(OpenCurlyBrace, string.Empty);
                key = key.Replace(ClosedCurlyBrace, string.Empty);

                if (workingOnDict.ContainsKey(key))
                {
                    if (workingOnDict[key].Contains(dataRow[ItemId].ToString()))
                    {
                        workingOn = true;
                    }
                }

                row[WorkingOnField] = workingOn;
                dataTable.Rows.Add(row);
            }
        }
    }
}