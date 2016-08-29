using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EPMLiveIntegration
{
    public enum TransactionType { INSERT = 1, UPDATE, DELETE, FAILED };

    public class TransactionTable : DataTable
    {

        public TransactionTable()
        {
            this.Columns.Add("SPID");
            this.Columns.Add("ID");
            this.Columns.Add("TYPE");
        }

        public void AddRow(string SPID, string ID, TransactionType Type)
        {
            this.Rows.Add(new string[] { SPID, ID, ((int)Type).ToString() });
        }
    }
}
