using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public class ColumnDefCollection : List<ColumnDef>
    {
        public ColumnDefCollection()
        {
        }

        public ColumnDefCollection(int capacity)
            : base(capacity)
        {
        }

        public ColumnDefCollection(IEnumerable<ColumnDef> collection)
            : base(collection)
        {
        }

        public ColumnDefCollection(DataColumnCollection columns)
        {
            foreach (DataColumn column in columns)
            {
                Add(new ColumnDef(column));
            }
        }

        public void AddColumn(SPField field)
        {
            //Add(new ColumnDef(field));
            ColumnDef.AddColumn(this, field);
        }
        public void AddColumn(DataColumn column)
        {
            Add(new ColumnDef(column));
        }
        public ColumnDefCollection DiffColumns(List<ColumnDef> newSet)
        {
            return DiffColumns(this, newSet);
        }

        public string GetSqlColumnDefs()
        {
            var columns = new List<string>();
            foreach (var columnDef in this)
            {
                columns.Add(columnDef.ToString());
            }
            return string.Join(", ", columns.ToArray());
        }

        public string GetSqlCreateTable(string tableName)
        {
            return string.Format("create table [{0}]({1}) on [primary]", tableName, GetSqlColumnDefs());
        }

        public override string ToString()
        {
            if (Count == 0)
                return "None";
            var s = "";
            ForEach(cd => s += string.Format("[{0}] ", cd.DisplayName));
            return s;
        }

        /* Static Methods */

        public static ColumnDefCollection DiffColumns(List<ColumnDef> existingSet, List<ColumnDef> newSet)
        {
            var diff = new ColumnDefCollection();
            foreach (ColumnDef columnDef in newSet)
            {
                ColumnDef def = columnDef;
                if (existingSet.Find(c => c.InternalName == def.InternalName) == null)
                    diff.Add(columnDef);
            }
            return diff;
        }

    }

    public class ColumnDef
    {
        private readonly string _displayName;
        private readonly string _internalName;
        private readonly string _sqlColumnName;
        private readonly int _sqlColumnSize;
        private readonly SqlDbType _sqlColumnType;
        private readonly bool _isLookup;

        public ColumnDef(SPField spField)
        {
            _sqlColumnName = spField.InternalName;

            if (spField.Type.ToString().ToLower() != "invalid")
            {
                ColumnType = spField.Type;
            }
            else
            {
                ColumnType = GetInvalidFieldType(spField);
            }
            _internalName = spField.InternalName;
            _displayName = spField.Title;
            SqlParameter p = GetParameterFromSPField(spField);
            _sqlColumnType = p.SqlDbType;
            _sqlColumnSize = p.Size;
            _isLookup = false;
            if (spField is SPFieldLookup)
            {
                _isLookup = true;
            }
            
        }

        private SPFieldType GetInvalidFieldType(SPField field)
        {
            string sType = field.TypeAsString.ToLower();
            SPFieldType type = SPFieldType.Invalid;
            switch (sType)
            {
                case "filteredlookup":
                    type = SPFieldType.Lookup;
                    break;

                case "totalrollup":
                    type = SPFieldType.Integer;
                    break;

                case "resourcepermissions":
                    type = SPFieldType.Note;
                    break;

                default:
                    type = SPFieldType.Text;
                    break;
            }
            return type;
        }

        public ColumnDef(string sqlColumnName, string internalName, string displayName, SPFieldType spFieldType, SqlDbType sqlDbType)
            : this(sqlColumnName, internalName, displayName, spFieldType, sqlDbType, 0)
        {
        }

        public ColumnDef(string sqlColumnName, string internalName, string displayName, SPFieldType spFieldType, SqlDbType sqlDbType, int size)
        {
            _sqlColumnName = sqlColumnName;
            ColumnType = spFieldType;
            _internalName = internalName;
            _displayName = displayName;
            _sqlColumnType = sqlDbType;
            _sqlColumnSize = size;
        }

        public ColumnDef(DataRow row)
        {
            _sqlColumnName = row["ColumnName"].ToString();
            _internalName = row["InternalName"].ToString();
            _displayName = row["DisplayName"].ToString();
            _sqlColumnSize = (int)row["ColumnSize"];
        }

        public ColumnDef(DataColumn column)
        {
            _sqlColumnName = column.ColumnName;
            _sqlColumnType = ConvertDbTypeToSqlDbType(column.DataType);            
            _sqlColumnSize = column.MaxLength;          
            _internalName = _sqlColumnName;
            _displayName = _sqlColumnName;
        }

        public string SqlColumnName
        {
            get { return _sqlColumnName; }
        }

        public SPFieldType ColumnType { get; set; }

        public string InternalName
        {
            get { return _internalName; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public SqlDbType SqlColumnType
        {
            get { return _sqlColumnType; }
        }

        public int SqlColumnSize
        {
            get { return _sqlColumnSize; }
        }

        public bool IsLookup
        {
            get { return _isLookup; }
        }

        /// <summary>
        /// Get Sql column definition in the form [NAME] [TYPE] (SIZE) NULL
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string colSize = _sqlColumnSize.ToString();
            if (_sqlColumnSize > 8000)
            {
                colSize = "MAX";
            }

            if (_sqlColumnName.ToLower() != "webid" && _sqlColumnName.ToLower() != "itemid" && _sqlColumnName.ToLower() != "periodid" && _sqlColumnName.ToLower() != "rpttsduid")
            {


                return


                    string.Format("[{0}] [{1}]{2} NULL",
                                     _sqlColumnName,
                                     _sqlColumnType,
                                     _sqlColumnSize > 0 ? string.Format("({0})", colSize) : "");
            }
            else
            {
                return


                   string.Format("[{0}] [{1}]{2} NOT NULL",
                                    _sqlColumnName,
                                    _sqlColumnType,
                                    _sqlColumnSize > 0 ? string.Format("({0})", colSize) : "");

            }
        }

        /* Static Methods */

        public static string GetString(ColumnDef columnDef)
        {
            return string.Format("[{0}] ", columnDef.InternalName);
        }

        public static ColumnDefCollection GetDefaultColumns()
        {
            var columns = new ColumnDefCollection
                              {
                                  new ColumnDef("SiteId", "SiteId", "SiteId", SPFieldType.Guid, SqlDbType.UniqueIdentifier),
                                  new ColumnDef("WebId", "WebId", "WebId", SPFieldType.Guid, SqlDbType.UniqueIdentifier),
                                  new ColumnDef("ListId", "ListId", "ListId", SPFieldType.Guid, SqlDbType.UniqueIdentifier),
                                  new ColumnDef("ItemId", "ItemId", "ItemId", SPFieldType.Integer, SqlDbType.Int),
                                  new ColumnDef("WebUrl", "WebUrl", "WebUrl", SPFieldType.Text, SqlDbType.VarChar, 256),
                                  new ColumnDef("Commenters", "Commenters", "Commenters", SPFieldType.Note, SqlDbType.NVarChar, 8001),
                                  new ColumnDef("CommentersRead", "CommentersRead", "CommentersRead", SPFieldType.Note, SqlDbType.NVarChar, 8001),
                                  new ColumnDef("CommentCount", "CommentCount", "CommentCount", SPFieldType.Number, SqlDbType.Int),
                                  new ColumnDef("WorkspaceUrl", "WorkspaceUrl", "WorkspaceUrl", SPFieldType.Text, SqlDbType.NVarChar, 8001)
                              };
            return columns;
        }

        public static ColumnDefCollection GetDefaultColumnsSnapshot()
        {
            var columns = new ColumnDefCollection(GetDefaultColumns());
            columns.Insert(0, new ColumnDef("PeriodId", "PeriodId", "PeriodId", SPFieldType.Guid, SqlDbType.UniqueIdentifier));
            return columns;
        }

        public static void AddColumn(ColumnDefCollection columns, SPField field)
        {
            if ((from c in columns
                where c.InternalName.Equals(field.InternalName, StringComparison.CurrentCultureIgnoreCase)
                select c).Any())
            {
                return;
            }

            SqlParameter p = GetParameterFromSPField(field);
            string sType = field.TypeAsString.ToLower();
            switch (field.Type)
            {
                case SPFieldType.Lookup:
                case SPFieldType.MultiChoice:
                case SPFieldType.User:
                    if (sType != "lookupmulti" && sType != "usermulti" && sType != "multichoice")
                    {
                        columns.Add(new ColumnDef(field.InternalName + "ID", field.InternalName, field.Title, field.Type, SqlDbType.Int));
                    }
                    else
                    {
                        columns.Add(new ColumnDef(field.InternalName + "ID", field.InternalName, field.Title, field.Type, p.SqlDbType, p.Size));
                    }
                    columns.Add(new ColumnDef(field.InternalName + "Text", field.InternalName, field.Title, field.Type, SqlDbType.NVarChar, 8001));
                    //columns.Add(new ColumnDef(field.InternalName + "Text", field.InternalName, field.Title, field.Type, SqlDbType.NText));
                    break;

                case SPFieldType.Invalid:
                    switch (sType)
                    {
                        case "filteredlookup":
                            columns.Add(new ColumnDef(field.InternalName + "ID", field.InternalName, field.Title, SPFieldType.Lookup, SqlDbType.Int));
                            columns.Add(new ColumnDef(field.InternalName + "Text", field.InternalName, field.Title, SPFieldType.Lookup, SqlDbType.NVarChar, 256));
                            break;

                        default:
                            columns.Add(new ColumnDef(field));
                            break;
                    }
                    break;

                default:
                    columns.Add(new ColumnDef(field));
                    break;
            }
        }

        public static void AddColumn(ColumnDefCollection columns, DataColumn column)
        {
            columns.Add(new ColumnDef(column));
        }

        private static Hashtable _dbTypeTable;

        public static SqlDbType ConvertDbTypeToSqlDbType(Type dbType)
        {
            if (_dbTypeTable == null)
            {
                _dbTypeTable = new Hashtable
                                   {
                                       {typeof (Boolean), SqlDbType.Bit},
                                       {typeof (Int16), SqlDbType.SmallInt},
                                       {typeof (Int32), SqlDbType.Int},
                                       {typeof (Int64), SqlDbType.BigInt},
                                       {typeof (Double), SqlDbType.Float},
                                       {typeof (Decimal), SqlDbType.Decimal},
                                       {typeof (String), SqlDbType.VarChar},
                                       {typeof (DateTime), SqlDbType.DateTime},
                                       {typeof (Byte[]), SqlDbType.VarBinary},
                                       {typeof (Guid), SqlDbType.UniqueIdentifier}
                                   };
            }
            SqlDbType dbtype;
            try
            {
                dbtype = (SqlDbType)_dbTypeTable[dbType];
            }
            catch
            {
                dbtype = SqlDbType.Variant;
            }
            return dbtype;
        }

        public static SqlParameter GetParameterFromSPField(SPField field)
        {
            SqlParameter param = new SqlParameter();
            SPFieldType type = field.Type;
            string sType = field.TypeAsString.ToLower();

            switch (type)
            {
                case SPFieldType.Integer:
                    param.SqlDbType = SqlDbType.Float;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Lookup:
                    if (field.Title.ToLower().EndsWith("id") && sType != "lookupmulti")
                    {
                        param.SqlDbType = SqlDbType.Int;
                    }
                    else
                    {
                        param.SqlDbType = SqlDbType.NText;
                    }

                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.User:
                    if (field.Title.ToLower().EndsWith("id") && sType != "usermulti")
                    {
                        param.SqlDbType = SqlDbType.Int;
                    }
                    else
                    {
                        param.SqlDbType = SqlDbType.NVarChar;
                        param.Size = 8001;
                        //param.SqlDbType = SqlDbType.NText;                        
                    }

                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Text:
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Note:
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    //param.SqlDbType = SqlDbType.NText;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.MultiChoice:
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Number:
                    param.SqlDbType = SqlDbType.Float;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Currency:
                    param.SqlDbType = SqlDbType.Float;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Boolean:
                    param.SqlDbType = SqlDbType.Bit;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.DateTime:
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Invalid:
                    switch (sType)
                    {
                        case "filteredlookup":
                            if (field.Title.ToLower().EndsWith("id") && sType != "lookupmulti")
                            {
                                param.SqlDbType = SqlDbType.Int;
                            }
                            else
                            {
                                param.SqlDbType = SqlDbType.NVarChar;
                                param.Size = 8001;
                                //param.SqlDbType = SqlDbType.NText;
                            }

                            param.Direction = ParameterDirection.Input;
                            break;

                        case "totalrollup":
                            param.SqlDbType = SqlDbType.Float;
                            break;

                        case "resourcepermissions":
                            param.SqlDbType = SqlDbType.NVarChar;
                            param.Size = 8001;
                            break;

                        default:
                            param.SqlDbType = SqlDbType.NVarChar;
                            param.Size = 256;
                            break;
                    }
                    break;

                case SPFieldType.Calculated:
                    string sResultType = field.GetProperty("ResultType").ToLower();
                    switch (sResultType)
                    {
                        case "currency":
                            param.SqlDbType = SqlDbType.Float;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "number":
                            param.SqlDbType = SqlDbType.Float;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "datetime":
                            param.SqlDbType = SqlDbType.DateTime;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "boolean":
                            param.SqlDbType = SqlDbType.Bit;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "text":
                            param.SqlDbType = SqlDbType.NVarChar;
                            param.Size = 256;
                            break;
                    }
                    break;

                case SPFieldType.Guid:
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Counter:
                    param.SqlDbType = SqlDbType.Int;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.URL:
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    break;

                default:
                    switch (sType)
                    {
                        case "totalrollup":
                            param.SqlDbType = SqlDbType.Float;
                            break;

                        default:
                            param.SqlDbType = SqlDbType.NVarChar;
                            param.Size = 256;
                            break;
                    }
                    break;
            }
            return param;
        }
    }

    public class Utility
    {
        public static string GetCleanAlphaNumeric(string input)
        {
            var regex = new Regex(@"[^\w+]");
            return regex.Replace(input, "");
        }
    }
}