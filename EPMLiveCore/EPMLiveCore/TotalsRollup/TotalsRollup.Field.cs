using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;

using System.Collections.Generic;
using System.Text;

using System.IO;

namespace EPMLiveCore
{
    [Guid("907642a2-01e4-4a56-b2ce-a3c941633083")]
    public class TotalsRollupField : SPFieldText
    {
        public TotalsRollupField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
            Init();
        }
        
        public TotalsRollupField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
            Init();
        }
        private void Init()
        {
            ListName = GetCustomProperty("ListName") + "";
            ListQuery = GetCustomProperty("ListQuery") + "";
            AggType = GetCustomProperty("AggType") + "";
            AggColumn = GetCustomProperty("AggColumn") + "";
            LookupColumn = GetCustomProperty("LookupColumn") + "";
            Decimals = GetCustomProperty("Decimals") + "";
            OutputType = GetCustomProperty("OutputType") + "";
            if(SPContext.Current == null)
            {
                contextId = Guid.NewGuid().GetHashCode();
            }
        }

        public override object GetFieldValue(string value)
        {
            return value;
        }

        private static Dictionary<int, string> updatedListName = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedListQuery = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedAggType = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedAggColumn = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedLookupColumn = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedDecimals = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedOutputType = new Dictionary<int, string>();

        private string listName;
        private string listQuery;
        private string aggColumn;
        private string aggType;
        private string lookupColumn;
        private string decimals;
        private string outputType;

        public string ListName
        {

            get
            {
                return updatedListName.ContainsKey(ContextId) ? updatedListName[ContextId] : listName;
            }
            set
            {
                this.listName = value;
            }

        }

        public string ListQuery
        {

            get
            {
                return updatedListQuery.ContainsKey(ContextId) ? updatedListQuery[ContextId] : listQuery;
            }
            set
            {
                this.listQuery = value;
            }

        }

        public string AggType
        {

            get
            {
                return updatedAggType.ContainsKey(ContextId) ? updatedAggType[ContextId] : aggType;
            }
            set
            {
                this.aggType = value;
            }

        }

        public string AggColumn
        {

            get
            {
                return updatedAggColumn.ContainsKey(ContextId) ? updatedAggColumn[ContextId] : aggColumn;
            }
            set
            {
                this.aggColumn = value;
            }

        }
        public string LookupColumn
        {
            get
            {
                return updatedLookupColumn.ContainsKey(ContextId) ? updatedLookupColumn[ContextId] : lookupColumn;
            }
            set
            {
                this.lookupColumn = value;
            }
            
        }

        public string Decimals
        {
            get
            {
                return updatedDecimals.ContainsKey(ContextId) ? updatedDecimals[ContextId] : decimals;
            }
            set
            {
                this.decimals = value;
            }

        }

        public string OutputType
        {
            get
            {
                return updatedOutputType.ContainsKey(ContextId) ? updatedOutputType[ContextId] : outputType;
            }
            set
            {
                this.outputType = value;
            }

        }

        public void UpdateListName(string value)
        {
            updatedListName[ContextId] = value;
        }

        public void UpdateListQuery(string value)
        {
            updatedListQuery[ContextId] = value;
        }

        public void UpdateAggType(string value)
        {
            updatedAggType[ContextId] = value;
        }

        public void UpdateAggColumn(string value)
        {
            updatedAggColumn[ContextId] = value;
        }

        public void UpdateLookupColumn(string value)
        {
            updatedLookupColumn[ContextId] = value;
        }
        public void UpdateDecimals(string value)
        {
            updatedDecimals[ContextId] = value;
        }
        public void UpdateOutputType(string value)
        {
            updatedOutputType[ContextId] = value;
        }
        private int contextId;
        public int ContextId
        {
            get
            {
                if(SPContext.Current == null)
                    return contextId;

                return SPContext.Current.GetHashCode();
            }
            set
            {
                contextId = value;
            }
        }

        public override void Update()
        {

            this.SetCustomProperty("ListName", this.ListName);
            this.SetCustomProperty("ListQuery", this.ListQuery);
            this.SetCustomProperty("AggType", this.AggType);
            this.SetCustomProperty("AggColumn", this.AggColumn);
            this.SetCustomProperty("LookupColumn", this.LookupColumn);
            this.SetCustomProperty("Decimals", this.Decimals);
            this.SetCustomProperty("OutputType", this.OutputType);

            base.Update();

            if (updatedListName.ContainsKey(ContextId))
                updatedListName.Remove(ContextId);

            if (updatedListQuery.ContainsKey(ContextId))
                updatedListQuery.Remove(ContextId);

            if (updatedAggType.ContainsKey(ContextId))
                updatedAggType.Remove(ContextId);

            if (updatedAggColumn.ContainsKey(ContextId))
                updatedAggColumn.Remove(ContextId);

            if (updatedLookupColumn.ContainsKey(ContextId))
                updatedLookupColumn.Remove(ContextId);

            if (updatedDecimals.ContainsKey(ContextId))
                updatedDecimals.Remove(ContextId);

            if (updatedOutputType.ContainsKey(ContextId))
                updatedOutputType.Remove(ContextId);
        }

        public override string GetFieldValueAsText(object value)
        {
            if (value == null)
                return null;


            System.Globalization.NumberFormatInfo providerEn = new System.Globalization.NumberFormatInfo();
            providerEn.NumberDecimalSeparator = ".";
            providerEn.NumberGroupSeparator = ",";
            providerEn.NumberGroupSizes = new int[] { 3 };


            try
            {
                if (OutputType == "percent")
                {
                    if (Decimals == "")
                    {
                        return (double.Parse(value.ToString(), providerEn) * 100).ToString() + "%";
                    }
                    else
                    {
                        string format = "";
                        for (int j = 0; j < int.Parse(Decimals); j++)
                        {
                            format += "0";
                        }
                        if (format.Length > 0)
                            format = "#,##0." + format;
                        else
                            format = "#,##0";

                        return (double.Parse(value.ToString(), providerEn) * 100).ToString(format) + "%";

                    }
                }
                else if (OutputType == "currency")
                {
                    return double.Parse(value.ToString(), providerEn).ToString("C");
                }
                else
                {
                    if (Decimals == "")
                    {
                        return double.Parse(value.ToString(), providerEn).ToString();
                    }
                    else
                    {
                        string format = "";
                        for (int j = 0; j < int.Parse(Decimals); j++)
                        {
                            format += "0";
                        }
                        if (format.Length > 0)
                            format = "#,##0." + format;
                        else
                            format = "#,##0";

                        return double.Parse(value.ToString(), providerEn).ToString(format);

                    }
                }
            }
            catch { }
            return value.ToString();
            //return base.GetFieldValueAsText(value);
        }

        public override string GetFieldValueAsHtml(object value)
        {
            return GetFieldValueAsText(value);
        }

        public override void OnAdded(SPAddFieldOptions op)
        {
            this.ShowInEditForm = false;
            this.ShowInNewForm = false;
            base.OnAdded(op);

            Update();

        }

        public override BaseFieldControl FieldRenderingControl
        {
            get
            {
                BaseFieldControl fieldControl = new TotalsRollupFieldControl();
                fieldControl.FieldName = this.InternalName;
                return fieldControl;
            }
        }

    }
}
