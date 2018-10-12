using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        private static readonly Dictionary<SPFieldType, SqlDbType> DbTypeMapping = new Dictionary<SPFieldType, SqlDbType>
        {
            [SPFieldType.Integer] = SqlDbType.Float,
            [SPFieldType.Text] = SqlDbType.NVarChar,
            [SPFieldType.Note] = SqlDbType.NText,
            [SPFieldType.Number] = SqlDbType.Float,
            [SPFieldType.Currency] = SqlDbType.Float,
            [SPFieldType.Boolean] = SqlDbType.Bit,
            [SPFieldType.DateTime] = SqlDbType.DateTime,
            [SPFieldType.Guid] = SqlDbType.UniqueIdentifier,
            [SPFieldType.Counter] = SqlDbType.Int,
            [SPFieldType.URL] = SqlDbType.NVarChar
        };

        private static readonly SPFieldType[] InputDirectionSpFields =
        {
            SPFieldType.Integer,
            SPFieldType.Lookup,
            SPFieldType.User,
            SPFieldType.Text,
            SPFieldType.Note,
            SPFieldType.MultiChoice,
            SPFieldType.Number,
            SPFieldType.Currency,
            SPFieldType.Boolean,
            SPFieldType.DateTime,
            SPFieldType.Guid,
            SPFieldType.Counter,
            SPFieldType.URL
        };

        public static SqlParameter GetParam(SPField field, string sColumnName)
        {
            var param = new SqlParameter();
            var fieldType = field.Type;
            var typeString = field.TypeAsString.ToLower();

            if (DbTypeMapping.ContainsKey(fieldType))
            {
                param.SqlDbType = DbTypeMapping[fieldType];
            }

            if (InputDirectionSpFields.Contains(fieldType))
            {
                param.Direction = ParameterDirection.Input;
            }

            if (fieldType == SPFieldType.Lookup)
            {
                SetParamLookUpOrUserOrMultiChoice(sColumnName, typeString, param, LookupMulti, Size8001);
            }
            else if (fieldType == SPFieldType.User)
            {
                SetParamLookUpOrUserOrMultiChoice(sColumnName, typeString, param, UserMulti, DefaultSize);
            }
            else if (fieldType == SPFieldType.MultiChoice)
            {
                SetParamLookUpOrUserOrMultiChoice(sColumnName, typeString, param, string.Empty, Size8001);
            }
            else if (fieldType == SPFieldType.Calculated)
            {
                GetParamCalculated(field, param);
            }
            else if (fieldType == SPFieldType.Text || fieldType == SPFieldType.URL || typeString != TotalRollup)
            {
                param.Size = Size256;
            }
            else if (!DbTypeMapping.ContainsKey(fieldType))
            {
                param.SqlDbType = typeString == TotalRollup
                    ? SqlDbType.Float
                    : SqlDbType.NVarChar;
            }

            return param;
        }

        private static void GetParamCalculated(SPField field, SqlParameter param)
        {
            var resultType = field.GetProperty(ResultType);

            if (resultType.Equals(Currency, StringComparison.OrdinalIgnoreCase) ||
                resultType.Equals(Number, StringComparison.OrdinalIgnoreCase))
            {
                param.SqlDbType = SqlDbType.Float;
                param.Direction = ParameterDirection.Input;
            }

            if (resultType.Equals(DateTimeText, StringComparison.OrdinalIgnoreCase))
            {
                param.SqlDbType = SqlDbType.DateTime;
                param.Direction = ParameterDirection.Input;
            }

            if (resultType.Equals(BooleanText, StringComparison.OrdinalIgnoreCase))
            {
                param.SqlDbType = SqlDbType.Bit;
                param.Direction = ParameterDirection.Input;
            }

            if (resultType.Equals(TextId, StringComparison.OrdinalIgnoreCase))
            {
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = Size256;
            }
        }

        private static void SetParamLookUpOrUserOrMultiChoice(string columnName, string typeString, SqlParameter sqlParam, string typeExclude, int size)
        {
            if (columnName.ToLower().EndsWith(IdText) && typeString != typeExclude)
            {
                sqlParam.SqlDbType = SqlDbType.Int;
            }
            else
            {
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = size;
            }
        }
    }
}