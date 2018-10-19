using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore.Helpers;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        private const string RpttsData = "rpttsdata";
        private const string LstMyWorkSnapshot = "lstmyworksnapshot";
        private const string Snapshot = "snapshot";
        private const string LstMyWork = "lstmywork";

        public bool CreateTable(string name, List<ColumnDef> columnDefs, bool dropIfExists, out string message)
        {
            Guard.ArgumentIsNotNull(columnDefs, nameof(columnDefs));

            if (!dropIfExists && TableExists(name))
            {
                message = "Table already exists.";
                return false;
            }

            var columns = new List<string>();

            foreach (var columnDef in columnDefs)
            {
                columns.Add(columnDef.ToString());
            }

            _DAO.Command = PopulateScript(name, columns);

            if (!_DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection))
            {
                message = $"Error creating table: {_DAO.SqlError}";
                return false;
            }

            message = $"Table [{name}] successfully created.";
            return true;
        }

        private static string PopulateScript(string name, List<string> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            Guard.ArgumentIsNotNull(name, nameof(name));

            string script;

            if (name.IndexOf(RpttsData, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                script = $@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{name}]') AND type in (N'U'))
                    DROP TABLE [{name}]
                create table [{name}]({string.Join(", ", columns.ToArray())},
                CONSTRAINT [PK_{name}] 
                PRIMARY KEY CLUSTERED ([rpttsduid] ASC)
                WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
                ALLOW_PAGE_LOCKS  = ON) 
                )ON [PRIMARY]";
            }
            else if (name.Equals(LstMyWorkSnapshot, StringComparison.OrdinalIgnoreCase))
            {
                script = ProcessLstMyWork(name, columns);
            }
            else if (name.IndexOf(Snapshot, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                script = $@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{name}]') AND type in (N'U'))
                    DROP TABLE [{name}]

                create table [{name}]({string.Join(", ", columns.ToArray())},  
                CONSTRAINT [PK_{name}] 
                PRIMARY KEY CLUSTERED ([PeriodId] ASC, [WebId] ASC,[ItemId] ASC)
                WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
                ALLOW_PAGE_LOCKS  = ON) 
                )ON [PRIMARY]
                ALTER TABLE [dbo].[{name}]  WITH NOCHECK ADD  CONSTRAINT [FK_EPM_{name}_RPTPeriod] FOREIGN KEY([PeriodId])
                REFERENCES [dbo].[RPTPeriods] ([PeriodId])
                NOT FOR REPLICATION                
                ALTER TABLE [dbo].[{name}] NOCHECK CONSTRAINT [FK_EPM_{name}_RPTPeriod]
                ";
            }
            else if (name.Equals(LstMyWork, StringComparison.OrdinalIgnoreCase))
            {
                script = ProcessLstMyWork(name, columns);
            }
            else
            {
                script = $@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{name}]') AND type in (N'U'))
                    DROP TABLE [{name}]

                create table [{name}]({string.Join(", ", columns.ToArray())},  
                CONSTRAINT [PK_{name}] 
                PRIMARY KEY CLUSTERED ([WebId] ASC,[ItemId] ASC)
                WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
                ALLOW_PAGE_LOCKS  = ON) 
                )ON [PRIMARY]";
            }

            return script;
        }

        private static string ProcessLstMyWork(string name, List<string> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            Guard.ArgumentIsNotNull(name, nameof(name));

            foreach (var keyValuePair in new Dictionary<string, string>
            {
                { "[WorkType]", "[NVarChar](256) NOT NULL" },
                { "[DataSource]", "[Int] NULL" },
                { "[Commenters]", "[NVarChar](MAX) NULL" },
                { "[CommentersRead]", "[NVarChar](MAX) NULL" },
                { "[CommentCount]", "[Int] NULL" }
            }.Where(col => !columns.Exists(c => c.StartsWith(col.Key, StringComparison.OrdinalIgnoreCase))))
            {
                columns.Add($"{keyValuePair.Key}{keyValuePair.Value}");
            }

            var script = $@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{name}]') AND type in (N'U'))
                    DROP TABLE [{name}]

                create table [{name}]({string.Join(", ", columns.ToArray())})ON [PRIMARY]

                CREATE CLUSTERED INDEX [IX_SiteId_WebId_ListId_ItemId] ON [{name}] 
                (
	                [SiteId] ASC,
	                [WebId] ASC,
	                [ListId] ASC,
	                [ItemId] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, 
                DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
            return script;
        }
    }
}